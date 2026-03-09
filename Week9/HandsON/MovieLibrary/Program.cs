using System;
using System.Collections.Generic;
using System.Linq;

// Interface for Film
public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

// Interface for FilmLibrary
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

// Film class
public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public Film(){}
    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}

// FilmLibrary class
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();

    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        IFilm film = null;

foreach (var f in _films)
{
    if (f.Title.ToLower() == title.ToLower())
    {
        film = f;
        break;
    }
}
        if (film != null)
            _films.Remove(film);
    }

    public List<IFilm> GetFilms()
    {
        return _films;
    }

    public List<IFilm> SearchFilms(string query)
    {
        // return _films
        //     .Where(f => f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
        //                 f.Director.Contains(query, StringComparison.OrdinalIgnoreCase))
        //     .ToList();

            List<IFilm> Got = new List<IFilm>();

    var result = from f in _films
                 where f.Title.ToLower().Contains(query.ToLower()) ||
                       f.Director.ToLower().Contains(query.ToLower())
                 select f;

    foreach (var x in result)
    {
        Got.Add(x);
    }

    return Got;
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        FilmLibrary library = new FilmLibrary();

        // Adding films
        library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
        library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
        library.AddFilm(new Film("Titanic", "James Cameron", 1997));

        Console.WriteLine("All Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

        // Search films
        Console.WriteLine("\nSearch Results for 'Nolan':");
        var searchResults = library.SearchFilms("Nolan");
        foreach (var film in searchResults)
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

        // Remove film
        library.RemoveFilm("Titanic");

        Console.WriteLine("\nAfter Removing Titanic:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

        // Total film count
        Console.WriteLine($"\nTotal Films in Library: {library.GetTotalFilmCount()}");
    }
}