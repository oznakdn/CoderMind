using AspNetCoreHero.ToastNotification.Abstractions;
using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Shared.Dtos.SubjectDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Subject;

public class CreateModel(IEfSubjectService subjectService, IEfTechnologyService technologyService,INotyfService notyfService) : PageModel
{
    [BindProperty]
    public CreateSubjectDto CreateSubject { get; set; } = new();

    public async Task OnGet(string technologyId)
    {
        CreateSubject.TechnologyId = technologyId;
        var tehnology = await technologyService.GetTechnologyAsync(technologyId);
        ViewData["TechnologyName"] = tehnology.Name;
    }

    public async Task<IActionResult> OnPostCreateSubject(CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid)
            return Page();

        await subjectService.CreateSubjectAsync(CreateSubject, cancellationToken);
        notyfService.Success("Subject created successfully");
        return RedirectToPage("/Index");
    }
}
