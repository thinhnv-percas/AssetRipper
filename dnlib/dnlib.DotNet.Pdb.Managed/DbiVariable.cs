using System;
using dnlib.DotNet.Pdb.Symbols;
using dnlib.IO;

namespace dnlib.DotNet.Pdb.Managed;

internal sealed class DbiVariable : SymbolVariable
{
	private string name;

	private PdbLocalAttributes attributes;

	private int index;

	public override string Name => name;

	public override PdbLocalAttributes Attributes => attributes;

	public override int Index => index;

	public override PdbCustomDebugInfo[] CustomDebugInfos => Array2.Empty<PdbCustomDebugInfo>();

	public void Read(ref DataReader reader)
	{
		index = reader.ReadInt32();
		reader.Position += 10u;
		attributes = GetAttributes(reader.ReadUInt16());
		name = PdbReader.ReadCString(ref reader);
	}

	private static PdbLocalAttributes GetAttributes(uint flags)
	{
		PdbLocalAttributes pdbLocalAttributes = PdbLocalAttributes.None;
		if ((flags & 4) != 0)
		{
			pdbLocalAttributes |= PdbLocalAttributes.DebuggerHidden;
		}
		return pdbLocalAttributes;
	}
}
