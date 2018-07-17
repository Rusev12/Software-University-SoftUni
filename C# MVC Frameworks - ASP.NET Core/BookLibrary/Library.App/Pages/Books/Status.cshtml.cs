namespace Library.App.Pages.Books
{
    using Library.App.Models;
    using Library.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class StatusModel : BasePageModel
    {
        public StatusModel(LibraryDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<BookHistoryStatusViewModel> AllDatesOfBorrow { get; set; }

        public BookDetailsStatusViewModel BookInfo { get; set; }

        public void OnGet(int id)
        {
            var dates = this.Context
                .BookHistories
                .Where(bh => bh.BookId == id)
                .Select(bh => 
                new BookHistoryStatusViewModel()
                 {
                    DateOfBorrowed = bh.DateOfBorrowed
                 })
                .ToArray();

            this.AllDatesOfBorrow = dates;


            var bookInfo = this.Context.Books.Where(b => b.Id == id)
                .Select(b => new BookDetailsStatusViewModel()
                {
                    Title = b.Title,
                    CoverImageUrl = b.CoverImageUrl
                })
                .FirstOrDefault();


            this.BookInfo = bookInfo;


        }
    }
}