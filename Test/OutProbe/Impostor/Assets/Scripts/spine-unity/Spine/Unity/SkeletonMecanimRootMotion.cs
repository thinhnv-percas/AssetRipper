using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonMecanimRootMotion")]
	[Token(Token = "0x200007A")]
	public class SkeletonMecanimRootMotion : SkeletonRootMotionBase
	{
		[Token(Token = "0x40002FF")]
		private const int DefaultMecanimLayerFlags = -1;

		[Token(Token = "0x4000300")]
		[FieldOffset(Offset = "0x70")]
		public int mecanimLayerFlags;

		[Token(Token = "0x4000301")]
		[FieldOffset(Offset = "0x74")]
		protected Vector2 movementDelta;

		[Token(Token = "0x4000302")]
		[FieldOffset(Offset = "0x80")]
		private SkeletonMecanim skeletonMecanim;

		[Token(Token = "0x1700018D")]
		public SkeletonMecanim SkeletonMecanim
		{
			[Token(Token = "0x6000502")]
			[Address(RVA = "0x15583B8", Offset = "0x15583B8", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C05]) = v38;\nL_001B:\n\tgoto L_001F;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = UnityEngine.Object::op_Implicit(this.skeletonMecanim);\n\tv52 = v50 == 0;\n\tif (v52) goto L_0029;\n\treturnVal1 = this.skeletonMecanim;\n\tgoto L_0030;\nL_0029:\n\treturnVal1 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonMecanim = returnVal1;\nL_0030:\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonMecanim ? skeletonMecanim : (skeletonMecanim = GetComponent<SkeletonMecanim>());
			}
		}

		[Token(Token = "0x6000503")]
		[Address(RVA = "0x1558448", Offset = "0x1558448", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, layerIndex, methodInfo, v21, v22, v23, v24, v25, returnVal1, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, layerIndex, methodInfo, v21, v22, v23, v24, v25, returnVal1, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37C06]) = v37;\nL_0015:\n\tv38 = this.skeletonMecanim;\n\tv48 = Spine.Unity.SkeletonMecanim+MecanimTranslator::GetActiveAnimationAndTime(v38.translator, layerIndex);\n\tv49 = v48 == 0;\n\tif (v49) goto L_002B;\n\treturnVal2 = Spine.Unity.SkeletonRootMotionBase::GetAnimationRootMotion(this, layerIndex, *([v48 @ X0_v5 (System.Collections.Generic.KeyValuePair`2<Spine.Animation, System.Single>)+28]), v48);\n\tgoto L_003C;\nL_002B:\n\tgoto L_0035;\n\tv82 = UnityEngine.Vector2;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, v47, methodInfo, v21, v22, v23, v24, v25, returnVal1, v27, v28, v29, v30, v31, v32, v33);\n\tv86 = 1;\n\t*([1A35518]) = v86;\nL_0035:\n\treturnVal2 = v90.zeroVector;\nL_003C:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector2 GetRemainingRootMotion(int layerIndex)
		{
			//IL_0053: Expected F4, but got I
			SkeletonMecanim skeletonMecanim = this.skeletonMecanim;
			KeyValuePair<Animation, float> activeAnimationAndTime = skeletonMecanim.Translator.GetActiveAnimationAndTime(layerIndex);
			if ((object)activeAnimationAndTime != null)
			{
				float startTime = layerIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X0_v5 (System.Collections.Generic.KeyValuePair`2<Spine.Animation, System.Single>)+28]");
				return GetAnimationRootMotion(startTime, 0f, (Animation)activeAnimationAndTime);
			}
			return Vector2.zero;
		}

		[Token(Token = "0x6000504")]
		[Address(RVA = "0x1558780", Offset = "0x1558780", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonRootMotionBase::FindRigidbodyComponent(this);\n\tthis.mecanimLayerFlags = 0xFFFFFFFF;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Reset()
		{
			FindRigidbodyComponent();
			mecanimLayerFlags = -1;
		}

		[Token(Token = "0x6000505")]
		[Address(RVA = "0x15587A0", Offset = "0x15587A0", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv47 = UnityEngine.Object;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv53 = Spine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv61 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37C07]) = v44;\nL_0021:\n\tSpine.Unity.SkeletonRootMotionBase::Start(this);\n\tv51 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonMecanim = v51;\n\tgoto L_002F;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v56, v49, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002F:\n\tv66 = UnityEngine.Object::op_Implicit(v51);\n\tv68 = v66 == 0;\n\tif (v68) goto L_0064;\n\tv69 = this.skeletonMecanim;\n\tv81 = new Spine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate();\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate::.ctor(v81, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::remove__OnClipApplied(v69.translator, v81);\n\tv99 = this.skeletonMecanim;\n\tv93 = new Spine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate();\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate::.ctor(v93, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::add__OnClipApplied(v99.translator, v93);\n\treturn;\nL_0064:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Start()
		{
			base.Start();
			if ((bool)(this.skeletonMecanim = GetComponent<SkeletonMecanim>()))
			{
				SkeletonMecanim skeletonMecanim = this.skeletonMecanim;
				SkeletonMecanim.MecanimTranslator.OnClipAppliedDelegate value = OnClipApplied;
				skeletonMecanim.Translator._OnClipApplied -= value;
				SkeletonMecanim skeletonMecanim2 = this.skeletonMecanim;
				SkeletonMecanim.MecanimTranslator.OnClipAppliedDelegate value2 = OnClipApplied;
				skeletonMecanim2.Translator._OnClipApplied += value2;
			}
		}

		[Token(Token = "0x6000506")]
		[Address(RVA = "0x1558B24", Offset = "0x1558B24", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = weight == 0;\n\tif (v11) goto L_0030;\n\tv19 = 1 << layerIndex;\n\tv22 = this.mecanimLayerFlags & v19;\n\tv23 = v22 == 0;\n\tif (v23) goto L_0030;\n\tv40 = playsBackward == 0;\n\tif (v40) goto L_0025;\n\tv55 = Spine.Unity.SkeletonRootMotionBase::GetAnimationRootMotion(this, time, lastTime, animation);\n\tv63 = v55 * v61;\n\tv31 = this.movementDelta - v63;\n\tgoto L_002B;\nL_0025:\n\tv58 = Spine.Unity.SkeletonRootMotionBase::GetAnimationRootMotion(this, lastTime, time, animation);\n\tv68 = v58 * v61;\n\tv31 = this.movementDelta + v68;\nL_002B:\n\tthis.movementDelta = v31;\nL_0030:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnClipApplied(Animation animation, int layerIndex, float weight, float time, float lastTime, bool playsBackward)
		{
			//IL_010b: Expected O, but got F4
			if (weight == 0f)
			{
				return;
			}
			int num = 1 << layerIndex;
			if ((mecanimLayerFlags & num) != 0)
			{
				object obj = default(object);
				float num3;
				if (playsBackward)
				{
					float num2 = GetAnimationRootMotion(time, lastTime, animation).x * (float)obj;
					num3 = movementDelta.x - num2;
				}
				else
				{
					float num4 = GetAnimationRootMotion(lastTime, time, animation).x * (float)obj;
					num3 = movementDelta.x + num4;
				}
				movementDelta = (Vector2)num3;
			}
		}

		[Token(Token = "0x6000507")]
		[Address(RVA = "0x1558BAC", Offset = "0x1558BAC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv19 = UnityEngine.Vector2;\n\tv20 = \"il2cpp_codegen_initialize_runtime_metadata\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35518]) = v38;\nL_001A:\n\tthis.movementDelta = v44.zeroVector;\n\treturn this.movementDelta;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override Vector2 CalculateAnimationsMovementDelta()
		{
			movementDelta = Vector2.zero;
			return movementDelta;
		}

		[Token(Token = "0x6000508")]
		[Address(RVA = "0x1558C10", Offset = "0x1558C10", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mecanimLayerFlags = 0xFFFFFFFF;\n\tSpine.Unity.SkeletonRootMotionBase::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonMecanimRootMotion()
		{
			mecanimLayerFlags = -1;
		}
	}
}
