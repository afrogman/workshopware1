-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-10-2021 a las 22:59:42
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
(1, 'Papalina', 'Merida', 'Xela', 4578965, 1234598, 'appalina@gmail.com', '12346-9'),
(2, 'Rina', 'Morales', '2da Avenida 11-34 Zona 1.', 78651258, 12457896, 'rinamorales@coco.com.gt', '789542-5');

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
(1, 'Teclado', 'Color negro', 'Genius', 'XP90', '45789654655', 2, 25.75, 30.5, 2),
(2, 'Mouse Optico', 'BlueTuut de color rojo con negro version Maziger Z.', 'Genius', '78-op', '23456', 5, 56.5, 60.25, 1),
(3, 'Memoria Ram', 'DDR 2', 'Kingstone', 'I890', '12345679', 8, 125.25, 250.25, 1);

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
(1, 'MTI', 'Roman Robles', '1era Calle A-78 Zona 2', 457896523, 1234568, 'rodrgo@jka.com'),
(2, 'Access', 'Juan Roman', '1era Calle 7-78 Zona 2', 45123698, 12457896, 'hugo@arun.com');

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
  `idtecnico` int(11) NOT NULL,
  `pago` double NOT NULL,
  `saldo` double NOT NULL,
  `total` double NOT NULL,
  `estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
(1, 'Juan Miguel', 'Cacatzun Perez', '7ma Calle 12-89 Zona 1', 45235689, 12457898, 'miguelelcacatzun@gmail.com'),
(2, 'German Alfonso', 'Merida Molotovense', '4ta Calle 12-56 Zona 2.', 589647123, 459876123, 'ranaxtg@gmail.com');

--
-- Índices para tablas volcadas
--

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
-- Restricciones para tablas volcadas
--

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
