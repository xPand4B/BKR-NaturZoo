-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jan 17, 2019 at 08:26 AM
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
  `city` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`id`, `postcode`, `city`) VALUES
(1, 48465, 'Schüttorf');

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
(1, 'Alfred', 'Clownfisch', 'Männlich', '2018-11-28', 1, 1, NULL, '2019-01-17 07:40:36', NULL);

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
(1, 'Seeworld', 1, '2019-01-17 00:31:26', NULL);

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
(1, 'Aquarium', 1, '2019-01-17 00:57:52', NULL);

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
(1, 'Getreide', 10, 1, '2019-01-17 00:40:14', NULL);

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
(1, 1, 1, '13:00', 'Montag', '42', '2019-01-17 07:41:39', NULL);

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
(1, 'Eric', 'Heinzl', 'eric.heinzl@gmail.com', 'Start1000', 1, 'Samernsche Straße 1', '05923994390', '1998-08-24', 1, 1, '2019-01-16 23:47:20', NULL);

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

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`id`, `status`, `message`, `created_at`) VALUES
(1, 'Info', 'Database connection successfully established.', '2019-01-16 22:55:32'),
(2, 'Info', 'Database connection successfully established.', '2019-01-16 22:56:58'),
(3, 'Info', 'Database connection successfully established.', '2019-01-16 22:57:12'),
(4, 'Info', 'Database connection successfully established.', '2019-01-16 23:02:40'),
(5, 'Info', 'Database connection successfully established.', '2019-01-16 23:04:57'),
(6, 'Info', 'Database connection successfully established.', '2019-01-16 23:08:05'),
(7, 'Info', 'Database connection successfully established.', '2019-01-16 23:11:41'),
(8, 'Info', 'Database connection successfully established.', '2019-01-16 23:12:03'),
(9, 'Info', 'Database connection successfully established.', '2019-01-16 23:12:55'),
(10, 'Info', 'Database connection successfully established.', '2019-01-16 23:15:26'),
(11, 'Info', 'Database connection successfully established.', '2019-01-16 23:18:11'),
(12, 'Info', 'Database connection successfully established.', '2019-01-16 23:20:05'),
(13, 'Info', 'Database connection successfully established.', '2019-01-16 23:25:49'),
(14, 'Update', 'New entry has been added to the territory table.', '2019-01-16 23:26:58'),
(15, 'Info', 'Database connection successfully established.', '2019-01-16 23:30:32'),
(16, 'Info', 'Database connection successfully established.', '2019-01-16 23:31:05'),
(17, 'Update', 'New entry has been added to the building table.', '2019-01-16 23:31:26'),
(18, 'Info', 'Database connection successfully established.', '2019-01-16 23:33:20'),
(19, 'Update', 'New entry has been added to the supplier table.', '2019-01-16 23:34:24'),
(20, 'Info', 'Database connection successfully established.', '2019-01-16 23:35:15'),
(21, 'Info', 'Database connection successfully established.', '2019-01-16 23:35:47'),
(22, 'Info', 'Database connection successfully established.', '2019-01-16 23:36:08'),
(23, 'Info', 'Database connection successfully established.', '2019-01-16 23:36:29'),
(24, 'Info', 'Database connection successfully established.', '2019-01-16 23:38:22'),
(25, 'Info', 'Database connection successfully established.', '2019-01-16 23:39:59'),
(26, 'Update', 'New entry has been added to the food table.', '2019-01-16 23:40:14'),
(27, 'Info', 'Database connection successfully established.', '2019-01-16 23:42:46'),
(28, 'Info', 'Database connection successfully established.', '2019-01-16 23:43:59'),
(29, 'Info', 'Database connection successfully established.', '2019-01-16 23:44:56'),
(30, 'Info', 'Database connection successfully established.', '2019-01-16 23:45:19'),
(31, 'Info', 'Database connection successfully established.', '2019-01-16 23:46:36'),
(32, 'Update', 'New entry has been added to the guardian table.', '2019-01-16 23:47:20'),
(33, 'Info', 'Database connection successfully established.', '2019-01-16 23:51:06'),
(34, 'Info', 'Database connection successfully established.', '2019-01-16 23:52:54'),
(35, 'Info', 'Database connection successfully established.', '2019-01-16 23:53:25'),
(36, 'Update', 'New entry has been added to the enclosure table.', '2019-01-16 23:53:35'),
(37, 'Info', 'Database connection successfully established.', '2019-01-16 23:56:14'),
(38, 'Update', 'New entry has been added to the enclosure table.', '2019-01-16 23:56:19'),
(39, 'Info', 'Database connection successfully established.', '2019-01-16 23:57:25'),
(40, 'Info', 'Database connection successfully established.', '2019-01-16 23:57:43'),
(41, 'Update', 'New entry has been added to the enclosure table.', '2019-01-16 23:57:52'),
(42, 'Info', 'Database connection successfully established.', '2019-01-16 23:58:51'),
(43, 'Update', 'New entry has been added to the building table.', '2019-01-16 23:58:57'),
(44, 'Info', 'Database connection successfully established.', '2019-01-17 00:00:06'),
(45, 'Info', 'Database connection successfully established.', '2019-01-17 00:00:42'),
(46, 'Update', 'New entry has been added to the enclosure table.', '2019-01-17 00:00:47'),
(47, 'Info', 'Database connection successfully established.', '2019-01-17 06:25:30'),
(48, 'Update', 'New entry has been added to the enclosure table.', '2019-01-17 06:25:55'),
(49, 'Update', 'New entry has been added to the enclosure table.', '2019-01-17 06:26:30'),
(50, 'Info', 'Database connection successfully established.', '2019-01-17 06:32:23'),
(51, 'Update', 'New entry has been added to the enclosure table.', '2019-01-17 06:32:36'),
(52, 'Info', 'Database connection successfully established.', '2019-01-17 06:34:07'),
(53, 'Info', 'Database connection successfully established.', '2019-01-17 06:38:09'),
(54, 'Info', 'Database connection successfully established.', '2019-01-17 06:38:26'),
(55, 'Info', 'Database connection successfully established.', '2019-01-17 06:40:01'),
(56, 'Update', 'New entry has been added to the animal table.', '2019-01-17 06:40:36'),
(57, 'Update', 'New entry has been added to the foodplan table.', '2019-01-17 06:41:39'),
(58, 'Info', 'Database connection successfully established.', '2019-01-17 07:17:03'),
(59, 'Info', 'Database connection successfully established.', '2019-01-17 07:19:02'),
(60, 'Info', 'Database connection successfully established.', '2019-01-17 07:19:28');

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
(1, 'Test Lieferant', 1, 'Teststraße 1337', '0123456789', 'Musterman', 'Max', '2019-01-17 00:34:24', NULL);

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
(1, 'Hummer', '2019-01-17 00:26:58', NULL);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `animal`
--
ALTER TABLE `animal`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `building`
--
ALTER TABLE `building`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `enclosure`
--
ALTER TABLE `enclosure`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `food`
--
ALTER TABLE `food`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `foodplan`
--
ALTER TABLE `foodplan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `guardian`
--
ALTER TABLE `guardian`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `permission`
--
ALTER TABLE `permission`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `territory`
--
ALTER TABLE `territory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
