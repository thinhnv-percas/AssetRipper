using System;

namespace dnSpy.Contracts.Decompiler;

public sealed class MethodDebugScope
{
	public ILSpan Span { get; }

	public MethodDebugScope[] Scopes { get; }

	public SourceLocal[] Locals { get; }

	public ImportInfo[] Imports { get; }

	public MethodDebugConstant[] Constants { get; }

	public MethodDebugScope(ILSpan span, MethodDebugScope[] scopes, SourceLocal[] locals, ImportInfo[] imports, MethodDebugConstant[] constants)
	{
		Span = span;
		Scopes = scopes ?? throw new ArgumentNullException("scopes");
		Locals = locals ?? throw new ArgumentNullException("locals");
		Imports = imports ?? throw new ArgumentNullException("imports");
		Constants = constants ?? throw new ArgumentNullException("constants");
	}
}
