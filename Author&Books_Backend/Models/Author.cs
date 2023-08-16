using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Author_Books_Backend.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; } 
        public string ? AuthorName { get; set; }
        [ForeignKey("AuthorBook")]
        public int AuthorBookId { get; set; }
        public virtual AuthorBook ? AuthorBook { get; set; }  

    }
}
