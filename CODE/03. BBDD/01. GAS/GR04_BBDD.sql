/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     27/5/2023 14:23:58                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   USU_CODIGO           bigint               identity,
   USU_NOMBRE           varchar(50)          not null,
   USU_APELLIDO         varchar(50)          not null,
   USU_CEDULA           varchar(10)          not null,
   USU_DIRECCION        varchar(100)         not null,
   USU_TELEFONO         varchar(20)          not null,
   USU_EMAIL            varchar(100)         not null,
   USU_USUARIO          varchar(100)         not null,
   USU_PASSWORD         varchar(100)         not null,
   USU_ISADMIN          bit                  not null,
   constraint PK_USUARIO primary key (USU_CODIGO)
)
go

