using FutureDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureDemo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Page1()
        {
            return View();
        }
        public ActionResult Page2()
        {
            var dataList = DataLogic.ReadFromJsonFile();
            return View(dataList);
        }
        public ActionResult Page3()
        {
            var dataList = DataLogic.ReadFromJsonFile();
            return View(dataList);
            return View();
        }

        public ActionResult AddNumber(string number)
        {
            float data = 0;
            if (float.TryParse(number, out data))
            {
                var dataList = DataLogic.ReadFromJsonFile();
                if (!dataList.Any(x => x.Data == data))
                {
                    dataList.Add(new UserData { Data = data, Display = false, AddDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
                    DataLogic.SaveToJsonFile(dataList);
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("can't add dulicate data", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("you need to enter a number", JsonRequestBehavior.AllowGet);

        }
        public ActionResult Approve(string number)
        {
            float data = 0;
            if (float.TryParse(number, out data))
            {
                var dataList = DataLogic.ReadFromJsonFile();
                var item = dataList.FirstOrDefault(x => x.Data == data);
                if (item != null)
                {
                    item.Display = true;
                }
                DataLogic.SaveToJsonFile(dataList);
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            return Json("you need to enter a number", JsonRequestBehavior.AllowGet);

        }


    }


}