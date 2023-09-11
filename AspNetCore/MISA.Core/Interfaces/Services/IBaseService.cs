using System;
namespace MISA.Core.Interfaces.Services
{
	public interface IBaseService<MISAentity>
	{
	
        int InsertService(MISAentity misaEntity); 

        int UpdateService(MISAentity misaEntity, Guid misaEntityId);
        
	}
}

