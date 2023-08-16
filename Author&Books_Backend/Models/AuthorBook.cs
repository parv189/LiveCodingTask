namespace Author_Books_Backend.Models
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }   
        public int BookId { get; set; }

        public virtual ICollection<Author>? Authors { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
