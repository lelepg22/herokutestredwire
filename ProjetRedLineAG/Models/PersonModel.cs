using System.Text.Json.Serialization;

namespace ProjetRedLineAG.Models
{
    public class PersonModel
    {

        public PersonModel()
        {
            EntrepriseId = 1;
            ApplicationId = 1;
            StatutId = 1;
        }
        public int Id { get; set; }
        public string LastNamePerson { get; set; }
        public string FirstNamePerson { get; set; }        
        public string TelPerson { get; set; }
        public string EmailPerson { get; set; }
        public string CommentsPerson { get; set; }
       
        public int EntrepriseId { get; set; }
        
        public EntrepriseModel Entreprise { get; set; }

        public int StatutId { get; set; }
        [JsonIgnore]

        public StatutModel Statut { get; set; }


        public int? ApplicationId { get; set; }
      

      
    }
}
