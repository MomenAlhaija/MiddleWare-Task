﻿namespace MSTART_Task.Models
{
    public class User
    {
        public int ID { get; set; }
        public DateTime? Server_DateTime { get; set; }
        public DateTime? DateTime_UTC { get; set; }
        public DateTime? Update_DateTime_UTC { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set;}
        public int Status { get; set;}
        public int Gender { get; set;}
        public DateTime? Date_Of_Birth { get; set;}
    }
}
