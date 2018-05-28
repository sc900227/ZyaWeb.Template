using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles.Dtos
{
    [AutoMapTo(typeof(Article))]
    public class ArticleDto
    {
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
    }
}
