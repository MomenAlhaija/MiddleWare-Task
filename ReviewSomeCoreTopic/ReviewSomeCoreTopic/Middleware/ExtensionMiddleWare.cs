namespace ReviewSomeCoreTopic.Middleware
{
    public static class ExtensionMiddleWare
    {
        public static IApplicationBuilder useMyCustomeMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomeMiddleware>();
        }
    }
}
