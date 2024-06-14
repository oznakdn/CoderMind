using CoderMind.Application.Services.Interfaces;
using CoderMind.Shared.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages;

public class RegisterModel(IUserService userService) : PageModel
{
    [BindProperty]
    public RegisterDto RegisterDto { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var result = await userService.Register(RegisterDto);
        if (!result.IsSuccess)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            return Page();
        }

        return RedirectToPage("/Index");
    }
}
