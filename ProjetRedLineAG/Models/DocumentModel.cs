using System.ComponentModel.DataAnnotations;

namespace ProjetRedLineAG.Models
{
    public class DocumentModel
    {
        [Key]
        public int DocumentId { get; set; }
        public string TitleDocument { get; set; }
    }
}
