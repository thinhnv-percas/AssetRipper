using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7521F4", Offset = "0x7521F4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7521F4", Offset = "0x7521F4")]
	[Token(Token = "0x2000124")]
	public class PlayAnimation : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A2AB4", Offset = "0x7A2AB4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2AB4", Offset = "0x7A2AB4")]
		[Token(Token = "0x40010CD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A2B4C", Offset = "0x7A2B4C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2B4C", Offset = "0x7A2B4C")]
		[Token(Token = "0x40010CE")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2B9C", Offset = "0x7A2B9C")]
		[Token(Token = "0x40010CF")]
		[FieldOffset(Offset = "0x70")]
		public PlayMode playMode;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A2BD4", Offset = "0x7A2BD4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2BD4", Offset = "0x7A2BD4")]
		[Token(Token = "0x40010D0")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat blendTime;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2C28", Offset = "0x7A2C28")]
		[Token(Token = "0x40010D1")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2C60", Offset = "0x7A2C60")]
		[Token(Token = "0x40010D2")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent loopEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2C98", Offset = "0x7A2C98")]
		[Token(Token = "0x40010D3")]
		[FieldOffset(Offset = "0x90")]
		public bool stopOnExit;

		[Token(Token = "0x40010D4")]
		[FieldOffset(Offset = "0x98")]
		private AnimationState anim;

		[Token(Token = "0x40010D5")]
		[FieldOffset(Offset = "0xA0")]
		private float prevAnimtTime;

		[Token(Token = "0x60006A8")]
		[Address(RVA = "0xB19154", Offset = "0xB19154", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.playMode = 4;\n\tthis.gameObject = 0;\n\tthis.animName = 0;\n\tv14 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.3f);\n\tthis.stopOnExit = 0;\n\tthis.finishEvent = 0;\n\tthis.loopEvent = 0;\n\tthis.blendTime = v14;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			playMode = PlayMode.StopAll;
			gameObject = null;
			animName = null;
			FsmFloat fsmFloat = 0.3f;
			stopOnExit = false;
			finishEvent = null;
			loopEvent = null;
			blendTime = fsmFloat;
		}

		[Token(Token = "0x60006A9")]
		[Address(RVA = "0xB19198", Offset = "0xB19198", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.PlayAnimation::DoPlayAnimation(this);\n\treturn;\n")]
		public override void OnEnter()
		{
			DoPlayAnimation();
		}

		[Token(Token = "0x60006AA")]
		[Address(RVA = "0xB1919C", Offset = "0xB1919C", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ED8F78]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202255C]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]), this.gameObject);\n\tv111 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, v47);\n\tv147 = v111 == 0;\n\tif (v147) goto L_0064;\n\tv201 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv203 = System.String::IsNullOrEmpty(v201);\n\tv205 = v203 == 0;\n\tif (v205) goto L_0036;\n\tgoto L_005A;\nL_0036:\n\tv132 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv133 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv221 = UnityEngine.Animation::get_Item(v132, v133);\n\tthis.anim = v221;\n\tv222 = UnityEngine.TrackedReference::op_Equality(v221, 0);\n\tv224 = v222 == 0;\n\tif (v224) goto L_006A;\n\tv226 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv215 = System.String::Concat(\"Missing animation: \", v226);\nL_005A:\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v153);\nL_0064:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_006A:\n\tv123 = HutongGames.PlayMaker.FsmFloat::get_Value(this.blendTime);\n\tv134 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv135 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv52 = v123 >= 0.001f;\n\tif (v52) goto L_008D;\n\tv239 = UnityEngine.Animation::Play(v134, v135, this.playMode);\n\tgoto L_0092;\nL_008D:\n\tUnityEngine.Animation::CrossFade(v134, v135, v123, this.playMode);\nL_0092:\n\tv181 = UnityEngine.AnimationState::get_time(this.anim);\n\tthis.prevAnimtTime = v181;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoPlayAnimation()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				string value = animName.Value;
				string text;
				if (string.IsNullOrEmpty(value))
				{
					text = "Missing animName!";
				}
				else
				{
					Animation animation = base.animation;
					string value2 = animName.Value;
					if (!((anim = animation.get_Item(value2)) == null))
					{
						float value3 = blendTime.Value;
						Animation animation2 = base.animation;
						string value4 = animName.Value;
						if (value3 < 0.001f)
						{
							bool flag = animation2.Play(value4, playMode);
						}
						else
						{
							animation2.CrossFade(value4, value3, playMode);
						}
						float time = anim.time;
						prevAnimtTime = time;
						return;
					}
					string value5 = animName.Value;
					string text2 = "Missing animation: " + value5;
					text = text2;
				}
				LogWarning(text);
			}
			Finish();
		}

		[Token(Token = "0x60006AB")]
		[Address(RVA = "0xB19384", Offset = "0xB19384", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECFA98]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202255D]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]), this.gameObject);\n\tgoto L_002B;\n\tv179 = *([v170 @ X8_v6+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_002B;\n\tv236 = v170;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v236, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv188 = UnityEngine.Object::op_Equality(v45, 0);\n\tv238 = v188 == 0;\n\tv239 = ~v238;\n\tif (v239) goto L_00BC;\n\tv241 = UnityEngine.TrackedReference::op_Equality(this.anim, 0);\n\tv246 = v241 == 0;\n\tv244 = ~v246;\n\tif (v244) goto L_00BC;\n\tv247 = UnityEngine.AnimationState::get_enabled(this.anim);\n\tv249 = v247 == 0;\n\tif (v249) goto L_006D;\n\tv263 = UnityEngine.AnimationState::get_wrapMode(this.anim);\n\tv61 = v263 != 8;\n\tif (v61) goto L_0075;\n\tv53 = UnityEngine.AnimationState::get_time(this.anim);\n\tv250 = UnityEngine.AnimationState::get_length(this.anim);\n\tv251 = v53 <= v250;\n\tif (v251) goto L_0075;\nL_006D:\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]), this.finishEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0075:\n\tv243 = UnityEngine.AnimationState::get_wrapMode(this.anim);\n\tv103 = v243 == 8;\n\tif (v103) goto L_00BC;\n\tv56 = UnityEngine.AnimationState::get_time(this.anim);\n\tv57 = UnityEngine.AnimationState::get_length(this.anim);\n\tv64 = v56 <= v57;\n\tif (v64) goto L_00BC;\n\tv58 = UnityEngine.AnimationState::get_length(this.anim);\n\tv65 = this.prevAnimtTime >= v58;\n\tif (v65) goto L_00BC;\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]), this.loopEvent);\n\treturn;\nL_00BC:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_001c: Expected O, but got I
			//IL_0149: Expected O, but got I
			//IL_020d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.PlayAnimation)+30]");
					((Fsm)0).Event(loopEvent);
				}
			}
		}

		[Token(Token = "0x60006AC")]
		[Address(RVA = "0xB1952C", Offset = "0xB1952C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.stopOnExit;\n\tif (v2) goto L_0005;\n\tHutongGames.PlayMaker.Actions.PlayAnimation::StopAnimation(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (stopOnExit)
			{
				StopAnimation();
			}
		}

		[Token(Token = "0x60006AD")]
		[Address(RVA = "0xB1953C", Offset = "0xB1953C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F06D48]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202255E]) = v40;\nL_0018:\n\tv45 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tgoto L_002A;\n\tv53 = *([v49 @ X8_v5+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002A;\n\tv64 = v49;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v64, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv63 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv66 = v63 == 0;\n\tif (v66) goto L_004B;\n\tv69 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv102 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tUnityEngine.Animation::Stop(v69, v102);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopAnimation()
		{
			Animation animation = base.animation;
			if (animation != null)
			{
				Animation animation2 = base.animation;
				string value = animName.Value;
				animation2.Stop(value);
			}
		}

		[Token(Token = "0x60006AE")]
		[Address(RVA = "0xB19620", Offset = "0xB19620", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayAnimation()
		{
		}
	}
}
