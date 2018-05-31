using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GiangVienLop: Entity<int>
    {
        public virtual GiangVien GV { get; set; }
        public virtual Lop Lop { get; set; }
    }
}
