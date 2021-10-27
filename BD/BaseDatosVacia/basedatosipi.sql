-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-10-2021 a las 06:01:00
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
  MODIFY `idasignacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

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
