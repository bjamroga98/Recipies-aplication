using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using WpfApp1.models;

namespace RecipeApp.test
{
    [TestClass]
    public class MainWindowTest
    {

        /// <summary>
        /// proper function start
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestMethod1()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "eggs,ham,tomatoes";
            String category = "omelet";
            //----------Run function-------
            RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            //----------Check result-------
            Assert.AreEqual(true, model != null);
            Assert.AreEqual(true, model.results.Count > 0);

        }
        /// <summary>
        /// check for ingradients = null
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = null;
            String category = "omelet";
            //----------Run function and check result-------
            Assert.ThrowsExceptionAsync<NullReferenceException>(async () =>
            {
                RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            });
        }
        /// <summary>
        /// check for category = null
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "eggs,ham,tomatoes";
            String category = null;
            //----------Run function and check result-------
            Assert.ThrowsExceptionAsync<NullReferenceException>(async () =>
            {
                RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            });
        }
        /// <summary>
        /// check for ingradients is empty
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "";
            String category = "omelet";
            //----------Run function and check result-------
            Assert.ThrowsExceptionAsync<NullReferenceException>(async () =>
            {
                RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            });
        }
        /// <summary>
        /// check for category is empty
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "eggs,ham,tomatoes";
            String category = "";
            //----------Run function and check result-------
            Assert.ThrowsExceptionAsync<NullReferenceException>(async () =>
            {
                RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            });
        }
        /// <summary>
        /// check for category and ingradients is corect
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestMethod6()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "aazzzz";
            String category = "azzzzaa";
            //----------Run function-------
            RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            //----------Check result-------
            Assert.AreEqual(true, model == null);
        }
        /// <summary>
        /// validation for space
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestMethod7()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "eggs ham tomatoes";
            String category = "omelet";
            //----------Run function-------
            RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            //----------Check result-------
            Assert.AreEqual(true, model != null);
            Assert.AreEqual(true, model.results.Count > 0);
        }
        /// <summary>
        /// validation for dots
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestMethod8()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "eggs.ham.tomatoes";
            String category = "omelet";
            //----------Run function-------
            RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            //----------Check result-------
            Assert.AreEqual(true, model != null);
            Assert.AreEqual(true, model.results.Count > 0);
        }
        /// <summary>
        /// validation for dots and spaces
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestMethod9()
        {
            //----------Prepare components------
            MainWindowControler mainControler = new WpfApp1.MainWindowControler();
            String ingredients = "eggs,ham.tomatoes onions";
            String category = "omelet";
            //----------Run function-------
            RootModel model = await mainControler.makeQueryAsync(ingredients, category);
            //----------Check result-------
            Assert.AreEqual(true, model != null);
            Assert.AreEqual(true, model.results.Count > 0);
        }
    }
}
