USE [uybus]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conductor]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conductor](
	[Id] [int] NOT NULL,
	[VencimientoLicencia] [date] NOT NULL,
 CONSTRAINT [PK_Conductor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Linea]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linea](
	[IdLinea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Linea] PRIMARY KEY CLUSTERED 
(
	[IdLinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Llegada]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Llegada](
	[idParada] [int] NOT NULL,
	[idViaje] [int] NOT NULL,
	[hora] [time](7) NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Llegada] PRIMARY KEY CLUSTERED 
(
	[idParada] ASC,
	[idViaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parada]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parada](
	[IdParada] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Lat] [float] NOT NULL,
	[Long] [float] NOT NULL,
 CONSTRAINT [PK_Parada] PRIMARY KEY CLUSTERED 
(
	[IdParada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametro]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametro](
	[IdParametro] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [int] NOT NULL,
 CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED 
(
	[IdParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasaje]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasaje](
	[IdPasaje] [int] IDENTITY(1,1) NOT NULL,
	[Asientos] [int] NULL,
	[Documento] [varchar](50) NOT NULL,
	[TipoDocuemtno] [varchar](50) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdViaje] [int] NOT NULL,
	[IdParadaDestino] [int] NOT NULL,
	[IdParadaOrigen] [int] NOT NULL,
 CONSTRAINT [PK_Pasaje] PRIMARY KEY CLUSTERED 
(
	[IdPasaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[TipoDocumento] [int] NOT NULL,
	[pNombre] [varchar](50) NOT NULL,
	[sNombre] [varchar](50) NULL,
	[pApellido] [varchar](50) NOT NULL,
	[sApellido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Precio]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precio](
	[IdPrecio] [int] IDENTITY(1,1) NOT NULL,
	[Precio] [int] NOT NULL,
	[FechaEntradaVigencia] [date] NOT NULL,
	[IdLinea] [int] NOT NULL,
	[IdParada] [int] NOT NULL,
 CONSTRAINT [PK_Precio] PRIMARY KEY CLUSTERED 
(
	[IdPrecio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salida]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salida](
	[IdSalida] [int] IDENTITY(1,1) NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[IdConductor] [int] NOT NULL,
	[IdVehiculo] [varchar](50) NOT NULL,
	[IdLinea] [int] NOT NULL,
 CONSTRAINT [PK_Salida] PRIMARY KEY CLUSTERED 
(
	[IdSalida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuperAdmin]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperAdmin](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_SuperAdmin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tramo]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tramo](
	[IdLinea] [int] NOT NULL,
	[IdParada] [int] NOT NULL,
	[TiempoEstimado] [int] NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_Tramo] PRIMARY KEY CLUSTERED 
(
	[IdLinea] ASC,
	[IdParada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Matricula] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[CantAsientos] [int] NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viaje]    Script Date: 16/10/2020 23:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viaje](
	[IdViaje] [int] IDENTITY(1,1) NOT NULL,
	[Finalizado] [tinyint] NULL,
	[Fecha] [date] NOT NULL,
	[HoraInicioReal] [time](7) NULL,
	[IdSalida] [int] NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[IdViaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Persona] FOREIGN KEY([Id])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Admin] CHECK CONSTRAINT [FK_Admin_Persona]
GO
ALTER TABLE [dbo].[Conductor]  WITH CHECK ADD  CONSTRAINT [FK_Conductor_Persona] FOREIGN KEY([Id])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Conductor] CHECK CONSTRAINT [FK_Conductor_Persona]
GO
ALTER TABLE [dbo].[Llegada]  WITH CHECK ADD  CONSTRAINT [FK_Llegada_Parada] FOREIGN KEY([idParada])
REFERENCES [dbo].[Parada] ([IdParada])
GO
ALTER TABLE [dbo].[Llegada] CHECK CONSTRAINT [FK_Llegada_Parada]
GO
ALTER TABLE [dbo].[Llegada]  WITH CHECK ADD  CONSTRAINT [FK_Llegada_Viaje] FOREIGN KEY([idViaje])
REFERENCES [dbo].[Viaje] ([IdViaje])
GO
ALTER TABLE [dbo].[Llegada] CHECK CONSTRAINT [FK_Llegada_Viaje]
GO
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Parada] FOREIGN KEY([IdParadaOrigen])
REFERENCES [dbo].[Parada] ([IdParada])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Parada]
GO
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Parada1] FOREIGN KEY([IdParadaDestino])
REFERENCES [dbo].[Parada] ([IdParada])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Parada1]
GO
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Usuario]
GO
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Viaje] FOREIGN KEY([IdViaje])
REFERENCES [dbo].[Viaje] ([IdViaje])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Viaje]
GO
ALTER TABLE [dbo].[Precio]  WITH CHECK ADD  CONSTRAINT [FK_Precio_Tramo] FOREIGN KEY([IdLinea], [IdParada])
REFERENCES [dbo].[Tramo] ([IdLinea], [IdParada])
GO
ALTER TABLE [dbo].[Precio] CHECK CONSTRAINT [FK_Precio_Tramo]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Conductor] FOREIGN KEY([IdConductor])
REFERENCES [dbo].[Conductor] ([Id])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Conductor]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Linea] FOREIGN KEY([IdLinea])
REFERENCES [dbo].[Linea] ([IdLinea])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Linea]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Vehiculo] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculo] ([Matricula])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Vehiculo]
GO
ALTER TABLE [dbo].[SuperAdmin]  WITH CHECK ADD  CONSTRAINT [FK_SuperAdmin_Persona] FOREIGN KEY([Id])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[SuperAdmin] CHECK CONSTRAINT [FK_SuperAdmin_Persona]
GO
ALTER TABLE [dbo].[Tramo]  WITH CHECK ADD  CONSTRAINT [FK_Tramo_Linea] FOREIGN KEY([IdLinea])
REFERENCES [dbo].[Linea] ([IdLinea])
GO
ALTER TABLE [dbo].[Tramo] CHECK CONSTRAINT [FK_Tramo_Linea]
GO
ALTER TABLE [dbo].[Tramo]  WITH CHECK ADD  CONSTRAINT [FK_Tramo_Parada] FOREIGN KEY([IdParada])
REFERENCES [dbo].[Parada] ([IdParada])
GO
ALTER TABLE [dbo].[Tramo] CHECK CONSTRAINT [FK_Tramo_Parada]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([Id])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Salida] FOREIGN KEY([IdSalida])
REFERENCES [dbo].[Salida] ([IdSalida])
GO
ALTER TABLE [dbo].[Viaje] CHECK CONSTRAINT [FK_Viaje_Salida]
GO
