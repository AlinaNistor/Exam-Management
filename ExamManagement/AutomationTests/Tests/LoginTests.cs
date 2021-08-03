using AutomationTests.Helpers;
using AutomationTests.PageObjects.Dashboard;
using AutomationTests.PageObjects;
using System;
using Xunit;

namespace AutomationTests.Tests
{
    public class LoginTests : Browser, IDisposable
    {
        public LoginPage loginPage;
        public DashboardPage dashboardPage;

        public LoginTests() : base()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication/login/");
            loginPage = new LoginPage(Driver);
        }

        [Fact]
        public void Login_With_Valid_Credentials()
        {
            loginPage.Login("ana-maria.atasiei@student.tuiasi.ro", "atasiei");
            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("app-dashboard");
            Assert.True(dashboardPage.ContainerDashboard.Displayed);
        }

        [Fact]
        public void Login_With_Invalid_Credentials()
        {
            loginPage.Login("Admin@gmail.com", "12345678");
            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[id='errors']");
            Assert.True(loginPage.ErrInvalidCred.Displayed);
        }

        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
