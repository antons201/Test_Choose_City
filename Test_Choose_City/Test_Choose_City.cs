using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using Main;

namespace Test_Choose_City
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class Test_Choose_City <TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;
        String test_url = "https://www.dns-shop.ru";
        MainPage mainPage;

        [SetUp]
        public void Init()
        {
            this.driver = new TWebDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Url = test_url;

            mainPage = new MainPage(this.driver);

        }

        [Test]
        public void Test_Check_Select_District()
        {
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string selectedDistrict = mainPage.SelectElement(MainPageLocators.MainPageLocators.DISTRICT_LOCATOR, "districts", "8");
            Assert.True(mainPage.CheckSelectedElement(selectedDistrict, "districts"));

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Select_Region()
        {
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string selectedRegion = mainPage.SelectElement(MainPageLocators.MainPageLocators.REGION_AND_CITY_LOCATOR, "regions", "1");
            Assert.True(mainPage.CheckSelectedElement(selectedRegion, "regions"));

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Select_City_In_Head()
        {
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string selectedCity = mainPage.SelectElement(MainPageLocators.MainPageLocators.REGION_AND_CITY_LOCATOR, "cities", "1");
            mainPage.WaitLoader();
            Assert.True(mainPage.CheckSelectedCity(selectedCity));

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Select_City_In_Cities_Column()
        {
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string selectedCity = mainPage.SelectElement(MainPageLocators.MainPageLocators.REGION_AND_CITY_LOCATOR, "cities", "1");
            mainPage.WaitLoader();
            mainPage.OpenCity();
            Assert.True(mainPage.CheckSelectedElement(selectedCity, "cities"));

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Select_City_In_Widget_Accept()
        {

            string city = mainPage.AcceptWidgetCity();
            mainPage.WaitLoader();
            Assert.True(mainPage.CheckSelectedCity(city));

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Select_City_In_Widget_Reject()
        {
            mainPage.RejectWidgetCity();
            mainPage.WaitLoader();
            Assert.True(mainPage.Find(MainPageLocators.MainPageLocators.CITY_HEADER_LOCATOR).Displayed);

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Select_City_In_Suggest()
        {
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string city = mainPage.ClickSuggest("1");
            mainPage.WaitLoader();
            Assert.True(mainPage.CheckSelectedCity(city));

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Search_City_Found()
        {
            string cityForSearch = "Владивосток";
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string foundCity = mainPage.SearchCity(cityForSearch);
            Assert.True(cityForSearch == foundCity);
            mainPage.WaitLoader();
            Assert.True(mainPage.CheckSelectedCity(cityForSearch));

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Search_City_Not_Found()
        {
            string cityForSearch = "ььшываопр";
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string foundCity = mainPage.SearchCity(cityForSearch, false);
            Assert.True(mainPage.Find(MainPageLocators.MainPageLocators.CITY_NOT_FOUND_LOCATOR).Displayed);

            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void Test_Check_Search_City_Part_Of_Word()
        {
            string cityForSearch = "Владив";
            mainPage.OpenCity();
            mainPage.WaitLoader();
            string foundCity = mainPage.SearchCity(cityForSearch);
            mainPage.WaitLoader();
            Assert.True(mainPage.CheckSelectedCity(foundCity));

            System.Threading.Thread.Sleep(2000);
        }

        [TearDown]
        public void Close_Browser()
        {
            this.driver.Quit();
        }
    }
}