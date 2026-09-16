using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74E7D4", Offset = "0x74E7D4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74E7D4", Offset = "0x74E7D4")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74E7D4", Offset = "0x74E7D4")]
	[Token(Token = "0x20000A9")]
	public class DOTweenControlMethodsSmoothRewindById : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7704C0", Offset = "0x7704C0")]
		[Token(Token = "0x4000559")]
		[FieldOffset(Offset = "0x4C")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7704F8", Offset = "0x7704F8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7704F8", Offset = "0x7704F8")]
		[Token(Token = "0x400055A")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770548", Offset = "0x770548")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770548", Offset = "0x770548")]
		[Token(Token = "0x400055B")]
		[FieldOffset(Offset = "0x58")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770598", Offset = "0x770598")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770598", Offset = "0x770598")]
		[Token(Token = "0x400055C")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject gameObjectAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7705E8", Offset = "0x7705E8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7705E8", Offset = "0x7705E8")]
		[Token(Token = "0x400055D")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool debugThis;

		[Token(Token = "0x6000427")]
		[Address(RVA = "0xAF3220", Offset = "0xAF3220", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F09258]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022457]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v46);\n\tv46.useVariable = 0;\n\tthis.stringAsId = v46;\n\tv51 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v51);\n\tv51.useVariable = 0;\n\tthis.tagAsId = v51;\n\tv59 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v59);\n\tv59.useVariable = 0;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v59, 0);\n\tthis.gameObjectAsId = v59;\n\tv60 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v60);\n\tv60.value = 0;\n\tthis.debugThis = v60;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			FsmBool fsmBool = new FsmBool();
			fsmBool.value = false;
			debugThis = fsmBool;
		}

		[Token(Token = "0x6000428")]
		[Address(RVA = "0xAF3324", Offset = "0xAF3324", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC8450]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022458]) = v40;\nL_0019:\n\tv46 = this.tweenIdType == 3;\n\tif (v46) goto L_0048;\n\tv55 = this.tweenIdType == 2;\n\tif (v55) goto L_0068;\n\tv71 = this.tweenIdType != 1;\n\tif (v71) goto L_FFFFFFFF;\n\tv157 = HutongGames.PlayMaker.FsmString::get_Value(this.stringAsId);\n\tv140 = System.String::IsNullOrEmpty(v157);\n\tv225 = v140 == 0;\n\tv144 = ~v225;\n\tif (v144) goto L_FFFFFFFF;\n\tv254 = this.stringAsId;\n\tv227 = this.stringAsId == 0;\n\tv115 = ~v227;\n\tif (v115) goto L_0074;\n\tgoto L_00AE;\nL_0048:\n\tv75 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\n\tgoto L_005A;\n\tv176 = *([v120 @ X8_v19+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_005A;\n\tv222 = v120;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v222, v74, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005A:\n\tv141 = UnityEngine.Object::op_Inequality(v75, 0);\n\tv145 = v141 == 0;\n\tif (v145) goto L_FFFFFFFF;\n\tv259 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\n\tgoto L_007C;\nL_0068:\n\tv150 = HutongGames.PlayMaker.FsmString::get_Value(this.tagAsId);\n\tv139 = System.String::IsNullOrEmpty(v150);\n\tv143 = v139 == 0;\n\tif (v143) goto L_0070;\n\tgoto L_008B;\nL_0070:\n\tv254 = this.tagAsId;\nL_0074:\n\tv257 = HutongGames.PlayMaker.FsmString::get_Value(v254);\nL_007C:\n\tgoto L_0085;\n\tv279 = *([v174 @ X8_v15+E0]);\n\tv280 = v279 == 0;\n\tv281 = ~v280;\n\tif (v281) goto L_0085;\n\tv285 = v174;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v285, v268, v158, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0085:\n\tv171 = DG.Tweening.DOTween::SmoothRewind(v269);\nL_008B:\n\tv220 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv210 = v220 == 0;\n\tif (v210) goto L_00A6;\n\t// 149 Box v234 @ X0_v8 (System.Object), typeof(System.Int32), &v124 @ X20_v2 (System.Int32)\n\tv266 = System.String::Concat(\"DOTween Control Methods Smooth Rewind All - Rewinding/Rewinded \", v234, \" tweens\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v266);\nL_00A6:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00AE:\n\tthrow System.NullReferenceException;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
							goto IL_017e;
						}
					}
				}
				else
				{
					string value2 = tagAsId.Value;
					if (!string.IsNullOrEmpty(value2))
					{
						fsmString = tagAsId;
						goto IL_017e;
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
					goto IL_019d;
				}
			}
			int num = 0;
			goto IL_01b7;
			IL_017e:
			string value5 = fsmString.Value;
			targetOrId = value5;
			goto IL_019d;
			IL_019d:
			int num2 = DOTween.SmoothRewind(targetOrId);
			num = num2;
			goto IL_01b7;
			IL_01b7:
			if (debugThis.Value)
			{
				object obj = num;
				string message = string.Concat("DOTween Control Methods Smooth Rewind All - Rewinding/Rewinded ", obj, " tweens");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x6000429")]
		[Address(RVA = "0xAF34F4", Offset = "0xAF34F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsSmoothRewindById()
		{
		}
	}
}
