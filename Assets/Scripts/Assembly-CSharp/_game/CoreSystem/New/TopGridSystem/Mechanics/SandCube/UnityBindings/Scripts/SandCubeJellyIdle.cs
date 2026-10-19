using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts
{
	[DisallowMultipleComponent]
	[Token(Token = "0x200018C")]
	public class SandCubeJellyIdle : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x200018D")]
		public class JellyBone
		{
			[Token(Token = "0x40004ED")]
			[FieldOffset(Offset = "0x10")]
			public Transform target;

			[Token(Token = "0x40004EE")]
			[FieldOffset(Offset = "0x18")]
			public Vector3 positionAmplitude;

			[Token(Token = "0x40004EF")]
			[FieldOffset(Offset = "0x24")]
			public Vector3 rotationAmplitude;

			[Range(0f, 0.2f)]
			[Token(Token = "0x40004F0")]
			[FieldOffset(Offset = "0x30")]
			public float scaleAmplitude;

			[Token(Token = "0x40004F1")]
			[FieldOffset(Offset = "0x34")]
			public float phaseOffset;

			[Min(0.0001f)]
			[Token(Token = "0x40004F2")]
			[FieldOffset(Offset = "0x38")]
			public float frequencyMultiplier;

			[Token(Token = "0x600075D")]
			[Address(RVA = "0x3E681AC", Offset = "0x3E681AC", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.positionAmplitude = *([93094D0]);\n\tthis.rotationAmplitude.y = 2d;\n\tthis.scaleAmplitude = 0.02f;\n\tthis.frequencyMultiplier = 1f;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public JellyBone()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SandCubeJellyIdle.JellyBone::.ctor");
			}
		}

		[SerializeField]
		[Token(Token = "0x40004E6")]
		[FieldOffset(Offset = "0x20")]
		private List<JellyBone> m_bones;

		[Tooltip("Base wobble cycles per second.")]
		[SerializeField]
		[Token(Token = "0x40004E7")]
		[FieldOffset(Offset = "0x28")]
		private float m_baseFrequency;

		[Tooltip("Global amplitude multiplier — drop to 0 to mute without disabling.")]
		[Range(0f, 2f)]
		[SerializeField]
		[Token(Token = "0x40004E8")]
		[FieldOffset(Offset = "0x2C")]
		private float m_intensity;

		[Tooltip("Randomize the starting phase on enable so neighbouring cubes don't pulse in lockstep.")]
		[SerializeField]
		[Token(Token = "0x40004E9")]
		[FieldOffset(Offset = "0x30")]
		private bool m_randomizeStartPhase;

		[SerializeField]
		[Token(Token = "0x40004EA")]
		[FieldOffset(Offset = "0x31")]
		private bool m_useUnscaledTime;

		[Token(Token = "0x40004EB")]
		[FieldOffset(Offset = "0x34")]
		private float _time;

		[Token(Token = "0x40004EC")]
		[FieldOffset(Offset = "0x38")]
		private float _startPhase;

		[Token(Token = "0x600075A")]
		[Address(RVA = "0x3E67D5C", Offset = "0x3E67D5C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._time = 0f;\n\tv23 = this.m_randomizeStartPhase != 1;\n\tv32 = 0;\n\tif (v23) goto L_001A;\n\tv32 = UnityEngine.Random::Range(0f, 6.2831855f);\nL_001A:\n\tthis._startPhase = v32;\n\treturn;\n")]
		private void OnEnable()
		{
			_time = 0f;
			bool flag = !m_randomizeStartPhase;
			float startPhase = 0f;
			if (!flag)
			{
				startPhase = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
			}
			_startPhase = startPhase;
		}

		[Token(Token = "0x600075B")]
		[Address(RVA = "0x3E67DA4", Offset = "0x3E67DA4", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv77 = v71.Count == 0;\n\tif (v77) goto L_012F;\n\tv206 = this.m_intensity == 0;\n\tv238 = this.m_intensity < 0;\n\tv201 = ~v238;\n\tv239 = ~v201;\n\tv186 = v239 | v206;\n\tif (v186) goto L_012F;\n\tv314 = this.m_useUnscaledTime == 0;\n\tif (v314) goto L_0041;\n\tv368 = UnityEngine.Time::get_unscaledDeltaTime();\n\tgoto L_0042;\nL_0041:\n\tv368 = UnityEngine.Time::get_deltaTime();\nL_0042:\n\tv216 = this._time + v368;\n\tthis._time = v216;\n\tv287 = this.m_bones;\n\tv377 = this.m_baseFrequency * 0x40C90FDB;\nL_FFFFFFFF:\n\tv233 = 0;\n\tgoto L_0069;\nL_005B:\n\tv233 = v233 + 1;\n\tv287 = this.m_bones;\nL_0069:\n\tv188 = v233 >= v287.Count;\n\tif (v188) goto L_012F;\n\tv395 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeJellyIdle+JellyBone>::get_Item(v287, v233);\n\tv396 = v395 == 0;\n\tif (v396) goto L_005B;\n\tgoto L_0079;\nL_0079:\n\tv222 = UnityEngine.Object::op_Equality(v395.target, 0);\n\tv444 = v222 == 0;\n\tv439 = ~v444;\n\tif (v439) goto L_005B;\n\tgoto L_008F;\nL_008F:\n\tv452 = v377 * v395.frequencyMultiplier;\n\tv455 = v452 * this._time;\n\tv456 = this._startPhase + v395.phaseOffset;\n\tv457 = v455 + v456;\n\tv459 = v457 + 0x3F666666;\n\tv460 = 0x8BF749C(v222, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v459, v456, this._time, this._startPhase, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv463 = v457 + 0x3FD9999A;\n\tv464 = 0x8BF749C(v460, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v463, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv466 = 0x8BF749C(v464, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v457, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv470 = UnityEngine.Transform::get_localPosition(v395.target);\n\tv476 = v395.positionAmplitude * v457;\n\tv477 = this.m_intensity * v476;\n\tv478 = v395.positionAmplitude.y * v463;\n\tv479 = this.m_intensity * v478;\n\tv480 = v395.positionAmplitude.z * v459;\n\tv481 = this.m_intensity * v480;\n\tv482 = v470 + v477;\n\tv483 = v470.y + v479;\n\tv484 = v470.z + v481;\n\t// 179 MakeStruct v411 @ AGG3E67FAC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v482 @ V0_v18 (System.Single), v483 @ V1_v8 (System.Single), v484 @ V2_v7 (System.Single)\n\tUnityEngine.Transform::set_localPosition(v395.target, v411);\n\tv489 = UnityEngine.Transform::get_localRotation(v395.target);\n\tv496 = v457 * v395.rotationAmplitude;\n\tv497 = this.m_intensity * v496;\n\tv498 = v463 * v395.rotationAmplitude.y;\n\tv499 = this.m_intensity * v498;\n\tv500 = v459 * v395.rotationAmplitude.z;\n\tv501 = this.m_intensity * v500;\n\tv503 = v497 * 0x3C8EFA35;\n\tv504 = v499 * 0x3C8EFA35;\n\tv505 = v501 * 0x3C8EFA35;\n\t// 205 MakeStruct v406 @ AGG3E68000_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v503 @ V0_v23 (System.Single), v504 @ V1_v13 (System.Single), v505 @ V2_v12 (System.Single)\n\tv507 = UnityEngine.Quaternion::Internal_FromEulerRad(v406);\n\tv511 = v489.w * v507;\n\tv512 = v489 * v507.w;\n\tv513 = v511 + v512;\n\tv514 = v489.y * v507.z;\n\tv515 = v514 + v513;\n\tv516 = v489.z * v507.y;\n\tv413 = v515 - v516;\n\tv517 = v489.w * v507.y;\n\tv518 = v489.y * v507.w;\n\tv519 = v517 + v518;\n\tv520 = v489.z * v507;\n\tv521 = v520 + v519;\n\tv522 = v489 * v507.z;\n\tv412 = v521 - v522;\n\tv523 = v489.w * v507.z;\n\tv524 = v489.z * v507.w;\n\tv525 = v523 + v524;\n\tv526 = v489 * v507.y;\n\tv527 = v526 + v525;\n\tv404 = v489.y * v507;\n\tv405 = v527 - v404;\n\tv528 = v489.w * v507.w;\n\tv529 = v489 * v507;\n\tv530 = v528 - v529;\n\tv531 = v489.y * v507.y;\n\tv532 = v530 - v531;\n\tv533 = v489.z * v507.z;\n\tv416 = v532 - v533;\n\t// 243 MakeStruct v403 @ AGG3E68088_1_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v413 @ V4_v10 (System.Single), v412 @ V5_v13 (System.Single), v405 @ V6_v10 (System.Single), v416 @ V3_v12 (System.Single)\n\tUnityEngine.Transform::set_localRotation(v395.target, v403);\n\tv540 = v457 * v395.scaleAmplitude;\n\tv541 = this.m_intensity * v540;\n\tv426 = v541 + 1f;\n\tv543 = 1f / v426;\n\tv432 = v426 < 0x3C23D70A;\n\tv431 = v426 == 0x3C23D70A;\n\tv546 = v426 == v426;\n\tv428 = ~v546;\n\tv547 = v432 == v428;\n\tv402 = ~v431;\n\tv427 = v547 & v402;\n\tv401 = ~v427;\n\tif (v401) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv415 = v543;\n\tgoto L_010F;\nL_FFFFFFFF:\n\tv415 = 1f;\nL_012F:\n\treturn;\nL_0028:\n\tv71 = this.m_bones;\nL_010F:\n\tv552 = UnityEngine.Transform::get_localScale(v395.target);\n\tv433 = v552 * v426;\n\tv425 = v552.y * v415;\n\tv417 = v552.z * v426;\n\t// 279 MakeStruct v400 @ AGG3E680D0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v433 @ V0_v34 (System.Single), v425 @ V1_v20 (System.Single), v417 @ V2_v17 (System.Single)\n\tUnityEngine.Transform::set_localScale(v395.target, v400);\n\tgoto L_005B;\n")]
		private void LateUpdate()
		{
			List<JellyBone> bones = m_bones;
			if (bones.Count == 0)
			{
				return;
			}
			bool flag = m_intensity == 0f;
			bool flag2 = m_intensity < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (flag4 || flag)
			{
				return;
			}
			float num = ((!m_useUnscaledTime) ? Time.deltaTime : Time.unscaledDeltaTime);
			float time = _time + num;
			_time = time;
			List<JellyBone> bones2 = m_bones;
			float num2 = m_baseFrequency * ((float)Math.PI * 2f);
			int num3 = 0;
			Vector3 localPosition2 = default(Vector3);
			Vector3 vector = default(Vector3);
			Quaternion localRotation2 = default(Quaternion);
			Vector3 localScale2 = default(Vector3);
			while (num3 < bones2.Count)
			{
				JellyBone jellyBone = bones2[num3];
				if (jellyBone != null && !(jellyBone.target == null))
				{
					float num4 = num2 * jellyBone.frequencyMultiplier;
					float num5 = num4 * _time;
					float num6 = _startPhase + jellyBone.phaseOffset;
					float num7 = num5 + num6;
					float num8 = num7 + 0.9f;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num9 = num7 + 1.7f;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					Vector3 localPosition = jellyBone.target.localPosition;
					float num10 = jellyBone.positionAmplitude.x * num7;
					float num11 = m_intensity * num10;
					float num12 = jellyBone.positionAmplitude.y * num9;
					float num13 = m_intensity * num12;
					float num14 = jellyBone.positionAmplitude.z * num8;
					float num15 = m_intensity * num14;
					float x = localPosition.x + num11;
					float y = localPosition.y + num13;
					float z = localPosition.z + num15;
					localPosition2.x = x;
					localPosition2.y = y;
					localPosition2.z = z;
					jellyBone.target.localPosition = localPosition2;
					Quaternion localRotation = jellyBone.target.localRotation;
					float num16 = num7 * jellyBone.rotationAmplitude.x;
					float num17 = m_intensity * num16;
					float num18 = num9 * jellyBone.rotationAmplitude.y;
					float num19 = m_intensity * num18;
					float num20 = num8 * jellyBone.rotationAmplitude.z;
					float num21 = m_intensity * num20;
					float x2 = num17 * ((float)Math.PI / 180f);
					float y2 = num19 * ((float)Math.PI / 180f);
					float z2 = num21 * ((float)Math.PI / 180f);
					vector.x = x2;
					vector.y = y2;
					vector.z = z2;
					Quaternion quaternion = Quaternion.Euler(vector * 57.29578f);
					float num22 = localRotation.w * quaternion.x;
					float num23 = localRotation.x * quaternion.w;
					float num24 = num22 + num23;
					float num25 = localRotation.y * quaternion.z;
					float num26 = num25 + num24;
					float num27 = localRotation.z * quaternion.y;
					float x3 = num26 - num27;
					float num28 = localRotation.w * quaternion.y;
					float num29 = localRotation.y * quaternion.w;
					float num30 = num28 + num29;
					float num31 = localRotation.z * quaternion.x;
					float num32 = num31 + num30;
					float num33 = localRotation.x * quaternion.z;
					float y3 = num32 - num33;
					float num34 = localRotation.w * quaternion.z;
					float num35 = localRotation.z * quaternion.w;
					float num36 = num34 + num35;
					float num37 = localRotation.x * quaternion.y;
					float num38 = num37 + num36;
					float num39 = localRotation.y * quaternion.x;
					float z3 = num38 - num39;
					float num40 = localRotation.w * quaternion.w;
					float num41 = localRotation.x * quaternion.x;
					float num42 = num40 - num41;
					float num43 = localRotation.y * quaternion.y;
					float num44 = num42 - num43;
					float num45 = localRotation.z * quaternion.z;
					float w = num44 - num45;
					localRotation2.x = x3;
					localRotation2.y = y3;
					localRotation2.z = z3;
					localRotation2.w = w;
					jellyBone.target.localRotation = localRotation2;
					float num46 = num7 * jellyBone.scaleAmplitude;
					float num47 = m_intensity * num46;
					float num48 = num47 + 1f;
					float num49 = 1f / num48;
					bool flag5 = num48 < 0.01f;
					bool flag6 = num48 == 0.01f;
					bool flag7 = num48 == num48;
					bool flag8 = !flag7;
					bool flag9 = flag5 == flag8;
					bool flag10 = !flag6;
					float num50 = ((!(flag9 && flag10)) ? 1f : num49);
					Vector3 localScale = jellyBone.target.localScale;
					float x4 = localScale.x * num48;
					float y4 = localScale.y * num50;
					float z4 = localScale.z * num48;
					localScale2.x = x4;
					localScale2.y = y4;
					localScale2.z = z4;
					jellyBone.target.localScale = localScale2;
				}
				num3++;
				bones2 = m_bones;
			}
		}

		[Token(Token = "0x600075C")]
		[Address(RVA = "0x3E6810C", Offset = "0x3E6810C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tthis.m_baseFrequency = 0.007812501836451703d;\n\tthis.m_randomizeStartPhase = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeJellyIdle+JellyBone>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeJellyIdle+JellyBone>::.ctor(v48);\n\tthis.m_bones = v48;\n")]
		public SandCubeJellyIdle()
		{
			List<JellyBone> bones = new List<JellyBone>();
			m_bones = bones;
			m_baseFrequency = 0.6f;
			m_intensity = 1f;
			m_randomizeStartPhase = true;
		}
	}
}
