CREATE DATABASE biblioteca_teste

CREATE TABLE biblioteca(
  ID samllint NOT NULL DEFAULT '1899',
  TITULO varchar(64),
  AUTOR varchar(64),
  ALUGADO smallint  NOT NULL DEFAULT '0',
  CONSTRAINT biblioteca PRIMARY KEY  (ID,TITULO,AUTOR)
);

CREATE TABLE users(
     ID samllint NOT NULL DEFAULT '0',
     USER varchar(64),
     PASSWORD varchar(64),
	 CONSTRAINT users PRIMARY KEY  (ID,USER)
);
