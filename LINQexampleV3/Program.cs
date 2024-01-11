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

#region Grouping Operation
////Groupby
//var groupResult = from emp in employeeList
//                  orderby emp.DepartmentId
//                  group emp by emp.DepartmentId;
//foreach (var empGroup in groupResult)
//{
//    Console.WriteLine($"Department Id: {empGroup.Key}");
//    foreach (Employee emp in empGroup)
//    {
//        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
//    }
//}

////ToLookup
//var groupResult = employeeList.OrderBy(o =>o.DepartmentId).ToLookup(e => e.DepartmentId);
//foreach (var empGroup in groupResult)
//{
//    Console.WriteLine($"Department Id: {empGroup.Key}");
//    foreach (Employee emp in empGroup)
//    {
//        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
//    }
//}
#endregion

#region Quantifier Operators
////All and Any Operators
//var annualSalaryCompare = 2000;
//bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare);
//if (isTrueAll)
//    Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
//else 
//    Console.WriteLine($"Not all employee annual salaries are above {annualSalaryCompare}");
///////////
//bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
//if (isTrueAny)
//    Console.WriteLine($"At least one employee has annual salary above {annualSalaryCompare}");
//else
//    Console.WriteLine($" No employee has annual salary above {annualSalaryCompare}");

////Contains Operator
//var searchEmployee = new Employee
//{
//    Id = 3,
//    FirstName = "Douglas",
//    LastName = "Roberts",
//    AnnualSalary = 40000.2m,
//    IsManager = false,
//    DepartmentId = 1
//};
//bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());
//if (containsEmployee )
//    Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found");
//else
//    Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was not found");
#endregion

#region Filter Operation
////OfType filter Operation
ArrayList mixedCollection =Data.GetHeterogeneousDataCollection();
//var stringResult = from s in mixedCollection.OfType<string>()
//                   select s;
//foreach (var item in stringResult)
//    Console.WriteLine(item);
//var intResult = from s in mixedCollection.OfType<int>()
//                   select s;
//foreach (var item in intResult)
//    Console.WriteLine(item);
//var employeeResult = from e in mixedCollection.OfType<Employee>()
//                     select e;
//foreach (var employee in employeeResult)
//    Console.WriteLine($"{employee.Id, -5} {employee.FirstName,-15} {employee.LastName, -15}");
//var departmentResult = from d in mixedCollection.OfType<Department>()
//                     select d;
//foreach (var department in departmentResult)
//    Console.WriteLine($"{department.Id,-5} {department.ShortName,-15} {department.LongName,-35}");
#endregion

#region Element Operation
////ElementAt and ElementAtOrDefault
//var employee = employeeList.ElementAt(8);
//Console.WriteLine($"{employee.Id,-5} {employee.FirstName,-15} {employee.LastName,-35}");
//var employee = employeeList.ElementAtOrDefault(8);
//if (employee != null)
//    Console.WriteLine($"{employee.Id,-5} {employee.FirstName,-15} {employee.LastName,-35}");
//else
//    Console.WriteLine("This employee record does not exist within the collection");
////First, FirstOrDefault, Last, LastOrDefault
//List<int> integerList = new List<int> { 3, 141, 15, 25, 35, 15, 841, 123 };
//int result = integerList.First();
//int result = integerList.First(x => x%2==0);
//int result = integerList.Last();
//int result = integerList.Last(x => x%2==0);
//Console.WriteLine(result);
//int result = integerList.FirstOrDefault(x => x%2==0);
//int result = integerList.LastOrDefault(x => x % 2 == 0);
//if (result != 0)
//    Console.WriteLine(result);
//else
//    Console.WriteLine("There are no even numbers in the collection");
////Single, SingleOrDefault Operators
//var emp = employeeList.Single();
//var emp = employeeList.Single(x => x.Id==2);
//Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
//var emp = employeeList.SingleOrDefault(x=> x.Id>3);
//if (emp != null)
//    Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
//else
//    Console.WriteLine("This employee does not exist within the collection");
#endregion

Console.ReadKey();

public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? x, Employee? y)
    {
        if(x.Id==y.Id && x.FirstName.ToLower()==y.FirstName.ToLower() && x.LastName.ToLower()==y.LastName.ToLower())
            return true;
        return false;
    }
    public int GetHashCode([DisallowNull] Employee obj)
    {
        return obj.Id.GetHashCode();
    }
};