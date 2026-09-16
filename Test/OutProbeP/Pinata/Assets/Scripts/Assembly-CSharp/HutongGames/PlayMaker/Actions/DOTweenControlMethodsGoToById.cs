using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74DF94", Offset = "0x74DF94")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74DF94", Offset = "0x74DF94")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74DF94", Offset = "0x74DF94")]
	[Token(Token = "0x2000099")]
	public class DOTweenControlMethodsGoToById : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F3B8", Offset = "0x76F3B8")]
		[Token(Token = "0x4000520")]
		[FieldOffset(Offset = "0x4C")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F3F0", Offset = "0x76F3F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F3F0", Offset = "0x76F3F0")]
		[Token(Token = "0x4000521")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F440", Offset = "0x76F440")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F440", Offset = "0x76F440")]
		[Token(Token = "0x4000522")]
		[FieldOffset(Offset = "0x58")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F490", Offset = "0x76F490")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F490", Offset = "0x76F490")]
		[Token(Token = "0x4000523")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject gameObjectAsId;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F4E0", Offset = "0x76F4E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F4E0", Offset = "0x76F4E0")]
		[Token(Token = "0x4000524")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F540", Offset = "0x76F540")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F540", Offset = "0x76F540")]
		[Token(Token = "0x4000525")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool andPlay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76F590", Offset = "0x76F590")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F590", Offset = "0x76F590")]
		[Token(Token = "0x4000526")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool debugThis;

		[Token(Token = "0x60003F7")]
		[Address(RVA = "0xAF0C10", Offset = "0xAF0C10", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1ED4D48]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022437]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v46);\n\tv46.useVariable = 0;\n\tthis.stringAsId = v46;\n\tv51 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v51);\n\tv51.useVariable = 0;\n\tthis.tagAsId = v51;\n\tv63 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v63);\n\tv63.useVariable = 0;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v63, 0);\n\tthis.gameObjectAsId = v63;\n\tv64 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v64);\n\tv64.useVariable = 0;\n\tthis.to = v64;\n\tv65 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v65);\n\tv65.useVariable = 0;\n\tv65.value = 0;\n\tthis.andPlay = v65;\n\tv66 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v66);\n\tv66.value = 0;\n\tthis.debugThis = v66;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			stringAsId = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			tagAsId = fsmString2;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			fsmGameObject.Value = null;
			gameObjectAsId = fsmGameObject;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			andPlay = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.value = false;
			debugThis = fsmBool2;
		}

		[Token(Token = "0x60003F8")]
		[Address(RVA = "0xAF0D60", Offset = "0xAF0D60", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EF4FE0]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022438]) = v42;\nL_001A:\n\tv48 = this.tweenIdType == 3;\n\tif (v48) goto L_005A;\n\tv57 = this.tweenIdType == 2;\n\tif (v57) goto L_0049;\n\tv73 = this.tweenIdType != 1;\n\tif (v73) goto L_FFFFFFFF;\n\tv207 = HutongGames.PlayMaker.FsmString::get_Value(this.stringAsId);\n\tv165 = System.String::IsNullOrEmpty(v207);\n\tv272 = v165 == 0;\n\tv169 = ~v272;\n\tif (v169) goto L_FFFFFFFF;\n\tv301 = this.stringAsId;\n\tv274 = this.stringAsId == 0;\n\tv138 = ~v274;\n\tif (v138) goto L_0054;\n\tgoto L_00C0;\nL_0049:\n\tv176 = HutongGames.PlayMaker.FsmString::get_Value(this.tagAsId);\n\tv166 = System.String::IsNullOrEmpty(v176);\n\tv229 = v166 == 0;\n\tv170 = ~v229;\n\tif (v170) goto L_FFFFFFFF;\n\tv301 = this.tagAsId;\nL_0054:\n\tv304 = HutongGames.PlayMaker.FsmString::get_Value(v301);\n\tgoto L_007B;\nL_005A:\n\tv77 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\n\tgoto L_006C;\n\tv219 = *([v144 @ X8_v21+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_006C;\n\tv230 = v144;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v230, v76, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006C:\n\tv167 = UnityEngine.Object::op_Inequality(v77, 0);\n\tv171 = v167 == 0;\n\tif (v171) goto L_FFFFFFFF;\n\tv306 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\nL_007B:\n\tv84 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv319 = HutongGames.PlayMaker.FsmBool::get_Value(this.andPlay);\n\tgoto L_0094;\n\tv325 = *([v217 @ X8_v18+E0]);\n\tv326 = v325 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_0094;\n\tv331 = v217;\n\tv329 = \"il2cpp_codegen_runtime_class_init\"(v331, v318, v88, v27, v28, v29, v30, v31, v84, v33, v34, v35, v36, v37, v38, v39);\nL_0094:\n\tv214 = DG.Tweening.DOTween::Goto(v199, v84, v319);\n\tgoto L_009C;\nL_009C:\n\tv227 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv262 = v227 == 0;\n\tif (v262) goto L_00B7;\n\t// 166 Box v281 @ X0_v8 (System.Object), typeof(System.Int32), &v150 @ X20_v2 (System.Int32)\n\tv313 = System.String::Concat(\"DOTween Control Methods Go To By Id - \", v281, \" tweens involved\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v313);\nL_00B7:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00C0:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmString fsmString;
			object targetOrId;
			if (tweenIdType != TweenId.UseGameObject)
			{
				if (tweenIdType != TweenId.UseTag)
				{
					if (tweenIdType == TweenId.UseString)
					{
						string value = stringAsId.Value;
						if (!string.IsNullOrEmpty(value))
						{
							fsmString = stringAsId;
							if (stringAsId == null)
							{
								throw new NullReferenceException();
							}
							goto IL_0120;
						}
					}
				}
				else
				{
					string value2 = tagAsId.Value;
					if (!string.IsNullOrEmpty(value2))
					{
						fsmString = tagAsId;
						goto IL_0120;
					}
				}
			}
			else
			{
				GameObject value3 = gameObjectAsId.Value;
				if (value3 != null)
				{
					GameObject value4 = gameObjectAsId.Value;
					targetOrId = value4;
					goto IL_0195;
				}
			}
			int num = 0;
			goto IL_01ed;
			IL_0120:
			string value5 = fsmString.Value;
			targetOrId = value5;
			goto IL_0195;
			IL_0195:
			float value6 = to.Value;
			bool value7 = andPlay.Value;
			int num2 = DOTween.Goto(targetOrId, value6, value7);
			num = num2;
			goto IL_01ed;
			IL_01ed:
			if (debugThis.Value)
			{
				object obj = num;
				string message = string.Concat("DOTween Control Methods Go To By Id - ", obj, " tweens involved");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x60003F9")]
		[Address(RVA = "0xAF0F7C", Offset = "0xAF0F7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsGoToById()
		{
		}
	}
}
