using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Base;

public class BasePage
{
	private IWebDriver driver;
	private const int CLICK_RETRY = 5;
	public BasePage(IWebDriver driver)
	{
		this.driver = driver;
	}

	private WebDriverWait Wait(Double timeout=3)
    {
		return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
    }

	public IWebElement Find(By locator, Double timeout=3)
    {
		return this.Wait(timeout).Until(e => e.FindElement(locator));
    }

	public void Click(By locator, Double timeout=3, Boolean offset=false, int x_offset=0, int y_offset=0)
    {
		for (int i = 0; i < CLICK_RETRY; i++)
		{
			try
			{
				this.Find(locator, timeout);
				IWebElement el = this.Wait(timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

				if (offset) {
					this.ClickWithOffset(el, x_offset, y_offset);
				} else {
					el.Click();
				}

				return;
			}
			catch (Exception)
			{
				if (i == CLICK_RETRY - 1) {
					throw;
				}
			}
		}

	}

	public void WaitLoader()
    {
		this.Wait(10).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(MainPageLocators.MainPageLocators.LOADER_LOCATOR));
    }

	private void ClickWithOffset(IWebElement el, int x_offset, int y_offset)
    {
		Actions actionProvider = new(this.driver);
		actionProvider.MoveToElement(el).MoveByOffset(x_offset, y_offset).Click().Build().Perform();
	}

	public void SendData(By locator, String data, Boolean clear=true)
    {
		IWebElement elem = this.Find(locator);
		if (clear)
        {
			elem.Clear();
        }
		elem.SendKeys(data);
    }
}
