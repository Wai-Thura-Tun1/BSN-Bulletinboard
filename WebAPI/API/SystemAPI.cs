using Model;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories;

namespace Bulletinboard.Back.WebAPI.API
{
    [Route("System")]
    [ApiController]
    public class SystemAPI:ControllerBase
    {
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{User?}}"/>
        /// </returns>
        [HttpPost("Login")]
        public async Task<ActionResult<User>?> LoginAsync(User loginData)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderKey;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderKey);
            if (!APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaderKey))
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            bool result = await userRepository.LoginAsync(loginData);
            if (result == true)
            {
                return loginData;
            }
            else
            {
                return null;
            }

        }


    }
}
