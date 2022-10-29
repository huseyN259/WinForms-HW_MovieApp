using WinForms_HW_MovieApp.View;

namespace WinForms_HW_MovieApp;

static class Program
{
	[STAThread]
	static void Main()
	{
		ApplicationConfiguration.Initialize();
		Application.Run(new MainForm());
	}
}