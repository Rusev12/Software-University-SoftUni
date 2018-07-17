namespace Library.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfBorrowed { get; set; }

        public DateTime? DateOfReturning { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }
    }
}
