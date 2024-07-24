using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace api.Models
{
    public class Student
    {
       
       public int Id { get; set; }
       public string LastName { get; set; } = string.Empty;
       public string FirstName { get; set; }  = string.Empty;
       public string Programme { get; set; }  = string.Empty;
       public string EmailAddress { get; set; } = string.Empty;
       public string Level { get; set; } = string.Empty;

    }
}