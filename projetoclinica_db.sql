-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 08/09/2020 às 21:53
-- Versão do servidor: 10.4.11-MariaDB
-- Versão do PHP: 7.4.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `projetoclinica`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `cadastro`
--

CREATE TABLE `cadastro` (
  `idCadastro` int(11) NOT NULL,
  `nomeCompleto` varchar(200) NOT NULL,
  `dataNascimento` varchar(20) NOT NULL,
  `sexo` varchar(50) NOT NULL,
  `rgPaciente` varchar(100) NOT NULL,
  `endereco` varchar(500) NOT NULL,
  `contato` varchar(100) NOT NULL,
  `planoSaude` varchar(20) NOT NULL,
  `ativoPaciente` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura para tabela `especialidademedica`
--

CREATE TABLE `especialidademedica` (
  `idEspecMed` int(11) NOT NULL,
  `nomeEspec` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura para tabela `marcarconsulta`
--

CREATE TABLE `marcarconsulta` (
  `idConsulta` int(11) NOT NULL,
  `nomePaciente` varchar(200) NOT NULL,
  `procedimento` varchar(100) NOT NULL,
  `especmed` varchar(100) NOT NULL,
  `dataConsulta` varchar(15) NOT NULL,
  `ativoConsulta` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices de tabelas apagadas
--

--
-- Índices de tabela `cadastro`
--
ALTER TABLE `cadastro`
  ADD PRIMARY KEY (`idCadastro`);

--
-- Índices de tabela `especialidademedica`
--
ALTER TABLE `especialidademedica`
  ADD PRIMARY KEY (`idEspecMed`);

--
-- Índices de tabela `marcarconsulta`
--
ALTER TABLE `marcarconsulta`
  ADD PRIMARY KEY (`idConsulta`);

--
-- AUTO_INCREMENT de tabelas apagadas
--

--
-- AUTO_INCREMENT de tabela `cadastro`
--
ALTER TABLE `cadastro`
  MODIFY `idCadastro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT de tabela `especialidademedica`
--
ALTER TABLE `especialidademedica`
  MODIFY `idEspecMed` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `marcarconsulta`
--
ALTER TABLE `marcarconsulta`
  MODIFY `idConsulta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
