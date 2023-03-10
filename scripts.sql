USE [DigitalBooks]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 13-01-2023 12:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[Publisher] [nvarchar](50) NULL,
	[Active] [nvarchar](50) NULL,
	[BookContent] [nvarchar](max) NULL,
	[Author] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 13-01-2023 12:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[SubscriptionId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[SubscriptionActive] [nvarchar](50) NULL,
	[UserId] [int] NULL,
	[Author] [nvarchar](50) NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13-01-2023 12:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserType] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (2, N'The Big Five For Life', N'Spirituality', N'books/ImagesWizardOfEarthSea.jpg20221228224335', 400, N'St. Martin''s Press', N'yes', N'Joe is dissatisfied with his life, especially with his job. By chance he meets the successful businessman Thomas and learns about his profound corporate philosophy and the secrets of his success. The story begins and takes its course: Thomas becomes Joe''s mentor and shows him the guiding principles of his companies. This consists of two essential factors: First, every employee must know his or her personal purpose, the so-called purpose of existence (ZDE).', N'John Strelecky', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (3, N'The Little Prince', N'Fiction', NULL, 200, N'Reynal & Hitchcock (U.S.) Gallimard (France)', N'yes', N'The story follows a young prince who visits various planets in space, including Earth, and addresses themes of loneliness, friendship, love, and loss.', N'Antoine de Saint-Exupéry', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (7, N'Pride and Prejudice', N'Fantasy', N'books/ImagesPrideAndPrejudice.jpg20221230125023', 200, N'T. Egerton, Whitehall', N'yes', N'Pride and Prejudice is an 1813 novel of manners by Jane Austen. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.', N'Jane Austen', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (8, N'All the Light We Cannot See', N'Fiction', NULL, 200, N'Simon & Schuster', N'yes', N'All the Light We Cannot See is a 2014 war novel that was written by American author Anthony Doerr. The novel is set during World War II and centers around the characters Marie-Laure Leblanc, a blind French girl who takes refuge in her uncle''s house in Saint-Malo after Paris is invaded by Nazi Germany; and Werner Pfennig, a bright German boy who is accepted into a military school because of his skills in radio technology before being sent to the military.', N'Anthony Doerr', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (10, N'A Wizard Of Earthsea', N'Fantasy', NULL, 150, N'Parnassus Press', N'yes', N'A Wizard of Earthsea is a fantasy novel written by American author Ursula K. Le Guin and first published by the small press Parnassus in 1968. It is regarded as a classic of children''s literature and of fantasy, within which it is widely influential.', N'Ursula K. Le Guin', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (11, N'The Grimm''s fairy tale', N'Fiction', N'GrimmsFairyTale20230104202351.jpg', 200, N'Simon', N'yes', N'Cinderella, Rapunzel, Snow-White, Hänsel and Gretel, Little Red-Cap (Little Red Riding Hood), and Briar-Rose (Sleeping Beauty) are only a few of the more than two hundred enchanting characters included in this volume', N'Jacob and Wilhelm Grimm', N'test2@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (13, N'Where The Mountain Meets The Moon', N'Fiction', NULL, 350, N'Little, Brown and Company', N'yes', N'Where the Mountain Meets the Moon is a fantasy-adventure children''s novel inspired by Chinese folklore. It was written and illustrated by Grace Lin and published in 2009.', N'Grace Lin', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (24, N'The Nightingale', N'Fiction', NULL, 200, N'St. Martin''s Press', N'yes', N'The Nightingale is a historical fiction novel by American author Kristin Hannah published by St. Martin''s Press in 2015. The book tells the story of two sisters in France during World War II and their struggle to survive and resist the German occupation of France. The book was inspired by the story of a Belgian woman, Andrée de Jongh, who helped downed Allied pilots escape Nazi territory.', N'Kristin Hannah', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (29, N'RingWorld', N'Science Fiction', N'string', 500, N'zxc', N'yes', N'Ringworld is a 1970 science fiction novel by Larry Niven, set in his Known Space universe and considered a classic of science fiction literature.', N'Larry Niven', NULL, 15)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (48, N'The Kite Runner', N'Fiction', NULL, 200, N'Riverhead Books', N'yes', N'The Kite Runner is the first novel by Afghan-American author Khaled Hosseini.Published in 2003 by Riverhead Books, it tells the story of Amir, a young boy from the Wazir Akbar Khan district of Kabul. The story is set against a backdrop of tumultuous events, from the fall of Afghanistan''s monarchy through the Soviet invasion, the exodus of refugees to Pakistan and the United States, and the rise of the Taliban regime.', N'Khaled Hosseini', N'testauthor@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (50, N'Harry Potter and the Philosopher''s Stone', N'Fantasy', N'string', 300, N'Bloomsbury', N'yes', N'Harry Potter and the Philosopher''s Stone is a 1997 fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling''s debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry.', N'J. K. Rowling.', N'testauthor@gmail.com', 26)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (51, N'Pride and Prejudice', N'Fantasy', N'string', 200, N'T. Egerton, Whitehall', N'yes', N'Pride and Prejudice is an 1813 novel of manners by Jane Austen. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.', N'Jane Austen', N'testauthor@gmail.com', 29)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (52, N'Pride and Prejudice', N'Fantasy', N'string', 200, N'T. Egerton, Whitehall', N'yes', N'Pride and Prejudice is an 1813 novel of manners by Jane Austen. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.', N'Jane Austen', N'testauthor@gmail.com', 31)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (55, N'The Exiles', N'Fiction', NULL, 300, N'HarperCollins Publishers India', N'yes', N'A thrilling mystery novel with an evocative outback setting and heart-pounding twists, Exiles is a book you’ll want to discuss with everyone you know. ', N'Jane Harper', N'priyanga.a@gmail.com', NULL)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (57, N'The Hobbit, or There and Back Again', N'Fantasy', NULL, 300, N'George Allen & Unwin (UK)', N'yes', N'The Hobbit, or There and Back Again is a children''s fantasy novel by English author J. R. R. Tolkien. It was published in 1937 to wide critical acclaim, being nominated for the Carnegie Medal and awarded a prize from the New York Herald Tribune for best juvenile fiction.', N'J. R. R. Tolkien.', N'testauthor@gmail.com', 20)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (58, N'All good people here', N'Thriller', NULL, 500, N'Random House Publishing Group', N'yes', N'All Good People Here is a debut thriller written by podcast host Ashley Flowers.', N'Alex Kiester', N'priyanga.a@gmail.com', 33)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (60, N'Owner of a Lonely Heart', N'Fiction', NULL, 550, N'Simon & Schuster', N'yes', N'Gemma is scared that if life slows down she''ll have to face up to how lonely she is having lost her true love. She crams her days with work and taking her dog Bear to visit young hospital patients. Dan is scared of anyone knowing the real him. He is the life and soul of the party, but he''s hiding a deep secret.	', N'Eva Carter', N'priyanga.a@gmail.com', 33)
INSERT [dbo].[Book] ([BookId], [Title], [Category], [Image], [Price], [Publisher], [Active], [BookContent], [Author], [EmailId], [UserId]) VALUES (61, N'The Push', N'Thriller', NULL, 600, N'Pamela Dorman Books', N'yes', N'Blythe Connor is determined that she will be the warm, comforting mother to her new baby Violet that she herself never had.', N'Ashley Audrain', N'priyanga.a@gmail.com', 33)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscription] ON 

INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (1, 2, N'aa', NULL, N'yes', NULL, NULL)
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (2, 8, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (3, 8, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (7, 8, N'Where The Mountain Meets The Moon', N'testauthor@gmail.com', N'yes', NULL, NULL)
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (8, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (9, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (13, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (14, 3, N'The Name of the Wind', NULL, NULL, NULL, N'Patrick Rothfuss')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (23, 50, N'A Wizard Of Earthsea', N'test7@gmail.com', N'yes', 27, N'zxc')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (24, 7, N'Pride and Prejudice', NULL, NULL, NULL, N'Jane Austen')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (25, 7, N'Pride and Prejudice', NULL, NULL, NULL, N'Jane Austen')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (27, 48, N'Where The Mountain Meets The Moon', NULL, N'yes', NULL, N'Grace Lin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (31, 10, N'A Wizard Of Earthsea', N'testreader1@gmail.com', N'yes', NULL, N'Ursula K. Le Guin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (32, 10, N'A Wizard Of Earthsea', N'testreader1@gmail.com', N'yes', NULL, N'Ursula K. Le Guin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (33, 10, N'A Wizard Of Earthsea', N'testreader1@gmail.com', N'yes', NULL, N'Ursula K. Le Guin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (34, 10, N'A Wizard Of Earthsea', N'testreader1@gmail.com', N'yes', NULL, N'Ursula K. Le Guin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (35, 7, N'Pride and Prejudice', NULL, N'yes', NULL, N'Jane Austen')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (36, 7, N'Pride and Prejudice', N'testreader1@gmail.com', N'yes', NULL, N'Jane Austen')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (37, 10, N'A Wizard Of Earthsea', N'testreader1@gmail.com', N'yes', NULL, N'Ursula K. Le Guin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (38, 3, N'The Name of the Wind', N'testreader1@gmail.com', N'yes', NULL, N'Patrick Rothfuss')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (39, 11, N'The Grimm''s fairy tale', N'testreader1@gmail.com', N'yes', NULL, N'Jacob and Wilhelm Grimm')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (40, 11, N'The Grimm''s fairy tale', N'testreader1@gmail.com', N'yes', NULL, N'Jacob and Wilhelm Grimm')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (41, 11, N'The Grimm''s fairy tale', N'testreader1@gmail.com', N'yes', NULL, N'Jacob and Wilhelm Grimm')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (42, 13, N'Where The Mountain Meets The Moon', N'testreader1@gmail.com', N'yes', NULL, N'Grace Lin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (43, 13, N'Where The Mountain Meets The Moon', N'testreader1@gmail.com', N'yes', NULL, N'Grace Lin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (44, 13, N'Where The Mountain Meets The Moon', N'testreader1@gmail.com', N'no', NULL, N'Grace Lin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (45, 24, N'A Wizard Of Earthsea', N'priyanga.r@gmail.com', N'yes', NULL, N'Ursula K. Le Guin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (46, 7, N'Pride and Prejudice', N'testreader1@gmail.com', N'yes', NULL, N'Jane Austen')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (47, 51, N'Pride and Prejudice', N'testauthor@gmail.com', N'yes', 30, N'Jane Austen')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (48, 52, N'Pride and Prejudice', N'testauthor@gmail.com', N'yes', 32, N'Jane Austen')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (49, 55, N'The Exiles', N'priyanga.r@gmail.com', N'yes', NULL, N'Jane Harper')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (50, 57, N'A Wizard Of Earthsea', N'testreader1@gmail.com', N'yes', 3, N'Ursula K. Le Guin')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (51, 58, N'All good people here', N'priyanga.r@gmail.com', N'yes', 28, N'Alex Kiester')
INSERT [dbo].[Subscription] ([SubscriptionId], [BookId], [Title], [EmailId], [SubscriptionActive], [UserId], [Author]) VALUES (52, 60, N'Owner of a Lonely Heart', N'priyanga.r@gmail.com', N'yes', 28, N'Eva Carter')
SET IDENTITY_INSERT [dbo].[Subscription] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (1, N'Priyanga', N'priyanga@gmail.com', N'Password01', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (2, N'Test', N'testauthor@gmail.com', N'Password01', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (3, N'TestReader', N'testreader@gmail.com', N'Password01', N'Reader')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (4, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (5, N'Priya', N'priya@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (6, N'Test1', N'test1@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (7, N'Test1', N'test1@gmail.com', N'Password', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (8, N'Test2', N'test2@gmail.com', N'Password01', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (9, N'Test3', N'test3@gmail.com', N'Password01', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (10, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (11, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (12, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (13, N'Test4', N'test4@gmail.com', N'Password01', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (14, N'string', N'string', N'string', N'string')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (15, N'string', N'string', N'string', N'string')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (16, N'string', N'string', N'string', N'string')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (17, N'string', N'string', N'string', N'string')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (18, N'TestReader', N'testreader1@gmail.com', N'Password01', N'reader')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (19, N'Test6', N'test6@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (20, N'Test7', N'test7@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (21, N'PriyangaT', N'priyanga.t@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (26, N'Test7', N'test7@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (27, N'Test7', N'test7@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (28, N'PriyangaR', N'priyanga.r@gmail.com', N'Password01', N'reader')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (29, N'Test', N'testauthor@gmail.com', N'Password01', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (30, N'string', N'string', N'string', N'string')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (31, N'Test', N'testauthor@gmail.com', N'Password01', N'Author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (32, N'string', N'string', N'string', N'string')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (33, N'PriyangaA', N'priyanga.a@gmail.com', N'Password01', N'author')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (34, N'PriyangaAdm', N'priyanga.adm@gmail.com', N'Password01', N'reader')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (35, N'PriyangaAdmin', N'priyanga.admin@gmail.com', N'Password01', N'reader')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (36, N'Test', N'test.a@gmail.com', N'Password01', N'reader')
INSERT [dbo].[User] ([UserId], [UserName], [EmailId], [Password], [UserType]) VALUES (37, N'PriyangaTAdmin', N'priyanga.tadmin@gmail.com', N'Password01', N'admin')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_User1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_User1]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Book1] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_Book1]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_User1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_User1]
GO
