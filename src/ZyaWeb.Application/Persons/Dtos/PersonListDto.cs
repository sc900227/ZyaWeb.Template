using System;
using Abp.Application.Services.Dto;
using ZyaWeb.Persons.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Persons;
using System.Collections.Generic;
using ZyaWeb.Articles.Dtos;

namespace ZyaWeb.Persons.Dtos
{
    public class PersonListDto : FullAuditedEntityDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<ArticleListDto> Articles { get; set; }
    }
}