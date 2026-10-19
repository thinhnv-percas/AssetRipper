using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000008")]
	internal static class Vector3Extensions
	{
		[Token(Token = "0x6000018")]
		[Address(RVA = "0x3F1F74C", Offset = "0x3F1F74C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv73 = v71 * 0x358637BD;\n\tv74 = v73 < v58;\n\tv75 = v73 == v58;\n\tv78 = v73 == v73;\n\tv79 = v58 == v58;\n\tv80 = v78 & v79;\n\tv81 = ~v80;\n\tv82 = v74 == v81;\n\tv83 = ~v75;\n\tv84 = v82 & v83;\n\tv85 = ~v84;\n\tif (v85) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv88 = v73;\n\tgoto L_0048;\nL_FFFFFFFF:\n\tv88 = v58;\n\tgoto L_0061;\nL_0020:\n\tv58 = v55.Epsilon * 8f;\n\t// 35 NotImplemented \"Instruction FABD not yet implemented.\"\n\t// 36 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv62 = UnityEngine.Mathf::Max(8f, 0f);\n\t// 40 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 42 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 43 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 44 NotImplemented \"Instruction BIT not yet implemented.\"\n\t// 45 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 49 NotImplemented \"Instruction BSL not yet implemented.\"\n\tv69 = UnityEngine.Mathf::Abs(self.z);\n\tv71 = UnityEngine.Mathf::Max(v69, 0f);\nL_0048:\n\t// 72 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv91 = v73 < v88;\n\tv99 = ~v91;\n\tif (v99) goto L_0061;\nL_0061:\n\treturn v62;\n")]
		public static Vector3 Inverse(this Vector3 self)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Vector3Extensions::Inverse");
			return default;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x3F1F8CC", Offset = "0x3F1F8CC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = self * other1;\n\treturn returnVal1;\n")]
		public static Vector3 GetScaled(this Vector3 self, Vector3 other1)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Vector3Extensions::GetScaled");
			return default;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x3F1F8DC", Offset = "0x3F1F8DC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = self * other1;\n\treturnVal1 = other2 * v12;\n\treturn returnVal1;\n")]
		public static Vector3 GetScaled(this Vector3 self, Vector3 other1, Vector3 other2)
		{
			float num = self.x * other1.x;
			float x = other2.x * num;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x3F1F900", Offset = "0x3F1F900", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = self * other1;\n\tv21 = other2 * v18;\n\treturnVal1 = other3 * v21;\n\treturn returnVal1;\n")]
		public static Vector3 GetScaled(this Vector3 self, Vector3 other1, Vector3 other2, Vector3 other3)
		{
			float num = self.x * other1.x;
			float num2 = other2.x * num;
			float x = other3.x * num2;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x3F1F934", Offset = "0x3F1F934", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = self * self.y;\n\tv4 = self.z * v3;\n\tv5 = v4 < 0;\n\tv6 = v4 == 0;\n\tv9 = v4 == v4;\n\tv10 = ~v9;\n\tv12 = v5 == v10;\n\tv13 = ~v12;\n\tv14 = v13 | v6;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = v5;\n\tgoto L_0014;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_0014:\n\treturn returnVal1;\n")]
		public static bool IsVisible(this Vector3 self)
		{
			float num = self.x * self.y;
			float num2 = self.z * num;
			bool flag = num2 < 0f;
			bool flag2 = num2 == 0f;
			bool flag3 = num2 == num2;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			if (flag6 || flag2)
			{
				return flag;
			}
			return true;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x3F1F94C", Offset = "0x3F1F94C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = self * self.y;\n\tv4 = v3 < 0;\n\tv5 = v3 == 0;\n\tv8 = v3 == v3;\n\tv9 = ~v8;\n\tv11 = v4 == v9;\n\tv12 = ~v11;\n\tv13 = v12 | v5;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = v4;\n\tgoto L_0013;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_0013:\n\treturn returnVal1;\n")]
		public static bool IsVisible2D(this Vector3 self)
		{
			float num = self.x * self.y;
			bool flag = num < 0f;
			bool flag2 = num == 0f;
			bool flag3 = num == num;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			if (flag6 || flag2)
			{
				return flag;
			}
			return true;
		}
	}
}
