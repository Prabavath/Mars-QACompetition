﻿using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace Mars_CompetitionNUnit.Utilities.Extent
{
    public class ExtentTest
    {
#pragma warning disable CS8618
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            string reportPath = "D:\\IC Course\\Competition Task\\Mars-QACompetition\\Mars-CompetitionNUnit\\Mars-CompetitionNUnit\\Utilities\\Extent\\ExtentTest.cs"; // Update this with the desired report path
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
       
        [OneTimeTearDown]
        public void ReportTeardown()
        {
            extent.Flush();
        }
    }
}
    

