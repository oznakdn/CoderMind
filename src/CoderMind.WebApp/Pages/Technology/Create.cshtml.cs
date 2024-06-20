using AspNetCoreHero.ToastNotification.Abstractions;
using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Shared.Dtos.TechnologyDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Technology;

public class CreateModel(IEfTechnologyService technologyService,INotyfService notyfService) : PageModel
{

    [BindProperty]
    public CreateTechnologyDto CreateTechnology { get; set; }
    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostCreateTechnology()
    {
        if(!ModelState.IsValid)
        {
            return Page();
        }
        await technologyService.CreateTechnologyAsync(CreateTechnology);
        notyfService.Success("Technology created successfully");
        return RedirectToPage("/Index");
    }

}
