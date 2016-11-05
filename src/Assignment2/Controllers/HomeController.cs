using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Sakura.AspNetCore;


namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        IHostingEnvironment env = null;
        ShoppingContext context = null;
        public HomeController(ShoppingContext _context,IHostingEnvironment _env)
        {
            context = _context;
            env = _env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            //ViewBag.CreatedDate = System.DateTime.Now.ToString();
           // ViewData["SessionName"] = HttpContext.Session.GetString("name");
           // ViewData["SessionType"] = HttpContext.Session.GetString("type");

           // ViewBag.CatList = context.TblCategory.ToList<TblCategory>();
            return View();
        }
        #region AddCategory
        [HttpGet]
        public IActionResult Category()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Category(TblCategory C)
        {
            C.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");
            C.ModifyDate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");
            context.TblCategory.Add(C);
            context.SaveChanges();
            ViewBag.Message = "Your Desired Category Added Successfully";

             return View();
            //return RedirectToAction("Category");
        }
        #endregion

        public IActionResult Categories()
        {
            IList<TblCategory> CatL = context.TblCategory.ToList<TblCategory>();
            ViewBag.CL = CatL;
            return View();
        }
        #region AddSubCategory
        [HttpGet]
        public IActionResult SubCategory()
        {
            IList<TblCategory> CatL = context.TblCategory.ToList<TblCategory>();
            ViewBag.CL = CatL;
            
            return View();
        }
        [HttpPost]
        public IActionResult SubCategory(TblSubCategory SC)
        {
           

            SC.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");

            SC.ModifyDate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");

            context.TblSubCategory.Add(SC);
            context.SaveChanges();
            ViewBag.Message = "Your Desired SubCategory Added Successfully";
            //return View();
            return RedirectToAction("SubCategory");
        }
        #endregion
        #region AddProducts
        [HttpGet]
        public IActionResult Product()
        {
            IList<TblCategory> CatL = context.TblCategory.ToList<TblCategory>();
            ViewBag.CL = CatL;
            IList<TblSubCategory> SCatL = context.TblSubCategory.ToList<TblSubCategory>();
            ViewBag.SCL = SCatL;
            return View();
        }
        [HttpPost]
        public IActionResult Product(TblProduct P)
        {
            foreach(var file in Request.Form.Files)
            {
                string name = file.Name;
                string ext = System.IO.Path.GetExtension(file.FileName);
                string filename = DateTime.Now.ToString("ddMMyyyyhhmmss")+ ext;

                P.ProductImage = filename;
                string path = env.WebRootPath + "/Data/pimg/" + filename;

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
            }

            P.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");

            P.ModifyDate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");

            context.TblProduct.Add(P);
            context.SaveChanges();
            ViewBag.Message = "Your Desired Product Added Successfully";
            
            //return View();
            return RedirectToAction("Product");
        }
        #endregion
        #region ShowProducts
        public IActionResult AddedProducts(int? Category, int page=1)
        {
               ViewBag.Category=context.TblCategory.ToList<TblCategory>();
               if (Category == null)
            { 

               IPagedList<TblProduct> ProductILS=context.TblProduct.ToPagedList<TblProduct>(4,page);
               return View(ProductILS);

            }
            else if(Category!=null)

            {

                IPagedList<TblProduct> link = context.TblProduct.Where(m => m.Categoryid == Category && m.Scategoryid == Category ).ToPagedList<TblProduct>(4,page);
                return View(link);

            }
            return View();
        }
        #endregion

        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FacebookLogin()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FacebookLogin(FacebookLoginModel fb)
        {
            //Session["uid"] = fb.uid;
            //Session["accessToken"] = fb.accessToken;

            return Json(new { success = true });
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            IList<TblProduct> tbl = context.TblProduct.ToList<TblProduct>();
            return View(tbl);
        }
        public IActionResult ProductDescription(int id)
        {
            var  value = context.TblProduct.Where(m=>m.Productid==id).FirstOrDefault<TblProduct>();
            return View(value);
        }
    }
}
