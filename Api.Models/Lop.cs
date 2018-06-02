using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
	public class Lop : Entity<int>
	{
		public string Ma { get; set; }
		public string Ten { get; set; }
        public virtual ICollection<SinhVien> Students { get; set; }
        public virtual GiangVien GVCN { get; set; }
        public virtual ICollection<GiangVien> GVs { get; set; }		
	}
}
