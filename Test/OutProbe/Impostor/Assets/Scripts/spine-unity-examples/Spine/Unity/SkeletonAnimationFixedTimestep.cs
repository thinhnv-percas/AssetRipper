using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[DisallowMultipleComponent]
	[Token(Token = "0x2000008")]
	public sealed class SkeletonAnimationFixedTimestep : MonoBehaviour
	{
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation skeletonAnimation;

		[Tooltip("The duration of each frame in seconds. For 12 fps: enter '1/12' in the Unity inspector.")]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x28")]
		public float frameDeltaTime;

		[Tooltip("The maximum number of fixed timesteps. If the game framerate drops below the If the framerate is consistently faster than the limited frames, this does nothing.")]
		[Header("Advanced")]
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x2C")]
		public int maxFrameSkip;

		[Tooltip("If enabled, the Skeleton mesh will be updated only on the same frame when the animation and skeleton are updated. Disable this or call SkeletonAnimation.LateUpdate yourself if you are modifying the Skeleton using other components that don't run in the same fixed timestep.")]
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x30")]
		public bool frameskipMeshUpdate;

		[Tooltip("This is the amount the internal accumulator starts with. Set it to some fraction of your frame delta time if you want to stagger updates between multiple skeletons.")]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x34")]
		public float timeOffset;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x38")]
		private float accumulatedTime;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x3C")]
		private bool requiresNewMesh;

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x15088C4", Offset = "0x15088C4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379DF]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v40;\n\tv42 = this.frameDeltaTime < 0;\n\tv43 = ~v42;\n\tv46 = this.frameDeltaTime == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0033;\n\tthis.frameDeltaTime = 0.016666668f;\nL_0033:\n\tv68 = this.maxFrameSkip > 0;\n\tif (v68) goto L_003C;\n\tthis.maxFrameSkip = 1;\nL_003C:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			skeletonAnimation = component;
			bool flag = frameDeltaTime < 0f;
			bool flag2 = !flag;
			bool flag3 = frameDeltaTime == 0f;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				frameDeltaTime = 1f / 60f;
			}
			if (maxFrameSkip <= 0)
			{
				maxFrameSkip = 1;
			}
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x1508940", Offset = "0x1508940", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.requiresNewMesh = 1;\n\tthis.accumulatedTime = this.timeOffset;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			requiresNewMesh = true;
			accumulatedTime = timeOffset;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x1508954", Offset = "0x1508954", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Behaviour::get_enabled(this.skeletonAnimation);\n\tv81 = v11 == 0;\n\tif (v81) goto L_0015;\n\tUnityEngine.Behaviour::set_enabled(this.skeletonAnimation, 0);\nL_0015:\n\tv87 = UnityEngine.Time::get_deltaTime();\n\tv169 = this.accumulatedTime + v87;\n\tthis.accumulatedTime = v169;\n\tv144 = v169 < this.frameDeltaTime;\n\tif (v144) goto L_005D;\nL_0029:\n\tv171 = v171 + 1f;\n\tv182 = v171 > this.maxFrameSkip;\n\tif (v182) goto L_004F;\n\tv169 = v169 - this.frameDeltaTime;\n\tthis.accumulatedTime = v169;\n\tv152 = v169 >= this.frameDeltaTime;\n\tif (v152) goto L_0029;\nL_004F:\n\tv23 = v171 <= 0;\n\tif (v23) goto L_005D;\n\tv148 = this.frameDeltaTime * v171;\n\tSpine.Unity.SkeletonAnimation::Update(this.skeletonAnimation, v148);\n\tthis.requiresNewMesh = 1;\nL_005D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (skeletonAnimation.enabled)
			{
				skeletonAnimation.enabled = false;
			}
			float deltaTime = Time.deltaTime;
			float num = (accumulatedTime += deltaTime);
			if (num < frameDeltaTime)
			{
				return;
			}
			float num2 = 0f;
			do
			{
				num2 += 1f;
				if (num2 > (float)maxFrameSkip)
				{
					break;
				}
				num = (accumulatedTime = num - frameDeltaTime);
			}
			while (!(num < frameDeltaTime));
			if (num2 > 0f)
			{
				float deltaTime2 = frameDeltaTime * num2;
				skeletonAnimation.Update(deltaTime2);
				requiresNewMesh = true;
			}
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x1508A08", Offset = "0x1508A08", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = ~this.frameskipMeshUpdate;\n\tif (v7) goto L_0010;\n\tv9 = ~this.requiresNewMesh;\n\tif (v9) goto L_0015;\nL_0010:\n\tv21 = Spine.Unity.SkeletonAnimation::LateUpdate(this.skeletonAnimation);\n\tthis.requiresNewMesh = 0;\nL_0015:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			if (!frameskipMeshUpdate || requiresNewMesh)
			{
				skeletonAnimation.LateUpdate();
				requiresNewMesh = false;
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x1508A44", Offset = "0x1508A44", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frameDeltaTime = 0.06666667f;\n\tthis.frameskipMeshUpdate = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonAnimationFixedTimestep()
		{
			frameDeltaTime = 1f / 15f;
			frameskipMeshUpdate = true;
		}
	}
}
