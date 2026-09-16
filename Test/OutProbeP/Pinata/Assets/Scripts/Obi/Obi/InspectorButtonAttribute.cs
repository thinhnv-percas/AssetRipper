using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x744994", Offset = "0x744994")]
	[Token(Token = "0x2000049")]
	public class InspectorButtonAttribute : PropertyAttribute
	{
		[Token(Token = "0x4000163")]
		public static float kDefaultButtonWidth = 80f;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x10")]
		public readonly string MethodName;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x18")]
		private float _buttonWidth;

		[Token(Token = "0x17000083")]
		public float ButtonWidth
		{
			[Token(Token = "0x6000368")]
			[Address(RVA = "0xE2F188", Offset = "0xE2F188", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._buttonWidth;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ButtonWidth;
			}
			[Token(Token = "0x6000369")]
			[Address(RVA = "0xE2F190", Offset = "0xE2F190", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._buttonWidth = value;\n\treturn;\n")]
			set
			{
				ButtonWidth = value;
			}
		}

		[Token(Token = "0x600036A")]
		[Address(RVA = "0xE2F198", Offset = "0xE2F198", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEC048]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, MethodName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024687]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Obi.InspectorButtonAttribute>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v44, MethodName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Obi.InspectorButtonAttribute;\nL_0026:\n\tthis._buttonWidth = v55.kDefaultButtonWidth;\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.MethodName = MethodName;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InspectorButtonAttribute(string MethodName)
		{
			ButtonWidth = kDefaultButtonWidth;
			this.MethodName = MethodName;
		}
	}
}
