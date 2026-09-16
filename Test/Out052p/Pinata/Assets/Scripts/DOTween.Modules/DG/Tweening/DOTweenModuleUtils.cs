using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Scripting;

namespace DG.Tweening
{
	[Token(Token = "0x2000009")]
	public static class DOTweenModuleUtils
	{
		[Token(Token = "0x2000050")]
		public static class Physics
		{
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x157EE0C", Offset = "0x157EE0C", Length = "0x138")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv42 = *([1EC9E40]);\n\tv43 = *([v42 @ X8_v17]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, t, trans, methodInfo, v46, v47, v48, v49, newRot, v0, v2, v3, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([202919F]) = v56;\nL_0023:\n\tv58 = ~options.isRigidbody;\n\tif (v58) goto L_008E;\n\tgoto L_FFFFFFFF;\n\tv170 = v170_asT == 0;\n\tif (v170) goto L_0090;\n\tgoto L_FFFFFFFF;\n\tv173 = v173_asT == 0;\n\tif (v173) goto L_0090;\n\tUnityEngine.Rigidbody::set_rotation(t.target, newRot);\n\treturn;\nL_008E:\n\tUnityEngine.Transform::set_rotation(trans, newRot);\n\treturn;\nL_0090:\n\tthrow System.InvalidCastException;\n\tv107 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans)
			{
				if (options.isRigidbody)
				{
					Rigidbody rigidbody = t.target as Rigidbody;
					if ((object)rigidbody != null)
					{
						Rigidbody rigidbody2 = t.target as Rigidbody;
						if ((object)rigidbody2 != null)
						{
							((Rigidbody)t.target).rotation = newRot;
							return;
						}
					}
					throw new InvalidCastException();
				}
				trans.rotation = newRot;
			}

			[Token(Token = "0x6000122")]
			[Address(RVA = "0x157EF44", Offset = "0x157EF44", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEC110]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20291A0]) = v38;\nL_0019:\n\tv44 = UnityEngine.Component::GetComponent(target);\n\tgoto L_0030;\n\tv54 = *([v50 @ X8_v7+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0030;\n\tv80 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v80, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0030:\n\treturnVal2 = UnityEngine.Object::op_Inequality(v44, 0);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static bool HasRigidbody2D(Component target)
			{
				Rigidbody2D component = target.GetComponent<Rigidbody2D>();
				return component != null;
			}

			[Preserve]
			[Token(Token = "0x6000123")]
			[Address(RVA = "0x157EFD8", Offset = "0x157EFD8", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0FD50]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20291A1]) = v38;\nL_0019:\n\tv44 = UnityEngine.Component::GetComponent(target);\n\tgoto L_0030;\n\tv54 = *([v50 @ X8_v7+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0030;\n\tv80 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v80, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0030:\n\treturnVal2 = UnityEngine.Object::op_Inequality(v44, 0);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static bool HasRigidbody(Component target)
			{
				Rigidbody component = target.GetComponent<Rigidbody>();
				return component != null;
			}

			[Preserve]
			[Token(Token = "0x6000124")]
			[Address(RVA = "0x157F06C", Offset = "0x157F06C", Length = "0x115C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1ED43C0]);\n\tv39 = *([v38 @ X8_v11]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, tweenRigidbody, isLocal, path, pathMode, methodInfo, v42, v43, duration, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20291A2]) = v53;\nL_001E:\n\tv55 = tweenRigidbody == 0;\n\tif (v55) goto L_004F;\n\tv56 = target == 0;\n\tif (v56) goto L_0084;\n\tv62 = UnityEngine.Component::GetComponent(target);\n\tgoto L_0038;\n\tv96 = *([v80 @ X8_v8+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0038;\n\tv126 = v80;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v126, v61, isLocal, path, pathMode, methodInfo, v42, v43, duration, v44, v45, v46, v47, v48, v49, v50);\nL_0038:\n\tv74 = UnityEngine.Object::op_Inequality(v62, 0);\n\tv76 = v74 == 0;\n\tif (v76) goto L_0053;\n\tv149 = isLocal == 0;\n\tif (v149) goto L_0081;\n\treturnVal4 = DG.Tweening.DOTweenModulePhysics::DOLocalPath(v62, path, duration, pathMode);\n\treturn returnVal4;\nL_004F:\n\tv57 = target == 0;\n\tif (v57) goto L_0084;\nL_0053:\n\tv83 = UnityEngine.Component::get_transform(target);\n\tv95 = isLocal == 0;\n\tif (v95) goto L_0071;\n\treturnVal2 = DG.Tweening.ShortcutExtensions::DOLocalPath(v83, path, duration, pathMode);\n\treturn returnVal2;\nL_0071:\n\treturnVal3 = DG.Tweening.ShortcutExtensions::DOPath(v83, path, duration, pathMode);\n\treturn returnVal3;\nL_0081:\n\treturnVal5 = DG.Tweening.DOTweenModulePhysics::DOPath(v62, path, duration, pathMode);\n\treturn returnVal5;\nL_0084:\n\treturnVal1 = new System.NullReferenceException();\n\tv89 = UnityEngine.SpriteRenderer::get_color(returnVal1);\n\treturn returnVal1;\n\tX9 = *([X9+C98]);\n\tX0 = 0x1579008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\treturn X0;\n// 1120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static TweenerCore<Vector3, Path, PathOptions> CreateDOTweenPathTween(MonoBehaviour target, bool tweenRigidbody, bool isLocal, Path path, float duration, PathMode pathMode)
			{
				if (tweenRigidbody)
				{
					if ((object)target != null)
					{
						Rigidbody component = target.GetComponent<Rigidbody>();
						if (component != null)
						{
							if (isLocal)
							{
								return component.DOLocalPath(path, duration, pathMode);
							}
							return component.DOPath(path, duration, pathMode);
						}
						goto IL_00b7;
					}
				}
				else if ((object)target != null)
				{
					goto IL_00b7;
				}
				NullReferenceException ex = new NullReferenceException();
				Color color = ((SpriteRenderer)(object)ex).color;
				return (TweenerCore<Vector3, Path, PathOptions>)(object)ex;
				IL_00b7:
				Transform transform = target.transform;
				if (isLocal)
				{
					return transform.DOLocalPath(path, duration, pathMode);
				}
				return transform.DOPath(path, duration, pathMode);
			}
		}

		[Token(Token = "0x4000001")]
		private static bool _initialized;

		[Preserve]
		[Token(Token = "0x6000056")]
		[Address(RVA = "0x157ECC8", Offset = "0x157ECC8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EEC858]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202919D]) = v35;\nL_0016:\n\tv41 = ~v39._initialized;\n\tif (v41) goto L_001E;\n\treturn;\nL_001E:\n\tv39._initialized = 1;\n\tv49 = new System.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>();\n\tSystem.Action`4<DG.Tweening.Plugins.Options.PathOptions, DG.Tweening.Tween, UnityEngine.Quaternion, UnityEngine.Transform>::.ctor(v49, 0, Il2CppMethodInfo);\n\tDG.Tweening.Core.DOTweenExternalCommand::add_SetOrientationOnPath(v49);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init()
		{
			if (!_initialized)
			{
				_initialized = true;
				Action<PathOptions, Tween, Quaternion, Transform> value = Physics.SetOrientationOnPath;
				DOTweenExternalCommand.SetOrientationOnPath += value;
			}
		}

		[Preserve]
		[Token(Token = "0x6000057")]
		[Address(RVA = "0x157ED6C", Offset = "0x157ED6C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EED2F8]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202919E]) = v35;\nL_0012:\n\tv37 = System.AppDomain::get_CurrentDomain();\n\tv40 = System.AppDomain::GetAssemblies(v37);\n\tgoto L_0028;\n\tv62 = *([v57 @ X0_v7+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0028;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v57, v39, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\tv47 = System.Type::GetTypeFromHandle(UnityEngine.MonoBehaviour);\n\tv77 = System.Type::GetMethod(v47, \"Stub\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Preserver()
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			Type typeFromHandle = typeof(MonoBehaviour);
			MethodInfo method = typeFromHandle.GetMethod("Stub");
		}
	}
}
