CREATE TABLE IF NOT EXISTS `simple_project`.`users` (
  `id` INT PRIMARY KEY AUTO_INCREMENT,
  `nome` VARCHAR(200),
  `apelido` VARCHAR(200),
  `nascimento` DATE
);
