using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7522E4", Offset = "0x7522E4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7522E4", Offset = "0x7522E4")]
	[Token(Token = "0x2000127")]
	public class RewindAnimation : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3064", Offset = "0x7A3064")]
		[Token(Token = "0x40010E3")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A30D8", Offset = "0x7A30D8")]
		[Token(Token = "0x40010E4")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[Token(Token = "0x60006BB")]
		[Address(RVA = "0xB24284", Offset = "0xB24284", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.animName = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			animName = null;
		}

		[Token(Token = "0x60006BC")]
		[Address(RVA = "0xB2428C", Offset = "0xB2428C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RewindAnimation::DoRewindAnimation(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoRewindAnimation();
			Finish();
		}

		[Token(Token = "0x60006BD")]
		[Address(RVA = "0xB242B4", Offset = "0xB242B4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F03A30]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225CF]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv50 = System.String::IsNullOrEmpty(v42);\n\tv69 = v50 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_004A;\n\tv101 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.RewindAnimation)+30]), this.gameObject);\n\tv75 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, v101);\n\tv77 = v75 == 0;\n\tif (v77) goto L_004A;\n\tv57 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv58 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tUnityEngine.Animation::Rewind(v57, v58);\n\treturn;\nL_004A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoRewindAnimation()
		{
			//IL_0065: Expected O, but got I
			string value = animName.Value;
			if (!string.IsNullOrEmpty(value))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.RewindAnimation)+30]");
				GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
				if (UpdateCache(ownerDefaultTarget))
				{
					Animation animation = base.animation;
					string value2 = animName.Value;
					animation.Rewind(value2);
				}
			}
		}

		[Token(Token = "0x60006BE")]
		[Address(RVA = "0xB24394", Offset = "0xB24394", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RewindAnimation()
		{
		}
	}
}
