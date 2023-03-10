USE [master]
GO
/****** Object:  Database [Spotify]    Script Date: 19/12/2022 10:43:33 ******/
CREATE DATABASE [Spotify]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Spotify', FILENAME = N'/var/opt/mssql/data/Spotify.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Spotify_log', FILENAME = N'/var/opt/mssql/data/Spotify_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Spotify] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Spotify].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Spotify] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Spotify] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Spotify] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Spotify] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Spotify] SET ARITHABORT OFF 
GO
ALTER DATABASE [Spotify] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Spotify] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Spotify] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Spotify] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Spotify] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Spotify] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Spotify] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Spotify] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Spotify] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Spotify] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Spotify] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Spotify] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Spotify] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Spotify] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Spotify] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Spotify] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Spotify] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Spotify] SET RECOVERY FULL 
GO
ALTER DATABASE [Spotify] SET  MULTI_USER 
GO
ALTER DATABASE [Spotify] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Spotify] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Spotify] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Spotify] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Spotify] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Spotify', N'ON'
GO
ALTER DATABASE [Spotify] SET QUERY_STORE = OFF
GO
USE [Spotify]
GO
/****** Object:  Table [dbo].[account]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[pw] [varchar](64) NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[album]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_at] [datetime] NULL,
	[id_artist] [int] NULL,
	[id_genre] [int] NULL,
	[album_name] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[artist]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_at] [datetime] NULL,
	[artist_name] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_at] [datetime] NULL,
	[genre_name] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[playlist]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playlist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_account] [int] NULL,
	[playlist_name] [varchar](30) NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[playlist_songs]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playlist_songs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_song] [int] NULL,
	[id_playlist] [int] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[radio]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[radio_name] [varchar](30) NOT NULL,
	[created_at] [datetime] NULL,
	[id_genre] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[song]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[song](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[song_name] [varchar](30) NOT NULL,
	[id_genre] [int] NULL,
	[id_artist] [int] NULL,
	[id_album] [int] NULL,
	[popularity] [int] NULL,
	[created_at] [datetime] NULL,
	[publication_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subscription]    Script Date: 19/12/2022 10:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subscription](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subscription_name] [varchar](30) NOT NULL,
	[price] [float] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[album] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[artist] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[genre] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[playlist] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[playlist_songs] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[radio] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[song] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[subscription] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[album]  WITH CHECK ADD FOREIGN KEY([id_artist])
REFERENCES [dbo].[artist] ([id])
GO
ALTER TABLE [dbo].[album]  WITH CHECK ADD FOREIGN KEY([id_artist])
REFERENCES [dbo].[artist] ([id])
GO
ALTER TABLE [dbo].[album]  WITH CHECK ADD FOREIGN KEY([id_genre])
REFERENCES [dbo].[genre] ([id])
GO
ALTER TABLE [dbo].[album]  WITH CHECK ADD FOREIGN KEY([id_genre])
REFERENCES [dbo].[genre] ([id])
GO
ALTER TABLE [dbo].[playlist]  WITH CHECK ADD FOREIGN KEY([id_account])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[playlist]  WITH CHECK ADD FOREIGN KEY([id_account])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[radio]  WITH CHECK ADD FOREIGN KEY([id_genre])
REFERENCES [dbo].[genre] ([id])
GO
ALTER TABLE [dbo].[radio]  WITH CHECK ADD FOREIGN KEY([id_genre])
REFERENCES [dbo].[genre] ([id])
GO
ALTER TABLE [dbo].[song]  WITH CHECK ADD FOREIGN KEY([id_album])
REFERENCES [dbo].[album] ([id])
GO
ALTER TABLE [dbo].[song]  WITH CHECK ADD FOREIGN KEY([id_album])
REFERENCES [dbo].[album] ([id])
GO
ALTER TABLE [dbo].[song]  WITH CHECK ADD FOREIGN KEY([id_artist])
REFERENCES [dbo].[artist] ([id])
GO
ALTER TABLE [dbo].[song]  WITH CHECK ADD FOREIGN KEY([id_artist])
REFERENCES [dbo].[artist] ([id])
GO
ALTER TABLE [dbo].[song]  WITH CHECK ADD FOREIGN KEY([id_genre])
REFERENCES [dbo].[genre] ([id])
GO
ALTER TABLE [dbo].[song]  WITH CHECK ADD FOREIGN KEY([id_genre])
REFERENCES [dbo].[genre] ([id])
GO
USE [master]
GO
ALTER DATABASE [Spotify] SET  READ_WRITE 
GO
