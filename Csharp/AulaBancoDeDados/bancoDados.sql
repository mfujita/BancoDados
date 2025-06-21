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


INSERT INTO bd1 (nome, endereco, bairro, cidade, telefone, sexo, nascimento, fumante, propriedades) VALUES
("Patasquio Pataqua","Rua Piedade, 480","Peri Peri","Limeira","19 914706 0408","M","1998-03-31",false,"Veículo|TV por assinatura|"),
("Tiburcio Coiote","Rua Florencio, 698","Jd. Arpoador","São Paulo","19 948123 4798","M","1976-10-27",true,"Internet|Tablet|"),
("Rozalino Ritalino","Rua Sem Fim, 746","Jd. Bonfa","São Paulo","19 953078 6398","M","1984-09-18",false,"Serviço de Streaming|Notebook|"),
("Guibaldo Antopi","Rua Encruzilhada, 94","Vila Maria Luiza","São Paulo","19 98980 4579","M","1983-05-01",true,"Computador desktop|"),
("Faganeto Rogueti","Rua da Lã, 854","Risca Faca","Santa Bárbara d´Oeste","19 97483 4129","M","1993-09-07",true,"Notebook|Internet|"),
("Astrogildo Samanco","Av. Tatuapé, 641","Lagoa Rasa","Sumaré","19 99568 6067","M","1995-01-20",true,"Veículo|Geladeira|Internet|"),
("Chica da Silva","Travessa Dona Lordes, 56","Pinheiros","Rio Claro","19 92348 6534","F","1984-09-18",true,"Geladeira|TV por assinatura|"),
("Juvenal Mosquera","Av. Principal, 699","Cracudos","São Paulo","19 95604 6873","M","1981-07-11",true,"Veículo|Internet|"),
("Margarida Viola","Rua da Felicidade, 583","Luz Vermelha","Piracicaba","19 96505 6537","F","1987-05-15",true,"Computador desktop|Notebook|"),
("Dafra Topata","Rua das Torres, 935","Sinal Amarelo","Piracicaba","19 98458 6864","F","1990-11-11",true,"TV por assinatura|Serviço de streaming|"),
("Raquelina Albra","Alameda Santidade, 88","Tiro Livre","Santa Bárbara d´Oeste","19 98546 6584","F","1994-10-03",true,"Serviço de streaming|"),
("Tormentina Mianto","Av. Europa, 637","Bandeiras","Sumaré","19 987898 0058","F","1986-12-27",true,"Internet|TV por assinatura|"),
("Fizema Igarro","Rua do Cipó, 864","Recreio","Americana","19 98752 5628","F","1982-02-17",false,"Tablet|Serviço de streaming|"),
("Bartina Lagame","Rua dos Calados, 478","Cruz Caiada","Piracicaba","19 98785 5650","F","1983-04-19",true,"Geladeira|Serviço de streaming|"),
("Cremilda Tutibona","Rua Mato Alto, 882","Fogo Cruzado","Americana","19 98135 3595","F","1988-05-17",false,"Computador desktop|Tablet|"),
("Pragilda Lunataque","Rua das Saúvas, 673","Rio Grande","Limeira","19 95681 1583","F","1981-02-15",false,"Veículo|Computador desktop|"),
("Piangela Alvira","Rua dos Moleques, 85","Socorro","São Paulo","19 98981 6067","F","1982-08-28",true,"Serviço de streaming|Tablet|"),
("Gatunilda Amiuna","Rua dos Anônimos, 195","Imperial","Santa Bárbara d´Oeste","19 98054 6304","F","1977-07-18",false,"Geladeira|Celular|"),
("Lartina Dumante","Rua do Sofrimento, 867","Cachoeira","Limeira","19 96536 6504","F","1994-06-22",false,"Veículo|Notebook|Geladeira|"),
("Ursula Cavasca","Rua Sem Asfalto, 69","Vila Necessitados","Americana","19 98351 7708","F","1992-08-14",false,"Notebook|Internet|"),
("Alairton Masquero", "Rua do Trigo, 15" , "Floresta Queimada", "Piracicaba", "19 97733 0584", "M", "1994-10-16", false, "Tablet|Computador desktop|");