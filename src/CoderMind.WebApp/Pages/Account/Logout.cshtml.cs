using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoderMind.WebApp.Pages.Account;

public class LogoutModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly INotyfService _notyfService;

    public LogoutModel(SignInManager<IdentityUser> signInManager, INotyfService notyfService)
    {
        _signInManager = signInManager;
        _notyfService = notyfService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await _signInManager.SignOutAsync();
        _notyfService.Success("Logout successful");
        return RedirectToPage("/account/login");
    }
}
