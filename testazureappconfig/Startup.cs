using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace testazureappconfig
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async ctx => 
            {
                var sb = new StringBuilder();
                sb.AppendLine($"{configuration["Curso:Nombre"]}");
                sb.AppendLine($"{configuration["Curso:Tema"]}");
                await ctx.Response.WriteAsync(sb.ToString());
            });
        }
    }
}