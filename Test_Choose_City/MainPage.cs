using OpenQA.Selenium;
using System;
using Base;
using MainPageLocators;

namespace Main;
public class MainPage : BasePage
{
	public MainPage(IWebDriver driver) : base(driver)
	{
	}

	public void OpenCity()
    {
		this.Click(MainPageLocators.MainPageLocators.CHOOSING_CITY_LOCATOR, 3, true, 0, -20);
    }

	public string SelectElement(string locator, string column, string elemNum)
    {
		string elem = this.Find(By.XPath(String.Format(locator, column, elemNum))).Text;
		this.Click(By.XPath(String.Format(locator, column, elemNum)));
		return elem;
	}

	public Boolean CheckSelectedElement(string selectedElement, string columnName)
    {
		return selectedElement.Equals(this.Find(By.XPath(String.Format(MainPageLocators.MainPageLocators.SELECTED_ELEMENT_LOCATOR, columnName))).Text);
    }

	public Boolean CheckSelectedCity(string selectedElement)
	{
		string a = this.Find(MainPageLocators.MainPageLocators.CHOOSING_CITY_LOCATOR).Text;
		return selectedElement.Equals(this.Find(MainPageLocators.MainPageLocators.CHOOSING_CITY_LOCATOR).Text);
	}

	public string AcceptWidgetCity()
    {
		string city = this.Find(MainPageLocators.MainPageLocators.CHOOSE_CITY_WIDGET_CITY_LOCATOR).Text;
		this.Click(MainPageLocators.MainPageLocators.CHOOSE_CITY_WIDGET_YES_LOCATOR);
		return city;
    }

	public void RejectWidgetCity()
	{
		this.Click(MainPageLocators.MainPageLocators.CHOOSE_CITY_WIDGET_NO_LOCATOR);
	}

	public string ClickSuggest(string elem)
    {
		string city = this.Find(By.XPath(String.Format(MainPageLocators.MainPageLocators.SUGGEST_LOCATOR, elem))).Text;
		this.Click(By.XPath(String.Format(MainPageLocators.MainPageLocators.SUGGEST_LOCATOR, elem)));
		return city;
    }

	public string SearchCity(string request, Boolean choiseClick=true)
    {
		this.SendData(MainPageLocators.MainPageLocators.SEARCH_CITY_LOCATOR, request);
		if (choiseClick)
		{
			string city = this.Find(MainPageLocators.MainPageLocators.FIRST_SEARCH_CHOISE_LOCATOR).Text.Split("\r")[0];
			this.Click(MainPageLocators.MainPageLocators.FIRST_SEARCH_CHOISE_LOCATOR);
			return city;
		} else
        {
			return "";
        }
	}
}
