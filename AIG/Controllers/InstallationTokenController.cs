﻿using System.Collections.Generic;
using AIG.Constants;
using AIG.Contracts;
using AIG.Mappers;
using AIG.Services.InstallationToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallationTokenController : ControllerBase
    {
        private readonly IInstallationTokenService _installationTokenService;

        public InstallationTokenController(IInstallationTokenService installationTokenService)
        {
            _installationTokenService = installationTokenService;
        }

        /// <summary>
        /// Fetches the installation token for the given context
        /// </summary>
        /// <param name="installationTokenContext">Context to fetch installation token</param>
        /// <param name="usertoken">User token to verify Azure scope</param>
        /// <returns>List of repos and the token</returns>
        [HttpPut]
        [Authorize(AuthenticationSchemes = AigAuthConstants.TokenAuthenticationDefaultScheme)]
        public IEnumerable<InstallationTokenResponse> FetchToken(
            InstallationTokenContext installationTokenContext,
            string usertoken)
        {
            var installationTokenServiceContext = 
                InstallationTokenContextMapper.MapToInstallationTokenServiceContext(
                    installationTokenContext);
            return _installationTokenService.FetchInstallationToken(installationTokenServiceContext);
        }

        [HttpGet]
        public string Name()
        {
            return "My name is Manish Narula";
        }
    }
}
