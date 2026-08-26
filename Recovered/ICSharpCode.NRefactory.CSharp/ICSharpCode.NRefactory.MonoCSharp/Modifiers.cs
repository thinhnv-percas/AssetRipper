using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	[Flags]
	public enum Modifiers
	{
		PROTECTED = 0x1,
		PUBLIC = 0x2,
		PRIVATE = 0x4,
		INTERNAL = 0x8,
		NEW = 0x10,
		ABSTRACT = 0x20,
		SEALED = 0x40,
		STATIC = 0x80,
		READONLY = 0x100,
		VIRTUAL = 0x200,
		OVERRIDE = 0x400,
		EXTERN = 0x800,
		VOLATILE = 0x1000,
		UNSAFE = 0x2000,
		ASYNC = 0x4000,
		TOP = 0x8000,
		PROPERTY_CUSTOM = 0x10000,
		PARTIAL = 0x20000,
		DEFAULT_ACCESS_MODIFIER = 0x40000,
		METHOD_EXTENSION = 0x80000,
		COMPILER_GENERATED = 0x100000,
		BACKING_FIELD = 0x200000,
		DEBUGGER_HIDDEN = 0x400000,
		DEBUGGER_STEP_THROUGH = 0x800000,
		AccessibilityMask = 0xF,
		AllowedExplicitImplFlags = 0x2800
	}
}
