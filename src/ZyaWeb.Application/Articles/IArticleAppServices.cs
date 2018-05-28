using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ZyaWeb.Articles.Dtos;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles
{
    /// <summary>
    /// Article应用层服务的接口方法
    /// </summary>
    public interface IArticleAppService : IApplicationService
    {
        /// <summary>
        /// 获取Article的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ArticleListDto>> GetPagedArticles(GetArticlesInput input);

        /// <summary>
        /// 通过指定id获取ArticleListDto信息
        /// </summary>
        Task<ArticleListDto> GetArticleByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出Article为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetArticlesToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetArticleForEditOutput> GetArticleForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetArticleForEditOutput
        /// <summary>
        /// 添加或者修改Article的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateArticle(CreateOrUpdateArticleInput input);

        /// <summary>
        /// 删除Article信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteArticle(EntityDto<int> input);

        /// <summary>
        /// 批量删除Article
        /// </summary>
        Task BatchDeleteArticlesAsync(List<int> input);
    }
}
