namespace AssetRipper.Import.Structure.Assembly.Recovery;

/// <summary>
/// The result of attempting to recover a single method body from Il2Cpp machine code.
/// </summary>
public enum MethodRecoveryOutcome
{
	/// <summary>
	/// The declaring assembly is excluded from analysis for performance reasons.
	/// </summary>
	Excluded,
	/// <summary>
	/// The method has no managed body to fill, such as an abstract or extern method.
	/// </summary>
	NoBody,
	/// <summary>
	/// Recovery threw an exception. The body was replaced with a throw statement containing the error message.
	/// </summary>
	Failed,
	/// <summary>
	/// Recovery completed without throwing, but produced no meaningful instructions,
	/// so the body only returns a default value.
	/// </summary>
	Minimal,
	/// <summary>
	/// Recovery produced real instructions.
	/// </summary>
	Recovered,
}
