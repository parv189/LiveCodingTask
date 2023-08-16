using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Author_Books_Backend.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string ? Bookname { get; set; }
        public int BookPrice { get; set; }
        public DateTime PublicationDate { get; set; }
        [ForeignKey("AuthorBook")]
        public int AuthorBookId { get; set; }
        public virtual AuthorBook? AuthorBook { get; set; }

    }
}
