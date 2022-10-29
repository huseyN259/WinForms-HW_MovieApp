using WinForms_HW_MovieApp.Models;
using WinForms_HW_MovieApp.UC;

namespace WinForms_HW_MovieApp.View;

public partial class Form1Movie : Form
{
	public Form1Movie(MovieClass movieClass)
	{
		InitializeComponent();

		var userControl = new UC_Movie(movieClass!);
		userControl.Dock = DockStyle.Top;
		panel1.Controls.Add(userControl);
	}

	private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

	private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
}