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
        /**
         * @api {POST} /sinhviens/TaoSinhVien Tạo một sinh viên mới
         * @apiGroup SinhVien
         * @apiPermission none
         * 
         * @apiParam {string} HoTen Họ tên sinh viên
         * @apiParam {DateTime} NgaySinh Ngày sinh của sinh viên
         * @apiParam {string} DiaChi Địa chỉ của sinh viên
         * @apiParam {string} MSSV Mã số sinh viên
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      HoTen: "Nguyen Van A",
         *      NgaySinh: "01/01/1991",
         *      DiaChi: "abc",
         *      MSSV: "N14DCCN001",
         * }
         * 
         * @apiSuccess {int} Id Id của sinh viên vừa tạo
         * @apiSuccess {string} HoTen Họ tên của sinh viên vừa tạo
         * @apiSuccess {DateTime} NgaySinh Ngày sinh của sinh viên vừa tạo
         * @apiSuccess {string} DiaChi Địa chỉ của sinh viên vừa tạo
         * @apiSuccess {string} MSSV Mã số sinh viên vừa tạo
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      "Id": "1",
         *      "HoTen": "Nguyen Van A",
         *      "NgaySinh": "1991-01-01T00:00:00",
         *      "DiaChi": "abc",
         *      "MSSV": "N14DCCN001"
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "MSSV là trường bắt buộc"
         *      ]
         * }
         */
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
                SV.DiaChi = model.DiaChi;
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

        /**
         * @api {PUT} /sinhviens/CapNhatSV Cập nhật thông tin một sinh viên
         * @apiGroup SinhVien
         * @apiPermission none
         * 
         * @apiParam {int} Id Id sinh viên cần cập nhật
         * @apiParam {string} HoTen  Họ tên của sinh viên cần cập nhật
         * @apiParam {string} DiaChi Điạ chỉ của sinh viên cần cập nhật
         * @apiParam {string} MSSV Mã số sinh viên của sinh viên cần cập nhật
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      Id: "1",
         *      HoTen: "Nguyen Van B",
         *      DiaChi: "abc",
         *      MSSV: "N14DCCN001",
         * }
         * 
         * @apiSuccess {int} Id Id sinh viên vừa cập nhật
         * @apiSuccess {string} Họ tên của sinh viên vừa cập nhật
         * @apiSuccess {string} DiaChi Điạ chỉ của sinh viên của cập nhật
         * @apiSuccess {string} MSSV Mã số sinh viên của sinh viên vừa cập nhật
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      "Id": 1,
         *      "HoTen": "Nguyen Van B",
         *      "NgaySinh": "1991-01-01T00:00:00",
         *      "DiaChi": "abc",
         *      "MSSV": "N14DCCN001"
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "Không tìm thấy sinh viên có ID này"
         *      ]
         * }
         */
        [HttpPut]
        public IHttpActionResult CapNhatSV(UpdateSVModel model)
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

        /**
        * @api {GET} /sinhviens/GetAll Lấy thông tin tất cả sinh viên 
        * @apiGroup SinhVien
        * @apiPermission none
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      "Id": 1,
        *      "HoTen": "Nguyen Van B",
        *      "NgaySinh": "1991-01-01T00:00:00",
        *      "DiaChi": "abc",
        *      "MSSV": "N14DCCN001"
        *      
        *      "Id": 2,
        *      "HoTen": "Nguyen Van A",
        *      "NgaySinh": "1991-01-01T00:00:00",
        *      "DiaChi": "abc",
        *      "MSSV": "N14DCCN001"
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

        /**
        * @api {GET} /sinhviens/GetById?Id=Id Lấy thông tin sinh viên theo Id
        * @apiGroup SinhVien
        * @apiPermission none
        * 
        * @apiParam {int} Id Id của sinh viên
        * 
        * @apiExample Example usage: 
        * 
        * /api/sinhviens/GetById?Id=1
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      "Id": 1,
        *      "HoTen": "Nguyen Van B",
        *      "NgaySinh": "1991-01-01T00:00:00",
        *      "DiaChi": "abc",
        *      "MSSV": "N14DCCN001"
        * }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample {json} Error-Response:
        * {
        *      "Error":[
        *          "Không tìm thấy sinh viên này!"
        *      ]
        * }
        */

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var SV = _db.SinhViens.FirstOrDefault(x => x.Id == id);

            if (SV == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy sinh viên này!");

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
