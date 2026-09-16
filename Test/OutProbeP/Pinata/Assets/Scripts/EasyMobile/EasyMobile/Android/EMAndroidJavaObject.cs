using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Android
{
	[Token(Token = "0x2000095")]
	internal class EMAndroidJavaObject : IDisposable
	{
		[Token(Token = "0x400037E")]
		[FieldOffset(Offset = "0x10")]
		private readonly AndroidJavaObject nativeObj;

		[Token(Token = "0x170001C6")]
		public AndroidJavaObject NativeObject
		{
			[Token(Token = "0x6000648")]
			[Address(RVA = "0xA4D6B4", Offset = "0xA4D6B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.nativeObj;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return NativeObject;
			}
		}

		[Token(Token = "0x6000649")]
		[Address(RVA = "0xA4D6BC", Offset = "0xA4D6BC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED5AC8]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, className, args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021F2C]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tv50 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v50, className, args);\n\tthis.nativeObj = v50;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EMAndroidJavaObject(string className, params object[] args)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject(className, args);
			nativeObj = androidJavaObject;
		}

		[Token(Token = "0x600064A")]
		[Address(RVA = "0xA4D740", Offset = "0xA4D740", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.nativeObj = nativeObj;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EMAndroidJavaObject(AndroidJavaObject nativeObj)
		{
			this.nativeObj = nativeObj;
		}

		[Token(Token = "0x600064B")]
		[Address(RVA = "0xA4D76C", Offset = "0xA4D76C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.AndroidJavaObject::Dispose(this.nativeObj);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			NativeObject.Dispose();
		}

		[Token(Token = "0x600064C")]
		[Address(RVA = "0xA4D788", Offset = "0xA4D788", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.AndroidJavaObject::Call(this.nativeObj, methodName, args);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Call(string methodName, params object[] args)
		{
			NativeObject.Call(methodName, args);
		}

		[Token(Token = "0x600064D")]
		[Address(RVA = "0xB87B60", Offset = "0xB87B60", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.nativeObj;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X4_v1, v0 @ X0_v1 (UnityEngine.AndroidJavaObject), v0 @ X0_v1 (UnityEngine.AndroidJavaObject), methodName @ X1 (System.String), args @ X2 (System.Object[]), methodof(UnityEngine.AndroidJavaObject::Call), v6 @ X4_v1, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Call<T>(string methodName, params object[] args)
		{
			//IL_001d: Expected O, but got I
			AndroidJavaObject nativeObject = NativeObject;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x600064E")]
		[Address(RVA = "0xA4D7A4", Offset = "0xA4D7A4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.AndroidJavaObject::CallStatic(this.nativeObj, methodName, args);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CallStatic(string methodName, params object[] args)
		{
			NativeObject.CallStatic(methodName, args);
		}

		[Token(Token = "0x600064F")]
		[Address(RVA = "0xB87B84", Offset = "0xB87B84", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.nativeObj;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X4_v1, v0 @ X0_v1 (UnityEngine.AndroidJavaObject), v0 @ X0_v1 (UnityEngine.AndroidJavaObject), methodName @ X1 (System.String), args @ X2 (System.Object[]), methodof(UnityEngine.AndroidJavaObject::CallStatic), v6 @ X4_v1, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T CallStatic<T>(string methodName, params object[] args)
		{
			//IL_001d: Expected O, but got I
			AndroidJavaObject nativeObject = NativeObject;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000650")]
		[Address(RVA = "0xB87BA8", Offset = "0xB87BA8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.nativeObj;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X3_v1, v0 @ X0_v1 (UnityEngine.AndroidJavaObject), v0 @ X0_v1 (UnityEngine.AndroidJavaObject), fieldName @ X1 (System.String), methodof(UnityEngine.AndroidJavaObject::Get), v6 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Get<T>(string fieldName)
		{
			//IL_001d: Expected O, but got I
			AndroidJavaObject nativeObject = NativeObject;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X3_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000651")]
		[Address(RVA = "0xB87BCC", Offset = "0xB87BCC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.nativeObj;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X3_v1, v0 @ X0_v1 (UnityEngine.AndroidJavaObject), v0 @ X0_v1 (UnityEngine.AndroidJavaObject), fieldName @ X1 (System.String), methodof(UnityEngine.AndroidJavaObject::GetStatic), v6 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetStatic<T>(string fieldName)
		{
			//IL_001d: Expected O, but got I
			AndroidJavaObject nativeObject = NativeObject;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X3_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000652")]
		[Address(RVA = "0xBB2834", Offset = "0xBB2834", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.nativeObj;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X4_v1, v0 @ X0_v1 (UnityEngine.AndroidJavaObject), v0 @ X0_v1 (UnityEngine.AndroidJavaObject), fieldName @ X1 (System.String), val @ X2 (T), methodof(UnityEngine.AndroidJavaObject::Set), v6 @ X4_v1, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Set<T>(string fieldName, T val)
		{
			//IL_001d: Expected O, but got I
			AndroidJavaObject nativeObject = NativeObject;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000653")]
		[Address(RVA = "0xBB2858", Offset = "0xBB2858", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.nativeObj;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X4_v1, v0 @ X0_v1 (UnityEngine.AndroidJavaObject), v0 @ X0_v1 (UnityEngine.AndroidJavaObject), fieldName @ X1 (System.String), val @ X2 (T), methodof(UnityEngine.AndroidJavaObject::SetStatic), v6 @ X4_v1, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetStatic<T>(string fieldName, T val)
		{
			//IL_001d: Expected O, but got I
			AndroidJavaObject nativeObject = NativeObject;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000654")]
		[Address(RVA = "0xA4D7C0", Offset = "0xA4D7C0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.AndroidJavaObject::GetRawObject(this.nativeObj);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntPtr GetRawObject()
		{
			return NativeObject.GetRawObject();
		}

		[Token(Token = "0x6000655")]
		[Address(RVA = "0xA4D7DC", Offset = "0xA4D7DC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.AndroidJavaObject::GetRawClass(this.nativeObj);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntPtr GetRawClass()
		{
			return NativeObject.GetRawClass();
		}
	}
}
