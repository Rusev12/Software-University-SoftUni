namespace Library.App.Pages.Books
{
    using Library.App.Models;
    using Library.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Library.Models;

    public class BorrowModel : BasePageModel
    {
        public BorrowModel(LibraryDbContext context) 
            : base(context)
        {
            this.AllBorrowers = new List<string>();
        }

        [BindProperty]
        public DateTime StartDate { get; set; } = DateTime.Now;


        [BindProperty]
        public DateTime? EndDate { get; set; } = DateTime.Now;

        public IEnumerable<string> AllBorrowers;

        [BindProperty]
        public string NameOfBorrower { get; set; }


        public void OnGet()
        {
            var allBorrowers = this.Context.Borrowers.Select(b => b.Name).ToArray();

            this.AllBorrowers = allBorrowers;


        }

        public IActionResult OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var book = this.Context.Books.Where(b => b.Id == id).FirstOrDefault();
            var borrower = this.Context.Borrowers.Where(br => br.Name == this.NameOfBorrower).FirstOrDefault();

            var history = new BookHistoryBindingModel()
            {
                DateOfBorrowed = this.StartDate,
                Book = book
            };

            this.Context.BookHistories.Add(new BookHistory()
            {
                Book = history.Book,
                DateOfBorrowed = history.DateOfBorrowed,
            });

            book.Borrower = borrower;
            borrower.Books.Add(book);
            book.Status = "Borrowed";

            this.Context.SaveChanges();


            return this.RedirectToPage("/Index");
        }
    }
}