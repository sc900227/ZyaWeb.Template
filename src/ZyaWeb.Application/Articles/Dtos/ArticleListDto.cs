using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using ZyaWeb.Articles.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles.Dtos
{
    public class ArticleListDto : FullAuditedEntityDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        [Description("文章标题")]
        public string Title { get; set; }
        [Description("文章内容")]
        public string Content { get; set; }
        [Description("人员Id")]
        public int PersonId { get; set; }
    }
}