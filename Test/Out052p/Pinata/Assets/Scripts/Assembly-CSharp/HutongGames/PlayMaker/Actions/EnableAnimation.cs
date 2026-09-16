using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7521A4", Offset = "0x7521A4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7521A4", Offset = "0x7521A4")]
	[Token(Token = "0x2000123")]
	public class EnableAnimation : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A2938", Offset = "0x7A2938")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2938", Offset = "0x7A2938")]
		[Token(Token = "0x40010C8")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A29D0", Offset = "0x7A29D0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A29D0", Offset = "0x7A29D0")]
		[Token(Token = "0x40010C9")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2A30", Offset = "0x7A2A30")]
		[Token(Token = "0x40010CA")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool enable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2A7C", Offset = "0x7A2A7C")]
		[Token(Token = "0x40010CB")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool resetOnExit;

		[Token(Token = "0x40010CC")]
		[FieldOffset(Offset = "0x80")]
		private AnimationState anim;

		[Token(Token = "0x60006A3")]
		[Address(RVA = "0xB73B60", Offset = "0xB73B60", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.animName = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.enable = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.resetOnExit = v15;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			animName = null;
			FsmBool fsmBool = true;
			enable = fsmBool;
			FsmBool fsmBool2 = false;
			resetOnExit = fsmBool2;
		}

		[Token(Token = "0x60006A4")]
		[Address(RVA = "0xB73BA0", Offset = "0xB73BA0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.EnableAnimation)+30]), this.gameObject);\n\tHutongGames.PlayMaker.Actions.EnableAnimation::DoEnableAnimation(this, v14);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0017: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.EnableAnimation)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			DoEnableAnimation(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x60006A5")]
		[Address(RVA = "0xB73BE8", Offset = "0xB73BE8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE22A0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022914]) = v41;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, go);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0050;\n\tv54 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv99 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv116 = UnityEngine.Animation::get_Item(v54, v99);\n\tthis.anim = v116;\n\tv60 = UnityEngine.TrackedReference::op_Inequality(v116, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0050;\n\tv105 = HutongGames.PlayMaker.FsmBool::get_Value(this.enable);\n\tUnityEngine.AnimationState::set_enabled(this.anim, v105);\n\treturn;\nL_0050:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoEnableAnimation(GameObject go)
		{
			if (UpdateCache(go))
			{
				Animation animation = base.animation;
				string value = animName.Value;
				if ((anim = animation.get_Item(value)) != null)
				{
					bool value2 = enable.Value;
					anim.enabled = value2;
				}
			}
		}

		[Token(Token = "0x60006A6")]
		[Address(RVA = "0xB73CE0", Offset = "0xB73CE0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetOnExit);\n\tv39 = v13 == 0;\n\tif (v39) goto L_002C;\n\tv52 = UnityEngine.TrackedReference::op_Inequality(this.anim, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_002C;\n\tv46 = HutongGames.PlayMaker.FsmBool::get_Value(this.enable);\n\tv72 = ~v46;\n\tUnityEngine.AnimationState::set_enabled(this.anim, v72);\n\treturn;\nL_002C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (resetOnExit.Value && anim != null)
			{
				bool value = enable.Value;
				bool flag = !value;
				anim.enabled = flag;
			}
		}

		[Token(Token = "0x60006A7")]
		[Address(RVA = "0xB73D64", Offset = "0xB73D64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnableAnimation()
		{
		}
	}
}
