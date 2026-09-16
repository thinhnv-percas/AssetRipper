using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000030")]
	public class MecanimToAnimationHandleExample : StateMachineBehaviour
	{
		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x18")]
		private SkeletonAnimationHandleExample animationHandle;

		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x20")]
		private bool initialized;

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x150ED8C", Offset = "0x150ED8C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, animator, stateInfo, layerIndex, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37A2B]) = v42;\nL_0017:\n\tv44 = ~this.initialized;\n\tif (v44) goto L_0021;\n\tv52 = this.animationHandle;\n\tgoto L_0028;\nL_0021:\n\tv50 = UnityEngine.Component::GetComponent(animator);\n\tthis.animationHandle = v50;\n\tthis.initialized = 1;\nL_0028:\n\tv58 = UnityEngine.AnimatorStateInfo::get_shortNameHash(stateInfo);\n\tSpine.Unity.Examples.SkeletonAnimationHandleExample::PlayAnimationForState(v52, v58, layerIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			SkeletonAnimationHandleExample skeletonAnimationHandleExample;
			if (initialized)
			{
				skeletonAnimationHandleExample = animationHandle;
			}
			else
			{
				SkeletonAnimationHandleExample skeletonAnimationHandleExample2 = (animationHandle = animator.GetComponent<SkeletonAnimationHandleExample>());
				initialized = true;
				skeletonAnimationHandleExample = skeletonAnimationHandleExample2;
			}
			int shortNameHash = ((AnimatorStateInfo*)stateInfo)->shortNameHash;
			skeletonAnimationHandleExample.PlayAnimationForState(shortNameHash, layerIndex);
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x150EE6C", Offset = "0x150EE6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.StateMachineBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MecanimToAnimationHandleExample()
		{
		}
	}
}
