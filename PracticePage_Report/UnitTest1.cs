using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using DemoQASite;

namespace PracticePage_Report
{
    [TestClass]
    public class UnitTest1 : Selenium_Base
    {
        public static ExtentTest Test;

        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            Extent = new ExtentReports();

            var HtmlReporter = new ExtentHtmlReporter(@"E:\TestReportResults\PracticePageReport" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            Extent.AttachReporter(HtmlReporter);
        }

        [Test, Order(1)]
        public void RadioButtonTest()
        {
            Test = null;
            Test = Extent.CreateTest("RadioButton").Info("RadioButtonTesting");
            try
            {
                GoToPracticePage();
                click(FindXPath("//input[@id='benzradio']"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch(Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
 
        }

        [Test, Order(2)]
        public void SelectClassTest()
        {
            Test = null;
            Test = Extent.CreateTest("SelectClass").Info("SelectClassTesting");
            try
            {
                GoToPracticePage();
                click(FindXPath("//select[@id='carselect']"));
                wait(2000);
                click(FindXPath("//option[text()='Benz']"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(3)]
        public void MultipleSelectClassTest()
        {
            Test = null;
            Test = Extent.CreateTest("MultipleSelectClass").Info("MultipleSelectClassTesting");
            try
            {
                GoToPracticePage();
                getAction().KeyDown(Keys.LeftControl)
                .MoveToElement(FindXPath("//option[text()='Apple']"))
                .Click()
                .MoveToElement(FindXPath("//option[text()='Orange']"))
                .Click()
                .Release()
                .Build()
                .Perform();

            wait(1000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(4)]
        public void CheckBoxTest()
        {
            Test = null;
            Test = Extent.CreateTest("CheckBox").Info("CheckBoxTesting");
            try
            {
                GoToPracticePage();
                click(FindXPath("//input[@id='bmwcheck']"));
                wait(2000);
                click(FindXPath("//input[@id='benzcheck']"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(5)]
        public void SwitchWindowTest()
        {
            Test = null;
            Test = Extent.CreateTest("SwitchWindow").Info("SwitchWindowTesting");
            try
            {
                GoToPracticePage();
                click(FindXPath("//button[@id='openwindow']"));
                wait(2000);
                switchToWindow(1);
                wait(2000);
                scrollPage(0, 800);
                wait(5000);
                close();
                switchToWindow(0);
                wait(1000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(6)]
        public void SwitchTabTest()
        {
            Test = null;
            Test = Extent.CreateTest("SwitchTab").Info("SwitchTabTesting");
            try
            {
                GoToPracticePage();
                click(FindXPath("//a[@id='opentab']"));
                wait(2000);
                switchToWindow(1);
                wait(2000);
                scrollPage(0, 1000);
                wait(5000);
                close();
                switchToWindow(0);
                wait(1000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(7)]
        public void SwitchAlertTest()
        {
            Test = null;
            Test = Extent.CreateTest("SwitchAlert").Info("SwitchAlertTesting");
            try
            {
                GoToPracticePage();
                sendKeys(FindXPath("//input[@name='enter-name']"), "Laxmi");
                wait(1000);
                sendKeys(FindXPath("//input[@name='enter-name']"), "Laxmi");
                wait(1000);
                click(FindXPath("//input[@id='alertbtn']"));
                wait(2000);
                acceptAlert();
                sendKeys(FindXPath("//input[@name='enter-name']"), "Laxmi");
                wait(1000);
                click(FindXPath("//input[@id='confirmbtn']"));
                wait(2000);
                rejectAlert();

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(8)]
        public void EnableDisableTest()
        {
            Test = null;
            Test = Extent.CreateTest("EnableDisable").Info("EnableDisableTesting");
            try
            {
                GoToPracticePage();
                click(FindXPath("//input[@id='disabled-button']"));
                wait(2000);
                Disable();
                wait(1000);
                click(FindXPath("//input[@id='enabled-button']"));
                wait(2000);
                sendKeys(FindXPath("//input[@id='enabled-example-input']"), "Laxmi");
                wait(1000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(9)]
        public void HideShowTest()
        {
            Test = null;
            Test = Extent.CreateTest("HideShow").Info("HideShowTesting");
            try
            {
                GoToPracticePage();
                sendKeys(FindXPath("//input[@id='displayed-text']"), "Laxmi");
                wait(2000);
                click(FindXPath("//input[@id='hide-textbox']"));
                wait(2000);
                click(FindXPath("//input[@id='show-textbox']"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(10)]
        public void MouseHoverTest()
        {
            Test = null;
            Test = Extent.CreateTest("MouseHover").Info("MouseHoverTesting");
            try
            {
                GoToPracticePage();
                scrollPage(0, 300);
                wait(1000);
                hoverOnto(FindXPath("//button[@id='mousehover']"));
                wait(2000);
                click(FindXPath("//a[text()='Top']"));
                wait(2000);
                scrollPage(0, 400);
                wait(1000);
                hoverOnto(FindXPath("//button[@id='mousehover']"));
                wait(2000);
                click(FindXPath("//a[text()='Reload']"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(11)]
        public void iframeTest()
        {
            Test = null;
            Test = Extent.CreateTest("iframe").Info("iframeTesting");
            try
            {
                GoToPracticePage();
                scrollPage(0, 900);
                wait(1000);
                switchToanotherFrame("//iframe[@id='courses-iframe']");
                wait(1000);
                scrollPage(0, 1500);
                wait(1000);
                scrollPage(0, -1000);
                wait(3000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }
        public void GoToPracticePage()
        {
            open("https://courses.letskodeit.com/practice");
            wait(2000);
        }

        public void Disable()
        {
            try
            {
                sendKeys(FindXPath("//input[@id='enabled-example-input']"), "l");
                wait(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Disable to click");
            }
        }

        [TearDown]
        public void CloseChrome()
        {
            Driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            Extent.Flush();
        }
    }
}
