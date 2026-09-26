using System.Text;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: turning a compiled Metal program back into source. Declared, not implemented.
/// </summary>
/// <remarks>
/// An iOS build compiles its shaders to Metal, which is a library format rather than text: the iOS
/// fixture carries 1164 sub-programs and not one byte of shading-language source. Extraction cannot
/// reach it, and a decompiler for it is a project of its own. The interface exists so that the
/// pipeline has a named place for one and so that "not supported" is a stated verdict rather than an
/// absence; nothing in this repository implements it.
/// </remarks>
public interface IMetalShaderDecompiler
{
	/// <summary>The source of one Metal function, or null when this decompiler cannot produce it.</summary>
	string? Decompile(ReadOnlySpan<byte> library, string functionName);
}

/// <summary>What can be read out of a compiled Metal program without decompiling it.</summary>
public static class MetalShaderLibrary
{
	/// <summary>Apple's `metallib` magic, little-endian.</summary>
	private static readonly byte[] Magic = [(byte)'M', (byte)'T', (byte)'L', (byte)'B'];

	public sealed record Evidence(
		bool IsMetalLibrary,
		int MagicOffset,
		int Length,
		IReadOnlyList<string> FunctionNames,
		string Status);

	/// <summary>
	/// Reads what the bytes state about themselves: whether they are a Metal library, where it starts
	/// and which function names it carries. Never guesses a stage or a body.
	/// </summary>
	public static Evidence Read(ReadOnlySpan<byte> bytes)
	{
		int offset = IndexOf(bytes, Magic);

		if (offset < 0)
		{
			return new Evidence(false, -1, bytes.Length, [], "NOT_A_METAL_LIBRARY");
		}

		// Function names are stored as plain strings in the library's name table. Reading them needs
		// no format knowledge beyond "a run of printable bytes ending in a NUL", and they are the one
		// thing a reader can act on: they name the entry points the pass was compiled with.
		List<string> names = [];
		StringBuilder current = new();

		for (int position = offset; position < bytes.Length; position++)
		{
			byte value = bytes[position];

			if (value is >= 0x20 and < 0x7F)
			{
				current.Append((char)value);
				continue;
			}

			if (current.Length >= 4 && (current.ToString().Contains("_main", StringComparison.Ordinal)
				|| current.ToString().StartsWith("xlat", StringComparison.Ordinal)))
			{
				names.Add(current.ToString());
			}

			current.Clear();
		}

		return new Evidence(true, offset, bytes.Length, names, "BINARY_ONLY_NO_DECOMPILER");
	}

	private static int IndexOf(ReadOnlySpan<byte> haystack, ReadOnlySpan<byte> needle)
	{
		for (int position = 0; position + needle.Length <= haystack.Length; position++)
		{
			if (haystack.Slice(position, needle.Length).SequenceEqual(needle))
			{
				return position;
			}
		}

		return -1;
	}
}
