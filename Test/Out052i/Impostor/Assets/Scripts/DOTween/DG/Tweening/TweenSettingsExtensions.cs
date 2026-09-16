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
	[Token(Token = "0x200006D")]
	public static class TweenSettingsExtensions
	{
		[Token(Token = "0x6000244")]
		[Address(RVA = "0xCB5860", Offset = "0xCB5860", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+100]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9C]) = 1;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAutoKill<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						_ = 1;
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0xCB5884", Offset = "0xCB5884", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+100]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9C]) = autoKillOnCompletion;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAutoKill<T>(this T t, bool autoKillOnCompletion) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0xCB5C18", Offset = "0xCB5C18", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+30]) = objectId;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetId<T>(this T t, object objectId) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0xCB5C2C", Offset = "0xCB5C2C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+38]) = stringId;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetId<T>(this T t, string stringId) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0xCB5C04", Offset = "0xCB5C04", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+40]) = intId;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetId<T>(this T t, int intId) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0xCB5C88", Offset = "0xCB5C88", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, gameObject, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = DG.Tweening.Core.TweenLink;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, gameObject, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv71 = DG.Tweening.Core.TweenManager;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, gameObject, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3584B]) = v37;\nL_0018:\n\tv38 = t == 0;\n\tif (v38) goto L_004C;\n\tv43 = *([t @ X0 (T)+E8]) == 0;\n\tif (v43) goto L_004C;\n\tv72 = *([t @ X0 (T)+E9]) == 0;\n\tv57 = ~v72;\n\tif (v57) goto L_004C;\n\tgoto L_002C;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v75, gameObject, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002C:\n\tv54 = UnityEngine.Object::op_Equality(gameObject, 0);\n\tv82 = v54 == 0;\n\tv58 = ~v82;\n\tif (v58) goto L_004C;\n\tv86 = new DG.Tweening.Core.TweenLink();\n\tDG.Tweening.Core.TweenLink::.ctor(v86, gameObject, 6);\n\tgoto L_0045;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v91, v88, v87, v45, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0045:\n\tDG.Tweening.Core.TweenManager::AddTweenLink(t, v86);\nL_004C:\n\treturn t;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLink<T>(this T t, GameObject gameObject) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E9]");
					if ((nint)0 == 0 && !(gameObject == null))
					{
						TweenLink tweenLink = new TweenLink(gameObject, LinkBehaviour.KillOnDestroy);
						TweenManager.AddTweenLink(t, tweenLink);
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0xCB5D6C", Offset = "0xCB5D6C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, gameObject, behaviour, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = DG.Tweening.Core.TweenLink;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, gameObject, behaviour, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv75 = DG.Tweening.Core.TweenManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, gameObject, behaviour, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A3584C]) = v40;\nL_001A:\n\tv41 = t == 0;\n\tif (v41) goto L_004F;\n\tv46 = *([t @ X0 (T)+E8]) == 0;\n\tif (v46) goto L_004F;\n\tv76 = *([t @ X0 (T)+E9]) == 0;\n\tv60 = ~v76;\n\tif (v60) goto L_004F;\n\tgoto L_002E;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v79, gameObject, behaviour, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002E:\n\tv57 = UnityEngine.Object::op_Equality(gameObject, 0);\n\tv86 = v57 == 0;\n\tv61 = ~v86;\n\tif (v61) goto L_004F;\n\tv90 = new DG.Tweening.Core.TweenLink();\n\tDG.Tweening.Core.TweenLink::.ctor(v90, gameObject, behaviour);\n\tgoto L_0047;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v95, v91, v92, v48, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0047:\n\tDG.Tweening.Core.TweenManager::AddTweenLink(t, v90);\nL_004F:\n\treturn t;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLink<T>(this T t, GameObject gameObject, LinkBehaviour behaviour) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E9]");
					if ((nint)0 == 0 && !(gameObject == null))
					{
						TweenLink tweenLink = new TweenLink(gameObject, behaviour);
						TweenManager.AddTweenLink(t, tweenLink);
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0xCB5FEC", Offset = "0xCB5FEC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Component;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, target, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = DG.Tweening.DOTween;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, target, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv101 = UnityEngine.Object;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, target, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3584D]) = v37;\nL_0018:\n\tv38 = t == 0;\n\tif (v38) goto L_0075;\n\tv43 = *([t @ X0 (T)+E8]) == 0;\n\tif (v43) goto L_0075;\n\tgoto L_0026;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v104, target, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv152 = DG.Tweening.DOTween::get_debugStoreTargetId();\n\tv154 = v152 == 0;\n\tif (v154) goto L_006E;\n\tv155 = target == 0;\n\tif (v155) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0057;\n\tv202 = v202_asT == 0;\n\tif (v202) goto L_FFFFFFFF;\n\tgoto L_0057;\nL_0057:\n\tgoto L_005C;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v208, target, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_005C:\n\tv214 = UnityEngine.Object::op_Inequality(v148, 0);\n\tv216 = v214 == 0;\n\tif (v216) goto L_006C;\n\tv158 = UnityEngine.Object::get_name(v148);\n\tgoto L_006D;\nL_006C:\n\tv158 = System.Object::ToString(target);\nL_006D:\n\t*([t @ X0 (T)+C8]) = v158;\nL_006E:\n\t*([t @ X0 (T)+48]) = target;\nL_0075:\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetTarget<T>(this T t, object target) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0 && DOTween.debugStoreTargetId)
				{
					UnityEngine.Object obj;
					if (target == null)
					{
						obj = null;
					}
					else
					{
						Component component = target as Component;
						obj = (UnityEngine.Object)(((object)component == null) ? null : target);
					}
					if (obj != null)
					{
						string name = obj.name;
					}
					else
					{
						string name = target.ToString();
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0xCB5E5C", Offset = "0xCB5E5C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv42 = *([t @ X0 (T)+100]) == 0;\n\tif (v42) goto L_000E;\nL_0008:\n\treturn t;\nL_000E:\n\tv69 = loops == 0;\n\tv71 = ~v69;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tv76 = loops + 1;\n\tv27 = v76 < 0;\n\tv9 = v27 == 0;\n\tv6 = ~v9;\n\tif (v6) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\t*([t @ X0 (T)+A4]) = v40;\n\tv79 = *([t @ X0 (T)+10]) == 0;\n\tv43 = ~v79;\n\tif (v43) goto L_0008;\n\tv80 = v40 & 0x80000000;\n\tv81 = v80 == 0;\n\tv64 = ~v81;\n\tif (v64) goto L_0034;\n\tv49 = *([t @ X0 (T)+A0]) * v40;\n\t*([t @ X0 (T)+108]) = v49;\n\treturn t;\nL_0034:\n\t*([t @ X0 (T)+108]) = 0x7F800000;\n\treturn t;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLoops<T>(this T t, int loops) where T : Tween
		{
			//IL_00df: Expected I4, but got I8
			//IL_011c: Expected O, but got I
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						int num = ((loops == 0) ? 1 : loops);
						int num2 = loops + 1;
						if (num2 < 0)
						{
							num = -1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((nint)0 == 0)
						{
							if ((int)(num & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								object obj = (nint)0 * (nint)num;
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

		[Token(Token = "0x600024D")]
		[Address(RVA = "0xCB5EB4", Offset = "0xCB5EB4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv42 = *([t @ X0 (T)+100]) == 0;\n\tif (v42) goto L_000E;\nL_0008:\n\treturn t;\nL_000E:\n\tv69 = loops == 0;\n\tv71 = ~v69;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tv76 = loops + 1;\n\tv27 = v76 < 0;\n\tv9 = v27 == 0;\n\tv6 = ~v9;\n\tif (v6) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\t*([t @ X0 (T)+A4]) = v40;\n\t*([t @ X0 (T)+A8]) = loopType;\n\tv80 = *([t @ X0 (T)+10]) == 0;\n\tv43 = ~v80;\n\tif (v43) goto L_0008;\n\tv81 = v40 & 0x80000000;\n\tv82 = v81 == 0;\n\tv64 = ~v82;\n\tif (v64) goto L_0035;\n\tv49 = *([t @ X0 (T)+A0]) * v40;\n\t*([t @ X0 (T)+108]) = v49;\n\treturn t;\nL_0035:\n\t*([t @ X0 (T)+108]) = 0x7F800000;\n\treturn t;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetLoops<T>(this T t, int loops, LoopType loopType) where T : Tween
		{
			//IL_00df: Expected I4, but got I8
			//IL_011c: Expected O, but got I
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						int num = ((loops == 0) ? 1 : loops);
						int num2 = loops + 1;
						if (num2 < 0)
						{
							num = -1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((nint)0 == 0)
						{
							if ((int)(num & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								object obj = (nint)0 * (nint)num;
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

		[Token(Token = "0x600024E")]
		[Address(RVA = "0xCB5AAC", Offset = "0xCB5AAC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t == 0;\n\tif (v6) goto L_002C;\n\tv8 = *([t @ X0 (T)+E8]) == 0;\n\tif (v8) goto L_002C;\n\t*([t @ X0 (T)+B4]) = ease;\n\tv52 = DG.Tweening.Core.Easing.EaseManager::IsFlashEase(ease);\n\tv57 = v52 == 0;\n\tif (v57) goto L_0027;\n\tv80 = *([t @ X0 (T)+C0]);\n\tv79 = *([t @ X0 (T)+C0]) != 0x7F800000;\n\tif (v79) goto L_0026;\n\tgoto L_0026;\nL_0026:\n\t*([t @ X0 (T)+C0]) = v80;\nL_0027:\n\t*([t @ X0 (T)+B8]) = 0;\nL_002C:\n\treturn t;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, Ease ease) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					if (EaseManager.IsFlashEase(ease))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+C0]");
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+C0]");
						if ((nint)0 == 2139095040)
						{
							num = -822083584;
						}
					}
					_ = 0;
				}
			}
			return t;
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0xCB5B28", Offset = "0xCB5B28", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = t == 0;\n\tif (v8) goto L_0037;\n\tv10 = *([t @ X0 (T)+E8]) == 0;\n\tif (v10) goto L_0037;\n\t*([t @ X0 (T)+B4]) = ease;\n\tv59 = DG.Tweening.Core.Easing.EaseManager::IsFlashEase(ease);\n\tv77 = overshoot != 0x7F800000;\n\tif (v77) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\tv30 = v59 == 0;\n\tv12 = ~v30;\n\tv15 = ~v12;\n\tif (v15) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\t*([t @ X0 (T)+C0]) = v42;\n\t*([t @ X0 (T)+B8]) = 0;\nL_0037:\n\treturn t;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, Ease ease, float overshoot) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					bool flag = EaseManager.IsFlashEase(ease);
					if (overshoot == float.PositiveInfinity)
					{
						float num = -2.1474836E+09f;
					}
					else
					{
						float num = overshoot;
					}
					if (!flag)
					{
						float num = overshoot;
					}
					_ = 0;
				}
			}
			return t;
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0xCB5B94", Offset = "0xCB5B94", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = t == 0;\n\tif (v10) goto L_003B;\n\tv12 = *([t @ X0 (T)+E8]) == 0;\n\tif (v12) goto L_003B;\n\t*([t @ X0 (T)+B4]) = ease;\n\tv63 = DG.Tweening.Core.Easing.EaseManager::IsFlashEase(ease);\n\tv82 = amplitude != 0x7F800000;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0028;\nL_0028:\n\tv32 = v63 == 0;\n\tv14 = ~v32;\n\tv17 = ~v14;\n\tif (v17) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\t*([t @ X0 (T)+C0]) = v44;\n\t*([t @ X0 (T)+C4]) = period;\n\t*([t @ X0 (T)+B8]) = 0;\nL_003B:\n\treturn t;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, Ease ease, float amplitude, float period) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					bool flag = EaseManager.IsFlashEase(ease);
					if (amplitude == float.PositiveInfinity)
					{
						float num = -2.1474836E+09f;
					}
					else
					{
						float num = amplitude;
					}
					if (!flag)
					{
						float num = amplitude;
					}
					_ = 0;
				}
			}
			return t;
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0xCB59F0", Offset = "0xCB59F0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, animCurve, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = DG.Tweening.Core.Easing.EaseCurve;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, animCurve, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv65 = DG.Tweening.EaseFunction;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, animCurve, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3584A]) = v37;\nL_0018:\n\tv38 = t == 0;\n\tif (v38) goto L_0039;\n\tv43 = *([t @ X0 (T)+E8]) == 0;\n\tif (v43) goto L_0039;\n\t*([t @ X0 (T)+B4]) = 0x25;\n\tv70 = new DG.Tweening.Core.Easing.EaseCurve();\n\tDG.Tweening.Core.Easing.EaseCurve::.ctor(v70, animCurve);\n\tv51 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v51, v70, Il2CppMethodInfo);\n\t*([t @ X0 (T)+B8]) = v51;\nL_0039:\n\treturn t;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, AnimationCurve animCurve) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					_ = 37;
					EaseCurve easeCurve = new EaseCurve(animCurve);
					EaseFunction easeFunction = easeCurve.Evaluate;
				}
			}
			return t;
		}

		[Token(Token = "0x6000252")]
		[Address(RVA = "0xCB5B0C", Offset = "0xCB5B0C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\t*([t @ X0 (T)+B4]) = 0x25;\n\t*([t @ X0 (T)+B8]) = customEase;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetEase<T>(this T t, EaseFunction customEase) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					_ = 37;
				}
			}
			return t;
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0xCB5F0C", Offset = "0xCB5F0C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (T)+9A]) = 1;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRecyclable<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
				}
			}
			return t;
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0xCB5F24", Offset = "0xCB5F24", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (T)+9A]) = recyclable;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRecyclable<T>(this T t, bool recyclable) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0xCB6114", Offset = "0xCB6114", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, isIndependentUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = DG.Tweening.Core.TweenManager;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, isIndependentUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3584E]) = v37;\nL_0015:\n\tv38 = t == 0;\n\tif (v38) goto L_0039;\n\tv42 = *([t @ X0 (T)+E8]) == 0;\n\tif (v42) goto L_0039;\n\tgoto L_002B;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v70, isIndependentUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv76 = DG.Tweening.DOTween;\nL_002B:\n\tgoto L_0032;\n\tv80 = v60;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v80, isIndependentUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0032:\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, v47.defaultUpdateType, isIndependentUpdate);\nL_0039:\n\treturn t;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetUpdate<T>(this T t, bool isIndependentUpdate) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					TweenManager.SetUpdateType(t, DOTween.defaultUpdateType, isIndependentUpdate);
				}
			}
			return t;
		}

		[Token(Token = "0x6000256")]
		[Address(RVA = "0xCB61C0", Offset = "0xCB61C0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, updateType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = DG.Tweening.Core.TweenManager;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, updateType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3584F]) = v37;\nL_0015:\n\tv38 = t == 0;\n\tif (v38) goto L_0043;\n\tv42 = *([t @ X0 (T)+E8]) == 0;\n\tif (v42) goto L_0043;\n\tgoto L_002B;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v97, updateType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv103 = DG.Tweening.DOTween;\nL_002B:\n\tgoto L_0032;\n\tv107 = v87;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v107, updateType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0032:\n\tv71 = v47.defaultTimeScaleIndependent == 0;\n\tv56 = ~v71;\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, updateType, v56);\nL_0043:\n\treturn t;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetUpdate<T>(this T t, UpdateType updateType) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					bool flag = !DOTween.defaultTimeScaleIndependent;
					bool isIndependentUpdate = !flag;
					TweenManager.SetUpdateType(t, updateType, isIndependentUpdate);
				}
			}
			return t;
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0xCB6270", Offset = "0xCB6270", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A35850]) = v39;\nL_0014:\n\tv40 = t == 0;\n\tif (v40) goto L_002D;\n\tv42 = *([t @ X0 (T)+E8]) == 0;\n\tif (v42) goto L_002D;\n\tgoto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v63, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0025:\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, updateType, isIndependentUpdate);\nL_002D:\n\treturn t;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetUpdate<T>(this T t, UpdateType updateType, bool isIndependentUpdate) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					TweenManager.SetUpdateType(t, updateType, isIndependentUpdate);
				}
			}
			return t;
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0xCB5C40", Offset = "0xCB5C40", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+100]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+2D]) = 1;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetInverted<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						_ = 1;
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0xCB5C64", Offset = "0xCB5C64", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+100]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+2D]) = inverted;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetInverted<T>(this T t, bool inverted) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0xCB54F4", Offset = "0xCB54F4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+20]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnStart<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0xCB54CC", Offset = "0xCB54CC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+58]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnPlay<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600025C")]
		[Address(RVA = "0xCB54B8", Offset = "0xCB54B8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+60]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnPause<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600025D")]
		[Address(RVA = "0xCB54E0", Offset = "0xCB54E0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+68]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnRewind<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0xCB551C", Offset = "0xCB551C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+70]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnUpdate<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0xCB5508", Offset = "0xCB5508", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+78]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnStepComplete<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0xCB5490", Offset = "0xCB5490", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+80]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnComplete<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0xCB54A4", Offset = "0xCB54A4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+88]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnKill<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000262")]
		[Address(RVA = "0xCB5530", Offset = "0xCB5530", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0006;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0006;\n\t*([t @ X0 (T)+90]) = action;\nL_0006:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T OnWaypointChange<T>(this T t, TweenCallback<int> action) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			return t;
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0xCB5544", Offset = "0xCB5544", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv20 = DG.Tweening.Core.TweenManager;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, asTween, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35846]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_0083;\n\tv41 = *([t @ X0 (T)+E8]) == 0;\n\tif (v41) goto L_0083;\n\tv97 = *([t @ X0 (T)+100]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0083;\n\t*([t @ X0 (T)+28]) = asTween.timeScale;\n\t*([t @ X0 (T)+2C]) = asTween.isBackwards;\n\tgoto L_0030;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v126, asTween, methodInfo, v23, v24, v25, v26, v27, v122, v29, v30, v31, v32, v33, v34, v35);\nL_0030:\n\tv136 = asTween.isIndependentUpdate == 0;\n\tv141 = ~v136;\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, asTween.updateType, v141);\n\t*([t @ X0 (T)+30]) = asTween.id;\n\t*([t @ X0 (T)+38]) = asTween.stringId;\n\t*([t @ X0 (T)+40]) = asTween.intId;\n\t*([t @ X0 (T)+20]) = asTween.onStart;\n\t*([t @ X0 (T)+58]) = asTween.onPlay;\n\t*([t @ X0 (T)+68]) = asTween.onRewind;\n\t*([t @ X0 (T)+78]) = asTween.onStepComplete;\n\t*([t @ X0 (T)+88]) = asTween.onKill;\n\t*([t @ X0 (T)+90]) = asTween.onWaypointChange;\n\t*([t @ X0 (T)+9A]) = asTween.isRecyclable;\n\t*([t @ X0 (T)+9B]) = asTween.isSpeedBased;\n\t*([t @ X0 (T)+9C]) = asTween.autoKill;\n\t*([t @ X0 (T)+A4]) = asTween.loops;\n\tv156 = *([t @ X0 (T)+10]) == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0066;\n\tv159 = asTween.loops & 0x80000000;\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_FFFFFFFF;\n\tv164 = *([t @ X0 (T)+A0]) * asTween.loops;\n\tgoto L_0064;\nL_0064:\n\t*([t @ X0 (T)+108]) = v164;\nL_0066:\n\tv168 = asTween.delay < 0;\n\tv75 = ~v168;\n\tv66 = asTween.delay == 0;\n\tv169 = ~v75;\n\tv51 = v169 | v66;\n\t*([t @ X0 (T)+AC]) = asTween.delay;\n\t*([t @ X0 (T)+118]) = v51;\n\t*([t @ X0 (T)+B0]) = asTween.<isRelative>k__BackingField;\n\t*([t @ X0 (T)+B4]) = asTween.easeType;\n\t*([t @ X0 (T)+B8]) = asTween.customEase;\n\t*([t @ X0 (T)+C0]) = asTween.easeOvershootOrAmplitude;\nL_0083:\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAs<T>(this T t, Tween asTween) where T : Tween
		{
			//IL_0171: Expected I4, but got I8
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						_ = asTween.timeScale;
						_ = asTween.isBackwards;
						bool flag = !asTween.isIndependentUpdate;
						bool isIndependentUpdate = !flag;
						TweenManager.SetUpdateType(t, asTween.updateType, isIndependentUpdate);
						_ = asTween.id;
						_ = asTween.stringId;
						_ = asTween.intId;
						_ = asTween.onStart;
						_ = asTween.onPlay;
						_ = asTween.onRewind;
						_ = asTween.onStepComplete;
						_ = asTween.onKill;
						_ = asTween.onWaypointChange;
						_ = asTween.isRecyclable;
						_ = asTween.isSpeedBased;
						_ = asTween.autoKill;
						_ = asTween.loops;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((nint)0 == 0)
						{
							if ((int)(asTween.loops & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								int num = (int)((nint)0 * (nint)asTween.loops);
							}
							else
							{
								int num = 2139095040;
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
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0xCB56B8", Offset = "0xCB56B8", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = DG.Tweening.DOTween;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, tweenParams, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv42 = DG.Tweening.Core.TweenManager;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, tweenParams, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A35847]) = v39;\nL_0016:\n\tv40 = t == 0;\n\tif (v40) goto L_009D;\n\tv44 = *([t @ X0 (T)+E8]) == 0;\n\tif (v44) goto L_009D;\n\tv103 = *([t @ X0 (T)+100]) == 0;\n\tv91 = ~v103;\n\tif (v91) goto L_009D;\n\tgoto L_002F;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v132, tweenParams, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv142 = tweenParams.isIndependentUpdate == 0;\n\tv147 = ~v142;\n\tDG.Tweening.Core.TweenManager::SetUpdateType(t, tweenParams.updateType, v147);\n\t*([t @ X0 (T)+30]) = tweenParams.id;\n\t*([t @ X0 (T)+38]) = tweenParams.stringId;\n\t*([t @ X0 (T)+40]) = tweenParams.intId;\n\t*([t @ X0 (T)+20]) = tweenParams.onStart;\n\t*([t @ X0 (T)+58]) = tweenParams.onPlay;\n\t*([t @ X0 (T)+68]) = tweenParams.onRewind;\n\t*([t @ X0 (T)+78]) = tweenParams.onStepComplete;\n\t*([t @ X0 (T)+88]) = tweenParams.onKill;\n\t*([t @ X0 (T)+90]) = tweenParams.onWaypointChange;\n\t*([t @ X0 (T)+9A]) = tweenParams.isRecyclable;\n\t*([t @ X0 (T)+9B]) = tweenParams.isSpeedBased;\n\t*([t @ X0 (T)+9C]) = tweenParams.autoKill;\n\t*([t @ X0 (T)+A4]) = tweenParams.loops;\n\tv163 = *([t @ X0 (T)+10]) == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_0065;\n\tv166 = tweenParams.loops & 0x80000000;\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_FFFFFFFF;\n\tv173 = *([t @ X0 (T)+A0]) * tweenParams.loops;\n\tgoto L_0063;\nL_0063:\n\t*([t @ X0 (T)+108]) = v173;\nL_0065:\n\tv176 = tweenParams.delay < 0;\n\tv177 = ~v176;\n\tv180 = tweenParams.delay == 0;\n\tv185 = ~v177;\n\tv186 = v185 | v180;\n\t*([t @ X0 (T)+AC]) = tweenParams.delay;\n\t*([t @ X0 (T)+118]) = v186;\n\t*([t @ X0 (T)+B0]) = tweenParams.isRelative;\n\tv48 = tweenParams.easeType;\n\tv190 = tweenParams.easeType == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0091;\n\tv206 = *([t @ X0 (T)+10]) != 1;\n\tif (v206) goto L_008C;\n\tgoto L_0091;\nL_008C:\n\tgoto L_0090;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v215, v55, v57, v53, v24, v25, v26, v27, v175, v46, v30, v31, v32, v33, v34, v35);\n\tv219 = DG.Tweening.DOTween;\nL_0090:\n\tv48 = v212.defaultEaseType;\nL_0091:\n\t*([t @ X0 (T)+B4]) = v48;\n\t*([t @ X0 (T)+B8]) = tweenParams.customEase;\n\t*([t @ X0 (T)+C0]) = tweenParams.easeOvershootOrAmplitude;\nL_009D:\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetAs<T>(this T t, TweenParams tweenParams) where T : Tween
		{
			//IL_015d: Expected I4, but got I8
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						bool flag = !tweenParams.isIndependentUpdate;
						bool isIndependentUpdate = !flag;
						TweenManager.SetUpdateType(t, tweenParams.updateType, isIndependentUpdate);
						_ = tweenParams.id;
						_ = tweenParams.stringId;
						_ = tweenParams.intId;
						_ = tweenParams.onStart;
						_ = tweenParams.onPlay;
						_ = tweenParams.onRewind;
						_ = tweenParams.onStepComplete;
						_ = tweenParams.onKill;
						_ = tweenParams.onWaypointChange;
						_ = tweenParams.isRecyclable;
						_ = tweenParams.isSpeedBased;
						_ = tweenParams.autoKill;
						_ = tweenParams.loops;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((nint)0 == 0)
						{
							if ((int)(tweenParams.loops & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
								int num = (int)((nint)0 * (nint)tweenParams.loops);
							}
							else
							{
								int num = 2139095040;
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
							if ((nint)0 == 1)
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
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000265")]
		[Address(RVA = "0xC16C10", Offset = "0xC16C10", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, t, 0);\n\tv14 = v11 == 0;\n\tif (v14) goto L_0016;\n\tv23 = DG.Tweening.Sequence::DoInsert(s, t, s.duration);\nL_0016:\n\treturn s;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Append(this Sequence s, Tween t)
		{
			if (ValidateAddToSequence(s, t))
			{
				Sequence sequence = Sequence.DoInsert(s, t, s.duration);
			}
			return s;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0xC1BBF4", Offset = "0xC1BBF4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, t, 0);\n\tv14 = v11 == 0;\n\tif (v14) goto L_0013;\n\tv17 = DG.Tweening.Sequence::DoPrepend(s, t);\nL_0013:\n\treturn s;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Prepend(this Sequence s, Tween t)
		{
			if (ValidateAddToSequence(s, t))
			{
				Sequence sequence = Sequence.DoPrepend(s, t);
			}
			return s;
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0xC16C54", Offset = "0xC16C54", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, t, 0);\n\tv14 = v11 == 0;\n\tif (v14) goto L_0016;\n\tv23 = DG.Tweening.Sequence::DoInsert(s, t, s.lastTweenInsertTime);\nL_0016:\n\treturn s;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Join(this Sequence s, Tween t)
		{
			if (ValidateAddToSequence(s, t))
			{
				Sequence sequence = Sequence.DoInsert(s, t, s.lastTweenInsertTime);
			}
			return s;
		}

		[Token(Token = "0x6000268")]
		[Address(RVA = "0xC1BC2C", Offset = "0xC1BC2C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, t, 0);\n\tv18 = v15 == 0;\n\tif (v18) goto L_0017;\n\tv22 = DG.Tweening.Sequence::DoInsert(s, t, atPosition);\nL_0017:\n\treturn s;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Insert(this Sequence s, float atPosition, Tween t)
		{
			if (ValidateAddToSequence(s, t))
			{
				Sequence sequence = Sequence.DoInsert(s, t, atPosition);
			}
			return s;
		}

		[Token(Token = "0x6000269")]
		[Address(RVA = "0xC0B4E0", Offset = "0xC0B4E0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, 0, 1);\n\tv15 = v12 == 0;\n\tif (v15) goto L_0017;\n\ts.lastTweenInsertTime = s.duration;\n\tv18 = s.duration + interval;\n\ts.duration = v18;\nL_0017:\n\treturn s;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence AppendInterval(this Sequence s, float interval)
		{
			if (ValidateAddToSequence(s, null, ignoreTween: true))
			{
				s.lastTweenInsertTime = s.duration;
				float duration = s.duration + interval;
				s.duration = duration;
			}
			return s;
		}

		[Token(Token = "0x600026A")]
		[Address(RVA = "0xC1BC74", Offset = "0xC1BC74", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, 0, 1);\n\tv15 = v12 == 0;\n\tif (v15) goto L_0014;\n\tv18 = DG.Tweening.Sequence::DoPrependInterval(s, interval);\nL_0014:\n\treturn s;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence PrependInterval(this Sequence s, float interval)
		{
			if (ValidateAddToSequence(s, null, ignoreTween: true))
			{
				Sequence sequence = Sequence.DoPrependInterval(s, interval);
			}
			return s;
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0xC1BCB0", Offset = "0xC1BCB0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, 0, 1);\n\tv14 = callback == 0;\n\tif (v14) goto L_0019;\n\tv16 = v12 == 0;\n\tif (v16) goto L_0019;\n\tv23 = DG.Tweening.Sequence::DoInsertCallback(s, callback, s.duration);\nL_0019:\n\treturn s;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence AppendCallback(this Sequence s, TweenCallback callback)
		{
			bool flag = ValidateAddToSequence(s, null, ignoreTween: true);
			if (callback != null && flag)
			{
				Sequence sequence = Sequence.DoInsertCallback(s, callback, s.duration);
			}
			return s;
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0xC1BCFC", Offset = "0xC1BCFC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, 0, 1);\n\tv14 = callback == 0;\n\tif (v14) goto L_0017;\n\tv16 = v12 == 0;\n\tif (v16) goto L_0017;\n\tv22 = DG.Tweening.Sequence::DoInsertCallback(s, callback, 0f);\nL_0017:\n\treturn s;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence PrependCallback(this Sequence s, TweenCallback callback)
		{
			bool flag = ValidateAddToSequence(s, null, ignoreTween: true);
			if (callback != null && flag)
			{
				Sequence sequence = Sequence.DoInsertCallback(s, callback, 0f);
			}
			return s;
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0xC1BD40", Offset = "0xC1BD40", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, 0, 1);\n\tv14 = callback == 0;\n\tif (v14) goto L_0019;\n\tv16 = v12 == 0;\n\tif (v16) goto L_0019;\n\tv23 = DG.Tweening.Sequence::DoInsertCallback(s, callback, s.lastTweenInsertTime);\nL_0019:\n\treturn s;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence JoinCallback(this Sequence s, TweenCallback callback)
		{
			bool flag = ValidateAddToSequence(s, null, ignoreTween: true);
			if (callback != null && flag)
			{
				Sequence sequence = Sequence.DoInsertCallback(s, callback, s.lastTweenInsertTime);
			}
			return s;
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0xC1BD8C", Offset = "0xC1BD8C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = DG.Tweening.TweenSettingsExtensions::ValidateAddToSequence(s, 0, 1);\n\tv18 = callback == 0;\n\tif (v18) goto L_001A;\n\tv20 = v16 == 0;\n\tif (v20) goto L_001A;\n\tv25 = DG.Tweening.Sequence::DoInsertCallback(s, callback, atPosition);\nL_001A:\n\treturn s;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence InsertCallback(this Sequence s, float atPosition, TweenCallback callback)
		{
			bool flag = ValidateAddToSequence(s, null, ignoreTween: true);
			if (callback != null && flag)
			{
				Sequence sequence = Sequence.DoInsertCallback(s, callback, atPosition);
			}
			return s;
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0xC1BB68", Offset = "0xC1BB68", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = s == 0;\n\tif (v2) goto L_000D;\n\tv5 = ~s.<active>k__BackingField;\n\tif (v5) goto L_0010;\n\tv7 = ~s.creationLocked;\n\tif (v7) goto L_0016;\n\tDG.Tweening.Core.Debugger+Sequence::LogAddToLockedSequence();\n\tgoto L_FFFFFFFF;\nL_000D:\n\tDG.Tweening.Core.Debugger+Sequence::LogAddToNullSequence();\n\tgoto L_FFFFFFFF;\nL_0010:\n\tDG.Tweening.Core.Debugger+Sequence::LogAddToInactiveSequence();\nL_0014:\n\treturn returnVal1;\nL_0016:\n\tv12 = ignoreTween == 0;\n\tif (v12) goto L_001A;\n\tgoto L_0014;\nL_001A:\n\tv27 = t == 0;\n\tif (v27) goto L_0027;\n\tv28 = ~t.<active>k__BackingField;\n\tif (v28) goto L_002B;\n\tv26 = ~t.isSequenced;\n\tif (v26) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger+Sequence::LogAddAlreadySequencedTween(t);\n\tgoto L_FFFFFFFF;\nL_0027:\n\tDG.Tweening.Core.Debugger+Sequence::LogAddNullTween();\n\tgoto L_FFFFFFFF;\nL_002B:\n\tDG.Tweening.Core.Debugger+Sequence::LogAddInactiveTween(t);\n\tgoto L_FFFFFFFF;\n\treturn X0;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool ValidateAddToSequence(Sequence s, Tween t, bool ignoreTween = false)
		{
			if (s != null)
			{
				if (s.active)
				{
					if (s.creationLocked)
					{
						Debugger.Sequence.LogAddToLockedSequence();
					}
					else
					{
						if (ignoreTween)
						{
							goto IL_00a2;
						}
						if (t != null)
						{
							if (t.active)
							{
								if (!t.isSequenced)
								{
									goto IL_00a2;
								}
								Debugger.Sequence.LogAddAlreadySequencedTween(t);
							}
							else
							{
								Debugger.Sequence.LogAddInactiveTween(t);
							}
						}
						else
						{
							Debugger.Sequence.LogAddNullTween();
						}
					}
				}
				else
				{
					Debugger.Sequence.LogAddToInactiveSequence();
				}
			}
			else
			{
				Debugger.Sequence.LogAddToNullSequence();
			}
			return false;
			IL_00a2:
			return true;
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0xCB5248", Offset = "0xCB5248", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0007;\nL_0007:\n\tv9 = t == 0;\n\tv10 = ~v9;\n\tif (v10) goto L_0010;\n\tgoto L_0025;\n\tv12 = 0xB3490C(methodInfo, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv29 = t == 0;\n\tif (v29) goto L_0025;\nL_0010:\n\tv31 = *([t @ X0 (T)+E8]) == 0;\n\tif (v31) goto L_0025;\n\tv51 = *([t @ X0 (T)+100]) == 0;\n\tv43 = ~v51;\n\tif (v43) goto L_0025;\n\tv42 = *([t @ X0 (T)+121]) == 0;\n\tif (v42) goto L_0025;\n\tv45 = t->klass;\n\t*([t @ X0 (T)+98]) = 1;\n\t*([v45 @ X8_v6 (Il2CppClass<T>)+208])(v40, t, 0, *([v45 @ X8_v6 (Il2CppClass<T>)+210]), v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\nL_0025:\n\treturn t;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T From<T>(this T t) where T : Tweener
		{
			//IL_00db: Expected I, but got O
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+121]");
						if ((nint)0 != 0)
						{
							nint num = (nint)t;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v45 @ X8_v6 (Il2CppClass<T>)+208] (should have been resolved before IL gen)");
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0xCB52B0", Offset = "0xCB52B0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv15 = 0xB3490C(methodInfo, isRelative, methodInfo, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0013:\n\treturnVal1 = DG.Tweening.TweenSettingsExtensions::From /* +1 sharing this address */(t, 1, isRelative, v16);\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T From<T>(this T t, bool isRelative) where T : Tweener
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CB92E8 (DG.Tweening.TweenSettingsExtensions::From, and 1 more at this address)");
			T result = default(T);
			return result;
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0xCB52E8", Offset = "0xCB52E8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t == 0;\n\tif (v6) goto L_0010;\n\tv8 = *([t @ X0 (T)+E8]) == 0;\n\tif (v8) goto L_0010;\n\tv51 = *([t @ X0 (T)+100]) == 0;\n\tif (v51) goto L_0012;\nL_0010:\n\treturn t;\nL_0012:\n\tv52 = *([t @ X0 (T)+121]) == 0;\n\tif (v52) goto L_0010;\n\t*([t @ X0 (T)+98]) = 1;\n\tv53 = setImmediately == 0;\n\tif (v53) goto L_0029;\n\tv54 = isRelative == 0;\n\tif (v54) goto L_FFFFFFFF;\n\tv66 = *([t @ X0 (T)+99]) == 0;\n\tgoto L_002C;\nL_0029:\n\t*([t @ X0 (T)+B0]) = isRelative;\n\tgoto L_0010;\nL_002C:\n\tv49 = t->klass;\n\t*([v49 @ X8_v8 (Il2CppClass<T>)+208])(v43, t, v17, *([v49 @ X8_v8 (Il2CppClass<T>)+210]), methodInfo, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87);\n\tgoto L_0010;\n\treturn X0;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T From<T>(this T t, bool setImmediately, bool isRelative) where T : Tweener
		{
			//IL_0115: Expected I, but got O
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+121]");
						if ((nint)0 != 0)
						{
							_ = 1;
							if (setImmediately)
							{
								if (isRelative)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+99]");
									bool flag = (nint)0 == 0;
									bool flag2 = flag;
								}
								else
								{
									bool flag2 = false;
								}
								nint num = (nint)t;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ X8_v8 (Il2CppClass<T>)+208] (should have been resolved before IL gen)");
							}
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0xCB5360", Offset = "0xCB5360", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-50_v2;\n\t*([v18 @ X29_v1-8]) = *([v21 @ SYSREG+28]);\n\t*([v18 @ X29_v1-38]) = v174;\n\tgoto L_001C;\n\tv111 = 0xB3490C(v63, v174, setImmediately, v65, v63, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_001C:\n\tv52 = Il2CppClass<T2>;\n\tv75 = *([v52 @ X8_v4 (Il2CppClass<T2>)+FC]);\n\tv56 = *([v52 @ X8_v4 (Il2CppClass<T2>)+FC]) + 0xF;\n\tv57 = v56 & 0x1FFFFFFF0;\n\tv78 = &v55 @ stack_-90_v1 - v57;\n\tv60 = t == 0;\n\tif (v60) goto L_006A;\n\tv62 = ~t.<active>k__BackingField;\n\tif (v62) goto L_006A;\n\tv135 = ~t.creationLocked;\n\tv115 = ~v135;\n\tif (v115) goto L_006A;\n\tv116 = ~t.isFromAllowed;\n\tif (v116) goto L_006A;\n\tt.isFrom = 1;\n\tv167 = Il2CppClass<T2>;\n\tv103 = *([v167 @ X8_v12 (Il2CppClass<T2>)+28]) < 0;\n\tv94 = *([v167 @ X8_v12 (Il2CppClass<T2>)+28]) ^ *([v167 @ X8_v12 (Il2CppClass<T2>)+28]);\n\tv91 = *([v167 @ X8_v12 (Il2CppClass<T2>)+28]) & v94;\n\tv88 = v91 < 0;\n\tv170 = &v19 @ stack_-50_v2 - 0x38;\n\tv171 = v103 == v88;\n\tv85 = ~v171;\n\tv82 = ~v85;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0047;\nL_0047:\n\tv175 = 0x1854F10(v78, v174, v75, v65, v63, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv80 = Il2CppMethodInfo;\n\tgoto L_0053;\n\tv181 = *([v58 @ X22_v1]);\nL_0053:\n\tv71 = &v19 @ stack_-50_v2 - 0xC;\n\tv68 = &v19 @ stack_-50_v2 - 0x10;\n\t*([v18 @ X29_v1-C]) = setImmediately;\n\t*([v18 @ X29_v1-10]) = v65;\n\t*([v18 @ X29_v1-30]) = v78;\n\t*([v18 @ X29_v1-28]) = v71;\n\t*([v18 @ X29_v1-20]) = v68;\n\tv65 = &v19 @ stack_-50_v2 - 0x30;\n\tv63 = &v19 @ stack_-50_v2 - 0x18;\n\t*([v80 @ X1_v3 (Il2CppMethodInfo)+10])(v111, *([v80 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, t, v65, v63, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_006A:\n\tv134 = *([v21 @ SYSREG+28]) != *([v18 @ X29_v1-8]);\n\tif (v134) goto L_0079;\n\treturn t;\nL_0079:\n\treturnVal2 = 0x1854EB0(v111, v174, v75, v65, v63, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn returnVal2;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<T1, T2, TPlugOptions> From<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> t, T2 fromValue, bool setImmediately = true, bool isRelative = false) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0184: Expected O, but got I
			//IL_019a: Expected O, but got I
			//IL_01ad: Expected I4, but got I8
			//IL_01bb: Expected O, but got I
			//IL_0116: Expected O, but got I
			//IL_022b: Expected O, but got I
			//IL_023a: Expected O, but got I
			//IL_0289: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v4 (Il2CppClass<T2>)+FC]");
			TweenerCore<T1, T2, TPlugOptions> tweenerCore = (TweenerCore<T1, T2, TPlugOptions>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v4 (Il2CppClass<T2>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			if (t != null && t._003Cactive_003Ek__BackingField && !t.creationLocked && t.isFromAllowed)
			{
				t.isFrom = true;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v12 (Il2CppClass<T2>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v12 (Il2CppClass<T2>)+28]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v12 (Il2CppClass<T2>)+28]");
				int num5 = (int)(num4 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v12 (Il2CppClass<T2>)+28]");
				int num6 = (int)((nint)0 & (nint)num5);
				bool flag2 = num6 < 0;
				T2 val = (T2)((nint)obj2 - 56);
				T2 val2;
				if (flag == flag2)
				{
					val2 = val;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				nint num7 = 0;
				object obj6 = (nint)obj2 - 12;
				object obj7 = (nint)obj2 - 16;
				bool flag3 = (byte)((nint)obj2 - 48) != 0;
				nint num8 = (nint)obj2 - 24;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				tweenerCore = t;
				val2 = (T2)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-8]");
			if (num9 == 0)
			{
				return t;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			TweenerCore<T1, T2, TPlugOptions> result = default(TweenerCore<T1, T2, TPlugOptions>);
			return result;
		}

		[Token(Token = "0x6000274")]
		[Address(RVA = "0xC1BDDC", Offset = "0xC1BDDC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, setImmediately, isRelative, methodInfo, v29, v30, v31, v32, fromAlphaValue, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3574D]) = v42;\nL_0016:\n\tv43 = t == 0;\n\tif (v43) goto L_0037;\n\tv45 = ~t.<active>k__BackingField;\n\tif (v45) goto L_0037;\n\tv76 = ~t.creationLocked;\n\tv64 = ~v76;\n\tif (v64) goto L_0037;\n\tv63 = ~t.isFromAllowed;\n\tif (v63) goto L_0037;\n\tt.isFrom = 1;\n\tv61 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>::SetFrom(t, setImmediately, isRelative, Il2CppMethodInfo);\nL_0037:\n\treturn t;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> From(this TweenerCore<Color, Color, ColorOptions> t, float fromAlphaValue, bool setImmediately = true, bool isRelative = false)
		{
			//IL_008b: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField && !t.creationLocked && t.isFromAllowed)
			{
				t.isFrom = true;
				Tweener tweener = t.SetFrom((Color)setImmediately, isRelative, relative: false);
			}
			return t;
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0xC1BE84", Offset = "0xC1BE84", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, setImmediately, isRelative, methodInfo, v29, v30, v31, v32, fromValue, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3574E]) = v42;\nL_0016:\n\tv43 = t == 0;\n\tif (v43) goto L_0037;\n\tv45 = ~t.<active>k__BackingField;\n\tif (v45) goto L_0037;\n\tv77 = ~t.creationLocked;\n\tv65 = ~v77;\n\tif (v65) goto L_0037;\n\tv64 = ~t.isFromAllowed;\n\tif (v64) goto L_0037;\n\tt.isFrom = 1;\n\t// 45 MakeStruct v47 @ AGGC1FF0C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), fromValue @ V0 (System.Single), fromValue @ V0 (System.Single), fromValue @ V0 (System.Single)\n\tv62 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>::SetFrom(t, v47, setImmediately, isRelative);\nL_0037:\n\treturn t;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> From(this TweenerCore<Vector3, Vector3, VectorOptions> t, float fromValue, bool setImmediately = true, bool isRelative = false)
		{
			if (t != null && t._003Cactive_003Ek__BackingField && !t.creationLocked && t.isFromAllowed)
			{
				t.isFrom = true;
				Vector3 fromValue2 = default(Vector3);
				fromValue2.x = fromValue;
				fromValue2.y = fromValue;
				fromValue2.z = fromValue;
				Tweener tweener = t.SetFrom(fromValue2, setImmediately, isRelative);
			}
			return t;
		}

		[Token(Token = "0x6000276")]
		[Address(RVA = "0xC1BF28", Offset = "0xC1BF28", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, setImmediately, isRelative, methodInfo, v29, v30, v31, v32, fromValueDegrees, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3574F]) = v42;\nL_0016:\n\tv43 = t == 0;\n\tif (v43) goto L_0036;\n\tv45 = ~t.<active>k__BackingField;\n\tif (v45) goto L_0036;\n\tv75 = ~t.creationLocked;\n\tv63 = ~v75;\n\tif (v63) goto L_0036;\n\tv62 = ~t.isFromAllowed;\n\tif (v62) goto L_0036;\n\tt.isFrom = 1;\n\t// 44 MakeStruct v47 @ AGGC1FFAC_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), fromValueDegrees @ V0 (System.Single), 0\n\tv60 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.CircleOptions>::SetFrom(t, v47, setImmediately, isRelative);\nL_0036:\n\treturn t;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, CircleOptions> From(this TweenerCore<Vector2, Vector2, CircleOptions> t, float fromValueDegrees, bool setImmediately = true, bool isRelative = false)
		{
			if (t != null && t._003Cactive_003Ek__BackingField && !t.creationLocked && t.isFromAllowed)
			{
				t.isFrom = true;
				Vector2 fromValue = default(Vector2);
				fromValue.x = fromValueDegrees;
				fromValue.y = 0f;
				Tweener tweener = t.SetFrom(fromValue, setImmediately, isRelative);
			}
			return t;
		}

		[Token(Token = "0x6000277")]
		[Address(RVA = "0xCB58A8", Offset = "0xCB58A8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Sequence;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, delay, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35848]) = v36;\nL_0012:\n\tv37 = t == 0;\n\tif (v37) goto L_0052;\n\tv39 = *([t @ X0 (T)+E8]) == 0;\n\tif (v39) goto L_0052;\n\tv99 = *([t @ X0 (T)+100]) == 0;\n\tv89 = ~v99;\n\tif (v89) goto L_0052;\n\tv53 = *([t @ X0 (T)+10]) != 1;\n\tif (v53) goto L_003E;\n\tv42 = *([t @ X0 (T)]) != DG.Tweening.Sequence;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tv87 = DG.Tweening.TweenSettingsExtensions::PrependInterval(v117, delay);\n\tgoto L_0052;\nL_003E:\n\tv113 = delay < 0;\n\tv83 = ~v113;\n\tv71 = delay == 0;\n\tv114 = ~v83;\n\tv51 = v114 | v71;\n\t*([t @ X0 (T)+AC]) = delay;\n\t*([t @ X0 (T)+118]) = v51;\nL_0052:\n\treturn t;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetDelay<T>(this T t, float delay) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((nint)0 == 1)
						{
							Sequence s = (Sequence)(object)(((object)t.GetType() != typeof(Sequence)) ? null : t);
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

		[Token(Token = "0x6000278")]
		[Address(RVA = "0xCB5948", Offset = "0xCB5948", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = DG.Tweening.Sequence;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, asPrependedIntervalIfSequence, methodInfo, v25, v26, v27, v28, v29, delay, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A35849]) = v39;\nL_0014:\n\tv40 = t == 0;\n\tif (v40) goto L_0058;\n\tv42 = *([t @ X0 (T)+E8]) == 0;\n\tif (v42) goto L_0058;\n\tv105 = *([t @ X0 (T)+100]) == 0;\n\tv93 = ~v105;\n\tif (v93) goto L_0058;\n\tv56 = *([t @ X0 (T)+10]) != 1;\n\tif (v56) goto L_0043;\n\tv94 = asPrependedIntervalIfSequence == 0;\n\tif (v94) goto L_0043;\n\tv45 = *([t @ X0 (T)]) != DG.Tweening.Sequence;\n\tif (v45) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tv90 = DG.Tweening.TweenSettingsExtensions::PrependInterval(v124, delay);\n\tgoto L_0058;\nL_0043:\n\tv117 = delay < 0;\n\tv86 = ~v117;\n\tv74 = delay == 0;\n\tv118 = ~v86;\n\tv54 = v118 | v74;\n\t*([t @ X0 (T)+AC]) = delay;\n\t*([t @ X0 (T)+118]) = v54;\nL_0058:\n\treturn t;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetDelay<T>(this T t, float delay, bool asPrependedIntervalIfSequence) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+10]");
						if ((nint)0 != 1 || !asPrependedIntervalIfSequence)
						{
							bool flag = delay < 0f;
							bool flag2 = !flag;
							bool flag3 = delay == 0f;
							bool flag4 = !flag2;
							bool flag5 = flag4 || flag3;
						}
						else
						{
							Sequence s = (Sequence)(object)(((object)t.GetType() != typeof(Sequence)) ? null : t);
							Sequence sequence = s.PrependInterval(delay);
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x6000279")]
		[Address(RVA = "0xCB5F3C", Offset = "0xCB5F3C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv10 = *([t @ X0 (T)+100]) == 0;\n\tif (v10) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\tv16 = *([t @ X0 (T)+98]) == 0;\n\tv11 = ~v16;\n\tif (v11) goto L_0008;\n\tv17 = *([t @ X0 (T)+99]) == 0;\n\tv12 = ~v17;\n\tif (v12) goto L_0008;\n\t*([t @ X0 (T)+B0]) = 1;\n\treturn t;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRelative<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+99]");
							if ((nint)0 == 0)
							{
								_ = 1;
								return t;
							}
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600027A")]
		[Address(RVA = "0xCB5F70", Offset = "0xCB5F70", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv10 = *([t @ X0 (T)+100]) == 0;\n\tif (v10) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\tv16 = *([t @ X0 (T)+98]) == 0;\n\tv11 = ~v16;\n\tif (v11) goto L_0008;\n\tv17 = *([t @ X0 (T)+99]) == 0;\n\tv12 = ~v17;\n\tif (v12) goto L_0008;\n\t*([t @ X0 (T)+B0]) = isRelative;\n\treturn t;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetRelative<T>(this T t, bool isRelative) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+99]");
							if ((nint)0 == 0)
							{
								return t;
							}
						}
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0xCB5FA4", Offset = "0xCB5FA4", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+100]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9B]) = 1;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetSpeedBased<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						_ = 1;
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0xCB5FC8", Offset = "0xCB5FC8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = *([t @ X0 (T)+E8]) == 0;\n\tif (v3) goto L_0008;\n\tv8 = *([t @ X0 (T)+100]) == 0;\n\tif (v8) goto L_000A;\nL_0008:\n\treturn t;\nL_000A:\n\t*([t @ X0 (T)+9B]) = isSpeedBased;\n\treturn t;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T SetSpeedBased<T>(this T t, bool isSpeedBased) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+100]");
					if ((nint)0 == 0)
					{
						return t;
					}
				}
			}
			return t;
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0xC1BFC8", Offset = "0xC1BFC8", Length = "0x18")]
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

		[Token(Token = "0x600027E")]
		[Address(RVA = "0xC1BFE0", Offset = "0xC1BFE0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+140]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0xC1BFF8", Offset = "0xC1BFF8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+140]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (VectorOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0xC13510", Offset = "0xC13510", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xC136C4", Offset = "0xC136C4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (VectorOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xC1C014", Offset = "0xC1C014", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+158]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0xC1C02C", Offset = "0xC1C02C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+158]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (VectorOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0xC1C048", Offset = "0xC1C048", Length = "0x1C")]
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

		[Token(Token = "0x6000285")]
		[Address(RVA = "0xC07868", Offset = "0xC07868", Length = "0x18")]
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

		[Token(Token = "0x6000286")]
		[Address(RVA = "0xC1C064", Offset = "0xC1C064", Length = "0x18")]
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

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xC1C07C", Offset = "0xC1C07C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = DG.Tweening.Plugins.StringPluginExtensions;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, richTextEnabled, scrambleMode, scrambleChars, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A35750]) = v42;\nL_0016:\n\tv43 = t == 0;\n\tif (v43) goto L_0054;\n\tv45 = ~t.<active>k__BackingField;\n\tif (v45) goto L_0054;\n\tt.plugOptions = richTextEnabled;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+144]) = scrambleMode;\n\tv83 = System.String::IsNullOrEmpty(scrambleChars);\n\tv138 = v83 == 0;\n\tv86 = ~v138;\n\tif (v86) goto L_0054;\n\tv52 = scrambleChars._stringLength > 1;\n\tif (v52) goto L_003E;\n\tv146 = System.String::Concat(scrambleChars, scrambleChars);\nL_003E:\n\tv156 = System.String::ToCharArray(v153);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+148]) = v156;\n\tgoto L_004B;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v159, v155, v47, scrambleChars, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004B:\n\tDG.Tweening.Plugins.StringPluginExtensions::ScrambleChars(v156);\nL_0054:\n\treturn t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xC153D8", Offset = "0xC153D8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0007;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0007;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+144]) = snapping;\nL_0007:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool snapping)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xC1C158", Offset = "0xC1C158", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\tt.plugOptions = axisConstraint;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+144]) = snapping;\nL_0008:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			//IL_0048: Expected O, but got I4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (Vector3ArrayOptions)axisConstraint;
			}
			return t;
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xC1C174", Offset = "0xC1C174", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_000B;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_000B;\n\tt.plugOptions = endValueDegrees;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.CircleOptions>)+140]) = relativeCenter;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.CircleOptions>)+141]) = snapping;\nL_000B:\n\treturn t;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, CircleOptions> t, float endValueDegrees, bool relativeCenter = true, bool snapping = false)
		{
			//IL_0048: Expected O, but got F4
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				t.plugOptions = (CircleOptions)endValueDegrees;
			}
			return t;
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xC1C19C", Offset = "0xC1C19C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0008;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0008;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+150]) = 0;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]) = lockPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+14C]) = lockRotation;\nL_0008:\n\treturn t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, AxisConstraint lockPosition, AxisConstraint lockRotation = AxisConstraint.None)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				_ = 0;
			}
			return t;
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0xC1C1B8", Offset = "0xC1C1B8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_0009;\n\tv3 = ~t.<active>k__BackingField;\n\tif (v3) goto L_0009;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]) = lockPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+150]) = closePath;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+14C]) = lockRotation;\nL_0009:\n\treturn t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, bool closePath, AxisConstraint lockPosition = AxisConstraint.None, AxisConstraint lockRotation = AxisConstraint.None)
		{
			if (t == null || t._003Cactive_003Ek__BackingField)
			{
			}
			return t;
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xC1C1D8", Offset = "0xC1C1D8", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = t == 0;\n\tif (v9) goto L_0017;\n\tv11 = ~t.<active>k__BackingField;\n\tif (v11) goto L_0017;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+154]) = lookAtPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+158]) = lookAtPosition.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+15C]) = lookAtPosition.z;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]) = 3;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+192]) = 0;\n\tDG.Tweening.TweenSettingsExtensions::SetPathForwardDirection(t, forwardDirection, up);\nL_0017:\n\treturn t;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				_ = lookAtPosition.y;
				_ = lookAtPosition.z;
				_ = 3;
				_ = 0;
				t.SetPathForwardDirection(forwardDirection, up);
			}
			return t;
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xC1C290", Offset = "0xC1C290", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = t == 0;\n\tif (v9) goto L_001C;\n\tv11 = ~t.<active>k__BackingField;\n\tif (v11) goto L_001C;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+154]) = lookAtPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+158]) = lookAtPosition.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+15C]) = lookAtPosition.z;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]) = 3;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+192]) = stableZRotation;\n\tDG.Tweening.TweenSettingsExtensions::SetPathForwardDirection(t, 0, 0);\nL_001C:\n\treturn t;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, bool stableZRotation)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				_ = lookAtPosition.y;
				_ = lookAtPosition.z;
				_ = 3;
				t.SetPathForwardDirection();
			}
			return t;
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xC1C2E4", Offset = "0xC1C2E4", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([1A35519]) == 0;\n\tif (v30) goto L_001B;\n\tv31 = t == 0;\n\tv32 = ~v31;\n\tif (v32) goto L_001F;\n\tgoto L_003E;\nL_001B:\n\t*([1A35519]) = 1;\n\tv48 = t == 0;\n\tif (v48) goto L_003E;\nL_001F:\n\tv52 = ~t.<active>k__BackingField;\n\tif (v52) goto L_003E;\n\tv87 = UnityEngine.Vector3;\n\tv75 = *([v87 @ X8_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]) = 2;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+160]) = lookAtTransform;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+154]) = v75.zeroVector;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+15C]) = *([v75 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+192]) = 0;\n\tDG.Tweening.TweenSettingsExtensions::SetPathForwardDirection(t, forwardDirection, up);\nL_003E:\n\treturn t;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, Vector3? forwardDirection = null, Vector3? up = null)
		{
			//IL_00a1: Expected I, but got O
			//IL_00aa: Expected I, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35519]");
			if ((nint)0 != 0)
			{
				if (t != null)
				{
					goto IL_0075;
				}
			}
			else
			{
				_ = 1;
				if (t != null)
				{
					goto IL_0075;
				}
			}
			goto IL_00e4;
			IL_00e4:
			return t;
			IL_0075:
			if (t._003Cactive_003Ek__BackingField)
			{
				nint num = (nint)typeof(Vector3);
				nint num2 = (nint)Vector3.zero;
				_ = 2;
				_ = Vector3.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				_ = 0;
				t.SetPathForwardDirection(forwardDirection, up);
			}
			goto IL_00e4;
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0xC1C3A4", Offset = "0xC1C3A4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv21 = UnityEngine.Vector3;\n\tv22 = \"il2cpp_codegen_initialize_runtime_metadata\"(v21, lookAtTransform, stableZRotation, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35519]) = v38;\nL_0024:\n\treturnVal1 = DG.Tweening.TweenSettingsExtensions::SetLookAt(t, 2, v48.zeroVector, lookAtTransform, -1f, 0, 0, 0);\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, bool stableZRotation)
		{
			return t.SetLookAt(OrientType.LookAtTransform, Vector3.zero, lookAtTransform, -1f);
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0xC1C434", Offset = "0xC1C434", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv33 = UnityEngine.Vector3;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v33, forwardDirection, up, methodInfo, v19, v35, v36, v37, lookAhead, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A35519]) = v47;\nL_002A:\n\treturnVal1 = DG.Tweening.TweenSettingsExtensions::SetLookAt(t, 1, v57.zeroVector, 0, lookAhead, forwardDirection, up, methodInfo);\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, Vector3? forwardDirection = null, Vector3? up = null)
		{
			IntPtr intPtr = default(IntPtr);
			return t.SetLookAt(OrientType.ToPath, Vector3.zero, null, lookAhead, forwardDirection, up, (byte)(nint)intPtr != 0);
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0xC1C4E0", Offset = "0xC1C4E0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv21 = UnityEngine.Vector3;\n\tv22 = \"il2cpp_codegen_initialize_runtime_metadata\"(v21, stableZRotation, methodInfo, v24, v25, v26, v27, v28, lookAhead, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35519]) = v38;\nL_0024:\n\treturnVal1 = DG.Tweening.TweenSettingsExtensions::SetLookAt(t, 1, v48.zeroVector, 0, lookAhead, 0, 0, 0);\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, bool stableZRotation)
		{
			return t.SetLookAt(OrientType.ToPath, Vector3.zero, null, lookAhead);
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0xC1C218", Offset = "0xC1C218", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = t == 0;\n\tif (v9) goto L_0036;\n\tv11 = ~t.<active>k__BackingField;\n\tif (v11) goto L_0036;\n\tv63 = v69 & 1;\n\tv74 = orientType == 1;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]) = orientType;\n\tif (v74) goto L_0026;\n\tv88 = orientType != 2;\n\tif (v88) goto L_002D;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+160]) = lookAtTransform;\n\tgoto L_002D;\nL_0026:\n\tv91 = UnityEngine.Mathf::Max(lookAhead, 0.0001f);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+168]) = v91;\nL_002D:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+154]) = lookAtPosition;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+158]) = lookAtPosition.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+15C]) = lookAtPosition.z;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+192]) = v63;\n\tDG.Tweening.TweenSettingsExtensions::SetPathForwardDirection(t, forwardDirection, up);\nL_0036:\n\treturn t;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, OrientType orientType, Vector3 lookAtPosition, Transform lookAtTransform, float lookAhead, Vector3? forwardDirection = null, Vector3? up = null, bool stableZRotation = false)
		{
			if (t != null && t._003Cactive_003Ek__BackingField)
			{
				object obj = default(object);
				int num = (int)((nint)obj & 1);
				switch (orientType)
				{
				case OrientType.ToPath:
				{
					float num2 = Mathf.Max(lookAhead, 0.0001f);
					break;
				}
				}
				_ = lookAtPosition.y;
				_ = lookAtPosition.z;
				t.SetPathForwardDirection(forwardDirection, up);
			}
			return t;
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0xC1C570", Offset = "0xC1C570", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, forwardDirection, up, methodInfo, v29, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, forwardDirection, up, methodInfo, v29, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv182 = Il2CppMethodInfo;\n\tv183 = \"il2cpp_codegen_initialize_runtime_metadata\"(v182, forwardDirection, up, methodInfo, v29, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv193 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, forwardDirection, up, methodInfo, v29, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv62 = 1;\n\t*([1A35751]) = v62;\nL_002B:\n\tv63 = t == 0;\n\tif (v63) goto L_0123;\n\tv68 = ~t.<active>k__BackingField;\n\tif (v68) goto L_0123;\n\tv184 = up >> 0x20;\n\tv186 = forwardDirection >> 0x20;\n\tv187 = forwardDirection & 0xFF;\n\tv189 = v187 == 0;\n\tif (v189) goto L_0061;\n\tgoto L_0048;\n\tv234 = UnityEngine.Vector3;\n\tv235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v234, forwardDirection, up, methodInfo, v29, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv237 = 1;\n\t*([1A35519]) = v237;\nL_0048:\n\tv238 = UnityEngine.Vector3;\n\tv227 = *([v238 @ X8_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv242 = v186 - v227.zeroVector;\n\tv243 = up - *([v227 @ X8_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+4]);\n\tv208 = v184 - *([v227 @ X8_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv244 = v242 * v242;\n\tv245 = v243 * v243;\n\tv246 = v245 + v244;\n\tv210 = v208 * v208;\n\tv212 = v210 + v246;\n\tv198 = v212 >= 9.9999994E-11f;\n\tif (v198) goto L_FFFFFFFF;\nL_0061:\n\tv228 = methodInfo & 0xFF;\n\tv230 = v228 == 0;\n\tif (v230) goto L_FFFFFFFF;\n\tv249 = methodInfo >> 0x20;\n\tgoto L_0073;\n\tv257 = UnityEngine.Vector3;\n\tv258 = \"il2cpp_codegen_initialize_runtime_metadata\"(v257, forwardDirection, up, methodInfo, v29, v48, v49, v50, v211, v209, v207, v213, v55, v56, v57, v58);\n\tv261 = 1;\n\t*([1A35519]) = v261;\nL_0073:\n\tv262 = UnityEngine.Vector3;\n\tv264 = *([v262 @ X8_v41 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv267 = v249 - v264.zeroVector;\n\tv268 = v29 - *([v264 @ X8_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+4]);\n\tv269 = v267 * v267;\n\tv270 = v268 * v268;\n\tv271 = v270 + v269;\n\tv274 = v273 + v271;\n\tv277 = v274 - 9.9999994E-11f;\n\tv278 = v277 < 0;\n\tv284 = ~v278;\n\tgoto L_008E;\n\tgoto L_008E;\nL_008E:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+16C]) = v165;\n\tv156 = ~v165;\n\tif (v156) goto L_0123;\n\tgoto L_009A;\n\tv291 = UnityEngine.Vector3;\n\tv292 = \"il2cpp_codegen_initialize_runtime_metadata\"(v291, forwardDirection, up, methodInfo, v29, v48, v49, v50, v112, v109, v106, v115, v55, v56, v57, v58);\n\tv295 = 1;\n\t*([1A35519]) = v295;\nL_009A:\n\tv296 = forwardDirection & 0xFF;\n\tv298 = v296 == 0;\n\tif (v298) goto L_00DF;\n\tv301 = UnityEngine.Vector3;\n\tv303 = *([v301 @ X8_v25 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv307 = v186 - v303.zeroVector;\n\tv308 = up - *([v303 @ X8_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+4]);\n\tv309 = v184 - *([v303 @ X8_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv310 = v307 * v307;\n\tv311 = v308 * v308;\n\tv312 = v311 + v310;\n\tv313 = v309 * v309;\n\tv314 = v313 + v312;\n\tv324 = v314 >= 9.9999994E-11f;\n\tif (v324) goto L_00D4;\n\tgoto L_00CC;\n\tv391 = v162;\n\tv392 = \"il2cpp_codegen_initialize_runtime_metadata\"(v391, forwardDirection, up, methodInfo, v29, v48, v49, v50, v314, v313, v309, v302, v55, v56, v57, v58);\n\tv415 = UnityEngine.Vector3;\n\tv393 = 1;\n\t*([1A3559C]) = v393;\n\tv396 = *([v415 @ X8_v34+B8]);\nL_00CC:\n\tSystem.Nullable`1<UnityEngine.Vector3>::.ctor(&v372 @ stack_-80_v5 (System.Nullable`1<UnityEngine.Vector3>), v395.forwardVector);\n\tv350 = forwardDirection == 0;\n\tif (v350) goto L_00DF;\nL_00D4:\n\tv379 = System.Nullable`1<UnityEngine.Vector3>::get_Value(&v372 @ stack_-80_v5 (System.Nullable`1<UnityEngine.Vector3>));\n\tgoto L_00EB;\nL_00DF:\n\tgoto L_00E5;\n\tv381 = UnityEngine.Vector3;\n\tv382 = \"il2cpp_codegen_initialize_runtime_metadata\"(v381, v327, up, methodInfo, v29, v48, v49, v50, v338, v336, v334, v340, v55, v56, v57, v58);\n\tv385 = 1;\n\t*([1A3559C]) = v385;\nL_00E5:\n\tv386 = UnityEngine.Vector3;\n\tv387 = *([v386 @ X8_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv145 = v387.forwardVector;\n\tv121 = *([v387 @ X8_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+4C]);\n\tv124 = *([v387 @ X8_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+50]);\nL_00EB:\n\tv414 = methodInfo == 0;\n\tif (v414) goto L_00FC;\n\tv420 = System.Nullable`1<UnityEngine.Vector3>::get_Value(&methodInfo @ X3 (Il2CppMethodInfo));\n\tgoto L_010B;\nL_00FC:\n\tgoto L_0102;\n\tv431 = UnityEngine.Vector3;\n\tv432 = \"il2cpp_codegen_initialize_runtime_metadata\"(v431, v404, up, methodInfo, v29, v48, v49, v50, v407, v406, v405, v408, v55, v56, v57, v58);\n\tv435 = 1;\n\t*([1A3575B]) = v435;\nL_0102:\n\tv436 = UnityEngine.Vector3;\n\tv437 = *([v436 @ X8_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv444 = v437.upVector;\n\tv81 = *([v437 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]);\n\tv79 = *([v437 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]);\nL_010B:\n\t// 267 MakeStruct v73 @ AGGC20868_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v145 @ V8_v4 (UnityEngine.Vector3), v121 @ V9_v4 (System.Single), v124 @ V10_v4 (System.Single)\n\t// 268 MakeStruct v70 @ AGGC20868_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v444 @ V3_v4 (UnityEngine.Vector3), v81 @ V4_v2 (System.Single), v79 @ V5_v2 (System.Single)\n\tv111 = UnityEngine.Quaternion::LookRotation(v73, v70);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+170]) = v111;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+174]) = v111.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+178]) = v111.z;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+17C]) = v111.w;\nL_0123:\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void SetPathForwardDirection(this TweenerCore<Vector3, Path, PathOptions> t, Vector3? forwardDirection = null, Vector3? up = null)
		{
			//IL_0031: Expected I4, but got O
			//IL_003f: Expected I4, but got O
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected I4, but got Unknown
			//IL_023f: Expected I, but got O
			//IL_0248: Expected I, but got O
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Expected O, but got Unknown
			//IL_0288: Expected O, but got I
			//IL_02a6: Expected O, but got I
			//IL_02c4: Expected O, but got I
			//IL_0303: Expected I, but got O
			//IL_030c: Expected I, but got O
			//IL_0338: Expected O, but got I
			//IL_0356: Expected O, but got I
			//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d9: Expected I4, but got Unknown
			//IL_044c: Expected I, but got O
			//IL_0455: Expected I, but got O
			//IL_046e: Expected F4, but got I
			//IL_047e: Expected F4, but got I
			//IL_00de: Expected I, but got O
			//IL_00e7: Expected I, but got O
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_0127: Expected O, but got I
			//IL_0145: Expected O, but got I
			//IL_0163: Expected O, but got I
			//IL_0522: Expected I, but got O
			//IL_052b: Expected I, but got O
			//IL_0544: Expected F4, but got I
			//IL_0554: Expected F4, but got I
			if (t == null || !t._003Cactive_003Ek__BackingField)
			{
				return;
			}
			int num = (object?)up >> 32;
			int num2 = (object?)forwardDirection >> 32;
			bool flag;
			if (((_003F?)forwardDirection & 0xFF) != 0)
			{
				nint num3 = (nint)typeof(Vector3);
				nint num4 = (nint)Vector3.zero;
				float num5 = (float)num2 - Vector3.zero.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
				object obj = (_003F?)up - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				object obj2 = (nint)num - (nint)0;
				float num6 = num5 * num5;
				object obj3 = (nint)obj * (nint)obj;
				float num7 = (float)obj3 + num6;
				object obj4 = (nint)obj2 * (nint)obj2;
				float num8 = (float)obj4 + num7;
				if (!(num8 < 9.9999994E-11f))
				{
					flag = true;
					goto IL_03ad;
				}
			}
			IntPtr intPtr = default(IntPtr);
			if ((int)((nint)intPtr & 0xFF) != 0)
			{
				int num9 = (int)((nint)intPtr >> 32);
				nint num10 = (nint)typeof(Vector3);
				nint num11 = (nint)Vector3.zero;
				float num12 = (float)num9 - Vector3.zero.x;
				object obj5 = default(object);
				nint num13 = (nint)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ X8_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
				object obj6 = num13 - 0;
				float num14 = num12 * num12;
				object obj7 = (nint)obj6 * (nint)obj6;
				float num15 = (float)obj7 + num14;
				object obj8 = default(object);
				float num16 = (float)obj8 + num15;
				float num17 = num16 - 9.9999994E-11f;
				bool flag2 = num17 < 0f;
				bool flag3 = !flag2;
				flag = flag3;
			}
			else
			{
				flag = false;
			}
			goto IL_03ad;
			IL_03ad:
			if (!flag)
			{
				return;
			}
			float y;
			float z;
			Vector3 vector2;
			if (((_003F?)forwardDirection & 0xFF) != 0)
			{
				nint num18 = (nint)typeof(Vector3);
				nint num19 = (nint)Vector3.zero;
				float num20 = (float)num2 - Vector3.zero.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ X8_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
				object obj9 = (_003F?)up - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ X8_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				object obj10 = (nint)num - (nint)0;
				float num21 = num20 * num20;
				object obj11 = (nint)obj9 * (nint)obj9;
				float num22 = (float)obj11 + num21;
				object obj12 = (nint)obj10 * (nint)obj10;
				float num23 = (float)obj12 + num22;
				bool flag4 = !(num23 < 9.9999994E-11f);
				Vector3? vector = forwardDirection;
				if (!flag4)
				{
					vector = Vector3.forward;
					if ((object)forwardDirection == null)
					{
						goto IL_043e;
					}
				}
				Vector3 value = vector.Value;
				y = value.y;
				z = value.z;
				vector2 = value;
				goto IL_0421;
			}
			goto IL_043e;
			IL_043e:
			nint num24 = (nint)typeof(Vector3);
			nint num25 = (nint)Vector3.zero;
			vector2 = Vector3.forward;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X8_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+4C]");
			y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X8_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
			z = 0f;
			goto IL_0421;
			IL_0421:
			float z2;
			float y2;
			Vector3 vector3;
			if (intPtr != (IntPtr)0)
			{
				Vector3 value2 = ((Vector3?*)(&intPtr))->Value;
				z2 = value2.z;
				y2 = value2.y;
				vector3 = value2;
			}
			else
			{
				nint num26 = (nint)typeof(Vector3);
				nint num27 = (nint)Vector3.zero;
				vector3 = Vector3.upVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				y2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				z2 = 0f;
			}
			Vector3 forward = default(Vector3);
			forward.x = vector2.x;
			forward.y = y;
			forward.z = z;
			Vector3 upwards = default(Vector3);
			upwards.x = vector3.x;
			upwards.y = y2;
			upwards.z = z2;
			Quaternion quaternion = Quaternion.LookRotation(forward, upwards);
			_ = quaternion.y;
			_ = quaternion.z;
			_ = quaternion.w;
		}
	}
}
