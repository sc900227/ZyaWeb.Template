using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ZyaWeb.PersonArticles.Persons;

namespace ZyaWeb.Persons.DomainServices
{
    public interface IPersonManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitPerson();

    }
}
