﻿using Model.Attributes;
using Model.Dto;
using Model.EF;
using Model.Enums;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class DonHangRepository
    {
        PetStoreDbContext db = null;
        public DonHangRepository()
        {
            db = new PetStoreDbContext();
        }
        public DonHangDto ConvertToDto(DonHang entity)
        {
            var data = new DonHangDto();
            data.ID_DonHang = entity.ID_DonHang;
            data.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.ConfirmDate = entity.ConfirmDate?.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.ShipDate = entity.ShipDate?.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.ShipName = entity.ShipName;
            data.ShipMobile = entity.ShipMobile;
            data.ShipAddress = entity.ShipAddress;
            data.TongTien = entity.TongTien;
            data.TrangThaiDonHang = entity.TrangThaiDonHang;
            data.TenTrangThaiDonHang= GetEnum.GetText(GetEnum.GetByCode(data.TrangThaiDonHang));
            data.LyDoHuy = entity.LyDoHuy;
            data.DanhSachDonHangChiTiet = new DonHangChiTietRepository().ListAllPaging(data.ID_DonHang, 1, 10).ToList();
            return data;
        }
        public int Insert(DonHang donHang)
        { 
            db.DonHangs.Add(donHang);
            db.SaveChanges();         
            return donHang.ID_DonHang;  
        }
        public IEnumerable<DonHangDto> ListAllPaging(String searchString, int page, int pageSize, TrangThaiDonHangEnum trangThaiEnum)
        {
            IEnumerable<DonHangDto> returnData;
            IEnumerable<DonHang> data;
            IQueryable<DonHang> model = db.DonHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipMobile.Contains(searchString) || x.ShipAddress.Contains(searchString));
            }
            var trangThaiDonHang = GetEnum.GetCode(trangThaiEnum);
            model = model.Where(x => x.TrangThaiDonHang == trangThaiDonHang);
            data = model.OrderByDescending(x => x.CreateDate);
            returnData = data.Select(x => ConvertToDto(x));
            return returnData.ToPagedList(page, pageSize);
        }

        public DonHangDto GetDonHangById(int id)
        {
            return ConvertToDto(db.DonHangs.SingleOrDefault(x => x.ID_DonHang == id));
        }
        public List<DonHangDto> LayDanhSachDonHangByKhachHangId(int id)
        {
            List<DonHangDto> returnData;
            returnData = db.DonHangs.Where(x => x.ID_KhachHang == id).OrderByDescending(x => x.CreateDate).Select(ConvertToDto).ToList();
            return returnData;
        }
        public  bool XacNhan (int id)
        {
            var entity = db.DonHangs.SingleOrDefault(x => x.ID_DonHang == id);
            if (entity.TrangThaiDonHang == GetEnum.GetCode(TrangThaiDonHangEnum.ChuaXacNhan))
            {
                entity.TrangThaiDonHang = GetEnum.GetCode(TrangThaiDonHangEnum.DaXacNhan);
                entity.ConfirmDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool TuChoi(int id, string lydo)
        {
            var entity = db.DonHangs.SingleOrDefault(x => x.ID_DonHang == id);
            if (entity.TrangThaiDonHang == GetEnum.GetCode(TrangThaiDonHangEnum.ChuaXacNhan) || (entity.TrangThaiDonHang == GetEnum.GetCode(TrangThaiDonHangEnum.DaXacNhan)))
            {
                entity.TrangThaiDonHang = GetEnum.GetCode(TrangThaiDonHangEnum.DaHuy);
                entity.LyDoHuy = lydo;
                entity.ConfirmDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool HoanThanh(int id)
        {
            var entity = db.DonHangs.SingleOrDefault(x => x.ID_DonHang == id);
            if (entity.TrangThaiDonHang == GetEnum.GetCode(TrangThaiDonHangEnum.DaXacNhan))
            {
                entity.TrangThaiDonHang = GetEnum.GetCode(TrangThaiDonHangEnum.DaHoanThanh);
                entity.ShipDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
