// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 3d4b1d758996dfd1bd603ae3e7c3589bfde459233112073bca30693da233e03d
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models;
using LagoVista.Core;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Validation;
using System;
using System.Threading.Tasks;

namespace LagoVista.Campaigns
{
    public class SocialMediaAccountManager : ManagerBase, ISocialMediaAccountManager
    {
        ISocialMediaAccountRepo _repo;
        ISecureStorage _secureStorage;

        public SocialMediaAccountManager(ISocialMediaAccountRepo repo, ISecureStorage secureStorage, ILogger logger, IAppConfig appConfig, IDependencyManager dependencyManager, ISecurity security) :
           base(logger, appConfig, dependencyManager, security)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _secureStorage = secureStorage ?? throw new ArgumentNullException(nameof(secureStorage));
        }

        public async Task<InvokeResult<SocialMediaAccount>> AddAccountAsync(SocialMediaAccount account, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(account, Actions.Create);

            var result = await _secureStorage.AddSecretAsync(org, account.Id, account.AccountSecret);
            if(!result.Successful)
            {
                return InvokeResult<SocialMediaAccount>.FromInvokeResult(result.ToInvokeResult());
            }

            account.AccountSecretId = result.Result;
            account.AccountSecret = null;

            await AuthorizeAsync(account, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddAccountAsync(account);

            return InvokeResult<SocialMediaAccount>.Create(account);
        }

        public async Task<ListResponse<SocialMediaAccount>> GetAccountsAsync(ListRequest request, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(SocialMediaAccount), Actions.Read);

            return await _repo.GetAccountsAsync(request, org.Id);
        }

        public async Task<SocialMediaAccount> GetAccountWithSecret(string id, EntityHeader org, EntityHeader user)
        {
            var account = await _repo.GetAccountAsync(id);
            await AuthorizeAsync(account, AuthorizeResult.AuthorizeActions.Read, user, org);
            account.AccountSecret = (await _secureStorage.GetSecretAsync(org, account.AccountSecretId, user)).Result;
            return account; 
        }

        public async Task<InvokeResult<SocialMediaAccount>> UpdateAccountAsync(SocialMediaAccount account, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(account, Actions.Create);
            account.LastUpdatedBy = user;
            account.LastUpdatedDate = DateTime.UtcNow.ToJSONString();

            if(!String.IsNullOrEmpty(account.AccountSecret))
            {
                await _secureStorage.RemoveSecretAsync(org, account.AccountSecretId);

                var result = await _secureStorage.AddSecretAsync(org, account.Id, account.AccountSecret);
                if (!result.Successful)
                {
                    return InvokeResult<SocialMediaAccount>.FromInvokeResult(result.ToInvokeResult());
                }

                account.AccountSecretId = result.Result;
                account.AccountSecret = null;
            }

            await AuthorizeAsync(account, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.UpdateAccountAsync(account);

            return InvokeResult<SocialMediaAccount>.Create(account);
        }
    }
}
