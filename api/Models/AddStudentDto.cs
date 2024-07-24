using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AddStudentDto
    {
       public string LastName { get; set; } = string.Empty;
       public string FirstName { get; set; }  = string.Empty;
       public string Programme { get; set; }  = string.Empty;
       public string EmailAddress { get; set; } = string.Empty;
       public string Level { get; set; } = string.Empty; 
    }
}