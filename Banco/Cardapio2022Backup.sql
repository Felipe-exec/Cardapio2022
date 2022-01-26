-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.4.21-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para cardapio2022
CREATE DATABASE IF NOT EXISTS `cardapio2022` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `cardapio2022`;

-- Copiando estrutura para procedure cardapio2022.altera_lanche
DELIMITER //
CREATE PROCEDURE `altera_lanche`(
	IN `id` INT,
	IN `nomeproduto` VARCHAR(50),
	IN `acompanhamento` VARCHAR(50),
	IN `valor` FLOAT
)
BEGIN
UPDATE `cardapio2022`.`cardapio`
SET
`nomeproduto` = nomeproduto,
`acompanhamento` = acompanhamento,
`valor` = valor
WHERE `idproduto` = id;
END//
DELIMITER ;

-- Copiando estrutura para tabela cardapio2022.cardapio
CREATE TABLE IF NOT EXISTS `cardapio` (
  `idproduto` int(3) NOT NULL AUTO_INCREMENT,
  `nomeproduto` varchar(50) NOT NULL,
  `acompanhamento` varchar(50) DEFAULT NULL,
  `valor` float NOT NULL,
  PRIMARY KEY (`idproduto`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

-- Copiando dados para a tabela cardapio2022.cardapio: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `cardapio` DISABLE KEYS */;
INSERT INTO `cardapio` (`idproduto`, `nomeproduto`, `acompanhamento`, `valor`) VALUES
	(1, 'X-Burger', NULL, 14),
	(2, 'X-Salada', 'Batata Frita', 20),
	(3, 'X-Bacon', 'Batata Frita', 21.5),
	(4, 'X-Salada Bacon', 'Batata Frita Grande', 24.5),
	(5, 'X-Onion', 'Batata Frita', 22),
	(6, 'X-Tudo', 'Batata Frita Grande', 25.5),
	(7, 'Refrigerante Lata', NULL, 5),
	(8, 'Suco Natural', NULL, 4.5),
	(9, 'Batata Frita Supreme', 'Bacon e Cheddar', 15.5),
	(10, 'Onion Rings', 'Molho Especial', 17.5);
/*!40000 ALTER TABLE `cardapio` ENABLE KEYS */;

-- Copiando estrutura para procedure cardapio2022.deleta_lanche
DELIMITER //
CREATE PROCEDURE `deleta_lanche`(
	IN `idprodutos` INT
)
BEGIN
DELETE FROM `cardapio2022`.`cardapio`
WHERE cardapio.idproduto = idprodutos;
END//
DELIMITER ;

-- Copiando estrutura para procedure cardapio2022.insere_lanche
DELIMITER //
CREATE PROCEDURE `insere_lanche`(
	IN `nomeproduto` VARCHAR(50),
	IN `acompanhamento` VARCHAR(50),
	IN `valor` FLOAT
)
BEGIN
INSERT INTO cardapio2022.cardapio
(`nomeproduto`,
`acompanhamento`,
`valor`)
VALUES
(nomeproduto,
acompanhamento,
valor);
END//
DELIMITER ;

-- Copiando estrutura para procedure cardapio2022.lista_cardapio
DELIMITER //
CREATE PROCEDURE `lista_cardapio`()
BEGIN
	SELECT*FROM cardapio;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
