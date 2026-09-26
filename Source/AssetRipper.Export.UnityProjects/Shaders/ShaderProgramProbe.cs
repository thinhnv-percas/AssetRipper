using System.Text;
using AssetRipper.SourceGenerated.Classes.ClassID_48;
using AssetRipper.SourceGenerated.Extensions.Enums.Shader;
using K4os.Compression.LZ4;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: what a shader's compiled program blobs actually contain, established by reading them
/// rather than by assuming what a backend implies.
/// </summary>
/// <remarks>
/// <para>
/// This project has carried the note "GLES means GLSL text is <em>not</em> confirmed" since the
/// backends were first read, and nothing had ever opened a blob to settle it. A probe that reports
/// evidence - how the bytes decompress, what the entry table says, how much of a sub-program is
/// printable and which shading-language markers appear in it - settles it either way, and says
/// <see cref="ProgramEncoding.Unknown"/> where it cannot.
/// </para>
/// <para>
/// Nothing here decompiles. The one question is what kind of thing is in the blob, because until that
/// is known every plan for recovering it is a guess about the input.
/// </para>
/// </remarks>
public static class ShaderProgramProbe
{
	/// <summary>What the bytes of one sub-program turned out to be.</summary>
	public enum ProgramEncoding
	{
		/// <summary>Not established. Never inferred from the backend.</summary>
		Unknown,

		/// <summary>Shading-language source, in the clear, with recognisable markers.</summary>
		SourceText,

		/// <summary>Mostly printable but with none of the markers a shading language carries.</summary>
		PrintableNoMarkers,

		/// <summary>Not printable: a compiled form of some kind.</summary>
		Binary,

		/// <summary>The blob would not decompress, so nothing can be said about its contents.</summary>
		Undecodable,

		/// <summary>
		/// A compiled Metal library. Not source, and not reachable by extraction: see
		/// <see cref="IMetalShaderDecompiler"/>, which is declared and deliberately unimplemented.
		/// </summary>
		MetalLibrary,
	}

	public sealed record SubProgramEvidence(
		int Platform,
		string Backend,
		int Index,
		int Offset,
		int Length,
		ProgramEncoding Encoding,
		double PrintableRatio,
		IReadOnlyList<string> Markers,
		string HeadHex,
		int TextOffset,
		int TextLength);

	public sealed record ShaderEvidence(
		string Shader,
		bool HasBlob,
		int CompressedBlobLength,
		int PlatformCount,
		string BlobShape,
		IReadOnlyList<SubProgramEvidence> SubPrograms,
		string? Failure);

	/// <summary>
	/// Markers a shading language writes in the clear. Every one of them is a token no compiled form
	/// would contain by accident at this length, and finding any of them in a printable run is what
	/// makes <see cref="ProgramEncoding.SourceText"/> a reading of the bytes rather than a guess.
	/// </summary>
	private static readonly string[] Markers =
	[
		"#version", "void main", "gl_Position", "gl_FragColor", "attribute ", "varying ",
		"uniform ", "precision ", "highp ", "mediump ", "texture2D", "SV_POSITION", "cbuffer",
	];

	/// <summary>
	/// Probed evidence per shader, so the exporter and the report read the same decompression rather
	/// than each paying for their own and possibly disagreeing.
	/// </summary>
	private static readonly System.Runtime.CompilerServices.ConditionalWeakTable<IShader, ShaderEvidence> Cache = new();

	public static ShaderEvidence Probe(IShader shader)
	{
		if (Cache.TryGetValue(shader, out var cached))
			return cached;

		var probed = ProbeUncached(shader);
		Cache.AddOrUpdate(shader, probed);
		return probed;
	}

	/// <summary>
	/// The source text of one sub-program, or null when that blob index was not read as source.
	/// </summary>
	/// <remarks>
	/// A sub-program's <c>BlobIndex</c> is an index into <em>its own platform's</em> entry table, so
	/// the backend has to be matched before the index means anything. A backend this does not know how
	/// to match answers null rather than reaching into whichever table happens to be first.
	/// </remarks>
	public static string? SourceFor(IShader shader, string gpuProgramType, int blobIndex)
	{
		if (PlatformOf(gpuProgramType) is not { } wanted)
			return null;

		var evidence = Probe(shader);

		foreach (var program in evidence.SubPrograms)
		{
			if (program.Index == blobIndex
				&& string.Equals(program.Backend, wanted, StringComparison.Ordinal)
				&& program.Encoding == ProgramEncoding.SourceText)
			{
				return TextOf(shader, program);
			}
		}

		return null;
	}

	/// <summary>
	/// The bytes of one sub-program, read again on demand.
	/// </summary>
	/// <remarks>
	/// Deliberately not cached with the evidence. One of these games carries 3016 sub-programs whose
	/// source runs to several kilobytes each, and holding them all alive for the length of a run
	/// exhausted the container - so the evidence stays small and says <em>where</em> each program is,
	/// and the bytes are fetched by whoever needs one.
	/// </remarks>
	public static string? TextOf(IShader shader, SubProgramEvidence program)
	{
		if (!shader.Has_CompressedBlob())
			return null;

		try
		{
			var (_, segments) = ReadSegmentTable(shader, shader.Has_Platforms() ? shader.Platforms.Count : 0);

			if (program.Platform >= segments.Count)
				return null;

			byte[] decompressed = Decompress(shader.CompressedBlob, segments[program.Platform]);

			if (program.Offset + program.Length > decompressed.Length)
				return null;

			ReadOnlySpan<byte> bytes = decompressed.AsSpan(program.Offset, program.Length);
			return SourceTextOf(bytes, Encoding.Latin1.GetString(bytes));
		}
		catch (Exception)
		{
			return null;
		}
	}

	/// <summary>
	/// Which <c>GPUPlatform</c> a sub-program's compiled-program type belongs to. Only the pairs this
	/// project has read blobs for are listed; anything else is "not known", which is what stops a
	/// program being taken out of the wrong platform's table.
	/// </summary>
	public static string? PlatformNameOf(string gpuProgramType) => PlatformOf(gpuProgramType);

	private static string? PlatformOf(string gpuProgramType) => gpuProgramType switch
	{
		"GLES" => nameof(GPUPlatform.Gles20),
		"GLES3" or "GLES31" or "GLES31AEP" => nameof(GPUPlatform.Gles3x),
		"GLCore32" or "GLCore41" or "GLCore43" => nameof(GPUPlatform.GlCore),
		// Metal's two program types are one platform in the blob table. Without them every row of an
		// iOS build's mapping reads NOT_IN_TABLE, which says nothing about the build and everything
		// about the table not being consulted.
		"MetalVS" or "MetalFS" => nameof(GPUPlatform.Metal),
		"SPIRV" => nameof(GPUPlatform.Vulkan),
		_ => null,
	};

	private static ShaderEvidence ProbeUncached(IShader shader)
	{
		string name = shader.Has_ParsedForm() ? shader.ParsedForm.Name.String : "";

		if (!shader.Has_CompressedBlob() || shader.CompressedBlob.Length == 0)
			return new ShaderEvidence(name, false, 0, 0, "NONE", [], null);

		byte[] compressed = shader.CompressedBlob;
		int platformCount = shader.Has_Platforms() ? shader.Platforms.Count : 0;

		try
		{
			var (shape, segments) = ReadSegmentTable(shader, platformCount);
			List<SubProgramEvidence> found = [];

			for (int platform = 0; platform < segments.Count; platform++)
			{
				byte[] decompressed = Decompress(compressed, segments[platform]);

				if (decompressed.Length == 0)
					continue;

				string backend = platform < platformCount
					? ((GPUPlatform)shader.Platforms[platform]).ToString()
					: "?";

				var entries = ReadEntryTable(decompressed);

				// The index is the entry's position in this platform's table, because that is what a
				// sub-program's BlobIndex names. A running counter across platforms would look the
				// same in the report and point at the wrong program.
				for (int entry = 0; entry < entries.Count; entry++)
					found.Add(Classify(platform, backend, entry, entries[entry].Offset, entries[entry].Length, decompressed));
			}

			return new ShaderEvidence(name, true, compressed.Length, platformCount, shape, found, null);
		}
		catch (Exception exception)
		{
			return new ShaderEvidence(name, true, compressed.Length, platformCount, "READ_FAILED", [], exception.Message);
		}
	}

	/// <summary>
	/// The compressed segments of each platform, in whichever of the two shapes the asset carries.
	/// </summary>
	/// <remarks>
	/// Older builds record one offset and one pair of lengths per platform; newer ones record a list
	/// per platform, because the blob is split into segments that decompress and concatenate. Both are
	/// read; an asset carrying neither is reported as such rather than assumed to be the other.
	/// </remarks>
	private static (string Shape, List<List<(int Offset, int Compressed, int Decompressed)>> Segments) ReadSegmentTable(
		IShader shader, int platformCount)
	{
		List<List<(int, int, int)>> segments = [];

		if (shader.Has_Offsets_AssetList_AssetList_UInt32())
		{
			var offsets = shader.Offsets_AssetList_AssetList_UInt32;
			var compressedLengths = shader.CompressedLengths_AssetList_AssetList_UInt32;
			var decompressedLengths = shader.DecompressedLengths_AssetList_AssetList_UInt32;

			for (int platform = 0; platform < offsets.Count; platform++)
			{
				List<(int, int, int)> perPlatform = [];

				for (int segment = 0; segment < offsets[platform].Count; segment++)
				{
					perPlatform.Add((
						(int)offsets[platform][segment],
						(int)compressedLengths[platform][segment],
						(int)decompressedLengths[platform][segment]));
				}

				segments.Add(perPlatform);
			}

			return ("SEGMENTED", segments);
		}

		if (shader.Has_Offsets_AssetList_UInt32())
		{
			var offsets = shader.Offsets_AssetList_UInt32;
			var compressedLengths = shader.CompressedLengths_AssetList_UInt32;
			var decompressedLengths = shader.DecompressedLengths_AssetList_UInt32;

			for (int platform = 0; platform < offsets.Count; platform++)
			{
				segments.Add([((int)offsets[platform], (int)compressedLengths[platform], (int)decompressedLengths[platform])]);
			}

			return ("FLAT", segments);
		}

		_ = platformCount;
		return ("NO_OFFSET_TABLE", segments);
	}

	private static byte[] Decompress(byte[] compressed, List<(int Offset, int Compressed, int Decompressed)> segments)
	{
		int total = 0;

		foreach (var segment in segments)
			total += segment.Decompressed;

		byte[] output = new byte[total];
		int written = 0;

		foreach (var (offset, compressedLength, decompressedLength) in segments)
		{
			if (offset < 0 || compressedLength <= 0 || decompressedLength <= 0)
				return [];

			if (offset + compressedLength > compressed.Length || written + decompressedLength > output.Length)
				return [];

			int produced = LZ4Codec.Decode(
				compressed.AsSpan(offset, compressedLength),
				output.AsSpan(written, decompressedLength));

			if (produced != decompressedLength)
				return [];

			written += decompressedLength;
		}

		return output;
	}

	/// <summary>
	/// The sub-program entry table at the head of a decompressed platform blob: a count, then one
	/// (offset, length) pair per sub-program, both into the same buffer.
	/// </summary>
	/// <remarks>
	/// Read defensively and validated against the buffer rather than trusted: a table that does not
	/// fit is reported as no entries, which is the honest answer, not a reason to throw somewhere else.
	/// </remarks>
	private static List<(int Offset, int Length)> ReadEntryTable(byte[] blob)
	{
		List<(int, int)> entries = [];

		if (blob.Length < 4)
			return entries;

		int count = BitConverter.ToInt32(blob, 0);

		if (count <= 0 || count > 0x100000 || 4 + count * 8 > blob.Length)
			return entries;

		for (int index = 0; index < count; index++)
		{
			int offset = BitConverter.ToInt32(blob, 4 + index * 8);
			int length = BitConverter.ToInt32(blob, 8 + index * 8);

			if (offset < 0 || length < 0 || offset + length > blob.Length)
				continue;

			entries.Add((offset, length));
		}

		return entries;
	}

	/// <summary>
	/// What one sub-program's bytes are, as a seam a test can reach without a shader behind it.
	/// </summary>
	public static SubProgramEvidence ClassifyBytes(byte[] bytes, string backend = "?")
		=> Classify(0, backend, 0, 0, bytes.Length, bytes);

	/// <summary>The source text of one sub-program's bytes, for the same reason.</summary>
	public static string SourceTextOfBytes(byte[] bytes)
		=> SourceTextOf(bytes, Encoding.Latin1.GetString(bytes));

	private static SubProgramEvidence Classify(int platform, string backend, int index, int offset, int length, byte[] blob)
	{
		ReadOnlySpan<byte> bytes = blob.AsSpan(offset, length);

		int printable = 0;

		foreach (byte value in bytes)
		{
			if (value is >= 0x20 and < 0x7F || value is (byte)'\n' or (byte)'\r' or (byte)'\t')
				printable++;
		}

		double ratio = length == 0 ? 0 : (double)printable / length;
		var (textOffset, textLength) = LongestPrintableRun(bytes);
		string text = Encoding.ASCII.GetString(bytes.Slice(textOffset, textLength));

		// AssetRipper: markers are looked for across the whole sub-program, not only in its longest
		// printable run. A single non-printable byte inside the source - and a binary header before
		// it - splits the run, and a search confined to the longest piece then reports a program that
		// plainly is source text as "printable, no markers". Searching the whole buffer permissively
		// costs nothing and cannot invent a marker that is not in the bytes.
		string whole = Encoding.Latin1.GetString(bytes);
		List<string> markers = [];

		foreach (string marker in Markers)
		{
			if (whole.Contains(marker, StringComparison.Ordinal))
				markers.Add(marker);
		}

		// A Metal library says what it is in its own header, and it is not source whatever its name
		// table happens to contain - a library naming `_main` and `xlatMtlMain` carries enough
		// printable text to trip a marker search that did not look for the header first.
		// The asset names the backend, which is stronger evidence than a byte scan: a sub-program
		// compiled to Metal is a Metal library whether or not Unity kept Apple's own header on it,
		// and 870 of one fixture's carry enough printable name table to read as text otherwise.
		var metal = MetalShaderLibrary.Read(bytes);
		bool isMetal = metal.IsMetalLibrary
			|| string.Equals(backend, nameof(GPUPlatform.Metal), StringComparison.Ordinal);

		ProgramEncoding encoding = isMetal
			? ProgramEncoding.MetalLibrary
			: markers.Count > 0
				? ProgramEncoding.SourceText
				: ratio > 0.9
					? ProgramEncoding.PrintableNoMarkers
					: ProgramEncoding.Binary;

		StringBuilder head = new();

		for (int position = 0; position < Math.Min(32, length); position++)
			head.Append(bytes[position].ToString("x2"));

		return new SubProgramEvidence(
			platform, backend, index, offset, length, encoding, Math.Round(ratio, 4), markers, head.ToString(),
			textOffset, textLength);
	}

	/// <summary>
	/// The source text of a sub-program: from the first marker's line back to the start of that line,
	/// to the last printable byte. A sub-program carries a binary header and keyword tables around
	/// its source, and taking the longest printable run alone drops whatever precedes the first
	/// non-printable byte inside it.
	/// </summary>
	private static string SourceTextOf(ReadOnlySpan<byte> bytes, string whole)
	{
		int first = int.MaxValue;

		foreach (string marker in Markers)
		{
			int position = whole.IndexOf(marker, StringComparison.Ordinal);

			if (position >= 0 && position < first)
				first = position;
		}

		if (first == int.MaxValue)
			return "";

		// The program is the one printable run the marker sits in, expanded both ways until a byte
		// that is not text. Running to the end of the sub-program instead is what produced an 8 MB
		// "shader": several entries in a large shader's table have a length reaching the end of the
		// platform blob, and everything after the program came with it.
		while (first > 0 && IsText(bytes[first - 1]))
			first--;

		int last = first;

		while (last < bytes.Length && IsText(bytes[last]))
			last++;

		return whole[first..last];
	}

	/// <summary>
	/// The longest run of printable bytes, which is where a shading language's source sits inside a
	/// sub-program that also carries a binary header and keyword tables around it.
	/// </summary>
	private static bool IsText(byte value)
		=> value is >= 0x20 and < 0x7F || value is (byte)'\n' or (byte)'\r' or (byte)'\t';

	private static (int Offset, int Length) LongestPrintableRun(ReadOnlySpan<byte> bytes)
	{
		int bestOffset = 0;
		int bestLength = 0;
		int runStart = 0;
		int runLength = 0;

		for (int position = 0; position < bytes.Length; position++)
		{
			byte value = bytes[position];

			if (value is >= 0x20 and < 0x7F || value is (byte)'\n' or (byte)'\r' or (byte)'\t')
			{
				if (runLength == 0)
					runStart = position;

				runLength++;

				if (runLength > bestLength)
				{
					bestLength = runLength;
					bestOffset = runStart;
				}
			}
			else
			{
				runLength = 0;
			}
		}

		return (bestOffset, bestLength);
	}
}
