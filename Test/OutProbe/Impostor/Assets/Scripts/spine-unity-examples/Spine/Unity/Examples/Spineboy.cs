using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200006B")]
	public class Spineboy : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200006C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400024B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400024C")]
			public static AnimationState.TrackEntryDelegate _003C_003E9__1_0;

			[Token(Token = "0x60001E1")]
			[Address(RVA = "0x151F2A4", Offset = "0x151F2A4", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.Unity.Examples.Spineboy+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37AB3]) = v34;\nL_0012:\n\tv36 = new Spine.Unity.Examples.Spineboy+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60001E2")]
			[Address(RVA = "0x151F300", Offset = "0x151F300", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CStart_003Eb__1_0(TrackEntry entry)
			{
				string text = entry.TrackIndex.ToString();
				string message = "start: " + text;
				Debug.Log(message);
			}
		}

		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0x20")]
		private SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0x151EE88", Offset = "0x151EE88", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv53 = Spine.AnimationState+TrackEntryDelegate;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv77 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv80 = Il2CppMethodInfo;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv116 = Spine.Unity.Examples.Spineboy+<>c;\n\tv117 = \"il2cpp_codegen_initialize_runtime_metadata\"(v116, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv124 = \"jump\";\n\tv125 = \"il2cpp_codegen_initialize_runtime_metadata\"(v124, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv131 = \"run\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37AB0]) = v44;\nL_002D:\n\tv47 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v47;\n\tv61 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v61, this, Il2CppMethodInfo);\n\tSpine.AnimationState::add_Event(v47.state, v61);\n\tgoto L_004F;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v126, v121, v122, v63, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv134 = Spine.Unity.Examples.Spineboy+<>c;\nL_004F:\n\tv155 = v135.<>9__1_0;\n\tv141 = v135.<>9__1_0 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_006E;\n\tgoto L_0060;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v133, v121, v122, v63, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv165 = Spine.Unity.Examples.Spineboy+<>c;\nL_0060:\n\tv154 = new Spine.AnimationState+TrackEntryDelegate();\n\tSpine.AnimationState+TrackEntryDelegate::.ctor(v154, v167.<>9, Il2CppMethodInfo);\n\tv157.<>9__1_0 = v154;\nL_006E:\n\tSpine.AnimationState::add_End(v47.state, v155);\n\tv175 = Spine.AnimationState::AddAnimation(v47.state, 0, \"jump\", 0, 2f);\n\tv104 = Spine.AnimationState::AddAnimation(v47.state, 0, \"run\", 1, 0f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			SkeletonAnimation skeletonAnimation = (this.skeletonAnimation = GetComponent<SkeletonAnimation>());
			AnimationState.TrackEntryEventDelegate value = HandleEvent;
			skeletonAnimation.state.Event += value;
			AnimationState.TrackEntryDelegate value2 = _003C_003Ec._003C_003E9__1_0;
			if (_003C_003Ec._003C_003E9__1_0 == null)
			{
				value2 = (_003C_003Ec._003C_003E9__1_0 = delegate(TrackEntry entry)
				{
					string text = entry.TrackIndex.ToString();
					string message = "start: " + text;
					Debug.Log(message);
				});
			}
			skeletonAnimation.state.End += value2;
			TrackEntry trackEntry = skeletonAnimation.state.AddAnimation(0, "jump", loop: false, 2f);
			TrackEntry trackEntry2 = skeletonAnimation.state.AddAnimation(0, "run", loop: true, 0f);
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0x151F054", Offset = "0x151F054", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, trackEntry, e, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv46 = System.String[];\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, trackEntry, e, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = \" \";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, trackEntry, e, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv128 = \", \";\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, trackEntry, e, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv131 = \": event \";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, trackEntry, e, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A37AB1]) = v41;\nL_0023:\n\t// 35 NewArr v44 @ X0_v3 (System.String[]), typeof(System.String[]), 7\n\tv52 = trackEntry.trackIndex;\n\tv57 = System.Int32::ToString(&v52 @ X8_v4 (System.Int32));\n\tv44[0] = v57;\n\tv44[1] = \" \";\n\tv65 = trackEntry.animation;\n\tv44[2] = v65.name;\n\tv44[3] = \": event \";\n\tv203 = e == 0;\n\tif (v203) goto L_FFFFFFFF;\n\tv115 = Spine.Event::ToString(e);\n\tgoto L_007E;\nL_007E:\n\tv44[4] = v115;\n\tv44[5] = \", \";\n\tv52 = e.intValue;\n\tv202 = System.Int32::ToString(&v52 @ X8_v4 (System.Int32));\n\tv44[6] = v202;\n\tv235 = System.String::Concat(v44);\n\tgoto L_00A8;\n\tv238 = v168;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v238, v234, e, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00A8:\n\tUnityEngine.Debug::Log(v235);\n\treturn;\n\tv114 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleEvent(TrackEntry trackEntry, Event e)
		{
			string[] array = new string[7];
			string text = trackEntry.TrackIndex.ToString();
			array[0] = text;
			array[1] = " ";
			Animation animation = trackEntry.Animation;
			array[2] = animation.Name;
			array[3] = ": event ";
			string text2 = e?.ToString();
			array[4] = text2;
			array[5] = ", ";
			string text3 = e.Int.ToString();
			array[6] = text3;
			string message = string.Concat(array);
			Debug.Log(message);
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0x151F1FC", Offset = "0x151F1FC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = \"jump\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = \"run\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37AB2]) = v34;\nL_0013:\n\tv35 = this.skeletonAnimation;\n\tv50 = Spine.AnimationState::SetAnimation(v35.state, 0, \"jump\", 0);\n\tv56 = this.skeletonAnimation;\n\tv73 = Spine.AnimationState::AddAnimation(v56.state, 0, \"run\", 1, 0f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnMouseDown()
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(0, "jump", loop: false);
			SkeletonAnimation skeletonAnimation2 = this.skeletonAnimation;
			TrackEntry trackEntry2 = skeletonAnimation2.state.AddAnimation(0, "run", loop: true, 0f);
		}

		[Token(Token = "0x60001E0")]
		[Address(RVA = "0x151F29C", Offset = "0x151F29C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Spineboy()
		{
		}
	}
}
