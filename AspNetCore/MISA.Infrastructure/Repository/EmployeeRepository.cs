using System;
using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MySqlConnector;

namespace MISA.Infrastructure.Repository
{
	public class EmployeeRepository :BaseRepository<Employee>, IEmployeeRepository
	{

        public EmployeeRepository()
        { 
        }

        private IEnumerable<Employee> Ok(IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid employeeId)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString)) {
                //2.Lay du lieu:
                //2.1 Cau lenh truy van du lieu:
                var sqlCommand = $"SELECT * FROM Employee Where EmployeeId =@EmployeeId";
                //Neu truy van sql phai su dung DynamicParameter
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                //2.2 Thuc hien lay du lieu:
                var employee = SqlConnection.QueryFirstOrDefault<Employee>(sql: sqlCommand, param: parameters);
                //Tra ket qua cho Client
                return employee;
            }
            
        }

        public IEnumerable<Employee> GetPaging(int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee employee)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                // Bước 2: Thực hiện thêm mới dữ liệu:
                employee.EmployeeId = Guid.NewGuid();
                var sqlCommand = "INSERT INTO employees(EmployeeId, EmployeeCode, FullName, DateOfBirth, Gender, IdentityNumber, IdentityDate, IdentityPlace, Email, PhoneNumber, TaxCode, Salary, JoinDate, WorkStatus, DepartmentId, PositionId)" +
                                  "VALUES(@EmployeeId, @EmployeeCode, @FullName, @DateOfBirth, @Gender, @IdentityNumber, @IdentityDate, @IdentityPlace, @Email, @PhoneNumber, @TaxCode, @Salary, @JoinDate, @WorkStatus, @DepartmentId, @PositionId)";
                // tạo mới employeeId
                var res = SqlConnection.Execute(sql: sqlCommand, param: employee);

                return res;
            }
        }

        public int Update(Employee employee, Guid employeeId)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                employee.EmployeeId = employeeId;
                // Bước 2: Thực hiện thêm mới dữ liệu:
                var sqlCommand = "UPDATE employees e SET EmployeeCode = @EmployeeCode, FullName = @FullName, DateOfBirth = @DateOfBirth, Gender = @Gender, IdentityNumber = @IdentityNumber, IdentityDate = @IdentityDate, IdentityPlace = @IdentityPlace, Email = @Email, PhoneNumber = @PhoneNumber, TaxCode = @TaxCode, Salary = @Salary, JoinDate = @JoinDate, WorkStatus = @WorkStatus, DepartmentId = @DepartmentId, PositionId = @PositionId WHERE EmployeeId = @EmployeeId;";

                // sửa nhân viên employeeId
                var res = SqlConnection.Execute(sql: sqlCommand, param: employee);
                return res;
            }
        }

        public bool CheckDuplicateCode(string employeeCode)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"SELECT * FROM employees WHERE EmployeeCode = @EmployeeCode";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", employeeCode);
                var res = SqlConnection.QueryFirstOrDefault<Employee>(sql: sqlCommand, param: parameters);

                if (res != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

