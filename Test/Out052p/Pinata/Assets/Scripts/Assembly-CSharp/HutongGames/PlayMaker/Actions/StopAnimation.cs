using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752424", Offset = "0x752424")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752424", Offset = "0x752424")]
	[Token(Token = "0x200012B")]
	public class StopAnimation : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A32FC", Offset = "0x7A32FC")]
		[Token(Token = "0x40010F2")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3370", Offset = "0x7A3370")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A3370", Offset = "0x7A3370")]
		[Token(Token = "0x40010F3")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[Token(Token = "0x60006CE")]
		[Address(RVA = "0x99E3A8", Offset = "0x99E3A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.animName = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			animName = null;
		}

		[Token(Token = "0x60006CF")]
		[Address(RVA = "0x99E3B0", Offset = "0x99E3B0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StopAnimation::DoStopAnimation(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoStopAnimation();
			Finish();
		}

		[Token(Token = "0x60006D0")]
		[Address(RVA = "0x99E3D8", Offset = "0x99E3D8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0F320]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217BA]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.StopAnimation)+30]), this.gameObject);\n\tv65 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, v45);\n\tv81 = v65 == 0;\n\tif (v81) goto L_0042;\n\tv84 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(this.animName);\n\tv71 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv117 = v84 == 0;\n\tif (v117) goto L_0047;\n\tUnityEngine.Animation::Stop(v71);\n\treturn;\nL_0042:\n\treturn;\nL_0047:\n\tv72 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tUnityEngine.Animation::Stop(v71, v72);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoStopAnimation()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.StopAnimation)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				bool flag = FsmString.IsNullOrEmpty(animName);
				Animation animation = base.animation;
				if (flag)
				{
					animation.Stop();
					return;
				}
				string value = animName.Value;
				animation.Stop(value);
			}
		}

		[Token(Token = "0x60006D1")]
		[Address(RVA = "0x99E4D4", Offset = "0x99E4D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StopAnimation()
		{
		}
	}
}
