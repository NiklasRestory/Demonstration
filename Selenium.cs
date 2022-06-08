using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace SeleniumDemonstration
{
    public class Selenium : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture driverFixture;
        public Selenium(WebDriverFixture webDriverFixture)
        {
            driverFixture = webDriverFixture;
        }

        [Fact]
        public void Login()
        {
            //ChromeDriver chromeDriver = new ChromeDriver(@"C:\Users\nikla\Downloads\chromedriver2");
            ChromeDriver chromeDriver = driverFixture.ChromeDriver;

            chromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

            IWebElement link = chromeDriver.FindElement(By.LinkText("Form Authentication"));
            link.Click();
            IWebElement usernameInput = chromeDriver.FindElement(By.Id("username"));
            IWebElement passwordInput = chromeDriver.FindElement(By.Name("password"));
            usernameInput.SendKeys("tomsmith");
            passwordInput.SendKeys("wrongpassword");
            passwordInput.Clear();
            passwordInput.SendKeys("SuperSecretPassword!");
            IWebElement button = chromeDriver.FindElement(By.CssSelector(".radius"));
            button.Click();
            IWebElement logoutButton = chromeDriver.FindElement(By.XPath("html/body/div[2]/div/div/a"));
            logoutButton.Click();

            /*Thread.Sleep(3000);
            chromeDriver.Quit();
            chromeDriver.Dispose();*/
        }


        [Fact]
        public void DropDown()
        {
            ChromeDriver driver = driverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

            IWebElement link = driver.FindElement(By.XPath("//a[@href='/dropdown']"));
            link.Click();

            IWebElement dropdown = driver.FindElement(By.Id("dropdown"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByIndex(1);
            select.SelectByValue("2");
            select.SelectByText("Option 1");
        }

        [Fact]
        public void CheckBox()
        {
            ChromeDriver driver = driverFixture.ChromeDriver;

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            driver.FindElement(By.LinkText("Checkboxes")).Click();

            IWebElement box = driver.FindElement(By.XPath("html/body/div[2]/div/div/form/input[1]"));
            box.Click();
        }

        [Fact]
        public void DynamicLoading()
        {
            ChromeDriver driver = driverFixture.ChromeDriver;

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            driver.FindElement(By.LinkText("Dynamic Loading")).Click();
            driver.FindElement(By.LinkText("Example 2: Element rendered after the fact")).Click();
            driver.FindElement(By.XPath("//button[contains(text(), 'Start')]")).Click();

            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement text = webDriverWait.Until(driver =>
             driver.FindElement(By.XPath("//h4[contains(text(), 'Hello World!')]")));

            Assert.Equal("Hello World!", text.Text);
        }

        /*[Fact]
        public void DragAndDrop()
        {
            ChromeDriver driver = driverFixture.ChromeDriver;

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            driver.FindElement(By.LinkText("Drag and Drop")).Click();

            IWebElement column_a = driver.FindElement(By.Id("column-a"));
            IWebElement column_b = driver.FindElement(By.Id("column-b"));

            Actions actions = new Actions(driver);

            actions.DragAndDrop(column_a, column_b).Build();
            actions.Perform();

            actions.MoveByOffset(100, 100);
            actions.DragAndDropToOffset(column_a, 100, 100);

            //actions.ClickAndHold(column_a).MoveToElement(column_b).Release(column_a).Build();
            //actions.Perform();
        }*/
    }
}
