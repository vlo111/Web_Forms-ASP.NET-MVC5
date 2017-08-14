using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CenDek.Controllers
{
    public class FilesController : Controller
    {
        private CenDekContext db = new CenDekContext();
        public static List<FileTmp> listFiles = new List<FileTmp>();
        public static List<DataAccess.Models.File> listSelectedFiles = new List<DataAccess.Models.File>();
        // GET: Files
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;

                    List<string> extensions = new List<string>() { ".gif", ".png", ".jpg", ".txt", ".pdf" };
                    string extension = Path.GetExtension(fName);

                    if (extensions.Contains(extension))
                    {

                        if (file != null && file.ContentLength > 0)
                        {
                            int size = 5 * 1024 * 1024;
                            if (file.ContentLength <= size)
                            {
                                var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallFiles", Server.MapPath(@"\")));

                                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "filepath");

                                var fileName1 = Path.GetFileName(file.FileName);

                                bool isExists = System.IO.Directory.Exists(pathString);

                                if (!isExists)
                                    System.IO.Directory.CreateDirectory(pathString);

                                var path = string.Format("{0}\\{1}", pathString, file.FileName);
                                file.SaveAs(path);

                                BinaryReader b = new BinaryReader(file.InputStream);
                                byte[] binData = b.ReadBytes((int)file.InputStream.Length);
                                string name = "";
                                if (extension.Length == 4)
                                {
                                    name = fileName1.Remove(fileName1.Length - 4);
                                }
                                else if (extension.Length == 5)
                                {
                                    name = fileName1.Remove(fileName1.Length - 5);
                                }
                                var list = new DataAccess.Models.FileTmp { Name = name, Type = extension.Replace(".", ""), Contents = binData };
                                db.FilesTmp.Add(list);
                                listFiles.Add(list);
                                db.SaveChanges();
                                ViewBag.DocumentTypeID = new SelectList(db.DocumentTypes, "DocumentTypeID", "Name");
                            }
                            else
                            {
                                ViewBag.Message = "Maximum allowed file size is 5 mb";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Error. Valid file extensions - '.png', '.jpg', '.gif', '.pdf','.txt'";
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

            return PartialView("_SaveUploadedFile", listFiles);
        }

        public async Task<ActionResult> delete(string name)
        {
            var file = listFiles.Find(i => i.Name == name);
            if (file != null)
            {
                listFiles.Remove(file);
                listSelectedFiles.Remove(listSelectedFiles.Find(i => i.Name == file.Name));
                db.FilesTmp.Remove(db.FilesTmp.Where(n => n.ID == file.ID).FirstOrDefault());
                await db.SaveChangesAsync();
            }
            return PartialView("_SaveUploadedFile");
        }

        public async Task<ActionResult> SaveFilledFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataAccess.Models.File file = new DataAccess.Models.File();
            var filetmp = await db.FilesTmp.FindAsync(id);
            if (filetmp != null)
            {
                file.FileID = filetmp.ID;
                file.Name = filetmp.Name;
                file.Type = filetmp.Type;
            }


            ViewBag.DocumentTypeID = new SelectList(db.DocumentTypes, "DocumentTypeID", "Name", file?.DocumentTypeID);
            return View(file);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveFilledFile(DataAccess.Models.File file)
        {
            FileTmp filetmp = new FileTmp();
            try
            {
                if (ModelState.IsValid)
                {
                    filetmp = await db.FilesTmp.FindAsync(file.FileID);
                    if (filetmp != null)
                     {
                        var newFile = new DataAccess.Models.File { Name = filetmp.Name, Type = filetmp.Type, Contents = filetmp.Contents, DocumentTypeID = file.DocumentTypeID, EmployeeID = file.EmployeeID };
                        db.Files.Add(newFile);
                        listSelectedFiles.Add(newFile);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        return Json(new { warning = "file not found" });
                    }
                }
                else
                {
                    return Json(new { warning = "model is not valid" });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(file);
            }
            return PartialView("_SelectedFiles", listSelectedFiles);
        }

        public ActionResult Refresh()
        {
            return PartialView("_SelectedFiles", listSelectedFiles);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFil(int? FileID)
        {
            var fileTmp = listFiles.Find(i => i.ID == FileID);
            if (fileTmp != null)
            {
                db.FilesTmp.Remove(db.FilesTmp.Where(n => n.ID == fileTmp.ID).FirstOrDefault());
                listFiles.Remove(fileTmp);
                listSelectedFiles.Remove(listSelectedFiles.Find(i => i.Name == fileTmp.Name));
                await db.SaveChangesAsync();
            }
            return PartialView("_SaveUploadedFile", listFiles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}