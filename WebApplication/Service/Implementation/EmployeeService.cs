using Database.IRepository;
using Database.Models;
using Database.UnitOfWork;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }
        public void SaveToDb(Employee Employee)
        {
            _unitOfWork.Repository<Employee>().Insert(Employee);
            _unitOfWork.Save();
        }
    }
}
