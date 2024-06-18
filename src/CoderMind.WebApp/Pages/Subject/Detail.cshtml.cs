using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.ContentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Subject;

public class DetailModel(IContentService contentService, ISubjectService subjectService) : PageModel
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
        await contentService.CreateContentAsync(CreateContent);
        return RedirectToPage("/Index");
    }

    public async Task<IActionResult> OnPostDeleteSubject(string subjectId)
    {
        await subjectService.DeleteSubjectAsync(subjectId);
        return RedirectToPage("/Index");
    }
}
