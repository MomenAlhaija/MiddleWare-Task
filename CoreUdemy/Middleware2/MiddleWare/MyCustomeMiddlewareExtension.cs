namespace CoreUdemy.MiddleWare
{
    public static class MyCustomeMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomeMiddleware
            (this IApplicationBuilder app)
        {
          return  app.UseMiddleware<MyCustomeMiddleware>();
        }
       
    }
}
