using AspNetCoreHero.ToastNotification.Abstractions;
using CoderMind.Shared.Dtos.AccountDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Account;

public class LoginModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private INotyfService _notyfService;

    public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, INotyfService notyfService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _notyfService = notyfService;
    }

    [BindProperty]
    public LoginDto LoginInput { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userManager.FindByEmailAsync(LoginInput.Email);

        if (user == null)
        {
            _notyfService.Error("Invalid user credentials!");
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(user, LoginInput.Password, false, false);

        if (!result.Succeeded)
        {
            _notyfService.Error("Invalid user credentials!");
            return Page();
        }

        _notyfService.Success("Login successful!");
        return RedirectToPage("/Index");

    }
}
