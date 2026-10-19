using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x2000005")]
	internal class BlendedClipsAdaptor
	{
		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x10")]
		private AnimationClip normalState;

		[SerializeField]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x18")]
		private AnimationClip fullyAdaptedState;

		[Tooltip("A curve which maps to the current blend percentage between normal and adapted state it should be. (Y axis, 0 to 1, 1 for fully adapted state")]
		[SerializeField]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x20")]
		internal AnimationCurve adaptationCurve;

		[Token(Token = "0x17000004")]
		internal bool Adaptable
		{
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x3F4528C", Offset = "0x3F4528C", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tgoto L_0021;\nL_0021:\n\tv58 = UnityEngine.Object::op_Equality(this.normalState, 0);\n\tv61 = v58 == 0;\n\tif (v61) goto L_003C;\nL_002D:\n\treturn 0;\nL_003C:\n\tgoto L_0041;\nL_0041:\n\tv110 = UnityEngine.Object::op_Equality(this.fullyAdaptedState, 0);\n\treturnVal2 = v110 ^ 1;\n\treturn returnVal2;\nL_0015:\n\tv43 = this.adaptationCurve == 0;\n\tif (v43) goto L_002D;\n")]
			get
			{
				if (adaptationCurve == null || normalState == null)
				{
					return false;
				}
				bool flag = fullyAdaptedState == null;
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x3F44DD8", Offset = "0x3F44DD8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.adaptationCurve = defaultCurve;\n\treturn;\n")]
		public BlendedClipsAdaptor(AnimationCurve defaultCurve)
		{
			adaptationCurve = defaultCurve;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x3F44F10", Offset = "0x3F44F10", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([B78EC19]) & 1;\n\tv35 = v34 == 0;\n\tif (v35) goto L_0033;\n\tv38 = *([B78EC18]) & 1;\n\tv39 = v38 == 0;\n\tif (v39) goto L_003E;\nL_001C:\n\tv65 = this.adaptationCurve == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0048;\n\tgoto L_00E4;\nL_0033:\n\t*([B78EC19]) = 1;\n\tv219 = *([B78EC18]) & 1;\n\tv220 = v219 == 0;\n\tv59 = ~v220;\n\tif (v59) goto L_001C;\nL_003E:\n\t*([B78EC18]) = 1;\n\tv79 = this.adaptationCurve == 0;\n\tif (v79) goto L_00E4;\nL_0048:\n\tgoto L_004C;\nL_004C:\n\tv135 = UnityEngine.Object::op_Equality(this.normalState, 0);\n\tv141 = v135 == 0;\n\tif (v141) goto L_005E;\n\tgoto L_00E4;\nL_005E:\n\tgoto L_0062;\nL_0062:\n\tv137 = UnityEngine.Object::op_Equality(this.fullyAdaptedState, 0);\n\tv143 = v137 == 0;\n\tif (v143) goto L_0075;\n\tgoto L_00E4;\nL_0075:\n\tv230 = UnityEngine.AnimationCurve::Evaluate(this.adaptationCurve, valueForAdaptationCurve);\n\tv235 = UnityEngine.Playables.PlayableGraph::Create(\"AdaptationGraph\");\n\tUnityEngine.Playables.PlayableGraph::SetTimeUpdateMode(&v238 @ stack_-70_v3 (UnityEngine.Playables.PlayableGraph), 3);\n\tgoto L_0091;\nL_0091:\n\tv255 = UnityEngine.Animations.AnimationMixerPlayable::Create(v238, 2, 1);\n\tv257 = 1f - v230;\n\tUnityEngine.Playables.PlayableExtensions::SetInputWeight /* +1 sharing this address */(v255, 0, v257, 0);\n\tUnityEngine.Playables.PlayableExtensions::SetInputWeight /* +1 sharing this address */(v255, 0, v230, 1);\n\tv270 = UnityEngine.Animations.AnimationClipPlayable::Create(v238, this.normalState);\n\tv275 = UnityEngine.Animations.AnimationClipPlayable::Create(v238, this.fullyAdaptedState);\n\tv286 = UnityEngine.Playables.PlayableGraph::Connect /* +1 sharing this address */(&v238 @ stack_-70_v3 (UnityEngine.Playables.PlayableGraph), v270, 0, 0, v255, 0);\n\tv292 = UnityEngine.Playables.PlayableGraph::Connect /* +1 sharing this address */(&v238 @ stack_-70_v3 (UnityEngine.Playables.PlayableGraph), v275, 0, 0, v255, 0);\n\tv300 = UnityEngine.Animations.AnimationPlayableOutput::Create(v238, \"AdaptationGraphOutput\", animator);\n\tUnityEngine.Playables.PlayableOutputExtensions::SetSourcePlayable /* +1 sharing this address */(v300, 0, v255);\n\tUnityEngine.Playables.PlayableGraph::Evaluate(&v238 @ stack_-70_v3 (UnityEngine.Playables.PlayableGraph));\n\tUnityEngine.Playables.PlayableGraph::Destroy(&v238 @ stack_-70_v3 (UnityEngine.Playables.PlayableGraph));\nL_00E4:\n\treturn;\n")]
		public void Adapt(float valueForAdaptationCurve, Animator animator)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EC19]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EC18]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EC18]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			_ = 1;
			if (adaptationCurve != null)
			{
				goto IL_00fb;
			}
			return;
			IL_00fb:
			if (!(normalState == null) && !(fullyAdaptedState == null))
			{
				float num = adaptationCurve.Evaluate(valueForAdaptationCurve);
				PlayableGraph playableGraph = PlayableGraph.Create("AdaptationGraph");
				PlayableGraph graph = default(PlayableGraph);
				graph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
				AnimationMixerPlayable animationMixerPlayable = AnimationMixerPlayable.Create(graph, 2, normalizeWeights: true);
				float num2 = 1f - num;
				Il2CppRuntime.Boundary("MANAGED", "Method not found @4B4369C (UnityEngine.Playables.PlayableExtensions::SetInputWeight, and 1 more at this address)");
				Il2CppRuntime.Boundary("MANAGED", "Method not found @4B4369C (UnityEngine.Playables.PlayableExtensions::SetInputWeight, and 1 more at this address)");
				AnimationClipPlayable animationClipPlayable = AnimationClipPlayable.Create(graph, normalState);
				AnimationClipPlayable animationClipPlayable2 = AnimationClipPlayable.Create(graph, fullyAdaptedState);
				Il2CppRuntime.Boundary("MANAGED", "Method not found @4B438B8 (UnityEngine.Playables.PlayableGraph::Connect, and 1 more at this address)");
				Il2CppRuntime.Boundary("MANAGED", "Method not found @4B438B8 (UnityEngine.Playables.PlayableGraph::Connect, and 1 more at this address)");
				AnimationPlayableOutput animationPlayableOutput = AnimationPlayableOutput.Create(graph, "AdaptationGraphOutput", animator);
				Il2CppRuntime.Boundary("MANAGED", "Method not found @4B44424 (UnityEngine.Playables.PlayableOutputExtensions::SetSourcePlayable, and 1 more at this address)");
				graph.Evaluate();
				graph.Destroy();
			}
			return;
			IL_0066:
			if (adaptationCurve == null)
			{
				return;
			}
			goto IL_00fb;
		}
	}
}
