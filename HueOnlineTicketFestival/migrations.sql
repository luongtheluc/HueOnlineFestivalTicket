IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Artist] (
    [artistID] int NOT NULL,
    [artistName] nvarchar(50) NULL,
    CONSTRAINT [PK__Artist__4F4393674FFC7E98] PRIMARY KEY ([artistID])
);
GO

CREATE TABLE [Customer] (
    [customerID] int NOT NULL,
    [Name] nvarchar(50) NULL,
    [birthday] datetime NULL,
    [identityCardNumber] varchar(20) NULL,
    [paymentInfo] varchar(50) NULL,
    CONSTRAINT [PK__Customer__B611CB9D6901DB4F] PRIMARY KEY ([customerID])
);
GO

CREATE TABLE [EventPicture] (
    [eventImageID] int NOT NULL,
    [eventImageName] varchar(50) NULL,
    CONSTRAINT [PK__EventPic__53AF40C725D8B205] PRIMARY KEY ([eventImageID])
);
GO

CREATE TABLE [EventType] (
    [eventTypeID] int NOT NULL,
    [eventTypeName] nvarchar(50) NULL,
    CONSTRAINT [PK__EventTyp__04ACC49D4C713A12] PRIMARY KEY ([eventTypeID])
);
GO

CREATE TABLE [Location] (
    [locationID] int NOT NULL,
    [locationName] nvarchar(50) NULL,
    [description] nvarchar(50) NULL,
    CONSTRAINT [PK__Location__30646B0E23C3E791] PRIMARY KEY ([locationID])
);
GO

CREATE TABLE [Permission] (
    [permissionID] int NOT NULL IDENTITY,
    [permissionName] varchar(50) NOT NULL,
    [description] text NULL,
    CONSTRAINT [PK__Permissi__D821317CFEA6E40E] PRIMARY KEY ([permissionID])
);
GO

CREATE TABLE [Role] (
    [roleID] int NOT NULL IDENTITY,
    [roleName] varchar(50) NOT NULL,
    [description] text NULL,
    CONSTRAINT [PK__Role__CD98460A825BC1BF] PRIMARY KEY ([roleID])
);
GO

CREATE TABLE [TicketType] (
    [ticketTypeID] int NOT NULL,
    [ticketTypeName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK__TicketTy__D18F5C141E84C927] PRIMARY KEY ([ticketTypeID])
);
GO

CREATE TABLE [User] (
    [userID] int NOT NULL IDENTITY,
    [username] varchar(16) NOT NULL,
    [password] varchar(16) NULL,
    [userImage] varchar(50) NULL,
    [isActive] bit NULL,
    [address] nvarchar(100) NULL,
    [name] nvarchar(50) NULL,
    [phone] varchar(11) NULL,
    [create_at] datetime NULL,
    [update_at] datetime NULL,
    [email] varchar(50) NULL,
    CONSTRAINT [PK__User__CB9A1CDFA9A7852D] PRIMARY KEY ([userID])
);
GO

CREATE TABLE [Event] (
    [eventID] int NOT NULL,
    [eventTypeID] int NOT NULL,
    [eventName] nvarchar(50) NULL,
    [eventContent] text NULL,
    [create_at] datetime NULL,
    [update_at] datetime NULL,
    CONSTRAINT [PK__Event__2DC7BD694B27AC64] PRIMARY KEY ([eventID]),
    CONSTRAINT [FK__Event__eventType__0E6E26BF] FOREIGN KEY ([eventTypeID]) REFERENCES [EventType] ([eventTypeID])
);
GO

CREATE TABLE [Role_Permission] (
    [roleID] int NOT NULL,
    [permissionID] int NOT NULL,
    CONSTRAINT [PK__Role_Per__101A551D30C51342] PRIMARY KEY ([roleID], [permissionID]),
    CONSTRAINT [FK__Role_Perm__permi__04E4BC85] FOREIGN KEY ([permissionID]) REFERENCES [Permission] ([permissionID]),
    CONSTRAINT [FK__Role_Perm__roleI__02FC7413] FOREIGN KEY ([roleID]) REFERENCES [Role] ([roleID])
);
GO

CREATE TABLE [User_Role] (
    [userID] int NOT NULL,
    [roleID] int NOT NULL,
    CONSTRAINT [PK__User_Rol__774398BF5D9DB1FD] PRIMARY KEY ([userID], [roleID]),
    CONSTRAINT [FK__User_Role__roleI__03F0984C] FOREIGN KEY ([roleID]) REFERENCES [Role] ([roleID]),
    CONSTRAINT [FK__User_Role__userI__01142BA1] FOREIGN KEY ([userID]) REFERENCES [User] ([userID])
);
GO

CREATE TABLE [Artists_Invited] (
    [artistID] int NOT NULL,
    [eventID] int NOT NULL,
    CONSTRAINT [PK__Artists___CD9FE8B16AA3F331] PRIMARY KEY ([artistID], [eventID]),
    CONSTRAINT [FK__Artists_I__artis__0C85DE4D] FOREIGN KEY ([artistID]) REFERENCES [Artist] ([artistID]),
    CONSTRAINT [FK__Artists_I__event__09A971A2] FOREIGN KEY ([eventID]) REFERENCES [Event] ([eventID])
);
GO

CREATE TABLE [Event_Images] (
    [eventImageID] int NOT NULL,
    [eventID] int NOT NULL,
    CONSTRAINT [PK__Event_Im__D1733B11F198F4BF] PRIMARY KEY ([eventImageID], [eventID]),
    CONSTRAINT [FK__Event_Ima__event__06CD04F7] FOREIGN KEY ([eventID]) REFERENCES [Event] ([eventID]),
    CONSTRAINT [FK__Event_Ima__event__0F624AF8] FOREIGN KEY ([eventImageID]) REFERENCES [EventPicture] ([eventImageID])
);
GO

CREATE TABLE [Events_Locations] (
    [locationID] int NOT NULL,
    [eventID] int NOT NULL,
    [ticketQuantity] int NULL,
    [start_at] datetime NULL,
    [end_at] datetime NULL,
    [create_at] datetime NULL,
    [update_at] datetime NULL,
    CONSTRAINT [PK__Events_L__B2B810D83C06C84F] PRIMARY KEY ([locationID], [eventID]),
    CONSTRAINT [FK__Events_Lo__event__08B54D69] FOREIGN KEY ([eventID]) REFERENCES [Event] ([eventID]),
    CONSTRAINT [FK__Events_Lo__locat__0B91BA14] FOREIGN KEY ([locationID]) REFERENCES [Location] ([locationID])
);
GO

CREATE TABLE [News] (
    [newsID] int NOT NULL,
    [eventID] int NOT NULL,
    [newName] nvarchar(50) NULL,
    [newsContent] text NULL,
    [create_at] datetime NULL,
    [update_at] datetime NULL,
    CONSTRAINT [PK__News__5218047E8B72649A] PRIMARY KEY ([newsID]),
    CONSTRAINT [FK__News__eventID__07C12930] FOREIGN KEY ([eventID]) REFERENCES [Event] ([eventID])
);
GO

CREATE TABLE [Ticket] (
    [ticketID] int NOT NULL,
    [customerID] int NOT NULL,
    [userID] int NOT NULL,
    [locationID] int NOT NULL,
    [eventID] int NOT NULL,
    [ticketTypeID] int NOT NULL,
    [ticketName] nvarchar(50) NOT NULL,
    [status] bit NULL,
    [price] int NULL,
    [description] text NULL,
    [create_at] datetime NULL,
    [update_at] datetime NULL,
    CONSTRAINT [PK__Ticket__3333C670A87837E0] PRIMARY KEY ([ticketID]),
    CONSTRAINT [FK__Ticket__10566F31] FOREIGN KEY ([locationID], [eventID]) REFERENCES [Events_Locations] ([locationID], [eventID]),
    CONSTRAINT [FK__Ticket__customer__0D7A0286] FOREIGN KEY ([customerID]) REFERENCES [Customer] ([customerID]),
    CONSTRAINT [FK__Ticket__ticketTy__0A9D95DB] FOREIGN KEY ([ticketTypeID]) REFERENCES [TicketType] ([ticketTypeID]),
    CONSTRAINT [FK__Ticket__userID__02084FDA] FOREIGN KEY ([userID]) REFERENCES [User] ([userID])
);
GO

CREATE TABLE [TicketCheckin] (
    [ticketCheckinID] int NOT NULL,
    [ticketID] int NOT NULL,
    [create_at] datetime NULL,
    [update_at] datetime NULL,
    CONSTRAINT [PK__TicketCh__73CB0A27F00460EC] PRIMARY KEY ([ticketCheckinID]),
    CONSTRAINT [FK__TicketChe__ticke__05D8E0BE] FOREIGN KEY ([ticketID]) REFERENCES [Ticket] ([ticketID])
);
GO

CREATE INDEX [IX_Artists_Invited_eventID] ON [Artists_Invited] ([eventID]);
GO

CREATE INDEX [IX_Event_eventTypeID] ON [Event] ([eventTypeID]);
GO

CREATE INDEX [IX_Event_Images_eventID] ON [Event_Images] ([eventID]);
GO

CREATE INDEX [IX_Events_Locations_eventID] ON [Events_Locations] ([eventID]);
GO

CREATE INDEX [IX_News_eventID] ON [News] ([eventID]);
GO

CREATE UNIQUE INDEX [UQ__Permissi__70661EFC89C695A4] ON [Permission] ([permissionName]);
GO

CREATE UNIQUE INDEX [UQ__Permissi__D821317DDFB5AED9] ON [Permission] ([permissionID]);
GO

CREATE UNIQUE INDEX [UQ__Role__B19478616F34A9AF] ON [Role] ([roleName]);
GO

CREATE INDEX [IX_Role_Permission_permissionID] ON [Role_Permission] ([permissionID]);
GO

CREATE INDEX [IX_Ticket_customerID] ON [Ticket] ([customerID]);
GO

CREATE INDEX [IX_Ticket_locationID_eventID] ON [Ticket] ([locationID], [eventID]);
GO

CREATE INDEX [IX_Ticket_ticketTypeID] ON [Ticket] ([ticketTypeID]);
GO

CREATE INDEX [IX_Ticket_userID] ON [Ticket] ([userID]);
GO

CREATE UNIQUE INDEX [UQ__Ticket__3333C6713A5EBE5D] ON [Ticket] ([ticketID]);
GO

CREATE INDEX [IX_TicketCheckin_ticketID] ON [TicketCheckin] ([ticketID]);
GO

CREATE UNIQUE INDEX [UQ__TicketTy__D18F5C159DD69347] ON [TicketType] ([ticketTypeID]);
GO

CREATE UNIQUE INDEX [UQ__User__CB9A1CDEF66D391D] ON [User] ([userID]);
GO

CREATE UNIQUE INDEX [UQ__User__F3DBC57293F17A33] ON [User] ([username]);
GO

CREATE INDEX [IX_User_Role_roleID] ON [User_Role] ([roleID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230507055901_Init', N'7.0.5');
GO

COMMIT;
GO

