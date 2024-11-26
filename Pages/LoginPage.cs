﻿using OpenQA.Selenium;

namespace StorySpoilAppTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly string Url = BaseUrl + "/User/Login";

        //elements
        private readonly By usernameField = By.Id("username");
        private readonly By passwordField = By.Id("password");
        private readonly By loginBtn = By.CssSelector("button[type='submit']");
        private readonly By forgotPasswordLink = By.CssSelector(".text-muted");
        private readonly By createNewBtn = By.CssSelector(".btn.btn-outline-info");

        //error msgs
        private readonly By mainErrorMssg = By.CssSelector(".text-info.validation-summary-errors > ul > li");
        private readonly Dictionary<string, By> requredErrorMsgs = new()
        {
            {"UsernameField",By.CssSelector("span[data-valmsg-for='Username']") },
            {"PasswordField",By.CssSelector("span[data-valmsg-for='Password']") },
        };
        //methods-> public
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
        public void TypeUsername(string username)
        {
            Type(usernameField, username);
        }
        public void TypePassword(string password)
        {
            Type(passwordField, password);
        }
        public void ClickLoginBtn()
        {
            Click(loginBtn);
        }
        public void Login(string username, string password)
        {
            TypeUsername(username);
            TypePassword(password);
            ClickLoginBtn();
        }

        //error messages text
        public string GetErrorMsg_RequiredField(string fieldName)
        {
            if (fieldName == "username")
            {
                return GetText(requredErrorMsgs["UsernameField"]);
            }
            else if (fieldName == "password")
            {
                return GetText(requredErrorMsgs["PasswordField"]);
            }
            else
            {
                return null;
            }
        }
        public string GetMainErrorMsg()
        {
            return GetText(mainErrorMssg);
        }
    }
}
