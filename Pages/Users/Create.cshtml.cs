using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakerShopPostgreSQL.Data;
using SneakerShopPostgreSQL.Models;
using System.Diagnostics;

namespace SneakerShopPostgreSQL.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly SneakerShopContext _context;
        private readonly ILogger<CreateModel> _logger;
        public CreateModel(SneakerShopContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.User User { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (User == null)
            {
                return Page();
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            User.Password = PasswordHasher.Hash(User.Password);
            _context.User.Add(User);
            await _context.SaveChangesAsync();
            stopwatch.Stop();
            _logger.LogInformation("User Create Time: {0}", stopwatch.ElapsedMilliseconds);
            if (HttpContext.Session.GetString("Email") == "admin@sneakershop.com")
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToPage("./Login");
            }
        }
    }
}
