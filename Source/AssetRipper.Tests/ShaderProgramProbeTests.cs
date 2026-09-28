using System.Text;
using AssetRipper.Export.UnityProjects.Shaders;

namespace AssetRipper.Tests;

/// <summary>
/// AssetRipper: that the probe reads a compiled shader program for what it is.
/// </summary>
/// <remarks>
/// Every case here is red if the rule it names is removed. The project has shipped two measurements
/// that could only report one answer, and a probe whose classification cannot be wrong is one of
/// those.
/// </remarks>
public sealed class ShaderProgramProbeTests
{
	private const string Glsl = """
		#ifdef VERTEX
		#version 100
		uniform vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
		attribute highp vec4 in_POSITION0;
		void main()
		{
		    gl_Position = in_POSITION0;
		}
		#endif
		""";

	[Test]
	public void SourceTextIsRecognisedByItsMarkers()
	{
		var evidence = ShaderProgramProbe.ClassifyBytes(Encoding.ASCII.GetBytes(Glsl));

		Assert.Multiple(() =>
		{
			Assert.That(evidence.Encoding, Is.EqualTo(ShaderProgramProbe.ProgramEncoding.SourceText));
			Assert.That(evidence.Markers, Does.Contain("#version"));
			Assert.That(evidence.Markers, Does.Contain("gl_Position"));
		});
	}

	[Test]
	public void CompiledBytesAreNotReadAsSource()
	{
		byte[] compiled = new byte[256];

		for (int index = 0; index < compiled.Length; index++)
		{
			compiled[index] = (byte)(index * 7 % 256);
		}

		var evidence = ShaderProgramProbe.ClassifyBytes(compiled);

		Assert.Multiple(() =>
		{
			Assert.That(evidence.Encoding, Is.EqualTo(ShaderProgramProbe.ProgramEncoding.Binary));
			Assert.That(evidence.Markers, Is.Empty);
		});
	}

	[Test]
	public void MarkersAreFoundPastANonPrintableByteInsideTheProgram()
	{
		// A sub-program carries a binary header and keyword tables around its source. Searching only
		// the longest printable run reported a program that plainly is source as "printable, no
		// markers" - so the search has to cover the whole buffer.
		List<byte> bytes = [0x01, 0x00, 0x00, 0x00, 0x7F, 0x80, 0x91];
		bytes.AddRange(Encoding.ASCII.GetBytes(Glsl));

		var evidence = ShaderProgramProbe.ClassifyBytes([.. bytes]);

		Assert.That(evidence.Encoding, Is.EqualTo(ShaderProgramProbe.ProgramEncoding.SourceText));
	}

	[Test]
	public void ExtractedTextStopsAtTheEndOfItsOwnPrintableRun()
	{
		// Several entries in a large shader's table have a length that reaches the end of the whole
		// platform blob. Running the extraction to the last printable byte of that span took
		// everything after the program with it: an 8 MB "shader", and 3 GB for one rip.
		List<byte> bytes = [.. Encoding.ASCII.GetBytes(Glsl)];
		bytes.Add(0x00);
		bytes.AddRange(Encoding.ASCII.GetBytes(new string('A', 4096)));

		string text = ShaderProgramProbe.SourceTextOfBytes([.. bytes]);

		Assert.Multiple(() =>
		{
			Assert.That(text, Does.Contain("gl_Position"));
			Assert.That(text, Does.Not.Contain("AAAA"));
			Assert.That(text.Length, Is.LessThan(Glsl.Length + 16));
		});
	}

	[Test]
	public void PrintableTextWithNoShadingMarkersIsNotCalledSource()
	{
		var evidence = ShaderProgramProbe.ClassifyBytes(
			Encoding.ASCII.GetBytes(new string('x', 512)));

		Assert.That(evidence.Encoding, Is.EqualTo(ShaderProgramProbe.ProgramEncoding.PrintableNoMarkers));
	}

	/// <summary>A blob whose table is a count then one entry of <paramref name="ints"/> per program.</summary>
	private static byte[] Blob(int stride, params (int Offset, int Length, int Segment)[] entries)
		=> Blob(stride, 0, entries);

	private static byte[] Blob(int stride, int size, params (int Offset, int Length, int Segment)[] entries)
	{
		int header = 4 + entries.Length * stride;
		int end = size > 0 ? size : entries.Max(e => e.Offset + e.Length);
		byte[] blob = new byte[Math.Max(header, end)];
		BitConverter.GetBytes(entries.Length).CopyTo(blob, 0);
		for (int i = 0; i < entries.Length; i++)
		{
			BitConverter.GetBytes(entries[i].Offset).CopyTo(blob, 4 + i * stride);
			BitConverter.GetBytes(entries[i].Length).CopyTo(blob, 8 + i * stride);
			if (stride == 12)
				BitConverter.GetBytes(entries[i].Segment).CopyTo(blob, 12 + i * stride);
		}
		return blob;
	}

	[Test]
	public void ASegmentedTableIsReadAsTriples()
	{
		// Iteration 061: the table of a segmented blob carries (offset, length, segment). Read as pairs,
		// only every third entry lined up and the others were spans from the start of the blob.
		byte[] blob = Blob(12, (40, 10, 0), (50, 20, 0), (70, 5, 0));

		var entries = ShaderProgramProbe.ReadEntryTable(blob, [blob.Length]);

		Assert.That(entries, Is.EqualTo(new List<(int, int)> { (40, 10), (50, 20), (70, 5) }));
	}

	[Test]
	public void AFlatTableIsReadAsPairs()
	{
		byte[] blob = Blob(8, (28, 10, 0), (38, 20, 0), (58, 5, 0));

		var entries = ShaderProgramProbe.ReadEntryTable(blob, [blob.Length]);

		Assert.That(entries, Is.EqualTo(new List<(int, int)> { (28, 10), (38, 20), (58, 5) }));
	}

	[Test]
	public void AStrippedEntryKeepsItsPosition()
	{
		// A position is the BlobIndex a sub-program names, so an entry that is empty or does not fit
		// must not shift the ones after it.
		byte[] blob = Blob(12, 67, (52, 10, 0), (9999, 50, 0), (62, 0, 0), (62, 5, 0));

		var entries = ShaderProgramProbe.ReadEntryTable(blob, [blob.Length]);

		Assert.Multiple(() =>
		{
			Assert.That(entries, Has.Count.EqualTo(4));
			Assert.That(entries[1], Is.EqualTo((0, 0)), "an entry that does not fit is empty, not dropped");
			Assert.That(entries[3], Is.EqualTo((62, 5)));
		});
	}

	[Test]
	public void AnEntryInALaterSegmentIsOffsetBySegmentsBeforeIt()
	{
		byte[] first = Blob(12, 38, (28, 10, 0), (0, 8, 1));
		byte[] blob = first.Concat(new byte[8]).ToArray();

		var entries = ShaderProgramProbe.ReadEntryTable(blob, [first.Length, 8]);

		Assert.That(entries[1], Is.EqualTo((first.Length, 8)));
	}

	[Test]
	public void ATableThatDescribesNeitherLayoutHasNoEntries()
	{
		byte[] blob = new byte[64];
		BitConverter.GetBytes(2).CopyTo(blob, 0);
		BitConverter.GetBytes(3).CopyTo(blob, 4);   // the first program cannot start inside the table
		BitConverter.GetBytes(4).CopyTo(blob, 8);

		Assert.That(ShaderProgramProbe.ReadEntryTable(blob, [blob.Length]), Is.Empty);
	}
}
