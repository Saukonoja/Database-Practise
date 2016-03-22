create table vuosi
(
  avain integer auto_increment not null,
  vuosi int not null,

  constraint PK_vuosi_avain Primary Key (avain),
  constraint UQ_vuosi_vuosi Unique (vuosi)
);

create table maa
(
  avain int auto_increment not null,
  isoalpha2 nvarchar(2) not null,
  nimi nvarchar(50) not null,
  
  constraint PK_maa_avain Primary Key (avain),
  constraint UQ_maa_isoalpha2 Unique (isoalpha2),
  constraint UQ_maa_nimi Unique (nimi)
);

create table yhtio
(
  avain integer auto_increment not null,
  nimi nvarchar(50) not null,
  maa_avain int not null,
  vuosi_avain int not null,

  constraint PK_yhtio_avain Primary Key (avain),
  constraint UQ_yhtio_nimi Unique (nimi),
  constraint FK_yhtio_maa_avain foreign key (maa_avain) references maa(avain),
  constraint FK_yhtio_vuosi_avain foreign key (vuosi_avain) references vuosi(avain)
);

create table esittaja
(
  avain int auto_increment not null,
  nimi nvarchar(50) not null,
  maa_avain int not null,
  vuosi_avain int not null,
  
  constraint PK_esittaja_avain primary key (avain),
  constraint UQ_esittaja_nimi Unique (nimi),
  constraint FK_esittaja_maa_avain foreign key (maa_avain) references maa(avain), 
  constraint FK_esittaja_vuosi_avain foreign key (vuosi_avain) references vuosi(avain)
);

create table genre
(
  avain int auto_increment not null,
  nimi nvarchar(50) not null,
  
  constraint PK_genre_avain Primary Key (avain),
  constraint UQ_genre_nimi Unique (nimi)
)

create table kappale
(
  avain int auto_increment not null,
  nimi nvarchar(50) not null,
  kesto int not null,
  esittaja_avain int not null,
  vuosi_avain int not null,
  tubepath nvarchar null,

  constraint PK_kappale_avain Primary Key (avain),
  constraint UQ_kappale_nimi Unique (nimi),
  constraint FK_kappale_esittaja_avain foreign key (esittaja_avain) references esittaja(avain),
  constraint FK_kappale_vuosi_avain foreign key (vuosi_avain) references vuosi(avain)
);

create table kappale_genre
(
  avain int auto_increment not null,
  kappale_avain int null,
  genre_avain int null,
  
  constraint PK_kappale_genre_avain Primary Key (avain),
  constraint UQ_kappale_genre_kappale_avain Unique (kappale_avain, genre_avain),
  constraint FK_kappale_genre_kappale_avain foreign key (kappale_avain) references kappale(avain),
  constraint FK_kappale_genre_genre_avain foreign key (genre_avain) references genre(avain)
);

create table cd
(
  avain int auto_increment not null,
  nimi nvarchar(50) not null,
  yhtio_avain int null,
  vuosi_avain int not null,
  
  constraint PK_cd_avain primary key (avain),
  constraint UQ_cd_nimi Unique (nimi),
  constraint FK_cd_yhtio_avain foreign key (yhtio_avain) references yhtio(avain),
  constraint FK_cd_vuosi_avain foreign key (vuosi_avain) references vuosi(avain)
);

create table cd_kappale
(
  avain int auto_increment not null,
  cd_avain int not null,
  kappale_avain int not null,
  
  constraint PK_cd_kappale_avain Primary Key (avain),
  constraint UQ_cd_kappale_cd_avain Unique (cd_avain, kappale_avain),
  constraint FK_cd_kappale_cd_avain foreign key (cd_avain) references cd(avain),
  constraint FK_cd_kappale_kappale_avain foreign key (kappale_avain) references kappale(avain)
);

create table cd_esittaja
(
  avain int auto_increment not null,
  cd_avain int null,
  esittaja_avain int null,
  
  constraint PK_kappale_genre_avain Primary Key (avain),
  constraint UQ_cd_esittaja_cd_avain Unique (cd_avain, esittaja_avain),
  constraint FK_cd_esittaja_cd_avain foreign key (cd_avain) references cd(avain),
  constraint FK_cd_esittaja_esittaja_avain foreign key (esittaja_avain) references esittaja(avain)
);

create table user
(
  avain int auto_increment not null,
  tunnus nvarchar(20) not null,
  salasana nvarchar(20) not null,
  tyyppi boolean not null,

  constraint PK_user_avain Primary Key (avain),
  constraint UQ_user_tunnus Unique(tunnus)
);