using System;
using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.ILSpy.Core.Settings;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class DecompilerProvider : IDecompilerProvider
{
	private readonly DecompilerSettingsService decompilerSettingsService;

	public DecompilerProvider()
		: this(DecompilerSettingsService.__Instance_DONT_USE)
	{
	}

	public DecompilerProvider(DecompilerSettingsService decompilerSettingsService)
	{
		this.decompilerSettingsService = decompilerSettingsService ?? throw new ArgumentNullException("decompilerSettingsService");
	}

	public IEnumerable<IDecompiler> Create()
	{
		yield return new CSharpDecompiler(decompilerSettingsService.CSharpVBDecompilerSettings, DecompilerConstants.CSHARP_ILSPY_ORDERUI);
	}
}
