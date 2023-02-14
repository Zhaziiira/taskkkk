create TABLE CUSTOMERS
(
    ID INT,
    NAME NVARCHAR(20),
    MANAGER_ID int
);
INSERT INTO CUSTOMERS (ID, NAME, MANAGER_ID) VALUES (1,'James' , 1);
INSERT INTO CUSTOMERS  (ID, NAME, MANAGER_ID) VALUES (2,'Zhansaya',2);
INSERT INTO CUSTOMERS (ID, NAME, MANAGER_ID) VALUES (3,'Henry' , 3);
INSERT INTO CUSTOMERS (ID, NAME, MANAGER_ID) VALUES (4,'Tom' , 4);
INSERT INTO CUSTOMERS (ID, NAME, MANAGER_ID) VALUES (5,'Hanry' , 1);
INSERT INTO CUSTOMERS (ID, NAME, MANAGER_ID) VALUES (6,'Alisa' ,2);

create TABLE MANAGER
(
    ID INT,
    NAME NVARCHAR(20),
);
INSERT INTO MANAGER (ID, NAME) VALUES (1,'MANAGER 1');
INSERT INTO MANAGER (ID, NAME) VALUES (2,'MANAGER 2');
INSERT INTO MANAGER (ID, NAME) VALUES (3,'MANAGER 3');
INSERT INTO MANAGER (ID, NAME) VALUES (4,'MANAGER 4');

create TABLE ORDERS
(
    ID INT,
    DATE NVARCHAR(20),
	AMOUNT INT,
	CUSTOMER_ID INT

);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (1,'02.02.16',2000,2);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (2,'02.02.19', 8000,2);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (3,'12.12.20', 9000,1);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (4,'12.02.20',2000,4);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (1,'02.12.16',5000,2);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (2,'02.02.19', 4000,2);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (3,'12.02.20', 9000,1);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (4,'12.02.20',7000,4);

INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (3,'12.10.10', 9000,1);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (4,'12.02.20',6000,6);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (1,'02.12.06',8000,3);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (2,'02.02.19', 8000,5);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (3,'12.12.20', 9000,2);
INSERT INTO ORDERS  (ID, DATE, AMOUNT, CUSTOMER_ID) VALUES (4,'02.02.21',7000,5);


select (c.name)customers_name, (m.name)manager_name
FROM customers c
JOIN MANAGER m
On m.id = c.MANAGER_ID
where c.id in (
		select CUSTOMER_ID
		from ORDERS 
			group by CUSTOMER_ID
			having sum(amount)>10000)
	AND
	c.id in (
		select CUSTOMER_ID
		from ORDERS 
			where datediff (day,'01.01.13',date)>=0);
