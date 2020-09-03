using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LEnglish.Models;
using System.IO;
using DAL;
using DAL.Models;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;

namespace LEnglish.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        public PicturesController(IPictureService service, IMapper mapper)
        {
            _mapper = mapper;
            _pictureService = service;
        }


        
        // GET: Picture
        public ActionResult Index()
        {
            var allPictures = _pictureService.GetAll();
            var pictures = _mapper.Map<IEnumerable<PictureViewModel>>(allPictures);
            //ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(pictures);

            //return View(pc_db.Pictures);
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            //PictureViewModel pictureViewModel = new PictureViewModel();
            //using (DBContext pc_db = new DBContext())
            //{
                var pictureModel = _pictureService.GetById(id);
                var pictureViewModel = _mapper.Map<PictureViewModel>(pictureModel);

                //var pictureModel = _mapper.Map<PictureModel>(pictureViewModel);
                //var picModel = _mapper.Map<Picture>(pictureModel);
                //pictureViewModel = pc_db.Pictures.Where(x => x.Id == id).FirstOrDefault();
            //}
            return View(pictureViewModel);
        }

        // GET: Picture/Create
        public ActionResult Create()
        {
            return View();
        }

        ////DBContext pc_db = new DBContext();
        // POST: Picture/Create
        [HttpPost]
        public ActionResult Create(PictureViewModel pictureViewModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(pictureViewModel.ImageFile.FileName);
            string extention = Path.GetExtension(pictureViewModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            pictureViewModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            pictureViewModel.ImageFile.SaveAs(fileName);
            using (DBContext pc_db = new DBContext()) 
            {
                var pictureModel = _mapper.Map<PictureModel>(pictureViewModel);
                var picModel = _mapper.Map<Picture>(pictureModel);
                pc_db.Pictures.Add(picModel);
                pc_db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }

        ////public ActionResult Create(Picture pic, HttpPostedFileBase uploadImage)
        ////{
        ////    if (ModelState.IsValid && uploadImage != null)
        ////    {
        ////        byte[] imageData = null;
        ////        using (var binaryReader = new BinaryReader(uploadImage.InputStream))
        ////        {
        ////            imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
        ////        }

        ////        pic.Image = imageData;
        ////        //var pictureModel = _mapper.Map<PictureModel>(pic);
        ////        //var picModel = _mapper.Map<Picture>(pictureModel);
        ////        //pc_db.Pictures.Add(picModel);
        ////        //_pictureService.Add(pictureModel);
        ////        pc_db.Pictures.Add(pic);
        ////        pc_db.SaveChanges();
        ////        //_pictureService.sa

        ////        return RedirectToAction("Index");
        ////    }
        ////    return View(pic);
        ////    //try
        ////    //{
        ////    //    // TODO: Add insert logic here

        ////    //    return RedirectToAction("Index");
        ////    //}
        ////    //catch
        ////    //{
        ////    //    return View();
        ////    //}
        ////}

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Picture/Edit/5
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

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Picture/Delete/5
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
