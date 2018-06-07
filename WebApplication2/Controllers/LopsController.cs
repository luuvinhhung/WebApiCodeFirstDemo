using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
	public class LopsController : ApiController
	{
		private ApiDBContext _db;

		public LopsController()
		{
			this._db = new ApiDBContext();
		}

        /**
         * @api {POST} /lops/TaoLop Tạo một lớp mới
         * @apiGroup Lop
         * @apiPermission none
         * 
         * @apiParam {string} Ten Tên lớp
         * @apiParam {string} MaLop Mã lớp
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      TenLop: "CNTT",
         *      MaLop: "D14",
         * }
         * 
         * @apiSuccess {int} Id Id của lớp vừa tạo
         * @apiSuccess {string} TenLop Tên của lớp vừa tạo
         * @apiSuccess {string} MaLop Mã lớp vừa tạo
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      "Id": "1",
         *      "TenLop": "CNTT",
         *      "MaLop": "D14"
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "Mã lớp là trường bắt buộc!"
         *      ]
         * }
         */

        [HttpPost]
		public IHttpActionResult TaoLop(CreateClassModel model)
		{
			IHttpActionResult httpActionResult;
			ErrorModel errors = new ErrorModel();

			if (string.IsNullOrEmpty(model.MaLop))
			{
				errors.Add("Mã lớp là trường bắt buộc!");
			}

			if (errors.Errors.Count == 0)
			{
				Lop lop = new Lop();
				lop.MaLop = model.MaLop;
				lop.TenLop = model.TenLop;
                //lop.GVCN_ID = model.GVCN_ID;
				lop = _db.Lops.Add(lop);

				this._db.SaveChanges();

				LopModel viewModel = new LopModel(lop);

				httpActionResult = Ok(viewModel);
			}
			else
			{
				httpActionResult = Ok(errors);
			}

			return httpActionResult;
		}

        /**
         * @api {PUT} /lops/CapNhatLop Cập nhật thông tin một lớp
         * @apiGroup Lop
         * @apiPermission none
         * 
         * @apiParam {int} Id Id lớp cần cập nhật
         * @apiParam {string} TenLop Tên của lớp cần cập nhật
         * @apiParam {string} MaLop Mã lớp của lớp cần cập nhật
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      Id: "1",
         *      TenLop: "VT",
         *      MaLop: "D13",
         * }
         * 
         * @apiSuccess {int} Id Id lớp vừa cập nhật
         * @apiSuccess {string} TenLop Tên của lớp vừa cập nhật
         * @apiSuccess {string} MaLop Mã lớp của lớp vừa cập nhật
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      "Id": 1,
         *      "TenLop": "CNTT",
         *      "MaLop": "D14",
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "Không tìm thấy lớp này!"
         *      ]
         * }
         */

        [HttpPut]
		public IHttpActionResult CapNhatLop(UpdateClassModel model)
		{
			IHttpActionResult httpActionResult;
			ErrorModel errors = new ErrorModel();

			Lop lop = this._db.Lops.FirstOrDefault(x => x.Id == model.Id);

			if (lop == null)
			{
				errors.Add("Không tìm thấy lớp này!");

				httpActionResult = Ok(errors);
			}
			else
			{
				lop.MaLop = model.MaLop ?? model.MaLop;
				lop.TenLop = model.TenLop ?? model.TenLop;

				this._db.Entry(lop).State = System.Data.Entity.EntityState.Modified;

				this._db.SaveChanges();

				httpActionResult = Ok(new LopModel(lop));
			}

			return httpActionResult;
		}

        /**
        * @api {GET} /lops/GetAll Lấy thông tin tất cả các lớp
        * @apiGroup Lop
        * @apiPermission none
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      "Id": 1,
        *      "TenLop": "CNTT",
        *      "MaLop": "D14"
        *      
        *      "Id": 2,
        *      "TenLop": "VT",
        *      "MaLop": "D13"
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

            var listLops = this._db.Lops.Select(x => new LopModel()
			{
                Id = x.Id,
                MaLop = x.MaLop,
				TenLop = x.TenLop,			
			});

			return Ok(listLops);
		}

                /**
        * @api {GET} /giangviens/GetById?Id=Id Lấy thông tin lớp theo Id
        * @apiGroup Lop
        * @apiPermission none
        * 
        * @apiParam {int} Id Id của lớp
        * 
        * @apiExample Example usage: 
        * 
        * /api/giangviens/GetById?Id=1
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      "Id": 1,
        *      "TenLop": "CNTT",
        *      "MaLop": "D14"
        * }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample {json} Error-Response:
        * {
        *      "Error":[
        *          "Không tìm thấy lớp này!"
        *      ]
        * }
        */

		[HttpGet]
		public IHttpActionResult GetById(int id)
		{
			IHttpActionResult httpActionResult; 
			var lop = _db.Lops.FirstOrDefault(x => x.Id == id);
            var GVCN = _db.GiangViens.FirstOrDefault(y => y.Id == id);
            if (lop == null)
			{
				ErrorModel errors = new ErrorModel();
				errors.Add("Không tìm thấy lớp này!");

				httpActionResult = Ok(errors);
			}
			else
			{
				httpActionResult = Ok(new LopModel(lop));
                httpActionResult = Ok(new GiangVienModel(GVCN));
            }

			return httpActionResult;
		} 
	}
}