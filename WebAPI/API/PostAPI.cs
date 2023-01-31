using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Bulletinboard.Back.WebAPI.API
{
    [Route("Post")]
    [ApiController]
    public class PostAPI : ControllerBase
    {
        /// <summary>
        /// Get post lists from table and filter if search string is not empty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{List{Post}?}}"/>
        /// </returns>
        [HttpPost("GetPostList")]
        public async Task<ActionResult<List<Post>?>> GetPostList(Post obj)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaders;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaders);
            if(APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN,string.Empty).Equals(requestHeaders) == false)
            {
                return Unauthorized();
            }
            PostRepository postRepository = new();
            return await postRepository.GetPostList(obj.Keyword);
        }

        /// <summary>
        /// Save post data into table
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("SavePost")]
        public async Task<ActionResult<int>> SavePost(Post obj)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaders;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaders);
            if(APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN,string.Empty).Equals(requestHeaders) == false)
            {
                return Unauthorized();
            }
            PostRepository postRepository = new();
            return await postRepository.SavePost(obj);
        }

        /// <summary>
        /// Get post data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{Post}}"/>
        /// </returns>
        [HttpGet("GetPost/{id}")]
        public async Task<ActionResult<Post>> GetPostById([FromRoute]int id)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaders;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaders);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaders) == false)
            {
                return Unauthorized();
            }
            PostRepository postRepository = new();
            return await postRepository.GetPostById(id);
        }

        /// <summary>
        /// Update post data
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("UpdatePost")]
        public async Task<ActionResult<int>> UpdatePost(Post obj)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaders;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaders);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaders) == false)
            {
                return Unauthorized();
            }
            PostRepository postRepository = new();
            return await postRepository.UpdatePost(obj);
        }

        /// <summary>
        /// Delete post data by id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("DeletePost")]
        public async Task<ActionResult<int>> DeletePost(Post obj)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaders;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaders);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaders) == false)
            {
                return Unauthorized();
            }
            PostRepository postRepository = new();
            return await postRepository.DeletePost(obj);
        }

        /// <summary>
        /// Upload post data into table
        /// </summary>
        /// <param name="postList"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{int}}"/>
        /// </returns>
        [HttpPost("UploadPost")]
        public async Task<ActionResult<int>> UploadPost(List<Post> postList)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValue;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValue);
            if (APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaderValue) == false)
            {
                return Unauthorized();
            }
            PostRepository postRepository = new();
            return await postRepository.UploadPost(postList);

        }

        /// <summary>
        /// Download post data
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// The <see cref="Task{ActionResult{List{Post}?}}"/>
        /// </returns>
        [HttpPost("DownloadPost")]
        public async Task<ActionResult<List<Post>?>> DownloadPost(User user)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderValues;
            Request.Headers.TryGetValue(APISetting.KEY_APITOKEN, out requestHeaderValues);
            if(APISetting.Configuration.GetValue(APISetting.KEY_APITOKEN, string.Empty).Equals(requestHeaderValues) == false)
            {
                return Unauthorized();
            }
            PostRepository postRepository = new();
            return await postRepository.DownloadPost(user);
        }
    }
}
