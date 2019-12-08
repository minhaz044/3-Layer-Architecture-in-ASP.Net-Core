using Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IEmployeeService
    {
        void SaveToDb(Employee Employee);
    }
}
