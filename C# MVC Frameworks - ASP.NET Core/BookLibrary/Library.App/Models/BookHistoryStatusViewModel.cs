namespace Library.App.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookHistoryStatusViewModel
    {
        [Required]
        public DateTime DateOfBorrowed { get; set; }
    }
}
