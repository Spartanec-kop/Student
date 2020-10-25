CREATE TABLE [dbo].[StudentGroup] (
    [StudentId] BIGINT NOT NULL,
    [GroupId]   BIGINT NOT NULL,
    CONSTRAINT [FK_StudentGroup_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_StudentGroup_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

