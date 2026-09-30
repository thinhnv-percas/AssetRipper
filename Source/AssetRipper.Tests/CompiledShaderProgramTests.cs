using System.Text;
using AssetRipper.Export.UnityProjects.Shaders;

namespace AssetRipper.Tests;

/// <summary>
/// AssetRipper: that a compiled shader program is typed by what its bytes are, and that only GLSL
/// can ever carry source.
/// </summary>
public sealed class CompiledShaderProgramTests
{
	private const string Glsl = "#ifdef VERTEX\n#version 100\nattribute highp vec4 in_POSITION0;\nvoid main()\n{\n    gl_Position = in_POSITION0;\n}\n#endif\n";

	[Test]
	public void AnEmptyEntryIsStripped()
	{
		var program = CompiledShaderProgram.From("GLES3", []);
		Assert.Multiple(() =>
		{
			Assert.That(program, Is.TypeOf<StrippedProgram>());
			Assert.That(program.Recoverability, Is.EqualTo(ProgramRecoverability.Stripped));
		});
	}

	[Test]
	public void GlslIsItsOwnSource()
	{
		var program = CompiledShaderProgram.From("GLES3", Encoding.ASCII.GetBytes(Glsl));
		Assert.Multiple(() =>
		{
			Assert.That(program, Is.TypeOf<GLSLSourceProgram>());
			Assert.That(program.SourceText, Does.Contain("gl_Position"));
		});
	}

	[Test]
	public void AMetalProgramIsBinaryOnlyWhateverItsBytesLookLike()
	{
		// A Metal library's name table carries enough printable text to read as source; the backend
		// the asset names is the stronger evidence, and no Metal program may come back with text.
		var program = CompiledShaderProgram.From("Metal", Encoding.ASCII.GetBytes(Glsl));
		Assert.Multiple(() =>
		{
			Assert.That(program, Is.TypeOf<MetalBinaryProgram>());
			Assert.That(program.SourceText, Is.Null);
			Assert.That(program.Recoverability, Is.EqualTo(ProgramRecoverability.BinaryOnly));
		});
	}

	/// <summary>
	/// Iteration 063: Unity ships a Metal program it did not precompile as MSL inside its own container,
	/// and that is source - 778 of JellyBlast's 778 Metal programs. It is not ShaderLab's to embed.
	/// </summary>
	[Test]
	public void MetalShadingLanguageInUnitysContainerIsSourceOutsideShaderLab()
	{
		byte[] container = [0xBA, 0x75, 0x0A, 0x0C, 0x18, 0, 0, 0, .. new byte[24],
			.. Encoding.ASCII.GetBytes("xlatMtlMain\0#include <metal_stdlib>\nusing namespace metal;\n" +
				"fragment half4 xlatMtlMain(float4 p [[ position ]]) { return half4(1); }\n")];
		var program = CompiledShaderProgram.From("Metal", container);
		Assert.Multiple(() =>
		{
			Assert.That(program, Is.TypeOf<MetalSourceProgram>());
			Assert.That(program.Recoverability, Is.EqualTo(ProgramRecoverability.SourceOutsideShaderLab));
			Assert.That(program.SourceText, Does.StartWith("#include <metal_stdlib>"));
			Assert.That(program.SourceText, Does.Contain("fragment half4 xlatMtlMain"));
		});
	}

	/// <summary>A Metal parameter block names its constants and is not a program.</summary>
	[Test]
	public void AMetalParameterBlockIsNotSource()
	{
		byte[] block = [0xBA, 0x75, 0x0A, 0x0C, .. Encoding.ASCII.GetBytes("\0VGlobals\0unity_ObjectToWorld\0unity_MatrixVP\0")];
		var program = CompiledShaderProgram.From("Metal", block);
		Assert.That(program.SourceText, Is.Null);
	}

	[Test]
	public void DxbcAndSpirvAreRecognisedBySignature()
	{
		byte[] dxbc = [.. new byte[16], .. "DXBC"u8.ToArray(), .. new byte[64]];
		byte[] spirv = [.. new byte[8], 0x03, 0x02, 0x23, 0x07, .. new byte[64]];

		Assert.Multiple(() =>
		{
			Assert.That(CompiledShaderProgram.From("D3D11", dxbc), Is.TypeOf<DXBCProgram>());
			Assert.That(CompiledShaderProgram.From("Vulkan", spirv), Is.TypeOf<SPIRVProgram>());
		});
	}

	[Test]
	public void BytesWithNoSignatureAreUnknownNotAGuess()
	{
		byte[] bytes = [.. Enumerable.Range(0, 200).Select(i => unchecked((byte)(i * 37 + 11)))];
		var program = CompiledShaderProgram.From("D3D11", bytes);
		Assert.Multiple(() =>
		{
			Assert.That(program, Is.TypeOf<UnknownBinaryProgram>(), "the backend is not evidence of DXBC");
			Assert.That(program.Recoverability, Is.EqualTo(ProgramRecoverability.Unknown));
		});
	}
}
