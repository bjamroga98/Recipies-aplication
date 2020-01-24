using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.models;

namespace WpfApp1.ClientAPI
{ 
    /// <summary>
    /// Class get parametrs and make request
    /// </summary>
    public class NetworkAsync
    {
        /// <summary>
        /// Media type formatter
        /// </summary>
        public static List<MediaTypeFormatter> formatters = new List<MediaTypeFormatter>() {
            new BsonMediaTypeFormatter(),
            new FormUrlEncodedMediaTypeFormatter(),
            new JsonMediaTypeFormatter(),
            new XmlMediaTypeFormatter()
        };
        /// <summary>
        /// Get Json and convert to c# object
        /// </summary>
        /// <param name="ingredients">contains ingradients parameters</param>
        /// <param name="mealType">contains mealtype parameter</param>
        /// <returns>rootModel</returns>
        public static async Task<RootModel> getJSON(String ingredients, String mealType)
        {
            String url = "http://www.recipepuppy.com/api/?i=" + ingredients + "&q=" + mealType;

            using (HttpResponseMessage response = await NetworkService.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    String jsonStringResponse = response.Content.ReadAsStringAsync().Result;
                    var contentData = JsonConvert.DeserializeObject<RootModel>(jsonStringResponse);
                    return (RootModel)contentData;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
