using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetRedLineAG.Models
{
    public class ApplicationModel
    {
        public ApplicationModel()
        {

            TimeApplication = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            EntrepriseId = 1;

        }

        [Key]
        public int ApplicationId { get; set; }
        public string TitleApplication { get; set; }
        public string StatusApplication { get; set; }
        public string CommentsApplication { get; set; }
        public string ExternalLinkApplication { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd-MM-yyyy")]
        public DateTime TimeApplication { get; set; }


        public int EntrepriseId { get; set; }
        
        public EntrepriseModel Entreprise { get; set; }
        
        //public ICollection<PersonModel>Person { get; set; }

        public ICollection<DocumentSentModel> DocumentSent { get; set; }

        public ICollection<PersonSentModel> PersonSent { get; set; }


    }
}
