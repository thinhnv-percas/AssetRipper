using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200004C")]
	public class FBSDKEventBindingManager
	{
		[Token(Token = "0x17000065")]
		public List<FBSDKEventBinding> eventBindings
		{
			[CompilerGenerated]
			[Token(Token = "0x60001AA")]
			[Address(RVA = "0xD2C604", Offset = "0xD2C604", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<eventBindings>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return eventBindings;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001AB")]
			[Address(RVA = "0xD2C60C", Offset = "0xD2C60C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<eventBindings>k__BackingField = value;\n\treturn;\n")]
			set
			{
				eventBindings = value;
			}
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0xD24F54", Offset = "0xD24F54", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EE8710]);\n\tv33 = *([v32 @ X8_v28]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, listDict, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2023C0F]) = v51;\nL_001F:\n\tSystem.Object::.ctor(this);\n\tv60 = new System.Collections.Generic.List`1<Facebook.Unity.FBSDKEventBinding>();\n\tSystem.Collections.Generic.List`1<Facebook.Unity.FBSDKEventBinding>::.ctor(v60);\n\tthis.<eventBindings>k__BackingField = v60;\n\tv65 = listDict == 0;\n\tif (v65) goto L_007E;\n\tv72 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(listDict);\nL_0040:\n\tv189 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v71 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv201 = v189 == 0;\n\tif (v201) goto L_0077;\n\tv204 = v144 == 0;\n\tif (v204) goto L_0067;\n\tgoto L_FFFFFFFF;\n\tv240 = v240_asT == 0;\n\tif (v240) goto L_007A;\nL_0067:\n\tv252 = new Facebook.Unity.FBSDKEventBinding();\n\tFacebook.Unity.FBSDKEventBinding::.ctor(v252, v144);\n\tSystem.Collections.Generic.List`1<Facebook.Unity.FBSDKEventBinding>::Add(this.<eventBindings>k__BackingField, v252);\n\tgoto L_0040;\nL_0077:\n\tv209 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v71 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00A4;\nL_007A:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_007E:\n\tv142 = new System.NullReferenceException();\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\nL_008C:\n\tv199 = Il2CppMethodInfo != 1;\n\tif (v199) goto L_00A5;\n\tv202 = 0x6D2BC0(v142, Il2CppMethodInfo, v74, v36, v37, v38, v39, v40, v125, v42, v43, v44, v45, v46, v47, v48);\n\tv211 = 0x6D2490(v202, Il2CppMethodInfo, v74, v36, v37, v38, v39, v40, v125, v42, v43, v44, v45, v46, v47, v48);\n\tv215 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v115 @ stack_-70_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv312 = *([v202 @ X0_v13]) == 0;\n\tv217 = ~v312;\n\tif (v217) goto L_00A9;\nL_00A4:\n\treturn;\nL_00A5:\n\tv203 = 0x6D2380(v142, Il2CppMethodInfo, v74, v36, v37, v38, v39, v40, v125, v42, v43, v44, v45, v46, v47, v48);\nL_00A9:\n\tthrow System.TypeLoadException;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FBSDKEventBindingManager(List<object> listDict)
		{
			List<FBSDKEventBinding> list = new List<FBSDKEventBinding>();
			eventBindings = list;
			bool flag = listDict == null;
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			if (!flag)
			{
				object enumerator2 = listDict.GetEnumerator();
				List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
				Dictionary<string, object> dictionary = default(Dictionary<string, object>);
				while (true)
				{
					if (enumerator3.MoveNext())
					{
						if (dictionary != null)
						{
							Dictionary<string, object> dictionary2 = dictionary as Dictionary<string, object>;
							if (dictionary2 == null)
							{
								break;
							}
						}
						FBSDKEventBinding item = new FBSDKEventBinding(dictionary);
						eventBindings.Add(item);
						continue;
					}
					enumerator3.Dispose();
					return;
				}
				throw new InvalidCastException();
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}
	}
}
