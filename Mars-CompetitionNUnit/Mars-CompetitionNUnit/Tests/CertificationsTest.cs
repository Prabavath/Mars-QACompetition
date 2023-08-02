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
    public class CertificationsTest:CommonDriver
    {
        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private CertificationPage CertificationsPageObj = new CertificationPage();

        [SetUp]
        public void SetUpActions()
        {
            
            //Open chrome browser
            driver = new ChromeDriver();
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
                // Perform the education test using the Education data
                CertificationsPageObj.AddCertifications(certificate,certifiedFrom,year);
                string newCertificate = CertificationsPageObj.GetVerifyCertificationList();
                if (certificate == newCertificate)
                {
                    Assert.AreEqual(certificate, newCertificate, "Actual certificate and expected certificate do not match");
                }
                else
                {
                    Assert.AreNotEqual(certificate, newCertificate, "Actual certificate and expected certificate do match");
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
                    string newUpdatedCertificate = CertificationsPageObj.GetVerifyUpdateCertificationsList();
                    if (certificate == newUpdatedCertificate)
                    {
                        Assert.AreEqual(certificate, newUpdatedCertificate, "Actual certificate and expected certificate do not match");
                    }
                    else
                    {
                        Assert.AreNotEqual(certificate, newUpdatedCertificate, "Actual certificate and expected certificate do match");
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
                if (certificate == deletedCertificate)
                {
                    Assert.AreEqual(certificate, deletedCertificate, "Actual certificate and expected certificate do not match");
                }
                else
                {
                    Assert.AreNotEqual(certificate, deletedCertificate, "Actual certificate and expected certificate do match");
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
