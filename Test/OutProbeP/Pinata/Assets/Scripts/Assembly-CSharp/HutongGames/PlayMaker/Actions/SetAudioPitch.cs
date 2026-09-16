using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754520", Offset = "0x754520")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754520", Offset = "0x754520")]
	[Token(Token = "0x200018D")]
	public class SetAudioPitch : ComponentAction<AudioSource>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AB56C", Offset = "0x7AB56C")]
		[Token(Token = "0x40012B6")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40012B7")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat pitch;

		[Token(Token = "0x40012B8")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x600087F")]
		[Address(RVA = "0xB2C04C", Offset = "0xB2C04C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.pitch = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 1f;
			pitch = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000880")]
		[Address(RVA = "0xB2C080", Offset = "0xB2C080", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAudioPitch::DoSetAudioPitch(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetAudioPitch();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000881")]
		[Address(RVA = "0xB2C190", Offset = "0xB2C190", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAudioPitch::DoSetAudioPitch(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetAudioPitch();
		}

		[Token(Token = "0x6000882")]
		[Address(RVA = "0xB2C0BC", Offset = "0xB2C0BC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFDF38]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202261E]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetAudioPitch)+30]), this.gameObject);\n\tv57 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::UpdateCache(this, v43);\n\tv77 = v57 == 0;\n\tif (v77) goto L_002F;\n\tv81 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.pitch);\n\tv83 = v81 == 0;\n\tif (v83) goto L_0034;\nL_002F:\n\treturn;\nL_0034:\n\tv65 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::get_audio(this);\n\tv59 = HutongGames.PlayMaker.FsmFloat::get_Value(this.pitch);\n\tUnityEngine.AudioSource::set_pitch(v65, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetAudioPitch()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAudioPitch)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget) && !pitch.IsNone)
			{
				AudioSource audioSource = base.audio;
				float value = pitch.Value;
				audioSource.pitch = value;
			}
		}

		[Token(Token = "0x6000883")]
		[Address(RVA = "0xB2C194", Offset = "0xB2C194", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EEEFA8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202261F]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAudioPitch()
		{
		}
	}
}
