using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.ContentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Note;

public class SubjectDetailModel(IContentService contentService) : PageModel
{
    [BindProperty]
    public GetContentDto? Content { get; set; }

    [BindProperty]
    public CreateContentDto CreateContent { get; set; } = new();

    public async Task OnGetAsync(string id)
    {
        CreateContent.SubjectId = id;
        Content = await contentService.GetSubjectContentBySubjectIdAsync(id);
    }

    public async Task<IActionResult> OnPostCreateContent()
    {
        await contentService.CreateContentAsync(CreateContent);
        return RedirectToPage("/Note/Index");
    }
}
