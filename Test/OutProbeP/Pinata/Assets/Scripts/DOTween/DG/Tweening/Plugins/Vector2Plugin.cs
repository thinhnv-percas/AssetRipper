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
	[Token(Token = "0x2000029")]
	public class Vector2Plugin : ABSTweenPlugin<Vector2, Vector2, VectorOptions>
	{
		[Token(Token = "0x60001EE")]
		[Address(RVA = "0x10DDE58", Offset = "0x10DDE58", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector2, Vector2, VectorOptions> t)
		{
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0x10DDE5C", Offset = "0x10DDE5C", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_001F;\n\tv30 = *([1EA3318]);\n\tv31 = *([v30 @ X8_v27]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, t, isRelative, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([20274DD]) = v49;\nL_001F:\n\tv244 = t.endValue;\n\tv243 = t.endValue.y;\n\tv59 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\n\tv139 = v59.y;\n\tt.endValue.x = v59;\n\tt.endValue.y = v59.y;\n\tv128 = isRelative == 0;\n\tif (v128) goto L_0045;\n\tgoto L_003E;\n\tv210 = *([v131 @ X0_v16+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_003E;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v131, v58, isRelative, methodInfo, v34, v35, v36, v37, v59, v125, v40, v41, v42, v43, v44, v45);\nL_003E:\n\t// 62 MakeStruct v135 @ AGG10DDF0C_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.endValue (UnityEngine.Vector2), t.endValue.y (System.Single)\n\tv142 = UnityEngine.Vector2::op_Addition(v59, v135);\n\tv139 = v142.y;\nL_0045:\n\tt.startValue.x = v244;\n\tt.startValue.y = v243;\n\tv159 = t.plugOptions == 4;\n\tif (v159) goto L_0060;\n\tv226 = t.plugOptions != 2;\n\tif (v226) goto L_FFFFFFFF;\n\tv121 = t.endValue.y;\n\tgoto L_0063;\nL_0060:\n\tv245 = t.endValue;\nL_0063:\n\tv247 = ~t.plugOptions.snapping;\n\tif (v247) goto L_0105;\n\tgoto L_0073;\n\tv275 = *([v251 @ X0_v9+E0]);\n\tv276 = v275 == 0;\n\tv277 = ~v276;\n\tif (v277) goto L_0073;\n\tv279 = \"il2cpp_codegen_runtime_class_init\"(v251, v58, isRelative, methodInfo, v34, v35, v36, v37, v141, v139, v102, v100, v42, v43, v44, v45);\nL_0073:\n\tv283 = &v19 @ stack_-10_v2 - 0x18;\n\tv285 = 0x6D1ED0(v283, Il2CppMethodInfo, isRelative, methodInfo, v34, v35, v36, v37, v245, v139, v244, v243, v42, v43, v44, v45);\n\tv296 = v245 >= 0;\n\tif (v296) goto L_009A;\n\tv307 = v245 != -0.5d;\n\tif (v307) goto L_00AC;\n\tv337 = *([v18 @ X29_v1-18]);\n\tgoto L_009F;\nL_009A:\n\tv318 = v245 != 0.5d;\n\tif (v318) goto L_00AF;\n\tv337 = *([v18 @ X29_v1-18]);\nL_009F:\n\tv356 = v337 + v336;\n\tv340 = v337 & 1;\n\tv342 = v340 == 0;\n\tv345 = ~v342;\n\tif (v345) goto L_FFFFFFFF;\n\tgoto L_00AB;\nL_00AB:\n\tgoto L_00B3;\nL_00AC:\n\tv321 = v245 + -0.5d;\n\tv358 = System.Math::Ceiling(v321);\n\tgoto L_00B3;\nL_00AF:\n\tv325 = v245 + 0.5d;\n\tv358 = System.Math::Floor(v325);\nL_00B3:\n\tv363 = &v19 @ stack_-10_v2 - 0x18;\n\tv271 = 0x6D1ED0(v363, Il2CppMethodInfo, isRelative, methodInfo, v34, v35, v36, v37, v121, v356, v244, v243, v42, v43, v44, v45);\n\tv376 = v121 >= 0;\n\tif (v376) goto L_00DA;\n\tv387 = v121 != -0.5d;\n\tif (v387) goto L_00EC;\n\tv267 = *([v18 @ X29_v1-18]);\n\tgoto L_00DF;\nL_00DA:\n\tv398 = v121 != 0.5d;\n\tif (v398) goto L_00EF;\n\tv267 = *([v18 @ X29_v1-18]);\nL_00DF:\n\tv419 = v267 + v416;\n\tv420 = v267 & 1;\n\tv422 = v420 == 0;\n\tv425 = ~v422;\n\tif (v425) goto L_FFFFFFFF;\n\tgoto L_00EB;\nL_00EB:\n\tgoto L_FFFFFFFF;\nL_00EC:\n\tv401 = v121 + -0.5d;\n\tv267 = System.Math::Ceiling(v401);\n\tgoto L_FFFFFFFF;\nL_00EF:\n\tv405 = v121 + 0.5d;\n\tv267 = System.Math::Floor(v405);\nL_0105:\n\t// 261 MakeStruct v166 @ AGG10DE090_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v244 @ V8_v4 (UnityEngine.Vector2), v243 @ V9_v4 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(t.setter, v166);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, bool isRelative)
		{
			//IL_0192: Expected O, but got I
			//IL_02fb: Expected O, but got I
			//IL_0250: Expected F8, but got I
			//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d6: Expected I4, but got Unknown
			//IL_0203: Expected F8, but got I
			//IL_042a: Expected O, but got F8
			//IL_03aa: Expected F8, but got I
			//IL_051b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0520: Expected I4, but got Unknown
			//IL_0362: Expected F8, but got I
			object obj2 = default(object);
			object obj = obj2;
			Vector2 vector = t.endValue;
			float num = t.endValue.y;
			Vector2 vector2 = t.getter();
			float y = vector2.y;
			t.endValue.x = vector2.x;
			t.endValue.y = vector2.y;
			if (isRelative)
			{
				Vector2 vector3 = default(Vector2);
				vector3.x = t.endValue.x;
				vector3.y = t.endValue.y;
				Vector2 vector4 = vector2 + vector3;
				y = vector4.y;
				num = vector4.y;
				vector = vector4;
			}
			t.startValue.x = vector.x;
			t.startValue.y = num;
			float num2;
			Vector2 vector5;
			if ((IntPtr)t.plugOptions != (IntPtr)4)
			{
				bool flag = (IntPtr)t.plugOptions != (IntPtr)2;
				num2 = num;
				if (!flag)
				{
					num2 = t.endValue.y;
					num = t.endValue.y;
				}
				vector5 = vector;
			}
			else
			{
				vector5 = t.endValue;
				vector = t.endValue;
				num2 = num;
			}
			double num3;
			if (t.plugOptions.snapping)
			{
				object obj3 = (long)(IntPtr)obj2 - 24L;
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
				double num5;
				double num6;
				double num4;
				if (vector5.x < 0f)
				{
					if ((double)vector5.x != -0.5)
					{
						double a = (double)vector5.x + -0.5;
						num3 = Math.Ceiling(a);
						num4 = -0.5;
						goto IL_02ec;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-18]");
					num5 = 0.0;
					num6 = -1.0;
				}
				else
				{
					if ((double)vector5.x != 0.5)
					{
						double d = (double)vector5.x + 0.5;
						num3 = Math.Floor(d);
						num4 = 0.5;
						goto IL_02ec;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-18]");
					num5 = 0.0;
					num6 = 1.0;
				}
				num4 = num5 + num6;
				num3 = (((num5 & 1) != 0) ? num4 : num5);
				goto IL_02ec;
			}
			goto IL_042f;
			IL_02ec:
			object obj4 = (long)(IntPtr)obj2 - 24L;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			double num7;
			double num8;
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a2 = (double)num2 + -0.5;
					num7 = Math.Ceiling(a2);
					goto IL_041a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-18]");
				num7 = 0.0;
				num8 = -1.0;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d2 = (double)num2 + 0.5;
					num7 = Math.Floor(d2);
					goto IL_041a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-18]");
				num7 = 0.0;
				num8 = 1.0;
			}
			double num9 = num7 + num8;
			if ((num7 & 1) != 0)
			{
				num7 = num9;
			}
			goto IL_041a;
			IL_041a:
			num = (float)num7;
			vector = (Vector2)num3;
			goto IL_042f;
			IL_042f:
			Vector2 pNewValue = default(Vector2);
			pNewValue.x = vector.x;
			pNewValue.y = num;
			t.setter(pNewValue);
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0x10DE09C", Offset = "0x10DE09C", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv201 = fromValue.y;\n\tgoto L_001D;\n\tv32 = *([1F0F280]);\n\tv33 = *([v32 @ X8_v25]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, t, setImmediately, methodInfo, v36, v37, v38, v39, fromValue, v0, v40, v41, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([20274DE]) = v49;\nL_001D:\n\tt.startValue.x = fromValue;\n\tt.startValue.y = fromValue.y;\n\tv52 = setImmediately == 0;\n\tif (v52) goto L_004B;\n\tv59 = t.plugOptions == 4;\n\tif (v59) goto L_0052;\n\tv86 = t.plugOptions != 2;\n\tif (v86) goto L_0056;\n\tv180 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\n\tv201 = v180.y;\n\tgoto L_0056;\nL_004B:\n\treturn;\nL_0052:\n\tv179 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\nL_0056:\n\tv205 = ~t.plugOptions.snapping;\n\tif (v205) goto L_00F5;\n\tgoto L_0067;\n\tv235 = *([v210 @ X0_v8+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0067;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v210, v83, setImmediately, methodInfo, v36, v37, v38, v39, v178, v201, v40, v41, v42, v43, v44, v45);\nL_0067:\n\tv246 = 0x6D1ED0(&v244 @ stack_-48_v3 (System.Double), v83, setImmediately, methodInfo, v36, v37, v38, v39, v129, v201, v40, v41, v42, v43, v44, v45);\n\tv257 = v129 >= 0;\n\tif (v257) goto L_008C;\n\tv268 = v129 != -0.5d;\n\tif (v268) goto L_009E;\n\tgoto L_0091;\nL_008C:\n\tv279 = v129 != 0.5d;\n\tif (v279) goto L_00A1;\nL_0091:\n\tv321 = v288 + v298;\n\tv301 = v288 & 1;\n\tv303 = v301 == 0;\n\tv306 = ~v303;\n\tif (v306) goto L_FFFFFFFF;\n\tgoto L_009D;\nL_009D:\n\tgoto L_00A6;\nL_009E:\n\tv282 = v129 + -0.5d;\n\tv216 = System.Math::Ceiling(v282);\n\tgoto L_00A6;\nL_00A1:\n\tv286 = v129 + 0.5d;\n\tv216 = System.Math::Floor(v286);\nL_00A6:\n\tv228 = 0x6D1ED0(&v244 @ stack_-48_v3 (System.Double), v83, setImmediately, methodInfo, v36, v37, v38, v39, v131, v321, v40, v41, v42, v43, v44, v45);\n\tv336 = v131 >= 0;\n\tif (v336) goto L_00CB;\n\tv347 = v131 != -0.5d;\n\tif (v347) goto L_00DD;\n\tgoto L_00D0;\nL_00CB:\n\tv358 = v131 != 0.5d;\n\tif (v358) goto L_00E0;\nL_00D0:\n\tv379 = v217 + v377;\n\tv380 = v217 & 1;\n\tv382 = v380 == 0;\n\tv385 = ~v382;\n\tif (v385) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\tgoto L_FFFFFFFF;\nL_00DD:\n\tv361 = v131 + -0.5d;\n\tv217 = System.Math::Ceiling(v361);\n\tgoto L_FFFFFFFF;\nL_00E0:\n\tv365 = v131 + 0.5d;\n\tv217 = System.Math::Floor(v365);\nL_00F5:\n\t// 245 MakeStruct v141 @ AGG10DE2A4_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v129 @ V9_v5 (UnityEngine.Vector2), v131 @ V8_v5 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(t.setter, v141);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 fromValue, bool setImmediately)
		{
			//IL_0114: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Expected I4, but got Unknown
			//IL_03a1: Expected O, but got F8
			//IL_0465: Unknown result type (might be due to invalid IL or missing references)
			//IL_046a: Expected I4, but got Unknown
			float y = fromValue.y;
			Vector2 vector = default(Vector2);
			t.startValue.x = vector.x;
			t.startValue.y = fromValue.y;
			if (!setImmediately)
			{
				return;
			}
			Vector2 vector2;
			float num;
			if ((IntPtr)t.plugOptions != (IntPtr)4)
			{
				bool flag = (IntPtr)t.plugOptions != (IntPtr)2;
				object obj = t;
				vector2 = fromValue;
				num = y;
				if (!flag)
				{
					Vector2 vector3 = t.getter();
					y = vector3.y;
					obj = 0;
					vector2 = fromValue;
					num = vector3.y;
				}
			}
			else
			{
				Vector2 vector4 = t.getter();
				object obj = 0;
				vector2 = vector4;
				num = fromValue.y;
				y = vector4.y;
			}
			double num2;
			double num5 = default(double);
			if (t.plugOptions.snapping)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
				double num4;
				double num6;
				double num3;
				if (vector2.x < 0f)
				{
					if ((double)vector2.x != -0.5)
					{
						double a = (double)vector2.x + -0.5;
						num2 = Math.Ceiling(a);
						num3 = -0.5;
						goto IL_028a;
					}
					num4 = num5;
					num6 = -1.0;
				}
				else
				{
					if ((double)vector2.x != 0.5)
					{
						double d = (double)vector2.x + 0.5;
						num2 = Math.Floor(d);
						num3 = 0.5;
						goto IL_028a;
					}
					num4 = num5;
					num6 = 1.0;
				}
				num3 = num4 + num6;
				num2 = (((num4 & 1) != 0) ? num3 : num4);
				goto IL_028a;
			}
			goto IL_03ae;
			IL_028a:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			double num7;
			double num8;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a2 = (double)num + -0.5;
					num7 = Math.Ceiling(a2);
					goto IL_0399;
				}
				num7 = num5;
				num8 = -1.0;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d2 = (double)num + 0.5;
					num7 = Math.Floor(d2);
					goto IL_0399;
				}
				num7 = num5;
				num8 = 1.0;
			}
			double num9 = num7 + num8;
			if ((num7 & 1) != 0)
			{
				num7 = num9;
			}
			goto IL_0399;
			IL_0399:
			vector2 = (Vector2)num2;
			num = (float)num7;
			goto IL_03ae;
			IL_03ae:
			Vector2 pNewValue = default(Vector2);
			pNewValue.x = vector2.x;
			pNewValue.y = num;
			t.setter(pNewValue);
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0x10DE2B0", Offset = "0x10DE2B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 value)
		{
			return value;
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0x10DE2B4", Offset = "0x10DE2B4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = *([1EC9260]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([20274DF]) = v46;\nL_0023:\n\tgoto L_002E;\n\tv60 = *([v53 @ X0_v4+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_002E;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v53, t, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_002E:\n\t// 46 MakeStruct v72 @ AGG10DE338_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.endValue (UnityEngine.Vector2), t.endValue.y (System.Single)\n\t// 47 MakeStruct v73 @ AGG10DE338_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.startValue (UnityEngine.Vector2), t.startValue.y (System.Single)\n\tv74 = UnityEngine.Vector2::op_Addition(v72, v73);\n\tt.endValue.x = v74;\n\tt.endValue.y = v74.y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector2, Vector2, VectorOptions> t)
		{
			Vector2 vector = default(Vector2);
			vector.x = t.endValue.x;
			vector.y = t.endValue.y;
			Vector2 vector2 = default(Vector2);
			vector2.x = t.startValue.x;
			vector2.y = t.startValue.y;
			Vector2 vector3 = vector + vector2;
			t.endValue.x = vector3.x;
			t.endValue.y = vector3.y;
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0x10DE360", Offset = "0x10DE360", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EA6748]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([20274E0]) = v46;\nL_001E:\n\tv53 = t.plugOptions == 4;\n\tif (v53) goto L_003A;\n\tv69 = t.plugOptions != 2;\n\tif (v69) goto L_004D;\n\tv74 = 0;\n\tv95 = t.endValue - t.startValue;\n\tgoto L_003D;\nL_003A:\n\tv94 = t.endValue.y - t.startValue.y;\nL_003D:\n\tv108 = 0x1588A6C(v106, 0, methodInfo, v30, v31, v32, v33, v34, v95, v94, v37, v38, v39, v40, v41, v42);\n\tt.changeValue.x = v74;\n\tt.changeValue.y = v196;\n\tgoto L_0067;\nL_004D:\n\tgoto L_0058;\n\tv179 = *([v88 @ X0_v8+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0058;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v88, t, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0058:\n\t// 88 MakeStruct v191 @ AGG10DE448_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.endValue (UnityEngine.Vector2), t.endValue.y (System.Single)\n\t// 89 MakeStruct v192 @ AGG10DE448_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.startValue (UnityEngine.Vector2), t.startValue.y (System.Single)\n\tv193 = UnityEngine.Vector2::op_Subtraction(v191, v192);\n\tt.changeValue.x = v193;\n\tt.changeValue.y = v193.y;\nL_0067:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector2, Vector2, VectorOptions> t)
		{
			//IL_00cb: Expected O, but got F4
			//IL_0092: Expected O, but got F4
			float num = default(float);
			if ((IntPtr)t.plugOptions != (IntPtr)4)
			{
				if ((IntPtr)t.plugOptions != (IntPtr)2)
				{
					Vector2 vector = default(Vector2);
					vector.x = t.endValue.x;
					vector.y = t.endValue.y;
					Vector2 vector2 = default(Vector2);
					vector2.x = t.startValue.x;
					vector2.y = t.startValue.y;
					Vector2 vector3 = vector - vector2;
					t.changeValue.x = vector3.x;
					t.changeValue.y = vector3.y;
					return;
				}
				num = 0f;
				float num2 = t.endValue.x - t.startValue.x;
				num = 0f;
				float num3 = 0f;
				object obj = num;
			}
			else
			{
				float num3 = t.endValue.y - t.startValue.y;
				float num2 = 0f;
				object obj = num;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			t.changeValue.x = num;
			float y = default(float);
			t.changeValue.y = y;
		}

		[Token(Token = "0x60001F4")]
		[Address(RVA = "0x10DE474", Offset = "0x10DE474", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0x1588E30(&changeValue @ V1 (System.Single), 0, methodInfo, v18, v19, v20, v21, v22, unitsXSecond, changeValue, *([changeValue @ V1 (System.Single)+4]), v23, v24, v25, v26, v27);\n\treturnVal1 = unitsXSecond / unitsXSecond;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector2 changeValue)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588E30 (inside UnityEngine.Vector2::Scale +0xC8)");
			return unitsXSecond / unitsXSecond;
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0x10DE4A4", Offset = "0x10DE4A4", Length = "0x4D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv60 = *([1EDEE80]);\n\tv61 = *([v60 @ X8_v63]);\n\tv62 = \"il2cpp_codegen_initialize_method\"(v61, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, changeValue, v2, duration, v66, v67);\n\tv71 = 0 | 1;\n\t*([20274E1]) = v71;\nL_0036:\n\tv83 = t.loopType != 2;\n\tif (v83) goto L_005B;\n\tv267 = t.completedLoops - t.isComplete;\n\tgoto L_004D;\n\tv286 = *([v263 @ X0_v40+E0]);\n\tv287 = v286 == 0;\n\tv288 = ~v287;\n\tif (v288) goto L_004D;\n\tv290 = \"il2cpp_codegen_runtime_class_init\"(v263, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, changeValue, v2, duration, v66, v67);\nL_004D:\n\tv295 = UnityEngine.Vector2::op_Multiply(changeValue, v267);\n\tv275 = UnityEngine.Vector2::op_Addition(startValue, v295);\nL_005B:\n\tv285 = ~t.isSequenced;\n\tif (v285) goto L_00BA;\n\tv245 = t.sequenceParent;\n\tv307 = v245.loopType != 2;\n\tif (v307) goto L_00BA;\n\tv153 = t.loopType != 2;\n\tif (v153) goto L_FFFFFFFF;\n\tv118 = t.loops;\n\tgoto L_0081;\nL_0081:\n\tgoto L_008C;\n\tv487 = *([v440 @ X0_v31+E0]);\n\tv488 = v487 == 0;\n\tv489 = ~v488;\n\tgoto L_008C;\n\tv491 = \"il2cpp_codegen_runtime_class_init\"(v440, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v139, v133, v255, v127, v2, duration, v66, v67);\nL_008C:\n\tv140 = UnityEngine.Vector2::op_Multiply(changeValue, v118);\n\tv246 = t.sequenceParent;\n\tv332 = v246.completedLoops - v246.isComplete;\n\tgoto L_00A6;\n\tv598 = *([v552 @ X0_v34+E0]);\n\tv599 = v598 == 0;\n\tv600 = ~v599;\n\tif (v600) goto L_00A6;\n\tv602 = \"il2cpp_codegen_runtime_class_init\"(v552, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v140, v134, v256, v127, v2, duration, v66, v67);\nL_00A6:\n\tv607 = UnityEngine.Vector2::op_Multiply(v140, v332);\n\t// 173 MakeStruct v297 @ AGG10DE654_0_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v230 @ V11_v4 (UnityEngine.Vector2), v233 @ V10_v4 (System.Single)\n\tv304 = UnityEngine.Vector2::op_Addition(v297, v607);\nL_00BA:\n\tv141 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv190 = options == 4;\n\tif (v190) goto L_0110;\n\tv154 = options != 2;\n\tif (v154) goto L_0143;\n\tv447 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(getter);\n\tv461 = changeValue * v141;\n\tv496 = options >> 0x20;\n\tv484 = v496 & 0xFF;\n\tv479 = v230 + v461;\n\tv475 = v484 == 0;\n\tif (v475) goto L_0238;\n\tgoto L_00EF;\n\tv557 = *([v526 @ X0_v26+E0]);\n\tv558 = v557 == 0;\n\tv559 = ~v558;\n\tif (v559) goto L_00EF;\n\tv561 = \"il2cpp_codegen_runtime_class_init\"(v526, v96, v89, isRelative, getter, setter, usingInversePosition, updateNotice, v461, v458, v257, v128, v2, duration, v66, v67);\nL_00EF:\n\tv219 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(&v549 @ stack_-88_v5 (System.Double));\n\tv617 = v479 >= 0;\n\tif (v617) goto L_019B;\n\tv661 = v479 != -0.5d;\n\tif (v661) goto L_01C9;\n\tgoto L_01A0;\nL_0110:\n\tv438 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(getter);\n\tv462 = changeValue.y * v141;\n\tv486 = options >> 0x20;\n\tv485 = v486 & 0xFF;\n\tv515 = v233 + v462;\n\tv476 = v485 == 0;\n\tif (v476) goto L_0238;\n\tgoto L_0128;\n\tv540 = *([v520 @ X0_v13+E0]);\n\tv541 = v540 == 0;\n\tv542 = ~v541;\n\tif (v542) goto L_0128;\n\tv544 = \"il2cpp_codegen_runtime_class_init\"(v520, v437, v89, isRelative, getter, setter, usingInversePosition, updateNotice, v462, v459, v257, v128, v2, duration, v66, v67);\nL_0128:\n\tv551 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(&v549 @ stack_-88_v5 (System.Double));\n\tv597 = v515 >= 0;\n\tif (v597) goto L_01B7;\n\tv636 = v515 != -0.5d;\n\tif (v636) goto L_01CC;\n\tgoto L_01BC;\nL_0143:\n\tv427 = changeValue * v141;\n\tv428 = changeValue.y * v141;\n\tv429 = options >> 0x20;\n\tv430 = v429 & 0xFF;\n\tv431 = v230 + v427;\n\tv515 = v233 + v428;\n\tv433 = v430 == 0;\n\tif (v433) goto L_0238;\n\tgoto L_015A;\n\tv497 = *([v450 @ X0_v18+E0]);\n\tv498 = v497 == 0;\n\tv499 = ~v498;\n\tif (v499) goto L_015A;\n\tv501 = \"il2cpp_codegen_runtime_class_init\"(v450, v95, v89, isRelative, getter, setter, usingInversePosition, updateNotice, v427, v428, v257, v128, v2, duration, v66, v67);\nL_015A:\n\tv508 = 0x6D1ED0(&v549 @ stack_-88_v5 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, updateNotice, v431, v428, t.easeOvershootOrAmplitude, t.easePeriod, changeValue.y, duration, v66, v67);\n\tv539 = v431 >= 0;\n\tif (v539) goto L_017F;\n\tv576 = v431 != -0.5d;\n\tif (v576) goto L_01CF;\n\tgoto L_0184;\nL_017F:\n\tv587 = v431 != 0.5d;\n\tif (v587) goto L_01D2;\nL_0184:\n\tv693 = v674 + v673;\n\tv686 = v674 & 1;\n\tv688 = v686 == 0;\n\tv691 = ~v688;\n\tif (v691) goto L_FFFFFFFF;\n\tgoto L_0190;\nL_0190:\n\tgoto L_01D7;\nL_019B:\n\tv672 = v479 != 0.5d;\n\tif (v672) goto L_020E;\nL_01A0:\n\tv772 = v142 + v760;\n\tv773 = v142 & 1;\n\tv775 = v773 == 0;\n\tv778 = ~v775;\n\tif (v778) goto L_FFFFFFFF;\n\tgoto L_01AC;\nL_01AC:\n\tgoto L_0211;\nL_01B7:\n\tv647 = v515 != 0.5d;\n\tif (v647) goto L_0215;\nL_01BC:\n\tv753 = v460 + v741;\n\tv754 = v460 & 1;\n\tv756 = v754 == 0;\n\tv759 = ~v756;\n\tif (v759) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_01C9:\n\tv723 = v479 + -0.5d;\n\tv142 = System.Math::Ceiling(v723);\n\tgoto L_0211;\nL_01CC:\n\tv715 = v515 + -0.5d;\n\tv460 = System.Math::Ceiling(v715);\n\tgoto L_FFFFFFFF;\nL_01CF:\n\tv620 = v431 + -0.5d;\n\tv705 = System.Math::Ceiling(v620);\n\tgoto L_01D7;\nL_01D2:\n\tv624 = v431 + 0.5d;\n\tv705 = System.Math::Floor(v624);\nL_01D7:\n\tv712 = 0x6D1ED0(&v549 @ stack_-88_v5 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, updateNotice, v515, v693, t.easeOvershootOrAmplitude, t.easePeriod, changeValue.y, duration, v66, v67);\n\tv740 = v515 >= 0;\n\tif (v740) goto L_01FC;\n\tv792 = v515 != -0.5d;\n\tif (v792) goto L_0218;\n\tgoto L_0201;\nL_01FC:\n\tv803 = v515 != 0.5d;\n\tif (v803) goto L_021B;\nL_0201:\n\tv845 = v460 + v833;\n\tv846 = v460 & 1;\n\tv848 = v846 == 0;\n\tv851 = ~v848;\n\tif (v851) goto L_FFFFFFFF;\n\tgoto L_020D;\nL_020D:\n\tgoto L_FFFFFFFF;\nL_020E:\n\tv727 = v479 + 0.5d;\n\tv142 = System.Math::Floor(v727);\nL_0211:\n\tv781 = setter == 0;\n\tv226 = ~v781;\n\tif (v226) goto L_0238;\n\tgoto L_023C;\nL_0215:\n\tv719 = v515 + 0.5d;\n\tv460 = System.Math::Floor(v719);\n\tgoto L_FFFFFFFF;\nL_0218:\n\tv827 = v515 + -0.5d;\n\tv460 = System.Math::Ceiling(v827);\n\tgoto L_FFFFFFFF;\nL_021B:\n\tv831 = v515 + 0.5d;\n\tv460 = System.Math::Floor(v831);\nL_0238:\n\t// 568 MakeStruct v340 @ AGG10DE968_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v514 @ V9_v5 (System.Double), v515 @ V8_v6 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(setter, v340);\n\treturn;\nL_023C:\n\tthrow System.NullReferenceException;\n// 396 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, DOSetter<Vector2> setter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_0302: Expected I4, but got O
			//IL_03f3: Expected I4, but got O
			//IL_0357: Expected O, but got F8
			//IL_020b: Expected I4, but got O
			//IL_026d: Expected O, but got F8
			//IL_0929: Unknown result type (might be due to invalid IL or missing references)
			//IL_092e: Expected I4, but got Unknown
			//IL_096e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0973: Expected I4, but got Unknown
			//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e9: Expected I4, but got Unknown
			//IL_0824: Expected O, but got F8
			//IL_09e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e9: Expected I4, but got Unknown
			bool flag = t.loopType != LoopType.Incremental;
			Vector2 vector = startValue;
			float y = startValue.y;
			if (!flag)
			{
				float num = (float)t.completedLoops - (float)(t.isComplete ? 1 : 0);
				Vector2 vector2 = changeValue * num;
				Vector2 vector3 = startValue + vector2;
				vector = vector3;
				y = vector3.y;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num2 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					Vector2 vector4 = changeValue * num2;
					Sequence sequenceParent2 = t.sequenceParent;
					float num3 = (float)sequenceParent2.completedLoops - (float)(sequenceParent2.isComplete ? 1 : 0);
					Vector2 vector5 = vector4 * num3;
					Vector2 vector6 = default(Vector2);
					vector6.x = vector.x;
					vector6.y = y;
					Vector2 vector7 = vector6 + vector5;
					vector = vector7;
					y = vector7.y;
				}
			}
			float num4 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			Vector2 vector8;
			double num9;
			float num10;
			double num11 = default(double);
			double num12;
			double num20;
			Vector2 vector11;
			double num27;
			double num28;
			Vector2 vector13;
			if ((IntPtr)options != (IntPtr)4)
			{
				Vector2 vector9 = default(Vector2);
				if ((IntPtr)options == (IntPtr)2)
				{
					vector8 = getter();
					float num5 = vector9.x * num4;
					int num6 = (object)options >> 32;
					int num7 = num6 & 0xFF;
					float num8 = vector.x + num5;
					bool flag2 = num7 == 0;
					num9 = num8;
					num10 = vector8.y;
					if (!flag2)
					{
						Vector2 vector10 = ((DOGetter<Vector2>)num11)();
						double num13;
						if (num8 < 0f)
						{
							if ((double)num8 != -0.5)
							{
								double a = (double)num8 + -0.5;
								num12 = Math.Ceiling(a);
								goto IL_0760;
							}
							num13 = -1.0;
							num12 = num11;
						}
						else
						{
							if ((double)num8 != 0.5)
							{
								double d = (double)num8 + 0.5;
								num12 = Math.Floor(d);
								goto IL_0760;
							}
							num13 = 1.0;
							num12 = num11;
						}
						double num14 = num12 + num13;
						if ((num12 & 1) != 0)
						{
							num12 = num14;
						}
						goto IL_0760;
					}
				}
				else
				{
					float num15 = vector9.x * num4;
					float num16 = changeValue.y * num4;
					int num17 = (object)options >> 32;
					int num18 = num17 & 0xFF;
					float num19 = vector.x + num15;
					num10 = y + num16;
					bool flag3 = num18 == 0;
					num9 = num19;
					if (!flag3)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
						double num22;
						double num23;
						double num21;
						if (num19 < 0f)
						{
							if ((double)num19 != -0.5)
							{
								double a2 = (double)num19 + -0.5;
								num20 = Math.Ceiling(a2);
								num21 = -0.5;
								goto IL_0677;
							}
							num22 = -1.0;
							num23 = num11;
						}
						else
						{
							if ((double)num19 != 0.5)
							{
								double d2 = (double)num19 + 0.5;
								num20 = Math.Floor(d2);
								num21 = 0.5;
								goto IL_0677;
							}
							num22 = 1.0;
							num23 = num11;
						}
						num21 = num23 + num22;
						num20 = (((num23 & 1) != 0) ? num21 : num23);
						goto IL_0677;
					}
				}
			}
			else
			{
				vector11 = getter();
				float num24 = changeValue.y * num4;
				int num25 = (object)options >> 32;
				int num26 = num25 & 0xFF;
				num10 = y + num24;
				bool flag4 = num26 == 0;
				num9 = vector11.x;
				if (!flag4)
				{
					Vector2 vector12 = ((DOGetter<Vector2>)num11)();
					if (num10 < 0f)
					{
						if ((double)num10 == -0.5)
						{
							num27 = -1.0;
							num28 = num11;
							goto IL_0911;
						}
						double a3 = (double)num10 + -0.5;
						num28 = Math.Ceiling(a3);
						vector13 = vector11;
					}
					else
					{
						if ((double)num10 == 0.5)
						{
							num27 = 1.0;
							num28 = num11;
							goto IL_0911;
						}
						double d3 = (double)num10 + 0.5;
						num28 = Math.Floor(d3);
						vector13 = vector11;
					}
					goto IL_09b2;
				}
			}
			goto IL_0829;
			IL_0677:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			double num29;
			if (num10 < 0f)
			{
				if ((double)num10 != -0.5)
				{
					double a4 = (double)num10 + -0.5;
					num28 = Math.Ceiling(a4);
					goto IL_081c;
				}
				num29 = -1.0;
				num28 = num11;
			}
			else
			{
				if ((double)num10 != 0.5)
				{
					double d4 = (double)num10 + 0.5;
					num28 = Math.Floor(d4);
					goto IL_081c;
				}
				num29 = 1.0;
				num28 = num11;
			}
			double num30 = num28 + num29;
			if ((num28 & 1) != 0)
			{
				num28 = num30;
			}
			goto IL_081c;
			IL_0760:
			bool flag5 = setter == null;
			bool flag6 = !flag5;
			num9 = num12;
			num10 = vector8.y;
			if (!flag6)
			{
				throw new NullReferenceException();
			}
			goto IL_0829;
			IL_0829:
			Vector2 pNewValue = default(Vector2);
			pNewValue.x = (float)num9;
			pNewValue.y = num10;
			setter(pNewValue);
			return;
			IL_0911:
			double num31 = num28 + num27;
			if ((num28 & 1) != 0)
			{
				num28 = num31;
			}
			vector13 = vector11;
			goto IL_09b2;
			IL_081c:
			vector13 = (Vector2)num20;
			goto IL_09b2;
			IL_09b2:
			num9 = vector13.x;
			num10 = (float)num28;
			goto IL_0829;
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0x10DE974", Offset = "0x10DE974", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF5100]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274E2]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector2Plugin()
		{
		}
	}
}
