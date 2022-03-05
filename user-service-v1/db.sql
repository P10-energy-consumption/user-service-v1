create table pets(
    ID int NOT NULL PRIMARY KEY,
    Name varchar(200) not null,
    Category int not null,
    Status int not null,
    Tags varchar(200),
    Created datetime not null,
    CreatedBy varchar(200) not null,
    Modified datetime,
    ModifiedBy varchar(200),
    Deleted datetime,
    DeletedBy varchar(200),
    IsDelete bit default 0 not null
);

create table photos(
    ID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    PetId int not null,
    Url varchar(200) not null,
    MetaData varchar(200) not null,
    Created DATETIME not null,
    CreatedBy varchar(200) not null,
    Modified DATETIME,
    ModifiedBy varchar(200),
    Deleted DATETIME,
    DeletedBy varchar(200),
    IsDelete bit default 0 not null
);

create table orders(
    ID int NOT NULL PRIMARY KEY,
    PetId int not null,
    Quantity int not null,
    ShipDate DATETIME not null,
    Status int not null,
    Complete bit not null,
    Created DATETIME not null,
    CreatedBy varchar(200) not null,
    Modified DATETIME,
    ModifiedBy varchar(200),
    Deleted DATETIME,
    DeletedBy varchar(200),
    IsDelete bit default 0 not null
);

create table users(
   ID int NOT NULL PRIMARY KEY,
   UserName varchar(200),
   FirstName varchar(200),
   LastName varchar(200),
   Email varchar(200),
   PasswordHash varchar(200),
   Salt varchar(200),
   Phone varchar(200),
   Status int not null,
   Created DATETIME not null,
   CreatedBy varchar(200) not null,
   Modified DATETIME,
   ModifiedBy varchar(200),
   Deleted DATETIME,
   DeletedBy varchar(200),
   IsDelete bit default 0 not null
);
