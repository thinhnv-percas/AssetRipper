using System;

namespace dnlib.DotNet;

[Flags]
public enum CallingConvention : byte
{
	Default = 0,
	C = 1,
	StdCall = 2,
	ThisCall = C | StdCall,
	FastCall = 4,
	VarArg = C | FastCall,
	Field = StdCall | FastCall,
	LocalSig = ThisCall | FastCall,
	Property = 8,
	Unmanaged = C | Property,
	GenericInst = StdCall | Property,
	NativeVarArg = ThisCall | Property,
	Mask = LocalSig | Property,
	Generic = 0x10,
	HasThis = 0x20,
	ExplicitThis = 0x40,
	ReservedByCLR = 0x80
}
