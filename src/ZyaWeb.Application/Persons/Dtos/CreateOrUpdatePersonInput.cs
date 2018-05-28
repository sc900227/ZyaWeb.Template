using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZyaWeb.PersonArticles.Persons;

namespace ZyaWeb.Persons.Dtos
{
    public class CreateOrUpdatePersonInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public PersonEditDto Person { get; set; }

}
}