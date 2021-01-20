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
                    AppName = "学生公众号",
                    AppId = Configuration["WeChat:AppId"],
                    AppSecret = Configuration["WeChat:AppSecret"],
                    Url = "/wechat/notify2",
                    Token = "222222222",
                    EncodingAESKey = "3333333"
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
