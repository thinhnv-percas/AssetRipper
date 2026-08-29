namespace AssetRipper.Il2CppRestore.Metadata;

/// <summary>
/// Every metadata section reduces to a (byte offset, byte size) pair regardless of version — v39's
/// three-field <c>Il2CppSectionMetadata</c> (offset, size, count) is read down to this same shape, so
/// nothing past <see cref="MetadataHeader"/> needs to know which header layout was actually on disk.
/// </summary>
public readonly record struct Section(int Offset, int Size);

/// <summary>
/// <c>global-metadata.dat</c>'s header: where every section lives. The single riskiest piece of the
/// whole reader, because getting the section order wrong does not throw — it silently reads every
/// section that follows at the wrong offset. See <see cref="Read"/>'s self-check and §4.3/§13 of the
/// integration guide before adding a new version.
/// </summary>
public sealed class MetadataHeader
{
	public const uint ExpectedSanity = 0xFAB11BAF;

	public uint Sanity;
	public int Version;

	public Section StringLiterals, StringLiteralData, Strings;
	public Section Events, Properties, Methods;
	public Section ParameterDefaultValues, FieldDefaultValues, FieldAndParameterDefaultValueData;
	public Section FieldMarshaledSizes, Parameters, Fields;
	public Section GenericParameters, GenericParameterConstraints, GenericContainers;
	public Section NestedTypes, Interfaces, VTableMethods, InterfaceOffsets;
	public Section TypeDefinitions, Images, Assemblies;
	public Section FieldRefs, ReferencedAssemblies;

	// v24..v27 only: superseded by direct decoding of Il2CppMetadataRegistration.metadataUsages in the
	// binary from v29 onward (guide §8). Read here only so field/section counting still lines up when
	// parsing an older file.
	public Section MetadataUsageLists, MetadataUsagePairs;

	// v24..v27: a flat list of attribute types per index range.
	public Section AttributesInfo, AttributeTypes;
	// v29+: attributes moved to a serialized binary blob, ECMA-335 CustomAttribute-shaped.
	public Section AttributeData, AttributeDataRanges;

	/// <summary>
	/// Reads the header for whichever version is actually on disk.
	/// </summary>
	/// <exception cref="InvalidDataException">The file does not start with the IL2CPP metadata sanity value.</exception>
	public static MetadataHeader Read(VersionedReader reader)
	{
		reader.Position = 0;
		MetadataHeader header = new() { Sanity = reader.ReadUInt32(), Version = reader.ReadInt32() };
		if (header.Sanity != ExpectedSanity)
		{
			throw new InvalidDataException("Not an IL2CPP global-metadata.dat file (bad sanity value).");
		}

		reader.Version = ProbeSubVersion(reader, header.Version);
		reader.Position = 8;

		// A section is (offset, size) before v39, (offset, size, count) from v39 on — the extra field is
		// simply dropped here since Section never needed the count.
		Section Next() => reader.Version >= 39 ? ReadTriple(reader) : ReadPair(reader);

		header.StringLiterals = Next();
		header.StringLiteralData = Next();
		header.Strings = Next();
		header.Events = Next();
		header.Properties = Next();
		header.Methods = Next();
		header.ParameterDefaultValues = Next();
		header.FieldDefaultValues = Next();
		header.FieldAndParameterDefaultValueData = Next();
		header.FieldMarshaledSizes = Next();
		header.Parameters = Next();
		header.Fields = Next();
		header.GenericParameters = Next();
		header.GenericParameterConstraints = Next();
		header.GenericContainers = Next();
		header.NestedTypes = Next();
		header.Interfaces = Next();
		header.VTableMethods = Next();
		header.InterfaceOffsets = Next();
		header.TypeDefinitions = Next();

		if (reader.Version <= 24.1)
		{
			// Legacy rgctx range sections lived here on very old metadata; they are per-TypeDefinition
			// fields on that version instead (see Il2CppTypeDefinition.rgctxStartIndex/Count), not a
			// section of their own, so there is nothing extra to consume — kept as a named branch point
			// because older tools disagree on this and it is worth a version-specific home if that
			// changes once checked against a real 24.0/24.1 header.
		}

		header.Images = Next();
		header.Assemblies = Next();

		if (reader.Version <= 27)
		{
			header.MetadataUsageLists = Next();
			header.MetadataUsagePairs = Next();
		}

		header.FieldRefs = Next();
		header.ReferencedAssemblies = Next();

		if (reader.Version <= 27)
		{
			header.AttributesInfo = Next();
			header.AttributeTypes = Next();
		}
		else
		{
			header.AttributeData = Next();
			header.AttributeDataRanges = Next();
		}

		// Sections past this point (unresolvedIndirectCall*, windowsRuntime*, exportedTypeDefinitions,
		// …) are not read: nothing in this pipeline currently needs them. Add a Next() call here, in the
		// same order as GlobalMetadataFileInternals.h, the day something does.

		// The runtime itself asserts this (GlobalMetadata.cpp), and it is the cheapest, strongest check
		// available: getting any section above wrong shifts every offset from here on, and this would
		// almost certainly not equal the true header size if that happened.
		int headerSize = HeaderSizeFor(reader);
		if (header.StringLiterals.Offset != headerSize)
		{
			throw new InvalidDataException(
				$"Metadata header self-check failed for version {reader.Version}: expected the first " +
				$"section at offset {headerSize} (the header's own size) but it claims {header.StringLiterals.Offset}. " +
				"The section list above does not match this file's actual layout — compare against " +
				"GlobalMetadataFileInternals.h for this Unity version before trusting anything read after this point.");
		}

		return header;
	}

	private static Section ReadPair(VersionedReader reader) => new(reader.ReadInt32(), reader.ReadInt32());

	private static Section ReadTriple(VersionedReader reader)
	{
		int offset = reader.ReadInt32();
		int size = reader.ReadInt32();
		_ = reader.ReadInt32(); // count — not needed once Section already carries Size.
		return new Section(offset, size);
	}

	/// <summary>
	/// How many bytes the header itself occupies, by reading it once and seeing where it ends up.
	/// </summary>
	private static int HeaderSizeFor(VersionedReader reader) => (int)reader.Position;

	/// <summary>
	/// Metadata version 24 alone covers Unity 2018.3 through 2019.4 (24.0 .. 24.5) with layouts that
	/// differ but are indistinguishable from the version number in the header. Resolved by trial: read
	/// with each candidate sub-version and keep the first one whose header actually checks out.
	/// </summary>
	/// <remarks>
	/// Reading with the wrong sub-version does not throw — it produces a header that looks plausible and
	/// is wrong, which surfaces much later as garbage in step 8. These three checks are cheap and catch
	/// nearly every wrong guess before that happens.
	/// </remarks>
	private static double ProbeSubVersion(VersionedReader reader, int majorVersion)
	{
		if (majorVersion != 24)
		{
			return majorVersion;
		}

		long dataLength = reader.BaseStream.Length;
		foreach (double candidate in (double[])[24.0, 24.1, 24.2, 24.3, 24.4, 24.5])
		{
			reader.Version = candidate;
			try
			{
				reader.Position = 8;
				int headerSize = ProbeHeaderSize(reader, candidate);
				reader.Position = 0;
				reader.ReadUInt32();
				reader.ReadInt32();
				Section stringLiterals = candidate >= 39 ? ReadTriple(reader) : ReadPair(reader);

				if (stringLiterals.Offset != headerSize)
				{
					continue;
				}
				if (stringLiterals.Offset < 0 || stringLiterals.Offset > dataLength
					|| stringLiterals.Size < 0 || stringLiterals.Offset + stringLiterals.Size > dataLength)
				{
					continue;
				}

				return candidate;
			}
			catch
			{
				// Try the next candidate.
			}
		}

		throw new NotSupportedException(
			$"Could not determine the metadata 24.x sub-version. Set it explicitly if known; otherwise " +
			"compare GlobalMetadataFileInternals.h for the exact Unity version this file came from.");
	}

	/// <summary>
	/// Reads a throwaway header at the given candidate version purely to measure how many bytes it
	/// consumes, without any of the invariant checks <see cref="Read"/> itself performs.
	/// </summary>
	private static int ProbeHeaderSize(VersionedReader reader, double candidate)
	{
		reader.Position = 8;
		reader.Version = candidate;
		int sectionCount = 20 // StringLiterals .. TypeDefinitions
			+ 2  // Images, Assemblies
			+ (candidate <= 27 ? 2 : 0) // MetadataUsageLists/Pairs
			+ 2  // FieldRefs, ReferencedAssemblies
			+ 2; // Attributes(Info/Types) or (Data/DataRanges)
		int perSection = candidate >= 39 ? 12 : 8;
		return 8 + sectionCount * perSection;
	}
}
