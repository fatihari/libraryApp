namespace LibraryApp.Business.Abstract.Dtos
{
    public class BookDto
    {  
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Literature { get; set; }
        public int AuthorId { get; set; }
    }
}