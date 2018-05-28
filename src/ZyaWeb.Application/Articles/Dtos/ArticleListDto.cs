using System;
using Abp.Application.Services.Dto;
using ZyaWeb.Articles.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles.Dtos
{
    public class ArticleListDto : FullAuditedEntityDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Title { get; set; }
        public string Content { get; set; }
        public int PersonId { get; set; }
    }
}