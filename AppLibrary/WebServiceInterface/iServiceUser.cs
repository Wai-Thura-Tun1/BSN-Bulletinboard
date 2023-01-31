using AppLibrary.Model;
using Bulletinboard.CommonLibrary;
using Bulletinboard.Front.AppLibrary;
using Bulletinboard.Front.AppLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.WebServiceInterface
{
    public class iServiceUser : IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public iServiceUser()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(iAppSettings.ApiEndpoint + CTRL_NAME);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add(iConstance.HTTP_HEADER_APITOKEN,iAppSettings.ApiToken);
        }

        /// <summary>
        /// Define httpclient
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// Define ctrl_name
        /// </summary>
        private const string CTRL_NAME = "user";

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns>
        /// The <see cref="Task{ObservableCollection{User}}"/>
        /// </returns>
        public async Task <ObservableCollection<User>> GetAllAsync(string searchName)
        {
            string? result;
            try
            {
                User userData = new User(searchName);
                var content = new StringContent(JsonConvert.SerializeObject(userData),Encoding.UTF8,@"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress + "/GetUserList", content);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<User>();
            }
            catch (Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<User>();
            }
            if(string.IsNullOrEmpty(result))
            {
                return new ObservableCollection<User>();
            }
            var objData = JsonConvert.DeserializeObject(result,typeof(ObservableCollection<User>));
            if (objData == null)
            {
                return new ObservableCollection<User>();
            }
            else
            {
                return (ObservableCollection<User>)objData;
            }
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>
        /// The <see cref="Task{ObservableCollection{Role}}"/>
        /// </returns>
        public async Task<ObservableCollection<Role>> GetRoleAsync()
        {
            string? result;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(httpClient.BaseAddress + "/GetRoleList");
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<Role>();
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new ObservableCollection<Role>();
            }
            if(string.IsNullOrEmpty(result))
            {
                return new ObservableCollection<Role>();
            }
            var objData = JsonConvert.DeserializeObject(result,typeof(ObservableCollection<Role>));
            if (objData == null)
            {
                return new ObservableCollection<Role>();
            }
            else
            {
                return (ObservableCollection<Role>)objData;
            }
        }

        /// <summary>
        /// Save,Update and Delete with methodname
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodName"></param>
        /// <returns>
        /// The <see cref="Task{int}"/>
        /// </returns>
        public async Task<int> UpdateAsync(User obj,string methodName)
        {
            string result = string.Empty;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, @"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress + "/" + methodName,content);
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
        /// Get user data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task{User}"/>
        /// </returns>
        public async Task<User> GetUserById(int id)
        {
            string result = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(httpClient.BaseAddress + "/GetUser/" + id);
                responseMessage.EnsureSuccessStatusCode();
                result = await responseMessage.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new User();
            }
            catch(Exception ex)
            {
                iAppSettings.Log.Logger.Error(ex.Message);
                return new User();
            }
            if (string.IsNullOrEmpty(result))
            {
                return new User();
            }
            var objData = JsonConvert.DeserializeObject(result, typeof(User));
            if (objData == null)
            {
                return new User();
            }
            else
            {
                return (User)objData;
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
