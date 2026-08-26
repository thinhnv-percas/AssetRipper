using System.Collections.Generic;
using System.ComponentModel.Composition;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.ILSpy.Core.IL;
using dnSpy.Decompiler.ILSpy.Core.Settings;

namespace dnSpy.Decompiler.ILSpy.IL;

[Export(typeof(IDecompilerCreator))]
internal sealed class MyDecompilerCreator : IDecompilerCreator
{
	private readonly DecompilerSettingsService decompilerSettingsService;

	[ImportingConstructor]
	private MyDecompilerCreator(DecompilerSettingsService decompilerSettingsService)
	{
		this.decompilerSettingsService = decompilerSettingsService;
	}

	public IEnumerable<IDecompiler> Create()
	{
		return new DecompilerProvider(decompilerSettingsService).Create();
	}
}
