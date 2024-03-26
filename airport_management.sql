-- MariaDB dump 10.19-11.3.2-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: airport_management
-- ------------------------------------------------------
-- Server version	11.3.2-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Airplanes`
--

DROP TABLE IF EXISTS `Airplanes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Airplanes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Classification` longtext NOT NULL,
  `ClientId` int(11) NOT NULL,
  `MaxLoad` int(11) NOT NULL,
  `PassengersCapacity` int(11) NOT NULL,
  `ArriveDate` longtext NOT NULL,
  `DepartureDate` longtext NOT NULL,
  `HasReceivedMaintenance` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Airplanes_ClientId` (`ClientId`),
  KEY `IX_Airplanes_Id` (`Id`),
  CONSTRAINT `FK_Airplanes_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Airplanes`
--

LOCK TABLES `Airplanes` WRITE;
/*!40000 ALTER TABLE `Airplanes` DISABLE KEYS */;
INSERT INTO `Airplanes` VALUES
(1,'Commercial',1,20000,200,'Monday, 25 March 2024 20:18:55','Monday, 25 March 2024 20:18:55',0),
(2,'Private',2,5000,20,'Monday, 25 March 2024 20:18:55','Monday, 25 March 2024 20:18:55',0),
(3,'Cargo',3,50000,0,'Monday, 25 March 2024 20:18:55','Monday, 25 March 2024 20:18:55',0);
/*!40000 ALTER TABLE `Airplanes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Airports`
--

DROP TABLE IF EXISTS `Airports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Airports` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Address` longtext NOT NULL,
  `GeographicLocation` longtext NOT NULL,
  `PhotoUrl` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Airports_Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Airports`
--

LOCK TABLES `Airports` WRITE;
/*!40000 ALTER TABLE `Airports` DISABLE KEYS */;
INSERT INTO `Airports` VALUES
(1,'Changi Airport','Airport Blvd, Singapore','1.3644° N, 103.9915° E',NULL),
(2,'Heathrow Airport','Longford TW6, United Kingdom','51.4700° N, 0.4543° W',NULL),
(3,'John F. Kennedy International Airport','Queens, NY 11430, United States','40.6413° N, 73.7781° W',NULL);
/*!40000 ALTER TABLE `Airports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ClientRatings`
--

DROP TABLE IF EXISTS `ClientRatings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ClientRatings` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClientId` int(11) NOT NULL,
  `ServiceId` int(11) NOT NULL,
  `Rating` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ClientRatings_ClientId` (`ClientId`),
  KEY `IX_ClientRatings_ServiceId` (`ServiceId`),
  CONSTRAINT `FK_ClientRatings_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ClientRatings_Services_ServiceId` FOREIGN KEY (`ServiceId`) REFERENCES `Services` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ClientRatings`
--

LOCK TABLES `ClientRatings` WRITE;
/*!40000 ALTER TABLE `ClientRatings` DISABLE KEYS */;
INSERT INTO `ClientRatings` VALUES
(1,1,1,9),
(2,1,1,9),
(3,3,3,10);
/*!40000 ALTER TABLE `ClientRatings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Clients`
--

DROP TABLE IF EXISTS `Clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Clients` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Ci` longtext NOT NULL,
  `Country` longtext NOT NULL,
  `ClientType` int(11) NOT NULL,
  `ArrivalRole` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Clients_Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Clients`
--

LOCK TABLES `Clients` WRITE;
/*!40000 ALTER TABLE `Clients` DISABLE KEYS */;
INSERT INTO `Clients` VALUES
(1,'Client 1','CI1','Country 1',0,0),
(2,'Client 2','CI2','Country 2',1,1),
(3,'Client 3','CI3','Country 3',2,2);
/*!40000 ALTER TABLE `Clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Facilities`
--

DROP TABLE IF EXISTS `Facilities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Facilities` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext DEFAULT NULL,
  `Type` longtext NOT NULL,
  `Location` longtext NOT NULL,
  `AirportId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Facilities_AirportId` (`AirportId`),
  KEY `IX_Facilities_Id` (`Id`),
  CONSTRAINT `FK_Facilities_Airports_AirportId` FOREIGN KEY (`AirportId`) REFERENCES `Airports` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Facilities`
--

LOCK TABLES `Facilities` WRITE;
/*!40000 ALTER TABLE `Facilities` DISABLE KEYS */;
INSERT INTO `Facilities` VALUES
(1,'Almacén','Almacén','Dentro del aeropuerto',1),
(2,'Almacén','Almacén','Dentro del aeropuerto',2),
(3,'Almacén','Almacén','Dentro del aeropuerto',3);
/*!40000 ALTER TABLE `Facilities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Services`
--

DROP TABLE IF EXISTS `Services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Services` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` longtext NOT NULL,
  `FacilityId` int(11) NOT NULL,
  `Price` decimal(65,30) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Services_FacilityId` (`FacilityId`),
  KEY `IX_Services_Id` (`Id`),
  CONSTRAINT `FK_Services_Airplanes_FacilityId` FOREIGN KEY (`FacilityId`) REFERENCES `Airplanes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Services_Facilities_FacilityId` FOREIGN KEY (`FacilityId`) REFERENCES `Facilities` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Services`
--

LOCK TABLES `Services` WRITE;
/*!40000 ALTER TABLE `Services` DISABLE KEYS */;
INSERT INTO `Services` VALUES
(1,'Reparación',1,500.000000000000000000000000000000),
(2,'Reparación',2,500.000000000000000000000000000000),
(3,'Reparación',3,500.000000000000000000000000000000);
/*!40000 ALTER TABLE `Services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Users` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `FirstName` longtext NOT NULL,
  `Lastname` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `Password` longtext NOT NULL,
  `IsSuperAdmin` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES
('7a319ed4-671e-48f6-8f02-e7f0cb6a00bf','Rafael','Acosta','admin@gmail.com','admin123',0);
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES
('20240323204128_ChangeUserPK','8.0.2'),
('20240324163605_AddNewAirplaneFields','8.0.2'),
('20240325235944_CreateClientRatingEntity','8.0.2');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-25 21:54:35
