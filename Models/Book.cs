using System.ComponentModel.DataAnnotations;

namespace LibraryMgmtCFA.Models
{
    public class Book
    {
        [Key]
        public int bookid { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        public string description { get; set; }
        public string bookimg { get; set; }
        [Required]
        public string genre { get; set; }
        public long isbn { get; set; }
        public DateTime publishdate { get; set; }
        public string publisher { get; set; }
        public int totalcopies { get; set; }
    }
}
