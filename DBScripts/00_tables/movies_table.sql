CREATE TABLE Movie (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(512) NOT NULL,
    Rated VARCHAR(512),
    Released VARCHAR(512),
    Runtime VARCHAR(512),
    Genre VARCHAR(512) NOT NULL,
    Director VARCHAR(512),
    Writer VARCHAR(512),
    Actors VARCHAR(512),
    Plot VARCHAR(512) NOT NULL,
    Country VARCHAR(512),
    Awards VARCHAR(512),
    Poster VARCHAR(512),
    ImdbRating DECIMAL,
    BoxOffice VARCHAR(512)
);