using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetRedLineAG.Models
{
    public class DocumentSentModel
    {
        [Key]
        public int Id { get; set; }        
        public int ApplicationId { get; set; }

        [JsonIgnore]
        public ApplicationModel Application { get; set; }


        public int DocumentId { get; set; }
        public ICollection<DocumentModel> Document { get; set; }
    }
}
