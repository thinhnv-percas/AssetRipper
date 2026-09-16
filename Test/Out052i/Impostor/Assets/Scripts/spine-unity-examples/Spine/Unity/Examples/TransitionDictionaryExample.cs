using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000027")]
	public sealed class TransitionDictionaryExample : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000028")]
		public struct SerializedEntry
		{
			[Token(Token = "0x40000DA")]
			[FieldOffset(Offset = "0x0")]
			public AnimationReferenceAsset from;

			[Token(Token = "0x40000DB")]
			[FieldOffset(Offset = "0x8")]
			public AnimationReferenceAsset to;

			[Token(Token = "0x40000DC")]
			[FieldOffset(Offset = "0x10")]
			public AnimationReferenceAsset transition;
		}

		[SerializeField]
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x20")]
		private List<SerializedEntry> transitions;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x28")]
		private readonly Dictionary<AnimationStateData.AnimationPair, Animation> dictionary;

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x150DB70", Offset = "0x150DB70", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv107 = Il2CppMethodInfo;\n\tv108 = \"il2cpp_codegen_initialize_runtime_metadata\"(v107, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv110 = Il2CppMethodInfo;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv133 = Il2CppMethodInfo;\n\tv134 = \"il2cpp_codegen_initialize_runtime_metadata\"(v133, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv149 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v149, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A15]) = v46;\nL_002A:\n\tv52 = this.dictionary == 0;\n\tif (v52) goto L_007F;\n\tSystem.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>::Clear(this.dictionary);\n\tv100 = this.transitions == 0;\n\tif (v100) goto L_007F;\n\tv120 = System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>::GetEnumerator(this.transitions);\nL_0046:\n\tv175 = System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>::MoveNext(&v119 @ stack_-A8_v3 (System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>));\n\tv180 = v175 == 0;\n\tif (v180) goto L_006F;\n\tv195 = Spine.Unity.AnimationReferenceAsset::get_Animation(v135);\n\tv300 = Spine.Unity.AnimationReferenceAsset::get_Animation(v193);\n\tSpine.AnimationStateData+AnimationPair::.ctor(&v164 @ stack_-A8_v8 (Spine.AnimationStateData+AnimationPair), v195, v300);\n\tv307 = Spine.Unity.AnimationReferenceAsset::get_Animation(v136);\n\tSystem.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>::Add(this.dictionary, v164, 0);\n\tgoto L_0046;\nL_006F:\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>::Dispose(&v119 @ stack_-A8_v3 (System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>));\nL_007A:\n\treturn;\n\tv308 = new System.NullReferenceException();\n\tv208 = new System.NullReferenceException();\n\tv212 = new System.NullReferenceException();\n\tv96 = new System.NullReferenceException();\nL_007F:\n\tv105 = new System.NullReferenceException();\n\tgoto L_0092;\n\tgoto L_0092;\n\tgoto L_0092;\n\tgoto L_0092;\n\tgoto L_0092;\n\tgoto L_0092;\n\tgoto L_0092;\n\tgoto L_0092;\nL_0092:\n\tv131 = v93 != 1;\n\tif (v131) goto L_00A0;\n\tv138 = System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>::Clear(v105);\n\tv176 = System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>::Clear(v138);\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>::Dispose(&v78 @ stack_-80_v2 (System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>));\n\tv144 = *([v138 @ X0_v14 (System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>)]) == 0;\n\tif (v144) goto L_007A;\n\tthrow System.OutOfMemoryException;\nL_00A0:\n\tgoto L_00A4;\n\tX19 = X0;\nL_00A4:\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>::Dispose(&v78 @ stack_-80_v2 (System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>+Enumerator<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>));\n\tgoto L_00AB;\n\tv189 = 0xBD3CD0(v105, *([v87 @ X24_v1 (Il2CppMethodInfo)]), v67, v62, v59, v32, v33, v34, v82, v135, v37, v38, v39, v40, v41, v42);\nL_00AB:\n\tv192 = new System.OutOfMemoryException();\n\tv263 = 0x9DACB4(v192, *([v87 @ X24_v1 (Il2CppMethodInfo)]), v67, v62, v59, v32, v33, v34, v82, v135, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			bool flag = this.dictionary == null;
			nint num = default(nint);
			IntPtr intPtr = num;
			List<SerializedEntry>.Enumerator enumerator = default(List<SerializedEntry>.Enumerator);
			List<SerializedEntry>.Enumerator enumerator2 = default(List<SerializedEntry>.Enumerator);
			nint num2 = 0;
			if (!flag)
			{
				this.dictionary.Clear();
				bool flag2 = transitions == null;
				intPtr = num;
				List<SerializedEntry>.Enumerator enumerator3 = default(List<SerializedEntry>.Enumerator);
				enumerator = enumerator3;
				enumerator2 = enumerator3;
				nint num3 = 0;
				IntPtr intPtr2 = default(IntPtr);
				num2 = intPtr2;
				if (!flag2)
				{
					List<SerializedEntry>.Enumerator enumerator4 = transitions.GetEnumerator();
					AnimationReferenceAsset animationReferenceAsset = default(AnimationReferenceAsset);
					AnimationReferenceAsset animationReferenceAsset2 = default(AnimationReferenceAsset);
					AnimationReferenceAsset animationReferenceAsset3 = default(AnimationReferenceAsset);
					while (enumerator3.MoveNext())
					{
						Animation animation = animationReferenceAsset.Animation;
						Animation animation2 = animationReferenceAsset2.Animation;
						AnimationStateData.AnimationPair key = new AnimationStateData.AnimationPair(animation, animation2);
						Animation animation3 = animationReferenceAsset3.Animation;
						this.dictionary.Add(key, null);
						num = 0;
					}
					enumerator3.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (num2 == 1)
			{
				((Dictionary<AnimationStateData.AnimationPair, Animation>)(object)ex).Clear();
				Dictionary<AnimationStateData.AnimationPair, Animation> dictionary = default(Dictionary<AnimationStateData.AnimationPair, Animation>);
				dictionary.Clear();
				enumerator.Dispose();
				if (dictionary != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			}
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x150DD94", Offset = "0x150DD94", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, from, to, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37A16]) = v39;\nL_001A:\n\tv43 = 0;\n\tSpine.AnimationStateData+AnimationPair::.ctor(&v43 @ stack_-40_v1 (Spine.AnimationStateData+AnimationPair), from, to);\n\tv57 = System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>::TryGetValue(this.dictionary, 0, 0);\n\treturn v54;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Animation GetTransition(Animation from, Animation to)
		{
			AnimationStateData.AnimationPair animationPair = default(AnimationStateData.AnimationPair);
			animationPair = new AnimationStateData.AnimationPair(from, to);
			bool flag = dictionary.TryGetValue(default(AnimationStateData.AnimationPair), out *(Animation*)null);
			Animation result = default(Animation);
			return result;
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x150DE28", Offset = "0x150DE28", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37A17]) = v50;\nL_0026:\n\tv52 = new System.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.TransitionDictionaryExample+SerializedEntry>::.ctor(v52);\n\tthis.transitions = v52;\n\tv62 = new System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, Spine.Animation>::.ctor(v62);\n\tthis.dictionary = v62;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransitionDictionaryExample()
		{
			List<SerializedEntry> list = new List<SerializedEntry>();
			transitions = list;
			Dictionary<AnimationStateData.AnimationPair, Animation> dictionary = new Dictionary<AnimationStateData.AnimationPair, Animation>();
			this.dictionary = dictionary;
		}
	}
}
