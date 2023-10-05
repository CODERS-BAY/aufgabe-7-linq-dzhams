using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LinqExercise
{
    class Program
    {
        static void Main()
        {
            string jsonFilePath = @"C:\Users\Codersbay\Source\Repos\aufgabe-7-linq-dzhams\films.json";

            try
            {
                // Lese die JSON-Datei und deserialisiere sie in eine Liste von Film-Objekten
                string json = System.IO.File.ReadAllText(jsonFilePath);
                List<Film> films = JsonConvert.DeserializeObject<List<Film>>(json);

                FilmOperations filmOperations = new FilmOperations(films);

                // Teste die Methoden der FilmOperations-Klasse
                var allMovies = filmOperations.GetAllMovies();
                Console.WriteLine("Alle Filme:");
                foreach (var film in allMovies)
                {
                    Console.WriteLine($"Titel: {film.title}, Jahr: {film.releaseYear}, Regisseur: {film.director}, Bewertung: {film.rating}");
                }

                var directorMovies = filmOperations.GetMoviesByDirector("Christopher Nolan"); // Ersetze "Christopher Nolan" durch den gewünschten Regisseur
                Console.WriteLine("\nFilme von einem bestimmten Regisseur:");
                foreach (var film in directorMovies)
                {
                    Console.WriteLine($"Titel: {film.title}, Jahr: {film.releaseYear}");
                }

                var yearMovies = filmOperations.GetMoviesByYear(1994); // Ersetze 1994 durch das gewünschte Jahr
                Console.WriteLine("\nFilme aus einem bestimmten Jahr:");
                foreach (var film in yearMovies)
                {
                    Console.WriteLine($"Titel: {film.title}, Regisseur: {film.director}");
                }

                var ratingMovies = filmOperations.GetMoviesByRatingRange(8.0, 9.0); // Ersetze die Bewertungsbereiche nach Bedarf
                Console.WriteLine("\nFilme im Bewertungsbereich:");
                foreach (var film in ratingMovies)
                {
                    Console.WriteLine($"Titel: {film.title}, Bewertung: {film.rating}");
                }

                var topRatedMovies = filmOperations.GetMoviesByRatingSortedLimited(5); // Ersetze 5 durch die gewünschte Anzahl der besten Filme
                Console.WriteLine("\nTop bewertete Filme:");
                foreach (var film in topRatedMovies)
                {
                    Console.WriteLine($"Titel: {film.title}, Bewertung: {film.rating}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
            }
        }
    }
}
