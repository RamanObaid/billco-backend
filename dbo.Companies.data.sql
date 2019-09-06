SET IDENTITY_INSERT [dbo].[Companies] ON
INSERT INTO [dbo].[Companies] ([Id], [Name], [Address], [LogoURL], [Phone], [Email]) VALUES (1, N'ABC', NULL, N'https://banner2.kisspng.com/20180509/dsw/kisspng-american-broadcasting-company-logo-big-three-telev-jingdong-broadcasting-co-5af2880ce40fb1.8276827915258439809341.jpg', NULL, NULL)
INSERT INTO [dbo].[Companies] ([Id], [Name], [Address], [LogoURL], [Phone], [Email]) VALUES (2, N'Example Co.', NULL, N'https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/Service_mark.svg/1200px-Service_mark.svg.png', NULL, N'info@exampleltd.com')
INSERT INTO [dbo].[Companies] ([Id], [Name], [Address], [LogoURL], [Phone], [Email]) VALUES (3, N'InnerG', N'Iraq, Slemani, AUIS', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfN9eF8AUkQaUrF0rgzYXgnlR0ZIXJw6cZRcdBiMEo_AgDGPv9', N'750 123 45 67', N'info@innerg.com')
SET IDENTITY_INSERT [dbo].[Companies] OFF
