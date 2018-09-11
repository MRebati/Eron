using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Eron.Business.Core.Core;
using Eron.Core.Entities.User;
using Eron.SharedKernel.Helpers.AppSettingsHelper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Eron.SharedKernel.Helpers.StringExtensions;
using hbehr.recaptcha;
using hbehr.recaptcha.Exceptions;

namespace Eron.Presentation.WebApplication.WebApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
                throw new ArgumentNullException(nameof(publicClientId));
            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (ApplicationSettingsHelper.AppSetting<bool>("use_recaptcha"))
            {
                var recaptchaIsValid = await ValidateRecaptch(context);
                if (!recaptchaIsValid)
                {
                    return;
                }
            }

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("مجوز نامعتبر", "نام کاربری یا رمز عبور اشتباه است");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        private async Task<bool> ValidateRecaptch(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var data = await context.Request.ReadFormAsync();
            string userResponse = data["recaptcha"];

            try
            {
                bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
                if (!validCaptcha || userResponse.IsNullOrWhiteSpace())
                {
                    // Bot Attack, non validated !
                    throw new ReCaptchaException();
                }

                return true;
            }
            catch
            {
                context.SetError("مجوز نامعتبر", "فیلد 'من ربات نیستم' صحیح نیست. لطفا مجددا تلاش کنید");
                return false;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}