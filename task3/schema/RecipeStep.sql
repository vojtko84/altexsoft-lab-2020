CREATE TABLE [dbo].[RecipeStep](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[NumberStep] [int] NOT NULL,
	[Instruction] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RecipeStep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[RecipeStep]  WITH CHECK ADD  CONSTRAINT [FK_RecipeStep_Recipe] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([Id])
GO
ALTER TABLE [dbo].[RecipeStep] CHECK CONSTRAINT [FK_RecipeStep_Recipe]
GO
