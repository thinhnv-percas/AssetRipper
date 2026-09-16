using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74E5C4", Offset = "0x74E5C4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74E5C4", Offset = "0x74E5C4")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74E5C4", Offset = "0x74E5C4")]
	[Token(Token = "0x20000A5")]
	public class DOTweenControlMethodsRestartById : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770040", Offset = "0x770040")]
		[Token(Token = "0x400054A")]
		[FieldOffset(Offset = "0x4C")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770078", Offset = "0x770078")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770078", Offset = "0x770078")]
		[Token(Token = "0x400054B")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7700C8", Offset = "0x7700C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7700C8", Offset = "0x7700C8")]
		[Token(Token = "0x400054C")]
		[FieldOffset(Offset = "0x58")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770118", Offset = "0x770118")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770118", Offset = "0x770118")]
		[Token(Token = "0x400054D")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject gameObjectAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x770168", Offset = "0x770168")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x770168", Offset = "0x770168")]
		[Token(Token = "0x400054E")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool includeDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7701B8", Offset = "0x7701B8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7701B8", Offset = "0x7701B8")]
		[Token(Token = "0x400054F")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool debugThis;

		[Token(Token = "0x600041B")]
		[Address(RVA = "0xAF288C", Offset = "0xAF288C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EFFD50]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202244F]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v46);\n\tv46.useVariable = 0;\n\tthis.stringAsId = v46;\n\tv51 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v51);\n\tv51.useVariable = 0;\n\tthis.tagAsId = v51;\n\tv62 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v62);\n\tv62.useVariable = 0;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v62, 0);\n\tthis.gameObjectAsId = v62;\n\tv63 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v63);\n\tv63.useVariable = 0;\n\tv63.value = 1;\n\tthis.includeDelay = v63;\n\tv64 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v64);\n\tv64.value = 0;\n\tthis.debugThis = v64;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600041C")]
		[Address(RVA = "0xAF29B8", Offset = "0xAF29B8", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED4098]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022450]) = v40;\nL_0019:\n\tv46 = this.tweenIdType == 3;\n\tif (v46) goto L_0048;\n\tv55 = this.tweenIdType == 2;\n\tif (v55) goto L_0068;\n\tv71 = this.tweenIdType != 1;\n\tif (v71) goto L_FFFFFFFF;\n\tv197 = HutongGames.PlayMaker.FsmString::get_Value(this.stringAsId);\n\tv144 = System.String::IsNullOrEmpty(v197);\n\tv259 = v144 == 0;\n\tv148 = ~v259;\n\tif (v148) goto L_FFFFFFFF;\n\tv288 = this.stringAsId;\n\tv261 = this.stringAsId == 0;\n\tv119 = ~v261;\n\tif (v119) goto L_0074;\n\tgoto L_00B7;\nL_0048:\n\tv75 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\n\tgoto L_005A;\n\tv209 = *([v124 @ X8_v21+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_005A;\n\tv219 = v124;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v219, v74, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005A:\n\tv145 = UnityEngine.Object::op_Inequality(v75, 0);\n\tv149 = v145 == 0;\n\tif (v149) goto L_FFFFFFFF;\n\tv293 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectAsId);\n\tgoto L_007B;\nL_0068:\n\tv154 = HutongGames.PlayMaker.FsmString::get_Value(this.tagAsId);\n\tv143 = System.String::IsNullOrEmpty(v154);\n\tv147 = v143 == 0;\n\tif (v147) goto L_0070;\n\tgoto L_0094;\nL_0070:\n\tv288 = this.tagAsId;\nL_0074:\n\tv291 = HutongGames.PlayMaker.FsmString::get_Value(v288);\nL_007B:\n\tv306 = HutongGames.PlayMaker.FsmBool::get_Value(this.includeDelay);\n\tgoto L_008E;\n\tv312 = *([v207 @ X8_v17+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_008E;\n\tv318 = v207;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v318, v305, v163, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008E:\n\tv204 = DG.Tweening.DOTween::Restart(v187, v306, -1f);\nL_0094:\n\tv217 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv249 = v217 == 0;\n\tif (v249) goto L_00AF;\n\t// 158 Box v268 @ X0_v8 (System.Object), typeof(System.Int32), &v128 @ X20_v2 (System.Int32)\n\tv300 = System.String::Concat(\"DOTween Control Methods Restart By Id - Restarted \", v268, \" tweens\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v300);\nL_00AF:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00B7:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			goto IL_01cf;
			IL_017e:
			string value5 = fsmString.Value;
			targetOrId = value5;
			goto IL_0198;
			IL_0198:
			bool value6 = includeDelay.Value;
			int num2 = DOTween.Restart(targetOrId, value6);
			num = num2;
			goto IL_01cf;
			IL_01cf:
			if (debugThis.Value)
			{
				object obj = num;
				string message = string.Concat("DOTween Control Methods Restart By Id - Restarted ", obj, " tweens");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x600041D")]
		[Address(RVA = "0xAF2BB0", Offset = "0xAF2BB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsRestartById()
		{
		}
	}
}
