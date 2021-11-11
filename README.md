# Movie Rater (Blue Badge Agile Assignment)

Authors: Adam Sadler and Zach Nichols

Due Date: November 13, 2021

Assignment: The **Eleven Fifty Academy Agile Assignment** requires each team to create user stories, generate tickets/tasks using a point system, plan an agile sprint, and begin work on an API program with associated unit tests. Our group chose to create an entertainment content rating API with the following classes:

- `Content` (abstract class, contains ContentId, Title, Description, ContentType enum, and list of Ratings). It's worth noting that the 'Content' class contains a method to calculate the average rating based on its list of Ratings.

- `Movie` (extends Content, also contains LengthOfMovie).

- `Show` (extends Content, also contains NumberOfSeaons).

- `Rating` (contains RatingId, ContentId, virtual Content, UserId, Score out of 5 stars, and text Description)

In addition to the standard endpoints for each concrete class (POST, GET ALL, GET BY ID, PUT, DELETE), we created a few unique endpoints:

- `api/Movie/GetByMinRating?minRating={minRating}` which accepts a minimum rating (out of 5) in the header and returns all Movies with average ratings meeting or exceeding this minimum.

- `api/Show/GetLongShows` which returns all shows with at least 5 seasons.


Some features we would like to add:

- `Actor` class (contains Id, Name, BirthDate, optional DeathDate, ListOfContent, ListOfAwards).

- `api/Movie/GetClassicMovie` endpoint that returns all movies with a 4+ rating that feature at least one deceased actor.

- `Genre` property on Movie class, as well as a `api/Movie/GetByGenre` endpoint to return all Movies in that genre.

- `Year` property on Movie class, as well as a `api/Movie/GetMoviesByEra` endpoint that returns all movies within 5 years of a specified date.


## Resources

- [GitHub Repository](https://github.com/znichols1131/AgileProject)
- [Assignment Requirements and Rubric](https://elevenfifty.instructure.com/courses/799/assignments/17167?module_item_id=72087)
- [Google Document](https://docs.google.com/document/d/1z7GkNKdBH18AkEQEWYyaFuxoO9lt0WyR6IxmUgkddRo/edit?usp=sharing)

---
