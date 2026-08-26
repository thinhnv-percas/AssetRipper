using System.Collections.Generic;
using System.IO;
using System.Threading;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public interface IBamlDecompiler
{
	IList<string> Decompile(ModuleDef module, byte[] data, CancellationToken token, BamlDecompilerOptions bamlDecompilerOptions, Stream output, XamlOutputOptions outputOptions);
}
