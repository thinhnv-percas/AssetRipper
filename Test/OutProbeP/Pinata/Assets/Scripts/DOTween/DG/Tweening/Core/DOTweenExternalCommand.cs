using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x200004F")]
	public static class DOTweenExternalCommand
	{
		[CompilerGenerated]
		[Token(Token = "0x4000155")]
		private static Action<PathOptions, Tween, Quaternion, Transform> m_SetOrientationOnPath;

		[Token(Token = "0x14000001")]
		public static event Action<PathOptions, Tween, Quaternion, Transform> SetOrientationOnPath
		{
			[CompilerGenerated]
			[Token(Token = "0x600029D")]
			[Address(RVA = "0x1071C04", Offset = "0x1071C04", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC7070]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202698F]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.SetOrientationOnPath, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				Delegate obj = DOTweenExternalCommand.m_SetOrientationOnPath;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<PathOptions, Tween, Quaternion, Transform>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600029E")]
			[Address(RVA = "0x1071CB8", Offset = "0x1071CB8", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBB158]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026990]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.SetOrientationOnPath, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				Delegate obj = DOTweenExternalCommand.m_SetOrientationOnPath;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<PathOptions, Tween, Quaternion, Transform>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x600029F")]
		[Address(RVA = "0x1071D6C", Offset = "0x1071D6C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv44 = *([1EE16F8]);\n\tv45 = *([v44 @ X8_v11]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, t, trans, methodInfo, v48, v49, v50, v51, newRot, v0, v2, v3, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2026991]) = v58;\nL_0028:\n\tv64 = v62.SetOrientationOnPath == 0;\n\tif (v64) goto L_004B;\n\tv69 = 0x6D2410(&v66 @ stack_-140, options, 0x70, methodInfo, v48, v49, v50, v51, newRot, newRot.y, newRot.z, newRot.w, v52, v53, v54, v55);\n\tv108 = 0x6D2410(&v105 @ stack_-D0, &v66 @ stack_-140, 0x70, methodInfo, v48, v49, v50, v51, newRot, newRot.y, newRot.z, newRot.w, v52, v53, v54, v55);\n\tSystem.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>::Invoke(v62.SetOrientationOnPath, &v105 @ stack_-D0, t, trans, Il2CppMethodInfo);\nL_004B:\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static void Dispatch_SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans)
		{
			//IL_0040: Expected O, but got I
			//IL_0040: Expected O, but got Ref
			if (DOTweenExternalCommand.SetOrientationOnPath != null)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
				object obj = default(object);
				DOTweenExternalCommand.SetOrientationOnPath((PathOptions)(&obj), t, (Quaternion)trans, (Transform)0);
			}
		}
	}
}
