using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000061")]
	public class SkeletonUtilityEyeConstraint : SkeletonUtilityConstraint
	{
		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x30")]
		public Transform[] eyes;

		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x38")]
		public float radius;

		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0x40")]
		public Transform target;

		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x48")]
		public Vector3 targetPosition;

		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0x54")]
		public float speed;

		[Token(Token = "0x400021A")]
		[FieldOffset(Offset = "0x58")]
		private Vector3[] origins;

		[Token(Token = "0x400021B")]
		[FieldOffset(Offset = "0x60")]
		private Vector3 centerPoint;

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0x151CEF8", Offset = "0x151CEF8", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = UnityEngine.Application;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv56 = UnityEngine.Vector3[];\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37A9F]) = v50;\nL_0020:\n\tgoto L_0023;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0023:\n\tv60 = UnityEngine.Application::get_isPlaying();\n\tv62 = v60 == 0;\n\tif (v62) goto L_00E7;\n\tSpine.Unity.SkeletonUtilityConstraint::OnEnable(this);\n\tv162 = this.eyes;\n\tv136 = UnityEngine.Transform::get_localPosition(v162[0]);\n\tgoto L_0044;\n\tv399 = UnityEngine.Vector3;\n\tv400 = \"il2cpp_codegen_initialize_runtime_metadata\"(v399, v342, v33, v34, v35, v36, v37, v38, v333, v325, v320, v42, v43, v44, v45, v46);\n\tv402 = 1;\n\t*([1A35519]) = v402;\nL_0044:\n\tv361 = this.eyes;\n\tv406 = UnityEngine.Vector3;\n\tv336 = *([v406 @ X9_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t// 81 NewArr v346 @ X0_v16 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v361.Length\n\tv384 = this.eyes;\n\tthis.origins = v346;\n\tv302 = v336.zeroVector * 0x3F;\n\tv306 = *([v336 @ X9_v9 (Il2CppStaticFields<UnityEngine.Vector3>)+8]) * 0.5f;\nL_0060:\n\t;\n\tv243 = v364 >= v384.Length;\n\tif (v243) goto L_00DA;\n\tv332 = UnityEngine.Transform::get_localPosition(v384[v364 @ X21_v9 (System.Int32)]);\n\tv360 = v368 + v294;\n\t*([v360 @ X8_v16+20]) = v332;\n\t*([v360 @ X8_v16+24]) = v332.y;\n\t*([v360 @ X8_v16+28]) = v332.z;\n\tv368 = this.origins;\n\tv364 = v364 + 1;\n\tv429 = this.origins + v294;\n\tv324 = v130 - v306;\n\tv432 = v136 - v302;\n\tv433 = v136 + v302;\n\tv248 = v130 + v306;\n\t// 178 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 179 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\tv443 = v324 >= *([v429 @ X8_v18+28]);\n\tif (v443) goto L_FFFFFFFF;\n\tgoto L_00BC;\nL_00BC:\n\tv283 = v248 - *([v429 @ X8_v18+28]);\n\tv279 = v283 < 0;\n\tv275 = v283 == 0;\n\tv271 = v248 ^ *([v429 @ X8_v18+28]);\n\tv267 = v248 ^ v283;\n\tv263 = v271 & v267;\n\tv259 = v263 < 0;\n\tv384 = this.eyes;\n\t// 196 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 197 NotImplemented \"Instruction BIF not yet implemented.\"\n\tv447 = v279 == v259;\n\tv239 = ~v275;\n\tv242 = v447 & v239;\n\tv245 = ~v242;\n\tif (v245) goto L_FFFFFFFF;\n\tgoto L_00CF;\nL_00CF:\n\tv319 = v433 - v432;\n\tv251 = v450 - v324;\n\tv302 = v319 * 0x3F;\n\tv306 = v251 * 0.5f;\n\tv294 = v294 + 0xC;\n\tv329 = v432 + v302;\n\tv314 = v324 + v306;\n\tv451 = v384 == 0;\n\tv349 = ~v451;\n\tif (v349) goto L_0060;\n\tthrow System.NullReferenceException;\nL_00DA:\n\tthis.centerPoint = v136;\n\tthis.centerPoint.z = v130;\nL_00E7:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 154 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnEnable()
		{
			//IL_006a: Expected I, but got O
			//IL_0073: Expected I, but got O
			//IL_011e: Expected O, but got I
			//IL_0169: Expected O, but got I
			//IL_0202: Expected F4, but got I
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Expected O, but got Unknown
			//IL_02bd: Expected O, but got F4
			//IL_0224: Expected F4, but got I
			//IL_03cc: Expected O, but got F4
			if (!Application.isPlaying)
			{
				return;
			}
			base.OnEnable();
			Transform[] array = eyes;
			Vector3 vector = array[0].localPosition;
			Transform[] array2 = eyes;
			nint num = (nint)typeof(Vector3);
			nint num2 = (nint)Vector3.zero;
			Vector3[] array3 = new Vector3[array2.Length];
			Transform[] array4 = eyes;
			origins = array3;
			float num3 = Vector3.zero.x * 8.8E-44f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ X9_v9 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float num4 = 0f * 0.5f;
			int num5 = 0;
			float num6 = vector.z;
			int num7 = 0;
			Vector3[] array5 = array3;
			while (num7 < array4.Length)
			{
				Vector3 localPosition = array4[num7].localPosition;
				object obj = (nint)array5 + num5;
				_ = localPosition.y;
				_ = localPosition.z;
				array5 = origins;
				num7++;
				object obj2 = (nint)origins + num5;
				float num8 = num6 - num4;
				float num9 = vector.x - num3;
				float num10 = vector.x + num3;
				float num11 = num6 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FCMGT not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FCMGT not yet implemented.\"");
				float num12 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X8_v18+28]");
				if (!(num12 < 0f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X8_v18+28]");
					num8 = 0f;
				}
				float num13 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X8_v18+28]");
				float num14 = num13 - 0f;
				bool flag = num14 < 0f;
				bool flag2 = num14 == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X8_v18+28]");
				object obj3 = num11 ^ 0;
				object obj4 = num11 ^ num14;
				int num15 = (int)((nint)obj3 & (nint)obj4);
				bool flag3 = num15 < 0;
				array4 = eyes;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIF not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIF not yet implemented.\"");
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				float num16;
				if (flag4 && flag5)
				{
					num16 = num11;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X8_v18+28]");
					num16 = 0f;
				}
				float num17 = num10 - num9;
				float num18 = num16 - num8;
				num3 = num17 * 8.8E-44f;
				num4 = num18 * 0.5f;
				num5 += 12;
				float num19 = num9 + num3;
				float num20 = num8 + num4;
				bool flag6 = array4 == null;
				bool flag7 = !flag6;
				num6 = num20;
				vector = (Vector3)num19;
				if (!flag7)
				{
					throw new NullReferenceException();
				}
			}
			centerPoint = vector;
			centerPoint.z = num6;
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0x151D120", Offset = "0x151D120", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AA0]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = UnityEngine.Application::get_isPlaying();\n\tv47 = v45 == 0;\n\tif (v47) goto L_0062;\n\tv159 = this.eyes;\nL_002D:\n\tv122 = v157 >= v159.Length;\n\tif (v122) goto L_006A;\n\tv171 = v157 + 1;\n\tv243 = this.origins + v168;\n\tv169 = v168 + 0xC;\n\t// 84 MakeStruct v123 @ AGG15211D0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v243 @ X9_v6+20], [v243 @ X9_v6+24], [v243 @ X9_v6+28]\n\tUnityEngine.Transform::set_localPosition(v159[v157 @ X10_v4 (System.Int32)], v123);\n\tv159 = this.eyes;\n\tv244 = this.eyes == 0;\n\tv164 = ~v244;\n\tif (v164) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0062:\n\treturn;\nL_006A:\n\tSpine.Unity.SkeletonUtilityConstraint::OnDisable(this);\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnDisable()
		{
			//IL_0074: Expected O, but got I
			//IL_0097: Expected F4, but got I
			//IL_00ac: Expected F4, but got I
			//IL_00c1: Expected F4, but got I
			if (!Application.isPlaying)
			{
				return;
			}
			Transform[] array = eyes;
			int num = 0;
			int num2 = 0;
			Vector3 localPosition = default(Vector3);
			while (num < array.Length)
			{
				int num3 = num + 1;
				object obj = (nint)origins + num2;
				int num4 = num2 + 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X9_v6+20]");
				localPosition.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X9_v6+24]");
				localPosition.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X9_v6+28]");
				localPosition.z = 0f;
				array[num].localPosition = localPosition;
				array = eyes;
				bool flag = eyes == null;
				bool flag2 = !flag;
				num = num3;
				num2 = num4;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			base.OnDisable();
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0x151D20C", Offset = "0x151D20C", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv42 = UnityEngine.Object;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 1;\n\t*([1A37AA1]) = v61;\nL_0024:\n\tgoto L_0029;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_0029:\n\tv72 = UnityEngine.Object::op_Inequality(this.target, 0);\n\tv74 = v72 == 0;\n\tif (v74) goto L_003B;\n\tv81 = UnityEngine.Transform::get_position(this.target);\n\tthis.targetPosition = v81;\n\tthis.targetPosition.y = v81.y;\n\tthis.targetPosition.z = v81.z;\n\tgoto L_0040;\nL_003B:\n\tv232 = this.targetPosition;\n\tv227 = this.targetPosition.y;\n\tv222 = this.targetPosition.z;\nL_0040:\n\tv265 = UnityEngine.Component::get_transform(this);\n\t// 71 MakeStruct v218 @ AGG15212D0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.centerPoint (UnityEngine.Vector3), this.centerPoint.y (System.Single), this.centerPoint.z (System.Single)\n\tv429 = UnityEngine.Transform::TransformPoint(v265, v218);\n\tgoto L_005A;\n\tv437 = System.Math;\n\tv438 = \"il2cpp_codegen_initialize_runtime_metadata\"(v437, v262, v71, v46, v47, v48, v49, v50, v429, v430, v431, v54, v55, v56, v57, v58);\n\tv441 = 1;\n\t*([1A35759]) = v441;\nL_005A:\n\tv443 = v232 - v429;\n\tv229 = v227 - v429.y;\n\tv224 = v222 - v429.z;\n\tgoto L_0063;\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v446, v262, v71, v46, v47, v48, v49, v50, v429, v430, v431, v54, v55, v56, v57, v58);\nL_0063:\n\tv452 = v443 * v443;\n\tv248 = v229 * v229;\n\tv241 = v224 * v224;\n\tv453 = v452 + v248;\n\tv454 = v241 + v453;\n\tv234 = UnityEngine.Mathf::Sqrt(v454);\n\tgoto L_00AE;\n\tv470 = *([1A3575C]);\n\tv471 = v470 == 0;\n\tv472 = ~v471;\n\tif (v472) goto L_FFFFFFFF;\n\tv493 = System.Math;\n\tv494 = \"il2cpp_codegen_initialize_runtime_metadata\"(v493, v262, v71, v46, v47, v48, v49, v50, v456, v248, v241, v54, v55, v56, v57, v58);\n\tv497 = 1;\n\t*([1A3575C]) = v497;\n\tv498 = System.Math;\n\tv499 = *([v498 @ X0_v28+E0]);\n\tv500 = v499 == 0;\n\tv501 = ~v500;\n\tif (v501) goto L_FFFFFFFF;\n\tv504 = \"il2cpp_codegen_runtime_class_init\"(v498, v262, v71, v46, v47, v48, v49, v50, v456, v248, v241, v54, v55, v56, v57, v58);\n\tv507 = 1E-05f;\n\tv473 = v234 <= v507;\n\tif (v473) goto L_009C;\n\tv522 = v455;\n\tv523 = v444 / v234;\n\tv524 = v445 / v234;\n\tv525 = v522 / v234;\n\tgoto L_FFFFFFFF;\nL_009C:\n\t;\n\tv527 = *([1A35519]);\n\tv528 = v527 == 0;\n\tv529 = ~v528;\n\tif (v529) goto L_FFFFFFFF;\n\tv537 = UnityEngine.Vector3;\n\tv538 = \"il2cpp_codegen_initialize_runtime_metadata\"(v537, v262, v71, v46, v47, v48, v49, v50, v507, v248, v241, v54, v55, v56, v57, v58);\n\tv540 = 1;\n\t*([1A35519]) = v540;\n\tv543 = UnityEngine.Vector3;\n\tv535 = *([v543 @ X8_v30+B8]);\n\tv533 = *([v535 @ X8_v31]);\n\tv532 = *([v535 @ X8_v31+4]);\n\tv531 = *([v535 @ X8_v31+8]);\n\tv482 = v485;\nL_00AE:\n\tv520 = this.eyes;\nL_00B7:\n\t;\n\tv141 = v134 >= v520.Length;\n\tif (v141) goto L_0176;\n\tv266 = UnityEngine.Component::get_transform(this);\n\tv545 = this.origins + v137;\n\t// 219 MakeStruct v114 @ AGG1521438_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v545 @ X8_v13+20], [v545 @ X8_v13+24], [v545 @ X8_v13+28]\n\tv253 = UnityEngine.Transform::TransformPoint(v266, v114);\n\tv281 = this.eyes;\n\tv254 = UnityEngine.Transform::get_position(v281[v134 @ X23_v2 (System.Int32)]);\n\tv283 = this.hierarchy;\n\tv554 = UnityEngine.Time::get_deltaTime();\n\tgoto L_0113;\n\tv559 = v286;\n\tv560 = v556;\n\tv561 = \"il2cpp_codegen_initialize_runtime_metadata\"(v559, v261, v71, v46, v47, v48, v49, v50, v554, v247, v240, v91, v88, v556, v57, v58);\n\tv562 = v560;\n\t*([1A37AC5]) = v129;\nL_0113:\n\tv567 = v229 * this.radius;\n\tv568 = v443 * this.radius;\n\tv569 = v224 * this.radius;\n\tv570 = v568 * v283.positionScale;\n\tv571 = v567 * v283.positionScale;\n\tv572 = v569 * v283.positionScale;\n\tv250 = v253 + v570;\n\tv243 = v253.y + v571;\n\tv236 = v253.z + v572;\n\tv203 = v250 - v254;\n\tv208 = v243 - v254.y;\n\tv213 = v236 - v254.z;\n\tv576 = v203 * v203;\n\tv577 = v208 * v208;\n\tv578 = v576 + v577;\n\tv87 = v213 * v213;\n\tv107 = v87 + v578;\n\tv583 = v107 == 0;\n\tif (v583) goto L_015C;\n\tv589 = v283.positionScale * this.speed;\n\tv590 = v589 * v554;\n\tv601 = v590 < 0;\n\tif (v601) goto L_014E;\n\tv603 = v590 * v590;\n\tv631 = v107 < v603;\n\tv621 = ~v631;\n\tv619 = v107 - v603;\n\tv615 = v619 == 0;\n\tv632 = ~v621;\n\tv605 = v632 | v615;\n\tif (v605) goto L_015C;\nL_014E:\n\tgoto L_0150;\n\tv637 = \"il2cpp_codegen_runtime_class_init\"(v634, v261, v71, v46, v47, v48, v49, v50, v573, v574, v575, v633, v87, v97, v57, v58);\nL_0150:\n\tv638 = UnityEngine.Mathf::Sqrt(v107);\n\tv639 = v203 / v638;\n\tv640 = v208 / v638;\n\tv641 = v213 / v638;\n\tv642 = v590 * v639;\n\tv643 = v590 * v640;\n\tv602 = v590 * v641;\n\tv250 = v254 + v642;\n\tv243 = v254.y + v643;\n\tv236 = v254.z + v602;\nL_015C:\n\t// 348 MakeStruct v83 @ AGG1521574_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v250 @ V0_v19 (System.Single), v243 @ V1_v14 (System.Single), v236 @ V2_v14 (System.Single)\n\tUnityEngine.Transform::set_position(v281[v134 @ X23_v2 (System.Int32)], v83);\n\tv520 = this.eyes;\n\tv134 = v134 + 1;\n\tv137 = v137 + 0xC;\n\tv636 = this.eyes == 0;\n\tv270 = ~v636;\n\tif (v270) goto L_00B7;\n\tthrow System.NullReferenceException;\nL_0176:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 229 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoUpdate()
		{
			//IL_01ac: Expected O, but got I
			//IL_01c4: Expected F4, but got I
			//IL_01d9: Expected F4, but got I
			//IL_01ee: Expected F4, but got I
			float z;
			float y;
			Vector3 vector2;
			if (target != null)
			{
				Vector3 vector = (targetPosition = target.position);
				targetPosition.y = vector.y;
				targetPosition.z = vector.z;
				z = vector.z;
				y = vector.y;
				vector2 = vector;
			}
			else
			{
				vector2 = targetPosition;
				y = targetPosition.y;
				z = targetPosition.z;
			}
			Transform transform = base.transform;
			Vector3 position = default(Vector3);
			position.x = centerPoint.x;
			position.y = centerPoint.y;
			position.z = centerPoint.z;
			Vector3 vector3 = transform.TransformPoint(position);
			float num = vector2.x - vector3.x;
			float num2 = y - vector3.y;
			float num3 = z - vector3.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num3 * num3;
			float num7 = num4 + num5;
			float f = num6 + num7;
			float num8 = Mathf.Sqrt(f);
			Transform[] array = eyes;
			int num9 = 0;
			int num10 = 0;
			Vector3 position2 = default(Vector3);
			Vector3 position4 = default(Vector3);
			while (num9 < array.Length)
			{
				Transform transform2 = base.transform;
				object obj = (nint)origins + num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ X8_v13+20]");
				position2.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ X8_v13+24]");
				position2.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ X8_v13+28]");
				position2.z = 0f;
				Vector3 vector4 = transform2.TransformPoint(position2);
				Transform[] array2 = eyes;
				Vector3 position3 = array2[num9].position;
				SkeletonUtility skeletonUtility = hierarchy;
				float deltaTime = Time.deltaTime;
				float num11 = num2 * radius;
				float num12 = num * radius;
				float num13 = num3 * radius;
				float num14 = num12 * skeletonUtility.PositionScale;
				float num15 = num11 * skeletonUtility.PositionScale;
				float num16 = num13 * skeletonUtility.PositionScale;
				float num17 = vector4.x + num14;
				float num18 = vector4.y + num15;
				float num19 = vector4.z + num16;
				float num20 = num17 - position3.x;
				float num21 = num18 - position3.y;
				float num22 = num19 - position3.z;
				float num23 = num20 * num20;
				float num24 = num21 * num21;
				float num25 = num23 + num24;
				float num26 = num22 * num22;
				float num27 = num26 + num25;
				if (num27 != 0f)
				{
					float num28 = skeletonUtility.PositionScale * speed;
					float num29 = num28 * deltaTime;
					if (!(num29 < 0f))
					{
						float num30 = num29 * num29;
						bool flag = num27 < num30;
						bool flag2 = !flag;
						float num31 = num27 - num30;
						bool flag3 = num31 == 0f;
						bool flag4 = !flag2;
						if (flag4 || flag3)
						{
							goto IL_0563;
						}
					}
					float num32 = Mathf.Sqrt(num27);
					float num33 = num20 / num32;
					float num34 = num21 / num32;
					float num35 = num22 / num32;
					float num36 = num29 * num33;
					float num37 = num29 * num34;
					float num38 = num29 * num35;
					num17 = position3.x + num36;
					num18 = position3.y + num37;
					num19 = position3.z + num38;
				}
				goto IL_0563;
				IL_0563:
				position4.x = num17;
				position4.y = num18;
				position4.z = num19;
				array2[num9].position = position4;
				array = eyes;
				num9++;
				num10 += 12;
				if (eyes == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0x151D5B8", Offset = "0x151D5B8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.radius = 0.5f;\n\tthis.speed = 10f;\n\tSpine.Unity.SkeletonUtilityConstraint::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonUtilityEyeConstraint()
		{
			radius = 0.5f;
			speed = 10f;
		}
	}
}
