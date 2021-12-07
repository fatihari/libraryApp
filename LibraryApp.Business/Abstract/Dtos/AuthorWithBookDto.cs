namespace LibraryApp.Business.Abstract.Dtos
{
    public class AuthorWithBookDto : AuthorDto
    {
        public ICollection<BookDto> Books { get; set; }
    }
}