using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selinium_Testing.DbTesting;
using System.Data.SqlClient;

namespace Selinium_Testing
{
    class NUnitTestClass
    {
        IWebDriver driver;
        Boolean isValid = false;

        [SetUp]
        public void FireFoxBrowser()
        {
            driver = new FirefoxDriver();
            ShoppingTest();
        }
        [SetUp]
        public void ChromeBrowser()
        {
            driver = new ChromeDriver();
            ShoppingTest();
        }
        [SetUp]
        public void InternetExplorer()
        {
            driver = new InternetExplorerDriver();
            ShoppingTest();
        }
        [SetUp]
        public void Edge()
        {
            driver = new EdgeDriver();
            ShoppingTest();
        }




        public void ShoppingTest()
        {
            string username="", password="";
            Boolean found = false;
            Boolean found2 = false;
            string productName;

            SqlConnection cnn;
                cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDb;Integrated Security=true;AttachDbFileName=|DataDirectory|\\TheCakeShop.mdf");
                cnn.Open();
                Console.WriteLine("Db Openned");

                string queryString = 
                  "SELECT Username, Password from users "
                + "WHERE Username = @username "
                + "And Password = @password";
                SqlCommand command = new SqlCommand(queryString, cnn);

                Console.Write("Enter Username: ");
                string UN = Console.ReadLine();

                Console.Write("Enter Password: ");
                string PW = Console.ReadLine();

                command.Parameters.AddWithValue("@username", UN);
                command.Parameters.AddWithValue("@password", PW);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        username = reader[0].ToString();
                        password = reader[1].ToString();
                        found = true;
                    }
            reader.Close();

                    
            if(found == true)
            {
                test1(username, password);

                 string queryString1 =
                   "SELECT Name from products "
                 + "WHERE Name = @productName ";
                SqlCommand command1 = new SqlCommand(queryString1, cnn);

                Console.Write("Enter ProductName: ");
                productName = Console.ReadLine();

                command1.Parameters.AddWithValue("@productName", productName);

                SqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    productName = reader1[0].ToString();
                    found2 = true;
                }

                if (found2 == true)
                {
                    test2(productName);
                    test3();
                    test4();
                    test5();
                    test6();
                }
                else
                {
                    Console.WriteLine("Product Didn't Exists In Inventory");
                }
            }
            else
            {
                Console.WriteLine("UserName Or Password Is In Correct");
            }
                
            
        }
        [Test]
        public void test1(string username, string password)
        {
            driver.Url = "http://localhost:62525/Account/Login";
            driver.Manage().Window.Maximize();
            Thread.Sleep(10000);

            IWebElement loginForm = driver.FindElement(By.ClassName("login"));
            IWebElement userNameTextBox = loginForm.FindElement(By.Id("Username"));
            IWebElement passwordTextBox = loginForm.FindElement(By.Id("Password"));

            userNameTextBox.SendKeys(username);
            passwordTextBox.SendKeys(password);
            IWebElement loginButton = loginForm.FindElement(By.ClassName("btn"));
            loginButton.Click();
            Thread.Sleep(10000);
        }
        [Test]
        public void test2(string productName)
        {
            IWebElement bananaCupcake = driver.FindElement(By.LinkText(productName));
            bananaCupcake.Click();
            Thread.Sleep(5000);

        }

        [Test]
        public void test3()
        {
            IWebElement bananaCupcakeAdToCart = driver.FindElement(By.ClassName("addtocart"));
            bananaCupcakeAdToCart.Click();
            Thread.Sleep(5000);
        }

        [Test]
        public void test4()
        {
            IWebElement proceedToCartBlock = driver.FindElement(By.ClassName("ajaxcart"));
            IWebElement proceedoCart = proceedToCartBlock.FindElement(By.TagName("a"));
            proceedoCart.Click();
            Thread.Sleep(5000);
        }

        [Test]
        public void test5()
        {
            IWebElement proceedToCheckoutBlock = driver.FindElement(By.ClassName("wc-proceed-to-checkout"));
            IWebElement proceedoCart = proceedToCheckoutBlock.FindElement(By.TagName("a"));
            proceedoCart.Click();
            Thread.Sleep(5000);
        }

        [Test]
        public void test6()
        {
            driver.Url = " https://www.sandbox.paypal.com/webapps/hermes?token=85K62980C2708812K&useraction=commit&mfid=1546277129329_ba90244142939";
            string pageTitle = driver.Title;
            if (pageTitle == "Log in to your PayPal account")
            {
                Console.WriteLine("Your Purchased Successfull");
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }

}