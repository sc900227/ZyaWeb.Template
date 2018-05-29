using System.ComponentModel.DataAnnotations;
using ZyaWeb.Persons.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Persons;
using System.Collections.Generic;
using ZyaWeb.Articles.Dtos;
using System.ComponentModel;
using Abp.AutoMapper;

namespace ZyaWeb.Persons.Dtos
{
    [AutoMapTo(typeof(Person))]
    public class PersonEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [Description("姓名")]
        public string Name { get; set; }
        [MaxLength(ZyaWebConsts.MaxEmailAddressLength)]
        [Description("邮箱")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        [Description("电话号码")]
        public string PhoneNumber { get; set; }
        public IEnumerable<ArticleEditDto> Articles { get; set; }
    }
}