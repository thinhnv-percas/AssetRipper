using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200006F")]
	public class SpineboyFootplanter : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000070")]
		public class FootMovement
		{
			[Token(Token = "0x400027F")]
			[FieldOffset(Offset = "0x10")]
			public AnimationCurve xMoveCurve;

			[Token(Token = "0x4000280")]
			[FieldOffset(Offset = "0x18")]
			public AnimationCurve raiseCurve;

			[Token(Token = "0x4000281")]
			[FieldOffset(Offset = "0x20")]
			public float maxRaise;

			[Token(Token = "0x4000282")]
			[FieldOffset(Offset = "0x24")]
			public float minDistanceCompensate;

			[Token(Token = "0x4000283")]
			[FieldOffset(Offset = "0x28")]
			public float maxDistanceCompensate;

			[Token(Token = "0x60001EF")]
			[Address(RVA = "0x152002C", Offset = "0x152002C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public FootMovement()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000071")]
		public class Foot
		{
			[Token(Token = "0x4000284")]
			[FieldOffset(Offset = "0x10")]
			public Vector2 worldPos;

			[Token(Token = "0x4000285")]
			[FieldOffset(Offset = "0x18")]
			public float displacementFromCenter;

			[Token(Token = "0x4000286")]
			[FieldOffset(Offset = "0x1C")]
			public float distanceFromCenter;

			[Space]
			[Token(Token = "0x4000287")]
			[FieldOffset(Offset = "0x20")]
			public float lerp;

			[Token(Token = "0x4000288")]
			[FieldOffset(Offset = "0x24")]
			public Vector2 worldPosPrev;

			[Token(Token = "0x4000289")]
			[FieldOffset(Offset = "0x2C")]
			public Vector2 worldPosNext;

			[Token(Token = "0x1700003D")]
			public bool IsStepInProgress
			{
				[Token(Token = "0x60001F0")]
				[Address(RVA = "0x151FB2C", Offset = "0x151FB2C", Length = "0x14")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.lerp - 1f;\n\tv6 = v5 < 0;\n\treturn v6;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					float num = lerp - 1f;
					return num < 0f;
				}
			}

			[Token(Token = "0x1700003E")]
			public bool IsPrettyMuchDoneStepping
			{
				[Token(Token = "0x60001F1")]
				[Address(RVA = "0x151FB40", Offset = "0x151FB40", Length = "0x18")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.lerp - 0.7f;\n\tv7 = v6 < 0;\n\tv8 = v6 == 0;\n\tv9 = this.lerp ^ 0.7f;\n\tv10 = this.lerp ^ v6;\n\tv11 = v9 & v10;\n\tv12 = v11 < 0;\n\tv13 = v7 == v12;\n\tv14 = ~v8;\n\tv15 = v13 & v14;\n\treturn v15;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0044: Expected O, but got F4
					//IL_0053: Expected O, but got F4
					float num = lerp - 0.7f;
					bool flag = num < 0f;
					bool flag2 = num == 0f;
					object obj = lerp ^ 0.7f;
					object obj2 = lerp ^ num;
					int num2 = (int)((nint)obj & (nint)obj2);
					bool flag3 = num2 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					return flag4 && flag5;
				}
			}

			[Token(Token = "0x60001F2")]
			[Address(RVA = "0x151FB18", Offset = "0x151FB18", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.worldPos - centerOfGravityX;\n\t// 2 NotImplemented \"Instruction FABD not yet implemented.\"\n\tthis.displacementFromCenter = v2;\n\tthis.distanceFromCenter = centerOfGravityX;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void UpdateDistance(float centerOfGravityX)
			{
				float num = worldPos.x - centerOfGravityX;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				displacementFromCenter = num;
				distanceFromCenter = centerOfGravityX;
			}

			[Token(Token = "0x60001F3")]
			[Address(RVA = "0x151FBD8", Offset = "0x151FBD8", Length = "0x184")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv54 = UnityEngine.Physics2D;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, hits, methodInfo, v57, v58, v59, v60, v61, newDistance, centerOfGravityX, tentativeY, footRayRaise, footSize, v0, v62, v63);\n\tv66 = 1;\n\t*([1A37ABB]) = v66;\nL_0027:\n\tthis.lerp = 0f;\n\tthis.worldPosPrev = this.worldPos;\n\tgoto L_0038;\n\tv75 = UnityEngine.Vector2;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, hits, methodInfo, v57, v58, v59, v60, v61, newDistance, centerOfGravityX, tentativeY, footRayRaise, footSize, v0, v62, v63);\n\tv79 = 1;\n\t*([1A37AC7]) = v79;\nL_0038:\n\tv83 = centerOfGravityX - newDistance;\n\tv84 = tentativeY + footRayRaise;\n\tv85 = UnityEngine.Vector2;\n\tv86 = *([v85 @ X8_v9 (Il2CppClass<UnityEngine.Vector2>)+B8]);\n\tgoto L_0055;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v82, hits, methodInfo, v57, v58, v59, v60, v61, newDistance, centerOfGravityX, tentativeY, footRayRaise, footSize, v0, v62, v63);\nL_0055:\n\tv103 = 0;\n\t// 86 MakeStruct v114 @ AGG1523CEC_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v83 @ V12_v2 (System.Single), v84 @ V11_v2 (System.Single)\n\tv117 = UnityEngine.Physics2D::BoxCast(v114, footSize, 0f, v86.downVector, &v103 @ stack_-B8_v1, v184);\n\tv128 = v117 < 1;\n\tif (v128) goto L_0071;\n\tv137 = v184 + 0x20;\n\tv135 = UnityEngine.RaycastHit2D::get_point(v137);\nL_0071:\n\tthis.worldPosNext = v140;\n\tthis.worldPosNext.y = v142;\n\tv157 = *([v31 @ SYSREG+28]) != *([v31 @ SYSREG+28]);\n\tif (v157) goto L_0092;\n\treturn;\n\tv158 = new System.NullReferenceException();\n\tv188 = new System.IndexOutOfRangeException();\nL_0092:\n\tv195 = 0x1854EB0(v187, v184, 0, v57, v58, v59, v60, v61, v83, v84, footSize, footSize.y, 0, v86.downVector, *([v86 @ X8_v10 (Il2CppStaticFields<UnityEngine.Vector2>)+1C]), v63);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void StartNewStep(float newDistance, float centerOfGravityX, float tentativeY, float footRayRaise, RaycastHit2D[] hits, Vector2 footSize)
			{
				//IL_0155: Expected I, but got O
				//IL_015e: Expected I, but got O
				//IL_000e: Expected O, but got I4
				//IL_0047: Expected O, but got Ref
				//IL_00eb: Expected O, but got F4
				//IL_0087: Expected O, but got I
				lerp = 0f;
				worldPosPrev = worldPos;
				float num = centerOfGravityX - newDistance;
				float y = tentativeY + footRayRaise;
				nint num2 = (nint)typeof(Vector2);
				nint num3 = (nint)Vector2.zero;
				object obj = 0;
				Vector2 origin = default(Vector2);
				origin.x = num;
				origin.y = y;
				RaycastHit2D[] array = default(RaycastHit2D[]);
				int num4 = Physics2D.BoxCast(origin, footSize, 0f, Vector2.down, (ContactFilter2D)(&obj), array);
				bool flag = num4 < 1;
				float num5 = num;
				float y2 = tentativeY;
				if (!flag)
				{
					RaycastHit2D raycastHit2D = (RaycastHit2D)((nint)array + 32);
					Vector2 point = ((RaycastHit2D*)raycastHit2D)->point;
					num5 = point.x;
					y2 = point.y;
				}
				worldPosNext = (Vector2)num5;
				worldPosNext.y = y2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ SYSREG+28]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ SYSREG+28]");
				if (num6 != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
				}
			}

			[Token(Token = "0x60001F4")]
			[Address(RVA = "0x151FD5C", Offset = "0x151FD5C", Length = "0x138")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this.lerp >= 1f;\n\tif (v28) goto L_00AE;\n\tv31 = deltaTime * stepSpeed;\n\tv35 = v31 + this.lerp;\n\tv36 = this.worldPosNext - this.worldPosPrev;\n\tv47 = v36 < 0;\n\tif (v47) goto L_FFFFFFFF;\n\tgoto L_002C;\nL_002C:\n\tthis.lerp = v35;\n\t// 51 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv185 = UnityEngine.AnimationCurve::Evaluate(v67.xMoveCurve, v35);\n\tv190 = v185 < 0;\n\tv201 = UnityEngine.Mathf::Min(v185, 1f);\n\tv197 = ~v190;\n\tv198 = ~v197;\n\tif (v198) goto L_FFFFFFFF;\n\tgoto L_0048;\nL_0048:\n\tv202 = v36 * v201;\n\tv203 = this.worldPosPrev + v202;\n\tthis.worldPos.x = v203;\n\tv217 = UnityEngine.Mathf::Min(this.lerp, 1f);\n\tv208 = this.lerp < 0;\n\tv160 = this.worldPosNext.y - this.worldPosPrev.y;\n\tv214 = ~v208;\n\tv165 = ~v214;\n\tif (v165) goto L_FFFFFFFF;\n\tgoto L_0060;\nL_0060:\n\tv166 = v160 * v217;\n\tv98 = this.worldPosPrev.y + v166;\n\tv167 = v3 <= shuffleDistance;\n\tif (v167) goto L_0092;\n\tv226 = v3 * 0.5f;\n\tv227 = UnityEngine.Mathf::Min(v226, 2f);\n\tv231 = v226 - 1f;\n\tv232 = v231 < 0;\n\tv240 = ~v232;\n\tv241 = ~v240;\n\tif (v241) goto L_FFFFFFFF;\n\tgoto L_0089;\nL_0089:\n\tv260 = UnityEngine.AnimationCurve::Evaluate(v67.raiseCurve, this.lerp);\n\tv262 = v260 * v67.maxRaise;\n\tv75 = this.lerp;\n\tv263 = v242 * v262;\n\tv244 = v98 + v263;\n\tthis.worldPos.y = v244;\n\tgoto L_00A2;\nL_0092:\n\tv222 = UnityEngine.Time::get_deltaTime();\n\tv75 = this.lerp + v222;\n\tthis.lerp = v75;\n\tthis.worldPos.y = v98;\nL_00A2:\n\tv78 = v75 <= 1f;\n\tif (v78) goto L_00AE;\n\tthis.lerp = 1f;\nL_00AE:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void UpdateStepProgress(float deltaTime, float stepSpeed, float shuffleDistance, FootMovement forwardMovement, FootMovement backwardMovement)
			{
				if (lerp < 1f)
				{
					float num = deltaTime * stepSpeed;
					float time = num + lerp;
					float num2 = worldPosNext.x - worldPosPrev.x;
					FootMovement footMovement = ((num2 < 0f) ? backwardMovement : forwardMovement);
					lerp = time;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					float num3 = footMovement.xMoveCurve.Evaluate(time);
					bool flag = num3 < 0f;
					float num4 = Mathf.Min(num3, 1f);
					if (flag)
					{
						num4 = 0f;
					}
					float num5 = num2 * num4;
					float x = worldPosPrev.x + num5;
					worldPos.x = x;
					float num6 = Mathf.Min(lerp, 1f);
					bool flag2 = lerp < 0f;
					float num7 = worldPosNext.y - worldPosPrev.y;
					if (flag2)
					{
						num6 = 0f;
					}
					float num8 = num7 * num6;
					float num9 = worldPosPrev.y + num8;
					object obj = default(object);
					float num16;
					if ((float)obj > shuffleDistance)
					{
						float num10 = (float)obj * 0.5f;
						float num11 = Mathf.Min(num10, 2f);
						float num12 = num10 - 1f;
						float num13 = ((num12 < 0f) ? 1f : num11);
						float num14 = footMovement.raiseCurve.Evaluate(lerp);
						float num15 = num14 * footMovement.maxRaise;
						num16 = lerp;
						float num17 = num13 * num15;
						float y = num9 + num17;
						worldPos.y = y;
					}
					else
					{
						float deltaTime2 = Time.deltaTime;
						num16 = (lerp += deltaTime2);
						worldPos.y = num9;
					}
					if (num16 > 1f)
					{
						lerp = 1f;
					}
				}
			}

			[Token(Token = "0x60001F5")]
			[Address(RVA = "0x151FB58", Offset = "0x151FB58", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = otherLegDisplacementFromCenter < 0;\n\tif (v26) goto L_FFFFFFFF;\n\tgoto L_0023;\nL_0023:\n\tv39 = returnVal1 >= 0;\n\tif (v39) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\tv53 = UnityEngine.Random::Range(v44.minDistanceCompensate, v44.maxDistanceCompensate);\n\tv65 = v53 * otherLegDisplacementFromCenter;\n\tv93 = -comfyDistance;\n\tv67 = UnityEngine.Mathf::Abs(v65);\n\tv77 = UnityEngine.Mathf::Abs(otherLegDisplacementFromCenter);\n\tv117 = v65 < 0;\n\tif (v117) goto L_0047;\n\tgoto L_0047;\nL_0047:\n\tv122 = v67 - maxNewStepDisplacement;\n\tv123 = v122 < 0;\n\tv124 = v122 == 0;\n\tv125 = v67 ^ maxNewStepDisplacement;\n\tv126 = v67 ^ v122;\n\tv127 = v125 & v126;\n\tv128 = v127 < 0;\n\tv129 = v123 == v128;\n\tv130 = ~v129;\n\tv91 = v130 | v124;\n\tv131 = ~v91;\n\tif (v131) goto L_FFFFFFFF;\n\tv134 = v77 - minimumFootDistanceX;\n\tv107 = v134 < 0;\n\tgoto L_0065;\nL_0065:\n\treturnVal2 = v53 * v93;\n\tv89 = ~v107;\n\tif (v89) goto L_FFFFFFFF;\n\tgoto L_006F;\nL_006F:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static float GetNewDisplacement(float otherLegDisplacementFromCenter, float comfyDistance, float minimumFootDistanceX, float maxNewStepDisplacement, FootMovement forwardMovement, FootMovement backwardMovement)
			{
				//IL_0178: Expected O, but got F4
				//IL_0185: Expected O, but got F4
				float num = ((otherLegDisplacementFromCenter < 0f) ? (-1f) : 1f);
				FootMovement footMovement = ((!(num < 0f)) ? backwardMovement : forwardMovement);
				float num2 = UnityEngine.Random.Range(footMovement.minDistanceCompensate, footMovement.maxDistanceCompensate);
				float num3 = num2 * otherLegDisplacementFromCenter;
				float num4 = 0f - comfyDistance;
				float num5 = Mathf.Abs(num3);
				float num6 = Mathf.Abs(otherLegDisplacementFromCenter);
				if (!(num3 < 0f))
				{
					num4 = comfyDistance;
				}
				float num7 = num5 - maxNewStepDisplacement;
				bool flag = num7 < 0f;
				bool flag2 = num7 == 0f;
				object obj = num5 ^ maxNewStepDisplacement;
				object obj2 = num5 ^ num7;
				int num8 = (int)((nint)obj & (nint)obj2);
				bool flag3 = num8 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag4;
				bool flag6;
				if (flag5 || flag2)
				{
					float num9 = num6 - minimumFootDistanceX;
					flag6 = num9 < 0f;
				}
				else
				{
					flag6 = true;
				}
				float result = num2 * num4;
				if (!flag6)
				{
					result = num3;
				}
				return result;
			}

			[Token(Token = "0x60001F6")]
			[Address(RVA = "0x1520034", Offset = "0x1520034", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Foot()
			{
			}
		}

		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x20")]
		public float timeScale;

		[SpineBone(null, null, true, false)]
		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x28")]
		public string nearBoneName;

		[SpineBone(null, null, true, false)]
		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x30")]
		public string farBoneName;

		[Header("Settings")]
		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x38")]
		public Vector2 footSize;

		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x40")]
		public float footRayRaise;

		[Token(Token = "0x400026D")]
		[FieldOffset(Offset = "0x44")]
		public float comfyDistance;

		[Token(Token = "0x400026E")]
		[FieldOffset(Offset = "0x48")]
		public float centerOfGravityXOffset;

		[Token(Token = "0x400026F")]
		[FieldOffset(Offset = "0x4C")]
		public float feetTooFarApartThreshold;

		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0x50")]
		public float offBalanceThreshold;

		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0x54")]
		public float minimumSpaceBetweenFeet;

		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0x58")]
		public float maxNewStepDisplacement;

		[Token(Token = "0x4000273")]
		[FieldOffset(Offset = "0x5C")]
		public float shuffleDistance;

		[Token(Token = "0x4000274")]
		[FieldOffset(Offset = "0x60")]
		public float baseLerpSpeed;

		[Token(Token = "0x4000275")]
		[FieldOffset(Offset = "0x68")]
		public FootMovement forward;

		[Token(Token = "0x4000276")]
		[FieldOffset(Offset = "0x70")]
		public FootMovement backward;

		[Header("Debug")]
		[SerializeField]
		[Token(Token = "0x4000277")]
		[FieldOffset(Offset = "0x78")]
		private float balance;

		[SerializeField]
		[Token(Token = "0x4000278")]
		[FieldOffset(Offset = "0x7C")]
		private float distanceBetweenFeet;

		[SerializeField]
		[Token(Token = "0x4000279")]
		[FieldOffset(Offset = "0x80")]
		protected Foot nearFoot;

		[SerializeField]
		[Token(Token = "0x400027A")]
		[FieldOffset(Offset = "0x88")]
		protected Foot farFoot;

		[Token(Token = "0x400027B")]
		[FieldOffset(Offset = "0x90")]
		private Skeleton skeleton;

		[Token(Token = "0x400027C")]
		[FieldOffset(Offset = "0x98")]
		private Bone nearFootBone;

		[Token(Token = "0x400027D")]
		[FieldOffset(Offset = "0xA0")]
		private Bone farFootBone;

		[Token(Token = "0x400027E")]
		[FieldOffset(Offset = "0xA8")]
		private RaycastHit2D[] hits;

		[Token(Token = "0x1700003C")]
		public float Balance
		{
			[Token(Token = "0x60001EA")]
			[Address(RVA = "0x151F7A4", Offset = "0x151F7A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.balance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Balance;
			}
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0x151F7AC", Offset = "0x151F7AC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = Spine.Unity.UpdateBonesDelegate;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37AB8]) = v38;\nL_001A:\n\tUnityEngine.Time::set_timeScale(this.timeScale);\n\tv46 = UnityEngine.Component::get_transform(this);\n\tv51 = UnityEngine.Transform::get_position(v46);\n\tv102 = this.nearFoot;\n\tv102.worldPos = v51;\n\tv102.worldPos.y = v51.y;\n\tv103 = this.nearFoot;\n\tv75 = v103.worldPos - this.comfyDistance;\n\tv103.worldPos.x = v75;\n\tv103.worldPosNext = v103.worldPos;\n\tv103.worldPosPrev = v103.worldPos;\n\tv104 = this.farFoot;\n\tv104.worldPos = v51;\n\tv104.worldPos.y = v51.y;\n\tv105 = this.farFoot;\n\tv80 = v105.worldPos + this.comfyDistance;\n\tv105.worldPos.x = v80;\n\tv105.worldPosNext = v105.worldPos;\n\tv105.worldPosPrev = v105.worldPos;\n\tv87 = UnityEngine.Component::GetComponent(this);\n\tv141 = Spine.Unity.SkeletonRenderer::get_Skeleton(v87);\n\tthis.skeleton = v141;\n\tv143 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v143, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonAnimation::add_UpdateLocal(v87, v143);\n\tv89 = Spine.Skeleton::FindBone(this.skeleton, this.nearBoneName);\n\tthis.nearFootBone = v89;\n\tv90 = Spine.Skeleton::FindBone(this.skeleton, this.farBoneName);\n\tv69 = this.nearFoot;\n\tthis.farFootBone = v90;\n\tv69.lerp = 1f;\n\tv70 = this.farFoot;\n\tv70.lerp = 1f;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Time.timeScale = timeScale;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Foot foot = nearFoot;
			foot.worldPos = position;
			foot.worldPos.y = position.y;
			Foot foot2 = nearFoot;
			float x = foot2.worldPos.x - comfyDistance;
			foot2.worldPos.x = x;
			foot2.worldPosNext = foot2.worldPos;
			foot2.worldPosPrev = foot2.worldPos;
			Foot foot3 = farFoot;
			foot3.worldPos = position;
			foot3.worldPos.y = position.y;
			Foot foot4 = farFoot;
			float x2 = foot4.worldPos.x + comfyDistance;
			foot4.worldPos.x = x2;
			foot4.worldPosNext = foot4.worldPos;
			foot4.worldPosPrev = foot4.worldPos;
			SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			Skeleton skeleton = component.Skeleton;
			this.skeleton = skeleton;
			UpdateBonesDelegate value = UpdateLocal;
			component.UpdateLocal += value;
			Bone bone = this.skeleton.FindBone(nearBoneName);
			nearFootBone = bone;
			Bone bone2 = this.skeleton.FindBone(farBoneName);
			Foot foot5 = nearFoot;
			farFootBone = bone2;
			foot5.lerp = 1f;
			Foot foot6 = farFoot;
			foot6.lerp = 1f;
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0x151F940", Offset = "0x151F940", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Component::get_transform(this);\n\tv19 = UnityEngine.Transform::get_position(v15);\n\tv127 = this + 0x80;\n\tv116 = this.nearFoot;\n\tv106 = v19 + this.centerOfGravityXOffset;\n\tv149 = v116.worldPos - v106;\n\t// 28 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv116.displacementFromCenter = v149;\n\tv116.distanceFromCenter = this.centerOfGravityXOffset;\n\tv110 = this + 0x88;\n\tv104 = this.farFoot;\n\tv236 = v104.worldPos - v106;\n\t// 37 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv104.displacementFromCenter = v236;\n\tv104.distanceFromCenter = v149;\n\t// 42 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv237 = v236 + v116.displacementFromCenter;\n\tv99 = UnityEngine.Mathf::Abs(v237);\n\tthis.balance = v237;\n\tthis.distanceBetweenFeet = v116.worldPos;\n\tv249 = v99 > this.offBalanceThreshold;\n\tif (v249) goto L_004D;\n\tv262 = v116.worldPos <= this.feetTooFarApartThreshold;\n\tif (v262) goto L_0099;\nL_004D:\n\tv83 = v116.distanceFromCenter - v149;\n\tv78 = v83 < 0;\n\tv73 = v83 == 0;\n\tv68 = v116.distanceFromCenter ^ v149;\n\tv63 = v116.distanceFromCenter ^ v83;\n\tv58 = v68 & v63;\n\tv53 = v58 < 0;\n\tv273 = v78 == v53;\n\tv274 = ~v73;\n\tv275 = v273 & v274;\n\tv276 = ~v275;\n\tif (v276) goto L_FFFFFFFF;\n\tgoto L_005D;\nL_005D:\n\tv27 = *([v117 @ X9_v4]);\n\tv304 = v78 == v53;\n\tv43 = ~v73;\n\tv47 = v304 & v43;\n\tv39 = ~v47;\n\tif (v39) goto L_006E;\n\tgoto L_006E;\nL_006E:\n\tv76 = v27.lerp < 1f;\n\tif (v76) goto L_0099;\n\tv122 = this.nearFoot;\n\tv278 = *([v122 @ X8_v9+20]) <= 0.7f;\n\tif (v278) goto L_0099;\n\tv295 = Spine.Unity.Examples.SpineboyFootplanter+Foot::GetNewDisplacement(*([v122 @ X8_v9+18]), this.comfyDistance, this.minimumSpaceBetweenFeet, this.maxNewStepDisplacement, this.forward, this.backward);\n\t// 150 MakeStruct v277 @ AGG1523A48_6_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.footSize (UnityEngine.Vector2), this.footSize.y (System.Single)\n\tSpine.Unity.Examples.SpineboyFootplanter+Foot::StartNewStep(v27, v295, v106, v19.y, this.footRayRaise, this.hits, v277);\nL_0099:\n\tv151 = UnityEngine.Time::get_deltaTime();\n\tv307 = UnityEngine.Mathf::Abs(this.balance);\n\tv310 = v307 + -0.6f;\n\tv312 = v310 * 2.5f;\n\tv107 = this.baseLerpSpeed + v312;\n\tSpine.Unity.Examples.SpineboyFootplanter+Foot::UpdateStepProgress(this.nearFoot, v151, v107, this.shuffleDistance, this.forward, this.backward);\n\tSpine.Unity.Examples.SpineboyFootplanter+Foot::UpdateStepProgress(this.farFoot, v151, v107, this.shuffleDistance, this.forward, this.backward);\n\tv125 = this.nearFoot;\n\t// 191 MakeStruct v25 @ AGG1523ACC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v125.worldPos (UnityEngine.Vector2), v125.worldPos.y (System.Single), 0\n\tv154 = UnityEngine.Transform::InverseTransformPoint(v15, v25);\n\tSpine.Unity.SkeletonExtensions::SetLocalPosition(this.nearFootBone, v154);\n\tv126 = this.farFoot;\n\t// 208 MakeStruct v190 @ AGG1523AF8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v126.worldPos (UnityEngine.Vector2), v126.worldPos.y (System.Single), 0\n\tv225 = UnityEngine.Transform::InverseTransformPoint(v15, v190);\n\tSpine.Unity.SkeletonExtensions::SetLocalPosition(this.farFootBone, v225);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 156 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateLocal(ISkeletonAnimation animated)
		{
			//IL_0028: Expected O, but got I
			//IL_0098: Expected O, but got I
			//IL_01c2: Expected O, but got F4
			//IL_01d4: Expected O, but got F4
			//IL_02e2: Expected F4, but got I
			Transform transform = base.transform;
			Vector3 position = transform.position;
			object obj = (nint)this + 128;
			Foot foot = nearFoot;
			float num = position.x + centerOfGravityXOffset;
			float num2 = foot.worldPos.x - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			foot.displacementFromCenter = num2;
			foot.distanceFromCenter = centerOfGravityXOffset;
			object obj2 = (nint)this + 136;
			Foot foot2 = farFoot;
			float num3 = foot2.worldPos.x - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			foot2.displacementFromCenter = num3;
			foot2.distanceFromCenter = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			float f = num3 + foot.displacementFromCenter;
			float num4 = Mathf.Abs(f);
			balance = f;
			distanceBetweenFeet = foot.worldPos.x;
			if (num4 > offBalanceThreshold || foot.worldPos.x > feetTooFarApartThreshold)
			{
				float num5 = foot.distanceFromCenter - num2;
				bool flag = num5 < 0f;
				bool flag2 = num5 == 0f;
				object obj3 = foot.distanceFromCenter ^ num2;
				object obj4 = foot.distanceFromCenter ^ num5;
				int num6 = (int)((nint)obj3 & (nint)obj4);
				bool flag3 = num6 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				object obj5 = ((!(flag4 && flag5)) ? obj2 : obj);
				Foot foot3 = (Foot)obj5;
				bool flag6 = flag == flag3;
				bool flag7 = !flag2;
				if (flag6 && flag7)
				{
					obj = obj2;
				}
				if (!(foot3.lerp < 1f))
				{
					object obj6 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v9+20]");
					if (0f > 0.7f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v9+18]");
						float newDisplacement = Foot.GetNewDisplacement(0f, comfyDistance, minimumSpaceBetweenFeet, maxNewStepDisplacement, forward, backward);
						Vector2 vector = default(Vector2);
						vector.x = footSize.x;
						vector.y = footSize.y;
						foot3.StartNewStep(newDisplacement, num, position.y, footRayRaise, hits, vector);
					}
				}
			}
			float deltaTime = Time.deltaTime;
			float num7 = Mathf.Abs(Balance);
			float num8 = num7 + -0.6f;
			float num9 = num8 * 2.5f;
			float stepSpeed = baseLerpSpeed + num9;
			nearFoot.UpdateStepProgress(deltaTime, stepSpeed, shuffleDistance, forward, backward);
			farFoot.UpdateStepProgress(deltaTime, stepSpeed, shuffleDistance, forward, backward);
			Foot foot4 = nearFoot;
			Vector3 position2 = default(Vector3);
			position2.x = foot4.worldPos.x;
			position2.y = foot4.worldPos.y;
			position2.z = 0f;
			Vector3 position3 = transform.InverseTransformPoint(position2);
			nearFootBone.SetLocalPosition(position3);
			Foot foot5 = farFoot;
			Vector3 position4 = default(Vector3);
			position4.x = foot5.worldPos.x;
			position4.y = foot5.worldPos.y;
			position4.z = 0f;
			Vector3 position5 = transform.InverseTransformPoint(position4);
			farFootBone.SetLocalPosition(position5);
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0x151FE94", Offset = "0x151FE94", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = UnityEngine.Application;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37AB9]) = v39;\nL_0018:\n\tgoto L_001B;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_001B:\n\tv47 = UnityEngine.Application::get_isPlaying();\n\tv49 = v47 == 0;\n\tif (v49) goto L_0064;\n\t// 36 MakeStruct v55 @ AGG1523EFC_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 0, 1f, 0, 1f\n\tUnityEngine.Gizmos::set_color(v55);\n\tv61 = this.nearFoot;\n\t// 48 MakeStruct v81 @ AGG1523F20_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v61.worldPos (UnityEngine.Vector2), v61.worldPos.y (System.Single), 0\n\tUnityEngine.Gizmos::DrawSphere(v81, 0.15f);\n\tv136 = this.nearFoot;\n\t// 58 MakeStruct v77 @ AGG1523F3C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v136.worldPosNext (UnityEngine.Vector2), v136.worldPosNext.y (System.Single), 0\n\tUnityEngine.Gizmos::DrawWireSphere(v77, 0.15f);\n\t// 65 MakeStruct v73 @ AGG1523F54_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), 1f, 0, 1f, 1f\n\tUnityEngine.Gizmos::set_color(v73);\n\tv137 = this.farFoot;\n\t// 75 MakeStruct v69 @ AGG1523F70_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v137.worldPos (UnityEngine.Vector2), v137.worldPos.y (System.Single), 0\n\tUnityEngine.Gizmos::DrawSphere(v69, 0.15f);\n\tv110 = this.farFoot;\n\t// 91 MakeStruct v64 @ AGG1523F98_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v110.worldPosNext (UnityEngine.Vector2), v110.worldPosNext.y (System.Single), 0\n\tUnityEngine.Gizmos::DrawWireSphere(v64, 0.15f);\n\treturn;\nL_0064:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDrawGizmos()
		{
			if (Application.isPlaying)
			{
				Color color = default(Color);
				color.r = 0f;
				color.g = 1f;
				color.b = 0f;
				color.a = 1f;
				Gizmos.color = color;
				Foot foot = nearFoot;
				Vector3 center = default(Vector3);
				center.x = foot.worldPos.x;
				center.y = foot.worldPos.y;
				center.z = 0f;
				Gizmos.DrawSphere(center, 0.15f);
				Foot foot2 = nearFoot;
				Vector3 center2 = default(Vector3);
				center2.x = foot2.worldPosNext.x;
				center2.y = foot2.worldPosNext.y;
				center2.z = 0f;
				Gizmos.DrawWireSphere(center2, 0.15f);
				Color color2 = default(Color);
				color2.r = 1f;
				color2.g = 0f;
				color2.b = 1f;
				color2.a = 1f;
				Gizmos.color = color2;
				Foot foot3 = farFoot;
				Vector3 center3 = default(Vector3);
				center3.x = foot3.worldPos.x;
				center3.y = foot3.worldPos.y;
				center3.z = 0f;
				Gizmos.DrawSphere(center3, 0.15f);
				Foot foot4 = farFoot;
				Vector3 center4 = default(Vector3);
				center4.x = foot4.worldPosNext.x;
				center4.y = foot4.worldPosNext.y;
				center4.z = 0f;
				Gizmos.DrawWireSphere(center4, 0.15f);
			}
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0x151FFB0", Offset = "0x151FFB0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = UnityEngine.RaycastHit2D[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37ABA]) = v37;\nL_0019:\n\tthis.timeScale = 0.5f;\n\tthis.footRayRaise = T;\n\tthis.offBalanceThreshold = *([407B80]);\n\tthis.baseLerpSpeed = 3.5f;\n\t// 31 NewArr v46 @ X0_v3 (UnityEngine.RaycastHit2D[]), typeof(UnityEngine.RaycastHit2D[]), 1\n\tthis.hits = v46;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyFootplanter()
		{
			//IL_0026: Expected F4, but got O
			//IL_0038: Expected F4, but got I
			base._002Ector();
			timeScale = 0.5f;
			footRayRaise = (float)typeof(_0021_00210);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B80]");
			offBalanceThreshold = 0f;
			baseLerpSpeed = 3.5f;
			RaycastHit2D[] array = new RaycastHit2D[1];
			hits = array;
		}
	}
}
