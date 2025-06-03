-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Окт 22 2024 г., 11:01
-- Версия сервера: 10.4.32-MariaDB
-- Версия PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `programma`
--

-- --------------------------------------------------------

--
-- Структура таблицы `developers`
--

CREATE TABLE `developers` (
  `DeveloperID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Website` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `developers`
--

INSERT INTO `developers` (`DeveloperID`, `Name`, `Website`) VALUES
(1, 'Разработчик 1', 'http://developer1.com'),
(2, 'Разработчик 2', 'http://developer2.com'),
(3, 'Разработчик 3', 'http://developer3.com');

-- --------------------------------------------------------

--
-- Структура таблицы `games`
--

CREATE TABLE `games` (
  `GameID` int(11) NOT NULL,
  `DeveloperID` int(11) DEFAULT NULL,
  `GenreID` int(11) DEFAULT NULL,
  `Rating` float DEFAULT NULL,
  `ReleaseDate` date DEFAULT NULL,
  `Platform` varchar(255) DEFAULT NULL,
  `Title` varchar(255) NOT NULL,
  `Description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `games`
--

INSERT INTO `games` (`GameID`, `DeveloperID`, `GenreID`, `Rating`, `ReleaseDate`, `Platform`, `Title`, `Description`) VALUES
(1, 1, 1, 9.5, '2023-01-15', 'PC', 'Гонка Времени', 'Увлекательная гонка в мире временных аномалий.'),
(2, 2, 2, 8.7, '2023-02-20', 'PC', 'Приключения в Тени', 'Исследуйте мрачные земли и решайте загадки.'),
(3, 3, 3, 9, '2023-03-05', 'Консоли', 'Эпоха Героя', 'Станьте героем в этом эпическом ролевом приключении.');

-- --------------------------------------------------------

--
-- Структура таблицы `genres`
--

CREATE TABLE `genres` (
  `GenreID` int(11) NOT NULL,
  `GenreName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `genres`
--

INSERT INTO `genres` (`GenreID`, `GenreName`) VALUES
(1, 'Экшен'),
(2, 'Приключения'),
(3, 'Ролевые игры'),
(4, 'Стратегия'),
(5, 'Головоломка');

-- --------------------------------------------------------

--
-- Структура таблицы `recommendations`
--

CREATE TABLE `recommendations` (
  `RecommendationID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `GameID` int(11) DEFAULT NULL,
  `RecommendationDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `recommendations`
--

INSERT INTO `recommendations` (`RecommendationID`, `UserID`, `GameID`, `RecommendationDate`) VALUES
(1, 1, 1, '2024-10-17 21:54:49'),
(2, 2, 2, '2024-10-17 21:54:49');

-- --------------------------------------------------------

--
-- Структура таблицы `reviews`
--

CREATE TABLE `reviews` (
  `ReviewID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `GameID` int(11) DEFAULT NULL,
  `ReviewText` text DEFAULT NULL,
  `Rating` float DEFAULT NULL CHECK (`Rating` between 1 and 5),
  `ReviewDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `reviews`
--

INSERT INTO `reviews` (`ReviewID`, `UserID`, `GameID`, `ReviewText`, `Rating`, `ReviewDate`) VALUES
(1, 1, 1, 'Отличная игра, рекомендую!', 5, '2024-10-17 21:54:49'),
(2, 2, 2, 'Интересный сюжет, но есть недочеты.', 4, '2024-10-17 21:54:49'),
(3, 1, 1, 'Отличная игра (тестируем)', 5, '2024-10-17 22:01:34'),
(4, 3, 2, '5', 5, '2024-10-17 22:15:35'),
(5, 3, 2, '5', 5, '2024-10-17 22:15:37'),
(6, 3, 2, '5', 5, '2024-10-17 22:15:39'),
(7, 3, 2, '5', 5, '2024-10-17 22:15:40'),
(8, 3, 2, '5', 5, '2024-10-17 22:15:41'),
(9, 3, 2, '5', 5, '2024-10-17 22:15:43'),
(10, 3, 2, '5', 5, '2024-10-17 22:15:44'),
(11, 3, 2, '5', 5, '2024-10-17 22:15:46'),
(12, 3, 2, '5', 5, '2024-10-17 22:15:47'),
(13, 3, 2, '5', 5, '2024-10-17 22:15:48'),
(14, 3, 2, '5', 5, '2024-10-17 22:15:49'),
(15, 3, 2, '5', 5, '2024-10-17 22:15:50'),
(16, 3, 2, '5', 5, '2024-10-17 22:15:52'),
(17, 3, 2, '5', 5, '2024-10-17 22:15:54'),
(18, 3, 2, '5', 5, '2024-10-17 22:15:55'),
(19, 3, 2, '5', 5, '2024-10-17 22:15:57'),
(20, 3, 2, '5', 5, '2024-10-17 22:15:58'),
(21, 3, 1, '5', 5, '2024-10-17 22:20:09'),
(22, 3, 1, '5', 5, '2024-10-17 22:20:10'),
(23, 3, 1, '5', 5, '2024-10-17 22:20:11'),
(24, 3, 1, '5', 5, '2024-10-17 22:20:12'),
(25, 3, 1, '5', 5, '2024-10-17 22:20:13'),
(26, 3, 1, '5', 5, '2024-10-17 22:20:14');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `RegistrationDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`UserID`, `Name`, `Password`, `RegistrationDate`) VALUES
(1, 'user1', 'password1', '2024-10-17 21:54:49'),
(2, 'user2', 'password2', '2024-10-17 21:54:49'),
(3, 'Дима', '123123', '2024-10-17 22:15:25'),
(4, 'Тест', '123123', '2024-10-21 20:41:07');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `developers`
--
ALTER TABLE `developers`
  ADD PRIMARY KEY (`DeveloperID`);

--
-- Индексы таблицы `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`GameID`),
  ADD KEY `DeveloperID` (`DeveloperID`),
  ADD KEY `GenreID` (`GenreID`);

--
-- Индексы таблицы `genres`
--
ALTER TABLE `genres`
  ADD PRIMARY KEY (`GenreID`);

--
-- Индексы таблицы `recommendations`
--
ALTER TABLE `recommendations`
  ADD PRIMARY KEY (`RecommendationID`),
  ADD KEY `UserID` (`UserID`),
  ADD KEY `GameID` (`GameID`);

--
-- Индексы таблицы `reviews`
--
ALTER TABLE `reviews`
  ADD PRIMARY KEY (`ReviewID`),
  ADD KEY `UserID` (`UserID`),
  ADD KEY `GameID` (`GameID`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `developers`
--
ALTER TABLE `developers`
  MODIFY `DeveloperID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `games`
--
ALTER TABLE `games`
  MODIFY `GameID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `genres`
--
ALTER TABLE `genres`
  MODIFY `GenreID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `recommendations`
--
ALTER TABLE `recommendations`
  MODIFY `RecommendationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `reviews`
--
ALTER TABLE `reviews`
  MODIFY `ReviewID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `games`
--
ALTER TABLE `games`
  ADD CONSTRAINT `games_ibfk_1` FOREIGN KEY (`DeveloperID`) REFERENCES `developers` (`DeveloperID`) ON DELETE SET NULL,
  ADD CONSTRAINT `games_ibfk_2` FOREIGN KEY (`GenreID`) REFERENCES `genres` (`GenreID`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `recommendations`
--
ALTER TABLE `recommendations`
  ADD CONSTRAINT `recommendations_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE CASCADE,
  ADD CONSTRAINT `recommendations_ibfk_2` FOREIGN KEY (`GameID`) REFERENCES `games` (`GameID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `reviews`
--
ALTER TABLE `reviews`
  ADD CONSTRAINT `reviews_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE CASCADE,
  ADD CONSTRAINT `reviews_ibfk_2` FOREIGN KEY (`GameID`) REFERENCES `games` (`GameID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
