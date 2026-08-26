namespace ICSharpCode.TextEditor.Actions;

public class Insert : AbstractEditAction
{
	public string text;

	public override void Execute(TextArea textArea)
	{
		if (!textArea.Document.ReadOnly)
		{
			textArea.InsertString(text);
		}
	}
}
