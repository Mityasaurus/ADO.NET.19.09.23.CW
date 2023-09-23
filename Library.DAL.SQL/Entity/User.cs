using System.ComponentModel.DataAnnotations;

namespace Library.DAL.SQL.Entity
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }

        public virtual IEnumerable<Lending> Lendings { get; set; } = new List<Lending>();

        public override string ToString()
        {
            return $"Повне iм'я - {Name} {LastName}. Номер телефону - {Phone}";
        }
    }
}
