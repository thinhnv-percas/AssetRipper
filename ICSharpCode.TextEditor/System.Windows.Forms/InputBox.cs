namespace System.Windows.Forms;

public static class InputBox
{
	public static string Show(string Prompt)
	{
		return Show(Prompt, null, null, int.MinValue, int.MinValue, isPassword: false);
	}

	public static string Show(string Prompt, string Title, string Default)
	{
		return Show(Prompt, Title, Default, int.MinValue, int.MinValue, isPassword: false);
	}

	public static string Show(string Prompt, string Title, string Default, int xPos, int yPos, bool isPassword)
	{
		if (Title == null)
		{
			Title = Application.ProductName;
		}
		InputBoxDialog inputBoxDialog = new InputBoxDialog(Prompt, Title, xPos, yPos);
		if (isPassword)
		{
			inputBoxDialog.txtInput.UseSystemPasswordChar = true;
		}
		if (Default != null)
		{
			inputBoxDialog.txtInput.Text = Default;
		}
		if (inputBoxDialog.ShowDialog() == DialogResult.Cancel)
		{
			return null;
		}
		return inputBoxDialog.txtInput.Text;
	}

	public static string ShowPasswordBox(string Prompt, string Title)
	{
		return Show(Prompt, Title, "", int.MinValue, int.MinValue, isPassword: true);
	}
}
