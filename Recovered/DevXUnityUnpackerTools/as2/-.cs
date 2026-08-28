using APK;
using DevXForms;
using DSMCaps.X86;
using SpirV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Wasm.Interpret;

namespace as2
{
	internal class _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A
	{
		public const int FIELD_ATTRIBUTE_FIELD_ACCESS_MASK = 7;

		public const int FIELD_ATTRIBUTE_COMPILER_CONTROLLED = 0;

		public const int FIELD_ATTRIBUTE_PRIVATE = 1;

		public const int FIELD_ATTRIBUTE_FAM_AND_ASSEM = 2;

		public const int FIELD_ATTRIBUTE_ASSEMBLY = 3;

		public const int FIELD_ATTRIBUTE_FAMILY = 4;

		public const int FIELD_ATTRIBUTE_FAM_OR_ASSEM = 5;

		public const int FIELD_ATTRIBUTE_PUBLIC = 6;

		public const int FIELD_ATTRIBUTE_STATIC = 16;

		public const int FIELD_ATTRIBUTE_INIT_ONLY = 32;

		public const int FIELD_ATTRIBUTE_LITERAL = 64;

		public const int METHOD_ATTRIBUTE_MEMBER_ACCESS_MASK = 7;

		public const int METHOD_ATTRIBUTE_COMPILER_CONTROLLED = 0;

		public const int METHOD_ATTRIBUTE_PRIVATE = 1;

		public const int METHOD_ATTRIBUTE_FAM_AND_ASSEM = 2;

		public const int METHOD_ATTRIBUTE_ASSEM = 3;

		public const int METHOD_ATTRIBUTE_FAMILY = 4;

		public const int METHOD_ATTRIBUTE_FAM_OR_ASSEM = 5;

		public const int METHOD_ATTRIBUTE_PUBLIC = 6;

		public const int METHOD_ATTRIBUTE_STATIC = 16;

		public const int METHOD_ATTRIBUTE_FINAL = 32;

		public const int METHOD_ATTRIBUTE_VIRTUAL = 64;

		public const int METHOD_ATTRIBUTE_VTABLE_LAYOUT_MASK = 256;

		public const int METHOD_ATTRIBUTE_REUSE_SLOT = 0;

		public const int METHOD_ATTRIBUTE_NEW_SLOT = 256;

		public const int METHOD_ATTRIBUTE_ABSTRACT = 1024;

		public const int METHOD_ATTRIBUTE_PINVOKE_IMPL = 8192;

		public const int TYPE_ATTRIBUTE_VISIBILITY_MASK = 7;

		public const int TYPE_ATTRIBUTE_NOT_PUBLIC = 0;

		public const int TYPE_ATTRIBUTE_PUBLIC = 1;

		public const int TYPE_ATTRIBUTE_NESTED_PUBLIC = 2;

		public const int TYPE_ATTRIBUTE_NESTED_PRIVATE = 3;

		public const int TYPE_ATTRIBUTE_NESTED_FAMILY = 4;

		public const int TYPE_ATTRIBUTE_NESTED_ASSEMBLY = 5;

		public const int TYPE_ATTRIBUTE_NESTED_FAM_AND_ASSEM = 6;

		public const int TYPE_ATTRIBUTE_NESTED_FAM_OR_ASSEM = 7;

		public const int TYPE_ATTRIBUTE_INTERFACE = 32;

		public const int TYPE_ATTRIBUTE_ABSTRACT = 128;

		public const int TYPE_ATTRIBUTE_SEALED = 256;

		public const int TYPE_ATTRIBUTE_SERIALIZABLE = 8192;

		public const int PARAM_ATTRIBUTE_IN = 1;

		public const int PARAM_ATTRIBUTE_OUT = 2;

		public const int PARAM_ATTRIBUTE_Lcid = 4;

		public const int PARAM_ATTRIBUTE_Retval = 8;

		public const int PARAM_ATTRIBUTE_OPTIONAL = 16;

		public const int PARAM_ATTRIBUTE_HasDefault = 4096;

		public const int PARAM_ATTRIBUTE_HasFieldMarshal = 8192;

		public const int PARAM_ATTRIBUTE_Unused = 53216;

		public static readonly Dictionary<int, string> TypeString = new Dictionary<int, string>
		{
			{
				1,
				"void"
			},
			{
				2,
				"bool"
			},
			{
				3,
				"char"
			},
			{
				4,
				"sbyte"
			},
			{
				5,
				"byte"
			},
			{
				6,
				"short"
			},
			{
				7,
				"ushort"
			},
			{
				8,
				"int"
			},
			{
				9,
				"uint"
			},
			{
				10,
				"long"
			},
			{
				11,
				"ulong"
			},
			{
				12,
				"float"
			},
			{
				13,
				"double"
			},
			{
				14,
				"string"
			},
			{
				19,
				"T"
			},
			{
				22,
				"System.TypedReference"
			},
			{
				24,
				"IntPtr"
			},
			{
				25,
				"UIntPtr"
			},
			{
				28,
				"object"
			},
			{
				30,
				"T"
			}
		};

		public static Version Unity20183 = new Version(2018, 3);

		public static Version Unity20191 = new Version(2019, 1);
	}
	internal class _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020
	{
		public const int DT_PLTGOT = 3;

		public const int DT_STRTAB = 5;

		public const int DT_SYMTAB = 6;

		public const int DT_RELA = 7;

		public const int DT_RELASZ = 8;

		public const int DT_REL = 17;

		public const int DT_RELSZ = 18;

		public const int DT_INIT_ARRAY = 25;

		public const int DT_INIT_ARRAYSZ = 27;

		public const int R_ARM_ABS32 = 2;

		public const int R_386_32 = 1;

		public const int R_AARCH64_ABS64 = 257;

		public const int R_AARCH64_RELATIVE = 1027;
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020(string _0020)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020(_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A _0020, _0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A _0020_000A)
		{
			OperatorImpls.Int32DivS(null, null);
			((_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020)null)._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020((object)null, (MouseEventArgs)null);
			return 1430621188;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020(bool _0020, object _0020_000A, int _0020_0020, bool _0020_000A_000A)
		{
			((_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020)null)._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A((Stream)null, (string)null);
			_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A.crn_convert_file_to_png(null, null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020()
		{
			return 490513001;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020(bool _0020, OpUGreaterThan _0020_000A)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A
	{
		// Dead decoy method removed (referenced an unresolved IL generic-parameter leak escaped as unbound generic syntax, e.g. `!0`/`!!0`); see FINDINGS.md §5.
	}
}
