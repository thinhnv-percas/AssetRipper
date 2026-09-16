using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000025")]
	public class QuaternionPlugin : ABSTweenPlugin<Quaternion, Vector3, QuaternionOptions>
	{
		[Token(Token = "0x60001C9")]
		[Address(RVA = "0x10D98F4", Offset = "0x10D98F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0x10D98F8", Offset = "0x10D98F8", Length = "0x350")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = *([1EBBDE8]);\n\tv35 = *([v34 @ X8_v37]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, t, isRelative, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([20274B8]) = v54;\nL_0023:\n\tv181 = t.endValue;\n\tv179 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]);\n\tv177 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]);\n\tv198 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::Invoke(t.getter);\n\tv275 = 0x10CC508(&v198 @ V0_v3 (UnityEngine.Quaternion), 0, isRelative, methodInfo, v39, v40, v41, v42, v198, v198.y, v198.z, v198.w, v47, v48, v49, v50);\n\tv232 = t.plugOptions == 1;\n\tt.endValue = v198;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) = v198.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]) = v198.z;\n\tif (v232) goto L_00B0;\n\tv350 = t.plugOptions == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_004E;\n\tv359 = ~t.<isRelative>k__BackingField;\n\tif (v359) goto L_00C5;\nL_004E:\n\tv198 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::Invoke(t.getter);\n\tv575 = v198.y;\n\tv573 = v198.z;\n\tv571 = v198.w;\n\tv417 = t.plugOptions != 2;\n\tif (v417) goto L_00CB;\n\tgoto L_0074;\n\tv484 = *([v466 @ X0_v21+E0]);\n\tv485 = v484 == 0;\n\tv486 = ~v485;\n\tif (v486) goto L_0074;\n\tv488 = \"il2cpp_codegen_runtime_class_init\"(v466, v397, isRelative, methodInfo, v39, v40, v41, v42, v398, v459, v460, v461, v47, v48, v49, v50);\nL_0074:\n\tv198 = UnityEngine.Quaternion::Inverse(v198);\n\tv198 = UnityEngine.Quaternion::op_Multiply(v198, v198);\n\tv198 = UnityEngine.Quaternion::Euler(t.endValue);\n\tv198 = UnityEngine.Quaternion::op_Multiply(v198, v198);\n\tgoto L_00EB;\nL_00B0:\n\tgoto L_00BD;\n\tv361 = *([v354 @ X0_v16+E0]);\n\tv362 = v361 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_00BD;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v354, v261, isRelative, methodInfo, v39, v40, v41, v42, v198, v258, v256, v254, v47, v48, v49, v50);\nL_00BD:\n\t// 189 MakeStruct v375 @ AGG10D9AD8_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v198 @ V0_v3 (UnityEngine.Quaternion), v198.y (System.Single), v198.z (System.Single)\n\tv377 = UnityEngine.Vector3::op_Addition(v375, t.endValue);\nL_00C5:\n\tt.startValue = v181;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+120]) = v179;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+124]) = v177;\n\tgoto L_011C;\nL_00CB:\n\tgoto L_00D6;\n\tv498 = *([v466 @ X0_v21+E0]);\n\tv499 = v498 == 0;\n\tv500 = ~v499;\n\tif (v500) goto L_00D6;\n\tv502 = \"il2cpp_codegen_runtime_class_init\"(v466, v397, isRelative, methodInfo, v39, v40, v41, v42, v398, v459, v460, v461, v47, v48, v49, v50);\nL_00D6:\n\tv198 = UnityEngine.Quaternion::Euler(t.endValue);\nL_00EB:\n\t// 235 MakeStruct v400 @ AGG10D9B60_0_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v198 @ V0_v3 (UnityEngine.Quaternion), v575 @ V1_v11 (System.Single), v573 @ V2_v11 (System.Single), v571 @ V3_v9 (System.Single)\n\t// 236 MakeStruct v399 @ AGG10D9B60_1_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v430 @ V11_v7 (UnityEngine.Quaternion), v429 @ V12_v7 (System.Single), v428 @ V13_v7 (System.Single), v418 @ V14_v6 (System.Single)\n\tv198 = UnityEngine.Quaternion::op_Multiply(v400, v399);\n\tv595 = 0x10CC508(&v198 @ V0_v3 (UnityEngine.Quaternion), 0, isRelative, methodInfo, v39, v40, v41, v42, v198, v198.y, v198.z, v198.w, v430, v429, v428, v418);\n\tt.startValue = v198;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+120]) = v198.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+124]) = v198.z;\n\tgoto L_010C;\n\tv602 = *([v598 @ X0_v26+E0]);\n\tv603 = v602 == 0;\n\tv604 = ~v603;\n\tgoto L_010C;\n\tv606 = \"il2cpp_codegen_runtime_class_init\"(v598, v443, isRelative, methodInfo, v39, v40, v41, v42, v584, v592, v593, v436, v415, v414, v413, v412);\nL_010C:\n\tv442 = UnityEngine.Vector3::op_UnaryNegation(t.endValue);\n\tv181 = t.startValue;\n\tv179 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+120]);\n\tv177 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+124]);\n\tt.endValue = v442;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) = v442.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]) = v442.z;\nL_011C:\n\tgoto L_0126;\n\tv471 = *([v455 @ X0_v10+E0]);\n\tv472 = v471 == 0;\n\tv473 = ~v472;\n\tgoto L_0126;\n\tv475 = \"il2cpp_codegen_runtime_class_init\"(v455, v175, isRelative, methodInfo, v39, v40, v41, v42, v441, v439, v437, v435, v114, v112, v110, v108);\nL_0126:\n\t// 294 MakeStruct v67 @ AGG10D9C04_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v181 @ V10_v4 (UnityEngine.Vector3), v179 @ V9_v4 (System.Single), v177 @ V8_v4 (System.Single)\n\tv198 = UnityEngine.Quaternion::Euler(v67);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(t.setter, v198);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 235 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool isRelative)
		{
			//IL_0022: Expected F4, but got I
			//IL_0032: Expected F4, but got I
			//IL_02dc: Expected F4, but got I
			//IL_02ec: Expected F4, but got I
			Vector3 startValue = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
			float y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]");
			float z = 0f;
			Quaternion endValue = t.getter();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
			bool flag = (IntPtr)t.plugOptions == (IntPtr)1;
			t.endValue = (Vector3)endValue;
			_ = endValue.y;
			_ = endValue.z;
			if (!flag)
			{
				if ((object)t.plugOptions != null || t._003CisRelative_003Ek__BackingField)
				{
					endValue = t.getter();
					float y2 = endValue.y;
					float z2 = endValue.z;
					float w = endValue.w;
					float w2;
					float z3;
					float y3;
					Quaternion quaternion;
					if ((IntPtr)t.plugOptions == (IntPtr)2)
					{
						endValue = Quaternion.Inverse(endValue);
						endValue *= endValue;
						endValue = Quaternion.Euler(t.endValue);
						endValue *= endValue;
						w2 = endValue.w;
						z3 = endValue.z;
						y3 = endValue.y;
						quaternion = endValue;
						w = endValue.w;
						z2 = endValue.z;
						y2 = endValue.y;
					}
					else
					{
						endValue = Quaternion.Euler(t.endValue);
						w2 = endValue.w;
						z3 = endValue.z;
						y3 = endValue.y;
						quaternion = endValue;
					}
					Quaternion quaternion2 = default(Quaternion);
					quaternion2.x = endValue.x;
					quaternion2.y = y2;
					quaternion2.z = z2;
					quaternion2.w = w;
					Quaternion quaternion3 = default(Quaternion);
					quaternion3.x = quaternion.x;
					quaternion3.y = y3;
					quaternion3.z = z3;
					quaternion3.w = w2;
					endValue = quaternion2 * quaternion3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
					t.startValue = (Vector3)endValue;
					_ = endValue.y;
					_ = endValue.z;
					Vector3 endValue2 = -t.endValue;
					startValue = t.startValue;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+120]");
					y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+124]");
					z = 0f;
					t.endValue = endValue2;
					_ = endValue2.y;
					_ = endValue2.z;
					goto IL_0312;
				}
			}
			else
			{
				Vector3 vector = default(Vector3);
				vector.x = endValue.x;
				vector.y = endValue.y;
				vector.z = endValue.z;
				Vector3 vector2 = vector + t.endValue;
				z = vector2.z;
				y = vector2.y;
				startValue = vector2;
			}
			t.startValue = startValue;
			goto IL_0312;
			IL_0312:
			Vector3 euler = default(Vector3);
			euler.x = startValue.x;
			euler.y = y;
			euler.z = z;
			endValue = Quaternion.Euler(euler);
			t.setter(endValue);
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0x10D9C48", Offset = "0x10D9C48", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1F017C0]);\n\tv35 = *([v34 @ X8_v13]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, t, setImmediately, methodInfo, v38, v39, v40, v41, fromValue, v0, v2, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([20274B9]) = v50;\nL_001F:\n\tt.startValue = fromValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+120]) = fromValue.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+124]) = fromValue.z;\n\tv53 = setImmediately == 0;\n\tif (v53) goto L_0056;\n\tgoto L_0037;\n\tv89 = *([v77 @ X0_v5+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0037;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v77, t, setImmediately, methodInfo, v38, v39, v40, v41, fromValue, v0, v2, v42, v43, v44, v45, v46);\nL_0037:\n\tv60 = UnityEngine.Quaternion::Euler(fromValue);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(t.setter, v60);\n\treturn;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Vector3 fromValue, bool setImmediately)
		{
			t.startValue = fromValue;
			_ = fromValue.y;
			_ = fromValue.z;
			if (setImmediately)
			{
				Quaternion pNewValue = Quaternion.Euler(fromValue);
				t.setter(pNewValue);
			}
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0x10D9D30", Offset = "0x10D9D30", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0x10CC508(&value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>), 0, methodInfo, v18, v19, v20, v21, v22, value, *([value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+4]), *([value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+8]), *([value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+C]), v23, v24, v25, v26);\n\treturn value;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector3 ConvertToStartValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Quaternion value)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
			return (Vector3)value;
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0x10D9D5C", Offset = "0x10D9D5C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv30 = *([1ED3B60]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, t, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([20274BA]) = v50;\nL_0027:\n\tgoto L_0036;\n\tv66 = *([v59 @ X0_v4+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0036;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v59, t, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0036:\n\tv82 = UnityEngine.Vector3::op_Addition(t.endValue, t.startValue);\n\tt.endValue = v82;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) = v82.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]) = v82.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
			Vector3 vector = (t.endValue += t.startValue);
			_ = vector.y;
			_ = vector.z;
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0x10D9E24", Offset = "0x10D9E24", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = *([1EC8F18]);\n\tv33 = *([v32 @ X8_v23]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, t, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([20274BB]) = v52;\nL_0021:\n\tv59 = t.plugOptions == 1;\n\tif (v59) goto L_003C;\n\tv66 = t.plugOptions == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_002E;\n\tv85 = ~t.<isRelative>k__BackingField;\n\tif (v85) goto L_0063;\nL_002E:\n\tv69 = ~t.<isRelative>k__BackingField;\n\tif (v69) goto L_004F;\nL_003C:\n\tgoto L_004B;\n\tv88 = *([v79 @ X0_v5+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_004B;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v79, t, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_004B:\n\tv141 = UnityEngine.Vector3::op_Subtraction(t.endValue, t.startValue);\n\tv139 = v141.y;\n\tv137 = v141.z;\n\tgoto L_0144;\nL_004F:\n\tv141 = t.endValue;\n\tv139 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]);\n\tv137 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]);\n\tgoto L_0144;\nL_0063:\n\tv206 = t.endValue <= 360f;\n\tif (v206) goto L_0074;\n\tv287 = 0x6D1F60(v287, t, methodInfo, v36, v37, v38, v39, v40, t.endValue, 360f, v43, v44, v45, v46, v47, v48);\nL_0074:\n\tv231 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) <= 360f;\n\tif (v231) goto L_0085;\n\tv287 = 0x6D1F60(v287, t, methodInfo, v36, v37, v38, v39, v40, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]), 360f, v43, v44, v45, v46, v47, v48);\nL_0085:\n\tv299 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]) <= 360f;\n\tif (v299) goto L_0094;\n\tv302 = 0x6D1F60(v287, t, methodInfo, v36, v37, v38, v39, v40, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]), 360f, v43, v44, v45, v46, v47, v48);\nL_0094:\n\tgoto L_00A1;\n\tv313 = *([v309 @ X0_v12+E0]);\n\tv314 = v313 == 0;\n\tv315 = ~v314;\n\tgoto L_00A1;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v309, t, methodInfo, v36, v37, v38, v39, v40, v304, v303, v43, v44, v45, v46, v47, v48);\nL_00A1:\n\t// 161 MakeStruct v239 @ AGG10D9F9C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), t.endValue (UnityEngine.Vector3), [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C], [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]\n\tv141 = UnityEngine.Vector3::op_Subtraction(v239, t.startValue);\n\tv139 = v141.y;\n\tv137 = v141.z;\n\tv343 = -v141;\n\tv331 = v141 < 0;\n\tv332 = v141 == 0;\n\tv334 = v141 ^ v141;\n\tv335 = v141 & v334;\n\tv336 = v335 < 0;\n\tv337 = v331 == v336;\n\tv338 = ~v332;\n\tv339 = v337 & v338;\n\tv340 = ~v339;\n\tif (v340) goto L_00C6;\n\tgoto L_00C6;\nL_00C6:\n\tv355 = v343 <= 180f;\n\tif (v355) goto L_00DC;\n\tv356 = 360f - v343;\n\tv357 = -v356;\n\tv361 = v141 < 0;\n\tv362 = v141 == 0;\n\tv364 = v141 ^ v141;\n\tv365 = v141 & v364;\n\tv366 = v365 < 0;\n\tv367 = v361 == v366;\n\tv368 = ~v362;\n\tv369 = v367 & v368;\n\tv370 = ~v369;\n\tif (v370) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\tv402 = -v139;\n\tv390 = v139 < 0;\n\tv391 = v139 == 0;\n\tv393 = v139 ^ v139;\n\tv394 = v139 & v393;\n\tv395 = v394 < 0;\n\tv396 = v390 == v395;\n\tv397 = ~v391;\n\tv398 = v396 & v397;\n\tv399 = ~v398;\n\tif (v399) goto L_00FA;\n\tgoto L_00FA;\nL_00FA:\n\tv414 = v402 <= 180f;\n\tif (v414) goto L_0110;\n\tv415 = 360f - v402;\n\tv416 = -v415;\n\tv420 = v139 < 0;\n\tv421 = v139 == 0;\n\tv423 = v139 ^ v139;\n\tv424 = v139 & v423;\n\tv425 = v424 < 0;\n\tv426 = v420 == v425;\n\tv427 = ~v421;\n\tv428 = v426 & v427;\n\tv429 = ~v428;\n\tif (v429) goto L_FFFFFFFF;\n\tgoto L_0110;\nL_0110:\n\tv243 = -v137;\n\tv448 = v137 < 0;\n\tv449 = v137 == 0;\n\tv451 = v137 ^ v137;\n\tv452 = v137 & v451;\n\tv453 = v452 < 0;\n\tv454 = v448 == v453;\n\tv236 = ~v449;\n\tv455 = v454 & v236;\n\tv234 = ~v455;\n\tif (v234) goto L_012E;\n\tgoto L_012E;\nL_012E:\n\tv240 = v243 <= 180f;\n\tif (v240) goto L_0144;\n\tv246 = 360f - v243;\n\tv244 = -v246;\n\tv273 = v137 < 0;\n\tv271 = v137 == 0;\n\tv267 = v137 ^ v137;\n\tv265 = v137 & v267;\n\tv263 = v265 < 0;\n\tv462 = v273 == v263;\n\tv237 = ~v271;\n\tv241 = v462 & v237;\n\tv235 = ~v241;\n\tif (v235) goto L_FFFFFFFF;\n\tgoto L_0144;\nL_0144:\n\tt.changeValue = v141;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) = v139;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+13C]) = v137;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 208 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
			//IL_00ec: Expected F4, but got I
			//IL_00fc: Expected F4, but got I
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Expected O, but got Unknown
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Expected O, but got Unknown
			//IL_01a7: Expected F4, but got I
			//IL_01bc: Expected F4, but got I
			//IL_01f0: Unsupported input type for neg.
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Expected O, but got Unknown
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Expected I4, but got Unknown
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Expected O, but got Unknown
			//IL_060e: Expected O, but got F4
			//IL_0617: Unknown result type (might be due to invalid IL or missing references)
			//IL_061c: Expected I4, but got Unknown
			//IL_02b5: Expected O, but got F4
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Expected I4, but got Unknown
			//IL_06a2: Expected O, but got F4
			//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b0: Expected I4, but got Unknown
			//IL_035f: Expected O, but got F4
			//IL_03b9: Expected O, but got F4
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c7: Expected I4, but got Unknown
			//IL_0484: Expected O, but got F4
			//IL_048d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Expected I4, but got Unknown
			Vector3 vector;
			float num;
			float num2;
			if ((IntPtr)t.plugOptions != (IntPtr)1)
			{
				if ((object)t.plugOptions != null || t._003CisRelative_003Ek__BackingField)
				{
					if (t._003CisRelative_003Ek__BackingField)
					{
						goto IL_0095;
					}
					vector = t.endValue;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
					num = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]");
					num2 = 0f;
				}
				else
				{
					if (t.endValue.x > 360f)
					{
						QuaternionPlugin quaternionPlugin = (QuaternionPlugin)(t.endValue % 360f);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
					if (0f > 360f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
						QuaternionPlugin quaternionPlugin = (QuaternionPlugin)(0 % 360f);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]");
					if (0f > 360f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]");
						object obj = 0 % 360f;
					}
					Vector3 vector2 = default(Vector3);
					vector2.x = t.endValue.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
					vector2.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]");
					vector2.z = 0f;
					vector = vector2 - t.startValue;
					num = vector.y;
					num2 = vector.z;
					Vector3 vector3 = 0 - vector;
					bool flag = vector.x < 0f;
					bool flag2 = vector.x == 0f;
					object obj2 = (object)vector ^ (object)vector;
					int num3 = (int)(vector & (long)(IntPtr)obj2);
					bool flag3 = num3 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					if (flag4 && flag5)
					{
						vector3 = vector;
					}
					if (vector3.x > 180f)
					{
						float num4 = 360f - vector3.x;
						Vector3 vector4 = (Vector3)(0f - num4);
						bool flag6 = vector.x < 0f;
						bool flag7 = vector.x == 0f;
						object obj3 = (object)vector ^ (object)vector;
						int num5 = (int)(vector & (long)(IntPtr)obj3);
						bool flag8 = num5 < 0;
						bool flag9 = flag6 == flag8;
						bool flag10 = !flag7;
						vector = ((!(flag9 && flag10)) ? ((Vector3)num4) : vector4);
					}
					float num6 = 0f - num;
					bool flag11 = num < 0f;
					bool flag12 = num == 0f;
					object obj4 = num ^ num;
					int num7 = num & (long)(IntPtr)obj4;
					bool flag13 = num7 < 0;
					bool flag14 = flag11 == flag13;
					bool flag15 = !flag12;
					if (flag14 && flag15)
					{
						num6 = num;
					}
					if (num6 > 180f)
					{
						float num8 = 360f - num6;
						float num9 = 0f - num8;
						bool flag16 = num < 0f;
						bool flag17 = num == 0f;
						object obj5 = num ^ num;
						int num10 = num & (long)(IntPtr)obj5;
						bool flag18 = num10 < 0;
						bool flag19 = flag16 == flag18;
						bool flag20 = !flag17;
						if (flag19 && flag20)
						{
							num = num9;
						}
						else
						{
							num = num8;
						}
					}
					float num11 = 0f - num2;
					bool flag21 = num2 < 0f;
					bool flag22 = num2 == 0f;
					object obj6 = num2 ^ num2;
					int num12 = num2 & (long)(IntPtr)obj6;
					bool flag23 = num12 < 0;
					bool flag24 = flag21 == flag23;
					bool flag25 = !flag22;
					if (flag24 && flag25)
					{
						num11 = num2;
					}
					if (num11 > 180f)
					{
						float num13 = 360f - num11;
						float num14 = 0f - num13;
						bool flag26 = num2 < 0f;
						bool flag27 = num2 == 0f;
						object obj7 = num2 ^ num2;
						int num15 = num2 & (long)(IntPtr)obj7;
						bool flag28 = num15 < 0;
						bool flag29 = flag26 == flag28;
						bool flag30 = !flag27;
						if (flag29 && flag30)
						{
							num2 = num14;
						}
						else
						{
							num2 = num13;
						}
					}
				}
				goto IL_04fa;
			}
			goto IL_0095;
			IL_0095:
			vector = t.endValue - t.startValue;
			num = vector.y;
			num2 = vector.z;
			goto IL_04fa;
			IL_04fa:
			t.changeValue = vector;
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0x10DA044", Offset = "0x10DA044", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0x158AD58(&changeValue @ V1 (System.Single), 0, methodInfo, v20, v21, v22, v23, v24, unitsXSecond, changeValue, *([changeValue @ V1 (System.Single)+4]), *([changeValue @ V1 (System.Single)+8]), v25, v26, v27, v28);\n\treturnVal1 = unitsXSecond / unitsXSecond;\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(QuaternionOptions options, float unitsXSecond, Vector3 changeValue)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			return unitsXSecond / unitsXSecond;
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0x10DA080", Offset = "0x10DA080", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv58 = *([1EE7E10]);\n\tv59 = *([v58 @ X8_v45]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, v2, changeValue, v3, v5, duration);\n\tv68 = 0 | 1;\n\t*([20274BC]) = v68;\nL_003A:\n\tv83 = t.loopType != 2;\n\tif (v83) goto L_FFFFFFFF;\n\tv324 = t.completedLoops - t.isComplete;\n\tgoto L_0052;\n\tv416 = *([v320 @ X0_v40+E0]);\n\tv417 = v416 == 0;\n\tv418 = ~v417;\n\tif (v418) goto L_0052;\n\tv420 = \"il2cpp_codegen_runtime_class_init\"(v320, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, v2, changeValue, v3, v5, duration);\nL_0052:\n\tv429 = UnityEngine.Vector3::op_Multiply(changeValue, v324);\n\tv434 = UnityEngine.Vector3::op_Addition(startValue, v429);\n\tgoto L_006A;\nL_006A:\n\tv445 = ~t.isSequenced;\n\tif (v445) goto L_00D7;\n\tv291 = t.sequenceParent;\n\tv475 = v291.loopType != 2;\n\tif (v475) goto L_00D7;\n\tv195 = t.loopType != 2;\n\tif (v195) goto L_FFFFFFFF;\n\tgoto L_0092;\nL_0092:\n\tgoto L_009F;\n\tv693 = *([v686 @ X0_v31+E0]);\n\tv694 = v693 == 0;\n\tv695 = ~v694;\n\tgoto L_009F;\n\tv697 = \"il2cpp_codegen_runtime_class_init\"(v686, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v683, v175, v312, v307, v167, v303, v5, duration);\nL_009F:\n\tv181 = UnityEngine.Vector3::op_Multiply(changeValue, v684);\n\tv292 = t.sequenceParent;\n\tv505 = v292.completedLoops - v292.isComplete;\n\tgoto L_00BC;\n\tv734 = *([v716 @ X0_v34+E0]);\n\tv735 = v734 == 0;\n\tv736 = ~v735;\n\tif (v736) goto L_00BC;\n\tv738 = \"il2cpp_codegen_runtime_class_init\"(v716, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v181, v176, v313, v308, v167, v303, v5, duration);\nL_00BC:\n\tv744 = UnityEngine.Vector3::op_Multiply(v181, v505);\n\t// 198 MakeStruct v465 @ AGG10DA278_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v279 @ V14_v8 (UnityEngine.Vector3), v277 @ V15_v2 (System.Single), v265 @ V11_v2 (System.Single)\n\tv471 = UnityEngine.Vector3::op_Addition(v465, v744);\nL_00D7:\n\tv516 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv531 = options.rotateMode & 0xFFFFFFFE;\n\tv194 = v531 != 2;\n\tif (v194) goto L_015B;\n\tgoto L_00F6;\n\tv586 = *([v568 @ X0_v20+E0]);\n\tv587 = v586 == 0;\n\tv588 = ~v587;\n\tif (v588) goto L_00F6;\n\tv590 = \"il2cpp_codegen_runtime_class_init\"(v568, v99, v96, isRelative, getter, setter, usingInversePosition, updateNotice, v516, v515, v512, v513, v166, v302, v5, duration);\nL_00F6:\n\t// 246 MakeStruct v346 @ AGG10DA2E8_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), startValue @ V1 (UnityEngine.Vector3), startValue.y (System.Single), v273 @ V13_v2 (System.Single)\n\tv596 = UnityEngine.Quaternion::Euler(v346);\n\tv261 = changeValue * v516;\n\tv288 = changeValue.y * v516;\n\tv269 = v283 * v516;\n\tv364 = options.rotateMode != 2;\n\tif (v364) goto L_017B;\n\tgoto L_0120;\n\tv705 = *([v385 @ X0_v23+E0]);\n\tv706 = v705 == 0;\n\tv707 = ~v706;\n\tif (v707) goto L_0120;\n\tv709 = \"il2cpp_codegen_runtime_class_init\"(v385, v99, v96, isRelative, getter, setter, usingInversePosition, updateNotice, v359, v357, v413, v411, v166, v302, v5, duration);\nL_0120:\n\tv715 = UnityEngine.Quaternion::Inverse(v596);\n\tv733 = UnityEngine.Quaternion::op_Multiply(v596, v715);\n\t// 318 MakeStruct v537 @ AGG10DA39C_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v261 @ V10_v2 (System.Single), v288 @ V9_v2 (System.Single), v269 @ V8_v2 (System.Single)\n\tv752 = UnityEngine.Quaternion::Euler(v537);\n\tv546 = UnityEngine.Quaternion::op_Multiply(v733, v752);\n\tv544 = v546.y;\n\tv563 = v546.z;\n\tv561 = v546.w;\n\tgoto L_0193;\nL_015B:\n\tv576 = changeValue * v516;\n\tv261 = v279 + v576;\n\tv579 = changeValue.y * v516;\n\tv288 = v277 + v579;\n\tv580 = v283 * v516;\n\tv269 = v265 + v580;\n\tgoto L_016F;\n\tv597 = *([v575 @ X0_v16+E0]);\n\tv598 = v597 == 0;\n\tv599 = ~v598;\n\tif (v599) goto L_016F;\n\tv601 = \"il2cpp_codegen_runtime_class_init\"(v575, v99, v96, isRelative, getter, setter, usingInversePosition, updateNotice, v580, v515, v512, v513, v166, v302, v5, duration);\nL_016F:\n\t// 367 MakeStruct v105 @ AGG10DA428_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v261 @ V10_v2 (System.Single), v288 @ V9_v2 (System.Single), v269 @ V8_v2 (System.Single)\n\tv632 = UnityEngine.Quaternion::Euler(v105);\n\tv631 = v632.y;\n\tv663 = v632.z;\n\tv662 = v632.w;\n\tv692 = setter == 0;\n\tv253 = ~v692;\n\tif (v253) goto L_01AE;\n\tv316 = new System.NullReferenceException();\nL_017B:\n\tgoto L_0185;\n\tv446 = *([v384 @ X0_v6+E0]);\n\tv447 = v446 == 0;\n\tv448 = ~v447;\n\tif (v448) goto L_0185;\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v384, v334, v333, isRelative, getter, setter, usingInversePosition, updateNotice, v358, v356, v412, v410, v354, v409, v408, v343);\nL_0185:\n\t// 389 MakeStruct v457 @ AGG10DA458_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v261 @ V10_v2 (System.Single), v288 @ V9_v2 (System.Single), v269 @ V8_v2 (System.Single)\n\tv458 = UnityEngine.Quaternion::Euler(v457);\nL_0193:\n\t// 403 MakeStruct v89 @ AGG10DA480_0_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v546 @ V0_v1 (UnityEngine.Quaternion), v544 @ V1_v1 (System.Single), v563 @ V2_v2 (System.Single), v561 @ V3_v2 (System.Single)\n\t// 404 MakeStruct v86 @ AGG10DA480_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v168 @ V4_v1 (UnityEngine.Quaternion), v304 @ V5_v2 (System.Single), v300 @ V6_v2 (System.Single), v128 @ V7_v1 (System.Single)\n\tv632 = UnityEngine.Quaternion::op_Multiply(v89, v86);\n\tv631 = v632.y;\n\tv663 = v632.z;\n\tv662 = v632.w;\nL_01AE:\n\t// 430 MakeStruct v682 @ AGG10DA4B8_1_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v632 @ V0_v3 (UnityEngine.Quaternion), v631 @ V1_v3 (System.Single), v663 @ V2_v4 (System.Single), v662 @ V3_v4 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(setter, v682);\n\treturn;\n// 319 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(QuaternionOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_0625: Expected I4, but got I8
			//IL_0140: Expected F4, but got I4
			float num2;
			float y;
			Vector3 vector3;
			if (t.loopType == LoopType.Incremental)
			{
				float num = (float)t.completedLoops - (float)(t.isComplete ? 1 : 0);
				Vector3 vector = changeValue * num;
				Vector3 vector2 = startValue + vector;
				num2 = vector2.z;
				y = vector2.y;
				vector3 = vector2;
			}
			else
			{
				num2 = startValue.z;
				y = startValue.y;
				vector3 = startValue;
			}
			bool flag = !t.isSequenced;
			float z = startValue.z;
			float z2 = changeValue.z;
			if (!flag)
			{
				Sequence sequenceParent = t.sequenceParent;
				bool flag2 = sequenceParent.loopType != LoopType.Incremental;
				z = startValue.z;
				z2 = changeValue.z;
				if (!flag2)
				{
					float num3 = ((t.loopType != LoopType.Incremental) ? 1f : ((float)t.loops));
					Vector3 vector4 = changeValue * num3;
					Sequence sequenceParent2 = t.sequenceParent;
					float num4 = (float)sequenceParent2.completedLoops - (float)(sequenceParent2.isComplete ? 1 : 0);
					Vector3 vector5 = vector4 * num4;
					Vector3 vector6 = default(Vector3);
					vector6.x = vector3.x;
					vector6.y = y;
					vector6.z = num2;
					Vector3 vector7 = vector6 + vector5;
					num2 = vector7.z;
					z = startValue.z;
					y = vector7.y;
					vector3 = vector7;
					z2 = changeValue.z;
				}
			}
			float num5 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			int num6 = (int)((long)options.rotateMode & 0xFFFFFFFEL);
			float x;
			Vector3 vector9 = default(Vector3);
			float y2;
			float z3;
			Quaternion quaternion2;
			Quaternion quaternion6;
			float y3;
			float z4;
			float w;
			float w2;
			Quaternion quaternion7;
			float z5;
			float y4;
			Quaternion quaternion8;
			float y5;
			float z6;
			float w3;
			if (num6 == 2)
			{
				Vector3 euler = default(Vector3);
				Vector3 vector8 = default(Vector3);
				euler.x = vector8.x;
				euler.y = startValue.y;
				euler.z = z;
				Quaternion quaternion = Quaternion.Euler(euler);
				x = vector9.x * num5;
				y2 = changeValue.y * num5;
				z3 = z2 * num5;
				bool flag3 = options.rotateMode != RotateMode.WorldAxisAdd;
				num2 = quaternion.w;
				z = quaternion.z;
				y = quaternion.y;
				quaternion2 = quaternion;
				if (!flag3)
				{
					Quaternion quaternion3 = Quaternion.Inverse(quaternion);
					Quaternion quaternion4 = quaternion * quaternion3;
					Vector3 euler2 = default(Vector3);
					euler2.x = x;
					euler2.y = y2;
					euler2.z = z3;
					Quaternion quaternion5 = Quaternion.Euler(euler2);
					quaternion6 = quaternion4 * quaternion5;
					y3 = quaternion6.y;
					z4 = quaternion6.z;
					w = quaternion6.w;
					w2 = quaternion.w;
					quaternion7 = quaternion;
					z5 = quaternion.z;
					y4 = quaternion.y;
					goto IL_064a;
				}
			}
			else
			{
				float num7 = vector9.x * num5;
				x = vector3.x + num7;
				float num8 = changeValue.y * num5;
				y2 = y + num8;
				float num9 = z2 * num5;
				z3 = num2 + num9;
				Vector3 euler3 = default(Vector3);
				euler3.x = x;
				euler3.y = y2;
				euler3.z = z3;
				quaternion8 = Quaternion.Euler(euler3);
				y5 = quaternion8.y;
				z6 = quaternion8.z;
				w3 = quaternion8.w;
				bool flag4 = setter == null;
				bool flag5 = !flag4;
				quaternion2 = (Quaternion)vector3;
				if (flag5)
				{
					goto IL_055a;
				}
				NullReferenceException ex = new NullReferenceException();
			}
			Vector3 euler4 = default(Vector3);
			euler4.x = x;
			euler4.y = y2;
			euler4.z = z3;
			Quaternion quaternion9 = Quaternion.Euler(euler4);
			w2 = quaternion9.w;
			quaternion7 = quaternion9;
			y3 = y;
			quaternion6 = quaternion2;
			z5 = quaternion9.z;
			y4 = quaternion9.y;
			w = num2;
			z4 = z;
			goto IL_064a;
			IL_055a:
			Quaternion pNewValue = default(Quaternion);
			pNewValue.x = quaternion8.x;
			pNewValue.y = y5;
			pNewValue.z = z6;
			pNewValue.w = w3;
			setter(pNewValue);
			return;
			IL_064a:
			Quaternion quaternion10 = default(Quaternion);
			quaternion10.x = quaternion6.x;
			quaternion10.y = y3;
			quaternion10.z = z4;
			quaternion10.w = w;
			Quaternion quaternion11 = default(Quaternion);
			quaternion11.x = quaternion7.x;
			quaternion11.y = y4;
			quaternion11.z = z5;
			quaternion11.w = w2;
			quaternion8 = quaternion10 * quaternion11;
			y5 = quaternion8.y;
			z6 = quaternion8.z;
			w3 = quaternion8.w;
			goto IL_055a;
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0x10DA4BC", Offset = "0x10DA4BC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F03B68]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274BD]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionPlugin()
		{
		}
	}
}
