using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200004D")]
	public class PowOut : Pow
	{
		[Token(Token = "0x60002F9")]
		[Address(RVA = "0x1533498", Offset = "0x1533498", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Pow::.ctor(this, power);\n\treturn;\n")]
		public PowOut(float power)
			: base(power)
		{
		}

		[Token(Token = "0x60002FA")]
		[Address(RVA = "0x1533590", Offset = "0x1533590", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = System.Math;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, a, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37B6A]) = v42;\nL_001B:\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v27, v28, v29, v30, v31, v32, a, v33, v34, v35, v36, v37, v38, v39);\nL_001E:\n\tv51 = a + -1f;\n\tv55 = System.Math::Pow(v51, this.<Power>k__BackingField);\n\tv60 = 0x1854EF0(0, methodInfo, v27, v28, v29, v30, v31, v32, this.<Power>k__BackingField, 2f, this.<Power>k__BackingField, v35, v36, v37, v38, v39);\n\tv79 = -v55;\n\tv76 = this.<Power>k__BackingField != 0;\n\tif (v76) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\treturnVal1 = v79 + 1f;\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override float Apply(float a)
		{
			//IL_0038: Expected O, but got F4
			float num = a + -1f;
			double num2 = Math.Pow(num, Power);
			object obj = Power % 2f;
			double num3 = 0.0 - num2;
			if (Power != 0f)
			{
				num3 = num2;
			}
			return (float)num3 + 1f;
		}
	}
}
