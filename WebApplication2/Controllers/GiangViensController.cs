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

        /**
         * @api {POST} /giangviens/TaoGiangVien Tạo một giảng viên mới
         * @apiGroup GiangVien
         * @apiPermission none
         * 
         * @apiParam {string} Ten Họ tên giảng viên
         * @apiParam {string} Ma Mã số giảng viên
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      Ten: "Nguyen Van A",
         *      Ma: "GV-01",
         * }
         * 
         * @apiSuccess {int} Id Id của giảng viên vừa tạo
         * @apiSuccess {string} Ten Họ tên của giảng viên vừa tạo
         * @apiSuccess {string} Ma Mã số giảng viên vừa tạo
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      "Id": "1",
         *      "Ten": "Nguyen Van A",
         *      "Ma": "GV-01"
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "Mã giảng viên là trường bắt buộc"
         *      ]
         * }
         */

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

        /**
         * @api {PUT} /giangvien/CapNhatGiangVien Cập nhật thông tin một giảng viên
         * @apiGroup GiangVien
         * @apiPermission none
         * 
         * @apiParam {int} Id Id giảng viên cần cập nhật
         * @apiParam {string} Ten  Họ tên của giảng viên cần cập nhật
         * @apiParam {string} Ma Mã số giảng viên của giảng viên cần cập nhật
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      Id: "1",
         *      Ten: "Nguyen Van B",
         *      Ma: "GV-01",
         * }
         * 
         * @apiSuccess {int} Id Id giảng viên vừa cập nhật
         * @apiSuccess {string} Họ tên của giảng viên vừa cập nhật
         * @apiSuccess {string} Ma Mã số giảng viên của giảng viên vừa cập nhật
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      "Id": 1,
         *      "Ten": "Nguyen Van B",
         *      "Ma": "GV-01"
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "Không tìm thấy giảng viên có ID này"
         *      ]
         * }
         */

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

        /**
        * @api {GET} /giangviens/GetAll Lấy thông tin tất cả giảng viên 
        * @apiGroup GiangVien
        * @apiPermission none
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      "Id": 1,
        *      "Ten": "Nguyen Van B",
        *      "Ma": "GV-01"
        *      
        *      "Id": 2,
        *      "Ten": "Nguyen Van A",
        *      "Ma": "GV-01"
        * }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample {json} Error-Response:
        * {
        *      "Error":[        
        *      ]
        * }
        */

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

        /**
        * @api {GET} /giangviens/GetById?Id=Id Lấy thông tin giảng viên theo Id
        * @apiGroup GiangVien
        * @apiPermission none
        * 
        * @apiParam {int} Id Id của giảng viên
        * 
        * @apiExample Example usage: 
        * 
        * /api/giangviens/GetById?Id=1
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      "Id": 1,
        *      "Ten": "Nguyen Van A",
        *      "Ma": "GV-01"
        * }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample {json} Error-Response:
        * {
        *      "Error":[
        *          "Không tìm thấy giảng viên này!"
        *      ]
        * }
        */

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var GV = _db.GiangViens.FirstOrDefault(x => x.Id == id);

            if (GV == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy giảng viên này!");

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