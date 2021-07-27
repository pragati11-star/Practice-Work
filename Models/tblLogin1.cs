using NewProject1.Models;
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
    public class PlacdOrder
    {
        public Nullable <int> Id { get; set; }
        public Nullable<int> ApprovedId { get; set; }
        public string OrderTime { get; set; }
        public string DeliveryAddress { get; set; }
        public string Price { get; set; }

        //public virtual tblApprovedOrder tblApprovedOrder { get; set; }
    }
    public class tblLogin1
    {
        public Nullable <int> Id { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        public string Email { get; set; }
        [Required(ErrorMessage= "Password is mandatory")]
        public string Password { get; set; }
        
        public string Role { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> U_Type { get; set; }
        public Nullable<System.DateTime> c_date { get; set; }
        public Nullable<System.DateTime> u_date { get; set; }
        public Nullable<int> is_active { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
    public  class ApprovedOrder
    {
        

        public Nullable<int> Id { get; set; }
        public Nullable<int> ChefId { get; set; }
        [Required(ErrorMessage="mobile no is mendentory ")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Address is mendentory ")]
        public string C_Address { get; set; }

        
    }
    public  class chef
    {
        
       
        public Nullable<int> Id { get; set; }
        public string ChefName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public string HttpPostedFileBase Image { get; set; }
    }

public  class ChefJoinApproveOrder
{
       
    public int Id { get; set; }
    public Nullable<int> ChefId { get; set; }
    public string MobileNo { get; set; }
    public string C_Address { get; set; }

    public string ChefName { get; set; }

    public string Password { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }




}

