using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class GiangViensController : ApiController
    {
        private ApiDBContext _db;

        public GiangViensController()
        {
            this._db = new ApiDBContext();
        }

        [HttpPost]
        public IHttpActionResult TaoGiangVien(CreateGVModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.Ma))
            {
                errors.Add("Mã giảng viên là trường bắt buộc");
            }

            if (string.IsNullOrEmpty(model.Ten))
            {
                errors.Add("Tên giảng viên là trường bắt buộc");
            }

            if (errors.Errors.Count == 0)
            {
                GiangVien GV = new GiangVien();
                GV.Ma = model.Ma;
                GV.Ten = model.Ten;
                GV = _db.GiangViens.Add(GV);

                this._db.SaveChanges();

                GiangVienModel viewModel = new GiangVienModel(GV);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }
        [HttpPut]
        public IHttpActionResult CapNhatGiangVien(UpdateGVModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            GiangVien GV = this._db.GiangViens.FirstOrDefault(x => x.Id == model.Id);

            if (GV == null)
            {
                errors.Add("Không tìm thấy giảng viên có ID này");

                httpActionResult = Ok(errors);
            }
            else
            {
                GV.Ma = model.Ma ?? model.Ma;
                GV.Ten = model.Ten ?? model.Ten;

                this._db.Entry(GV).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new GiangVienModel(GV));
            }

            return httpActionResult;
        }

        [HttpGet]
        public IHttpActionResult GetAll(GiangVienModel model)
        {
            //GiangVien GV = this._db.GiangViens.FirstOrDefault(x => x.Id == model.Id);
            //var DSLD = GV.LopDays;
            var DSGV = this._db.GiangViens.Select(x => new GiangVienModel()
            {
                Id = x.Id,
                Ma = x.Ma,
                Ten = x.Ten,
            });

            return Ok(DSGV);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var GV = _db.GiangViens.FirstOrDefault(x => x.Id == id);

            if (GV == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy giảng viên này");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new GiangVienModel(GV));
            }

            return httpActionResult;
        }
    }
}