namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>
/// What one ARM64/x64 register or memory slot symbolically holds while lifting a function — the whole
/// point of not just printing raw register numbers (guide §11.2). Each subtype renders to a small piece
/// of readable C#; nothing here is ever written out on its own except as an operand of a
/// <see cref="Statement"/>.
/// </summary>
public abstract record SymValue
{
	public sealed record Unknown : SymValue;

	public sealed record Const(long Value) : SymValue;

	/// <summary>An incoming parameter. Index 0 for the first non-<c>this</c> parameter.</summary>
	public sealed record Arg(int Index, string Type) : SymValue;

	public sealed record This : SymValue;

	public sealed record Local(int Id, string Type) : SymValue;

	public sealed record StrLit(string Text) : SymValue;

	public sealed record TypeRef(string TypeName) : SymValue;

	public sealed record FieldOf(SymValue Obj, string Field, string Type) : SymValue;

	/// <summary>
	/// A value produced by a call already emitted as a <see cref="Statement.Call"/>. <see cref="TempName"/>
	/// is decided once, at the moment the call is lifted (not at render time), so every later reference
	/// to "whatever x0 held right after that call" prints the same name instead of re-emitting the call.
	/// </summary>
	public sealed record CallResult(string Method, string RetType, string TempName) : SymValue;

	/// <summary>Renders this value as a C# expression. Best-effort: <see cref="Unknown"/> renders as a comment placeholder, not invented data.</summary>
	public string ToExpression() => this switch
	{
		Const c => c.Value.ToString(),
		Arg a => $"arg{a.Index}",
		This => "this",
		Local l => $"local{l.Id}",
		StrLit s => "\"" + s.Text.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"",
		TypeRef t => $"typeof({t.TypeName})",
		FieldOf f => $"{f.Obj.ToExpression()}.{f.Field}",
		CallResult r => r.TempName,
		_ => "/* unknown */ default",
	};
}
