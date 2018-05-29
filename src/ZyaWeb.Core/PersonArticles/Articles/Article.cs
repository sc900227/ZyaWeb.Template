using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZyaWeb.PersonArticles.Persons;

namespace ZyaWeb.PersonArticles.Articles
{
    /// <summary>
    /// 文章表
    /// </summary>
    public class Article: FullAuditedEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(ZyaWebConsts.MaxTitleLength)]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [MaxLength(ZyaWebConsts.MaxContentLength)]
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PersonId { get; set; }
        public Person Person { get; set; }
        

    }
}
