using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.ListAllWarehouses;
using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace EvidencijaTransporta.EndToEndTests
{
	public class WarehousingTests
	{
		private IWebDriver driver;
		protected Repository _repository = new Repository();
		private int _id;

		[SetUp]
		public void SetUp()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://localhost:44318/");

			var request = new ListAllWarehousesRequest();

			var warehouses = _repository.GetListStoredProcedureWithParameters<ListAllWarehousesResponse, ListAllWarehousesRequest>(request);

			_id = warehouses.FirstOrDefault().Id;
		}

		[TearDown]
		public void TearDown()
		{
			driver.Close();
		}

		[Test]
		public void Index_CallPageWarehousing_OpenAllWarehouses()
		{
			IWebElement webElement = driver.FindElement(By.PartialLinkText("Warehousing"));

			webElement.Click();

			var url = driver.Url;

			url.Should().Be("https://localhost:44318/Warehouse");
		}

		[Test]
		public void Index_CallPagAbout()
		{
			IWebElement webElement = driver.FindElement(By.PartialLinkText("About"));

			webElement.Click();

			var url = driver.Url;

			url.Should().Be("https://localhost:44318/About");
		}

		[Test]
		public void Index_CallPageContact()
		{
			IWebElement webElement = driver.FindElement(By.PartialLinkText("Contact"));

			webElement.Click();

			var url = driver.Url;

			url.Should().Be("https://localhost:44318/Contact");
		}

		[Test]
		public void Index_CallPageTransport()
		{
			IWebElement webElement = driver.FindElement(By.PartialLinkText("Transport"));

			webElement.Click();

			var url = driver.Url;

			url.Should().Be("https://localhost:44318/Transport");
		}

		[Test]
		public void Index_CreateTransport()
		{
			driver.Navigate().GoToUrl("https://localhost:44318/Transport");
			IWebElement element = driver.FindElement(By.Id("selectType"));
			IWebElement date = driver.FindElement(By.Id("txtDate"));
			IWebElement amount = driver.FindElement(By.Id("txtAmount"));
			IWebElement vehicle = driver.FindElement(By.Id("txtVehicle"));
			IWebElement button = driver.FindElement(By.Id("createTransport"));

			SelectElement select = new SelectElement(element);

			date.SendKeys("01/01/2022");
			amount.SendKeys("10");
			vehicle.SendKeys("Boat");
			select.SelectByText("Water");

			button.Click();

			amount.Text.Should().BeEmpty();
			vehicle.Text.Should().BeEmpty();
		}

		[Test]
		public void Index_Details_OpensDetailsDiv()
		{
			driver.Navigate().GoToUrl("https://localhost:44318/Transport");

			IWebElement button = driver.FindElement(By.Id("details"));

			button.Click();

			var section = driver.FindElement(By.Id("dvDetails")).GetCssValue("display");

			section.Should().Be("block");
		}

		[Test]
		public void Index_HideDetails_HidesDetailsDiv()
		{
			driver.Navigate().GoToUrl("https://localhost:44318/Transport");

			IWebElement button = driver.FindElement(By.Id("details"));

			button.Click();

			IWebElement hideButton = driver.FindElement(By.Id("dvDetails")).FindElement(By.Id("hide"));

			hideButton.Click();

			var section = driver.FindElement(By.Id("dvDetails")).GetCssValue("display");

			section.Should().Be("none");
		}

		[Test]
		public void Index_StoreInWarehouse_OpensDiv()
		{
			driver.Navigate().GoToUrl("https://localhost:44318/Warehouse");

			IWebElement button = driver.FindElement(By.Id("dvTable")).FindElement(By.Id($"storeWarehouse-{_id}"));

			button.Click();

			var section = driver.FindElement(By.Id("dvStorage")).GetCssValue("display");

			section.Should().Be("block");
		}

		[Test]
		public void Index_ListStorage_OpensDiv()
		{
			driver.Navigate().GoToUrl("https://localhost:44318/Warehouse");

			IWebElement button = driver.FindElement(By.Id("dvTable")).FindElement(By.Id($"listStorage-{_id}"));

			button.Click();

			var section = driver.FindElement(By.Id("warehouseInfo")).GetCssValue("display");

			section.Should().Be("block");
		}

		[Test]
		public void Index_ListStorage_HidesDiv()
		{
			driver.Navigate().GoToUrl("https://localhost:44318/Warehouse");

			IWebElement button = driver.FindElement(By.Id("dvTable")).FindElement(By.Id($"listStorage-{_id}"));

			button.Click();

			IWebElement hideButton = driver.FindElement(By.Id("warehouseInfo")).FindElement(By.Id($"hide"));

			hideButton.Click();

			var section = driver.FindElement(By.Id("warehouseInfo")).GetCssValue("display");

			section.Should().Be("none");
		}
	}
}
