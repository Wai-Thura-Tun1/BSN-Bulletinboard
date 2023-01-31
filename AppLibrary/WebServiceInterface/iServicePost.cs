using Bulletinboard.Front.AppLibrary;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Bulletinboard.Front.AppLibrary.Model;
using Bulletinboard.CommonLibrary;
using System.Collections.Generic;

namespace AppLibrary.WebServiceInterface
{
    public class iServicePost:IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public iServicePost()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(iAppSettings.ApiEndpoint + CTRL_NAME);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add(iConstance.HTTP_HEADER_APITOKEN, iAppSettings.ApiToken);
        }

        /// <summary>
        /// Define httpClient
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// Define ctrl_name
        /// </summary>
        private const string CTRL_NAME = "Post";

        /// <summary>
        /// Get post lists
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>
        /// The <see cref="Task{ObservableCollection{Post}}"/>
        /// </returns>
        public async Task<ObservableCollection<Post>> GetPostsAsync(string? searchString)
        {
            string result = string.Empty;
            try
            {
                Post postData = new(searchString);
                var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, @"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress + "/GetPostList",content);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<Post>();
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<Post>();
            }
            if (string.IsNullOrEmpty(result))
            {
                return new ObservableCollection<Post>();
            }
            var returnData = JsonConvert.DeserializeObject(result,typeof(ObservableCollection<Post>));
            if(returnData == null)
            {
                return new ObservableCollection<Post>();
            }
            else
            {
                return (ObservableCollection < Post >)returnData;
            }
        }

        /// <summary>
        /// Save,Update and Delete with methodname
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodName"></param>
        /// <returns>
        /// The <see cref="int"/>
        /// </returns>
        public async Task<int> UpdateAsync(Post obj,string methodName)
        {
            string result = string.Empty;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, @"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress + "/" + methodName, content);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return iConstance.APIRESULT_ERROR;
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return iConstance.APIRESULT_ERROR;
            }
            if(string.IsNullOrEmpty(result))
            {
                return iConstance.APIRESULT_ERROR;
            }
            return iConvert.ToInt(result);

        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="int"/>
        /// </returns>
        public async Task<int> DeleteUser(Post obj)
        {
            string result = string.Empty;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, @"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress + "/DeletePost", content);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return iConstance.APIRESULT_ERROR;
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return iConstance.APIRESULT_ERROR;
            }
            if(string.IsNullOrEmpty(result))
            {
                return iConstance.APIRESULT_ERROR;
            }
            return iConvert.ToInt(result);
        }

        /// <summary>
        /// Upload post data to api
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>
        /// The <see cref="int"/>
        /// </returns>
        public async Task<int> UploadPost(List<Post> postData)
        {
            string result;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, @"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress + "/UploadPost", content);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return iConstance.APIRESULT_ERROR;
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return iConstance.APIRESULT_ERROR;
            }
            if(string.IsNullOrEmpty(result))
            {
                return iConstance.APIRESULT_ERROR;
            }
            return iConvert.ToInt(result);
        }

        /// <summary>
        /// Download post data
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// The <see cref="Task{ObservableCollection{Post}}"/>
        /// </returns>
        public async Task<ObservableCollection<Post>> DownloadPost(User user)
        {
            string result = string.Empty;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(user),Encoding.UTF8, @"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress + "/DownloadPost", content);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<Post>();
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<Post>();
            }
            if(string.IsNullOrEmpty(result))
            {
                return new ObservableCollection<Post>();
            }
            var objData = JsonConvert.DeserializeObject(result, typeof(ObservableCollection<Post>));
            if (objData == null)
            {
                return new ObservableCollection<Post>();
            }
            return (ObservableCollection<Post>)objData;
        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task{Post}"/>
        /// </returns>
        public async Task<Post> GetPostById(int id)
        {
            string result = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(httpClient.BaseAddress + "/GetPost/" + id);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new Post();
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new Post();
            }
            if(string.IsNullOrEmpty(result))
            {
                return new Post();
            }
            var objData = JsonConvert.DeserializeObject(result, typeof(Post));
            if(objData == null)
            {
                return new Post();
            }
            else
            {
                return (Post)objData;
            }
        } 

        /// <summary>
        /// Dispose httpclient
        /// </summary>
        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
