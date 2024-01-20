
using System;
namespace ReviewTheCore.Exeption
{
    public class CustomeExeption: System.Exception
    {
        public CustomeExeption() : base() 
        {
            
        }
        public CustomeExeption(string? message):base(message) 
        {
            
        }
        public CustomeExeption(string? message,Exception? innerException):base(message, innerException)
        {
            
        }
    }
}
