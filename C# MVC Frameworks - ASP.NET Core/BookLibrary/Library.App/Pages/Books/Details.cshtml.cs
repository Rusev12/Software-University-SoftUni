namespace Library.App.Pages
{
    using Library.App.Models;
    using Library.Data;
    using Library.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class DetailsModel : BasePageModel
    {
        public DetailsModel(LibraryDbContext context)
            : base(context)
        {
        }

        public Book Book { get; set; }

        public IActionResult OnGet(int id)
        {
            this.Book = this.Context
                .Books
                .Include(b => b.Author)
                .Where(b => b.Id == id)
                .FirstOrDefault();


            return this.Page();
        }

    


    }
}