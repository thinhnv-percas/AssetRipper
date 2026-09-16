using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754570", Offset = "0x754570")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754570", Offset = "0x754570")]
	[Token(Token = "0x200018E")]
	public class SetAudioVolume : ComponentAction<AudioSource>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AB5E0", Offset = "0x7AB5E0")]
		[Token(Token = "0x40012B9")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AB654", Offset = "0x7AB654")]
		[Token(Token = "0x40012BA")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat volume;

		[Token(Token = "0x40012BB")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000884")]
		[Address(RVA = "0xB2C1E4", Offset = "0xB2C1E4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.volume = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 1f;
			volume = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000885")]
		[Address(RVA = "0xB2C218", Offset = "0xB2C218", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAudioVolume::DoSetAudioVolume(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetAudioVolume();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000886")]
		[Address(RVA = "0xB2C328", Offset = "0xB2C328", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAudioVolume::DoSetAudioVolume(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetAudioVolume();
		}

		[Token(Token = "0x6000887")]
		[Address(RVA = "0xB2C254", Offset = "0xB2C254", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF7CF0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022620]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetAudioVolume)+30]), this.gameObject);\n\tv57 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::UpdateCache(this, v43);\n\tv77 = v57 == 0;\n\tif (v77) goto L_002F;\n\tv81 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.volume);\n\tv83 = v81 == 0;\n\tif (v83) goto L_0034;\nL_002F:\n\treturn;\nL_0034:\n\tv65 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::get_audio(this);\n\tv59 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\tUnityEngine.AudioSource::set_volume(v65, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetAudioVolume()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAudioVolume)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget) && !volume.IsNone)
			{
				AudioSource audioSource = base.audio;
				float value = volume.Value;
				audioSource.volume = value;
			}
		}

		[Token(Token = "0x6000888")]
		[Address(RVA = "0xB2C32C", Offset = "0xB2C32C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDE308]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022621]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAudioVolume()
		{
		}
	}
}
