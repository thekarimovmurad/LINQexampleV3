using LINQexampleV3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

#region Sorting Operation
////method syntax
//var result = employeeList.Join(departmentList, e => e.DepartmentId, d => d.Id,
//    (emp, dep) => new
//    {
//        Id = emp.Id,
//        FirstName = emp.FirstName,
//        LastName = emp.LastName,
//        AnnualSalary = emp.AnnualSalary,
//        DepartmentId = emp.DepartmentId,
//        DepartmentName = dep.LongName
//    }).OrderBy(o => o.DepartmentId).ThenByDescending(o => o.AnnualSalary);
//foreach (var item in result)
//{
//    Console.WriteLine($"First Name:{item.FirstName,-10} Last Name: {item.LastName,-10} Annual Salary: {item.AnnualSalary,10}\tDepartment Name: {item.DepartmentName}");
//}

////query syntax
//var result = from emp in employeeList
//             join dep in departmentList
//             on emp.DepartmentId equals dep.Id
//             orderby emp.DepartmentId, emp.AnnualSalary descending
//             select new
//             {
//                Id= emp.Id,
//                FirstName= emp.FirstName,
//                LastName= emp.LastName,
//                AnnualSalary = emp.AnnualSalary,
//                DepartmentId= emp.DepartmentId,
//                DepartmentName = dep.LongName
//             };
//foreach (var item in result)
//{
//    Console.WriteLine($"First Name:{item.FirstName,-10} Last Name: {item.LastName, -10} Annual Salary: {item.AnnualSalary,10}\tDepartment Name: {item.DepartmentName}");
//}
#endregion




Console.ReadKey();