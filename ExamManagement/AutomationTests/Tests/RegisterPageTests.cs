using AutomationTests.Helpers;
using AutomationTests.PageObjects.Dashboard;
using AutomationTests.PageObjects;
using System;
using Xunit;

namespace AutomationTests.Tests
{
    public class RegisterTests : Browser, IDisposable
    {
        public RegisterPage registerPage;
        public LoginPage loginPage;

        public RegisterTests() : base()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication/register");
            registerPage = new RegisterPage(Driver);
        }

        [Fact]
        public void Register_With_Valid_Credentials()
        {
            String nowString = DateTime.Now.ToString();
            registerPage.Register(nowString, nowString,"Faculty",nowString+"@faculty.ro","student");
            loginPage = new LoginPage(Driver);
            loginPage.WaitForPageToLoad("app-login");
            Assert.True(loginPage.BtnLogin.Displayed);
        }

        [Fact]
        public void Register_With_Invalid_Data()
        {
            String nowString = DateTime.Now.ToString();
            registerPage.Register(nowString, nowString, "Faculty", nowString, "student");
            Assert.True(registerPage.TxtErrors.Displayed);
        }

        public void Dispose()
        {
            CloseBrowser();
        }
    }
}