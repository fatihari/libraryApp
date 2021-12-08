using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Business.Abstract.Dtos
{
    public class BookDto
    {  
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} field is not empty!")] // placeholder (0) is equal to "Title"..
        public string Title { get; set; }
        [Range(-9999, 2100, ErrorMessage = "{0} is not a valid year! ")] 
        public int Year { get; set; }
        [Required(ErrorMessage ="{0} field is not empty!")] // placeholder (0) is equal to "Literature"..
        public string Literature { get; set; }
        public int AuthorId { get; set; }
    }
}