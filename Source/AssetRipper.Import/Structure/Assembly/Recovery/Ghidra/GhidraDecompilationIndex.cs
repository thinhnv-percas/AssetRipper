using System.Globalization;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// The decompiled pseudo C for each method, looked up by a key that both Cpp2IL and ILSpy can build.
/// </summary>
/// <remarks>
/// Ghidra runs during import but the output is needed during export, so the result is parked here in
/// between. Matching is by declaring type, method name and parameter count rather than by address,
/// because the assemblies handed to ILSpy are generated and no longer carry the native addresses.
/// </remarks>
public sealed class GhidraDecompilationIndex
{
	/// <summary>
	/// The file the Ghidra script writes into its output directory.
	/// </summary>
	public const string FileName = "decompilation_index.txt";

	private readonly Dictionary<string, string> codeByKey;

	private GhidraDecompilationIndex(Dictionary<string, string> codeByKey)
	{
		this.codeByKey = codeByKey;
	}

	/// <summary>
	/// The index from the most recent Ghidra run, if there was one.
	/// </summary>
	public static GhidraDecompilationIndex? Current { get; set; }

	public int Count => codeByKey.Count;

	public bool TryGetCode(string key, [NotNullWhen(true)] out string? code)
	{
		return codeByKey.TryGetValue(key, out code);
	}

	/// <summary>
	/// Builds the key used to match a native function to a managed method.
	/// </summary>
	/// <remarks>
	/// Nested type separators differ between Cpp2IL and ILSpy, so they are normalized here.
	/// </remarks>
	public static string CreateKey(string? declaringTypeFullName, string? methodName, int parameterCount)
	{
		string type = NormalizeTypeName(declaringTypeFullName);
		return $"{type}|{methodName}|{parameterCount.ToString(CultureInfo.InvariantCulture)}";
	}

	private static string NormalizeTypeName(string? fullName)
	{
		if (string.IsNullOrEmpty(fullName))
		{
			return "";
		}

		StringBuilder builder = new(fullName.Length);
		foreach (char c in fullName)
		{
			builder.Append(c is '+' or '/' ? '.' : c);
		}
		return builder.ToString();
	}

	/// <summary>
	/// Reads an index written by the Ghidra export script.
	/// </summary>
	public static GhidraDecompilationIndex Read(TextReader reader)
	{
		Dictionary<string, string> codeByKey = new(StringComparer.Ordinal);

		while (reader.ReadLine() is string line)
		{
			if (line.Length == 0 || line[0] is '#')
			{
				continue;
			}

			int separator = line.IndexOf('\t');
			if (separator <= 0)
			{
				continue;
			}

			string key = line[..separator];
			string code = Unescape(line[(separator + 1)..]);
			codeByKey[key] = code;
		}

		return new GhidraDecompilationIndex(codeByKey);
	}

	public static GhidraDecompilationIndex? TryReadFrom(string directory)
	{
		string path = Path.Join(directory, FileName);
		if (!File.Exists(path))
		{
			return null;
		}

		using StreamReader reader = new(path);
		return Read(reader);
	}

	/// <summary>
	/// Reverses the escaping the export script applies so that each record fits on one line.
	/// </summary>
	public static string Unescape(string value)
	{
		if (!value.Contains('\\'))
		{
			return value;
		}

		StringBuilder builder = new(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] is not '\\' || i + 1 >= value.Length)
			{
				builder.Append(value[i]);
				continue;
			}

			i++;
			builder.Append(value[i] switch
			{
				'n' => '\n',
				't' => '\t',
				'\\' => '\\',
				char other => other,
			});
		}

		return builder.ToString();
	}
}
