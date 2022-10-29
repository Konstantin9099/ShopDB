-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: shop
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `avtorizacia`
--

DROP TABLE IF EXISTS `avtorizacia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avtorizacia` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `login` varchar(10) NOT NULL,
  `password` varchar(10) NOT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avtorizacia`
--

LOCK TABLES `avtorizacia` WRITE;
/*!40000 ALTER TABLE `avtorizacia` DISABLE KEYS */;
INSERT INTO `avtorizacia` VALUES (1,'1111','1111'),(2,'3333','3333'),(3,'222','222');
/*!40000 ALTER TABLE `avtorizacia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart`
--

DROP TABLE IF EXISTS `cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart` (
  `id_order` int DEFAULT NULL,
  `id_cloth` int DEFAULT NULL,
  KEY `fk_cart_orders` (`id_order`),
  KEY `fk_cart_clothing` (`id_cloth`),
  CONSTRAINT `fk_cart_clothing` FOREIGN KEY (`id_cloth`) REFERENCES `clothing` (`id_cloth`),
  CONSTRAINT `fk_cart_orders` FOREIGN KEY (`id_order`) REFERENCES `orders` (`id_order`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart`
--

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;
/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clothing`
--

DROP TABLE IF EXISTS `clothing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clothing` (
  `id_cloth` int NOT NULL AUTO_INCREMENT,
  `name_cloth` varchar(50) NOT NULL,
  `id_type` int DEFAULT NULL,
  `id_sex` int DEFAULT NULL,
  `id_seasons` int DEFAULT NULL,
  `price` double(7,2) NOT NULL,
  PRIMARY KEY (`id_cloth`),
  KEY `fk_clothing_types` (`id_type`),
  KEY `fk_clothing_sex` (`id_sex`),
  KEY `fk_clothing_seasons` (`id_seasons`),
  CONSTRAINT `fk_clothing_seasons` FOREIGN KEY (`id_seasons`) REFERENCES `seasons` (`id_seasons`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_clothing_sex` FOREIGN KEY (`id_sex`) REFERENCES `sex` (`id_sex`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_clothing_types` FOREIGN KEY (`id_type`) REFERENCES `types` (`id_type`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clothing`
--

LOCK TABLES `clothing` WRITE;
/*!40000 ALTER TABLE `clothing` DISABLE KEYS */;
INSERT INTO `clothing` VALUES (9,'Пальто',16,2,1,8000.00),(10,'Куртка',16,1,3,5500.00),(11,'Костюм',20,1,3,7500.00),(12,'Халат',19,2,3,2500.00),(13,'Майка',18,1,2,900.00),(14,'Брюки',17,1,3,2500.00),(15,'Юбка',17,2,3,1850.00),(16,'Футболка',20,1,2,1550.00),(17,'Носки',17,1,3,100.00),(18,'Шляпа',21,2,2,1500.00),(19,'Бейсболка',21,1,3,1500.00),(20,'Трусы пляжные',18,1,2,900.00),(22,'Шляпа',21,1,3,1500.00),(23,'Легинсы',20,2,2,1500.00),(24,'Жилет',16,1,3,2300.00);
/*!40000 ALTER TABLE `clothing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `id_order` int NOT NULL AUTO_INCREMENT,
  `date_order` date NOT NULL,
  `id_worker` int DEFAULT NULL,
  `final_price` double(8,2) NOT NULL,
  PRIMARY KEY (`id_order`),
  KEY `fk_orders_workers` (`id_worker`),
  CONSTRAINT `fk_orders_workers` FOREIGN KEY (`id_worker`) REFERENCES `workers` (`id_worker`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (3,'2022-10-25',5,10100.00),(4,'2022-10-25',5,7500.00),(5,'2022-10-27',5,9500.00),(6,'2022-10-27',3,4350.00),(7,'2022-10-28',4,4400.00),(8,'2022-10-25',4,13450.00),(9,'2022-10-30',3,13100.00),(10,'2022-10-30',3,2400.00);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `id_position` int NOT NULL AUTO_INCREMENT,
  `name_position` varchar(25) NOT NULL,
  `salary` double(7,2) NOT NULL,
  PRIMARY KEY (`id_position`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'Директор',50000.00),(2,'Товаровед',40000.00),(3,'Старший продавец',30000.00),(4,'Продавец',25000.00),(5,'Консультант',21000.00),(6,'Продавец-стажер',18000.00);
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seasons`
--

DROP TABLE IF EXISTS `seasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seasons` (
  `id_seasons` int NOT NULL AUTO_INCREMENT,
  `name_seasons` varchar(20) NOT NULL,
  PRIMARY KEY (`id_seasons`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seasons`
--

LOCK TABLES `seasons` WRITE;
/*!40000 ALTER TABLE `seasons` DISABLE KEYS */;
INSERT INTO `seasons` VALUES (1,'Зима'),(2,'Лето'),(3,'Весна/Осень');
/*!40000 ALTER TABLE `seasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sex`
--

DROP TABLE IF EXISTS `sex`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sex` (
  `id_sex` int NOT NULL AUTO_INCREMENT,
  `name_sex` varchar(20) NOT NULL,
  PRIMARY KEY (`id_sex`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sex`
--

LOCK TABLES `sex` WRITE;
/*!40000 ALTER TABLE `sex` DISABLE KEYS */;
INSERT INTO `sex` VALUES (1,'Мужской'),(2,'Женский');
/*!40000 ALTER TABLE `sex` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `types`
--

DROP TABLE IF EXISTS `types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `types` (
  `id_type` int NOT NULL AUTO_INCREMENT,
  `name_type` varchar(20) NOT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `types`
--

LOCK TABLES `types` WRITE;
/*!40000 ALTER TABLE `types` DISABLE KEYS */;
INSERT INTO `types` VALUES (16,'Верхняя одежда'),(17,'Легкая одежда'),(18,'Нижнее белье'),(19,'Домашняя одежда'),(20,'Спортивная одежда'),(21,'Головные уборы');
/*!40000 ALTER TABLE `types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workers` (
  `id_worker` int NOT NULL AUTO_INCREMENT,
  `fio_worker` varchar(100) NOT NULL,
  `id_posistion` int NOT NULL,
  `phone_number` varchar(18) NOT NULL,
  PRIMARY KEY (`id_worker`),
  KEY `fk_workers_positions` (`id_posistion`),
  CONSTRAINT `fk_workers_positions` FOREIGN KEY (`id_posistion`) REFERENCES `positions` (`id_position`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers` VALUES (1,'Зимина Алиса Антоновна',1,'+7 (931) 648-72-25'),(2,'Кулакова Анастасия Евгеньевна',2,'+7 (927) 801-19-67'),(3,'Гончарова Оксана Витальевна',3,'+7 (955) 893-65-25'),(4,'Румянцева Ольга Анатольевна',4,'+7 (906) 992-96-98'),(5,'Сергеева Полина Андреевна',5,'+7 (988) 205-26-58'),(6,'Харитонова Наталья Олеговна',5,'+7 (965) 650-81-71'),(7,'Морозова Виктория Георгиевна',6,'+7 (976) 695-29-14'),(9,'Богданова Екатерина Андреевна',6,'+7 (933) 361-55-54');
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-30  4:00:40
