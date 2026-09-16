using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;
using HutongGames.PlayMaker;
using UnityEngine;

namespace Doozy.PlayMaker
{
	[Token(Token = "0x2000068")]
	public static class DOTweenExtensions
	{
		[Token(Token = "0x60002BA")]
		[Address(RVA = "0x9FEC3C", Offset = "0x9FEC3C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EF52A8]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, tweenId, stringAsId, tagAsId, gameObject, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021C51]) = v50;\nL_001F:\n\tv55 = tweenId == 3;\n\tif (v55) goto L_0069;\n\tv64 = tweenId == 2;\n\tif (v64) goto L_004B;\n\tv92 = tweenId != 1;\n\tif (v92) goto L_005A;\n\tv183 = HutongGames.PlayMaker.FsmString::get_Value(stringAsId);\n\tv110 = System.String::IsNullOrEmpty(v183);\n\tv186 = v110 == 0;\n\tv113 = ~v186;\n\tif (v113) goto L_005A;\n\tgoto L_006D;\nL_004B:\n\tv124 = HutongGames.PlayMaker.FsmString::get_Value(tagAsId);\n\tv109 = System.String::IsNullOrEmpty(v124);\n\tv112 = v109 == 0;\n\tif (v112) goto L_FFFFFFFF;\nL_005A:\n\treturn;\nL_0069:\n\tv82 = DG.Tweening.TweenSettingsExtensions::SetId(tween, gameObject);\n\treturn;\nL_006D:\n\tv192 = HutongGames.PlayMaker.FsmString::get_Value(v190);\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetId(tween, v192);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetTweenId(this Tween tween, TweenId tweenId, FsmString stringAsId, FsmString tagAsId, GameObject gameObject)
		{
			FsmString fsmString;
			switch (tweenId)
			{
			case TweenId.UseString:
			{
				string value2 = stringAsId.Value;
				if (!string.IsNullOrEmpty(value2))
				{
					fsmString = stringAsId;
					break;
				}
				return;
			}
			case TweenId.UseTag:
			{
				string value = tagAsId.Value;
				if (string.IsNullOrEmpty(value))
				{
					return;
				}
				fsmString = tagAsId;
				break;
			}
			default:
				return;
			case TweenId.UseGameObject:
			{
				Tween tween2 = tween.SetId(gameObject);
				return;
			}
			}
			string value3 = fsmString.Value;
			Tween tween3 = tween.SetId(value3);
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0x9FED58", Offset = "0x9FED58", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EBD5C8]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, tweenId, stringAsId, tagAsId, gameObject, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021C52]) = v50;\nL_001F:\n\tv55 = tweenId == 3;\n\tif (v55) goto L_0069;\n\tv64 = tweenId == 2;\n\tif (v64) goto L_004B;\n\tv92 = tweenId != 1;\n\tif (v92) goto L_005A;\n\tv183 = HutongGames.PlayMaker.FsmString::get_Value(stringAsId);\n\tv110 = System.String::IsNullOrEmpty(v183);\n\tv186 = v110 == 0;\n\tv113 = ~v186;\n\tif (v113) goto L_005A;\n\tgoto L_006D;\nL_004B:\n\tv124 = HutongGames.PlayMaker.FsmString::get_Value(tagAsId);\n\tv109 = System.String::IsNullOrEmpty(v124);\n\tv112 = v109 == 0;\n\tif (v112) goto L_FFFFFFFF;\nL_005A:\n\treturn;\nL_0069:\n\tv82 = DG.Tweening.TweenSettingsExtensions::SetId(sequence, gameObject);\n\treturn;\nL_006D:\n\tv192 = HutongGames.PlayMaker.FsmString::get_Value(v190);\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetId(sequence, v192);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetTweenId(this Sequence sequence, TweenId tweenId, FsmString stringAsId, FsmString tagAsId, GameObject gameObject)
		{
			FsmString fsmString;
			switch (tweenId)
			{
			case TweenId.UseString:
			{
				string value2 = stringAsId.Value;
				if (!string.IsNullOrEmpty(value2))
				{
					fsmString = stringAsId;
					break;
				}
				return;
			}
			case TweenId.UseTag:
			{
				string value = tagAsId.Value;
				if (string.IsNullOrEmpty(value))
				{
					return;
				}
				fsmString = tagAsId;
				break;
			}
			default:
				return;
			case TweenId.UseGameObject:
			{
				Sequence sequence2 = sequence.SetId(gameObject);
				return;
			}
			}
			string value3 = fsmString.Value;
			Sequence sequence3 = sequence.SetId(value3);
		}

		[Token(Token = "0x60002BC")]
		[Address(RVA = "0x9FEE74", Offset = "0x9FEE74", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EB83E8]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, selectedEase, easeType, animationCurve, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021C53]) = v47;\nL_001D:\n\tv52 = selectedEase == 1;\n\tif (v52) goto L_0044;\n\tv57 = selectedEase == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_004E;\n\tv72 = DG.Tweening.TweenSettingsExtensions::SetEase(tween, easeType);\n\treturn;\nL_0044:\n\tv92 = DG.Tweening.TweenSettingsExtensions::SetEase(tween, animationCurve.curve);\n\treturn;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetSelectedEase(this Tween tween, SelectedEase selectedEase, Ease easeType, FsmAnimationCurve animationCurve)
		{
			switch (selectedEase)
			{
			case SelectedEase.EaseType:
			{
				Tween tween3 = tween.SetEase(easeType);
				break;
			}
			case SelectedEase.AnimationCurve:
			{
				Tween tween2 = tween.SetEase(animationCurve.curve);
				break;
			}
			}
		}

		[Token(Token = "0x60002BD")]
		[Address(RVA = "0x9FEF38", Offset = "0x9FEF38", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EF1668]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, selectedEase, easeType, animationCurve, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021C54]) = v47;\nL_001D:\n\tv52 = selectedEase == 1;\n\tif (v52) goto L_0044;\n\tv57 = selectedEase == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_004E;\n\tv72 = DG.Tweening.TweenSettingsExtensions::SetEase(sequence, easeType);\n\treturn;\nL_0044:\n\tv92 = DG.Tweening.TweenSettingsExtensions::SetEase(sequence, animationCurve.curve);\n\treturn;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetSelectedEase(this Sequence sequence, SelectedEase selectedEase, Ease easeType, FsmAnimationCurve animationCurve)
		{
			switch (selectedEase)
			{
			case SelectedEase.EaseType:
			{
				Sequence sequence3 = sequence.SetEase(easeType);
				break;
			}
			case SelectedEase.AnimationCurve:
			{
				Sequence sequence2 = sequence.SetEase(animationCurve.curve);
				break;
			}
			}
		}
	}
}
