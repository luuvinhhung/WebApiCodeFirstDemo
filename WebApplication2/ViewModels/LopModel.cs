using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
	public class LopModel
	{
        public int Id { get; set; }
        public string MaLop { get; set; }
		public string TenLop { get; set; }
        public int GVCN_ID { get; set; }

		public LopModel() { }
		public LopModel(Lop lop)
		{
            this.Id = lop.Id;
            this.MaLop = lop.Ma;
			this.TenLop = lop.Ten;

            this.GVCN_ID = lop.GVCN_ID;
		}
	}

	public class CreateClassModel
	{
		public string MaLop { get; set; }
		public string TenLop { get; set; }
        public int GVCN_ID { get; set; }
	}

	public class UpdateClassModel : CreateClassModel
	{
		public int Id { get; set; }
	}
}