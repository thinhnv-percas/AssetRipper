using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000B1")]
	public static class DOTweenExternalCommand
	{
		[CompilerGenerated]
		[Token(Token = "0x4000215")]
		private static Action<PathOptions, Tween, Quaternion, Transform> m_SetOrientationOnPath;

		[Token(Token = "0x14000001")]
		public static event Action<PathOptions, Tween, Quaternion, Transform> SetOrientationOnPath
		{
			[CompilerGenerated]
			[Token(Token = "0x600041D")]
			[Address(RVA = "0xC2DE68", Offset = "0xC2DE68", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv24 = System.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = DG.Tweening.Core.DOTweenExternalCommand;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A357E6]) = v44;\nL_0021:\n\tv98 = System.Delegate::Combine(v93, value);\n\tv99 = v98 == 0;\n\tif (v99) goto L_FFFFFFFF;\n\t// 39 IsInst v103 @ X0_v8 (System.Int32), typeof(System.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>), v98 @ X0_v4 (System.Delegate)\n\tv106 = v103 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0031;\n\tgoto L_0049;\nL_0031:\n\tv88 = 0xAF4130(v92.SetOrientationOnPath, v82, v93, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv56 = v93 != v88;\n\tif (v56) goto L_0021;\n\treturn;\nL_0049:\n\tthrow System.InvalidCastException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0012: Expected I4, but got O
				Delegate obj = DOTweenExternalCommand.m_SetOrientationOnPath;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if ((object)obj2 != null)
					{
						int num = (int)(obj2 as Action<PathOptions, Tween, Quaternion, Transform>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj != obj3;
					obj = obj3;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600041E")]
			[Address(RVA = "0xC2DF34", Offset = "0xC2DF34", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv24 = System.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = DG.Tweening.Core.DOTweenExternalCommand;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A357E7]) = v44;\nL_0021:\n\tv98 = System.Delegate::Remove(v93, value);\n\tv99 = v98 == 0;\n\tif (v99) goto L_FFFFFFFF;\n\t// 39 IsInst v103 @ X0_v8 (System.Int32), typeof(System.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>), v98 @ X0_v4 (System.Delegate)\n\tv106 = v103 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0031;\n\tgoto L_0049;\nL_0031:\n\tv88 = 0xAF4130(v92.SetOrientationOnPath, v82, v93, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv56 = v93 != v88;\n\tif (v56) goto L_0021;\n\treturn;\nL_0049:\n\tthrow System.InvalidCastException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0012: Expected I4, but got O
				Delegate obj = DOTweenExternalCommand.m_SetOrientationOnPath;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if ((object)obj2 != null)
					{
						int num = (int)(obj2 as Action<PathOptions, Tween, Quaternion, Transform>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj != obj3;
					obj = obj3;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x600041F")]
		[Address(RVA = "0xC2E000", Offset = "0xC2E000", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv44 = DG.Tweening.Core.DOTweenExternalCommand;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, t, trans, methodInfo, v47, v48, v49, v50, newRot, v0, v2, v3, v51, v52, v53, v54);\n\tv57 = 1;\n\t*([1A357E8]) = v57;\nL_0025:\n\tv60 = v59.SetOrientationOnPath;\n\tv61 = v59.SetOrientationOnPath == 0;\n\tif (v61) goto L_0048;\n\tv66 = 0x1854F10(&v63 @ stack_-140, options, 0x70, methodInfo, v47, v48, v49, v50, newRot, newRot.y, newRot.z, newRot.w, v51, v52, v53, v54);\n\tv104 = 0x1854F10(&v101 @ stack_-D0, &v63 @ stack_-140, 0x70, methodInfo, v47, v48, v49, v50, newRot, newRot.y, newRot.z, newRot.w, v51, v52, v53, v54);\n\tSystem.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>::Invoke(v59.SetOrientationOnPath, &v101 @ stack_-D0, t, trans, v60.method);\nL_0048:\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static void Dispatch_SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans)
		{
			//IL_0047: Expected O, but got I
			//IL_0047: Expected O, but got Ref
			Action<PathOptions, Tween, Quaternion, Transform> setOrientationOnPath = DOTweenExternalCommand.SetOrientationOnPath;
			if (DOTweenExternalCommand.SetOrientationOnPath != null)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				object obj = default(object);
				DOTweenExternalCommand.SetOrientationOnPath((PathOptions)(&obj), t, (Quaternion)trans, (Transform)(nint)setOrientationOnPath.method);
			}
		}
	}
}
