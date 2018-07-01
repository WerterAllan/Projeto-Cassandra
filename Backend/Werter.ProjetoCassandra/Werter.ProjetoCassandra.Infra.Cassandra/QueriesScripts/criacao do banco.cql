DROP KEYSPACE if exists WerterStore;

CREATE KEYSPACE IF NOT EXISTS WerterStore  
WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 3 };

USE WerterStore;

drop table if exists produto;



CREATE TABLE Produto (
  Id UUID,
  Titulo TEXT,
  Descricao TEXT,
  Preco DECIMAL,
  QuantidadeEmEstoque INT,
  PRIMARY KEY ( (Id), Titulo )
);

drop table if exists cliente;

CREATE TABLE cliente (
  id UUID,
  nome TEXT,
  email TEXT,
  documento TEXT,
  PRIMARY KEY ( (id), email, documento)
);


drop table if exists pedido;

CREATE TABLE pedido (
  id UUID,
  numero_pedido TEXT,
  valor_total DECIMAL,
  cliente_id UUID,
  data_do_pedido TEXT,
  PRIMARY KEY ( (id), numero_pedido, cliente_id )
);

drop table if exists pedido_item;

CREATE TABLE pedido_item (
  id UUID,
  pedido_id UUID,
  produto_id UUID,
  quantidade INT,  
  PRIMARY KEY ( (id), pedido_id )
);


