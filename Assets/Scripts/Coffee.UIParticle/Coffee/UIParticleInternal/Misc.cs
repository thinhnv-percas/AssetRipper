using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000015")]
	public static class Misc
	{
		[Token(Token = "0x6000054")]
		[Address(RVA = "0x4AE1D3C", Offset = "0x4AE1D3C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0017;\nL_0017:\n\tgoto L_0022;\nL_0022:\n\treturnVal1 = UnityEngine.Object::FindObjectsByType(1, 0);\n\treturn returnVal1;\n\tv64 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0022;\n")]
		public static T[] FindObjectsOfType<T>() where T : Object
		{
			return Object.FindObjectsByType<T>(FindObjectsInactive.Include, default(FindObjectsSortMode));
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x3F20954", Offset = "0x3F20954", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(obj);\n\tv58 = ~v51;\n\tif (v58) goto L_0040;\n\tgoto L_0026;\nL_0026:\n\tUnityEngine.Object::Destroy(obj);\n\treturn;\nL_0040:\n\treturn;\n")]
		public static void Destroy(Object obj)
		{
			if ((bool)obj)
			{
				Object.Destroy(obj);
			}
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x3F20A1C", Offset = "0x3F20A1C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(obj);\n\tv58 = ~v51;\n\tif (v58) goto L_0040;\n\tgoto L_0026;\nL_0026:\n\tUnityEngine.Object::Destroy(obj);\n\treturn;\nL_0040:\n\treturn;\n")]
		public static void DestroyImmediate(Object obj)
		{
			if ((bool)obj)
			{
				Object.Destroy(obj);
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Token(Token = "0x6000057")]
		[Address(RVA = "0x3F20AE4", Offset = "0x3F20AE4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetDirty(Object obj)
		{
		}

		[Conditional("UNITY_EDITOR")]
		[Token(Token = "0x6000058")]
		[Address(RVA = "0x3F20AE8", Offset = "0x3F20AE8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void QueuePlayerLoopUpdate()
		{
		}
	}
}
