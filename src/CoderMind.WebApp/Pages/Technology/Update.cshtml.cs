using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.TechnologyDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Technology;

public class UpdateModel(ITechnologyService technologyService) : PageModel
{
    [BindProperty]
    public UpdateTechnologyDto UpdateTechnology { get; set; }

    public async Task OnGet(string technologyId)
    {
        var technology = await technologyService.GetTechnologyAsync(technologyId);
        UpdateTechnology = new UpdateTechnologyDto
        {
            Id = technology.Id,
            Name = technology.Name,
            Logo = technology.Logo,
            Description = technology.Description
        };
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            await technologyService.UpdateTechnologyAsync(UpdateTechnology);
            return RedirectToPage("/Index");
        }
        return Page();
    }
}
