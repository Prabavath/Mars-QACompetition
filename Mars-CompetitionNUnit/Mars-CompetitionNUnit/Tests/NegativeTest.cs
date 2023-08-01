using Mars_CompetitionNUnit.Pages;
using Mars_CompetitionNUnit.TestModel;
using Mars_CompetitionNUnit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionNUnit.Tests
{
    [TestFixture]
    public class NegativeTest : CommonDriver
    {
        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private NegativePage negativeEducationPageObj = new NegativePage();

        [SetUp]
        public void SetUpActions()
        {
            //Open chrome browser
            driver = new ChromeDriver();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.LoginSteps();

        }

        [Test,Order(1)]
        public void Test1AddWithEducationData()
        {
            // Read test data from the JSON file using Jsonhelper
            string sFile = "AddEducationNegativedata.json";
            List<EducationTestModel> AddEducationNegativedata = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(AddEducationNegativedata.ToString());
            foreach (var data in AddEducationNegativedata)

            {
                // Access individual test data properties
                string university = data.University;
                string country = data.Country;
                string title = data.Title;
                string degree = data.Degree;
                string yearofgraduation = data.Yearofgraduation;
                // Perform the education test using the Education data
                negativeEducationPageObj.AddEducation(university, country, title, degree, yearofgraduation);
               
            }
        }
        [Test, Order(2)]
        public void TestUpdateWithEducationData()
        {
            // Read test data from the JSON file
            string sFile = "UpdateEducationNegativedata.json";
            List<EducationTestModel> UpdateEducationNegativedata = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(UpdateEducationNegativedata.ToString());
            foreach (var data in UpdateEducationNegativedata)

            {
                // Access individual test data properties
                string university = data.University;
                string country = data.Country;
                string title = data.Title;
                string degree = data.Degree;
                string yearofgraduation = data.Yearofgraduation;
                // Perform the education test using the Education data
                negativeEducationPageObj.UpdateEducation(university, country, title, degree, yearofgraduation);
            }

        }

        [TearDown]
        public void TearDownActions()
        {
            driver.Quit();
        }

    }
}
