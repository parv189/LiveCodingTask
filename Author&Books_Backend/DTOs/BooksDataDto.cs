using System.ComponentModel.DataAnnotations;

namespace Author_Books_Backend.DTOs
{
    public class BooksDataDto
    {
        [Key]
        public int BookID { get; set; }
        public string? Bookname { get; set; }
        public int BookPrice { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? AuthorsName { get; set; }
    }
}
