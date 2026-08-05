namespace AssetRipper.Import.Structure.Assembly.Recovery;

/// <summary>
/// The outcome of Il2Cpp method body recovery for one method.
/// </summary>
/// <param name="Assembly">The name of the module declaring the method.</param>
/// <param name="Method">The full name of the method, including its signature.</param>
/// <param name="Outcome">How recovery ended for this method.</param>
/// <param name="InstructionCount">The number of CIL instructions in the resulting body.</param>
/// <param name="FailureMessage">The error message when <paramref name="Outcome"/> is <see cref="MethodRecoveryOutcome.Failed"/>.</param>
public readonly record struct MethodRecoveryRecord(
	string Assembly,
	string Method,
	MethodRecoveryOutcome Outcome,
	int InstructionCount,
	string? FailureMessage);
