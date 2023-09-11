using System;
using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Services;

namespace MISA.Core.Services
{
	public class EmployeeService: IEmployeeService
	{
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public int InsertService(Employee employee)
        {
            // thuc hien validate du lieu
            //  Thong tin ma nhan vien bat buoc nhap:
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                throw new MISAValidateException("Mã nhân viên không được phép để trống");
            }
            // thong tin ho ten khong duoc phep de trong:
            if (string.IsNullOrEmpty(employee.FullName))
            {
                throw new MISAValidateException("Tên nhân viên không được phép để trống");
            }
            //  ngay sinh khong duoc lon hon ngay hien tai:
            if (employee.DateOfBirth >= DateTime.Now.Date)
            {
                throw new MISAValidateException("Ngày sinh không được lớn hơn ngày hiện tại");
            }
            // Sdt khong duoc phep de trong:
            if (string.IsNullOrEmpty(employee.PhoneNumber))
            {
                throw new MISAValidateException("Số điện thoại không được phép để trống");
            }
            // Ma nhan vien khong duoc phep trung :
            var isCheckEmployeeCode = _employeeRepository.CheckDuplicateCode(employee.EmployeeCode);
            if (isCheckEmployeeCode)
            {
                throw new MISAValidateException("Mã nhân viên không được phép trùng");
            }
            var res = _employeeRepository.Insert(employee);
            return res;
        }

        public int UpdateService(Employee employee, Guid employeeId)
        {
            // thuc hien validate du 
            // Thong tin ma nhan vien bat buoc nhap:
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                throw new MISAValidateException("Mã nhân viên không được phép để trống");
            }
            // thong tin ho ten khong duoc phep de trong:
            if (string.IsNullOrEmpty(employee.FullName))
            {
                throw new MISAValidateException("Tên nhân viên không được phép để trống");
            }

            //  ngay sinh khong duoc lon hon ngay hien tai:
            if (employee.DateOfBirth >= DateTime.Now.Date)
            {
                throw new MISAValidateException("Ngày sinh không được lớn hơn ngày hiện tại");
            }
            // Sdt khong duoc phep de trong:
            if (string.IsNullOrEmpty(employee.PhoneNumber))
            {
                throw new MISAValidateException("Số điện thoại không được phép để trống");
            }
            // Ma nhan vien khong duoc phep trung :
            var isCheckEmployeeCode = _employeeRepository.CheckDuplicateCode(employee.EmployeeCode);
            if (isCheckEmployeeCode)
            {
                throw new MISAValidateException("Mã nhân viên không được phép trùng");
            }
            var res = _employeeRepository.Update(employee, employeeId);
                return res;
        }
    }
}

