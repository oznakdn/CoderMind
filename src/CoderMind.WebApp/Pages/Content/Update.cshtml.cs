using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.ContentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Content;

public class UpdateModel(IContentService contentService) : PageModel
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

    }

    public async Task<IActionResult>OnPost()
    {
        await contentService.UpdateContentAsync(UpdateContent);
        return RedirectToPage("/Index");
    }
}
