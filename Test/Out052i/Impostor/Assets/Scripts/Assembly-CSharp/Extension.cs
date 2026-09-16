using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000024")]
public static class Extension
{
	[Token(Token = "0x60000E3")]
	[Address(RVA = "0xBFF390", Offset = "0xBFF390", Length = "0x18")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(obj, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Hide(this GameObject obj)
	{
		obj.SetActive(value: false);
	}

	[Token(Token = "0x60000E4")]
	[Address(RVA = "0xBFFD84", Offset = "0xBFFD84", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = UnityEngine.Component::get_gameObject(component);\n\tUnityEngine.GameObject::SetActive(v5, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Hide(this Component component)
	{
		GameObject gameObject = component.gameObject;
		gameObject.SetActive(value: false);
	}

	[Token(Token = "0x60000E5")]
	[Address(RVA = "0xBFFDAC", Offset = "0xBFFDAC", Length = "0x18")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(obj, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Show(this GameObject obj)
	{
		obj.SetActive(value: true);
	}

	[Token(Token = "0x60000E6")]
	[Address(RVA = "0xBFFDC4", Offset = "0xBFFDC4", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = UnityEngine.Component::get_gameObject(o);\n\tUnityEngine.GameObject::SetActive(v5, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Show(this Component o)
	{
		GameObject gameObject = o.gameObject;
		gameObject.SetActive(value: true);
	}

	[Token(Token = "0x60000E7")]
	[Address(RVA = "0xC71BEC", Offset = "0xC71BEC", Length = "0x94")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = 0xB3490C(methodInfo, methodInfo, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0012:\n\tgoto L_0017;\n\tv37 = v32;\n\tv38 = 0xB348B0(v37, v32, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv40 = v38;\nL_0017:\n\t// 23 IsInst v43 @ X0_v4, typeof(Il2CppMethodRgctx<Extension::Cast>), mono @ X0 (UnityEngine.MonoBehaviour)\n\tgoto L_0023;\n\tv51 = v46;\n\tv52 = 0xB348B0(v51, v39, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv55 = v52;\nL_0023:\n\tv56 = v43 == 0;\n\tif (v56) goto L_FFFFFFFF;\n\t// 39 IsInst returnVal1 @ X0_v6 (T), typeof(T), v43 @ X0_v4\n\tv67 = returnVal1 == 0;\n\tv65 = ~v67;\n\tif (v65) goto L_0033;\n\tthrow System.InvalidCastException;\nL_0033:\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static T Cast<T>(this MonoBehaviour mono) where T : class
	{
		object obj = ((mono is IntPtr) ? mono : null);
		T val;
		if (obj != null)
		{
			val = obj as T;
			if (val == null)
			{
				throw new InvalidCastException();
			}
		}
		else
		{
			val = null;
		}
		return val;
	}
}
