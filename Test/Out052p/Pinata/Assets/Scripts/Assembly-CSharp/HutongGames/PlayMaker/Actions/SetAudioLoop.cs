using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7544D0", Offset = "0x7544D0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7544D0", Offset = "0x7544D0")]
	[Token(Token = "0x200018C")]
	public class SetAudioLoop : ComponentAction<AudioSource>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AB4F8", Offset = "0x7AB4F8")]
		[Token(Token = "0x40012B4")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40012B5")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool loop;

		[Token(Token = "0x600087C")]
		[Address(RVA = "0xB2BF08", Offset = "0xB2BF08", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.loop = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			loop = fsmBool;
		}

		[Token(Token = "0x600087D")]
		[Address(RVA = "0xB2BF38", Offset = "0xB2BF38", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F10E80]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202261C]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetAudioLoop)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::UpdateCache(this, v43);\n\tv68 = v50 == 0;\n\tif (v68) goto L_003B;\n\tv56 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::get_audio(this);\n\tv57 = HutongGames.PlayMaker.FsmBool::get_Value(this.loop);\n\tUnityEngine.AudioSource::set_loop(v56, v57);\nL_003B:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAudioLoop)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				AudioSource audioSource = base.audio;
				bool value = loop.Value;
				audioSource.loop = value;
			}
			Finish();
		}

		[Token(Token = "0x600087E")]
		[Address(RVA = "0xB2BFFC", Offset = "0xB2BFFC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED7C80]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202261D]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAudioLoop()
		{
		}
	}
}
