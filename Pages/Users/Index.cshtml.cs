using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SneakerShopPostgreSQL.Data;
using SneakerShopPostgreSQL.Models;

namespace SneakerShopPostgreSQL.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly SneakerShopContext _context;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(SneakerShopContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Models.User> User { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                User = await _context.User.ToListAsync();
                stopwatch.Stop();
                _logger.LogInformation("User Index Time: {0}", stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
