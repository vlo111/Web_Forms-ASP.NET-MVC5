using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CenDek.Controllers
{
    public class ImagesController : Controller
    {
        private CenDekContext db = new CenDekContext();
        public static Image Image = new Image();


        // GET: Images
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            var image = new Image();
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;

                    List<string> extensions = new List<string>() { ".gif", ".png", ".jpg" };
                    string extension = Path.GetExtension(fName);

                    if (extensions.Contains(extension))
                    {

                        if (file != null && file.ContentLength > 0)
                        {
                            int size = 2 * 1024 * 1024;
                            if (file.ContentLength <= size)
                            {
                                var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

                                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                                var fileName1 = Path.GetFileName(file.FileName);

                                bool isExists = System.IO.Directory.Exists(pathString);

                                if (!isExists)
                                    System.IO.Directory.CreateDirectory(pathString);

                                var path = string.Format("{0}\\{1}", pathString, file.FileName);
                                file.SaveAs(path);

                                BinaryReader b = new BinaryReader(file.InputStream);
                                byte[] binData = b.ReadBytes((int)file.InputStream.Length);
                                image = new Image { Name = fileName1.Remove(fileName1.Length - 4), Ext = extension.Replace(".", ""), Image1 = binData };
                                db.Images.Add(image);
                                db.SaveChanges();
                                Image = image;
                            }
                            else
                            {
                                ViewBag.Message = "Maximum allowed file size is 2 mb";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Error. Valid file extensions - '.png', '.jpg', '.gif'";
                    }
                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                ViewBag.success = fName;
            }
            else
            {
                ViewBag.Message = "Error in saving file";
            }
            if (Image != null)
                return PartialView("_SaveUploadedFile", !string.IsNullOrEmpty(Image.Name) ? Image : null);
            else
                return PartialView("_SaveUploadedFile");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteImg(int ImageID)
        {
            if (Image != null)
            {
                db.Images.Remove(db.Images.Where(n => n.ImageID == ImageID).FirstOrDefault());
                Image = null;
                await db.SaveChangesAsync();
            }
            return PartialView("_SaveUploadedFile", Image);
        }
        public async Task<ActionResult> delete(string name)
        {
            if (Image != null)
            {
                if (Image.Name == name)
                {
                Image = null;
                db.Images.Remove(db.Images.Where(n => n.ImageID == Image.ImageID).FirstOrDefault());
                await db.SaveChangesAsync();
                }
            }
            return PartialView("_SaveUploadedFile");
        }

    }
}