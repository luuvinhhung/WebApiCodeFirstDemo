using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace WebApplication2.ViewModels
{
    public class GiangVienModel
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DSLD { get; set; }

        public GiangVienModel() { }
        public GiangVienModel(GiangVien GV)
        {
            this.Id = GV.Id;
            this.Ma = GV.Ma;
            this.Ma = GV.Ten;
            this.DSLD = GV.LopDays.ToString();
        }
    }

    public class CreateGVModel
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
    }

    public class UpdateGVModel : CreateGVModel
    {
        public int Id { get; set; }
    }
}