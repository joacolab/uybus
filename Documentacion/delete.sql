BEGIN TRAN t;
    DELETE FROM llegada;
    DELETE FROM pasaje;
	DELETE FROM viaje;
	DELETE FROM salida;
	DELETE FROM precio;
	DELETE FROM tramo;
	DELETE FROM vehiculo;
	DELETE FROM parametro;
	DELETE FROM parada;
	DELETE FROM linea;
	DELETE FROM superadmin;
	DELETE FROM conductor;
	DELETE FROM usuario;
	DELETE FROM admin;
	DELETE FROM persona;
	DELETE FROM pasaje;
	DELETE FROM llegada;
COMMIT TRAN t;

--
-- Reinicio de contadores para ID incrementales
--
BEGIN TRAN t;
    	DBCC CHECKIDENT ('viaje', RESEED, 0);
	DBCC CHECKIDENT ('salida', RESEED, 0);
	DBCC CHECKIDENT ('precio', RESEED, 0);
	DBCC CHECKIDENT ('parametro', RESEED, 0);
	DBCC CHECKIDENT ('parada', RESEED, 0);
	DBCC CHECKIDENT ('linea', RESEED, 0);
	DBCC CHECKIDENT ('persona', RESEED, 0);
	DBCC CHECKIDENT ('pasaje', RESEED, 0);
COMMIT TRAN t;