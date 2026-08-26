using System.Composition.Hosting.Core;

namespace System.Composition.TypedParts;

internal class ImportInfo
{
	private readonly CompositionContract _exportKey;

	private readonly bool _allowDefault;

	public bool AllowDefault => _allowDefault;

	public CompositionContract Contract => _exportKey;

	public ImportInfo(CompositionContract exportKey, bool allowDefault)
	{
		_exportKey = exportKey;
		_allowDefault = allowDefault;
	}
}
