using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetRedLineAG.Models
{
    public class PersonSentModel
    {
        [Key]
        public int Id { get; set; }        
        public int ApplicationId { get; set; }

        [JsonIgnore]
        public ApplicationModel Application { get; set; }


        public int PersonId { get; set; }
        public ICollection<PersonModel> Person { get; set; }
    }
}
