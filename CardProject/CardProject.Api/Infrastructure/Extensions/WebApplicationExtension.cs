namespace CardProject.Api.Infrastructure.Extensions
{
    public static class WebApplicationExtension
    {
        public static void ConfigureMapping(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
