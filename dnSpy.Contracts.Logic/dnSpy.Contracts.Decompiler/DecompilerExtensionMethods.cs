using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

public static class DecompilerExtensionMethods
{
	public static void WriteCommentLine(this IDecompiler self, IDecompilerOutput output, string comment)
	{
		self.WriteCommentBegin(output, addSpace: true);
		output.Write(comment, BoxedTextColor.Comment);
		self.WriteCommentEnd(output, addSpace: true);
		output.WriteLine();
	}
}
