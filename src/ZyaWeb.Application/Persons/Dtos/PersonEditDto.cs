using System.ComponentModel.DataAnnotations;
using ZyaWeb.Persons.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Persons;
using System.Collections.Generic;
using ZyaWeb.Articles.Dtos;

namespace ZyaWeb.Persons.Dtos
{
    public class PersonEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; }
        [MaxLength(ZyaWebConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public IEnumerable<ArticleEditDto> Articles { get; set; }
    }
}