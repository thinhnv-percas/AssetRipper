using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x2000015")]
	public static class AllIn1VfxNoiseCreator
	{
		[Token(Token = "0x600003F")]
		[Address(RVA = "0x3C26F88", Offset = "0x3C26F88", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv76 = UnityEngine.Texture::get_width(tex);\n\tv82 = UnityEngine.Texture::get_height(tex);\n\tUnityEngine.Random::InitState(randomSeed);\n\tv161 = UnityEngine.Random::Range(-100f, 100f);\n\tv102 = v82 < 1;\n\tif (v102) goto L_FFFFFFFF;\n\tv268 = v76 - 1;\n\tv284 = v268 < 0;\n\tv271 = v76 ^ 1;\n\tv272 = v76 ^ v268;\n\tv273 = v271 & v272;\n\tv279 = v273 < 0;\n\tgoto L_005A;\nL_FFFFFFFF:\n\tv279 = 0;\nL_FFFFFFFF:\n\tv284 = 1;\nL_FFFFFFFF:\n\tv338 = 0;\n\tv338 = v338 + 1;\n\tv299 = v338 != v82;\n\tif (v299) goto L_0060;\nL_008D:\n\tUnityEngine.Texture2D::Apply(tex);\n\tv344 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v344, v82, v76);\n\tv148 = UnityEngine.Texture2D::GetPixels(tex);\n\tUnityEngine.Texture2D::SetPixels(v344, v148);\n\tv396 = v82 < 1;\n\tif (v396) goto L_0185;\n\tv397 = ~tileable;\n\tif (v397) goto L_0185;\n\tv420 = v76 < 1;\n\tif (v420) goto L_0185;\n\tv411 = v161 + 0x41BB70A4;\nL_FFFFFFFF:\n\tv475 = v82;\nL_FFFFFFFF:\n\tv547 = 0.5f;\nL_FFFFFFFF:\n\tv491 = scale;\nL_FFFFFFFF:\n\tv492 = 0;\n\tgoto L_00D7;\nL_FFFFFFFF:\n\tv510 = v492;\nL_FFFFFFFF:\n\tv449 = v550;\n\tgoto L_00F0;\nL_FFFFFFFF:\n\tv449 = v521;\nL_FFFFFFFF:\n\tv591 = v554;\n\tgoto L_0109;\nL_FFFFFFFF:\n\tv591 = v401;\n\tgoto L_011B;\nL_FFFFFFFF:\n\tv607 = v514;\nL_FFFFFFFF:\n\tv622 = v591;\n\tgoto L_012D;\nL_FFFFFFFF:\n\tv622 = v607;\nL_FFFFFFFF:\n\tv656 = 1f;\n\tgoto L_0148;\nL_FFFFFFFF:\n\tv656 = v622;\nL_FFFFFFFF:\n\tv656 = 0;\n\tgoto L_0155;\n\tv492 = v492 + 1;\n\tv419 = v492 != v82;\nL_FFFFFFFF:\n\tv475 = v82;\nL_FFFFFFFF:\n\tv547 = 0.5f;\nL_FFFFFFFF:\n\tv491 = scale;\n\tif (v419) goto L_00C3;\nL_0185:\n\tUnityEngine.Texture2D::Apply(v344);\n\treturn v344;\nL_005A:\n\tv287 = v284 == v279;\n\tv288 = ~v287;\n\tif (v288) goto L_008D;\nL_0064:\n\tv374 = v161 + v345;\n\tv375 = v374 / v76;\n\tv376 = v375 * scale;\n\tv309 = UnityEngine.Mathf::PerlinNoise(v376, v290);\n\t// 113 MakeStruct v292 @ AGG3C270A4_3_v5 (UnityEngine.Color), typeof(UnityEngine.Color), v309 @ V0_v36 (System.Single), v309 @ V0_v36 (System.Single), v309 @ V0_v36 (System.Single), 1f\n\tUnityEngine.Texture2D::SetPixel(tex, v345, v338, v292);\n\tv345 = v345 + 1;\n\tv352 = v76 != v345;\n\tif (v352) goto L_0064;\nL_0060:\n\tv341 = v161 + v338;\n\tv342 = v341 / v82;\n\tv290 = v342 * scale;\nL_FFFFFFFF:\n\tv345 = 0;\nL_00D7:\n\tv512 = v411 + v510;\n\tv513 = v512 / v475;\n\tv440 = v513 * v491;\n\tv514 = 1f - v401;\nL_FFFFFFFF:\n\tv521 = 0;\nL_FFFFFFFF:\n\tv550 = v76;\nL_00F0:\n\tv570 = v411 + v449;\n\tv571 = v570 / v76;\n\tv573 = v571 * scale;\n\tv576 = UnityEngine.Mathf::PerlinNoise(v573, v440);\n\tv577 = v554 < v401;\n\tv578 = v554 == v401;\n\tv581 = v554 == v554;\n\tv582 = v401 == v401;\n\tv583 = v581 & v582;\n\tv584 = ~v583;\n\tv585 = v577 == v584;\n\tv586 = ~v578;\n\tv587 = v585 & v586;\n\tv588 = ~v587;\n\tif (v588) goto L_FFFFFFFF;\nL_0109:\n\tv607 = 1f - v554;\n\tv593 = v607 < v514;\n\tv594 = v607 == v514;\n\tv597 = v607 == v607;\n\tv598 = v514 == v514;\n\tv599 = v597 & v598;\n\tv600 = ~v599;\n\tv601 = v593 == v600;\n\tv602 = ~v594;\n\tv603 = v601 & v602;\n\tv604 = ~v603;\n\tif (v604) goto L_FFFFFFFF;\nL_011B:\n\tv608 = v591 < v607;\n\tv609 = v591 == v607;\n\tv612 = v591 == v591;\n\tv613 = v607 == v607;\n\tv614 = v612 & v613;\n\tv615 = ~v614;\n\tv616 = v608 == v615;\n\tv617 = ~v609;\n\tv618 = v616 & v617;\n\tv619 = ~v618;\n\tif (v619) goto L_FFFFFFFF;\nL_012D:\n\tv624 = 0x8BF6F2C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v622, 10f, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv629 = UnityEngine.Texture2D::GetPixel(tex, v521, v492);\n\tv633 = v622 < 1f;\n\tv634 = v622 == 1f;\n\tv637 = v622 == v622;\n\tv638 = 1f == 1f;\n\tv639 = v637 & v638;\n\tv640 = ~v639;\n\tv641 = v633 == v640;\n\tv403 = ~v634;\n\tv642 = v641 & v403;\n\tv643 = ~v642;\n\tif (v643) goto L_FFFFFFFF;\nL_0148:\n\tv647 = v622 < 0;\n\tv418 = ~v647;\n\tif (v418) goto L_0155;\nL_0155:\n\tv657 = v576 - v629;\n\tv658 = v656 * v657;\n\tv442 = v629 + v658;\n\tv659 = v576 - v629.g;\n\tv660 = v656 * v659;\n\tv661 = v629.g + v660;\n\tv662 = v576 - v629.b;\n\tv663 = v656 * v662;\n\tv415 = v629.b + v663;\n\tv399 = 1f - v629.a;\n\tv402 = v656 * v399;\n\tv417 = v629.a + v402;\n\t// 357 MakeStruct v398 @ AGG3C27230_3_v4 (UnityEngine.Color), typeof(UnityEngine.Color), v442 @ V0_v22 (System.Single), v661 @ V1_v14 (System.Single), v415 @ V2_v7 (System.Single), v417 @ V3_v7 (System.Single)\n\tUnityEngine.Texture2D::SetPixel(v344, v521, v492, v398);\n\tv521 = v521 + 1;\n\tv446 = v550 - 1;\n\tv528 = v550 != 1;\nL_FFFFFFFF:\n\tv547 = 0.5f;\nL_FFFFFFFF:\n\tv550 = v446;\n\tif (v528) goto L_00DD;\nL_00DD:\n\tv554 = v521 / v76;\n\tv555 = v554 < v547;\n\tv556 = v554 == v547;\n\tv559 = v554 == v554;\n\tv560 = v547 == v547;\n\tv561 = v559 & v560;\n\tv562 = ~v561;\n\tv563 = v555 == v562;\n\tv564 = ~v556;\n\tv565 = v563 & v564;\n\tv566 = ~v565;\n\tif (v566) goto L_FFFFFFFF;\nL_00C3:\n\tv401 = v492 / v475;\n\tv510 = v82 - v492;\n\tv496 = v401 < v547;\n\tv497 = v401 == v547;\n\tv500 = v401 == v401;\n\tv501 = v547 == v547;\n\tv502 = v500 & v501;\n\tv503 = ~v502;\n\tv504 = v496 == v503;\n\tv505 = ~v497;\n\tv506 = v504 & v505;\n\tv507 = ~v506;\n\tif (v507) goto L_FFFFFFFF;\n")]
		public static Texture2D PerlinNoise(Texture2D tex, float scale, int randomSeed, bool tileable)
		{
			int width = tex.width;
			int height = tex.height;
			Random.InitState(randomSeed);
			float num = Random.Range(-100f, 100f);
			bool flag;
			bool flag2;
			if (height >= 1)
			{
				int num2 = width - 1;
				flag = num2 < 0;
				int num3 = width ^ 1;
				int num4 = width ^ num2;
				int num5 = num3 & num4;
				flag2 = num5 < 0;
			}
			else
			{
				flag2 = false;
				flag = true;
			}
			if (flag == flag2)
			{
				int num6 = 0;
				Color color = default(Color);
				do
				{
					float num7 = num + (float)num6;
					float num8 = num7 / (float)height;
					float y = num8 * scale;
					int num9 = 0;
					do
					{
						float num10 = num + (float)num9;
						float num11 = num10 / (float)width;
						float x = num11 * scale;
						color.b = (color.g = (color.r = Mathf.PerlinNoise(x, y)));
						color.a = 1f;
						tex.SetPixel(num9, num6, color);
						num9++;
					}
					while (width != num9);
					num6++;
				}
				while (num6 != height);
			}
			tex.Apply();
			Texture2D texture2D = new Texture2D(height, width);
			Color[] pixels = tex.GetPixels();
			texture2D.SetPixels(pixels);
			if (height >= 1 && tileable && width >= 1)
			{
				float num12 = num + 23.43f;
				int num13 = height;
				float num14 = 0.5f;
				float num15 = scale;
				int num16 = 0;
				Color color2 = default(Color);
				bool flag52;
				do
				{
					int num17 = num16 / num13;
					int num18 = height - num16;
					bool flag3 = (float)num17 < num14;
					bool flag4 = (float)num17 == num14;
					bool flag5 = num17 == num17;
					bool flag6 = num14 == num14;
					bool flag7 = flag5 && flag6;
					bool flag8 = !flag7;
					bool flag9 = flag3 == flag8;
					bool flag10 = !flag4;
					if (!(flag9 && flag10))
					{
						num18 = num16;
					}
					float num19 = num12 + (float)num18;
					float num20 = num19 / (float)num13;
					float y2 = num20 * num15;
					float num21 = 1f - (float)num17;
					int num22 = 0;
					int num23 = width;
					bool flag51;
					do
					{
						int num24 = num22 / width;
						bool flag11 = (float)num24 < num14;
						bool flag12 = (float)num24 == num14;
						bool flag13 = num24 == num24;
						bool flag14 = num14 == num14;
						bool flag15 = flag13 && flag14;
						bool flag16 = !flag15;
						bool flag17 = flag11 == flag16;
						bool flag18 = !flag12;
						int num25 = ((!(flag17 && flag18)) ? num22 : num23);
						float num26 = num12 + (float)num25;
						float num27 = num26 / (float)width;
						float x2 = num27 * scale;
						float num28 = Mathf.PerlinNoise(x2, y2);
						bool flag19 = num24 < num17;
						bool flag20 = num24 == num17;
						bool flag21 = num24 == num24;
						bool flag22 = num17 == num17;
						bool flag23 = flag21 && flag22;
						bool flag24 = !flag23;
						bool flag25 = flag19 == flag24;
						bool flag26 = !flag20;
						int num29 = ((!(flag25 && flag26)) ? num17 : num24);
						float num30 = 1f - (float)num24;
						bool flag27 = num30 < num21;
						bool flag28 = num30 == num21;
						bool flag29 = num30 == num30;
						bool flag30 = num21 == num21;
						bool flag31 = flag29 && flag30;
						bool flag32 = !flag31;
						bool flag33 = flag27 == flag32;
						bool flag34 = !flag28;
						if (!(flag33 && flag34))
						{
							num30 = num21;
						}
						bool flag35 = (float)num29 < num30;
						bool flag36 = (float)num29 == num30;
						bool flag37 = num29 == num29;
						bool flag38 = num30 == num30;
						bool flag39 = flag37 && flag38;
						bool flag40 = !flag39;
						bool flag41 = flag35 == flag40;
						bool flag42 = !flag36;
						float num31 = ((!(flag41 && flag42)) ? num30 : ((float)num29));
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6F2C");
						Color pixel = tex.GetPixel(num22, num16);
						bool flag43 = num31 < 1f;
						bool flag44 = num31 == 1f;
						bool flag45 = num31 == num31;
						bool flag46 = 1f == 1f;
						bool flag47 = flag45 && flag46;
						bool flag48 = !flag47;
						bool flag49 = flag43 == flag48;
						bool flag50 = !flag44;
						float num32 = ((!(flag49 && flag50)) ? num31 : 1f);
						if (num31 < 0f)
						{
							num32 = 0f;
						}
						float num33 = num28 - pixel.r;
						float num34 = num32 * num33;
						float r = pixel.r + num34;
						float num35 = num28 - pixel.g;
						float num36 = num32 * num35;
						float g = pixel.g + num36;
						float num37 = num28 - pixel.b;
						float num38 = num32 * num37;
						float b = pixel.b + num38;
						float num39 = 1f - pixel.a;
						float num40 = num32 * num39;
						float a = pixel.a + num40;
						color2.r = r;
						color2.g = g;
						color2.b = b;
						color2.a = a;
						texture2D.SetPixel(num22, num16, color2);
						num22++;
						int num41 = num23 - 1;
						flag51 = num23 != 1;
						num14 = 0.5f;
						num23 = num41;
					}
					while (flag51);
					num16++;
					flag52 = num16 != height;
					num13 = height;
					num14 = 0.5f;
					num15 = scale;
				}
				while (flag52);
			}
			texture2D.Apply();
			return texture2D;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x3C27294", Offset = "0x3C27294", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = y + offset;\n\tv12 = v8 / height;\n\tv15 = v12 * scale;\n\tv17 = x + offset;\n\tv20 = v17 / width;\n\tv21 = v20 * scale;\n\treturnVal1 = UnityEngine.Mathf::PerlinNoise(v21, v15);\n\treturn returnVal1;\n")]
		private static Color CalculatePerlinColor(int x, int y, float scale, float offset, int width, int height)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxNoiseCreator::CalculatePerlinColor");
			return default;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x3C272E4", Offset = "0x3C272E4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = x / width;\n\tv35 = y / height;\n\tv52 = width - x;\n\tv38 = v32 < 0.5f;\n\tv39 = v32 == 0.5f;\n\tv42 = v32 == v32;\n\tv43 = 0.5f == 0.5f;\n\tv44 = v42 & v43;\n\tv45 = ~v44;\n\tv46 = v38 == v45;\n\tv47 = ~v39;\n\tv48 = v46 & v47;\n\tv49 = ~v48;\n\tif (v49) goto L_FFFFFFFF;\n\tgoto L_0028;\nL_FFFFFFFF:\n\tv52 = x;\n\tgoto L_003D;\nL_FFFFFFFF:\n\tv68 = y;\n\tv87 = v32 < v35;\n\tv88 = v32 == v35;\n\tv91 = v32 == v32;\n\tv92 = v35 == v35;\n\tv93 = v91 & v92;\n\tv94 = ~v93;\n\tv95 = v87 == v94;\n\tv96 = ~v88;\n\tv97 = v95 & v96;\n\tv98 = ~v97;\n\tif (v98) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv108 = v32;\n\tgoto L_005D;\nL_FFFFFFFF:\n\tv108 = v35;\n\tgoto L_0070;\nL_FFFFFFFF:\n\tv184 = v111;\nL_FFFFFFFF:\n\tv199 = v108;\n\tgoto L_0082;\nL_FFFFFFFF:\n\tv199 = v184;\nL_FFFFFFFF:\n\tv223 = 1f;\n\tgoto L_009D;\nL_FFFFFFFF:\n\tv223 = v199;\nL_FFFFFFFF:\n\tv223 = 0;\n\tgoto L_00AA;\nL_0028:\n\tv68 = height - y;\n\tv54 = v35 < 0.5f;\n\tv55 = v35 == 0.5f;\n\tv58 = v35 == v35;\n\tv59 = 0.5f == 0.5f;\n\tv60 = v58 & v59;\n\tv61 = ~v60;\n\tv62 = v54 == v61;\n\tv63 = ~v55;\n\tv64 = v62 & v63;\n\tv65 = ~v64;\n\tif (v65) goto L_FFFFFFFF;\nL_003D:\n\tv72 = offset + 0x41BB70A4;\n\tv75 = v72 + v68;\n\tv76 = v75 / height;\n\tv77 = v76 * scale;\n\tv80 = v72 + v52;\n\tv81 = v80 / width;\n\tv82 = v81 * scale;\n\treturnVal1 = UnityEngine.Mathf::PerlinNoise(v82, v77);\nL_005D:\n\tv184 = 1f - v32;\n\tv111 = 1f - v35;\n\tv112 = v184 < v111;\n\tv113 = v184 == v111;\n\tv116 = v184 == v184;\n\tv117 = v111 == v111;\n\tv118 = v116 & v117;\n\tv119 = ~v118;\n\tv120 = v112 == v119;\n\tv121 = ~v113;\n\tv122 = v120 & v121;\n\tv123 = ~v122;\n\tif (v123) goto L_FFFFFFFF;\nL_0070:\n\tv185 = v108 < v184;\n\tv186 = v108 == v184;\n\tv189 = v108 == v108;\n\tv190 = v184 == v184;\n\tv191 = v189 & v190;\n\tv192 = ~v191;\n\tv193 = v185 == v192;\n\tv194 = ~v186;\n\tv195 = v193 & v194;\n\tv196 = ~v195;\n\tif (v196) goto L_FFFFFFFF;\nL_0082:\n\tv201 = 0x8BF6F2C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v199, 10f, v111, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv203 = UnityEngine.Texture2D::GetPixel(previousPerlin, x, y);\n\tv207 = v199 < 1f;\n\tv208 = v199 == 1f;\n\tv211 = v199 == v199;\n\tv155 = 1f == 1f;\n\tv212 = v211 & v155;\n\tv213 = ~v212;\n\tv214 = v207 == v213;\n\tv149 = ~v208;\n\tv151 = v214 & v149;\n\tv215 = ~v151;\n\tif (v215) goto L_FFFFFFFF;\nL_009D:\n\tv163 = v199 < 0;\n\tv147 = ~v163;\n\tif (v147) goto L_00AA;\nL_00AA:\n\tv224 = returnVal1 - v203;\n\tv225 = v223 * v224;\n\treturnVal2 = v203 + v225;\n\treturn returnVal2;\n")]
		private static Color PerlinBorderless(int x, int y, float scale, float offset, int width, int height, Texture2D previousPerlin)
		{
			int num = x / width;
			int num2 = y / height;
			int num3 = width - x;
			bool flag = (float)num < 0.5f;
			bool flag2 = (float)num == 0.5f;
			bool flag3 = num == num;
			bool flag4 = 0.5f == 0.5f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (!(flag7 && flag8))
			{
				num3 = x;
			}
			int num4 = height - y;
			bool flag9 = (float)num2 < 0.5f;
			bool flag10 = (float)num2 == 0.5f;
			bool flag11 = num2 == num2;
			bool flag12 = 0.5f == 0.5f;
			bool flag13 = flag11 && flag12;
			bool flag14 = !flag13;
			bool flag15 = flag9 == flag14;
			bool flag16 = !flag10;
			if (!(flag15 && flag16))
			{
				num4 = y;
			}
			float num5 = offset + 23.43f;
			float num6 = num5 + (float)num4;
			float num7 = num6 / (float)height;
			float y2 = num7 * scale;
			float num8 = num5 + (float)num3;
			float num9 = num8 / (float)width;
			float x2 = num9 * scale;
			float num10 = Mathf.PerlinNoise(x2, y2);
			bool flag17 = num < num2;
			bool flag18 = num == num2;
			bool flag19 = num == num;
			bool flag20 = num2 == num2;
			bool flag21 = flag19 && flag20;
			bool flag22 = !flag21;
			bool flag23 = flag17 == flag22;
			bool flag24 = !flag18;
			int num11 = ((!(flag23 && flag24)) ? num2 : num);
			float num12 = 1f - (float)num;
			float num13 = 1f - (float)num2;
			bool flag25 = num12 < num13;
			bool flag26 = num12 == num13;
			bool flag27 = num12 == num12;
			bool flag28 = num13 == num13;
			bool flag29 = flag27 && flag28;
			bool flag30 = !flag29;
			bool flag31 = flag25 == flag30;
			bool flag32 = !flag26;
			if (!(flag31 && flag32))
			{
				num12 = num13;
			}
			bool flag33 = (float)num11 < num12;
			bool flag34 = (float)num11 == num12;
			bool flag35 = num11 == num11;
			bool flag36 = num12 == num12;
			bool flag37 = flag35 && flag36;
			bool flag38 = !flag37;
			bool flag39 = flag33 == flag38;
			bool flag40 = !flag34;
			float num14 = ((!(flag39 && flag40)) ? num12 : ((float)num11));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6F2C");
			Color pixel = previousPerlin.GetPixel(x, y);
			bool flag41 = num14 < 1f;
			bool flag42 = num14 == 1f;
			bool flag43 = num14 == num14;
			bool flag44 = 1f == 1f;
			bool flag45 = flag43 && flag44;
			bool flag46 = !flag45;
			bool flag47 = flag41 == flag46;
			bool flag48 = !flag42;
			float num15 = ((!(flag47 && flag48)) ? num14 : 1f);
			if (num14 < 0f)
			{
				num15 = 0f;
			}
			float num16 = num10 - pixel.r;
			float num17 = num15 * num16;
			float r = pixel.r + num17;
			Color result = default(Color);
			result.r = r;
			return result;
		}
	}
}
