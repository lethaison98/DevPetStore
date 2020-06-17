using Model.EF;
using Model.Repository;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PetStore.Controllers
{
    public class GioHangController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: GioHang
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Pet.ID_Item == item.Pet.ID_Item);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(int itemId, int soLuong)
        {
            var pet = new PetRepository().GetByID(itemId);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x => x.Pet.ID_Item == itemId)) {
                    foreach (var item in list)
                    {
                        if (item.Pet.ID_Item == itemId)
                        {
                            item.SoLuong += soLuong;
                        }
                    }
                }
                else
                {
                    //Tao moi item
                    var item = new CartItem();
                    item.Pet = pet;
                    item.SoLuong = soLuong;
                    list.Add(item);                  
                }
                Session[CartSession] = list;
            }
            else
            {
                //Tao moi item
                var item = new CartItem();
                item.Pet = pet;
                item.SoLuong = soLuong;
                var list = new List<CartItem>();
                list.Add(item);
                
                //Add vao Session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Pet.ID_Item == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            var UserSession = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            if (UserSession == null)
            {

            }
            else
            {
                var khachHangRepo = new KhachHangRepository();
                var khachHang = khachHangRepo.GetByUserId(UserSession.UserID);
                if(khachHang!= null)
                {
                    ViewBag.Name = khachHang.Ten;
                    ViewBag.Phone = khachHang.SoDienThoai;
                    ViewBag.Address = khachHang.DiaChi;
                }

            }
                return View(list);
        }
        [HttpPost]
        public ActionResult ThanhToan(string shipName, string shipMobile, string shipAddress)
        {
            var donHang = new DonHang();
            donHang.CreateDate = DateTime.Now;
            donHang.ShipAddress = shipAddress;
            donHang.ShipMobile = shipMobile;
            donHang.ShipName = shipName;
            donHang.TrangThaiDatHang = 1;
            donHang.TrangThaiDonHang = 1;
            donHang.TrangThaiGiaoHang = 0;
            var session = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            if (session != null)
            {
                donHang.ID_KhachHang = new KhachHangRepository().GetByUserId(session.UserID).ID_KhachHang;
            }
            try
            {               
                var cart = (List<CartItem>)Session[CartSession];
                var donHangChiTietRepo = new DonHangChiTietRepository();
                decimal total = 0;
                foreach(var item in cart)
                {
                    total += (item.Pet.GiaTien * item.SoLuong);
                }
                donHang.TongTien = total;
                var id = new DonHangRepository().Insert(donHang);
                foreach (var item in cart)
                {
                    var donHangChiTiet = new DonHangDetail();
                    donHangChiTiet.ID_Item = item.Pet.ID_Item;
                    donHangChiTiet.ID_DonHang = id;
                    donHangChiTiet.DonGia = item.Pet.GiaTien;
                    donHangChiTiet.ThanhTien = item.Pet.GiaTien * item.SoLuong;
                    donHangChiTiet.SoLuong = item.SoLuong;
                    var idItem = donHangChiTietRepo.Insert(donHangChiTiet);
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex");
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("~/Home");
        }
    }
}