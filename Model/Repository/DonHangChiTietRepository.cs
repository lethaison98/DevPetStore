using Model.Dto;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class DonHangChiTietRepository
    {
        PetStoreDbContext db = null;
        public DonHangChiTietRepository()
        {
            db = new PetStoreDbContext();
        }
        public DonHangDetailDto ConvertToDto(DonHangDetail entity)
        {
            var data = new DonHangDetailDto();
            data.ID_DonHang = entity.ID_DonHang;
            data.ID_DonHangDetail = entity.ID_DonHangChiTiet;
            data.ID_Item = entity.ID_Item;
            data.SoLuong = entity.SoLuong;
            data.DonGia = entity.DonGia;
            data.ThanhTien = entity.ThanhTien;
            data.TenItem = entity.Pet.Ten_Pet;
            data.ImgLink = entity.Pet.Image;
            return data;
        }
        public int Insert(DonHangDetail donHangChiTiet)
        {

                db.DonHangDetails.Add(donHangChiTiet);
                db.SaveChanges();
                return donHangChiTiet.ID_DonHangChiTiet;       
        }
        public IEnumerable<DonHangDetailDto> ListAllPaging(int DonHangID, int page, int pageSize)
        {
            IEnumerable<DonHangDetailDto> returnedData;
            IEnumerable<DonHangDetail> data;
            IQueryable<DonHangDetail> model = db.DonHangDetails;
            model = model.Where(x => x.ID_DonHang == DonHangID);
            data= model.OrderByDescending(x => x.ThanhTien);
            returnedData = data.Select(x => ConvertToDto(x));
            return returnedData.ToPagedList(page, pageSize);
        }
    }
}
