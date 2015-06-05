-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 05, 2015 at 10:02 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `medicadb`
--

-- --------------------------------------------------------

--
-- Table structure for table `administracija`
--

CREATE TABLE IF NOT EXISTS `administracija` (
  `idAdministracija` int(11) NOT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idAdministracija`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `administracija`
--

INSERT INTO `administracija` (`idAdministracija`, `username`, `password`) VALUES
(1, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `doktori`
--

CREATE TABLE IF NOT EXISTS `doktori` (
  `idDoktori` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(45) DEFAULT NULL,
  `prezime` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `specijalnost` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idDoktori`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `doktori`
--

INSERT INTO `doktori` (`idDoktori`, `ime`, `prezime`, `username`, `password`, `specijalnost`) VALUES
(1, 'Reuf', 'Karabeg', 'reuf_mengele', 'medicina', 'Hirurg'),
(2, 'Kenan', 'Popovcevic', 'hausfgbn', 'lol', 'Ortoped'),
(3, 'Demirel', 'Rujanac', 'dema_abalo', 'rukomet', 'Kardiolog');

-- --------------------------------------------------------

--
-- Table structure for table `pacijenti`
--

CREATE TABLE IF NOT EXISTS `pacijenti` (
  `idPacijenti` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(45) DEFAULT NULL,
  `prezime` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idPacijenti`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `pacijenti`
--

INSERT INTO `pacijenti` (`idPacijenti`, `ime`, `prezime`, `username`, `password`) VALUES
(1, 'Velid', 'Aljic', 'velid', 'velid'),
(2, 'Nermin', 'Boja', 'nermin', 'nermin'),
(3, 'Deni', 'Pencl', 'deni', 'deni'),
(4, 'Medin', 'Aljic', 'medin', 'medin');

-- --------------------------------------------------------

--
-- Table structure for table `termini`
--

CREATE TABLE IF NOT EXISTS `termini` (
  `idTermini` int(11) NOT NULL AUTO_INCREMENT,
  `Pacijenti_idPacijenti` int(11) NOT NULL,
  `Doktori_idDoktor` int(11) NOT NULL,
  `datumTermina` date DEFAULT NULL,
  `satiTermina` int(11) DEFAULT NULL,
  `ocjenaTermina` int(11) DEFAULT NULL,
  `soba` int(11) DEFAULT NULL,
  `Tretmani_idTretmani` int(11) NOT NULL,
  PRIMARY KEY (`idTermini`),
  KEY `fk_Termini_Pacijenti1_idx` (`Pacijenti_idPacijenti`),
  KEY `fk_Termini_Doktori1_idx` (`Doktori_idDoktor`),
  KEY `fk_Termini_Tretmani1_idx` (`Tretmani_idTretmani`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `termini`
--

INSERT INTO `termini` (`idTermini`, `Pacijenti_idPacijenti`, `Doktori_idDoktor`, `datumTermina`, `satiTermina`, `ocjenaTermina`, `soba`, `Tretmani_idTretmani`) VALUES
(1, 4, 1, '2015-06-10', 11, 2, NULL, 1),
(2, 4, 1, '2015-06-10', 14, 3, NULL, 1),
(3, 1, 1, '2015-06-10', 12, NULL, NULL, 4);

-- --------------------------------------------------------

--
-- Table structure for table `tretmani`
--

CREATE TABLE IF NOT EXISTS `tretmani` (
  `idTretmani` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` mediumtext,
  PRIMARY KEY (`idTretmani`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `tretmani`
--

INSERT INTO `tretmani` (`idTretmani`, `naziv`) VALUES
(1, 'Operacija 1'),
(2, 'Operacija 2'),
(3, 'Operacija 3'),
(4, 'Pregled 1'),
(5, 'Pregled 2'),
(6, 'Pregled 3');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `termini`
--
ALTER TABLE `termini`
  ADD CONSTRAINT `fk_Termini_Doktori1` FOREIGN KEY (`Doktori_idDoktor`) REFERENCES `doktori` (`idDoktori`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Termini_Pacijenti1` FOREIGN KEY (`Pacijenti_idPacijenti`) REFERENCES `pacijenti` (`idPacijenti`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Termini_Tretmani1` FOREIGN KEY (`Tretmani_idTretmani`) REFERENCES `tretmani` (`idTretmani`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
