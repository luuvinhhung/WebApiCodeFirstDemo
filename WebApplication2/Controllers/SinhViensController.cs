using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Api.Models;

namespace WebApplication2.ViewModels
{
    public class SinhViensController : ApiController
    {
        private ApiDBContext _db;

        public SinhViensController()
        {
            this._db = new ApiDBContext();
        }
        [HttpPost]
        public IHttpActionResult TaoSinhVien(CreateSVModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MSSV))
            {
                errors.Add("MSSV là trường bắt buộc");
            }

            if (errors.Errors.Count == 0)
            {
                SinhVien SV = new SinhVien();
                SV.MSSV = model.MSSV;
                SV.HoTen = model.HoTen;
                SV.NgaySinh = model.NgaySinh;
                SV = _db.SinhViens.Add(SV);

                this._db.SaveChanges();

                SinhVienModel viewModel = new SinhVienModel(SV);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }
        [HttpPut]
        public IHttpActionResult CapNhatLop(UpdateSVModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            SinhVien SV = this._db.SinhViens.FirstOrDefault(x => x.Id == model.Id);

            if (SV == null)
            {
                errors.Add("Không tìm thấy sinh viên có ID này");

                httpActionResult = Ok(errors);
            }
            else
            {
                SV.MSSV = model.MSSV ?? model.MSSV;
                SV.HoTen = model.HoTen ?? model.HoTen;
                SV.DiaChi = model.DiaChi ?? model.DiaChi;

                this._db.Entry(SV).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new SinhVienModel(SV));
            }

            return httpActionResult;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var DSSV = this._db.SinhViens.Select(x => new SinhVienModel()
            {
                MSSV = x.MSSV,
                HoTen = x.HoTen,
                Id = x.Id
            });

            return Ok(DSSV);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var SV = _db.SinhViens.FirstOrDefault(x => x.Id == id);

            if (SV == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy sinh viên này");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new SinhVienModel(SV));
            }

            return httpActionResult;
        }

    }
}
