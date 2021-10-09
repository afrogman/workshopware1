-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 09-10-2021 a las 08:07:31
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
(1, 2, '', 999, 60.25, 2, 120.5),
(2, 3, '', 999, 250.25, 2, 500.5),
(3, 2, '', 666, 60.25, 1, 60.25),
(4, 3, '', 666, 250.25, 3, 750.75),
(5, 1, '', 1111, 30.5, 50, 1525),
(6, 2, '', 1111, 60.25, 3, 180.75),
(7, 2, '', 4545, 60.25, 1, 60.25),
(8, 3, '', 4545, 250.25, 2, 500.5),
(9, 1, '', 4545, 30.5, 2, 61),
(10, 1, '', 4568, 30.5, 2, 61),
(11, 2, '', 4568, 60.25, 1, 60.25),
(12, 3, '', 4568, 250.25, 12, 3003),
(13, 2, 'Mouse Optico', 3121, 60.25, 2, 120.5),
(14, 3, 'Memoria Ram', 3121, 250.25, 2, 500.5),
(15, 3, 'Memoria Ram', 3121, 250.25, 17, 0),
(16, 1, 'Teclado', 211232, 30.5, 1, 30.5),
(17, 1, 'Teclado', 211232, 30.5, 2, 61),
(18, 2, 'Mouse Optico', 147258, 60.25, 1, 60.25),
(19, 1, 'Teclado', 897654, 30.5, 2, 61),
(20, 2, 'Mouse Optico', 897654, 60.25, 2, 120.5),
(21, 1, 'Teclado', 897654, 30.5, 1, 30.5),
(22, 2, 'Mouse Optico', 357951, 60.25, 1, 60.25),
(23, 1, 'Teclado', 564654, 30.5, 1, 30.5),
(24, 2, 'Mouse Optico', 855555, 60.25, 1, 60.25),
(25, 2, 'Mouse Optico', 12123, 60.25, 1, 60.25),
(26, 2, 'Mouse Optico', 12123, 60.25, 1, 60.25),
(27, 2, 'Mouse Optico', 3, 60.25, 1, 60.25),
(28, 1, 'Teclado', 3, 30.5, 1, 30.5),
(29, 2, 'Mouse Optico', 3, 60.25, 1, 60.25),
(30, 2, 'Mouse Optico', 236, 60.25, 1, 60.25),
(31, 2, 'Mouse Optico', 236, 60.25, 1, 60.25),
(32, 23, 'Chombomin', 654665, 200, 1, 200),
(33, 23, 'Chombomin', 654665, 200, 1, 200),
(34, 23, 'Chombomin', 788976, 200, 1, 200),
(35, 23, 'Chombomin', 789564, 200, 1, 200),
(36, 23, 'Chombomin', 636658, 200, 1, 200),
(37, 23, 'Chombomin', 636658, 200, 1, 200),
(38, 23, 'Chombomin', 665522, 200, 1, 200),
(39, 23, 'Chombomin', 665522, 200, 1, 200),
(40, 23, 'Chombomin', 544444, 200, 1, 200),
(41, 23, 'Chombomin', 544444, 200, 1, 200);

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
(5, 'adsf', 'asdfa', 'dsf', 'adf', 'adf', 1),
(8, 'Centuron', '456789', '123123123', 'No trae nada solo el Case', 'Todo bien', 2),
(21, 'Dell', '2345C', '902349', 'NO trae', 'Nnguna', 2),
(23, 'ada', 'a', 'a', 's', 's', 1),
(211, 'Lenovo', '19987', '23434', 'no tienen', 'adfadfadfa', 2),
(666, 'adfadfad', 'adfafad', '324234231', 'adfdafad', 'zcxvgcgfdfftadfadsfadfadsfad', 1),
(1236, 'adfadf', 'aadfdaf', 'adfadfa', 'adfad', 'adfdasfads', 2),
(4545, 'adfadfa', 'zcvczvzadfadfaq45q', 'adfadsfafda', 'addafadgaag', 'zbcbczbzcbvazdf', 2),
(4568, 'dfadfa', 'adsfadfa', 'adfadfa', 'asd', 'fadfa', 2),
(9999, 'adfadfa', 'adfdafa', 'dfdafa', 'adfadfadfad', 'zcvczvczvz', 2),
(12345, 'adfadfa', 'adfa', 'adfa', 'dfadfa', 'dfa', 1),
(44274, 'Toshiba', '12asadf', 'adsfadfa', 'adfafa', 'adfadfadfa', 2),
(85555, 'adsf', 'adf', 'adf', 'adf', 'adsf', 1),
(87645, 'a', 'd', 'd', 'ga', 'asd', 1),
(145672, 'adsf', 'adfa', 'adf', 'adf', 'adf', 1),
(148269, 'adfadfa', 'adsfadfa', 'adfadfa', 'adfadfa', 'adfafad', 1),
(213134, 'x<aadfadfa', 'zxcvczvczxvzcx', 'erqrqerqerqe', 'q32433adfac', 'eadgtwrthyk7ker7yjehju', 2),
(357951, 'adfaad', 'adf', 'adf', 'adf', 'adf', 1),
(456789, 'Sharp', 'dfadf', 'kjhkjh', 'zcxvz', 'qerqeqr', 2),
(544678, 'a', 's', 'd', 'r', 'y', 1),
(564123, 'adfaa', 'adf', 'zcvz', 'zc', 'df', 1),
(778855, 'adfdaf', 'adfa', 'adfad', 'adfaad', 'adfadfa', 1),
(874444, 'jkl', 'klj', 'klj', 'lkj', 'lk', 1),
(1234112, 'a', 'd', 'd', 'ga', 'as', 1),
(2144558, 'ads', 'adfs', 'adfs', 'adsf', 'adsf', 1),
(9873212, 'as', 'ds', 'sd', 'fd', 'fd', 1),
(22345768, 'as', 'sdsd', 'sd', 'sd', 'sd', 1),
(233411111, 'a', 's', 'd', 'd', 'has', 2);

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
(1, 'Teclado', 'Color negro', 'Genius', 'XP90', '45789654655', 0, 25.75, 30.5, 2),
(2, 'Mouse Optico', 'BlueTuut de color rojo con negro version Maziger Z.', 'Genius', '78-op', '23456', 6, 56.5, 60.25, 1),
(3, 'Memoria Ram', 'DDR 2', 'Kingstone', 'I890', '12345679', -1, 125.25, 250.25, 1),
(23, 'Chombomin', 'adfad', 'adfa', '231', '23', 13, 100, 200, 2);

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
(3, 1, 5, 'adf', 'adfa', '2021-10-08', '2021-10-15', '2021-10-29', 1, 100, 551, 500, 'Pendiente'),
(5, 2, 8, 'No enciende', 'Revisar contactos', '2021-10-07', '2021-10-14', '2021-12-08', 2, 100, 125, 225, 'P'),
(9, 2, 21, 'no jala', 'cambiarla', '2021-10-07', '2021-10-21', '2021-11-30', 2, 123.25, 12.33, 100.25, 'Pendiente'),
(112, 2, 211, 'adfadfadfa', 'adfadfadfads', '2021-10-07', '2021-10-21', '2021-11-05', 2, 40, 100.5, 140.5, 'Pendiente'),
(236, 1, 87645, 'adf', 'adf', '2021-10-08', '2021-10-15', '2021-10-22', 1, 100, 60.25, 100, 'Entregado'),
(456, 2, 1236, 'qereqrqe', 'dfadfa', '2021-10-07', '2021-10-29', '2021-11-04', 2, 100, 100, 200, 'Entregado'),
(666, 1, 666, 'adfdafadfah', 'rgtrgf4gq4qg', '2021-10-07', '2021-10-22', '2021-12-10', 2, 123.5, 77, 200.5, 'Pendiente'),
(999, 2, 9999, 'adgadgsfgagfas', 'adfafdafads', '2021-10-07', '2021-10-15', '2021-11-04', 2, 120, 180, 300, 'Pendiente'),
(1111, 2, 213134, 'abhgh45cf', 'qercf4qtq3y4qyg', '2021-10-07', '2021-10-15', '2021-10-20', 1, 123.44, 376.81, 500.25, 'Pendiente'),
(3121, 2, 44274, 'czvbasgswrgrsagvr', 'argtw45g5w4hyu5w4ywrtwretwre', '2021-10-08', '2021-10-29', '2021-11-05', 1, 10, 90, 100, 'Pendiente'),
(4545, 2, 4545, 'adgadgdagfadag', 'dgadgadgadga', '2021-10-07', '2021-10-20', '2021-11-24', 2, 100, 400, 500, 'Pendiente'),
(4568, 2, 4568, 'adfadfa', 'adfavadaa', '2021-10-07', '2021-10-21', '2021-12-29', 2, 100, 400, 500, 'Pendiente'),
(12123, 1, 145672, 'adfafdas', 'adsfadfadfas', '2021-10-08', '2021-10-15', '2021-10-22', 1, 100, 400, 60.25, 'Pendiente'),
(56956, 1, 874444, 'lio', 'oih', '2021-10-08', '2021-10-09', '2021-10-11', 1, 100, 100, 200, 'Pendiente'),
(123456, 2, 456789, 'adgadfa', 'adgbhrefgvaer', '2021-10-07', '2021-10-28', '2021-11-04', 2, 100, 150, 250, 'Pendiente'),
(147258, 1, 148269, 'adfadfad', 'adfadfadsfdas', '2021-10-08', '2021-10-22', '2021-10-28', 1, 12, 1222.56, 1234.56, 'Pendiente'),
(211232, 1, 12345, 'adfadfad', 'adfadfadads', '2021-10-08', '2021-10-15', '2021-10-20', 1, 1234.44, 8886.88, 10121.32, 'Pendiente'),
(357951, 1, 357951, 'adf', 'adf', '2021-10-08', '2021-10-22', '2021-10-29', 1, 12.34, 1222.22, 1234.56, 'Pendiente'),
(544444, 1, 544678, 'a', 'z', '2021-10-08', '2021-10-08', '2021-10-08', 1, 100, 500, 200, 'Pendiente'),
(564654, 1, 23, 's', 's', '2021-10-08', '2021-10-30', '2021-12-23', 1, 12.12, 3222.12, 3234.24, 'Pendiente'),
(636658, 1, 9873212, 'sfd', 'sfd', '2021-10-08', '2021-10-08', '2021-10-08', 1, 250, 500, 550, 'Pendiente'),
(654665, 2, 233411111, 'as', 'sd', '2021-10-08', '2021-10-15', '2021-10-29', 1, 100, 300, 200, 'Pendiente'),
(665522, 1, 22345768, 'asdf', 'adfa', '2021-10-08', '2021-10-15', '2021-10-22', 1, 100, 600, 500, 'Pendiente'),
(778899, 1, 778855, 'adfadfad', 'adfafdasfadsfadsafdsa', '2021-10-08', '2021-10-15', '2021-10-20', 1, 12, 88, 100, 'Pendiente'),
(788976, 1, 1234112, 'as', 'as', '2021-10-08', '2021-10-08', '2021-10-08', 1, 100, 100, 200, 'Pendiente'),
(789564, 1, 2144558, 'asdf', 'asdf', '2021-10-08', '2021-10-15', '2021-10-29', 1, 100, 100, 200, 'Pendiente'),
(855555, 1, 85555, 'adf', 'adf', '2021-10-08', '2021-10-15', '2021-10-27', 1, 100, 400, 500, 'Pendiente'),
(897654, 1, 564123, 'q34', 'avg', '2021-10-08', '2021-10-08', '2021-10-08', 1, 1, 19, 20, 'Pendiente');

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
  MODIFY `idasignacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

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
