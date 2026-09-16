using System;
using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x200000F")]
	internal class FirebaseAppPlatform : Firebase.Platform.IFirebaseAppPlatform
	{
		[Token(Token = "0x17000010")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x73B594", Offset = "0x73B594")]
		[field: Token(Token = "0x4000031")]
		[field: FieldOffset(Offset = "0x10")]
		private WeakReference app
		{
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x1601554", Offset = "0x1601554", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<app>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000074")]
			[Address(RVA = "0x160155C", Offset = "0x160155C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<app>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000011")]
		public object AppObject
		{
			[Token(Token = "0x6000075")]
			[Address(RVA = "0x1601564", Offset = "0x1601564", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F101B0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1AA]) = v38;\nL_0014:\n\tv40 = this.<app>k__BackingField == 0;\n\tif (v40) goto L_0020;\n\treturnVal1 = System.WeakReference::get_Target(this.<app>k__BackingField);\nL_001F:\n\treturn returnVal1;\nL_0020:\n\tv45 = new System.NullReferenceException();\n\tv48 = v104 != 1;\n\tif (v48) goto L_0047;\n\tv118 = 0x6D2BC0(v45, v104, v93, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv84 = *([v118 @ X0_v10]);\n\tv130 = \"il2cpp_vm_class_is_assignable_from\"(System.InvalidOperationException, *([v84 @ X8_v5]), v93, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv131 = v130 & 1;\n\tv80 = v131 == 0;\n\tif (v80) goto L_003D;\n\tv132 = 0x6D2490(v130, *([v84 @ X8_v5]), v93, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_001F;\nL_003D:\n\tv134 = 0x6D1E60(8, *([v84 @ X8_v5]), v93, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v134 @ X0_v14]) = *([v118 @ X0_v10]);\n\tv104 = 0x1E8A000 + 0x870;\n\tv136 = 0x6D2A00(v134, v104, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv123 = 0x6D2490(v136, v104, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\tv127 = 0x6D2380(v112, v104, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturnVal2 = 0x846AA4(v127, v104, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (app != null)
				{
					return app.Target;
				}
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				bool flag = intPtr != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (!flag)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj2 = default(object);
					object obj = obj2;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj3 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						return null;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj4 = obj2;
					intPtr = (IntPtr)(32022528 + 2160);
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					NullReferenceException ex3 = default(NullReferenceException);
					ex2 = ex3;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				object result = default(object);
				return result;
			}
		}

		[Token(Token = "0x17000012")]
		internal FirebaseApp App
		{
			[Token(Token = "0x6000076")]
			[Address(RVA = "0x1601630", Offset = "0x1601630", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F003F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1AB]) = v38;\nL_0014:\n\tv40 = Firebase.Platform.FirebaseAppPlatform::get_AppObject(this);\n\tv41 = v40 == 0;\n\tif (v41) goto L_002F;\n\tv55 = *([v40 @ X0_v3 (System.Object)]) != Firebase.FirebaseApp;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002F;\nL_002F:\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				object appObject = AppObject;
				bool flag = appObject == null;
				FirebaseApp result = (FirebaseApp)appObject;
				if (!flag)
				{
					result = (FirebaseApp)(((object)appObject.GetType() != typeof(FirebaseApp)) ? null : appObject);
				}
				return result;
			}
		}

		[Token(Token = "0x17000013")]
		public string Name
		{
			[Token(Token = "0x6000077")]
			[Address(RVA = "0x1601694", Offset = "0x1601694", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Firebase.Platform.FirebaseAppPlatform::get_App(this);\n\tv9 = v6 == 0;\n\tif (v9) goto L_000B;\n\treturnVal1 = v6.name;\nL_000B:\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FirebaseApp firebaseApp = App;
				bool flag = firebaseApp == null;
				string result = (string)(object)firebaseApp;
				if (!flag)
				{
					result = firebaseApp.Name;
				}
				return result;
			}
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x1600C94", Offset = "0x1600C94", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EA4568]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, wrappedApp, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1A9]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv47 = new System.WeakReference();\n\tSystem.WeakReference::.ctor(v47, wrappedApp, 0);\n\tthis.<app>k__BackingField = v47;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal FirebaseAppPlatform(FirebaseApp wrappedApp)
		{
			WeakReference weakReference = new WeakReference(wrappedApp, trackResurrection: false);
			app = weakReference;
		}
	}
}
