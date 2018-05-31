using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
	public class LopController : ApiController
	{
		private ApiDBContext _db;

		public LopController()
		{
			this._db = new ApiDBContext();
		}

		[HttpPost]
		public IHttpActionResult TaoLop(CreateClassModel model)
		{
			IHttpActionResult httpActionResult;
			ErrorModel errors = new ErrorModel();

			if (string.IsNullOrEmpty(model.MaLop))
			{
				errors.Add("Mã lớp là trường bắt buộc");
			}

			if (string.IsNullOrEmpty(model.TenLop))
			{
				errors.Add("Tên lớp là trường bắt buộc");
			}

			if (errors.Errors.Count == 0)
			{
				Lop lop = new Lop();
				lop.Ma = model.MaLop;
				lop.Ten = model.TenLop;
                lop.GVCN_ID = model.GVCN_ID;
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

		[HttpPut]
		public IHttpActionResult CapNhatLop(UpdateClassModel model)
		{
			IHttpActionResult httpActionResult;
			ErrorModel errors = new ErrorModel();

			Lop lop = this._db.Lops.FirstOrDefault(x => x.Id == model.Id);

			if (lop == null)
			{
				errors.Add("Không tìm thấy lớp");

				httpActionResult = Ok(errors);
			}
			else
			{
				lop.Ma = model.MaLop ?? model.MaLop;
				lop.Ten = model.TenLop ?? model.TenLop;

				this._db.Entry(lop).State = System.Data.Entity.EntityState.Modified;

				this._db.SaveChanges();

				httpActionResult = Ok(new LopModel(lop));
			}

			return httpActionResult;
		}

		[HttpGet]
		public IHttpActionResult GetAll()
		{

            var listLops = this._db.Lops.Select(x => new LopModel()
			{
				MaLop = x.Ma,
				TenLop = x.Ten,
				Id  = x.Id,
			});

			return Ok(listLops);
		}

		[HttpGet]
		public IHttpActionResult GetById(int id)
		{
			IHttpActionResult httpActionResult; 
			var lop = _db.Lops.FirstOrDefault(x => x.Id == id);
            var GVCN = _db.GiangViens.FirstOrDefault(y => y.Id == id);
            if (lop == null)
			{
				ErrorModel errors = new ErrorModel();
				errors.Add("Không tìm thấy lớp");

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