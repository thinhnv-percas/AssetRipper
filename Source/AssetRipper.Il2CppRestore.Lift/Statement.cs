namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>
/// One line of the lifted pseudocode. Deliberately a small, closed set: everything the lifter cannot
/// confidently turn into one of these stays inside the symbolic register state (<see cref="SymValue"/>)
/// and is inlined into whichever statement finally consumes it, rather than ever being printed on its
/// own. A lifter that leaks its internal representation as if it were a statement — an unresolved method
/// signature, a raw IL-shaped fragment — is exactly the failure this design avoids: see the integration
/// notes for how that class of bug produces output like <c>goto #0x9fd154;</c>.
/// </summary>
public abstract record Statement
{
	public sealed record Label(ulong Address) : Statement;

	public sealed record Call(string Method, IReadOnlyList<SymValue> Args, string? ResultTempName, string ResultType) : Statement;

	public sealed record Return(SymValue? Value) : Statement;

	public sealed record Branch(string Mnemonic, SymValue Condition, ulong Target) : Statement;

	public sealed record Goto(ulong Target) : Statement;

	public sealed record Comment(string Text) : Statement;

	public string ToLine()
	{
		return this switch
		{
			Label l => $"label_0x{l.Address:X}:",
			Call c => RenderCall(c),
			Return r => r.Value is null ? "return;" : $"return {r.Value.ToExpression()};",
			Branch b => $"if ({RenderCondition(b)}) goto label_0x{b.Target:X};",
			Goto g => $"goto label_0x{g.Target:X};",
			Comment cm => $"// {cm.Text}",
			_ => "// <unrenderable statement>",
		};
	}

	private static string RenderCall(Call c)
	{
		string args = string.Join(", ", c.Args.Select(a => a.ToExpression()));
		string call = $"{c.Method}({args});";
		return c.ResultTempName is null ? call : $"{c.ResultType} {c.ResultTempName} = {call}";
	}

	private static string RenderCondition(Branch b)
	{
		string value = b.Condition.ToExpression();
		return b.Mnemonic switch
		{
			"CBZ" or "TBZ" => $"{value} == 0",
			"CBNZ" or "TBNZ" => $"{value} != 0",
			_ => value,
		};
	}
}
