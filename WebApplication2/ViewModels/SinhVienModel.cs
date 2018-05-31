using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class SinhVienModel
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string MSSV { get; set; }

        public SinhVienModel() { }
        public SinhVienModel(SinhVien SV)
        {
            this.Id = SV.Id;
            this.HoTen = SV.HoTen;
            this.NgaySinh = SV.NgaySinh;
            this.DiaChi = SV.DiaChi;
            this.MSSV = SV.MSSV;
        }
    }

    public class CreateSVModel
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string MSSV { get; set; }
    }

    public class UpdateSVModel : CreateSVModel
    {
        public int Id { get; set; }
    }
    
}