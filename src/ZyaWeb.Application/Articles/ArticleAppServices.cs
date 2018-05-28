using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using ZyaWeb.Articles.Authorization;
using ZyaWeb.Articles.Dtos;
using ZyaWeb.Articles.DomainServices;
using ZyaWeb.PersonArticles.Articles;

namespace ZyaWeb.Articles
{
    /// <summary>
    /// Article应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(ArticleAppPermissions.Article)]
    public class ArticleAppService : ZyaWebAppServiceBase, IArticleAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Article, int> _articleRepository;
        private readonly IArticleManager _articleManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleAppService(IRepository<Article, int> articleRepository
      , IArticleManager articleManager
        )
        {
            _articleRepository = articleRepository;
            _articleManager = articleManager;
        }

        /// <summary>
        /// 获取Article的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ArticleListDto>> GetPagedArticles(GetArticlesInput input)
        {

            var query = _articleRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var articleCount = await query.CountAsync();

            var articles = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var articleListDtos = ObjectMapper.Map<List <ArticleListDto>>(articles);
            var articleListDtos = articles.MapTo<List<ArticleListDto>>();

            return new PagedResultDto<ArticleListDto>(
                articleCount,
                articleListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取ArticleListDto信息
        /// </summary>
        public async Task<ArticleListDto> GetArticleByIdAsync(EntityDto<int> input)
        {
            var entity = await _articleRepository.GetAsync(input.Id);

            return entity.MapTo<ArticleListDto>();
        }

        /// <summary>
        /// 导出Article为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetArticlesToExcel(){
        //var users = await UserManager.Users.ToListAsync();
        //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //await FillRoleNames(userListDtos);
        //return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetArticleForEditOutput> GetArticleForEdit(NullableIdDto<int> input)
        {
            var output = new GetArticleForEditOutput();
            ArticleEditDto articleEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _articleRepository.GetAsync(input.Id.Value);

                articleEditDto = entity.MapTo<ArticleEditDto>();

                //articleEditDto = ObjectMapper.Map<List <articleEditDto>>(entity);
            }
            else
            {
                articleEditDto = new ArticleEditDto();
            }

            output.Article = articleEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Article的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateArticle(CreateOrUpdateArticleInput input)
        {

            if (input.Article.Id.HasValue)
            {
                await UpdateArticleAsync(input.Article);
            }
            else
            {
                await CreateArticleAsync(input.Article);
            }
        }

        /// <summary>
        /// 新增Article
        /// </summary>
        [AbpAuthorize(ArticleAppPermissions.Article_CreateArticle)]
        protected virtual async Task<ArticleEditDto> CreateArticleAsync(ArticleEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<Article>(input);

            entity = await _articleRepository.InsertAsync(entity);
            return entity.MapTo<ArticleEditDto>();
        }

        /// <summary>
        /// 编辑Article
        /// </summary>
        [AbpAuthorize(ArticleAppPermissions.Article_EditArticle)]
        protected virtual async Task UpdateArticleAsync(ArticleEditDto input)
        {
            //TODO: 更新前的逻辑判断，是否允许更新
             var entity = await _articleRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _articleRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除Article信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ArticleAppPermissions.Article_DeleteArticle)]
        public async Task DeleteArticle(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _articleRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Article的方法
        /// </summary>
        [AbpAuthorize(ArticleAppPermissions.Article_BatchDeleteArticles)]
        public async Task BatchDeleteArticlesAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _articleRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

