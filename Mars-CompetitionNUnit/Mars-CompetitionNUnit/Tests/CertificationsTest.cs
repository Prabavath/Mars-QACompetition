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
using System.Diagnostics.Metrics;

namespace Mars_CompetitionNUnit.Tests
{
    [TestFixture]
    public class CertificationsTest : CommonDriver
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
        private CertificationPage CertificationsPageObj = new CertificationPage();

        [SetUp]
        public void SetUpActions()
        {
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.LoginSteps();
        }
        [Test, Order(1)]
        public void TestAddWithCertificationData()
        {
            // Read test data from the JSON file using Jsonhelper
            List<CertificationsTestModel> AddCertificationsPositivedata = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\AddCertificationsPositivedata.json");
            Console.WriteLine(AddCertificationsPositivedata.ToString());
            foreach (var data in AddCertificationsPositivedata)
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
                CertificationsPageObj.AddCertifications(certificate,certifiedFrom,year);
                string newCertificate = CertificationsPageObj.GetVerifyCertificationList();
                if (certificate == newCertificate)
                {
                    test.Pass("Added Certifications and Expected Certifications match");

                }
                else
                {
                    test.Fail("Added Certifications and Expected Certifications do not match");
                }

            }
        }

        [Test, Order(2)]
        public void TestUpdateWithCertificationData()
        {
            // Read test data from the JSON file
            List<CertificationsTestModel> UpdateCertificationsPositivedata = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\UpdateCertificationsPositivedata.json");
            Console.WriteLine(UpdateCertificationsPositivedata.ToString());
            foreach (var data in UpdateCertificationsPositivedata)
            {
                // Access individual test data properties
                string certificate = data.Certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.CertifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.Year;
                Console.WriteLine(year);
               // Perform the education test using the Education data
                try
                {
                    CertificationsPageObj.UpdateCertifications(certificate,certifiedFrom,year);
                    test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                    string screenshotPath = CaptureScreenshot(driver, "UpdateCertifications");
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                    string newUpdatedCertificate = CertificationsPageObj.GetVerifyUpdateCertificationsList();
                    string verifyRecord = $"//tbody/tr[td[text()='{certificate}'] and td[text()='{year}']]//span[2]";
                    IWebElement desiredElement = driver.FindElement(By.XPath(verifyRecord));
                    // Perform the verification
                    Console.WriteLine("Expected Data: " + certificate);
                    Console.WriteLine("Updated Education Data: " + newUpdatedCertificate);
                    if (desiredElement != null && desiredElement.Displayed)

                    {
                        test.Pass("Updated Certifications and Expected Certifications match");
                    }
                    else
                    {
                        test.Fail("Updated Certifications and Expected Certifications do not match");
                    }

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Upadated element not found", certificate.ToString());
                }
            }
        }
        [Test, Order(3)]
        public void TestDeleteWithCertificationData()
        {
            // Read test data from the JSON file
            List<CertificationsTestModel> Deletedata1 = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>("D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Json Datafile\\Deletedata1.json");
            Console.WriteLine(Deletedata1.ToString());
            foreach (var data in Deletedata1)
            {
                // Access individual test data properties
                string certificate = data.Certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.CertifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.Year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                CertificationsPageObj.DeleteCertification(certificate, year);
                string deletedCertificate = CertificationsPageObj.GetVerifyDeleteCertificationList();
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "AddEducation");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                if (certificate != deletedCertificate)
                {
                    test.Pass("Deleted Certifications and Expected Certifications match");
                }
                else
                {
                    test.Fail("Deleted Certifications and Expected Certifications do not match");
                }
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
