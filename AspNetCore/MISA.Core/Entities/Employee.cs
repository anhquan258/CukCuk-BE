using System;
namespace MISA.Core.Entities
{
	public class Employee
	{

        public Guid EmployeeId { get; set; }
        public String? TaxCode { get; set; }
        public Decimal? Salary { get; set; }
        public String EmployeeCode { get; set; }
        public int? Gender { get; set; }
        public int? WorkStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? IdentityDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public String FullName { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? PositionId { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String IdentityNumber { get; set; }
        public String? IdentityPlace { get; set; }
    }

}


