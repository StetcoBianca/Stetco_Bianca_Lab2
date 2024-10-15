using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stetco_Bianca_Lab2.Data;
using Stetco_Bianca_Lab2.Models;

namespace Stetco_Bianca_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Stetco_Bianca_Lab2.Data.Stetco_Bianca_Lab2Context _context;

        public IndexModel(Stetco_Bianca_Lab2.Data.Stetco_Bianca_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public IList<Authors> Authors { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Book = await _context.Book
                    .Include(b => b.Publisher)
                    .ToListAsync();

                // Dacă dorești să încarci și autorii, de exemplu:
                // Authors = await _context.Authors.ToListAsync();
            }
            catch (Exception ex)
            {
                // Gestionare simplă a erorilor
                // Poți salva mesajul de eroare sau loga în consola, etc.
                Console.WriteLine($"A apărut o eroare: {ex.Message}");
                // Poți decide să afișezi un mesaj de eroare în UI
            }
        }
    }
}
