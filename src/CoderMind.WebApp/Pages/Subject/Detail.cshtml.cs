using AspNetCoreHero.ToastNotification.Abstractions;
using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Shared.Dtos.ContentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Subject;

public class DetailModel(IEfContentService contentService, IEfSubjectService subjectService,INotyfService notyfService) : PageModel
{
    [BindProperty]
    public GetContentDto? Content { get; set; }

    [BindProperty]
    public CreateContentDto CreateContent { get; set; } = new();

    [BindProperty]
    public string SubjectId { get; set; }

    public async Task OnGetAsync(string id)
    {
        CreateContent.SubjectId = id;
        var subject = await subjectService.GetSubjectAsync(id);
        ViewData["SubjectTitle"] = subject.Title;
        SubjectId = id;
        Content = await contentService.GetSubjectContentBySubjectIdAsync(id);
    }

    public async Task<IActionResult> OnPostCreateContent()
    {
        if (string.IsNullOrWhiteSpace(CreateContent.Text))
        {
            notyfService.Warning("Content text is required!");
            return Page();
        }

        await contentService.CreateContentAsync(CreateContent);
        notyfService.Success("Content created successfully!");
        return RedirectToPage("/Index");
    }

    public async Task<IActionResult> OnPostDeleteSubject(string subjectId)
    {
        await subjectService.DeleteSubjectAsync(subjectId);
        notyfService.Success("Subject deleted successfully!");
        return RedirectToPage("/Index");
    }
}
