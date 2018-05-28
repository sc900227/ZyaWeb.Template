﻿using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles.DomainServices
{
    /// <summary>
    /// Article领域层的业务管理
    /// </summary>
    public class ArticleManager : ZyaWebDomainServiceBase, IArticleManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Article, int> _articleRepository;
        /// <summary>
        /// Article的构造方法
        /// </summary>
        public ArticleManager(IRepository<Article, int> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitArticle()
        {
            throw new NotImplementedException();
        }

    }

}
