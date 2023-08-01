using Mars_CompetitionNUnit.TestModel;
using Mars_CompetitionNUnit.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Collections.Specialized.BitVector32;

namespace Mars_CompetitionNUnit.Pages
{
    public class EducationPage : CommonDriver
    {
        private static IWebElement educationTab => driver.FindElement(By.XPath("//*[@class='ui top attached tabular menu']/a[3]"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New'] "));
        private static IWebElement universityTextbox => driver.FindElement(By.Name("instituteName"));
        private static IWebElement countryDropdown => driver.FindElement(By.Name("country"));
        private static IWebElement titleDropdown => driver.FindElement(By.Name("title"));
        private static IWebElement degreeTextbox => driver.FindElement(By.Name("degree"));
        private static IWebElement yearOfGraduationDropdown => driver.FindElement(By.Name("yearOfGraduation"));
        private static IWebElement addButton => driver.FindElement(By.CssSelector("input[value='Add']"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement newCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement newUpdatedCountry => driver.FindElement(By.XPath(".//div[@data-tab='third']//table//td"));
        private static IWebElement deletedCountry => driver.FindElement(By.XPath(".//div[@data-tab='third']//table//td"));
        
        public void AddEducation(string university, string country, string title, string degree, string yearofgraduation)
        {

            //Click on Education tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ui top attached tabular menu']/a[3]", 15);
            educationTab.Click();
            //Click on AddNew button
            addNewButton.Click();
            //Send the input
            universityTextbox.SendKeys(university);
            countryDropdown.SendKeys(country);
            titleDropdown.SendKeys(title);
            degreeTextbox.SendKeys(degree);
            yearOfGraduationDropdown.SendKeys(yearofgraduation);
            //Click on Add button
            addButton.Click();
            Console.WriteLine("Education has been added");
        }
        public string GetVerifyEducationList()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]",20);
            //Thread.Sleep(2000);
            return newCountry.Text;
        }

        public void UpdateEducation(string university, string country, string title, string degree, string yearofgraduation)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ui top attached tabular menu']/a[3]", 20);
            educationTab.Click();
            string editiconXPath = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editiconXPath));
            editIcon.Click();
            universityTextbox.Clear();
            universityTextbox.SendKeys(university);
            countryDropdown.SendKeys(country);
            titleDropdown.SendKeys(title);
            degreeTextbox.Clear();
            degreeTextbox.SendKeys(degree);
            yearOfGraduationDropdown.SendKeys(yearofgraduation);
            updateButton.Click();
            Console.WriteLine("Eduction has been updated");
        }
        public string GetVerifyUpdateEducationList()
        {
            Wait.WaitToBeVisible(driver, "XPath", ".//div[@data-tab='third']//table//td", 20);
            // Thread.Sleep(2000);
            return newUpdatedCountry.Text;

        }
        public void DeleteEducation(string university, string degree)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ui top attached tabular menu']/a[3]",20);
            educationTab.Click();
            string deleteiconXPath = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[2]";
            IWebElement deleteIcon = driver.FindElement(By.XPath(deleteiconXPath));
            Thread.Sleep(2000);
            deleteIcon.Click();
            Console.WriteLine("Eduction entry successfully removed");
        }
        public string GetVerifyDeleteEducationList()
        {
            Wait.WaitToBeVisible(driver, "XPath", ".//div[@data-tab='third']//table//td", 20);
            //Thread.Sleep(2000);
            return deletedCountry.Text;
        }
    }
}
      
