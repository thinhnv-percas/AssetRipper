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
	[Token(Token = "0x200007D")]
	public class QuaternionPlugin : ABSTweenPlugin<Quaternion, Vector3, QuaternionOptions>
	{
		[Token(Token = "0x6000310")]
		[Address(RVA = "0xC21308", Offset = "0xC21308", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
		}

		[Token(Token = "0x6000311")]
		[Address(RVA = "0xC2130C", Offset = "0xC2130C", Length = "0x3D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv210 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::Invoke(v311.getter);\n\t// 28 MakeStruct v168 @ AGGC2535C_0_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v311.endValue (UnityEngine.Vector3), v163 @ V1, v159 @ V2, v150 @ V3\n\tv212 = UnityEngine.Quaternion::Internal_ToEulerRad(v168);\n\tv216 = v212 * 57.29578f;\n\tv217 = v212.y * 57.29578f;\n\tv218 = v212.z * 57.29578f;\n\t// 38 MakeStruct v155 @ AGGC25378_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v216 @ V0_v4 (System.Single), v217 @ V1_v3 (System.Single), v218 @ V2_v3 (System.Single)\n\tv188 = UnityEngine.Quaternion::Internal_MakePositive(v155);\n\tv127 = v311.plugOptions == 1;\n\tv311.endValue = v188;\n\t*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+134]) = v188.y;\n\t*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) = v188.z;\n\tif (v127) goto L_00C4;\n\tv293 = v311.plugOptions == 0;\n\tv294 = ~v293;\n\tif (v294) goto L_0042;\n\tv304 = ~v311.<isRelative>k__BackingField;\n\tif (v304) goto L_FFFFFFFF;\nL_0042:\n\t;\n\tv326 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::Invoke(v311.getter);\n\tv341 = v311.plugOptions != 2;\n\tif (v341) goto L_00CF;\n\t// 94 MakeStruct v349 @ AGGC253F8_0_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v188 @ V0_v5 (UnityEngine.Vector3), v188.y (System.Single), v188.z (System.Single), v188 @ V0_v5 (UnityEngine.Vector3)\n\tv350 = UnityEngine.Quaternion::Inverse(v349);\n\tv404 = v188 * v350;\n\tv405 = v188 * v350.w;\n\tv406 = v188 * v350.y;\n\tv407 = v188.y * v350.w;\n\tv408 = v404 + v405;\n\tv409 = v188 * v350.z;\n\tv410 = v406 + v407;\n\tv411 = v188.z * v350.w;\n\tv412 = v188 * v350.w;\n\tv413 = v409 + v411;\n\tv414 = v188 * v350;\n\tv415 = v412 - v414;\n\tv416 = v188.y * v350.z;\n\tv417 = v416 + v408;\n\tv418 = v188.z * v350;\n\tv419 = v418 + v410;\n\tv420 = v188 * v350.y;\n\tv421 = v420 + v413;\n\tv422 = v188.z * v350.y;\n\tv423 = v188.y * v350.y;\n\tv424 = v415 - v423;\n\tv425 = v188 * v350.z;\n\tv426 = v188.z * v350.z;\n\tv427 = v419 - v425;\n\tv432 = v417 - v422;\n\tv434 = v424 - v426;\n\tv437 = v188.y * v350;\n\t// 133 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv438 = v311.endValue * v350;\n\tv439 = *([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) * 0.017453292f;\n\tv442 = v421 - v437;\n\t// 139 MakeStruct v443 @ AGGC25498_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v438 @ V0_v24 (System.Single), v322 @ V0.S1 (System.Single), v439 @ V2_v22 (System.Single)\n\tv444 = UnityEngine.Quaternion::Internal_FromEulerRad(v443);\n\tv471 = v444 * v434;\n\tv472 = v444.w * v432;\n\tv473 = v444.y * v442;\n\tv474 = v444.y * v434;\n\tv475 = v444.w * v427;\n\tv476 = v444 * v442;\n\tv477 = v444.y * v432;\n\tv478 = v444 * v432;\n\tv479 = v444 * v427;\n\tv480 = v444.y * v427;\n\tv481 = v444.z * v434;\n\tv482 = v444.w * v434;\n\tv483 = v444.w * v442;\n\tv484 = v444.z * v427;\n\tv485 = v444.z * v432;\n\tv486 = v444.z * v442;\n\tv489 = v471 + v472;\n\tv490 = v474 + v475;\n\tv491 = v481 + v483;\n\tv492 = v482 - v478;\n\tv493 = v484 + v489;\n\tv494 = v476 + v490;\n\tv495 = v492 - v480;\n\tv496 = v477 + v491;\n\tv497 = v493 - v473;\n\tv525 = v494 - v485;\n\tv523 = v495 - v486;\n\tv524 = v496 - v479;\n\tv501 = v188 * v523;\n\tv502 = v188 * v497;\n\tv503 = v188.y * v523;\n\tv504 = v188 * v525;\n\tv505 = v188.z * v525;\n\tv506 = v188 * v524;\n\tv507 = v501 + v502;\n\tv508 = v188.z * v523;\n\tv509 = v503 + v504;\n\tv510 = v188 * v524;\n\tv511 = v188.y * v524;\n\tv512 = v188.z * v497;\n\tv513 = v508 + v510;\n\tv514 = v188.y * v497;\n\tv515 = v505 + v507;\n\tv516 = v506 + v509;\n\tv521 = v514 + v513;\n\tv522 = v515 - v511;\n\tv144 = v516 - v512;\n\tv89 = v188 * v525;\n\tgoto L_00ED;\nL_00C4:\n\tv307 = *([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) + v188.z;\n\tv315 = v311.endValue + v188;\n\tv309 = v301 + v188.y;\n\tgoto L_0113;\nL_00CF:\n\t// 207 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv355 = v311.endValue * v188;\n\tv356 = *([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) * 0.017453292f;\n\t// 212 MakeStruct v359 @ AGGC255A8_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v355 @ V0_v20 (System.Single), v322 @ V0.S1 (System.Single), v356 @ V2_v17 (System.Single)\n\tv360 = UnityEngine.Quaternion::Internal_FromEulerRad(v359);\n\tv525 = v360.y;\n\tv524 = v360.z;\n\tv523 = v360.w;\n\tv448 = v188 * v360;\n\tv449 = v188 * v360.w;\n\tv450 = v188 * v360.y;\n\tv451 = v188.y * v360.w;\n\tv452 = v448 + v449;\n\tv453 = v188 * v360.z;\n\tv454 = v450 + v451;\n\tv455 = v188.z * v360.w;\n\tv456 = v453 + v455;\n\tv457 = v188.y * v360.z;\n\tv458 = v457 + v452;\n\tv459 = v188.z * v360;\n\tv460 = v459 + v454;\n\tv461 = v188 * v360.y;\n\tv521 = v461 + v456;\n\tv463 = v188.z * v360.y;\n\tv522 = v458 - v463;\n\tv465 = v188 * v360.z;\n\tv144 = v460 - v465;\n\tv89 = v188.y * v360;\nL_00ED:\n\tv528 = v188 * v523;\n\tv529 = v188 * v360;\n\tv530 = v188.y * v525;\n\tv531 = v528 - v529;\n\tv92 = v521 - v89;\n\tv532 = v531 - v530;\n\tv533 = v381 * v524;\n\tv534 = v532 - v533;\n\t// 249 MakeStruct v361 @ AGGC2562C_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v522 @ V4_v4 (System.Single), v144 @ V5_v3 (System.Single), v92 @ V6_v2 (System.Single), v534 @ V3_v8 (System.Single)\n\tv539 = UnityEngine.Quaternion::Internal_ToEulerRad(v361);\n\tv542 = v539 * 57.29578f;\n\tv543 = v539.y * 57.29578f;\n\tv544 = v539.z * 57.29578f;\n\t// 257 MakeStruct v362 @ AGGC25640_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v542 @ V0_v18 (System.Single), v543 @ V1_v18 (System.Single), v544 @ V2_v14 (System.Single)\n\tv393 = UnityEngine.Quaternion::Internal_MakePositive(v362);\n\tv388 = v393.y;\n\tv386 = v393.z;\n\tv148 = -*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]);\n\tv311.startValue = v393;\n\t*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]) = v393.y;\n\t// 265 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) = v393.z;\n\tv311.endValue = v311.endValue;\n\t*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) = v148;\n\tgoto L_011C;\nL_0113:\n\t// 275 MakeStruct v319 @ AGGC2567C_2_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v315 @ V0_v9 (System.Single), v309 @ V1_v8 (System.Single), v307 @ V2_v8 (System.Single)\n\tv393 = DG.Tweening.Plugins.QuaternionPlugin::GetEulerValForCalculations(v313, v311, v319, v188);\n\tv388 = v393.y;\n\tv386 = v393.z;\n\tv311.startValue = v393;\n\t*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]) = v393.y;\n\t*([v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) = v393.z;\nL_011C:\n\tv193 = v311.setter;\n\tv398 = v393 * 0.017453292f;\n\tv399 = v388 * 0.017453292f;\n\tv400 = v386 * 0.017453292f;\n\t// 289 MakeStruct v31 @ AGGC256A4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v398 @ V0_v7 (System.Single), v399 @ V1_v6 (System.Single), v400 @ V2_v6 (System.Single)\n\tv189 = UnityEngine.Quaternion::Internal_FromEulerRad(v31);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(v311.setter, v193.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool isRelative)
		{
			//IL_003c: Expected F4, but got O
			//IL_0049: Expected F4, but got O
			//IL_0056: Expected F4, but got O
			//IL_0b2c: Expected O, but got I
			//IL_0af6: Expected F4, but got I
			//IL_0c98: Expected F4, but got I
			//IL_0833: Expected O, but got F4
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = default(TweenerCore<Quaternion, Vector3, QuaternionOptions>);
			object obj = tweenerCore.getter();
			Quaternion rotation = default(Quaternion);
			rotation.x = tweenerCore.endValue.x;
			object obj2 = default(object);
			rotation.y = (float)obj2;
			object obj3 = default(object);
			rotation.z = (float)obj3;
			object obj4 = default(object);
			rotation.w = (float)obj4;
			Vector3 vector = Quaternion.Internal_ToEulerRad(rotation);
			float x = vector.x * 57.29578f;
			float y = vector.y * 57.29578f;
			float z = vector.z * 57.29578f;
			Vector3 euler = default(Vector3);
			euler.x = x;
			euler.y = y;
			euler.z = z;
			Vector3 vector2 = Quaternion.Internal_MakePositive(euler);
			bool flag = (nint)tweenerCore.plugOptions == 1;
			tweenerCore.endValue = vector2;
			_ = vector2.y;
			_ = vector2.z;
			Vector3 startValue;
			float y4;
			float z7;
			float z8;
			float y5;
			float x6;
			float y2;
			float num98;
			if (!flag)
			{
				float num29 = default(float);
				if ((object)tweenerCore.plugOptions != null || tweenerCore._003CisRelative_003Ek__BackingField)
				{
					object obj5 = tweenerCore.getter();
					float num55;
					float num56;
					float num57;
					float num74;
					float x3;
					float num75;
					float z3;
					Quaternion quaternion3;
					if ((nint)tweenerCore.plugOptions == 2)
					{
						Quaternion rotation2 = default(Quaternion);
						rotation2.x = vector2.x;
						rotation2.y = vector2.y;
						rotation2.z = vector2.z;
						rotation2.w = vector2.x;
						Quaternion quaternion = Quaternion.Inverse(rotation2);
						float num = vector2.x * quaternion.x;
						float num2 = vector2.x * quaternion.w;
						float num3 = vector2.x * quaternion.y;
						float num4 = vector2.y * quaternion.w;
						float num5 = num + num2;
						float num6 = vector2.x * quaternion.z;
						float num7 = num3 + num4;
						float num8 = vector2.z * quaternion.w;
						float num9 = vector2.x * quaternion.w;
						float num10 = num6 + num8;
						float num11 = vector2.x * quaternion.x;
						float num12 = num9 - num11;
						float num13 = vector2.y * quaternion.z;
						float num14 = num13 + num5;
						float num15 = vector2.z * quaternion.x;
						float num16 = num15 + num7;
						float num17 = vector2.x * quaternion.y;
						float num18 = num17 + num10;
						float num19 = vector2.z * quaternion.y;
						float num20 = vector2.y * quaternion.y;
						float num21 = num12 - num20;
						float num22 = vector2.x * quaternion.z;
						float num23 = vector2.z * quaternion.z;
						float num24 = num16 - num22;
						float num25 = num14 - num19;
						float num26 = num21 - num23;
						float num27 = vector2.y * quaternion.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
						float x2 = tweenerCore.endValue.x * quaternion.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
						float z2 = 0f * ((float)Math.PI / 180f);
						float num28 = num18 - num27;
						Vector3 vector3 = default(Vector3);
						vector3.x = x2;
						vector3.y = num29;
						vector3.z = z2;
						Quaternion quaternion2 = Quaternion.Euler(vector3 * 57.29578f);
						float num30 = quaternion2.x * num26;
						float num31 = quaternion2.w * num25;
						float num32 = quaternion2.y * num28;
						float num33 = quaternion2.y * num26;
						float num34 = quaternion2.w * num24;
						float num35 = quaternion2.x * num28;
						float num36 = quaternion2.y * num25;
						float num37 = quaternion2.x * num25;
						float num38 = quaternion2.x * num24;
						float num39 = quaternion2.y * num24;
						float num40 = quaternion2.z * num26;
						float num41 = quaternion2.w * num26;
						float num42 = quaternion2.w * num28;
						float num43 = quaternion2.z * num24;
						float num44 = quaternion2.z * num25;
						float num45 = quaternion2.z * num28;
						float num46 = num30 + num31;
						float num47 = num33 + num34;
						float num48 = num40 + num42;
						float num49 = num41 - num37;
						float num50 = num43 + num46;
						float num51 = num35 + num47;
						float num52 = num49 - num39;
						float num53 = num36 + num48;
						float num54 = num50 - num32;
						num55 = num51 - num44;
						num56 = num52 - num45;
						num57 = num53 - num38;
						float num58 = vector2.x * num56;
						float num59 = vector2.x * num54;
						float num60 = vector2.y * num56;
						float num61 = vector2.x * num55;
						float num62 = vector2.z * num55;
						float num63 = vector2.x * num57;
						float num64 = num58 + num59;
						float num65 = vector2.z * num56;
						float num66 = num60 + num61;
						float num67 = vector2.x * num57;
						float num68 = vector2.y * num57;
						float num69 = vector2.z * num54;
						float num70 = num65 + num67;
						float num71 = vector2.y * num54;
						float num72 = num62 + num64;
						float num73 = num63 + num66;
						num74 = num71 + num70;
						x3 = num72 - num68;
						y2 = num73 - num69;
						num75 = vector2.x * num55;
						z3 = vector2.z;
						quaternion3 = (Quaternion)num54;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
						float x4 = tweenerCore.endValue.x * vector2.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
						float z4 = 0f * ((float)Math.PI / 180f);
						Vector3 vector4 = default(Vector3);
						vector4.x = x4;
						vector4.y = num29;
						vector4.z = z4;
						quaternion3 = Quaternion.Euler(vector4 * 57.29578f);
						num55 = quaternion3.y;
						num57 = quaternion3.z;
						num56 = quaternion3.w;
						float num76 = vector2.x * quaternion3.x;
						float num77 = vector2.x * quaternion3.w;
						float num78 = vector2.x * quaternion3.y;
						float num79 = vector2.y * quaternion3.w;
						float num80 = num76 + num77;
						float num81 = vector2.x * quaternion3.z;
						float num82 = num78 + num79;
						float num83 = vector2.z * quaternion3.w;
						float num84 = num81 + num83;
						float num85 = vector2.y * quaternion3.z;
						float num86 = num85 + num80;
						float num87 = vector2.z * quaternion3.x;
						float num88 = num87 + num82;
						float num89 = vector2.x * quaternion3.y;
						num74 = num89 + num84;
						float num90 = vector2.z * quaternion3.y;
						x3 = num86 - num90;
						float num91 = vector2.x * quaternion3.z;
						y2 = num88 - num91;
						num75 = vector2.y * quaternion3.x;
						z3 = vector2.z;
					}
					float num92 = vector2.x * num56;
					float num93 = vector2.x * quaternion3.x;
					float num94 = vector2.y * num55;
					float num95 = num92 - num93;
					float z5 = num74 - num75;
					float num96 = num95 - num94;
					float num97 = z3 * num57;
					float w = num96 - num97;
					Quaternion rotation3 = default(Quaternion);
					rotation3.x = x3;
					rotation3.y = y2;
					rotation3.z = z5;
					rotation3.w = w;
					Vector3 vector5 = Quaternion.Internal_ToEulerRad(rotation3);
					float x5 = vector5.x * 57.29578f;
					float y3 = vector5.y * 57.29578f;
					float z6 = vector5.z * 57.29578f;
					Vector3 euler2 = default(Vector3);
					euler2.x = x5;
					euler2.y = y3;
					euler2.z = z6;
					startValue = Quaternion.Internal_MakePositive(euler2);
					y4 = startValue.y;
					z7 = startValue.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
					num98 = -0;
					tweenerCore.startValue = startValue;
					_ = startValue.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					_ = startValue.z;
					tweenerCore.endValue = tweenerCore.endValue;
					goto IL_0d76;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
				z8 = 0f;
				y5 = num29;
				x6 = tweenerCore.endValue.x;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X1_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
				z8 = 0f + vector2.z;
				x6 = tweenerCore.endValue.x + vector2.x;
				object obj6 = default(object);
				y5 = (float)obj6 + vector2.y;
			}
			Vector3 val = default(Vector3);
			val.x = x6;
			val.y = y5;
			val.z = z8;
			startValue = GetEulerValForCalculations(tweenerCore, val, vector2);
			y4 = startValue.y;
			z7 = startValue.z;
			tweenerCore.startValue = startValue;
			_ = startValue.y;
			_ = startValue.z;
			y2 = vector2.z;
			num98 = vector2.y;
			goto IL_0d76;
			IL_0d76:
			DOSetter<Quaternion> setter = tweenerCore.setter;
			float x7 = startValue.x * ((float)Math.PI / 180f);
			float y6 = y4 * ((float)Math.PI / 180f);
			float z9 = z7 * ((float)Math.PI / 180f);
			Vector3 vector6 = default(Vector3);
			vector6.x = x7;
			vector6.y = y6;
			vector6.z = z9;
			Quaternion quaternion4 = Quaternion.Euler(vector6 * 57.29578f);
			tweenerCore.setter((Quaternion)(nint)setter.method);
		}

		[Token(Token = "0x6000312")]
		[Address(RVA = "0xC2196C", Offset = "0xC2196C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = isRelative == 0;\n\tif (v28) goto L_FFFFFFFF;\n\tv124 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::Invoke(t.getter);\n\t// 29 MakeStruct v101 @ AGGC259B8_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), fromValue @ V0 (UnityEngine.Vector3), fromValue.y (System.Single), fromValue.z (System.Single), v55 @ V3\n\tv126 = UnityEngine.Quaternion::Internal_ToEulerRad(v101);\n\tv134 = v126 * 57.29578f;\n\tv135 = v126.y * 57.29578f;\n\tv136 = v126.z * 57.29578f;\n\t// 39 MakeStruct v96 @ AGGC259D4_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v134 @ V0_v8 (System.Single), v135 @ V1_v9 (System.Single), v136 @ V2_v10 (System.Single)\n\tv137 = UnityEngine.Quaternion::Internal_MakePositive(v96);\n\tv110 = fromValue + v137;\n\tv79 = fromValue.y + v137.y;\n\tv100 = t.endValue + v137;\n\tv116 = v137.z + *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]);\n\tt.endValue = v100;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) = v116;\n\tv81 = fromValue.z + v137.z;\n\tgoto L_0040;\nL_0040:\n\t// 64 MakeStruct v41 @ AGGC25A28_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v77 @ V10_v3 (UnityEngine.Vector3), v79 @ V9_v3 (System.Single), v81 @ V8_v3 (System.Single)\n\tv122 = DG.Tweening.Plugins.QuaternionPlugin::GetEulerValForCalculations(this, t, v41, t.endValue);\n\tt.startValue = v122;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]) = v122.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) = v122.z;\n\tv130 = setImmediately == 0;\n\tif (v130) goto L_006D;\n\tv75 = t.setter;\n\tv181 = v77 * 0.017453292f;\n\tv182 = v79 * 0.017453292f;\n\tv183 = v81 * 0.017453292f;\n\t// 82 MakeStruct v35 @ AGGC25A58_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v181 @ V0_v5 (System.Single), v182 @ V1_v6 (System.Single), v183 @ V2_v7 (System.Single)\n\tv58 = UnityEngine.Quaternion::Internal_FromEulerRad(v35);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(t.setter, v75.method);\nL_006D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Vector3 fromValue, bool setImmediately, bool isRelative)
		{
			//IL_0078: Expected F4, but got O
			//IL_0176: Expected O, but got F4
			//IL_019c: Expected O, but got F4
			//IL_02e9: Expected O, but got I
			float num2;
			float num6;
			Vector3 vector4;
			if (isRelative)
			{
				object obj = t.getter();
				Quaternion rotation = default(Quaternion);
				Vector3 vector = default(Vector3);
				rotation.x = vector.x;
				rotation.y = fromValue.y;
				rotation.z = fromValue.z;
				object obj2 = default(object);
				rotation.w = (float)obj2;
				Vector3 vector2 = Quaternion.Internal_ToEulerRad(rotation);
				float x = vector2.x * 57.29578f;
				float y = vector2.y * 57.29578f;
				float z = vector2.z * 57.29578f;
				Vector3 euler = default(Vector3);
				euler.x = x;
				euler.y = y;
				euler.z = z;
				Vector3 vector3 = Quaternion.Internal_MakePositive(euler);
				float num = vector.x + vector3.x;
				num2 = fromValue.y + vector3.y;
				float num3 = t.endValue.x + vector3.x;
				float num4 = vector3.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
				float num5 = num4 + 0f;
				t.endValue = (Vector3)num3;
				num6 = fromValue.z + vector3.z;
				vector4 = (Vector3)num;
			}
			else
			{
				vector4 = fromValue;
				num2 = fromValue.y;
				num6 = fromValue.z;
			}
			Vector3 val = default(Vector3);
			val.x = vector4.x;
			val.y = num2;
			val.z = num6;
			Vector3 vector5 = (t.startValue = GetEulerValForCalculations(t, val, t.endValue));
			_ = vector5.y;
			_ = vector5.z;
			if (setImmediately)
			{
				DOSetter<Quaternion> setter = t.setter;
				float x2 = vector4.x * ((float)Math.PI / 180f);
				float y2 = num2 * ((float)Math.PI / 180f);
				float z2 = num6 * ((float)Math.PI / 180f);
				Vector3 vector6 = default(Vector3);
				vector6.x = x2;
				vector6.y = y2;
				vector6.z = z2;
				Quaternion quaternion = Quaternion.Euler(vector6 * 57.29578f);
				t.setter((Quaternion)(nint)setter.method);
			}
		}

		[Token(Token = "0x6000313")]
		[Address(RVA = "0xC21A98", Offset = "0xC21A98", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 6 MakeStruct v7 @ AGGC25AA0_0_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>), [value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+4], [value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+8], [value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+C]\n\tv8 = UnityEngine.Quaternion::Internal_ToEulerRad(v7);\n\tv14 = v8 * 57.29578f;\n\tv15 = v8.y * 57.29578f;\n\tv16 = v8.z * 57.29578f;\n\t// 18 MakeStruct v18 @ AGGC25AC0_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v14 @ V0_v2 (System.Single), v15 @ V1_v3 (System.Single), v16 @ V2_v3 (System.Single)\n\treturnVal1 = UnityEngine.Quaternion::Internal_MakePositive(v18);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector3 ConvertToStartValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Quaternion value)
		{
			//IL_000d: Expected F4, but got O
			//IL_0022: Expected F4, but got I
			//IL_0037: Expected F4, but got I
			//IL_004c: Expected F4, but got I
			Quaternion rotation = default(Quaternion);
			rotation.x = (float)value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+4]");
			rotation.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+8]");
			rotation.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ V0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+C]");
			rotation.w = 0f;
			Vector3 vector = Quaternion.Internal_ToEulerRad(rotation);
			float x = vector.x * 57.29578f;
			float y = vector.y * 57.29578f;
			float z = vector.z * 57.29578f;
			Vector3 euler = default(Vector3);
			euler.x = x;
			euler.y = y;
			euler.z = z;
			return Quaternion.Internal_MakePositive(euler);
		}

		[Token(Token = "0x6000314")]
		[Address(RVA = "0xC21AC4", Offset = "0xC21AC4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = t.endValue + t.startValue;\n\tv10 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) + *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]);\n\tt.endValue = v9;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) = v10;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
			//IL_0040: Expected O, but got I
			//IL_004d: Expected O, but got F4
			float num = t.endValue.x + t.startValue.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
			object obj = num2 + 0;
			t.endValue = (Vector3)num;
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0xC21AFC", Offset = "0xC21AFC", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv230 = v62.endValue;\n\tv253 = *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+134]);\n\tv200 = *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]);\n\tv25 = ~v62.isFrom;\n\tv26 = ~v25;\n\tif (v26) goto L_002B;\n\tv52 = DG.Tweening.Plugins.QuaternionPlugin::GetEulerValForCalculations(this, v62, v62.endValue, v62.startValue);\nL_002B:\n\tv80 = v62.plugOptions == 1;\n\tif (v80) goto L_013C;\n\tv85 = v62.plugOptions == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_013A;\n\tv177 = ~v62.<isRelative>k__BackingField;\n\tv92 = ~v177;\n\tif (v92) goto L_013C;\n\tv210 = 0x1854EF0(this, v62, methodInfo, v30, v31, v32, v33, v34, v230, 0x43B40000, v52.z, v62.startValue, *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]), *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]), v41, v42);\n\tv213 = v230 - 0x43B40000;\n\tv214 = v213 < 0;\n\tv215 = v213 == 0;\n\tv216 = v230 ^ 0x43B40000;\n\tv217 = v230 ^ v213;\n\tv218 = v216 & v217;\n\tv219 = v218 < 0;\n\tv220 = v230 >= 0x43B40000;\n\tif (v220) goto L_FFFFFFFF;\n\tgoto L_004C;\nL_004C:\n\tv224 = v214 == v219;\n\tv225 = ~v215;\n\tv226 = v224 & v225;\n\tv227 = ~v226;\n\tif (v227) goto L_FFFFFFFF;\n\tgoto L_0057;\nL_0057:\n\tv233 = 0x1854EF0(v210, v62, methodInfo, v30, v31, v32, v33, v34, v253, 0x43B40000, v52.z, v62.startValue, *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]), *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]), v41, v42);\n\tv236 = v253 - 0x43B40000;\n\tv237 = v236 < 0;\n\tv238 = v236 == 0;\n\tv239 = v253 ^ 0x43B40000;\n\tv240 = v253 ^ v236;\n\tv241 = v239 & v240;\n\tv242 = v241 < 0;\n\tv243 = v253 >= 0x43B40000;\n\tif (v243) goto L_FFFFFFFF;\n\tgoto L_0067;\nL_0067:\n\tv247 = v237 == v242;\n\tv248 = ~v238;\n\tv249 = v247 & v248;\n\tv250 = ~v249;\n\tif (v250) goto L_FFFFFFFF;\n\tgoto L_0072;\nL_0072:\n\tv192 = 0x1854EF0(v233, v62, methodInfo, v30, v31, v32, v33, v34, v200, 0x43B40000, v52.z, v62.startValue, *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]), *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]), v41, v42);\n\tv258 = v200 - 0x43B40000;\n\tv259 = v258 < 0;\n\tv260 = v258 == 0;\n\tv261 = v200 ^ 0x43B40000;\n\tv262 = v200 ^ v258;\n\tv263 = v261 & v262;\n\tv264 = v263 < 0;\n\tv265 = v230 - v62.startValue;\n\tv266 = v200 >= 0x43B40000;\n\tif (v266) goto L_FFFFFFFF;\n\tgoto L_0083;\nL_0083:\n\tv270 = -v265;\n\tv271 = v259 == v264;\n\tv272 = ~v260;\n\tv273 = v271 & v272;\n\tv274 = ~v273;\n\tif (v274) goto L_FFFFFFFF;\n\tgoto L_0090;\nL_0090:\n\tv281 = v265 < 0;\n\tv282 = v265 == 0;\n\tv284 = v265 ^ v265;\n\tv285 = v265 & v284;\n\tv286 = v285 < 0;\n\tv288 = v281 == v286;\n\tv289 = ~v282;\n\tv290 = v288 & v289;\n\tv291 = ~v290;\n\tif (v291) goto L_FFFFFFFF;\n\tgoto L_00A1;\nL_00A1:\n\tv296 = v253 - *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]);\n\tv310 = v294 <= 0x43340000;\n\tif (v310) goto L_00C8;\n\tv313 = 0x43B40000 - v294;\n\tv314 = -v313;\n\tv318 = v265 < 0;\n\tv319 = v265 == 0;\n\tv321 = v265 ^ v265;\n\tv322 = v265 & v321;\n\tv323 = v322 < 0;\n\tv324 = v318 == v323;\n\tv325 = ~v319;\n\tv326 = v324 & v325;\n\tv327 = ~v326;\n\tif (v327) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_00C8:\n\tv364 = -v296;\n\tv349 = v296 < 0;\n\tv350 = v296 == 0;\n\tv352 = v296 ^ v296;\n\tv353 = v296 & v352;\n\tv354 = v353 < 0;\n\tv356 = v349 == v354;\n\tv357 = ~v350;\n\tv358 = v356 & v357;\n\tv359 = ~v358;\n\tif (v359) goto L_00E6;\n\tgoto L_00E6;\nL_00E6:\n\tv197 = v277 - *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]);\n\tv377 = v364 <= 0x43340000;\n\tif (v377) goto L_0102;\n\tv380 = 0x43B40000 - v364;\n\tv381 = -v380;\n\tv385 = v296 < 0;\n\tv386 = v296 == 0;\n\tv388 = v296 ^ v296;\n\tv389 = v296 & v388;\n\tv390 = v389 < 0;\n\tv391 = v385 == v390;\n\tv392 = ~v386;\n\tv393 = v391 & v392;\n\tv394 = ~v393;\n\tif (v394) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_0102:\n\tv196 = -v197;\n\tv416 = v197 < 0;\n\tv417 = v197 == 0;\n\tv419 = v197 ^ v197;\n\tv420 = v197 & v419;\n\tv421 = v420 < 0;\n\tv422 = v416 == v421;\n\tv423 = ~v417;\n\tv424 = v422 & v423;\n\tv425 = ~v424;\n\tif (v425) goto L_011A;\n\tgoto L_011A;\nL_011A:\n\tv195 = 0x43B40000 - v196;\n\tv198 = -v195;\n\tv432 = v416 == v421;\n\tv433 = ~v417;\n\tv434 = v432 & v433;\n\tv435 = ~v434;\n\tif (v435) goto L_0128;\n\tgoto L_0128;\nL_0128:\n\tv190 = v196 - 0x43340000;\n\tv189 = v190 < 0;\n\tv188 = v190 == 0;\n\tv187 = v196 ^ 0x43340000;\n\tv186 = v196 ^ v190;\n\tv185 = v187 & v186;\n\tv184 = v185 < 0;\n\tv439 = v189 == v184;\n\tv181 = ~v188;\n\tv182 = v439 & v181;\n\tv183 = ~v182;\n\tif (v183) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_013F;\nL_013A:\n\tv91 = ~v62.<isRelative>k__BackingField;\n\tif (v91) goto L_013F;\nL_013C:\n\tv93 = v230 - v62.startValue;\n\tv253 = v253 - *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]);\n\tv200 = v200 - *([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]);\nL_013F:\n\tv62.changeValue = v230;\n\t*([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+140]) = v253;\n\t*([v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]) = v200;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 167 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
			//IL_001d: Expected F4, but got I
			//IL_002d: Expected F4, but got I
			//IL_046c: Expected O, but got F4
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected I4, but got Unknown
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Expected O, but got Unknown
			//IL_04db: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e0: Expected O, but got Unknown
			//IL_051b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0520: Expected I4, but got Unknown
			//IL_052d: Expected O, but got F4
			//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b9: Expected O, but got Unknown
			//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f9: Expected I4, but got Unknown
			//IL_0606: Expected O, but got F4
			//IL_06da: Expected O, but got F4
			//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e8: Expected I4, but got Unknown
			//IL_0938: Expected O, but got F4
			//IL_0941: Unknown result type (might be due to invalid IL or missing references)
			//IL_0946: Expected I4, but got Unknown
			//IL_0285: Expected O, but got F4
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Expected I4, but got Unknown
			//IL_09cc: Expected O, but got F4
			//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_09da: Expected I4, but got Unknown
			//IL_0350: Expected O, but got F4
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Expected I4, but got Unknown
			//IL_0865: Unknown result type (might be due to invalid IL or missing references)
			//IL_086a: Expected I4, but got Unknown
			//IL_0877: Expected O, but got F4
			//IL_08e3: Expected O, but got F4
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = default(TweenerCore<Quaternion, Vector3, QuaternionOptions>);
			Vector3 vector = tweenerCore.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+134]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
			float num2 = 0f;
			if (!tweenerCore.isFrom)
			{
				Vector3 eulerValForCalculations = GetEulerValForCalculations(tweenerCore, tweenerCore.endValue, tweenerCore.startValue);
				num2 = eulerValForCalculations.z;
				num = eulerValForCalculations.y;
				vector = eulerValForCalculations;
			}
			if ((nint)tweenerCore.plugOptions == 1)
			{
				goto IL_0418;
			}
			if ((object)tweenerCore.plugOptions == null)
			{
				if (tweenerCore._003CisRelative_003Ek__BackingField)
				{
					goto IL_0418;
				}
				object obj = vector % 1135869952;
				float num3 = vector.x - 360f;
				bool flag = num3 < 0f;
				bool flag2 = num3 == 0f;
				int num4 = vector ^ 0x43B40000;
				object obj2 = vector ^ num3;
				int num5 = (int)(num4 & (nint)obj2);
				bool flag3 = num5 < 0;
				Vector3 vector2 = ((!(vector.x < 360f)) ? vector : vector);
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				if (!(flag4 && flag5))
				{
					vector = vector2;
				}
				object obj3 = num % 1135869952;
				float num6 = num - 360f;
				bool flag6 = num6 < 0f;
				bool flag7 = num6 == 0f;
				int num7 = num ^ 0x43B40000;
				object obj4 = num ^ num6;
				int num8 = (int)(num7 & (nint)obj4);
				bool flag8 = num8 < 0;
				float num9 = ((!(num < 360f)) ? num : num);
				bool flag9 = flag6 == flag8;
				bool flag10 = !flag7;
				if (!(flag9 && flag10))
				{
					num = num9;
				}
				object obj5 = num2 % 1135869952;
				float num10 = num2 - 360f;
				bool flag11 = num10 < 0f;
				bool flag12 = num10 == 0f;
				int num11 = num2 ^ 0x43B40000;
				object obj6 = num2 ^ num10;
				int num12 = (int)(num11 & (nint)obj6);
				bool flag13 = num12 < 0;
				float num13 = vector.x - tweenerCore.startValue.x;
				float num14 = ((!(num2 < 360f)) ? num2 : num2);
				float num15 = 0f - num13;
				bool flag14 = flag11 == flag13;
				bool flag15 = !flag12;
				float num16 = ((!(flag14 && flag15)) ? num14 : num2);
				bool flag16 = num13 < 0f;
				bool flag17 = num13 == 0f;
				object obj7 = num13 ^ num13;
				int num17 = num13 & (nint)obj7;
				bool flag18 = num17 < 0;
				bool flag19 = flag16 == flag18;
				bool flag20 = !flag17;
				float num18 = ((!(flag19 && flag20)) ? num15 : num13);
				float num19 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]");
				float num20 = num19 - 0f;
				bool flag21 = !(num18 > 180f);
				float num21 = num13;
				if (!flag21)
				{
					float num22 = 360f - num18;
					float num23 = 0f - num22;
					bool flag22 = num13 < 0f;
					bool flag23 = num13 == 0f;
					object obj8 = num13 ^ num13;
					int num24 = num13 & (nint)obj8;
					bool flag24 = num24 < 0;
					bool flag25 = flag22 == flag24;
					bool flag26 = !flag23;
					float num25 = ((!(flag25 && flag26)) ? num22 : num23);
					num21 = num25;
				}
				float num26 = 0f - num20;
				bool flag27 = num20 < 0f;
				bool flag28 = num20 == 0f;
				object obj9 = num20 ^ num20;
				int num27 = num20 & (nint)obj9;
				bool flag29 = num27 < 0;
				bool flag30 = flag27 == flag29;
				bool flag31 = !flag28;
				if (flag30 && flag31)
				{
					num26 = num20;
				}
				float num28 = num16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
				float num29 = num28 - 0f;
				bool flag32 = !(num26 > 180f);
				float num30 = num20;
				if (!flag32)
				{
					float num31 = 360f - num26;
					float num32 = 0f - num31;
					bool flag33 = num20 < 0f;
					bool flag34 = num20 == 0f;
					object obj10 = num20 ^ num20;
					int num33 = num20 & (nint)obj10;
					bool flag35 = num33 < 0;
					bool flag36 = flag33 == flag35;
					bool flag37 = !flag34;
					float num34 = ((!(flag36 && flag37)) ? num31 : num32);
					num30 = num34;
				}
				float num35 = 0f - num29;
				bool flag38 = num29 < 0f;
				bool flag39 = num29 == 0f;
				object obj11 = num29 ^ num29;
				int num36 = num29 & (nint)obj11;
				bool flag40 = num36 < 0;
				bool flag41 = flag38 == flag40;
				bool flag42 = !flag39;
				if (flag41 && flag42)
				{
					num35 = num29;
				}
				float num37 = 360f - num35;
				float num38 = 0f - num37;
				bool flag43 = flag38 == flag40;
				bool flag44 = !flag39;
				if (flag43 && flag44)
				{
					num37 = num38;
				}
				float num39 = num35 - 180f;
				bool flag45 = num39 < 0f;
				bool flag46 = num39 == 0f;
				int num40 = num35 ^ 0x43340000;
				object obj12 = num35 ^ num39;
				int num41 = (int)(num40 & (nint)obj12);
				bool flag47 = num41 < 0;
				bool flag48 = flag45 == flag47;
				bool flag49 = !flag46;
				if (flag48 && flag49)
				{
					num2 = num37;
				}
				else
				{
					num2 = num29;
				}
				num = num30;
				vector = (Vector3)num21;
			}
			else if (tweenerCore._003CisRelative_003Ek__BackingField)
			{
				goto IL_0418;
			}
			goto IL_08e8;
			IL_08e8:
			tweenerCore.changeValue = vector;
			return;
			IL_0418:
			float num42 = vector.x - tweenerCore.startValue.x;
			float num43 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+128]");
			num = num43 - 0f;
			float num44 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X1_v1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]");
			num2 = num44 - 0f;
			vector = (Vector3)num42;
			goto IL_08e8;
		}

		[Token(Token = "0x6000316")]
		[Address(RVA = "0xC21CC0", Offset = "0xC21CC0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv25 = System.Math;\n\tv26 = \"il2cpp_codegen_initialize_runtime_metadata\"(v25, options, methodInfo, v29, v30, v31, v32, v33, unitsXSecond, changeValue, v0, v2, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35759]) = v41;\nL_001D:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, options, methodInfo, v29, v30, v31, v32, v33, unitsXSecond, changeValue, v0, v2, v34, v35, v36, v37);\nL_001F:\n\tv50 = changeValue * changeValue;\n\tv51 = changeValue.y * changeValue.y;\n\tv52 = v50 + v51;\n\tv53 = changeValue.z * changeValue.z;\n\tv54 = v53 + v52;\n\tv55 = UnityEngine.Mathf::Sqrt(v54);\n\treturnVal1 = v55 / unitsXSecond;\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(QuaternionOptions options, float unitsXSecond, Vector3 changeValue)
		{
			Vector3 vector = default(Vector3);
			float num = vector.x * vector.x;
			float num2 = changeValue.y * changeValue.y;
			float num3 = num + num2;
			float num4 = changeValue.z * changeValue.z;
			float f = num4 + num3;
			float num5 = Mathf.Sqrt(f);
			return num5 / unitsXSecond;
		}

		[Token(Token = "0x6000317")]
		[Address(RVA = "0xC21D40", Offset = "0xC21D40", Length = "0x514")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv523 = v224.y;\n\tv521 = v224.z;\n\tgoto L_002E;\n\tv56 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>;\n\tv57 = changeValue;\n\tv58 = v3;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, options, t, isRelative, getter, setter, usingInversePosition, newCompletedSteps, elapsed, startValue, v0, v2, changeValue, v3, v5, duration);\n\tv74 = v58;\n\tv65 = v57;\n\tv72 = 1;\n\t*([1A35770]) = v72;\nL_002E:\n\tv77 = options.dynamicLookAt == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0035;\n\tgoto L_007E;\nL_0035:\n\tv80 = t == 0;\n\tif (v80) goto L_0065;\n\tgoto L_FFFFFFFF;\n\tv288 = v288_asT == 0;\n\tif (v288) goto L_01BD;\nL_0065:\n\t*([t @ X2 (DG.Tweening.Tween)+138]) = *([options @ X1 (DG.Tweening.Plugins.Options.QuaternionOptions)+20]);\n\t*([t @ X2 (DG.Tweening.Tween)+130]) = v300;\n\tv381 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetLookAt(t);\n\tv318 = DG.Tweening.Plugins.QuaternionPlugin::SetChangeValue(this, t);\n\tv252 = *([t @ X2 (DG.Tweening.Tween)+144]);\nL_007E:\n\tv154 = t.loopType != 2;\n\tif (v154) goto L_FFFFFFFF;\n\tv385 = t.completedLoops - t.isComplete;\n\tv387 = *([t @ X2 (DG.Tweening.Tween)+13C]) * v326;\n\tv388 = v252 * v385;\n\tv565 = startValue + v387;\n\tv111 = startValue.z + v388;\n\tgoto L_008D;\nL_008D:\n\tv396 = ~t.isSequenced;\n\tif (v396) goto L_00BF;\n\tv217 = t.sequenceParent;\n\tv535 = v217.loopType != 2;\n\tif (v535) goto L_00BF;\n\tv534 = t.loopType != 2;\n\tif (v534) goto L_00AE;\nL_00AE:\n\tv607 = *([t @ X2 (DG.Tweening.Tween)+13C]) * v326;\n\tv608 = v252 * v605;\n\tv564 = v217.completedLoops - v217.isComplete;\n\tv532 = v607 * v610;\n\tv530 = v608 * v564;\n\tv565 = v565 + v532;\n\tv111 = v111 + v530;\nL_00BF:\n\tv574 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, v408, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv578 = options.rotateMode & 0xFFFFFFFE;\n\tv156 = v578 != 2;\n\tif (v156) goto L_016B;\n\tv585 = startValue.z * 0.017453292f;\n\tv586 = startValue * 0.017453292f;\n\tv588 = startValue.y * 0.017453292f;\n\t// 215 MakeStruct v105 @ AGGC25F54_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v586 @ V0_v14 (System.Single), v588 @ V1_v12 (System.Single), v585 @ V2_v9 (System.Single)\n\tv589 = UnityEngine.Quaternion::Internal_FromEulerRad(v105);\n\tv250 = v574 * v326;\n\tv99 = v574 * v602;\n\tv253 = v252 * v574;\n\tv155 = options.rotateMode != 2;\n\tif (v155) goto L_0181;\n\tv622 = UnityEngine.Quaternion::Inverse(v589);\n\tv632 = v250 * 0.017453292f;\n\tv633 = v99 * 0.017453292f;\n\tv634 = v253 * 0.017453292f;\n\t// 260 MakeStruct v94 @ AGGC25FC4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v632 @ V0_v25 (System.Single), v633 @ V1_v22 (System.Single), v634 @ V2_v18 (System.Single)\n\tv138 = UnityEngine.Quaternion::Internal_FromEulerRad(v94);\n\tv698 = v589.w * v622;\n\tv699 = v589 * v622.w;\n\tv700 = v589.w * v622.z;\n\tv701 = v698 + v699;\n\tv702 = v589.z * v622.w;\n\tv703 = v589.w * v622.y;\n\tv704 = v589.y * v622.w;\n\tv705 = v589.z * v622;\n\tv706 = v700 + v702;\n\tv707 = v589.y * v622;\n\tv708 = v589.w * v622.w;\n\tv709 = v589 * v622;\n\tv710 = v589.y * v622.z;\n\tv711 = v589.z * v622.y;\n\tv712 = v703 + v704;\n\tv713 = v589 * v622.y;\n\tv714 = v589.y * v622.y;\n\tv715 = v708 - v709;\n\tv716 = v589 * v622.z;\n\tv717 = v589.z * v622.z;\n\tv718 = v710 + v701;\n\tv719 = v705 + v712;\n\tv720 = v713 + v706;\n\tv721 = v715 - v714;\n\tv722 = v718 - v711;\n\tv723 = v719 - v716;\n\tv724 = v720 - v707;\n\tv725 = v721 - v717;\n\tv726 = v138 * v725;\n\tv727 = v138.w * v722;\n\tv728 = v138.z * v723;\n\tv729 = v138.y * v724;\n\tv730 = v138.y * v725;\n\tv731 = v138.w * v723;\n\tv732 = v138 * v724;\n\tv733 = v138.z * v722;\n\tv652 = v138.y * v722;\n\tv734 = v138 * v722;\n\tv735 = v138 * v723;\n\tv736 = v138.y * v723;\n\tv737 = v138.z * v725;\n\tv738 = v138.w * v725;\n\tv739 = v138.w * v724;\n\tv740 = v138.z * v724;\n\tv741 = v726 + v727;\n\tv742 = v730 + v731;\n\tv743 = v737 + v739;\n\tv744 = v738 - v734;\n\tv745 = v728 + v741;\n\tv746 = v732 + v742;\n\tv747 = v652 + v743;\n\tv748 = v744 - v736;\n\tv749 = v745 - v729;\n\tv750 = v746 - v733;\n\tv751 = v747 - v735;\n\tv752 = v748 - v740;\n\tv753 = v589.w * v752;\n\tv754 = v589 * v749;\n\tv646 = v589.y * v749;\n\tv644 = v589.z * v752;\n\tv642 = v589.w * v751;\n\tv648 = v589.w * v750;\n\tv640 = v589.z * v749;\n\tv756 = v589.y * v752;\n\tv451 = setter.invoke_impl;\n\tv493 = setter.method_code;\n\tv482 = setter.method;\n\tv757 = v589.y * v750;\n\tv636 = v589 * v750;\n\tv523 = v589.z * v750;\n\tv655 = v589 * v751;\n\tv758 = v753 - v754;\n\tv759 = v644 + v642;\n\tv760 = v756 + v648;\n\tv408 = v589.z * v751;\n\tv763 = v758 - v757;\n\tv521 = v646 + v759;\n\tv764 = v655 + v760;\n\tv525 = v763 - v408;\n\tv527 = v521 - v636;\n\tv460 = v764 - v640;\n\tgoto L_01BA;\nL_016B:\n\tv593 = *([t @ X2 (DG.Tweening.Tween)+13C]) * v594;\n\tv595 = v565 + v593;\n\tv597 = v252 * v574;\n\t// 368 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv598 = v111 + v597;\n\tv599 = v595 * t.easePeriod;\n\tv600 = v598 * 0.017453292f;\n\t// 374 MakeStruct v91 @ AGGC26178_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v599 @ V0_v11 (System.Single), v602 @ V0.S1, v600 @ V2_v7 (System.Single)\n\tv139 = UnityEngine.Quaternion::Internal_FromEulerRad(v91);\n\tv460 = v139.y;\n\tv527 = v139.z;\n\tv525 = v139.w;\n\tv451 = setter.invoke_impl;\n\tv493 = setter.method_code;\n\tv482 = setter.method;\n\tgoto L_01BA;\nL_0181:\n\tv623 = v250 * 0.017453292f;\n\tv624 = v99 * 0.017453292f;\n\tv625 = v253 * 0.017453292f;\n\t// 389 MakeStruct v88 @ AGGC261A0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v623 @ V0_v17 (System.Single), v624 @ V1_v15 (System.Single), v625 @ V2_v11 (System.Single)\n\tv140 = UnityEngine.Quaternion::Internal_FromEulerRad(v88);\n\tv684 = v589.w * v140.w;\n\tv685 = v589 * v140;\n\tv408 = v589.z * v140.z;\n\tv643 = v589.w * v140.z;\n\tv641 = v589.z * v140.w;\n\tv635 = v589.y * v140;\n\tv647 = v589.y * v140.w;\n\tv654 = v589 * v140.z;\n\tv687 = v589.z * v140;\n\tv649 = v589.w * v140.y;\n\tv451 = setter.invoke_impl;\n\tv493 = setter.method_code;\n\tv482 = setter.method;\n\tv521 = v589.y * v140.y;\n\tv645 = v589 * v140.y;\n\tv689 = v684 - v685;\n\tv690 = v643 + v641;\n\tv523 = v649 + v647;\n\tv692 = v689 - v521;\n\tv693 = v645 + v690;\n\tv668 = v687 + v523;\n\tv525 = v692 - v408;\n\tv527 = v693 - v635;\n\tv460 = v668 - v654;\nL_01BA:\n\t// 442 IndirectJump v451 @ X2_v3 (System.IntPtr), v493 @ X0_v4 (System.IntPtr), v493 @ X0_v4 (System.IntPtr), v482 @ X1_v3 (System.IntPtr), v451 @ X2_v3 (System.IntPtr), isRelative @ X3 (System.Boolean), getter @ X4 (DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>), setter @ X5 (DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>), usingInversePosition @ X6 (System.Boolean), newCompletedSteps @ X7 (System.Int32), v139 @ V0_v12 (UnityEngine.Quaternion), v460 @ V1_v6 (System.Single), v527 @ V2_v4 (System.Single), v525 @ V3_v6 (System.Single), [t @ X2 (DG.Tweening.Tween)+13C], v523 @ V5_v3 (System.Single), v521 @ V6_v2 (System.Single), v408 @ V7_v1 (System.Single)\n\tthrow System.NullReferenceException;\nL_01BD:\n\tthrow System.InvalidCastException;\n// 250 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(QuaternionOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_00b8: Expected F4, but got I
			//IL_0d25: Expected I4, but got I8
			//IL_098e: Expected F4, but got O
			//IL_01b9: Expected F4, but got I4
			Vector3 vector = default(Vector3);
			float y = vector.y;
			float z = vector.z;
			float num;
			if (!options.dynamicLookAt)
			{
				num = vector.z;
			}
			else
			{
				if (t != null)
				{
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = t as TweenerCore<Quaternion, Vector3, QuaternionOptions>;
					if (tweenerCore == null)
					{
						throw new InvalidCastException();
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ X1 (DG.Tweening.Plugins.Options.QuaternionOptions)+20]");
				_ = 0;
				bool flag = SpecialPluginsUtils.SetLookAt((TweenerCore<Quaternion, Vector3, QuaternionOptions>)t);
				SetChangeValue((TweenerCore<Quaternion, Vector3, QuaternionOptions>)t);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X2 (DG.Tweening.Tween)+144]");
				num = 0f;
			}
			object obj = default(object);
			float num5;
			Vector3 vector2 = default(Vector3);
			float num6;
			if (t.loopType == LoopType.Incremental)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X2 (DG.Tweening.Tween)+13C]");
				float num3 = 0f * (float)obj;
				float num4 = num * (float)num2;
				num5 = vector2.x + num3;
				num6 = startValue.z + num4;
			}
			else
			{
				num6 = startValue.z;
				num5 = vector2.x;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					bool flag2 = t.loopType != LoopType.Incremental;
					float num7 = 1f;
					if (!flag2)
					{
						num7 = t.loops;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X2 (DG.Tweening.Tween)+13C]");
					float num8 = 0f * (float)obj;
					float num9 = num * num7;
					int num10 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					object obj2 = default(object);
					float num11 = num8 * (float)obj2;
					float num12 = num9 * (float)num10;
					num5 += num11;
					num6 += num12;
				}
			}
			float duration2 = default(float);
			float num13 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration2, t.easeOvershootOrAmplitude, t.easePeriod);
			int num14 = (int)((long)options.rotateMode & 0xFFFFFFFEL);
			object obj3 = default(object);
			if (num14 == 2)
			{
				float z2 = startValue.z * ((float)Math.PI / 180f);
				float x = vector2.x * ((float)Math.PI / 180f);
				float y2 = startValue.y * ((float)Math.PI / 180f);
				Vector3 vector3 = default(Vector3);
				vector3.x = x;
				vector3.y = y2;
				vector3.z = z2;
				Quaternion rotation = Quaternion.Euler(vector3 * 57.29578f);
				float num15 = num13 * (float)obj;
				float num16 = num13 * (float)obj3;
				float num17 = num * num13;
				if (options.rotateMode == RotateMode.WorldAxisAdd)
				{
					Quaternion quaternion = Quaternion.Inverse(rotation);
					float x2 = num15 * ((float)Math.PI / 180f);
					float y3 = num16 * ((float)Math.PI / 180f);
					float z3 = num17 * ((float)Math.PI / 180f);
					Vector3 vector4 = default(Vector3);
					vector4.x = x2;
					vector4.y = y3;
					vector4.z = z3;
					Quaternion quaternion2 = Quaternion.Euler(vector4 * 57.29578f);
					float num18 = rotation.w * quaternion.x;
					float num19 = rotation.x * quaternion.w;
					float num20 = rotation.w * quaternion.z;
					float num21 = num18 + num19;
					float num22 = rotation.z * quaternion.w;
					float num23 = rotation.w * quaternion.y;
					float num24 = rotation.y * quaternion.w;
					float num25 = rotation.z * quaternion.x;
					float num26 = num20 + num22;
					float num27 = rotation.y * quaternion.x;
					float num28 = rotation.w * quaternion.w;
					float num29 = rotation.x * quaternion.x;
					float num30 = rotation.y * quaternion.z;
					float num31 = rotation.z * quaternion.y;
					float num32 = num23 + num24;
					float num33 = rotation.x * quaternion.y;
					float num34 = rotation.y * quaternion.y;
					float num35 = num28 - num29;
					float num36 = rotation.x * quaternion.z;
					float num37 = rotation.z * quaternion.z;
					float num38 = num30 + num21;
					float num39 = num25 + num32;
					float num40 = num33 + num26;
					float num41 = num35 - num34;
					float num42 = num38 - num31;
					float num43 = num39 - num36;
					float num44 = num40 - num27;
					float num45 = num41 - num37;
					float num46 = quaternion2.x * num45;
					float num47 = quaternion2.w * num42;
					float num48 = quaternion2.z * num43;
					float num49 = quaternion2.y * num44;
					float num50 = quaternion2.y * num45;
					float num51 = quaternion2.w * num43;
					float num52 = quaternion2.x * num44;
					float num53 = quaternion2.z * num42;
					float num54 = quaternion2.y * num42;
					float num55 = quaternion2.x * num42;
					float num56 = quaternion2.x * num43;
					float num57 = quaternion2.y * num43;
					float num58 = quaternion2.z * num45;
					float num59 = quaternion2.w * num45;
					float num60 = quaternion2.w * num44;
					float num61 = quaternion2.z * num44;
					float num62 = num46 + num47;
					float num63 = num50 + num51;
					float num64 = num58 + num60;
					float num65 = num59 - num55;
					float num66 = num48 + num62;
					float num67 = num52 + num63;
					float num68 = num54 + num64;
					float num69 = num65 - num57;
					float num70 = num66 - num49;
					float num71 = num67 - num53;
					float num72 = num68 - num56;
					float num73 = num69 - num61;
					float num74 = rotation.w * num73;
					float num75 = rotation.x * num70;
					float num76 = rotation.y * num70;
					float num77 = rotation.z * num73;
					float num78 = rotation.w * num72;
					float num79 = rotation.w * num71;
					float num80 = rotation.z * num70;
					float num81 = rotation.y * num73;
					IntPtr invoke_impl = setter.invoke_impl;
					IntPtr method_code = setter.method_code;
					IntPtr method = setter.method;
					float num82 = rotation.y * num71;
					float num83 = rotation.x * num71;
					y = rotation.z * num71;
					float num84 = rotation.x * num72;
					float num85 = num74 - num75;
					float num86 = num77 + num78;
					float num87 = num81 + num79;
					duration2 = rotation.z * num72;
					float num88 = num85 - num82;
					z = num76 + num86;
					float num89 = num84 + num87;
					float num90 = num88 - duration2;
					float num91 = z - num83;
					float num92 = num89 - num80;
				}
				else
				{
					float x3 = num15 * ((float)Math.PI / 180f);
					float y4 = num16 * ((float)Math.PI / 180f);
					float z4 = num17 * ((float)Math.PI / 180f);
					Vector3 vector5 = default(Vector3);
					vector5.x = x3;
					vector5.y = y4;
					vector5.z = z4;
					Quaternion quaternion3 = Quaternion.Euler(vector5 * 57.29578f);
					float num93 = rotation.w * quaternion3.w;
					float num94 = rotation.x * quaternion3.x;
					duration2 = rotation.z * quaternion3.z;
					float num95 = rotation.w * quaternion3.z;
					float num96 = rotation.z * quaternion3.w;
					float num97 = rotation.y * quaternion3.x;
					float num98 = rotation.y * quaternion3.w;
					float num99 = rotation.x * quaternion3.z;
					float num100 = rotation.z * quaternion3.x;
					float num101 = rotation.w * quaternion3.y;
					IntPtr invoke_impl = setter.invoke_impl;
					IntPtr method_code = setter.method_code;
					IntPtr method = setter.method;
					z = rotation.y * quaternion3.y;
					float num102 = rotation.x * quaternion3.y;
					float num103 = num93 - num94;
					float num104 = num95 + num96;
					y = num101 + num98;
					float num105 = num103 - z;
					float num106 = num102 + num104;
					float num107 = num100 + y;
					float num90 = num105 - duration2;
					float num91 = num106 - num97;
					float num92 = num107 - num99;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X2 (DG.Tweening.Tween)+13C]");
				object obj4 = default(object);
				float num108 = 0f * (float)obj4;
				float num109 = num5 + num108;
				float num110 = num * num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				float num111 = num6 + num110;
				float x4 = num109 * t.easePeriod;
				float z5 = num111 * ((float)Math.PI / 180f);
				Vector3 vector6 = default(Vector3);
				vector6.x = x4;
				vector6.y = (float)obj3;
				vector6.z = z5;
				Quaternion quaternion4 = Quaternion.Euler(vector6 * 57.29578f);
				float num92 = quaternion4.y;
				float num91 = quaternion4.z;
				float num90 = quaternion4.w;
				IntPtr invoke_impl = setter.invoke_impl;
				IntPtr method_code = setter.method_code;
				IntPtr method = setter.method;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v451 @ X2_v3 (System.IntPtr) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000318")]
		[Address(RVA = "0xC216DC", Offset = "0xC216DC", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = ~t.<isRelative>k__BackingField;\n\tv33 = ~v32;\n\tif (v33) goto L_FFFFFFFF;\n\tv45 = t.plugOptions & 0xFFFFFFFE;\n\tv50 = v45 == 2;\n\tif (v50) goto L_FFFFFFFF;\n\tv244 = 0x43340000 - val;\n\tv127 = val.y + 0x43340000;\n\tv125 = val.z + 0x43340000;\n\tgoto L_003B;\n\tv350 = UnityEngine.Mathf;\n\tv351 = v5;\n\tv352 = \"il2cpp_codegen_initialize_runtime_metadata\"(v350, t, methodInfo, v37, v38, v39, v40, v41, v135, v0, v2, counterVal, v3, v5, v42, v43);\n\tv355 = v351;\n\tv354 = 1;\n\t*([1A357E1]) = v354;\nL_003B:\n\tv359 = UnityEngine.Mathf::Abs(counterVal);\n\tv379 = UnityEngine.Mathf::Abs(val);\n\tv364 = v359 - v379;\n\tv365 = v364 < 0;\n\tv366 = v364 == 0;\n\tv367 = v359 ^ v379;\n\tv368 = v359 ^ v364;\n\tv369 = v367 & v368;\n\tv370 = v369 < 0;\n\tv373 = v365 == v370;\n\tv374 = ~v366;\n\tv375 = v373 & v374;\n\tv376 = ~v375;\n\tif (v376) goto L_0052;\n\tgoto L_0052;\nL_0052:\n\tv62 = v379 * 1E-06f;\n\t// 83 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv381 = UnityEngine.Mathf::Abs(v244);\n\t// 86 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv382 = UnityEngine.Mathf::Abs(counterVal.y);\n\tv202 = v372.Epsilon * 8f;\n\tv385 = v62 - v202;\n\tv386 = v385 < 0;\n\tv387 = v385 == 0;\n\tv388 = v62 ^ v202;\n\tv389 = v62 ^ v385;\n\tv390 = v388 & v389;\n\tv391 = v390 < 0;\n\tv392 = v386 == v391;\n\tv393 = ~v387;\n\tv394 = v392 & v393;\n\tv395 = ~v394;\n\tif (v395) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_006D:\n\tv400 = 0x43340000 - v95;\n\tv401 = v400 < 0;\n\tv410 = v359 - v381;\n\tv411 = v410 < 0;\n\tv412 = v410 == 0;\n\tv413 = v359 ^ v381;\n\tv414 = v359 ^ v410;\n\tv415 = v413 & v414;\n\tv416 = v415 < 0;\n\tv417 = v411 == v416;\n\tv418 = ~v412;\n\tv419 = v417 & v418;\n\tv420 = ~v419;\n\tif (v420) goto L_FFFFFFFF;\n\tgoto L_0087;\nL_0087:\n\tv424 = v423 * 1E-06f;\n\tv427 = v424 - v202;\n\tv428 = v427 < 0;\n\tv429 = v427 == 0;\n\tv430 = v424 ^ v202;\n\tv431 = v424 ^ v427;\n\tv432 = v430 & v431;\n\tv433 = v432 < 0;\n\tv434 = v428 == v433;\n\tv435 = ~v429;\n\tv436 = v434 & v435;\n\tv437 = ~v436;\n\tif (v437) goto L_FFFFFFFF;\n\tgoto L_009A;\nL_009A:\n\tv440 = UnityEngine.Mathf::Abs(val.y);\n\tv443 = counterVal.y - v92;\n\tv444 = v443 < 0;\n\tv453 = v382 - v440;\n\tv454 = v453 < 0;\n\tv455 = v453 == 0;\n\tv456 = v382 ^ v440;\n\tv457 = v382 ^ v453;\n\tv458 = v456 & v457;\n\tv459 = v458 < 0;\n\tv460 = v454 == v459;\n\tv461 = ~v455;\n\tv462 = v460 & v461;\n\tv463 = ~v462;\n\tif (v463) goto L_FFFFFFFF;\n\tgoto L_00B7;\nL_00B7:\n\tv64 = v466 * 1E-06f;\n\tv469 = v64 - v202;\n\tv470 = v469 < 0;\n\tv471 = v469 == 0;\n\tv472 = v64 ^ v202;\n\tv473 = v64 ^ v469;\n\tv474 = v472 & v473;\n\tv475 = v474 < 0;\n\t// 193 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv476 = v470 == v475;\n\tv477 = ~v471;\n\tv478 = v476 & v477;\n\tv479 = ~v478;\n\tif (v479) goto L_FFFFFFFF;\n\tgoto L_00CB;\nL_00CB:\n\tv482 = UnityEngine.Mathf::Abs(v127);\n\tv485 = val.y - v86;\n\tv486 = v485 < 0;\n\tv495 = v382 - v482;\n\tv496 = v495 < 0;\n\tv497 = v495 == 0;\n\tv498 = v382 ^ v482;\n\tv499 = v382 ^ v495;\n\tv500 = v498 & v499;\n\tv501 = v500 < 0;\n\tv502 = v496 == v501;\n\tv503 = ~v497;\n\tv504 = v502 & v503;\n\tv505 = ~v504;\n\tif (v505) goto L_FFFFFFFF;\n\tgoto L_00E8;\nL_00E8:\n\tv509 = v508 * 1E-06f;\n\tv512 = v509 - v202;\n\tv513 = v512 < 0;\n\tv514 = v512 == 0;\n\tv515 = v509 ^ v202;\n\tv516 = v509 ^ v512;\n\tv517 = v515 & v516;\n\tv518 = v517 < 0;\n\t// 242 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv519 = v513 == v518;\n\tv520 = ~v514;\n\tv521 = v519 & v520;\n\tv522 = ~v521;\n\tif (v522) goto L_FFFFFFFF;\n\tgoto L_00FC;\nL_00FC:\n\tv59 = UnityEngine.Mathf::Abs(counterVal.z);\n\tv79 = UnityEngine.Mathf::Abs(val.z);\n\tv528 = v526 - v98;\n\tv529 = v528 < 0;\n\tv538 = v59 - v79;\n\tv539 = v538 < 0;\n\tv540 = v538 == 0;\n\tv541 = v59 ^ v79;\n\tv542 = v59 ^ v538;\n\tv543 = v541 & v542;\n\tv544 = v543 < 0;\n\tv545 = v539 == v544;\n\tv546 = ~v540;\n\tv547 = v545 & v546;\n\tv548 = ~v547;\n\tif (v548) goto L_FFFFFFFF;\n\tgoto L_011A;\nL_011A:\n\tv118 = v551 * 1E-06f;\n\tv554 = v118 - v202;\n\tv555 = v554 < 0;\n\tv556 = v554 == 0;\n\tv557 = v118 ^ v202;\n\tv558 = v118 ^ v554;\n\tv559 = v557 & v558;\n\tv560 = v559 < 0;\n\t// 292 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv561 = v555 == v560;\n\tv562 = ~v556;\n\tv563 = v561 & v562;\n\tv564 = ~v563;\n\tif (v564) goto L_FFFFFFFF;\n\tgoto L_0130;\nL_0130:\n\tv570 = counterVal - v567;\n\tv571 = v570 < 0;\n\tv594 = UnityEngine.Mathf::Abs(v125);\n\tv581 = v59 - v594;\n\tv582 = v581 < 0;\n\tv583 = v581 == 0;\n\tv584 = v59 ^ v594;\n\tv585 = v59 ^ v581;\n\tv586 = v584 & v585;\n\tv587 = v586 < 0;\n\tv588 = v582 == v587;\n\tv589 = ~v583;\n\tv590 = v588 & v589;\n\tv591 = ~v590;\n\tif (v591) goto L_014B;\n\tgoto L_014B;\nL_014B:\n\tv76 = v594 * 1E-06f;\n\tv56 = v486 | v571;\n\tv598 = v76 - v202;\n\tv599 = v598 < 0;\n\tv600 = v598 == 0;\n\tv601 = v76 ^ v202;\n\tv602 = v76 ^ v598;\n\tv603 = v601 & v602;\n\tv604 = v603 < 0;\n\t// 342 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv605 = v486 & v571;\n\tv606 = v401 & v56;\n\tv607 = v599 == v604;\n\tv107 = ~v600;\n\tv608 = v607 & v107;\n\tv101 = ~v608;\n\tif (v101) goto L_FFFFFFFF;\n\tgoto L_0162;\nL_0162:\n\tv139 = v605 | v606;\n\tv180 = v79 - v76;\n\tv613 = v180 < 0;\n\tv616 = ~v139;\n\tv617 = v444 & v616;\n\tv168 = ~v617;\n\tv112 = ~v168;\n\tv619 = v139 == 0;\n\tv620 = ~v619;\n\tif (v620) goto L_019F;\n\tv72 = v529 & v613;\n\tv622 = v72 == 0;\n\tv623 = ~v622;\n\tif (v623) goto L_019F;\n\tv636 = v529 | v613;\n\tv192 = v112 & v636;\n\tv637 = ~v192;\n\tv195 = ~v637;\n\tif (v195) goto L_019F;\nL_0194:\n\treturn v244;\nL_019F:\n\tv635 = val.y >= v86;\n\tif (v635) goto L_FFFFFFFF;\n\tgoto L_01AE;\nL_01AE:\n\tv650 = 0x43340000 >= v95;\n\tif (v650) goto L_FFFFFFFF;\n\tgoto L_01BD;\nL_01BD:\n\tv662 = v526 >= v98;\n\tif (v662) goto L_FFFFFFFF;\n\tgoto L_01CC;\nL_01CC:\n\tv675 = counterVal.y >= v92;\n\tif (v675) goto L_FFFFFFFF;\n\tgoto L_01D6;\nL_01D6:\n\tv683 = v139 == 0;\n\tv114 = ~v683;\n\tv103 = ~v114;\n\tif (v103) goto L_01E6;\n\tgoto L_01E6;\nL_01E6:\n\tv694 = v193 == 2;\n\tif (v694) goto L_0219;\n\tv170 = v193 == 1;\n\tif (v170) goto L_0253;\n\tv711 = v193 == 0;\n\tv196 = ~v711;\n\tif (v196) goto L_FFFFFFFF;\n\tv727 = v64 - v202;\n\tv728 = v727 < 0;\n\tv729 = v727 == 0;\n\tv730 = v64 ^ v202;\n\tv731 = v64 ^ v727;\n\tv732 = v730 & v731;\n\tv733 = v732 < 0;\n\tv734 = v728 == v733;\n\tv232 = ~v729;\n\tv735 = v734 & v232;\n\tv228 = ~v735;\n\tif (v228) goto L_FFFFFFFF;\n\tgoto L_0214;\nL_0214:\n\tv236 = val.y >= v248;\n\tif (v236) goto L_0194;\n\tgoto L_0270;\nL_0219:\n\tv702 = v62 - v202;\n\tv703 = v702 < 0;\n\tv704 = v702 == 0;\n\tv705 = v62 ^ v202;\n\tv706 = v62 ^ v702;\n\tv707 = v705 & v706;\n\tv708 = v707 < 0;\n\tv709 = v703 == v708;\n\tv233 = ~v704;\n\tv710 = v709 & v233;\n\tv229 = ~v710;\n\tif (v229) goto L_FFFFFFFF;\n\tgoto L_0232;\nL_0232:\n\tv237 = 0x43340000 >= v70;\n\tif (v237) goto L_0194;\n\tv744 = v64 - v202;\n\tv745 = v744 < 0;\n\tv746 = v744 == 0;\n\tv747 = v64 ^ v202;\n\tv748 = v64 ^ v744;\n\tv749 = v747 & v748;\n\tv750 = v749 < 0;\n\tv751 = v745 == v750;\n\tv109 = ~v746;\n\tv115 = v751 & v109;\n\tv104 = ~v115;\n\tif (v104) goto L_FFFFFFFF;\n\tgoto L_0249;\nL_0249:\n\tv177 = val.y < v136;\n\tif (v177) goto L_FFFFFFFF;\n\tgoto L_0194;\nL_0253:\n\tv714 = v62 - v202;\n\tv715 = v714 < 0;\n\tv716 = v714 == 0;\n\tv717 = v62 ^ v202;\n\tv718 = v62 ^ v714;\n\tv719 = v717 & v718;\n\tv720 = v719 < 0;\n\tv721 = v715 == v720;\n\tv234 = ~v716;\n\tv722 = v721 & v234;\n\tv230 = ~v722;\n\tif (v230) goto L_FFFFFFFF;\n\tgoto L_026C;\nL_026C:\n\tv238 = 0x43340000 >= v288;\n\tif (v238) goto L_0194;\nL_0270:\n\tv767 = v118 - v202;\n\tv768 = v767 < 0;\n\tv769 = v767 == 0;\n\tv770 = v118 ^ v202;\n\tv771 = v118 ^ v767;\n\tv772 = v770 & v771;\n\tv773 = v772 < 0;\n\tv774 = v768 == v773;\n\tv110 = ~v769;\n\tv116 = v774 & v110;\n\tv105 = ~v116;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_0283;\nL_0283:\n\tv178 = counterVal < v137;\n\tif (v178) goto L_FFFFFFFF;\n\tgoto L_0194;\n\tthrow System.NullReferenceException;\n\treturn val;\n// 322 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector3 GetEulerValForCalculations(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Vector3 val, Vector3 counterVal)
		{
			//IL_128e: Expected O, but got F4
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected I4, but got Unknown
			//IL_074d: Expected O, but got F4
			//IL_075a: Expected O, but got F4
			//IL_0849: Expected O, but got F4
			//IL_0856: Expected O, but got F4
			//IL_0912: Expected O, but got F4
			//IL_091f: Expected O, but got F4
			//IL_09ca: Expected O, but got F4
			//IL_09d7: Expected O, but got F4
			//IL_0aa9: Expected O, but got F4
			//IL_0ab6: Expected O, but got F4
			//IL_0b61: Expected O, but got F4
			//IL_0b6e: Expected O, but got F4
			//IL_0c45: Expected O, but got F4
			//IL_0c52: Expected O, but got F4
			//IL_0cfd: Expected O, but got F4
			//IL_0d0a: Expected O, but got F4
			//IL_0df3: Expected O, but got F4
			//IL_0e00: Expected O, but got F4
			//IL_0eab: Expected O, but got F4
			//IL_0eb8: Expected O, but got F4
			//IL_0f8f: Expected O, but got F4
			//IL_0f9c: Expected O, but got F4
			//IL_1054: Expected O, but got F4
			//IL_1061: Expected O, but got F4
			//IL_0417: Expected O, but got F4
			//IL_0424: Expected O, but got F4
			//IL_05a0: Expected O, but got F4
			//IL_05ad: Expected O, but got F4
			//IL_04d9: Expected O, but got F4
			//IL_04e6: Expected O, but got F4
			//IL_0350: Expected O, but got F4
			//IL_035d: Expected O, but got F4
			//IL_0662: Expected O, but got F4
			//IL_066f: Expected O, but got F4
			float num2;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num10;
			float num46;
			if (!t._003CisRelative_003Ek__BackingField)
			{
				int num = (int)(t.plugOptions & 0xFFFFFFFEL);
				if (num != 2)
				{
					num2 = 180f - vector.x;
					float f = val.y + 180f;
					float f2 = val.z + 180f;
					float num3 = Mathf.Abs(vector2.x);
					float num4 = Mathf.Abs(vector.x);
					float num5 = num3 - num4;
					bool flag = num5 < 0f;
					bool flag2 = num5 == 0f;
					object obj = num3 ^ num4;
					object obj2 = num3 ^ num5;
					int num6 = (int)((nint)obj & (nint)obj2);
					bool flag3 = num6 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					if (flag4 && flag5)
					{
						num4 = num3;
					}
					float num7 = num4 * 1E-06f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					float num8 = Mathf.Abs(num2);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					float num9 = Mathf.Abs(counterVal.y);
					num10 = Mathf.Epsilon * 8f;
					float num11 = num7 - num10;
					bool flag6 = num11 < 0f;
					bool flag7 = num11 == 0f;
					object obj3 = num7 ^ num10;
					object obj4 = num7 ^ num11;
					int num12 = (int)((nint)obj3 & (nint)obj4);
					bool flag8 = num12 < 0;
					bool flag9 = flag6 == flag8;
					bool flag10 = !flag7;
					float num13 = ((!(flag9 && flag10)) ? num10 : num7);
					float num14 = 180f - num13;
					bool flag11 = num14 < 0f;
					float num15 = num3 - num8;
					bool flag12 = num15 < 0f;
					bool flag13 = num15 == 0f;
					object obj5 = num3 ^ num8;
					object obj6 = num3 ^ num15;
					int num16 = (int)((nint)obj5 & (nint)obj6);
					bool flag14 = num16 < 0;
					bool flag15 = flag12 == flag14;
					bool flag16 = !flag13;
					float num17 = ((!(flag15 && flag16)) ? num8 : num3);
					float num18 = num17 * 1E-06f;
					float num19 = num18 - num10;
					bool flag17 = num19 < 0f;
					bool flag18 = num19 == 0f;
					object obj7 = num18 ^ num10;
					object obj8 = num18 ^ num19;
					int num20 = (int)((nint)obj7 & (nint)obj8);
					bool flag19 = num20 < 0;
					bool flag20 = flag17 == flag19;
					bool flag21 = !flag18;
					float num21 = ((!(flag20 && flag21)) ? num10 : num18);
					float num22 = Mathf.Abs(val.y);
					float num23 = counterVal.y - num21;
					bool flag22 = num23 < 0f;
					float num24 = num9 - num22;
					bool flag23 = num24 < 0f;
					bool flag24 = num24 == 0f;
					object obj9 = num9 ^ num22;
					object obj10 = num9 ^ num24;
					int num25 = (int)((nint)obj9 & (nint)obj10);
					bool flag25 = num25 < 0;
					bool flag26 = flag23 == flag25;
					bool flag27 = !flag24;
					float num26 = ((!(flag26 && flag27)) ? num22 : num9);
					float num27 = num26 * 1E-06f;
					float num28 = num27 - num10;
					bool flag28 = num28 < 0f;
					bool flag29 = num28 == 0f;
					object obj11 = num27 ^ num10;
					object obj12 = num27 ^ num28;
					int num29 = (int)((nint)obj11 & (nint)obj12);
					bool flag30 = num29 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					bool flag31 = flag28 == flag30;
					bool flag32 = !flag29;
					float num30 = ((!(flag31 && flag32)) ? num10 : num27);
					float num31 = Mathf.Abs(f);
					float num32 = val.y - num30;
					bool flag33 = num32 < 0f;
					float num33 = num9 - num31;
					bool flag34 = num33 < 0f;
					bool flag35 = num33 == 0f;
					object obj13 = num9 ^ num31;
					object obj14 = num9 ^ num33;
					int num34 = (int)((nint)obj13 & (nint)obj14);
					bool flag36 = num34 < 0;
					bool flag37 = flag34 == flag36;
					bool flag38 = !flag35;
					float num35 = ((!(flag37 && flag38)) ? num31 : num9);
					float num36 = num35 * 1E-06f;
					float num37 = num36 - num10;
					bool flag39 = num37 < 0f;
					bool flag40 = num37 == 0f;
					object obj15 = num36 ^ num10;
					object obj16 = num36 ^ num37;
					int num38 = (int)((nint)obj15 & (nint)obj16);
					bool flag41 = num38 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					bool flag42 = flag39 == flag41;
					bool flag43 = !flag40;
					float num39 = ((!(flag42 && flag43)) ? num10 : num36);
					float num40 = Mathf.Abs(counterVal.z);
					float num41 = Mathf.Abs(val.z);
					object obj17 = default(object);
					float num42 = (float)obj17 - num39;
					bool flag44 = num42 < 0f;
					float num43 = num40 - num41;
					bool flag45 = num43 < 0f;
					bool flag46 = num43 == 0f;
					object obj18 = num40 ^ num41;
					object obj19 = num40 ^ num43;
					int num44 = (int)((nint)obj18 & (nint)obj19);
					bool flag47 = num44 < 0;
					bool flag48 = flag45 == flag47;
					bool flag49 = !flag46;
					float num45 = ((!(flag48 && flag49)) ? num41 : num40);
					num46 = num45 * 1E-06f;
					float num47 = num46 - num10;
					bool flag50 = num47 < 0f;
					bool flag51 = num47 == 0f;
					object obj20 = num46 ^ num10;
					object obj21 = num46 ^ num47;
					int num48 = (int)((nint)obj20 & (nint)obj21);
					bool flag52 = num48 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					bool flag53 = flag50 == flag52;
					bool flag54 = !flag51;
					float num49 = ((!(flag53 && flag54)) ? num10 : num46);
					float num50 = vector2.x - num49;
					bool flag55 = num50 < 0f;
					float num51 = Mathf.Abs(f2);
					float num52 = num40 - num51;
					bool flag56 = num52 < 0f;
					bool flag57 = num52 == 0f;
					object obj22 = num40 ^ num51;
					object obj23 = num40 ^ num52;
					int num53 = (int)((nint)obj22 & (nint)obj23);
					bool flag58 = num53 < 0;
					bool flag59 = flag56 == flag58;
					bool flag60 = !flag57;
					if (flag59 && flag60)
					{
						num51 = num40;
					}
					float num54 = num51 * 1E-06f;
					bool flag61 = flag33 || flag55;
					float num55 = num54 - num10;
					bool flag62 = num55 < 0f;
					bool flag63 = num55 == 0f;
					object obj24 = num54 ^ num10;
					object obj25 = num54 ^ num55;
					int num56 = (int)((nint)obj24 & (nint)obj25);
					bool flag64 = num56 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					bool flag65 = flag33 && flag55;
					bool flag66 = flag11 && flag61;
					bool flag67 = flag62 == flag64;
					bool flag68 = !flag63;
					if (!(flag67 && flag68))
					{
						num54 = num10;
					}
					bool flag69 = flag65 || flag66;
					float num57 = num41 - num54;
					bool flag70 = num57 < 0f;
					bool flag71 = !flag69;
					bool flag72 = flag22 && flag71;
					bool flag73 = !flag72;
					bool flag74 = !flag73;
					if (!flag69 && !(flag44 && flag70))
					{
						bool flag75 = flag44 || flag70;
						if (!(flag74 && flag75))
						{
							goto IL_022a;
						}
					}
					int num58 = ((!(val.y < num30)) ? 1 : 2);
					if (!(180f < num13))
					{
						num58 = 0;
					}
					int num59 = ((!((float)obj17 < num39)) ? 1 : 2);
					if (!(counterVal.y < num21))
					{
						num59 = 0;
					}
					if (flag69)
					{
						num59 = num58;
					}
					if (num59 != 2)
					{
						if (num59 != 1)
						{
							if (num59 != 0)
							{
								goto IL_022a;
							}
							float num60 = num27 - num10;
							bool flag76 = num60 < 0f;
							bool flag77 = num60 == 0f;
							object obj26 = num27 ^ num10;
							object obj27 = num27 ^ num60;
							int num61 = (int)((nint)obj26 & (nint)obj27);
							bool flag78 = num61 < 0;
							bool flag79 = flag76 == flag78;
							bool flag80 = !flag77;
							float num62 = ((!(flag79 && flag80)) ? num10 : num27);
							if (val.y < num62)
							{
								goto IL_0624;
							}
						}
						else
						{
							float num63 = num7 - num10;
							bool flag81 = num63 < 0f;
							bool flag82 = num63 == 0f;
							object obj28 = num7 ^ num10;
							object obj29 = num7 ^ num63;
							int num64 = (int)((nint)obj28 & (nint)obj29);
							bool flag83 = num64 < 0;
							bool flag84 = flag81 == flag83;
							bool flag85 = !flag82;
							float num65 = ((!(flag84 && flag85)) ? num10 : num7);
							if (180f < num65)
							{
								goto IL_0624;
							}
						}
					}
					else
					{
						float num66 = num7 - num10;
						bool flag86 = num66 < 0f;
						bool flag87 = num66 == 0f;
						object obj30 = num7 ^ num10;
						object obj31 = num7 ^ num66;
						int num67 = (int)((nint)obj30 & (nint)obj31);
						bool flag88 = num67 < 0;
						bool flag89 = flag86 == flag88;
						bool flag90 = !flag87;
						float num68 = ((!(flag89 && flag90)) ? num10 : num7);
						if (180f < num68)
						{
							float num69 = num27 - num10;
							bool flag91 = num69 < 0f;
							bool flag92 = num69 == 0f;
							object obj32 = num27 ^ num10;
							object obj33 = num27 ^ num69;
							int num70 = (int)((nint)obj32 & (nint)obj33);
							bool flag93 = num70 < 0;
							bool flag94 = flag91 == flag93;
							bool flag95 = !flag92;
							float num71 = ((!(flag94 && flag95)) ? num10 : num27);
							if (val.y < num71)
							{
								goto IL_022a;
							}
						}
					}
					goto IL_1289;
				}
			}
			goto IL_022a;
			IL_1289:
			return (Vector3)num2;
			IL_0624:
			float num72 = num46 - num10;
			bool flag96 = num72 < 0f;
			bool flag97 = num72 == 0f;
			object obj34 = num46 ^ num10;
			object obj35 = num46 ^ num72;
			int num73 = (int)((nint)obj34 & (nint)obj35);
			bool flag98 = num73 < 0;
			bool flag99 = flag96 == flag98;
			bool flag100 = !flag97;
			float num74 = ((!(flag99 && flag100)) ? num10 : num46);
			if (vector2.x < num74)
			{
				goto IL_022a;
			}
			goto IL_1289;
			IL_022a:
			num2 = vector.x;
			goto IL_1289;
		}

		[Token(Token = "0x6000319")]
		[Address(RVA = "0xC22378", Offset = "0xC22378", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 0x43340000 - euler;\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector3 FlipEulerAngles(Vector3 euler)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			return 1127481344 - euler;
		}

		[Token(Token = "0x600031A")]
		[Address(RVA = "0xC22390", Offset = "0xC22390", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35771]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionPlugin()
		{
		}
	}
}
