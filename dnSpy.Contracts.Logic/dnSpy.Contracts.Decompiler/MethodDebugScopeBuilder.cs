using System;
using System.Collections.Generic;

namespace dnSpy.Contracts.Decompiler;

public sealed class MethodDebugScopeBuilder
{
	private List<MethodDebugScopeBuilder> scopes;

	private List<SourceLocal> locals;

	private List<ImportInfo> imports;

	private List<MethodDebugConstant> constants;

	public ILSpan Span { get; set; }

	public List<MethodDebugScopeBuilder> Scopes
	{
		get
		{
			if (scopes == null)
			{
				scopes = new List<MethodDebugScopeBuilder>();
			}
			return scopes;
		}
	}

	public List<SourceLocal> Locals
	{
		get
		{
			if (locals == null)
			{
				locals = new List<SourceLocal>();
			}
			return locals;
		}
	}

	public List<ImportInfo> Imports
	{
		get
		{
			if (imports == null)
			{
				imports = new List<ImportInfo>();
			}
			return imports;
		}
	}

	public List<MethodDebugConstant> Constants
	{
		get
		{
			if (constants == null)
			{
				constants = new List<MethodDebugConstant>();
			}
			return constants;
		}
	}

	public MethodDebugScope ToScope()
	{
		return new MethodDebugScope(Span, (scopes == null) ? Array.Empty<MethodDebugScope>() : ToScopes(scopes), (locals == null || locals.Count == 0) ? Array.Empty<SourceLocal>() : locals.ToArray(), (imports == null || imports.Count == 0) ? Array.Empty<ImportInfo>() : imports.ToArray(), (constants == null || constants.Count == 0) ? Array.Empty<MethodDebugConstant>() : constants.ToArray());
	}

	private static MethodDebugScope[] ToScopes(List<MethodDebugScopeBuilder> scopes)
	{
		MethodDebugScope[] array = new MethodDebugScope[scopes.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = scopes[i].ToScope();
		}
		return array;
	}
}
