using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BLL.HTTP
{
    public class HttpMethods
    {
        private static HttpClient httpClient;
        #region HTTP GET

        /// <summary>
        /// Http Async GET.
        /// </summary>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <param name="_api">Http client.</param>
        /// <param name="Api">string API.</param>
        /// <typeparam name="T">The object type parameter.</typeparam>
        public async Task<T> GET<T>()//APIRootAddress _api, string API, string Parameter = ""
        {
            //TODO - TEMP CODE, MUST RELOCATE TO DATA ACCESS LAYER -edited
            string cfg_web_srv_ip_addrss = "localhost:57452";
            string API = "GetUsersDbContext";
            string Parameter = "";

            var Obj = Activator.CreateInstance(typeof(T));
            string RootApi = "api/UserService/"; //GetAPIAddress(_api);
            string ApiAddress = $"http://{cfg_web_srv_ip_addrss}/{RootApi}{API}{(!string.IsNullOrEmpty(Parameter) ? $"?{Parameter}" : "")}";
            httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiAddress);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<T>(data);
                }
            }
            catch (Exception ex)
            {
                var error = ex;
            }
            return (T)Obj;
        }

        //private HttpClient CreateClient()
        //{
        //    string Token = CreateToken();
        //    HttpClient _client = new HttpClient();
        //    _client.BaseAddress = new Uri(uri);
        //    //string _param = !string.IsNullOrEmpty(Parameter) ? $"?{Parameter}" : "";
        //    //string GetAddress = $"http://{cfg_web_srv_ip_addrss}/{RootApi}{API}{(!string.IsNullOrEmpty(Parameter) ? $"?{Parameter}" : "")}";
        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
        //    return _client;
        //}

        //public enum APIRootAddress
        //{
        //    Root,
        //    Email,
        //    License
        //}
        //private string GetAPIAddress(APIRootAddress _api)
        //{
        //    string APIAddress = "";
        //    switch (_api)
        //    {
        //        default:
        //        case dbAPIController.APIRootAddress.Root:
        //            APIAddress = cfg_API_root_addrss;
        //            break;
        //        case dbAPIController.APIRootAddress.Email:
        //            APIAddress = cfg_API_Email_root_addrss;
        //            break;
        //        case dbAPIController.APIRootAddress.License:
        //            APIAddress = cfg_API_License_root_addrss;
        //            break;
        //    }
        //    return APIAddress;
        //}
        #endregion
    }
}
