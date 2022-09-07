using LagoVista.Campaigns.Models;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using System.Threading.Tasks;

namespace LagoVista.Campaigns
{
    public interface ISocialMediaAccountManager
    {
        Task<InvokeResult<SocialMediaAccount>> AddAccountAsync(SocialMediaAccount account, EntityHeader org, EntityHeader user);
        Task<InvokeResult<SocialMediaAccount>> UpdateAccountAsync(SocialMediaAccount account, EntityHeader org, EntityHeader user);
        Task<ListResponse<SocialMediaAccount>> GetAccountsAsync(ListRequest request, EntityHeader org, EntityHeader user);
        Task<SocialMediaAccount> GetAccountWithSecret(string id, EntityHeader org, EntityHeader user);
    }
}
