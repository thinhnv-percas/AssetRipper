using System;

namespace dnSpy.Contracts.Decompiler;

public sealed class AddressReference : IEquatable<AddressReference>
{
	public string Filename { get; }

	public bool IsRVA { get; }

	public ulong Address { get; }

	public ulong Length { get; }

	public AddressReference(string filename, bool isRva, ulong address, ulong length)
	{
		Filename = filename ?? string.Empty;
		IsRVA = isRva;
		Address = address;
		Length = length;
	}

	public bool Equals(AddressReference other)
	{
		return other != null && IsRVA == other.IsRVA && Address == other.Address && Length == other.Length && StringComparer.OrdinalIgnoreCase.Equals(Filename, other.Filename);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as AddressReference);
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(Filename) ^ ((!IsRVA) ? int.MinValue : 0) ^ (int)Address ^ (int)(Address >> 32) ^ (int)Length ^ (int)(Length >> 32);
	}
}
