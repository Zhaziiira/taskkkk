create TABLE Employees
(
    emp_id INT,
    emp_name NVARCHAR(20),
    dept_id int,
	salary int
)
INSERT INTO Employees (emp_id, emp_name, dept_id , salary) VALUES (1,'James' , 10,2000);
INSERT INTO Employees (emp_id, emp_name, dept_id , salary) VALUES (2,'Jack' , 10,4000);
INSERT INTO Employees (emp_id, emp_name, dept_id , salary) VALUES (3,'Henry' , 11,6000);
INSERT INTO Employees (emp_id, emp_name, dept_id , salary) VALUES (3,'Tom' , 11,8000);
INSERT INTO Employees (emp_id, emp_name, dept_id , salary) VALUES (3,'Hanry' , 11,4000);
INSERT INTO Employees (emp_id, emp_name, dept_id , salary) VALUES (3,'Alisa' , 10,6000);

select * from Employees where lower(emp_name) like '%m%'

select max(salary)
from Employees
    group by dept_id

select * from Employees where salary in (
select salary
 from Employees group by salary 
 having  count(salary )>1)



