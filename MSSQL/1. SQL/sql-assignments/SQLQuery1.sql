-- SUPPLIER Table

create table SUPPLIER
(
	SNO char(2) PRIMARY KEY,
	SNAME varchar(20),
	STATUS int,
	CITY varchar(20)
)
select * from SUPPLIER

INSERT INTO SUPPLIER (SNO, SNAME, STATUS, CITY) VALUES
('s1', 'Smith',  20,   'London'), 
('s2', 'Jones',  10,   'Paris'), 
('s3', 'Blakes', 30,   'Paris'), 
('s4', 'Clark',  20,   'London'), 
('s5', 'Adams',  30,   'Athens'), 
('s6', 'Oh',     NULL, 'Seattle'), 
('s7', 'Fidel',  NULL, 'Seattle'), 
('s8', 'Carlyle',NULL, 'Seattle');


-- PART Table

create table PART
(
	PNO char(2) PRIMARY KEY,
	PNAME varchar(20),
	COLOR varchar(20),
	WEIGHT int,
	CITY varchar(20)
)
SELECT * FROM PART

INSERT INTO PART (PNO, PNAME, COLOR,WEIGHT, CITY) VALUES
('p1', 'Nut',   'Red',   12,   'London'), 
('p2', 'Bolt',  'Green', 17,   'Paris'), 
('p3', 'Screw', 'Blue',  17,   'Rome'), 
('p4', 'Screw', 'Red',   14,   'London'), 
('p5', 'Cam',   'Blue',  12,   'Paris'), 
('p6', 'Cog',   'Red',   19,   'London');



-- SUPP_PART Table

create table SUPP_PART
(
	SNO char(2),
	PNO char(2),
	QTY int,
	FOREIGN KEY (SNO) REFERENCES SUPPLIER (SNO),
	FOREIGN KEY (PNO) REFERENCES PART (PNO)
);
SELECT * FROM SUPP_PART

INSERT INTO SUPP_PART (SNO, PNO, QTY) VALUES
('s1', 'p1',  300), 
('s1', 'p2',  200), 
('s1', 'p3',  400), 
('s1', 'p4',  200), 
('s1', 'p5',  100), 
('s1', 'p6',  100),
('s2', 'p1',  300), 
('s2', 'p2',  400), 
('s3', 'p2',  200), 
('s4', 'p2',  200), 
('s4', 'p4',  300), 
('s4', 'p5',  400);



--Q1. Get supplier numbers and status for suppliers in Paris.

SELECT SNO, STATUS FROM SUPPLIER  WHERE CITY = 'Paris';

--Q2. Get part numbers for all parts supplied.

SELECT PNO FROM SUPP_PART

--Q3. Get distinct part numbers for all parts supplied.

SELECT DISTINCT PNO FROM SUPP_PART;

--Q4. Get full details of all suppliers.

SELECT * FROM SUPPLIER;

-- Q5. For all parts, get the part number and the weight of that part in grams (part weights are given in pounds in the table PART). 1 pound is 454 grams.

SELECT PNO, WEIGHT ,(WEIGHT * 454) AS [Weight - in - Grams] FROM PART

-- Q6: Get supplier numbers for suppliers in Paris with status > 20.

SELECT SNO FROM SUPPLIER WHERE CITY='Paris' AND STATUS > 20


-- Q7: Get supplier numbers and status for suppliers in Paris in descending order of status.

SELECT SNO, STATUS FROM SUPPLIER WHERE CITY = 'Paris' ORDER BY STATUS DESC


-- Q8. Get supplier numbers for suppliers with no status.

SELECT SNO FROM SUPPLIER WHERE STATUS IS NULL

-- Q9: Get all combinations of supplier information and part information where the supplier and part concerned are co-located in the same city.

	
	SELECT * FROM SUPPLIER AS S
	JOIN PART AS P
	ON (S.CITY = P.CITY)
	--WHERE STATUS!=20
	--ORDER BY SNO;
	ORDER BY SNO,PNO DESC;



-- Q10: Get all combinations of supplier information and part information where the supplier and part concerned are co-located, but omitting suppliers with status 20.

SELECT * FROM SUPPLIER AS S
	JOIN PART AS P
	ON (S.CITY = P.CITY)
	WHERE STATUS!=20
	ORDER BY SNO;
-- Q13: Get the total number of suppliers.

SELECT COUNT(SNO) AS CountOfSNO FROM SUPPLIER

-- Q14: Get the number of shipments for part p2.

SELECT COUNT(PNO) AS CountOfPNO from SUPP_PART WHERE PNO ='P2'

-- Q15: Get the total quantity of part p2 supplied.

SELECT SUM(QTY) AS SumOfQTY FROM SUPP_PART WHERE PNO = 'P2'

-- Q16: For each part supplied, get the part number and the total shipment quantity for that part.

SELECT PNO, SUM(QTY) AS SumOfQTY FROM SUPP_PART GROUP BY PNO

-- Q17: Get part numbers for all parts supplied by more than one supplier.

SELECT PNO FROM SUPP_PART GROUP BY PNO HAVING COUNT(DISTINCT SNO)>1

-- Q18: Get all parts whose names begin with the letter C.

SELECT PNAME FROM PART WHERE PNAME LIKE 'C%' 