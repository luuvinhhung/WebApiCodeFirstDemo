using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GiangVien: Entity<int>
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        [InverseProperty("GVCN")]
        public virtual ICollection<Lop> ChuNhiems { get; set; }
        [InverseProperty("GVs")]
        public virtual ICollection<Lop> LopDays { get; set; }      
    }
}
