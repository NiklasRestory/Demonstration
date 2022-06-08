using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumDemonstration
{
    public class WebDriverFixture : IDisposable
    {
        public ChromeDriver ChromeDriver;

        public WebDriverFixture()
        {
            ChromeDriver = new ChromeDriver();
            //ChromeDriver = new ChromeDriver(@"C:\Users\nikla\Downloads\chromedriver2");
        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            ChromeDriver.Quit();
            ChromeDriver.Dispose();
        }
    }
}
