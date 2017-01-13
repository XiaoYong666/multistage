using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 多级下拉联动.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 模拟省份数据
        /// </summary>
        /// <returns></returns>
        public List<Province> Provincelist()
        {
            List<Province> list = new List<Province>();
            list.Add(new Province() { PID = 1, ProvinceName = "广东" });
            list.Add(new Province() { PID = 2, ProvinceName = "北京" });
            list.Add(new Province() { PID = 3, ProvinceName = "上海" });
            list.Add(new Province() { PID = 4, ProvinceName = "河北" });
            list.Add(new Province() { PID = 5, ProvinceName = "贵州" });
            list.Add(new Province() { PID = 6, ProvinceName = "云南" });

            return list;
        }

        /// <summary>
        /// 模拟城市数据
        /// </summary>
        /// <returns></returns>
        public List<City> Citylist()
        {
            List<City> cityList = new List<City>();
            cityList.Add(new City() { CID = 1, PID = 1, CityName = "广州" });
            cityList.Add(new City() { CID = 2, PID = 1, CityName = "深圳" });
            cityList.Add(new City() { CID = 3, PID = 1, CityName = "惠州" });
            cityList.Add(new City() { CID = 4, PID = 1, CityName = "湛江" });
            cityList.Add(new City() { CID = 5, PID = 2, CityName = "北京" });
            cityList.Add(new City() { CID = 6, PID = 3, CityName = "上海" });
            cityList.Add(new City() { CID = 7, PID = 4, CityName = "唐山市" });
            cityList.Add(new City() { CID = 8, PID = 4, CityName = "保定市" });
            cityList.Add(new City() { CID = 9, PID = 4, CityName = "张家口市" });
            return cityList;
        }


        /// <summary>
        /// 获取省份
        /// </summary>
        public JsonResult GetProvincelist()
        {
            var list = Provincelist();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取城市
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public JsonResult GetCitylist(int pid)
        {
            var citys = Citylist().Where(m => m.PID == pid).ToList();

            List<SelectListItem> item = new List<SelectListItem>();

            foreach (var City in citys)
            {
                item.Add(new SelectListItem { Text = City.CityName, Value = City.CID.ToString() });
            }
            return Json(item, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Edit()
        {
            ViewBag.ProvinceList = Provincelist().Select(m => new SelectListItem()
            {
                Text = m.ProvinceName,
                Value = m.PID.ToString(),
                Selected = (m.PID == 4) //测试，默认让它绑定第四个
            }).ToList();
            ViewBag.CityList = Citylist().Select(m => new SelectListItem()
            {
                Text = m.CityName,
                Value = m.CID.ToString(),
                Selected = (m.CID == 8) //测试，默认让它绑定第四个
            }).ToList();
            return View();
        }
    }

    /// <summary>
    /// 省份模型
    /// </summary>
    public class Province
    {
        /// <summary>
        /// 省份ID
        /// </summary>
        public int PID { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

    }

    public class City
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CID { get; set; }

        /// <summary>
        /// 省份ID
        /// </summary>
        public int PID { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

    }

}