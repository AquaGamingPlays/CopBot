using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;

namespace CopBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string baseUrl = "https://shopnicekicks.com/products/";
            Console.WriteLine("What shoe would you like to buy from NiceKicks?");
            //string Item = Console.ReadLine();
            string command = Console.ReadLine();
            if (File.Exists(Environment.CurrentDirectory + "Setup.txt") == true)
            {
                File.AppendAllText("Setup.txt" , "xd");
            }

            if (command == "c")
            {
                string Item = "NIKE AIR MAX 90 ESSENTIAL MEN'S SHOE - MARS STONE/VINTAGE CORAL/DESERT SAND";
                Item = Item.Replace("-", "");
                Item = Item.Replace(" ", "-");
                Item = Item.Replace("--", "-");
                Item = Item.Replace("/", "-");
                Item = Item.Replace("'", "");
                string SignInUrl = "https://shopnicekicks.com/account/login/";
                string Url = baseUrl + Item;
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("user-data-dir=C:/Users/khali/AppData/Local/Google/Chrome/User Data/Default/Default");
                options.AddArguments("--start-maximized");

                IWebDriver browser = new ChromeDriver(options);
                var _cookies = browser.Manage().Cookies.AllCookies;
                browser.Navigate().GoToUrl(Url);
                if (browser.PageSource.Contains("product-form") == false)
                {
                    Console.WriteLine("No Add to cart button");
                }
               
                string classname = "single-option-selector";
                var option = browser.FindElement(By.ClassName(classname));
                var selectElement = new SelectElement(option);
                selectElement.SelectByText("9");
                browser.FindElement(By.XPath("//*[@id=\"product-form\"]/div[5]/input")).Submit();
                browser.FindElement(By.XPath("//*[@id=\"tos_acceptance\"]")).Click();
                browser.FindElement(By.XPath("//*[@id=\"cart-form\"]/div/div[2]/div/input[2]")).Click();
            }
            if (command == "d")
            {
                
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            //browser.Close();
        }
    }
}
