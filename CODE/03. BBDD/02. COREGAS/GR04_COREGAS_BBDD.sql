/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     27/5/2023 14:24:37                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURA') and o.name = 'FK_FACTURA_CLIENTE_F_CLIENTE')
alter table FACTURA
   drop constraint FK_FACTURA_CLIENTE_F_CLIENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FACTURA')
            and   name  = 'CLIENTE_FACTURA_FK'
            and   indid > 0
            and   indid < 255)
   drop index FACTURA.CLIENTE_FACTURA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURA')
            and   type = 'U')
   drop table FACTURA
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   CLI_CODIGO           bigint               identity,
   CLI_NOMBRE           varchar(50)          not null,
   CLI_APELLIDO         varchar(50)          not null,
   CLI_ID               varchar(16)          not null,
   CLI_EMAIL            varchar(50)          not null,
   CLI_TEL              varchar(10)          not null,
   CLI_DIRECCION        varchar(100)         not null,
   CLI_BORRADO          bit                  not null,
   constraint PK_CLIENTE primary key (CLI_CODIGO)
)
go

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA (
   FACT_CODIGO          bigint               identity,
   CLI_CODIGO           bigint               not null,
   FACT_NUMERO          varchar(50)          not null,
   FACT_FECHA           datetime             not null,
   FACT_MONTOTOTAL      decimal(10,2)        not null,
   FACT_BORRADO         bit                  not null,
   constraint PK_FACTURA primary key (FACT_CODIGO)
)
go

/*==============================================================*/
/* Index: CLIENTE_FACTURA_FK                                    */
/*==============================================================*/




create nonclustered index CLIENTE_FACTURA_FK on FACTURA (CLI_CODIGO ASC)
go

alter table FACTURA
   add constraint FK_FACTURA_CLIENTE_F_CLIENTE foreign key (CLI_CODIGO)
      references CLIENTE (CLI_CODIGO)
go

