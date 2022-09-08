using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetRedLineAG.Models
{
    public class PersonSentModelDTO
    {         
        public int ApplicationId { get; set; }
        public int PersonId { get; set; }    
    }
}
