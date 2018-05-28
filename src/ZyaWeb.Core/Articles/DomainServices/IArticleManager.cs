using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles.DomainServices
{
    public interface IArticleManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitArticle();

    }
}
