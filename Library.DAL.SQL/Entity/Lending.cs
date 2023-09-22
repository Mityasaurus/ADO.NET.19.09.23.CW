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

        public int UserID { get; set; }
        public int BookID { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return $"Користувач - {User}\nКнига - {Book}\nДата видачі - {IssueDate.ToShortDateString()}. Очікувана дата повернення - {DueDate.ToShortDateString()}";
        }
    }
}
