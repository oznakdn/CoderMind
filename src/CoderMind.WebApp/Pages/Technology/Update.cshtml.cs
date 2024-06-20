using AspNetCoreHero.ToastNotification.Abstractions;
using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Shared.Dtos.TechnologyDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Technology;

public class UpdateModel(IEfTechnologyService technologyService,INotyfService notyfService) : PageModel
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
        ViewData["TechnologyName"] = technology.Name;
    }

    public async Task<IActionResult> OnPost()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }

        await technologyService.UpdateTechnologyAsync(UpdateTechnology);
        notyfService.Success("Technology updated successfully");
        return RedirectToPage("/Index");
    }
}
