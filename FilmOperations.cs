using LinqExercise;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class FilmOperations
{
    private List<Film> films;

    public FilmOperations(string jsonFilePath)
    {
        string json = File.ReadAllText(jsonFilePath);
        films = JsonConvert.DeserializeObject<List<Film>>(json);
    }

    public FilmOperations(List<Film>? films)
    {
        this.films = films;
    }

    public List<Film> GetAllMovies()
    {
        return films;
    }

    public Film[] GetMoviesByDirector(string directorName)
    {
        return films.Where(film => film.director == directorName).ToArray();
    }

    public Film[] GetMoviesByYear(int releaseYear)
    {
        return films.Where(film => film.releaseYear == releaseYear).ToArray();
    }

    public Film[] GetMoviesByRatingRange(double minRating, double maxRating)
    {
        return films.Where(film => film.rating >= minRating && film.rating <= maxRating).ToArray();
    }

    public Film[] GetMoviesByRatingSortedLimited(int numberOfFilms)
    {
        return films.OrderByDescending(film => film.rating).Take(numberOfFilms).ToArray();
    }
}
