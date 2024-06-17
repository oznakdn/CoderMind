using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.SubjectDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Note;

public class SubjectModel(ISubjectService subjectService) : PageModel
{

    [BindProperty]
    public CreateSubjectDto CreateSubject { get; set; } = new();


    public void OnGet(string technologyId)
    {
        CreateSubject.TechnologyId = technologyId;
    }

    public async Task<IActionResult> OnPostCreateSubject(CancellationToken cancellationToken)
    {
        await subjectService.CreateSubjectAsync(CreateSubject, cancellationToken);
        return RedirectToPage("/Index");
    }
   
}
