insert into persona VALUES ('45634766','admin@gmail.com','1234',1,'Juan','Pedro','Alvarez','Suarez'); 

insert into persona VALUES ('95614576','pedro@gmail.com','1234',1,'Pedor','Mario','Fransisco','Herrera'); 
insert into persona VALUES ('56615766','mario@gmail.com','1234',1,'Mario','Pedro','Alvarez','Hernandez'); 
insert into persona VALUES ('78665766','marcelo@gmail.com','1234',1,'Marcelo','Maria','Michely','Gonzalez'); 
insert into persona VALUES ('56257665','ricardo@gmail.com','1234',1,'Ricardo','Pedro','Rocha','Rodriguez'); 
insert into persona VALUES ('54653576','hernesto@gmail.com','1234',1,'Hernesto','Luciana','Arrieta','Tussy');
 
insert into persona VALUES ('43653766','ConductorGuille@gmail.com','1234',1,'Guillermina','Maria','Michely','Gonzalez'); 
insert into persona VALUES ('21315766','ConductorAlma@gmail.com','1234',1,'Alma','Estefania','Rocha','Rodriguez'); 

insert into persona VALUES ('34315766','superAdmin@gmail.com','1234',1,'Marcela','Luciana','Murillo','Bussy'); 

insert into admin VALUES (1);

insert into usuario VALUES (2);
insert into usuario VALUES (3);
insert into usuario VALUES (4);
insert into usuario VALUES (5);
insert into usuario VALUES (6);

insert into conductor VALUES (7, '2021-01-01');
insert into conductor VALUES (8, '2021-01-01');

insert into superadmin VALUES (9);

insert into linea VALUES ('SanJoseMontevideo');
insert into linea VALUES ('MontevideoSanJose');
insert into linea VALUES ('SanJoseMontevideoPorCanelones');
insert into linea VALUES ('MontevideoSanJosePorCanelones');

insert into parada VALUES ('TerminalSanJose',-34.333592, -56.7155999);
insert into parada VALUES ('PuntaValdez',-34.585873, -56.700948);
insert into parada VALUES ('Libertad',-34.639545, -56.617723);
insert into parada VALUES ('PlazaCuba',-34.872245, -56.202655);
insert into parada VALUES ('TresCruces',-34.893905, -56.167064);

insert into parada VALUES ('Rodriguez',-34.395239, -56.548601);
insert into parada VALUES ('SantaLucia',-34.458694, -56.383053);
insert into parada VALUES ('Canelones',-34.524248, -56.287812);
insert into parada VALUES ('LasPiedras',-34.708392, -56.216555);

insert into parametro VALUES (60);
insert into parametro VALUES (70);
insert into parametro VALUES (80);

insert into vehiculo VALUES('SAF3465','Campione Invictus 1200','Comil', 40); 
insert into vehiculo VALUES('SAB5465','Sbelto Doppio 1202','Comil', 42);
insert into vehiculo VALUES('MAT6548','Campione Invictus 1200','Comil', 40);
insert into vehiculo VALUES('MAU7645','Sbelto Doppio 1202','Comil', 42);

insert into tramo VALUES(1, 1, 0);
insert into tramo VALUES(1, 2, 1300);
insert into tramo VALUES(1, 3, 1300);
insert into tramo VALUES(1, 4, 1300);
insert into tramo VALUES(1, 5, 1300);

insert into tramo VALUES(2, 5, 0);
insert into tramo VALUES(2, 4, 1300);
insert into tramo VALUES(2, 3, 1300);
insert into tramo VALUES(2, 2, 1300);
insert into tramo VALUES(2, 1, 1300);

insert into tramo VALUES(3, 1, 0);
insert into tramo VALUES(3, 6, 1300);
insert into tramo VALUES(3, 7, 1300);
insert into tramo VALUES(3, 8, 1300);
insert into tramo VALUES(3, 9, 1300);
insert into tramo VALUES(3, 5, 1300);

insert into tramo VALUES(4, 5, 0);
insert into tramo VALUES(4, 9, 1300);
insert into tramo VALUES(4, 8, 1300);
insert into tramo VALUES(4, 7, 1300);
insert into tramo VALUES(4, 6, 1300);
insert into tramo VALUES(4, 1, 1300);

insert into precio VALUES(41, '2018-01-01', 1, 1);
insert into precio VALUES(43, '2019-01-01', 1, 1);

insert into precio VALUES(41, '2018-01-01', 1, 2);
insert into precio VALUES(43, '2019-01-01', 1, 2);

insert into precio VALUES(41, '2018-01-01', 1, 3);
insert into precio VALUES(43, '2019-01-01', 1, 3);

insert into precio VALUES(41, '2018-01-01', 1, 4);
insert into precio VALUES(43, '2019-01-01', 1, 4);

insert into precio VALUES(41, '2018-01-01', 1, 5);
insert into precio VALUES(43, '2019-01-01', 1, 5);


insert into precio VALUES(40, '2018-01-01', 2, 5);
insert into precio VALUES(40, '2018-01-01', 2, 4);
insert into precio VALUES(40, '2018-01-01', 2, 3);
insert into precio VALUES(40, '2018-01-01', 2, 2);
insert into precio VALUES(40, '2018-01-01', 2, 1);

insert into precio VALUES(38, '2019-01-01', 3, 1);
insert into precio VALUES(38, '2019-01-01', 3, 6);
insert into precio VALUES(38, '2019-01-01', 3, 7);
insert into precio VALUES(38, '2019-01-01', 3, 8);
insert into precio VALUES(38, '2019-01-01', 3, 9);
insert into precio VALUES(38, '2019-01-01', 3, 5);

insert into precio VALUES(38, '2019-01-01', 4, 5);
insert into precio VALUES(38, '2019-01-01', 4, 9);
insert into precio VALUES(38, '2019-01-01', 4, 8);
insert into precio VALUES(38, '2019-01-01', 4, 7);
insert into precio VALUES(38, '2019-01-01', 4, 6);
insert into precio VALUES(38, '2019-01-01', 4, 1);

insert into salida VALUES ('08:00:00.000', 7, 'SAF3465', 1);
insert into salida VALUES ('10:00:00.000', 8, 'SAB5465', 1);

insert into salida VALUES ('10:00:00.000', 7, 'SAF3465', 2);
insert into salida VALUES ('12:00:00.000', 8, 'SAB5465', 2);  

insert into salida VALUES ('11:00:00.000', 7, 'MAT6548', 3);
insert into salida VALUES ('13:00:00.000', 8, 'MAU7645', 3);

insert into salida VALUES ('13:00:00.000', 7, 'MAT6548', 4);
insert into salida VALUES ('15:00:00.000', 8, 'MAU7645', 4);


insert into salida VALUES ('14:00:00.000', 7, 'SAF3465', 1);
insert into salida VALUES ('16:00:00.000', 8, 'SAB5465', 1);

insert into salida VALUES ('16:00:00.000', 7, 'SAF3465', 2);
insert into salida VALUES ('18:00:00.000', 8, 'SAB5465', 2);


insert into salida VALUES ('17:00:00.000', 7, 'MAT6548', 3);
insert into salida VALUES ('19:00:00.000', 8, 'MAU7645', 3);

insert into salida VALUES ('19:00:00.000', 7, 'MAT6548', 4);
insert into salida VALUES ('22:00:00.000', 8, 'MAU7645', 4);

insert into viaje VALUES(0, '2020-12-03', NULL , 1); 
insert into viaje VALUES(0, '2020-12-03', NULL , 2);
insert into viaje VALUES(0, '2020-12-03', NULL , 3);
insert into viaje VALUES(0, '2020-12-03', NULL , 4);
insert into viaje VALUES(0, '2020-12-03', NULL , 5);
insert into viaje VALUES(0, '2020-12-03', NULL , 6);
insert into viaje VALUES(0, '2020-12-03', NULL , 7);
insert into viaje VALUES(0, '2020-12-03', NULL , 8);
insert into viaje VALUES(0, '2020-12-03', NULL , 9);
insert into viaje VALUES(0, '2020-12-03', NULL , 10);
insert into viaje VALUES(0, '2020-12-03', NULL , 11);
insert into viaje VALUES(0, '2020-12-03', NULL , 12);
insert into viaje VALUES(0, '2020-12-03', NULL , 13);
insert into viaje VALUES(0, '2020-12-03', NULL , 14);
insert into viaje VALUES(0, '2020-12-03', NULL , 15);
insert into viaje VALUES(0, '2020-12-03', NULL , 16);

insert into pasaje VALUES(1, '95614576','CI', 2, 1, 5, 1);
insert into pasaje VALUES(2, '56615766','CI', 3, 1, 5, 1);
insert into pasaje VALUES(3, '78665766','CI', 4, 1, 5, 1);
insert into pasaje VALUES(4, '56257665','CI', 5, 1, 4, 1);
insert into pasaje VALUES(5, '54653576','CI', 6, 1, 4, 1);

insert into pasaje VALUES(6, '34553576','CI', NULL, 1, 5, 1);
insert into pasaje VALUES(7, '76553576','CI', NULL, 1, 5, 1);
insert into pasaje VALUES(8, '25535746','CI', NULL, 1, 5, 1);
insert into pasaje VALUES(9, '88853576','CI', NULL, 1, 5, 1);
insert into pasaje VALUES(10, '98753576','CI', NULL, 1, 5, 1);
insert into pasaje VALUES(11, '70553576','CI', NULL, 1, 5, 1);
insert into pasaje VALUES(12, '45553576','CI', NULL, 1, 5, 1);

insert into pasaje VALUES(NULL, '45553576','CI', NULL, 1, 2, 1);
insert into pasaje VALUES(NULL, '65453576','CI', NULL, 1, 2, 1);
insert into pasaje VALUES(NULL, '65453576','CI', NULL, 1, 2, 1);
insert into pasaje VALUES(NULL, '87643576','CI', NULL, 1, 2, 1);