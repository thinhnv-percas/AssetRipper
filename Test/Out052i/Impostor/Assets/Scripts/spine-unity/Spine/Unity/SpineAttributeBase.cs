using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	[Token(Token = "0x20000B3")]
	public abstract class SpineAttributeBase : PropertyAttribute
	{
		[Token(Token = "0x400042C")]
		[FieldOffset(Offset = "0x10")]
		public string dataField;

		[Token(Token = "0x400042D")]
		[FieldOffset(Offset = "0x18")]
		public string startsWith;

		[Token(Token = "0x400042E")]
		[FieldOffset(Offset = "0x20")]
		public bool includeNone;

		[Token(Token = "0x400042F")]
		[FieldOffset(Offset = "0x21")]
		public bool fallbackToTextField;

		[Token(Token = "0x60006A8")]
		[Address(RVA = "0x1570950", Offset = "0x1570950", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = \"\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37CE5]) = v37;\nL_0015:\n\tthis.includeNone = 1;\n\tthis.dataField = \"\";\n\tthis.startsWith = \"\";\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal SpineAttributeBase()
		{
			includeNone = true;
			dataField = "";
			startsWith = "";
		}
	}
}
