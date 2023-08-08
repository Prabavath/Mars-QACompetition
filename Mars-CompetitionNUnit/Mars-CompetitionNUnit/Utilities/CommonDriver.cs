using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionNUnit.Utilities
{
    public class CommonDriver
    {
        //Base url
        //  public static string url = "http://localhost:5000";
#pragma warning disable CS8618
        public static IWebDriver driver;
       /* public CommonDriver(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string GetScreenshot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;
            return img;
        }*/
    }
}
