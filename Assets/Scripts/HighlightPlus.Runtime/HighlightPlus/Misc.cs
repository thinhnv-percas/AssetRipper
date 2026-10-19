using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[Token(Token = "0x200003E")]
	public class Misc
	{
		[Token(Token = "0x4000341")]
		public static Vector2 vector2Zero;

		[Token(Token = "0x4000342")]
		public static Vector2 vector2One;

		[Token(Token = "0x4000343")]
		public static Vector3 vector3Zero;

		[Token(Token = "0x4000344")]
		public static Vector3 vector3Max;

		[Token(Token = "0x4000345")]
		public static Vector3 vector3Min;

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x4AE1DBC", Offset = "0x4AE1DBC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0017;\nL_0017:\n\tgoto L_0020;\nL_0020:\n\treturnVal1 = UnityEngine.Object::FindAnyObjectByType(includeInactive);\n\treturn returnVal1;\n\tv63 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0020;\n")]
		public static T FindObjectOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindAnyObjectByType<T>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude);
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x7732B44", Offset = "0x7732B44", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0028:\n\treturnVal1 = UnityEngine.Object::FindObjectsByType(type, includeInactive, 0);\n\treturn returnVal1;\nL_001B:\n\tgoto L_0028;\n")]
		public static UnityEngine.Object[] FindObjectsOfType(Type type, bool includeInactive = false)
		{
			return UnityEngine.Object.FindObjectsByType(type, includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, default(FindObjectsSortMode));
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x4AE1E50", Offset = "0x4AE1E50", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0018;\nL_0018:\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = UnityEngine.Object::FindObjectsByType(includeInactive, 0);\n\treturn returnVal1;\n\tv65 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0023;\n")]
		public static T[] FindObjectsOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindObjectsByType<T>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, default(FindObjectsSortMode));
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x7732BB4", Offset = "0x7732BB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Misc()
		{
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x7732BBC", Offset = "0x7732BBC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tv40.vector2Zero = 0;\n\tv42.vector2One = 0;\n\tv44.vector3Zero = *([92E1060]);\n\tv44.vector3Max.y = *([92BCB10]);\n\tv44.vector3Min.z = -3.4028235E+38f;\n\treturn;\n")]
		static Misc()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Misc::.cctor");
		}
	}
}
