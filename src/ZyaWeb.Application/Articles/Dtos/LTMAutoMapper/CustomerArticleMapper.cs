using AutoMapper;

namespace ZyaWeb.Articles.Dtos.LTMAutoMapper
{
    using ZyaWeb.PersonArticles.Articles;

    /// <summary>
    /// 配置Article的AutoMapper
    /// </summary>
    internal static class CustomerArticleMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <Article, ArticleDto>();
            configuration.CreateMap<Article, ArticleListDto>();
            configuration.CreateMap<ArticleEditDto, Article>();
            configuration.CreateMap<ArticleDto, Article>();
            // configuration.CreateMap<CreateArticleInput, Article>();
            //        configuration.CreateMap<Article, GetArticleForEditOutput>();
        }
    }
}