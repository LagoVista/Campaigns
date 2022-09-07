using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Threading.Tasks;

namespace LagoVista.Campaigns
{
    public interface ISocialMediaAccountRepo
    {
        Task AddAccountAsync(SocialMediaAccount account);
        Task UpdateAccountAsync(SocialMediaAccount account);
        Task<SocialMediaAccount> GetAccountAsync(string id);
        Task<ListResponse<SocialMediaAccount>> GetAccountsAsync(ListRequest request, string orgId);
    }
}
