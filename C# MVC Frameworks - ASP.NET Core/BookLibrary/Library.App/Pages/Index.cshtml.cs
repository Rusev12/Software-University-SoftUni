namespace Library.App.Pages
{
    using Library.Data;
    using Library.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IndexModel : PageModel
    {
        private readonly LibraryDbContext _context;

        public IndexModel(LibraryDbContext context)
        {
            this._context = context;
        }

        public ICollection<Book> Books { get; set; }


        public void OnGet()
        {
            var books = this._context.Books.Include(b => b.Author).ToList();

            this.Books = books;
        }

        public IActionResult OnGetReturn(int id)
        {
            var book = this._context
                .Books
                .Where(b => b.Id == id)
                .FirstOrDefault();

            book.Status = "At home";
            book.BorrowerId = 0;
            this._context.SaveChanges();

            this.OnGet();

            return this.Page();
        }

      
    }
}
