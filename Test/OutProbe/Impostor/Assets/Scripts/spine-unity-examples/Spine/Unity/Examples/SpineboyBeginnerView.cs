using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000025")]
	public class SpineboyBeginnerView : MonoBehaviour
	{
		[Header("Components")]
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x20")]
		public SpineboyBeginnerModel model;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x28")]
		public SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x30")]
		public AnimationReferenceAsset run;

		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x38")]
		public AnimationReferenceAsset idle;

		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x40")]
		public AnimationReferenceAsset aim;

		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x48")]
		public AnimationReferenceAsset shoot;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x50")]
		public AnimationReferenceAsset jump;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x58")]
		public EventDataReferenceAsset footstepEvent;

		[Header("Audio")]
		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x60")]
		public float footstepPitchOffset;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x64")]
		public float gunsoundPitchOffset;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x68")]
		public AudioSource footstepSource;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x70")]
		public AudioSource gunSource;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x78")]
		public AudioSource jumpSource;

		[Header("Effects")]
		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x80")]
		public ParticleSystem gunParticles;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x88")]
		private SpineBeginnerBodyState previousViewState;

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x150D2DC", Offset = "0x150D2DC", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = UnityEngine.Object;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv113 = Il2CppMethodInfo;\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv117 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v117, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37A11]) = v40;\nL_002B:\n\tgoto L_0030;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0030:\n\tv54 = UnityEngine.Object::op_Equality(this.skeletonAnimation, 0);\n\tv59 = v54 == 0;\n\tif (v59) goto L_0041;\n\treturn;\nL_0041:\n\tv74 = new System.Action();\n\tSystem.Action::.ctor(v74, this, Il2CppMethodInfo);\n\tSpine.Unity.Examples.SpineboyBeginnerModel::add_ShootEvent(this.model, v74);\n\tv130 = new System.Action();\n\tSystem.Action::.ctor(v130, this, Il2CppMethodInfo);\n\tSpine.Unity.Examples.SpineboyBeginnerModel::add_StartAimEvent(this.model, v130);\n\tv131 = new System.Action();\n\tSystem.Action::.ctor(v131, this, Il2CppMethodInfo);\n\tSpine.Unity.Examples.SpineboyBeginnerModel::add_StopAimEvent(this.model, v131);\n\tv139 = this.skeletonAnimation;\n\tv133 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v133, this, Il2CppMethodInfo);\n\tSpine.AnimationState::add_Event(v139.state, v133);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (!(this.skeletonAnimation == null))
			{
				Action value = PlayShoot;
				model.ShootEvent += value;
				Action value2 = StartPlayingAim;
				model.StartAimEvent += value2;
				Action value3 = StopPlayingAim;
				model.StopAimEvent += value3;
				SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
				AnimationState.TrackEntryEventDelegate value4 = HandleEvent;
				skeletonAnimation.state.Event += value4;
			}
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x150D4A0", Offset = "0x150D4A0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = Spine.Unity.EventDataReferenceAsset::get_EventData(this.footstepEvent);\n\tv37 = e.data == v32;\n\tif (v37) goto L_0021;\n\treturn;\nL_0021:\n\tSpine.Unity.Examples.SpineboyBeginnerView::PlayFootstepSound(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleEvent(TrackEntry trackEntry, Event e)
		{
			EventData eventData = footstepEvent.EventData;
			if (e.Data == eventData)
			{
				PlayFootstepSound();
			}
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x150D538", Offset = "0x150D538", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A12]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Equality(this.skeletonAnimation, 0);\n\tv50 = v48 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0074;\n\tgoto L_002C;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v52, v46, v47, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tv99 = UnityEngine.Object::op_Equality(this.model, 0);\n\tv152 = v99 == 0;\n\tv102 = ~v152;\n\tif (v102) goto L_0074;\n\tv153 = this.skeletonAnimation;\n\tv155 = v153.skeleton;\n\tv201 = this.model;\n\tv176 = v155.scaleX < 0;\n\tv186 = v201.facingLeft == v176;\n\tif (v186) goto L_0066;\n\tv162 = v201.facingLeft == 0;\n\tv157 = ~v162;\n\tSpine.Unity.Examples.SpineboyBeginnerView::Turn(this, v157);\n\tv201 = this.model;\nL_0066:\n\tv76 = this.previousViewState == v201.state;\n\tif (v76) goto L_006E;\n\tSpine.Unity.Examples.SpineboyBeginnerView::PlayNewStableAnimation(this);\nL_006E:\n\tthis.previousViewState = v201.state;\nL_0074:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (!(this.skeletonAnimation == null) && !(model == null))
			{
				SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
				Skeleton skeleton = skeletonAnimation.skeleton;
				SpineboyBeginnerModel spineboyBeginnerModel = model;
				bool flag = skeleton.ScaleX < 0f;
				if (spineboyBeginnerModel.facingLeft != flag)
				{
					bool flag2 = !spineboyBeginnerModel.facingLeft;
					bool facingLeft = !flag2;
					Turn(facingLeft);
					spineboyBeginnerModel = model;
				}
				if (previousViewState != spineboyBeginnerModel.state)
				{
					PlayNewStableAnimation();
				}
				previousViewState = spineboyBeginnerModel.state;
			}
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x150D66C", Offset = "0x150D66C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.model;\n\tv15 = v6.state == 2;\n\tif (v15) goto L_0025;\n\tv99 = this.previousViewState != 2;\n\tif (v99) goto L_0025;\n\tSpine.Unity.Examples.SpineboyBeginnerView::PlayFootstepSound(this);\nL_0025:\n\tv115 = v6.state == 1;\n\tif (v115) goto L_003D;\n\tv32 = v6.state != 2;\n\tif (v32) goto L_003F;\n\tUnityEngine.AudioSource::Play(this.jumpSource);\n\tv153 = this + 0x50;\n\tgoto L_0042;\nL_003D:\n\tv153 = this + 0x30;\n\tgoto L_0042;\nL_003F:\n\tv153 = this + 0x38;\nL_0042:\n\tv28 = Spine.Unity.AnimationReferenceAsset::op_Implicit(*([v153 @ X8_v4]));\n\tv74 = this.skeletonAnimation;\n\tv132 = Spine.AnimationState::SetAnimation(v74.state, 0, v28, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PlayNewStableAnimation()
		{
			//IL_00cd: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_00bc: Expected O, but got I
			SpineboyBeginnerModel spineboyBeginnerModel = model;
			if (spineboyBeginnerModel.state != SpineBeginnerBodyState.Jumping && previousViewState == SpineBeginnerBodyState.Jumping)
			{
				PlayFootstepSound();
			}
			object obj;
			if (spineboyBeginnerModel.state != SpineBeginnerBodyState.Running)
			{
				if (spineboyBeginnerModel.state == SpineBeginnerBodyState.Jumping)
				{
					jumpSource.Play();
					obj = (nint)this + 80;
				}
				else
				{
					obj = (nint)this + 56;
				}
			}
			else
			{
				obj = (nint)this + 48;
			}
			Animation animation = (AnimationReferenceAsset)obj;
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(0, animation, loop: true);
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x150D4EC", Offset = "0x150D4EC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.AudioSource::Play(this.footstepSource);\n\tv36 = -this.footstepPitchOffset;\n\tv11 = UnityEngine.Random::Range(v36, this.footstepPitchOffset);\n\tv40 = v11 + 1f;\n\tUnityEngine.AudioSource::set_pitch(this.footstepSource, v40);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PlayFootstepSound()
		{
			footstepSource.Play();
			float minInclusive = 0f - footstepPitchOffset;
			float num = UnityEngine.Random.Range(minInclusive, footstepPitchOffset);
			float pitch = num + 1f;
			footstepSource.pitch = pitch;
		}

		[ContextMenu("Check Tracks")]
		[Token(Token = "0x6000090")]
		[Address(RVA = "0x150D734", Offset = "0x150D734", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37A13]) = v33;\nL_0010:\n\tv34 = this.skeletonAnimation;\n\tv46 = Spine.AnimationState::GetCurrent(v34.state, 0);\n\tgoto L_0026;\n\tv68 = v47;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v68, v44, v45, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\tUnityEngine.Debug::Log(v46);\n\tv61 = Spine.AnimationState::GetCurrent(v34.state, 1);\n\tUnityEngine.Debug::Log(v61);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckTracks()
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			TrackEntry current = skeletonAnimation.state.GetCurrent(0);
			Debug.Log(current);
			TrackEntry current2 = skeletonAnimation.state.GetCurrent(1);
			Debug.Log(current2);
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x150D7D0", Offset = "0x150D7D0", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.skeletonAnimation;\n\tv15 = Spine.Unity.AnimationReferenceAsset::op_Implicit(this.shoot);\n\tv57 = Spine.AnimationState::SetAnimation(v8.state, 1, v15, 0);\n\tv57.attachmentThreshold = 1f;\n\tv57.mixDuration = 0f;\n\tv84 = this.skeletonAnimation;\n\tv59 = Spine.AnimationState::AddEmptyAnimation(v84.state, 1, 0.5f, 0.1f);\n\tv59.attachmentThreshold = 1f;\n\tv86 = this.skeletonAnimation;\n\tv60 = Spine.Unity.AnimationReferenceAsset::op_Implicit(this.aim);\n\tv61 = Spine.AnimationState::SetAnimation(v86.state, 2, v60, 0);\n\tv61.attachmentThreshold = 1f;\n\tv61.mixDuration = 0f;\n\tv87 = this.skeletonAnimation;\n\tv63 = Spine.AnimationState::AddEmptyAnimation(v87.state, 2, 0.5f, 0.1f);\n\tv63.attachmentThreshold = 1f;\n\tv123 = -this.gunsoundPitchOffset;\n\tv26 = UnityEngine.Random::Range(v123, this.gunsoundPitchOffset);\n\tv27 = v26 + 1f;\n\tUnityEngine.AudioSource::set_pitch(this.gunSource, v27);\n\tUnityEngine.AudioSource::Play(this.gunSource);\n\tUnityEngine.ParticleSystem::Play(this.gunParticles);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayShoot()
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			Animation animation = shoot;
			TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(1, animation, loop: false);
			trackEntry.AttachmentThreshold = 1f;
			trackEntry.MixDuration = 0f;
			SkeletonAnimation skeletonAnimation2 = this.skeletonAnimation;
			TrackEntry trackEntry2 = skeletonAnimation2.state.AddEmptyAnimation(1, 0.5f, 0.1f);
			trackEntry2.AttachmentThreshold = 1f;
			SkeletonAnimation skeletonAnimation3 = this.skeletonAnimation;
			Animation animation2 = aim;
			TrackEntry trackEntry3 = skeletonAnimation3.state.SetAnimation(2, animation2, loop: false);
			trackEntry3.AttachmentThreshold = 1f;
			trackEntry3.MixDuration = 0f;
			SkeletonAnimation skeletonAnimation4 = this.skeletonAnimation;
			TrackEntry trackEntry4 = skeletonAnimation4.state.AddEmptyAnimation(2, 0.5f, 0.1f);
			trackEntry4.AttachmentThreshold = 1f;
			float minInclusive = 0f - gunsoundPitchOffset;
			float num = UnityEngine.Random.Range(minInclusive, gunsoundPitchOffset);
			float pitch = num + 1f;
			gunSource.pitch = pitch;
			gunSource.Play();
			gunParticles.Play();
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x150D92C", Offset = "0x150D92C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.skeletonAnimation;\n\tv10 = Spine.Unity.AnimationReferenceAsset::op_Implicit(this.aim);\n\tv25 = Spine.AnimationState::SetAnimation(v4.state, 2, v10, 1);\n\tv25.attachmentThreshold = 1f;\n\tv25.mixDuration = 0f;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StartPlayingAim()
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			Animation animation = aim;
			TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(2, animation, loop: true);
			trackEntry.AttachmentThreshold = 1f;
			trackEntry.MixDuration = 0f;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x150D980", Offset = "0x150D980", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.skeletonAnimation;\n\tv20 = Spine.AnimationState::AddEmptyAnimation(v2.state, 2, 0.5f, 0.1f);\n\tv20.attachmentThreshold = 1f;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StopPlayingAim()
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			TrackEntry trackEntry = skeletonAnimation.state.AddEmptyAnimation(2, 0.5f, 0.1f);
			trackEntry.AttachmentThreshold = 1f;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x150D630", Offset = "0x150D630", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv33 = facingLeft == 0;\n\tv38 = ~v33;\n\tv39 = ~v38;\n\tif (v39) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\tv10.scaleX = v48;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Turn(bool facingLeft)
		{
			Skeleton skeleton = skeletonAnimation.Skeleton;
			float scaleX = ((!facingLeft) ? 1f : (-1f));
			skeleton.ScaleX = scaleX;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x150D710", Offset = "0x150D710", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = -maxPitchOffset;\n\tv6 = UnityEngine.Random::Range(v4, maxPitchOffset);\n\treturnVal1 = v6 + 1f;\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetRandomPitch(float maxPitchOffset)
		{
			float minInclusive = 0f - maxPitchOffset;
			float num = UnityEngine.Random.Range(minInclusive, maxPitchOffset);
			return num + 1f;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x150D9C4", Offset = "0x150D9C4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.footstepPitchOffset = 6.146728652109412E-10d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyBeginnerView()
		{
			footstepPitchOffset = 0.2f;
			gunsoundPitchOffset = 0.13f;
		}
	}
}
