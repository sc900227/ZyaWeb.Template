using Abp.Domain.Services;
using ZyaWeb.PersonArticles.Persons;

namespace ZyaWeb
{
    public abstract class ZyaWebDomainServiceBase : DomainService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        /* Add your common members for all your domain services. */
        /*在领域服务中添加你的自定义公共方法*/
        protected ZyaWebDomainServiceBase()
        {
            LocalizationSourceName = ZyaWebConsts.LocalizationSourceName;
        }
    }
}
