using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Shared.Model
{
    public class Employee 
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal? Salary { get; set; }

        public string DepartmentName { get; set; }
    }
}
