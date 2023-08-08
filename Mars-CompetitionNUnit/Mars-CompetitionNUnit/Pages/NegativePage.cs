using Mars_CompetitionNUnit.TestModel;
using Mars_CompetitionNUnit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionNUnit.Pages
{
    public class NegativePage : CommonDriver 
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
        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement certificationsTab => driver.FindElement(By.XPath("//a[normalize-space()='Certifications']"));
        private static IWebElement certificateTextbox => driver.FindElement(By.Name("certificationName"));
        private static IWebElement certifiedFromTextbox => driver.FindElement(By.Name("certificationFrom"));
        private static IWebElement yearDropdown => driver.FindElement(By.Name("certificationYear"));
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
            Wait.WaitToBeVisible(driver, "XPath", " //div[@class='ns-box-inner']", 15);
            //get the popup message text
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            string expectedMessage1 = "Please enter all the fields";
            string expectedMessage2 = "This information is already exist.";
            string expectedMessage3 = "Education information was invalid";
            string expectedMessage4 = "Duplicated data";
            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Education has been added");
            }
            else if ((popupMessage == expectedMessage1) ||( popupMessage == expectedMessage2) ||( popupMessage == expectedMessage3) || (popupMessage == expectedMessage4))
            {
                Thread.Sleep(2000);
                IWebElement cancelIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
                cancelIcon.Click();
                Thread.Sleep(2000);
            }
            else
            {
             Console.WriteLine("check error");
            }
        }

        public void UpdateEducation(string university, string country, string title, string degree, string yearofgraduation)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ui top attached tabular menu']/a[3]", 15);
            educationTab.Click();
            string editiconXPath = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editiconXPath));
            Thread.Sleep(2000);
            editIcon.Click();
            universityTextbox.Clear();
            universityTextbox.SendKeys(university);
            countryDropdown.SendKeys(country);
            titleDropdown.SendKeys(title);
            degreeTextbox.Clear();
            degreeTextbox.SendKeys(degree);
            yearOfGraduationDropdown.SendKeys(yearofgraduation);
            updateButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", " //div[@class='ns-box-inner']", 15);
            //Thread.Sleep(2000);
            //get the popup message text
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is : " + popupMessage);
            string expectedMessage1 = "Please enter all the fields";
            string expectedMessage2 = "This information is already exist.";

            if (popupMessage.Contains("as been updated"))
            {
                Console.WriteLine("Education has been updated");
            }
            else if ((popupMessage == expectedMessage1) || (popupMessage == expectedMessage2))
            {
                //Thread.Sleep(2000);
                IWebElement cancelIcon = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                cancelIcon.Click();
                Thread.Sleep(2000);
            }
            else 
            {
                Console.WriteLine("check error");
            }
        }
        public void AddCertifications(string certificate, string certifiedFrom, string year)
        {
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//a[normalize-space()='Certifications']", 15);
            certificationsTab.Click();
            //Click on AddNew button
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
            addButton.Click();
            Thread.Sleep(2000);
           
            //Wait.WaitToBeVisible(driver, "XPath", " //div[@class='ns-box-inner']", 15);
            //get the popup message text
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is : " +popupMessage);
            string expectedMessage1 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage2 = "This information is already exist.";
            string expectedMessage3 = "Duplicated data";

            if (popupMessage.Contains("has been added to your certification"))
            {
                Console.WriteLine("Certifications has been added");
            }
            else if ((popupMessage == expectedMessage1) || (popupMessage == expectedMessage2) || (popupMessage == expectedMessage3))
                
            {
                //Thread.Sleep(2000);
                IWebElement cancelIcon = driver.FindElement(By.XPath("//div[@class='five wide field']//input[@value='Cancel']"));
                cancelIcon.Click();
               
            }
            else 
            {
                Console.WriteLine("check error");
            }
        }
        public void UpdateCertifications(string certificate, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[normalize-space()='Certifications']", 20);
            certificationsTab.Click();
            string editiconXPath = $"//tbody/tr[td[text()='{certificate}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editiconXPath));
            Thread.Sleep(2000);
            editIcon.Click();
            certificateTextbox.Clear();
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.Clear();
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            updateButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", " //div[@class='ns-box-inner']", 15);
            //Thread.Sleep(2000);
            //get the popup message text
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            string expectedMessage1 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage2 = "This information is already exist.";

            if (popupMessage.Contains("has been updated to your certification"))
            {
                Console.WriteLine("Certifications has been updated");
            }
            else if((popupMessage == expectedMessage1)||( popupMessage == expectedMessage2))
                  
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                // Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Cancel']", 15);
                cancelIcon.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("check error");
            }
        }
    }
}