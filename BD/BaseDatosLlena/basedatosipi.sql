-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-11-2021 a las 18:29:50
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `basedatosipi`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tblasignacionproducto`
--

CREATE TABLE `tblasignacionproducto` (
  `idasignacion` int(11) NOT NULL,
  `idproducto` int(11) NOT NULL,
  `nombreproducto` varchar(60) NOT NULL,
  `idservicio` int(11) NOT NULL,
  `precioventa` double NOT NULL,
  `cantidad` int(11) NOT NULL,
  `total` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tblasignacionproducto`
--

INSERT INTO `tblasignacionproducto` (`idasignacion`, `idproducto`, `nombreproducto`, `idservicio`, `precioventa`, `cantidad`, `total`) VALUES
(51, 3, 'DIM Ram 2GB', 4, 200, 2, 400),
(52, 1, 'Teclado', 5, 90, 1, 90),
(53, 2, 'Mouse Pad', 5, 6, 1, 6),
(54, 4, 'Ventilador para Laptop', 5, 90, 1, 90);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tblcliente`
--

CREATE TABLE `tblcliente` (
  `idcliente` int(11) NOT NULL,
  `nombres` varchar(40) NOT NULL,
  `apellidos` varchar(40) NOT NULL,
  `direccion` varchar(60) NOT NULL,
  `telefonocasa` int(11) NOT NULL,
  `telefonocelular` int(11) NOT NULL,
  `correoelectronico` varchar(60) NOT NULL,
  `nit` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tblcliente`
--

INSERT INTO `tblcliente` (`idcliente`, `nombres`, `apellidos`, `direccion`, `telefonocasa`, `telefonocelular`, `correoelectronico`, `nit`) VALUES
(1, 'Carlos Efrain', 'Reyes Escobar', 'Condominio las margaritas 12-45 zona 2', 78945632, 77889955, 'carlosreyes@hotmail.com', '1234567-8'),
(2, 'Amarilis Maringue', 'Zoe Bamaca', 'Avenida Jesus Castillo 12-34 Zona 2', 12345678, 69584745, 'amariliszoe@gmail.com', '1234678-9');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tblequipo`
--

CREATE TABLE `tblequipo` (
  `idequipo` int(11) NOT NULL,
  `marca` varchar(60) NOT NULL,
  `modelo` varchar(60) NOT NULL,
  `serie` varchar(60) NOT NULL,
  `accesorios` varchar(500) NOT NULL,
  `observaciones` varchar(500) NOT NULL,
  `idcliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tblequipo`
--

INSERT INTO `tblequipo` (`idequipo`, `marca`, `modelo`, `serie`, `accesorios`, `observaciones`, `idcliente`) VALUES
(1, 'Toshiba', '78945-8', '123456789', 'Teclado, bocinas y cargador.', 'Viene muy sucia, dice que no enciende y la pantalla no tira señal.', 2),
(2, 'Sharp', 'S345', '789465', 'Ninguno', 'Enciende, pero cuando se esta usando se queda congelada.', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tblproducto`
--

CREATE TABLE `tblproducto` (
  `idproducto` int(11) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `descripcion` varchar(60) NOT NULL,
  `marca` varchar(50) NOT NULL,
  `modelo` varchar(50) NOT NULL,
  `serie` varchar(60) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `pcosto` double NOT NULL,
  `pventa` double NOT NULL,
  `idproveedor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tblproducto`
--

INSERT INTO `tblproducto` (`idproducto`, `nombre`, `descripcion`, `marca`, `modelo`, `serie`, `cantidad`, `pcosto`, `pventa`, `idproveedor`) VALUES
(1, 'Teclado', 'Color negro, con 233 teclas edicion Avengers, con luces de n', 'Genius', 'RGT-4', '122345', 7, 78.5, 90, 1),
(2, 'Mouse Pad', 'Mouse Pad de color negro que ayuda a sostener la muñeca.', 'RLIP Extreme', '23', '798456', 9, 5.25, 6, 1),
(3, 'DIM Ram 2GB', 'DIM de memoria RAM de 2 GB', 'Kingstone', 'DIM 2', '789465', 6, 175, 200, 1),
(4, 'Ventilador para Laptop', 'Ventilador de color negro base, de conexion USB.', 'Tomeb', '45-8', '7895', 1, 75, 90, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tblproveedor`
--

CREATE TABLE `tblproveedor` (
  `idproveedor` int(11) NOT NULL,
  `nombre` varchar(40) NOT NULL,
  `nombreencargado` varchar(60) NOT NULL,
  `direccion` varchar(60) NOT NULL,
  `telefonooficina` int(11) NOT NULL,
  `telefonocelular` int(11) NOT NULL,
  `correoelectronico` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tblproveedor`
--

INSERT INTO `tblproveedor` (`idproveedor`, `nombre`, `nombreencargado`, `direccion`, `telefonooficina`, `telefonocelular`, `correoelectronico`) VALUES
(1, 'Computek S.A.', 'Sergio Armando Cajas Mejia', '2da Calle 7-11A Zona 1', 77658989, 59457825, 'cajasmejia@computeksa.com.gt');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tblservicio`
--

CREATE TABLE `tblservicio` (
  `idservicio` int(11) NOT NULL,
  `idcliente` int(11) NOT NULL,
  `idequipo` int(11) NOT NULL,
  `falla` varchar(500) NOT NULL,
  `reparacion` varchar(500) NOT NULL,
  `fechaentrada` date NOT NULL,
  `fechasalida` date NOT NULL,
  `fechaprogramada` date NOT NULL,
  `idtecnico` int(11) NOT NULL,
  `pago` double NOT NULL,
  `saldo` double NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tblservicio`
--

INSERT INTO `tblservicio` (`idservicio`, `idcliente`, `idequipo`, `falla`, `reparacion`, `fechaentrada`, `fechasalida`, `fechaprogramada`, `idtecnico`, `pago`, `saldo`, `total`, `estado`) VALUES
(1, 1, 1, 'No enciende el equipo.', 'Revision y limpieza.', '2021-10-23', '2021-11-05', '2021-12-30', 1, 10, 90, 100, 'Pendiente'),
(2, 2, 2, 'No enciende, esta muy sucia y no tiene definidos los nombres de los controles del panel frontal', 'Se va revisar y realizar una limpiza.', '2021-11-02', '2021-11-25', '2021-12-30', 2, 25, 475, 500, 'Pendiente'),
(3, 2, 1, 'Computadora viene para ser formateada  y que se le instale nuevo sistema operativo.', 'Se le va instalar Windows 7.', '2021-11-03', '2021-11-10', '2021-11-24', 1, 1500, 0, 1500, 'Entregado'),
(4, 1, 2, 'Necesita mas memoria ram, funciona muy lento', 'Limpieza e instalacion de mas memoria ram', '2021-11-03', '2021-11-05', '2021-12-31', 1, 50, 100, 550, 'Pendiente'),
(5, 1, 1, 'Se le instalaran nuevos insumos', 'Instalacion', '2021-11-03', '2021-11-04', '2021-11-24', 1, 86, 100, 186, 'Pendiente');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbltecnico`
--

CREATE TABLE `tbltecnico` (
  `idtecnico` int(11) NOT NULL,
  `nombres` varchar(40) NOT NULL,
  `apellidos` varchar(40) NOT NULL,
  `direccion` varchar(60) NOT NULL,
  `telefonocasa` int(11) NOT NULL,
  `telefonocelular` int(11) NOT NULL,
  `correoelectronico` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tbltecnico`
--

INSERT INTO `tbltecnico` (`idtecnico`, `nombres`, `apellidos`, `direccion`, `telefonocasa`, `telefonocelular`, `correoelectronico`) VALUES
(1, 'Jorge Antonio', 'Rojas Chavez', '11 Calle 6-78 Zona 3', 12345689, 56498732, 'jorgerojas@educatek.com.gt'),
(2, 'Gabriel', 'Sam', '6ta Calle 7-89 Zona 2.', 12345685, 85214796, 'samsam@compumundo.com.gt');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tblasignacionproducto`
--
ALTER TABLE `tblasignacionproducto`
  ADD PRIMARY KEY (`idasignacion`),
  ADD KEY `relacionProducto` (`idproducto`),
  ADD KEY `relacionServicio` (`idservicio`);

--
-- Indices de la tabla `tblcliente`
--
ALTER TABLE `tblcliente`
  ADD PRIMARY KEY (`idcliente`);

--
-- Indices de la tabla `tblequipo`
--
ALTER TABLE `tblequipo`
  ADD PRIMARY KEY (`idequipo`),
  ADD KEY `relacionCliente` (`idcliente`);

--
-- Indices de la tabla `tblproducto`
--
ALTER TABLE `tblproducto`
  ADD PRIMARY KEY (`idproducto`),
  ADD KEY `relacionProveedor` (`idproveedor`);

--
-- Indices de la tabla `tblproveedor`
--
ALTER TABLE `tblproveedor`
  ADD PRIMARY KEY (`idproveedor`);

--
-- Indices de la tabla `tblservicio`
--
ALTER TABLE `tblservicio`
  ADD PRIMARY KEY (`idservicio`),
  ADD KEY `relacionServicioCliente` (`idcliente`),
  ADD KEY `relacionServicioEquipo` (`idequipo`),
  ADD KEY `relacionServicioTecnico` (`idtecnico`);

--
-- Indices de la tabla `tbltecnico`
--
ALTER TABLE `tbltecnico`
  ADD PRIMARY KEY (`idtecnico`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tblasignacionproducto`
--
ALTER TABLE `tblasignacionproducto`
  MODIFY `idasignacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tblasignacionproducto`
--
ALTER TABLE `tblasignacionproducto`
  ADD CONSTRAINT `relacionProducto` FOREIGN KEY (`idproducto`) REFERENCES `tblproducto` (`idproducto`),
  ADD CONSTRAINT `relacionServicio` FOREIGN KEY (`idservicio`) REFERENCES `tblservicio` (`idservicio`);

--
-- Filtros para la tabla `tblequipo`
--
ALTER TABLE `tblequipo`
  ADD CONSTRAINT `relacionCliente` FOREIGN KEY (`idcliente`) REFERENCES `tblcliente` (`idcliente`);

--
-- Filtros para la tabla `tblproducto`
--
ALTER TABLE `tblproducto`
  ADD CONSTRAINT `relacionProveedor` FOREIGN KEY (`idproveedor`) REFERENCES `tblproveedor` (`idproveedor`);

--
-- Filtros para la tabla `tblservicio`
--
ALTER TABLE `tblservicio`
  ADD CONSTRAINT `relacionServicioCliente` FOREIGN KEY (`idcliente`) REFERENCES `tblcliente` (`idcliente`),
  ADD CONSTRAINT `relacionServicioEquipo` FOREIGN KEY (`idequipo`) REFERENCES `tblequipo` (`idequipo`),
  ADD CONSTRAINT `relacionServicioTecnico` FOREIGN KEY (`idtecnico`) REFERENCES `tbltecnico` (`idtecnico`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
