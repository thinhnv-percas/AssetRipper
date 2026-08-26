using System;
using System.Collections.Generic;
using System.Threading;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.Disassembler;

public class DisassemblerOptions
{
	public readonly ModuleDef OwnerModule;

	public readonly CancellationToken CancellationToken;

	public Func<OpCode, string> GetOpCodeDocumentation;

	public Func<IMemberRef, IEnumerable<string>> GetXmlDocComments;

	public Func<MethodDef, IInstructionBytesReader> CreateInstructionBytesReader;

	public bool ShowTokenAndRvaComments;

	public bool ShowILBytes;

	public bool SortMembers;

	public bool ShowPdbInfo;

	public readonly int OptionsVersion;

	public DisassemblerOptions(int optionsVersion, CancellationToken cancellationToken, ModuleDef ownerModule)
	{
		OptionsVersion = optionsVersion;
		CancellationToken = cancellationToken;
		OwnerModule = ownerModule;
	}
}
