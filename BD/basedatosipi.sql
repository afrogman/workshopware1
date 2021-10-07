-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 07-10-2021 a las 21:37:33
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
  `idservicio` int(11) NOT NULL,
  `precioventa` double NOT NULL,
  `cantidaddisponible` int(11) NOT NULL,
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

--
-- Volcado de datos para la tabla `tblequipo`
--

INSERT INTO `tblequipo` (`idequipo`, `marca`, `modelo`, `serie`, `accesorios`, `observaciones`, `idcliente`) VALUES
(1, 'Compaq', 'Presario 1200', '4578965423', 'Trae un mouse, pantalla plana lcd, teclado y una impresora.', 'El equipo viene sucio, lleno de polvo y con manchas de cafe.', 2),
(2, 'Dell', '7898', '123456789', 'Trae cargador.', 'El cargado viene quebrado y la computadora viene muy sucia.', 2),
(3, 'Toshiba', '1996', '123456789', 'Trae un caragado sucio', 'Computadora muy golpeada', 2),
(4, 'Tangerine', '1998', '123', 'NO hay', 'tampoco hay', 2),
(8, 'Centuron', '456789', '123123123', 'No trae nada solo el Case', 'Todo bien', 2),
(21, 'Dell', '2345C', '902349', 'NO trae', 'Nnguna', 2),
(211, 'Lenovo', '19987', '23434', 'no tienen', 'adfadfadfa', 2),
(1236, 'adfadf', 'aadfdaf', 'adfadfa', 'adfad', 'adfdasfads', 2);

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
(1, 2, 3, 'No enciende y parece que el disco esta dañado.', 'Chequeo de disco.', '2021-10-07', '2021-10-09', '2021-11-25', 2, 100, 25, 125, '0'),
(5, 2, 8, 'No enciende', 'Revisar contactos', '2021-10-07', '2021-10-14', '2021-12-08', 2, 100, 125, 225, 'P'),
(9, 2, 21, 'no jala', 'cambiarla', '2021-10-07', '2021-10-21', '2021-11-30', 2, 123.25, 12.33, 100.25, 'Pendiente'),
(112, 2, 211, 'adfadfadfa', 'adfadfadfads', '2021-10-07', '2021-10-21', '2021-11-05', 2, 40, 100.5, 140.5, 'Pendiente'),
(456, 2, 1236, 'qereqrqe', 'dfadfa', '2021-10-07', '2021-10-29', '2021-11-04', 2, 100, 100, 200, 'Entregado');

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
  MODIFY `idasignacion` int(11) NOT NULL AUTO_INCREMENT;

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
