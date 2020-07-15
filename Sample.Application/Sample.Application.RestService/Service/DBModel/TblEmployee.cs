using System;
using System.Collections.Generic;

namespace Sample.Application.RestService.Service.DBModel
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal? Salary { get; set; }
        public byte? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifitedBy { get; set; }
        public DateTime? ModifitedDate { get; set; }
        public int? DepartmentId { get; set; }

        public virtual TblDepartment Department { get; set; }
    }
}
