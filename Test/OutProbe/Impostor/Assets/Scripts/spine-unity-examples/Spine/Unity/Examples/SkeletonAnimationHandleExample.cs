using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000031")]
	public class SkeletonAnimationHandleExample : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000032")]
		public class StateNameToAnimationReference
		{
			[Token(Token = "0x400010E")]
			[FieldOffset(Offset = "0x10")]
			public string stateName;

			[Token(Token = "0x400010F")]
			[FieldOffset(Offset = "0x18")]
			public AnimationReferenceAsset animation;

			[Token(Token = "0x60000CA")]
			[Address(RVA = "0x150F670", Offset = "0x150F670", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public StateNameToAnimationReference()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000033")]
		public class AnimationTransition
		{
			[Token(Token = "0x4000110")]
			[FieldOffset(Offset = "0x10")]
			public AnimationReferenceAsset from;

			[Token(Token = "0x4000111")]
			[FieldOffset(Offset = "0x18")]
			public AnimationReferenceAsset to;

			[Token(Token = "0x4000112")]
			[FieldOffset(Offset = "0x20")]
			public AnimationReferenceAsset transition;

			[Token(Token = "0x60000CB")]
			[Address(RVA = "0x150F678", Offset = "0x150F678", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AnimationTransition()
			{
			}
		}

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x28")]
		public List<StateNameToAnimationReference> statesAndAnimations;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x30")]
		public List<AnimationTransition> transitions;

		[CompilerGenerated]
		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x38")]
		private Animation _003CTargetAnimation_003Ek__BackingField;

		[Token(Token = "0x17000016")]
		public Animation TargetAnimation
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BC")]
			[Address(RVA = "0x150EE74", Offset = "0x150EE74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TargetAnimation>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TargetAnimation;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0x150EE7C", Offset = "0x150EE7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TargetAnimation>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTargetAnimation_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x150EE84", Offset = "0x150EE84", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv161 = Il2CppMethodInfo;\n\tv162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv169 = Il2CppMethodInfo;\n\tv170 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv193 = Il2CppMethodInfo;\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv209 = Il2CppMethodInfo;\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv218 = Il2CppMethodInfo;\n\tv219 = \"il2cpp_codegen_initialize_runtime_metadata\"(v218, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv241 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v241, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A2C]) = v42;\nL_0030:\n\tv50 = this.statesAndAnimations == 0;\n\tif (v50) goto L_008C;\n\tv69 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::GetEnumerator(this.statesAndAnimations);\nL_0047:\n\tv181 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v68 @ stack_-98_v9 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv196 = v181 == 0;\n\tif (v196) goto L_0056;\n\tSpine.Unity.AnimationReferenceAsset::Initialize(*([v165 @ stack_-88+18]));\n\tgoto L_0047;\nL_0056:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v68 @ stack_-98_v9 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0058:\n\tv149 = v152.transitions == 0;\n\tif (v149) goto L_008C;\n\tv248 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+AnimationTransition>::GetEnumerator(v152.transitions);\nL_0061:\n\t;\n\tv400 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v68 @ stack_-98_v9 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv334 = v400 == 0;\n\tif (v334) goto L_007C;\n\tSpine.Unity.AnimationReferenceAsset::Initialize(*([v165 @ stack_-88+10]));\n\tSpine.Unity.AnimationReferenceAsset::Initialize(*([v165 @ stack_-88+18]));\n\tSpine.Unity.AnimationReferenceAsset::Initialize(*([v165 @ stack_-88+20]));\n\tgoto L_0061;\nL_007C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v68 @ stack_-98_v9 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0085:\n\treturn;\n\tv220 = new System.NullReferenceException();\n\tv244 = new System.NullReferenceException();\n\tv307 = new System.NullReferenceException();\n\tv393 = new System.NullReferenceException();\n\tv464 = new System.NullReferenceException();\n\tv145 = new System.NullReferenceException();\nL_008C:\n\tv159 = new System.NullReferenceException();\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\nL_00A0:\n\tv191 = v135 != 1;\n\tif (v191) goto L_00AE;\n\tv197 = 0x1854E70(v159, v135, v25, v26, v27, v28, v29, v30, v122, v32, v33, v34, v35, v36, v37, v38);\n\tv214 = 0x1854E80(v197, v135, v25, v26, v27, v28, v29, v30, v122, v32, v33, v34, v35, v36, v37, v38);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v115 @ stack_-80_v8 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv203 = *([v197 @ X0_v24]) == 0;\n\tif (v203) goto L_0085;\n\tv200 = new System.OutOfMemoryException();\nL_00AE:\n\tgoto L_00B0;\n\tstack[68] = X0;\nL_00B0:\n\t;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v115 @ stack_-80_v8 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00DC;\n\tv250 = new System.OutOfMemoryException();\nL_00B7:\n\t;\n\tv222 = *([v129 @ X21_v1 (Il2CppMethodInfo)]) != 1;\n\tif (v222) goto L_00D1;\n\tv430 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>+Enumerator<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::Dispose(v250);\n\tv466 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>+Enumerator<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::Dispose(v430);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v121 @ stack_-60_v8 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv235 = *([v430 @ X0_v19 (System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>+Enumerator<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>)]) == 0;\n\tif (v235) goto L_0058;\n\tthrow System.OutOfMemoryException;\nL_00D1:\n\tgoto L_00D7;\n\tstack[68] = X0;\nL_00D7:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v121 @ stack_-60_v8 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00DE;\nL_00DC:\n\tv272 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>+Enumerator<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::Dispose(v251);\nL_00DE:\n\tv363 = new System.OutOfMemoryException();\n\tv424 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>+Enumerator<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::Dispose(v363);\n\treturn;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Awake()
		{
			//IL_002a: Expected O, but got I
			//IL_00d4: Expected O, but got I
			//IL_00eb: Expected O, but got I
			//IL_0102: Expected O, but got I
			bool flag = statesAndAnimations == null;
			nint num = default(nint);
			IntPtr intPtr = num;
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			nint num2 = default(nint);
			if (!flag)
			{
				List<StateNameToAnimationReference>.Enumerator enumerator = statesAndAnimations.GetEnumerator();
				List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
				while (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ stack_-88+18]");
					((AnimationReferenceAsset)0).Initialize();
				}
				enumerator2.Dispose();
				enumerator3 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator4 = enumerator2;
				List<object>.Enumerator enumerator5 = enumerator2;
				num = 0;
				num2 = 0;
				bool flag2 = transitions == null;
				List<object>.Enumerator enumerator6 = default(List<object>.Enumerator);
				enumerator5 = enumerator6;
				IntPtr intPtr2 = default(IntPtr);
				intPtr = intPtr2;
				IntPtr intPtr3 = default(IntPtr);
				num2 = intPtr3;
				if (!flag2)
				{
					List<AnimationTransition>.Enumerator enumerator7 = transitions.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ stack_-88+10]");
						((AnimationReferenceAsset)0).Initialize();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ stack_-88+18]");
						((AnimationReferenceAsset)0).Initialize();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ stack_-88+20]");
						((AnimationReferenceAsset)0).Initialize();
					}
					enumerator2.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag3 = num2 != 1;
			OutOfMemoryException ex2 = (OutOfMemoryException)(object)ex;
			if (!flag3)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator3.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
				ex2 = new OutOfMemoryException();
			}
			enumerator3.Dispose();
			OutOfMemoryException ex3 = ex2;
			((List<StateNameToAnimationReference>.Enumerator*)ex3)->Dispose();
			OutOfMemoryException ex4 = new OutOfMemoryException();
			((List<StateNameToAnimationReference>.Enumerator*)ex4)->Dispose();
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x150BD9C", Offset = "0x150BD9C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = horizontal == 0;\n\tif (v9) goto L_002D;\n\tv40 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv52 = horizontal < 0;\n\tv50 = horizontal == 0;\n\tv46 = horizontal ^ horizontal;\n\tv44 = horizontal & v46;\n\tv42 = v44 < 0;\n\tv96 = v52 == v42;\n\tv21 = ~v50;\n\tv24 = v96 & v21;\n\tv18 = ~v24;\n\tif (v18) goto L_FFFFFFFF;\n\tgoto L_0029;\nL_0029:\n\tv40.scaleX = v30;\nL_002D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFlip(float horizontal)
		{
			//IL_0062: Expected O, but got F4
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected I4, but got Unknown
			if (horizontal != 0f)
			{
				Skeleton skeleton = skeletonAnimation.Skeleton;
				bool flag = horizontal < 0f;
				bool flag2 = horizontal == 0f;
				object obj = horizontal ^ horizontal;
				int num = horizontal & (nint)obj;
				bool flag3 = num < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				float scaleX = ((!(flag4 && flag5)) ? (-1f) : 1f);
				skeleton.ScaleX = scaleX;
			}
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x150BDE8", Offset = "0x150BDE8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Animator::StringToHash(stateShortName);\n\tSpine.Unity.Examples.SkeletonAnimationHandleExample::PlayAnimationForState(this, v13, layerIndex);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayAnimationForState(string stateShortName, int layerIndex)
		{
			int shortNameHash = Animator.StringToHash(stateShortName);
			PlayAnimationForState(shortNameHash, layerIndex);
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x150EE30", Offset = "0x150EE30", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Spine.Unity.Examples.SkeletonAnimationHandleExample::GetAnimationForState(this, shortNameHash);\n\tv12 = v10 == 0;\n\tif (v12) goto L_0016;\n\tSpine.Unity.Examples.SkeletonAnimationHandleExample::PlayNewAnimation(this, v10, layerIndex);\n\treturn;\nL_0016:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayAnimationForState(int shortNameHash, int layerIndex)
		{
			Animation animationForState = GetAnimationForState(shortNameHash);
			if (animationForState != null)
			{
				PlayNewAnimation(animationForState, layerIndex);
			}
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x150F2F8", Offset = "0x150F2F8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.Animator::StringToHash(stateShortName);\n\treturnVal1 = Spine.Unity.Examples.SkeletonAnimationHandleExample::GetAnimationForState(this, v9);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Animation GetAnimationForState(string stateShortName)
		{
			int shortNameHash = Animator.StringToHash(stateShortName);
			return GetAnimationForState(shortNameHash);
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x150F158", Offset = "0x150F158", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, shortNameHash, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv45 = System.Predicate`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, shortNameHash, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, shortNameHash, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv54 = Spine.Unity.Examples.SkeletonAnimationHandleExample+<>c__DisplayClass14_0;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, shortNameHash, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37A2D]) = v41;\nL_001F:\n\tv43 = new Spine.Unity.Examples.SkeletonAnimationHandleExample+<>c__DisplayClass14_0();\n\tSystem.Object::.ctor(v43);\n\tv43.<>4__this = this;\n\tv43.shortNameHash = shortNameHash;\n\tv61 = new System.Predicate`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>();\n\tSystem.Predicate`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::.ctor(v61, v43, Il2CppMethodInfo);\n\tv100 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::Find(this.statesAndAnimations, v61);\n\tv86 = v100 == 0;\n\tif (v86) goto L_0045;\n\tv102 = v100.animation;\nL_0045:\n\treturnVal2 = Spine.Unity.AnimationReferenceAsset::op_Implicit(v102);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Animation GetAnimationForState(int shortNameHash)
		{
			Predicate<StateNameToAnimationReference> match = delegate(StateNameToAnimationReference entry)
			{
				int num = Animator.StringToHash(entry.stateName);
				int num2 = num - shortNameHash;
				return num2 == 0;
			};
			StateNameToAnimationReference stateNameToAnimationReference = statesAndAnimations.Find(match);
			bool flag = stateNameToAnimationReference == null;
			AnimationReferenceAsset animationReferenceAsset = (AnimationReferenceAsset)(object)stateNameToAnimationReference;
			if (!flag)
			{
				animationReferenceAsset = stateNameToAnimationReference.animation;
			}
			return animationReferenceAsset;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x150F244", Offset = "0x150F244", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Spine.Unity.Examples.SkeletonAnimationHandleExample::GetCurrentAnimation(this, layerIndex);\n\tv16 = v15 == 0;\n\tif (v16) goto L_FFFFFFFF;\n\tv20 = Spine.Unity.Examples.SkeletonAnimationHandleExample::TryGetTransition(this, v15, target);\n\tgoto L_0013;\nL_0013:\n\tv27 = this.skeletonAnimation;\n\tv58 = v24 == 0;\n\tif (v58) goto L_0030;\n\tv42 = Spine.AnimationState::SetAnimation(v27.state, layerIndex, v24, 0);\n\tv32 = this.skeletonAnimation;\n\tv92 = Spine.AnimationState::AddAnimation(v32.state, layerIndex, target, 1, 0f);\n\tgoto L_0031;\nL_0030:\n\tv63 = Spine.AnimationState::SetAnimation(v27.state, layerIndex, target, 1);\nL_0031:\n\tthis.<TargetAnimation>k__BackingField = target;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayNewAnimation(Animation target, int layerIndex)
		{
			Animation currentAnimation = GetCurrentAnimation(layerIndex);
			Animation animation2;
			if (currentAnimation != null)
			{
				Animation animation = TryGetTransition(currentAnimation, target);
				animation2 = animation;
			}
			else
			{
				animation2 = null;
			}
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			if (animation2 != null)
			{
				TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(layerIndex, animation2, loop: false);
				SkeletonAnimation skeletonAnimation2 = this.skeletonAnimation;
				TrackEntry trackEntry2 = skeletonAnimation2.state.AddAnimation(layerIndex, target, loop: true, 0f);
			}
			else
			{
				TrackEntry trackEntry3 = skeletonAnimation.state.SetAnimation(layerIndex, target, loop: true);
			}
			TargetAnimation = target;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x150F51C", Offset = "0x150F51C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.skeletonAnimation;\n\tv38 = Spine.AnimationState::SetAnimation(v8.state, 0, oneShot, 0);\n\tv42 = Spine.Unity.Examples.SkeletonAnimationHandleExample::TryGetTransition(this, oneShot, this.<TargetAnimation>k__BackingField);\n\tv64 = v42 == 0;\n\tif (v64) goto L_002B;\n\tv71 = Spine.AnimationState::AddAnimation(v8.state, 0, v42, 0, 0f);\nL_002B:\n\tv56 = Spine.AnimationState::AddAnimation(v8.state, 0, this.<TargetAnimation>k__BackingField, 1, 0f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayOneShot(Animation oneShot, int layerIndex)
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(0, oneShot, loop: false);
			Animation animation = TryGetTransition(oneShot, TargetAnimation);
			if (animation != null)
			{
				TrackEntry trackEntry2 = skeletonAnimation.state.AddAnimation(0, animation, loop: false, 0f);
			}
			TrackEntry trackEntry3 = skeletonAnimation.state.AddAnimation(0, TargetAnimation, loop: true, 0f);
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x150F354", Offset = "0x150F354", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, from, to, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, from, to, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv110 = Il2CppMethodInfo;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, from, to, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv147 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v147, from, to, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A2E]) = v42;\nL_002C:\n\tv60 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+AnimationTransition>::GetEnumerator(this.transitions);\nL_0033:\n\tv177 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v59 @ stack_-68_v4 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv179 = v177 == 0;\n\tif (v179) goto L_FFFFFFFF;\n\tv170 = Spine.Unity.AnimationReferenceAsset::get_Animation(*([v112 @ stack_-58+10]));\n\tv149 = v170 != from;\n\tif (v149) goto L_0033;\n\tv171 = Spine.Unity.AnimationReferenceAsset::get_Animation(*([v112 @ stack_-58+18]));\n\tv114 = v171 != to;\n\tif (v114) goto L_0033;\n\tv141 = *([v112 @ stack_-58+20]) == 0;\n\tif (v141) goto L_0072;\n\tv211 = Spine.Unity.AnimationReferenceAsset::get_Animation(*([v112 @ stack_-58+20]));\n\tgoto L_0064;\nL_0064:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v59 @ stack_-68_v4 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_006D:\n\treturn v253;\n\tv197 = new System.NullReferenceException();\n\tv232 = new System.NullReferenceException();\n\tv101 = new System.NullReferenceException();\n\tv108 = new System.NullReferenceException();\nL_0072:\n\tv145 = new System.NullReferenceException();\n\tgoto L_0084;\n\tgoto L_0084;\n\tgoto L_0084;\n\tgoto L_0084;\n\tgoto L_0084;\n\tgoto L_0084;\n\tgoto L_0084;\nL_0084:\n\tv190 = v136 != 1;\n\tif (v190) goto L_FFFFFFFF;\n\tv194 = 0x1854E70(v145, v136, to, methodInfo, v27, v28, v29, v30, v134, v32, v33, v34, v35, v36, v37, v38);\n\tv225 = *([v194 @ X0_v14]);\n\tv218 = 0x1854E80(v194, v136, to, methodInfo, v27, v28, v29, v30, v134, v32, v33, v34, v35, v36, v37, v38);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v92 @ stack_-50_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv293 = *([v194 @ X0_v14]) == 0;\n\tv224 = ~v293;\n\tif (v224) goto L_0095;\n\tgoto L_006D;\n\tgoto L_0099;\nL_0095:\n\tv222 = new System.OutOfMemoryException();\nL_0099:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v92 @ stack_-50_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv264 = v225 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_00A0;\n\tv295 = 0xBD3CD0(v226, *([v142 @ X21_v2 (Il2CppMethodInfo)]), to, methodInfo, v27, v28, v29, v30, v134, v32, v33, v34, v35, v36, v37, v38);\nL_00A0:\n\tv298 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v298, *([v142 @ X21_v2 (Il2CppMethodInfo)]), to, methodInfo, v27, v28, v29, v30, v134, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal2;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Animation TryGetTransition(Animation from, Animation to)
		{
			//IL_002a: Expected O, but got I
			//IL_005e: Expected O, but got I
			//IL_00b7: Expected O, but got I
			//IL_011c: Expected I4, but got O
			List<AnimationTransition>.Enumerator enumerator = transitions.GetEnumerator();
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			object obj = default(object);
			int num;
			object obj2 = default(object);
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			while (true)
			{
				Animation result;
				if (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-58+10]");
					Animation animation = ((AnimationReferenceAsset)0).Animation;
					if (animation != from)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-58+18]");
					Animation animation2 = ((AnimationReferenceAsset)0).Animation;
					if (animation2 != to)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-58+20]");
					if ((nint)0 == 0)
					{
						NullReferenceException ex = new NullReferenceException();
						NullReferenceException ex3;
						if ((nint)obj == 1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
							num = (int)obj2;
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
							enumerator3.Dispose();
							if (obj2 == null)
							{
								result = null;
								goto IL_00d2;
							}
							OutOfMemoryException ex2 = new OutOfMemoryException();
							ex3 = (NullReferenceException)(object)ex2;
							break;
						}
						num = 0;
						ex3 = ex;
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-58+20]");
					Animation animation3 = ((AnimationReferenceAsset)0).Animation;
					result = animation3;
				}
				else
				{
					result = null;
				}
				enumerator2.Dispose();
				goto IL_00d2;
				IL_00d2:
				return result;
			}
			enumerator3.Dispose();
			if (num == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
			}
			OutOfMemoryException ex4 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			Animation result2 = default(Animation);
			return result2;
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x150F324", Offset = "0x150F324", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.skeletonAnimation;\n\tv26 = Spine.AnimationState::GetCurrent(v2.state, layerIndex);\n\tv27 = v26 == 0;\n\tif (v27) goto L_000F;\n\treturnVal2 = v26.animation;\nL_000F:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Animation GetCurrentAnimation(int layerIndex)
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			TrackEntry current = skeletonAnimation.state.GetCurrent(layerIndex);
			bool flag = current == null;
			Animation result = (Animation)(object)current;
			if (!flag)
			{
				result = current.Animation;
			}
			return result;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x150F14C", Offset = "0x150F14C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Animator::StringToHash(s);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int StringToHash(string s)
		{
			return Animator.StringToHash(s);
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x150F5AC", Offset = "0x150F5AC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+AnimationTransition>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37A2F]) = v50;\nL_0026:\n\tv52 = new System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+StateNameToAnimationReference>::.ctor(v52);\n\tthis.statesAndAnimations = v52;\n\tv62 = new System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+AnimationTransition>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonAnimationHandleExample+AnimationTransition>::.ctor(v62);\n\tthis.transitions = v62;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonAnimationHandleExample()
		{
			List<StateNameToAnimationReference> list = new List<StateNameToAnimationReference>();
			statesAndAnimations = list;
			List<AnimationTransition> list2 = new List<AnimationTransition>();
			transitions = list2;
		}
	}
}
