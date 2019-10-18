using System.Reflection.Metadata;

namespace WebApiUser.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Emaill { get; set; }   
        public string Phone { get; set; }
        public string Photo { get; set; }
    }
}