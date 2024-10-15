using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Collection_Leave
{
    internal class Employee
    {
        private int EmpId;
        private string EmpName;
        private int DeptId;
        private int LeavesAvailable;

        public Employee(int EmpId, string EmpName, int DeptId, int LeavesAvailable)
        {
            this.EmpId = EmpId;
            this.EmpName = EmpName;
            this.DeptId = DeptId;
            this.LeavesAvailable = LeavesAvailable;
        }
        public int GetEmpId()
        {
            return EmpId;
        }

        public string GetEmpName()
        {
            return EmpName;
        }
        public int GetDeptId()
        {
            return DeptId;
        }
        public int GetLeavesAvailable()
        {
            return LeavesAvailable;
        }
        public bool RequestedLeaves(int requestedLeaves)
        {
            if(requestedLeaves <= LeavesAvailable)
            {
                LeavesAvailable -= requestedLeaves;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
