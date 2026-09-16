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
	[Token(Token = "0x200007A")]
	public class PathPlugin : ABSTweenPlugin<Vector3, Path, PathOptions>
	{
		[Token(Token = "0x4000160")]
		public const float MinLookAhead = 0.0001f;

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0xC1F11C", Offset = "0xC1F11C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.Plugins.Core.PathCore.Path::Destroy(t.endValue);\n\tt.startValue = 0;\n\tt.endValue = 0;\n\tt.changeValue = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<Vector3, Path, PathOptions> t)
		{
			t.endValue.Destroy();
			t.startValue = null;
			t.endValue = null;
			t.changeValue = null;
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0xC1F260", Offset = "0xC1F260", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, bool isRelative)
		{
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0xC1F264", Offset = "0xC1F264", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, Path fromValue, bool setImmediately, bool isRelative)
		{
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0xC1F268", Offset = "0xC1F268", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35768]) = v34;\nL_0016:\n\treturnVal1 = DG.Tweening.Plugins.Core.PluginsManager::GetCustomPlugin();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ABSTweenPlugin<Vector3, Path, PathOptions> Get()
		{
			return (ABSTweenPlugin<Vector3, Path, PathOptions>)(object)PluginsManager.GetCustomPlugin<object, Vector3, object, PathOptions>();
		}

		[Token(Token = "0x60002F5")]
		[Address(RVA = "0xC1F2A8", Offset = "0xC1F2A8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn t.endValue;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Path ConvertToStartValue(TweenerCore<Vector3, Path, PathOptions> t, Vector3 value)
		{
			return t.endValue;
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0xC1F2C0", Offset = "0xC1F2C0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.endValue;\n\tv104 = ~v6.isFinalized;\n\tif (v104) goto L_0010;\nL_000F:\n\treturn;\nL_0010:\n\t;\n\tv70 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv195 = t.endValue;\n\tv82 = v195.wps;\n\tv25 = v82.Length < 1;\n\tif (v25) goto L_000F;\n\tv60 = v82.Length & 0xFFFFFFFF;\nL_003C:\n\tv159 = v195.wps + v83;\n\tv76 = v76 + 1;\n\tv44 = v60 == v76;\n\tv14 = v97 + *([v159 @ X11_v6+20]);\n\tv10 = v98 + *([v159 @ X11_v6+28]);\n\t*([v159 @ X11_v6+20]) = v14;\n\t*([v159 @ X11_v6+28]) = v10;\n\tif (v44) goto L_000F;\n\tv195 = t.endValue;\n\tv83 = v83 + 0xC;\n\tv201 = t.endValue == 0;\n\tv85 = ~v201;\n\tif (v85) goto L_003C;\n\tv90 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector3, Path, PathOptions> t)
		{
			//IL_00a0: Expected I4, but got I8
			//IL_00ca: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_0112: Expected O, but got I
			Path endValue = t.endValue;
			if (endValue.isFinalized)
			{
				return;
			}
			object obj = t.getter();
			Path endValue2 = t.endValue;
			Vector3[] wps = endValue2.wps;
			if (wps.Length < 1)
			{
				return;
			}
			int num = (int)(wps.Length & 0xFFFFFFFFL);
			int num2 = 0;
			int num3 = 0;
			object obj3 = default(object);
			object obj5 = default(object);
			do
			{
				object obj2 = (nint)endValue2.wps + num3;
				num2++;
				bool flag = num == num2;
				nint num4 = (nint)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X11_v6+20]");
				object obj4 = num4 + 0;
				nint num5 = (nint)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X11_v6+28]");
				object obj6 = num5 + 0;
				if (flag)
				{
					return;
				}
				endValue2 = t.endValue;
				num3 += 12;
			}
			while (t.endValue != null);
			NullReferenceException ex = new NullReferenceException();
			throw new IndexOutOfRangeException();
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0xC1F378", Offset = "0xC1F378", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv34 = UnityEngine.Component;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, t, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOTweenUtils;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, t, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv283 = UnityEngine.Debug;\n\tv284 = \"il2cpp_codegen_initialize_runtime_metadata\"(v283, t, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv384 = UnityEngine.GameObject;\n\tv385 = \"il2cpp_codegen_initialize_runtime_metadata\"(v384, t, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv458 = UnityEngine.Vector3[];\n\tv459 = \"il2cpp_codegen_initialize_runtime_metadata\"(v458, t, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv477 = \"CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v477, t, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv54 = 1;\n\t*([1A35769]) = v54;\nL_002B:\n\tv59 = t.target;\n\tv293 = *([v59 @ X0_v8 (UnityEngine.GameObject)]) == UnityEngine.GameObject;\n\tif (v293) goto L_005F;\n\tgoto L_FFFFFFFF;\n\tv431 = v431_asT == 0;\n\tif (v431) goto L_01C7;\n\tv245 = UnityEngine.Component::get_transform(v59);\n\tgoto L_006B;\nL_005F:\n\tv245 = UnityEngine.GameObject::get_transform(v59);\nL_006B:\n\tv149 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]) != 1;\n\tif (v149) goto L_0073;\n\tv479 = UnityEngine.Transform::get_parent(v245);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+188]) = v479;\nL_0073:\n\tv565 = t.endValue;\n\tv569 = ~v565.isFinalized;\n\tv570 = ~v569;\n\tif (v570) goto L_01B5;\n\tv142 = t + 0x140;\n\tv590 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv140 = t.endValue;\n\tv247 = 0x1854F10(&v592 @ stack_-E0, v142, 0x70, v37, v38, v39, v40, v41, v42, v43, v44, v101, v98, v96, v48, v49);\n\tv593 = t.endValue + 0x58;\n\tv248 = 0x1854F10(v593, &v592 @ stack_-E0, 0x70, v37, v38, v39, v40, v41, v42, v43, v44, v101, v98, v96, v48, v49);\n\tv271 = v140.wps;\n\tv250 = DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder::get_minInputWaypoints(v140._decoder);\n\tv150 = v250 >= v271.Length;\n\tif (v150) goto L_FFFFFFFF;\n\tv272 = v140.wps;\n\tgoto L_00BE;\n\tv684 = \"il2cpp_codegen_runtime_class_init\"(v633, v159, v137, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00BE:\n\t// 190 MakeStruct v599 @ AGGC23558_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v272 @ X8_v43 (UnityEngine.Vector3[])+20], [v272 @ X8_v43 (UnityEngine.Vector3[])+24], [v272 @ X8_v43 (UnityEngine.Vector3[])+28]\n\t// 191 MakeStruct v597 @ AGGC23558_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v42 @ V0 (UnityEngine.Vector3), v43 @ V1 (UnityEngine.Vector3), v44 @ V2 (UnityEngine.Vector3)\n\tv621 = DG.Tweening.Core.DOTweenUtils::Vector3AreApproximatelyEqual(v599, v597);\n\tv623 = v621 == 0;\n\tif (v623) goto L_FFFFFFFF;\n\tgoto L_00C8;\nL_00C8:\n\tv630 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+150]) == 0;\n\tif (v630) goto L_FFFFFFFF;\n\tv335 = v271.Length - 1;\n\tv375 = v335 * 0xC;\n\tv698 = v140.wps + v375;\n\tv649 = *([v698 @ X10_v14+20]);\n\tv647 = *([v698 @ X10_v14+24]);\n\tv651 = *([v698 @ X10_v14+28]);\n\tv708 = v140.type != 2;\n\tif (v708) goto L_011C;\n\tv332 = v271.Length <= 2;\n\tif (v332) goto L_0114;\n\tv336 = v271.Length - 3;\n\tv736 = v336 * 0xC;\n\tv739 = v140.wps + v736;\n\tv649 = *([v739 @ X8_v41+20]);\n\tv647 = *([v739 @ X8_v41+24]);\n\tv651 = *([v739 @ X8_v41+28]);\n\tgoto L_011C;\nL_0114:\n\tgoto L_011A;\n\tv788 = \"il2cpp_codegen_runtime_class_init\"(v764, v159, v137, v37, v38, v39, v40, v41, v113, v107, v103, v100, v98, v96, v48, v49);\nL_011A:\n\tUnityEngine.Debug::LogError(\"CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)\");\nL_011C:\n\tv740 = v649 - v42;\n\tv741 = v647 - v43;\n\tv104 = v651 - v44;\n\tv742 = v740 * v740;\n\tv743 = v741 * v741;\n\tv744 = v742 + v743;\n\tv108 = v104 * v104;\n\tv114 = v108 + v744;\n\tv669 = v114 < 9.9999994E-11f;\n\tif (v669) goto L_FFFFFFFF;\n\tv274 = v143 + 1;\n\tgoto L_0136;\nL_0136:\n\tv160 = v274 + v271.Length;\n\t// 312 NewArr v252 @ X0_v23 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v160 @ X1_v12\n\tv709 = ~v143;\n\tif (v709) goto L_014D;\n\t*([v252 @ X0_v23 (UnityEngine.Vector3[])+20]) = v42;\n\t*([v252 @ X0_v23 (UnityEngine.Vector3[])+24]) = v43;\n\t*([v252 @ X0_v23 (UnityEngine.Vector3[])+28]) = v44;\nL_014D:\n\tv758 = v271.Length < 1;\n\tif (v758) goto L_0185;\n\tv241 = v271.Length & 0xFFFFFFFF;\n\tv769 = v143 * 0xC;\n\tv87 = v252 + v769;\nL_0172:\n\tv771 = v140.wps + v82;\n\tv275 = v275 + 1;\n\tv772 = v87 + v82;\n\tv82 = v82 + 0xC;\n\t*([v772 @ X14_v9]) = *([v771 @ X13_v8]);\n\t*([v772 @ X14_v9+8]) = *([v771 @ X13_v8+8]);\n\tv776 = v241 != v275;\n\tif (v776) goto L_0172;\nL_0185:\n\tv787 = ~v78;\n\tif (v787) goto L_0197;\n\tv798 = v252 + 0x20;\n\tv804 = v252.Length - 1;\n\tv800 = v804 * 0xC;\n\tv801 = v798 + v800;\n\t*([v801 @ X8_v25]) = *([v252 @ X0_v23 (UnityEngine.Vector3[])+20]);\n\t*([v801 @ X8_v25+8]) = *([v252 @ X0_v23 (UnityEngine.Vector3[])+28]);\nL_0197:\n\tv140.wps = v252;\n\tv140.addedExtraStartWp = v143;\n\tv140.addedExtraEndWp = v78;\n\t// 416 MakeStruct v63 @ AGGC23744_3_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v42 @ V0 (UnityEngine.Vector3), v43 @ V1 (UnityEngine.Vector3), v44 @ V2 (UnityEngine.Vector3)\n\tDG.Tweening.Plugins.Core.PathCore.Path::FinalizePath(t.endValue, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+150]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]), v63);\n\tv807 = UnityEngine.Transform::get_rotation(v245);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+194]) = v807;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+198]) = v807.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+19C]) = v807.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+1A0]) = v807.w;\n\tv575 = UnityEngine.Transform::get_eulerAngles(v245);\n\tv565 = t.endValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+1A4]) = v575.z;\nL_01B5:\n\tt.changeValue = v565;\n\treturn;\n\tv281 = new System.NullReferenceException();\n\tv382 = new System.IndexOutOfRangeException();\nL_01C7:\n\tthrow System.InvalidCastException;\n// 326 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector3, Path, PathOptions> t)
		{
			//IL_010e: Expected O, but got I
			//IL_0150: Expected O, but got I
			//IL_0747: Expected O, but got I4
			//IL_01e3: Expected F4, but got I
			//IL_01f8: Expected F4, but got I
			//IL_020d: Expected F4, but got I
			//IL_0290: Expected O, but got I
			//IL_02a0: Expected O, but got I
			//IL_02b0: Expected O, but got I
			//IL_035d: Expected O, but got I
			//IL_036d: Expected O, but got I
			//IL_037d: Expected O, but got I
			//IL_038d: Expected O, but got I
			//IL_0484: Unknown result type (might be due to invalid IL or missing references)
			//IL_0489: Expected O, but got Unknown
			//IL_02eb: Expected O, but got I
			//IL_02fb: Expected O, but got I
			//IL_030b: Expected O, but got I
			//IL_0572: Expected I4, but got I8
			//IL_0580: Expected O, but got I4
			//IL_058f: Expected O, but got I
			//IL_063f: Expected O, but got I
			//IL_064f: Expected O, but got I4
			//IL_065e: Expected O, but got I
			//IL_066d: Expected O, but got I
			//IL_067d: Expected O, but got I
			//IL_05b9: Expected O, but got I
			//IL_05d5: Expected O, but got I
			//IL_040a: Expected O, but got I
			//IL_041a: Expected O, but got I
			//IL_042a: Expected O, but got I
			//IL_043a: Expected O, but got I
			GameObject target = (GameObject)t.target;
			Transform transform;
			if ((object)target.GetType() != typeof(GameObject))
			{
				Component component = target as Component;
				if ((object)component == null)
				{
					throw new InvalidCastException();
				}
				transform = ((Component)(object)target).transform;
			}
			else
			{
				transform = target.transform;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+144]");
			if ((nint)0 == 1)
			{
				Transform parent = transform.parent;
			}
			Path endValue = t.endValue;
			if (endValue.isFinalized)
			{
				goto IL_0705;
			}
			object obj = (nint)t + 320;
			object obj2 = t.getter();
			Path endValue2 = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			object obj3 = (nint)t.endValue + 88;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			Vector3[] wps = endValue2.wps;
			int minInputWaypoints = endValue2._decoder.minInputWaypoints;
			bool flag = minInputWaypoints >= wps.Length;
			Vector3 vector2 = default(Vector3);
			Vector3 vector = vector2;
			Vector3 vector4 = default(Vector3);
			Vector3 vector3 = vector4;
			Vector3 vector6 = default(Vector3);
			Vector3 vector5 = vector6;
			bool flag4;
			if (!flag)
			{
				Vector3[] wps2 = endValue2.wps;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+20]");
				Vector3 a = default(Vector3);
				a.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+24]");
				a.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+28]");
				a.z = 0f;
				Vector3 b = default(Vector3);
				b.x = vector6.x;
				b.y = vector4.x;
				b.z = vector2.x;
				bool flag2 = DOTweenUtils.Vector3AreApproximatelyEqual(a, b);
				bool flag3 = !flag2;
				Vector3 vector7 = vector2;
				Vector3 vector8 = vector4;
				float x = vector6.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+28]");
				vector = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+24]");
				vector3 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+20]");
				vector5 = (Vector3)0;
				if (!flag3)
				{
					vector7 = vector2;
					vector8 = vector4;
					x = vector6.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+28]");
					vector = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+24]");
					vector3 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v43 (UnityEngine.Vector3[])+20]");
					vector5 = (Vector3)0;
					flag4 = false;
					goto IL_0713;
				}
			}
			flag4 = true;
			goto IL_0713;
			IL_0713:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+150]");
			bool flag6;
			bool flag7;
			if ((nint)0 != 0)
			{
				int num = wps.Length - 1;
				int num2 = num * 12;
				object obj4 = (nint)endValue2.wps + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X10_v14+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X10_v14+24]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X10_v14+28]");
				object obj7 = 0;
				if (endValue2.type == PathType.CubicBezier)
				{
					if (wps.Length > 2)
					{
						int num3 = wps.Length - 3;
						int num4 = num3 * 12;
						object obj8 = (nint)endValue2.wps + num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ X8_v41+20]");
						obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ X8_v41+24]");
						obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ X8_v41+28]");
						obj7 = 0;
					}
					else
					{
						Debug.LogError("CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)");
					}
				}
				float num5 = (float)obj5 - vector6.x;
				float num6 = (float)obj6 - vector4.x;
				vector = (Vector3)((nint)obj7 - vector2);
				float num7 = num5 * num5;
				float num8 = num6 * num6;
				float num9 = num7 + num8;
				float x2 = ((Vector3)((object)vector * (object)vector)).x + num9;
				vector5.x = x2;
				bool flag5 = vector5.x < 9.9999994E-11f;
				float x = 9.9999994E-11f;
				if (!flag5)
				{
					flag6 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
					flag7 = true;
					x = 9.9999994E-11f;
					goto IL_0738;
				}
			}
			flag7 = false;
			flag6 = flag4;
			goto IL_0738;
			IL_0705:
			t.changeValue = endValue;
			return;
			IL_0738:
			object obj9 = (flag6 ? 1 : 0) + wps.Length;
			Vector3[] array = new Vector3[obj9];
			if (flag4)
			{
			}
			if (wps.Length >= 1)
			{
				int num10 = (int)(wps.Length & 0xFFFFFFFFL);
				object obj10 = (flag4 ? 1 : 0) * 12;
				object obj11 = (nint)array + (nint)obj10;
				int num11 = 32;
				int num12 = 0;
				do
				{
					object obj12 = (nint)endValue2.wps + num11;
					num12++;
					object obj13 = (nint)obj11 + num11;
					num11 += 12;
					obj13 = obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ X13_v8+8]");
					_ = 0;
				}
				while (num10 != num12);
			}
			if (flag7)
			{
				object obj14 = (nint)array + 32;
				object obj15 = array.Length - 1;
				object obj16 = (nint)obj15 * 12;
				object obj17 = (nint)obj14 + (nint)obj16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ X0_v23 (UnityEngine.Vector3[])+20]");
				obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ X0_v23 (UnityEngine.Vector3[])+28]");
				_ = 0;
			}
			endValue2.wps = array;
			endValue2.addedExtraStartWp = flag4;
			endValue2.addedExtraEndWp = flag7;
			Vector3 currTargetVal = default(Vector3);
			currTargetVal.x = vector6.x;
			currTargetVal.y = vector4.x;
			currTargetVal.z = vector2.x;
			Path endValue3 = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+150]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+148]");
			endValue3.FinalizePath((byte)num13 != 0, AxisConstraint.None, currTargetVal);
			Quaternion rotation = transform.rotation;
			_ = rotation.y;
			_ = rotation.z;
			_ = rotation.w;
			Vector3 eulerAngles = transform.eulerAngles;
			endValue = t.endValue;
			_ = eulerAngles.z;
			goto IL_0705;
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0xC1F874", Offset = "0xC1F874", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue.length / unitsXSecond;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn unitsXSecond;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(PathOptions options, float unitsXSecond, Path changeValue)
		{
			return changeValue.length / unitsXSecond;
		}

		[Token(Token = "0x60002F9")]
		[Address(RVA = "0xC1F890", Offset = "0xC1F890", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v51, v52, v53, v54, v55, v56);\n\tv59 = 1;\n\t*([1A3576A]) = v59;\nL_002C:\n\tv71 = t.loopType != 2;\n\tif (v71) goto L_004F;\n\tv193 = options.isClosedPath == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_004F;\n\tv109 = t.completedLoops - t.isComplete;\n\tv119 = v109 < 1;\n\tif (v119) goto L_004F;\n\tv197 = DG.Tweening.Plugins.Core.PathCore.Path::CloneIncremental(changeValue, v109);\nL_004F:\n\tv105 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv271 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToConstantPathPerc(v181, v105);\n\tv106 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(v181, v271, 0);\n\tv181.targetPosition = v106;\n\tv181.targetPosition.y = v106.y;\n\tv181.targetPosition.z = v106.z;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(setter, setter.method);\n\tv280 = options.mode == 0;\n\tif (v280) goto L_0085;\n\tv282 = options.orientType == 0;\n\tif (v282) goto L_0085;\n\tv322 = 0x1854F10(&v319 @ stack_-E0, options, 0x70, isRelative, getter, setter, startValue, changeValue, v106, v106.y, v106.z, t.easePeriod, v53, v54, v55, v56);\n\tDG.Tweening.Plugins.PathPlugin::SetOrientation(this, &v319 @ stack_-E0, t, v181, v271, v106, updateNotice);\nL_0085:\n\tv308 = t.isBackwards == 0;\n\tv314 = v308 ^ usingInversePosition;\n\tv316 = DG.Tweening.Plugins.Core.PathCore.Path::GetWaypointIndexFromPerc(v181, v105, v314);\n\tv328 = v316 == t.miscInt;\n\tif (v328) goto L_015C;\n\tt.miscInt = v316;\n\tv334 = t.onWaypointChange == 0;\n\tif (v334) goto L_015C;\n\tv359 = DG.Tweening.Tween::get_hasLoops(t);\n\tv361 = v359 == 0;\n\tif (v361) goto L_00D9;\n\tv372 = t.loopType != 1;\n\tif (v372) goto L_00D9;\n\tv386 = ~t.isBackwards;\n\tif (v386) goto L_012E;\n\tv438 = t.completedLoops & 1;\n\tv398 = v438 == 0;\n\tif (v398) goto L_00DB;\nL_00B9:\n\tv557 = t.miscInt + 1;\n\tv437 = v557 >= v316;\n\tif (v437) goto L_0113;\nL_00CB:\n\tv477 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, t, v557);\n\tv557 = v557 + 1;\n\tv451 = v316 != v557;\n\tif (v451) goto L_00CB;\n\tgoto L_0113;\nL_00D9:\n\tv383 = ~t.isBackwards;\n\tif (v383) goto L_00B9;\nL_00DB:\n\tv509 = t.miscInt - 1;\n\tv402 = v316 - 1;\n\tv414 = v509 <= v402;\n\tif (v414) goto L_0113;\nL_00F0:\n\tv514 = v316 == v509;\n\tif (v514) goto L_00FB;\n\tv563 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, t, v509);\nL_00FB:\n\tv509 = v509 - 1;\n\tv450 = v509 > v402;\n\tif (v450) goto L_00F0;\nL_0113:\n\tv493 = newCompletedSteps < 1;\n\tif (v493) goto L_014D;\n\tv520 = ~t.isComplete;\n\tv521 = ~v520;\n\tif (v521) goto L_014D;\n\tv121 = t.loopType != 1;\n\tif (v121) goto L_012A;\n\tv570 = t.completedLoops & 1;\n\tv571 = v570 == 0;\n\tif (v571) goto L_FFFFFFFF;\nL_012A:\n\tv575 = ~t.isBackwards;\n\tif (v575) goto L_0132;\n\tgoto L_013B;\nL_012E:\n\tv439 = t.completedLoops & 1;\n\tv399 = v439 == 0;\n\tif (v399) goto L_00B9;\n\tgoto L_00DB;\nL_0132:\n\tv187 = v181.wps;\n\tv525 = v187.Length - 1;\nL_013B:\n\tv532 = v525 == v316;\n\tif (v532) goto L_014D;\n\tv537 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, t, v525);\nL_014D:\n\tv348 = DG.Tweening.Tween::OnTweenCallback(t.onWaypointChange, t, v316);\nL_015C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 260 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(PathOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Path startValue, Path changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_013f: Expected O, but got I
			//IL_01ad: Expected O, but got Ref
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
			Vector3 tPos = (path.targetPosition = path.GetPoint(num2));
			path.targetPosition.y = tPos.y;
			path.targetPosition.z = tPos.z;
			setter((Vector3)(nint)setter.method);
			if (options.mode != PathMode.Ignore && options.orientType != OrientType.None)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				object obj = default(object);
				SetOrientation((PathOptions)(&obj), t, path, num2, tPos, updateNotice);
			}
			bool flag5 = !t.isBackwards;
			bool isMovingForward = flag5 ^ usingInversePosition;
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
			if (t.hasLoops && t.loopType == LoopType.Yoyo)
			{
				if (t.isBackwards)
				{
					if ((t.completedLoops & 1) != 0)
					{
						goto IL_02d6;
					}
				}
				else if ((t.completedLoops & 1) == 0)
				{
					goto IL_02d6;
				}
			}
			else if (!t.isBackwards)
			{
				goto IL_02d6;
			}
			int num3 = t.miscInt - 1;
			int num4 = waypointIndexFromPerc - 1;
			if (num3 > num4)
			{
				do
				{
					if (waypointIndexFromPerc != num3)
					{
						bool flag6 = Tween.OnTweenCallback(t.onWaypointChange, t, num3);
					}
					num3--;
				}
				while (num3 > num4);
			}
			goto IL_03b4;
			IL_02d6:
			int num5 = t.miscInt + 1;
			if (num5 < waypointIndexFromPerc)
			{
				do
				{
					bool flag7 = Tween.OnTweenCallback(t.onWaypointChange, t, num5);
					num5++;
				}
				while (waypointIndexFromPerc != num5);
			}
			goto IL_03b4;
			IL_03b4:
			if (newCompletedSteps >= 1 && !t.isComplete)
			{
				int num6;
				if ((t.loopType == LoopType.Yoyo && (t.completedLoops & 1) == 0) || t.isBackwards)
				{
					num6 = 0;
				}
				else
				{
					Vector3[] wps = path.wps;
					num6 = wps.Length - 1;
				}
				if (num6 != waypointIndexFromPerc)
				{
					bool flag8 = Tween.OnTweenCallback(t.onWaypointChange, t, num6);
				}
			}
			bool flag9 = Tween.OnTweenCallback(t.onWaypointChange, t, waypointIndexFromPerc);
		}

		[Token(Token = "0x60002FA")]
		[Address(RVA = "0xC2013C", Offset = "0xC2013C", Length = "0x940")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv56 = UnityEngine.Component;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, options, t, path, updateNotice, methodInfo, v59, v60, pathPerc, tPos, v0, v2, v61, v62, v63, v64);\n\tv72 = DG.Tweening.Core.DOTweenUtils;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, options, t, path, updateNotice, methodInfo, v59, v60, pathPerc, tPos, v0, v2, v61, v62, v63, v64);\n\tv416 = UnityEngine.GameObject;\n\tv417 = \"il2cpp_codegen_initialize_runtime_metadata\"(v416, options, t, path, updateNotice, methodInfo, v59, v60, pathPerc, tPos, v0, v2, v61, v62, v63, v64);\n\tv509 = Il2CppMethodInfo;\n\tv510 = \"il2cpp_codegen_initialize_runtime_metadata\"(v509, options, t, path, updateNotice, methodInfo, v59, v60, pathPerc, tPos, v0, v2, v61, v62, v63, v64);\n\tv612 = UnityEngine.Object;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v612, options, t, path, updateNotice, methodInfo, v59, v60, pathPerc, tPos, v0, v2, v61, v62, v63, v64);\n\tv69 = 1;\n\t*([1A3576B]) = v69;\nL_0035:\n\tv74 = t.target;\n\tv426 = *([v74 @ X0_v8 (UnityEngine.GameObject)]) == UnityEngine.GameObject;\n\tif (v426) goto L_0069;\n\tgoto L_FFFFFFFF;\n\tv463 = v463_asT == 0;\n\tif (v463) goto L_03DD;\n\tv617 = UnityEngine.Component::get_transform(v74);\n\tgoto L_006F;\nL_0069:\n\tv617 = UnityEngine.GameObject::get_transform(v74);\nL_006F:\n\tgoto L_007B;\n\tv624 = UnityEngine.Quaternion;\n\tv625 = \"il2cpp_codegen_initialize_runtime_metadata\"(v624, v227, t, path, updateNotice, methodInfo, v59, v60, pathPerc, tPos, v0, v2, v61, v62, v63, v64);\n\tv626 = 1;\n\t*([1A3551A]) = v626;\nL_007B:\n\tv790 = UnityEngine.Quaternion;\n\tv791 = *([v790 @ X8_v14 (Il2CppClass<UnityEngine.Quaternion>)+B8]);\n\tv862 = v791.identityQuaternion;\n\tv961 = *([v791 @ X8_v15 (Il2CppStaticFields<UnityEngine.Quaternion>)+4]);\n\tv960 = *([v791 @ X8_v15 (Il2CppStaticFields<UnityEngine.Quaternion>)+8]);\n\tv959 = *([v791 @ X8_v15 (Il2CppStaticFields<UnityEngine.Quaternion>)+C]);\n\tv792 = UnityEngine.Transform::get_position(v617);\n\tv209 = updateNotice != 1;\n\tif (v209) goto L_009F;\n\tv957 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+58]);\n\tv964 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+5C]);\n\tv963 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+60]);\n\tUnityEngine.Transform::set_rotation(v617, options.startupRot);\nL_009F:\n\tv284 = options.orientType == 1;\n\tif (v284) goto L_00D8;\n\tv286 = options.orientType == 2;\n\tif (v286) goto L_011C;\n\tv208 = options.orientType != 3;\n\tif (v208) goto L_030A;\n\tv136 = 0;\n\tSystem.Nullable`1<UnityEngine.Vector3>::.ctor(&v136 @ stack_-A0_v9 (System.Nullable`1<UnityEngine.Vector3>), options.lookAtPosition);\n\tpath.lookAtPosition = 0;\n\tv1028 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+18]);\n\tv1052 = *([options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+1C]);\n\tv1049 = options.stableZRotation;\n\tv1045 = options.lookAtPosition - v792;\n\tgoto L_0143;\nL_00D8:\n\tv821 = options.lookAhead < 0.0001f;\n\tv321 = ~v821;\n\tv309 = options.lookAhead - 0.0001f;\n\tv285 = v309 == 0;\n\tv822 = ~v285;\n\tv210 = v321 & v822;\n\tif (v210) goto L_0168;\n\tv908 = path.type == 0;\n\tv909 = ~v908;\n\tif (v909) goto L_0168;\n\tv533 = path.linearWPIndex - 1;\n\tv1132 = path.wps + 0x20;\n\tv1133 = path.linearWPIndex * 0xC;\n\tv1074 = v1132 + v1133;\n\tv1076 = v533 * 0xC;\n\tv1078 = v1132 + v1076;\n\tv1069 = tPos.z + *([v1074 @ X9_v22+8]);\n\tv1068 = tPos.y + *([v1074 @ X9_v22+4]);\n\tv1080 = tPos + *([v1074 @ X9_v22]);\n\tv1072 = v1080 - *([v1078 @ X8_v73]);\n\tv186 = v1068 - *([v1078 @ X8_v73+4]);\n\tv179 = v1069 - *([v1078 @ X8_v73+8]);\n\tgoto L_019D;\nL_011C:\n\tgoto L_0121;\n\tv905 = \"il2cpp_codegen_runtime_class_init\"(v816, v218, t, path, updateNotice, methodInfo, v59, v60, v163, v152, v406, v401, v61, v62, v63, v64);\nL_0121:\n\tv882 = UnityEngine.Object::op_Inequality(options.lookAtTransform, 0);\n\tv885 = v882 == 0;\n\tif (v885) goto L_030A;\n\tv165 = UnityEngine.Transform::get_position(options.lookAtTransform);\n\tv136 = 0;\n\tSystem.Nullable`1<UnityEngine.Vector3>::.ctor(&v136 @ stack_-A0_v9 (System.Nullable`1<UnityEngine.Vector3>), v165);\n\tpath.lookAtPosition = 0;\n\tv1031 = UnityEngine.Transform::get_position(options.lookAtTransform);\n\tv1028 = v1031.y;\n\tv1052 = v1031.z;\n\tv1049 = options.stableZRotation;\n\tv1045 = v1031 - v792;\nL_0143:\n\tv1055 = v1028 - v792.y;\n\tv1057 = v1052 - v792.z;\n\tv1059 = v1049 == 0;\n\tv1060 = ~v1059;\n\tif (v1060) goto L_0157;\n\tv1126 = UnityEngine.Transform::get_up(v617);\n\tgoto L_FFFFFFFF;\nL_0157:\n\tgoto L_015F;\n\tv1150 = UnityEngine.Vector3;\n\tv1151 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1150, v1033, v1024, path, updateNotice, methodInfo, v59, v60, v1056, v1028, v1052, v1051, v61, v62, v63, v64);\n\tv1154 = 1;\n\t*([1A3575B]) = v1154;\nL_015F:\n\tv1157 = UnityEngine.Vector3;\n\tv1158 = *([v1157 @ X8_v80 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv1254 = v1158.upVector;\n\tv705 = *([v1158 @ X8_v81 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]);\n\tv703 = *([v1158 @ X8_v81 (Il2CppStaticFields<UnityEngine.Vector3>)+20]);\n\tgoto L_02FE;\nL_0168:\n\tv980 = options.lookAhead + pathPerc;\n\tv924 = v980 <= 1f;\n\tif (v924) goto L_0193;\n\tv973 = options.isClosedPath == 0;\n\tv974 = ~v973;\n\tif (v974) goto L_0190;\n\tv976 = path.type != 0;\n\tif (v976) goto L_FFFFFFFF;\n\tgoto L_018E;\nL_018E:\n\tgoto L_0193;\nL_0190:\n\tv980 = v980 + -1f;\nL_0193:\n\tv1004 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(path, v980, 0);\n\tv1021 = *([1A35020]) == 0;\n\tv1022 = ~v1021;\n\tif (v1022) goto L_01F6;\nL_019D:\n\tv391 = *([1A35018]);\n\tv552 = *([v391 @ X8_v68+18]) << 0x20;\n\tv1163 = 0xFFFFFFFF00000000 + v552;\n\tv1164 = v1163 >> 0x20;\n\tv597 = v1164 * 0xC;\n\tv558 = v391 + v597;\n\tv1165 = v193 - *([v558 @ X10_v15+20]);\n\tv1166 = v186 - *([v558 @ X10_v15+24]);\n\tv1167 = v1165 * v1165;\n\tv1168 = v1166 * v1166;\n\tv1169 = v1167 + v1168;\n\tv1170 = v179 - *([v558 @ X10_v15+28]);\n\tv1081 = v1170 * v1170;\n\tv1083 = v1081 + v1169;\n\tv1095 = v1083 >= 9.9999994E-11f;\n\tif (v1095) goto L_01F6;\n\tv1190 = tPos - *([v558 @ X10_v15+20]);\n\tv1191 = tPos.y - *([v558 @ X10_v15+24]);\n\tv839 = tPos.z - *([v558 @ X10_v15+28]);\n\tv1192 = v1190 * v1190;\n\tv1193 = v1191 * v1191;\n\tv1194 = v1192 + v1193;\n\tv529 = v839 * v839;\n\tv531 = v529 + v1194;\n\tv1094 = v531 >= 9.9999994E-11f;\n\tif (v1094) goto L_FFFFFFFF;\n\tv1285 = *([v391 @ X8_v68+18]) << 0x20;\n\tv1286 = v1285 + 0xFFFFFFFE00000000;\n\tv1114 = v1286 >> 0x20;\n\tv1117 = v1114 * 0xC;\n\tv1119 = v391 + v1117;\n\tv1120 = *([v558 @ X10_v15+20]) - *([v1119 @ X8_v69+20]);\n\tv1084 = *([v558 @ X10_v15+24]) - *([v1119 @ X8_v69+24]);\n\tv1082 = *([v558 @ X10_v15+28]) - *([v1119 @ X8_v69+28]);\n\tv1340 = *([v558 @ X10_v15+20]) + v1120;\n\tv1338 = *([v558 @ X10_v15+24]) + v1084;\n\tv1336 = *([v558 @ X10_v15+28]) + v1082;\n\tgoto L_01F6;\nL_01F6:\n\tv168 = UnityEngine.Transform::get_up(v617);\n\tgoto L_0208;\n\tv1172 = \"il2cpp_codegen_runtime_class_init\"(v1140, v1123, t, path, updateNotice, methodInfo, v59, v60, v168, v156, v409, v403, v122, v119, v104, v64);\nL_0208:\n\tv1175 = UnityEngine.Object::op_Inequality(options.parent, 0);\n\tv380 = v1175 & options.useLocalPosition;\n\tv1196 = v380 & 1;\n\tv1197 = v1196 == 0;\n\tif (v1197) goto L_021D;\n\t// 534 MakeStruct v1264 @ AGGC24624_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1340 @ V11_v15 (UnityEngine.Vector3), v1338 @ V12_v15 (System.Single), v1336 @ V13_v15 (System.Single)\n\tv1268 = UnityEngine.Transform::TransformPoint(options.parent, v1264);\nL_021D:\n\tv1320 = options.lockRotationAxis;\n\tv1281 = options.lockRotationAxis == 0;\n\tif (v1281) goto L_02B6;\n\tv381 = v380 & 1;\n\tv1293 = options.lockRotationAxis & 2;\n\tv1294 = v1293 == 0;\n\tif (v1294) goto L_0256;\n\t// 553 MakeStruct v97 @ AGGC24658_1_v9 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1340 @ V11_v15 (UnityEngine.Vector3), v1338 @ V12_v15 (System.Single), v1336 @ V13_v15 (System.Single)\n\tv1366 = UnityEngine.Transform::InverseTransformPoint(v617, v97);\n\t// 560 MakeStruct v92 @ AGGC24668_1_v9 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1366 @ V0_v56 (UnityEngine.Vector3), 0, v1366.z (System.Single)\n\tv169 = UnityEngine.Transform::TransformPoint(v617, v92);\n\tv1474 = v381 == 0;\n\tif (v1474) goto L_0248;\n\tv1543 = UnityEngine.Transform::get_up(options.parent);\n\tgoto L_0255;\nL_0248:\n\tgoto L_0250;\n\tv1545 = UnityEngine.Vector3\n// ... truncated")]
		public unsafe void SetOrientation(PathOptions options, Tween t, Path path, float pathPerc, Vector3 tPos, UpdateNotice updateNotice)
		{
			//IL_00a4: Expected I, but got O
			//IL_00ad: Expected I, but got O
			//IL_00c6: Expected F4, but got I
			//IL_00d6: Expected F4, but got I
			//IL_00e6: Expected F4, but got I
			//IL_0152: Expected F4, but got I
			//IL_0162: Expected F4, but got I
			//IL_0172: Expected F4, but got I
			//IL_05f8: Expected O, but got I
			//IL_0625: Expected O, but got I8
			//IL_0650: Expected O, but got I
			//IL_034d: Expected O, but got I
			//IL_036e: Expected O, but got I
			//IL_038a: Expected O, but got I
			//IL_041b: Expected O, but got F4
			//IL_174f: Expected O, but got Ref
			//IL_0efa: Expected O, but got F4
			//IL_0f02: Expected O, but got F4
			//IL_0247: Expected F4, but got I
			//IL_0257: Expected F4, but got I
			//IL_08f5: Expected F4, but got I
			//IL_0905: Expected F4, but got I
			//IL_0915: Expected O, but got I
			//IL_1007: Expected O, but got F4
			//IL_153f: Expected I, but got O
			//IL_1548: Expected I, but got O
			//IL_0808: Expected O, but got I8
			//IL_0833: Expected O, but got I
			//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a5: Expected F4, but got Unknown
			//IL_1267: Expected I, but got O
			//IL_1270: Expected I, but got O
			//IL_1289: Expected F4, but got I
			//IL_1299: Expected F4, but got I
			//IL_13fd: Expected I, but got O
			//IL_1406: Expected I, but got O
			//IL_141f: Expected F4, but got I
			//IL_142f: Expected F4, but got I
			//IL_112b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1130: Expected I4, but got Unknown
			//IL_113d: Expected O, but got F4
			GameObject target = (GameObject)t.target;
			Transform transform;
			if ((object)target.GetType() != typeof(GameObject))
			{
				Component component = target as Component;
				if ((object)component == null)
				{
					goto IL_11b6;
				}
				transform = ((Component)(object)target).transform;
			}
			else
			{
				transform = target.transform;
			}
			nint num = (nint)typeof(Quaternion);
			nint num2 = (nint)Quaternion.identity;
			Quaternion quaternion = Quaternion.identity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ X8_v15 (Il2CppStaticFields<UnityEngine.Quaternion>)+4]");
			float num3 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ X8_v15 (Il2CppStaticFields<UnityEngine.Quaternion>)+8]");
			float num4 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ X8_v15 (Il2CppStaticFields<UnityEngine.Quaternion>)+C]");
			float num5 = 0f;
			Vector3 position = transform.position;
			bool flag = updateNotice != UpdateNotice.RewindStep;
			float y = position.y;
			Vector3 vector = position;
			float z = tPos.z;
			float z2 = position.z;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+58]");
				y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+5C]");
				z2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+60]");
				z = 0f;
				transform.rotation = options.startupRot;
				vector = (Vector3)options.startupRot;
			}
			Vector3 vector3;
			float y3;
			float x;
			float z4;
			float z3;
			float y2;
			if (options.orientType != OrientType.ToPath)
			{
				float num6;
				float num7;
				bool stableZRotation;
				float num8;
				if (options.orientType != OrientType.LookAtTransform)
				{
					if (options.orientType != OrientType.LookAtPosition)
					{
						goto IL_11ca;
					}
					Vector3? vector2 = null;
					vector2 = options.lookAtPosition;
					path.lookAtPosition = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+18]");
					num6 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+1C]");
					num7 = 0f;
					stableZRotation = options.stableZRotation;
					num8 = options.lookAtPosition.x - position.x;
				}
				else
				{
					if (!(options.lookAtTransform != null))
					{
						goto IL_11ca;
					}
					Vector3 position2 = options.lookAtTransform.position;
					Vector3? vector2 = null;
					vector2 = position2;
					path.lookAtPosition = null;
					Vector3 position3 = options.lookAtTransform.position;
					num6 = position3.y;
					num7 = position3.z;
					stableZRotation = options.stableZRotation;
					num8 = position3.x - position.x;
				}
				float num9 = num6 - position.y;
				float num10 = num7 - position.z;
				if (!stableZRotation)
				{
					Vector3 up = transform.up;
					z3 = up.z;
					y2 = up.y;
					vector3 = up;
				}
				else
				{
					nint num11 = (nint)typeof(Vector3);
					nint num12 = (nint)Vector3.zero;
					vector3 = Vector3.upVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v81 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					y2 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v81 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					z3 = 0f;
				}
				y3 = num9;
				x = num8;
				z4 = num10;
				goto IL_1750;
			}
			bool flag2 = options.lookAhead < 0.0001f;
			bool flag3 = !flag2;
			float num13 = options.lookAhead - 0.0001f;
			bool flag4 = num13 == 0f;
			bool flag5 = !flag4;
			Vector3 vector4 = default(Vector3);
			float num24;
			float num26;
			Vector3 vector5;
			float num28;
			float num29;
			Vector3 vector6;
			if (!(flag3 && flag5) && path.type == PathType.Linear)
			{
				int num14 = path.linearWPIndex - 1;
				object obj = (nint)path.wps + 32;
				int num15 = path.linearWPIndex * 12;
				object obj2 = (nint)obj + num15;
				int num16 = num14 * 12;
				object obj3 = (nint)obj + num16;
				float num17 = tPos.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ X9_v22+8]");
				float num18 = num17 + 0f;
				float num19 = tPos.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ X9_v22+4]");
				float num20 = num19 + 0f;
				float num21 = vector4.x + (float)obj2;
				float num22 = num21 - (float)obj3;
				float num23 = num20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ X8_v73+4]");
				num24 = num23 - 0f;
				float num25 = num18;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ X8_v73+8]");
				num26 = num25 - 0f;
				vector5 = (Vector3)num22;
			}
			else
			{
				float num27 = options.lookAhead + pathPerc;
				if (num27 > 1f)
				{
					num27 = (options.isClosedPath ? (num27 + -1f) : ((path.type != PathType.Linear) ? 1.00001f : 1f));
				}
				Vector3 point = path.GetPoint(num27);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35020]");
				bool flag6 = (nint)0 == 0;
				bool flag7 = !flag6;
				num26 = point.z;
				num24 = point.y;
				vector5 = point;
				num28 = point.z;
				num29 = point.y;
				vector6 = point;
				if (flag7)
				{
					goto IL_132d;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35018]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ X8_v68+18]");
			int num30 = (int)((nint)0 << 32);
			object obj5 = -4294967296L + num30;
			int num31 = (int)((nint)obj5 >> 32);
			int num32 = num31 * 12;
			object obj6 = (nint)obj4 + num32;
			float num33 = vector5.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+20]");
			float num34 = num33 - 0f;
			float num35 = num24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+24]");
			float num36 = num35 - 0f;
			float num37 = num34 * num34;
			float num38 = num36 * num36;
			float num39 = num37 + num38;
			float num40 = num26;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+28]");
			float num41 = num40 - 0f;
			float num42 = num41 * num41;
			float num43 = num42 + num39;
			bool flag8 = !(num43 < 9.9999994E-11f);
			num28 = num26;
			num29 = num24;
			vector6 = vector5;
			if (!flag8)
			{
				float num44 = vector4.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+20]");
				float num45 = num44 - 0f;
				float num46 = tPos.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+24]");
				float num47 = num46 - 0f;
				float num48 = tPos.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+28]");
				float num49 = num48 - 0f;
				float num50 = num45 * num45;
				float num51 = num47 * num47;
				float num52 = num50 + num51;
				float num53 = num49 * num49;
				float num54 = num53 + num52;
				if (num54 < 9.9999994E-11f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ X8_v68+18]");
					int num55 = (int)((nint)0 << 32);
					object obj7 = num55 + -8589934592L;
					int num56 = (int)((nint)obj7 >> 32);
					int num57 = num56 * 12;
					object obj8 = (nint)obj4 + num57;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+20]");
					float num58 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1119 @ X8_v69+20]");
					float num59 = num58 - 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+24]");
					float num60 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1119 @ X8_v69+24]");
					float num61 = num60 - 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+28]");
					float num62 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1119 @ X8_v69+28]");
					float num63 = num62 - 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+20]");
					float x2 = 0 + num59;
					vector6.x = x2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+24]");
					num29 = 0f + num61;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+28]");
					num28 = 0f + num63;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+28]");
					num28 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+24]");
					num29 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X10_v15+20]");
					vector6 = (Vector3)0;
				}
			}
			goto IL_132d;
			IL_1750:
			Vector3 forward = default(Vector3);
			forward.x = x;
			forward.y = y3;
			forward.z = z4;
			Vector3 upwards = default(Vector3);
			upwards.x = vector3.x;
			upwards.y = y2;
			upwards.z = z3;
			Quaternion quaternion2 = Quaternion.LookRotation(forward, upwards);
			y = quaternion2.y;
			z2 = quaternion2.z;
			z = quaternion2.w;
			goto IL_16ca;
			IL_11ca:
			if (options.hasCustomForwardDirection)
			{
				float num64 = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+3C]");
				float num65 = num64 * 0f;
				float num66 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+3C]");
				float num67 = num66 * 0f;
				float num68 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+38]");
				float num69 = num68 * 0f;
				float num70 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+3C]");
				float num71 = num70 * 0f;
				float num72 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+3C]");
				float num73 = num72 * 0f;
				float num74 = num5 * options.forward.x;
				float num75 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+34]");
				float num76 = num75 * 0f;
				float num77 = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+34]");
				float num78 = num77 * 0f;
				float num79 = quaternion.x * options.forward.x;
				float num80 = num69 + num73;
				float num81 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+38]");
				float num49 = num81 * 0f;
				float num82 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+34]");
				float num83 = num82 * 0f;
				float num84 = num4 * options.forward.x;
				float num85 = num3 * options.forward.x;
				float num86 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+34]");
				z = num86 * 0f;
				float num87 = num74 + num65;
				float num88 = num76 + num67;
				float num89 = num71 - num79;
				y = num78 + num80;
				float num90 = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+38]");
				float num91 = num90 * 0f;
				float num92 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.PathOptions)+38]");
				z2 = num92 * 0f;
				y2 = num49 + num87;
				z3 = num84 + num88;
				num4 = y - num85;
				float num93 = num89 - z;
				float num94 = y2 - num83;
				num3 = z3 - num91;
				num5 = num93 - z2;
				vector = (Vector3)num93;
				quaternion = (Quaternion)num94;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			Quaternion newRot = default(Quaternion);
			newRot.x = quaternion.x;
			newRot.y = num3;
			newRot.z = num4;
			newRot.w = num5;
			object obj9 = default(object);
			DOTweenExternalCommand.Dispatch_SetOrientationOnPath((PathOptions)(&obj9), t, newRot, transform);
			return;
			IL_16ca:
			vector = (Vector3)quaternion2;
			num5 = z;
			num4 = z2;
			num3 = y;
			quaternion = quaternion2;
			goto IL_11ca;
			IL_132d:
			Vector3 up2 = transform.up;
			bool flag9 = options.parent != null;
			int num95 = ((flag9 & options.useLocalPosition) ? 1 : 0);
			if ((num95 & 1) != 0)
			{
				Vector3 position4 = default(Vector3);
				position4.x = vector6.x;
				position4.y = num29;
				position4.z = num28;
				Vector3 vector7 = options.parent.TransformPoint(position4);
				num28 = vector7.z;
				num29 = vector7.y;
				vector6 = vector7;
			}
			AxisConstraint lockRotationAxis = options.lockRotationAxis;
			bool flag10 = options.lockRotationAxis == AxisConstraint.None;
			float num96 = up2.z;
			float num97 = up2.y;
			Vector3 vector8 = up2;
			if (!flag10)
			{
				int num98 = num95 & 1;
				int num99 = (int)(options.lockRotationAxis & AxisConstraint.X);
				bool flag11 = num99 == 0;
				num96 = up2.z;
				num97 = up2.y;
				vector8 = up2;
				if (!flag11)
				{
					Vector3 position5 = default(Vector3);
					position5.x = vector6.x;
					position5.y = num29;
					position5.z = num28;
					Vector3 vector9 = transform.InverseTransformPoint(position5);
					Vector3 position6 = default(Vector3);
					position6.x = vector9.x;
					position6.y = 0f;
					position6.z = vector9.z;
					Vector3 vector10 = transform.TransformPoint(position6);
					if (num98 != 0)
					{
						Vector3 up3 = options.parent.up;
						num96 = up3.z;
						num97 = up3.y;
						vector8 = up3;
					}
					else
					{
						nint num100 = (nint)typeof(Vector3);
						nint num101 = (nint)Vector3.zero;
						vector8 = Vector3.upVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1553 @ X8_v65 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
						num97 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1553 @ X8_v65 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						num96 = 0f;
					}
					lockRotationAxis = options.lockRotationAxis;
					num28 = vector10.z;
					num29 = vector10.y;
					vector6 = vector10;
				}
				if ((lockRotationAxis & AxisConstraint.Y) != AxisConstraint.None)
				{
					Vector3 position7 = default(Vector3);
					position7.x = vector6.x;
					position7.y = num29;
					position7.z = num28;
					Vector3 vector11 = transform.InverseTransformPoint(position7);
					float z5 = vector11.z;
					float num102 = 0f - vector11.z;
					if (vector11.z < 0f)
					{
						z5 = num102;
					}
					Vector3 position8 = default(Vector3);
					position8.x = 0f;
					position8.y = vector11.y;
					position8.z = z5;
					Vector3 vector12 = transform.TransformPoint(position8);
					lockRotationAxis = options.lockRotationAxis;
					num28 = vector12.z;
					num29 = vector12.y;
					vector6 = vector12;
				}
				if ((lockRotationAxis & AxisConstraint.Z) != AxisConstraint.None)
				{
					Transform transform2;
					if (num98 != 0)
					{
						transform2 = options.parent;
						if ((object)options.parent == null)
						{
							NullReferenceException ex = new NullReferenceException();
							goto IL_11b6;
						}
					}
					else
					{
						transform2 = transform;
					}
					Vector3 vector13 = transform2.TransformDirection(Vector3.upVector);
					num96 = options.startupZRot;
					num97 = vector13.y;
					vector8 = vector13;
				}
			}
			if (options.mode == PathMode.Full3D)
			{
				float num103 = vector6.x - position.x;
				float num104 = num29 - position.y;
				float num105 = num28 - position.z;
				nint num106 = (nint)typeof(Vector3);
				nint num107 = (nint)Vector3.zero;
				float num108 = num103 - Vector3.zero.x;
				float num109 = num104;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v43 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
				float num110 = num109 - 0f;
				float num111 = num108 * num108;
				float num112 = num110 * num110;
				float num113 = num111 + num112;
				float num114 = num105;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v43 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				float num115 = num114 - 0f;
				float num116 = num115 * num115;
				float num117 = num116 + num113;
				if (num117 < 9.9999994E-11f)
				{
					Vector3 forward2 = transform.forward;
					num103 = forward2.x;
					num105 = forward2.z;
					num104 = forward2.y;
				}
				if (flag9)
				{
					Vector3 localScale = options.parent.localScale;
					num103 /= localScale.x;
					num104 /= localScale.y;
					num105 /= localScale.z;
				}
				z3 = num96;
				y2 = num97;
				y3 = num104;
				x = num103;
				vector3 = vector8;
				z4 = num105;
				goto IL_1750;
			}
			bool flag12 = !flag9;
			Vector3 vector14 = position;
			if (!flag12)
			{
				float num118 = num28 - position.z;
				float num119 = num29 - position.y;
				float num120 = vector6.x - position.x;
				Vector3 localScale2 = options.parent.localScale;
				float num121 = num120 / localScale2.x;
				float num122 = num119 / localScale2.y;
				float num123 = num118 / localScale2.z;
				float num124 = position.x + num121;
				num29 = position.y + num122;
				num28 = position.z + num123;
				vector14 = position;
				vector6 = (Vector3)num124;
			}
			Vector3 vector15 = default(Vector3);
			vector15.x = vector14.x;
			vector15.y = position.y;
			vector15.z = position.z;
			Vector3 to = default(Vector3);
			to.x = vector6.x;
			to.y = num29;
			to.z = num28;
			float num125 = DOTweenUtils.Angle2D(vector15, to);
			float num126 = num125 + 360f;
			if (num125 < 0f)
			{
				num125 = num126;
			}
			bool flag13 = options.mode != PathMode.Sidescroller2D;
			float y4 = 0f;
			if (!flag13)
			{
				float num127 = 180f - num125;
				bool flag14;
				bool flag15;
				bool flag16;
				if (num125 < 270f)
				{
					float num128 = num125 - 90f;
					flag14 = num128 < 0f;
					flag15 = num128 == 0f;
					int num129 = num125 ^ 0x42B40000;
					object obj10 = num125 ^ num128;
					int num130 = (int)(num129 & (nint)obj10);
					flag16 = num130 < 0;
				}
				else
				{
					flag16 = false;
					flag15 = true;
					flag14 = false;
				}
				bool flag17 = flag14 == flag16;
				bool flag18 = !flag15;
				if (flag17 && flag18)
				{
					num125 = num127;
				}
				y4 = ((!(vector6.x < vector14.x)) ? 0f : ((float)Math.PI));
			}
			float z6 = num125 * ((float)Math.PI / 180f);
			Vector3 vector16 = default(Vector3);
			vector16.x = 0f;
			vector16.y = y4;
			vector16.z = z6;
			quaternion2 = Quaternion.Euler(vector16 * 57.29578f);
			y = quaternion2.y;
			z2 = quaternion2.z;
			z = quaternion2.w;
			z3 = num28;
			y2 = num29;
			goto IL_16ca;
			IL_11b6:
			InvalidCastException ex2 = new InvalidCastException();
			throw new IndexOutOfRangeException();
		}

		[Token(Token = "0x60002FB")]
		[Address(RVA = "0xC20B24", Offset = "0xC20B24", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = vector / byVector;\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector3 DivideVectorByVector(Vector3 vector, Vector3 byVector)
		{
			return (Vector3)((object)vector / (object)byVector);
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0xC20B34", Offset = "0xC20B34", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = vector * byVector;\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector3 MultiplyVectorByVector(Vector3 vector, Vector3 byVector)
		{
			return (Vector3)((object)vector * (object)byVector);
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0xC20B44", Offset = "0xC20B44", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3576C]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector3, System.Object, DG.Tweening.Plugins.Options.PathOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathPlugin()
		{
		}
	}
}
