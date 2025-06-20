CREATE TABLE bd1 (
    id int PRIMARY KEY AUTO_INCREMENT,
    nome varchar(50),
    endereco varchar(50),
    bairro varchar(50),
	cidade varchar(50),
    telefone varchar(15),
    sexo char,
    nascimento date,
    fumante boolean,
    propriedades varchar(255)
);