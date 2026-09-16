using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752294", Offset = "0x752294")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752294", Offset = "0x752294")]
	[Token(Token = "0x2000126")]
	public class RemoveMixingTransform : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A2F34", Offset = "0x7A2F34")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2F34", Offset = "0x7A2F34")]
		[Token(Token = "0x40010E0")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2FCC", Offset = "0x7A2FCC")]
		[Token(Token = "0x40010E1")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animationName;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3018", Offset = "0x7A3018")]
		[Token(Token = "0x40010E2")]
		[FieldOffset(Offset = "0x70")]
		public FsmString transfrom;

		[Token(Token = "0x60006B7")]
		[Address(RVA = "0xB23EC4", Offset = "0xB23EC4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE6800]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225CC]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.animationName = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			animationName = fsmString;
		}

		[Token(Token = "0x60006B8")]
		[Address(RVA = "0xB23F20", Offset = "0xB23F20", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RemoveMixingTransform::DoRemoveMixingTransform(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoRemoveMixingTransform();
			Finish();
		}

		[Token(Token = "0x60006B9")]
		[Address(RVA = "0xB23F48", Offset = "0xB23F48", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC1020]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225CD]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.RemoveMixingTransform)+30]), this.gameObject);\n\tv68 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, v45);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0043;\n\tv105 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv117 = HutongGames.PlayMaker.FsmString::get_Value(this.animationName);\n\tv134 = UnityEngine.Animation::get_Item(v105, v117);\n\tv110 = UnityEngine.TrackedReference::op_Equality(v134, 0);\n\tv111 = v110 == 0;\n\tif (v111) goto L_0048;\nL_0043:\n\treturn;\nL_0048:\n\tv123 = UnityEngine.GameObject::get_transform(v45);\n\tv124 = HutongGames.PlayMaker.FsmString::get_Value(this.transfrom);\n\tv125 = UnityEngine.Transform::Find(v123, v124);\n\tUnityEngine.AnimationState::AddMixingTransform(v134, v125);\n\treturn;\n\tv53 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoRemoveMixingTransform()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.RemoveMixingTransform)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Animation animation = base.animation;
				string value = animationName.Value;
				AnimationState animationState = animation.get_Item(value);
				if (!(animationState == null))
				{
					Transform transform = ownerDefaultTarget.transform;
					string value2 = transfrom.Value;
					Transform mix = transform.Find(value2);
					animationState.AddMixingTransform(mix);
				}
			}
		}

		[Token(Token = "0x60006BA")]
		[Address(RVA = "0xB24080", Offset = "0xB24080", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RemoveMixingTransform()
		{
		}
	}
}
