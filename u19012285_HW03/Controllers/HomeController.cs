using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using u19012285_HW03.Models;


namespace u19012285_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, FormCollection collections)
        {
            string SelectedFile = Convert.ToString(collections["FileOption"]);

            if(SelectedFile == "Document")
            {
                file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Documents/ "), file.FileName));
            }
            else if (SelectedFile == "Image")
            {
                file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Images/ "), file.FileName));
            }
            else
            {
                file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Videos/ "), file.FileName));
            }

            return RedirectToAction("Index");
        }

        public ActionResult File()
        {
            List<FileModel> UploadedFiles = new List<FileModel>();
            string[] Documents = Directory.GetFiles(Server.MapPath("~/Documents/ "));
           // string[] Images = Directory.GetFiles(Server.MapPath("~/Images/ "));
            //string[] Videos = Directory.GetFiles(Server.MapPath("~/Videos/ "));

            foreach(var document in Documents)
            {
               FileModel RetrieveFile = new FileModel();
                RetrieveFile.FileName = Path.GetFileName(document);
                RetrieveFile.FileType = "Document";
                UploadedFiles.Add(RetrieveFile);
            }

           // foreach (var image in Images)
           // {
              //  FileModel RetrieveFile = new FileModel();
               // RetrieveFile.FileName = Path.GetFileName(image);
              //  myFile.Add(RetrieveFile);
           /// }
///
            //foreach (var video in Videos)
            //{
             //   FileModel RetrieveFile = new FileModel();
            //    RetrieveFile.FileName = Path.GetFileName(video);
             //   myFile.Add(RetrieveFile);
           // }

            return View(UploadedFiles);
        }

        public ActionResult Image()
        {
            List<FileModel> UploadedImages = new List<FileModel>();
            string[] Images = Directory.GetFiles(Server.MapPath("~/Images/ "));
            foreach (var images in Images)
            {
                FileModel RetrieveImage = new FileModel();
                RetrieveImage.FileName = Path.GetFileName(images);
                RetrieveImage.FileType = "Image";
                UploadedImages.Add(RetrieveImage);
            }
            return View(UploadedImages);
        }

        public ActionResult Video()
        {
            List<FileModel> UploadedVideos = new List<FileModel>();
            string[] Videos = Directory.GetFiles(Server.MapPath("~/Videos/ "));
            foreach (var videos in Videos)
            {
                FileModel RetrieveVideo = new FileModel();
                RetrieveVideo.FileName = Path.GetFileName(videos);
                RetrieveVideo.FileType = "Video";
                UploadedVideos.Add(RetrieveVideo);
            }
            return View(UploadedVideos);

        }

        //public FileResult DownloadUploadedFile(string FileName, string FileType)
        //{
        // byte[] Housing = null; //ask
        //// if(FileType == "Document")
        //{
        //    Housing = System.IO.File.ReadAllBytes(Server.MapPath("~/Documents/") + FileName);
        //}
        //else if(FileType == "Video")
        // {
        // //    Housing = System.IO.File.ReadAllBytes(Server.MapPath("~/Videos/") + FileName);
        //}
        // else
        //{
        //    Housing = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/") + FileName);
        //}

        // return File(Housing, "application/octet-stream", FileName);
        //}

        public FileResult DownloadUploadedFile(string FileName)
        {
            

            string download = Server.MapPath("~/Documents/") + FileName;

            

            byte[] bytes = System.IO.File.ReadAllBytes(download);


            return File(bytes, "application/octet-stream", FileName);
        }

        public ActionResult DeleteUploadedFile(string FileName)
        {
            //string HousingDeletion = null;
            // if (FileType == "Document")
            //{
            //  HousingDeletion = Server.MapPath("~/Documents/") + FileName;
            //}
            //else if (FileType == "Video")
            //{
            //  HousingDeletion = Server.MapPath("~/Videos/") + FileName;
            //}
            //else
            //{
            //  HousingDeletion = Server.MapPath("~/Images/") + FileName;
            //}
            //System.IO.File.Delete(HousingDeletion);
            //return RedirectToAction("Index");
            string delete = Server.MapPath("~/Documents/") + FileName;
            byte[] bytes = System.IO.File.ReadAllBytes(delete);

            System.IO.File.Delete(delete);

            return RedirectToAction("Index");
        }

        public ActionResult Aboutme()
        {
            
            return View();
        }

        //Image post action
        
       

    }
}