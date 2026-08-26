namespace dnSpy.Contracts.Text;

public interface ITextColorWriter
{
	void Write(object color, string text);

	void Write(TextColor color, string text);
}
