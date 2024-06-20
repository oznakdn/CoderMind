using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.TechnologyDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Technology;

public class DetailModel(IEfTechnologyService technologyService) : PageModel
{
    [BindProperty]
    public GetTechnologyDto TechnologyDto { get; set; }

    public async Task OnGet(string technologyId)
    {
        TechnologyDto = await technologyService.GetTechnologyAsync(technologyId);
    }

    public async Task<IActionResult> OnPostDeleteTechnology(string technologyId)
    {
        await technologyService.DeleteTechnologyAsync(technologyId);
        return RedirectToPage("/Index");
    }
}
