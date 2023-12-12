-- SQLite
-- Création de la table
CREATE TABLE IF NOT EXISTS Films (
    Id INTEGER PRIMARY KEY,
    Title TEXT,
    Director TEXT
);

-- Insertion de données dans la table
INSERT INTO Films (Title, Director) VALUES ('spiderman', 'SAM REMI');

-- Sélection des données de la table
SELECT * FROM Films;

-- Mise à jour des données dans la table
UPDATE Films SET Director = 'New Director' WHERE Id = 1;

-- Suppression des données dans la table
DELETE FROM Films WHERE Id = 1;

-- Suppression de la table
DROP TABLE IF EXISTS Films;

-- Création d'un index
CREATE INDEX IF NOT EXISTS idx_films_title ON Films (Title);