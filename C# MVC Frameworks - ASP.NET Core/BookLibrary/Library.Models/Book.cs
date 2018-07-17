namespace Library.Models
{
    using System;
    using System.Collections.Generic;

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }

        public string Status { get; set; } = "At home";
        
        public string CoverImageUrl { get; set; }

        public Borrower Borrower { get; set; }

        public int BorrowerId { get; set; }

        public ICollection<BookHistory> bookHistories = new List<BookHistory>();
    }
}
