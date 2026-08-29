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
	/// IL2Cpp methods are recovered by disassembling and lifting the native binary directly, as a post-export
	/// pass over the files <see cref="Level2"/>/<see cref="Level3"/> already produced. Requires a struct DB folder
	/// (see <c>AssetRipper.Il2CppRestore.StructDb</c>) to resolve native field names inside lifted bodies.
	/// </summary>
	Level4,
}
