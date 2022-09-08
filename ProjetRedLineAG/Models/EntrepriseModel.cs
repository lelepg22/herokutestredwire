using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetRedLineAG.Models
{
    public class EntrepriseModel
    {
        [Key]
        public int EntrepriseId { get; set; }
        public string TitleEntreprise { get; set; }
        public string CommentsEntreprise { get; set; }
        public string LinkEntreprise { get; set; }
        public string TelEntreprise { get; set; }
        public string EmailEntreprise { get; set; }


       [JsonIgnore]
        public PersonModel Person { get; set; }

    }
}
