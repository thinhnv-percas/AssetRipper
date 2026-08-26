using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.Metadata;

public static class ILOpCodeExtensions
{
	public static readonly HashSet<string> ILKeywords;

	private static readonly byte[] operandTypes;

	private static readonly string[] operandNames;

	public static OperandType GetOperandType(this ILOpCode opCode)
	{
		ushort num;
		checked
		{
			num = (ushort)unchecked(((int)(opCode & (ILOpCode)0x200) >> 1) | (int)(opCode & (ILOpCode)0xFF));
			if (num >= operandTypes.Length)
			{
				return (OperandType)255;
			}
		}
		return (OperandType)operandTypes[num];
	}

	public static string GetDisplayName(this ILOpCode opCode)
	{
		checked
		{
			ushort num = (ushort)unchecked(((int)(opCode & (ILOpCode)0x200) >> 1) | (int)(opCode & (ILOpCode)0xFF));
			if (num >= operandNames.Length)
			{
				return "";
			}
			return operandNames[num];
		}
	}

	public static bool IsDefined(this ILOpCode opCode)
	{
		return !string.IsNullOrEmpty(opCode.GetDisplayName());
	}

	static ILOpCodeExtensions()
	{
		operandTypes = new byte[287]
		{
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 5, 18, 18, 18, 18, 18, 18,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 16, 2, 3, 17, 7, 255, 5, 5, 4,
			4, 9, 5, 15, 15, 15, 15, 15, 15, 15,
			15, 15, 15, 15, 15, 15, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 11,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 4, 13, 13, 10, 4, 13, 13, 5, 255,
			255, 13, 5, 1, 1, 1, 1, 1, 1, 13,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			13, 13, 5, 13, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 13, 13, 13, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 5,
			5, 5, 5, 5, 5, 5, 5, 255, 255, 255,
			255, 255, 255, 255, 13, 5, 255, 255, 13, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 12, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 0, 15, 5, 5, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 5, 4, 4, 255, 14, 14, 14, 14, 14,
			14, 5, 255, 5, 16, 5, 5, 13, 13, 5,
			5, 255, 5, 255, 13, 5, 5
		};
		operandNames = new string[287]
		{
			"nop", "break", "ldarg.0", "ldarg.1", "ldarg.2", "ldarg.3", "ldloc.0", "ldloc.1", "ldloc.2", "ldloc.3",
			"stloc.0", "stloc.1", "stloc.2", "stloc.3", "ldarg.s", "ldarga.s", "starg.s", "ldloc.s", "ldloca.s", "stloc.s",
			"ldnull", "ldc.i4.m1", "ldc.i4.0", "ldc.i4.1", "ldc.i4.2", "ldc.i4.3", "ldc.i4.4", "ldc.i4.5", "ldc.i4.6", "ldc.i4.7",
			"ldc.i4.8", "ldc.i4.s", "ldc.i4", "ldc.i8", "ldc.r4", "ldc.r8", "", "dup", "pop", "jmp",
			"call", "calli", "ret", "br.s", "brfalse.s", "brtrue.s", "beq.s", "bge.s", "bgt.s", "ble.s",
			"blt.s", "bne.un.s", "bge.un.s", "bgt.un.s", "ble.un.s", "blt.un.s", "br", "brfalse", "brtrue", "beq",
			"bge", "bgt", "ble", "blt", "bne.un", "bge.un", "bgt.un", "ble.un", "blt.un", "switch",
			"ldind.i1", "ldind.u1", "ldind.i2", "ldind.u2", "ldind.i4", "ldind.u4", "ldind.i8", "ldind.i", "ldind.r4", "ldind.r8",
			"ldind.ref", "stind.ref", "stind.i1", "stind.i2", "stind.i4", "stind.i8", "stind.r4", "stind.r8", "add", "sub",
			"mul", "div", "div.un", "rem", "rem.un", "and", "or", "xor", "shl", "shr",
			"shr.un", "neg", "not", "conv.i1", "conv.i2", "conv.i4", "conv.i8", "conv.r4", "conv.r8", "conv.u4",
			"conv.u8", "callvirt", "cpobj", "ldobj", "ldstr", "newobj", "castclass", "isinst", "conv.r.un", "",
			"", "unbox", "throw", "ldfld", "ldflda", "stfld", "ldsfld", "ldsflda", "stsfld", "stobj",
			"conv.ovf.i1.un", "conv.ovf.i2.un", "conv.ovf.i4.un", "conv.ovf.i8.un", "conv.ovf.u1.un", "conv.ovf.u2.un", "conv.ovf.u4.un", "conv.ovf.u8.un", "conv.ovf.i.un", "conv.ovf.u.un",
			"box", "newarr", "ldlen", "ldelema", "ldelem.i1", "ldelem.u1", "ldelem.i2", "ldelem.u2", "ldelem.i4", "ldelem.u4",
			"ldelem.i8", "ldelem.i", "ldelem.r4", "ldelem.r8", "ldelem.ref", "stelem.i", "stelem.i1", "stelem.i2", "stelem.i4", "stelem.i8",
			"stelem.r4", "stelem.r8", "stelem.ref", "ldelem", "stelem", "unbox.any", "", "", "", "",
			"", "", "", "", "", "", "", "", "", "conv.ovf.i1",
			"conv.ovf.u1", "conv.ovf.i2", "conv.ovf.u2", "conv.ovf.i4", "conv.ovf.u4", "conv.ovf.i8", "conv.ovf.u8", "", "", "",
			"", "", "", "", "refanyval", "ckfinite", "", "", "mkrefany", "",
			"", "", "", "", "", "", "", "", "ldtoken", "conv.u2",
			"conv.u1", "conv.i", "conv.ovf.i", "conv.ovf.u", "add.ovf", "add.ovf.un", "mul.ovf", "mul.ovf.un", "sub.ovf", "sub.ovf.un",
			"endfinally", "leave", "leave.s", "stind.i", "conv.u", "", "", "", "", "",
			"", "", "", "", "", "", "", "", "", "",
			"", "", "", "", "", "", "", "", "prefix7", "prefix6",
			"prefix5", "prefix4", "prefix3", "prefix2", "prefix1", "prefixref", "arglist", "ceq", "cgt", "cgt.un",
			"clt", "clt.un", "ldftn", "ldvirtftn", "", "ldarg", "ldarga", "starg", "ldloc", "ldloca",
			"stloc", "localloc", "", "endfilter", "unaligned.", "volatile.", "tail.", "initobj", "constrained.", "cpblk",
			"initblk", "", "rethrow", "", "sizeof", "refanytype", "readonly."
		};
		ILKeywords = BuildKeywordList("abstract", "algorithm", "alignment", "ansi", "any", "arglist", "array", "as", "assembly", "assert", "at", "auto", "autochar", "beforefieldinit", "blob", "blob_object", "bool", "brnull", "brnull.s", "brzero", "brzero.s", "bstr", "bytearray", "byvalstr", "callmostderived", "carray", "catch", "cdecl", "cf", "char", "cil", "class", "clsid", "const", "currency", "custom", "date", "decimal", "default", "demand", "deny", "endmac", "enum", "error", "explicit", "extends", "extern", "false", "famandassem", "family", "famorassem", "fastcall", "fault", "field", "filetime", "filter", "final", "finally", "fixed", "float", "float32", "float64", "forwardref", "fromunmanaged", "handler", "hidebysig", "hresult", "idispatch", "il", "illegal", "implements", "implicitcom", "implicitres", "import", "in", "inheritcheck", "init", "initonly", "instance", "int", "int16", "int32", "int64", "int8", "interface", "internalcall", "iunknown", "lasterr", "lcid", "linkcheck", "literal", "localloc", "lpstr", "lpstruct", "lptstr", "lpvoid", "lpwstr", "managed", "marshal", "method", "modopt", "modreq", "native", "nested", "newslot", "noappdomain", "noinlining", "nomachine", "nomangle", "nometadata", "noncasdemand", "noncasinheritance", "noncaslinkdemand", "noprocess", "not", "not_in_gc_heap", "notremotable", "notserialized", "null", "nullref", "object", "objectref", "opt", "optil", "out", "permitonly", "pinned", "pinvokeimpl", "prefix1", "prefix2", "prefix3", "prefix4", "prefix5", "prefix6", "prefix7", "prefixref", "prejitdeny", "prejitgrant", "preservesig", "private", "privatescope", "protected", "public", "record", "refany", "reqmin", "reqopt", "reqrefuse", "reqsecobj", "request", "retval", "rtspecialname", "runtime", "safearray", "sealed", "sequential", "serializable", "special", "specialname", "static", "stdcall", "storage", "stored_object", "stream", "streamed_object", "string", "struct", "synchronized", "syschar", "sysstring", "tbstr", "thiscall", "tls", "to", "true", "typedref", "unicode", "unmanaged", "unmanagedexp", "unsigned", "unused", "userdefined", "value", "valuetype", "vararg", "variant", "vector", "virtual", "void", "wchar", "winapi", "with", "wrapper", "property", "type", "flags", "callconv", "strict");
	}

	private static HashSet<string> BuildKeywordList(params string[] keywords)
	{
		HashSet<string> val = new HashSet<string>((IEnumerable<string>)keywords);
		string[] array = operandNames;
		foreach (string text in array)
		{
			if (!string.IsNullOrEmpty(text))
			{
				val.Add(text);
			}
		}
		return val;
	}
}
