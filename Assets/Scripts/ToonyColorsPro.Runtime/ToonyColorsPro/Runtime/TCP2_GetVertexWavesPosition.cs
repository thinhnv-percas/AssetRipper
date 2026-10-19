using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ToonyColorsPro.Runtime
{
	[Token(Token = "0x2000006")]
	public class TCP2_GetVertexWavesPosition : MonoBehaviour
	{
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x20")]
		public Transform WaterPlane;

		[Space]
		[Tooltip("Will make the object stick to the water plane")]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x28")]
		public bool followWaterHeight;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x2C")]
		public float heightOffset;

		[Space]
		[Tooltip("Will align the object to the wave normal based on its position")]
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x30")]
		public bool followWaterNormal;

		[Tooltip("Determine the object's up axis (when following wave normal)")]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x34")]
		public Vector3 upAxis;

		[Tooltip("Rotation of the object once it's been affected by the water normal")]
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x40")]
		public Vector3 postRotation;

		[Header("Water Shader Configuration")]
		[Space]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x4C")]
		public int sineCount;

		[Space]
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x50")]
		public float WavesSpeed;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x54")]
		public float WavesHeight;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x58")]
		public float WavesFrequency;

		[Space]
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x5C")]
		public bool useCustomTime;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x5D")]
		public bool customSineValues;

		[HideInInspector]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x60")]
		public Vector4 sinOffsets1;

		[HideInInspector]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x70")]
		public Vector4 phaseOffsets1;

		[HideInInspector]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x80")]
		public Vector4 sinOffsets2;

		[HideInInspector]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x90")]
		public Vector4 phaseOffsets2;

		[HideInInspector]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0xA0")]
		public Vector4 sinOffsets3;

		[HideInInspector]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0xB0")]
		public Vector4 phaseOffsets3;

		[HideInInspector]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0xC0")]
		public Vector4 sinOffsets4;

		[HideInInspector]
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0xD0")]
		public Vector4 phaseOffsets4;

		[Token(Token = "0x4000028")]
		private static readonly int _Time;

		[Token(Token = "0x4000029")]
		private static int LastFrameTimeSampling;

		[Token(Token = "0x400002A")]
		private static float ShaderTime;

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81979DC", Offset = "0x81979DC", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv62 = UnityEngine.Time::get_time();\n\tv75 = this.followWaterHeight == 1;\n\tv230 = v62;\n\tv166 = v62;\n\tif (v75) goto L_00D9;\nL_003C:\n\tv150 = this.followWaterNormal != 1;\n\tif (v150) goto L_0110;\nL_0040:\n\tv242 = UnityEngine.Component::get_transform(this);\n\tv302 = UnityEngine.Component::get_transform(this);\n\tv439 = UnityEngine.Transform::get_position(v302);\n\tv451 = ToonyColorsPro.Runtime.TCP2_GetVertexWavesPosition::GetNormalOnWater_SG2(this, v230, v439);\n\t// 97 MakeStruct v330 @ AGG8197AB8_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.upAxis (UnityEngine.Vector3), this.upAxis.y (System.Single), this.upAxis.z (System.Single)\n\tv412 = UnityEngine.Quaternion::FromToRotation(v330, v451);\n\tUnityEngine.Transform::set_rotation(v242, v412);\n\tv389 = UnityEngine.Component::get_transform(this);\n\t// 130 MakeStruct v310 @ AGG8197B00_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.postRotation (UnityEngine.Vector3), this.postRotation.y (System.Single), this.postRotation.z (System.Single)\n\tUnityEngine.Transform::Rotate(v389, v310, 1);\n\treturn;\nL_008B:\n\tgoto L_0091;\n\tgoto L_00A8;\nL_00B9:\n\tv230 = v423.ShaderTime;\n\tv100 = this.followWaterHeight != 1;\n\tif (v100) goto L_003C;\n\tv166 = v423.ShaderTime;\n\tgoto L_00D9;\nL_00D9:\n\tv174 = UnityEngine.Component::get_transform(this);\n\tv404 = UnityEngine.Transform::get_position(v174);\n\tv413 = ToonyColorsPro.Runtime.TCP2_GetVertexWavesPosition::GetPositionOnWater_SG2(this, v166, v404);\n\tv234 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::set_position(v234, v413);\n\tv223 = this.followWaterNormal == 1;\n\tv230 = v166;\n\tif (v223) goto L_0040;\nL_0110:\n\treturn;\nL_0022:\n\tv60 = this.useCustomTime != 1;\n\tif (v60) goto L_008B;\nL_0091:\n\tv86 = UnityEngine.Time::get_frameCount();\n\tv186 = v83.LastFrameTimeSampling >= v86;\n\tif (v186) goto L_00B7;\nL_00B7:\n\tgoto L_00B9;\nL_00A8:\n\tv290 = UnityEngine.Shader::GetGlobalVector(v421._Time);\n\tv434.ShaderTime = v290.y;\n\tv436 = UnityEngine.Time::get_frameCount();\n\tv285.LastFrameTimeSampling = v436;\n")]
		private void LateUpdate()
		{
			float time2;
			float num;
			if (useCustomTime)
			{
				float time = Time.time;
				bool flag = followWaterHeight;
				time2 = time;
				num = time;
				if (!flag)
				{
					goto IL_003d;
				}
			}
			else
			{
				int frameCount = Time.frameCount;
				if (LastFrameTimeSampling < frameCount)
				{
					ShaderTime = Shader.GetGlobalVector(_Time).y;
					int frameCount2 = Time.frameCount;
					LastFrameTimeSampling = frameCount2;
				}
				time2 = ShaderTime;
				if (!followWaterHeight)
				{
					goto IL_003d;
				}
				num = ShaderTime;
			}
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 positionOnWater_SG = GetPositionOnWater_SG2(num, position);
			Transform transform2 = base.transform;
			transform2.position = positionOnWater_SG;
			bool flag2 = followWaterNormal;
			time2 = num;
			if (!flag2)
			{
				return;
			}
			goto IL_005f;
			IL_005f:
			Transform transform3 = base.transform;
			Transform transform4 = base.transform;
			Vector3 position2 = transform4.position;
			Vector3 normalOnWater_SG = GetNormalOnWater_SG2(time2, position2);
			Vector3 fromDirection = default(Vector3);
			fromDirection.x = upAxis.x;
			fromDirection.y = upAxis.y;
			fromDirection.z = upAxis.z;
			Quaternion rotation = Quaternion.FromToRotation(fromDirection, normalOnWater_SG);
			transform3.rotation = rotation;
			Transform transform5 = base.transform;
			Vector3 eulers = default(Vector3);
			eulers.x = postRotation.x;
			eulers.y = postRotation.y;
			eulers.z = postRotation.z;
			transform5.Rotate(eulers, Space.Self);
			return;
			IL_003d:
			if (followWaterNormal)
			{
				goto IL_005f;
			}
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x819871C", Offset = "0x819871C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv44 = sinOffsets * v1;\n\tv45 = phaseOffsets * *([phase @ X1 (System.Single&)]);\n\tv46 = v44 + v45;\n\tv47 = 0x8BF749C(this, phase, methodInfo, v50, v51, v52, v53, v54, v46, v44, sinOffsets, sinOffsets.y, sinOffsets.z, sinOffsets.w, v55, v56);\n\tv58 = sinOffsets.y * v1;\n\tv59 = v37 * *([phase @ X1 (System.Single&)]);\n\tv60 = v58 + v59;\n\tv61 = 0x8BF749C(v47, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v60, v59, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv63 = sinOffsets.z * v2;\n\tv64 = v39 * *([phase @ X1 (System.Single&)]);\n\tv65 = v63 + v64;\n\tv66 = 0x8BF749C(v61, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v65, v64, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv70 = sinOffsets.w * v2;\n\tv71 = v34 * *([phase @ X1 (System.Single&)]);\n\tv72 = v70 + v71;\n\tv73 = 0x8BF749C(v66, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v72, v71, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v46;\n")]
		private Vector4 CalculateSinePosition(float v1, float v2, Vector4 sinOffsets, Vector4 phaseOffsets, ref float phase)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_GetVertexWavesPosition::CalculateSinePosition");
			return default;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81987DC", Offset = "0x81987DC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv45 = sinOffsets * v1;\n\tv46 = phaseOffsets * *([phase @ X1 (System.Single&)]);\n\tv47 = v45 + v46;\n\tv48 = 0x8BF608C(this, phase, methodInfo, v51, v52, v53, v54, v55, v47, v45, sinOffsets, sinOffsets.y, sinOffsets.z, sinOffsets.w, v56, v57);\n\tv59 = sinOffsets.y * v1;\n\tv60 = v38 * *([phase @ X1 (System.Single&)]);\n\tv61 = v59 + v60;\n\tv62 = 0x8BF608C(v48, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v61, v60, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv64 = sinOffsets.z * v2;\n\tv65 = v40 * *([phase @ X1 (System.Single&)]);\n\tv66 = v64 + v65;\n\tv67 = 0x8BF608C(v62, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v66, v65, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv71 = sinOffsets.w * v2;\n\tv72 = v35 * *([phase @ X1 (System.Single&)]);\n\tv73 = v71 + v72;\n\tv74 = 0x8BF608C(v67, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v73, v72, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv76 = sinOffsets * v47;\n\treturn v76;\n")]
		private Vector4 CalculateSineNormal(float v1, float v2, Vector4 sinOffsets, Vector4 phaseOffsets, ref float phase)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_GetVertexWavesPosition::CalculateSineNormal");
			return default;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x8197C54", Offset = "0x8197C54", Length = "0x4C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv41 = UnityEngine.Component::get_transform(this.WaterPlane);\n\tv142 = this.WavesSpeed * time;\n\tv173 = worldPosition * this.WavesFrequency;\n\tv144 = worldPosition.z * this.WavesFrequency;\n\tv174 = UnityEngine.Transform::get_lossyScale(v41);\n\tv253 = this.sineCount > 3;\n\tif (v253) goto L_007D;\n\tv258 = this.sineCount == 1;\n\tif (v258) goto L_0128;\n\tv282 = this.sineCount != 2;\n\tv150 = worldPosition;\n\tif (v282) goto L_0182;\n\tv326 = v173 * this.sinOffsets1;\n\tv327 = v142 * this.phaseOffsets1;\n\tv328 = v326 + v327;\n\tv329 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v328, v327, this.phaseOffsets1.w, this.sinOffsets1.w, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv395 = v173 * this.sinOffsets1.y;\n\tv396 = v142 * this.phaseOffsets1.y;\n\tv398 = v395 + v396;\n\tv399 = 0x8BF749C(v329, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v398, v396, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv412 = v144 * this.sinOffsets1.z;\n\tv413 = v142 * this.phaseOffsets1.z;\n\tv415 = v412 + v413;\n\tv416 = 0x8BF749C(v399, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v415, v413, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv431 = v144 * this.sinOffsets1.w;\n\tv432 = v142 * this.phaseOffsets1.w;\n\tv433 = v431 + v432;\n\tv434 = 0x8BF749C(v416, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v433, v432, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = worldPosition;\n\tgoto L_0182;\nL_007D:\n\tv267 = this.sineCount == 4;\n\tif (v267) goto L_013B;\n\tv295 = this.sineCount != 8;\n\tv150 = worldPosition;\n\tif (v295) goto L_0182;\n\tv385 = v173 * this.sinOffsets1;\n\tv386 = v142 * this.phaseOffsets1;\n\tv387 = v385 + v386;\n\tv388 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v387, v386, v174.z, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv401 = v173 * this.sinOffsets1.y;\n\tv402 = v142 * this.phaseOffsets1.y;\n\tv403 = v401 + v402;\n\tv404 = 0x8BF749C(v388, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v403, v402, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv418 = v173 * this.sinOffsets1.z;\n\tv419 = v142 * this.phaseOffsets1.z;\n\tv420 = v418 + v419;\n\tv421 = 0x8BF749C(v404, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v420, v419, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv438 = v173 * this.sinOffsets1.w;\n\tv439 = v142 * this.phaseOffsets1.w;\n\tv440 = v438 + v439;\n\tv441 = 0x8BF749C(v421, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v440, v439, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv477 = v144 * this.sinOffsets2;\n\tv478 = v142 * this.phaseOffsets2;\n\tv479 = v477 + v478;\n\tv480 = 0x8BF749C(v441, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v479, v478, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv527 = v144 * this.sinOffsets2.y;\n\tv528 = v142 * this.phaseOffsets2.y;\n\tv529 = v527 + v528;\n\tv530 = 0x8BF749C(v480, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v529, v528, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv537 = v144 * this.sinOffsets2.z;\n\tv538 = v142 * this.phaseOffsets2.z;\n\tv539 = v537 + v538;\n\tv540 = 0x8BF749C(v530, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v539, v538, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv549 = v144 * this.sinOffsets2.w;\n\tv550 = v142 * this.phaseOffsets2.w;\n\tv551 = v549 + v550;\n\tv552 = 0x8BF749C(v540, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v551, v550, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv578 = v173 * this.sinOffsets3;\n\tv579 = v142 * this.phaseOffsets3;\n\tv580 = v578 + v579;\n\tv581 = 0x8BF749C(v552, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v580, v579, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv601 = v173 * this.sinOffsets3.y;\n\tv602 = v142 * this.phaseOffsets3.y;\n\tv603 = v601 + v602;\n\tv604 = 0x8BF749C(v581, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v603, v602, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv605 = v173 * this.sinOffsets3.z;\n\tv606 = v142 * this.phaseOffsets3.z;\n\tv607 = v605 + v606;\n\tv608 = 0x8BF749C(v604, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v607, v606, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv610 = v173 * this.sinOffsets3.w;\n\tv611 = v142 * this.phaseOffsets3.w;\n\tv612 = v610 + v611;\n\tv613 = 0x8BF749C(v608, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v612, v611, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv621 = v144 * this.sinOffsets4;\n\tv622 = v142 * this.phaseOffsets4;\n\tv623 = v621 + v622;\n\tv624 = 0x8BF749C(v613, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v623, v622, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv625 = v144 * this.sinOffsets4.y;\n\tv626 = v142 * this.phaseOffsets4.y;\n\tv627 = v625 + v626;\n\tv628 = 0x8BF749C(v624, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v627, v626, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv629 = v144 * this.sinOffsets4.z;\n\tv630 = v142 * this.phaseOffsets4.z;\n\tv631 = v629 + v630;\n\tv632 = 0x8BF749C(v628, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v631, v630, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv633 = v144 * this.sinOffsets4.w;\n\tv634 = v142 * this.phaseOffsets4.w;\n\tv592 = v633 + v634;\n\tv598 = 0x8BF749C(v632, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v592, v634, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = worldPosition;\n\tgoto L_0182;\nL_0128:\n\tv283 = v142 + v173;\n\tv284 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v283, v174.y, v174.z, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv361 = v142 + v144;\n\tv370 = 0x8BF749C(v284, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v361, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = worldPosition;\n\tgoto L_0182;\nL_013B:\n\tv308 = v173 * this.sinOffsets1;\n\tv309 = v142 * this.phaseOffsets1;\n\tv310 = v308 + v309;\n\tv311 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v310, v309, v174.z, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv390 = v173 * this.sinOffsets1.y;\n\tv391 = v142 * this.phaseOffsets1.y;\n\tv392 = v390 + v391;\n\tv393 = 0x8BF749C(v311, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v392, v391, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv406 = v173 * this.sinOffsets1.z;\n\tv407 = v142 * this.phaseOffsets1.z;\n\n// ... truncated")]
		public Vector3 GetPositionOnWater_SG2(float time, Vector3 worldPosition)
		{
			Transform transform = WaterPlane.transform;
			float num = WavesSpeed * time;
			float num2 = worldPosition.x * WavesFrequency;
			float num3 = worldPosition.z * WavesFrequency;
			Vector3 lossyScale = transform.lossyScale;
			Vector3 result;
			if (sineCount <= 3)
			{
				if (sineCount != 1)
				{
					bool flag = sineCount != 2;
					result = worldPosition;
					if (!flag)
					{
						float num4 = num2 * sinOffsets1.x;
						float num5 = num * phaseOffsets1.x;
						float num6 = num4 + num5;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						float num7 = num2 * sinOffsets1.y;
						float num8 = num * phaseOffsets1.y;
						float num9 = num7 + num8;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						float num10 = num3 * sinOffsets1.z;
						float num11 = num * phaseOffsets1.z;
						float num12 = num10 + num11;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						float num13 = num3 * sinOffsets1.w;
						float num14 = num * phaseOffsets1.w;
						float num15 = num13 + num14;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						result = worldPosition;
					}
				}
				else
				{
					float num16 = num + num2;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num17 = num + num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					result = worldPosition;
				}
			}
			else if (sineCount != 4)
			{
				bool flag2 = sineCount != 8;
				result = worldPosition;
				if (!flag2)
				{
					float num18 = num2 * sinOffsets1.x;
					float num19 = num * phaseOffsets1.x;
					float num20 = num18 + num19;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num21 = num2 * sinOffsets1.y;
					float num22 = num * phaseOffsets1.y;
					float num23 = num21 + num22;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num24 = num2 * sinOffsets1.z;
					float num25 = num * phaseOffsets1.z;
					float num26 = num24 + num25;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num27 = num2 * sinOffsets1.w;
					float num28 = num * phaseOffsets1.w;
					float num29 = num27 + num28;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num30 = num3 * sinOffsets2.x;
					float num31 = num * phaseOffsets2.x;
					float num32 = num30 + num31;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num33 = num3 * sinOffsets2.y;
					float num34 = num * phaseOffsets2.y;
					float num35 = num33 + num34;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num36 = num3 * sinOffsets2.z;
					float num37 = num * phaseOffsets2.z;
					float num38 = num36 + num37;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num39 = num3 * sinOffsets2.w;
					float num40 = num * phaseOffsets2.w;
					float num41 = num39 + num40;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num42 = num2 * sinOffsets3.x;
					float num43 = num * phaseOffsets3.x;
					float num44 = num42 + num43;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num45 = num2 * sinOffsets3.y;
					float num46 = num * phaseOffsets3.y;
					float num47 = num45 + num46;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num48 = num2 * sinOffsets3.z;
					float num49 = num * phaseOffsets3.z;
					float num50 = num48 + num49;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num51 = num2 * sinOffsets3.w;
					float num52 = num * phaseOffsets3.w;
					float num53 = num51 + num52;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num54 = num3 * sinOffsets4.x;
					float num55 = num * phaseOffsets4.x;
					float num56 = num54 + num55;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num57 = num3 * sinOffsets4.y;
					float num58 = num * phaseOffsets4.y;
					float num59 = num57 + num58;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num60 = num3 * sinOffsets4.z;
					float num61 = num * phaseOffsets4.z;
					float num62 = num60 + num61;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num63 = num3 * sinOffsets4.w;
					float num64 = num * phaseOffsets4.w;
					float num65 = num63 + num64;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					result = worldPosition;
				}
			}
			else
			{
				float num66 = num2 * sinOffsets1.x;
				float num67 = num * phaseOffsets1.x;
				float num68 = num66 + num67;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num69 = num2 * sinOffsets1.y;
				float num70 = num * phaseOffsets1.y;
				float num71 = num69 + num70;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num72 = num2 * sinOffsets1.z;
				float num73 = num * phaseOffsets1.z;
				float num74 = num72 + num73;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num75 = num2 * sinOffsets1.w;
				float num76 = num * phaseOffsets1.w;
				float num77 = num75 + num76;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num78 = num3 * sinOffsets2.x;
				float num79 = num * phaseOffsets2.x;
				float num80 = num78 + num79;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num81 = num3 * sinOffsets2.y;
				float num82 = num * phaseOffsets2.y;
				float num83 = num81 + num82;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num84 = num3 * sinOffsets2.z;
				float num85 = num * phaseOffsets2.z;
				float num86 = num84 + num85;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num87 = num3 * sinOffsets2.w;
				float num88 = num * phaseOffsets2.w;
				float num89 = num87 + num88;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				result = worldPosition;
			}
			Transform transform2 = WaterPlane.transform;
			Vector3 position = transform2.position;
			return result;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x819811C", Offset = "0x819811C", Length = "0x600")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = UnityEngine.Component::get_transform(this.WaterPlane);\n\tv60 = this.WavesSpeed * time;\n\tv62 = worldPosition * this.WavesFrequency;\n\tv64 = worldPosition.z * this.WavesFrequency;\n\tv67 = UnityEngine.Transform::get_lossyScale(v37);\n\tv173 = this.WavesHeight * v67.y;\n\tv186 = this.sineCount > 3;\n\tif (v186) goto L_007C;\n\tv191 = this.sineCount == 1;\n\tif (v191) goto L_0136;\n\tv215 = this.sineCount != 2;\n\tv294 = 0;\n\tv298 = 0;\n\tif (v215) goto L_019E;\n\tv246 = this.sinOffsets1 * v235;\n\tv248 = this.phaseOffsets1 * v238;\n\tv249 = v246 + v248;\n\tv252 = 0x8BF608C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v96, v246, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv334 = 0x8BF608C(v252, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v249, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv365 = this.sinOffsets1 * v249;\n\tv370 = this.sinOffsets1.z * v235;\n\tv371 = this.phaseOffsets1.z * v238;\n\tv372 = v370 + v371;\n\tv374 = 0x8BF608C(v334, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v235, v370, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv304 = 0x8BF608C(v374, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v372, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv426 = this.sinOffsets1.z * v372;\n\t// 110 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv428 = v173 * v365;\n\tv282 = -v428;\n\tv298 = v282 * 0.5f;\n\t// 115 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv429 = v173 * v426;\n\tv292 = -v429;\n\tv294 = v292 * 0.5f;\n\tgoto L_019E;\nL_007C:\n\tv200 = this.sineCount == 4;\n\tif (v200) goto L_0144;\n\tv230 = this.sineCount != 8;\n\tv294 = 0;\n\tv298 = 0;\n\tif (v230) goto L_019E;\n\tv322 = this.sinOffsets1 * v235;\n\tv324 = this.phaseOffsets1 * v238;\n\tv325 = v322 + v324;\n\tv328 = 0x8BF608C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v96, v322, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv348 = 0x8BF608C(v328, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v325, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv386 = this.sinOffsets1 * v325;\n\tv390 = this.sinOffsets1.z * v235;\n\tv392 = this.phaseOffsets1.z * v238;\n\tv393 = v390 + v392;\n\tv396 = 0x8BF608C(v348, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v238, v390, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv410 = 0x8BF608C(v396, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v393, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv442 = this.sinOffsets1.z * v393;\n\tv448 = this.sinOffsets2 * v235;\n\tv449 = this.phaseOffsets2 * v238;\n\tv450 = v448 + v449;\n\tv453 = 0x8BF608C(v410, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v235, v448, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv472 = 0x8BF608C(v453, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v450, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv489 = this.sinOffsets2 * v450;\n\tv495 = this.sinOffsets2.z * v235;\n\tv496 = this.phaseOffsets2.z * v238;\n\tv497 = v495 + v496;\n\tv500 = 0x8BF608C(v472, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v235, v495, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv506 = 0x8BF608C(v500, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v497, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv523 = this.sinOffsets2.z * v497;\n\tv528 = this.sinOffsets3 * v235;\n\tv530 = this.phaseOffsets3 * v238;\n\tv531 = v528 + v530;\n\tv534 = 0x8BF608C(v506, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v235, v528, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv555 = 0x8BF608C(v534, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v531, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv558 = this.sinOffsets3 * v531;\n\tv562 = this.sinOffsets3.z * v235;\n\tv564 = this.phaseOffsets3.z * v238;\n\tv565 = v562 + v564;\n\tv568 = 0x8BF608C(v555, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v235, v562, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv571 = 0x8BF608C(v568, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v565, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv574 = this.sinOffsets3.z * v565;\n\tv579 = this.sinOffsets4 * v235;\n\tv580 = this.phaseOffsets4 * v238;\n\tv581 = v579 + v580;\n\tv583 = 0x8BF608C(v571, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v235, v579, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv586 = 0x8BF608C(v583, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v581, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv589 = this.sinOffsets4 * v581;\n\tv594 = this.sinOffsets4.z * v235;\n\tv595 = this.phaseOffsets4.z * v238;\n\tv596 = v594 + v595;\n\tv598 = 0x8BF608C(v586, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v235, v594, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv549 = 0x8BF608C(v598, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v596, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv546 = this.sinOffsets4.z * v596;\n\t// 279 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv603 = v386 + v235;\n\tv604 = v603 + v442;\n\t// 282 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv605 = v604 + v442;\n\tv607 = v605 + v558;\n\t// 287 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv608 = v607 + v558;\n\tv610 = v608 + v574;\n\t// 291 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv611 = v610 + v574;\n\tv308 = -v173;\n\tv612 = v308 * v611;\n\tv298 = v612 * 0.125f;\n\t// 298 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv614 = v489 + v612;\n\t// 300 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv615 = v614 + v523;\n\tv616 = v615 + v489;\n\tv617 = v616 + v589;\n\t// 305 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv541 = v617 + v589;\n\tv306 = 0.125f;\n\tgoto L_0192;\nL_0136:\n\tv218 = v60 + v62;\n\tv219 = 0x8BF608C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v218, v60, v67.z, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv317 = v173 * v218;\n\tv298 = -v317;\n\tv293 = v60 + v64;\n\tv305 = 0x8BF608C(v219, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v293, v60, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv345 = v173 * v293;\n\tv294 = -v345;\n\tgoto L_019E;\nL_0144:\n\tv234 = this.sinOffsets1 * v235;\n\tv237 = this.phaseOffsets1 * v238;\n\tv239 = v234 + v237;\n\tv242 = 0x8BF608C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v96, v234, v60, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_\n// ... truncated")]
		public Vector3 GetNormalOnWater_SG2(float time, Vector3 worldPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_GetVertexWavesPosition::GetNormalOnWater_SG2");
			return default;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x81988A8", Offset = "0x81988A8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.followWaterHeight = 1;\n\tthis.upAxis = 0.0078125d;\n\tthis.postRotation.y = 0f;\n\tthis.upAxis.z = 0f;\n\tthis.sineCount = 1;\n\tthis.WavesSpeed = 5.2386907312129694E-11d;\n\tthis.WavesFrequency = 1f;\n\tthis.sinOffsets1 = *([93B23C0]);\n\tthis.phaseOffsets1 = *([93B23D0]);\n\tthis.sinOffsets2 = *([93B23E0]);\n\tthis.phaseOffsets2 = *([93B23F0]);\n\tthis.sinOffsets3 = *([93B2400]);\n\tthis.phaseOffsets3 = *([93B2410]);\n\tthis.sinOffsets4 = *([93B2420]);\n\tthis.phaseOffsets4 = *([93B2430]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TCP2_GetVertexWavesPosition()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_GetVertexWavesPosition::.ctor");
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x8198934", Offset = "0x8198934", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv48 = UnityEngine.Shader::PropertyToID(\"_Time\");\n\tv52._Time = v48;\n\tv52.ShaderTime = 0f;\n\treturn;\n")]
		static TCP2_GetVertexWavesPosition()
		{
			int time = Shader.PropertyToID("_Time");
			_Time = time;
			ShaderTime = 0f;
		}
	}
}
