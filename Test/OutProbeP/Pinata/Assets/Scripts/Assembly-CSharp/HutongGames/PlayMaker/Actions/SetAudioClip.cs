using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754480", Offset = "0x754480")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754480", Offset = "0x754480")]
	[Token(Token = "0x200018B")]
	public class SetAudioClip : ComponentAction<AudioSource>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AB3D8", Offset = "0x7AB3D8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB3D8", Offset = "0x7AB3D8")]
		[Token(Token = "0x40012B2")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7AB470", Offset = "0x7AB470")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB470", Offset = "0x7AB470")]
		[Token(Token = "0x40012B3")]
		[FieldOffset(Offset = "0x68")]
		public FsmObject audioClip;

		[Token(Token = "0x6000879")]
		[Address(RVA = "0xB2BDCC", Offset = "0xB2BDCC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.audioClip = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			audioClip = null;
		}

		[Token(Token = "0x600087A")]
		[Address(RVA = "0xB2BDD4", Offset = "0xB2BDD4", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDC3F0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202261A]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetAudioClip)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::UpdateCache(this, v43);\n\tv68 = v50 == 0;\n\tif (v68) goto L_0051;\n\tv56 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::get_audio(this);\n\tv57 = HutongGames.PlayMaker.FsmObject::get_Value(this.audioClip);\n\tv109 = v57 == 0;\n\tif (v109) goto L_FFFFFFFF;\n\tv152 = *([v57 @ X0_v15 (UnityEngine.Object)]) != UnityEngine.AudioClip;\n\tif (v152) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tUnityEngine.AudioSource::set_clip(v56, v105);\nL_0051:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAudioClip)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				AudioSource audioSource = base.audio;
				Object value = audioClip.Value;
				AudioClip clip;
				if ((object)value != null)
				{
					Object obj = (((object)value.GetType() != typeof(AudioClip)) ? null : value);
					clip = (AudioClip)obj;
				}
				else
				{
					clip = null;
				}
				audioSource.clip = clip;
			}
			Finish();
		}

		[Token(Token = "0x600087B")]
		[Address(RVA = "0xB2BEB8", Offset = "0xB2BEB8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB5B30]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202261B]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.AudioSource>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAudioClip()
		{
		}
	}
}
