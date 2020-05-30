using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApi.Properties;

namespace WebApi.Models
{
    public class Book
    {
        public int ID { get; set; }
        [MinLength(5)]
        public string Name { get; set; }
    }
}