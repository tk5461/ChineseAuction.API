using Microsoft.EntityFrameworkCore;
using ChineseAuctionAPI.Data;
using Microsoft.EntityFrameworkCore.Design;

namespace ChineseAuctionAPI.Data
{
    public class SalesContextFactory
    {

            private const string ConnectionString = "Server=DESKTOP-021APTL\\SQLEXPRESS;DataBase=0583285461_SalesAPI;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";

            public static SalesContextDB CreateContext()
            {
                var optionsBuilder = new DbContextOptionsBuilder<SalesContextDB>();
                optionsBuilder.UseSqlServer(ConnectionString);
                return new SalesContextDB(optionsBuilder.Options);
            }
        }
}






