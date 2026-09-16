using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754294", Offset = "0x754294")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x754294", Offset = "0x754294")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x754294", Offset = "0x754294")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754294", Offset = "0x754294")]
	[Token(Token = "0x2000187")]
	public class AudioPlay : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AAF1C", Offset = "0x7AAF1C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAF1C", Offset = "0x7AAF1C")]
		[Token(Token = "0x400129F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AAFB4", Offset = "0x7AAFB4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAFB4", Offset = "0x7AAFB4")]
		[Token(Token = "0x40012A0")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat volume;

		[Attribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7AB008", Offset = "0x7AB008")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB008", Offset = "0x7AB008")]
		[Token(Token = "0x40012A1")]
		[FieldOffset(Offset = "0x60")]
		public FsmObject oneShotClip;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB090", Offset = "0x7AB090")]
		[Token(Token = "0x40012A2")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool WaitForEndOfClip;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB0C8", Offset = "0x7AB0C8")]
		[Token(Token = "0x40012A3")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishedEvent;

		[Token(Token = "0x40012A4")]
		[FieldOffset(Offset = "0x78")]
		private AudioSource audio;

		[Token(Token = "0x600086A")]
		[Address(RVA = "0xA8AB88", Offset = "0xA8AB88", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.volume = v12;\n\tthis.oneShotClip = 0;\n\tthis.finishedEvent = 0;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.WaitForEndOfClip = v15;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 1f;
			volume = fsmFloat;
			oneShotClip = null;
			finishedEvent = null;
			FsmBool waitForEndOfClip = true;
			WaitForEndOfClip = waitForEndOfClip;
		}

		[Token(Token = "0x600086B")]
		[Address(RVA = "0xA8ABCC", Offset = "0xA8ABCC", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F00148]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221C0]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv159 = *([v121 @ X8_v5+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_002B;\n\tv166 = v121;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v166, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv146 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv168 = v146 == 0;\n\tif (v168) goto L_00CE;\n\tv240 = UnityEngine.GameObject::GetComponent(v45);\n\tthis.audio = v240;\n\tgoto L_0045;\n\tv245 = *([v241 @ X0_v16+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_0045;\n\tv249 = \"il2cpp_codegen_runtime_class_init\"(v241, v239, v140, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv233 = UnityEngine.Object::op_Inequality(v240, 0);\n\tv234 = v233 == 0;\n\tif (v234) goto L_00CE;\n\tv254 = HutongGames.PlayMaker.FsmObject::get_Value(this.oneShotClip);\n\tv255 = v254 == 0;\n\tif (v255) goto L_FFFFFFFF;\n\tv269 = *([v254 @ X0_v21 (UnityEngine.Object)]) != UnityEngine.AudioClip;\n\tif (v269) goto L_FFFFFFFF;\n\tgoto L_0063;\nL_0063:\n\tgoto L_0069;\nL_0069:\n\tgoto L_0072;\n\tv279 = *([v275 @ X0_v22+E0]);\n\tv280 = v279 == 0;\n\tv281 = ~v280;\n\tgoto L_0072;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v275, v253, v83, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0072:\n\tv286 = UnityEngine.Object::op_Equality(v117, 0);\n\tv288 = v286 == 0;\n\tif (v288) goto L_009A;\n\tUnityEngine.AudioSource::Play(this.audio);\n\tv291 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.volume);\n\tv293 = v291 == 0;\n\tv294 = ~v293;\n\tif (v294) goto L_00BF;\n\tv126 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\tUnityEngine.AudioSource::set_volume(this.audio, v126);\n\treturn;\nL_009A:\n\tv147 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.volume);\n\tv290 = v147 == 0;\n\tif (v290) goto L_00AA;\n\tUnityEngine.AudioSource::PlayOneShot(this.audio, v117);\n\tgoto L_00B5;\nL_00AA:\n\tv127 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\tUnityEngine.AudioSource::PlayOneShot(this.audio, v117, v127);\nL_00B5:\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.WaitForEndOfClip);\n\tv300 = v299 == 0;\n\tif (v300) goto L_00C5;\nL_00BF:\n\treturn;\nL_00C5:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishedEvent);\nL_00CE:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null && (audio = ownerDefaultTarget.GetComponent<AudioSource>()) != null)
			{
				Object value = oneShotClip.Value;
				Object obj = (((object)value == null) ? null : (((object)value.GetType() != typeof(AudioClip)) ? null : value));
				if (obj == null)
				{
					audio.Play();
					if (!volume.IsNone)
					{
						float value2 = volume.Value;
						audio.volume = value2;
					}
					return;
				}
				if (volume.IsNone)
				{
					audio.PlayOneShot((AudioClip)obj);
				}
				else
				{
					float value3 = volume.Value;
					audio.PlayOneShot((AudioClip)obj, value3);
				}
				if (WaitForEndOfClip.Value)
				{
					return;
				}
				Fsm.Event(finishedEvent);
			}
			Finish();
		}

		[Token(Token = "0x600086C")]
		[Address(RVA = "0xA8AE04", Offset = "0xA8AE04", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EF3990]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221C1]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.audio, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_006F;\n\tv80 = UnityEngine.AudioSource::get_isPlaying(this.audio);\n\tv126 = v80 == 0;\n\tif (v126) goto L_0066;\n\tv189 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.volume);\n\tv191 = v189 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_0077;\n\tv108 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\tv109 = UnityEngine.AudioSource::get_volume(this.audio);\n\tv95 = v108 == v109;\n\tif (v95) goto L_0077;\n\tv137 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\tUnityEngine.AudioSource::set_volume(this.audio, v137);\n\treturn;\nL_0066:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishedEvent);\nL_006F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0077:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (!(audio == null))
			{
				if (audio.isPlaying)
				{
					if (!volume.IsNone)
					{
						float value = volume.Value;
						float num = audio.volume;
						if (value != num)
						{
							float value2 = volume.Value;
							audio.volume = value2;
						}
					}
					return;
				}
				Fsm.Event(finishedEvent);
			}
			Finish();
		}

		[Token(Token = "0x600086D")]
		[Address(RVA = "0xA8AF40", Offset = "0xA8AF40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AudioPlay()
		{
		}
	}
}
