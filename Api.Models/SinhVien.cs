﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
	public class SinhVien: Entity<int>
	{

        public string HoTen { get; set; }
		public DateTime NgaySinh { get; set; }
		public string DiaChi { get; set; }
		public string MSSV { get; set; }
        public virtual Lop Lop { get; set; }

    }
}
