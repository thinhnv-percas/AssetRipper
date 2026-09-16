using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200004C")]
	public class Pow : IInterpolation
	{
		[Token(Token = "0x170000EA")]
		public float Power
		{
			[CompilerGenerated]
			[Token(Token = "0x60002F5")]
			[Address(RVA = "0x153349C", Offset = "0x153349C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Power>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Power;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002F6")]
			[Address(RVA = "0x15334A4", Offset = "0x15334A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Power>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Power = value;
			}
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0x153342C", Offset = "0x153342C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.IInterpolation;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, power, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B68]) = v40;\nL_0019:\n\tgoto L_001D;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v25, v26, v27, v28, v29, v30, power, v31, v32, v33, v34, v35, v36, v37);\nL_001D:\n\tSystem.Object::.ctor(this);\n\tthis.<Power>k__BackingField = power;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Pow(float power)
		{
			Power = power;
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0x15334AC", Offset = "0x15334AC", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = System.Math;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, a, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A37B69]) = v44;\nL_001C:\n\tgoto L_001F;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v29, v30, v31, v32, v33, v34, a, v35, v36, v37, v38, v39, v40, v41);\nL_001F:\n\tv53 = a < 0.5f;\n\tv54 = ~v53;\n\tv55 = a - 0.5f;\n\tv57 = v55 == 0;\n\tv62 = ~v54;\n\tv63 = v62 | v57;\n\tif (v63) goto L_004D;\n\tv65 = a + -1f;\n\tv66 = v65 + v65;\n\tv70 = System.Math::Pow(v66, this.<Power>k__BackingField);\n\tv81 = 0x1854EF0(0, methodInfo, v29, v30, v31, v32, v33, v34, this.<Power>k__BackingField, 2f, this.<Power>k__BackingField, v37, v38, v39, v40, v41);\n\tv95 = this.<Power>k__BackingField != 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tv124 = v70 / v123;\n\tv103 = v124 + 1f;\n\tgoto L_005C;\nL_004D:\n\tv71 = a + a;\n\tv75 = System.Math::Pow(v71, this.<Power>k__BackingField);\n\tv83 = v75 * 0.5f;\nL_005C:\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override float Apply(float a)
		{
			//IL_00aa: Expected O, but got F4
			bool flag = a < 0.5f;
			bool flag2 = !flag;
			float num = a - 0.5f;
			bool flag3 = num == 0f;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				float num2 = a + -1f;
				float num3 = num2 + num2;
				double num4 = Math.Pow(num3, Power);
				object obj = Power % 2f;
				float num5 = ((Power != 0f) ? 2f : (-2f));
				double num6 = num4 / (double)num5;
				double num7 = num6 + 1.0;
				return (float)num7;
			}
			float num8 = a + a;
			double num9 = Math.Pow(num8, Power);
			double num10 = num9 * 0.5;
			return (float)num10;
		}
	}
}
