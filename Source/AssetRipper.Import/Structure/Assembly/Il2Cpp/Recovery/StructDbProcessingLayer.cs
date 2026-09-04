using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Loads the IL2CPP runtime struct layout matching the game's Unity version and pointer size, and
/// publishes it on the application context for later layers.
/// </summary>
/// <remarks>
/// Runs first and never throws: with no database, later layers simply leave memory accesses unnamed,
/// which is the behaviour without this port at all.
/// </remarks>
public sealed class StructDbProcessingLayer(string? databaseDirectory) : Cpp2IlProcessingLayer
{
	/// <summary>Key under which <see cref="RuntimeStructDb"/> is published on the application context.</summary>
	public const string ContextKey = "assetripper.il2cpp.structdb";

	public override string Name => "IL2CPP Struct Database";

	public override string Id => "structdb";

	public override void Process(ApplicationAnalysisContext appContext, Action<int, int>? progressCallback = null)
	{
		// A patch left over from a previous run would describe the wrong Unity version.
		Il2CppClassOffsetPatcher.Restore();

		StructDbCatalog? catalog = StructDbCatalog.TryCreate(databaseDirectory);
		if (catalog is null)
		{
			Logger.Info(LogCategory.Import,
				"IL2CPP struct database not found; recovered method bodies will show raw offsets instead of runtime field names.");
			return;
		}

		bool is32Bit = appContext.Binary.is32Bit;
		RuntimeStructDb? db = catalog.Load(appContext.UnityVersion, is32Bit);
		if (db is null)
		{
			return;
		}

		appContext.PutExtraData(ContextKey, db);

		// Cpp2IL's own Il2CppClass offset table holds two versions of 64-bit constants and nothing for
		// 32-bit. Measured offsets are strictly better wherever the database covers the game's version.
		Il2CppClassOffsetPatcher.Apply(db);

		Logger.Info(LogCategory.Import,
			$"IL2CPP struct database loaded: Unity {db.Version}, {(is32Bit ? "32" : "64")}-bit, sizeof(Il2CppClass) = {db.GetSize("Il2CppClass")}");

		progressCallback?.Invoke(1, 1);
	}

	/// <summary>Retrieves the database published by this layer, or null when none was loaded.</summary>
	public static RuntimeStructDb? Get(ApplicationAnalysisContext appContext)
		=> appContext.GetExtraData<RuntimeStructDb>(ContextKey);
}
