using WinForms_HW_MovieApp.Models;

namespace WinForms_HW_MovieApp.UC;

public partial class UC_Movie : UserControl
{
	public UC_Movie(MovieClass movieClass)
	{
		InitializeComponent();

		pictureBox1.Load(movieClass?.Poster);
		lblNameMovie.Text = movieClass?.Title;
		lblImdb.Text = movieClass?.imdbRating?.ToString();
		lblYearMovie.Text = movieClass?.Year;
		lblGenreMovie.Text = movieClass?.Genre;
		lblWriterMovie.Text = movieClass?.Writer;
		lblActorsMovies.Text = movieClass?.Actors;
		lblLanguageMovies.Text = movieClass?.Language;
		lblCountryMovie.Text = movieClass?.Country;
		lblDirectorMovies.Text = movieClass?.Director;
		lblPlotMovies.Text = movieClass?.Plot;
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{

	}
}