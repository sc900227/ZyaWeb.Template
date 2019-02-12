using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.PersonArticles.Persons
{
    /// <summary>
    /// 人员信息表
    /// </summary>
    [Table("Person")]
    public class Person: FullAuditedEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        [EmailAddress]
        [MaxLength(ZyaWebConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 文章导航属性
        /// </summary>
        public ICollection<Article> Articles { get; set; }
    }
}
