using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Extensions
{
	[Token(Token = "0x2000017")]
	public static class ObjectExtensions
	{
		[Token(Token = "0x6000097")]
		[Address(RVA = "0x4B01CAC", Offset = "0x4B01CAC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001E:\n\tv52 = UnityEngine.Object::op_Implicit(returnVal1);\n\tv57 = v52 == 0;\n\tv62 = ~v57;\n\tv63 = ~v62;\n\tif (v63) goto L_0036;\n\tgoto L_0036;\nL_001A:\n\tgoto L_001E;\nL_0036:\n\treturn 0;\n")]
		public static T OrNull<T>(this T obj) where T : Object
		{
			T val = default(T);
			if ((bool)val)
			{
			}
			return null;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x81AA754", Offset = "0x81AA754", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = obj == 0;\n\treturn v5;\n")]
		public static bool IsNull(this object obj)
		{
			return obj == null;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x4B01BE4", Offset = "0x4B01BE4", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_001C;\n\tv39 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001C:\n\tv49 = UnityEngine.GameObject::GetComponent(gameObject);\n\tgoto L_0027;\nL_0027:\n\tv61 = UnityEngine.Object::op_Equality(v49, 0);\n\tv95 = ~v61;\n\tif (v95) goto L_0046;\n\treturnVal3 = UnityEngine.GameObject::AddComponent(gameObject);\n\treturn returnVal3;\nL_0046:\n\treturn v49;\n")]
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			Object component = gameObject.GetComponent<T>();
			if (component == null)
			{
				return gameObject.AddComponent<T>();
			}
			return (T)component;
		}
	}
}
