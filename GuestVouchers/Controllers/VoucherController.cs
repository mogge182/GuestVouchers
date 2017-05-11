using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace GuestVouchers.Controllers
{
    public class VoucherController : Controller
    {
        // GET: Voucher
        public ActionResult Index()
        {
            return View();
        }

        [Route("voucher/getvoucher")]
        public string GetVoucher()
        {
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Server.MapPath("~/App_Data/XmlDB.xml"), FileMode.Open);
            xdoc.Load(rfile);
            rfile.Close();
            XmlNodeList list = xdoc.GetElementsByTagName("Voucher");
            XmlElement cl;

            for (int i = 0; i < list.Count; i++)
            {
                cl = (XmlElement)xdoc.GetElementsByTagName("Code")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName("Used")[i];
                if (add.InnerText == "false")
                {
                    add.InnerText = true.ToString();
                    xdoc.Save(Server.MapPath("~/App_Data/XmlDB.xml"));
                    return cl.InnerText;
                }
            }
            rfile.Close();

            return "No voucher found";


        }
    }
}