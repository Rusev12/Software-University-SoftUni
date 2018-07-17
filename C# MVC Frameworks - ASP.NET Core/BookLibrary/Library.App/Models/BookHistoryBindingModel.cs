namespace Library.App.Models
{
    using Library.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookHistoryBindingModel
    {
        [Required]
        public DateTime DateOfBorrowed { get; set; }

        public Book Book { get; set; }
    }
}
