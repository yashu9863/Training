using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}