using System.ComponentModel.DataAnnotations;

namespace Library.DAL.SQL.Entity
{
    public class Lending
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
