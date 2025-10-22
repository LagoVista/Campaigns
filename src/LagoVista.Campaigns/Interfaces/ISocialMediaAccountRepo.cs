// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b98cbf01a55f7a784561285e7b5f3c25aea1365a7c53c0d8478aac8e303cbd20
// IndexVersion: 0
// --- END CODE INDEX META ---
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
