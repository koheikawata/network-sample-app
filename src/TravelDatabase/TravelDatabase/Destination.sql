CREATE TABLE [dbo].[Destination] (
    [Country]     NVARCHAR (256) NOT NULL,
    [City]        NVARCHAR (256) NULL,
    [Food]        NVARCHAR (256) NULL,
    [SightSeeing] NVARCHAR (256) NULL,
    PRIMARY KEY CLUSTERED ([Country] ASC)
)
