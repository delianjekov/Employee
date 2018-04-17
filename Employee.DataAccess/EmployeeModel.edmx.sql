SET QUOTED_IDENTIFIER OFF;
GO
USE [Employee];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Employee__TypeId__145C0A3F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK__Employee__TypeId__145C0A3F];
GO
IF OBJECT_ID(N'[dbo].[FK__EmployeeS__Emplo__1920BF5C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeSchedule] DROP CONSTRAINT [FK__EmployeeS__Emplo__1920BF5C];
GO
IF OBJECT_ID(N'[dbo].[FK__EmployeeS__Store__1A14E395]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeSchedule] DROP CONSTRAINT [FK__EmployeeS__Store__1A14E395];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[EmployeeSchedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSchedule];
GO
IF OBJECT_ID(N'[dbo].[EmployeeType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeType];
GO
IF OBJECT_ID(N'[dbo].[Store]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Store];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeId] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Surname] varchar(50)  NOT NULL,
    [Age] int  NOT NULL
);
GO

-- Creating table 'EmployeeSchedules'
CREATE TABLE [dbo].[EmployeeSchedules] (
    [EmployeeId] int  NOT NULL,
    [StoreId] int  NOT NULL,
    [StartDate] datetime  NOT NULL
);
GO

-- Creating table 'EmployeeTypes'
CREATE TABLE [dbo].[EmployeeTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] varchar(50)  NOT NULL,
    [Salary] int  NOT NULL
);
GO

-- Creating table 'Stores'
CREATE TABLE [dbo].[Stores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [AddressLine1] varchar(50)  NOT NULL,
    [AddressLine2] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EmployeeId], [StoreId] in table 'EmployeeSchedules'
ALTER TABLE [dbo].[EmployeeSchedules]
ADD CONSTRAINT [PK_EmployeeSchedules]
    PRIMARY KEY CLUSTERED ([EmployeeId], [StoreId] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeTypes'
ALTER TABLE [dbo].[EmployeeTypes]
ADD CONSTRAINT [PK_EmployeeTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stores'
ALTER TABLE [dbo].[Stores]
ADD CONSTRAINT [PK_Stores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK__Employee__TypeId__145C0A3F]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[EmployeeTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Employee__TypeId__145C0A3F'
CREATE INDEX [IX_FK__Employee__TypeId__145C0A3F]
ON [dbo].[Employees]
    ([TypeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'EmployeeSchedules'
ALTER TABLE [dbo].[EmployeeSchedules]
ADD CONSTRAINT [FK__EmployeeS__Emplo__1920BF5C]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StoreId] in table 'EmployeeSchedules'
ALTER TABLE [dbo].[EmployeeSchedules]
ADD CONSTRAINT [FK__EmployeeS__Store__1A14E395]
    FOREIGN KEY ([StoreId])
    REFERENCES [dbo].[Stores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__EmployeeS__Store__1A14E395'
CREATE INDEX [IX_FK__EmployeeS__Store__1A14E395]
ON [dbo].[EmployeeSchedules]
    ([StoreId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------