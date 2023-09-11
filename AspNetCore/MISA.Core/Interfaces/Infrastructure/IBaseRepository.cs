using System;
namespace MISA.Core.Interfaces.Infrastructure
{
	public interface IBaseRepository<MISAentity>
	{
        IEnumerable<MISAentity> GetAll();
        MISAentity GetById(Guid employeeId);
        int Insert(MISAentity employee);
        int Update(MISAentity employee, Guid employeeId);
        int Delete(Guid employee);
    }

}

