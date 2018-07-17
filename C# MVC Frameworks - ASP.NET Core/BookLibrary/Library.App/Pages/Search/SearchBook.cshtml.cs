namespace Library.App.Pages.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using Library.App.Models;
    using Library.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class SearchBookModel : BasePageModel
    {
        public SearchBookModel(LibraryDbContext context)
            : base(context)
        {
        }
        
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public ICollection<SearchBookViewModel> SearchingBooks { get; set; }


        [BindProperty(SupportsGet = true)]
        public ICollection<SearchAuthorViewModel> SearchingAuthors { get; set; }

        public void OnGet()
        {
            var books =  this.Context.Books.Include(b => b.Author)               
                .ToArray();

            foreach (var book in books)
            {
                if (book.Title.Contains(this.searchString))
                {
                    SearchingBooks.Add(new SearchBookViewModel() {
                        Title = book.Title ,
                    });
                }

                if (book.Author.Name.Contains(this.searchString))
                {
                    SearchingAuthors.Add(new SearchAuthorViewModel()
                    {
                        AuthorName = book.Author.Name
                    });
                }
            }
            
        }
    }
}