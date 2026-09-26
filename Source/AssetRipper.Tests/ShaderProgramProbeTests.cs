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
}
