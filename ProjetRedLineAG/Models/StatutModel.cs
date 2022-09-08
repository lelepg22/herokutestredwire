using System.ComponentModel.DataAnnotations;

namespace ProjetRedLineAG.Models
{
    public class StatutModel
    {
        [Key]
        public int StatutId { get; set; }
        public string TitleStatut { get; set; }
    }
}
