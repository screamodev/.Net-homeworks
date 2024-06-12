select * from Sales.Customer;

select * from Sales.Store
  order by Name asc;

select * from HumanResources.Employee
  where BirthDate > '1989-09-28';

select NationalIDNumber, LoginID, JobTitle from HumanResources.Employee
  where LoginID like '%0'
    order by JobTitle asc;

select * from Person.Person
  where ModifiedDate between '2008-01-01' and '2008-12-01'
    and MiddleName is not null and title is null;

select distinct Name from HumanResources.Department d
  join HumanResources.EmployeeDepartmentHistory edh on d.DepartmentID = edh.DepartmentID;

select count(CommissionPct) from Sales.SalesPerson
  where CommissionPct > 0
    group by TerritoryID;

select * from HumanResources.Employee
  where VacationHours = (select max(VacationHours) from HumanResources.Employee);

select * from HumanResources.Employee
 where JobTitle like 'Sales Representative' 
  or JobTitle like 'Network Administrator' 
  or JobTitle like 'Network Manager';

select e.*, p.* from HumanResources.Employee e
left join Purchasing.PurchaseOrderHeader p on e.BusinessEntityID = p.EmployeeID;