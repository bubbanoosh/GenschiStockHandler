-- /*
USE GenschiStockHandler;
show tables;

SELECT JSON_TYPE('["a", "b", 1]');

select c.CategoryName as category, s.BusinessName as Supplier, p.*
from Products p
inner join Categories c on c.Id = p.CategoryId
inner join Suppliers s on s.Id = p.SupplierId;

select * from Products where Id = 2;

-- */

 /*
-- DROP database GenschiStockHandler;

CREATE DATABASE IF NOT EXISTS GenschiStockHandler
DEFAULT CHARACTER SET utf8
DEFAULT COLLATE utf8_general_ci;
SET default_storage_engine = INNODB;

USE GenschiStockHandler;




CREATE TABLE `GenschiStockHandler`.`Suppliers`(
    `Id` INT UNSIGNED NOT NULL auto_increment ,
    `BusinessName` VARCHAR(250) NOT NULL ,
    `Url` VARCHAR(250) NOT NULL ,
    `ContactName` VARCHAR(50) NULL ,
    `Phone` VARCHAR(50) NULL ,
    PRIMARY KEY(`Id`)
);

CREATE TABLE `GenschiStockHandler`.`Categories`(
    `Id` INT UNSIGNED NOT NULL auto_increment ,
    `CategoryName` VARCHAR(250) NOT NULL ,
    PRIMARY KEY(`Id`)
);


## Suppliers 
INSERT INTO `GenschiStockHandler`.`Suppliers`(`BusinessName`, `Url`, `ContactName`, `Phone`)
VALUES
    ('Amazing Glass', 'http://www.amazingglass.com', 'Jim Smith', '+61 02 56689959');

INSERT INTO `GenschiStockHandler`.`Suppliers`(`BusinessName`, `Url`, `ContactName`, `Phone`)
VALUES
    ('Dichroic dudes', 'http://www.dichro.com', 'Suzanne Williams', '+1 444 5559876');

INSERT INTO `GenschiStockHandler`.`Suppliers`(`BusinessName`, `Url`, `ContactName`, `Phone`)
VALUES
    ('Glass is us', 'http://www.glassisus.com', null, null);





## Types of electronic device
INSERT INTO `GenschiStockHandler`.`Categories`(`CategoryName`)
VALUES
    ('Tools');

INSERT INTO `GenschiStockHandler`.`Categories`(`CategoryName`)
VALUES
    ('Glass Rods');

INSERT INTO `GenschiStockHandler`.`Categories`(`CategoryName`)
VALUES
    ('Moulds');
    
  
  
  CREATE TABLE `GenschiStockHandler`.`Products`(
    `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
    `Name` VARCHAR(250) NOT NULL ,
    `CostPrice` DECIMAL(13, 2) NOT NULL,
    `Price` DECIMAL(13, 2) NOT NULL,
    `SupplierId` INT UNSIGNED NOT NULL ,
    `CategoryId` INT UNSIGNED NOT NULL ,
    `Attributes` JSON NOT NULL ,
    PRIMARY KEY(`Id`) ,
    INDEX `CategoryId`(`CategoryId` ASC) ,
    INDEX `SupplierId`(`SupplierId` ASC) ,
    CONSTRAINT `SupplierId` FOREIGN KEY(`SupplierId`) REFERENCES `GenschiStockHandler`.`Suppliers`(`Id`) ON DELETE RESTRICT ON UPDATE CASCADE ,
    CONSTRAINT `CategoryId` FOREIGN KEY(`CategoryId`) REFERENCES `GenschiStockHandler`.`Categories`(`Id`) ON DELETE RESTRICT ON UPDATE CASCADE
);


## Let's sell some cameras
INSERT INTO `GenschiStockHandler`.`Products`(
    `Name` ,
    `Price`,
    `CostPrice`,
    `SupplierId` ,
    `CategoryId` ,
    `Attributes`
)
VALUES(
    'Awesome Stainless Steel Spatula Set' ,
    15.00,
    60.00,
    1 ,
    1 ,
    JSON_MERGE(
        '{"description": "our stainless steel shaping tools with a total of 7 different shapes. Great for shaping glass beads and doing detail work."}' ,
        '{"material": ["stainless steel"]}' ,
        '{"dimensions": "4 inches"}' ,
        '{"pieces": "Packet of 4"}'
    )
);

INSERT INTO `GenschiStockHandler`.`Products`(
    `Name` ,
    `Price`,
    `CostPrice`,
    `SupplierId` ,
    `CategoryId` ,
    `Attributes`
)
VALUES(
    'Pointed Stainless Steel Tweezers' ,
    3.00,
    9.50,
    2 ,
    1 ,
    JSON_MERGE(
        JSON_OBJECT("description" , "7\" pointed tweezers. Stainless steel. Pointed non-serrated tip. Perfect for picking up or manipulating hot glass.") ,
        '{"material": ["stainless steel"]}' ,
        JSON_OBJECT("dimensions" , "7 inches") ,
        JSON_OBJECT("pieces" , "1")
    )
);

INSERT INTO `GenschiStockHandler`.`Products`(
    `Name` ,
    `Price`,
    `CostPrice`,
    `SupplierId` ,
    `CategoryId` ,
    `Attributes`
)
VALUES(
    'Graphite Paddle' ,
    5.00,
    55.00,
    2 ,
    1 ,
    JSON_MERGE(
        JSON_OBJECT("description" , "Perfect little graphite paddle for beadmakers.") ,
        '{"material": ["stainless steel"]}' ,
        '{"dimensions": "2.5\\" long X 1.5\\" X 3/8\\" thick"}' ,
        '{"pieces": "1"}'
    )
);

INSERT INTO `GenschiStockHandler`.`Products`(
    `Name` ,
    `Price`,
    `CostPrice`,
    `SupplierId` ,
    `CategoryId` ,
    `Attributes`
)
VALUES(
    'Small Brass Shaping Tool' ,
    1.50,
    20.00,
    3 ,
    1 ,
    JSON_MERGE(
        JSON_OBJECT("description" , "A small brass shaping tool, great for getting your hot glass to move. Several different angles make this a very useful tool.") ,
        '{"material": ["stainless steel", "graphite"]}' ,
        JSON_OBJECT("dimensions" , "7 inches") ,
        JSON_OBJECT("pieces" , "1")
    )
);

INSERT INTO `GenschiStockHandler`.`Products`(
    `Name` ,
    `Price`,
    `CostPrice`,
    `SupplierId` ,
    `CategoryId` ,
    `Attributes`
)
VALUES(
    'Bent Tungsten Rake' ,
    18.00,
    79.00,
    3 ,
    1 ,
    JSON_MERGE(
        '{"description": "Bent Tungsten rake. Sharply pointed 3/32\\" diameter tungsten poker with a 90 degree bend near the end. Mounted in a wooden handle. The perfect tool for feathering or raking."}' ,
        '{"material": ["tungsten steel", "wood"]}' ,
        '{"dimensions": "3/32 inches"}' ,
        '{"pieces": "1"}'
    )
);
-- */
