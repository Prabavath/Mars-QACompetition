using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
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
    public class NegativeTest : CommonDriver
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;
        [OneTimeSetUp]
        public void SetupReporting()
        {
            string reportPath = "D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Utilities\\Extent\\ExtentTest.cs";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private NegativePage negativeEducationPageObj = new NegativePage();
        private NegativePage negativeCertificationPageObj = new NegativePage();

        [SetUp]
        public void SetUpActions()
        {
            //Open chrome browser
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.LoginSteps();
        }

        [Test,Order(1)]
        public void Test1AddWithEducationData()
        {
            // Read test data from the JSON file using Jsonhelper
            List<EducationTestModel> AddEducationNegativedata = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\AddEducationNegativedata.json");
            Console.WriteLine(AddEducationNegativedata.ToString());
            foreach (var data in AddEducationNegativedata)

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
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "AddEducation");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                // Perform the education test using the Education data
                negativeEducationPageObj.AddEducation(university, country, title, degree, yearofgraduation);
               
            }
        }
        [Test, Order(2)]
        public void TestUpdateWithEducationData()
        {
            // Read test data from the JSON file
            List<EducationTestModel> UpdateEducationNegativedata = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\UpdateEducationNegativedata.json");
            Console.WriteLine(UpdateEducationNegativedata.ToString());
            foreach (var data in UpdateEducationNegativedata)

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
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "UpdateEducation");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                // Perform the education test using the Education data
                negativeEducationPageObj.UpdateEducation(university, country, title, degree, yearofgraduation);
            }

        }
        [Test, Order(3)]
        public void TestAddWithCertificationData()
        {
            // Read test data from the JSON file using Jsonhelper
            List<CertificationsTestModel> AddCertificationNegativedata = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\AddCertificationNegativedata.json");
            Console.WriteLine(AddCertificationNegativedata.ToString());
            foreach (var data in AddCertificationNegativedata)
            {
                // Access individual test data properties
                string certificate = data.Certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.CertifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.Year;
                Console.WriteLine(year);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "AddCertifications");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                // Perform the education test using the Education data
                negativeCertificationPageObj.AddCertifications(certificate, certifiedFrom, year);
            }
        }

        [Test, Order(4)]
        public void TestUpdateWithCertificationData()
        {
            // Read test data from the JSON file
            List<CertificationsTestModel> UpdateCertificationNegativedata = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\UpdateCertificationNegativedata.json");
            Console.WriteLine(UpdateCertificationNegativedata.ToString());
            foreach (var data in UpdateCertificationNegativedata)
            {
                // Access individual test data properties
                string certificate = data.Certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.CertifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.Year;
                Console.WriteLine(year);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "UpdateCertifications");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                // Perform the education test using the Education data
                negativeCertificationPageObj.UpdateCertifications(certificate, certifiedFrom, year);
            }       
        }
               
        [TearDown]
        public void TearDownActions()
        {
            driver.Quit();
            extent.Flush();
        }
        private string CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine(@"D:\IC Course\Competition Task\Mars-QACompetition\Mars-CompetitionNUnit\Mars-CompetitionNUnit\CompetionScreenshot", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }
        [OneTimeTearDown]
        public void ExtentTeardown()
        {
            extent.Flush();
        }


    }
}
