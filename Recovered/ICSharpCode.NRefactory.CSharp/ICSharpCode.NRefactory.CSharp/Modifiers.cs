using System;

namespace ICSharpCode.NRefactory.CSharp
{
	[Flags]
	public enum Modifiers
	{
		None = 0x0,
		Private = 0x1,
		Internal = 0x2,
		Protected = 0x4,
		Public = 0x8,
		Abstract = 0x10,
		Virtual = 0x20,
		Sealed = 0x40,
		Static = 0x80,
		Override = 0x100,
		Readonly = 0x200,
		Const = 0x400,
		New = 0x800,
		Partial = 0x1000,
		Extern = 0x2000,
		Volatile = 0x4000,
		Unsafe = 0x8000,
		Async = 0x10000,
		VisibilityMask = 0xF,
		Any = int.MinValue
	}
}
