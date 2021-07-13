-- Drop Script
IF OBJECT_ID('[dbo].[ProductAttribute]') is not null
	DROP TABLE [dbo].[ProductAttribute]

IF OBJECT_ID('[dbo].[Product]') is not null
	DROP TABLE [dbo].[Product]

IF OBJECT_ID('[dbo].[AttributeType]') is not null
	DROP TABLE [dbo].[AttributeType]

-- Table Creation Script
CREATE TABLE [dbo].[AttributeType](
	[AttributeTypeId] [int] IDENTITY(1,1) NOT NULL ,
	[Name] [varchar](60) NULL,
	[IsArchived] [bit] NOT NULL default 0
 CONSTRAINT [PK_AttributeType] PRIMARY KEY CLUSTERED ([AttributeTypeId] ASC)) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL ,
	[Name] [varchar](60) NULL,
	[PricePerItem] [Decimal](18,2) NULL,
	[AverageCustomerRating] [Decimal](18,2) NULL,
	[IsArchived] [bit] NOT NULL default 0
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC)) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductAttribute] (
    [ProductAttributeId]           INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]            INT            NOT NULL,
    [AttributeTypeId]           INT            NOT NULL,
    [AttributeValue]             VARCHAR (150)            NOT NULL,
    CONSTRAINT [PK_ProductAttribute] PRIMARY KEY CLUSTERED ([ProductAttributeId] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Product_ProductAttrubite_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [FK_AttributeType_ProductAttrubite_AttributeTypeId] FOREIGN KEY ([AttributeTypeId]) REFERENCES [dbo].[AttributeType] ([AttributeTypeId])
);


-- Insert Script
Insert into AttributeType ([Name]) VALUES ('Color')
Insert into AttributeType ([Name]) VALUES ('Product Weight')
Insert into AttributeType ([Name]) VALUES ('Height')
Insert into AttributeType ([Name]) VALUES ('Material')
Insert into AttributeType ([Name]) VALUES ('Product Dimensions')
Insert into AttributeType ([Name]) VALUES ('Manufacturer')


Insert into Product ([Name],[PricePerItem],[AverageCustomerRating]) VALUES ('Product 1', 49.99, 5.5)
Insert into Product ([Name],[PricePerItem],[AverageCustomerRating]) VALUES ('Product 2 with no Attribute', 29.00, 4.8)
Insert into Product ([Name],[PricePerItem],[AverageCustomerRating]) VALUES ('Product 3', 37, 7.2)
Insert into Product ([Name],[PricePerItem],[AverageCustomerRating]) VALUES ('Product 4', 102, 9.5)
Insert into Product ([Name],[PricePerItem],[AverageCustomerRating]) VALUES ('Product 5', 99.99, 5.4)
Insert into Product ([Name],[PricePerItem],[AverageCustomerRating]) VALUES ('Product 6', 50, 2.5)


Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (1, 1, 'Red')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (1, 2, '15.2 ounces')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (1, 3, '9 inches')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (1, 4, 'Fabric')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (1, 6, 'ABC LTD')



Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (3, 1, 'Blue')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (3, 2, '19 ounces')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (3, 4, 'Fabric')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (3, 5, '1.5 x 11.5 x 9 inches')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (3, 6, 'Dell LTD')

Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (4, 1, 'Green')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (4, 2, '15.2 ounces')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (4, 3, '9 inches')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (4, 4, 'Fabric')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (4, 5, '1.5 x 11.5 x 9 inches')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (4, 6, 'ABC LTD')


Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (5, 1, 'Gold')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (5, 2, '5.1 ounces')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (5, 4, 'Steel')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (5, 5, '1.5 x 11.5 x 9 inches')
Insert into ProductAttribute ([ProductId],[AttributeTypeId],[AttributeValue]) VALUES (5, 6, 'Apple')


