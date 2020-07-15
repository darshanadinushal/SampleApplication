using System;
using System.Collections.Generic;

namespace Sample.Application.RestService.Service.DBModel
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifitedDate { get; set; }
        public string ModifitedBy { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
