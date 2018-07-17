namespace Library.App.Pages
{
    using Library.Data;
    using Library.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CreateModel : PageModel
    {
        private readonly LibraryDbContext _context;

        public CreateModel(LibraryDbContext context)
        {
            this._context = context;
        }


        [BindProperty]
        public string Title { get; set; }


        [BindProperty]
        public Author Author { get; set; }

        [BindProperty]
        public string Description { get; set; }


        [BindProperty]
        public string ImageUrl { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var book = new Book()
            {
                Title = this.Title,
                Author = this.Author,
                AuthorId = this.Author.Id,
                ShortDescription = this.Description,
                CoverImageUrl = this.ImageUrl
            };
            this._context.Books.Add(book);
            this._context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}