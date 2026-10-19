using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ToonyColorsPro.Runtime
{
	[Token(Token = "0x2000005")]
	public class TCP2_GetPosOnWater : MonoBehaviour
	{
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x20")]
		public Material WaterMaterial;

		[Tooltip("Height scale, for example if the water mesh is scaled along its Y axis")]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x28")]
		public float heightScale;

		[Space]
		[Tooltip("Will make the object stick to the water plane")]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x2C")]
		public bool followWaterHeight;

		[Tooltip("Y Position offset")]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x30")]
		public float heightOffset;

		[Space]
		[Tooltip("Will align the object to the wave normal based on its position")]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x34")]
		public bool followWaterNormal;

		[Tooltip("Determine the object's up axis (when following wave normal)")]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x38")]
		public Vector3 upAxis;

		[Tooltip("Rotation of the object once it's been affected by the water normal")]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x44")]
		public Vector3 postRotation;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x50")]
		private bool isValid;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x54")]
		private int sineCount;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x58")]
		private float[] sinePosOffsetsX;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x60")]
		private float[] sinePosOffsetsZ;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x68")]
		private float[] sinePhsOffsetsX;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x70")]
		private float[] sinePhsOffsetsZ;

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x8196620", Offset = "0x8196620", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = this.followWaterHeight != 1;\n\tif (v30) goto L_003E;\n\tv33 = UnityEngine.Component::get_transform(this);\n\tv89 = UnityEngine.Transform::get_position(v33);\n\tv129 = ToonyColorsPro.Runtime.TCP2_GetPosOnWater::GetPositionOnWater(this, v89);\n\tv64 = UnityEngine.Component::get_transform(this);\n\tv52 = v129.y + this.heightOffset;\n\t// 50 MakeStruct v35 @ AGG8196694_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v129 @ V0_v9 (UnityEngine.Vector3), v52 @ V1_v10 (System.Single), v129.z (System.Single)\n\tUnityEngine.Transform::set_position(v64, v35);\nL_003E:\n\tv75 = this.followWaterNormal != 1;\n\tif (v75) goto L_0087;\n\tv79 = UnityEngine.Component::get_transform(this);\n\tv141 = UnityEngine.Component::get_transform(this);\n\tv218 = UnityEngine.Transform::get_position(v141);\n\tv222 = ToonyColorsPro.Runtime.TCP2_GetPosOnWater::GetNormalOnWater(this, v218);\n\t// 92 MakeStruct v98 @ AGG81966F8_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.upAxis (UnityEngine.Vector3), this.upAxis.y (System.Single), this.upAxis.z (System.Single)\n\tv130 = UnityEngine.Quaternion::FromToRotation(v98, v222);\n\tUnityEngine.Transform::set_rotation(v79, v130);\n\tv143 = UnityEngine.Component::get_transform(this);\n\t// 123 MakeStruct v165 @ AGG819673C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.postRotation (UnityEngine.Vector3), this.postRotation.y (System.Single), this.postRotation.z (System.Single)\n\tUnityEngine.Transform::Rotate(v143, v165, 1);\n\treturn;\nL_0087:\n\treturn;\n")]
		private void LateUpdate()
		{
			if (followWaterHeight)
			{
				Transform transform = base.transform;
				Vector3 position = transform.position;
				Vector3 positionOnWater = GetPositionOnWater(position);
				Transform transform2 = base.transform;
				float y = positionOnWater.y + heightOffset;
				Vector3 position2 = default(Vector3);
				position2.x = positionOnWater.x;
				position2.y = y;
				position2.z = positionOnWater.z;
				transform2.position = position2;
			}
			if (followWaterNormal)
			{
				Transform transform3 = base.transform;
				Transform transform4 = base.transform;
				Vector3 position3 = transform4.position;
				Vector3 normalOnWater = GetNormalOnWater(position3);
				Vector3 fromDirection = default(Vector3);
				fromDirection.x = upAxis.x;
				fromDirection.y = upAxis.y;
				fromDirection.z = upAxis.z;
				Quaternion rotation = Quaternion.FromToRotation(fromDirection, normalOnWater);
				transform3.rotation = rotation;
				Transform transform5 = base.transform;
				Vector3 eulers = default(Vector3);
				eulers.x = postRotation.x;
				eulers.y = postRotation.y;
				eulers.z = postRotation.z;
				transform5.Rotate(eulers, Space.Self);
			}
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x8196758", Offset = "0x8196758", Length = "0x7B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\nL_002F:\n\tv74 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveFrequency\");\n\tv244 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveHeight\");\n\tv401 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveSpeed\");\n\tv402 = UnityEngine.Time::get_time();\n\tv227 = v401 * v402;\n\tv225 = worldPosition * v74;\n\tv222 = worldPosition.z * v74;\n\tv147 = this.sineCount > 3;\n\tif (v147) goto L_00DA;\n\tv417 = this.sineCount == 1;\n\tif (v417) goto L_02CB;\n\tv144 = this.sineCount != 2;\n\tv499 = worldPosition;\n\tif (v144) goto L_03CB;\n\tv284 = this.sinePosOffsetsX;\n\tv121 = this.sinePhsOffsetsX;\n\tv917 = v225 * v284[0];\n\tv890 = v227 * v121[0];\n\tv836 = v917 + v890;\n\tv859 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v836, v890, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv932 = v225 * v284[1];\n\tv302 = v227 * v121[1];\n\tv246 = v932 + v302;\n\tv260 = 0x8BF749C(v859, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v246, v302, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv285 = this.sinePosOffsetsZ;\n\tv292 = this.sinePhsOffsetsZ;\n\tv955 = v222 * v285[0];\n\tv891 = v227 * v292[0];\n\tv837 = v955 + v891;\n\tv860 = 0x8BF749C(v260, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v837, v891, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv973 = v222 * v285[1];\n\tv974 = v227 * v292[1];\n\tv975 = v973 + v974;\n\tv491 = 0x8BF749C(v860, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v975, v974, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv499 = worldPosition;\n\tgoto L_03CB;\nL_00DA:\n\tv192 = this.sineCount == 4;\n\tif (v192) goto L_02D3;\n\tv145 = this.sineCount != 8;\n\tv499 = worldPosition;\n\tif (v145) goto L_03CB;\n\tv286 = this.sinePosOffsetsX;\n\tv123 = this.sinePhsOffsetsX;\n\tv920 = v225 * v286[0];\n\tv892 = v227 * v123[0];\n\tv838 = v920 + v892;\n\tv861 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v838, v892, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv935 = v225 * v286[1];\n\tv893 = v227 * v123[1];\n\tv839 = v935 + v893;\n\tv862 = 0x8BF749C(v861, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v839, v893, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv949 = v225 * v286[2];\n\tv894 = v227 * v123[2];\n\tv840 = v949 + v894;\n\tv863 = 0x8BF749C(v862, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v840, v894, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv963 = v225 * v286[3];\n\tv895 = v227 * v123[3];\n\tv841 = v963 + v895;\n\tv864 = 0x8BF749C(v863, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v841, v895, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv982 = v225 * v286[4];\n\tv896 = v227 * v123[4];\n\tv842 = v982 + v896;\n\tv865 = 0x8BF749C(v864, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v842, v896, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv991 = v225 * v286[5];\n\tv897 = v227 * v123[5];\n\tv843 = v991 + v897;\n\tv866 = 0x8BF749C(v865, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v843, v897, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1004 = v225 * v286[6];\n\tv898 = v227 * v123[6];\n\tv844 = v1004 + v898;\n\tv867 = 0x8BF749C(v866, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v844, v898, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1015 = v225 * v286[7];\n\tv303 = v227 * v123[7];\n\tv247 = v1015 + v303;\n\tv261 = 0x8BF749C(v867, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v247, v303, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv287 = this.sinePosOffsetsZ;\n\tv293 = this.sinePhsOffsetsZ;\n\tv1035 = v222 * v287[0];\n\tv899 = v227 * v293[0];\n\tv845 = v1035 + v899;\n\tv868 = 0x8BF749C(v261, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v845, v899, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1040 = v222 * v287[1];\n\tv900 = v227 * v293[1];\n\tv846 = v1040 + v900;\n\tv869 = 0x8BF749C(v868, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v846, v900, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1047 = v222 * v287[2];\n\tv901 = v227 * v293[2];\n\tv847 = v1047 + v901;\n\tv870 = 0x8BF749C(v869, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v847, v901, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1052 = v222 * v287[3];\n\tv902 = v227 * v293[3];\n\tv848 = v1052 + v902;\n\tv871 = 0x8BF749C(v870, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v848, v902, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1059 = v222 * v287[4];\n\tv903 = v227 * v293[4];\n\tv849 = v1059 + v903;\n\tv872 = 0x8BF749C(v871, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v849, v903, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1064 = v222 * v287[5];\n\tv904 = v227 * v293[5];\n\tv850 = v1064 + v904;\n\tv873 = 0x8BF749C(v872, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v850, v904, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1071 = v222 * v287[6];\n\tv905 = v227 * v293[6];\n\tv851 = v1071 + v905;\n\tv874 = 0x8BF749C(v873, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v851, v905, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1092 = v222 * v287[7];\n\tv1093 = v227 * v293[7];\n\tv1094 = v1092 + v1093;\n\tv492 = 0x8BF749C(v874, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1094, v1093, v842, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv499 = worldPosition;\n\tgoto L_03CB;\nL_02CB:\n\tv424 = v225 + v227;\n\tv425 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v424, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv512 = v222 + v227;\n\tv493 = 0x8BF749C(v425, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v512, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv499 = worldPosition;\n\tgoto L_03CB;\nL_02D3:\n\tv288 = this.sinePosOffsetsX;\n\tv125 = this.sinePhsOffsetsX;\n\tv914 = v225 * v288[0];\n\tv906 = v227 * v125[0];\n\tv852 = v914 + v906;\n\tv875 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v852, v906, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv929 = v225 * v288[1];\n\tv907 = v227 * v125[1];\n\tv853 = v929 + v907;\n\tv876 = 0x8BF749C(v875, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v853, v907, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv946 = v225 * v288[2];\n\tv908 = v227 * v125[2];\n\tv854 = v946 + v908;\n\tv877 = 0x8BF749C(v876, clobbered_X1, clobbered_X2,\n// ... truncated")]
		public Vector3 GetPositionOnWater(Vector3 worldPosition)
		{
			float num = WaterMaterial.GetFloat("_WaveFrequency");
			float num2 = WaterMaterial.GetFloat("_WaveHeight");
			float num3 = WaterMaterial.GetFloat("_WaveSpeed");
			float time = Time.time;
			float num4 = num3 * time;
			float num5 = worldPosition.x * num;
			float num6 = worldPosition.z * num;
			Vector3 result;
			if (sineCount <= 3)
			{
				if (sineCount != 1)
				{
					bool flag = sineCount != 2;
					result = worldPosition;
					if (!flag)
					{
						float[] array = sinePosOffsetsX;
						float[] array2 = sinePhsOffsetsX;
						float num7 = num5 * array[0];
						float num8 = num4 * array2[0];
						float num9 = num7 + num8;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						float num10 = num5 * array[1];
						float num11 = num4 * array2[1];
						float num12 = num10 + num11;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						float[] array3 = sinePosOffsetsZ;
						float[] array4 = sinePhsOffsetsZ;
						float num13 = num6 * array3[0];
						float num14 = num4 * array4[0];
						float num15 = num13 + num14;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						float num16 = num6 * array3[1];
						float num17 = num4 * array4[1];
						float num18 = num16 + num17;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
						result = worldPosition;
					}
				}
				else
				{
					float num19 = num5 + num4;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num20 = num6 + num4;
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
					float[] array5 = sinePosOffsetsX;
					float[] array6 = sinePhsOffsetsX;
					float num21 = num5 * array5[0];
					float num22 = num4 * array6[0];
					float num23 = num21 + num22;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num24 = num5 * array5[1];
					float num25 = num4 * array6[1];
					float num26 = num24 + num25;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num27 = num5 * array5[2];
					float num28 = num4 * array6[2];
					float num29 = num27 + num28;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num30 = num5 * array5[3];
					float num31 = num4 * array6[3];
					float num32 = num30 + num31;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num33 = num5 * array5[4];
					float num34 = num4 * array6[4];
					float num35 = num33 + num34;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num36 = num5 * array5[5];
					float num37 = num4 * array6[5];
					float num38 = num36 + num37;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num39 = num5 * array5[6];
					float num40 = num4 * array6[6];
					float num41 = num39 + num40;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num42 = num5 * array5[7];
					float num43 = num4 * array6[7];
					float num44 = num42 + num43;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float[] array7 = sinePosOffsetsZ;
					float[] array8 = sinePhsOffsetsZ;
					float num45 = num6 * array7[0];
					float num46 = num4 * array8[0];
					float num47 = num45 + num46;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num48 = num6 * array7[1];
					float num49 = num4 * array8[1];
					float num50 = num48 + num49;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num51 = num6 * array7[2];
					float num52 = num4 * array8[2];
					float num53 = num51 + num52;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num54 = num6 * array7[3];
					float num55 = num4 * array8[3];
					float num56 = num54 + num55;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num57 = num6 * array7[4];
					float num58 = num4 * array8[4];
					float num59 = num57 + num58;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num60 = num6 * array7[5];
					float num61 = num4 * array8[5];
					float num62 = num60 + num61;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num63 = num6 * array7[6];
					float num64 = num4 * array8[6];
					float num65 = num63 + num64;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					float num66 = num6 * array7[7];
					float num67 = num4 * array8[7];
					float num68 = num66 + num67;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
					result = worldPosition;
				}
			}
			else
			{
				float[] array9 = sinePosOffsetsX;
				float[] array10 = sinePhsOffsetsX;
				float num69 = num5 * array9[0];
				float num70 = num4 * array10[0];
				float num71 = num69 + num70;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num72 = num5 * array9[1];
				float num73 = num4 * array10[1];
				float num74 = num72 + num73;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num75 = num5 * array9[2];
				float num76 = num4 * array10[2];
				float num77 = num75 + num76;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num78 = num5 * array9[3];
				float num79 = num4 * array10[3];
				float num80 = num78 + num79;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float[] array11 = sinePosOffsetsZ;
				float[] array12 = sinePhsOffsetsZ;
				float num81 = num6 * array11[0];
				float num82 = num4 * array12[0];
				float num83 = num81 + num82;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num84 = num6 * array11[1];
				float num85 = num4 * array12[1];
				float num86 = num84 + num85;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num87 = num6 * array11[2];
				float num88 = num4 * array12[2];
				float num89 = num87 + num88;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				float num90 = num6 * array11[3];
				float num91 = num4 * array12[3];
				float num92 = num90 + num91;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
				result = worldPosition;
			}
			return result;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x8196F0C", Offset = "0x8196F0C", Length = "0x94C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\nL_002F:\n\tv74 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveFrequency\");\n\tv290 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveHeight\");\n\tv281 = v290 * this.heightScale;\n\tv483 = UnityEngine.Material::GetFloat(this.WaterMaterial, \"_WaveSpeed\");\n\tv484 = UnityEngine.Time::get_time();\n\tv274 = v483 * v484;\n\tv272 = worldPosition * v74;\n\tv291 = worldPosition.z * v74;\n\tv193 = this.sineCount > 3;\n\tif (v193) goto L_00DA;\n\tv499 = this.sineCount == 1;\n\tif (v499) goto L_02FD;\n\tv190 = this.sineCount != 2;\n\tv698 = 0;\n\tv699 = 0;\n\tif (v190) goto L_030D;\n\tv330 = this.sinePosOffsetsX;\n\tv173 = this.sinePhsOffsetsX;\n\tv1128 = v272 * v330[0];\n\tv1168 = v274 * v173[0];\n\tv1064 = v1128 + v1168;\n\tv1087 = 0x8BF608C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1064, v1128, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv358 = v272 * v330[1];\n\tv1203 = v274 * v173[1];\n\tv292 = v358 + v1203;\n\tv306 = 0x8BF608C(v1087, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v292, v358, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv331 = this.sinePosOffsetsZ;\n\tv338 = this.sinePhsOffsetsZ;\n\tv1129 = v291 * v331[0];\n\tv1225 = v274 * v338[0];\n\tv1065 = v1129 + v1225;\n\tv1088 = 0x8BF608C(v306, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1065, v1129, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1267 = v281 * -0.5f;\n\tv1240 = v330[0] * v1064;\n\tv1241 = v330[1] * v292;\n\tv1242 = v1240 + v1241;\n\tv699 = v1267 * v1242;\n\tv1247 = v291 * v331[1];\n\tv1248 = v274 * v338[1];\n\tv1249 = v1247 + v1248;\n\tv1250 = 0x8BF608C(v1088, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1249, v1247, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv672 = v331[0] * v1065;\n\tv1261 = v331[1] * v1249;\n\tgoto L_02F3;\nL_00DA:\n\tv238 = this.sineCount == 4;\n\tif (v238) goto L_0356;\n\tv191 = this.sineCount != 8;\n\tv698 = 0;\n\tv699 = 0;\n\tif (v191) goto L_030D;\n\tv332 = this.sinePosOffsetsX;\n\tv175 = this.sinePhsOffsetsX;\n\tv1130 = v272 * v332[0];\n\tv1180 = v274 * v175[0];\n\tv1066 = v1130 + v1180;\n\tv1089 = 0x8BF608C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1066, v1130, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1131 = v272 * v332[1];\n\tv1205 = v274 * v175[1];\n\tv1067 = v1131 + v1205;\n\tv1090 = 0x8BF608C(v1089, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1067, v1131, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1132 = v272 * v332[2];\n\tv1219 = v274 * v175[2];\n\tv1068 = v1132 + v1219;\n\tv1091 = 0x8BF608C(v1090, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1068, v1132, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1133 = v272 * v332[3];\n\tv1233 = v274 * v175[3];\n\tv1069 = v1133 + v1233;\n\tv1092 = 0x8BF608C(v1091, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1069, v1133, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1134 = v272 * v332[4];\n\tv1257 = v274 * v175[4];\n\tv1070 = v1134 + v1257;\n\tv1093 = 0x8BF608C(v1092, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1070, v1134, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1135 = v272 * v332[5];\n\tv1282 = v274 * v175[5];\n\tv1071 = v1135 + v1282;\n\tv1094 = 0x8BF608C(v1093, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1071, v1135, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1136 = v272 * v332[6];\n\tv1295 = v274 * v175[6];\n\tv1072 = v1136 + v1295;\n\tv1095 = 0x8BF608C(v1094, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1072, v1136, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv359 = v272 * v332[7];\n\tv1305 = v274 * v175[7];\n\tv293 = v359 + v1305;\n\tv307 = 0x8BF608C(v1095, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v293, v359, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv333 = this.sinePosOffsetsZ;\n\tv339 = this.sinePhsOffsetsZ;\n\tv1137 = v291 * v333[0];\n\tv1335 = v274 * v339[0];\n\tv1073 = v1137 + v1335;\n\tv1096 = 0x8BF608C(v307, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1073, v1137, v291, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1138 = v291 * v333[1];\n\tv1340 = v274 * v339[1];\n\tv1074 = v1138 + v1340;\n\tv1097 = 0x8BF608C(v1096, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1074, v1138, v291, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1139 = v291 * v333[2];\n\tv1347 = v274 * v339[2];\n\tv1075 = v1139 + v1347;\n\tv1098 = 0x8BF608C(v1097, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1075, v1139, v291, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1140 = v291 * v333[3];\n\tv1352 = v274 * v339[3];\n\tv1076 = v1140 + v1352;\n\tv1099 = 0x8BF608C(v1098, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1076, v1140, v291, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1141 = v291 * v333[4];\n\tv1359 = v274 * v339[4];\n\tv1077 = v1141 + v1359;\n\tv1100 = 0x8BF608C(v1099, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1077, v1141, v291, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1142 = v291 * v333[5];\n\tv1364 = v274 * v339[5];\n\tv1078 = v1142 + v1364;\n\tv1101 = 0x8BF608C(v1100, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1078, v1142, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1143 = v291 * v333[6];\n\tv1371 = v274 * v339[6];\n\tv1079 = v1143 + v1371;\n\tv1102 = 0x8BF608C(v1101, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1079, v1143, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1267 = v281 * -0.125f;\n\tv1376 = v332[0] * v1066;\n\tv1378 = v332[1] * v1067;\n\tv1379 = v1376 + v1378;\n\tv1382 = v332[2] * v1068;\n\tv1383 = v1379 + v1382;\n\tv1386 = v332[3] * v1069;\n\tv1387 = v1383 + v1386;\n\tv1390 = v332[4] * v1070;\n\tv1391 = v1387 + v1390;\n\tv1394 = v332[5] * v1071;\n\tv1395 = v1391 + v1394;\n\tv1398 = v332[6] * v1072;\n\tv1399 = v1395 + v1398;\n\tv1402 = v332[7] * v293;\n\tv1403 = v1399 + v1402;\n\tv699 = v1267 * v1403;\n\tv1406 = v291 * v333[7];\n\tv1407 = v274 * v339[7];\n\tv1408 = v1406 + v1407;\n\tv1263 = 0x8BF608C(v1102, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1408, v1406, v293, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1411 = v333[0] * v1073;\n\tv1414 = v333[1] * v1074;\n\tv1415 = v1411 + v1414;\n\tv1418 = v333[2] * v1075;\n\tv1419 = v1415 + v1418;\n\tv1422 = v333[3] * v1076;\n\tv1423 = v1419 + v1422;\n\tv1425 = v333[4] * v1077;\n\tv1426 = v1423 + v1425;\n\tv1428 = v333[5] * v1078;\n\tv1429 = v1426 + v1428;\n\tv1270 = v333[6] * v1079;\n\tv672 = v1429 + v1270;\n\tv1261 = v333[7] * v1408;\n\tgoto L_0317;\nL_02FD:\n\tv506 = v272 + v274;\n\tv507 = 0x8BF608C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v506, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv533 = v281 * v506;\n\tv699 \n// ... truncated")]
		public Vector3 GetNormalOnWater(Vector3 worldPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_GetPosOnWater::GetNormalOnWater");
			return default;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x8197858", Offset = "0x8197858", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\t// 69 NewArr v86 @ X0_v8 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v86, Il2CppFieldInfo);\n\tthis.sinePosOffsetsZ = v86;\n\t// 81 NewArr v98 @ X0_v13 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v98, Il2CppFieldInfo);\n\tthis.sinePhsOffsetsX = v98;\n\t// 93 NewArr v108 @ X0_v18 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v108, Il2CppFieldInfo);\n\tthis.sinePhsOffsetsZ = v108;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_002F:\n\tthis.heightScale = 1f;\n\tthis.followWaterHeight = 1;\n\tthis.upAxis = 0.0078125d;\n\tthis.upAxis.z = 0f;\n\tthis.postRotation.y = 0f;\n\t// 57 NewArr v67 @ X0_v3 (System.Single[]), typeof(System.Single[]), 8\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v67, Il2CppFieldInfo);\n\tthis.sinePosOffsetsX = v67;\n")]
		public TCP2_GetPosOnWater()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_GetPosOnWater::.ctor");
		}
	}
}
