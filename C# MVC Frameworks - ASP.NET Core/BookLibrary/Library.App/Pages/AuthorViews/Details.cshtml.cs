namespace Library.App.Pages.AuthorViews
{
    using System.Linq;
    using Library.App.Models;
    using Library.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class DetailsModel : BasePageModel
    {
        public DetailsModel(LibraryDbContext context) : base(context)
        {
        }

        public Library.Models.Author Author { get; set; }

        public IActionResult OnGet(int id)
        {
            this.Author = this.Context.Authors.Include(b => b.Books).Where(b => b.Id == id).FirstOrDefault();


            return this.Page();
        }

    }
}