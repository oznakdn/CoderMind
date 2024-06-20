using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.SubjectDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Subject;

public class UpdateModel(IEfSubjectService subjectService) : PageModel
{

    [BindProperty]
    public UpdateSubjectDto UpdateSubject { get; set; }

    public async Task OnGet(string id)
    {
        var subject = await subjectService.GetSubjectAsync(id);
        UpdateSubject = new UpdateSubjectDto
        {
            Id = subject.SubjectId,
            Title = subject.Title,
            Tags = subject.Tags == null ? null : string.Join(",", subject.Tags)
        };

        ViewData["SubjectTitle"] = subject.Title;
    }

    public async Task<IActionResult>OnPost()
    {
        await subjectService.UpdateSubjectAsync(UpdateSubject);
        return RedirectToPage("/Index");
    }

}
