using CoderMind.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoderMind.WebApp.Components;

public class TechnologySubjectsViewComponent(ITechnologyService technologyService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await technologyService.GetTechnologySubjectsAsync();
        return View(result);
    }
}
