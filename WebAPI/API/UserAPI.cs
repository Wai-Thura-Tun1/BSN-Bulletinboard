using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Data;

namespace Bulletinboard.Back.WebAPI.API
{
    [Route("User")]
    [ApiController]
    public class UserAPI: ControllerBase
    {
        /// <summary>
        /// Get user lists from table and filter if search string isn't empty
        /// </summary>
        /// <param name="objData"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{List{User}?}}"/>
        /// </returns>
        [HttpPost("GetUserList")]
        public async Task<ActionResult<List<User>?>> GetUser(User objData)
        {

            Microsoft.Extensions.Primitives.StringValues requestHeaderValue;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValue);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaderValue) == false)
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            return await userRepository.GetUserList(objData.Keyword);
        }

        /// <summary>
        /// Get role lists
        /// </summary>
        /// <returns>
        /// The <see cref="Task{ActionResult{List{Role}?}}"/>
        /// </returns>
        [HttpGet("GetRoleList")]
        public async Task<ActionResult<List<Role>?>> GetRole()
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValue;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValue);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaderValue) == false)
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            return await userRepository.GetRoleList();
        }

        /// <summary>
        /// Save user data to table
        /// </summary>
        /// <param name="objData"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("SaveUser")]
        public async Task<ActionResult<int>> SaveUser(User objData)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValue;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValue);
            if(APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN,string.Empty).Equals(requestHeaderValue) == false)
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            return await userRepository.SaveUser(objData);
        }

        /// <summary>
        /// Update user data into table
        /// </summary>
        /// <param name="objData"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("UpdateUser")]
        public async Task<ActionResult<int>> UpdateUser(User objData)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValue;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValue);
            if(APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN,string.Empty).Equals(requestHeaderValue) == false)
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            return await userRepository.UpdateUser(objData);
        }

        /// <summary>
        /// Get user data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{User}}"/>
        /// </returns>
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute]int id)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValue;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValue);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN,string.Empty).Equals(requestHeaderValue) == false)
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            return await userRepository.GetUserById(id);
        }

        /// <summary>
        /// Delete user data by id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("DeleteUser")]
        public async Task<ActionResult<int>> DeleteUser(User obj)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValue;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValue);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaderValue) == false)
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            return await userRepository.DeleteUser(obj);
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("ChangePassword")]
        public async Task<ActionResult<int>> ChangePassword(User obj)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValues;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValues);
            if(APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN,string.Empty).Equals(requestHeaderValues) == false)
            {
                return Unauthorized();
            }
            UserRepository userRepository = new();
            return await userRepository.ChangePassword(obj);
        }

    }
}
