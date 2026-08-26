using System;

namespace ICSharpCode.NRefactory.VB.Ast;

[Flags]
public enum Modifiers
{
	None = 0,
	Private = 1,
	Friend = 2,
	Protected = 4,
	Public = 8,
	MustInherit = 0x10,
	MustOverride = 0x20,
	Overridable = 0x40,
	NotInheritable = 0x80,
	NotOverridable = 0x100,
	Const = 0x200,
	Shared = 0x400,
	Static = 0x800,
	Overrides = 0x1000,
	ReadOnly = 0x2000,
	Shadows = 0x4000,
	Partial = 0x8000,
	Overloads = 0x10000,
	WithEvents = 0x20000,
	Default = 0x40000,
	Dim = 0x80000,
	WriteOnly = 0x100000,
	ByVal = 0x200000,
	ByRef = 0x400000,
	ParamArray = 0x800000,
	Optional = 0x1000000,
	Narrowing = 0x2000000,
	Widening = 0x4000000,
	Iterator = 0x8000000,
	Async = 0x10000000,
	Any = int.MinValue
}
