-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-10-2021 a las 06:57:17
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
(42, 1, 'Teclado', 1, 121, 2, 121),
(43, 2, 'Case XT', 1, 230, 1, 230);

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
(1, 'Jose Antonio', 'Rojas de Leon', '11 Avenida 7-80 Zona 2', 77615689, 56897412, 'jrojas@gmail.com', '258974-5'),
(2, 'Julio Eduardo', 'Xicará Castañeda', 'Diagonal 11 7-40 Zona 1', 77600339, 59452313, 'ranaxtg@gmail.com', '2055900-3');

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
(1, 'Toshiba', 'Tecra', '456789', 'Cargador', 'Viene sucia, quebrada, el cargador viene con cita de aislar, no enciende', 2);

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
(1, 'Teclado', 'USB/BlueTu', 'Genius', '123456', '45678', 8, 100, 121, 3),
(2, 'Case XT', 'Color negro, neon, bien chilero', 'Neon', '45678', '123132465', 1, 200, 230, 2);

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
(1, 'MTI', 'Ulices Sajquim', 'Xela', 77661033, 67896546, 'ulces@gmail.com'),
(2, 'Access', 'Fernando Yac', 'Xeal', 45678912, 45678965, 'jajaja@gmail.com'),
(3, 'Tecnologia S.A.', 'Gerson', 'xela', 45678912, 45678998, 'jajaja@gmail.com');

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
(1, 2, 1, 'No enciende y el disco duro hace ruido', 'Revision, mantenimiento y cambiar disco duro', '2021-10-09', '2021-10-23', '2021-12-24', 2, 100, 451, 200, 'Pendiente');

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
(1, 'Luis', 'Perez', 'Xela', 1234568, 45678965, 'tecnico1@gmail.com'),
(2, 'Hernesto', 'Gomez', 'Salcaja', 78945623, 45678912, 'tecnico2@gmail.com');

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
  MODIFY `idasignacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

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
