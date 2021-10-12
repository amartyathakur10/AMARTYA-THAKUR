using DAL;
using DAL.Repositories;
using DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        IUnitOfWork uow;
        public ProductController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var data = uow.ProductRepo.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = uow.CategoryRepo.GetAll();
            return View();
        }


        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                string folderPath = "~/Uploads/";
                bool exists = Directory.Exists(Server.MapPath(folderPath));
                if (!exists)
                    Directory.CreateDirectory(Server.MapPath(folderPath));

                //saving file
                string fileName = Path.GetFileName(model.File.FileName);
                string path = Path.Combine(Server.MapPath(folderPath), fileName);
                model.File.SaveAs(path);

                Product product = new Product();

                //product.ProductId = model.ProductId;
                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                product.Description = model.Description;
                product.ImageName = fileName;
                product.ImagePath = "/Uploads/" + fileName;
                product.CreatedDate = DateTime.Now;

                uow.ProductRepo.Add(product);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            ViewBag.Categories = uow.CategoryRepo.GetAll();
            return View();
        }



    }
}