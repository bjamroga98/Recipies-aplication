using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfApp1.ClientAPI;
using WpfApp1.models;

namespace WpfApp1
{   
    /// <summary>
    /// contsroler screen
    /// </summary>
    public class MainWindowControler
    {

        /// <summary>
        /// Load data 
        /// </summary>
        /// <param name="ingradients">
        /// contains ingradient parameter
        /// </param>
        /// <param name="category">
        /// contains ingradient category
        /// </param>
        /// <returns></returns>
        private static async Task<RootModel> LoadData(string ingradients, string category)
        {
            RootModel rootModel = await NetworkAsync.getJSON(ingradients, category);
            return rootModel;
        }

        /// <summary>
        /// replace all for comma
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        private String buildLine(String ingredient)
        {
            string pattern = "[,. /]";

            return Regex.Replace(ingredient.Trim(), pattern, ",");
        }
        /// <summary>
        /// make request to api
        /// </summary>
        /// <param name="ingredients"></param>
        /// <param name="category"></param>
        /// <returns>
        /// NullReferenceException if values is null or empty
        /// null if results list is empty
        /// model if is ok
        /// </returns>
        public async Task<RootModel> makeQueryAsync(String ingredients, String category)
        {
            if (string.IsNullOrWhiteSpace(ingredients) || string.IsNullOrWhiteSpace(category))
                throw new NullReferenceException();

            NetworkService.InitializeClient();
           
            RootModel model = await LoadData(buildLine(ingredients), category);

            if (model.results.Count == 0)
                return null;

            return model;
        }
    }
}
