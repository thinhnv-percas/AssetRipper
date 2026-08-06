namespace AssetRipper.Import.Configuration;

public enum ScriptContentLevel
{
	/// <summary>
	/// Scripts are not loaded.
	/// </summary>
	Level0,
	/// <summary>
	/// Methods are stubbed during processing.
	/// </summary>
	Level1,
	/// <summary>
	/// This level is the default. It has full methods for Mono games and empty methods for IL2Cpp games.
	/// </summary>
	Level2,
	/// <summary>
	/// IL2Cpp methods are safely recovered where possible.
	/// </summary>
	Level3,
	/// <summary>
	/// Everything <see cref="Level3"/> does, plus the native binary is decompiled with Ghidra.
	/// </summary>
	/// <remarks>
	/// Ghidra produces pseudo C rather than C#, but it covers nearly every method instead of the
	/// fraction that <see cref="Level3"/> manages, and it handles ARM well. This requires a Ghidra
	/// installation and adds an hour or more to loading.
	/// </remarks>
	Level4,
}
