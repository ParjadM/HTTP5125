using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative1.Model
{
    public class Teacher 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
