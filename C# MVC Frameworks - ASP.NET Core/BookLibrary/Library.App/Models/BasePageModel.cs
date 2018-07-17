namespace Library.App.Models
{
    using Library.Data;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class BasePageModel : PageModel
    {
        public BasePageModel(LibraryDbContext context)
        {
            this.Context = context;
        }
        
        public LibraryDbContext Context { get; set; }
    }
}
