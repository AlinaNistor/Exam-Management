using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomationTests.PageObjects
{
    public class RegisterPage: BasePage
    {
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        #region Register section

        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='lastName']")]
        public IWebElement TxtLastName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='firstName']")]
        public IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='facultyId']")]
        public IWebElement TxtFaculty { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='email']")]
        public IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name='password']")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement BtnRegister { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='errors']")]
        public IWebElement TxtErrors { get; set; }
        #endregion

        public void Register(string lastName, string firstName, string faculty, string email, string password)
        {
            TxtLastName.SendKeys(lastName);
            TxtFirstName.SendKeys(firstName);
            TxtFaculty.SendKeys(faculty);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnRegister.Click();
        }
    }
}
