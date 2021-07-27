
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace NewProject1.Models
{
    public class DataReg
    {
        public string saveImage(HttpPostedFileBase file)
        {
            var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg" };
            if (file != null)
            {
                var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string myfile = Path.GetFileNameWithoutExtension(file.FileName) + (new Random().Next(1000, 9999)) + ext;
                    //string myfile = Guid.NewGuid().ToString() + ext; //appending the name with id  
                    // store the file inside ~/project folder(Img)  
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Img"), myfile);
                    file.SaveAs(path);
                    //    var medImg = Images.ResizeImage(Image.FromFile(path), 300, 300);
                    //medImg.Save(Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Img/"), myfile));
                    return myfile;
                }
                else
                    return null;
            }
            else
                return null;
        }
        public class tblReg1
        {
            public Nullable <int> Id { get; set; }
            [Required]
            public string F_Name { get; set; }
            
            public string MobileNo { get; set; }
            [Required]
            public string Email { get; set; }
            public string Password { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
            public Nullable<bool> isactive { get; set; }
            public Nullable<System.DateTime> u_date { get; set; }
            public Nullable<System.DateTime> c_date { get; set; }
            public Nullable<System.DateTime> DateOfBirth { get; set; }
            public Nullable<int> Role { get; set; }
        }
    
}
}