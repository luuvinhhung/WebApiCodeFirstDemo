using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GiangVien: Entity<int>
    {
        public string Ma { get; set; }
        public string Ten { get; set; }

        public virtual ICollection<GiangVienLop> LopDays { get; set; }
        public virtual ICollection<Lop> ChuNhiems { get; set; }
    }
}
