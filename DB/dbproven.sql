
CREATE DATABASE dbproven;

USE dbproven;

CREATE TABLE `bookings` (
  `idBooking` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `userName` varchar(32) NOT NULL,
  `userEmail` varchar(32) NOT NULL,
  `className` varchar(32) NOT NULL,
  `day` varchar(32) NOT NULL,
  `hours` varchar(32) NOT NULL
) ENGINE=InnoDB;


INSERT INTO `bookings` (`idBooking`, `userName`, `userEmail`, `className`, `day`, `hours`) VALUES
(32, 'alex', 'alex@gmail.com', 'A28', '2020-04-15', '8:30-15:00');



CREATE TABLE `classroom` (
  `roomId` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(32) NOT NULL,
  `description` varchar(240) NOT NULL,
  `timeZone` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


INSERT INTO `classroom` (`roomId`, `name`, `description`, `timeZone`) VALUES
(1, 'A27', 'Esta clase dispone de 30 ordenadores con linux y windows', 1),
(2, 'A28', 'Esta clase dispone de 20 ordenadores con linux y windows', 2),
(3, 'A12', 'Esta clase dispone de sitio para 25 personas, no tiene ordenadores', 3),
(4, 'A13', 'Esta clase dispone de un taller para que los alumnos puedan inspeccionar componentes electronicos', 4),
(5, 'A27', 'Esta clase dispone de 30 ordenadores con Linux y Windows', 2);


CREATE TABLE `timezones` (
  `timeZoneId` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `day` date NOT NULL,
  `timeZone` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


INSERT INTO `timezones` (`timeZoneId`, `day`, `timeZone`) VALUES
(1, '2020-04-06', '8:30-11:30'),
(2, '2020-04-15', '8:30-15:00'),
(3, '2020-04-06', '12:00-15:00'),
(4, '2020-04-10', '8:30-11:30');


CREATE TABLE `users` (
  `userName` varchar(32) NOT NULL PRIMARY KEY,
  `password` varchar(32) NOT NULL,
  `rol` varchar(32) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


INSERT INTO `users` (`userName`, `password`, `rol`, `email`) VALUES
('alex', 'pass2', 'teacher', 'alex@gmail.com'),
('chems', 'pass1', 'admin', 'chems@gmail.com'),
('Martin', '12345', 'Admin', 'ritman@gmail.com');

