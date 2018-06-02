using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ApiDBContext : DbContext
    {
        //private DbSet<GiangVien> _giangViens;

        public ApiDBContext() : base("ApiConnection")
        {

        }
        static ApiDBContext()
        {
            Database.SetInitializer<ApiDBContext>(new IdentityDbInit());
        }

        public static ApiDBContext Create()
        {
            return new ApiDBContext();
        }

        public DbSet<Lop> Lops { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

    internal class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApiDBContext>
	{
		public void Seed(ApiDBContext context)
		{
			PerformInit();
			base.Seed(context);
		}

		public void PerformInit()
		{

		}
	}
}
