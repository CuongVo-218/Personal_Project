using MyClass.DAO;
using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDienThoai.Controllers
{
    public class KhachHangController : Controller
    {
        UserDAO userDAO = new UserDAO();
        // GET: KhachHang
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection form)
        {
            string username = form["username"];
            string password = XString.ToMD5(form["password"]);
            //
            User row_user = userDAO.getRow(username, "Customer");
            // Thông báo lỗi
            string strError = "";
            if (row_user == null || username != row_user.UserName /*|| username != row_user.Email || username != row_user.Phone*/)
            {
                strError = "Tên đăng nhập không tồn tại!!!";
            }
            else
            {
                if (password.Equals(row_user.Password))
                {
                    // Thực hiện đăng nhập
                    Session["UserCustomer"] = username;
                    Session["CustomerId"] = row_user.Id;
                    return Redirect("~/");
                }
                else
                {
                    strError = "Mật khẩu sai hoặc không tồn tại !!!";
                }
            }
            ViewBag.Error = "<div class='text-danger'>" + strError + "</div>";
            return View("DangNhap");
        }

        public ActionResult DangXuat()
        {
            Session["UserCustomer"] = "";
            Session["CustomerId"] = "";
            return RedirectToAction("Index", "Site");
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DangKy(FormCollection form, User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Gender == null)
                {
                    user.Gender = 1;
                }
                if (user.Roles == null)
                {
                    user.Roles = "Customer";
                }
                user.Status = 1;
                string pass = XString.ToMD5(form["Password"]);
                user.Password = pass;
                user.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                user.CreatedAt = DateTime.Now;
                userDAO.Insert(user);
                SuccessNotifical("Đăng ký tài khoản");
                return RedirectToAction("DangKy");
            }
            return View("DangKy");
        }
       
        public ActionResult ChinhSua()
        {
            int userid = int.Parse(Session["CustomerId"].ToString());
            User user = userDAO.getRow(userid);
            return View("ChinhSua", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSua(FormCollection form, User user)
        {
            if (ModelState.IsValid)
            {
                // xử lý cập nhật
                string pass = XString.ToMD5(form["Password"]);
                user.Password = pass;
                user.UpdateBy = Convert.ToInt32(Session["UserId"].ToString());
                user.UpdateAt = DateTime.Now;
                userDAO.Update(user);
                SuccessNotifical("Chỉnh sửa tài khoản");
                return RedirectToAction("ChinhSua", user);
    
            }
            return View(user);
        }
        void SuccessNotifical(string s)
        {
            TempData["message"] = new XMessage("success", s + " thành công");
        }
    }
}