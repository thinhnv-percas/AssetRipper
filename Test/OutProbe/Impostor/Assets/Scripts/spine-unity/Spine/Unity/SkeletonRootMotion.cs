using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRootMotion")]
	[Token(Token = "0x200007B")]
	public class SkeletonRootMotion : SkeletonRootMotionBase
	{
		[Token(Token = "0x4000303")]
		private const int DefaultAnimationTrackFlags = -1;

		[Token(Token = "0x4000304")]
		[FieldOffset(Offset = "0x70")]
		public int animationTrackFlags;

		[Token(Token = "0x4000305")]
		[FieldOffset(Offset = "0x78")]
		private AnimationState animationState;

		[Token(Token = "0x4000306")]
		[FieldOffset(Offset = "0x80")]
		private Canvas canvas;

		[Token(Token = "0x1700018E")]
		protected override float AdditionalScale
		{
			[Token(Token = "0x600050A")]
			[Address(RVA = "0x1558D4C", Offset = "0x1558D4C", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, returnVal3, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C08]) = v37;\nL_0018:\n\tgoto L_001C;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, returnVal3, v28, v29, v30, v31, v32, v33, v34);\nL_001C:\n\tv47 = UnityEngine.Object::op_Implicit(this.canvas);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0031;\n\treturnVal2 = UnityEngine.Canvas::get_referencePixelsPerUnit(this.canvas);\n\treturn returnVal2;\nL_0031:\n\treturn 1f;\n\tthrow System.NullReferenceException;\n\treturn returnVal3;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((bool)canvas)
				{
					return canvas.referencePixelsPerUnit;
				}
				return 1f;
			}
		}

		[Token(Token = "0x6000509")]
		[Address(RVA = "0x1558CC4", Offset = "0x1558CC4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Spine.AnimationState::GetCurrent(this.animationState, trackIndex);\n\tv38 = v11 == 0;\n\tif (v38) goto L_001B;\n\tv19 = v11.animation;\n\tv15 = Spine.TrackEntry::get_AnimationTime(v11);\n\treturnVal2 = Spine.Unity.SkeletonRootMotionBase::GetAnimationRootMotion(this, v15, v19.duration, v11.animation);\n\tgoto L_002B;\nL_001B:\n\tgoto L_0025;\n\tv64 = UnityEngine.Vector2;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, trackIndex, v10, v26, v27, v28, v29, v30, v14, v31, v32, v33, v34, v35, v36, v37);\n\tv67 = 1;\n\t*([1A35518]) = v67;\nL_0025:\n\treturnVal2 = v72.zeroVector;\nL_002B:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector2 GetRemainingRootMotion(int trackIndex)
		{
			TrackEntry current = animationState.GetCurrent(trackIndex);
			if (current != null)
			{
				Animation animation = current.Animation;
				float animationTime = current.AnimationTime;
				return GetAnimationRootMotion(animationTime, animation.Duration, current.Animation);
			}
			return Vector2.zero;
		}

		[Token(Token = "0x600050B")]
		[Address(RVA = "0x1558DD0", Offset = "0x1558DD0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonRootMotionBase::FindRigidbodyComponent(this);\n\tthis.animationTrackFlags = 0xFFFFFFFF;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Reset()
		{
			FindRigidbodyComponent();
			animationTrackFlags = -1;
		}

		[Token(Token = "0x600050C")]
		[Address(RVA = "0x1558DEC", Offset = "0x1558DEC", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Spine.Unity.IAnimationStateComponent;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv62 = UnityEngine.Object;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C09]) = v40;\nL_001E:\n\tSpine.Unity.SkeletonRootMotionBase::Start(this);\n\t// 33 IsInst v47 @ X0_v4 (Spine.Unity.IAnimationStateComponent), typeof(Spine.Unity.IAnimationStateComponent), this.skeletonComponent (Spine.Unity.ISkeletonComponent)\n\tv60 = v47 != 0;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_0031:\n\tv66 = v47 == 0;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0060;\n\tv73 = *([v67 @ X8_v10+B0]);\n\tv74 = v73 + 8;\n\tv76 = *([v154 @ X10_v6-8]);\n\tv168 = v76 == v68;\n\tif (v168) goto L_0059;\n\tv85 = v155 - 1;\n\tv82 = v154 + 0x10;\n\tv79 = v155 != 1;\n\tif (v79) goto L_FFFFFFFF;\n\tv102 = v69;\n\tv103 = 0;\n\tv104 = 0xB349B4(v102, v68, v103, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0060;\n\tgoto L_0065;\nL_0059:\n\tv179 = *([v154 @ X10_v6]);\n\tv180 = v179 << 4;\n\tv181 = v67 + v180;\n\tv182 = v181 + 0x138;\nL_0060:\n\tv138 = Spine.Unity.IAnimationStateComponent::get_AnimationState(v47);\nL_0065:\n\tv119.animationState = v138;\n\tv151 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0076;\n\tv186 = v173;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v186, v149, v110, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0076:\n\tv192 = UnityEngine.Object::op_Inequality(v151, 0);\n\tv195 = v192 == 0;\n\tif (v195) goto L_0086;\n\tv200 = UnityEngine.Component::GetComponentInParent(this);\n\tthis.canvas = v200;\nL_0086:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Start()
		{
			base.Start();
			IAnimationStateComponent animationStateComponent = skeletonComponent as IAnimationStateComponent;
			SkeletonRootMotion skeletonRootMotion = ((animationStateComponent != null) ? this : null);
			AnimationState animationState;
			if (animationStateComponent == null)
			{
				skeletonRootMotion = this;
				animationState = (AnimationState)animationStateComponent;
			}
			else
			{
				animationState = animationStateComponent.AnimationState;
			}
			skeletonRootMotion.animationState = animationState;
			CanvasRenderer component = GetComponent<CanvasRenderer>();
			if (component != null)
			{
				Canvas componentInParent = GetComponentInParent<Canvas>();
				canvas = componentInParent;
			}
		}

		[Token(Token = "0x600050D")]
		[Address(RVA = "0x1558F48", Offset = "0x1558F48", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv33 = UnityEngine.Vector2;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 1;\n\t*([1A35518]) = v52;\nL_0019:\n\tv53 = v344.animationState;\n\tv55 = v53.tracks;\n\tv147 = v55.Count < 1;\n\tif (v147) goto L_009C;\nL_0037:\n\tv262 = v344.animationTrackFlags + 1;\n\tv109 = v262 == 0;\n\tif (v109) goto L_0046;\n\tv263 = v344.animationTrackFlags >> v84;\n\tv264 = v263 & 1;\n\tv265 = v264 == 0;\n\tif (v265) goto L_0080;\nL_0046:\n\tv326 = Spine.AnimationState::GetCurrent(v344.animationState, v84);\n\tv301 = v326 == 0;\n\tif (v301) goto L_0080;\nL_004E:\n\tv331 = Spine.TrackEntry::get_AnimationTime(v326);\n\tv336 = Spine.Unity.SkeletonRootMotionBase::GetAnimationRootMotion(v344, v326.animationLast, v331, v326.animation);\n\tgoto L_0060;\n\tv342 = v125;\n\tv343 = \"il2cpp_codegen_initialize_runtime_metadata\"(v342, v335, v314, v307, v38, v39, v40, v41, v336, v337, v44, v45, v46, v47, v48, v49);\n\t*([1A35518]) = v82;\nL_0060:\n\tv345 = UnityEngine.Vector2;\n\tv302 = *([v345 @ X8_v14 (Il2CppClass<UnityEngine.Vector2>)+B8]);\n\tv348 = v336 - v302.zeroVector;\n\tv349 = v336.y - *([v302 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector2>)+4]);\n\tv350 = v348 * v348;\n\tv351 = v349 * v349;\n\tv352 = v350 + v351;\n\tv293 = v352 < 9.9999994E-11f;\n\tif (v293) goto L_007D;\n\tSpine.Unity.SkeletonRootMotion::ApplyMixAlphaToDelta(v344, &v355 @ stack_-68_v8 (UnityEngine.Vector2), v313, v326);\n\tv358 = v280 + v355;\nL_007D:\n\tv361 = v326.mixingFrom == 0;\n\tv300 = ~v361;\n\tif (v300) goto L_004E;\nL_0080:\n\tv84 = v84 + 1;\n\tv177 = v84 != v55.Count;\n\tif (v177) goto L_0037;\nL_009C:\n\treturn v178;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override Vector2 CalculateAnimationsMovementDelta()
		{
			//IL_016b: Expected I, but got O
			//IL_0174: Expected I, but got O
			//IL_027c: Expected O, but got F4
			AnimationState animationState = this.animationState;
			ExposedList<TrackEntry> tracks = animationState.Tracks;
			bool flag = tracks.Count < 1;
			Vector2 result = Vector2.zero;
			if (!flag)
			{
				int num = 0;
				Vector2 vector = Vector2.zero;
				Vector2 currentDelta = default(Vector2);
				bool flag4;
				do
				{
					if (animationTrackFlags + 1 != 0)
					{
						int num2 = animationTrackFlags >> num;
						if ((num2 & 1) == 0)
						{
							goto IL_010f;
						}
					}
					TrackEntry trackEntry = this.animationState.GetCurrent(num);
					if (trackEntry != null)
					{
						TrackEntry next = null;
						float num3 = vector.x;
						bool flag3;
						do
						{
							float animationTime = trackEntry.AnimationTime;
							Vector2 animationRootMotion = GetAnimationRootMotion(trackEntry.AnimationLast, animationTime, trackEntry.Animation);
							nint num4 = (nint)typeof(Vector2);
							nint num5 = (nint)Vector2.zero;
							float num6 = animationRootMotion.x - Vector2.zero.x;
							float num7 = animationRootMotion.y;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
							float num8 = num7 - 0f;
							float num9 = num6 * num6;
							float num10 = num8 * num8;
							float num11 = num9 + num10;
							if (!(num11 < 9.9999994E-11f))
							{
								ApplyMixAlphaToDelta(ref currentDelta, next, trackEntry);
								float num12 = num3 + currentDelta.x;
								num3 = num12;
							}
							bool flag2 = trackEntry.MixingFrom == null;
							flag3 = !flag2;
							vector = (Vector2)num3;
							next = trackEntry;
							trackEntry = trackEntry.MixingFrom;
						}
						while (flag3);
					}
					goto IL_010f;
					IL_010f:
					num++;
					flag4 = num != tracks.Count;
					result = vector;
				}
				while (flag4);
			}
			return result;
		}

		[Token(Token = "0x600050E")]
		[Address(RVA = "0x15590D8", Offset = "0x15590D8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = next == 0;\n\tif (v2) goto L_0037;\n\tv10 = next.mixDuration == 0;\n\tif (v10) goto L_0028;\n\tv42 = next.mixTime / next.mixDuration;\n\tv31 = v42 <= 1f;\n\tif (v31) goto L_0028;\nL_0028:\n\tv139 = currentDelta + 4;\n\tv153 = currentDelta->klass+0x4;\n\tv99 = track.alpha * next.interruptAlpha;\n\tv100 = 1f - v42;\n\tv152 = v100 * v99;\n\tv142 = *([currentDelta @ X1 (UnityEngine.Vector2&)]) * v152;\n\tgoto L_0055;\nL_0037:\n\tv52 = track.mixDuration == 0;\n\tif (v52) goto L_0052;\n\tv105 = track.mixTime / track.mixDuration;\n\tv153 = track.alpha * v105;\n\tv119 = v153 <= 1f;\n\tif (v119) goto L_0052;\nL_0052:\n\tv139 = currentDelta + 4;\n\tv152 = currentDelta->klass+0x4;\n\tv142 = v153 * *([currentDelta @ X1 (UnityEngine.Vector2&)]);\nL_0055:\n\tv155 = v153 * v152;\n\t*([currentDelta @ X1 (UnityEngine.Vector2&)]) = v142;\n\t*([v139 @ X8_v1]) = v155;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ApplyMixAlphaToDelta(ref Vector2 currentDelta, TrackEntry next, TrackEntry track)
		{
			//IL_01bc: Expected O, but got I
			//IL_01cc: Expected F4, but got I
			//IL_01a4: Expected Ref, but got F4
			//IL_01ac: Expected O, but got F4
			//IL_00a2: Expected O, but got I
			//IL_00b2: Expected F4, but got I
			float num2;
			float num5;
			float num6;
			object obj;
			if (next != null)
			{
				bool flag = next.MixDuration == 0f;
				float num = 1f;
				if (!flag)
				{
					num = next.MixTime / next.MixDuration;
					if (num > 1f)
					{
						num = 1f;
					}
				}
				obj = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref currentDelta) + 4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [currentDelta @ X1 (UnityEngine.Vector2&)+4]");
				num2 = 0f;
				float num3 = track.Alpha * next.interruptAlpha;
				float num4 = 1f - num;
				num5 = num4 * num3;
				num6 = (float)currentDelta * num5;
			}
			else
			{
				bool flag2 = track.MixDuration == 0f;
				num2 = 1f;
				if (!flag2)
				{
					float num7 = track.MixTime / track.MixDuration;
					num2 = track.Alpha * num7;
					if (num2 > 1f)
					{
						num2 = 1f;
					}
				}
				obj = (object)((byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref currentDelta) + 4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [currentDelta @ X1 (UnityEngine.Vector2&)+4]");
				num5 = 0f;
				num6 = num2 * (float)currentDelta;
			}
			float num8 = num2 * num5;
			ref Vector2 reference = ref *(Vector2*)num6;
			obj = num8;
		}

		[Token(Token = "0x600050F")]
		[Address(RVA = "0x1559190", Offset = "0x1559190", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.animationTrackFlags = 0xFFFFFFFF;\n\tSpine.Unity.SkeletonRootMotionBase::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonRootMotion()
		{
			animationTrackFlags = -1;
		}
	}
}
