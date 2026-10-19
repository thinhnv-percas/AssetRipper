using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000005")]
	internal static class Color32Extensions
	{
		[Token(Token = "0x4000006")]
		private static readonly List<Color32> s_Colors;

		[Token(Token = "0x4000007")]
		private static byte[] s_LinearToGammaLut;

		[Token(Token = "0x4000008")]
		private static byte[] s_GammaToLinearLut;

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x3F1EF8C", Offset = "0x3F1EF8C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tv55 = v53.s_LinearToGammaLut == 0;\n\tif (v55) goto L_003B;\n\tgoto L_001E;\nL_001E:\n\tv175 = v129.s_LinearToGammaLut;\n\tv131 = v129.s_LinearToGammaLut == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_009E;\n\tgoto L_009F;\nL_003B:\n\t// 59 NewArr v78 @ X0_v12 (System.Byte[]), typeof(System.Byte[]), 256\n\tgoto L_0046;\n\tv92 = v201 * 0x437F0000;\n\tv84[v227 @ X20_v9 (System.Int32)] = v92;\n\tv227 = v227 + 1;\n\tv87 = v227 != 0x100;\n\tif (v87) goto L_0050;\n\tgoto L_001E;\nL_009E:\n\treturn v175[self @ X0 (System.Byte)];\nL_009F:\n\tv228 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\nL_0046:\n\tv192.s_LinearToGammaLut = v78;\n\tv227 = 0;\nL_0054:\n\tv84 = v225.s_LinearToGammaLut;\n\tv306 = v227 / 0x437F0000;\n\tv201 = UnityEngine.Mathf::LinearToGammaSpace(v306);\nL_0050:\n\tgoto L_0054;\n")]
		public static byte LinearToGamma(this byte self)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Color32Extensions::LinearToGamma");
			return default;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x3F1F120", Offset = "0x3F1F120", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tv55 = v53.s_GammaToLinearLut == 0;\n\tif (v55) goto L_003B;\n\tgoto L_001E;\nL_001E:\n\tv175 = v129.s_GammaToLinearLut;\n\tv131 = v129.s_GammaToLinearLut == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_009E;\n\tgoto L_009F;\nL_003B:\n\t// 59 NewArr v78 @ X0_v12 (System.Byte[]), typeof(System.Byte[]), 256\n\tgoto L_0046;\n\tv92 = v201 * 0x437F0000;\n\tv84[v227 @ X20_v9 (System.Int32)] = v92;\n\tv227 = v227 + 1;\n\tv87 = v227 != 0x100;\n\tif (v87) goto L_0050;\n\tgoto L_001E;\nL_009E:\n\treturn v175[self @ X0 (System.Byte)];\nL_009F:\n\tv228 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\nL_0046:\n\tv192.s_GammaToLinearLut = v78;\n\tv227 = 0;\nL_0054:\n\tv84 = v225.s_GammaToLinearLut;\n\tv306 = v227 / 0x437F0000;\n\tv201 = UnityEngine.Mathf::GammaToLinearSpace(v306);\nL_0050:\n\tgoto L_0054;\n")]
		public static byte GammaToLinear(this byte self)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Color32Extensions::GammaToLinear");
			return default;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x3F1F2B4", Offset = "0x3F1F2B4", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_001A;\nL_001A:\n\tv61 = self == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0039;\n\tgoto L_009D;\nL_0039:\n\tUnityEngine.Mesh::GetColors(self, v75.s_Colors);\n\tv145 = v151.s_Colors;\n\tv165 = v145.Count < 1;\n\tif (v165) goto L_0087;\n\tv149 = 0;\nL_005E:\n\tv269 = System.Collections.Generic.List`1<UnityEngine.Color32>::get_Item(v147.s_Colors, v149);\n\tv270 = v269 & 0xFF;\n\tv271 = Coffee.UIParticleInternal.Color32Extensions::LinearToGamma(v270);\n\tv273 = v269.g & 0xFF;\n\tv274 = Coffee.UIParticleInternal.Color32Extensions::LinearToGamma(v273);\n\tv276 = v269.b & 0xFF;\n\tv277 = Coffee.UIParticleInternal.Color32Extensions::LinearToGamma(v276);\n\tv228 = v269 & 0xFFFFFFFFFF000000;\n\tv279 = v228 | v277;\n\tv251 = v279 | v274;\n\tv244 = v251 | v271;\n\tSystem.Collections.Generic.List`1<UnityEngine.Color32>::set_Item(v86.s_Colors, v149, v244);\n\tv149 = v149 + 1;\n\tv234 = v145.Count != v149;\n\tif (v234) goto L_0055;\nL_009D:\n\tthrow System.NullReferenceException;\nL_0087:\n\tgoto L_009B;\nL_0055:\n\tgoto L_005E;\nL_009B:\n\tUnityEngine.Mesh::SetColors(self, v217.s_Colors);\n\treturn;\n")]
		public static void LinearToGamma(this Mesh self)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Color32Extensions::LinearToGamma");
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x3F1F460", Offset = "0x3F1F460", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_001A;\nL_001A:\n\tv61 = self == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0039;\n\tgoto L_009D;\nL_0039:\n\tUnityEngine.Mesh::GetColors(self, v75.s_Colors);\n\tv145 = v151.s_Colors;\n\tv165 = v145.Count < 1;\n\tif (v165) goto L_0087;\n\tv149 = 0;\nL_005E:\n\tv269 = System.Collections.Generic.List`1<UnityEngine.Color32>::get_Item(v147.s_Colors, v149);\n\tv270 = v269 & 0xFF;\n\tv271 = Coffee.UIParticleInternal.Color32Extensions::GammaToLinear(v270);\n\tv273 = v269.g & 0xFF;\n\tv274 = Coffee.UIParticleInternal.Color32Extensions::GammaToLinear(v273);\n\tv276 = v269.b & 0xFF;\n\tv277 = Coffee.UIParticleInternal.Color32Extensions::GammaToLinear(v276);\n\tv228 = v269 & 0xFFFFFFFFFF000000;\n\tv279 = v228 | v277;\n\tv251 = v279 | v274;\n\tv244 = v251 | v271;\n\tSystem.Collections.Generic.List`1<UnityEngine.Color32>::set_Item(v86.s_Colors, v149, v244);\n\tv149 = v149 + 1;\n\tv234 = v145.Count != v149;\n\tif (v234) goto L_0055;\nL_009D:\n\tthrow System.NullReferenceException;\nL_0087:\n\tgoto L_009B;\nL_0055:\n\tgoto L_005E;\nL_009B:\n\tUnityEngine.Mesh::SetColors(self, v217.s_Colors);\n\treturn;\n")]
		public static void GammaToLinear(this Mesh self)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Color32Extensions::GammaToLinear");
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x3F1F60C", Offset = "0x3F1F60C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.List`1<UnityEngine.Color32>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Color32>::.ctor(v49);\n\tv58.s_Colors = v49;\n")]
		static Color32Extensions()
		{
			List<Color32> list = new List<Color32>();
			s_Colors = list;
		}
	}
}
