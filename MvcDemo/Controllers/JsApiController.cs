using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using XLWXLibrary.JSSDK;
using XLWXLibrary.WXEntity;
namespace MvcDemo.Controllers
{
    public class JsApiController : Controller
    {
        //
        // GET: /JsApi/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult JsApi()
        {
            SignPackage sSignConfig = JSSDKHelper.GetQySignPackage( QyJsApiEnum.getNetworkType );
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            ViewBag.config = serializer.Serialize( sSignConfig );
            return View();
        }

        //
        // GET: /JsApi/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /JsApi/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /JsApi/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /JsApi/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /JsApi/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /JsApi/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /JsApi/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
