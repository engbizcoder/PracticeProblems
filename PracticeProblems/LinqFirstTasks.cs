/*var employees = new List<Employee>
{
    new(1, "Alice", 1),
    new(2, "Bob", 1),
    new(3, "Charlie", 1),
    new(4, "David", 1),
    new(5, "Eve", 2),
    new(6, "Frank", 2),
    new(7, "Grace", 3),
    new(8, "Hannah", 3),
    new(9, "Ian", 4),
    new(10, "Jack", 4)
};

var departments = new List<Department>
{
    new(1, "HR"),
    new(2, "IT"),
    new(3, "Finance"),
    new(4, "Marketing")
};

#region Task1
var employeeWithNamesWithQuerySyntax =
    from d in departments
    join e in employees on d.DepartmentId equals e.DepartmentId into gj
    select new DepartmentEmployeeCount(d.DepartmentName, gj?.Count() ?? 0);

//Alternatively using 
var employeeWithNamesWithQuerySyntaxUsingDefaultIfEmpty =
    from d in departments
    join e in employees on d.DepartmentId equals e.DepartmentId into gj
    from employeeDepartmentGroup in gj.DefaultIfEmpty()
    group employeeDepartmentGroup by d
    into grouped
    select new DepartmentEmployeeCount(grouped.Key.DepartmentName, grouped?.Count() ?? 0);

var employeeWithNamesResultList = employeeWithNamesWithQuerySyntax.ToList();
employeeWithNamesResultList.ForEach(report =>
    Console.WriteLine($"Department: {report.DepartmentName}, Employee Count: {report.EmployeeCount}")
);
#endregion

//Aggregate department details
#region Task2

var departmentsWithHighestEmployeeCount = employeeWithNamesResultList.OrderByDescending(s => s.EmployeeCount).ToList();
Console.WriteLine($"The max employees are in department {departmentsWithHighestEmployeeCount.FirstOrDefault()?.DepartmentName}");
Console.WriteLine($"The minimum employees are in department {departmentsWithHighestEmployeeCount.LastOrDefault()?.DepartmentName}");

#endregion

//Complex filtering
#region Task3

var filteredEmployees =
    from d in departments
    join e in employees on d.DepartmentId equals e.DepartmentId
        into employeeGroup
    where (employeeGroup?.Count() ?? 0) > 3
    select new DepartmentEmployees(d, employeeGroup.OrderBy(s => s.Name));
  
foreach (var departmentEmployee in filteredEmployees)
{
    foreach (var employee in departmentEmployee.EmployeeGroup)
    {
        Console.WriteLine($"Department {departmentEmployee.Department.DepartmentName} has employees {employee.Name}");
    }
}

//Assuming we do flatten the data and not print per department then we do as following
var flattenedFilteringOfEmployees =
    (from d in departments
    join e in employees on d.DepartmentId equals e.DepartmentId
        into employeeGroup
    where (employeeGroup?.Count() ?? 0) > 3
    from employee in employeeGroup
    orderby employee.Name
    select employee).ToList();
foreach (var employee in flattenedFilteringOfEmployees)
{
    Console.WriteLine($"Employee name: {employee.Name}");
}

#endregion

internal record Employee(int EmployeeId, string Name, int DepartmentId);
internal record Department(int DepartmentId, string DepartmentName);
internal record DepartmentEmployeeCount(string DepartmentName, int EmployeeCount);
internal record DepartmentEmployees(Department Department, IEnumerable<Employee> EmployeeGroup);*/