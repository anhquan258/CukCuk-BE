using System;
using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Infrastructure
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetAll();
		Employee GetById(Guid employeeId);
		int Insert(Employee employee);
		int Update(Employee employee,Guid employeeId);
		int Delete(Guid employee);
		IEnumerable<Employee> GetPaging(int pageSize, int pageIndex);
		bool CheckDuplicateCode(string employeeCode);
	}
}

