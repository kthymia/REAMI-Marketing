-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 14, 2024 at 10:40 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `reami`
--

-- --------------------------------------------------------

--
-- Table structure for table `companies`
--

CREATE TABLE `companies` (
  `Company_ID` int(11) NOT NULL,
  `Company_Name` longtext NOT NULL,
  `Contact` longtext NOT NULL,
  `Location` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `Customer_ID` int(11) NOT NULL,
  `Customer_Name` longtext NOT NULL,
  `Customer_Contact` longtext NOT NULL,
  `Customer_Location` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`Customer_ID`, `Customer_Name`, `Customer_Contact`, `Customer_Location`) VALUES
(1, 'customer', 'contact ', 'location');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `Employee_ID` int(11) NOT NULL,
  `First_Name` longtext NOT NULL,
  `Last_Name` longtext NOT NULL,
  `Middle_Name` longtext NOT NULL,
  `Date_of_Birth` datetime(6) NOT NULL,
  `Email` longtext NOT NULL,
  `Phone_Number` longtext NOT NULL,
  `Address` longtext NOT NULL,
  `IsActive` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`Employee_ID`, `First_Name`, `Last_Name`, `Middle_Name`, `Date_of_Birth`, `Email`, `Phone_Number`, `Address`, `IsActive`) VALUES
(1, 'first name', 'last name', 'middle name', '2023-11-08 06:15:00.000000', 'email@gmail.com', '69696969696969', 'address', 1);

-- --------------------------------------------------------

--
-- Table structure for table `installation`
--

CREATE TABLE `installation` (
  `Installation_ID` int(11) NOT NULL,
  `Project_ID` int(11) NOT NULL,
  `Order_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `installation_details`
--

CREATE TABLE `installation_details` (
  `Installation_ID` int(11) NOT NULL,
  `Employee_ID` int(11) NOT NULL,
  `Role_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `measurements`
--

CREATE TABLE `measurements` (
  `Measurement_ID` int(11) NOT NULL,
  `Measurement_Type` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `Order_ID` int(11) NOT NULL,
  `Customer_ID` int(11) NOT NULL,
  `Date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `order_details`
--

CREATE TABLE `order_details` (
  `Order_Details_ID` int(11) NOT NULL,
  `Order_ID` int(11) NOT NULL,
  `Product_ID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Price` decimal(65,30) NOT NULL,
  `Unit` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `Product_ID` int(11) NOT NULL,
  `Product_Desc` longtext NOT NULL,
  `Stocks_available` int(11) NOT NULL,
  `Unit` longtext NOT NULL,
  `Price` decimal(65,30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `product_details`
--

CREATE TABLE `product_details` (
  `Order_Details_ID` int(11) NOT NULL,
  `Measurement_ID` int(11) NOT NULL,
  `Value` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `projects`
--

CREATE TABLE `projects` (
  `Project_ID` int(11) NOT NULL,
  `Project_Name` longtext NOT NULL,
  `Duration` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `Role_ID` int(11) NOT NULL,
  `Role_Name` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `role`
--

INSERT INTO `role` (`Role_ID`, `Role_Name`) VALUES
(1, 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `supplies`
--

CREATE TABLE `supplies` (
  `Supply_ID` int(11) NOT NULL,
  `Company_ID` int(11) NOT NULL,
  `Date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `supply_details`
--

CREATE TABLE `supply_details` (
  `Supply_ID` int(11) NOT NULL,
  `Product_ID` int(11) NOT NULL,
  `Unit` longtext NOT NULL,
  `Quantity_Supplied` int(11) NOT NULL,
  `Price` decimal(65,30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20240311211310_initDB', '8.0.2'),
('20240311225256_Add_Remaining_Models', '8.0.2');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `companies`
--
ALTER TABLE `companies`
  ADD PRIMARY KEY (`Company_ID`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`Customer_ID`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`Employee_ID`);

--
-- Indexes for table `installation`
--
ALTER TABLE `installation`
  ADD PRIMARY KEY (`Installation_ID`),
  ADD KEY `IX_Installation_Order_ID` (`Order_ID`),
  ADD KEY `IX_Installation_Project_ID` (`Project_ID`);

--
-- Indexes for table `installation_details`
--
ALTER TABLE `installation_details`
  ADD PRIMARY KEY (`Installation_ID`),
  ADD KEY `IX_Installation_Details_Employee_ID` (`Employee_ID`),
  ADD KEY `IX_Installation_Details_Role_ID` (`Role_ID`);

--
-- Indexes for table `measurements`
--
ALTER TABLE `measurements`
  ADD PRIMARY KEY (`Measurement_ID`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`Order_ID`),
  ADD KEY `IX_Orders_Customer_ID` (`Customer_ID`);

--
-- Indexes for table `order_details`
--
ALTER TABLE `order_details`
  ADD PRIMARY KEY (`Order_Details_ID`),
  ADD KEY `IX_Order_Details_Order_ID` (`Order_ID`),
  ADD KEY `IX_Order_Details_Product_ID` (`Product_ID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Product_ID`);

--
-- Indexes for table `product_details`
--
ALTER TABLE `product_details`
  ADD PRIMARY KEY (`Order_Details_ID`,`Measurement_ID`),
  ADD KEY `IX_Product_Details_Measurement_ID` (`Measurement_ID`);

--
-- Indexes for table `projects`
--
ALTER TABLE `projects`
  ADD PRIMARY KEY (`Project_ID`);

--
-- Indexes for table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`Role_ID`);

--
-- Indexes for table `supplies`
--
ALTER TABLE `supplies`
  ADD PRIMARY KEY (`Supply_ID`),
  ADD KEY `IX_Supplies_Company_ID` (`Company_ID`);

--
-- Indexes for table `supply_details`
--
ALTER TABLE `supply_details`
  ADD PRIMARY KEY (`Supply_ID`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `companies`
--
ALTER TABLE `companies`
  MODIFY `Company_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `Customer_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `Employee_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `installation`
--
ALTER TABLE `installation`
  MODIFY `Installation_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `installation_details`
--
ALTER TABLE `installation_details`
  MODIFY `Installation_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `measurements`
--
ALTER TABLE `measurements`
  MODIFY `Measurement_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `Order_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `order_details`
--
ALTER TABLE `order_details`
  MODIFY `Order_Details_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `Product_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `projects`
--
ALTER TABLE `projects`
  MODIFY `Project_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `role`
--
ALTER TABLE `role`
  MODIFY `Role_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `supplies`
--
ALTER TABLE `supplies`
  MODIFY `Supply_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supply_details`
--
ALTER TABLE `supply_details`
  MODIFY `Supply_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `installation`
--
ALTER TABLE `installation`
  ADD CONSTRAINT `FK_Installation_Orders_Order_ID` FOREIGN KEY (`Order_ID`) REFERENCES `orders` (`Order_ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Installation_Projects_Project_ID` FOREIGN KEY (`Project_ID`) REFERENCES `projects` (`Project_ID`) ON DELETE CASCADE;

--
-- Constraints for table `installation_details`
--
ALTER TABLE `installation_details`
  ADD CONSTRAINT `FK_Installation_Details_Employees_Employee_ID` FOREIGN KEY (`Employee_ID`) REFERENCES `employees` (`Employee_ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Installation_Details_Role_Role_ID` FOREIGN KEY (`Role_ID`) REFERENCES `role` (`Role_ID`) ON DELETE CASCADE;

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_Orders_Customers_Customer_ID` FOREIGN KEY (`Customer_ID`) REFERENCES `customers` (`Customer_ID`) ON DELETE CASCADE;

--
-- Constraints for table `order_details`
--
ALTER TABLE `order_details`
  ADD CONSTRAINT `FK_Order_Details_Orders_Order_ID` FOREIGN KEY (`Order_ID`) REFERENCES `orders` (`Order_ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Order_Details_Products_Product_ID` FOREIGN KEY (`Product_ID`) REFERENCES `products` (`Product_ID`) ON DELETE CASCADE;

--
-- Constraints for table `product_details`
--
ALTER TABLE `product_details`
  ADD CONSTRAINT `FK_Product_Details_Measurements_Measurement_ID` FOREIGN KEY (`Measurement_ID`) REFERENCES `measurements` (`Measurement_ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Product_Details_Order_Details_Order_Details_ID` FOREIGN KEY (`Order_Details_ID`) REFERENCES `order_details` (`Order_Details_ID`) ON DELETE CASCADE;

--
-- Constraints for table `supplies`
--
ALTER TABLE `supplies`
  ADD CONSTRAINT `FK_Supplies_Companies_Company_ID` FOREIGN KEY (`Company_ID`) REFERENCES `companies` (`Company_ID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
