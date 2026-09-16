using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200002A")]
	public class HandleEventWithAudioExample : MonoBehaviour
	{
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation skeletonAnimation;

		[SpineEvent(null, "skeletonAnimation", true, true, false)]
		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x28")]
		public string eventName;

		[Space]
		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x30")]
		public AudioSource audioSource;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x38")]
		public AudioClip audioClip;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x40")]
		public float basePitch;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x44")]
		public float randomPitchOffset;

		[Space]
		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x48")]
		public bool logDebugMessage;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x50")]
		private EventData eventData;

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x150E14C", Offset = "0x150E14C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A1C]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonAnimation, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_0031;\n\tv61 = UnityEngine.Component::GetComponent(this);\nL_0031:\n\tgoto L_0036;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v65, v62, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0036:\n\tv75 = UnityEngine.Object::op_Equality(this.audioSource, 0);\n\tv77 = v75 == 0;\n\tif (v77) goto L_004A;\n\tv86 = UnityEngine.Component::GetComponent(this);\n\treturn;\nL_004A:\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			if (skeletonAnimation == null)
			{
				SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			}
			if (audioSource == null)
			{
				AudioSource component2 = GetComponent<AudioSource>();
			}
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x150E224", Offset = "0x150E224", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A1D]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Equality(this.audioSource, 0);\n\tv56 = v52 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0070;\n\tgoto L_0032;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v58, v50, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0032:\n\tv73 = UnityEngine.Object::op_Equality(this.skeletonAnimation, 0);\n\tv119 = v73 == 0;\n\tv76 = ~v119;\n\tif (v76) goto L_0070;\n\tv123 = Spine.Unity.SkeletonAnimation::Initialize(this.skeletonAnimation, 0);\n\tv74 = this.skeletonAnimation;\n\tv77 = ~v74.valid;\n\tif (v77) goto L_0070;\n\tv131 = Spine.Unity.SkeletonRenderer::get_Skeleton(v74);\n\tv133 = Spine.SkeletonData::FindEvent(v131.data, this.eventName);\n\tv138 = this.skeletonAnimation;\n\tthis.eventData = v133;\n\tv134 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v134, this, Il2CppMethodInfo);\n\tSpine.AnimationState::add_Event(v138.state, v134);\n\treturn;\nL_0070:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (!(audioSource == null) && !(this.skeletonAnimation == null))
			{
				this.skeletonAnimation.Initialize(overwrite: false);
				SkeletonRenderer skeletonRenderer = this.skeletonAnimation;
				if (skeletonRenderer.valid)
				{
					Skeleton skeleton = skeletonRenderer.Skeleton;
					EventData eventData = skeleton.Data.FindEvent(eventName);
					SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
					this.eventData = eventData;
					AnimationState.TrackEntryEventDelegate value = HandleAnimationStateEvent;
					skeletonAnimation.state.Event += value;
				}
			}
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x150E370", Offset = "0x150E370", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, trackEntry, e, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = \"Event fired! \";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, trackEntry, e, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37A1E]) = v37;\nL_0016:\n\tv39 = ~this.logDebugMessage;\n\tif (v39) goto L_0039;\n\tv44 = e.data;\n\tv81 = System.String::Concat(\"Event fired! \", v44.name);\n\tgoto L_002F;\n\tv118 = v61;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v118, v77, v50, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002F:\n\tUnityEngine.Debug::Log(v81);\n\tgoto L_0039;\nL_0039:\n\tv70 = this.eventData == e.data;\n\tif (v70) goto L_004B;\n\treturn;\nL_004B:\n\tSpine.Unity.Examples.HandleEventWithAudioExample::Play(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleAnimationStateEvent(TrackEntry trackEntry, Event e)
		{
			if (logDebugMessage)
			{
				EventData data = e.Data;
				string message = "Event fired! " + data.Name;
				Debug.Log(message);
			}
			if (eventData == e.Data)
			{
				Play();
			}
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x150E43C", Offset = "0x150E43C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = -this.randomPitchOffset;\n\tv15 = UnityEngine.Random::Range(v14, this.randomPitchOffset);\n\tv17 = this.basePitch + v15;\n\tUnityEngine.AudioSource::set_pitch(this.audioSource, v17);\n\tUnityEngine.AudioSource::set_clip(this.audioSource, this.audioClip);\n\tUnityEngine.AudioSource::Play(this.audioSource);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Play()
		{
			float minInclusive = 0f - randomPitchOffset;
			float num = Random.Range(minInclusive, randomPitchOffset);
			float pitch = basePitch + num;
			audioSource.pitch = pitch;
			audioSource.clip = audioClip;
			audioSource.Play();
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x150E4A8", Offset = "0x150E4A8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.basePitch = 5.2386907257919585E-11d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HandleEventWithAudioExample()
		{
			basePitch = 1f;
			randomPitchOffset = 0.1f;
		}
	}
}
