using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZyaWeb.PersonArticles.Persons;

namespace ZyaWeb.PersonArticles.PhoneNumbers
{
    public class PhoneNumber: FullAuditedEntity
    {
        [Required]
        [Description("电话号码")]
        public string Phone { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
