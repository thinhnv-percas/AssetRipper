using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7520B4", Offset = "0x7520B4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7520B4", Offset = "0x7520B4")]
	[Token(Token = "0x200011F")]
	public class AnimationSettings : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A2360", Offset = "0x7A2360")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2360", Offset = "0x7A2360")]
		[Token(Token = "0x40010B7")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A23F8", Offset = "0x7A23F8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A23F8", Offset = "0x7A23F8")]
		[Token(Token = "0x40010B8")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2458", Offset = "0x7A2458")]
		[Token(Token = "0x40010B9")]
		[FieldOffset(Offset = "0x70")]
		public WrapMode wrapMode;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2490", Offset = "0x7A2490")]
		[Token(Token = "0x40010BA")]
		[FieldOffset(Offset = "0x74")]
		public AnimationBlendMode blendMode;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A24C8", Offset = "0x7A24C8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A24C8", Offset = "0x7A24C8")]
		[Token(Token = "0x40010BB")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat speed;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A251C", Offset = "0x7A251C")]
		[Token(Token = "0x40010BC")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt layer;

		[Token(Token = "0x600068F")]
		[Address(RVA = "0xA8725C", Offset = "0xA8725C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.animName = 0;\n\tthis.wrapMode = 2;\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.speed = v13;\n\tv16 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.layer = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			animName = null;
			wrapMode = WrapMode.Loop;
			FsmFloat fsmFloat = 1f;
			speed = fsmFloat;
			FsmInt fsmInt = 0;
			layer = fsmInt;
		}

		[Token(Token = "0x6000690")]
		[Address(RVA = "0xA872A4", Offset = "0xA872A4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimationSettings::DoAnimationSettings(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAnimationSettings();
			Finish();
		}

		[Token(Token = "0x6000691")]
		[Address(RVA = "0xA872CC", Offset = "0xA872CC", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE2D30]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221A0]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv73 = System.String::IsNullOrEmpty(v42);\n\tv93 = v73 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0085;\n\tv138 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.AnimationSettings)+30]), this.gameObject);\n\tv100 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, v138);\n\tv103 = v100 == 0;\n\tif (v103) goto L_0085;\n\tv80 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv81 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv149 = UnityEngine.Animation::get_Item(v80, v81);\n\tv82 = UnityEngine.TrackedReference::op_Equality(v149, 0);\n\tv151 = v82 == 0;\n\tif (v151) goto L_0061;\n\tv153 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv162 = System.String::Concat(\"Missing animation: \", v153);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v162);\n\treturn;\nL_0061:\n\tUnityEngine.AnimationState::set_wrapMode(v149, this.wrapMode);\n\tUnityEngine.AnimationState::set_blendMode(v149, this.blendMode);\n\tv164 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.layer);\n\tv166 = v164 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_007C;\n\tv174 = HutongGames.PlayMaker.FsmInt::get_Value(this.layer);\n\tUnityEngine.AnimationState::set_layer(v149, v174);\nL_007C:\n\tv99 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.speed);\n\tv102 = v99 == 0;\n\tif (v102) goto L_008A;\nL_0085:\n\treturn;\nL_008A:\n\tv112 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tUnityEngine.AnimationState::set_speed(v149, v112);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAnimationSettings()
		{
			//IL_0065: Expected O, but got I
			string value = animName.Value;
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AnimationSettings)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!UpdateCache(ownerDefaultTarget))
			{
				return;
			}
			Animation animation = base.animation;
			string value2 = animName.Value;
			AnimationState animationState = animation.get_Item(value2);
			if (animationState == null)
			{
				string value3 = animName.Value;
				string text = "Missing animation: " + value3;
				LogWarning(text);
				return;
			}
			animationState.wrapMode = wrapMode;
			animationState.blendMode = blendMode;
			if (!layer.IsNone)
			{
				int value4 = layer.Value;
				animationState.layer = value4;
			}
			if (!speed.IsNone)
			{
				float value5 = speed.Value;
				animationState.speed = value5;
			}
		}

		[Token(Token = "0x6000692")]
		[Address(RVA = "0xA8748C", Offset = "0xA8748C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n")]
		public AnimationSettings()
		{
		}
	}
}
