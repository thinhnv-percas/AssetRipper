using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000017")]
	public static class TweenSettingsExtensions
	{
		[Token(Token = "0x6000119")]
		[Address(RVA = "0xB872C0", Offset = "0xB872C0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+F8]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9C]) = 1;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAutoKill<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						_ = 1;
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0xB872E4", Offset = "0xB872E4", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+F8]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9C]) = autoKillOnCompletion;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAutoKill<T>(this T t, bool autoKillOnCompletion) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0xB875A8", Offset = "0xB875A8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+30]) = objectId;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetId<T>(this T t, object objectId) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0xB875BC", Offset = "0xB875BC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+38]) = stringId;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetId<T>(this T t, string stringId) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0xB87594", Offset = "0xB87594", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+40]) = intId;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetId<T>(this T t, int intId) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0xB875D0", Offset = "0xB875D0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFC518]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, gameObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229F4]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_0052;\n\tv44 = *([t @ X0 (T)+E0]) == 0;\n\tif (v44) goto L_0052;\n\tv72 = *([t @ X0 (T)+E1]) == 0;\n\tv58 = ~v72;\n\tif (v58) goto L_0052;\n\tgoto L_002D;\n\tv79 = *([v75 @ X0_v4+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_002D;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v75, gameObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tv55 = UnityEngine.Object::op_Equality(gameObject, 0);\n\tv87 = v55 == 0;\n\tv59 = ~v87;\n\tif (v59) goto L_0052;\n\tv91 = new DG.Tweening.Core.TweenLink();\n\tDG.Tweening.Core.TweenLink::.ctor(v91, gameObject, 6);\n\tgoto L_004A;\n\tv100 = *([v96 @ X0_v10+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_004A;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v96, v93, v92, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004A:\n\tDG.Tweening.Core.TweenManager::AddTweenLink(t, v91);\nL_0052:\n\treturn t;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLink<T>(this T t, GameObject gameObject) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E1]");
					if ((IntPtr)0 == (IntPtr)0 && !(gameObject == null))
					{
						TweenLink tweenLink = new TweenLink(gameObject, LinkBehaviour.KillOnDestroy);
						TweenManager.AddTweenLink(t, tweenLink);
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0xB876BC", Offset = "0xB876BC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F0BDB8]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, gameObject, behaviour, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20229F5]) = v44;\nL_0017:\n\tv45 = t == 0;\n\tif (v45) goto L_0055;\n\tv47 = *([t @ X0 (T)+E0]) == 0;\n\tif (v47) goto L_0055;\n\tv76 = *([t @ X0 (T)+E1]) == 0;\n\tv61 = ~v76;\n\tif (v61) goto L_0055;\n\tgoto L_002F;\n\tv83 = *([v79 @ X0_v4+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002F;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v79, gameObject, behaviour, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002F:\n\tv58 = UnityEngine.Object::op_Equality(gameObject, 0);\n\tv91 = v58 == 0;\n\tv62 = ~v91;\n\tif (v62) goto L_0055;\n\tv95 = new DG.Tweening.Core.TweenLink();\n\tDG.Tweening.Core.TweenLink::.ctor(v95, gameObject, behaviour);\n\tgoto L_004C;\n\tv104 = *([v100 @ X0_v10+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_004C;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v100, v96, v97, v49, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004C:\n\tDG.Tweening.Core.TweenManager::AddTweenLink(t, v95);\nL_0055:\n\treturn t;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLink<T>(this T t, GameObject gameObject, LinkBehaviour behaviour) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E1]");
					if ((IntPtr)0 == (IntPtr)0 && !(gameObject == null))
					{
						TweenLink tweenLink = new TweenLink(gameObject, behaviour);
						TweenManager.AddTweenLink(t, tweenLink);
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0xB87934", Offset = "0xB87934", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+48]) = target;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetTarget<T>(this T t, object target) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000121")]
		[Address(RVA = "0xB877AC", Offset = "0xB877AC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0029;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0029;\n\tv44 = *([t @ X0 (T)+F8]) == 0;\n\tv43 = ~v44;\n\tif (v43) goto L_0029;\n\tv70 = loops == 0;\n\tv72 = ~v70;\n\tv73 = ~v72;\n\tif (v73) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tv77 = loops + 1;\n\tv26 = v77 < 0;\n\tv8 = v26 == 0;\n\tv5 = ~v8;\n\tif (v5) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\t*([t @ X0 (T)+A4]) = v38;\n\tv42 = *([t @ X0 (T)+10]) == 0;\n\tif (v42) goto L_002A;\nL_0029:\n\treturn t;\nL_002A:\n\tv80 = v38 & 0x80000000;\n\tv81 = v80 == 0;\n\tv65 = ~v81;\n\tif (v65) goto L_0034;\n\tv50 = *([t @ X0 (T)+A0]) * v38;\n\t*([t @ X0 (T)+100]) = v50;\n\treturn t;\nL_0034:\n\t*([t @ X0 (T)+100]) = 0x7F800000;\n\treturn t;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLoops<T>(this T t, int loops) where T : Tween
		{
			//IL_00ea: Expected I4, but got I8
			//IL_0127: Expected O, but got I
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						int num = ((loops == 0) ? 1 : loops);
						int num2 = loops + 1;
						if (num2 < 0)
						{
							num = -1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							if ((int)(num & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								object obj = 0L * (long)num;
								return t;
							}
							_ = 2139095040;
							return t;
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0xB87804", Offset = "0xB87804", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_002A;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_002A;\n\tv44 = *([t @ X0 (T)+F8]) == 0;\n\tv43 = ~v44;\n\tif (v43) goto L_002A;\n\tv70 = loops == 0;\n\tv72 = ~v70;\n\tv73 = ~v72;\n\tif (v73) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tv77 = loops + 1;\n\tv26 = v77 < 0;\n\tv8 = v26 == 0;\n\tv5 = ~v8;\n\tif (v5) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\t*([t @ X0 (T)+A4]) = v38;\n\t*([t @ X0 (T)+A8]) = loopType;\n\tv42 = *([t @ X0 (T)+10]) == 0;\n\tif (v42) goto L_002B;\nL_002A:\n\treturn t;\nL_002B:\n\tv81 = v38 & 0x80000000;\n\tv82 = v81 == 0;\n\tv65 = ~v82;\n\tif (v65) goto L_0035;\n\tv50 = *([t @ X0 (T)+A0]) * v38;\n\t*([t @ X0 (T)+100]) = v50;\n\treturn t;\nL_0035:\n\t*([t @ X0 (T)+100]) = 0x7F800000;\n\treturn t;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLoops<T>(this T t, int loops, LoopType loopType) where T : Tween
		{
			//IL_00ea: Expected I4, but got I8
			//IL_0127: Expected O, but got I
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						int num = ((loops == 0) ? 1 : loops);
						int num2 = loops + 1;
						if (num2 < 0)
						{
							num = -1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							if ((int)(num & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								object obj = 0L * (long)num;
								return t;
							}
							_ = 2139095040;
							return t;
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xB873AC", Offset = "0xB873AC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = t == 0;\n\tif (v10) goto L_001C;\n\tv12 = *([t @ X0 (T)+E0]) == 0;\n\tif (v12) goto L_001C;\n\t*([t @ X0 (T)+B4]) = ease;\n\tv20 = DG.Tweening.Core.Easing.EaseManager::IsFlashEase(ease);\n\tv25 = v20 == 0;\n\tif (v25) goto L_0016;\n\t*([t @ X0 (T)+C0]) = *([t @ X0 (T)+C0]);\nL_0016:\n\t*([t @ X0 (T)+B8]) = 0;\nL_001C:\n\treturn t;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, Ease ease) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					if (EaseManager.IsFlashEase(ease))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+C0]");
						_ = 0;
					}
					_ = 0;
				}
			}
			return t;
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0xB87400", Offset = "0xB87400", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = t == 0;\n\tif (v14) goto L_0027;\n\tv16 = *([t @ X0 (T)+E0]) == 0;\n\tif (v16) goto L_0027;\n\t*([t @ X0 (T)+B4]) = ease;\n\tv41 = DG.Tweening.Core.Easing.EaseManager::IsFlashEase(ease);\n\tv32 = v41 == 0;\n\tv21 = ~v32;\n\tv18 = ~v21;\n\tif (v18) goto L_001F;\n\tgoto L_001F;\nL_001F:\n\t*([t @ X0 (T)+C0]) = v24;\n\t*([t @ X0 (T)+B8]) = 0;\nL_0027:\n\treturn t;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, Ease ease, float overshoot) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					if (EaseManager.IsFlashEase(ease))
					{
					}
					_ = 0;
				}
			}
			return t;
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0xB87460", Offset = "0xB87460", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = t == 0;\n\tif (v18) goto L_002B;\n\tv20 = *([t @ X0 (T)+E0]) == 0;\n\tif (v20) goto L_002B;\n\t*([t @ X0 (T)+B4]) = ease;\n\tv45 = DG.Tweening.Core.Easing.EaseManager::IsFlashEase(ease);\n\tv36 = v45 == 0;\n\tv25 = ~v36;\n\tv22 = ~v25;\n\tif (v22) goto L_0021;\n\tgoto L_0021;\nL_0021:\n\t*([t @ X0 (T)+C0]) = v28;\n\t*([t @ X0 (T)+C4]) = period;\n\t*([t @ X0 (T)+B8]) = 0;\nL_002B:\n\treturn t;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, Ease ease, float amplitude, float period) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					if (EaseManager.IsFlashEase(ease))
					{
					}
					_ = 0;
				}
			}
			return t;
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0xB874E0", Offset = "0xB874E0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED2A70]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, animCurve, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229F3]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_0037;\n\tv44 = *([t @ X0 (T)+E0]) == 0;\n\tif (v44) goto L_0037;\n\t*([t @ X0 (T)+B4]) = 0x25;\n\tv70 = new DG.Tweening.Core.Easing.EaseCurve();\n\tDG.Tweening.Core.Easing.EaseCurve::.ctor(v70, animCurve);\n\tv52 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v52, v70, Il2CppMethodInfo);\n\t*([t @ X0 (T)+B8]) = v52;\nL_0037:\n\treturn t;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, AnimationCurve animCurve) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = 37;
					EaseCurve easeCurve = new EaseCurve(animCurve);
					EaseFunction easeFunction = easeCurve.Evaluate;
				}
			}
			return t;
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0xB874C4", Offset = "0xB874C4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0008;\n\t*([t @ X0 (T)+B4]) = 0x25;\n\t*([t @ X0 (T)+B8]) = customEase;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, EaseFunction customEase) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = 37;
				}
			}
			return t;
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0xB8785C", Offset = "0xB8785C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (T)+9A]) = 1;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRecyclable<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = 1;
				}
			}
			return t;
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0xB87874", Offset = "0xB87874", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (T)+9A]) = recyclable;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRecyclable<T>(this T t, bool recyclable) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0xB87AA0", Offset = "0xB87AA0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB9620]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, isIndependentUpdate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229F8]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_0042;\n\tv44 = *([t @ X0 (T)+E0]) == 0;\n\tif (v44) goto L_0042;\n\tgoto L_002F;\n\tv77 = *([v73 @ X0_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002F;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v73, isIndependentUpdate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv81 = DG.Tweening.DOTween;\nL_002F:\n\tgoto L_003A;\n\tv90 = *([v62 @ X8_v9+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tgoto L_003A;\n\tv95 = v62;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v95, isIndependentUpdate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003A:\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, v86.defaultUpdateType, isIndependentUpdate);\nL_0042:\n\treturn t;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetUpdate<T>(this T t, bool isIndependentUpdate) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					TweenManager.SetUpdateType(t, DOTween.defaultUpdateType, isIndependentUpdate);
				}
			}
			return t;
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0xB87948", Offset = "0xB87948", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB25E8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, updateType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229F6]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_004C;\n\tv44 = *([t @ X0 (T)+E0]) == 0;\n\tif (v44) goto L_004C;\n\tgoto L_002F;\n\tv104 = *([v100 @ X0_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_002F;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v100, updateType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv108 = DG.Tweening.DOTween;\nL_002F:\n\tgoto L_003A;\n\tv117 = *([v89 @ X8_v9+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tgoto L_003A;\n\tv123 = v89;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v123, updateType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003A:\n\tv70 = v113.defaultTimeScaleIndependent == 0;\n\tv55 = ~v70;\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, updateType, v55);\nL_004C:\n\treturn t;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetUpdate<T>(this T t, UpdateType updateType) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					bool flag = !DOTween.defaultTimeScaleIndependent;
					bool isIndependentUpdate = !flag;
					TweenManager.SetUpdateType(t, updateType, isIndependentUpdate);
				}
			}
			return t;
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0xB87A0C", Offset = "0xB87A0C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EE6B20]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20229F7]) = v44;\nL_0017:\n\tv45 = t == 0;\n\tif (v45) goto L_0035;\n\tv47 = *([t @ X0 (T)+E0]) == 0;\n\tif (v47) goto L_0035;\n\tgoto L_002C;\n\tv73 = *([v69 @ X0_v4+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_002C;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v69, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, updateType, isIndependentUpdate);\nL_0035:\n\treturn t;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetUpdate<T>(this T t, UpdateType updateType, bool isIndependentUpdate) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					TweenManager.SetUpdateType(t, updateType, isIndependentUpdate);
				}
			}
			return t;
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0xB86F18", Offset = "0xB86F18", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+20]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnStart<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xB86EF0", Offset = "0xB86EF0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+58]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnPlay<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0xB86EDC", Offset = "0xB86EDC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+60]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnPause<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0xB86F04", Offset = "0xB86F04", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+68]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnRewind<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0xB86F40", Offset = "0xB86F40", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+70]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnUpdate<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0xB86F2C", Offset = "0xB86F2C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+78]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnStepComplete<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0xB86EB4", Offset = "0xB86EB4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+80]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnComplete<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0xB86EC8", Offset = "0xB86EC8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+88]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnKill<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0xB86F54", Offset = "0xB86F54", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+90]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnWaypointChange<T>(this T t, TweenCallback<int> action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0xB86F68", Offset = "0xB86F68", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EC31B0]);\n\tv25 = *([v24 @ X8_v37]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, asTween, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20229F0]) = v43;\nL_0016:\n\tv44 = t == 0;\n\tif (v44) goto L_008E;\n\tv46 = *([t @ X0 (T)+E0]) == 0;\n\tif (v46) goto L_008E;\n\tv109 = *([t @ X0 (T)+F8]) == 0;\n\tv96 = ~v109;\n\tif (v96) goto L_008E;\n\t*([t @ X0 (T)+28]) = asTween.timeScale;\n\t*([t @ X0 (T)+2C]) = asTween.isBackwards;\n\tgoto L_0037;\n\tv146 = *([v141 @ X0_v6+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0037;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v141, asTween, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0037:\n\tv157 = asTween.isIndependentUpdate == 0;\n\tv162 = ~v157;\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, asTween.updateType, v162);\n\t*([t @ X0 (T)+30]) = asTween.id;\n\t*([t @ X0 (T)+20]) = asTween.onStart;\n\t*([t @ X0 (T)+58]) = asTween.onPlay;\n\t*([t @ X0 (T)+68]) = asTween.onRewind;\n\t*([t @ X0 (T)+70]) = asTween.onUpdate;\n\t*([t @ X0 (T)+78]) = asTween.onStepComplete;\n\t*([t @ X0 (T)+80]) = asTween.onComplete;\n\t*([t @ X0 (T)+88]) = asTween.onKill;\n\t*([t @ X0 (T)+90]) = asTween.onWaypointChange;\n\t*([t @ X0 (T)+9A]) = asTween.isRecyclable;\n\t*([t @ X0 (T)+9B]) = asTween.isSpeedBased;\n\t*([t @ X0 (T)+9C]) = asTween.autoKill;\n\t*([t @ X0 (T)+A4]) = asTween.loops;\n\t*([t @ X0 (T)+A8]) = asTween.loopType;\n\tv176 = *([t @ X0 (T)+10]) == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_006E;\n\tv178 = asTween.loops & 0x80000000;\n\tv179 = v178 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_FFFFFFFF;\n\tv183 = *([t @ X0 (T)+A0]) * asTween.loops;\n\tgoto L_006C;\nL_006C:\n\t*([t @ X0 (T)+100]) = v183;\nL_006E:\n\tv186 = asTween.delay < 0;\n\tv88 = ~v186;\n\tv79 = asTween.delay == 0;\n\tv187 = ~v88;\n\tv64 = v187 | v79;\n\t*([t @ X0 (T)+AC]) = asTween.delay;\n\t*([t @ X0 (T)+110]) = v64;\n\t*([t @ X0 (T)+B0]) = asTween.<isRelative>k__BackingField;\n\t*([t @ X0 (T)+B4]) = asTween.easeType;\n\t*([t @ X0 (T)+B8]) = asTween.customEase;\n\t*([t @ X0 (T)+C0]) = asTween.easeOvershootOrAmplitude;\n\t*([t @ X0 (T)+C4]) = asTween.easePeriod;\nL_008E:\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAs<T>(this T t, Tween asTween) where T : Tween
		{
			//IL_017b: Expected I4, but got I8
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						_ = asTween.timeScale;
						_ = asTween.isBackwards;
						bool flag = !asTween.isIndependentUpdate;
						bool isIndependentUpdate = !flag;
						TweenManager.SetUpdateType(t, asTween.updateType, isIndependentUpdate);
						_ = asTween.id;
						_ = asTween.onStart;
						_ = asTween.onPlay;
						_ = asTween.onRewind;
						_ = asTween.onUpdate;
						_ = asTween.onStepComplete;
						_ = asTween.onComplete;
						_ = asTween.onKill;
						_ = asTween.onWaypointChange;
						_ = asTween.isRecyclable;
						_ = asTween.isSpeedBased;
						_ = asTween.autoKill;
						_ = asTween.loops;
						_ = asTween.loopType;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							if ((int)(asTween.loops & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								float num = 0f * (float)asTween.loops;
							}
							else
							{
								float num = float.PositiveInfinity;
							}
						}
						bool flag2 = asTween.delay < 0f;
						bool flag3 = !flag2;
						bool flag4 = asTween.delay == 0f;
						bool flag5 = !flag3;
						bool flag6 = flag5 || flag4;
						_ = asTween.delay;
						_ = asTween.isRelative;
						_ = asTween.easeType;
						_ = asTween.customEase;
						_ = asTween.easeOvershootOrAmplitude;
						_ = asTween.easePeriod;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0xB870FC", Offset = "0xB870FC", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EC65B8]);\n\tv25 = *([v24 @ X8_v34]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, tweenParams, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20229F1]) = v43;\nL_0016:\n\tv44 = t == 0;\n\tif (v44) goto L_00A9;\n\tv46 = *([t @ X0 (T)+E0]) == 0;\n\tif (v46) goto L_00A9;\n\tv109 = *([t @ X0 (T)+F8]) == 0;\n\tv96 = ~v109;\n\tif (v96) goto L_00A9;\n\tgoto L_0033;\n\tv145 = *([v140 @ X0_v6+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0033;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v140, tweenParams, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0033:\n\tv156 = tweenParams.isIndependentUpdate == 0;\n\tv161 = ~v156;\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, tweenParams.updateType, v161);\n\t*([t @ X0 (T)+30]) = tweenParams.id;\n\t*([t @ X0 (T)+20]) = tweenParams.onStart;\n\t*([t @ X0 (T)+58]) = tweenParams.onPlay;\n\t*([t @ X0 (T)+68]) = tweenParams.onRewind;\n\t*([t @ X0 (T)+70]) = tweenParams.onUpdate;\n\t*([t @ X0 (T)+78]) = tweenParams.onStepComplete;\n\t*([t @ X0 (T)+80]) = tweenParams.onComplete;\n\t*([t @ X0 (T)+88]) = tweenParams.onKill;\n\t*([t @ X0 (T)+90]) = tweenParams.onWaypointChange;\n\t*([t @ X0 (T)+9A]) = tweenParams.isRecyclable;\n\t*([t @ X0 (T)+9B]) = tweenParams.isSpeedBased;\n\t*([t @ X0 (T)+9C]) = tweenParams.autoKill;\n\t*([t @ X0 (T)+A4]) = tweenParams.loops;\n\t*([t @ X0 (T)+A8]) = tweenParams.loopType;\n\tv177 = *([t @ X0 (T)+10]) == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_006A;\n\tv179 = tweenParams.loops & 0x80000000;\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_FFFFFFFF;\n\tv184 = *([t @ X0 (T)+A0]) * tweenParams.loops;\n\tgoto L_0068;\nL_0068:\n\t*([t @ X0 (T)+100]) = v184;\nL_006A:\n\tv188 = tweenParams.delay < 0;\n\tv189 = ~v188;\n\tv192 = tweenParams.delay == 0;\n\tv197 = ~v189;\n\tv198 = v197 | v192;\n\t*([t @ X0 (T)+AC]) = tweenParams.delay;\n\t*([t @ X0 (T)+110]) = v198;\n\t*([t @ X0 (T)+B0]) = tweenParams.isRelative;\n\tv201 = tweenParams.easeType;\n\tv202 = tweenParams.easeType == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_009A;\n\tv218 = *([t @ X0 (T)+10]) != 1;\n\tif (v218) goto L_0091;\n\tgoto L_009A;\nL_0091:\n\tgoto L_0099;\n\tv233 = *([v229 @ X0_v10 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_0099;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v229, v60, v62, v58, v29, v30, v31, v32, v50, v48, v35, v36, v37, v38, v39, v40);\n\tv236 = DG.Tweening.DOTween;\nL_0099:\n\tv201 = v224.defaultEaseType;\nL_009A:\n\t*([t @ X0 (T)+B4]) = v201;\n\t*([t @ X0 (T)+B8]) = tweenParams.customEase;\n\t*([t @ X0 (T)+C0]) = tweenParams.easeOvershootOrAmplitude;\n\t*([t @ X0 (T)+C4]) = tweenParams.easePeriod;\nL_00A9:\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAs<T>(this T t, TweenParams tweenParams) where T : Tween
		{
			//IL_0167: Expected I4, but got I8
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						bool flag = !tweenParams.isIndependentUpdate;
						bool isIndependentUpdate = !flag;
						TweenManager.SetUpdateType(t, tweenParams.updateType, isIndependentUpdate);
						_ = tweenParams.id;
						_ = tweenParams.onStart;
						_ = tweenParams.onPlay;
						_ = tweenParams.onRewind;
						_ = tweenParams.onUpdate;
						_ = tweenParams.onStepComplete;
						_ = tweenParams.onComplete;
						_ = tweenParams.onKill;
						_ = tweenParams.onWaypointChange;
						_ = tweenParams.isRecyclable;
						_ = tweenParams.isSpeedBased;
						_ = tweenParams.autoKill;
						_ = tweenParams.loops;
						_ = tweenParams.loopType;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							if ((int)(tweenParams.loops & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								float num = 0f * (float)tweenParams.loops;
							}
							else
							{
								float num = float.PositiveInfinity;
							}
						}
						bool flag2 = tweenParams.delay < 0f;
						bool flag3 = !flag2;
						bool flag4 = tweenParams.delay == 0f;
						bool flag5 = !flag3;
						bool flag6 = flag5 || flag4;
						_ = tweenParams.delay;
						_ = tweenParams.isRelative;
						Ease easeType = tweenParams.easeType;
						if (tweenParams.easeType == Ease.Unset)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
							if ((IntPtr)0 == (IntPtr)1)
							{
								easeType = Ease.Linear;
							}
							else
							{
								easeType = DOTween.defaultEaseType;
							}
						}
						_ = tweenParams.customEase;
						_ = tweenParams.easeOvershootOrAmplitude;
						_ = tweenParams.easePeriod;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x1605784", Offset = "0x1605784", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_0021;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_0021;\n\tv28 = t == 0;\n\tif (v28) goto L_0021;\n\tv36 = ~s.creationLocked;\n\tv29 = ~v36;\n\tif (v29) goto L_0021;\n\tv30 = ~t.<active>k__BackingField;\n\tif (v30) goto L_0021;\n\tv37 = ~t.isSequenced;\n\tv27 = ~v37;\n\tif (v27) goto L_0021;\n\tv17 = DG.Tweening.Sequence::DoInsert(s, t, s.duration);\nL_0021:\n\treturn s;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Append(this Sequence s, Tween t)
		{
			if (s != null && s.active && t != null && !s.creationLocked && t.active && !t.isSequenced)
			{
				Sequence sequence = Sequence.DoInsert(s, t, s.duration);
			}
			return s;
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x16057DC", Offset = "0x16057DC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_0020;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_0020;\n\tv25 = t == 0;\n\tif (v25) goto L_0020;\n\tv33 = ~s.creationLocked;\n\tv26 = ~v33;\n\tif (v26) goto L_0020;\n\tv27 = ~t.<active>k__BackingField;\n\tif (v27) goto L_0020;\n\tv34 = ~t.isSequenced;\n\tv24 = ~v34;\n\tif (v24) goto L_0020;\n\tv17 = DG.Tweening.Sequence::DoPrepend(s, t);\nL_0020:\n\treturn s;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Prepend(this Sequence s, Tween t)
		{
			if (s != null && s.active && t != null && !s.creationLocked && t.active && !t.isSequenced)
			{
				Sequence sequence = Sequence.DoPrepend(s, t);
			}
			return s;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x1605830", Offset = "0x1605830", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_0021;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_0021;\n\tv28 = t == 0;\n\tif (v28) goto L_0021;\n\tv36 = ~s.creationLocked;\n\tv29 = ~v36;\n\tif (v29) goto L_0021;\n\tv30 = ~t.<active>k__BackingField;\n\tif (v30) goto L_0021;\n\tv37 = ~t.isSequenced;\n\tv27 = ~v37;\n\tif (v27) goto L_0021;\n\tv17 = DG.Tweening.Sequence::DoInsert(s, t, s.lastTweenInsertTime);\nL_0021:\n\treturn s;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Join(this Sequence s, Tween t)
		{
			if (s != null && s.active && t != null && !s.creationLocked && t.active && !t.isSequenced)
			{
				Sequence sequence = Sequence.DoInsert(s, t, s.lastTweenInsertTime);
			}
			return s;
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0x1605888", Offset = "0x1605888", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_0020;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_0020;\n\tv25 = t == 0;\n\tif (v25) goto L_0020;\n\tv33 = ~s.creationLocked;\n\tv26 = ~v33;\n\tif (v26) goto L_0020;\n\tv27 = ~t.<active>k__BackingField;\n\tif (v27) goto L_0020;\n\tv34 = ~t.isSequenced;\n\tv24 = ~v34;\n\tif (v24) goto L_0020;\n\tv17 = DG.Tweening.Sequence::DoInsert(s, t, atPosition);\nL_0020:\n\treturn s;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Insert(this Sequence s, float atPosition, Tween t)
		{
			if (s != null && s.active && t != null && !s.creationLocked && t.active && !t.isSequenced)
			{
				Sequence sequence = Sequence.DoInsert(s, t, atPosition);
			}
			return s;
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0x16058DC", Offset = "0x16058DC", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_0017;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_0017;\n\tv27 = ~s.creationLocked;\n\tv22 = ~v27;\n\tif (v22) goto L_0017;\n\tv17 = DG.Tweening.Sequence::DoAppendInterval(s, interval);\nL_0017:\n\treturn s;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence AppendInterval(this Sequence s, float interval)
		{
			if (s != null && s.active && !s.creationLocked)
			{
				Sequence sequence = Sequence.DoAppendInterval(s, interval);
			}
			return s;
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0x160591C", Offset = "0x160591C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_0017;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_0017;\n\tv27 = ~s.creationLocked;\n\tv22 = ~v27;\n\tif (v22) goto L_0017;\n\tv17 = DG.Tweening.Sequence::DoPrependInterval(s, interval);\nL_0017:\n\treturn s;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence PrependInterval(this Sequence s, float interval)
		{
			if (s != null && s.active && !s.creationLocked)
			{
				Sequence sequence = Sequence.DoPrependInterval(s, interval);
			}
			return s;
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0x160595C", Offset = "0x160595C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_001A;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_001A;\n\tv26 = callback == 0;\n\tif (v26) goto L_001A;\n\tv32 = ~s.creationLocked;\n\tv25 = ~v32;\n\tif (v25) goto L_001A;\n\tv17 = DG.Tweening.Sequence::DoInsertCallback(s, callback, s.duration);\nL_001A:\n\treturn s;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence AppendCallback(this Sequence s, TweenCallback callback)
		{
			if (s != null && s.active && callback != null && !s.creationLocked)
			{
				Sequence sequence = Sequence.DoInsertCallback(s, callback, s.duration);
			}
			return s;
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x16059A4", Offset = "0x16059A4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_001A;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_001A;\n\tv26 = callback == 0;\n\tif (v26) goto L_001A;\n\tv32 = ~s.creationLocked;\n\tv25 = ~v32;\n\tif (v25) goto L_001A;\n\tv17 = DG.Tweening.Sequence::DoInsertCallback(s, callback, 0f);\nL_001A:\n\treturn s;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence PrependCallback(this Sequence s, TweenCallback callback)
		{
			if (s != null && s.active && callback != null && !s.creationLocked)
			{
				Sequence sequence = Sequence.DoInsertCallback(s, callback, 0f);
			}
			return s;
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x16059EC", Offset = "0x16059EC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = s == 0;\n\tif (v10) goto L_0019;\n\tv12 = ~s.<active>k__BackingField;\n\tif (v12) goto L_0019;\n\tv23 = callback == 0;\n\tif (v23) goto L_0019;\n\tv29 = ~s.creationLocked;\n\tv22 = ~v29;\n\tif (v22) goto L_0019;\n\tv17 = DG.Tweening.Sequence::DoInsertCallback(s, callback, atPosition);\nL_0019:\n\treturn s;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence InsertCallback(this Sequence s, float atPosition, TweenCallback callback)
		{
			if (s != null && s.active && callback != null && !s.creationLocked)
			{
				Sequence sequence = Sequence.DoInsertCallback(s, callback, atPosition);
			}
			return s;
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0xB86DD0", Offset = "0xB86DD0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = t == 0;\n\tif (v10) goto L_001F;\n\tv12 = *([t @ X0 (T)+E0]) == 0;\n\tif (v12) goto L_001F;\n\tv36 = *([t @ X0 (T)+F8]) == 0;\n\tv31 = ~v36;\n\tif (v31) goto L_001F;\n\tv30 = *([t @ X0 (T)+119]) == 0;\n\tif (v30) goto L_001F;\n\tv25 = t->klass;\n\t*([t @ X0 (T)+98]) = 1;\n\t*([v25 @ X8_v5 (Il2CppClass<T>)+200])(v20, t, 0, *([v25 @ X8_v5 (Il2CppClass<T>)+208]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_001F:\n\treturn t;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T From<T>(this T t) where T : Tweener
		{
			//IL_009f: Expected I, but got O
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+119]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							IntPtr intPtr = (IntPtr)t;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v25 @ X8_v5 (Il2CppClass<T>)+200] (should have been resolved before IL gen)");
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0xB86E2C", Offset = "0xB86E2C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = t == 0;\n\tif (v10) goto L_0013;\n\tv12 = *([t @ X0 (T)+E0]) == 0;\n\tif (v12) goto L_0013;\n\tv62 = *([t @ X0 (T)+F8]) == 0;\n\tif (v62) goto L_0015;\nL_0013:\n\treturn t;\nL_0015:\n\tv63 = *([t @ X0 (T)+119]) == 0;\n\tif (v63) goto L_0013;\n\t*([t @ X0 (T)+98]) = 1;\n\tv64 = isRelative == 0;\n\tif (v64) goto L_002D;\n\tv59 = t->klass;\n\tv31 = *([t @ X0 (T)+99]) == 0;\n\t*([v59 @ X8_v7 (Il2CppClass<T>)+200])(v53, t, v31, *([v59 @ X8_v7 (Il2CppClass<T>)+208]), v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tgoto L_0013;\nL_002D:\n\tv60 = t->klass;\n\t*([v60 @ X8_v6 (Il2CppClass<T>)+200])(v54, t, 0, *([v60 @ X8_v6 (Il2CppClass<T>)+208]), v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tgoto L_0013;\n\treturn X0;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T From<T>(this T t, bool isRelative) where T : Tweener
		{
			//IL_00ea: Expected I, but got O
			//IL_00bc: Expected I, but got O
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+119]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							_ = 1;
							if (isRelative)
							{
								IntPtr intPtr = (IntPtr)t;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+99]");
								bool flag = (IntPtr)0 == (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ X8_v7 (Il2CppClass<T>)+200] (should have been resolved before IL gen)");
							}
							else
							{
								IntPtr intPtr2 = (IntPtr)t;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v60 @ X8_v6 (Il2CppClass<T>)+200] (should have been resolved before IL gen)");
							}
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000143")]
		public static TweenerCore<T1, T2, TPlugOptions> From<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> t, T2 fromValue, bool setImmediately = true) where TPlugOptions : struct, IPlugOptions
		{
			return null;
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0x1605A30", Offset = "0x1605A30", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC0E30]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, setImmediately, methodInfo, v30, v31, v32, v33, v34, fromAlphaValue, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1D4]) = v44;\nL_0017:\n\tv45 = t == 0;\n\tif (v45) goto L_0041;\n\tv47 = ~t.<active>k__BackingField;\n\tif (v47) goto L_0041;\n\tv85 = ~t.creationLocked;\n\tv73 = ~v85;\n\tif (v73) goto L_0041;\n\tv72 = ~t.isFromAllowed;\n\tif (v72) goto L_0041;\n\tt.isFrom = 1;\n\tv57 = 0;\n\tv93 = 0x101059C(&v57 @ stack_-40_v2, 0, methodInfo, v30, v31, v32, v33, v34, 0, 0, 0, fromAlphaValue, v38, v39, v40, v41);\n\t// 55 MakeStruct v49 @ AGG1605AD8_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v95 @ stack_-3C, 0, v96 @ stack_-34\n\tv70 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>::SetFrom(t, v49, setImmediately);\nL_0041:\n\treturn t;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> From(this TweenerCore<Color, Color, ColorOptions> t, float fromAlphaValue, bool setImmediately = true)
		{
			//IL_0081: Expected O, but got I4
			//IL_00a6: Expected F4, but got O
			//IL_00c1: Expected F4, but got O
			if (t != null && t._003Cactive_003Ek__BackingField && !t.creationLocked && t.isFromAllowed)
			{
				t.isFrom = true;
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
				Color fromValue = default(Color);
				fromValue.r = 0f;
				object obj2 = default(object);
				fromValue.g = (float)obj2;
				fromValue.b = 0f;
				object obj3 = default(object);
				fromValue.a = (float)obj3;
				Tweener tweener = t.SetFrom(fromValue, setImmediately);
			}
			return t;
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0x1605AF8", Offset = "0x1605AF8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC52D0]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, setImmediately, methodInfo, v30, v31, v32, v33, v34, fromValue, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1D5]) = v44;\nL_0017:\n\tv45 = t == 0;\n\tif (v45) goto L_003F;\n\tv47 = ~t.<active>k__BackingField;\n\tif (v47) goto L_003F;\n\tv83 = ~t.creationLocked;\n\tv71 = ~v83;\n\tif (v71) goto L_003F;\n\tv70 = ~t.isFromAllowed;\n\tif (v70) goto L_003F;\n\tt.isFrom = 1;\n\tv54 = 0;\n\tv90 = 0x1586898(&v54 @ stack_-40_v2, 0, methodInfo, v30, v31, v32, v33, v34, fromValue, fromValue, fromValue, v37, v38, v39, v40, v41);\n\t// 53 MakeStruct v49 @ AGG1605BA0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v92 @ stack_-3C, 0\n\tv68 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>::SetFrom(t, v49, setImmediately);\nL_003F:\n\treturn t;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> From(this TweenerCore<Vector3, Vector3, VectorOptions> t, float fromValue, bool setImmediately = true)
		{
			//IL_0081: Expected O, but got I4
			//IL_00a6: Expected F4, but got O
			if (t != null && t._003Cactive_003Ek__BackingField && !t.creationLocked && t.isFromAllowed)
			{
				t.isFrom = true;
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 fromValue2 = default(Vector3);
				fromValue2.x = 0f;
				object obj2 = default(object);
				fromValue2.y = (float)obj2;
				fromValue2.z = 0f;
				Tweener tweener = t.SetFrom(fromValue2, setImmediately);
			}
			return t;
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xB87308", Offset = "0xB87308", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC7188]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, delay, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229F2]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_0048;\n\tv44 = *([t @ X0 (T)+E0]) == 0;\n\tif (v44) goto L_0048;\n\tv99 = *([t @ X0 (T)+F8]) == 0;\n\tv88 = ~v99;\n\tif (v88) goto L_0048;\n\tv52 = *([t @ X0 (T)+10]) != 1;\n\tif (v52) goto L_0033;\n\t// 46 IsInst v105 @ X0_v5 (DG.Tweening.Sequence), typeof(DG.Tweening.Sequence), t @ X0 (T)\n\tv86 = DG.Tweening.TweenSettingsExtensions::PrependInterval(v105, delay);\n\tgoto L_0048;\nL_0033:\n\tv106 = delay < 0;\n\tv82 = ~v106;\n\tv70 = delay == 0;\n\tv107 = ~v82;\n\tv50 = v107 | v70;\n\t*([t @ X0 (T)+AC]) = delay;\n\t*([t @ X0 (T)+110]) = v50;\nL_0048:\n\treturn t;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetDelay<T>(this T t, float delay) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((IntPtr)0 == (IntPtr)1)
						{
							Sequence s = t as Sequence;
							Sequence sequence = s.PrependInterval(delay);
						}
						else
						{
							bool flag = delay < 0f;
							bool flag2 = !flag;
							bool flag3 = delay == 0f;
							bool flag4 = !flag2;
							bool flag5 = flag4 || flag3;
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0xB8788C", Offset = "0xB8788C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0013;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0013;\n\tv14 = *([t @ X0 (T)+F8]) == 0;\n\tv12 = ~v14;\n\tif (v12) goto L_0013;\n\tv15 = *([t @ X0 (T)+98]) == 0;\n\tv13 = ~v15;\n\tif (v13) goto L_0013;\n\tv16 = *([t @ X0 (T)+99]) == 0;\n\tv11 = ~v16;\n\tif (v11) goto L_0013;\n\t*([t @ X0 (T)+B0]) = 1;\nL_0013:\n\treturn t;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRelative<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+98]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+99]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								_ = 1;
							}
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0xB878BC", Offset = "0xB878BC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0013;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0013;\n\tv14 = *([t @ X0 (T)+F8]) == 0;\n\tv12 = ~v14;\n\tif (v12) goto L_0013;\n\tv15 = *([t @ X0 (T)+98]) == 0;\n\tv13 = ~v15;\n\tif (v13) goto L_0013;\n\tv16 = *([t @ X0 (T)+99]) == 0;\n\tv11 = ~v16;\n\tif (v11) goto L_0013;\n\t*([t @ X0 (T)+B0]) = isRelative;\nL_0013:\n\treturn t;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRelative<T>(this T t, bool isRelative) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+98]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+99]");
							if ((IntPtr)0 != (IntPtr)0)
							{
							}
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0xB878EC", Offset = "0xB878EC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+F8]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9B]) = 1;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetSpeedBased<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						_ = 1;
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0xB87910", Offset = "0xB87910", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E0]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+F8]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9B]) = isSpeedBased;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetSpeedBased<T>(this T t, bool isSpeedBased) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+F8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600014B")]
		[Address(RVA = "0x1605BC0", Offset = "0x1605BC0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\tt.plugOptions = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<float, float, FloatOptions> t, bool snapping)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (FloatOptions)snapping;
			}
			return t;
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0x1605BD8", Offset = "0x1605BD8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+138]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0x1605BF0", Offset = "0x1605BF0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+138]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (VectorOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0x1605C0C", Offset = "0x1605C0C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+144]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0x1605C24", Offset = "0x1605C24", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+144]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (VectorOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0x1605C40", Offset = "0x1605C40", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+150]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x6000151")]
		[Address(RVA = "0x1605C58", Offset = "0x1605C58", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+150]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (VectorOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0x1605C74", Offset = "0x1605C74", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0009;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0009;\n\tv8 = ~useShortest360Route;\n\tt.plugOptions = v8;\nL_0009:\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool useShortest360Route = true)
		{
			//IL_0053: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				bool flag = !useShortest360Route;
				t.plugOptions = (QuaternionOptions)flag;
			}
			return t;
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0x1605C90", Offset = "0x1605C90", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\tt.plugOptions = alphaOnly;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Color, Color, ColorOptions> t, bool alphaOnly)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (ColorOptions)alphaOnly;
			}
			return t;
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0x1605CA8", Offset = "0x1605CA8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\tt.plugOptions = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Rect, Rect, RectOptions> t, bool snapping)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (RectOptions)snapping;
			}
			return t;
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0x1605CC0", Offset = "0x1605CC0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F0B468]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, richTextEnabled, scrambleMode, scrambleChars, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202A1D6]) = v47;\nL_0019:\n\tv48 = t == 0;\n\tif (v48) goto L_005C;\n\tv50 = ~t.<active>k__BackingField;\n\tif (v50) goto L_005C;\n\tt.plugOptions = richTextEnabled;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+13C]) = scrambleMode;\n\tv88 = System.String::IsNullOrEmpty(scrambleChars);\n\tv145 = v88 == 0;\n\tv91 = ~v145;\n\tif (v91) goto L_005C;\n\tv57 = scrambleChars.m_stringLength > 1;\n\tif (v57) goto L_0041;\n\tv154 = System.String::Concat(scrambleChars, scrambleChars);\nL_0041:\n\tv163 = System.String::ToCharArray(v159);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+140]) = v163;\n\tgoto L_0052;\n\tv171 = *([v167 @ X0_v12+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0052;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v167, v162, v52, scrambleChars, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0052:\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v163);\nL_005C:\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<string, string, StringOptions> t, bool richTextEnabled, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			//IL_0030: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (StringOptions)richTextEnabled;
				if (!string.IsNullOrEmpty(scrambleChars))
				{
					bool flag = scrambleChars.Length > 1;
					string text = scrambleChars;
					if (!flag)
					{
						string text2 = scrambleChars + scrambleChars;
						text = text2;
					}
					char[] chars = text.ToCharArray();
					chars.ScrambleChars();
				}
			}
			return t;
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0x1605DB8", Offset = "0x1605DB8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+13C]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0x1605DD0", Offset = "0x1605DD0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+13C]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (Vector3ArrayOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0x1605DEC", Offset = "0x1605DEC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]) = 0;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+140]) = lockPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]) = lockRotation;\nL_0008:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, AxisConstraint lockPosition, AxisConstraint lockRotation = AxisConstraint.None)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				_ = 0;
			}
			return t;
		}

		[Token(Token = "0x6000159")]
		[Address(RVA = "0x1605E08", Offset = "0x1605E08", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0009;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0009;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+140]) = lockPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]) = closePath;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]) = lockRotation;\nL_0009:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, bool closePath, AxisConstraint lockPosition = AxisConstraint.None, AxisConstraint lockRotation = AxisConstraint.None)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x600015A")]
		[Address(RVA = "0x1605E28", Offset = "0x1605E28", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = t == 0;\n\tif (v13) goto L_0019;\n\tv15 = ~t.<active>k__BackingField;\n\tif (v15) goto L_0019;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+14C]) = lookAtPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+150]) = lookAtPosition.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+13C]) = 3;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+154]) = lookAtPosition.z;\n\tDG.Tweening.TweenSettingsExtensions::SetPathForwardDirection(t, forwardDirection, up);\nL_0019:\n\treturn t;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				_ = lookAtPosition.y;
				_ = 3;
				_ = lookAtPosition.z;
				t.SetPathForwardDirection(forwardDirection, up);
			}
			return t;
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x16061E0", Offset = "0x16061E0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = t == 0;\n\tif (v10) goto L_0019;\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_0019;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+158]) = lookAtTransform;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+13C]) = 2;\n\tDG.Tweening.TweenSettingsExtensions::SetPathForwardDirection(t, forwardDirection, up);\nL_0019:\n\treturn t;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				_ = 2;
				t.SetPathForwardDirection(forwardDirection, up);
			}
			return t;
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x1606230", Offset = "0x1606230", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = t == 0;\n\tif (v10) goto L_0018;\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_0018;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+13C]) = 1;\n\tv14 = UnityEngine.Mathf::Max(lookAhead, 0.0001f);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+160]) = v14;\n\tDG.Tweening.TweenSettingsExtensions::SetPathForwardDirection(t, forwardDirection, up);\nL_0018:\n\treturn t;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				_ = 1;
				float num = Mathf.Max(lookAhead, 0.0001f);
				t.SetPathForwardDirection(forwardDirection, up);
			}
			return t;
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x1605E70", Offset = "0x1605E70", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv54 = *([1EDE0C8]);\n\tv55 = *([v54 @ X8_v56]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, forwardDirection, up, methodInfo, v37, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([202A1D7]) = v70;\nL_0027:\n\tv71 = t == 0;\n\tif (v71) goto L_013C;\n\tv73 = ~t.<active>k__BackingField;\n\tif (v73) goto L_013C;\n\tv202 = forwardDirection >> 0x20;\n\tv185 = up & 0xFF00000000;\n\tv203 = v185 == 0;\n\tif (v203) goto L_0060;\n\tgoto L_0040;\n\tv226 = *([v206 @ X0_v49+E0]);\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_0040;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v206, forwardDirection, up, methodInfo, v37, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_0040:\n\tv234 = UnityEngine.Vector3::get_zero();\n\tgoto L_0057;\n\tv257 = *([v244 @ X0_v52+E0]);\n\tv258 = v257 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_0057;\n\tv261 = \"il2cpp_codegen_runtime_class_init\"(v244, forwardDirection, up, methodInfo, v37, v57, v58, v59, v234, v242, v243, v63, v64, v65, v66, v67);\nL_0057:\n\t// 87 MakeStruct v211 @ AGG1605F64_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), forwardDirection @ X1 (System.Nullable`1<UnityEngine.Vector3>), v202 @ X8_v5 (System.Int32), up @ X2 (System.Nullable`1<UnityEngine.Vector3>)\n\tv221 = UnityEngine.Vector3::op_Inequality(v211, v234);\n\tv223 = v221 == 0;\n\tif (v223) goto L_0060;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+164]) = 1;\n\tgoto L_009F;\nL_0060:\n\tv183 = v37 & 0xFF00000000;\n\tv173 = v183 == 0;\n\tif (v173) goto L_00FB;\n\tv105 = methodInfo >> 0x20;\n\tgoto L_0077;\n\tv248 = *([v238 @ X0_v40+E0]);\n\tv249 = v248 == 0;\n\tv250 = ~v249;\n\tif (v250) goto L_0077;\n\tv252 = \"il2cpp_codegen_runtime_class_init\"(v238, forwardDirection, up, methodInfo, v37, v57, v58, v59, v153, v149, v145, v129, v125, v121, v66, v67);\nL_0077:\n\tv256 = UnityEngine.Vector3::get_zero();\n\tgoto L_008E;\n\tv272 = *([v266 @ X0_v43+E0]);\n\tv273 = v272 == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_008E;\n\tv276 = \"il2cpp_codegen_runtime_class_init\"(v266, forwardDirection, up, methodInfo, v37, v57, v58, v59, v256, v264, v265, v129, v125, v121, v66, v67);\nL_008E:\n\t// 142 MakeStruct v95 @ AGG1606004_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), methodInfo @ X3 (Il2CppMethodInfo), v105 @ X9_v3 (System.Int32), v37 @ X4\n\tv168 = UnityEngine.Vector3::op_Inequality(v95, v256);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+164]) = v168;\n\tv172 = v168 == 0;\n\tif (v172) goto L_013C;\nL_009F:\n\tgoto L_00A6;\n\tv302 = *([v298 @ X0_v4+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_00A6;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v298, forwardDirection, up, methodInfo, v37, v57, v58, v59, v290, v289, v288, v284, v283, v282, v66, v67);\nL_00A6:\n\tv310 = UnityEngine.Vector3::get_zero();\n\tv316 = v185 == 0;\n\tif (v316) goto L_00E5;\n\tgoto L_00BF;\n\tv349 = *([v317 @ X0_v24+E0]);\n\tv350 = v349 == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_00BF;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v317, forwardDirection, up, methodInfo, v37, v57, v58, v59, v310, v311, v312, v284, v283, v282, v66, v67);\nL_00BF:\n\t// 191 MakeStruct v326 @ AGG160608C_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v293 @ V10_v4 (System.Nullable`1<UnityEngine.Vector3>), v292 @ V9_v4 (System.Int32), v291 @ V8_v4 (System.Nullable`1<UnityEngine.Vector3>)\n\tv360 = UnityEngine.Vector3::op_Equality(v326, v310);\n\tv371 = v360 == 0;\n\tif (v371) goto L_00DF;\n\tgoto L_00D0;\n\tv403 = *([v374 @ X0_v31+E0]);\n\tv404 = v403 == 0;\n\tv405 = ~v404;\n\tif (v405) goto L_00D0;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v374, forwardDirection, up, methodInfo, v37, v57, v58, v59, v356, v357, v358, v332, v330, v328, v66, v67);\nL_00D0:\n\tv396 = UnityEngine.Vector3::get_forward();\n\tv340 = 0x115D2C0(&forwardDirection @ X1 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, up, methodInfo, v37, v57, v58, v59, v396, v396.y, v396.z, v310, v310.y, v310.z, v66, v67);\n\tv342 = v432 == 0;\n\tif (v342) goto L_00E5;\nL_00DF:\n\tv389 = 0x115D2DC(&forwardDirection @ X1 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, up, methodInfo, v37, v57, v58, v59, v396, v380, v379, v310, v310.y, v310.z, v66, v67);\n\tgoto L_00F3;\nL_00E5:\n\tgoto L_00EC;\n\tv361 = *([v345 @ X0_v20+E0]);\n\tv362 = v361 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_00EC;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v345, v321, up, methodInfo, v37, v57, v58, v59, v337, v335, v333, v331, v329, v327, v66, v67);\nL_00EC:\n\tv396 = UnityEngine.Vector3::get_forward();\n\tv395 = v396.y;\n\tv394 = v396.z;\nL_00F3:\n\tv402 = v401 == 0;\n\tif (v402) goto L_0101;\n\tv415 = 0x115D2DC(&methodInfo @ X3 (Il2CppMethodInfo), Il2CppMethodInfo, up, methodInfo, v37, v57, v58, v59, v396, v395, v394, v393, v392, v391, v66, v67);\n\tgoto L_0114;\nL_00FB:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+164]) = 0;\n\tgoto L_013C;\nL_0101:\n\tgoto L_0108;\n\tv423 = *([v416 @ X0_v13+E0]);\n\tv424 = v423 == 0;\n\tv425 = ~v424;\n\tif (v425) goto L_0108;\n\tv427 = \"il2cpp_codegen_runtime_class_init\"(v416, v390, up, methodInfo, v37, v57, v58, v59, v396, v395, v394, v393, v392, v391, v66, v67);\nL_0108:\n\tv437 = UnityEngine.Vector3::get_up();\n\tv435 = v437.y;\n\tv433 = v437.z;\nL_0114:\n\tgoto L_0121;\n\tv447 = *([v443 @ X0_v9+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tgoto L_0121;\n\tv451 = \"il2cpp_codegen_runtime_class_init\"(v443, v81, up, methodInfo, v37, v57, v58, v59, v437, v435, v433, v393, v392, v391, v66, v67);\nL_0121:\n\t// 289 MakeStruct v78 @ AGG16061A4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v396 @ V0_v4 (UnityEngine.Vector3), v395 @ V1_v4 (System.Single), v394 @ V2_v4 (System.Single)\n\t// 290 MakeStruct v75 @ AGG16061A4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v437 @ V0_v5 (UnityEngine.Vector3), v435 @ V1_v5 (System.Single), v433 @ V2_v5 (System.Single)\n\tv151 = UnityEngine.Quaternion::LookRotation(v78, v75);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+168]) = v151;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+16C]) = v151.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+170]) = v151.z;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+174]) = v151.w;\nL_013C:\n\treturn;\n// 193 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetPathForwardDirection(this TweenerCore<Vector3, Path, PathOptions> t, Vector3? forwardDirection = null, Vector3? up = null)
		{
			//IL_0031: Expected I4, but got O
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected I4, but got Unknown
			//IL_0121: Expected I4, but got I8
			//IL_0080: Expected F4, but got O
			//IL_009b: Expected F4, but got O
			//IL_016d: Expected F4, but got I
			//IL_0188: Expected F4, but got O
			//IL_0232: Expected F4, but got O
			//IL_024d: Expected F4, but got O
			//IL_033d: Expected F4, but got O
			//IL_02cc: Expected O, but got F4
			//IL_02d9: Expected I4, but got F4
			if (t == null || !t._003Cactive_003Ek__BackingField)
			{
				return;
			}
			int num = (object?)forwardDirection >> 32;
			int num2 = (int)((_003F?)up & 0xFF00000000L);
			Vector3? vector3;
			int num3;
			Vector3? vector4;
			if (num2 != 0)
			{
				Vector3 zero = Vector3.zero;
				Vector3 vector = default(Vector3);
				vector.x = (float)forwardDirection;
				vector.y = num;
				vector.z = (float)up;
				if (vector != zero)
				{
					_ = 1;
					float z = zero.z;
					float y = zero.y;
					Vector3 vector2 = zero;
					vector3 = up;
					num3 = num;
					vector4 = forwardDirection;
					goto IL_01fa;
				}
			}
			object obj = default(object);
			if ((int)((long)(IntPtr)obj & 0xFF00000000L) != 0)
			{
				IntPtr intPtr = default(IntPtr);
				int num4 = (int)((long)intPtr >> 32);
				Vector3 zero2 = Vector3.zero;
				Vector3 vector5 = default(Vector3);
				vector5.x = (long)intPtr;
				vector5.y = num4;
				vector5.z = (float)obj;
				bool flag = vector5 != zero2;
				bool flag2 = !flag;
				float z = zero2.z;
				float y = zero2.y;
				Vector3 vector2 = zero2;
				vector3 = up;
				num3 = num;
				vector4 = forwardDirection;
				if (!flag2)
				{
					goto IL_01fa;
				}
				return;
			}
			_ = 0;
			return;
			IL_0350:
			Vector3 vector6 = Vector3.forward;
			float num5 = vector6.y;
			float num6 = vector6.z;
			goto IL_0486;
			IL_0486:
			object obj2 = default(object);
			float z2;
			float y2;
			Vector3 vector7;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115D2DC (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xE4)");
				z2 = num6;
				y2 = num5;
				vector7 = vector6;
			}
			else
			{
				vector7 = Vector3.up;
				y2 = vector7.y;
				z2 = vector7.z;
			}
			Vector3 forward = default(Vector3);
			forward.x = vector6.x;
			forward.y = num5;
			forward.z = num6;
			Vector3 upwards = default(Vector3);
			upwards.x = vector7.x;
			upwards.y = y2;
			upwards.z = z2;
			Quaternion quaternion = Quaternion.LookRotation(forward, upwards);
			_ = quaternion.y;
			_ = quaternion.z;
			_ = quaternion.w;
			return;
			IL_01fa:
			Vector3 zero3 = Vector3.zero;
			if (num2 != 0)
			{
				Vector3 vector8 = default(Vector3);
				vector8.x = (float)vector4;
				vector8.y = num3;
				vector8.z = (float)vector3;
				bool flag3 = vector8 == zero3;
				bool flag4 = !flag3;
				Vector3? vector9 = vector3;
				int num7 = num3;
				vector6 = (Vector3)vector4;
				float z;
				float y;
				Vector3 vector2;
				if (!flag4)
				{
					vector6 = Vector3.forward;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
					object obj3 = default(object);
					bool flag5 = obj3 == null;
					vector9 = (Vector3?)(object)vector6.z;
					num7 = (int)vector6.y;
					z = zero3.z;
					y = zero3.y;
					vector2 = zero3;
					if (flag5)
					{
						goto IL_0350;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115D2DC (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xE4)");
				z = zero3.z;
				y = zero3.y;
				vector2 = zero3;
				num6 = (float)vector9;
				num5 = num7;
				goto IL_0486;
			}
			goto IL_0350;
		}
	}
}
