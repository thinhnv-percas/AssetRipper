using System.Security.Cryptography;
using System.Text;

namespace AssetRipper.Il2CppRestore.Emit;

/// <summary>
/// Writes a lifted type as a Unity script under <c>Assets/</c>, with the <c>.meta</c> file that makes
/// scenes and prefabs actually resolve <c>m_Script</c> back to it (guide §12.2).
/// </summary>
public static class UnityProjectWriter
{
	/// <summary>
	/// <c>fileID: 11500000</c> is the fixed MonoScript file ID every source-file script reference in a
	/// scene/prefab/asset uses — this is not a hash of anything, just a constant IL2CPP/Unity itself uses.
	/// </summary>
	public const long MonoScriptFileId = 11500000;

	/// <summary>
	/// A deterministic GUID from (assembly, full type name). The exact hash does not matter — the only
	/// requirement is that this function and nowhere else decides a script's GUID, and that it is stable
	/// across runs, so a <c>.cs.meta</c> written today still matches an <c>m_Script</c> reference written
	/// yesterday.
	/// </summary>
	public static string ScriptGuid(string assemblyName, string fullTypeName)
	{
		string key = $"{Path.GetFileNameWithoutExtension(assemblyName)}\\{fullTypeName}";
		byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(key));
		return Convert.ToHexString(hash).ToLowerInvariant();
	}

	/// <summary>
	/// Writes the <c>.cs</c> file and its matching <c>.meta</c> under <c>Assets/Scripts/&lt;namespace&gt;/</c>.
	/// </summary>
	public static void WriteScript(string assetsRoot, string assemblyName, string fullTypeName, string code)
	{
		int lastDot = fullTypeName.LastIndexOf('.');
		string ns = lastDot >= 0 ? fullTypeName[..lastDot] : "";
		string className = lastDot >= 0 ? fullTypeName[(lastDot + 1)..] : fullTypeName;

		string dir = Path.Combine(assetsRoot, "Scripts", ns.Replace('.', Path.DirectorySeparatorChar));
		// A namespace deep enough to blow past MAX_PATH on Windows falls back to a flat, underscore-joined
		// folder name rather than failing the whole export over one pathological type.
		if (dir.Length > 200)
		{
			dir = Path.Combine(assetsRoot, "Scripts", ns.Replace('.', '_'));
		}

		Directory.CreateDirectory(dir);
		string path = MakeUnique(Path.Combine(dir, SanitizeFileName(className) + ".cs"));

		// Unity's own compiler expects a BOM on any .cs file containing non-ASCII characters; writing it
		// unconditionally is simpler than detecting that case and is harmless either way.
		File.WriteAllText(path, code, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

		string guid = ScriptGuid(assemblyName, fullTypeName);
		// $$"""...""" (not $"""...""") because the literal YAML itself contains "{}" and "{instanceID: 0}" —
		// with a single '$', raw string interpolation reads consecutive braces as a request for a
		// higher-count interpolation delimiter (CS9006), not as literal text.
		File.WriteAllText(path + ".meta", $$"""
			fileFormatVersion: 2
			guid: {{guid}}
			MonoImporter:
			  externalObjects: {}
			  serializedVersion: 2
			  defaultReferences: []
			  executionOrder: 0
			  icon: {instanceID: 0}
			  userData:
			  assetBundleName:
			  assetBundleVariant:
			""");
	}

	/// <summary>
	/// The <c>{fileID: 11500000, guid: ..., type: 3}</c> block every scene/prefab reference to this
	/// script must use — provided so a future package-remapping-style step can write these consistently.
	/// </summary>
	public static string ScriptReference(string assemblyName, string fullTypeName) =>
		$"{{fileID: {MonoScriptFileId}, guid: {ScriptGuid(assemblyName, fullTypeName)}, type: 3}}";

	private static string SanitizeFileName(string name)
	{
		foreach (char c in Path.GetInvalidFileNameChars())
		{
			name = name.Replace(c, '_');
		}
		return name;
	}

	private static string MakeUnique(string path)
	{
		if (!File.Exists(path))
		{
			return path;
		}

		string directory = Path.GetDirectoryName(path) ?? "";
		string nameWithoutExtension = Path.GetFileNameWithoutExtension(path);
		string extension = Path.GetExtension(path);
		for (int i = 1; ; i++)
		{
			string candidate = Path.Combine(directory, $"{nameWithoutExtension}_{i}{extension}");
			if (!File.Exists(candidate))
			{
				return candidate;
			}
		}
	}
}
