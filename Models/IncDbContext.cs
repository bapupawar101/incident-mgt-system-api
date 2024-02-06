using Microsoft.EntityFrameworkCore;

namespace IncidentMgtSystem.API.Models
{
    public class IncDbContext : DbContext
    {
        public DbSet<UserLogin> tbl_UserLogin { get; set; }
        public DbSet<User> tbl_User { get; set; }
        public DbSet<RoleMaster> tbl_RoleMaster { get; set; }
        public DbSet<UserRoles> tbl_UserRoles { get; set; }
        public DbSet<IncidentMaster> tbl_IncidentMaster { get; set; }
        public DbSet<IncidentComments> tbl_IncidentComments { get; set; }
        public DbSet<IncidentMasterJson> tbl_IncidentMasterJson { get; set; }
        public DbSet<TenantMaster> tbl_TenantMaster { get; set; }
        public DbSet<CityMaster> tbl_CityMaster { get; set; }
        public DbSet<StateMaster> tbl_StateMaster { get; set; }
        public DbSet<CountryMaster> tbl_CountryMaster { get; set; }

        public IncDbContext(DbContextOptions<IncDbContext> options) : base(options) { 
        
        }
    }
}
