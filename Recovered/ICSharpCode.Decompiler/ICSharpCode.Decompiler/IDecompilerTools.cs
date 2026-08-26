using System.Runtime.InteropServices;

namespace ICSharpCode.Decompiler
{
	[ComVisible(true)]
	[Guid("39727F7F-F4D3-4759-B878-37BC6474CA2B")]
	public interface IDecompilerTools
	{
		bool Run(string compiledFile, string expectedOutputFile, string class_name);
	}
}
