namespace AssetRipper.Il2CppRestore.Binary;

/// <summary>
/// A loaded game binary (<c>libil2cpp.so</c>, <c>GameAssembly.dll</c>, a Mach-O slice, or a
/// <c>.wasm</c> module), abstracted just enough for everything past step 2 of the guide to not care
/// which format it actually is.
/// </summary>
public interface IBinaryImage
{
	bool Is32Bit { get; }
	Architecture Arch { get; }

	/// <summary>Virtual address to file offset, or -1 when the address is not backed by any loaded region.</summary>
	long MapVaToOffset(ulong va);

	/// <summary>File offset to virtual address, or 0 when the offset is not inside any loaded region.</summary>
	ulong MapOffsetToVa(long offset);

	ReadOnlyMemory<byte> Data { get; }

	IReadOnlyList<BinarySection> Sections { get; }

	/// <summary>
	/// Exported/debug symbol name by virtual address. Empty when the binary has been stripped, which is
	/// the common case for a shipped IL2CPP build — everything downstream must tolerate that.
	/// </summary>
	IReadOnlyDictionary<ulong, string> SymbolsByVa { get; }

	ulong ReadPointer(long fileOffset);
}

public readonly record struct BinarySection(string Name, ulong Va, long Offset, long Size, bool Executable);

public static class BinaryImageExtensions
{
	public static ulong ReadPointerAtVa(this IBinaryImage image, ulong va)
	{
		long offset = image.MapVaToOffset(va);
		return offset < 0 ? 0 : image.ReadPointer(offset);
	}
}
