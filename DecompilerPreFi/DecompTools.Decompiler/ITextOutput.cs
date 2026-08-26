using System.Reflection.Metadata;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler;

public interface ITextOutput
{
	void Indent();

	void Unindent();

	void Write(char ch);

	void Write(string text);

	void WriteLine();

	void WriteReference(OpCodeInfo opCode);

	void WriteReference(PEFile module, EntityHandle handle, string text, bool isDefinition = false);

	void WriteReference(IType type, string text, bool isDefinition = false);

	void WriteReference(IMember member, string text, bool isDefinition = false);

	void WriteLocalReference(string text, object reference, bool isDefinition = false);

	void MarkFoldStart(string collapsedText = "...", bool defaultCollapsed = false);

	void MarkFoldEnd();
}
