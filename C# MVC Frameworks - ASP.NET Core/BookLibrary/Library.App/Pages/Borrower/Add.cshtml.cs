using Library.App.Models;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.App.Pages.Borrower
{
    public class AddModel : BasePageModel
    {
        public AddModel(LibraryDbContext context) 
            : base(context)
        {
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Address { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            this.Context.Borrowers.Add(new Library.Models.Borrower()
            {
                Name = this.Name,
                Address = this.Address
            });

            this.Context.SaveChanges();

            return this.RedirectToPage("/Index");
        }
    }
}