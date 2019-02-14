-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Feb 14, 2019 at 12:46 PM
-- Server version: 10.3.7-MariaDB
-- PHP Version: 7.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bkr_zoo_eric_heinzl`
--
CREATE DATABASE IF NOT EXISTS `bkr_zoo_eric_heinzl` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `bkr_zoo_eric_heinzl`;

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `id` int(11) NOT NULL,
  `postcode` int(5) NOT NULL,
  `city` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`id`, `postcode`, `city`, `created_at`, `updated_at`) VALUES
(1, 48465, 'Schüttorf', '2019-02-13 00:38:57', NULL),
(2, 48282, 'Emsdetten', '2019-02-13 00:48:17', NULL),
(3, 00000, 'Adlertown', '2019-02-13 00:49:09', NULL),
(4, 01234, 'Bottown', '2019-02-13 00:49:58', NULL),
(5, 01234, 'Adlertown', '2019-02-14 12:39:42', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `animal`
--

CREATE TABLE `animal` (
  `id` int(11) NOT NULL,
  `name` varchar(128) COLLATE utf8mb4_unicode_ci NOT NULL,
  `species` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gender` varchar(24) COLLATE utf8mb4_unicode_ci NOT NULL,
  `birthday` date NOT NULL,
  `fk_territoryid` int(11) NOT NULL,
  `fk_enclosureid` int(11) NOT NULL,
  `away_since` date DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `animal`
--

INSERT INTO `animal` (`id`, `name`, `species`, `gender`, `birthday`, `fk_territoryid`, `fk_enclosureid`, `away_since`, `created_at`, `updated_at`) VALUES
(1, 'Venum', 'Elefant', 'Männlich', '2018-11-06', 3, 2, NULL, '2019-02-14 12:10:24', NULL),
(2, 'Theo', 'Tiger', 'Weiblich', '2018-11-28', 1, 3, NULL, '2019-02-14 12:35:19', NULL),
(3, 'Saskia', 'Eule', 'Männlich', '2018-11-28', 4, 7, NULL, '2019-02-14 12:43:24', NULL),
(4, 'Norbert', 'Eule', 'Weiblich', '2018-11-28', 4, 7, NULL, '2019-02-14 12:43:46', NULL),
(5, 'Gutruhn', 'Spatz', 'Weiblich', '2018-11-02', 4, 6, NULL, '2019-02-14 12:44:12', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `building`
--

CREATE TABLE `building` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fk_territoryid` int(11) NOT NULL,
  `created_At` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_At` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `building`
--

INSERT INTO `building` (`id`, `name`, `fk_territoryid`, `created_At`, `updated_At`) VALUES
(1, 'Elefanten-Haus', 3, '2019-02-13 00:24:46', NULL),
(2, 'Antilopen-Wiese', 3, '2019-02-13 00:27:30', NULL),
(3, 'Seelöwen-Planschbecken', 8, '2019-02-13 00:28:36', NULL),
(4, 'Löwen-Haus', 1, '2019-02-13 00:37:03', NULL),
(5, 'Affen-Haus', 3, '2019-02-13 00:37:32', NULL),
(6, 'Vogel-Haus', 4, '2019-02-14 12:42:03', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `enclosure`
--

CREATE TABLE `enclosure` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fk_buildingid` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `enclosure`
--

INSERT INTO `enclosure` (`id`, `name`, `fk_buildingid`, `created_at`, `updated_at`) VALUES
(1, 'Orangutan-Gehege', 5, '2019-02-13 00:38:03', NULL),
(2, 'Elefanten-Babies', 1, '2019-02-13 00:51:50', NULL),
(3, 'Löwen-Gehege', 4, '2019-02-14 12:35:12', NULL),
(4, 'Seelöwen-Gehege', 3, '2019-02-14 12:40:47', NULL),
(5, 'Antilopen-Gehege', 2, '2019-02-14 12:40:59', NULL),
(6, 'Spatzen-Gehege', 6, '2019-02-14 12:42:47', NULL),
(7, 'Eulen-Gehege', 6, '2019-02-14 12:43:01', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `food`
--

CREATE TABLE `food` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `amount` int(11) NOT NULL,
  `fk_supplierid` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `food`
--

INSERT INTO `food` (`id`, `name`, `amount`, `fk_supplierid`, `created_at`, `updated_at`) VALUES
(1, 'Getreide', 10, 2, '2019-02-14 12:32:15', NULL),
(2, 'Fleisch', 50, 2, '2019-02-14 12:32:27', NULL),
(3, 'Vitamine', 8, 1, '2019-02-14 12:32:50', NULL),
(4, 'Brot', 20, 1, '2019-02-14 12:33:04', NULL),
(5, 'Bananen', 40, 2, '2019-02-14 12:33:28', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `foodplan`
--

CREATE TABLE `foodplan` (
  `id` int(11) NOT NULL,
  `fk_animalid` int(11) NOT NULL,
  `fk_foodid` int(11) NOT NULL,
  `time` varchar(5) COLLATE utf8mb4_unicode_ci NOT NULL,
  `weekday` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `amount` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `foodplan`
--

INSERT INTO `foodplan` (`id`, `fk_animalid`, `fk_foodid`, `time`, `weekday`, `amount`, `created_at`, `updated_at`) VALUES
(1, 1, 5, '09:00', 'Montag', '1', '2019-02-14 12:34:17', NULL),
(2, 2, 2, '15:00', 'Freitag', '2', '2019-02-14 12:35:37', NULL),
(3, 2, 3, '12:00', 'Dienstag', '1', '2019-02-14 12:37:50', NULL),
(4, 5, 4, '18:00', 'Mittwoch', '5', '2019-02-14 12:44:36', NULL),
(5, 4, 2, '07:00', 'Montag', '10', '2019-02-14 12:45:04', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `guardian`
--

CREATE TABLE `guardian` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `surname` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fk_addressid` int(11) NOT NULL,
  `street` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `telephone` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL,
  `birthday` date NOT NULL,
  `fk_territoryid` int(11) NOT NULL,
  `permission` int(2) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `guardian`
--

INSERT INTO `guardian` (`id`, `name`, `surname`, `email`, `password`, `fk_addressid`, `street`, `telephone`, `birthday`, `fk_territoryid`, `permission`, `created_at`, `updated_at`) VALUES
(1, 'Eric', 'Heinzl', 'eric.heinzl@gmail.com', 'Start1000', 1, 'Samernschestraße 1', '05923994390', '1998-08-24', 4, 1, '2019-02-12 23:38:57', NULL),
(2, 'Henning', 'Holthaus', 'h.holthaus@gmail.com', 'Start1000', 1, 'Holzhausweg 69', '0123456789', '1998-08-24', 5, 1, '2019-02-12 23:40:26', NULL),
(3, 'Vural', 'Corapci', 'v.corapci@gmail.com', 'Start1000', 1, 'Keine-Ahnung-999', '0123456789', '1999-01-01', 1, 1, '2019-02-12 23:47:28', NULL),
(4, 'Stuart', 'Lux', 's.lux@gmail.com', 'Start1000', 2, 'Badjoke-Straße 1337', '0123456789', '1999-01-01', 3, 1, '2019-02-12 23:48:17', NULL),
(5, 'Justin', 'Adler', 'j.adler@gmail.com', 'Start1000', 3, 'Adlerweg', '0123456789', '1999-01-01', 8, 1, '2019-02-12 23:49:09', NULL),
(6, 'Sven', 'König', 's.koenig@gmail.com', 'Start1000', 4, 'Xovs-Avenue 009', '0123456789', '1999-01-01', 4, 1, '2019-02-12 23:49:58', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `id` int(11) NOT NULL,
  `status` varchar(32) COLLATE utf8mb4_unicode_ci NOT NULL,
  `message` varchar(512) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `permission`
--

CREATE TABLE `permission` (
  `id` int(11) NOT NULL,
  `level` int(11) NOT NULL,
  `name` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `id` int(11) NOT NULL,
  `name` varchar(265) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fk_addressid` int(11) NOT NULL,
  `street` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `telephone` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL,
  `contact_person_name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `contact_person_surname` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`id`, `name`, `fk_addressid`, `street`, `telephone`, `contact_person_name`, `contact_person_surname`, `created_at`, `updated_at`) VALUES
(1, 'Futter GmbH', 4, 'Teststraße 34', '0123456789', 'Mustermann', 'Max', '2019-02-14 12:30:06', NULL),
(2, 'Food-Supplier Corp', 2, 'Bird Avenue 45', '0123456789', 'Trump', 'Donald', '2019-02-14 12:31:54', NULL),
(3, 'Arnold Lammering', 1, 'Industriestraße 85', '012345789', 'Lammering', 'Arnold', '2019-02-14 12:39:00', NULL),
(4, 'Retard Supply', 5, 'Yuki 88', '0123456789', 'Adler', 'Justin', '2019-02-14 12:39:42', NULL),
(5, 'xPand', 1, 'Samernschestraße 1', '0123456789', 'Heinzl', 'Eric', '2019-02-14 12:40:22', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `territory`
--

CREATE TABLE `territory` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `territory`
--

INSERT INTO `territory` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'Großtiere', '2019-02-13 00:18:50', NULL),
(2, 'Kleintiere', '2019-02-13 00:18:55', NULL),
(3, 'Afrika-Revier', '2019-02-13 00:19:26', NULL),
(4, 'Vogel-Haus', '2019-02-13 00:19:35', NULL),
(5, 'Raubtier-Revier', '2019-02-13 00:20:01', NULL),
(6, 'Giraffen-Haus', '2019-02-13 00:20:30', NULL),
(7, 'Huftier-Revier', '2019-02-13 00:20:55', NULL),
(8, 'Robbenklippen', '2019-02-13 00:21:07', NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `animal`
--
ALTER TABLE `animal`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `building`
--
ALTER TABLE `building`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `enclosure`
--
ALTER TABLE `enclosure`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `food`
--
ALTER TABLE `food`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `foodplan`
--
ALTER TABLE `foodplan`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `guardian`
--
ALTER TABLE `guardian`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `permission`
--
ALTER TABLE `permission`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `territory`
--
ALTER TABLE `territory`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `animal`
--
ALTER TABLE `animal`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `building`
--
ALTER TABLE `building`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `enclosure`
--
ALTER TABLE `enclosure`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `food`
--
ALTER TABLE `food`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `foodplan`
--
ALTER TABLE `foodplan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `guardian`
--
ALTER TABLE `guardian`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `permission`
--
ALTER TABLE `permission`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `territory`
--
ALTER TABLE `territory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
