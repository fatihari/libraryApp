using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Business.Abstract.Dtos
{
    public class AuthorDto
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}