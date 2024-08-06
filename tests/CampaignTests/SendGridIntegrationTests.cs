﻿using LagoVista.AspNetCore.Identity;
using LagoVista.AspNetCore.Identity.Services;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Interfaces.Managers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignTests
{
    public class SendGridIntegrationTests
    {
        private readonly IEmailSender _emailSender;

        [SetUp]
        public void Setup()
        {
            _emailSender = new SendGridEmailService(new IdentitySettings(), new Moq.Mock<IAppConfig>().Object, new Moq.Mock<IAdminLogger>().Object);
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
