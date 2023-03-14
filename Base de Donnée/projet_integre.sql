-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 20 jan. 2023 à 09:58
-- Version du serveur : 8.0.31
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `projet_integre`
--

-- --------------------------------------------------------

--
-- Structure de la table `boitesvitesse`
--

DROP TABLE IF EXISTS `boitesvitesse`;
CREATE TABLE IF NOT EXISTS `boitesvitesse` (
  `idBoiteVitesse` int NOT NULL COMMENT 'Identifiant unique pour chaque boite de vitesse',
  `modele` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Nom du modèle de la boite de vitesse',
  `type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Type de boite de vitesse',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Description de la boite de vitesse',
  `prix` int DEFAULT NULL COMMENT 'Prix de la boite de vitesse',
  PRIMARY KEY (`idBoiteVitesse`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `carrosseries`
--

DROP TABLE IF EXISTS `carrosseries`;
CREATE TABLE IF NOT EXISTS `carrosseries` (
  `idCarrosserie` int NOT NULL COMMENT 'Identifiant unique pour chaque carrosserie',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `modele` varchar(255) DEFAULT NULL COMMENT 'Modèle de la carrosserie',
  `couleur` varchar(255) DEFAULT NULL COMMENT 'Couleur de la carrosserie',
  `materiaux` varchar(255) DEFAULT NULL COMMENT 'Matériaux de la carrosserie',
  `prix` int DEFAULT NULL COMMENT 'Prix de la carrosserie',
  PRIMARY KEY (`idCarrosserie`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `idClient` int NOT NULL AUTO_INCREMENT COMMENT 'Identifiant unique pour chaque client',
  `nomEntreprise` varchar(255) DEFAULT NULL COMMENT 'Nom de l''entreprise cliente',
  `mail` varchar(255) DEFAULT NULL COMMENT 'Adresse mail du client',
  `dateInscription` date DEFAULT NULL COMMENT 'Date d''inscription du client',
  `finAbonnement` date DEFAULT NULL COMMENT 'Date de fin d''abonnement du client',
  `Mdp` varchar(255) DEFAULT NULL COMMENT 'Mdp de l''entreprise cliente',
  PRIMARY KEY (`idClient`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `client_environnement`
--

DROP TABLE IF EXISTS `client_environnement`;
CREATE TABLE IF NOT EXISTS `client_environnement` (
  `idClient` int NOT NULL COMMENT 'ID du client qui a créer l''environnement',
  `idEnvironnement` int NOT NULL COMMENT 'ID de l''environnement qu''a créer le client',
  PRIMARY KEY (`idClient`,`idEnvironnement`),
  KEY `idEnvironnement` (`idEnvironnement`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `client_simulation`
--

DROP TABLE IF EXISTS `client_simulation`;
CREATE TABLE IF NOT EXISTS `client_simulation` (
  `idClient` int NOT NULL COMMENT 'ID du client qui a créé la simulation',
  `idSimulation` int NOT NULL COMMENT 'ID de la simulation qu''a créé le client',
  PRIMARY KEY (`idClient`,`idSimulation`),
  KEY `idSimulation` (`idSimulation`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `client_vehicule`
--

DROP TABLE IF EXISTS `client_vehicule`;
CREATE TABLE IF NOT EXISTS `client_vehicule` (
  `idClient` int NOT NULL COMMENT 'ID du client qui a créé le véhicule',
  `idVehicule` int NOT NULL COMMENT 'ID du véhicule qu''a créé le client',
  PRIMARY KEY (`idClient`,`idVehicule`),
  KEY `idVehicule` (`idVehicule`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `environnements`
--

DROP TABLE IF EXISTS `environnements`;
CREATE TABLE IF NOT EXISTS `environnements` (
  `idEnvironnement` int NOT NULL COMMENT 'Identifiant unique pour chaque environnement',
  `meteo` int DEFAULT NULL COMMENT 'Id de la météo associé à cet environnement',
  `sol` int DEFAULT NULL COMMENT 'Id du sol associé à cet environnement',
  `obstacle` int DEFAULT NULL COMMENT 'Id de l''obstacle associé à cet environnement',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description de l''environnement',
  PRIMARY KEY (`idEnvironnement`),
  KEY `meteo` (`meteo`),
  KEY `sol` (`sol`),
  KEY `obstacle` (`obstacle`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `extensionsarrière`
--

DROP TABLE IF EXISTS `extensionsarrière`;
CREATE TABLE IF NOT EXISTS `extensionsarrière` (
  `idExtArr` int NOT NULL COMMENT 'Identifiant unique pour chaque extension arrière',
  `chemin` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Chemin vers le modèle 3D pour Unity',
  `modele` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Nom du modèle d''extension arrière',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Description de l''extension arrière',
  `prix` int DEFAULT NULL COMMENT 'Prix de l''extension arrière',
  PRIMARY KEY (`idExtArr`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `extensionsavant`
--

DROP TABLE IF EXISTS `extensionsavant`;
CREATE TABLE IF NOT EXISTS `extensionsavant` (
  `idExtAv` int NOT NULL COMMENT 'Identifiant unique pour chaque extension avant',
  `chemin` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Chemin vers le modèle 3D pour Unity',
  `modele` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Nom du modèle de l''extension avant',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Description de l''extension avant',
  `prix` int DEFAULT NULL COMMENT 'Prix de l''extension avant',
  PRIMARY KEY (`idExtAv`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `extensionstoit`
--

DROP TABLE IF EXISTS `extensionstoit`;
CREATE TABLE IF NOT EXISTS `extensionstoit` (
  `idExtToit` int NOT NULL COMMENT 'Identifiant unique pour chaque extension de toit',
  `chemin` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Chemin vers le modèle 3D pour Unity',
  `modele` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Nom du modèle d''extension de toit',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Description de l''extension de toit',
  `prix` int DEFAULT NULL COMMENT 'Prix de l''extension de toit',
  PRIMARY KEY (`idExtToit`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `freins`
--

DROP TABLE IF EXISTS `freins`;
CREATE TABLE IF NOT EXISTS `freins` (
  `idFrein` int NOT NULL COMMENT 'Identifiant unique pour chaque frein',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `modele` varchar(255) DEFAULT NULL COMMENT 'Modèle des freins',
  `type` varchar(255) DEFAULT NULL COMMENT 'Type de freins',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description des freins',
  `prix` int DEFAULT NULL COMMENT 'Prix des freins',
  PRIMARY KEY (`idFrein`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `meteo`
--

DROP TABLE IF EXISTS `meteo`;
CREATE TABLE IF NOT EXISTS `meteo` (
  `idMeteo` int NOT NULL COMMENT 'Identifiant unique pour chaque météo',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description de la météo',
  PRIMARY KEY (`idMeteo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `moteurs`
--

DROP TABLE IF EXISTS `moteurs`;
CREATE TABLE IF NOT EXISTS `moteurs` (
  `idMoteur` int NOT NULL COMMENT 'Identifiant unique pour chaque moteur',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `modele` varchar(255) DEFAULT NULL COMMENT 'Modèle du moteur',
  `type` varchar(255) DEFAULT NULL COMMENT 'Type de moteur',
  `puissance` int DEFAULT NULL COMMENT 'Puissance en chevaux',
  `couple` int DEFAULT NULL COMMENT 'Couple en newton mètres',
  `nbrChevaux` int DEFAULT NULL COMMENT 'Nombre de chevaux',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description du moteur',
  `prix` int DEFAULT NULL COMMENT 'Prix du moteur',
  PRIMARY KEY (`idMoteur`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `obstacles`
--

DROP TABLE IF EXISTS `obstacles`;
CREATE TABLE IF NOT EXISTS `obstacles` (
  `idObstacle` int NOT NULL COMMENT 'Identifiant unique pour chaque obstacle',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description de l''obstacle',
  PRIMARY KEY (`idObstacle`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `roues`
--

DROP TABLE IF EXISTS `roues`;
CREATE TABLE IF NOT EXISTS `roues` (
  `idRoue` int NOT NULL COMMENT 'Identifiant unique pour chaque roue',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `modele` varchar(255) DEFAULT NULL COMMENT 'Modèle de la roue',
  `diametre` int DEFAULT NULL COMMENT 'Diamètre de la roue',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description de la roue',
  `prix` int DEFAULT NULL COMMENT 'Prix de la roue',
  PRIMARY KEY (`idRoue`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `simulations`
--

DROP TABLE IF EXISTS `simulations`;
CREATE TABLE IF NOT EXISTS `simulations` (
  `idSimulation` int NOT NULL COMMENT 'Identifiant unique pour chaque simulation',
  `vitesseMax` varchar(255) DEFAULT NULL COMMENT 'Vitesse maximum du véhicule lors de la simulation',
  `tenueDeRoute` varchar(255) DEFAULT NULL COMMENT 'Tenue de route du véhicule lors la simulation',
  `charge` varchar(255) DEFAULT NULL COMMENT 'Charge du véhicule lors la simulation',
  `consommation` varchar(255) DEFAULT NULL COMMENT 'Consommation du véhicule lors la simulation',
  PRIMARY KEY (`idSimulation`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `sols`
--

DROP TABLE IF EXISTS `sols`;
CREATE TABLE IF NOT EXISTS `sols` (
  `idSol` int NOT NULL COMMENT 'Identifiant unique pour chaque sol',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description du sol',
  PRIMARY KEY (`idSol`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `suspensions`
--

DROP TABLE IF EXISTS `suspensions`;
CREATE TABLE IF NOT EXISTS `suspensions` (
  `idSuspension` int NOT NULL COMMENT 'Identifiant unique pour chaque suspension',
  `chemin` varchar(255) DEFAULT NULL COMMENT 'Chemin du modèle 3D pour Unity',
  `modele` varchar(255) DEFAULT NULL COMMENT 'Modèle de la suspension',
  `type` varchar(255) DEFAULT NULL COMMENT 'Type de la suspension',
  `description` varchar(255) DEFAULT NULL COMMENT 'Description de la suspension',
  `prix` int DEFAULT NULL COMMENT 'Prix de la suspension',
  PRIMARY KEY (`idSuspension`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `vehicules`
--

DROP TABLE IF EXISTS `vehicules`;
CREATE TABLE IF NOT EXISTS `vehicules` (
  `idVehicule` int NOT NULL COMMENT 'Identifiant unique pour chaque véhicule',
  `idMoteur` int DEFAULT NULL COMMENT 'Identifiant du moteur associé',
  `idSuspension` int DEFAULT NULL COMMENT 'Id des suspensions associées à ce véhicule',
  `idRoue` int DEFAULT NULL COMMENT 'Id des roues associées à ce véhicule',
  `idFrein` int DEFAULT NULL COMMENT 'Id des freins associés à ce véhicule',
  `idCarrosserie` int DEFAULT NULL COMMENT 'Id de la carrosserie associée à ce véhicule',
  `idBoiteVitesse` int DEFAULT NULL COMMENT 'Id de la boîte de vitesse associée à ce véhicule',
  `idExtAv` int DEFAULT NULL COMMENT 'Id des extensions avant associées à ce véhicule',
  `idExtArr` int DEFAULT NULL COMMENT 'Id des extensions arrière associées à ce véhicule',
  `idExtToit` int DEFAULT NULL COMMENT 'Id des extensions de toit associées à ce véhicule',
  `nbrRoues` int DEFAULT NULL COMMENT 'Nombre de roues pour ce véhicule',
  `nbrRouesMotrices` int DEFAULT NULL COMMENT 'Nombre de roues motrices pour ce véhicule',
  `dateCreation` date DEFAULT NULL COMMENT 'Date de création de ce véhicule',
  PRIMARY KEY (`idVehicule`),
  KEY `idExtToit` (`idExtToit`),
  KEY `idExtArr` (`idExtArr`),
  KEY `idExtAv` (`idExtAv`),
  KEY `idBoiteVitesse` (`idBoiteVitesse`),
  KEY `idCarosserie` (`idCarrosserie`),
  KEY `idFrein` (`idFrein`),
  KEY `idRoue` (`idRoue`),
  KEY `idSuspension` (`idSuspension`),
  KEY `idMoteur` (`idMoteur`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
