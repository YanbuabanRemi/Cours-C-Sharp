// Sql est un langage de programation standardisé pour les bases de données
- Ouvrir un server Sql :

// Ouvrir le PowerShell (MAJ + Click Droit)
// sqllocaldb c nomDuServer
// sqllocaldb s nomDuServer

// Se rendre dans le dossier dans Visual Studio
// -> Explorateur de server
// -> Microsoft Sql Server
// Connexion à la base de donnée
// Nom du server : (localdb)\nomDuServer

// Sql est un langage basé sur trois principes :

- Le langage de définition

creer une table:
// Click droit sur le server dans l'explorateur 
// -> new requete
// CREATE TABLE xxx (
// variable valeur(nbMax) NOT NULL PRIMARY KEY
// (PRIMARY KEY permet de donner une valeur unique)
// variable2 valeur 
// id INT NOT NULL PRIMARY KEY IDENTITY(10, 1)
// (Identity(10, 1) => auto - incremente l'id de 1 en commençant par le chiffre 10)
// )

supprimer une table:
// DROP TABLE xxx

modifier une table:
// (en ajoutant)
ALTER TABLE xxx ADD variable valeur....
// (en supprimant)
ALTER TABLE xxx DROP COLUMN variable

- Le langage de Manipulation

//insertion de données
INSERT INTO xxx (variable, variable1, variable2) VALUES (donnée, donnée1, donnée2)

//mise à jour des données
UPDATE xxx set variable = donnée3, variable2 = donnée4 WHERE variable1 = donnée1

//supression de données
DELETE FROM xxx WHERE variable1 > donnnée10

- Le langage de Selection

// selectionne toute la table
SELECT * FROM xxx

// selectionne les colonnes nom et prenom de la table xxx et revoie les données avec l'intituler n et p
SELECT nom as n, prenom as p FROM xxx

// selectionne que les id supérieur à 2
SELECT nom FROM xxx WHERE id>2