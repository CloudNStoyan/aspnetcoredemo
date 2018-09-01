using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Demo1
{
    public class MyMiddleWare
    {
        public RequestDelegate Next { get; set; }
        private int a;
        private int b;

        public MyMiddleWare(RequestDelegate next, int a,int b)
        {
            this.Next = next;
            this.a = a;
            this.b = b;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync(this.a + "\n");
            await this.Next(context);
            await context.Response.WriteAsync(this.b + "\n");
        }
    }

    public static class MiddleWareExtension
    {
        public static void UseMyMiddlware(this IApplicationBuilder app,int a ,int b)
        {
            app.UseMiddleware<MyMiddleWare>(a,b);
        }
    }
}
