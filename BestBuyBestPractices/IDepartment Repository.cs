using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    internal interface IDepartment_Repository 
    {
        IEnumerable<Departments> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }


    

}
