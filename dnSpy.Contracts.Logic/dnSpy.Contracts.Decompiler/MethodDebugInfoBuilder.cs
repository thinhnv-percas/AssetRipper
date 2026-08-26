using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class MethodDebugInfoBuilder
{
	private readonly MethodDef method;

	private readonly MethodDef kickoffMethod;

	private readonly StateMachineKind stateMachineKind;

	private readonly List<SourceStatement> statements;

	private readonly int decompilerSettingsVersion;

	public string CompilerName { get; set; }

	public MethodDebugScopeBuilder Scope { get; }

	public SourceParameter[] Parameters { get; set; }

	public AsyncMethodDebugInfo AsyncInfo { get; set; }

	public int? StartPosition { get; set; }

	public int? EndPosition { get; set; }

	public MethodDebugInfoBuilder(int decompilerSettingsVersion, StateMachineKind stateMachineKind, MethodDef method, MethodDef kickoffMethod)
	{
		this.decompilerSettingsVersion = decompilerSettingsVersion;
		this.stateMachineKind = stateMachineKind;
		this.method = method ?? throw new ArgumentNullException("method");
		this.kickoffMethod = kickoffMethod;
		statements = new List<SourceStatement>();
		Scope = new MethodDebugScopeBuilder();
		Scope.Span = ILSpan.FromBounds(0u, (uint)method.Body.GetCodeSize());
		if (method == kickoffMethod)
		{
			throw new ArgumentException();
		}
	}

	public MethodDebugInfoBuilder(int decompilerSettingsVersion, StateMachineKind stateMachineKind, MethodDef method, MethodDef kickoffMethod, SourceLocal[] locals, SourceParameter[] parameters, AsyncMethodDebugInfo asyncInfo)
		: this(decompilerSettingsVersion, stateMachineKind, method, kickoffMethod)
	{
		Scope.Locals.AddRange(locals);
		Parameters = parameters;
		AsyncInfo = asyncInfo;
	}

	public void Add(SourceStatement statement)
	{
		statements.Add(statement);
	}

	public MethodDebugInfo Create()
	{
		TextSpan? methodSpan = ((!StartPosition.HasValue || !EndPosition.HasValue || StartPosition.Value > EndPosition.Value) ? ((TextSpan?)null) : new TextSpan?(TextSpan.FromBounds(StartPosition.Value, EndPosition.Value)));
		return new MethodDebugInfo(CompilerName, decompilerSettingsVersion, stateMachineKind, method, kickoffMethod, Parameters, statements.ToArray(), Scope.ToScope(), methodSpan, AsyncInfo);
	}
}
