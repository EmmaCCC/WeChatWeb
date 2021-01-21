using Emma.WeChat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WeChatWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddWeChat(opts =>
            {
                opts.AppConfigs.Add(new AppConfig()
                {
                    AppName = "学生公众号1",
                    AppId = Configuration["WeChat:AppId"],
                    AppSecret = Configuration["WeChat:AppSecret"],
                    Url = "/wechat/notify1",
                    Token = "1111111",
                    EncodingAESKey = "1111111"
                });
                opts.AppConfigs.Add(new AppConfig()
                {
                    AppName = "学生公众号2",
                    AppId = Configuration["WeChat:AppId"]+"two",
                    AppSecret = Configuration["WeChat:AppSecret"],
                    Url = "/wechat/notify2",
                    Token = "2222222",
                    EncodingAESKey = "2222222"
                });
            })
            .AddMessageNotifier<MyWeChatNotifier>()
            .AddRequestFilter<MyWeChatRequestFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWeChat();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
