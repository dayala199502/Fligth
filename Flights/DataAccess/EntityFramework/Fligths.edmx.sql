
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/19/2023 18:04:56
-- Generated from EDMX file: D:\Pruebas\Nueva carpeta\Flights\DataAccess\EntityFramework\Fligths.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Fligths];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TRANSPORT_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FLIGHT] DROP CONSTRAINT [FK_TRANSPORT_ID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FLIGHT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FLIGHT];
GO
IF OBJECT_ID(N'[dbo].[JOURNEY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JOURNEY];
GO
IF OBJECT_ID(N'[dbo].[TRANSPORT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TRANSPORT];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FLIGHT'
CREATE TABLE [dbo].[FLIGHT] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TRANSPORT_ID] int  NOT NULL,
    [ORIGIN] varchar(100)  NOT NULL,
    [DESTINATION] varchar(100)  NOT NULL,
    [PRICE] decimal(10,0)  NOT NULL
);
GO

-- Creating table 'JOURNEY'
CREATE TABLE [dbo].[JOURNEY] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ORIGIN] varchar(100)  NOT NULL,
    [DESTINATION] varchar(100)  NOT NULL,
    [PRICE] decimal(10,0)  NULL
);
GO

-- Creating table 'TRANSPORT'
CREATE TABLE [dbo].[TRANSPORT] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FLIGHTCARNER] varchar(100)  NOT NULL,
    [FLIGHTNUMBER] varchar(100)  NOT NULL
);
GO

-- Creating table 'JOURNEYFLIGHTSet'
CREATE TABLE [dbo].[JOURNEYFLIGHTSet] (
    [FLIGHTID] int  NOT NULL,
    [JOURNEYID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'FLIGHT'
ALTER TABLE [dbo].[FLIGHT]
ADD CONSTRAINT [PK_FLIGHT]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JOURNEY'
ALTER TABLE [dbo].[JOURNEY]
ADD CONSTRAINT [PK_JOURNEY]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TRANSPORT'
ALTER TABLE [dbo].[TRANSPORT]
ADD CONSTRAINT [PK_TRANSPORT]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [FLIGHTID], [JOURNEYID] in table 'JOURNEYFLIGHTSet'
ALTER TABLE [dbo].[JOURNEYFLIGHTSet]
ADD CONSTRAINT [PK_JOURNEYFLIGHTSet]
    PRIMARY KEY CLUSTERED ([FLIGHTID], [JOURNEYID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TRANSPORT_ID] in table 'FLIGHT'
ALTER TABLE [dbo].[FLIGHT]
ADD CONSTRAINT [FK_TRANSPORT_ID]
    FOREIGN KEY ([TRANSPORT_ID])
    REFERENCES [dbo].[TRANSPORT]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TRANSPORT_ID'
CREATE INDEX [IX_FK_TRANSPORT_ID]
ON [dbo].[FLIGHT]
    ([TRANSPORT_ID]);
GO

-- Creating foreign key on [FLIGHTID] in table 'JOURNEYFLIGHTSet'
ALTER TABLE [dbo].[JOURNEYFLIGHTSet]
ADD CONSTRAINT [FK_FLIGHTJOURNEYFLIGHT]
    FOREIGN KEY ([FLIGHTID])
    REFERENCES [dbo].[FLIGHT]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JOURNEYID] in table 'JOURNEYFLIGHTSet'
ALTER TABLE [dbo].[JOURNEYFLIGHTSet]
ADD CONSTRAINT [FK_JOURNEYJOURNEYFLIGHT]
    FOREIGN KEY ([JOURNEYID])
    REFERENCES [dbo].[JOURNEY]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JOURNEYJOURNEYFLIGHT'
CREATE INDEX [IX_FK_JOURNEYJOURNEYFLIGHT]
ON [dbo].[JOURNEYFLIGHTSet]
    ([JOURNEYID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------