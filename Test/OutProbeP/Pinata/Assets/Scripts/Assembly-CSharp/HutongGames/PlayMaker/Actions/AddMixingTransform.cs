using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752064", Offset = "0x752064")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752064", Offset = "0x752064")]
	[Token(Token = "0x200011E")]
	public class AddMixingTransform : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A21F8", Offset = "0x7A21F8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A21F8", Offset = "0x7A21F8")]
		[Token(Token = "0x40010B3")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2290", Offset = "0x7A2290")]
		[Token(Token = "0x40010B4")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animationName;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A22DC", Offset = "0x7A22DC")]
		[Token(Token = "0x40010B5")]
		[FieldOffset(Offset = "0x70")]
		public FsmString transform;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2328", Offset = "0x7A2328")]
		[Token(Token = "0x40010B6")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool recursive;

		[Token(Token = "0x600068B")]
		[Address(RVA = "0xA12FBC", Offset = "0xA12FBC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC3B40]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D1D]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.animationName = v43;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.transform = v46;\n\tv49 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.recursive = v49;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			animationName = fsmString;
			FsmString fsmString2 = "";
			transform = fsmString2;
			FsmBool fsmBool = true;
			recursive = fsmBool;
		}

		[Token(Token = "0x600068C")]
		[Address(RVA = "0xA13038", Offset = "0xA13038", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddMixingTransform::DoAddMixingTransform(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddMixingTransform();
			Finish();
		}

		[Token(Token = "0x600068D")]
		[Address(RVA = "0xA13060", Offset = "0xA13060", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECBEA0]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D1E]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.AddMixingTransform)+30]), this.gameObject);\n\tv69 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, v45);\n\tv71 = v69 == 0;\n\tif (v71) goto L_0043;\n\tv108 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv120 = HutongGames.PlayMaker.FsmString::get_Value(this.animationName);\n\tv142 = UnityEngine.Animation::get_Item(v108, v120);\n\tv111 = UnityEngine.TrackedReference::op_Equality(v142, 0);\n\tv112 = v111 == 0;\n\tif (v112) goto L_0048;\nL_0043:\n\treturn;\nL_0048:\n\tv128 = UnityEngine.GameObject::get_transform(v45);\n\tv129 = HutongGames.PlayMaker.FsmString::get_Value(this.transform);\n\tv130 = UnityEngine.Transform::Find(v128, v129);\n\tv131 = HutongGames.PlayMaker.FsmBool::get_Value(this.recursive);\n\tUnityEngine.AnimationState::AddMixingTransform(v142, v130, v131);\n\treturn;\n\tv53 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddMixingTransform()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddMixingTransform)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Animation animation = base.animation;
				string value = animationName.Value;
				AnimationState animationState = animation.get_Item(value);
				if (!(animationState == null))
				{
					Transform transform = ownerDefaultTarget.transform;
					string value2 = this.transform.Value;
					Transform mix = transform.Find(value2);
					bool value3 = recursive.Value;
					animationState.AddMixingTransform(mix, value3);
				}
			}
		}

		[Token(Token = "0x600068E")]
		[Address(RVA = "0xA131B4", Offset = "0xA131B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddMixingTransform()
		{
		}
	}
}
