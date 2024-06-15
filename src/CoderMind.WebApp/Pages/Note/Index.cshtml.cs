using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.TechnologyDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Note;

public class IndexModel(ITechnologyService technologyService) : PageModel
{
    [BindProperty]
    public CreateTechnologyDto CreateTechnology { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult>OnPostCreateTechnology()
    {
        await technologyService.CreateTechnologyAsync(CreateTechnology);
        return RedirectToPage("/Note/Index");
    }
}
