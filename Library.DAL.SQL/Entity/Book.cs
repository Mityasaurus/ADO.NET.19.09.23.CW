using System.ComponentModel.DataAnnotations;

namespace Library.DAL.SQL.Entity
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Number { get; set; }

        public virtual Lending Lending { get; set; }

        public override string ToString()
        {
            return $"Назва - {Name}. Автор - {Author}. Жанр - {Genre}. Кiлькiсть доступних - {Number}";
        }
    }
}
