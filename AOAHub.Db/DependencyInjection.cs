using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AOAHub.Db
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AOAContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
