CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),    
);
GO

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),    
);
GO

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
);
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Name]                 NVARCHAR (256) NULL,
    [Email]                NVARCHAR (256) NULL,
    [StreetAddress]        NVARCHAR (256) NULL,
    [City]                 NVARCHAR (50)  NULL,
    [State]                NVARCHAR (20)  NULL,
    [Zip]                  NVARCHAR (20)  NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Address] (
    [Id]        INT         IDENTITY (1,1)    NOT NULL,
    [Street]    NVARCHAR(MAX)   NULL,
    [City]      NVARCHAR(MAX)   NULL,
    [State]     NVARCHAR(MAX)   NULL,
    [Zip]       NVARCHAR(MAX)   NULL,
    CONSTRAINT [PK_dbo.Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Clients] (
    [Id]            INT     IDENTITY(1,1)        NOT NULL,
    [Name]          NVARCHAR(256)   NOT NULL,
    [AddressID]     INT             NULL,
    [PhoneNumber]   NVARCHAR(150)   NULL,
    [Email]         NVARCHAR(MAX)   NULL,
    [UserId]        NVARCHAR(128)   NULL,
    CONSTRAINT [Pk_dbo.Client] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[ServiceTypes](
[Id]                INT     PRIMARY KEY IDENTITY(1,1)   NOT NULL,
[Name]              NVARCHAR(250)                       NOT NULL,
[Rate]              DECIMAL(8,2)                        NULL,
[UserId]            NVARCHAR(128)                       NULL
);
GO

CREATE TABLE [dbo].[ScheduleJob](
[Id]                INT     PRIMARY KEY IDENTITY (1,1)  NOT NULL,
[ServiceTypeID]     INT                                 NOT NULL,
[ClientID]          INT                                 NOT NULL,
[UserID]            NVARCHAR(128)                       NOT NULL,
[StartDate]         DATETIME                            NULL,
[EndDate]           DATETIME                            NULL,
[EstimatedDuration] INT                                 NULL,
[Notes]             NVARCHAR(MAX)                       NULL,
[Hours]             DECIMAL(4,2)                        NULL,
[Complete]          BIT     DEFAULT 0                   NOT NULL
);
GO

CREATE TABLE [dbo].[JobExpense] (
[Id]              INT     PRIMARY KEY IDENTITY (1,1)  NOT NULL,
[JobID]           INT                                 NOT NULL,
[ExpenseID]       INT                                 NULL,
);
GO

CREATE TABLE [dbo].[Expense](
[Id]        INT PRIMARY KEY IDENTITY (1,1)      NOT NULL,
[Name]      NVARCHAR(MAX)                       NOT NULL,
[Cost]      DECIMAL(8,2)                        NOT NULL,
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].[Address]([Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].Clients([Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].ServiceTypes([Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].ScheduleJob([Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].JobExpense([Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].Expense([Id] ASC);
GO

ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_dbo.Client_dbo.Address_ID] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ScheduleJob]
ADD CONSTRAINT [FK_dbo.ScheduleJob_dbo.ServiceTypes_ServiceTypeID] FOREIGN KEY ([ServiceTypeID]) REFERENCES [dbo].[ServiceTypes] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ScheduleJob]
ADD CONSTRAINT [FK_dbo.ScheduleJob_dbo.Clients_ClientID] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[JobExpense]
ADD CONSTRAINT [FK_dbo.JobExpense_dbo.Expense_ExpenseID] FOREIGN KEY ([ExpenseID]) REFERENCES [dbo].[Expense] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[JobExpense]
ADD CONSTRAINT [FK_dbo.JobExpense_dbo.ScheduleJob_JobID] FOREIGN KEY ([JobID]) REFERENCES [dbo].[ScheduleJob] ([Id]) ON DELETE CASCADE
GO