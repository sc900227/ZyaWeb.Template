using System;
using Abp.Application.Services.Dto;
using ZyaWeb.Persons.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Persons;
using System.Collections.Generic;
using ZyaWeb.Articles.Dtos;
using System.ComponentModel;

namespace ZyaWeb.Persons.Dtos
{
    public class PersonListDto : FullAuditedEntityDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        [Description("姓名")]
        public string Name { get; set; }
        [Description("邮箱")]
        public string EmailAddress { get; set; }
        [Description("电话号码")]
        public string PhoneNumber { get; set; }
        public IEnumerable<ArticleEditDto> Articles { get; set; }
    }
}