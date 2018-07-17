using System.Collections.Generic;

namespace Library.Models
{
    public class Borrower
    {
        public Borrower()
        {
            this.Books = new List<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
