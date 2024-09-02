using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace Kurtosys
{
    public class UITest
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()
        {
            driver = new ChromeDriver("");
        }

        [Test]

        public void WhitePapersDownloadErrorMessageTest()
        {
            driver.Url = "https://www.kurtosys.com/";
            driver.Manage().Window.Maximize();
            IWebElement whitePapersAndEbookLink = driver.FindElement(By.XPath("//span[contains(.,'White Papers & eBooks')]"));
            IWebElement whitePaperLink = driver.FindElement(By.XPath("//a[@href='https://www.kurtosys.com/white-papers/institutional-reporting-survey/']"));
            IWebElement firstNameField = driver.FindElement(By.XPath("//input[@class='elementor-field elementor-size-sm  elementor-field-textual' and @id='form-field-firstname']"));
            IWebElement lastNameField = driver.FindElement(By.XPath("//input[@class='elementor-field elementor-size-sm  elementor-field-textual' and @id='form-field-lastname']"));
            IWebElement companyNameField = driver.FindElement(By.XPath("//input[@class='elementor-field elementor-size-sm  elementor-field-textual' and @id='form-field-company']"));
            IWebElement industryDropdown = driver.FindElement(By.Id("form-field-industry"));
            IWebElement industryDropdownMenuOption = driver.FindElement(By.XPath("//option[@value='Banking']"));
            IWebElement dowloadButton = driver.FindElement(By.XPath("//button[@class='elementor-button elementor-size-sm']"));

            whitePapersAndEbookLink.Click();
            string pageTitle = driver.Title;
            Debug.Assert(pageTitle.Contains("White Papers"));

            whitePaperLink.Click();
            firstNameField.SendKeys("QA");
            lastNameField.SendKeys("Test");
            companyNameField.SendKeys("Denva");
            industryDropdown.Click();
            industryDropdownMenuOption.Click();
            string getDownloadButtonText = driver.FindElement(By.XPath("//button[contains(.,'Proceed to download')]")).Text;
            Debug.Assert(getDownloadButtonText.Contains("Proceed to download"));

        }

        [TearDown]

        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}