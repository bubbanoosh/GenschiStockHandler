--  /*
USE GenschiStockHandler;
show tables;

SELECT JSON_TYPE('["a", "b", 1]');

select c.category_name as category, s.business_name as supplier, p.*
from products p
inner join categories c on c.id = p.category_id
inner join suppliers s on s.id = p.supplier_id;

-- */

 /*
-- DROP database GenschiStockHandler;

CREATE DATABASE IF NOT EXISTS GenschiStockHandler
DEFAULT CHARACTER SET utf8
DEFAULT COLLATE utf8_general_ci;
SET default_storage_engine = INNODB;

USE GenschiStockHandler;




CREATE TABLE `GenschiStockHandler`.`suppliers`(
    `id` INT UNSIGNED NOT NULL auto_increment ,
    `business_name` VARCHAR(250) NOT NULL ,
    `url` VARCHAR(250) NOT NULL ,
    `contact_name` VARCHAR(50) NULL ,
    `phone` VARCHAR(50) NULL ,
    PRIMARY KEY(`id`)
);

CREATE TABLE `GenschiStockHandler`.`categories`(
    `id` INT UNSIGNED NOT NULL auto_increment ,
    `category_name` VARCHAR(250) NOT NULL ,
    PRIMARY KEY(`id`)
);


## suppliers 
INSERT INTO `GenschiStockHandler`.`suppliers`(`business_name`, `url`, `contact_name`, `phone`)
VALUES
    ('Amazing Glass', 'http://www.amazingglass.com', 'Jim Smith', '+61 02 56689959');

INSERT INTO `GenschiStockHandler`.`suppliers`(`business_name`, `url`, `contact_name`, `phone`)
VALUES
    ('Dichroic dudes', 'http://www.dichro.com', 'Suzanne Williams', '+1 444 5559876');

INSERT INTO `GenschiStockHandler`.`suppliers`(`business_name`, `url`, `contact_name`, `phone`)
VALUES
    ('Glass is us', 'http://www.glassisus.com', null, null);





## Types of electronic device
INSERT INTO `GenschiStockHandler`.`categories`(`category_name`)
VALUES
    ('Tools');

INSERT INTO `GenschiStockHandler`.`categories`(`category_name`)
VALUES
    ('Glass Rods');

INSERT INTO `GenschiStockHandler`.`categories`(`category_name`)
VALUES
    ('Moulds');
    
  
  
  CREATE TABLE `GenschiStockHandler`.`products`(
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
    `name` VARCHAR(250) NOT NULL ,
    `cost_price` DECIMAL(13, 2) NOT NULL,
    `price` DECIMAL(13, 2) NOT NULL,
    `supplier_id` INT UNSIGNED NOT NULL ,
    `category_id` INT UNSIGNED NOT NULL ,
    `attributes` JSON NOT NULL ,
    PRIMARY KEY(`id`) ,
    INDEX `CATEGORY_ID`(`category_id` ASC) ,
    INDEX `supplier_id`(`supplier_id` ASC) ,
    CONSTRAINT `supplier_id` FOREIGN KEY(`supplier_id`) REFERENCES `GenschiStockHandler`.`suppliers`(`id`) ON DELETE RESTRICT ON UPDATE CASCADE ,
    CONSTRAINT `category_id` FOREIGN KEY(`category_id`) REFERENCES `GenschiStockHandler`.`categories`(`id`) ON DELETE RESTRICT ON UPDATE CASCADE
);


## Let's sell some cameras
INSERT INTO `GenschiStockHandler`.`products`(
    `name` ,
    `price`,
    `cost_price`,
    `supplier_id` ,
    `category_id` ,
    `attributes`
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

INSERT INTO `GenschiStockHandler`.`products`(
    `name` ,
    `price`,
    `cost_price`,
    `supplier_id` ,
    `category_id` ,
    `attributes`
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

INSERT INTO `GenschiStockHandler`.`products`(
    `name` ,
    `price`,
    `cost_price`,
    `supplier_id` ,
    `category_id` ,
    `attributes`
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

INSERT INTO `GenschiStockHandler`.`products`(
    `name` ,
    `price`,
    `cost_price`,
    `supplier_id` ,
    `category_id` ,
    `attributes`
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

INSERT INTO `GenschiStockHandler`.`products`(
    `name` ,
    `price`,
    `cost_price`,
    `supplier_id` ,
    `category_id` ,
    `attributes`
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
