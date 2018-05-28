using System.ComponentModel.DataAnnotations;
using ZyaWeb.Articles.Dtos.LTMAutoMapper;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles.Dtos
{
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
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [MaxLength(ZyaWebConsts.MaxContentLength)]
        public string Content { get; set; }
        public int PersonId { get; set; }
    }
}