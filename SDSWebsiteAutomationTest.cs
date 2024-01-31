using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;




namespace SeleniumUITest.Tests
{
    [TestClass]
    public class SDSWebsiteAutomationTest
    {
        [TestMethod]
        public void AutomationTest()
        {
            // Create an instance of ChromeDriver
            IWebDriver driver = new ChromeDriver();

            try
            {
                // 1. Homepage Verification (Launching the browser and accepting the cookies warning)

                driver.Navigate().GoToUrl("https://www.s-d-s.co.uk");
                driver.Manage().Window.Maximize();
                VerifyTitleAndURL(driver, "SDS: Social Housing Development Software | Land Development Services", "https://s-d-s.co.uk/");
                ClickOnGotItButton(driver, "GOT IT");

                // 2. Navigation Test

                NavigateToSection(driver, "menu-item-77085");
                VerifyTitleAndURL(driver, "Products - SDS software", "https://s-d-s.co.uk/products/");

                NavigateToSection(driver, "menu-item-76684");
                VerifyTitleAndURL(driver, "Shelton Development Services (SDS) Consultancy Services | UK", "https://s-d-s.co.uk/consultancy/");
                                                    
                NavigateToSection(driver, "menu-item-77146");
                VerifyTitleAndURL(driver, "Shelton Development Services (SDS) | Software Training & Consultancy", "https://s-d-s.co.uk/services/");

                NavigateToSection(driver, "menu-item-77155");
                VerifyTitleAndURL(driver, "SDS Support Team | Shelton Development Services Help Desk", "https://s-d-s.co.uk/support/");

                NavigateToSection(driver, "menu-item-78438");
                VerifyTitleAndURL(driver, "SDS Software Industry Events and Conferences United Kingdom", "https://s-d-s.co.uk/events/");
                ClickOnGotItButton(driver, "GOT IT");

                NavigateToSection(driver, "menu-item-83988");
                VerifyTitleAndURL(driver, "Blog - SDS software", "https://s-d-s.co.uk/blog/");

                NavigateToSection(driver, "menu-item-75311");
                VerifyTitleAndURL(driver, "Contact SDS Help Desk | Shelton Development Services", "https://s-d-s.co.uk/contact/");

                // 3. Product Information Test

                // Selecting Landval option from dropdown and validating text on the page
                SelectProduct(driver, "menu-item-77085", "menu-item-76509");
                // Verifying that the content displayed on this page is matching with expected one.
                VerifyProductInformation(driver, "Landval: Land Valuation Software | Property Valuation | SDS UK", "Competitive Land Valuation");

                // 4. Contact Form Test

                // Entering text in the contact form fields
                NavigateToSection(driver, "menu-item-75311");
                FillContactForm(driver, "Shubham", "Sonwane", "TestCompany", "1234567890", "Shubham@gmail.com");
            }


            finally
            {
                // Close the browser
               // driver.Quit();
            }
        }

        // Method to verify title and URL on every page.
        private static void VerifyTitleAndURL(IWebDriver driver, string expectedTitle, string expectedURL)
        {
            string actualTitle = driver.Title;
            string actualURL = driver.Url;

            Assert.AreEqual(expectedTitle, actualTitle, $"Title mismatch: Expected - {expectedTitle}, Actual - {actualTitle}");
            Assert.AreEqual(expectedURL, actualURL, $"URL mismatch: Expected - {expectedURL}, Actual - {actualURL}");
        }

        // Method for navigating to every page.
        private static void NavigateToSection(IWebDriver driver, string sectionId)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Increased timeout

            try
            {
                IWebElement sectionLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(sectionId)));
                sectionLink.Click();
            }
            catch (Exception ex)
            {
                // Re-locate the element and try clicking again
                if (ex is StaleElementReferenceException || ex is ElementClickInterceptedException)
                {
                    IWebElement sectionLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(sectionId)));
                    ScrollIntoView(driver, sectionLink);

                    // Wait for the intercepting element to be invisible
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".litho-cookie-policy-wrapper")));

                    sectionLink.Click();
                }
                else
                {
                    // If it's a different exception, rethrow it
                    throw;
                }
            }
        }

        // Javascript click method 
        private static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }





        // Method to handle cookies request on every page.
        private static void ClickOnGotItButton(IWebDriver driver, string elementText)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement gotItButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(elementText)));
            gotItButton.Click();
        }

        // Method to select the product from dropdown
        private static void SelectProduct(IWebDriver driver, string dropdownId, string productId)
        {
            WaitForElementToBeVisible(driver, By.Id(dropdownId));
            IWebElement sectionLink = driver.FindElement(By.Id(dropdownId));
            Actions act = new Actions(driver);
            act.MoveToElement(sectionLink).Perform();

            WaitForElementToBeVisible(driver, By.Id(productId));

            IWebElement productLink = driver.FindElement(By.Id(productId));
            productLink.Click();
        }

        //Created ExplicitWait method to wait for the element util its ready to click
        private static void WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }



        // Method to verify the product details like product text and also verifying the page title
        private static void VerifyProductInformation(IWebDriver driver, string expectedTitle, string expectedText)
        {
            string actualTitle = driver.Title;
            string actualText = driver.FindElement(By.XPath("//h1[text()='Competitive Land Valuation']")).Text;

            if (actualTitle != expectedTitle)
                throw new Exception($"Title mismatch: Expected - {expectedTitle}, Actual - {actualTitle}");

            if (actualText != expectedText)
                throw new Exception($"Text mismatch: Expected - {expectedText}, Actual - {actualText}");
        }

        // Method to fill contact details of the user on the contact page.
        private static void FillContactForm(IWebDriver driver, string fname, string lname, string company, string number, string emailId)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 1.5)");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstNameInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='First name*']")));
            firstNameInput.SendKeys(fname);

            IWebElement lastNameInput = driver.FindElement(By.XPath("//input[@placeholder='Last name*']"));
            lastNameInput.SendKeys(lname);

            IWebElement companyNameInput = driver.FindElement(By.XPath("//input[@placeholder='Company name*']"));
            companyNameInput.SendKeys(company);

            IWebElement phoneNumberInput = driver.FindElement(By.XPath("//input[@name=\"phonenumber\"]"));
            phoneNumberInput.SendKeys(number);

            IWebElement emailInput = driver.FindElement(By.XPath("//input[@name=\"email-address\"]"));
            emailInput.SendKeys(emailId);
        }
    }
}

