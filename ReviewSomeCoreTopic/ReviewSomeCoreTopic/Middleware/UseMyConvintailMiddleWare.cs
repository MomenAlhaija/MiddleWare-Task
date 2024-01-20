namespace ReviewSomeCoreTopic.Middleware
{
    public static class UseMyConvintailMiddleWare
    {
        public static IApplicationBuilder UseConvintalMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ConvintaionalMiddleWare>();
        }
    }
}
