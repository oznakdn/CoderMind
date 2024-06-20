using AspNetCoreHero.ToastNotification.Abstractions;
using CoderMind.Shared.Dtos.AccountDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Account;

public class RegisterModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly INotyfService _notyfService;

    public RegisterModel(UserManager<IdentityUser> userManager, INotyfService notyfService)
    {
        _userManager = userManager;
        _notyfService = notyfService;
    }

    [BindProperty]
    public RegisterDto RegisterInput { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = new IdentityUser
        {
            UserName = RegisterInput.Email,
            Email = RegisterInput.Email
        };

        var result = await _userManager.CreateAsync(user, RegisterInput.Password);


        if (!result.Succeeded)
        {
            _notyfService.Error("Invalid user credentials!");
            return Page();
        }


        _notyfService.Success("Register successful!");
        return RedirectToPage("/account/login");

    }
}
