namespace dnSpy.Contracts.Decompiler;

public interface IDecompilerOutput
{
	int Length { get; }

	int NextPosition { get; }

	bool UsesCustomData { get; }

	void IncreaseIndent();

	void DecreaseIndent();

	void WriteLine();

	void Write(string text, object color);

	void Write(string text, int index, int length, object color);

	void Write(string text, object reference, DecompilerReferenceFlags flags, object color);

	void Write(string text, int index, int length, object reference, DecompilerReferenceFlags flags, object color);

	void AddCustomData<TData>(string id, TData data);
}
