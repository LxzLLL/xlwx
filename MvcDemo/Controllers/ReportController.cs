using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using XLWXLibrary.WXHandler.WXQY.Menu;
using XLToolLibrary.Utilities;
namespace MvcDemo.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult NoiseReport()
        {
            ViewBag.pm = 25;
            //Dictionary<string,string> dictParam = new Dictionary<string, string> {{"department_id","3"},{"fetch_child","0"},{"status","0"} };
            Dictionary<string,string> dictParam = new Dictionary<string, string> { { "agentid", "2" } };
            //string strJson = "{\"userid\":\"luxiaolin\"}";
            string strJson =FileOperateHelper.ReadFile( HttpRuntime.AppDomainAppPath + @"bin\xmlConfig\JsonButtonConfig.txt");

            //ViewBag.Result = new MenuManager().Delete(dictParam );
            //ViewBag.Result = new MenuManager().Create(strJson, dictParam );
            ViewBag.Result = new MenuManager().Get( dictParam );
            return View();
        }

    }
}
