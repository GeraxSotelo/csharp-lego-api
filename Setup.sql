-- CREATE TABLE bricks (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   price DECIMAL(5, 2) NOT NULL,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE bricksets (
--   id int NOT NULL AUTO_INCREMENT,
--   brickId int NOT NULL,
--   setId int NOT NULL,
--   PRIMARY KEY(id),

--   FOREIGN KEY (brickId) REFERENCES bricks(id) ON DELETE CASCADE,

--   FOREIGN KEY (setId) 
--     REFERENCES bsets(id) 
--     ON DELETE CASCADE
-- )