using Cpp2IL.Core.Model.Contexts;
using System.Globalization;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Writes the address of every Il2Cpp method along with its managed name, so that a disassembler can
/// label the native functions.
/// </summary>
/// <remarks>
/// This is the piece that makes native decompilation readable. Il2Cpp keeps full type and method
/// names in its metadata even though the compiled code has no symbols, so every function can be
/// named without any guesswork.
/// </remarks>
public static class Il2CppSymbolTable
{
	/// <summary>
	/// One method: where it lives in the binary, which assembly it belongs to, what it is called, and
	/// the key used to match it back to a managed method when exporting.
	/// </summary>
	public readonly record struct Entry(ulong Address, string Group, string Name, string Key);

	/// <summary>
	/// Writes the entries as a tab separated file.
	/// </summary>
	public static void Write(IEnumerable<Entry> entries, TextWriter writer)
	{
		writer.WriteLine("# address\tgroup\tname\tkey");
		foreach (Entry entry in entries)
		{
			writer.Write("0x");
			writer.Write(entry.Address.ToString("x", CultureInfo.InvariantCulture));
			writer.Write('\t');
			writer.Write(Sanitize(entry.Group));
			writer.Write('\t');
			writer.Write(Sanitize(entry.Name));
			writer.Write('\t');
			writer.Write(Sanitize(entry.Key));
			writer.WriteLine();
		}
	}

	/// <summary>
	/// Collects every method that has a native address.
	/// </summary>
	public static List<Entry> Collect(ApplicationAnalysisContext context)
	{
		List<Entry> entries = [];

		foreach (AssemblyAnalysisContext assembly in context.Assemblies)
		{
			string group = assembly.Definition?.AssemblyName.Name ?? "Unknown";

			foreach (TypeAnalysisContext type in assembly.Types)
			{
				foreach (MethodAnalysisContext method in type.Methods)
				{
					// Abstract and runtime provided methods have no code to point at.
					if (method.UnderlyingPointer == 0)
					{
						continue;
					}

					string key = GhidraDecompilationIndex.CreateKey(type.FullName, method.DefaultName, method.Parameters.Count);
					entries.Add(new Entry(method.UnderlyingPointer, group, method.FullName, key));
				}
			}
		}

		return entries;
	}

	/// <summary>
	/// Removes the characters that would break the tab separated format.
	/// </summary>
	private static string Sanitize(string value)
	{
		if (value.AsSpan().IndexOfAny('\t', '\r', '\n') < 0)
		{
			return value;
		}

		return value.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
	}
}
