namespace LibraryApp.Business.Abstract.Dtos
{
    public class BookWithAuthorDto : BookDto
    {
        public AuthorDto Author { get; set; }
    }
}