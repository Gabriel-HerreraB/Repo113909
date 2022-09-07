CREATE DATABASE Ejercicio2_113909
GO
USE Ejercicio2_113909
GO

SET DATEFORMAT DMY
CREATE TABLE FORMAS_PAGO(
cod_FormaPago int identity (1,1),
nombre varchar(30)
CONSTRAINT PK_FORMA_PAGO PRIMARY KEY (cod_FormaPago)
)

CREATE TABLE ARTICULOS(
cod_articulo int identity (1,1),
nombre varchar(50),
pre_unitario decimal,
estado bit
CONSTRAINT PK_ARTICULOS PRIMARY KEY (cod_articulo)
)

CREATE TABLE FACTURAS(
nro_factura int identity (1,1),
fecha datetime not null,
forma_pago int,
cliente varchar (50),
estado bit,
total decimal
CONSTRAINT PK_FACTURAS PRIMARY KEY (nro_factura),
CONSTRAINT FK_FACTURAS_FORMASPAGO FOREIGN KEY (forma_pago)
REFERENCES FORMAS_PAGO (cod_FormaPago)
)

CREATE TABLE DETALLES_FACTURA(
cod_detalle int identity (1,1),
factura int,
articulo int,
cantidad int,
CONSTRAINT PK_DETALLES_FACTURAS PRIMARY KEY (cod_detalle),
CONSTRAINT FK_DETALLES_FACTURAS FOREIGN KEY (factura)
REFERENCES FACTURAS (nro_factura),
CONSTRAINT FK_DETALLES_ARTICULOS FOREIGN KEY (articulo)
REFERENCES ARTICULOS (cod_articulo)
)

INSERT INTO FORMAS_PAGO VALUES ('Efectivo')
INSERT INTO FORMAS_PAGO VALUES ('Tarjeta Débito')
INSERT INTO FORMAS_PAGO VALUES ('Tarjeta Credito')
INSERT INTO FORMAS_PAGO VALUES ('Transferencia')

INSERT INTO ARTICULOS VALUES ('Agua', 100, 'true')
INSERT INTO ARTICULOS VALUES ('CocaCola', 230, 'true')
INSERT INTO ARTICULOS VALUES ('Pepsi', 180, 'true')
INSERT INTO ARTICULOS VALUES ('Pritty', 180, 'true')
INSERT INTO ARTICULOS VALUES ('Agua saborizada', 150, 'true')
INSERT INTO ARTICULOS VALUES ('Agua del pico', 150, 'false')

INSERT INTO FACTURAS VALUES ('18/8/2022', 1, 'Juan Anibal', 'true', 100)
INSERT INTO FACTURAS VALUES ('13/2/2022', 2, 'Armando Paredes', 'true', 150)
INSERT INTO FACTURAS VALUES ('3/3/2022', 3, 'Armando Casas', 'true', 200)
INSERT INTO FACTURAS VALUES ('18/8/2022', 4, 'Estaban Quito', 'true',321)
INSERT INTO FACTURAS VALUES ('9/9/2022', 4, 'Carlos Jimenes', 'true',1561)
INSERT INTO FACTURAS VALUES ('11/8/2022', 1, 'Nicky Nicole', 'true',165156)
INSERT INTO FACTURAS VALUES ('16/8/2022', 2, 'Maria Becerra', 'true',1515)
INSERT INTO FACTURAS VALUES ('17/7/2022', 2, 'Mara Dona', 'true',151)
INSERT INTO FACTURAS VALUES ('15/5/2022', 3, 'Armando Puentes', 'true',1561)
INSERT INTO FACTURAS VALUES ('13/8/2022', 1, 'Juan Juan', 'true',1651)
INSERT INTO FACTURAS VALUES ('18/8/2022', 3, 'Juan Gabriel', 'true',1351)

INSERT INTO DETALLES_FACTURA VALUES (1,2,3)
INSERT INTO DETALLES_FACTURA VALUES (2,4,2)
INSERT INTO DETALLES_FACTURA VALUES (3,2,1)
INSERT INTO DETALLES_FACTURA VALUES (4,4,3)
INSERT INTO DETALLES_FACTURA VALUES (5,3,6)
INSERT INTO DETALLES_FACTURA VALUES (6,3,6)
INSERT INTO DETALLES_FACTURA VALUES (7,1,4)
INSERT INTO DETALLES_FACTURA VALUES (8,2,2)
INSERT INTO DETALLES_FACTURA VALUES (9,1,7)
INSERT INTO DETALLES_FACTURA VALUES (10,1,6)
INSERT INTO DETALLES_FACTURA VALUES (11,2,13)
INSERT INTO DETALLES_FACTURA VALUES (11,4,3)


CREATE PROC SP_CARGAR_FORMA_PAGO
AS SELECT * FROM FORMAS_PAGO

Create PROC SP_CARGAR_ARTICULO
AS SELECT * FROM ARTICULOS where estado != 'false'


Create Proc SP_PROXIMA_FACTURA
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(nro_factura)+1  FROM FACTURAS);
END

Create PROCEDURE SP_INSERTAR_FACTURA
	@cliente varchar(255), 
	@total decimal,
	@forma_pago int,
	@factura_nro int OUTPUT
AS
BEGIN
	INSERT INTO FACTURAS(fecha, cliente, forma_pago, total,estado)
    VALUES (GETDATE(), @cliente, @forma_pago,  @total,'true');
    SET @factura_nro = SCOPE_IDENTITY();
END


Create PROCEDURE SP_INSERTAR_DETALLE
	@factura_nro int,
	--@detalle int, 
	@id_articulo int, 
	@cantidad int
AS
BEGIN
	INSERT INTO DETALLES_FACTURA(factura, articulo, cantidad)
    VALUES (@factura_nro, @id_articulo, @cantidad)
	--set @detalle = SCOPE_IDENTITY();
END

Create PROCEDURE SP_CARGAR_FACTURAS
AS select nro_factura  from FACTURAS where estado = 'true'

CREATE PROC SP_CARGAR_BAJA
@nro_factura int
AS SELECT fecha, cliente, cod_articulo, nombre, cantidad, pre_unitario
FROM DETALLES_FACTURA DF JOIN FACTURAS F ON DF.factura = F.nro_factura join ARTICULOS a on df.articulo = a.cod_articulo
where @nro_factura = nro_factura

CREATE PROC SP_EJECUTAR_BAJA
@nro int
as update FACTURAS set estado = 'false' where nro_factura = @nro

Create proc SP_DataSet
@desde datetime,
@hasta datetime
as select nombre Articulo, sum(cantidad) Cantidad
from  DETALLES_FACTURA df join ARTICULOS a on df.articulo = a.cod_articulo join FACTURAS f on f.nro_factura = df.factura
where fecha between @desde and @hasta 
group by nombre