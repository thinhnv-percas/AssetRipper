using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7523D4", Offset = "0x7523D4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7523D4", Offset = "0x7523D4")]
	[Token(Token = "0x200012A")]
	public class SetAnimationWeight : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A324C", Offset = "0x7A324C")]
		[Token(Token = "0x40010EE")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A32C0", Offset = "0x7A32C0")]
		[Token(Token = "0x40010EF")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[Token(Token = "0x40010F0")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat weight;

		[Token(Token = "0x40010F1")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x60006C9")]
		[Address(RVA = "0xB28D94", Offset = "0xB28D94", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.animName = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.weight = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			animName = null;
			FsmFloat fsmFloat = 1f;
			weight = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x60006CA")]
		[Address(RVA = "0xB28DC8", Offset = "0xB28DC8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0015;\nL_0013:\n\tv40 = *([this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationWeight)+20]);\nL_0015:\n\tHutongGames.PlayMaker.Actions.SetAnimationWeight::DoSetAnimationWeight(this, v40);\n\tv46 = ~this.everyFrame;\n\tif (v46) goto L_0024;\n\treturn;\nL_0024:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0060: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationWeight)+20]");
				go = (GameObject)0;
			}
			DoSetAnimationWeight(go);
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60006CB")]
		[Address(RVA = "0xB28F74", Offset = "0xB28F74", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0019;\nL_0013:\n\tv40 = *([this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationWeight)+20]);\nL_0019:\n\tHutongGames.PlayMaker.Actions.SetAnimationWeight::DoSetAnimationWeight(this, v40);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_0060: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationWeight)+20]");
				go = (GameObject)0;
			}
			DoSetAnimationWeight(go);
		}

		[Token(Token = "0x60006CC")]
		[Address(RVA = "0xB28E3C", Offset = "0xB28E3C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ED4CC8]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20225F3]) = v41;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, go);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0054;\n\tv54 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv102 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv121 = UnityEngine.Animation::get_Item(v54, v102);\n\tv122 = UnityEngine.TrackedReference::op_Equality(v121, 0);\n\tv124 = v122 == 0;\n\tif (v124) goto L_0059;\n\tv126 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv132 = System.String::Concat(\"Missing animation: \", v126);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v132);\n\treturn;\nL_0054:\n\treturn;\nL_0059:\n\tv64 = HutongGames.PlayMaker.FsmFloat::get_Value(this.weight);\n\tUnityEngine.AnimationState::set_weight(v121, v64);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetAnimationWeight(GameObject go)
		{
			if (UpdateCache(go))
			{
				Animation animation = base.animation;
				string value = animName.Value;
				AnimationState animationState = animation.get_Item(value);
				if (animationState == null)
				{
					string value2 = animName.Value;
					string text = "Missing animation: " + value2;
					LogWarning(text);
				}
				else
				{
					float value3 = weight.Value;
					animationState.weight = value3;
				}
			}
		}

		[Token(Token = "0x60006CD")]
		[Address(RVA = "0xB28FC8", Offset = "0xB28FC8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.weight = v12;\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimationWeight()
		{
			FsmFloat fsmFloat = 1f;
			weight = fsmFloat;
		}
	}
}
