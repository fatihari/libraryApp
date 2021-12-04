namespace LibraryApp.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Literature { get; set; }
        public virtual Publisher Publisher { get; set; } // EF will track changes using inherit via the Publisher class. 
    }
}