using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class EmployeeDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string NID { get; set; }
        public string PhotoPath { get; set; }
        public List<Address> Address { get; set; }
        public List<Education> Education { get; set; }
    }
}