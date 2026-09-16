using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonMecanim-Component")]
	[RequireComponent(typeof(Animator))]
	[Token(Token = "0x2000080")]
	public class SkeletonMecanim : SkeletonRenderer, ISkeletonAnimation
	{
		[Serializable]
		[Token(Token = "0x2000081")]
		public class MecanimTranslator
		{
			[Token(Token = "0x2000082")]
			public delegate void OnClipAppliedDelegate(Animation clip, int layerIndex, float weight, float time, float lastTime, bool playsBackward);

			[Token(Token = "0x2000083")]
			public enum MixMode
			{
				[Token(Token = "0x4000352")]
				AlwaysMix = 0,
				[Token(Token = "0x4000353")]
				MixNext = 1,
				[Token(Token = "0x4000354")]
				Hard = 2
			}

			[Token(Token = "0x2000084")]
			protected class ClipInfos
			{
				[Token(Token = "0x4000355")]
				[FieldOffset(Offset = "0x10")]
				public bool isInterruptionActive;

				[Token(Token = "0x4000356")]
				[FieldOffset(Offset = "0x11")]
				public bool isLastFrameOfInterruption;

				[Token(Token = "0x4000357")]
				[FieldOffset(Offset = "0x14")]
				public int clipInfoCount;

				[Token(Token = "0x4000358")]
				[FieldOffset(Offset = "0x18")]
				public int nextClipInfoCount;

				[Token(Token = "0x4000359")]
				[FieldOffset(Offset = "0x1C")]
				public int interruptingClipInfoCount;

				[Token(Token = "0x400035A")]
				[FieldOffset(Offset = "0x20")]
				public readonly List<AnimatorClipInfo> clipInfos;

				[Token(Token = "0x400035B")]
				[FieldOffset(Offset = "0x28")]
				public readonly List<AnimatorClipInfo> nextClipInfos;

				[Token(Token = "0x400035C")]
				[FieldOffset(Offset = "0x30")]
				public readonly List<AnimatorClipInfo> interruptingClipInfos;

				[Token(Token = "0x400035D")]
				[FieldOffset(Offset = "0x38")]
				public AnimatorStateInfo stateInfo;

				[Token(Token = "0x400035E")]
				[FieldOffset(Offset = "0x5C")]
				public AnimatorStateInfo nextStateInfo;

				[Token(Token = "0x400035F")]
				[FieldOffset(Offset = "0x80")]
				public AnimatorStateInfo interruptingStateInfo;

				[Token(Token = "0x4000360")]
				[FieldOffset(Offset = "0xA4")]
				public float interruptingClipTimeAddition;

				[Token(Token = "0x60005B2")]
				[Address(RVA = "0x1561420", Offset = "0x1561420", Length = "0xAC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C59]) = v42;\nL_001A:\n\tv44 = new System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>();\n\tSystem.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::.ctor(v44);\n\tthis.clipInfos = v44;\n\tv50 = new System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>();\n\tSystem.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::.ctor(v50);\n\tthis.nextClipInfos = v50;\n\tv54 = new System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>();\n\tSystem.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::.ctor(v54);\n\tthis.interruptingClipInfos = v54;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public ClipInfos()
				{
					List<AnimatorClipInfo> list = new List<AnimatorClipInfo>();
					clipInfos = list;
					List<AnimatorClipInfo> list2 = new List<AnimatorClipInfo>();
					nextClipInfos = list2;
					List<AnimatorClipInfo> list3 = new List<AnimatorClipInfo>();
					interruptingClipInfos = list3;
				}
			}

			[Token(Token = "0x2000085")]
			private class AnimationClipEqualityComparer : IEqualityComparer<AnimationClip>
			{
				[Token(Token = "0x4000361")]
				internal static readonly IEqualityComparer<AnimationClip> Instance;

				[Token(Token = "0x60005B3")]
				[Address(RVA = "0x156161C", Offset = "0x156161C", Length = "0x48")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UnityEngine.Object::GetInstanceID(x);\n\tv36 = UnityEngine.Object::GetInstanceID(y);\n\tv58 = v12 - v36;\n\tv52 = v58 == 0;\n\treturn v52;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public bool Equals(AnimationClip x, AnimationClip y)
				{
					int instanceID = x.GetInstanceID();
					int instanceID2 = y.GetInstanceID();
					int num = instanceID - instanceID2;
					return num == 0;
				}

				[Token(Token = "0x60005B4")]
				[Address(RVA = "0x1561664", Offset = "0x1561664", Length = "0x18")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Object::GetInstanceID(o);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public int GetHashCode(AnimationClip o)
				{
					return o.GetInstanceID();
				}

				[Token(Token = "0x60005B5")]
				[Address(RVA = "0x156167C", Offset = "0x156167C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public AnimationClipEqualityComparer()
				{
				}

				[Token(Token = "0x60005B6")]
				[Address(RVA = "0x1561684", Offset = "0x1561684", Length = "0x5C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.Unity.SkeletonMecanim+MecanimTranslator+AnimationClipEqualityComparer;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37C5A]) = v34;\nL_0012:\n\tv36 = new Spine.Unity.SkeletonMecanim+MecanimTranslator+AnimationClipEqualityComparer();\n\tSystem.Object::.ctor(v36);\n\tv40.Instance = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				static AnimationClipEqualityComparer()
				{
					AnimationClipEqualityComparer instance = new AnimationClipEqualityComparer();
					Instance = instance;
				}
			}

			[Token(Token = "0x2000086")]
			private class IntEqualityComparer : IEqualityComparer<int>
			{
				[Token(Token = "0x4000362")]
				internal static readonly IEqualityComparer<int> Instance;

				[Token(Token = "0x60005B7")]
				[Address(RVA = "0x15616E0", Offset = "0x15616E0", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = x - y;\n\tv6 = v4 == 0;\n\treturn v6;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public bool Equals(int x, int y)
				{
					int num = x - y;
					return num == 0;
				}

				[Token(Token = "0x60005B8")]
				[Address(RVA = "0x15616EC", Offset = "0x15616EC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn o;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public int GetHashCode(int o)
				{
					return o;
				}

				[Token(Token = "0x60005B9")]
				[Address(RVA = "0x15616F4", Offset = "0x15616F4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public IntEqualityComparer()
				{
				}

				[Token(Token = "0x60005BA")]
				[Address(RVA = "0x15616FC", Offset = "0x15616FC", Length = "0x5C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.Unity.SkeletonMecanim+MecanimTranslator+IntEqualityComparer;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37C5B]) = v34;\nL_0012:\n\tv36 = new Spine.Unity.SkeletonMecanim+MecanimTranslator+IntEqualityComparer();\n\tSystem.Object::.ctor(v36);\n\tv40.Instance = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				static IntEqualityComparer()
				{
					IntEqualityComparer instance = new IntEqualityComparer();
					Instance = instance;
				}
			}

			[Token(Token = "0x4000347")]
			[FieldOffset(Offset = "0x10")]
			public bool autoReset;

			[Token(Token = "0x4000348")]
			[FieldOffset(Offset = "0x11")]
			public bool useCustomMixMode;

			[Token(Token = "0x4000349")]
			[FieldOffset(Offset = "0x18")]
			public MixMode[] layerMixModes;

			[Token(Token = "0x400034A")]
			[FieldOffset(Offset = "0x20")]
			public MixBlend[] layerBlendModes;

			[CompilerGenerated]
			[Token(Token = "0x400034B")]
			[FieldOffset(Offset = "0x28")]
			private OnClipAppliedDelegate m__OnClipApplied;

			[Token(Token = "0x400034C")]
			[FieldOffset(Offset = "0x30")]
			private readonly Dictionary<int, Animation> animationTable;

			[Token(Token = "0x400034D")]
			[FieldOffset(Offset = "0x38")]
			private readonly Dictionary<AnimationClip, int> clipNameHashCodeTable;

			[Token(Token = "0x400034E")]
			[FieldOffset(Offset = "0x40")]
			private readonly List<Animation> previousAnimations;

			[Token(Token = "0x400034F")]
			[FieldOffset(Offset = "0x48")]
			protected ClipInfos[] layerClipInfos;

			[Token(Token = "0x4000350")]
			[FieldOffset(Offset = "0x50")]
			private Animator animator;

			[Token(Token = "0x170001A0")]
			public Animator Animator
			{
				[Token(Token = "0x600059B")]
				[Address(RVA = "0x1560520", Offset = "0x1560520", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animator;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Animator;
				}
			}

			[Token(Token = "0x170001A1")]
			public int MecanimLayerCount
			{
				[Token(Token = "0x600059C")]
				[Address(RVA = "0x1560528", Offset = "0x1560528", Length = "0x84")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C4E]) = v37;\nL_0018:\n\tgoto L_001C;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001C:\n\tv47 = UnityEngine.Object::op_Implicit(this.animator);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0031;\n\treturnVal2 = UnityEngine.Animator::get_layerCount(this.animator);\n\treturn returnVal2;\nL_0031:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					if ((bool)Animator)
					{
						return Animator.layerCount;
					}
					return 0;
				}
			}

			[Token(Token = "0x170001A2")]
			public string[] MecanimLayerNames
			{
				[Token(Token = "0x600059D")]
				[Address(RVA = "0x15605AC", Offset = "0x15605AC", Length = "0x128")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = UnityEngine.Object;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = System.String[];\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C4F]) = v40;\nL_001C:\n\tgoto L_0020;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0020:\n\tv52 = UnityEngine.Object::op_Implicit(this.animator);\n\tv54 = v52 == 0;\n\tif (v54) goto L_0067;\n\tv111 = UnityEngine.Animator::get_layerCount(this.animator);\n\t// 46 NewArr v137 @ X0_v14 (System.String[]), typeof(System.String[]), v111 @ X0_v12 (System.Int32)\n\tv145 = this.animator;\nL_0037:\n\tv194 = UnityEngine.Animator::get_layerCount(v145);\n\tv114 = v148 >= v194;\n\tif (v114) goto L_0070;\n\tv136 = UnityEngine.Animator::GetLayerName(this.animator, v148);\n\tv137[v148 @ X21_v6 (System.Int32)] = v136;\n\tv145 = this.animator;\n\tv148 = v148 + 1;\n\tv197 = this.animator == 0;\n\tv139 = ~v197;\n\tif (v139) goto L_0037;\n\tthrow System.NullReferenceException;\nL_0067:\n\t// 103 NewArr returnVal1 @ X0_v8 (System.String[]), typeof(System.String[]), 0\n\treturn returnVal1;\nL_0070:\n\treturn v137;\n\treturnVal3 = new System.IndexOutOfRangeException();\n\treturn returnVal3;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					if ((bool)Animator)
					{
						int layerCount = Animator.layerCount;
						string[] array = new string[layerCount];
						Animator animator = Animator;
						int num = 0;
						while (true)
						{
							int layerCount2 = animator.layerCount;
							if (num >= layerCount2)
							{
								break;
							}
							string layerName = Animator.GetLayerName(num);
							array[num] = layerName;
							animator = Animator;
							num++;
							if ((object)Animator == null)
							{
								throw new NullReferenceException();
							}
						}
						return array;
					}
					return new string[0];
				}
			}

			[Token(Token = "0x14000025")]
			protected internal event OnClipAppliedDelegate _OnClipApplied
			{
				[CompilerGenerated]
				[Token(Token = "0x6000597")]
				[Address(RVA = "0x15603E8", Offset = "0x15603E8", Length = "0x9C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C4C]) = v38;\nL_0014:\n\tv40 = this + 0x28;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				add
				{
					//IL_0078: Expected O, but got I
					object obj = (nint)this + 40;
					Delegate obj2 = this.m__OnClipApplied;
					Delegate obj4 = default(Delegate);
					while (true)
					{
						Delegate obj3 = Delegate.Combine(obj2, value);
						if ((object)obj3 != null && (object)obj3.GetType() != typeof(OnClipAppliedDelegate))
						{
							break;
						}
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
						bool flag = (object)obj2 != obj4;
						obj2 = obj4;
						if (!flag)
						{
							return;
						}
					}
					throw new InvalidCastException();
				}
				[CompilerGenerated]
				[Token(Token = "0x6000598")]
				[Address(RVA = "0x1560484", Offset = "0x1560484", Length = "0x9C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C4D]) = v38;\nL_0014:\n\tv40 = this + 0x28;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				remove
				{
					//IL_0078: Expected O, but got I
					object obj = (nint)this + 40;
					Delegate obj2 = this.m__OnClipApplied;
					Delegate obj4 = default(Delegate);
					while (true)
					{
						Delegate obj3 = Delegate.Remove(obj2, value);
						if ((object)obj3 != null && (object)obj3.GetType() != typeof(OnClipAppliedDelegate))
						{
							break;
						}
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
						bool flag = (object)obj2 != obj4;
						obj2 = obj4;
						if (!flag)
						{
							return;
						}
					}
					throw new InvalidCastException();
				}
			}

			[Token(Token = "0x14000026")]
			public event OnClipAppliedDelegate OnClipApplied
			{
				[Token(Token = "0x6000599")]
				[Address(RVA = "0x1558B20", Offset = "0x1558B20", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::add__OnClipApplied(this, value);\n\treturn;\n")]
				add
				{
					_OnClipApplied += value;
				}
				[Token(Token = "0x600059A")]
				[Address(RVA = "0x1558B1C", Offset = "0x1558B1C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::remove__OnClipApplied(this, value);\n\treturn;\n")]
				remove
				{
					_OnClipApplied -= value;
				}
			}

			[Token(Token = "0x600059E")]
			[Address(RVA = "0x155F150", Offset = "0x155F150", Length = "0x254")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv163 = Il2CppMethodInfo;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv170 = Il2CppMethodInfo;\n\tv171 = \"il2cpp_codegen_initialize_runtime_metadata\"(v170, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv185 = Il2CppMethodInfo;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv199 = Il2CppMethodInfo;\n\tv200 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv206 = Il2CppMethodInfo;\n\tv207 = \"il2cpp_codegen_initialize_runtime_metadata\"(v206, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv212 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v212, animator, skeletonDataAsset, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37C50]) = v46;\nL_002F:\n\tv50 = this.previousAnimations;\n\tthis.animator = animator;\n\tv51 = this.previousAnimations == 0;\n\tif (v51) goto L_009A;\n\tv57 = v50._version + 1;\n\tv50._size = 0;\n\tv50._version = v57;\n\tv68 = v50._size < 1;\n\tif (v68) goto L_0049;\n\tSystem.Array::Clear(v50._items, 0, v50._size);\nL_0049:\n\tv143 = this.animationTable == 0;\n\tif (v143) goto L_009A;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, Spine.Animation>::Clear(this.animationTable);\n\tv144 = skeletonDataAsset == 0;\n\tif (v144) goto L_009A;\n\tv138 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(skeletonDataAsset, 1);\n\tv145 = v138 == 0;\n\tif (v145) goto L_009A;\n\tv146 = v138.animations == 0;\n\tif (v146) goto L_009A;\n\tv226 = Spine.ExposedList`1<Spine.Animation>::GetEnumerator(v138.animations);\nL_006C:\n\tv254 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v79 @ stack_-78_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv233 = v254 == 0;\n\tif (v233) goto L_0085;\n\tv305 = System.String::GetHashCode(v239.name);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, Spine.Animation>::Add(this.animationTable, v305, v239);\n\tgoto L_006C;\nL_0085:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v79 @ stack_-78_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0087:\n\tv147 = this.clipNameHashCodeTable == 0;\n\tif (v147) goto L_009A;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.AnimationClip, System.Int32>::Clear(this.clipNameHashCodeTable);\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::ClearClipInfosForLayers(this);\n\treturn;\n\tv299 = new System.NullReferenceException();\n\tv303 = new System.NullReferenceException();\n\tv136 = new System.NullReferenceException();\nL_009A:\n\tv161 = new System.NullReferenceException();\n\tgoto L_00AA;\n\tgoto L_00AA;\n\tgoto L_00AA;\n\tgoto L_00AA;\n\tgoto L_00AA;\nL_00AA:\n\tv183 = v100 != 1;\n\tif (v183) goto L_00B8;\n\tv188 = 0x1854E70(v161, v100, v132, v91, v31, v32, v33, v34, v75, v36, v37, v38, v39, v40, v41, v42);\n\tv202 = 0x1854E80(v188, v100, v132, v91, v31, v32, v33, v34, v75, v36, v37, v38, v39, v40, v41, v42);\n\tv100 = *([v82 @ X23_v1 (Il2CppMethodInfo)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v74 @ stack_-60_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv194 = *([v188 @ X0_v13]) == 0;\n\tif (v194) goto L_0087;\n\tthrow System.OutOfMemoryException;\nL_00B8:\n\tgoto L_00BC;\n\tX20 = X0;\nL_00BC:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v74 @ stack_-60_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00C3;\n\tv214 = 0xBD3CD0(v161, *([v82 @ X23_v1 (Il2CppMethodInfo)]), v132, v91, v31, v32, v33, v34, v75, v36, v37, v38, v39, v40, v41, v42);\nL_00C3:\n\tv217 = new System.OutOfMemoryException();\n\tv237 = 0x9DACB4(v217, *([v82 @ X23_v1 (Il2CppMethodInfo)]), v132, v91, v31, v32, v33, v34, v75, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Initialize(Animator animator, SkeletonDataAsset skeletonDataAsset)
			{
				//IL_00ad: Expected I, but got O
				//IL_00fd: Expected I, but got O
				//IL_0102: Expected I, but got O
				//IL_02a9: Expected I, but got O
				//IL_015e: Expected I, but got O
				//IL_01b3: Expected I, but got O
				//IL_01ef: Expected I, but got O
				//IL_0239: Expected I4, but got O
				List<Animation> list = previousAnimations;
				this.animator = animator;
				ExposedList<object>.Enumerator enumerator4 = default(ExposedList<object>.Enumerator);
				IntPtr intPtr = default(IntPtr);
				ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
				nint num = default(nint);
				ExposedList<object>.Enumerator enumerator3;
				nint num2;
				int num5;
				nint num4 = default(nint);
				if (previousAnimations != null)
				{
					int version = list._version + 1;
					list._size = 0;
					list._version = version;
					if (list.Count >= 1)
					{
						Array.Clear(list._items, 0, list.Count);
					}
					bool flag = animationTable == null;
					ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
					enumerator = enumerator2;
					enumerator3 = enumerator2;
					num = 0;
					nint num3 = default(nint);
					num2 = num3;
					object obj = default(object);
					num4 = (nint)obj;
					int num6 = default(int);
					num5 = num6;
					if (!flag)
					{
						animationTable.Clear();
						bool flag2 = (object)skeletonDataAsset == null;
						enumerator = default(ExposedList<object>.Enumerator);
						enumerator3 = enumerator4;
						num = intPtr;
						num2 = unchecked((nint)null);
						num4 = unchecked((nint)null);
						num5 = list.Count;
						if (!flag2)
						{
							SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: true);
							bool flag3 = skeletonData == null;
							enumerator = default(ExposedList<object>.Enumerator);
							enumerator3 = enumerator4;
							num = intPtr;
							num2 = unchecked((nint)null);
							num4 = 0;
							num5 = list.Count;
							if (!flag3)
							{
								bool flag4 = skeletonData.Animations == null;
								enumerator = default(ExposedList<object>.Enumerator);
								enumerator3 = enumerator4;
								num = intPtr;
								num2 = unchecked((nint)null);
								num4 = 1;
								num5 = list.Count;
								if (!flag4)
								{
									ExposedList<Animation>.Enumerator enumerator5 = skeletonData.Animations.GetEnumerator();
									num3 = unchecked((nint)null);
									num6 = list.Count;
									Animation animation = default(Animation);
									while (enumerator2.MoveNext())
									{
										int hashCode = animation.Name.GetHashCode();
										animationTable.Add(hashCode, animation);
										num3 = 0;
										num6 = (int)animation;
									}
									enumerator2.Dispose();
									enumerator = enumerator2;
									enumerator3 = enumerator2;
									num = 0;
									num2 = num3;
									num4 = 0;
									num5 = num6;
									goto IL_0279;
								}
							}
						}
					}
				}
				goto IL_02e5;
				IL_0279:
				bool flag5 = clipNameHashCodeTable == null;
				enumerator = default(ExposedList<object>.Enumerator);
				enumerator3 = enumerator4;
				num = intPtr;
				num2 = unchecked((nint)null);
				num4 = 1;
				num5 = list.Count;
				if (!flag5)
				{
					clipNameHashCodeTable.Clear();
					ClearClipInfosForLayers();
					return;
				}
				goto IL_02e5;
				IL_02e5:
				NullReferenceException ex = new NullReferenceException();
				if (num4 == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					num4 = num;
					enumerator.Dispose();
					object obj2 = default(object);
					if (obj2 != null)
					{
						throw new OutOfMemoryException();
					}
					goto IL_0279;
				}
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			}

			[Token(Token = "0x600059F")]
			[Address(RVA = "0x1560810", Offset = "0x1560810", Length = "0x1F8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv46 = UnityEngine.AnimatorClipInfo::get_weight(&info @ X2 (UnityEngine.AnimatorClipInfo));\n\tv47 = v46 * layerWeight;\n\tv52 = v47 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv59 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X2 (UnityEngine.AnimatorClipInfo));\n\tv63 = Spine.Unity.SkeletonMecanim+MecanimTranslator::GetAnimation(this, v59);\n\tv119 = v63 == 0;\n\tif (v119) goto L_00D1;\n\tv302 = UnityEngine.AnimatorStateInfo::get_normalizedTime(stateInfo);\n\tv235 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X2 (UnityEngine.AnimatorClipInfo));\n\tv238 = UnityEngine.AnimationClip::get_length(v235);\n\tv260 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X2 (UnityEngine.AnimatorClipInfo));\n\tv271 = UnityEngine.Motion::get_isLooping(v260);\n\tv274 = UnityEngine.AnimatorStateInfo::get_speed(stateInfo);\n\tv275 = 1f - v302;\n\tv285 = v274 >= 0;\n\tif (v285) goto L_005F;\n\tgoto L_005F;\nL_005F:\n\tv298 = v302 >= 0;\n\tif (v298) goto L_0066;\n\tv300 = 0x1854EF0(stateInfo, 0, info, stateInfo, layerIndex, layerBlendMode, useClipWeight1, methodInfo, v302, 1f, v95, v264, v265, v266, v267, v268);\n\tv302 = v302 + 1f;\nL_0066:\n\tv254 = v238 * v302;\n\tv245 = v238 - v254;\n\tv312 = v245 >= 0.033333335f;\n\tif (v312) goto L_FFFFFFFF;\n\tgoto L_007A;\nL_007A:\n\tv317 = v271 == 0;\n\tv320 = ~v317;\n\tv321 = ~v320;\n\tif (v321) goto L_FFFFFFFF;\n\tgoto L_0086;\nL_0086:\n\tv130 = useClipWeight1 == 0;\n\tv66 = ~v130;\n\tv103 = ~v66;\n\tif (v103) goto L_FFFFFFFF;\n\tgoto L_0091;\nL_0091:\n\tv261 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X2 (UnityEngine.AnimatorClipInfo));\n\tv328 = UnityEngine.Motion::get_isLooping(v261);\n\tSpine.Animation::Apply(v63, skeleton, 0f, v112, v328, 0, v140, layerBlendMode, 0);\n\tv334 = this._OnClipApplied == 0;\n\tif (v334) goto L_FFFFFFFF;\n\tv249 = stateInfo.m_Name;\n\tv262 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X2 (UnityEngine.AnimatorClipInfo));\n\tv349 = UnityEngine.Motion::get_isLooping(v262);\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::OnClipAppliedCallback(this, v63, &v249 @ V1_v9 (System.Int32), layerIndex, v112, v349, v140);\n\tgoto L_00D1;\nL_00D1:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool ApplyAnimation(Skeleton skeleton, AnimatorClipInfo info, AnimatorStateInfo stateInfo, int layerIndex, float layerWeight, MixBlend layerBlendMode, bool useClipWeight1 = false)
			{
				//IL_0072: Expected I4, but got O
				//IL_012a: Expected O, but got F4
				//IL_0239: Expected O, but got Ref
				AnimatorClipInfo animatorClipInfo = default(AnimatorClipInfo);
				float weight = animatorClipInfo.weight;
				float num = weight * layerWeight;
				bool result;
				if (num != 0f)
				{
					AnimationClip clip = animatorClipInfo.clip;
					Animation animation = GetAnimation(clip);
					bool flag = animation == null;
					result = (byte)(int)animation != 0;
					if (!flag)
					{
						float num2 = ((AnimatorStateInfo*)stateInfo)->normalizedTime;
						AnimationClip clip2 = animatorClipInfo.clip;
						float length = clip2.length;
						AnimationClip clip3 = animatorClipInfo.clip;
						bool isLooping = clip3.isLooping;
						float speed = ((AnimatorStateInfo*)stateInfo)->speed;
						float num3 = 1f - num2;
						if (speed < 0f)
						{
							num2 = num3;
						}
						if (num2 < 0f)
						{
							object obj = num2 % 1f;
							num2 += 1f;
						}
						float num4 = length * num2;
						float num5 = length - num4;
						num3 = ((!(num5 < 1f / 30f)) ? num4 : length);
						float time = ((!isLooping) ? num3 : num4);
						float num6 = ((!useClipWeight1) ? num : layerWeight);
						AnimationClip clip4 = animatorClipInfo.clip;
						bool isLooping2 = clip4.isLooping;
						animation.Apply(skeleton, 0f, time, isLooping2, null, num6, layerBlendMode, default(MixDirection));
						if (this._OnClipApplied != null)
						{
							int name = stateInfo.m_Name;
							AnimationClip clip5 = animatorClipInfo.clip;
							bool isLooping3 = clip5.isLooping;
							OnClipAppliedCallback(animation, (AnimatorStateInfo)(&name), layerIndex, time, isLooping3, num6);
						}
						result = true;
					}
				}
				else
				{
					result = false;
				}
				return result;
			}

			[Token(Token = "0x60005A0")]
			[Address(RVA = "0x1560C40", Offset = "0x1560C40", Length = "0x1E0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv62 = UnityEngine.AnimatorClipInfo::get_weight(&info @ X3 (UnityEngine.AnimatorClipInfo));\n\tv51 = v62 + 1f;\n\tv51 = v51 * 0.5f;\n\tv55 = interpolateWeightTo1 == 0;\n\tv58 = ~v55;\n\tv59 = ~v58;\n\tif (v59) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\tv63 = v62 * layerWeight;\n\tv68 = v63 == 0;\n\tif (v68) goto L_FFFFFFFF;\n\tv75 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X3 (UnityEngine.AnimatorClipInfo));\n\tv79 = Spine.Unity.SkeletonMecanim+MecanimTranslator::GetAnimation(this, v75);\n\tv136 = v79 == 0;\n\tif (v136) goto L_00BD;\n\tv239 = UnityEngine.AnimatorStateInfo::get_normalizedTime(stateInfo);\n\tv243 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X3 (UnityEngine.AnimatorClipInfo));\n\tv246 = UnityEngine.AnimationClip::get_length(v243);\n\tv274 = UnityEngine.AnimatorStateInfo::get_speed(stateInfo);\n\tv51 = v239 + v51;\n\tv256 = 1f - v51;\n\tv285 = v274 >= 0;\n\tif (v285) goto L_FFFFFFFF;\n\tgoto L_0069;\nL_0069:\n\tv294 = v261 >= 0;\n\tif (v294) goto L_0071;\n\tv297 = 0x1854EF0(stateInfo, 0, interpolateWeightTo1, info, stateInfo, layerIndex, layerBlendMode, useClipWeight1, v261, 1f, v256, v267, v268, v269, v270, v271);\n\tv261 = v261 + 1f;\nL_0071:\n\tv132 = useClipWeight1 == 0;\n\tv126 = ~v132;\n\tv124 = ~v126;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_007D;\nL_007D:\n\tv265 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X3 (UnityEngine.AnimatorClipInfo));\n\tv149 = v246 * v261;\n\tv305 = UnityEngine.Motion::get_isLooping(v265);\n\tSpine.Animation::Apply(v79, skeleton, 0f, v149, v305, 0, v147, layerBlendMode, 0);\n\tv311 = this._OnClipApplied == 0;\n\tif (v311) goto L_FFFFFFFF;\n\tv258 = stateInfo.m_Name;\n\tv266 = UnityEngine.AnimatorClipInfo::get_clip(&info @ X3 (UnityEngine.AnimatorClipInfo));\n\tv326 = UnityEngine.Motion::get_isLooping(v266);\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::OnClipAppliedCallback(this, v79, &v258 @ V1_v10 (System.Int32), layerIndex, v149, v326, v147);\n\tgoto L_00BD;\nL_00BD:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool ApplyInterruptionAnimation(Skeleton skeleton, bool interpolateWeightTo1, AnimatorClipInfo info, AnimatorStateInfo stateInfo, int layerIndex, float layerWeight, MixBlend layerBlendMode, float interruptingClipTimeAddition, bool useClipWeight1 = false)
			{
				//IL_00a4: Expected I4, but got O
				//IL_0159: Expected O, but got F4
				//IL_0243: Expected O, but got Ref
				AnimatorClipInfo animatorClipInfo = default(AnimatorClipInfo);
				float num = animatorClipInfo.weight;
				float num2 = num + 1f;
				num2 *= 0.5f;
				if (interpolateWeightTo1)
				{
					num = num2;
				}
				float num3 = num * layerWeight;
				bool result;
				if (num3 != 0f)
				{
					AnimationClip clip = animatorClipInfo.clip;
					Animation animation = GetAnimation(clip);
					bool flag = animation == null;
					result = (byte)(int)animation != 0;
					if (!flag)
					{
						float normalizedTime = ((AnimatorStateInfo*)stateInfo)->normalizedTime;
						AnimationClip clip2 = animatorClipInfo.clip;
						float length = clip2.length;
						float speed = ((AnimatorStateInfo*)stateInfo)->speed;
						num2 = normalizedTime + num2;
						float num4 = 1f - num2;
						float num5 = ((!(speed < 0f)) ? num2 : num4);
						if (num5 < 0f)
						{
							object obj = num5 % 1f;
							num5 += 1f;
						}
						float num6 = ((!useClipWeight1) ? num3 : layerWeight);
						AnimationClip clip3 = animatorClipInfo.clip;
						float time = length * num5;
						bool isLooping = clip3.isLooping;
						animation.Apply(skeleton, 0f, time, isLooping, null, num6, layerBlendMode, default(MixDirection));
						if (this._OnClipApplied != null)
						{
							int name = stateInfo.m_Name;
							AnimationClip clip4 = animatorClipInfo.clip;
							bool isLooping2 = clip4.isLooping;
							OnClipAppliedCallback(animation, (AnimatorStateInfo)(&name), layerIndex, time, isLooping2, num6);
						}
						result = true;
					}
				}
				else
				{
					result = false;
				}
				return result;
			}

			[Token(Token = "0x60005A1")]
			[Address(RVA = "0x1560B58", Offset = "0x1560B58", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = UnityEngine.AnimatorStateInfo::get_speedMultiplier(stateInfo);\n\tv42 = UnityEngine.AnimatorStateInfo::get_speed(stateInfo);\n\tv44 = v38 * v42;\n\tv45 = UnityEngine.Time::get_deltaTime();\n\tv46 = v45 * v44;\n\tv80 = time - v46;\n\tv49 = isLooping == 0;\n\tif (v49) goto L_0037;\n\tv66 = clip.duration == 0;\n\tif (v66) goto L_0037;\n\tv149 = 0x1854EF0(0, 0, stateInfo, layerIndex, isLooping, methodInfo, v110, v111, time, clip.duration, v112, v113, v114, v115, v116, v117);\n\tv87 = 0x1854EF0(v149, 0, stateInfo, layerIndex, isLooping, methodInfo, v110, v111, v80, clip.duration, v112, v113, v114, v115, v116, v117);\nL_0037:\n\tv88 = this._OnClipApplied;\n\tv139 = v44 < 0;\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator+OnClipAppliedDelegate::Invoke(this._OnClipApplied, clip, layerIndex, v139, v88.method, v88.invoke_impl, v110);\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void OnClipAppliedCallback(Animation clip, AnimatorStateInfo stateInfo, int layerIndex, float time, bool isLooping, float weight)
			{
				//IL_0105: Expected I4, but got O
				//IL_0105: Expected F4, but got I
				//IL_0105: Expected F4, but got I
				//IL_0105: Expected F4, but got I4
				//IL_00aa: Expected O, but got F4
				//IL_00bc: Expected O, but got F4
				float speedMultiplier = ((AnimatorStateInfo*)stateInfo)->speedMultiplier;
				float speed = ((AnimatorStateInfo*)stateInfo)->speed;
				float num = speedMultiplier * speed;
				float deltaTime = Time.deltaTime;
				float num2 = deltaTime * num;
				float num3 = time - num2;
				if (isLooping && clip.Duration != 0f)
				{
					object obj = time % clip.Duration;
					object obj2 = num3 % clip.Duration;
				}
				OnClipAppliedDelegate onClipAppliedDelegate = this._OnClipApplied;
				bool flag = num < 0f;
				object obj3 = default(object);
				this._OnClipApplied(clip, layerIndex, flag ? 1 : 0, (nint)((Delegate)onClipAppliedDelegate).method, (nint)((Delegate)onClipAppliedDelegate).invoke_impl, (byte)(int)obj3 != 0);
			}

			[Token(Token = "0x60005A2")]
			[Address(RVA = "0x155F480", Offset = "0x155F480", Length = "0xEC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004C;\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, skeleton, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv95 = System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, skeleton, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1080 = Il2CppMethodInfo;\n\tv1081 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1080, skeleton, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1208 = Il2CppMethodInfo;\n\tv1209 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1208, skeleton, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1214 = Il2CppMethodInfo;\n\tv1215 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1214, skeleton, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1413 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1413, skeleton, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A37C51]) = v59;\nL_004C:\n\tv91 = this + 0x18;\n\tv92 = this.layerMixModes;\n\tv983 = UnityEngine.Animator::get_layerCount(this.animator);\n\tv706 = v983 <= v92.Length;\n\tif (v706) goto L_00BB;\n\tv694 = this.layerMixModes;\n\tv1415 = UnityEngine.Animator::get_layerCount(this.animator);\n\tSystem.Array::Resize(v91, v1415);\n\tv1544 = this.animator;\n\tv695 = v694.Length;\n\tv1449 = v694.Length << 2;\n\tv661 = v1449 + 0x20;\nL_0078:\n\tv986 = UnityEngine.Animator::get_layerCount(v1544);\n\tv707 = v695 >= v986;\n\tif (v707) goto L_00BB;\n\tv1044 = this.layerBlendModes;\n\tv1175 = v695 >= v1044.Length;\n\tif (v1175) goto L_FFFFFFFF;\n\tv1704 = *([v1044 @ X8_v132 (Spine.MixBlend[])+v661 @ X23_v16 (System.Int32)]) - 3;\n\tv1706 = v1704 == 0;\n\tv1711 = ~v1706;\n\tgoto L_00B0;\nL_00B0:\n\tv597 = v695 << 2;\n\tv640 = *([v91 @ X21_v3 (System.Int32Enum[]&)]) + v597;\n\t*([v640 @ X9_v115+20]) = v1045;\n\tv1544 = this.animator;\n\tv695 = v695 + 1;\n\tv661 = v661 + 4;\n\tv1744 = this.animator == 0;\n\tv1016 = ~v1744;\n\tif (v1016) goto L_0078;\n\tgoto L_0722;\nL_00BB:\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::InitClipInfosForLayers(this);\n\tv1417 = UnityEngine.Animator::get_layerCount(this.animator);\n\tv1430 = v1417 < 1;\n\tif (v1430) goto L_00E1;\nL_00D1:\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::GetStateUpdatesFromAnimator(this, v1451);\n\tv1451 = v1451 + 1;\n\tv1434 = v1417 != v1451;\n\tif (v1434) goto L_00D1;\nL_00E1:\n\tv1447 = ~this.autoReset;\n\tif (v1447) goto L_035A;\n\tv1069 = this.previousAnimations;\n\tv1557 = v1069._size <= 0;\n\tif (v1557) goto L_0120;\nL_00FA:\n\tv1602 = System.Collections.Generic.List`1<Spine.Animation>::get_Item(v1069, v1579);\n\tSpine.SpineSkeletonExtensions::SetKeyedItemsToSetupPose(v1602, skeleton);\n\tv1579 = v1579 + 1;\n\tv1582 = v1069._size != v1579;\n\tif (v1582) goto L_00FA;\n\tv1619 = v1069._version + 1;\n\tv1069._size = 0;\n\tv1069._version = v1619;\n\tv1607 = v1069._size < 1;\n\tif (v1607) goto L_0127;\n\tSystem.Array::Clear(v1069._items, 0, v1069._size);\n\tgoto L_0127;\nL_0120:\n\tv1565 = v1069._version + 1;\n\tv1069._size = 0;\n\tv1069._version = v1565;\nL_0127:\n\tv1530 = UnityEngine.Animator::get_layerCount(this.animator);\n\tv1509 = v1530 < 1;\n\tif (v1509) goto L_035A;\nL_013B:\n\tv1740 = v664 == 0;\n\tif (v1740) goto L_0156;\n\tv1746 = UnityEngine.Animator::GetLayerWeight(this.animator, v664);\n\tv1767 = v1746 < 0;\n\tv1756 = ~v1767;\n\tv1753 = v1746 == 0;\n\tv1768 = ~v1756;\n\tv1748 = v1768 | v1753;\n\tif (v1748) goto L_034A;\nL_0156:\n\tv1766 = UnityEngine.Animator::GetNextAnimatorStateInfo(this.animator, v664);\n\tv518 = v1766.m_Name;\n\tv1772 = UnityEngine.AnimatorStateInfo::get_fullPathHash(&v518 @ stack_-1D0_v6 (System.Int32));\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::GetAnimatorClipInfos(this, v664, &v443 @ stack_-D4_v7 (System.Boolean), &v439 @ stack_-74_v6 (System.Int32), &v420 @ stack_-78_v7 (System.Int32), &v402 @ stack_-B4_v7 (System.Int32), &v384 @ stack_-C0_v7 (System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>), &v372 @ stack_-C8_v7 (System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>), &v361 @ stack_-D0_v7 (System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>), &v447 @ stack_-D8_v7 (System.Boolean));\n\tv713 = v439 < 1;\n\tif (v713) goto L_020B;\n\tv1875 = v439 - 1;\n\tv1876 = v1875 < 0;\n\tv1877 = v1875 == 0;\n\tv1878 = v439 ^ 1;\n\tv1879 = v439 ^ v1875;\n\tv1880 = v1878 & v1879;\n\tv1881 = v1880 < 0;\n\tv1883 = v1876 == v1881;\n\tv315 = ~v1877;\n\tv1884 = v1883 & v315;\n\tv306 = ~v1884;\n\tif (v306) goto L_FFFFFFFF;\n\tgoto L_019E;\nL_019E:\n\tgoto L_01C5;\n\tv2110 = *([v1997 @ X8_v115+B0]);\n\tv2111 = v2110 + 8;\n\tv2113 = *([v2343 @ X10_v112-8]);\n\tv2358 = v2113 == v1998;\n\tif (v2358) goto L_01BD;\n\tv2117 = v2344 - 1;\n\tv2115 = v2343 + 0x10;\n\tv2119 = v2344 != 1;\n\tif (v2119) goto L_FFFFFFFF;\n\tv2136 = v339;\n\tv2137 = 0;\n\tv2138 = 0xB349B4(v2136, v1998, v2137, v565, v424, v406, v388, v376, v1979, v463, v50, v51, v52, v53, v54, v55);\n\tgoto L_01C5;\nL_01BD:\n\tv2462 = *([v2343 @ X10_v112]);\n\tv2463 = v2462 << 4;\n\tv2464 = v1997 + v2463;\n\tv2465 = v2464 + 0x138;\nL_01C5:\n\tv2483 = System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>::get_Item(v384, v323);\n\tv2486 = UnityEngine.AnimatorClipInfo::get_weight(&v2483 @ X0_v158 (UnityEngine.AnimatorClipInfo));\n\tv530 = v522 * v2486;\n\tv714 = v530 != 0;\n\tif (v714) goto L_01E5;\nL_01D6:\n\tv323 = v323 + 1;\n\tv1848 = v323 != v295;\n\tif (v1848) goto L_019E;\n\tgoto L_020B;\nL_01E5:\n\tv2896 = UnityEngine.AnimatorClipInfo::get_clip(&v2483 @ X0_v158 (UnityEngine.AnimatorClipInfo));\n\tv993 = Spine.Unity.SkeletonMecanim+MecanimTranslator::GetAnimation(this, v2896);\n\tv2890 = v993 == 0;\n\tif (v2890) goto L_01D6;\n\tv1050 = v1069._items;\n\tv622 = v1069._version + 1;\n\tv1069._version = v622;\n\tv2869 = v1069._size;\n\tv3475 = v1069._size < v1050.Length;\n\tv2887 = ~v3475;\n\tif (v2887) goto L_0209;\n\tv2870 = v1069._size + 1;\n\tv1069._size = v2870;\n\tv1050[v2869 @ X10_v107 (System.Int32)] = v993;\n\tgoto L_01D6;\nL_0209:\n\tSystem.Collections.Generic.List`1<Spine.Animation>::AddWithResize(v1069, v993);\n\tgoto L_01D6;\nL_020B:\n\tv1871 = v1772 == 0;\n\tif (v1871) goto L_02A2;\n\tv715 = v420 < 1;\n\tif (v715) goto L_02A2;\n\tv2003 = v420 - 1;\n\tv2004 = v2003 < 0;\n\tv2005 = v2003 == 0;\n\tv2006 = v420 ^ 1;\n\tv2007 = v420 ^ v2003;\n\tv2008 = v2006 & v2007;\n\tv2009 = v2008 < 0;\n\tv2011 = v2004 == v2009;\n\tv317 = ~v2005;\n\tv2012 = v2011 & v317;\n\tv308 = ~v2012;\n\tif (v308) goto L_FFFFFFFF;\n\tgoto L_0234;\nL_0234:\n\tgoto L_025B;\n\tv2487 = *([v2383 @ X8_v105+B0]);\n\tv2488 = v2487 + 8;\n\tv2490 = *([v2668 @ X10_v101-8]);\n\tv2683 = v2490 == v2384;\n\tif (v2683) goto L_0253;\n\tv2494 = v2669 - 1;\n\tv2492 = v2668 + 0x10;\n\tv2496 = v2669 != 1;\n\tif (v2496) goto L_FFFFFFFF;\n\tv2513 = v581;\n\tv2514 = 0;\n\tv2515 = 0xB349B4(v2513, v2384, v2514, v565, v424, v406, v388, v376, v2365, v463, v50, v51, v52, v53, v54, v55);\n\tgoto L_025B;\nL_0253:\n\tv2898 = *([v2668 @ X10_v101]);\n\tv2899 = v2898 << 4;\n\tv2900 = v2383 + v2899;\n\tv2901 = v2900 + 0x138;\nL_025B:\n\tv2919 = System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>::get_Item(v372, v341);\n\tv2922 = UnityEngine.AnimatorClipInfo::get_weight(&v2919 @ X0_v144 (UnityEngine.AnimatorClipInfo));\n\tv532 = v522 * v2922;\n\tv716 = v532 != 0;\n\tif (v716) goto L_027B;\nL_026C:\n\tv341 = v341 + 1;\n\tv1893 = v341 != v325;\n\tif (v1893) goto L_0234;\n\tgoto L_02A2;\nL_027B:\n\tv3197 = UnityEngine.AnimatorClipInfo::get_clip(&v2919 @ X0_v144 (UnityEngine.AnimatorClipInfo));\n\tv995 = Spine.Unity.SkeletonMecanim+MecanimTranslator::GetAnimation(this, v3197);\n\tv3191 = v995 == 0;\n\tif (v3191) goto L_026C;\n\tv1052 = v1069._items;\n\tv624 = v1069._version + 1;\n\tv1069._version = v624;\n\tv3170 = v1069._size;\n\tv3646 = v1069._size < v1052.Length;\n\tv3188 = ~v3646;\n\tif (v3188) goto L_029F;\n\tv3171 = v1069._size + 1;\n\tv1069._size = v3171;\n\tv1052[v3170 @ X10_v96 (System.Int32)] = v995;\n\tgoto L_026C;\nL_029F:\n\tSystem.Collections.Generic.List`1<Spine.Animation>::AddWithResize(v1069, v995);\n\tgoto L_026C;\nL_02A2:\n\tv1818 = ~v443;\n\tif (v1818) goto L_034A;\n\tv717 = v402 < 1;\n\tif (v717) goto L_034A;\n\tv2143 = v402 - 1;\n\tv2144 = v2143 < 0;\n\tv2145 = v2143 == 0;\n\tv2146 = v402 ^ 1;\n\tv2147 = v402 ^ v2143;\n\tv2148 = v2146 & \n// ... truncated")]
			public unsafe void Apply(Skeleton skeleton)
			{
				//IL_0133: Unknown result type (might be due to invalid IL or missing references)
				//IL_0138: Expected O, but got Unknown
				//IL_0b4b: Expected O, but got I
				//IL_1222: Expected O, but got Ref
				//IL_10a0: Expected O, but got Ref
				//IL_1289: Expected O, but got Ref
				//IL_1312: Expected O, but got Ref
				//IL_1379: Expected O, but got Ref
				//IL_111f: Expected O, but got Ref
				//IL_14be: Expected O, but got Ref
				//IL_1184: Expected O, but got Ref
				//IL_13fd: Expected O, but got Ref
				ref System.Int32Enum[] reference = ref *(System.Int32Enum[]*)((nint)this + 24);
				System.Int32Enum[] array = reference;
				int layerCount = Animator.layerCount;
				if (layerCount > array.Length)
				{
					System.Int32Enum[] array2 = reference;
					int layerCount2 = Animator.layerCount;
					Array.Resize(ref reference, layerCount2);
					Animator animator = Animator;
					int num = array2.Length;
					int num2 = array2.Length << 2;
					int num3 = num2 + 32;
					while (true)
					{
						int layerCount3 = animator.layerCount;
						if (num >= layerCount3)
						{
							break;
						}
						MixBlend[] array3 = layerBlendModes;
						if (num < array3.Length)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ X8_v132 (Spine.MixBlend[])+v661 @ X23_v16 (System.Int32)]");
							int num4 = (int)(-3);
							bool flag = num4 == 0;
							bool flag2 = !flag;
							bool flag3 = flag2;
						}
						else
						{
							bool flag3 = true;
						}
						int num5 = num << 2;
						object obj = reference + num5;
						animator = Animator;
						num++;
						num3 += 4;
						if ((object)Animator == null)
						{
							NullReferenceException ex = new NullReferenceException();
							throw new IndexOutOfRangeException();
						}
					}
				}
				InitClipInfosForLayers();
				int layerCount4 = Animator.layerCount;
				if (layerCount4 >= 1)
				{
					int num6 = 0;
					do
					{
						GetStateUpdatesFromAnimator(num6);
						num6++;
					}
					while (layerCount4 != num6);
				}
				if (autoReset)
				{
					List<Animation> list = previousAnimations;
					if (list.Count > 0)
					{
						int num7 = 0;
						do
						{
							Animation animation = list[num7];
							animation.SetKeyedItemsToSetupPose(skeleton);
							num7++;
						}
						while (list.Count != num7);
						int version = list._version + 1;
						list._size = 0;
						list._version = version;
						if (list.Count >= 1)
						{
							Array.Clear(list._items, 0, list.Count);
						}
					}
					else
					{
						int version2 = list._version + 1;
						list._size = 0;
						list._version = version2;
					}
					int layerCount5 = Animator.layerCount;
					if (layerCount5 >= 1)
					{
						int num8 = 0;
						do
						{
							bool flag4 = num8 == 0;
							float num9 = 1f;
							if (!flag4)
							{
								float layerWeight = Animator.GetLayerWeight(num8);
								bool flag5 = layerWeight < 0f;
								bool flag6 = !flag5;
								bool flag7 = layerWeight == 0f;
								bool flag8 = !flag6;
								bool flag9 = flag8 || flag7;
								num9 = layerWeight;
								if (flag9)
								{
									goto IL_0a58;
								}
							}
							int fullPathHash = System.Runtime.CompilerServices.Unsafe.As<int, AnimatorStateInfo>(ref Animator.GetNextAnimatorStateInfo(num8).m_Name).fullPathHash;
							GetAnimatorClipInfos(num8, out var isInterruptionActive, out var clipInfoCount, out var nextClipInfoCount, out var interruptingClipInfoCount, out var clipInfo, out var nextClipInfo, out var interruptingClipInfo, out var shallInterpolateWeightTo);
							if (clipInfoCount >= 1)
							{
								int num10 = clipInfoCount - 1;
								bool flag10 = num10 < 0;
								bool flag11 = num10 == 0;
								int num11 = clipInfoCount ^ 1;
								int num12 = clipInfoCount ^ num10;
								int num13 = num11 & num12;
								bool flag12 = num13 < 0;
								bool flag13 = flag10 == flag12;
								bool flag14 = !flag11;
								int num14;
								int num15;
								if (flag13 && flag14)
								{
									num14 = clipInfoCount;
									num15 = 0;
								}
								else
								{
									num14 = 1;
									num15 = 0;
								}
								do
								{
									AnimatorClipInfo animatorClipInfo = clipInfo[num15];
									float weight = animatorClipInfo.weight;
									float num16 = num9 * weight;
									if (num16 != 0f)
									{
										AnimationClip clip = animatorClipInfo.clip;
										Animation animation2 = GetAnimation(clip);
										if (animation2 != null)
										{
											Animation[] items = list._items;
											int version3 = list._version + 1;
											list._version = version3;
											int count = list.Count;
											if (list.Count < items.Length)
											{
												int size = list.Count + 1;
												list._size = size;
												items[count] = animation2;
											}
											else
											{
												list.Add(animation2);
											}
										}
									}
									num15++;
								}
								while (num15 != num14);
							}
							if (fullPathHash != 0 && nextClipInfoCount >= 1)
							{
								int num17 = nextClipInfoCount - 1;
								bool flag15 = num17 < 0;
								bool flag16 = num17 == 0;
								int num18 = nextClipInfoCount ^ 1;
								int num19 = nextClipInfoCount ^ num17;
								int num20 = num18 & num19;
								bool flag17 = num20 < 0;
								bool flag18 = flag15 == flag17;
								bool flag19 = !flag16;
								int num21;
								int num22;
								if (flag18 && flag19)
								{
									num21 = nextClipInfoCount;
									num22 = 0;
								}
								else
								{
									num21 = 1;
									num22 = 0;
								}
								do
								{
									AnimatorClipInfo animatorClipInfo2 = nextClipInfo[num22];
									float weight2 = animatorClipInfo2.weight;
									float num23 = num9 * weight2;
									if (num23 != 0f)
									{
										AnimationClip clip2 = animatorClipInfo2.clip;
										Animation animation3 = GetAnimation(clip2);
										if (animation3 != null)
										{
											Animation[] items2 = list._items;
											int version4 = list._version + 1;
											list._version = version4;
											int count2 = list.Count;
											if (list.Count < items2.Length)
											{
												int size2 = list.Count + 1;
												list._size = size2;
												items2[count2] = animation3;
											}
											else
											{
												list.Add(animation3);
											}
										}
									}
									num22++;
								}
								while (num22 != num21);
							}
							if (isInterruptionActive && interruptingClipInfoCount >= 1)
							{
								int num24 = interruptingClipInfoCount - 1;
								bool flag20 = num24 < 0;
								bool flag21 = num24 == 0;
								int num25 = interruptingClipInfoCount ^ 1;
								int num26 = interruptingClipInfoCount ^ num24;
								int num27 = num25 & num26;
								bool flag22 = num27 < 0;
								bool flag23 = flag20 == flag22;
								bool flag24 = !flag21;
								int num28;
								int num29;
								if (flag23 && flag24)
								{
									num28 = interruptingClipInfoCount;
									num29 = 0;
								}
								else
								{
									num28 = 1;
									num29 = 0;
								}
								do
								{
									AnimatorClipInfo animatorClipInfo3 = interruptingClipInfo[num29];
									float num30 = animatorClipInfo3.weight;
									float num31 = num30 + 1f;
									float num32 = num31 * 0.5f;
									if (shallInterpolateWeightTo)
									{
										num30 = num32;
									}
									float num33 = num9 * num30;
									if (num33 != 0f)
									{
										AnimationClip clip3 = animatorClipInfo3.clip;
										Animation animation4 = GetAnimation(clip3);
										if (animation4 != null)
										{
											Animation[] items3 = list._items;
											int version5 = list._version + 1;
											list._version = version5;
											int count3 = list.Count;
											if (list.Count < items3.Length)
											{
												int size3 = list.Count + 1;
												list._size = size3;
												items3[count3] = animation4;
											}
											else
											{
												list.Add(animation4);
											}
										}
									}
									num29++;
								}
								while (num29 != num28);
							}
							goto IL_0a58;
							IL_0a58:
							num8++;
						}
						while (num8 != layerCount5);
					}
				}
				int layerCount6 = Animator.layerCount;
				if (layerCount6 < 1)
				{
					return;
				}
				int num34 = 0;
				do
				{
					float layerWeight3;
					int num35;
					if (num34 != 0)
					{
						float layerWeight2 = Animator.GetLayerWeight(num34);
						layerWeight3 = layerWeight2;
						num35 = num34;
					}
					else
					{
						layerWeight3 = 1f;
						num35 = 0;
					}
					GetAnimatorStateInfos(num35, out var isInterruptionActive2, out var stateInfo, out var nextStateInfo, out var interruptingStateInfo, out var interruptingClipTimeAddition);
					int fullPathHash2 = nextStateInfo.fullPathHash;
					GetAnimatorClipInfos(num35, out isInterruptionActive2, out var clipInfoCount2, out var nextClipInfoCount2, out var interruptingClipInfoCount2, out var clipInfo2, out var nextClipInfo2, out var interruptingClipInfo2, out var shallInterpolateWeightTo2);
					MixBlend[] array4 = layerBlendModes;
					MixBlend layerBlendMode;
					if (num34 < array4.Length)
					{
						int num36 = num34 << 2;
						object obj2 = (nint)array4 + num36;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1830 @ X8_v80+20]");
						layerBlendMode = MixBlend.Setup;
					}
					else
					{
						layerBlendMode = MixBlend.Replace;
					}
					MixMode mixMode = GetMixMode(num35, layerBlendMode);
					int num40;
					if (mixMode != MixMode.AlwaysMix)
					{
						int num37 = ~clipInfoCount2;
						int num38 = clipInfoCount2 & num37;
						int num39 = 0;
						while (num39 != num38)
						{
							AnimatorClipInfo info = clipInfo2[num39];
							bool flag25 = ApplyAnimation(skeleton, info, (AnimatorStateInfo)(&stateInfo), num35, layerWeight3, layerBlendMode, useClipWeight1: true);
							num39++;
							if (!flag25)
							{
								continue;
							}
							if (num39 < clipInfoCount2)
							{
								do
								{
									AnimatorClipInfo info2 = clipInfo2[num39];
									bool flag26 = ApplyAnimation(skeleton, info2, (AnimatorStateInfo)(&stateInfo), num35, layerWeight3, layerBlendMode);
									num39++;
								}
								while (num39 != clipInfoCount2);
							}
							break;
						}
						if (fullPathHash2 != 0)
						{
							if (mixMode != MixMode.Hard)
							{
								num40 = 0;
								goto IL_11cf;
							}
							int num41 = ~nextClipInfoCount2;
							int num42 = nextClipInfoCount2 & num41;
							num40 = 0;
							while (num40 != num42)
							{
								AnimatorClipInfo info3 = nextClipInfo2[num40];
								bool flag27 = ApplyAnimation(skeleton, info3, (AnimatorStateInfo)(&nextStateInfo), num35, layerWeight3, layerBlendMode, useClipWeight1: true);
								num40++;
								if (!flag27)
								{
									continue;
								}
								goto IL_11cf;
							}
						}
						goto IL_0cf8;
					}
					if (clipInfoCount2 >= 1)
					{
						int num43 = 0;
						do
						{
							AnimatorClipInfo info4 = clipInfo2[num43];
							bool flag28 = ApplyAnimation(skeleton, info4, (AnimatorStateInfo)(&stateInfo), num35, layerWeight3, layerBlendMode);
							num43++;
						}
						while (num43 < clipInfoCount2);
					}
					if (nextClipInfoCount2 >= 1 && fullPathHash2 != 0)
					{
						int num44 = 0;
						do
						{
							AnimatorClipInfo info5 = nextClipInfo2[num44];
							bool flag29 = ApplyAnimation(skeleton, info5, (AnimatorStateInfo)(&nextStateInfo), num35, layerWeight3, layerBlendMode);
							num44++;
						}
						while (num44 < nextClipInfoCount2);
					}
					if (isInterruptionActive2 && interruptingClipInfoCount2 >= 1)
					{
						int num45 = 0;
						do
						{
							bool flag30 = !shallInterpolateWeightTo2;
							bool interpolateWeightTo = !flag30;
							AnimatorClipInfo info6 = interruptingClipInfo2[num45];
							bool flag31 = ApplyInterruptionAnimation(skeleton, interpolateWeightTo, info6, (AnimatorStateInfo)(&interruptingStateInfo), num35, layerWeight3, layerBlendMode, interruptingClipTimeAddition);
							num45++;
						}
						while (num45 < interruptingClipInfoCount2);
					}
					goto IL_0d71;
					IL_0d71:
					num34++;
					continue;
					IL_0cf8:
					int num46;
					if (isInterruptionActive2)
					{
						if (mixMode != MixMode.Hard)
						{
							num46 = 0;
							goto IL_1449;
						}
						int num47 = ~interruptingClipInfoCount2;
						int num48 = interruptingClipInfoCount2 & num47;
						num46 = 0;
						while (num46 != num48)
						{
							bool flag32 = !shallInterpolateWeightTo2;
							bool interpolateWeightTo2 = !flag32;
							AnimatorClipInfo info7 = interruptingClipInfo2[num46];
							bool flag33 = ApplyInterruptionAnimation(skeleton, interpolateWeightTo2, info7, (AnimatorStateInfo)(&interruptingStateInfo), num35, layerWeight3, layerBlendMode, interruptingClipTimeAddition, useClipWeight1: true);
							num46++;
							if (!flag33)
							{
								continue;
							}
							goto IL_1449;
						}
					}
					goto IL_0d71;
					IL_1449:
					if (num46 < interruptingClipInfoCount2)
					{
						do
						{
							bool flag34 = !shallInterpolateWeightTo2;
							bool interpolateWeightTo3 = !flag34;
							AnimatorClipInfo info8 = interruptingClipInfo2[num46];
							bool flag35 = ApplyInterruptionAnimation(skeleton, interpolateWeightTo3, info8, (AnimatorStateInfo)(&interruptingStateInfo), num35, layerWeight3, layerBlendMode, interruptingClipTimeAddition);
							num46++;
						}
						while (num46 < interruptingClipInfoCount2);
					}
					goto IL_0d71;
					IL_11cf:
					if (num40 < nextClipInfoCount2)
					{
						do
						{
							AnimatorClipInfo info9 = nextClipInfo2[num40];
							bool flag36 = ApplyAnimation(skeleton, info9, (AnimatorStateInfo)(&nextStateInfo), num35, layerWeight3, layerBlendMode);
							num40++;
						}
						while (num40 < nextClipInfoCount2);
					}
					goto IL_0cf8;
				}
				while (num34 != layerCount6);
			}

			[Token(Token = "0x60005A3")]
			[Address(RVA = "0x1558500", Offset = "0x1558500", Length = "0x200")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, layer, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv52 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, layer, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37C52]) = v43;\nL_001D:\n\tv49 = this.layerClipInfos;\n\tv65 = v49.Length <= layer;\n\tif (v65) goto L_FFFFFFFF;\n\tv153 = v49[layer @ X1 (System.Int32)];\n\tv249 = ~v153.isInterruptionActive;\n\tif (v249) goto L_0065;\n\tv87 = v153.interruptingClipInfoCount < 1;\n\tif (v87) goto L_0065;\n\tv305 = System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::get_Item(v153.interruptingClipInfos, 0);\n\tv313 = UnityEngine.AnimatorClipInfo::get_clip(&v305 @ X0_v25 (UnityEngine.AnimatorClipInfo));\n\tv151 = v49[layer @ X1 (System.Int32)] + 0x80;\n\tgoto L_006D;\n\tgoto L_00CC;\nL_0065:\n\tv300 = System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::get_Item(v153.clipInfos, 0);\n\tv309 = UnityEngine.AnimatorClipInfo::get_clip(&v300 @ X0_v21 (UnityEngine.AnimatorClipInfo));\n\tv151 = v49[layer @ X1 (System.Int32)] + 0x38;\nL_006D:\n\tv73 = *([v151 @ X8_v11]);\n\tv324 = Spine.Unity.SkeletonMecanim+MecanimTranslator::GetAnimation(this, v146);\n\tv361 = UnityEngine.AnimatorStateInfo::get_normalizedTime(&v73 @ V1_v4 (UnityEngine.AnimatorStateInfo));\n\tv327 = UnityEngine.AnimationClip::get_length(v146);\n\tv330 = UnityEngine.Motion::get_isLooping(v146);\n\tv333 = UnityEngine.AnimatorStateInfo::get_speed(&v73 @ V1_v4 (UnityEngine.AnimatorStateInfo));\n\tv334 = 1f - v361;\n\tv344 = v333 >= 0;\n\tif (v344) goto L_00A1;\n\tgoto L_00A1;\nL_00A1:\n\tv357 = v361 >= 0;\n\tif (v357) goto L_00AA;\n\tv359 = System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::get_Item(&v73 @ V1_v4 (UnityEngine.AnimatorStateInfo), 0);\n\tv361 = v361 + 1f;\nL_00AA:\n\tv207 = v327 * v361;\n\tv192 = v327 - v207;\n\tv373 = v192 >= 0.033333335f;\n\tif (v373) goto L_FFFFFFFF;\n\tgoto L_00BE;\nL_00BE:\n\tv230 = v330 == 0;\n\tv220 = ~v230;\n\tv197 = ~v220;\n\tif (v197) goto L_FFFFFFFF;\n\tgoto L_00CA;\nL_00CA:\n\tv161 = 0;\nL_00CC:\n\tSystem.Collections.Generic.KeyValuePair`2<System.Object, System.Single>::.ctor(this, v216, v207);\n\treturn v161;\n\tv154 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe KeyValuePair<Animation, float> GetActiveAnimationAndTime(int layer)
			{
				//IL_0232: Expected native int or pointer, but got O
				//IL_0121: Unknown result type (might be due to invalid IL or missing references)
				//IL_0126: Expected O, but got Unknown
				//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bc: Expected O, but got Unknown
				ClipInfos[] array = layerClipInfos;
				float num3;
				KeyValuePair<Animation, float> keyValuePair = default(KeyValuePair<Animation, float>);
				Animation key;
				if (array.Length > layer)
				{
					ClipInfos clipInfos = array[layer];
					object obj;
					AnimationClip animationClip;
					if (clipInfos.isInterruptionActive && clipInfos.interruptingClipInfoCount >= 1)
					{
						AnimationClip clip = clipInfos.interruptingClipInfos[0].clip;
						obj = array[layer] + 128;
						animationClip = clip;
					}
					else
					{
						AnimationClip clip2 = clipInfos.clipInfos[0].clip;
						obj = array[layer] + 56;
						animationClip = clip2;
					}
					AnimatorStateInfo animatorStateInfo = (AnimatorStateInfo)obj;
					Animation animation = GetAnimation(animationClip);
					float num = animatorStateInfo.normalizedTime;
					float length = animationClip.length;
					bool isLooping = animationClip.isLooping;
					float speed = animatorStateInfo.speed;
					float num2 = 1f - num;
					if (speed < 0f)
					{
						num = num2;
					}
					if (num < 0f)
					{
						AnimatorClipInfo animatorClipInfo = ((List<AnimatorClipInfo>)animatorStateInfo)[0];
						num += 1f;
					}
					num3 = length * num;
					float num4 = length - num3;
					float num5 = ((!(num4 < 1f / 30f)) ? num3 : length);
					if (!isLooping)
					{
						num3 = num5;
					}
					keyValuePair = default(KeyValuePair<Animation, float>);
					keyValuePair = default(KeyValuePair<Animation, float>);
					key = animation;
					MecanimTranslator mecanimTranslator = (MecanimTranslator)keyValuePair;
				}
				else
				{
					num3 = 0f;
					key = null;
					MecanimTranslator mecanimTranslator = (MecanimTranslator)keyValuePair;
				}
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)this, new KeyValuePair<object, float>(key, num3));
				return keyValuePair;
			}

			[Token(Token = "0x60005A4")]
			[Address(RVA = "0x1560AFC", Offset = "0x1560AFC", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = 1f - v51;\n\tv14 = reversed == 0;\n\tv17 = ~v14;\n\tv18 = ~v17;\n\tif (v18) goto L_001E;\n\tgoto L_001E;\nL_001E:\n\tv35 = v51 >= 0;\n\tif (v35) goto L_0023;\n\tv37 = 0x1854EF0(loop, reversed, methodInfo, v39, v40, v41, v42, v43, v51, 1f, v9, v44, v45, v46, v47, v48);\n\tv51 = v51 + 1f;\nL_0023:\n\treturnVal1 = v51 * clipLength;\n\tv55 = loop == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_003F;\n\tv59 = clipLength - returnVal1;\n\tv69 = v59 >= 0.033333335f;\n\tif (v69) goto L_003F;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static float AnimationTime(float normalizedTime, float clipLength, bool loop, bool reversed)
			{
				//IL_005e: Expected O, but got F4
				float num2 = default(float);
				float num = 1f - num2;
				if (reversed)
				{
					num2 = num;
				}
				if (num2 < 0f)
				{
					object obj = num2 % 1f;
					num2 += 1f;
				}
				float num3 = num2 * clipLength;
				if (!loop)
				{
					float num4 = clipLength - num3;
					if (num4 < 1f / 30f)
					{
						num3 = clipLength;
					}
				}
				return num3;
			}

			[Token(Token = "0x60005A5")]
			[Address(RVA = "0x1560E20", Offset = "0x1560E20", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 1f - v48;\n\tv12 = reversed == 0;\n\tv15 = ~v12;\n\tv16 = ~v15;\n\tif (v16) goto L_001C;\n\tgoto L_001C;\nL_001C:\n\tv31 = v48 >= 0;\n\tif (v31) goto L_0022;\n\tv33 = 0x1854EF0(reversed, methodInfo, v35, v36, v37, v38, v39, v40, v48, 1f, v7, v41, v42, v43, v44, v45);\n\tv48 = v48 + 1f;\nL_0022:\n\treturnVal1 = v48 * clipLength;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static float AnimationTime(float normalizedTime, float clipLength, bool reversed)
			{
				//IL_005e: Expected O, but got F4
				float num2 = default(float);
				float num = 1f - num2;
				if (reversed)
				{
					num2 = num;
				}
				if (num2 < 0f)
				{
					object obj = num2 % 1f;
					num2 += 1f;
				}
				return num2 * clipLength;
			}

			[Token(Token = "0x60005A6")]
			[Address(RVA = "0x1560E60", Offset = "0x1560E60", Length = "0x148")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = Spine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C53]) = v42;\nL_0018:\n\tv44 = this + 0x48;\n\tv45 = this.layerClipInfos;\n\tv133 = UnityEngine.Animator::get_layerCount(this.animator);\n\tv68 = v133 <= v45.Length;\n\tif (v68) goto L_0091;\n\tv229 = UnityEngine.Animator::get_layerCount(this.animator);\n\tSystem.Array::Resize(v44, v229);\n\tv214 = UnityEngine.Animator::get_layerCount(this.animator);\n\tv184 = v214 < 1;\n\tif (v184) goto L_0091;\nL_004F:\n\tv52 = this.layerClipInfos;\n\tv264 = v52[v60 @ X21_v7 (System.Int32)] == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_007D;\n\tv280 = new Spine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos();\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos::.ctor(v280);\n\tv292 = v280 == 0;\n\tif (v292) goto L_007C;\n\t// 108 IsInst v161 @ X0_v23, typeof(System.Object), v280 @ X0_v20 (Spine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos)\n\tv163 = v161 == 0;\n\tif (v163) goto L_0094;\nL_007C:\n\tv52[v60 @ X21_v7 (System.Int32)] = v280;\nL_007D:\n\tv60 = v60 + 1;\n\tv183 = v214 != v60;\n\tif (v183) goto L_004F;\nL_0091:\n\treturn;\n\tv115 = new System.IndexOutOfRangeException();\n\tv132 = new System.NullReferenceException();\nL_0094:\n\tv168 = new System.ArrayTypeMismatchException();\n\tthrow v168;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void InitClipInfosForLayers()
			{
				ref object[] reference = ref *(object[]*)((nint)this + 72);
				object[] array = reference;
				int layerCount = Animator.layerCount;
				if (layerCount <= array.Length)
				{
					return;
				}
				int layerCount2 = Animator.layerCount;
				Array.Resize(ref reference, layerCount2);
				int layerCount3 = Animator.layerCount;
				if (layerCount3 < 1)
				{
					return;
				}
				int num = 0;
				while (true)
				{
					object[] array2 = reference;
					if (array2[num] == null)
					{
						ClipInfos clipInfos = new ClipInfos();
						if (clipInfos != null)
						{
							object obj = clipInfos as object;
							if (obj == null)
							{
								break;
							}
						}
						array2[num] = clipInfos;
					}
					num++;
					if (layerCount3 == num)
					{
						return;
					}
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}

			[Token(Token = "0x60005A7")]
			[Address(RVA = "0x15606D4", Offset = "0x15606D4", Length = "0x13C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = Spine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C54]) = v42;\nL_0017:\n\tv61 = this.layerClipInfos;\n\tv58 = v61.Length < 1;\n\tif (v58) goto L_0085;\n\tv138 = v61.Length & 0xFFFFFFFF;\n\tv81 = v138 - 1;\nL_0039:\n\tv131 = v61[v84 @ X21_v5 (System.Int32)];\n\tv221 = v61[v84 @ X21_v5 (System.Int32)] == 0;\n\tif (v221) goto L_0054;\n\tv73 = v131.clipInfos;\n\tv131.isInterruptionActive = 0;\n\tv68 = v73._version + 1;\n\tv73._size = 0;\n\tv73._version = v68;\n\tv74 = v131.nextClipInfos;\n\tv69 = v74._version + 1;\n\tv74._size = 0;\n\tv74._version = v69;\n\tv132 = v131.interruptingClipInfos;\n\tv263 = v132._version + 1;\n\tv132._size = 0;\n\tv132._version = v263;\n\tgoto L_0071;\nL_0054:\n\tv251 = new Spine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos();\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos::.ctor(v251);\n\tv261 = v251 == 0;\n\tif (v261) goto L_006C;\n\t// 92 IsInst v255 @ X0_v16, typeof(Spine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos), v251 @ X0_v13 (Spine.Unity.SkeletonMecanim+MecanimTranslator+ClipInfos)\n\tv256 = v255 == 0;\n\tif (v256) goto L_0087;\nL_006C:\n\tv61[v84 @ X21_v5 (System.Int32)] = v251;\nL_0071:\n\tv106 = v81 == v84;\n\tif (v106) goto L_0085;\n\tv61 = this.layerClipInfos;\n\tv84 = v84 + 1;\n\tv278 = this.layerClipInfos == 0;\n\tv125 = ~v278;\n\tif (v125) goto L_0039;\n\tthrow System.NullReferenceException;\nL_0085:\n\treturn;\n\tv249 = new System.IndexOutOfRangeException();\nL_0087:\n\tv258 = new System.ArrayTypeMismatchException();\n\tthrow v258;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void ClearClipInfosForLayers()
			{
				//IL_0038: Expected I4, but got I8
				ClipInfos[] array = layerClipInfos;
				if (array.Length < 1)
				{
					return;
				}
				int num = (int)(array.Length & 0xFFFFFFFFL);
				int num2 = num - 1;
				int num3 = 0;
				while (true)
				{
					ClipInfos clipInfos = array[num3];
					if (array[num3] != null)
					{
						List<AnimatorClipInfo> clipInfos2 = clipInfos.clipInfos;
						clipInfos.isInterruptionActive = false;
						clipInfos.isLastFrameOfInterruption = false;
						int version = clipInfos2._version + 1;
						clipInfos2._size = 0;
						clipInfos2._version = version;
						List<AnimatorClipInfo> nextClipInfos = clipInfos.nextClipInfos;
						int version2 = nextClipInfos._version + 1;
						nextClipInfos._size = 0;
						nextClipInfos._version = version2;
						List<AnimatorClipInfo> interruptingClipInfos = clipInfos.interruptingClipInfos;
						int version3 = interruptingClipInfos._version + 1;
						interruptingClipInfos._size = 0;
						interruptingClipInfos._version = version3;
					}
					else
					{
						ClipInfos clipInfos3 = new ClipInfos();
						if (clipInfos3 != null)
						{
							object obj = clipInfos3 as ClipInfos;
							if (obj == null)
							{
								break;
							}
						}
						array[num3] = clipInfos3;
					}
					if (num2 != num3)
					{
						array = layerClipInfos;
						num3++;
						if (layerClipInfos == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					return;
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}

			[Token(Token = "0x60005A8")]
			[Address(RVA = "0x15613C4", Offset = "0x15613C4", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.useCustomMixMode;\n\tif (v4) goto L_0034;\n\tv51 = layer << 2;\n\tv85 = this.layerMixModes + v51;\n\tv83 = v85 + 0x20;\n\treturnVal1 = *([v83 @ X8_v5]);\n\tv53 = layerBlendMode != 3;\n\tif (v53) goto L_003F;\n\tv54 = *([v83 @ X8_v5]) != 1;\n\tif (v54) goto L_003F;\n\t*([v83 @ X8_v5]) = 0;\n\tgoto L_003F;\nL_0034:\n\tv10 = layerBlendMode - 3;\n\tv12 = v10 == 0;\n\tv17 = ~v12;\nL_003F:\n\treturn returnVal1;\n\tv32 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private MixMode GetMixMode(int layer, MixBlend layerBlendMode)
			{
				//IL_0039: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_0050: Expected I4, but got O
				//IL_0099: Expected O, but got I4
				MixMode result;
				if (useCustomMixMode)
				{
					int num = layer << 2;
					object obj = (nint)layerMixModes + num;
					object obj2 = (nint)obj + 32;
					result = (MixMode)obj2;
					if (layerBlendMode == MixBlend.Add && (nint)obj2 == 1)
					{
						obj2 = 0;
						result = default(MixMode);
					}
				}
				else
				{
					int num2 = (int)(layerBlendMode - 3);
					bool flag = num2 == 0;
					bool flag2 = !flag;
					result = (flag2 ? MixMode.MixNext : MixMode.AlwaysMix);
				}
				return result;
			}

			[Token(Token = "0x60005A9")]
			[Address(RVA = "0x1560FA8", Offset = "0x1560FA8", Length = "0x308")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-90 (UnityEngine.AnimatorStateInfo);\n\tgoto L_0023;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, layer, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, layer, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv299 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v299, layer, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37C55]) = v55;\nL_0023:\n\t*([v30 @ X27_v1]) = 0;\n\t*([v30 @ X27_v1+10]) = 0;\n\tv58 = this.layerClipInfos;\n\tv177 = v58[layer @ X1 (System.Int32)];\n\tv259 = UnityEngine.Animator::GetCurrentAnimatorClipInfoCount(this.animator, layer);\n\tv260 = UnityEngine.Animator::GetNextAnimatorClipInfoCount(this.animator, layer);\n\tv153 = v177.clipInfos;\n\tv296 = v177.nextClipInfos;\n\tv150 = v177.interruptingClipInfos;\n\tv146 = v259 != 0;\n\tif (v146) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\tv477 = v259 == 0;\n\tif (v477) goto L_0063;\n\tgoto L_0081;\nL_0063:\n\tv483 = v153._size == 0;\n\tif (v483) goto L_006D;\n\tv484 = v260 == 0;\n\tif (v484) goto L_0078;\n\tv493 = v481 == 0;\n\tv273 = ~v493;\n\tif (v273) goto L_0081;\n\tgoto L_0146;\nL_006D:\n\tv485 = v58[layer @ X1 (System.Int32)] == 0;\n\tv274 = ~v485;\n\tif (v274) goto L_0081;\n\tgoto L_0146;\nL_0078:\n\tv221 = v296._size == 0;\n\tv182 = ~v221;\nL_0081:\n\tv481.isInterruptionActive = v255;\n\tv482 = ~v177.isInterruptionActive;\n\tif (v482) goto L_00C6;\n\tv488 = UnityEngine.Animator::GetNextAnimatorStateInfo(this.animator, layer);\n\t*([v30 @ X27_v1]) = v488.m_Name;\n\t*([v30 @ X27_v1+10]) = v488.m_Length;\n\tv496 = UnityEngine.AnimatorStateInfo::get_fullPathHash(&v31 @ stack_-90 (UnityEngine.AnimatorStateInfo));\n\tv223 = v496 == 0;\n\tv177.isLastFrameOfInterruption = v223;\n\tv501 = v496 == 0;\n\tif (v501) goto L_0145;\n\tUnityEngine.Animator::GetNextAnimatorClipInfo(this.animator, layer, v177.interruptingClipInfos);\n\tv544 = v58[layer @ X1 (System.Int32)] + 0x80;\n\tv177.interruptingClipInfoCount = v150._size;\n\tv546 = UnityEngine.AnimatorStateInfo::get_normalizedTime(v544);\n\tv547 = UnityEngine.AnimatorStateInfo::get_normalizedTime(&v31 @ stack_-90 (UnityEngine.AnimatorStateInfo));\n\tv548 = v547 - v546;\n\tv177.interruptingClipTimeAddition = v548;\n\tv177.interruptingStateInfo = *([v30 @ X27_v1]);\n\tv177.interruptingStateInfo.m_Length = *([v30 @ X27_v1+10]);\n\tv177.interruptingStateInfo.m_Loop = v488.m_Loop;\n\tgoto L_0145;\nL_00C6:\n\tv177.clipInfoCount = v259;\n\tv177.nextClipInfoCount = v260;\n\tv177.interruptingClipInfoCount = 0;\n\tv177.isLastFrameOfInterruption = 0;\n\tv492 = System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::get_Capacity(v153);\n\tv184 = v492 >= v259;\n\tif (v184) goto L_00E6;\n\tSystem.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::set_Capacity(v153, v259);\nL_00E6:\n\tv535 = System.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::get_Capacity(v177.nextClipInfos);\n\tv185 = v535 >= v260;\n\tif (v185) goto L_00FE;\n\tSystem.Collections.Generic.List`1<UnityEngine.AnimatorClipInfo>::set_Capacity(v177.nextClipInfos, v260);\nL_00FE:\n\tUnityEngine.Animator::GetCurrentAnimatorClipInfo(this.animator, layer, v153);\n\tUnityEngine.Animator::GetNextAnimatorClipInfo(this.animator, layer, v177.nextClipInfos);\n\tv549 = &v101 @ stack_-F0_v4 (UnityEngine.AnimatorStateInfo);\n\tv550 = UnityEngine.Animator::GetCurrentAnimatorStateInfo(this.animator, layer);\n\tv177.stateInfo.m_Loop = *([v549 @ X8_v14+20]);\n\tv177.stateInfo.m_Length = *([v549 @ X8_v14+10]);\n\tv177.stateInfo = *([v549 @ X8_v14]);\n\tv529 = UnityEngine.Animator::GetNextAnimatorStateInfo(this.animator, layer);\n\tv177.nextStateInfo.m_Loop = v529.m_Loop;\n\tv177.nextStateInfo.m_Length = v529.m_Length;\n\tv177.nextStateInfo = v529.m_Name;\nL_0145:\n\treturn;\nL_0146:\n\tv297 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n// 242 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void GetStateUpdatesFromAnimator(int layer)
			{
				//IL_04f9: Expected O, but got I4
				//IL_0214: Expected O, but got I4
				//IL_0472: Expected F4, but got I
				//IL_0298: Unknown result type (might be due to invalid IL or missing references)
				//IL_029d: Expected O, but got Unknown
				//IL_04d7: Expected O, but got I4
				//IL_0311: Expected F4, but got I
				AnimatorStateInfo animatorStateInfo = default(AnimatorStateInfo);
				object obj = animatorStateInfo;
				obj = 0;
				_ = 0;
				ClipInfos[] array = layerClipInfos;
				ClipInfos clipInfos = array[layer];
				int currentAnimatorClipInfoCount = Animator.GetCurrentAnimatorClipInfoCount(layer);
				int nextAnimatorClipInfoCount = Animator.GetNextAnimatorClipInfoCount(layer);
				List<AnimatorClipInfo> clipInfos2 = clipInfos.clipInfos;
				List<AnimatorClipInfo> nextClipInfos = clipInfos.nextClipInfos;
				List<AnimatorClipInfo> interruptingClipInfos = clipInfos.interruptingClipInfos;
				ClipInfos clipInfos3 = ((currentAnimatorClipInfoCount != 0) ? null : array[layer]);
				bool isInterruptionActive;
				if (currentAnimatorClipInfoCount != 0)
				{
					isInterruptionActive = false;
					clipInfos3 = array[layer];
				}
				else if (clipInfos2.Count != 0)
				{
					if (nextAnimatorClipInfoCount != 0)
					{
						bool flag = clipInfos3 == null;
						bool flag2 = !flag;
						isInterruptionActive = false;
						if (!flag2)
						{
							goto IL_04dc;
						}
					}
					else
					{
						bool flag3 = nextClipInfos.Count == 0;
						bool flag4 = !flag3;
						isInterruptionActive = flag4;
					}
				}
				else
				{
					bool flag5 = array[layer] == null;
					bool flag6 = !flag5;
					isInterruptionActive = (byte)clipInfos2.Count != 0;
					clipInfos3 = array[layer];
					if (!flag6)
					{
						goto IL_04dc;
					}
				}
				clipInfos3.isInterruptionActive = isInterruptionActive;
				if (clipInfos.isInterruptionActive)
				{
					AnimatorStateInfo nextAnimatorStateInfo = Animator.GetNextAnimatorStateInfo(layer);
					obj = nextAnimatorStateInfo.m_Name;
					_ = nextAnimatorStateInfo.m_Length;
					int fullPathHash = animatorStateInfo.fullPathHash;
					bool isLastFrameOfInterruption = fullPathHash == 0;
					clipInfos.isLastFrameOfInterruption = isLastFrameOfInterruption;
					if (fullPathHash != 0)
					{
						Animator.GetNextAnimatorClipInfo(layer, clipInfos.interruptingClipInfos);
						AnimatorStateInfo animatorStateInfo2 = (AnimatorStateInfo)(array[layer] + 128);
						clipInfos.interruptingClipInfoCount = interruptingClipInfos.Count;
						float normalizedTime = ((AnimatorStateInfo*)animatorStateInfo2)->normalizedTime;
						float normalizedTime2 = animatorStateInfo.normalizedTime;
						float interruptingClipTimeAddition = normalizedTime2 - normalizedTime;
						clipInfos.interruptingClipTimeAddition = interruptingClipTimeAddition;
						clipInfos.interruptingStateInfo = (AnimatorStateInfo)obj;
						ref AnimatorStateInfo interruptingStateInfo = ref clipInfos.interruptingStateInfo;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X27_v1+10]");
						interruptingStateInfo.m_Length = 0f;
						clipInfos.interruptingStateInfo.m_Loop = nextAnimatorStateInfo.m_Loop;
					}
					return;
				}
				clipInfos.clipInfoCount = currentAnimatorClipInfoCount;
				clipInfos.nextClipInfoCount = nextAnimatorClipInfoCount;
				clipInfos.interruptingClipInfoCount = 0;
				clipInfos.isLastFrameOfInterruption = false;
				int capacity = clipInfos2.Capacity;
				if (capacity < currentAnimatorClipInfoCount)
				{
					clipInfos2.Capacity = currentAnimatorClipInfoCount;
				}
				int capacity2 = clipInfos.nextClipInfos.Capacity;
				if (capacity2 < nextAnimatorClipInfoCount)
				{
					clipInfos.nextClipInfos.Capacity = nextAnimatorClipInfoCount;
				}
				Animator.GetCurrentAnimatorClipInfo(layer, clipInfos2);
				Animator.GetNextAnimatorClipInfo(layer, clipInfos.nextClipInfos);
				AnimatorStateInfo animatorStateInfo3 = default(AnimatorStateInfo);
				object stateInfo = animatorStateInfo3;
				AnimatorStateInfo currentAnimatorStateInfo = Animator.GetCurrentAnimatorStateInfo(layer);
				ref AnimatorStateInfo stateInfo2 = ref clipInfos.stateInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ X8_v14+20]");
				stateInfo2.m_Loop = 0;
				ref AnimatorStateInfo stateInfo3 = ref clipInfos.stateInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ X8_v14+10]");
				stateInfo3.m_Length = 0f;
				clipInfos.stateInfo = (AnimatorStateInfo)stateInfo;
				AnimatorStateInfo nextAnimatorStateInfo2 = Animator.GetNextAnimatorStateInfo(layer);
				clipInfos.nextStateInfo.m_Loop = nextAnimatorStateInfo2.m_Loop;
				clipInfos.nextStateInfo.m_Length = nextAnimatorStateInfo2.m_Length;
				clipInfos.nextStateInfo = (AnimatorStateInfo)nextAnimatorStateInfo2.m_Name;
				return;
				IL_04dc:
				NullReferenceException ex = new NullReferenceException();
				throw new IndexOutOfRangeException();
			}

			[Token(Token = "0x60005AA")]
			[Address(RVA = "0x15612B0", Offset = "0x15612B0", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.layerClipInfos;\n\tv44 = v2[layer @ X1 (System.Int32)];\n\t*([isInterruptionActive @ X2 (System.Boolean&)]) = v44.isInterruptionActive;\n\t*([clipInfoCount @ X3 (System.Int32&)]) = v44.clipInfoCount;\n\t*([nextClipInfoCount @ X4 (System.Int32&)]) = v44.nextClipInfoCount;\n\t*([interruptingClipInfoCount @ X5 (System.Int32&)]) = v44.interruptingClipInfoCount;\n\t*([clipInfo @ X6 (System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>&)]) = v44.clipInfos;\n\t*([nextClipInfo @ X7 (System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>&)]) = v44.nextClipInfos;\n\tv87 = *([isInterruptionActive @ X2 (System.Boolean&)]) == 0;\n\tif (v87) goto L_FFFFFFFF;\n\tv96 = v44.interruptingClipInfos;\n\tgoto L_002B;\nL_002B:\n\t*([interruptingClipInfo @ stack_0 (System.Collections.Generic.IList`1<UnityEngine.AnimatorClipInfo>&)]) = v96;\n\t*([shallInterpolateWeightTo1 @ stack_8 (System.Boolean&)]) = v44.isLastFrameOfInterruption;\n\treturn;\n\tv45 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void GetAnimatorClipInfos(int layer, out bool isInterruptionActive, out int clipInfoCount, out int nextClipInfoCount, out int interruptingClipInfoCount, out IList<AnimatorClipInfo> clipInfo, out IList<AnimatorClipInfo> nextClipInfo, out IList<AnimatorClipInfo> interruptingClipInfo, out bool shallInterpolateWeightTo1)
			{
				isInterruptionActive = default(bool);
				clipInfoCount = default(int);
				nextClipInfoCount = default(int);
				interruptingClipInfoCount = default(int);
				clipInfo = null;
				nextClipInfo = null;
				interruptingClipInfo = null;
				shallInterpolateWeightTo1 = default(bool);
				ClipInfos[] array = layerClipInfos;
				ClipInfos clipInfos = array[layer];
				ref bool reference = ref *(clipInfos.isInterruptionActive ? ((bool*)1) : ((bool*)null));
				ref int reference2 = ref *(int*)clipInfos.clipInfoCount;
				ref int reference3 = ref *(int*)clipInfos.nextClipInfoCount;
				ref int reference4 = ref *(int*)clipInfos.interruptingClipInfoCount;
				ref IList<AnimatorClipInfo> reference5 = ref *(IList<AnimatorClipInfo>*)clipInfos.clipInfos;
				ref IList<AnimatorClipInfo> reference6 = ref *(IList<AnimatorClipInfo>*)clipInfos.nextClipInfos;
				List<AnimatorClipInfo> list = ((!isInterruptionActive) ? null : clipInfos.interruptingClipInfos);
				ref IList<AnimatorClipInfo> reference7 = ref *(IList<AnimatorClipInfo>*)list;
				ref bool reference8 = ref *(clipInfos.isLastFrameOfInterruption ? ((bool*)1) : ((bool*)null));
			}

			[Token(Token = "0x60005AB")]
			[Address(RVA = "0x1561338", Offset = "0x1561338", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.layerClipInfos;\n\tv44 = v2[layer @ X1 (System.Int32)];\n\t*([isInterruptionActive @ X2 (System.Boolean&)]) = v44.isInterruptionActive;\n\t*([stateInfo @ X3 (UnityEngine.AnimatorStateInfo&)+20]) = v44.stateInfo.m_Loop;\n\t*([stateInfo @ X3 (UnityEngine.AnimatorStateInfo&)]) = v44.stateInfo;\n\t*([stateInfo @ X3 (UnityEngine.AnimatorStateInfo&)+10]) = v44.stateInfo.m_Length;\n\t*([nextStateInfo @ X4 (UnityEngine.AnimatorStateInfo&)+20]) = v44.nextStateInfo.m_Loop;\n\t*([nextStateInfo @ X4 (UnityEngine.AnimatorStateInfo&)]) = v44.nextStateInfo;\n\t*([nextStateInfo @ X4 (UnityEngine.AnimatorStateInfo&)+10]) = v44.nextStateInfo.m_Length;\n\t*([interruptingStateInfo @ X5 (UnityEngine.AnimatorStateInfo&)+20]) = v44.interruptingStateInfo.m_Loop;\n\t*([interruptingStateInfo @ X5 (UnityEngine.AnimatorStateInfo&)]) = v44.interruptingStateInfo;\n\t*([interruptingStateInfo @ X5 (UnityEngine.AnimatorStateInfo&)+10]) = v44.interruptingStateInfo.m_Length;\n\tv87 = ~v44.isLastFrameOfInterruption;\n\tif (v87) goto L_FFFFFFFF;\n\tv95 = v44.interruptingClipTimeAddition;\n\tgoto L_0031;\nL_0031:\n\t*([interruptingClipTimeAddition @ X6 (System.Single&)]) = v95;\n\treturn;\n\tv45 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void GetAnimatorStateInfos(int layer, out bool isInterruptionActive, out AnimatorStateInfo stateInfo, out AnimatorStateInfo nextStateInfo, out AnimatorStateInfo interruptingStateInfo, out float interruptingClipTimeAddition)
			{
				//IL_012b: Expected Ref, but got F4
				isInterruptionActive = default(bool);
				stateInfo = default(AnimatorStateInfo);
				nextStateInfo = default(AnimatorStateInfo);
				interruptingStateInfo = default(AnimatorStateInfo);
				interruptingClipTimeAddition = default(float);
				ClipInfos[] array = layerClipInfos;
				ClipInfos clipInfos = array[layer];
				ref bool reference = ref *(clipInfos.isInterruptionActive ? ((bool*)1) : ((bool*)null));
				_ = clipInfos.stateInfo.m_Loop;
				ref AnimatorStateInfo reference2 = ref *(AnimatorStateInfo*)clipInfos.stateInfo;
				_ = clipInfos.stateInfo.m_Length;
				_ = clipInfos.nextStateInfo.m_Loop;
				ref AnimatorStateInfo reference3 = ref *(AnimatorStateInfo*)clipInfos.nextStateInfo;
				_ = clipInfos.nextStateInfo.m_Length;
				_ = clipInfos.interruptingStateInfo.m_Loop;
				ref AnimatorStateInfo reference4 = ref *(AnimatorStateInfo*)clipInfos.interruptingStateInfo;
				_ = clipInfos.interruptingStateInfo.m_Length;
				float num = ((!clipInfos.isLastFrameOfInterruption) ? 0f : clipInfos.interruptingClipTimeAddition);
				ref float reference5 = ref *(float*)num;
			}

			[Token(Token = "0x60005AC")]
			[Address(RVA = "0x1560A08", Offset = "0x1560A08", Length = "0xF4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, clip, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, clip, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv82 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, clip, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37C56]) = v37;\nL_0022:\n\tv51 = System.Collections.Generic.Dictionary`2<UnityEngine.AnimationClip, System.Int32>::TryGetValue(this.clipNameHashCodeTable, clip, &v48 @ stack_-24_v3 (System.Int32));\n\tv84 = v51 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0044;\n\tv69 = UnityEngine.Object::get_name(clip);\n\tv117 = System.String::GetHashCode(v69);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.AnimationClip, System.Int32>::Add(this.clipNameHashCodeTable, clip, v117);\nL_0044:\n\tv116 = System.Collections.Generic.Dictionary`2<System.Int32, Spine.Animation>::TryGetValue(this.animationTable, v117, &v94 @ stack_-30_v2 (System.Object));\n\treturn v94;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe Animation GetAnimation(AnimationClip clip)
			{
				int hashCode = default(int);
				if (!clipNameHashCodeTable.TryGetValue(clip, out var _))
				{
					string name = clip.name;
					hashCode = name.GetHashCode();
					clipNameHashCodeTable.Add(clip, hashCode);
				}
				object value2;
				bool flag = animationTable.TryGetValue(hashCode, out *(Animation*)(&value2));
				return (Animation)value2;
			}

			[Token(Token = "0x60005AD")]
			[Address(RVA = "0x155EF60", Offset = "0x155EF60", Length = "0x1F0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tv36 = Spine.Unity.SkeletonMecanim+MecanimTranslator+AnimationClipEqualityComparer;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv68 = ClipInfos[];\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv101 = System.Collections.Generic.Dictionary`2<UnityEngine.AnimationClip, System.Int32>;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv107 = System.Collections.Generic.Dictionary`2<System.Int32, Spine.Animation>;\n\tv108 = \"il2cpp_codegen_initialize_runtime_metadata\"(v107, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv114 = Spine.Unity.SkeletonMecanim+MecanimTranslator+IntEqualityComparer;\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv124 = Il2CppMethodInfo;\n\tv125 = \"il2cpp_codegen_initialize_runtime_metadata\"(v124, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv130 = System.Collections.Generic.List`1<Spine.Animation>;\n\tv131 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv135 = Spine.MixBlend[];\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv140 = MixMode[];\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37C57]) = v56;\nL_003D:\n\tthis.autoReset = 0x101;\n\t// 70 NewArr v66 @ X0_v3 (MixMode[]), typeof(MixMode[]), 0\n\tthis.layerMixModes = v66;\n\t// 74 NewArr v72 @ X0_v5 (Spine.MixBlend[]), typeof(Spine.MixBlend[]), 0\n\tthis.layerBlendModes = v72;\n\tgoto L_0060;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v76, v71, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv85 = Spine.Unity.SkeletonMecanim+MecanimTranslator+IntEqualityComparer;\nL_0060:\n\tv99 = new System.Collections.Generic.Dictionary`2<System.Int32, Spine.Animation>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, Spine.Animation>::.ctor(v99, v86.Instance);\n\tthis.animationTable = v99;\n\tgoto L_0070;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v109, v104, v103, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv118 = Spine.Unity.SkeletonMecanim+MecanimTranslator+AnimationClipEqualityComparer;\nL_0070:\n\tv122 = new System.Collections.Generic.Dictionary`2<UnityEngine.AnimationClip, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.AnimationClip, System.Int32>::.ctor(v122, v119.Instance);\n\tthis.clipNameHashCodeTable = v122;\n\tv133 = new System.Collections.Generic.List`1<Spine.Animation>();\n\tSystem.Collections.Generic.List`1<Spine.Animation>::.ctor(v133);\n\tthis.previousAnimations = v133;\n\t// 126 NewArr v143 @ X0_v17 (ClipInfos[]), typeof(ClipInfos[]), 0\n\tthis.layerClipInfos = v143;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public MecanimTranslator()
			{
				//IL_0088: Expected I4, but got O
				//IL_00a6: Expected I4, but got O
				base._002Ector();
				autoReset = true;
				useCustomMixMode = true;
				MixMode[] array = new MixMode[0];
				layerMixModes = array;
				MixBlend[] array2 = new MixBlend[0];
				layerBlendModes = array2;
				Dictionary<int, Animation> dictionary = new Dictionary<int, Animation>((int)IntEqualityComparer.Instance);
				animationTable = dictionary;
				Dictionary<AnimationClip, int> dictionary2 = new Dictionary<AnimationClip, int>((int)AnimationClipEqualityComparer.Instance);
				clipNameHashCodeTable = dictionary2;
				List<Animation> list = new List<Animation>();
				previousAnimations = list;
				ClipInfos[] array3 = new ClipInfos[0];
				layerClipInfos = array3;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000341")]
		[FieldOffset(Offset = "0xE8")]
		protected MecanimTranslator translator;

		[Token(Token = "0x4000342")]
		[FieldOffset(Offset = "0xF0")]
		private bool wasUpdatedAfterInit = true;

		[CompilerGenerated]
		[Token(Token = "0x4000343")]
		[FieldOffset(Offset = "0xF8")]
		private UpdateBonesDelegate m__BeforeApply;

		[CompilerGenerated]
		[Token(Token = "0x4000344")]
		[FieldOffset(Offset = "0x100")]
		private UpdateBonesDelegate m__UpdateLocal;

		[CompilerGenerated]
		[Token(Token = "0x4000345")]
		[FieldOffset(Offset = "0x108")]
		private UpdateBonesDelegate m__UpdateWorld;

		[CompilerGenerated]
		[Token(Token = "0x4000346")]
		[FieldOffset(Offset = "0x110")]
		private UpdateBonesDelegate m__UpdateComplete;

		[Token(Token = "0x1700019F")]
		public MecanimTranslator Translator
		{
			[Token(Token = "0x6000581")]
			[Address(RVA = "0x155E984", Offset = "0x155E984", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.translator;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Translator;
			}
		}

		[Token(Token = "0x1400001D")]
		protected event UpdateBonesDelegate _BeforeApply
		{
			[CompilerGenerated]
			[Token(Token = "0x6000582")]
			[Address(RVA = "0x155E98C", Offset = "0x155E98C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C42]) = v38;\nL_0014:\n\tv40 = this + 0xF8;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 248;
				Delegate obj2 = this.m__BeforeApply;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000583")]
			[Address(RVA = "0x155EA28", Offset = "0x155EA28", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C43]) = v38;\nL_0014:\n\tv40 = this + 0xF8;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 248;
				Delegate obj2 = this.m__BeforeApply;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400001E")]
		protected event UpdateBonesDelegate _UpdateLocal
		{
			[CompilerGenerated]
			[Token(Token = "0x6000584")]
			[Address(RVA = "0x155EAC4", Offset = "0x155EAC4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C44]) = v38;\nL_0016:\n\tv42 = this + 0x100;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 256;
				Delegate obj2 = this.m__UpdateLocal;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000585")]
			[Address(RVA = "0x155EB64", Offset = "0x155EB64", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C45]) = v38;\nL_0016:\n\tv42 = this + 0x100;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 256;
				Delegate obj2 = this.m__UpdateLocal;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400001F")]
		protected event UpdateBonesDelegate _UpdateWorld
		{
			[CompilerGenerated]
			[Token(Token = "0x6000586")]
			[Address(RVA = "0x155EC04", Offset = "0x155EC04", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C46]) = v38;\nL_0016:\n\tv42 = this + 0x108;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 264;
				Delegate obj2 = this.m__UpdateWorld;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000587")]
			[Address(RVA = "0x155ECA4", Offset = "0x155ECA4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C47]) = v38;\nL_0016:\n\tv42 = this + 0x108;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 264;
				Delegate obj2 = this.m__UpdateWorld;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000020")]
		protected event UpdateBonesDelegate _UpdateComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x6000588")]
			[Address(RVA = "0x155ED44", Offset = "0x155ED44", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C48]) = v38;\nL_0016:\n\tv42 = this + 0x110;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 272;
				Delegate obj2 = this.m__UpdateComplete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000589")]
			[Address(RVA = "0x155EDE4", Offset = "0x155EDE4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C49]) = v38;\nL_0016:\n\tv42 = this + 0x110;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 272;
				Delegate obj2 = this.m__UpdateComplete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000021")]
		public event UpdateBonesDelegate BeforeApply
		{
			[Token(Token = "0x600058A")]
			[Address(RVA = "0x155EE84", Offset = "0x155EE84", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::add__BeforeApply(this, value);\n\treturn;\n")]
			add
			{
				_BeforeApply += value;
			}
			[Token(Token = "0x600058B")]
			[Address(RVA = "0x155EE88", Offset = "0x155EE88", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::remove__BeforeApply(this, value);\n\treturn;\n")]
			remove
			{
				_BeforeApply -= value;
			}
		}

		[Token(Token = "0x14000022")]
		public event UpdateBonesDelegate UpdateLocal
		{
			[Token(Token = "0x600058C")]
			[Address(RVA = "0x155EE8C", Offset = "0x155EE8C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::add__UpdateLocal(this, value);\n\treturn;\n")]
			add
			{
				_UpdateLocal += value;
			}
			[Token(Token = "0x600058D")]
			[Address(RVA = "0x155EE90", Offset = "0x155EE90", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::remove__UpdateLocal(this, value);\n\treturn;\n")]
			remove
			{
				_UpdateLocal -= value;
			}
		}

		[Token(Token = "0x14000023")]
		public event UpdateBonesDelegate UpdateWorld
		{
			[Token(Token = "0x600058E")]
			[Address(RVA = "0x155EE94", Offset = "0x155EE94", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::add__UpdateWorld(this, value);\n\treturn;\n")]
			add
			{
				_UpdateWorld += value;
			}
			[Token(Token = "0x600058F")]
			[Address(RVA = "0x155EE98", Offset = "0x155EE98", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::remove__UpdateWorld(this, value);\n\treturn;\n")]
			remove
			{
				_UpdateWorld -= value;
			}
		}

		[Token(Token = "0x14000024")]
		public event UpdateBonesDelegate UpdateComplete
		{
			[Token(Token = "0x6000590")]
			[Address(RVA = "0x155EE9C", Offset = "0x155EE9C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::add__UpdateComplete(this, value);\n\treturn;\n")]
			add
			{
				_UpdateComplete += value;
			}
			[Token(Token = "0x6000591")]
			[Address(RVA = "0x155EEA0", Offset = "0x155EEA0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonMecanim::remove__UpdateComplete(this, value);\n\treturn;\n")]
			remove
			{
				_UpdateComplete -= value;
			}
		}

		[Token(Token = "0x6000592")]
		[Address(RVA = "0x155EEA4", Offset = "0x155EEA4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, overwrite, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Spine.Unity.SkeletonMecanim+MecanimTranslator;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, overwrite, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37C4A]) = v37;\nL_0016:\n\tv39 = ~this.valid;\n\tif (v39) goto L_001D;\n\tv43 = overwrite == 0;\n\tif (v43) goto L_003D;\nL_001D:\n\tSpine.Unity.SkeletonRenderer::Initialize(this, overwrite);\n\tv55 = ~this.valid;\n\tif (v55) goto L_003D;\n\tv57 = this.translator;\n\tv77 = this.translator == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0030;\n\tv82 = new Spine.Unity.SkeletonMecanim+MecanimTranslator();\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::.ctor(v82);\n\tthis.translator = v82;\nL_0030:\n\tv88 = UnityEngine.Component::GetComponent(this);\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::Initialize(v57, v88, this.skeletonDataAsset);\n\tthis.wasUpdatedAfterInit = 0;\nL_003D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Initialize(bool overwrite)
		{
			if (valid && !overwrite)
			{
				return;
			}
			base.Initialize(overwrite);
			if (valid)
			{
				MecanimTranslator mecanimTranslator = Translator;
				if (Translator == null)
				{
					mecanimTranslator = (translator = new MecanimTranslator());
				}
				Animator component = GetComponent<Animator>();
				mecanimTranslator.Initialize(component, skeletonDataAsset);
				wasUpdatedAfterInit = false;
			}
		}

		[Token(Token = "0x6000593")]
		[Address(RVA = "0x155F3A4", Offset = "0x155F3A4", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.valid;\n\tif (v2) goto L_0014;\n\tthis.wasUpdatedAfterInit = 1;\n\tv15 = this.updateMode < 2;\n\tif (v15) goto L_0014;\n\tSpine.Unity.SkeletonMecanim::ApplyAnimation(this);\n\treturn;\nL_0014:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			if (valid)
			{
				wasUpdatedAfterInit = true;
				if (UpdateMode >= UpdateMode.EverythingExceptMesh)
				{
					ApplyAnimation();
				}
			}
		}

		[Token(Token = "0x6000594")]
		[Address(RVA = "0x155F3C8", Offset = "0x155F3C8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this._BeforeApply == 0;\n\tif (v7) goto L_0010;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._BeforeApply, this);\nL_0010:\n\tSpine.Unity.SkeletonMecanim+MecanimTranslator::Apply(this.translator, this.skeleton);\n\tv55 = this._UpdateLocal == 0;\n\tif (v55) goto L_001D;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._UpdateLocal, this);\nL_001D:\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\n\tv86 = this._UpdateWorld == 0;\n\tif (v86) goto L_002B;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._UpdateWorld, this);\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\nL_002B:\n\t;\n\tv79 = this._UpdateComplete == 0;\n\tif (v79) goto L_0039;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._UpdateComplete, this);\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ApplyAnimation()
		{
			if (this._BeforeApply != null)
			{
				this._BeforeApply(this);
			}
			Translator.Apply(skeleton);
			if (this._UpdateLocal != null)
			{
				this._UpdateLocal(this);
			}
			skeleton.UpdateWorldTransform();
			if (this._UpdateWorld != null)
			{
				this._UpdateWorld(this);
				skeleton.UpdateWorldTransform();
			}
			if (this._UpdateComplete != null)
			{
				this._UpdateComplete(this);
			}
		}

		[Token(Token = "0x6000595")]
		[Address(RVA = "0x1560348", Offset = "0x1560348", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = ~this.wasUpdatedAfterInit;\n\tif (v7) goto L_000E;\nL_000B:\n\tSpine.Unity.SkeletonRenderer::LateUpdate(this);\n\treturn;\nL_000E:\n\tv41 = ~this.valid;\n\tif (v41) goto L_000B;\n\tthis.wasUpdatedAfterInit = 1;\n\tv10 = this.updateMode < 2;\n\tif (v10) goto L_000B;\n\tSpine.Unity.SkeletonMecanim::ApplyAnimation(this);\n\tgoto L_000B;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LateUpdate()
		{
			if (!wasUpdatedAfterInit && valid)
			{
				wasUpdatedAfterInit = true;
				if (UpdateMode >= UpdateMode.EverythingExceptMesh)
				{
					ApplyAnimation();
				}
			}
			base.LateUpdate();
		}

		[Token(Token = "0x6000596")]
		[Address(RVA = "0x156038C", Offset = "0x156038C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.SkeletonRenderer;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C4B]) = v37;\nL_0014:\n\tthis.wasUpdatedAfterInit = 1;\n\tgoto L_0021;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0021:\n\tSpine.Unity.SkeletonRenderer::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonMecanim()
		{
		}
	}
}
