namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>What one compiled sub-program of a shader is.</summary>
public enum CompiledProgramKind
{
	/// <summary>The build stripped it: the table has an entry and the entry has no bytes.</summary>
	Stripped,

	/// <summary>GLSL source in the clear - what Unity's GLES backends ship.</summary>
	GlslSource,

	/// <summary>A compiled Metal library.</summary>
	MetalBinary,

	/// <summary>Direct3D bytecode.</summary>
	Dxbc,

	/// <summary>A SPIR-V module.</summary>
	Spirv,

	/// <summary>Bytes whose format was not established.</summary>
	UnknownBinary,
}

/// <summary>How much of a program can be brought back as something a project can compile.</summary>
public enum ProgramRecoverability
{
	/// <summary>The program is its own source and goes into a <c>GLSLPROGRAM</c> block verbatim.</summary>
	Source,

	/// <summary>
	/// A compiled form with no decompiler here. Recorded, never rendered as source: a program that
	/// looks recovered and is not is worse than one that says it is missing.
	/// </summary>
	BinaryOnly,

	/// <summary>Nothing to recover: the build did not keep the variant.</summary>
	Stripped,

	/// <summary>Not established.</summary>
	Unknown,
}

/// <summary>
/// AssetRipper: one compiled shader program, typed by what its bytes are rather than by the backend
/// that asked for it.
/// </summary>
/// <remarks>
/// <para>
/// The distinction matters because only one kind has source. A GLES program is GLSL text; a Metal
/// program is a compiled library; DXBC and SPIR-V are bytecode that a decompiler could in principle
/// turn back into source and that this project has no decompiler for. Treating them alike is how a
/// replacement program comes to be called recovered, and how a binary comes to be written into a
/// <c>GLSLPROGRAM</c> block.
/// </para>
/// <para>
/// <see cref="SourceText"/> is non-null for <see cref="GLSLSourceProgram"/> and for nothing else, by
/// construction: none of the other types has a way to carry text.
/// </para>
/// </remarks>
public interface ICompiledShaderProgram
{
	string Backend { get; }
	CompiledProgramKind Kind { get; }
	ProgramRecoverability Recoverability { get; }
	int Length { get; }
	string? SourceText { get; }
}

public sealed record GLSLSourceProgram(string Backend, int Length, string SourceText) : ICompiledShaderProgram
{
	public CompiledProgramKind Kind => CompiledProgramKind.GlslSource;
	public ProgramRecoverability Recoverability => ProgramRecoverability.Source;
	string? ICompiledShaderProgram.SourceText => SourceText;
}

/// <summary>A Metal library. <see cref="IMetalShaderDecompiler"/> is declared and deliberately unimplemented.</summary>
public sealed record MetalBinaryProgram(string Backend, int Length) : ICompiledShaderProgram
{
	public CompiledProgramKind Kind => CompiledProgramKind.MetalBinary;
	public ProgramRecoverability Recoverability => ProgramRecoverability.BinaryOnly;
	public string? SourceText => null;
}

public sealed record DXBCProgram(string Backend, int Length) : ICompiledShaderProgram
{
	public CompiledProgramKind Kind => CompiledProgramKind.Dxbc;
	public ProgramRecoverability Recoverability => ProgramRecoverability.BinaryOnly;
	public string? SourceText => null;
}

public sealed record SPIRVProgram(string Backend, int Length) : ICompiledShaderProgram
{
	public CompiledProgramKind Kind => CompiledProgramKind.Spirv;
	public ProgramRecoverability Recoverability => ProgramRecoverability.BinaryOnly;
	public string? SourceText => null;
}

public sealed record UnknownBinaryProgram(string Backend, int Length) : ICompiledShaderProgram
{
	public CompiledProgramKind Kind => CompiledProgramKind.UnknownBinary;
	public ProgramRecoverability Recoverability => ProgramRecoverability.Unknown;
	public string? SourceText => null;
}

public sealed record StrippedProgram(string Backend) : ICompiledShaderProgram
{
	public CompiledProgramKind Kind => CompiledProgramKind.Stripped;
	public ProgramRecoverability Recoverability => ProgramRecoverability.Stripped;
	public int Length => 0;
	public string? SourceText => null;
}

public static class CompiledShaderProgram
{
	private static readonly byte[] DxbcMagic = "DXBC"u8.ToArray();
	private const uint SpirvMagic = 0x07230203;

	/// <summary>
	/// What <paramref name="bytes"/> are. The backend is evidence only for Metal, where the asset
	/// naming the backend is stronger than a byte scan (see <see cref="ShaderProgramProbe"/>); for
	/// every other kind the bytes decide, and a signature must be present, not merely plausible.
	/// </summary>
	public static ICompiledShaderProgram From(string backend, ReadOnlySpan<byte> bytes)
	{
		if (bytes.Length == 0)
			return new StrippedProgram(backend);

		var evidence = ShaderProgramProbe.ClassifyBytes(bytes.ToArray(), backend);

		if (evidence.Encoding == ShaderProgramProbe.ProgramEncoding.MetalLibrary)
			return new MetalBinaryProgram(backend, bytes.Length);

		// Unity puts its own header in front of the container, so the magic is looked for near the
		// start rather than at offset zero - and only near it, so a byte pattern deep inside some
		// other format cannot claim the program.
		if (bytes[..Math.Min(bytes.Length, 256)].IndexOf(DxbcMagic) >= 0)
			return new DXBCProgram(backend, bytes.Length);

		for (int at = 0; at + 4 <= Math.Min(bytes.Length, 256); at += 4)
		{
			if (BitConverter.ToUInt32(bytes.Slice(at, 4)) == SpirvMagic)
				return new SPIRVProgram(backend, bytes.Length);
		}

		if (evidence.Encoding == ShaderProgramProbe.ProgramEncoding.SourceText)
			return new GLSLSourceProgram(backend, bytes.Length, ShaderProgramProbe.SourceTextOfBytes(bytes.ToArray()));

		return new UnknownBinaryProgram(backend, bytes.Length);
	}

	/// <summary>
	/// The kind of a program the probe has already read, from its evidence alone. Without the bytes a
	/// DXBC or SPIR-V signature is only visible when it falls inside the recorded head, so a binary
	/// whose head carries neither is <see cref="CompiledProgramKind.UnknownBinary"/> - the honest
	/// answer, not a guess at the likelier format.
	/// </summary>
	public static (CompiledProgramKind Kind, ProgramRecoverability Recoverability) KindOf(ShaderProgramProbe.SubProgramEvidence evidence)
	{
		if (evidence.Length == 0)
			return (CompiledProgramKind.Stripped, ProgramRecoverability.Stripped);

		switch (evidence.Encoding)
		{
			case ShaderProgramProbe.ProgramEncoding.MetalLibrary:
				return (CompiledProgramKind.MetalBinary, ProgramRecoverability.BinaryOnly);
			case ShaderProgramProbe.ProgramEncoding.SourceText:
				return (CompiledProgramKind.GlslSource, ProgramRecoverability.Source);
		}

		string head = evidence.HeadHex;
		if (head.Contains("44584243", StringComparison.Ordinal))   // "DXBC"
			return (CompiledProgramKind.Dxbc, ProgramRecoverability.BinaryOnly);
		for (int at = 0; at + 8 <= head.Length; at += 8)
		{
			if (string.Equals(head.Substring(at, 8), "03022307", StringComparison.Ordinal))
				return (CompiledProgramKind.Spirv, ProgramRecoverability.BinaryOnly);
		}

		return (CompiledProgramKind.UnknownBinary, ProgramRecoverability.Unknown);
	}
}
