﻿using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ZyaWeb.Articles.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles.Dtos
{
    [AutoMapTo(typeof(Article))]
    public class ArticleEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(ZyaWebConsts.MaxTitleLength)]
        [Description("文章标题")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [MaxLength(ZyaWebConsts.MaxContentLength)]
        [Description("文章内容")]
        public string Content { get; set; }
        
        public int PersonId { get; set; }
    }
}