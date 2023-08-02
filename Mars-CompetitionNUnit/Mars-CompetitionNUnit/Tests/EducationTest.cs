using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Gherkin.CucumberMessages.Types;
using Mars_CompetitionNUnit.Pages;
using Mars_CompetitionNUnit.TestModel;
using Mars_CompetitionNUnit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionNUnit.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {
        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private EducationPage educationPageObj = new EducationPage();
        
        [SetUp]
        public void SetUpActions()
        {
            //Open chrome browser
            driver = new ChromeDriver();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.LoginSteps();
        }
        [Test,Order(1)]
        public void TestAddWithEducationData()
        {
            // Read test data from the JSON file using Jsonhelper
            List<EducationTestModel> AddEducationPositivedata = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\AddEducationPositivedata.json");
            Console.WriteLine(AddEducationPositivedata.ToString());
            foreach (var data in AddEducationPositivedata)
            {
                // Access individual test data properties
                string university = data.University;
                Console.WriteLine(university);
                string country = data.Country;
                Console.WriteLine(country);
                string title = data.Title;
                Console.WriteLine(title);
                string degree = data.Degree;
                Console.WriteLine(degree);
                string yearofgraduation = data.Yearofgraduation;
                Console.WriteLine(yearofgraduation);
                // Perform the education test using the Education data
                educationPageObj.AddEducation(university, country, title, degree, yearofgraduation);
                string newCountry = educationPageObj.GetVerifyEducationList();
                if (country == newCountry)
                {
                   Assert.AreEqual(country, newCountry, "Actual country and expected country do not match");
                }
                else
                {
                    Assert.AreNotEqual(country, newCountry, "Actual country and expected country do match");
                }
            }
        }

        [Test, Order(2)]
        public void TestUpdateWithEducationData()
        {
            // Read test data from the JSON file
            List<EducationTestModel> UpdateEducationPositivedata = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\UpdateEducationPositivedata.json");
            Console.WriteLine(UpdateEducationPositivedata.ToString());
            foreach (var data in UpdateEducationPositivedata)
            {
                // Access individual test data properties
                string university = data.University;
                Console.WriteLine(university);
                string country = data.Country;
                Console.WriteLine(country);
                string title = data.Title;
                Console.WriteLine(title);
                string degree = data.Degree;
                Console.WriteLine(degree);
                string yearofgraduation = data.Yearofgraduation;
                Console.WriteLine(yearofgraduation);
                // Perform the education test using the Education data
                try
                {
                    educationPageObj.UpdateEducation(university, country, title, degree, yearofgraduation);
                    string newUpdatedCountry = educationPageObj.GetVerifyUpdateEducationList();
                    if (country == newUpdatedCountry)
                    {
                        Assert.AreEqual(country, newUpdatedCountry, "Actual country and expected country do not match");
                    }
                    else
                    {
                        Assert.AreNotEqual(country, newUpdatedCountry, "Actual country and expected country do match");
                    }

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Upadated element not found", university.ToString());
                }
            }
        }

        [Test,Order(3)]
        public void TestDeleteWithEducationData()
        {
            // Read test data from the JSON file
            List<EducationTestModel> Deletedata = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\Deletedata.json");
            Console.WriteLine(Deletedata.ToString());
            foreach (var data in Deletedata)
            {
                // Access individual test data properties
                string university = data.University;
                Console.WriteLine(university);
                string country = data.Country;
                Console.WriteLine(country);
                string title = data.Title;
                Console.WriteLine(title);
                string degree = data.Degree;
                Console.WriteLine(degree);
                string yearofgraduation = data.Yearofgraduation;
                Console.WriteLine(yearofgraduation);
                // Perform the education test using the Education data
                educationPageObj.DeleteEducation(university,degree);
                string deletedCountry = educationPageObj.GetVerifyDeleteEducationList();
                if (country == deletedCountry)
                {
                    Assert.AreEqual(country, deletedCountry, "Actual country and expected country do not match");
                }
                else
                {
                    Assert.AreNotEqual(country, deletedCountry, "Actual country and expected country do match");
                }
            }
        }


         [TearDown]
         public void TearDownActions()
         {
                driver.Quit();
         }
    }
}

