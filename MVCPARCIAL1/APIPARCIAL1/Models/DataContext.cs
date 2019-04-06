using System.Data.Entity;

namespace APIPARCIAL1.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<APIPARCIAL1.Models.MauroHernandezFriend> MauroHernandezFriends { get; set; }
    }
}