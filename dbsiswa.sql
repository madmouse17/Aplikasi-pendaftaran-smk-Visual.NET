-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 08, 2019 at 03:55 PM
-- Server version: 10.1.32-MariaDB
-- PHP Version: 5.6.36

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbsiswa`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbdaftar`
--

CREATE TABLE `tbdaftar` (
  `no` char(10) NOT NULL,
  `tgl_daftar` varchar(20) NOT NULL,
  `nama` varchar(25) NOT NULL,
  `jenis` varchar(10) NOT NULL,
  `tempat` varchar(10) NOT NULL,
  `tgl_lahir` varchar(20) NOT NULL,
  `asal` varchar(20) NOT NULL,
  `agama` varchar(10) NOT NULL,
  `alamat` varchar(40) NOT NULL,
  `nama_ortu` varchar(20) NOT NULL,
  `pekerjaan` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbdaftar`
--

INSERT INTO `tbdaftar` (`no`, `tgl_daftar`, `nama`, `jenis`, `tempat`, `tgl_lahir`, `asal`, `agama`, `alamat`, `nama_ortu`, `pekerjaan`) VALUES
('2018001', '08 Januari 2019', 'Ika', 'P', 'Deso', '05/07/1995', 'Smp N 18 Surakarta', 'Islam', 'Karanganyar', 'Sukijo', 'Swasta'),
('2018002', '08 Januari 2019', 'Huda', 'L', 'Klaten', '12/06/1989', 'Smp N 19 Klaten', 'Islam', 'Solo Baru', 'Sujiyo', 'Swasta'),
('2018003', '08 Januari 2019', 'Sigit', 'L', 'Boyolali', '29/12/2008', 'SMP N 2 Boyolali', 'Kristen', 'Boyolali', 'Bimbo', 'Swasta');

-- --------------------------------------------------------

--
-- Table structure for table `tblogin`
--

CREATE TABLE `tblogin` (
  `email` varchar(30) NOT NULL,
  `username` char(20) NOT NULL,
  `password` varchar(225) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblogin`
--

INSERT INTO `tblogin` (`email`, `username`, `password`) VALUES
('admin@admin.com', 'admin', '21232f297a57a5a743894a0e4a801fc3'),
('galih@admin.com', 'galih', '027dc74f0bbf09a61a36ec7f0d9e08ca');

-- --------------------------------------------------------

--
-- Table structure for table `tbnilai`
--

CREATE TABLE `tbnilai` (
  `no` char(10) NOT NULL,
  `id_test` char(20) NOT NULL,
  `nama` varchar(25) NOT NULL,
  `asal` varchar(25) NOT NULL,
  `jurusan` varchar(25) NOT NULL,
  `ruangan` varchar(11) NOT NULL,
  `mtk` int(11) NOT NULL,
  `bi` int(11) NOT NULL,
  `bing` int(11) NOT NULL,
  `kejuruan` int(11) NOT NULL,
  `rata` float NOT NULL,
  `ket` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbnilai`
--

INSERT INTO `tbnilai` (`no`, `id_test`, `nama`, `asal`, `jurusan`, `ruangan`, `mtk`, `bi`, `bing`, `kejuruan`, `rata`, `ket`) VALUES
('2018001', 'SOAL001', 'Ika', 'Smp N 18 Surakarta', 'Multimedia', 'LAB Multime', 80, 80, 80, 80, 80, 'LULUS'),
('2018002', 'SOAL002', 'Huda', 'Smp N 19 Klaten', 'Akutansi', '5', 88, 70, 85, 77, 80, 'LULUS'),
('2018003', 'SOAL003', 'Sigit', 'SMP N 2 Boyolali', 'TKJ', ' LAB 3', 70, 80, 60, 20, 57, 'TIDAK LULUS');

-- --------------------------------------------------------

--
-- Table structure for table `tbregist`
--

CREATE TABLE `tbregist` (
  `no` char(10) NOT NULL,
  `nama` varchar(25) NOT NULL,
  `asal` varchar(20) NOT NULL,
  `jurusan` varchar(20) NOT NULL,
  `ruangan` varchar(20) NOT NULL,
  `guru` varchar(25) NOT NULL,
  `registrasi` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbregist`
--

INSERT INTO `tbregist` (`no`, `nama`, `asal`, `jurusan`, `ruangan`, `guru`, `registrasi`) VALUES
('2018001', 'Ika', 'Smp N 18 Surakarta', 'Multimedia', 'LAB Multimedia', 'Djoko Santoso Spd', '200.000'),
('2018002', 'Huda', 'Smp N 19 Klaten', 'Akutansi', '5', 'Sumarlina Spd', '200.000'),
('2018003', 'Sigit', 'SMP N 2 Boyolali', 'TKJ', ' LAB 3', 'Darmawan S.Kom', '200.000');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbdaftar`
--
ALTER TABLE `tbdaftar`
  ADD PRIMARY KEY (`no`);

--
-- Indexes for table `tblogin`
--
ALTER TABLE `tblogin`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `tbnilai`
--
ALTER TABLE `tbnilai`
  ADD PRIMARY KEY (`no`);

--
-- Indexes for table `tbregist`
--
ALTER TABLE `tbregist`
  ADD PRIMARY KEY (`no`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
