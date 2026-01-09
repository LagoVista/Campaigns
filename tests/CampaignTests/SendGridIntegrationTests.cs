// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 1489a8d26ce156543a440aa29e7e72ba37e865d53bc2746d8a5e1f7bba3f1796
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.AspNetCore.Identity;
using LagoVista.AspNetCore.Identity.Services;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Interfaces.Managers;
using LagoVista.UserAdmin.Interfaces.Repos.Orgs;
using LagoVista.UserAdmin.Interfaces.Repos.Users;
using Moq;
using NUnit.Framework;
using System;

namespace CampaignTests
{
    public class SendGridIntegrationTests
    {
        private  IEmailSender _emailSender;

        [SetUp]
        public void Setup()
        {
            _emailSender = new SendGridEmailService(new IdentitySettings(), new Mock<IOrganizationLoaderRepo>().Object, new Moq.Mock<IAppUserLoaderRepo>().Object, new Moq.Mock<IBackgroundServiceTaskQueue>().Object, new Moq.Mock<IAppConfig>().Object,  new Moq.Mock<IAdminLogger>().Object);
        }

        public class IdentitySettings : ILagoVistaAspNetCoreIdentityProviderSettings
        {
            public string SmtpFrom => throw new NotImplementedException();

            public string FromPhoneNumber => throw new NotImplementedException();


            IConnectionSettings _smsSettings = new ConnectionSettings()
            {
                Password = Environment.GetEnvironmentVariable("TWILLIO_API_KEY")
            };

            public IConnectionSettings SmsServer
            {
                get => _smsSettings;
            }

            IConnectionSettings _smtpSettings = new ConnectionSettings()
            {
                Password = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY")
            };

            public IConnectionSettings SmtpServer
            {
                get => _smtpSettings;
            }
        }

    }
}
