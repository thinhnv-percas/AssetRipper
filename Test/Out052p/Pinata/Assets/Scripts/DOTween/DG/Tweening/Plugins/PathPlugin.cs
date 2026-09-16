using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000022")]
	public class PathPlugin : ABSTweenPlugin<Vector3, Path, PathOptions>
	{
		[Token(Token = "0x40000D0")]
		public const float MinLookAhead = 0.0001f;

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0x10D8590", Offset = "0x10D8590", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.Plugins.Core.PathCore.Path::Destroy(t.endValue);\n\tt.endValue = 0;\n\tt.changeValue = 0;\n\tt.startValue = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<Vector3, Path, PathOptions> t)
		{
			t.endValue.Destroy();
			t.endValue = null;
			t.changeValue = null;
			t.startValue = null;
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0x10D85D0", Offset = "0x10D85D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, bool isRelative)
		{
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0x10D85D4", Offset = "0x10D85D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, Path fromValue, bool setImmediately)
		{
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0x10D85D8", Offset = "0x10D85D8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EC7DE8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20274B2]) = v35;\nL_0018:\n\treturnVal1 = DG.Tweening.Plugins.Core.PluginsManager::GetCustomPlugin();\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ABSTweenPlugin<Vector3, Path, PathOptions> Get()
		{
			return PluginsManager.GetCustomPlugin<PathPlugin, Vector3, Path, PathOptions>();
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0x10D8620", Offset = "0x10D8620", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn t.endValue;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Path ConvertToStartValue(TweenerCore<Vector3, Path, PathOptions> t, Vector3 value)
		{
			return t.endValue;
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0x10D863C", Offset = "0x10D863C", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv38 = *([1EE4C70]);\n\tv39 = *([v38 @ X8_v19]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 0 | 1;\n\t*([20274B3]) = v58;\nL_001F:\n\tv60 = t.endValue;\n\tv177 = ~v60.isFinalized;\n\tv178 = ~v177;\n\tif (v178) goto L_0097;\n\tv155 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv329 = t.endValue;\n\tv137 = v329.wps;\n\tv227 = v137.Length < 1;\n\tif (v227) goto L_0097;\nL_004A:\n\tv171 = v329.wps;\n\tv330 = v95 < v171.Length;\n\tv306 = ~v330;\n\tif (v306) goto L_0098;\n\tv89 = v171 + v174;\n\tgoto L_006D;\n\tv336 = *([v331 @ X0_v11+E0]);\n\tv337 = v336 == 0;\n\tv338 = ~v337;\n\tif (v338) goto L_006D;\n\tv340 = \"il2cpp_codegen_runtime_class_init\"(v331, v158, methodInfo, v42, v43, v44, v45, v46, v156, v152, v148, v78, v75, v72, v53, v54);\nL_006D:\n\t// 109 MakeStruct v67 @ AGG10D8740_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v89 @ X24_v6+20], [v89 @ X24_v6+24], [v89 @ X24_v6+28]\n\tv154 = UnityEngine.Vector3::op_Addition(v67, v155);\n\tv95 = v95 + 1;\n\t*([v89 @ X24_v6+20]) = v154;\n\t*([v89 @ X24_v6+24]) = v154.y;\n\t*([v89 @ X24_v6+28]) = v154.z;\n\tv99 = v95 >= v137.Length;\n\tif (v99) goto L_0097;\n\tv329 = t.endValue;\n\tv174 = v174 + 0xC;\n\tv345 = t.endValue == 0;\n\tv164 = ~v345;\n\tif (v164) goto L_004A;\n\tthrow System.NullReferenceException;\nL_0097:\n\treturn;\nL_0098:\n\tv335 = new System.IndexOutOfRangeException();\n\tthrow v335;\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector3, Path, PathOptions> t)
		{
			//IL_00e4: Expected O, but got I
			//IL_0101: Expected F4, but got I
			//IL_0116: Expected F4, but got I
			//IL_012b: Expected F4, but got I
			Path endValue = t.endValue;
			if (endValue.isFinalized)
			{
				return;
			}
			Vector3 vector = t.getter();
			Path endValue2 = t.endValue;
			Vector3[] wps = endValue2.wps;
			if (wps.Length < 1)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			Vector3 vector2 = default(Vector3);
			do
			{
				Vector3[] wps2 = endValue2.wps;
				if (num < wps2.Length)
				{
					object obj = (long)(IntPtr)wps2 + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X24_v6+20]");
					vector2.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X24_v6+24]");
					vector2.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X24_v6+28]");
					vector2.z = 0f;
					Vector3 vector3 = vector2 + vector;
					num++;
					_ = vector3.y;
					_ = vector3.z;
					if (num < wps.Length)
					{
						endValue2 = t.endValue;
						num2 += 12;
						continue;
					}
					return;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			while (t.endValue != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0x10D879C", Offset = "0x10D879C", Length = "0x40C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv40 = *([1EE7C18]);\n\tv41 = *([v40 @ X8_v64]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, t, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 0 | 1;\n\t*([20274B4]) = v60;\nL_0033:\n\tgoto L_FFFFFFFF;\n\tv396 = v396_asT == 0;\n\tif (v396) goto L_01DD;\n\tgoto L_FFFFFFFF;\n\tv430 = v430_asT == 0;\n\tif (v430) goto L_01DD;\n\tv259 = UnityEngine.Component::get_transform(t.target);\n\tv184 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+13C]) != 1;\n\tif (v184) goto L_0078;\n\tv571 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+178]) == 0;\n\tif (v571) goto L_0078;\n\tv573 = UnityEngine.Transform::get_parent(v259);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+180]) = v573;\nL_0078:\n\tv564 = t.endValue;\n\tv576 = ~v564.isFinalized;\n\tv577 = ~v576;\n\tif (v577) goto L_01C4;\n\tv174 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv159 = t.endValue;\n\tv278 = v159.wps;\n\tv598 = v278.Length == 0;\n\tif (v598) goto L_01D6;\n\tgoto L_00AA;\n\tv648 = *([v601 @ X0_v17+E0]);\n\tv649 = v648 == 0;\n\tv650 = ~v649;\n\tif (v650) goto L_00AA;\n\tv652 = \"il2cpp_codegen_runtime_class_init\"(v601, v245, methodInfo, v44, v45, v46, v47, v48, v174, v168, v162, v52, v53, v54, v55, v56);\nL_00AA:\n\t// 170 MakeStruct v125 @ AGG10D8914_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v278 @ X8_v20 (UnityEngine.Vector3[])+20], [v278 @ X8_v20 (UnityEngine.Vector3[])+24], [v278 @ X8_v20 (UnityEngine.Vector3[])+28]\n\tv261 = DG.Tweening.Core.Utils::Vector3AreApproximatelyEqual(v125, v174);\n\tv657 = ~v261;\n\tv658 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]) == 0;\n\tif (v658) goto L_FFFFFFFF;\n\tv279 = v159.wps;\n\tv637 = v278.Length - 1;\n\tv661 = v637 < v279.Length;\n\tv634 = ~v661;\n\tif (v634) goto L_01D6;\n\tv642 = v637 * 0xC;\n\tv698 = v279 + v642;\n\tv670 = *([v698 @ X10_v16+20]);\n\tv669 = v279[v637 @ X10_v14 (System.Int32)].y;\n\tv671 = v279[v637 @ X10_v14 (System.Int32)].z;\n\tv708 = v159.type != 2;\n\tif (v708) goto L_0111;\n\tv612 = v278.Length <= 2;\n\tif (v612) goto L_0100;\n\tv638 = v278.Length - 3;\n\tv761 = v638 < v279.Length;\n\tv635 = ~v761;\n\tif (v635) goto L_01D6;\n\tv738 = v638 * 0xC;\n\tv741 = v279 + v738;\n\tv670 = *([v741 @ X8_v59+20]);\n\tv669 = v279[v638 @ X10_v18 (System.Int32)].y;\n\tv671 = v279[v638 @ X10_v18 (System.Int32)].z;\n\tgoto L_0111;\n\tgoto L_013C;\nL_0100:\n\tgoto L_010A;\n\tv798 = *([v764 @ X0_v33+E0]);\n\tv799 = v798 == 0;\n\tv800 = ~v799;\n\tif (v800) goto L_010A;\n\tv802 = \"il2cpp_codegen_runtime_class_init\"(v764, v245, methodInfo, v44, v45, v46, v47, v48, v175, v169, v163, v136, v132, v128, v55, v56);\nL_010A:\n\tUnityEngine.Debug::LogError(\"CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)\");\nL_0111:\n\tgoto L_011E;\n\tv768 = *([v744 @ X0_v28+E0]);\n\tv769 = v768 == 0;\n\tv770 = ~v769;\n\tif (v770) goto L_011E;\n\tv772 = \"il2cpp_codegen_runtime_class_init\"(v744, v686, methodInfo, v44, v45, v46, v47, v48, v175, v169, v163, v136, v132, v128, v55, v56);\nL_011E:\n\t// 286 MakeStruct v664 @ AGG10D8A10_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v670 @ V11_v10 (UnityEngine.Vector3), v669 @ V12_v10 (UnityEngine.Vector3), v671 @ V13_v10 (UnityEngine.Vector3)\n\tv690 = UnityEngine.Vector3::op_Inequality(v664, v174);\n\tv807 = v261 == 0;\n\tv811 = ~v807;\n\tif (v811) goto L_FFFFFFFF;\n\tv379 = 1 + 1;\n\tgoto L_0130;\nL_0130:\n\tv680 = v690 == 0;\n\tv675 = ~v680;\n\tv662 = ~v675;\n\tif (v662) goto L_FFFFFFFF;\n\tgoto L_013C;\nL_013C:\n\tv246 = v379 + v278.Length;\n\t// 318 NewArr v262 @ X0_v23 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v246 @ X1_v12 (System.Int32)\n\tv710 = v261 == 0;\n\tv711 = ~v710;\n\tif (v711) goto L_0155;\n\tv643 = v262.Length == 0;\n\tif (v643) goto L_01D6;\n\t*([v262 @ X0_v23 (UnityEngine.Vector3[])+20]) = v174;\n\t*([v262 @ X0_v23 (UnityEngine.Vector3[])+24]) = v174.y;\n\t*([v262 @ X0_v23 (UnityEngine.Vector3[])+28]) = v174.z;\nL_0155:\n\tv760 = v278.Length < 1;\n\tif (v760) goto L_0190;\n\tv778 = v657 * 0xC;\n\tv239 = v262 + v778;\nL_015D:\n\tv105 = v159.wps;\n\tv825 = v280 < v105.Length;\n\tv364 = ~v825;\n\tif (v364) goto L_01D6;\n\tv605 = v657 + v280;\n\tv834 = v605 < v262.Length;\n\tv636 = ~v834;\n\tif (v636) goto L_01D6;\n\tv837 = v105 + v110;\n\tv280 = v280 + 1;\n\tv782 = v239 + v110;\n\tv110 = v110 + 0xC;\n\t*([v782 @ X13_v10]) = *([v837 @ X12_v12]);\n\t*([v782 @ X13_v10+4]) = *([v837 @ X12_v12+4]);\n\t*([v782 @ X13_v10+8]) = *([v837 @ X12_v12+8]);\n\tv785 = v280 < v278.Length;\n\tif (v785) goto L_015D;\nL_0190:\n\tv797 = v101 == 0;\n\tif (v797) goto L_01A5;\n\tv644 = v262.Length == 0;\n\tif (v644) goto L_01D6;\n\tv818 = v262 + 0x20;\n\tv816 = v262.Length << 0x20;\n\tv829 = 0xFFFFFFFF00000000 + v816;\n\tv830 = v829 >> 0x20;\n\tv820 = v830 * 0xC;\n\tv822 = v818 + v820;\n\t*([v822 @ X8_v33]) = *([v262 @ X0_v23 (UnityEngine.Vector3[])+20]);\n\t*([v822 @ X8_v33+8]) = *([v262 @ X0_v23 (UnityEngine.Vector3[])+28]);\nL_01A5:\n\tv159.wps = v262;\n\tv159.addedExtraStartWp = v657;\n\tv159.addedExtraEndWp = v101;\n\tDG.Tweening.Plugins.Core.PathCore.Path::FinalizePath(v159, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+140]), v174);\n\tv833 = UnityEngine.Transform::get_rotation(v259);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+18C]) = v833;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+190]) = v833.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+194]) = v833.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+198]) = v833.w;\n\tv593 = UnityEngine.Transform::get_eulerAngles(v259);\n\tv564 = t.endValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+19C]) = v593.z;\nL_01C4:\n\tt.changeValue = v564;\n\treturn;\nL_01D6:\n\tv647 = new System.IndexOutOfRangeException();\n\tthrow v647;\n\tv286 = new System.NullReferenceException();\n\tv382 = new System.NullReferenceException();\nL_01DD:\n\tthrow System.InvalidCastException;\n// 328 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector3, Path, PathOptions> t)
		{
			//IL_017b: Expected F4, but got I
			//IL_0190: Expected F4, but got I
			//IL_01a5: Expected F4, but got I
			//IL_04b3: Expected O, but got I
			//IL_024d: Expected O, but got I
			//IL_025d: Expected O, but got I
			//IL_0273: Expected O, but got F4
			//IL_0289: Expected O, but got F4
			//IL_05f1: Expected O, but got I
			//IL_0613: Expected O, but got I8
			//IL_063e: Expected O, but got I
			//IL_064e: Expected O, but got I
			//IL_0539: Expected O, but got I
			//IL_0558: Expected O, but got I
			//IL_0325: Expected O, but got I
			//IL_0335: Expected O, but got I
			//IL_034b: Expected O, but got F4
			//IL_0361: Expected O, but got F4
			Component component = t.target as Component;
			Transform transform;
			Path endValue;
			Vector3 vector;
			Path endValue2;
			bool flag2;
			bool flag4;
			Vector3[] array;
			if ((object)component != null)
			{
				Component component2 = t.target as Component;
				if ((object)component2 != null)
				{
					transform = ((Component)t.target).transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+13C]");
					if ((IntPtr)0 == (IntPtr)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+178]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Transform parent = transform.parent;
						}
					}
					endValue = t.endValue;
					if (!endValue.isFinalized)
					{
						vector = t.getter();
						endValue2 = t.endValue;
						Vector3[] wps = endValue2.wps;
						if (wps.Length != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v20 (UnityEngine.Vector3[])+20]");
							Vector3 a = default(Vector3);
							a.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v20 (UnityEngine.Vector3[])+24]");
							a.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v20 (UnityEngine.Vector3[])+28]");
							a.z = 0f;
							bool flag = Utils.Vector3AreApproximatelyEqual(a, vector);
							flag2 = !flag;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]");
							int num5;
							if ((IntPtr)0 != (IntPtr)0)
							{
								Vector3[] wps2 = endValue2.wps;
								int num = wps.Length - 1;
								if (num >= wps2.Length)
								{
									goto IL_06be;
								}
								int num2 = num * 12;
								object obj = (long)(IntPtr)wps2 + (long)num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X10_v16+20]");
								Vector3 vector2 = (Vector3)0;
								Vector3 vector3 = (Vector3)wps2[num].y;
								Vector3 vector4 = (Vector3)wps2[num].z;
								if (endValue2.type == PathType.CubicBezier)
								{
									if (wps.Length > 2)
									{
										int num3 = wps.Length - 3;
										if (num3 >= wps2.Length)
										{
											goto IL_06be;
										}
										int num4 = num3 * 12;
										object obj2 = (long)(IntPtr)wps2 + (long)num4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ X8_v59+20]");
										vector2 = (Vector3)0;
										vector3 = (Vector3)wps2[num3].y;
										vector4 = (Vector3)wps2[num3].z;
									}
									else
									{
										Debug.LogError("CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)");
									}
								}
								Vector3 vector5 = default(Vector3);
								vector5.x = vector2.x;
								vector5.y = vector3.x;
								vector5.z = vector4.x;
								bool flag3 = vector5 != vector;
								num5 = (flag ? 1 : (1 + 1));
								if (flag3)
								{
									flag4 = flag3;
								}
								else
								{
									flag4 = flag3;
									num5 = (flag2 ? 1 : 0);
								}
							}
							else
							{
								flag4 = false;
								num5 = (flag2 ? 1 : 0);
							}
							int num6 = num5 + wps.Length;
							array = new Vector3[num6];
							if (!flag)
							{
								if (array.Length == 0)
								{
									goto IL_06be;
								}
								_ = vector.y;
								_ = vector.z;
							}
							if (wps.Length < 1)
							{
								goto IL_05a6;
							}
							int num7 = (flag2 ? 1 : 0) * 12;
							object obj3 = (long)(IntPtr)array + (long)num7;
							int num8 = 32;
							int num9 = 0;
							while (true)
							{
								Vector3[] wps3 = endValue2.wps;
								if (num9 >= wps3.Length)
								{
									break;
								}
								int num10 = (flag2 ? 1 : 0) + num9;
								if (num10 >= array.Length)
								{
									break;
								}
								object obj4 = (long)(IntPtr)wps3 + (long)num8;
								num9++;
								object obj5 = (long)(IntPtr)obj3 + (long)num8;
								num8 += 12;
								obj5 = obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ X12_v12+4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ X12_v12+8]");
								_ = 0;
								if (num9 < wps.Length)
								{
									continue;
								}
								goto IL_05a6;
							}
						}
						goto IL_06be;
					}
					goto IL_06e4;
				}
			}
			throw new InvalidCastException();
			IL_05a6:
			if (flag4)
			{
				if (array.Length == 0)
				{
					goto IL_06be;
				}
				object obj6 = (long)(IntPtr)array + 32L;
				int num11 = array.Length << 32;
				object obj7 = -4294967296L + num11;
				int num12 = (int)((long)(IntPtr)obj7 >> 32);
				int num13 = num12 * 12;
				object obj8 = (long)(IntPtr)obj6 + (long)num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ X0_v23 (UnityEngine.Vector3[])+20]");
				obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ X0_v23 (UnityEngine.Vector3[])+28]");
				_ = 0;
			}
			endValue2.wps = array;
			endValue2.addedExtraStartWp = flag2;
			endValue2.addedExtraEndWp = flag4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+140]");
			endValue2.FinalizePath((byte)(long)intPtr != 0, AxisConstraint.None, vector);
			Quaternion rotation = transform.rotation;
			_ = rotation.y;
			_ = rotation.z;
			_ = rotation.w;
			Vector3 eulerAngles = transform.eulerAngles;
			endValue = t.endValue;
			_ = eulerAngles.z;
			goto IL_06e4;
			IL_06be:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_06e4:
			t.changeValue = endValue;
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0x10D8BA8", Offset = "0x10D8BA8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue.length / unitsXSecond;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn unitsXSecond;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(PathOptions options, float unitsXSecond, Path changeValue)
		{
			return changeValue.length / unitsXSecond;
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0x10D8BC8", Offset = "0x10D8BC8", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_002C;\n\tv44 = *([1EAEC08]);\n\tv45 = *([v44 @ X8_v28]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v50, v51, v52, v53, v54, v55);\n\tv59 = 0 | 1;\n\t*([20274B5]) = v59;\nL_002C:\n\tv71 = t.loopType != 2;\n\tif (v71) goto L_004F;\n\tv155 = ~options.isClosedPath;\n\tv156 = ~v155;\n\tif (v156) goto L_004F;\n\tv93 = t.completedLoops - t.isComplete;\n\tv101 = v93 < 1;\n\tif (v101) goto L_004F;\n\tv161 = DG.Tweening.Plugins.Core.PathCore.Path::CloneIncremental(changeValue, v93);\nL_004F:\n\tv87 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv246 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToConstantPathPerc(v146, v87);\n\tv88 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(v146, v246, 0);\n\tv146.targetPosition = v88;\n\tv146.targetPosition.y = v88.y;\n\tv146.targetPosition.z = v88.z;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(setter, v88);\n\tv257 = options.mode == 0;\n\tif (v257) goto L_008D;\n\tv259 = options.orientType == 0;\n\tif (v259) goto L_008D;\n\tv273 = 0x6D2410(&v295 @ stack_-D0, options, 0x70, isRelative, getter, setter, startValue, changeValue, v88, v88.y, v88.z, t.easePeriod, v52, v53, v54, v55);\n\tDG.Tweening.Plugins.PathPlugin::SetOrientation(v273, &v295 @ stack_-D0, t, v146, v246, v88, *([v24 @ X29_v1+18]));\nL_008D:\n\tv285 = t.isBackwards == 0;\n\tv291 = v285 ^ *([v24 @ X29_v1+10]);\n\tv292 = v291 & 1;\n\tv293 = DG.Tweening.Plugins.Core.PathCore.Path::GetWaypointIndexFromPerc(v146, v87, v292);\n\tv304 = v293 == t.miscInt;\n\tif (v304) goto L_0137;\n\tt.miscInt = v293;\n\tv310 = t.onWaypointChange == 0;\n\tif (v310) goto L_0137;\n\tv344 = t.loopType != 1;\n\tif (v344) goto L_00C7;\n\tv355 = ~t.isBackwards;\n\tif (v355) goto L_00F2;\n\tv358 = t.loops < 2;\n\tif (v358) goto L_00F9;\n\tv414 = t.completedLoops & 1;\n\tv372 = v414 == 0;\n\tif (v372) goto L_00C9;\n\tgoto L_00F9;\nL_00C7:\n\tv356 = ~t.isBackwards;\n\tif (v356) goto L_00F9;\nL_00C9:\n\tv377 = t.miscInt - 1;\n\tv378 = v293 - 1;\n\tv390 = v377 <= v378;\n\tif (v390) goto L_0129;\n\tv420 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, v377);\n\tv460 = t.miscInt - 2;\n\tgoto L_00EE;\nL_00E1:\n\tv481 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, v460);\n\tv460 = v460 - 1;\nL_00EE:\n\tv430 = v460 > v378;\n\tif (v430) goto L_00E1;\n\tgoto L_0129;\nL_00F2:\n\tv360 = t.loops < 2;\n\tif (v360) goto L_00F9;\n\tv415 = t.completedLoops & 1;\n\tv416 = v415 == 0;\n\tv373 = ~v416;\n\tif (v373) goto L_00C9;\nL_00F9:\n\tv403 = t.miscInt + 1;\n\tv413 = v403 >= v293;\n\tif (v413) goto L_0129;\n\tv458 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, v403);\n\tv497 = t.miscInt + 2;\n\tv445 = v497 == v293;\n\tif (v445) goto L_0129;\nL_0117:\n\tv456 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, v497);\n\tv497 = v497 + 1;\n\tv429 = v293 != v497;\n\tif (v429) goto L_0117;\nL_0129:\n\tv324 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, v293);\nL_0137:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 232 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(PathOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Path startValue, Path changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_01b5: Expected O, but got Ref
			object obj2 = default(object);
			object obj = obj2;
			bool flag = t.loopType != LoopType.Incremental;
			Path path = changeValue;
			if (!flag)
			{
				bool flag2 = !options.isClosedPath;
				bool flag3 = !flag2;
				path = changeValue;
				if (!flag3)
				{
					int num = t.completedLoops - (t.isComplete ? 1 : 0);
					bool flag4 = num < 1;
					path = changeValue;
					if (!flag4)
					{
						Path path2 = changeValue.CloneIncremental(num);
						path = path2;
					}
				}
			}
			float perc = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num2 = path.ConvertToConstantPathPerc(perc);
			Vector3 vector = (path.targetPosition = path.GetPoint(num2));
			path.targetPosition.y = vector.y;
			path.targetPosition.z = vector.z;
			setter(vector);
			if (options.mode != PathMode.Ignore && options.orientType != OrientType.None)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				Path path3 = path;
				Vector3 tPos = vector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
				PathPlugin pathPlugin = default(PathPlugin);
				object obj3 = default(object);
				pathPlugin.SetOrientation((PathOptions)(&obj3), t, path3, num2, tPos, UpdateNotice.None);
			}
			bool flag5 = !t.isBackwards;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			int num3 = (int)((long)(flag5 ? 1 : 0) ^ 0L);
			bool isMovingForward = (byte)(num3 & 1) != 0;
			int waypointIndexFromPerc = path.GetWaypointIndexFromPerc(perc, isMovingForward);
			if (waypointIndexFromPerc == t.miscInt)
			{
				return;
			}
			t.miscInt = waypointIndexFromPerc;
			if (t.onWaypointChange == null)
			{
				return;
			}
			if (t.loopType == LoopType.Yoyo)
			{
				if (t.isBackwards)
				{
					if (t.loops >= 2 && (t.completedLoops & 1) == 0)
					{
						goto IL_030e;
					}
				}
				else if (t.loops >= 2 && (t.completedLoops & 1) != 0)
				{
					goto IL_030e;
				}
			}
			else if (t.isBackwards)
			{
				goto IL_030e;
			}
			int num4 = t.miscInt + 1;
			if (num4 < waypointIndexFromPerc)
			{
				bool flag6 = Tween.OnTweenCallback(t.onWaypointChange, num4);
				int num5 = t.miscInt + 2;
				if (num5 != waypointIndexFromPerc)
				{
					do
					{
						bool flag7 = Tween.OnTweenCallback(t.onWaypointChange, num5);
						num5++;
					}
					while (waypointIndexFromPerc != num5);
				}
			}
			goto IL_04c1;
			IL_030e:
			int num6 = t.miscInt - 1;
			int num7 = waypointIndexFromPerc - 1;
			if (num6 > num7)
			{
				bool flag8 = Tween.OnTweenCallback(t.onWaypointChange, num6);
				for (int num8 = t.miscInt - 2; num8 > num7; num8--)
				{
					bool flag9 = Tween.OnTweenCallback(t.onWaypointChange, num8);
				}
			}
			goto IL_04c1;
			IL_04c1:
			bool flag10 = Tween.OnTweenCallback(t.onWaypointChange, waypointIndexFromPerc);
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0x10D8E84", Offset = "0x10D8E84", Length = "0xA20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = &v38 @ stack_-10_v2;\n\tgoto L_003E;\n\tv58 = *([1EBED00]);\n\tv59 = *([v58 @ X8_v131]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, options, t, path, updateNotice, methodInfo, v62, v63, pathPerc, tPos, v0, v2, v64, v65, v66, v67);\n\tv71 = 0 | 1;\n\t*([20274B6]) = v71;\nL_003E:\n\tgoto L_FFFFFFFF;\n\tv624 = v624_asT == 0;\n\tif (v624) goto L_0465;\n\tgoto L_FFFFFFFF;\n\tv626 = v626_asT == 0;\n\tif (v626) goto L_0465;\n\tv806 = UnityEngine.Component::get_transform(t.target);\n\tgoto L_007C;\n\tv1066 = *([v386 @ X8_v51+E0]);\n\tv1067 = v1066 == 0;\n\tv1068 = ~v1067;\n\tif (v1068) goto L_007C;\n\tv1087 = v386;\n\tv1070 = \"il2cpp_codegen_runtime_class_init\"(v1087, v329, t, path, updateNotice, methodInfo, v62, v63, pathPerc, tPos, v0, v2, v64, v65, v66, v67);\nL_007C:\n\tv208 = UnityEngine.Quaternion::get_identity();\n\tv227 = updateNotice != 1;\n\tif (v227) goto L_009E;\n\tv1351 = options.startupRot;\n\tv1349 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+58]);\n\tv1363 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+5C]);\n\tv1361 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+60]);\n\tUnityEngine.Transform::set_rotation(v806, options.startupRot);\nL_009E:\n\tv280 = options.orientType == 1;\n\tif (v280) goto L_00D5;\n\tv283 = options.orientType == 2;\n\tif (v283) goto L_0136;\n\tv228 = options.orientType != 3;\n\tif (v228) goto L_039A;\n\tv162 = 0;\n\tv347 = 0x115D2C0(&v162 @ stack_-A0_v13 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, t, path, updateNotice, methodInfo, v62, v63, options.lookAtPosition, *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+18]), *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+1C]), v1361, v903, v901, v839, v837);\n\tpath.lookAtPosition = 0;\n\t*([path @ X3 (DG.Tweening.Plugins.Core.PathCore.Path)+94]) = 0;\n\tv1727 = options.lookAtPosition;\n\tv1726 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+18]);\n\tv1725 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+1C]);\n\tgoto L_0165;\nL_00D5:\n\tv1176 = options.lookAhead < 0.0001f;\n\tv314 = ~v1176;\n\tv303 = options.lookAhead - 0.0001f;\n\tv281 = v303 == 0;\n\tv1177 = ~v281;\n\tv229 = v314 & v1177;\n\tif (v229) goto L_0195;\n\tv1297 = path.type == 0;\n\tv1298 = ~v1297;\n\tif (v1298) goto L_0195;\n\tv390 = path.wps;\n\tv1483 = path.linearWPIndex < v390.Length;\n\tv315 = ~v1483;\n\tif (v315) goto L_0467;\n\tv1692 = path.linearWPIndex * 0xC;\n\tv1693 = v390 + v1692;\n\tgoto L_010D;\n\tv1740 = *([v1694 @ X0_v112+E0]);\n\tv1741 = v1740 == 0;\n\tv1742 = ~v1741;\n\tif (v1742) goto L_010D;\n\tv1744 = \"il2cpp_codegen_runtime_class_init\"(v1694, v331, t, path, updateNotice, methodInfo, v62, v63, v211, v199, v410, v402, v64, v65, v66, v67);\nL_010D:\n\t// 269 MakeStruct v135 @ AGG10D90A4_1_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1693 @ X8_v106+20], v390[path.linearWPIndex (System.Int32)].y (System.Single), v390[path.linearWPIndex (System.Int32)].z (System.Single)\n\tv212 = UnityEngine.Vector3::op_Addition(tPos, v135);\n\tv391 = path.wps;\n\tv709 = path.linearWPIndex - 1;\n\tv1835 = v709 < v391.Length;\n\tv701 = ~v1835;\n\tif (v701) goto L_0467;\n\tv1709 = v709 * 0xC;\n\tv1711 = v391 + v1709;\n\t// 298 MakeStruct v1697 @ AGG10D90DC_1_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1711 @ X8_v109+20], v391[v709 @ X9_v36 (System.Int32)].y (System.Single), v391[v709 @ X9_v36 (System.Int32)].z (System.Single)\n\tv215 = UnityEngine.Vector3::op_Subtraction(v212, v1697);\n\tv203 = v215.y;\n\tv414 = v215.z;\n\tgoto L_01C1;\nL_0136:\n\tgoto L_013F;\n\tv1290 = *([v1170 @ X0_v125+E0]);\n\tv1291 = v1290 == 0;\n\tv1292 = ~v1291;\n\tif (v1292) goto L_013F;\n\tv1294 = \"il2cpp_codegen_runtime_class_init\"(v1170, v331, t, path, updateNotice, methodInfo, v62, v63, v210, v198, v410, v402, v64, v65, v66, v67);\nL_013F:\n\tv1264 = UnityEngine.Object::op_Inequality(options.lookAtTransform, 0);\n\tv1267 = v1264 == 0;\n\tif (v1267) goto L_039A;\n\tv213 = UnityEngine.Transform::get_position(options.lookAtTransform);\n\tv162 = 0;\n\tv350 = 0x115D2C0(&v162 @ stack_-A0_v13 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, 0, path, updateNotice, methodInfo, v62, v63, v213, v213.y, v213.z, v1361, v903, v901, v839, v837);\n\tpath.lookAtPosition = 0;\n\t*([path @ X3 (DG.Tweening.Plugins.Core.PathCore.Path)+94]) = 0;\n\tv214 = UnityEngine.Transform::get_position(options.lookAtTransform);\nL_0165:\n\tv1737 = UnityEngine.Transform::get_position(v806);\n\tgoto L_017E;\n\tv1822 = *([v1803 @ X0_v119+E0]);\n\tv1823 = v1822 == 0;\n\tv1824 = ~v1823;\n\tif (v1824) goto L_017E;\n\tv1826 = \"il2cpp_codegen_runtime_class_init\"(v1803, v1736, v1512, path, updateNotice, methodInfo, v62, v63, v1737, v1796, v1797, v402, v64, v65, v66, v67);\nL_017E:\n\t// 382 MakeStruct v1510 @ AGG10D91C8_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1727 @ V8_v32 (UnityEngine.Vector3), v1726 @ V9_v30 (System.Single), v1725 @ V10_v37 (System.Single)\n\tv1833 = UnityEngine.Vector3::op_Subtraction(v1510, v1737);\n\tv1537 = UnityEngine.Transform::get_up(v806);\n\tv1564 = UnityEngine.Quaternion;\n\tv1874 = *([v1564 @ X0_v123 (Il2CppClass<UnityEngine.Quaternion>)+12F]) & 2;\n\tv1875 = v1874 == 0;\n\tv1566 = ~v1875;\n\tif (v1566) goto L_0386;\n\tgoto L_038F;\nL_0195:\n\tv1377 = options.lookAhead + pathPerc;\n\tv1313 = v1377 <= 1f;\n\tif (v1313) goto L_01BE;\n\tv1372 = ~options.isClosedPath;\n\tif (v1372) goto L_01B5;\n\tv1377 = v1377 + -1f;\n\tgoto L_01BE;\nL_01B5:\n\tv1374 = path.type != 0;\n\tif (v1374) goto L_FFFFFFFF;\n\tgoto L_01BE;\nL_01BE:\n\tv215 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(path, v1377, 0);\n\tv203 = v215.y;\n\tv414 = v215.z;\nL_01C1:\n\t*([v37 @ X29_v1-34]) = v203;\n\tv1715 = path.type == 0;\n\tv1716 = ~v1715;\n\tif (v1716) goto L_024E;\n\tv394 = path.wps;\n\tv714 = v394.Length == 0;\n\tif (v714) goto L_0467;\n\tv223 = v394.Length << 0x20;\n\tv1837 = 0xFFFFFFFF00000000 + v223;\n\tv1839 = v1837 >> 0x20;\n\tv1840 = v1839 * 0xC;\n\tv1841 = v394 + v1840;\n\tgoto L_01EB;\n\tv1850 = *([v1838 @ X0_v96+E0]);\n\tv1851 = v1850 == 0;\n\tv1852 = ~v1851;\n\tif (v1852) goto L_01EB;\n\tv1854 = \"il2cpp_codegen_runtime_class_init\"(v1838, v334, v125, path, updateNotice, methodInfo, v62, v63, v215, v203, v414, v404, v148, v143, v66, v67);\nL_01EB:\n\t// 491 MakeStruct v117 @ AGG10D92C0_0_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v215 @ V0_v37 (UnityEngine.Vector3), [v37 @ X29_v1-34], v414 @ V2_v35 (System.Single)\n\t// 492 MakeStruct v113 @ AGG10D92C0_1_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1841 @ X8_v95+20], v394[v1839 @ X9_v24 (System.Int32)].y (System.Single), v394[v1839 @ X9_v24 (System.Int32)].z (System.Single)\n\tv1769 = UnityEngine.Vector3::op_Equality(v117, v113);\n\tv1772 = v1769 == 0;\n\tif (v1772) goto L_024E;\n\tgoto L_0203;\n\tv1921 = *([v1886 @ X0_v100+E0]);\n\tv1922 = v1921 == 0;\n\tv1923 = ~v1922;\n\tif (v1923) goto L_0203;\n\tv1925 = \"il2cpp_codegen_runtime_class_init\"(v1886, v334, v125, path, updateNotice, methodInfo, v62, v63, v1764, v1762, v1781, v1779, v1757, v1755, v66, v67);\nL_0203:\n\t// 515 MakeStruct v105 @ AGG10D92FC_1_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1841 @ X8_v95+20], v394[v1839 @ X9_v24 (System.Int32)].y (System.Single), v394[v1839 @ X9_v24 (System.Int32)].z (System.Single)\n\tv353 = UnityEngine.Vector3::op_Equality(tPos, v105);\n\t*([v37 @ X29_v1-34]) = v394[v1839 @ X9_v24 (System.Int32)].y;\n\tv1773 = v353 == 0;\n\tif (v1773) goto L_024E;\n\tv395 = path.wps;\n\tv1997 = v395.Length < 1;\n\tv702 = ~v1997;\n\tv699 = v395.Length - 1;\n\tv693 = v699 == 0;\n\tv1998 = ~v702;\n\tv678 = v1998 | v693;\n\tif (v678) goto L_0467;\n\tv1765 = v395.Length << 0x20;\n\tv2025 = 0xFFFFFFFE00000000 + v1765;\n\tv2026 = v2025 >> 0x20;\n\tv2027 = v2026 * 0xC;\n\tv2028 = v395 + v2027;\n\tgoto L_0236;\n\tv2037 = *([v2024 @ X0_v104+E0]);\n\tv2038 = v2037 == 0;\n\tv2039 = ~v2038;\n\tif (v2039) goto L_0236;\n\tv2041 = \"il2cpp_codegen_runtime_class_init\"(v2024, v334, v125, path, updateNotice, methodInfo, v62, v63, v216, v204, v415, v405, v149, v144, v66, v67);\nL_0236:\n\t// 566 MakeStruct v1753 @ AGG10D9374_0_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1841 @ X8_v95+20], v394[v1839 @ X9_v24 (System.Int32)].y (System.Single), v394[v1839 @ X9_v24 (System.Int32)].z (System.Single)\n\t// 567 MakeStruct v1752 @ AGG10D9374_1_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v2028 @ X8_v100+20\n// ... truncated")]
		public unsafe void SetOrientation(PathOptions options, Tween t, Path path, float pathPerc, Vector3 tPos, UpdateNotice updateNotice)
		{
			//IL_0101: Expected F4, but got I
			//IL_0111: Expected F4, but got I
			//IL_0121: Expected F4, but got I
			//IL_16f6: Expected O, but got Ref
			//IL_0340: Expected O, but got I
			//IL_1127: Expected F4, but got I
			//IL_0230: Expected F4, but got I
			//IL_0240: Expected F4, but got I
			//IL_1182: Expected F4, but got I
			//IL_11a9: Expected F4, but got I
			//IL_077d: Expected O, but got I8
			//IL_07a8: Expected O, but got I
			//IL_035a: Expected F4, but got I
			//IL_0f42: Expected F4, but got I
			//IL_0c59: Expected F4, but got I
			//IL_0b99: Expected F4, but got I
			//IL_07d4: Expected F4, but got I
			//IL_07f6: Expected F4, but got I
			//IL_0da1: Expected F4, but got I
			//IL_05f1: Expected I, but got O
			//IL_0415: Expected O, but got I
			//IL_042a: Expected F4, but got I
			//IL_0884: Expected F4, but got I
			//IL_0913: Expected O, but got I
			//IL_095f: Expected O, but got I4
			//IL_12a7: Expected O, but got F4
			//IL_12b4: Expected O, but got F4
			//IL_09b6: Expected O, but got I8
			//IL_09e1: Expected O, but got I
			//IL_09fb: Expected F4, but got I
			//IL_0a46: Expected F4, but got I
			//IL_0aa2: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			Component component = t.target as Component;
			Transform transform;
			float w2;
			float z2;
			float y2;
			Quaternion quaternion2;
			Transform trans;
			Vector3 vector2;
			float y3;
			float z3;
			Vector3 vector6;
			float z4;
			Quaternion quaternion;
			float y;
			float z;
			float w;
			if ((object)component != null)
			{
				Component component2 = t.target as Component;
				if ((object)component2 != null)
				{
					transform = ((Component)t.target).transform;
					Quaternion identity = Quaternion.identity;
					bool flag = updateNotice != UpdateNotice.RewindStep;
					y = identity.y;
					quaternion = identity;
					w = identity.w;
					z = identity.z;
					if (!flag)
					{
						quaternion = options.startupRot;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+58]");
						y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+5C]");
						z = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+60]");
						w = 0f;
						transform.rotation = options.startupRot;
					}
					if (options.orientType != OrientType.ToPath)
					{
						if (options.orientType != OrientType.LookAtTransform)
						{
							bool flag2 = options.orientType != OrientType.LookAtPosition;
							w2 = identity.w;
							z2 = identity.z;
							y2 = identity.y;
							quaternion2 = identity;
							trans = transform;
							if (!flag2)
							{
								Vector3? vector = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
								path.lookAtPosition = null;
								_ = 0;
								vector2 = options.lookAtPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+18]");
								y3 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+1C]");
								z3 = 0f;
								goto IL_0582;
							}
						}
						else
						{
							bool flag3 = options.lookAtTransform != null;
							bool flag4 = !flag3;
							w2 = identity.w;
							z2 = identity.z;
							y2 = identity.y;
							quaternion2 = identity;
							trans = transform;
							if (!flag4)
							{
								Vector3 position = options.lookAtTransform.position;
								Vector3? vector = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
								path.lookAtPosition = null;
								_ = 0;
								Vector3 position2 = options.lookAtTransform.position;
								z3 = position2.z;
								y3 = position2.y;
								vector2 = position2;
								goto IL_0582;
							}
						}
						goto IL_1378;
					}
					bool flag5 = options.lookAhead < 0.0001f;
					bool flag6 = !flag5;
					float num = options.lookAhead - 0.0001f;
					bool flag7 = num == 0f;
					bool flag8 = !flag7;
					float y4;
					if (!(flag6 && flag8) && path.type == PathType.Linear)
					{
						Vector3[] wps = path.wps;
						if (path.linearWPIndex < wps.Length)
						{
							int num2 = path.linearWPIndex * 12;
							object obj3 = (long)(IntPtr)wps + (long)num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1693 @ X8_v106+20]");
							Vector3 vector3 = default(Vector3);
							vector3.x = 0f;
							vector3.y = wps[path.linearWPIndex].y;
							vector3.z = wps[path.linearWPIndex].z;
							Vector3 vector4 = tPos + vector3;
							Vector3[] wps2 = path.wps;
							int num3 = path.linearWPIndex - 1;
							if (num3 < wps2.Length)
							{
								int num4 = num3 * 12;
								object obj4 = (long)(IntPtr)wps2 + (long)num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1711 @ X8_v109+20]");
								Vector3 vector5 = default(Vector3);
								vector5.x = 0f;
								vector5.y = wps2[num3].y;
								vector5.z = wps2[num3].z;
								vector6 = vector4 - vector5;
								y4 = vector6.y;
								z4 = vector6.z;
								goto IL_1396;
							}
						}
						goto IL_136a;
					}
					float num5 = options.lookAhead + pathPerc;
					if (num5 > 1f)
					{
						num5 = (options.isClosedPath ? (num5 + -1f) : ((path.type != PathType.Linear) ? 1.00001f : 1f));
					}
					vector6 = path.GetPoint(num5);
					y4 = vector6.y;
					z4 = vector6.z;
					goto IL_1396;
				}
			}
			InvalidCastException ex = new InvalidCastException();
			NullReferenceException ex2 = new NullReferenceException();
			goto IL_136a;
			IL_1671:
			w2 = w;
			z2 = z;
			y2 = y;
			quaternion2 = quaternion;
			Transform transform2 = default(Transform);
			trans = transform2;
			goto IL_1378;
			IL_1396:
			bool flag9 = path.type == PathType.Linear;
			bool flag10 = !flag9;
			float num6 = z4;
			Vector3 vector7 = vector6;
			if (!flag10)
			{
				Vector3[] wps3 = path.wps;
				if (wps3.Length == 0)
				{
					goto IL_136a;
				}
				int num7 = wps3.Length << 32;
				object obj5 = -4294967296L + num7;
				int num8 = (int)((long)(IntPtr)obj5 >> 32);
				int num9 = num8 * 12;
				object obj6 = (long)(IntPtr)wps3 + (long)num9;
				Vector3 vector8 = default(Vector3);
				vector8.x = vector6.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29_v1-34]");
				vector8.y = 0f;
				vector8.z = z4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1841 @ X8_v95+20]");
				Vector3 vector9 = default(Vector3);
				vector9.x = 0f;
				vector9.y = wps3[num8].y;
				vector9.z = wps3[num8].z;
				bool flag11 = vector8 == vector9;
				bool flag12 = !flag11;
				num6 = z4;
				vector7 = vector6;
				if (!flag12)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1841 @ X8_v95+20]");
					Vector3 vector10 = default(Vector3);
					vector10.x = 0f;
					vector10.y = wps3[num8].y;
					vector10.z = wps3[num8].z;
					bool flag13 = tPos == vector10;
					_ = wps3[num8].y;
					bool flag14 = !flag13;
					num6 = wps3[num8].z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1841 @ X8_v95+20]");
					vector7 = (Vector3)0;
					if (!flag14)
					{
						Vector3[] wps4 = path.wps;
						bool flag15 = wps4.Length < 1;
						bool flag16 = !flag15;
						object obj7 = wps4.Length - 1;
						bool flag17 = obj7 == null;
						bool flag18 = !flag16;
						if (flag18 || flag17)
						{
							goto IL_136a;
						}
						int num10 = wps4.Length << 32;
						object obj8 = -8589934592L + num10;
						int num11 = (int)((long)(IntPtr)obj8 >> 32);
						int num12 = num11 * 12;
						object obj9 = (long)(IntPtr)wps4 + (long)num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1841 @ X8_v95+20]");
						Vector3 vector11 = default(Vector3);
						vector11.x = 0f;
						vector11.y = wps3[num8].y;
						vector11.z = wps3[num8].z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2028 @ X8_v100+20]");
						Vector3 vector12 = default(Vector3);
						vector12.x = 0f;
						vector12.y = wps4[num11].y;
						vector12.z = wps4[num11].z;
						Vector3 vector13 = vector11 - vector12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1841 @ X8_v95+20]");
						Vector3 vector14 = default(Vector3);
						vector14.x = 0f;
						vector14.y = wps3[num8].y;
						vector14.z = wps3[num8].z;
						Vector3 vector15 = vector14 + vector13;
						_ = vector15.y;
						num6 = vector15.z;
						vector7 = vector15;
					}
				}
			}
			Vector3 up = transform.up;
			if (options.useLocalPosition && options.parent != null)
			{
				Vector3 position3 = default(Vector3);
				position3.x = vector7.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29_v1-34]");
				position3.y = 0f;
				position3.z = num6;
				Vector3 vector16 = options.parent.TransformPoint(position3);
				_ = vector16.y;
				num6 = vector16.z;
				vector7 = vector16;
			}
			bool flag19 = options.lockRotationAxis == AxisConstraint.None;
			float num13 = up.z;
			float num14 = up.y;
			Vector3 vector17 = up;
			transform2 = transform;
			Transform transform3;
			Vector3 up3;
			float y6;
			float z7;
			if (!flag19)
			{
				int num15 = (int)(options.lockRotationAxis & AxisConstraint.X);
				bool flag20 = num15 == 0;
				num13 = up.z;
				num14 = up.y;
				vector17 = up;
				if (!flag20)
				{
					Vector3 position4 = default(Vector3);
					position4.x = vector7.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29_v1-34]");
					position4.y = 0f;
					position4.z = num6;
					Vector3 vector18 = transform.InverseTransformPoint(position4);
					Vector3 position5 = default(Vector3);
					position5.x = vector18.x;
					position5.y = 0f;
					position5.z = vector18.z;
					Vector3 vector19 = transform.TransformPoint(position5);
					_ = vector19.y;
					Vector3 up2;
					float y5;
					float z5;
					if (options.useLocalPosition && options.parent != null)
					{
						up2 = options.parent.up;
						y5 = up2.y;
						z5 = up2.z;
					}
					else
					{
						up2 = Vector3.up;
						y5 = up2.y;
						z5 = up2.z;
					}
					num6 = vector19.z;
					vector7 = vector19;
					num13 = z5;
					num14 = y5;
					vector17 = up2;
				}
				AxisConstraint lockRotationAxis = options.lockRotationAxis;
				if ((options.lockRotationAxis & AxisConstraint.Y) != AxisConstraint.None)
				{
					Vector3 position6 = default(Vector3);
					position6.x = vector7.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29_v1-34]");
					position6.y = 0f;
					position6.z = num6;
					Vector3 vector20 = transform.InverseTransformPoint(position6);
					float z6 = vector20.z;
					float num16 = 0f - vector20.z;
					if (vector20.z < 0f)
					{
						z6 = num16;
					}
					Vector3 position7 = default(Vector3);
					position7.x = 0f;
					position7.y = vector20.y;
					position7.z = z6;
					Vector3 vector21 = transform.TransformPoint(position7);
					_ = vector21.y;
					lockRotationAxis = options.lockRotationAxis;
					num6 = vector21.z;
					vector7 = vector21;
				}
				int num17 = (int)(lockRotationAxis & AxisConstraint.Z);
				bool flag21 = num17 == 0;
				transform2 = transform;
				if (!flag21)
				{
					bool flag22 = !options.useLocalPosition;
					transform2 = transform;
					if (!flag22)
					{
						bool flag23 = options.parent != null;
						bool flag24 = !flag23;
						transform2 = transform;
						if (!flag24)
						{
							transform3 = options.parent;
							up3 = Vector3.up;
							y6 = up3.y;
							z7 = up3.z;
							bool flag25 = (object)options.parent == null;
							bool flag26 = !flag25;
							transform2 = transform;
							if (!flag26)
							{
								throw new NullReferenceException();
							}
							goto IL_1569;
						}
					}
					up3 = Vector3.up;
					y6 = up3.y;
					z7 = up3.z;
					transform3 = transform2;
					goto IL_1569;
				}
			}
			goto IL_1537;
			IL_1537:
			Vector3 position8 = transform2.position;
			float z8 = default(float);
			float y7 = default(float);
			Vector3 vector24 = default(Vector3);
			if (options.mode == PathMode.Full3D)
			{
				Vector3 vector22 = default(Vector3);
				vector22.x = vector7.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29_v1-34]");
				vector22.y = 0f;
				vector22.z = num6;
				Vector3 vector23 = vector22 - position8;
				Vector3 zero = Vector3.zero;
				bool flag27 = vector23 == zero;
				bool flag28 = !flag27;
				z8 = vector23.z;
				y7 = vector23.y;
				vector24 = vector23;
				if (!flag28)
				{
					Vector3 forward = transform2.forward;
					z8 = forward.z;
					y7 = forward.y;
					vector24 = forward;
				}
				goto IL_0ff7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29_v1-34]");
			float num18 = 0f;
			Vector3 to = default(Vector3);
			to.x = vector7.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29_v1-34]");
			to.y = 0f;
			to.z = num6;
			float num19 = Utils.Angle2D(position8, to);
			float num20 = num19 + 360f;
			float num21 = ((!(num19 < 0f)) ? num19 : num20);
			bool flag29 = options.mode != PathMode.Sidescroller2D;
			float y8 = 0f;
			if (!flag29)
			{
				Vector3 position9 = transform2.position;
				y8 = ((!(vector7.x < position9.x)) ? 0f : 180f);
				bool flag30;
				bool flag31;
				bool flag32;
				if (num21 < 270f)
				{
					float num22 = num21 - 90f;
					flag30 = num22 < 0f;
					flag31 = num22 == 0f;
					object obj10 = num21 ^ 90f;
					object obj11 = num21 ^ num22;
					int num23 = (int)((long)(IntPtr)obj10 & (long)(IntPtr)obj11);
					flag32 = num23 < 0;
				}
				else
				{
					flag32 = false;
					flag31 = true;
					flag30 = false;
				}
				float num24 = 180f - num21;
				bool flag33 = flag30 == flag32;
				bool flag34 = !flag31;
				if (flag33 && flag34)
				{
					num21 = num24;
				}
			}
			quaternion = Quaternion.Euler(0f, y8, num21);
			y = quaternion.y;
			z = quaternion.z;
			w = quaternion.w;
			float num25 = num6;
			goto IL_1671;
			IL_1569:
			Vector3 direction = default(Vector3);
			direction.x = up3.x;
			direction.y = y6;
			direction.z = z7;
			Vector3 vector25 = transform3.TransformDirection(direction);
			num13 = options.startupZRot;
			num14 = vector25.y;
			vector17 = vector25;
			goto IL_1537;
			IL_0ff7:
			Vector3 forward2 = default(Vector3);
			forward2.x = vector24.x;
			forward2.y = y7;
			forward2.z = z8;
			Vector3 upwards = default(Vector3);
			upwards.x = vector17.x;
			upwards.y = num14;
			upwards.z = num13;
			quaternion = Quaternion.LookRotation(forward2, upwards);
			y = quaternion.y;
			z = quaternion.z;
			w = quaternion.w;
			num25 = num13;
			num18 = num14;
			goto IL_1671;
			IL_136a:
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
			IL_1378:
			if (options.hasCustomForwardDirection)
			{
				Quaternion quaternion3 = default(Quaternion);
				quaternion3.x = quaternion2.x;
				quaternion3.y = y2;
				quaternion3.z = z2;
				quaternion3.w = w2;
				quaternion = quaternion3 * options.forward;
				y = quaternion.y;
				z = quaternion.z;
				w = quaternion.w;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+34]");
				num25 = 0f;
				num18 = options.forward.x;
				w2 = quaternion.w;
				z2 = quaternion.z;
				y2 = quaternion.y;
				quaternion2 = quaternion;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			Quaternion newRot = default(Quaternion);
			newRot.x = quaternion2.x;
			newRot.y = y2;
			newRot.z = z2;
			newRot.w = w2;
			object obj12 = default(object);
			DOTweenExternalCommand.Dispatch_SetOrientationOnPath((PathOptions)(&obj12), t, newRot, trans);
			return;
			IL_0582:
			Vector3 position10 = transform.position;
			Vector3 vector26 = default(Vector3);
			vector26.x = vector2.x;
			vector26.y = y3;
			vector26.z = z3;
			Vector3 vector27 = vector26 - position10;
			Vector3 up4 = transform.up;
			IntPtr intPtr = (IntPtr)typeof(Quaternion);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ X0_v123 (Il2CppClass<UnityEngine.Quaternion>)+12F]");
			if (0 == 0)
			{
				z8 = vector27.z;
				y7 = vector27.y;
				vector24 = vector27;
				num13 = up4.z;
				num14 = up4.y;
				vector17 = up4;
				transform2 = transform;
			}
			goto IL_0ff7;
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0x10D98A4", Offset = "0x10D98A4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF56D0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274B7]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathPlugin()
		{
		}
	}
}
