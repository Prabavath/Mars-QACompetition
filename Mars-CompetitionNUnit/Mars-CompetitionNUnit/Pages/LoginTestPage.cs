using Mars_CompetitionNUnit.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionNUnit.Pages
{
    public class LoginTestPage : CommonDriver 
    {
        private static IWebElement signinButton => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
        private static IWebElement emailaddressTextbox => driver.FindElement(By.Name("email"));
        private static IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
        private static IWebElement loginButton => driver.FindElement(By.XPath("//button[normalize-space()='Login']"));

        public void LoginSteps()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            signinButton.Click();
            emailaddressTextbox.SendKeys("prabavathini@yahoo.com");
            passwordTextbox.SendKeys("Password123");
            loginButton.Click();
        }
    }
}
