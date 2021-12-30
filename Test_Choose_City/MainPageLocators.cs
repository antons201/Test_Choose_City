using OpenQA.Selenium;

namespace MainPageLocators;
public class MainPageLocators
{
	public static By CHOOSING_CITY_LOCATOR = By.XPath("//div[contains(@class, 'header-top-menu__common-link_city')]//p");
	public static By CITY_HEADER_LOCATOR = By.XPath("//div[@class='base-modal select-city-modal base-modal_full-on-mobile']");
	public static By LOADER_LOCATOR = By.Id("bodyLoader");
	public static By CHOOSE_CITY_WIDGET_CITY_LOCATOR = By.XPath("//p[@class='w-choose-city-widget__city-info']/b");
	public static By CHOOSE_CITY_WIDGET_YES_LOCATOR = By.XPath("//a[@class='btn btn-additional']");
	public static By CHOOSE_CITY_WIDGET_NO_LOCATOR = By.XPath("//a[@class='w-choose-city-widget pseudo-link pull-right']");
	public static By SEARCH_CITY_LOCATOR = By.XPath("//input[@data-role='search-city']");
	public static By FIRST_SEARCH_CHOISE_LOCATOR = By.XPath("//ul[@class='cities-search']//span");
	public static By CITY_NOT_FOUND_LOCATOR = By.XPath("//div[@class='city-not-found']");
	public static string DISTRICT_LOCATOR = "//ul[@class='{0}']/li[{1}]//span";
	public static string REGION_AND_CITY_LOCATOR = "//ul[@class='{0}']/li[contains(@style,'display: block')][{1}]//span";
	public static string SELECTED_ELEMENT_LOCATOR = "//ul[@class='{0}']/li[@class='modal-row active']//span";
	public static string SUGGEST_LOCATOR = "//div[@class='big-cities-bubble-list']/span[{0}]/a";
}
