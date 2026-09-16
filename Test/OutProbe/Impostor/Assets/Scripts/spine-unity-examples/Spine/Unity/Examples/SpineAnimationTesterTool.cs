using System;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200000F")]
	public class SpineAnimationTesterTool : MonoBehaviour, IHasSkeletonDataAsset, IHasSkeletonComponent
	{
		[Serializable]
		[Token(Token = "0x2000010")]
		public struct AnimationControl
		{
			[SpineAnimation(null, null, true, false)]
			[Token(Token = "0x4000041")]
			[FieldOffset(Offset = "0x0")]
			public string animationName;

			[Token(Token = "0x4000042")]
			[FieldOffset(Offset = "0x8")]
			public bool loop;

			[Token(Token = "0x4000043")]
			[FieldOffset(Offset = "0xC")]
			public KeyCode key;

			[Space]
			[Token(Token = "0x4000044")]
			[FieldOffset(Offset = "0x10")]
			public bool useCustomMixDuration;

			[Token(Token = "0x4000045")]
			[FieldOffset(Offset = "0x14")]
			public float mixDuration;
		}

		[Serializable]
		[Token(Token = "0x2000011")]
		public class ControlledTrack
		{
			[Token(Token = "0x4000046")]
			[FieldOffset(Offset = "0x10")]
			public List<AnimationControl> controls;

			[Token(Token = "0x6000035")]
			[Address(RVA = "0x150A9F0", Offset = "0x150A9F0", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A379EF]) = v42;\nL_001A:\n\tv44 = new System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::.ctor(v44);\n\tthis.controls = v44;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ControlledTrack()
			{
				List<AnimationControl> list = new List<AnimationControl>();
				controls = list;
			}
		}

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x28")]
		public bool useOverrideMixDuration;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x2C")]
		public float overrideMixDuration;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x30")]
		public bool useOverrideAttachmentThreshold;

		[Range(0f, 1f)]
		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x34")]
		public float attachmentThreshold;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x38")]
		public bool useOverrideDrawOrderThreshold;

		[Range(0f, 1f)]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x3C")]
		public float drawOrderThreshold;

		[Space]
		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x40")]
		public List<ControlledTrack> trackControls;

		[Header("UI")]
		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x48")]
		public Text boundAnimationsText;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x50")]
		public Text skeletonNameText;

		[Token(Token = "0x17000006")]
		public SkeletonDataAsset SkeletonDataAsset
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x150A1BC", Offset = "0x150A1BC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.skeletonAnimation;\n\treturn v2.skeletonDataAsset;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
				return skeletonAnimation.skeletonDataAsset;
			}
		}

		[Token(Token = "0x17000007")]
		public ISkeletonComponent SkeletonComponent
		{
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x150A1D8", Offset = "0x150A1D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonAnimation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonAnimation;
			}
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x150A1E0", Offset = "0x150A1E0", Length = "0x490")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0052;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv80 = System.Int32;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv122 = UnityEngine.KeyCode;\n\tv123 = \"il2cpp_codegen_initialize_runtime_metadata\"(v122, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv134 = Il2CppMethodInfo;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv140 = Il2CppMethodInfo;\n\tv141 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv251 = Il2CppMethodInfo;\n\tv252 = \"il2cpp_codegen_initialize_runtime_metadata\"(v251, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv407 = UnityEngine.Object;\n\tv408 = \"il2cpp_codegen_initialize_runtime_metadata\"(v407, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv413 = System.Text.StringBuilder;\n\tv414 = \"il2cpp_codegen_initialize_runtime_metadata\"(v413, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv422 = \"---- Track {0} ---- \\n\";\n\tv423 = \"il2cpp_codegen_initialize_runtime_metadata\"(v422, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv428 = \"[{0}]  {1}\\n\";\n\tv429 = \"il2cpp_codegen_initialize_runtime_metadata\"(v428, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv441 = \"SetEmptyAnimation\";\n\tv442 = \"il2cpp_codegen_initialize_runtime_metadata\"(v441, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv459 = \"_SkeletonData\";\n\tv460 = \"il2cpp_codegen_initialize_runtime_metadata\"(v459, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv465 = \"\";\n\tv466 = \"il2cpp_codegen_initialize_runtime_metadata\"(v465, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv481 = \"Animation Controls:\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v481, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A379EC]) = v54;\nL_0052:\n\tgoto L_0057;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v37, v38, v39, v40, v41, v42, v57, v44, v45, v46, v47, v48, v49, v50);\nL_0057:\n\tv73 = UnityEngine.Object::op_Inequality(this.skeletonNameText, 0);\n\tv78 = v73 == 0;\n\tif (v78) goto L_009F;\n\tgoto L_0066;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v82, v71, v72, v38, v39, v40, v41, v42, v57, v44, v45, v46, v47, v48, v49, v50);\nL_0066:\n\tv103 = UnityEngine.Object::op_Inequality(this.skeletonAnimation, 0);\n\tv107 = v103 == 0;\n\tif (v107) goto L_009F;\n\tv111 = this.skeletonAnimation;\n\tv143 = this.skeletonAnimation == 0;\n\tif (v143) goto L_0165;\n\tgoto L_0078;\n\tv409 = \"il2cpp_codegen_runtime_class_init\"(v253, v99, v95, v38, v39, v40, v41, v42, v57, v44, v45, v46, v47, v48, v49, v50);\nL_0078:\n\tv104 = UnityEngine.Object::op_Inequality(v111.skeletonDataAsset, 0);\n\tv108 = v104 == 0;\n\tif (v108) goto L_009F;\n\tv349 = this.skeletonAnimation;\n\tv339 = this.skeletonAnimation == 0;\n\tif (v339) goto L_0165;\n\tv340 = v349.skeletonDataAsset == 0;\n\tif (v340) goto L_0165;\n\tv330 = UnityEngine.Object::get_name(v349.skeletonDataAsset);\n\tv341 = v330 == 0;\n\tif (v341) goto L_0165;\n\tv331 = System.String::Replace(v330, \"_SkeletonData\", \"\");\n\tv106 = this.skeletonNameText == 0;\n\tif (v106) goto L_0165;\n\tv102 = UnityEngine.UI.Text::set_text(this.skeletonNameText, v331);\nL_009F:\n\tgoto L_00A4;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v115, v97, v93, v88, v39, v40, v41, v42, v57, v44, v45, v46, v47, v48, v49, v50);\nL_00A4:\n\tv132 = UnityEngine.Object::op_Inequality(this.boundAnimationsText, 0);\n\tv138 = v132 == 0;\n\tif (v138) goto L_0164;\n\tv147 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v147);\n\tv342 = v147 == 0;\n\tif (v342) goto L_0165;\n\tv332 = System.Text.StringBuilder::AppendLine(v147, \"Animation Controls:\");\n\tv455 = this.trackControls;\n\tv343 = this.trackControls == 0;\n\tif (v343) goto L_0165;\nL_00CF:\n\tv166 = v235 >= v455._size;\n\tif (v166) goto L_014E;\n\tv461 = v235 == 0;\n\tif (v461) goto L_00DB;\n\tv471 = System.Text.StringBuilder::AppendLine(v147);\nL_00DB:\n\t// 219 Box v478 @ X0_v23 (System.Object), typeof(System.Int32), &v235 @ X21_v6 (System.Int32)\n\tv485 = System.Text.StringBuilder::AppendFormat(v147, \"---- Track {0} ---- \\n\", v478);\n\tv344 = this.trackControls == 0;\n\tif (v344) goto L_0165;\n\tv334 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+ControlledTrack>::get_Item(this.trackControls, v235);\n\tv345 = v334 == 0;\n\tif (v345) goto L_0165;\n\tv346 = v334.controls == 0;\n\tif (v346) goto L_0165;\n\tv493 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::GetEnumerator(v334.controls);\nL_00FE:\n\tv522 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::MoveNext(&v492 @ stack_-C0_v3 (System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>));\n\tv524 = v522 == 0;\n\tif (v524) goto L_0126;\n\tv528 = System.String::IsNullOrEmpty(v277);\n\tv534 = System.Enum::ToString(&v492 @ stack_-C0_v3 (System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>));\n\tv501 = v528 == 0;\n\tv498 = ~v501;\n\tv497 = ~v498;\n\tif (v497) goto L_FFFFFFFF;\n\tgoto L_0120;\nL_0120:\n\tv515 = System.Text.StringBuilder::AppendFormat(v147, \"[{0}]  {1}\\n\", v534, v221);\n\tgoto L_00FE;\nL_0126:\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::Dispose(&v492 @ stack_-C0_v3 (System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>));\nL_0127:\n\t;\n\tv235 = v235 + 1;\n\tv455 = this.trackControls;\n\tv536 = this.trackControls == 0;\n\tv347 = ~v536;\n\tif (v347) goto L_00CF;\n\tgoto L_0165;\n\tgoto L_0131;\n\tgoto L_0131;\n\tgoto L_0131;\nL_0131:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0166;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1945B10]);\n\tX0 = &stack[40];\n\tX1 = *([X8]);\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::Dispose(X0, X1);\n\tif (TEMP) goto L_0127;\n\tX0 = X22;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014E:\n\tv337 = System.Text.StringBuilder::ToString(v147);\n\tv231 = this.boundAnimationsText == 0;\n\tif (v231) goto L_0165;\n\tv229 = UnityEngine.UI.Text::set_text(this.boundAnimationsText, v337);\nL_0164:\n\treturn;\nL_0165:\n\tv360 = new System.NullReferenceException();\nL_0166:\n\t;\n\tgoto L_016E;\n\tX19 = X0;\nL_016E:\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::Dis\n// ... truncated")]
		private unsafe void OnValidate()
		{
			List<AnimationControl>.Enumerator enumerator;
			if (skeletonNameText != null && this.skeletonAnimation != null)
			{
				SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
				bool flag = (object)this.skeletonAnimation == null;
				enumerator = default(List<AnimationControl>.Enumerator);
				if (!flag)
				{
					if (!(skeletonAnimation.skeletonDataAsset != null))
					{
						goto IL_01bd;
					}
					SkeletonAnimation skeletonAnimation2 = this.skeletonAnimation;
					bool flag2 = (object)this.skeletonAnimation == null;
					enumerator = default(List<AnimationControl>.Enumerator);
					if (!flag2)
					{
						bool flag3 = (object)skeletonAnimation2.skeletonDataAsset == null;
						enumerator = default(List<AnimationControl>.Enumerator);
						if (!flag3)
						{
							string text = skeletonAnimation2.skeletonDataAsset.name;
							bool flag4 = text == null;
							enumerator = default(List<AnimationControl>.Enumerator);
							if (!flag4)
							{
								string text2 = text.Replace("_SkeletonData", "");
								bool flag5 = (object)skeletonNameText == null;
								enumerator = default(List<AnimationControl>.Enumerator);
								if (!flag5)
								{
									skeletonNameText.text = text2;
									string text3 = null;
									goto IL_01bd;
								}
							}
						}
					}
				}
				goto IL_047a;
			}
			goto IL_01bd;
			IL_01bd:
			if (!(boundAnimationsText != null))
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag6 = stringBuilder == null;
			enumerator = default(List<AnimationControl>.Enumerator);
			if (!flag6)
			{
				StringBuilder stringBuilder2 = stringBuilder.AppendLine("Animation Controls:");
				List<ControlledTrack> list = trackControls;
				bool flag7 = trackControls == null;
				enumerator = default(List<AnimationControl>.Enumerator);
				if (!flag7)
				{
					enumerator = default(List<AnimationControl>.Enumerator);
					int num = 0;
					string text4 = default(string);
					List<AnimationControl>.Enumerator enumerator3 = default(List<AnimationControl>.Enumerator);
					string text5 = default(string);
					while (true)
					{
						if (num < list.Count)
						{
							if (num != 0)
							{
								StringBuilder stringBuilder3 = stringBuilder.AppendLine();
							}
							object arg = num;
							StringBuilder stringBuilder4 = stringBuilder.AppendFormat("---- Track {0} ---- \n", arg);
							if (trackControls == null)
							{
								break;
							}
							ControlledTrack controlledTrack = trackControls[num];
							if (controlledTrack == null || controlledTrack.controls == null)
							{
								break;
							}
							List<AnimationControl>.Enumerator enumerator2 = controlledTrack.controls.GetEnumerator();
							text4 = text4;
							string text3 = null;
							while (enumerator3.MoveNext())
							{
								bool flag8 = string.IsNullOrEmpty(text4);
								string arg2 = ((Enum)enumerator3).ToString();
								text3 = ((!flag8) ? text4 : "SetEmptyAnimation");
								StringBuilder stringBuilder5 = stringBuilder.AppendFormat("[{0}]  {1}\n", arg2, text3);
								text4 = text5;
							}
							enumerator3.Dispose();
							num++;
							list = trackControls;
							bool flag9 = trackControls == null;
							bool flag10 = !flag9;
							enumerator = enumerator3;
							if (!flag10)
							{
								enumerator = enumerator3;
								break;
							}
							continue;
						}
						string text6 = stringBuilder.ToString();
						if ((object)boundAnimationsText == null)
						{
							break;
						}
						boundAnimationsText.text = text6;
						return;
					}
				}
			}
			goto IL_047a;
			IL_047a:
			NullReferenceException ex = new NullReferenceException();
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((List<AnimationControl>.Enumerator*)ex2)->Dispose();
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x150A670", Offset = "0x150A670", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.useOverrideMixDuration;\n\tif (v4) goto L_0012;\n\tv5 = this.skeletonAnimation;\n\tv15 = v5.state;\n\tv13 = v15.data;\n\tv13.defaultMix = this.overrideMixDuration;\nL_0012:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (useOverrideMixDuration)
			{
				SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
				AnimationState state = skeletonAnimation.state;
				AnimationStateData data = state.Data;
				data.DefaultMix = overrideMixDuration;
			}
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x150A6A8", Offset = "0x150A6A8", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv164 = Il2CppMethodInfo;\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv222 = Il2CppMethodInfo;\n\tv223 = \"il2cpp_codegen_initialize_runtime_metadata\"(v222, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv279 = Il2CppMethodInfo;\n\tv280 = \"il2cpp_codegen_initialize_runtime_metadata\"(v279, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv296 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v296, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A379ED]) = v52;\nL_002C:\n\tv57 = this.skeletonAnimation;\n\tv235 = this.trackControls;\n\tv139 = v57.state;\nL_0046:\n\tv66 = v160 >= v235._size;\n\tif (v66) goto L_00D6;\n\tv149 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+ControlledTrack>::get_Item(v235, v160);\n\tv340 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::GetEnumerator(v149.controls);\nL_005B:\n\tv355 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::MoveNext(&v131 @ stack_-B8_v5 (System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>));\n\tv357 = v355 == 0;\n\tif (v357) goto L_009D;\n\tv350 = UnityEngine.Input::GetKeyDown(v360);\n\tv352 = v350 == 0;\n\tif (v352) goto L_005B;\n\tv381 = System.String::IsNullOrEmpty(v341);\n\tv383 = v381 == 0;\n\tif (v383) goto L_007A;\n\tv384 = v342 & 1;\n\tv385 = v384 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_0084;\n\tv212 = v57.state == 0;\n\tif (v212) goto L_00A6;\n\tv217 = v139.data;\n\tv214 = v139.data == 0;\n\tif (v214) goto L_00AA;\n\tv393 = v217.defaultMix;\n\tgoto L_0089;\nL_007A:\n\tv271 = v57.state == 0;\n\tif (v271) goto L_00A4;\n\tv387 = v358 & 1;\n\tv372 = Spine.AnimationState::SetAnimation(v57.state, v160, v341, v387);\n\tgoto L_008B;\nL_0084:\n\tv213 = v57.state == 0;\n\tif (v213) goto L_00A8;\nL_0089:\n\tv372 = Spine.AnimationState::SetEmptyAnimation(v57.state, v160, v393);\nL_008B:\n\tv375 = v372 == 0;\n\tif (v375) goto L_009D;\n\tv403 = v342 & 1;\n\tv404 = v403 == 0;\n\tif (v404) goto L_0092;\n\tv372.mixDuration = v361;\nL_0092:\n\tv406 = ~this.useOverrideAttachmentThreshold;\n\tif (v406) goto L_0097;\n\tv372.attachmentThreshold = this.attachmentThreshold;\nL_0097:\n\tv374 = ~this.useOverrideDrawOrderThreshold;\n\tif (v374) goto L_009D;\n\tv372.drawOrderThreshold = this.drawOrderThreshold;\nL_009D:\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::Dispose(&v131 @ stack_-B8_v5 (System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>));\nL_009E:\n\tv235 = this.trackControls;\n\tv160 = v160 + 1;\n\tv379 = this.trackControls == 0;\n\tv155 = ~v379;\n\tif (v155) goto L_0046;\n\tgoto L_00D7;\nL_00A4:\n\tv269 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_00A6:\n\tv207 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_00A8:\n\tv207 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_00AA:\n\tv207 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_00B4;\n\tgoto L_00B4;\n\tgoto L_00B4;\n\tgoto L_00B4;\n\tgoto L_00B4;\n\tgoto L_00B4;\n\tgoto L_00B4;\n\tgoto L_00B4;\nL_00B4:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_FFFFFFFF;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = *([X23]);\n\tX0 = &stack[30];\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::Dispose(X0, X1);\n\tif (TEMP) goto L_009E;\n\tX0 = X22;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00D6:\n\treturn;\nL_00D7:\n\tv207 = new System.NullReferenceException();\n\tgoto L_00DE;\nL_00DE:\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>::Dispose(&v120 @ stack_-90_v5 (System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>+Enumerator<Spine.Unity.Examples.SpineAnimationTesterTool+AnimationControl>));\n\tv293 = v254 == 0;\n\tv294 = ~v293;\n\tif (v294) goto L_00E5;\n\tv334 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+ControlledTrack>::get_Item(v272, *([v264 @ X23_v1 (Il2CppMethodInfo)]));\nL_00E5:\n\tv337 = new System.OutOfMemoryException();\n\tv328 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+ControlledTrack>::get_Item(v337, *([v264 @ X23_v1 (Il2CppMethodInfo)]));\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			List<ControlledTrack> list = trackControls;
			AnimationState state = skeletonAnimation.state;
			List<AnimationControl>.Enumerator enumerator = default(List<AnimationControl>.Enumerator);
			int num = 0;
			List<AnimationControl>.Enumerator enumerator3 = default(List<AnimationControl>.Enumerator);
			KeyCode key = default(KeyCode);
			string text = default(string);
			object obj = default(object);
			nint num2 = default(nint);
			float num3 = default(float);
			object obj2 = default(object);
			while (num < list.Count)
			{
				ControlledTrack controlledTrack = list[num];
				List<AnimationControl>.Enumerator enumerator2 = controlledTrack.controls.GetEnumerator();
				while (true)
				{
					if (!enumerator3.MoveNext())
					{
						goto IL_0373;
					}
					if (!Input.GetKeyDown(key))
					{
						continue;
					}
					float mixDuration;
					NullReferenceException ex;
					if (string.IsNullOrEmpty(text))
					{
						if ((int)((nint)obj & 1) == 0)
						{
							if (skeletonAnimation.state != null)
							{
								AnimationStateData data = state.Data;
								if (state.Data != null)
								{
									mixDuration = data.DefaultMix;
									goto IL_01d2;
								}
								ex = new NullReferenceException();
								enumerator = enumerator3;
								num2 = 0;
							}
							else
							{
								ex = new NullReferenceException();
								enumerator = enumerator3;
								num2 = 0;
							}
						}
						else
						{
							bool flag = skeletonAnimation.state == null;
							mixDuration = num3;
							if (!flag)
							{
								goto IL_01d2;
							}
							ex = new NullReferenceException();
							enumerator = enumerator3;
							num2 = 0;
						}
						goto IL_02f8;
					}
					TrackEntry trackEntry;
					if (skeletonAnimation.state != null)
					{
						bool loop = (byte)((nint)obj2 & 1) != 0;
						trackEntry = skeletonAnimation.state.SetAnimation(num, text, loop);
						goto IL_01f2;
					}
					NullReferenceException ex2 = new NullReferenceException();
					string text2 = text;
					enumerator = enumerator3;
					num2 = 0;
					NullReferenceException ex3 = ex2;
					goto IL_0430;
					IL_01f2:
					if (trackEntry != null)
					{
						if ((int)((nint)obj & 1) != 0)
						{
							trackEntry.MixDuration = num3;
						}
						if (useOverrideAttachmentThreshold)
						{
							trackEntry.AttachmentThreshold = attachmentThreshold;
						}
						if (useOverrideDrawOrderThreshold)
						{
							trackEntry.DrawOrderThreshold = drawOrderThreshold;
						}
					}
					goto IL_0373;
					IL_0373:
					enumerator3.Dispose();
					list = trackControls;
					num++;
					bool flag2 = trackControls == null;
					bool flag3 = !flag2;
					enumerator = enumerator3;
					if (flag3)
					{
						break;
					}
					enumerator = default(List<AnimationControl>.Enumerator);
					ex = new NullReferenceException();
					goto IL_02f8;
					IL_02f8:
					text2 = null;
					ex3 = ex;
					goto IL_0430;
					IL_01d2:
					trackEntry = skeletonAnimation.state.SetEmptyAnimation(num, mixDuration);
					goto IL_01f2;
					IL_0430:
					enumerator.Dispose();
					if (text2 == null)
					{
						ControlledTrack controlledTrack2 = ((List<ControlledTrack>)(object)ex3)[(int)num2];
					}
					OutOfMemoryException ex4 = new OutOfMemoryException();
					ControlledTrack controlledTrack3 = ((List<ControlledTrack>)(object)ex4)[(int)num2];
					return;
				}
			}
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x150A954", Offset = "0x150A954", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv50 = System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+ControlledTrack>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A379EE]) = v42;\nL_001D:\n\tthis.overrideMixDuration = 0.2f;\n\tthis.useOverrideAttachmentThreshold = 1;\n\tthis.attachmentThreshold = 0.5f;\n\tthis.drawOrderThreshold = 0.5f;\n\tv48 = new System.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+ControlledTrack>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SpineAnimationTesterTool+ControlledTrack>::.ctor(v48);\n\tthis.trackControls = v48;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineAnimationTesterTool()
		{
			overrideMixDuration = 0.2f;
			useOverrideAttachmentThreshold = true;
			attachmentThreshold = 0.5f;
			drawOrderThreshold = 0.5f;
			List<ControlledTrack> list = new List<ControlledTrack>();
			trackControls = list;
		}
	}
}
