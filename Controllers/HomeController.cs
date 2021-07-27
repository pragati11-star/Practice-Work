using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using NewProject1.Models;
using static NewProject1.Models.DataReg;

namespace NewProject1.Controllers
{
    public class HomeController : Controller
    {

        DataReg dm = new DataReg();
        IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        [HttpGet]
        public ActionResult Index()
        {

            var model = db.QueryAsync<tblReg>("select * from tblreg").Result.ToList();
            ViewBag.list = model;
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblReg1 m)
        {
            if (ModelState.IsValid)

            {
                db.Execute("insert into tblReg (F_name,Email,Address,Password) values (@F_name,@Email,@Address,@Password)", new { @F_name = m.F_Name, @Email = m.Email, @Address = m.Address, @Password = m.Password });
            }
            var model = db.QueryAsync<tblReg>("select * from tblreg").Result.ToList();
            ViewBag.list = model;
            return View();
        }
        [HttpGet]
        public ActionResult About(int id = 0)
        {
            var item = new tblLogin1();
            if (id > 0)
            {
                item = db.QueryAsync<tblLogin1>("select * from tbllogin where id=@id  ", new { @id = id }).Result.ToList().FirstOrDefault();
            }
            var model = db.QueryAsync<tblLogin>("select * from tbllogin").Result.ToList();
            ViewBag.list = model;
            return View(item);
        }
        [HttpPost]
        public ActionResult About(tblLogin1 m)
        {
            if (ModelState.IsValid)
            {
                string filename = dm.saveImage(m.Image);
                if (m.Id > 0)
                {
                    db.Execute("update tblLogin set Email = @Email, Password= @Password, image= @saveImage where Id = @Id ", new { @Id = m.Id, @Email = m.Email, @Password = m.Password ,@saveImage = filename});
                }
                else
                {
                    db.Execute("insert into tblLogin(Email,Password,image) values(@Email,@Password,@saveImage)", new { @Email = m.Email, @Password = m.Password , @saveImage =filename});
                }
            }
            var model = db.QueryAsync<tblLogin>("select * from tbllogin").Result.ToList();
            ViewBag.list = model;
            return View();
        }
        public ActionResult DeleteAbout(int id)
        {
            db.Execute("DELETE FROM tblLogin WHERE id=@id", new { @id = id});
            return RedirectToAction("About");
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Order()
        {
            var model = db.QueryAsync<PlacdOrder>("select * from tblPlacdOrder").Result.ToList();
            ViewBag.list = model;
            return View();
        }
        [HttpPost]
        public ActionResult Order(PlacdOrder m)
        {
            if (ModelState.IsValid)
            {
                db.Execute("insert into tblPlacdOrder(DeliveryAddress) values(@DeliveryAddress)", new { @DeliveryAddress=m.DeliveryAddress, @Price= m.Price, @OrderTime= m.OrderTime });
            }
            var model = db.QueryAsync<PlacdOrder>("select * from tblPlacdOrder").Result.ToList();
            ViewBag.list = model;
            return View();
        }
         public ActionResult approveorder ( int  id=0)
        {
            var item = new ApprovedOrder();
            ViewBag.ChefId = db.QueryAsync<SelectListItem>("select id Value,ChefName text  from tblChef order by id desc").Result.ToList();
            if(id>0)
            {
                item = db.QueryAsync<ApprovedOrder>("select * from tblApprovedOrder where id=@id  ", new {@id=id }).Result.ToList().FirstOrDefault();
            }
            var model = db.QueryAsync<ChefJoinApproveOrder>("select * from tblApprovedOrder ap inner join tblChef c on ap.ChefId=c.Id").Result.ToList();
            ViewBag.list = model;
            return View(item);
        }

        [HttpPost]
        public ActionResult approveorder (ApprovedOrder m)
        {
            if (ModelState.IsValid)
            {
                if (m.Id > 0)
                {
                    db.Execute("update tblApprovedOrder set MobileNo= @MobileNo,ChefId= @ChefId,C_Address= @C_Address where Id = @Id ", new{@Id=m.Id, @MobileNo = m.MobileNo,@ChefId= m.ChefId, @C_Address = m.C_Address });

                }
                else
                {
                    db.Execute("insert into tblApprovedOrder(MobileNo,ChefId, C_Address) values(@MobileNo,@ChefId, @C_Address)", new { @MobileNo = m.MobileNo,@ChefId= m.ChefId, @C_Address = m.C_Address });
                }
            }

            var model = db.QueryAsync<ChefJoinApproveOrder>("select * from tblApprovedOrder ap inner join tblChef c on ap.ChefId=c.Id").Result.ToList();
            ViewBag.list = model;
            ViewBag.ChefId = db.QueryAsync<SelectListItem>("select id Value,ChefName text  from tblChef order by id desc").Result.ToList();
            return View();
        }
        public ActionResult DeleteApproveOrder(int id)
        {
            db.Execute("DELETE FROM tblApprovedOrder WHERE id=@id", new { @id = id });
            return RedirectToAction("ApproveOrder");

        }
        [HttpGet]
        public ActionResult Chef(int id = 0)
        {
            var item = new chef();
            if(id>0)
            {

                item =  db.QueryAsync<chef>("select * from tblChef where id=@id", new { @id = id }).Result.ToList().FirstOrDefault();
            } 
            var model = db.QueryAsync<tblChef>("select * from tblChef").Result.ToList();
            ViewBag.list = model;
            return View(item);
        }
        [HttpPost]
        public ActionResult chef(chef m)
        {
            if (ModelState.IsValid)
            {
                string filename = dm.saveImage(m.Image);
                if (m.Id > 0)
                {

                    db.Execute("update tblChef set ChefName= @ChefName, MobileNo=@MobileNo, Email= @Email, Password= @Password, Address= @Address, Gender= @Gender , Image = @saveImage Where id = @id ", new { @id = m.Id, @ChefName = m.ChefName, @MobileNo = m.MobileNo, @Email = m.Email, @Password = m.Password, @Address = m.Address, @Gender = m.Gender ,@saveImage = filename});
                }
                else
                {
                    db.Execute("insert into tblChef(ChefName, MobileNo, Email, Password, Address, Gender,Image) values(@ChefName, @MobileNo, @Email, @Password, @Address, @Gender, @saveImage)", new { @ChefName = m.ChefName, @MobileNo = m.MobileNo, @Email = m.Email, @Password = m.Password, @Address = m.Address, @Gender = m.Gender , @saveImage = filename });
                }
            }
            var model = db.QueryAsync<tblChef>("select * from tblChef").Result.ToList();
            ViewBag.list = model;
            return View();
        }
        public ActionResult DeleteChef(int id)
        {
            db.Execute("DELETE FROM tblChef WHERE id= @id", new { @id = id });
            return RedirectToAction("Chef");
        }

    }

}