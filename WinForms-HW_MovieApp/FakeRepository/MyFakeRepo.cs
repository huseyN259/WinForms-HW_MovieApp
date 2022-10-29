using System.Text.Json;
using WinForms_HW_MovieApp.Models;

namespace WinForms_HW_MovieApp.FakeRepository;

class MyFakeRepo
{
	const string APIkey = "580270e";
	const string url = $"http://www.omdbapi.com/?apikey={APIkey}";
	public static string[] movies = new string[] 
	{ 
		"The Maze Runner",
		"The Amazing Spiderman",
		"I Origins",
		"11.22.63",
		"Teen Wolf",
	};

	public static List<MovieClass> GetMovies()
	{
		List<MovieClass> movieClasses = new List<MovieClass>();

		for (int i = 0; i < movies.Length; i++)
		{
			string search = $"{url}&t={movies[i]}";
			using HttpClient client = new();
			string jsonStr = client.GetStringAsync(search).Result;
			var movie = JsonSerializer.Deserialize<MovieClass>(jsonStr);
			movieClasses.Add(movie!);
		}

		return movieClasses;
	}
}