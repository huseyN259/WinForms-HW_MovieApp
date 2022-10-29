using System.Text.Json;
using WinForms_HW_MovieApp.FakeRepository;
using WinForms_HW_MovieApp.Models;
using WinForms_HW_MovieApp.UC;

namespace WinForms_HW_MovieApp.View;

public partial class MainForm : Form
{
	public MainForm()
	{
		InitializeComponent();
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		for (int i = MyFakeRepo.GetMovies().Count - 1; i >= 0; i--)
		{
			var userControl = new UC_Movie(MyFakeRepo.GetMovies()[i]);
			userControl.Dock = DockStyle.Top;
			panel2.Controls.Add(userControl);
		}
	}

	private async void btnSearch_Click(object sender, EventArgs e)
	{
		const string APIkey = "580270e";
		const string url = $"http://www.omdbapi.com/?apikey={APIkey}";
		if (string.IsNullOrWhiteSpace(textBox1.Text))
		{
			MessageBox.Show("Enter The Movie Name...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		string search = $"{url}&t={textBox1.Text}";
		using HttpClient client = new();
		string jsonStr = await client.GetStringAsync(search);
		var movie = JsonSerializer.Deserialize<MovieClass>(jsonStr);
		if (movie?.Title is null)
		{
			MessageBox.Show("No More Movie...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		Form1Movie form1Movie = new(movie!);
		DialogResult dialogResult = form1Movie.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			var userControl = new UC_Movie(movie!);
			userControl.Dock = DockStyle.Top;
			panel2.Controls.Add(userControl);
			return;
		}
	}
}