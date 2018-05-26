
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2018 12:30:18
-- Generated from EDMX file: C:\Users\Дядя Яр\Desktop\ВШЭ Пермь\Курсовая 2017 - 2018\ControlSpecs 0.6\EnergoControl\EnergoControl\ModelDataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CounterStorage];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CounterSet'
CREATE TABLE [dbo].[CounterSet] (
    [IDCounter] smallint IDENTITY(1,1) NOT NULL,
    [Current] smallint  NOT NULL,
    [Voltage] smallint  NOT NULL,
    [CosFi] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDCounter] in table 'CounterSet'
ALTER TABLE [dbo].[CounterSet]
ADD CONSTRAINT [PK_CounterSet]
    PRIMARY KEY CLUSTERED ([IDCounter] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------