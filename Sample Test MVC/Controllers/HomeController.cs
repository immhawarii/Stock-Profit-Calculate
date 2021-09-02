using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample_Test_MVC.Models;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace Sample_Test_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult SampleTest()
        {
            ViewBag.Message = "Sample Test Page";
            return View(new StockValueModel());
        }

        [HttpPost]
        public ActionResult SampleTest(string data)
        {
            StockValueModel stockValue = new StockValueModel();
            var serializer = new JavaScriptSerializer();

            try 
            {
                dynamic jsonData = serializer.Deserialize(data, typeof(object));

                List<int> currentValue = new List<int>();
                List<int> futureValue = new List<int>();

                int indexCurrent = 0;
                foreach (var item in jsonData[1]["current"])
                {
                    currentValue.Add(int.Parse(item));
                    indexCurrent++;
                }

                int indexFuture = 0;
                foreach (var item in jsonData[2]["future"])
                {
                    futureValue.Add(int.Parse(item));
                    indexFuture++;
                }

                List<int> indexProfit = new List<int>();
                bool isProfit = false;
                int profit = 0;
                if (currentValue.Count == futureValue.Count)
                {
                    // Traverse both array and compare
                    //each element
                    for (int i = 0;  i < currentValue.Count;  i++)
                    {
                        // set true if each corresponding
                        //elements of arrays are equal 
                        if (futureValue[i] > currentValue[i])
                        {
                            indexProfit.Add(i);
                            isProfit = true;
                        }
                        else
                        {
                            isProfit = false;
                        }
                    }
                }

                if (indexProfit.Count > 0)
                {
                    foreach (var item in indexProfit)
                    {
                        profit += futureValue[item] - currentValue[item];
                    }
                }

                return Json(profit);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }

        }
    }
}

