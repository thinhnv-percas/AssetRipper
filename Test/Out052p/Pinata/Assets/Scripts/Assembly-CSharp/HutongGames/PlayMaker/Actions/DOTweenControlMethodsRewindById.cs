using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74E6CC", Offset = "0x74E6CC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74E6CC", Offset = "0x74E6CC")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74E6CC", Offset = "0x74E6CC")]
	[Token(Token = "0x20000A7")]
	public class DOTweenControlMethodsRewindById : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7702A8", Offset = "0x7702A8")]
		[Token(Token = "0x4000552")]
		[FieldOffset(Offset = "0x4C")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7702E0", Offset = "0x7702E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7702E0", Offset = "0x7702E0")]
		[Token(Token = "0x4000553")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770330", Offset = "0x770330")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770330", Offset = "0x770330")]
		[Token(Token = "0x4000554")]
		[FieldOffset(Offset = "0x58")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770380", Offset = "0x770380")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770380", Offset = "0x770380")]
		[Token(Token = "0x4000555")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject gameObjectAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7703D0", Offset = "0x7703D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7703D0", Offset = "0x7703D0")]
		[Token(Token = "0x4000556")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool includeDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x770420", Offset = "0x770420")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770420", Offset = "0x770420")]
		[Token(Token = "0x4000557")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool debugThis;

		[Token(Token = "0x6000421")]
		[Address(RVA = "0xAF2D80", Offset = "0xAF2D80", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EDF278]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022453]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v46);\n\tv46.useVariable = 0;\n\tthis.stringAsId = v46;\n\tv51 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v51);\n\tv51.useVariable = 0;\n\tthis.tagAsId = v51;\n\tv62 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v62);\n\tv62.useVariable = 0;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v62, 0);\n\tthis.gameObjectAsId = v62;\n\tv63 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v63);\n\tv63.useVariable = 0;\n\tv63.value = 1;\n\tthis.includeDelay = v63;\n\tv64 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v64);\n\tv64.value = 0;\n\tthis.debugThis = v64;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			fsmBool.useVariable = false;
			fsmBool.value = true;
			includeDelay = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.value = false;
			debugThis = fsmBool2;
		}

		[Token(Token = "0x6000422")]
		[Address(RVA = "0xAF2EAC", Offset = "0xAF2EAC", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EDDC48]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022454]) = v40;\nL_0019:\n\tv46 = this.tweenIdType == 3;\n\tif (v46) goto L_0048;\n\tv55 = this.tweenIdType == 2;\n\tif (v55) goto L_0068;\n\tv71 = this.tweenIdType != 1;\n\tif (v71) goto L_FFFFFFFF;\n\tv194 = HutongGames.PlayMaker.FsmString::get_Value(this.stringAsId);\n\tv142 = System.String::IsNullOrEmpty(v194);\n\tv254 = v142 == 0;\n\tv146 = ~v254;\n\tif (v146) goto L_FFFFFFFF;\n\tv283 = this.stringAsId;\n\tv256 = this.stringAsId == 0;\n\tv117 = ~v256;\n\tif (v117) goto L_0074;\n\tgoto L_00B6;\nL_0048:\n\tv75 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\n\tgoto L_005A;\n\tv205 = *([v122 @ X8_v21+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_005A;\n\tv215 = v122;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v215, v74, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005A:\n\tv143 = UnityEngine.Object::op_Inequality(v75, 0);\n\tv147 = v143 == 0;\n\tif (v147) goto L_FFFFFFFF;\n\tv288 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\n\tgoto L_007B;\nL_0068:\n\tv152 = HutongGames.PlayMaker.FsmString::get_Value(this.tagAsId);\n\tv141 = System.String::IsNullOrEmpty(v152);\n\tv145 = v141 == 0;\n\tif (v145) goto L_0070;\n\tgoto L_0093;\nL_0070:\n\tv283 = this.tagAsId;\nL_0074:\n\tv286 = HutongGames.PlayMaker.FsmString::get_Value(v283);\nL_007B:\n\tv301 = HutongGames.PlayMaker.FsmBool::get_Value(this.includeDelay);\n\tgoto L_008D;\n\tv307 = *([v203 @ X8_v17+E0]);\n\tv308 = v307 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_008D;\n\tv313 = v203;\n\tv311 = \"il2cpp_codegen_runtime_class_init\"(v313, v300, v160, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008D:\n\tv200 = DG.Tweening.DOTween::Rewind(v184, v301);\nL_0093:\n\tv213 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv244 = v213 == 0;\n\tif (v244) goto L_00AE;\n\t// 157 Box v263 @ X0_v8 (System.Object), typeof(System.Int32), &v126 @ X20_v2 (System.Int32)\n\tv295 = System.String::Concat(\"DOTween Control Methods Rewind By Id - Rewinded and paused \", v263, \" tweens\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v295);\nL_00AE:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00B6:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					goto IL_0198;
				}
			}
			int num = 0;
			goto IL_01ca;
			IL_017e:
			string value5 = fsmString.Value;
			targetOrId = value5;
			goto IL_0198;
			IL_0198:
			bool value6 = includeDelay.Value;
			int num2 = DOTween.Rewind(targetOrId, value6);
			num = num2;
			goto IL_01ca;
			IL_01ca:
			if (debugThis.Value)
			{
				object obj = num;
				string message = string.Concat("DOTween Control Methods Rewind By Id - Rewinded and paused ", obj, " tweens");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x6000423")]
		[Address(RVA = "0xAF30A0", Offset = "0xAF30A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsRewindById()
		{
		}
	}
}
