using AspNetCoreHero.ToastNotification.Abstractions;
using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.ContentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Content;

public class UpdateModel(IEfContentService contentService, IEfSubjectService subjectService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public UpdateContentDto UpdateContent { get; set; }

    public async Task OnGet(string id)
    {
        var content = await contentService.GetContentAsync(id);

        UpdateContent = new UpdateContentDto
        {
            Id = content.Id,
            Text = content.Text,
            Files = content.Files == null ? null : string.Join(",", content.Files),
            Links = content.Links == null ? null : string.Join(" ,", content.Links)
        };

        var subject = await subjectService.GetSubjectAsync(content.SubjectTitle);
        ViewData["SubjectTitle"] = subject.Title;

    }

    public async Task<IActionResult>OnPost()
    {
        if(string.IsNullOrWhiteSpace(UpdateContent.Text))
        {
            notyfService.Error("Text is required");
            return Page();
        }

        await contentService.UpdateContentAsync(UpdateContent);
        notyfService.Success("Content updated successfully");
        return RedirectToPage("/Index");
    }
}
