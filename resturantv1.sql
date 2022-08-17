-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 17, 2022 at 04:29 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `resturantv1`
--

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `AddressId` int(11) NOT NULL,
  `city` varchar(50) DEFAULT NULL,
  `homeLocation` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`AddressId`, `city`, `homeLocation`) VALUES
(1, 'fsdfsdf', 'fsdfsdfsdf');

-- --------------------------------------------------------

--
-- Table structure for table `invoicedetails`
--

CREATE TABLE `invoicedetails` (
  `Id` int(11) NOT NULL,
  `Count` double NOT NULL,
  `Price` double NOT NULL,
  `APDTotalCost` double NOT NULL,
  `discount` double NOT NULL,
  `MainId` int(11) NOT NULL,
  `ItemId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `invoicedetails`
--

INSERT INTO `invoicedetails` (`Id`, `Count`, `Price`, `APDTotalCost`, `discount`, `MainId`, `ItemId`) VALUES
(1, 4, 55, 219, 1, 1, 1),
(2, 4, 66, 263, 1, 2, 1),
(3, 5, 25, 123, 2, 3, 1),
(4, 76, 100, 7598, 2, 4, 1),
(5, 3, 23, 64, 5, 5, 1),
(6, 4, 24, 95, 1, 5, 1);

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `Id` int(11) NOT NULL,
  `Name` text DEFAULT NULL,
  `Description` text DEFAULT NULL,
  `UnitId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`Id`, `Name`, `Description`, `UnitId`) VALUES
(1, 'test', 'test', 1);

-- --------------------------------------------------------

--
-- Table structure for table `manager`
--

CREATE TABLE `manager` (
  `ManagerId` int(11) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phoneNumber` varchar(50) DEFAULT NULL,
  `AddressId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`ManagerId`, `username`, `password`, `email`, `phoneNumber`, `AddressId`) VALUES
(1, 'mahmoud', 'Mahmoud_123', 'mm@mm.com', '0111111111', 1),
(2, 'Najd', 'Mahmoud_117', 'mm@mm.com', '0598743747', 1);

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `Id` int(11) NOT NULL,
  `ConsumingDate` datetime NOT NULL,
  `Count` double NOT NULL,
  `ItemId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`Id`, `ConsumingDate`, `Count`, `ItemId`) VALUES
(1, '2022-08-16 00:00:00', 2, 1),
(2, '2022-08-16 00:00:00', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `stockitems`
--

CREATE TABLE `stockitems` (
  `StockId` int(11) NOT NULL,
  `stockNumber` int(11) NOT NULL,
  `ItemId` int(11) NOT NULL,
  `storage` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `stockitems`
--

INSERT INTO `stockitems` (`StockId`, `stockNumber`, `ItemId`, `storage`) VALUES
(1, 1, 1, 93);

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `SupplierId` int(11) NOT NULL,
  `supplierName` varchar(50) DEFAULT NULL,
  `supplierPhone` varchar(10) DEFAULT NULL,
  `supplierNumber` int(11) NOT NULL,
  `supplierLocation` varchar(100) DEFAULT NULL,
  `ManagerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`SupplierId`, `supplierName`, `supplierPhone`, `supplierNumber`, `supplierLocation`, `ManagerId`) VALUES
(1, 'sss', '0598743747', 54, 'ewae', 1);

-- --------------------------------------------------------

--
-- Table structure for table `supplying`
--

CREATE TABLE `supplying` (
  `SupplyingId` int(11) NOT NULL,
  `supplyingNumber` int(11) NOT NULL,
  `supplyingDate` datetime NOT NULL,
  `goodsName` varchar(100) DEFAULT NULL,
  `amount` int(11) NOT NULL,
  `unitId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `supplyinginvoice`
--

CREATE TABLE `supplyinginvoice` (
  `InvoiceId` int(11) NOT NULL,
  `invoiceDate` datetime NOT NULL,
  `supplierId` int(11) NOT NULL,
  `TotalOfPurchase` double NOT NULL,
  `InvoiceStatus` varchar(50) DEFAULT NULL,
  `Url` text DEFAULT NULL,
  `Deleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `supplyinginvoice`
--

INSERT INTO `supplyinginvoice` (`InvoiceId`, `invoiceDate`, `supplierId`, `TotalOfPurchase`, `InvoiceStatus`, `Url`, `Deleted`) VALUES
(1, '2022-08-16 00:00:00', 1, 219, NULL, '/uploads/images/7e6d1bbc954b41418a1af0444f8beade.jpg', 0),
(2, '2022-08-18 00:00:00', 1, 263, NULL, '/uploads/images/0b117552225d42daa7e64505ed174a50.jpg', 0),
(3, '2022-08-16 00:00:00', 1, 123, NULL, '/uploads/images/9902308eed9142af90ccb7f9126ad7de.jpg', 0),
(4, '2022-08-19 00:00:00', 1, 7598, NULL, '/uploads/images/3e0daab06b24492aa70b8a5ffc05db66.jpg', 1),
(5, '2022-08-17 00:00:00', 1, 159, NULL, '/uploads/images/ebaab46387744113bab02a80f70d89f2.jpg', 0);

-- --------------------------------------------------------

--
-- Table structure for table `supplyingprocess`
--

CREATE TABLE `supplyingprocess` (
  `Id` int(11) NOT NULL,
  `SupplierId` int(11) NOT NULL,
  `SupplyingId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `units`
--

CREATE TABLE `units` (
  `Id` int(11) NOT NULL,
  `Name` text DEFAULT NULL,
  `IsNumber` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`Id`, `Name`, `IsNumber`) VALUES
(1, 'ghram', 1);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220815150332_InitialModel', '5.0.5'),
('20220817121601_Secondmig', '5.0.5'),
('20220817121740_thirdmig', '5.0.5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`AddressId`);

--
-- Indexes for table `invoicedetails`
--
ALTER TABLE `invoicedetails`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_InvoiceDetails_ItemId` (`ItemId`),
  ADD KEY `IX_InvoiceDetails_MainId` (`MainId`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Items_UnitId` (`UnitId`);

--
-- Indexes for table `manager`
--
ALTER TABLE `manager`
  ADD PRIMARY KEY (`ManagerId`),
  ADD KEY `IX_Manager_AddressId` (`AddressId`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Sales_ItemId` (`ItemId`);

--
-- Indexes for table `stockitems`
--
ALTER TABLE `stockitems`
  ADD PRIMARY KEY (`StockId`),
  ADD KEY `IX_StockItems_ItemId` (`ItemId`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`SupplierId`),
  ADD KEY `IX_Supplier_ManagerId` (`ManagerId`);

--
-- Indexes for table `supplying`
--
ALTER TABLE `supplying`
  ADD PRIMARY KEY (`SupplyingId`),
  ADD KEY `IX_Supplying_unitId` (`unitId`);

--
-- Indexes for table `supplyinginvoice`
--
ALTER TABLE `supplyinginvoice`
  ADD PRIMARY KEY (`InvoiceId`),
  ADD KEY `IX_SupplyingInvoice_supplierId` (`supplierId`);

--
-- Indexes for table `supplyingprocess`
--
ALTER TABLE `supplyingprocess`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_SupplyingProcess_SupplierId` (`SupplierId`),
  ADD KEY `IX_SupplyingProcess_SupplyingId` (`SupplyingId`);

--
-- Indexes for table `units`
--
ALTER TABLE `units`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `AddressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `invoicedetails`
--
ALTER TABLE `invoicedetails`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `manager`
--
ALTER TABLE `manager`
  MODIFY `ManagerId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `stockitems`
--
ALTER TABLE `stockitems`
  MODIFY `StockId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `SupplierId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `supplying`
--
ALTER TABLE `supplying`
  MODIFY `SupplyingId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplyinginvoice`
--
ALTER TABLE `supplyinginvoice`
  MODIFY `InvoiceId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `supplyingprocess`
--
ALTER TABLE `supplyingprocess`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `units`
--
ALTER TABLE `units`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `invoicedetails`
--
ALTER TABLE `invoicedetails`
  ADD CONSTRAINT `FK_InvoiceDetails_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `items` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_InvoiceDetails_SupplyingInvoice_MainId` FOREIGN KEY (`MainId`) REFERENCES `supplyinginvoice` (`InvoiceId`) ON DELETE CASCADE;

--
-- Constraints for table `items`
--
ALTER TABLE `items`
  ADD CONSTRAINT `FK_Items_Units_UnitId` FOREIGN KEY (`UnitId`) REFERENCES `units` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `manager`
--
ALTER TABLE `manager`
  ADD CONSTRAINT `FK_Manager_Address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `address` (`AddressId`) ON DELETE CASCADE;

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `FK_Sales_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `items` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `stockitems`
--
ALTER TABLE `stockitems`
  ADD CONSTRAINT `FK_StockItems_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `items` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `supplier`
--
ALTER TABLE `supplier`
  ADD CONSTRAINT `FK_Supplier_Manager_ManagerId` FOREIGN KEY (`ManagerId`) REFERENCES `manager` (`ManagerId`) ON DELETE CASCADE;

--
-- Constraints for table `supplying`
--
ALTER TABLE `supplying`
  ADD CONSTRAINT `FK_Supplying_Units_unitId` FOREIGN KEY (`unitId`) REFERENCES `units` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `supplyinginvoice`
--
ALTER TABLE `supplyinginvoice`
  ADD CONSTRAINT `FK_SupplyingInvoice_Supplier_supplierId` FOREIGN KEY (`supplierId`) REFERENCES `supplier` (`SupplierId`) ON DELETE CASCADE;

--
-- Constraints for table `supplyingprocess`
--
ALTER TABLE `supplyingprocess`
  ADD CONSTRAINT `FK_SupplyingProcess_Supplier_SupplierId` FOREIGN KEY (`SupplierId`) REFERENCES `supplier` (`SupplierId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_SupplyingProcess_Supplying_SupplyingId` FOREIGN KEY (`SupplyingId`) REFERENCES `supplying` (`SupplyingId`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
