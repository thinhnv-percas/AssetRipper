using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752244", Offset = "0x752244")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x752244", Offset = "0x752244")]
	[Token(Token = "0x2000125")]
	public class PlayRandomAnimation : BaseAnimationAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A2CD0", Offset = "0x7A2CD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A2CD0", Offset = "0x7A2CD0")]
		[Token(Token = "0x40010D6")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7A2D68", Offset = "0x7A2D68")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A2D68", Offset = "0x7A2D68")]
		[Token(Token = "0x40010D7")]
		[FieldOffset(Offset = "0x68")]
		public FsmString[] animations;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A2DE8", Offset = "0x7A2DE8")]
		[Token(Token = "0x40010D8")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat[] weights;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A2E00", Offset = "0x7A2E00")]
		[Token(Token = "0x40010D9")]
		[FieldOffset(Offset = "0x78")]
		public PlayMode playMode;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A2E38", Offset = "0x7A2E38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A2E38", Offset = "0x7A2E38")]
		[Token(Token = "0x40010DA")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat blendTime;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A2E8C", Offset = "0x7A2E8C")]
		[Token(Token = "0x40010DB")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A2EC4", Offset = "0x7A2EC4")]
		[Token(Token = "0x40010DC")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A2EFC", Offset = "0x7A2EFC")]
		[Token(Token = "0x40010DD")]
		[FieldOffset(Offset = "0x98")]
		public bool stopOnExit;

		[Token(Token = "0x40010DE")]
		[FieldOffset(Offset = "0xA0")]
		private AnimationState anim;

		[Token(Token = "0x40010DF")]
		[FieldOffset(Offset = "0xA8")]
		private float prevAnimtTime;

		[Token(Token = "0x60006AF")]
		[Address(RVA = "0xB19628", Offset = "0xB19628", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0D698]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202255F]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\t// 24 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 0\n\tthis.animations = v43;\n\t// 30 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmFloat[]), typeof(HutongGames.PlayMaker.FsmFloat[]), 0\n\tthis.playMode = 4;\n\tthis.weights = v48;\n\tv53 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.3f);\n\tthis.stopOnExit = 0;\n\tthis.finishEvent = 0;\n\tthis.loopEvent = 0;\n\tthis.blendTime = v53;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString[] array = new FsmString[0];
			animations = array;
			FsmFloat[] array2 = new FsmFloat[0];
			playMode = PlayMode.StopAll;
			weights = array2;
			FsmFloat fsmFloat = 0.3f;
			stopOnExit = false;
			finishEvent = null;
			loopEvent = null;
			blendTime = fsmFloat;
		}

		[Token(Token = "0x60006B0")]
		[Address(RVA = "0xB196C0", Offset = "0xB196C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.PlayRandomAnimation::DoPlayRandomAnimation(this);\n\treturn;\n")]
		public override void OnEnter()
		{
			DoPlayRandomAnimation();
		}

		[Token(Token = "0x60006B1")]
		[Address(RVA = "0xB196C4", Offset = "0xB196C4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.animations;\n\tv13 = v10.Length == 0;\n\tif (v13) goto L_0036;\n\tv30 = HutongGames.PlayMaker.ActionHelpers::GetRandomWeightedIndex(this.weights);\n\tv59 = v30 + 1;\n\tv22 = v59 == 0;\n\tif (v22) goto L_0036;\n\tv34 = this.animations;\n\tv138 = v30 < v34.Length;\n\tv81 = ~v138;\n\tif (v81) goto L_0039;\n\tv140 = HutongGames.PlayMaker.FsmString::get_Value(v34[v30 @ X0_v11 (System.Int32)]);\n\tHutongGames.PlayMaker.Actions.PlayRandomAnimation::DoPlayAnimation(this, v140);\n\treturn;\nL_0036:\n\treturn;\n\tv36 = new System.NullReferenceException();\nL_0039:\n\tv90 = new System.IndexOutOfRangeException();\n\tthrow v90;\n\tthrow System.NullReferenceException;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoPlayRandomAnimation()
		{
			FsmString[] array = animations;
			if (array.Length == 0)
			{
				return;
			}
			int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(weights);
			if (randomWeightedIndex + 1 != 0)
			{
				FsmString[] array2 = animations;
				if (randomWeightedIndex >= array2.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				string value = array2[randomWeightedIndex].Value;
				DoPlayAnimation(value);
			}
		}

		[Token(Token = "0x60006B2")]
		[Address(RVA = "0xB1975C", Offset = "0xB1975C", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EE0098]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, animName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022560]) = v43;\nL_001B:\n\tv48 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]), this.gameObject);\n\tv111 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, v48);\n\tv113 = v111 == 0;\n\tif (v113) goto L_0053;\n\tv157 = System.String::IsNullOrEmpty(animName);\n\tv168 = v157 == 0;\n\tif (v168) goto L_0033;\n\tgoto L_0049;\nL_0033:\n\tv93 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv183 = UnityEngine.Animation::get_Item(v93, animName);\n\tthis.anim = v183;\n\tv184 = UnityEngine.TrackedReference::op_Equality(v183, 0);\n\tv179 = v184 == 0;\n\tif (v179) goto L_0059;\n\tv178 = System.String::Concat(\"Missing animation: \", animName);\nL_0049:\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v160);\nL_0053:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0059:\n\tv79 = HutongGames.PlayMaker.FsmFloat::get_Value(this.blendTime);\n\tv95 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv53 = v79 >= 0.001f;\n\tif (v53) goto L_0074;\n\tv194 = UnityEngine.Animation::Play(v95, animName, this.playMode);\n\tgoto L_0079;\nL_0074:\n\tUnityEngine.Animation::CrossFade(v95, animName, v79, this.playMode);\nL_0079:\n\tv125 = UnityEngine.AnimationState::get_time(this.anim);\n\tthis.prevAnimtTime = v125;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoPlayAnimation(string animName)
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				string text;
				if (string.IsNullOrEmpty(animName))
				{
					text = "Missing animName!";
				}
				else
				{
					Animation animation = base.animation;
					if (!((anim = animation.get_Item(animName)) == null))
					{
						float value = blendTime.Value;
						Animation animation2 = base.animation;
						if (value < 0.001f)
						{
							bool flag = animation2.Play(animName, playMode);
						}
						else
						{
							animation2.CrossFade(animName, value, playMode);
						}
						float time = anim.time;
						prevAnimtTime = time;
						return;
					}
					string text2 = "Missing animation: " + animName;
					text = text2;
				}
				LogWarning(text);
			}
			Finish();
		}

		[Token(Token = "0x60006B3")]
		[Address(RVA = "0xB198E8", Offset = "0xB198E8", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F01DE0]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022561]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]), this.gameObject);\n\tgoto L_002B;\n\tv179 = *([v170 @ X8_v6+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_002B;\n\tv236 = v170;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v236, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv188 = UnityEngine.Object::op_Equality(v45, 0);\n\tv238 = v188 == 0;\n\tv239 = ~v238;\n\tif (v239) goto L_00BC;\n\tv241 = UnityEngine.TrackedReference::op_Equality(this.anim, 0);\n\tv246 = v241 == 0;\n\tv244 = ~v246;\n\tif (v244) goto L_00BC;\n\tv247 = UnityEngine.AnimationState::get_enabled(this.anim);\n\tv249 = v247 == 0;\n\tif (v249) goto L_006D;\n\tv263 = UnityEngine.AnimationState::get_wrapMode(this.anim);\n\tv61 = v263 != 8;\n\tif (v61) goto L_0075;\n\tv53 = UnityEngine.AnimationState::get_time(this.anim);\n\tv250 = UnityEngine.AnimationState::get_length(this.anim);\n\tv251 = v53 <= v250;\n\tif (v251) goto L_0075;\nL_006D:\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]), this.finishEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0075:\n\tv243 = UnityEngine.AnimationState::get_wrapMode(this.anim);\n\tv103 = v243 == 8;\n\tif (v103) goto L_00BC;\n\tv56 = UnityEngine.AnimationState::get_time(this.anim);\n\tv57 = UnityEngine.AnimationState::get_length(this.anim);\n\tv64 = v56 <= v57;\n\tif (v64) goto L_00BC;\n\tv58 = UnityEngine.AnimationState::get_length(this.anim);\n\tv65 = this.prevAnimtTime >= v58;\n\tif (v65) goto L_00BC;\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]), this.loopEvent);\n\treturn;\nL_00BC:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_001c: Expected O, but got I
			//IL_0149: Expected O, but got I
			//IL_020d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null || anim == null)
			{
				return;
			}
			if (!anim.enabled)
			{
				goto IL_0132;
			}
			WrapMode wrapMode = anim.wrapMode;
			if (wrapMode == WrapMode.ClampForever)
			{
				float time = anim.time;
				float length = anim.length;
				if (time > length)
				{
					goto IL_0132;
				}
			}
			goto IL_0154;
			IL_0132:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]");
			((Fsm)0).Event(finishEvent);
			Finish();
			goto IL_0154;
			IL_0154:
			WrapMode wrapMode2 = anim.wrapMode;
			if (wrapMode2 == WrapMode.ClampForever)
			{
				return;
			}
			float time2 = anim.time;
			float length2 = anim.length;
			if (time2 > length2)
			{
				float length3 = anim.length;
				if (prevAnimtTime < length3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayRandomAnimation)+30]");
					((Fsm)0).Event(loopEvent);
				}
			}
		}

		[Token(Token = "0x60006B4")]
		[Address(RVA = "0xB19A90", Offset = "0xB19A90", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.stopOnExit;\n\tif (v2) goto L_0005;\n\tHutongGames.PlayMaker.Actions.PlayRandomAnimation::StopAnimation(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (stopOnExit)
			{
				StopAnimation();
			}
		}

		[Token(Token = "0x60006B5")]
		[Address(RVA = "0xB19AA0", Offset = "0xB19AA0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF3FF8]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022562]) = v40;\nL_0018:\n\tv45 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tgoto L_002A;\n\tv53 = *([v49 @ X8_v5+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002A;\n\tv64 = v49;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v64, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv63 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv66 = v63 == 0;\n\tif (v66) goto L_004B;\n\tv69 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv102 = UnityEngine.AnimationState::get_name(this.anim);\n\tUnityEngine.Animation::Stop(v69, v102);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopAnimation()
		{
			Animation animation = base.animation;
			if (animation != null)
			{
				Animation animation2 = base.animation;
				string text = anim.name;
				animation2.Stop(text);
			}
		}

		[Token(Token = "0x60006B6")]
		[Address(RVA = "0xB19B84", Offset = "0xB19B84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayRandomAnimation()
		{
		}
	}
}
