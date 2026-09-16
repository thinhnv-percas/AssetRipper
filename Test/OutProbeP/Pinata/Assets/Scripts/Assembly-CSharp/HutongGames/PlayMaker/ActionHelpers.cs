using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker.AnimationEnums;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200006E")]
	public static class ActionHelpers
	{
		[Token(Token = "0x40002BD")]
		public static RaycastHit mousePickInfo;

		[Token(Token = "0x40002BE")]
		private static float mousePickRaycastTime;

		[Token(Token = "0x40002BF")]
		private static float mousePickDistanceUsed;

		[Token(Token = "0x40002C0")]
		private static int mousePickLayerMaskUsed;

		[Token(Token = "0x17000055")]
		public static Texture2D WhiteTexture
		{
			[Token(Token = "0x6000303")]
			[Address(RVA = "0xA0EA80", Offset = "0xA0EA80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Texture2D::get_whiteTexture();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Texture2D.whiteTexture;
			}
		}

		[Token(Token = "0x6000304")]
		[Address(RVA = "0xA0EA88", Offset = "0xA0EA88", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv50 = *([1EFE270]);\n\tv51 = *([v50 @ X8_v9]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, c1, v0, v2, v3, c2, v4, v6, v7);\n\tv62 = 0 | 1;\n\t*([2021CEA]) = v62;\nL_0029:\n\tv63 = blendMode == 0;\n\tif (v63) goto L_FFFFFFFF;\n\tv68 = blendMode == 2;\n\tif (v68) goto L_0053;\n\tv83 = blendMode != 1;\n\tif (v83) goto L_00C1;\n\tv143 = UnityEngine.Color::op_Multiply(c1, c2);\n\tv190 = v143.g;\n\tv188 = v143.b;\n\tv186 = v143.a;\n\tgoto L_FFFFFFFF;\n\tgoto L_00AB;\nL_0053:\n\tv85 = UnityEngine.Color::get_white();\n\tv227 = UnityEngine.Color::get_white();\n\tv258 = UnityEngine.Color::op_Subtraction(v227, c1);\n\tv346 = UnityEngine.Color::get_white();\n\tv355 = UnityEngine.Color::op_Subtraction(v346, c2);\n\tv368 = UnityEngine.Color::op_Multiply(v258, v355);\n\tv143 = UnityEngine.Color::op_Subtraction(v85, v368);\n\tv190 = v143.g;\n\tv188 = v143.b;\n\tv186 = v143.a;\nL_00AB:\n\t// 171 MakeStruct v201 @ AGGA0EC04_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v173 @ V15_v2 (UnityEngine.Color), v175 @ V14_v2 (System.Single), v177 @ V13_v2 (System.Single), v179 @ V7_v2 (System.Single)\n\treturnVal1 = UnityEngine.Color::Lerp(c1, v201, c2.a);\n\treturn returnVal1;\nL_00C1:\n\tv218 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v218);\n\tthrow v218;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color BlendColor(ColorBlendMode blendMode, Color c1, Color c2)
		{
			Color color5;
			float g2;
			float b2;
			float a2;
			if (blendMode != ColorBlendMode.Normal)
			{
				Color color4;
				float g;
				float b;
				float a;
				switch (blendMode)
				{
				case ColorBlendMode.Multiply:
					color4 = c1 * c2;
					g = color4.g;
					b = color4.b;
					a = color4.a;
					break;
				case ColorBlendMode.Screen:
				{
					Color white = Color.white;
					Color white2 = Color.white;
					Color color = white2 - c1;
					Color white3 = Color.white;
					Color color2 = white3 - c2;
					Color color3 = color * color2;
					color4 = white - color3;
					g = color4.g;
					b = color4.b;
					a = color4.a;
					break;
				}
				default:
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				}
				color5 = color4;
				g2 = g;
				b2 = b;
				a2 = a;
			}
			else
			{
				color5 = c2;
				g2 = c2.g;
				b2 = c2.b;
				a2 = c2.a;
			}
			Color b3 = default(Color);
			b3.r = color5.r;
			b3.g = g2;
			b3.b = b2;
			b3.a = a2;
			return Color.Lerp(c1, b3, c2.a);
		}

		[Token(Token = "0x6000305")]
		[Address(RVA = "0xA0EC5C", Offset = "0xA0EC5C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F04CE0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CEB]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Equality(go, 0);\n\tv57 = v55 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0052;\n\tv84 = UnityEngine.GameObject::GetComponent(go);\n\tgoto L_003D;\n\tv114 = *([v74 @ X8_v9+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_003D;\n\tv121 = v74;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v121, v83, v54, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tv68 = UnityEngine.Object::op_Inequality(v84, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0052;\n\treturnVal3 = UnityEngine.Renderer::get_isVisible(v84);\n\treturn returnVal3;\nL_0052:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsVisible(GameObject go)
		{
			if (!(go == null))
			{
				Renderer component = go.GetComponent<Renderer>();
				if (component != null)
				{
					return component.isVisible;
				}
			}
			return false;
		}

		[Token(Token = "0x6000306")]
		[Address(RVA = "0xA0ED40", Offset = "0xA0ED40", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(action.fsm, ownerDefault);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static GameObject GetOwnerDefault(FsmStateAction action, FsmOwnerDefault ownerDefault)
		{
			return action.Fsm.GetOwnerDefaultTarget(ownerDefault);
		}

		[Token(Token = "0x6000307")]
		[Address(RVA = "0xA0ED64", Offset = "0xA0ED64", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EF0F88]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsmName, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021CEC]) = v45;\nL_0019:\n\tv48 = System.String::IsNullOrEmpty(fsmName);\n\tv50 = v48 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_007A;\n\tv109 = UnityEngine.GameObject::GetComponents(go);\n\tv177 = v109.Length;\n\tv192 = v109.Length < 1;\n\tif (v192) goto L_0062;\nL_0036:\n\tv302 = v118 < v177;\n\tv136 = ~v302;\n\tif (v136) goto L_0088;\n\tv315 = PlayMakerFSM::get_FsmName(v109[v118 @ X23_v9 (System.Int32)]);\n\tv235 = System.String::op_Equality(v315, fsmName);\n\tv318 = v235 == 0;\n\tv237 = ~v318;\n\tif (v237) goto L_0085;\n\tv177 = v109.Length;\n\tv118 = v118 + 1;\n\tv252 = v118 < v109.Length;\n\tif (v252) goto L_0036;\nL_0062:\n\tv270 = System.String::Concat(\"Could not find FSM: \", fsmName);\n\tgoto L_0073;\n\tv308 = *([v101 @ X8_v18+E0]);\n\tv309 = v308 == 0;\n\tv310 = ~v309;\n\tif (v310) goto L_0073;\n\tv316 = v101;\n\tv312 = \"il2cpp_codegen_runtime_class_init\"(v316, v268, v57, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0073:\n\tUnityEngine.Debug::LogWarning(v270);\nL_007A:\n\tv153 = UnityEngine.GameObject::GetComponent(go);\nL_0085:\n\treturn v220;\n\tv148 = new System.NullReferenceException();\nL_0088:\n\tv179 = new System.IndexOutOfRangeException();\n\tthrow v179;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PlayMakerFSM GetGameObjectFsm(GameObject go, string fsmName)
		{
			if (string.IsNullOrEmpty(fsmName))
			{
				goto IL_010e;
			}
			PlayMakerFSM[] components = go.GetComponents<PlayMakerFSM>();
			int num = components.Length;
			if (components.Length < 1)
			{
				goto IL_00e9;
			}
			int num2 = 0;
			PlayMakerFSM result;
			while (true)
			{
				if (num2 < num)
				{
					string fsmName2 = components[num2].FsmName;
					bool flag = fsmName2 == fsmName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = components[num2];
					if (flag3)
					{
						break;
					}
					num = components.Length;
					num2++;
					if (num2 < components.Length)
					{
						continue;
					}
					goto IL_00e9;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_016b;
			IL_00e9:
			string message = "Could not find FSM: " + fsmName;
			Debug.LogWarning(message);
			goto IL_010e;
			IL_016b:
			return result;
			IL_010e:
			PlayMakerFSM component = go.GetComponent<PlayMakerFSM>();
			result = component;
			goto IL_016b;
		}

		[Token(Token = "0x6000308")]
		[Address(RVA = "0xA0EEC0", Offset = "0xA0EEC0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv171 = weights.Length;\n\tv28 = weights.Length < 1;\n\tif (v28) goto L_FFFFFFFF;\nL_001A:\n\tv174 = v67 < v171;\n\tv119 = ~v174;\n\tif (v119) goto L_0094;\n\tv148 = HutongGames.PlayMaker.FsmFloat::get_Value(weights[v67 @ X20_v12 (System.Int32)]);\n\tv171 = weights.Length;\n\tv67 = v67 + 1;\n\tv179 = v179 + v148;\n\tv154 = v67 < weights.Length;\n\tif (v154) goto L_001A;\n\tgoto L_003F;\nL_003F:\n\tv194 = UnityEngine.Random::Range(0f, v179);\n\tv126 = weights.Length;\n\tv258 = weights.Length < 1;\n\tif (v258) goto L_FFFFFFFF;\nL_004F:\n\tv303 = v307 < v126;\n\tv120 = ~v303;\n\tif (v120) goto L_0094;\n\tv60 = v307 << 3;\n\tv316 = weights + v60;\n\tv38 = v316 + 0x20;\n\tv44 = HutongGames.PlayMaker.FsmFloat::get_Value(*([v38 @ X21_v7]));\n\tv313 = v64 < v44;\n\tif (v313) goto L_0093;\n\tv318 = v307 < weights.Length;\n\tv121 = ~v318;\n\tif (v121) goto L_0094;\n\tv262 = HutongGames.PlayMaker.FsmFloat::get_Value(*([v38 @ X21_v7]));\n\tv126 = weights.Length;\n\tv307 = v307 + 1;\n\tv64 = v64 - v262;\n\tv272 = v307 < weights.Length;\n\tif (v272) goto L_004F;\nL_0093:\n\treturn v307;\nL_0094:\n\tv245 = new System.IndexOutOfRangeException();\n\tthrow v245;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetRandomWeightedIndex(FsmFloat[] weights)
		{
			//IL_00e0: Expected O, but got I
			//IL_00ef: Expected O, but got I
			int num = weights.Length;
			float num2;
			if (weights.Length >= 1)
			{
				num2 = 0f;
				int num3 = 0;
				while (num3 < num)
				{
					float value = weights[num3].Value;
					num = weights.Length;
					num3++;
					num2 += value;
					if (num3 < weights.Length)
					{
						continue;
					}
					goto IL_01dd;
				}
				goto IL_01a8;
			}
			num2 = 0f;
			goto IL_01dd;
			IL_0218:
			int num4;
			return num4;
			IL_01dd:
			float num5 = UnityEngine.Random.Range(0f, num2);
			int num6 = weights.Length;
			if (weights.Length < 1)
			{
				goto IL_019a;
			}
			float num7 = num5;
			num4 = 0;
			while (num4 < num6)
			{
				int num8 = num4 << 3;
				object obj = (long)(IntPtr)weights + (long)num8;
				object obj2 = (long)(IntPtr)obj + 32L;
				float value2 = ((FsmFloat)obj2).Value;
				if (!(num7 < value2))
				{
					if (num4 >= weights.Length)
					{
						break;
					}
					float value3 = ((FsmFloat)obj2).Value;
					num6 = weights.Length;
					num4++;
					num7 -= value3;
					if (num4 < weights.Length)
					{
						continue;
					}
					goto IL_019a;
				}
				goto IL_0218;
			}
			goto IL_01a8;
			IL_019a:
			num4 = -1;
			goto IL_0218;
			IL_01a8:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000309")]
		[Address(RVA = "0xA0EFD0", Offset = "0xA0EFD0", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB4618]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, animClip, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021CED]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, animClip, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(animClip, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_005C;\n\tv87 = UnityEngine.GameObject::GetComponent(go);\n\tgoto L_003F;\n\tv125 = *([v77 @ X8_v9+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_003F;\n\tv132 = v77;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v132, v86, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\tv71 = UnityEngine.Object::op_Inequality(v87, 0);\n\tv73 = v71 == 0;\n\tif (v73) goto L_005C;\n\tv94 = UnityEngine.Object::get_name(animClip);\n\tUnityEngine.Animation::AddClip(v87, animClip, v94);\n\treturn;\nL_005C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddAnimationClip(GameObject go, AnimationClip animClip)
		{
			if (!(animClip == null))
			{
				Animation component = go.GetComponent<Animation>();
				if (component != null)
				{
					string name = animClip.name;
					component.AddClip(animClip, name);
				}
			}
		}

		[Token(Token = "0x600030A")]
		[Address(RVA = "0xA0F0D8", Offset = "0xA0F0D8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.AnimationState::get_wrapMode(anim);\n\tv38 = v19 == 2;\n\tif (v38) goto L_FFFFFFFF;\n\tv45 = UnityEngine.AnimationState::get_wrapMode(anim);\n\tv64 = v45 == 4;\n\tif (v64) goto L_FFFFFFFF;\n\tv159 = UnityEngine.AnimationState::get_wrapMode(anim);\n\tv160 = v159 == 0;\n\tif (v160) goto L_0050;\n\tv163 = UnityEngine.AnimationState::get_wrapMode(anim);\n\tv187 = prevTime <= 0;\n\tif (v187) goto L_005D;\n\tv192 = v163 == 1;\n\tif (v192) goto L_0055;\n\tgoto L_005D;\nL_0050:\n\tv175 = prevTime <= 0;\n\tif (v175) goto L_005D;\nL_0055:\n\tv199 = 0xBCCE68(&v82 @ stack_-24_v4 (System.Single), 0, v22, v23, v24, v25, v26, v27, 0, currentTime, v28, v29, v30, v31, v32, v33);\n\tv213 = v199 & 1;\n\tv153 = v213 == 0;\n\tif (v153) goto L_005D;\n\tgoto L_0081;\nL_005D:\n\tv47 = UnityEngine.AnimationState::get_length(anim);\n\tv50 = v47 <= prevTime;\n\tif (v50) goto L_FFFFFFFF;\n\tv130 = UnityEngine.AnimationState::get_length(anim);\n\tv146 = v82 - v130;\n\tv144 = v146 < 0;\n\tv140 = v82 ^ v130;\n\tv138 = v82 ^ v146;\n\tv136 = v140 & v138;\n\tv134 = v136 < 0;\n\tv132 = v144 == v134;\n\tgoto L_0081;\nL_0081:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasAnimationFinished(AnimationState anim, float prevTime, float currentTime)
		{
			//IL_01ba: Expected O, but got F4
			//IL_01c7: Expected O, but got F4
			WrapMode wrapMode = anim.wrapMode;
			float num;
			if (wrapMode != WrapMode.Loop)
			{
				WrapMode wrapMode2 = anim.wrapMode;
				if (wrapMode2 != WrapMode.PingPong)
				{
					if (anim.wrapMode != WrapMode.Default)
					{
						WrapMode wrapMode3 = anim.wrapMode;
						bool flag = !(prevTime > 0f);
						num = currentTime;
						if (!flag)
						{
							if (wrapMode3 == WrapMode.Once)
							{
								goto IL_0109;
							}
							num = currentTime;
						}
					}
					else
					{
						bool flag2 = !(prevTime > 0f);
						num = currentTime;
						if (!flag2)
						{
							goto IL_0109;
						}
					}
					goto IL_0152;
				}
			}
			goto IL_0200;
			IL_0109:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCE68 (inside System.Single::IsNaN +0x250)");
			object obj = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
			{
				return true;
			}
			goto IL_0152;
			IL_0152:
			float length = anim.length;
			if (length > prevTime)
			{
				float length2 = anim.length;
				float num2 = num - length2;
				bool flag3 = num2 < 0f;
				object obj2 = num ^ length2;
				object obj3 = num ^ num2;
				int num3 = (int)((long)(IntPtr)obj2 & (long)(IntPtr)obj3);
				bool flag4 = num3 < 0;
				return flag3 == flag4;
			}
			goto IL_0200;
			IL_0200:
			return false;
		}

		[Token(Token = "0x600030B")]
		[Address(RVA = "0xA0F1C4", Offset = "0xA0F1C4", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC3D20]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fsmVector3, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021CEE]) = v41;\nL_0019:\n\tv45 = HutongGames.PlayMaker.FsmGameObject::get_Value(fsmGameObject);\n\tgoto L_002B;\n\tv97 = *([v72 @ X8_v7+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_002B;\n\tv104 = v72;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v104, v44, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002B:\n\tv62 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv135 = v62 == 0;\n\tif (v135) goto L_0056;\n\tv156 = HutongGames.PlayMaker.NamedVariable::get_IsNone(fsmVector3);\n\tv90 = HutongGames.PlayMaker.FsmGameObject::get_Value(fsmGameObject);\n\tv63 = UnityEngine.GameObject::get_transform(v90);\n\tv159 = v156 == 0;\n\tif (v159) goto L_005C;\n\treturnVal3 = UnityEngine.Transform::get_position(v63);\n\treturn returnVal3;\nL_0056:\n\treturnVal2 = HutongGames.PlayMaker.FsmVector3::get_Value(fsmVector3);\n\treturn returnVal2;\nL_005C:\n\tv51 = HutongGames.PlayMaker.FsmVector3::get_Value(fsmVector3);\n\treturnVal4 = UnityEngine.Transform::TransformPoint(v63, v51);\n\treturn returnVal4;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 GetPosition(FsmGameObject fsmGameObject, FsmVector3 fsmVector3)
		{
			GameObject value = fsmGameObject.Value;
			if (value != null)
			{
				bool isNone = fsmVector3.IsNone;
				GameObject value2 = fsmGameObject.Value;
				Transform transform = value2.transform;
				if (isNone)
				{
					return transform.position;
				}
				Vector3 value3 = fsmVector3.Value;
				return transform.TransformPoint(value3);
			}
			return fsmVector3.Value;
		}

		[Token(Token = "0x600030C")]
		[Address(RVA = "0xA0F2E4", Offset = "0xA0F2E4", Length = "0x350")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = rotation.y;\n\tv2 = rotation.z;\n\tgoto L_0029;\n\tv46 = *([1EDE2A8]);\n\tv47 = *([v46 @ X8_v20]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, owner, target, methodInfo, v50, v51, v52, v53, rotation, v0, v2, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2021CEF]) = v61;\nL_0029:\n\tgoto L_0032;\n\tv68 = *([v64 @ X0_v2+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_0032;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v64, owner, target, methodInfo, v50, v51, v52, v53, rotation, v0, v2, v54, v55, v56, v57, v58);\nL_0032:\n\tv78 = UnityEngine.Object::op_Equality(owner, 0);\n\tv80 = v78 == 0;\n\tif (v80) goto L_0056;\n\tgoto L_0051;\n\tv98 = *([v83 @ X0_v13+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0051;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v83, v76, v77, methodInfo, v50, v51, v52, v53, rotation, v0, v2, v54, v55, v56, v57, v58);\nL_0051:\n\treturnVal1 = UnityEngine.Quaternion::get_identity();\n\treturn returnVal1;\nL_0056:\n\tv87 = option < 5;\n\tv88 = ~v87;\n\tv89 = option - 5;\n\tv91 = v89 == 0;\n\tv96 = ~v91;\n\tv97 = v88 & v96;\n\tif (v97) goto L_0142;\n\tv122 = 0x1818000 + 0x7D4;\n\tv124 = *([v122 @ X9_v2 (System.Int32)+option @ X0 (HutongGames.PlayMaker.AnimationEnums.RotationOptions)*4]) + v122;\n\t// 103 IndirectJump v124 @ X8_v11, v78 @ X0_v5 (System.Boolean), v78 @ X0_v5 (System.Boolean), 0, 0, methodInfo @ X3 (Il2CppMethodInfo), v50 @ X4, v51 @ X5, v52 @ X6, v53 @ X7, rotation @ V0 (UnityEngine.Vector3), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v54 @ V3, v55 @ V4, v56 @ V5, v57 @ V6, v58 @ V7\n\tif (TEMP) goto L_014C;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Transform::get_parent(X0, X1);\n\tX8 = *([X22]);\n\tX20 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0079;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0079;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0079:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00FE;\n\tX8 = *([1EC5B90]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_008C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008C:\n\tV0 = V10;\n\tV1 = V9;\n\tV2 = V8;\n\tX29 = stack[60];\n\tX30 = stack[68];\n\tX20 = stack[50];\n\tX19 = stack[58];\n\tX22 = stack[40];\n\tX21 = stack[48];\n\tV9 = stack[30];\n\tV8 = stack[38];\n\tV11 = stack[20];\n\tV10 = stack[28];\n\tV13 = stack[10];\n\tV12 = stack[18];\n\tX0 = 0;\n\tV14 = stack[0];\n\t// 157 ShiftStack 112\n\t// 158 MakeStruct AGGA0F468_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Quaternion::Euler(AGGA0F468_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\treturn V0;\n\tif (TEMP) goto L_014C;\n\tX0 = X19;\n\tgoto L_0103;\n\tX8 = *([1EC5B90]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00B4;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B4;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B4:\n\tV0 = V10;\n\tV1 = V9;\n\tV2 = V8;\n\tX0 = 0;\n\t// 184 MakeStruct AGGA0F4A8_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Quaternion::Euler(AGGA0F4A8_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tV11 = V3;\n\tif (TEMP) goto L_014C;\n\tX0 = X19;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_rotation(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = V0;\n\tV5 = V1;\n\tV6 = V2;\n\tV7 = V3;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tV3 = V11;\n\tgoto L_0129;\n\tX0 = *([X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00DC;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00DC;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00DC:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00FA;\n\tif (TEMP) goto L_014C;\n\tX0 = X19;\n\tX29 = stack[60];\n\tX30 = stack[68];\n\tX20 = stack[50];\n\tX19 = stack[58];\n\tX22 = stack[40];\n\tX21 = stack[48];\n\tV9 = stack[30];\n\tV8 = stack[38];\n\tV11 = stack[20];\n\tV10 = stack[28];\n\tV13 = stack[10];\n\tV12 = stack[18];\n\tX1 = 0;\n\tV14 = stack[0];\n\t// 244 ShiftStack 112\n\tV0 = UnityEngine.Transform::get_rotation(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\treturn V0;\nL_00FA:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_014C;\n\tX0 = X20;\n\tgoto L_0103;\nL_00FE:\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Transform::get_parent(X0, X1);\n\tif (TEMP) goto L_014E;\nL_0103:\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_rotation(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX8 = *([1EC5B90]);\n\tV11 = V0;\n\tV12 = V1;\n\tV13 = V2;\n\tX0 = *([X8]);\n\tV14 = V3;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0118;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0118;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0118:\n\tV0 = V10;\n\tV1 = V9;\n\tV2 = V8;\n\tX0 = 0;\n\t// 284 MakeStruct AGGA0F5AC_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Quaternion::Euler(AGGA0F5AC_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = V0;\n\tV5 = V1;\n\tV6 = V2;\n\tV7 = V3;\n\tV0 = V11;\n\tV1 = V12;\n\tV2 = V13;\n\tV3 = V14;\nL_0129:\n\tX29 = stack[60];\n\tX30 = stack[68];\n\tX20 = stack[50];\n\tX19 = stack[58];\n\tX22 = stack[40];\n\tX21 = stack[48];\n\tV9 = stack[30];\n\tV8 = stack[38];\n\tV11 = stack[20];\n\tV10 = stack[28];\n\tV13 = stack[10];\n\tV12 = stack[18];\n\tX0 = 0;\n\tV14 = stack[0];\n\t// 311 ShiftStack 112\n\t// 312 MakeStruct AGGA0F5F0_0, typeof(UnityEngine.Quaternion), V0, V1, V2, V3\n\t// 313 MakeStruct AGGA0F5F0_1, typeof(UnityEngine.Quaternion), V4, V5, V6, V7\n\tV0 = UnityEngine.Quaternion::op_Multiply(AGGA0F5F0_0, AGGA0F5F0_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\treturn V0;\nL_0142:\n\tv128 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v128);\n\tthrow v128;\nL_014C:\n\t;\nL_014E:\n\tthrow v184;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion GetTargetRotation(RotationOptions option, Transform owner, Transform target, Vector3 rotation)
		{
			//IL_00de: Expected O, but got I
			float y = rotation.y;
			float z = rotation.z;
			if (owner == null)
			{
				return Quaternion.identity;
			}
			bool flag = option < RotationOptions.MatchGameObjectRotation;
			bool flag2 = !flag;
			int num = (int)(option - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 2004;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X9_v2 (System.Int32)+option @ X0 (HutongGames.PlayMaker.AnimationEnums.RotationOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v124 @ X8_v11 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600030D")]
		[Address(RVA = "0xA0F634", Offset = "0xA0F634", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1F0ECD8]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, owner, rotation, target, targetRotation, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021CF0]) = v50;\nL_0021:\n\tgoto L_0028;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, owner, rotation, target, targetRotation, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0028:\n\tv65 = UnityEngine.Quaternion::get_identity();\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)]) = v65;\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)+4]) = v65.y;\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)+8]) = v65.z;\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)+C]) = v65.w;\n\tgoto L_003F;\n\tv75 = *([v71 @ X0_v5+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_003F;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v71, owner, rotation, target, targetRotation, methodInfo, v38, v39, v65, v66, v67, v68, v44, v45, v46, v47);\nL_003F:\n\tv85 = UnityEngine.Object::op_Equality(owner, 0);\n\tv87 = v85 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_FFFFFFFF;\n\tv92 = HutongGames.PlayMaker.ActionHelpers::CanEditTargetRotation(option, rotation, target);\n\tv97 = v92 == 0;\n\tif (v97) goto L_FFFFFFFF;\n\tv163 = HutongGames.PlayMaker.FsmGameObject::get_Value(target);\n\tgoto L_005F;\n\tv184 = *([v123 @ X8_v12+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_005F;\n\tv193 = v123;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v193, v162, v91, target, targetRotation, methodInfo, v38, v39, v65, v66, v67, v68, v44, v45, v46, v47);\nL_005F:\n\tv192 = UnityEngine.Object::op_Inequality(v163, 0);\n\tv195 = v192 == 0;\n\tif (v195) goto L_0070;\n\tv181 = HutongGames.PlayMaker.FsmGameObject::get_Value(target);\n\tv198 = UnityEngine.GameObject::get_transform(v181);\nL_0070:\n\tv203 = HutongGames.PlayMaker.FsmVector3::get_Value(rotation);\n\tv117 = HutongGames.PlayMaker.ActionHelpers::GetTargetRotation(option, owner, v125, v203);\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)]) = v117;\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)+4]) = v117.y;\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)+8]) = v117.z;\n\t*([targetRotation @ X4 (UnityEngine.Quaternion&)+C]) = v117.w;\n\tgoto L_008B;\nL_008B:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool GetTargetRotation(RotationOptions option, Transform owner, FsmVector3 rotation, FsmGameObject target, out Quaternion targetRotation)
		{
			targetRotation = default(Quaternion);
			Quaternion identity = Quaternion.identity;
			ref Quaternion reference = ref *(Quaternion*)identity;
			_ = identity.y;
			_ = identity.z;
			_ = identity.w;
			if (!(owner == null) && CanEditTargetRotation(option, rotation, target))
			{
				GameObject value = target.Value;
				bool flag = value != null;
				bool flag2 = !flag;
				Transform target2 = null;
				if (!flag2)
				{
					GameObject value2 = target.Value;
					Transform transform = value2.transform;
					target2 = transform;
				}
				Vector3 value3 = rotation.Value;
				Quaternion targetRotation2 = GetTargetRotation(option, owner, target2, value3);
				reference = ref *(Quaternion*)targetRotation2;
				_ = targetRotation2.y;
				_ = targetRotation2.z;
				_ = targetRotation2.w;
				return true;
			}
			return false;
		}

		[Token(Token = "0x600030E")]
		[Address(RVA = "0xA0F7AC", Offset = "0xA0F7AC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFAB40]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, rotation, target, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021CF1]) = v44;\nL_0017:\n\tv45 = option - 1;\n\tv46 = v45 < 4;\n\tv47 = ~v46;\n\tif (v47) goto L_0029;\n\tv59 = HutongGames.PlayMaker.NamedVariable::get_IsNone(rotation);\n\tv103 = v59 ^ 1;\n\tgoto L_005A;\nL_0029:\n\tv56 = option == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tv63 = option != 5;\n\tif (v63) goto L_0062;\n\tv147 = HutongGames.PlayMaker.FsmGameObject::get_Value(target);\n\tgoto L_0053;\n\tv157 = *([v140 @ X8_v13+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0053;\n\tv163 = v140;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v163, v146, target, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0053:\n\treturnVal3 = UnityEngine.Object::op_Inequality(v147, 0);\n\treturn returnVal3;\nL_005A:\n\treturnVal2 = v103 & 1;\n\treturn returnVal2;\nL_0062:\n\tv99 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v99);\n\tthrow v99;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool CanEditTargetRotation(RotationOptions option, NamedVariable rotation, FsmGameObject target)
		{
			int num = (int)(option - 1);
			int num2;
			if (num < 4)
			{
				bool isNone = rotation.IsNone;
				num2 = (isNone ? 1 : 0) ^ 1;
			}
			else
			{
				switch (option)
				{
				case RotationOptions.MatchGameObjectRotation:
				{
					GameObject value = target.Value;
					return value != null;
				}
				case RotationOptions.CurrentRotation:
					break;
				default:
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				}
				num2 = 0;
			}
			return (byte)(num2 & 1) != 0;
		}

		[Token(Token = "0x600030F")]
		[Address(RVA = "0xA0F8C4", Offset = "0xA0F8C4", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = scale.y;\n\tv2 = scale.z;\n\tgoto L_0027;\n\tv42 = *([1F0FB60]);\n\tv43 = *([v42 @ X8_v17]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, owner, target, methodInfo, v46, v47, v48, v49, scale, v0, v2, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2021CF2]) = v57;\nL_0027:\n\tgoto L_0030;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0030;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, owner, target, methodInfo, v46, v47, v48, v49, scale, v0, v2, v50, v51, v52, v53, v54);\nL_0030:\n\tv74 = UnityEngine.Object::op_Equality(owner, 0);\n\tv76 = v74 == 0;\n\tif (v76) goto L_0045;\n\tgoto L_0041;\n\tv94 = *([v79 @ X0_v10+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0041;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v79, v72, v73, methodInfo, v46, v47, v48, v49, scale, v0, v2, v50, v51, v52, v53, v54);\nL_0041:\n\tv188 = UnityEngine.Vector3::get_one();\n\tgoto L_00BA;\nL_0045:\n\tv83 = option < 4;\n\tv84 = ~v83;\n\tv85 = option - 4;\n\tv87 = v85 == 0;\n\tv92 = ~v87;\n\tv93 = v84 & v92;\n\tif (v93) goto L_00A5;\n\tv105 = 0x1818000 + 0x7EC;\n\tv107 = *([v105 @ X9_v2 (System.Int32)+option @ X0 (HutongGames.PlayMaker.AnimationEnums.ScaleOptions)*4]) + v105;\n\t// 86 IndirectJump v107 @ X8_v8, v74 @ X0_v5 (System.Boolean), v74 @ X0_v5 (System.Boolean), 0, 0, methodInfo @ X3 (Il2CppMethodInfo), v46 @ X4, v47 @ X5, v48 @ X6, v49 @ X7, scale @ V0 (UnityEngine.Vector3), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v50 @ V3, v51 @ V4, v52 @ V5, v53 @ V6, v54 @ V7\n\tstack[0] = V10;\n\tstack[4] = V9;\n\tstack[8] = V8;\n\tgoto L_00BA;\n\tif (TEMP) goto L_00BF;\n\tX0 = X19;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_localScale(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X19;\n\tX1 = 0;\n\tV11 = V0;\n\tV0 = UnityEngine.Transform::get_localScale(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X19;\n\tX1 = 0;\n\tV12 = V1;\n\tV0 = UnityEngine.Transform::get_localScale(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV0 = V10 * V11;\n\tV1 = V9 * V12;\n\tV2 = V8 * V2;\n\tstack[8] = 0;\n\tstack[0] = 0;\n\tgoto L_008C;\n\tif (TEMP) goto L_00BF;\n\tX0 = X19;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_localScale(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X19;\n\tX1 = 0;\n\tV11 = V0;\n\tV0 = UnityEngine.Transform::get_localScale(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X19;\n\tX1 = 0;\n\tV12 = V1;\n\tV0 = UnityEngine.Transform::get_localScale(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tstack[8] = 0;\n\tstack[0] = 0;\n\tV0 = V10 + V11;\n\tV1 = V9 + V12;\n\tV2 = V8 + V2;\nL_008C:\n\tX0 = &stack[0];\n\tX1 = 0;\n\tX0 = 0x1586898(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00BA;\n\tX0 = *([X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_009A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009A:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BB;\nL_00A5:\n\tv188 = UnityEngine.Transform::get_localScale(owner);\nL_00BA:\n\treturn v188;\nL_00BB:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_00BF;\n\tX0 = X20;\n\tgoto L_00A5;\nL_00BF:\n\t;\n\tthrow System.NullReferenceException;\n\treturn scale;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 GetTargetScale(ScaleOptions option, Transform owner, Transform target, Vector3 scale)
		{
			//IL_00de: Expected O, but got I
			float y = scale.y;
			float z = scale.z;
			while (true)
			{
				if (owner == null)
				{
					return Vector3.one;
				}
				bool flag = option < ScaleOptions.MatchGameObject;
				bool flag2 = !flag;
				int num = (int)(option - 4);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25264128 + 2028;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X9_v2 (System.Int32)+option @ X0 (HutongGames.PlayMaker.AnimationEnums.ScaleOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v107 @ X8_v8 (should have been resolved before IL gen)");
			}
			return owner.localScale;
		}

		[Token(Token = "0x6000310")]
		[Address(RVA = "0xA0FAC8", Offset = "0xA0FAC8", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EBB0E8]);\n\tv35 = *([v34 @ X8_v19]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, owner, position, target, targetPosition, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021CF3]) = v50;\nL_0021:\n\tgoto L_0028;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, owner, position, target, targetPosition, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0028:\n\tv65 = UnityEngine.Vector3::get_zero();\n\t*([targetPosition @ X4 (UnityEngine.Vector3&)]) = v65;\n\t*([targetPosition @ X4 (UnityEngine.Vector3&)+4]) = v65.y;\n\t*([targetPosition @ X4 (UnityEngine.Vector3&)+8]) = v65.z;\n\tgoto L_003D;\n\tv74 = *([v70 @ X0_v5+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_003D;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v70, owner, position, target, targetPosition, methodInfo, v38, v39, v65, v66, v67, v43, v44, v45, v46, v47);\nL_003D:\n\tv84 = UnityEngine.Object::op_Equality(owner, 0);\n\tv86 = v84 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_FFFFFFFF;\n\tv91 = HutongGames.PlayMaker.ActionHelpers::IsValidTargetPosition(option, position, target);\n\tv96 = v91 == 0;\n\tif (v96) goto L_FFFFFFFF;\n\tv131 = target == 0;\n\tif (v131) goto L_FFFFFFFF;\n\tv159 = HutongGames.PlayMaker.FsmGameObject::get_Value(target);\n\tgoto L_005D;\n\tv180 = *([v161 @ X8_v14+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_005D;\n\tv206 = v161;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v206, v158, v90, target, targetPosition, methodInfo, v38, v39, v65, v66, v67, v43, v44, v45, v46, v47);\nL_005D:\n\tv173 = UnityEngine.Object::op_Inequality(v159, 0);\n\tv175 = v173 == 0;\n\tif (v175) goto L_0075;\n\tv213 = HutongGames.PlayMaker.FsmGameObject::get_Value(target);\n\tv191 = UnityEngine.GameObject::get_transform(v213);\n\tv216 = position == 0;\n\tv192 = ~v216;\n\tif (v192) goto L_0075;\n\tgoto L_008E;\n\tgoto L_008C;\nL_0075:\n\tv196 = HutongGames.PlayMaker.FsmVector3::get_Value(position);\n\tv114 = HutongGames.PlayMaker.ActionHelpers::GetTargetPosition(option, owner, v122, v196);\n\t*([targetPosition @ X4 (UnityEngine.Vector3&)]) = v114;\n\t*([targetPosition @ X4 (UnityEngine.Vector3&)+4]) = v114.y;\n\t*([targetPosition @ X4 (UnityEngine.Vector3&)+8]) = v114.z;\nL_008C:\n\treturn returnVal1;\nL_008E:\n\tv205 = new System.NullReferenceException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool GetTargetPosition(PositionOptions option, Transform owner, FsmVector3 position, FsmGameObject target, out Vector3 targetPosition)
		{
			//IL_01dd: Expected I4, but got O
			targetPosition = default(Vector3);
			Vector3 zero = Vector3.zero;
			ref Vector3 reference = ref *(Vector3*)zero;
			_ = zero.y;
			_ = zero.z;
			if (!(owner == null) && IsValidTargetPosition(option, position, target))
			{
				Transform target2;
				if (target != null)
				{
					GameObject value = target.Value;
					bool flag = value != null;
					bool flag2 = !flag;
					target2 = null;
					if (!flag2)
					{
						GameObject value2 = target.Value;
						Transform transform = value2.transform;
						bool flag3 = position == null;
						bool flag4 = !flag3;
						target2 = transform;
						if (!flag4)
						{
							NullReferenceException ex = new NullReferenceException();
							NullReferenceException ex2 = new NullReferenceException();
							return (byte)(int)ex2 != 0;
						}
					}
				}
				else
				{
					target2 = null;
				}
				Vector3 value3 = position.Value;
				Vector3 targetPosition2 = GetTargetPosition(option, owner, target2, value3);
				reference = ref *(Vector3*)targetPosition2;
				_ = targetPosition2.y;
				_ = targetPosition2.z;
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000311")]
		[Address(RVA = "0xA0FC50", Offset = "0xA0FC50", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ECBAA8]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, position, target, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021CF4]) = v44;\nL_0017:\n\tv45 = option - 1;\n\tv46 = v45 < 4;\n\tv47 = ~v46;\n\tif (v47) goto L_0029;\n\tv59 = HutongGames.PlayMaker.NamedVariable::get_IsNone(position);\n\tv103 = v59 ^ 1;\n\tgoto L_005A;\nL_0029:\n\tv56 = option == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tv63 = option != 5;\n\tif (v63) goto L_0062;\n\tv147 = HutongGames.PlayMaker.FsmGameObject::get_Value(target);\n\tgoto L_0053;\n\tv157 = *([v140 @ X8_v13+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0053;\n\tv163 = v140;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v163, v146, target, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0053:\n\treturnVal3 = UnityEngine.Object::op_Inequality(v147, 0);\n\treturn returnVal3;\nL_005A:\n\treturnVal2 = v103 & 1;\n\treturn returnVal2;\nL_0062:\n\tv99 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v99);\n\tthrow v99;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsValidTargetPosition(PositionOptions option, NamedVariable position, FsmGameObject target)
		{
			int num = (int)(option - 1);
			int num2;
			if (num < 4)
			{
				bool isNone = position.IsNone;
				num2 = (isNone ? 1 : 0) ^ 1;
			}
			else
			{
				switch (option)
				{
				case PositionOptions.TargetGameObject:
				{
					GameObject value = target.Value;
					return value != null;
				}
				case PositionOptions.CurrentPosition:
					break;
				default:
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				}
				num2 = 1;
			}
			return (byte)(num2 & 1) != 0;
		}

		[Token(Token = "0x6000312")]
		[Address(RVA = "0xA10024", Offset = "0xA10024", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFC4D0]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, position, target, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021CF5]) = v44;\nL_0017:\n\tv45 = option - 1;\n\tv46 = v45 < 4;\n\tv47 = ~v46;\n\tif (v47) goto L_0029;\n\tv59 = HutongGames.PlayMaker.NamedVariable::get_IsNone(position);\n\tv103 = v59 ^ 1;\n\tgoto L_005A;\nL_0029:\n\tv56 = option == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tv63 = option != 5;\n\tif (v63) goto L_0062;\n\tv147 = HutongGames.PlayMaker.FsmGameObject::get_Value(target);\n\tgoto L_0053;\n\tv157 = *([v140 @ X8_v13+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0053;\n\tv163 = v140;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v163, v146, target, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0053:\n\treturnVal3 = UnityEngine.Object::op_Inequality(v147, 0);\n\treturn returnVal3;\nL_005A:\n\treturnVal2 = v103 & 1;\n\treturn returnVal2;\nL_0062:\n\tv99 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v99);\n\tthrow v99;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CanEditTargetPosition(PositionOptions option, NamedVariable position, FsmGameObject target)
		{
			int num = (int)(option - 1);
			int num2;
			if (num < 4)
			{
				bool isNone = position.IsNone;
				num2 = (isNone ? 1 : 0) ^ 1;
			}
			else
			{
				switch (option)
				{
				case PositionOptions.TargetGameObject:
				{
					GameObject value = target.Value;
					return value != null;
				}
				case PositionOptions.CurrentPosition:
					break;
				default:
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				}
				num2 = 0;
			}
			return (byte)(num2 & 1) != 0;
		}

		[Token(Token = "0x6000313")]
		[Address(RVA = "0xA0FD68", Offset = "0xA0FD68", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = position.y;\n\tv2 = position.z;\n\tgoto L_0028;\n\tv44 = *([1ECB7E0]);\n\tv45 = *([v44 @ X8_v20]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, owner, target, methodInfo, v48, v49, v50, v51, position, v0, v2, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2021CF6]) = v59;\nL_0028:\n\tgoto L_0031;\n\tv66 = *([v62 @ X0_v2+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0031;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, owner, target, methodInfo, v48, v49, v50, v51, position, v0, v2, v52, v53, v54, v55, v56);\nL_0031:\n\tv76 = UnityEngine.Object::op_Equality(owner, 0);\n\tv78 = v76 == 0;\n\tif (v78) goto L_0046;\n\tgoto L_0042;\n\tv96 = *([v81 @ X0_v12+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0042;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v81, v74, v75, methodInfo, v48, v49, v50, v51, position, v0, v2, v52, v53, v54, v55, v56);\nL_0042:\n\tv104 = UnityEngine.Vector3::get_zero();\n\tgoto L_00D2;\nL_0046:\n\tv85 = option < 5;\n\tv86 = ~v85;\n\tv87 = option - 5;\n\tv89 = v87 == 0;\n\tv94 = ~v89;\n\tv95 = v86 & v94;\n\tif (v95) goto L_00F9;\n\tv107 = 0x1818000 + 0x800;\n\tv109 = *([v107 @ X9_v2 (System.Int32)+option @ X0 (HutongGames.PlayMaker.AnimationEnums.PositionOptions)*4]) + v107;\n\t// 87 IndirectJump v109 @ X8_v11, v76 @ X0_v5 (System.Boolean), v76 @ X0_v5 (System.Boolean), 0, 0, methodInfo @ X3 (Il2CppMethodInfo), v48 @ X4, v49 @ X5, v50 @ X6, v51 @ X7, position @ V0 (UnityEngine.Vector3), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v52 @ V3, v53 @ V4, v54 @ V5, v55 @ V6, v56 @ V7\n\tif (TEMP) goto L_0103;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Transform::get_parent(X0, X1);\n\tX8 = *([X22]);\n\tX20 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0069;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0069;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0069:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D2;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Transform::get_parent(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007B;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0103;\n\tX0 = X19;\nL_007B:\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tX1 = 0;\n\t// 127 MakeStruct AGGA0FEB0_1, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Transform::TransformPoint(X0, AGGA0FEB0_1, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t// 131 Jump @b59\n\tif (TEMP) goto L_0103;\n\tX0 = X19;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_position(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX8 = *([1EE1550]);\n\tV11 = V0;\n\tV12 = V1;\n\tV13 = V2;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_009A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009A:\n\tV0 = V11;\n\tV1 = V12;\n\tV2 = V13;\n\tV3 = V8;\n\tV4 = V9;\n\tV5 = V10;\n\tX0 = 0;\n\t// 161 MakeStruct AGGA0FF10_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 162 MakeStruct AGGA0FF10_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::op_Addition(AGGA0FF10_0, AGGA0FF10_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t// 166 Jump @b59\n\tX0 = *([X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00B1;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B1;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B1:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00D3;\n\tif (TEMP) goto L_0103;\n\tX0 = X19;\nL_00BB:\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_position(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\nL_00D2:\n\treturn v104;\nL_00D3:\n\tX8 = 0x1EE1000;\n\tX8 = *([1EE1550]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00DF;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00DF;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00DF:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector3::get_zero(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = V0;\n\tV4 = V1;\n\tV5 = V2;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tX0 = 0;\n\t// 234 MakeStruct AGGA0FFCC_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 235 MakeStruct AGGA0FFCC_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tX0 = UnityEngine.Vector3::op_Inequality(AGGA0FFCC_0, AGGA0FFCC_1, X0);\n\tif (TEMP) goto L_0103;\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00F4;\n\tX0 = X20;\n\tgoto L_007B;\nL_00F4:\n\tX0 = X20;\n\tgoto L_00BB;\nL_00F9:\n\tv113 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v113);\n\tthrow v113;\nL_0103:\n\t;\n\treturn position;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 GetTargetPosition(PositionOptions option, Transform owner, Transform target, Vector3 position)
		{
			//IL_00de: Expected O, but got I
			float y = position.y;
			float z = position.z;
			if (owner == null)
			{
				return Vector3.zero;
			}
			bool flag = option < PositionOptions.TargetGameObject;
			bool flag2 = !flag;
			int num = (int)(option - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 2048;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X9_v2 (System.Int32)+option @ X0 (HutongGames.PlayMaker.AnimationEnums.PositionOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v109 @ X8_v11 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000314")]
		[Address(RVA = "0xA1013C", Offset = "0xA1013C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EBE7B8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, layerMask, methodInfo, v30, v31, v32, v33, v34, distance, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021CF7]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, layerMask, methodInfo, v30, v31, v32, v33, v34, distance, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv61 = UnityEngine.Object::op_Equality(gameObject, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_0035;\n\treturn 0;\nL_0035:\n\tv73 = HutongGames.PlayMaker.ActionHelpers::MouseOver(distance, layerMask);\n\tgoto L_004C;\n\tv104 = *([v95 @ X8_v5+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_004C;\n\tv110 = v95;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v110, v59, v60, v30, v31, v32, v33, v34, v71, v35, v36, v37, v38, v39, v40, v41);\nL_004C:\n\treturnVal2 = UnityEngine.Object::op_Equality(gameObject, v73);\n\treturn returnVal2;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsMouseOver(GameObject gameObject, float distance, int layerMask)
		{
			if (gameObject == null)
			{
				return false;
			}
			GameObject gameObject2 = MouseOver(distance, layerMask);
			return gameObject == gameObject2;
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0xA10354", Offset = "0xA10354", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1F0ED28]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, distance, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021CF8]) = v45;\nL_0018:\n\tv47 = UnityEngine.Time::get_frameCount();\n\tv54 = v52.mousePickInfo + 0x2C;\n\treturnVal1 = 0xBCCE68(v54, 0, v30, v31, v32, v33, v34, v35, v47, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = returnVal1 & 1;\n\tv58 = v57 == 0;\n\tif (v58) goto L_003F;\n\tv59 = HutongGames.PlayMaker.ActionHelpers;\n\tv114 = *([v59 @ X8_v9 (Il2CppClass<HutongGames.PlayMaker.ActionHelpers>)+B8]);\n\tv65 = v114.mousePickDistanceUsed < distance;\n\tif (v65) goto L_003F;\n\tv84 = v114.mousePickLayerMaskUsed == layerMask;\n\tif (v84) goto L_0046;\nL_003F:\n\tHutongGames.PlayMaker.ActionHelpers::DoMousePick(distance, layerMask);\nL_0046:\n\treturnBuffer.m_Distance = *([v114 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+1C]);\n\t*([returnBuffer @ X8 (UnityEngine.RaycastHit)+10]) = *([v114 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+10]);\n\treturnBuffer.m_Point = v114.mousePickInfo;\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static RaycastHit MousePick(float distance, int layerMask)
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected I4, but got Unknown
			//IL_006d: Expected O, but got I4
			//IL_0076: Expected I, but got O
			//IL_00e2: Expected F4, but got I
			//IL_00dd: Expected native int or pointer, but got O
			//IL_00f8: Expected native int or pointer, but got O
			//IL_0013: Expected I, but got O
			//IL_001c: Expected I, but got O
			int frameCount = Time.frameCount;
			object obj = mousePickInfo + 44;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCE68 (inside System.Single::IsNaN +0x250)");
			RaycastHit raycastHit = default(RaycastHit);
			IntPtr intPtr2;
			if ((raycastHit & 1) != 0)
			{
				IntPtr intPtr = (IntPtr)typeof(ActionHelpers);
				intPtr2 = (IntPtr)mousePickInfo;
				if (!(mousePickDistanceUsed < distance) && mousePickLayerMaskUsed == layerMask)
				{
					goto IL_00cd;
				}
			}
			DoMousePick(distance, layerMask);
			raycastHit = (RaycastHit)layerMask;
			intPtr2 = (IntPtr)mousePickInfo;
			goto IL_00cd;
			IL_00cd:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+1C]");
			RaycastHit raycastHit2 = default(RaycastHit);
			((RaycastHit*)(IntPtr)raycastHit2)->m_Distance = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+10]");
			_ = 0;
			((RaycastHit*)(IntPtr)raycastHit2)->m_Point = (Vector3)mousePickInfo;
			return raycastHit;
		}

		[Token(Token = "0x6000316")]
		[Address(RVA = "0xA10218", Offset = "0xA10218", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB8A58]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, distance, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021CF9]) = v41;\nL_0016:\n\tv43 = UnityEngine.Time::get_frameCount();\n\tv50 = v48.mousePickInfo + 0x2C;\n\tv52 = 0xBCCE68(v50, 0, v26, v27, v28, v29, v30, v31, v43, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = v52 & 1;\n\tv54 = v53 == 0;\n\tif (v54) goto L_003D;\n\tv55 = HutongGames.PlayMaker.ActionHelpers;\n\tv109 = *([v55 @ X8_v16 (Il2CppClass<HutongGames.PlayMaker.ActionHelpers>)+B8]);\n\tv108 = v109.mousePickDistanceUsed;\n\tv61 = v109.mousePickDistanceUsed < distance;\n\tif (v61) goto L_003D;\n\tv80 = v109.mousePickLayerMaskUsed == layerMask;\n\tif (v80) goto L_0041;\nL_003D:\n\tHutongGames.PlayMaker.ActionHelpers::DoMousePick(distance, layerMask);\nL_0041:\n\tv112 = 0x164C7C8(v109, 0, v26, v27, v28, v29, v30, v31, v108, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0053;\n\tv120 = *([v116 @ X8_v9+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_0053;\n\tv131 = v116;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v131, v111, v26, v27, v28, v29, v30, v31, v108, v32, v33, v34, v35, v36, v37, v38);\nL_0053:\n\tv130 = UnityEngine.Object::op_Inequality(v112, 0);\n\tv133 = v130 == 0;\n\tif (v133) goto L_007C;\n\tv137 = 0x164C890(v134.mousePickInfo, 0, 0, v27, v28, v29, v30, v31, v108, v32, v33, v34, v35, v36, v37, v38);\n\tv140 = v108 >= distance;\n\tif (v140) goto L_007C;\n\tv197 = 0x164C7C8(v191.mousePickInfo, 0, 0, v27, v28, v29, v30, v31, v108, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = UnityEngine.Component::get_gameObject(v197);\n\treturn returnVal2;\nL_007C:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static GameObject MouseOver(float distance, int layerMask)
		{
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Expected O, but got Unknown
			//IL_007f: Expected I, but got O
			//IL_0013: Expected I, but got O
			//IL_001c: Expected I, but got O
			int frameCount = Time.frameCount;
			object obj = mousePickInfo + 44;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCE68 (inside System.Single::IsNaN +0x250)");
			object obj2 = default(object);
			float num;
			IntPtr intPtr2;
			if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
			{
				IntPtr intPtr = (IntPtr)typeof(ActionHelpers);
				intPtr2 = (IntPtr)mousePickInfo;
				num = mousePickDistanceUsed;
				if (!(mousePickDistanceUsed < distance) && mousePickLayerMaskUsed == layerMask)
				{
					goto IL_015a;
				}
			}
			DoMousePick(distance, layerMask);
			num = distance;
			intPtr2 = (IntPtr)mousePickInfo;
			goto IL_015a;
			IL_015a:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
			UnityEngine.Object obj3 = default(UnityEngine.Object);
			if (obj3 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
				if (num < distance)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
					Component component = default(Component);
					return component.gameObject;
				}
			}
			return null;
		}

		[Token(Token = "0x6000317")]
		[Address(RVA = "0xA10428", Offset = "0xA10428", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F066C0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, distance, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021CFA]) = v41;\nL_0016:\n\tv43 = UnityEngine.Camera::get_main();\n\tgoto L_0028;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv62 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, distance, v32, v33, v34, v35, v36, v37, v38);\nL_0028:\n\tv61 = UnityEngine.Object::op_Equality(v43, 0);\n\tv64 = v61 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_005F;\n\tv67 = UnityEngine.Camera::get_main();\n\tv124 = UnityEngine.Input::get_mousePosition();\n\tv153 = UnityEngine.Camera::ScreenPointToRay(v67, v124);\n\tv92 = v153.m_Origin;\n\tv161 = UnityEngine.Physics::Raycast(&v92 @ stack_-48_v2 (UnityEngine.Vector3), v159.mousePickInfo, distance, layerMask);\n\tv108.mousePickLayerMaskUsed = layerMask;\n\tv164.mousePickDistanceUsed = distance;\n\tv110 = UnityEngine.Time::get_frameCount();\n\tv114.mousePickRaycastTime = v110;\nL_005F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void DoMousePick(float distance, int layerMask)
		{
			//IL_0086: Expected O, but got Ref
			Camera main = Camera.main;
			if (!(main == null))
			{
				Camera main2 = Camera.main;
				Vector3 mousePosition = Input.mousePosition;
				Vector3 origin = main2.ScreenPointToRay(mousePosition).m_Origin;
				bool flag = Physics.Raycast((Ray)(&origin), out mousePickInfo, distance, layerMask);
				mousePickLayerMaskUsed = layerMask;
				mousePickDistanceUsed = distance;
				int frameCount = Time.frameCount;
				mousePickRaycastTime = frameCount;
			}
		}

		[Token(Token = "0x6000318")]
		[Address(RVA = "0xA10550", Offset = "0xA10550", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv118 = layers.Length;\n\tv32 = layers.Length < 1;\n\tif (v32) goto L_FFFFFFFF;\nL_001D:\n\tv145 = v48 < v118;\n\tv75 = ~v145;\n\tif (v75) goto L_005E;\n\tv124 = HutongGames.PlayMaker.FsmInt::get_Value(layers[v48 @ X22_v6 (System.Int32)]);\n\tv118 = layers.Length;\n\tv216 = v124 & 0x1F;\n\tv122 = 1 << v216;\n\tv48 = v48 + 1;\n\tv151 = v122 | v151;\n\tv127 = v48 < layers.Length;\n\tif (v127) goto L_001D;\n\tgoto L_0043;\nL_0043:\n\tv166 = v151 ^ invert;\n\tv183 = v166 != 0;\n\tif (v183) goto L_FFFFFFFF;\n\tgoto L_005C;\nL_005C:\n\treturn returnVal2;\n\tv81 = new System.NullReferenceException();\nL_005E:\n\tv121 = new System.IndexOutOfRangeException();\n\tthrow v121;\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int LayerArrayToLayerMask(FsmInt[] layers, bool invert)
		{
			int num = layers.Length;
			int num2;
			if (layers.Length >= 1)
			{
				num2 = 0;
				int num3 = 0;
				do
				{
					if (num3 < num)
					{
						int value = layers[num3].Value;
						num = layers.Length;
						int num4 = value & 0x1F;
						int num5 = 1 << num4;
						num3++;
						num2 = num5 | num2;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num3 < layers.Length);
			}
			else
			{
				num2 = 0;
			}
			int num6 = num2 ^ (invert ? 1 : 0);
			if (num6 == 0)
			{
				return -5;
			}
			return num6;
		}

		[Token(Token = "0x6000319")]
		[Address(RVA = "0xA10604", Offset = "0xA10604", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = wrapMode - 2;\n\tv5 = v3 == 0;\n\tv13 = wrapMode - 4;\n\tv15 = v13 == 0;\n\treturnVal1 = v15 | v5;\n\treturn returnVal1;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsLoopingWrapMode(WrapMode wrapMode)
		{
			int num = (int)(wrapMode - 2);
			bool flag = num == 0;
			int num2 = (int)(wrapMode - 4);
			bool flag2 = num2 == 0;
			return flag2 || flag;
		}

		[Token(Token = "0x600031A")]
		[Address(RVA = "0xA1061C", Offset = "0xA1061C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF3A58]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, rayDistance, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021CFB]) = v38;\nL_0017:\n\tv43 = rayDistance < 0;\n\tv44 = ~v43;\n\tv47 = rayDistance == 0;\n\tv55 = ~v47;\n\tv56 = v44 & v55;\n\tv57 = ~v56;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\treturn *([v60 @ X8_v5 (System.String)]);\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string CheckRayDistance(float rayDistance)
		{
			bool flag = rayDistance < 0f;
			bool flag2 = !flag;
			bool flag3 = rayDistance == 0f;
			bool flag4 = !flag3;
			if (flag2 && flag4)
			{
				return "";
			}
			return "Ray Distance should be greater than zero!\n";
		}

		[Token(Token = "0x600031B")]
		[Address(RVA = "0xA10680", Offset = "0xA10680", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1ED46F0]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021CFC]) = v43;\nL_0016:\n\tv44 = state == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tv47 = System.String::IsNullOrEmpty(eventName);\n\tv51 = v47 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\n\tv108 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv143 = v108.globalTransitions;\n\tv291 = v143.Length;\n\tv246 = v143.Length < 1;\n\tif (v246) goto L_005B;\nL_0035:\n\tv315 = v113 < v291;\n\tv131 = ~v315;\n\tif (v131) goto L_00AF;\n\tv348 = HutongGames.PlayMaker.FsmTransition::get_EventName(v143[v113 @ X22_v10 (System.Int32)]);\n\tv135 = System.String::op_Equality(v348, eventName);\n\tv359 = v135 == 0;\n\tv137 = ~v359;\n\tif (v137) goto L_FFFFFFFF;\n\tv291 = v143.Length;\n\tv113 = v113 + 1;\n\tv296 = v113 < v143.Length;\n\tif (v296) goto L_0035;\nL_005B:\n\tv139 = state.transitions;\n\tv292 = v139.Length;\n\tv327 = v139.Length < 1;\n\tif (v327) goto L_009E;\nL_006C:\n\tv357 = v144 < v292;\n\tv132 = ~v357;\n\tif (v132) goto L_00AF;\n\tv361 = HutongGames.PlayMaker.FsmTransition::get_EventName(v139[v144 @ X21_v12 (System.Int32)]);\n\tv136 = System.String::op_Equality(v361, eventName);\n\tv365 = v136 == 0;\n\tv138 = ~v365;\n\tif (v138) goto L_FFFFFFFF;\n\tv292 = v139.Length;\n\tv144 = v144 + 1;\n\tv330 = v144 < v139.Length;\n\tif (v330) goto L_006C;\nL_009E:\n\treturnVal3 = System.String::Concat(\"Fsm will not respond to Event: \", eventName);\n\treturn returnVal3;\n\tgoto L_00AD;\nL_00AD:\n\treturn *([v95 @ X8_v3 (System.String)]);\n\tv234 = new System.NullReferenceException();\nL_00AF:\n\tv293 = new System.IndexOutOfRangeException();\n\tthrow v293;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string CheckForValidEvent(FsmState state, string eventName)
		{
			if (state != null)
			{
				if (string.IsNullOrEmpty(eventName))
				{
					goto IL_0209;
				}
				Fsm fsm = state.Fsm;
				FsmTransition[] globalTransitions = fsm.GlobalTransitions;
				int num = globalTransitions.Length;
				if (globalTransitions.Length < 1)
				{
					goto IL_011f;
				}
				int num2 = 0;
				while (num2 < num)
				{
					string eventName2 = globalTransitions[num2].EventName;
					if (!(eventName2 == eventName))
					{
						num = globalTransitions.Length;
						num2++;
						if (num2 < globalTransitions.Length)
						{
							continue;
						}
						goto IL_011f;
					}
					goto IL_0209;
				}
				goto IL_0225;
			}
			return "Invalid State!";
			IL_0209:
			return "";
			IL_0225:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f2:
			return "Fsm will not respond to Event: " + eventName;
			IL_011f:
			FsmTransition[] transitions = state.Transitions;
			int num3 = transitions.Length;
			if (transitions.Length < 1)
			{
				goto IL_01f2;
			}
			int num4 = 0;
			while (num4 < num3)
			{
				string eventName3 = transitions[num4].EventName;
				if (!(eventName3 == eventName))
				{
					num3 = transitions.Length;
					num4++;
					if (num4 < transitions.Length)
					{
						continue;
					}
					goto IL_01f2;
				}
				goto IL_0209;
			}
			goto IL_0225;
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0xA107F0", Offset = "0xA107F0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC6820]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CFD]) = v38;\nL_0013:\n\tv39 = ownerDefault == 0;\n\tif (v39) goto L_0029;\n\tv50 = HutongGames.PlayMaker.FsmGameObject::get_Value(ownerDefault.gameObject);\n\treturnVal3 = HutongGames.PlayMaker.ActionHelpers::CheckPhysicsSetup(v50);\n\treturn returnVal3;\nL_0029:\n\treturn \"\";\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string CheckPhysicsSetup(FsmOwnerDefault ownerDefault)
		{
			if (ownerDefault != null)
			{
				GameObject value = ownerDefault.GameObject.Value;
				return CheckPhysicsSetup(value);
			}
			return "";
		}

		[Token(Token = "0x600031D")]
		[Address(RVA = "0xA109B4", Offset = "0xA109B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.ActionHelpers::CheckPhysicsSetup(gameObject);\n\treturn returnVal1;\n")]
		public static string CheckOwnerPhysicsSetup(GameObject gameObject)
		{
			return CheckPhysicsSetup(gameObject);
		}

		[Token(Token = "0x600031E")]
		[Address(RVA = "0xA10860", Offset = "0xA10860", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EEC7A0]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021CFE]) = v42;\nL_0020:\n\tgoto L_0029;\n\tv54 = *([v49 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tv64 = UnityEngine.Object::op_Inequality(gameObject, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0075;\n\tv101 = UnityEngine.GameObject::GetComponent(gameObject);\n\tgoto L_0043;\n\tv129 = *([v88 @ X8_v11+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0043;\n\tv136 = v88;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v136, v100, v63, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0043:\n\tv80 = UnityEngine.Object::op_Equality(v101, 0);\n\tv83 = v80 == 0;\n\tif (v83) goto L_0075;\n\tv142 = UnityEngine.GameObject::GetComponent(gameObject);\n\tgoto L_005B;\n\tv146 = *([v89 @ X8_v14+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_005B;\n\tv153 = v89;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v153, v141, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005B:\n\tv81 = UnityEngine.Object::op_Equality(v142, 0);\n\tv84 = v81 == 0;\n\tif (v84) goto L_0075;\n\treturnVal3 = System.String::Concat(v48.Empty, \"GameObject requires RigidBody/Collider!\\n\");\n\treturn returnVal3;\nL_0075:\n\treturn v48.Empty;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string CheckPhysicsSetup(GameObject gameObject)
		{
			if (gameObject != null)
			{
				Collider component = gameObject.GetComponent<Collider>();
				if (component == null)
				{
					Rigidbody component2 = gameObject.GetComponent<Rigidbody>();
					if (component2 == null)
					{
						return string.Empty + "GameObject requires RigidBody/Collider!\n";
					}
				}
			}
			return string.Empty;
		}

		[Token(Token = "0x600031F")]
		[Address(RVA = "0xA109B8", Offset = "0xA109B8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC9208]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CFF]) = v38;\nL_0013:\n\tv39 = ownerDefault == 0;\n\tif (v39) goto L_0029;\n\tv50 = HutongGames.PlayMaker.FsmGameObject::get_Value(ownerDefault.gameObject);\n\treturnVal3 = HutongGames.PlayMaker.ActionHelpers::CheckPhysics2dSetup(v50);\n\treturn returnVal3;\nL_0029:\n\treturn \"\";\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string CheckPhysics2dSetup(FsmOwnerDefault ownerDefault)
		{
			if (ownerDefault != null)
			{
				GameObject value = ownerDefault.GameObject.Value;
				return CheckPhysics2dSetup(value);
			}
			return "";
		}

		[Token(Token = "0x6000320")]
		[Address(RVA = "0xA10B7C", Offset = "0xA10B7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.ActionHelpers::CheckPhysics2dSetup(gameObject);\n\treturn returnVal1;\n")]
		public static string CheckOwnerPhysics2dSetup(GameObject gameObject)
		{
			return CheckPhysics2dSetup(gameObject);
		}

		[Token(Token = "0x6000321")]
		[Address(RVA = "0xA10A28", Offset = "0xA10A28", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EBB010]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D00]) = v42;\nL_0020:\n\tgoto L_0029;\n\tv54 = *([v49 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tv64 = UnityEngine.Object::op_Inequality(gameObject, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0075;\n\tv101 = UnityEngine.GameObject::GetComponent(gameObject);\n\tgoto L_0043;\n\tv129 = *([v88 @ X8_v11+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0043;\n\tv136 = v88;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v136, v100, v63, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0043:\n\tv80 = UnityEngine.Object::op_Equality(v101, 0);\n\tv83 = v80 == 0;\n\tif (v83) goto L_0075;\n\tv142 = UnityEngine.GameObject::GetComponent(gameObject);\n\tgoto L_005B;\n\tv146 = *([v89 @ X8_v14+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_005B;\n\tv153 = v89;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v153, v141, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005B:\n\tv81 = UnityEngine.Object::op_Equality(v142, 0);\n\tv84 = v81 == 0;\n\tif (v84) goto L_0075;\n\treturnVal3 = System.String::Concat(v48.Empty, \"GameObject requires a RigidBody2D or Collider2D component!\\n\");\n\treturn returnVal3;\nL_0075:\n\treturn v48.Empty;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string CheckPhysics2dSetup(GameObject gameObject)
		{
			if (gameObject != null)
			{
				Collider2D component = gameObject.GetComponent<Collider2D>();
				if (component == null)
				{
					Rigidbody2D component2 = gameObject.GetComponent<Rigidbody2D>();
					if (component2 == null)
					{
						return string.Empty + "GameObject requires a RigidBody2D or Collider2D component!\n";
					}
				}
			}
			return string.Empty;
		}

		[Token(Token = "0x6000322")]
		[Address(RVA = "0xA10B80", Offset = "0xA10B80", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1EF33D8]);\n\tv33 = *([v32 @ X8_v32]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, logLevel, text, sendToUnityLog, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2021D01]) = v49;\nL_001B:\n\tv51 = UnityEngine.Application::get_isEditor();\n\tv53 = v51 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_006C;\n\tv56 = v230 == 0;\n\tif (v56) goto L_006C;\n\tv117 = HutongGames.PlayMaker.ActionHelpers::FormatUnityLogString(text);\n\tv83 = logLevel == 2;\n\tif (v83) goto L_004F;\n\tv62 = logLevel != 1;\n\tif (v62) goto L_005D;\n\tgoto L_0049;\n\tv203 = *([v153 @ X0_v36+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tif (v205) goto L_0049;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v153, logLevel, text, sendToUnityLog, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0049:\n\tUnityEngine.Debug::LogWarning(v117);\n\tgoto L_006C;\nL_004F:\n\tgoto L_0057;\n\tv161 = *([v144 @ X0_v28+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0057;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v144, logLevel, text, sendToUnityLog, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0057:\n\tUnityEngine.Debug::LogError(v117);\n\tgoto L_006C;\nL_005D:\n\tgoto L_0065;\n\tv208 = *([v157 @ X0_v32+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0065;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v157, logLevel, text, sendToUnityLog, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0065:\n\tUnityEngine.Debug::Log(v117);\nL_006C:\n\tgoto L_0076;\n\tv118 = *([v112 @ X0_v5+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0076;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v112, v57, text, sendToUnityLog, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0076:\n\tgoto L_007D;\n\tv133 = *([1EB1558]);\n\tv134 = *([v133 @ X8_v17]);\n\tv135 = \"il2cpp_codegen_initialize_method\"(v134, v57, text, sendToUnityLog, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv138 = 0 | 1;\n\t*([2021AA1]) = v138;\nL_007D:\n\tv139 = HutongGames.PlayMaker.FsmLog;\n\tv141 = *([v139 @ X0_v8 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+12F]) & 2;\n\tv142 = v141 == 0;\n\tif (v142) goto L_0085;\n\tv149 = *([v139 @ X0_v8 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]) == 0;\n\tif (v149) goto L_00AC;\nL_0085:\n\tv152 = fsm == 0;\n\tif (v152) goto L_00B8;\nL_0089:\n\tv174 = ~v172.<LoggingEnabled>k__BackingField;\n\tif (v174) goto L_00B8;\n\tv218 = logLevel == 2;\n\tif (v218) goto L_00BB;\n\tv184 = logLevel == 1;\n\tif (v184) goto L_00C3;\n\tv283 = logLevel == 0;\n\tv193 = ~v283;\n\tif (v193) goto L_00B8;\n\tv261 = HutongGames.PlayMaker.Fsm::get_MyLog(fsm);\n\tgoto L_00D3;\nL_00AC:\n\tv213 = fsm == 0;\n\tv170 = ~v213;\n\tif (v170) goto L_0089;\nL_00B8:\n\treturn;\nL_00BB:\n\tv261 = HutongGames.PlayMaker.Fsm::get_MyLog(fsm);\n\tgoto L_00D3;\nL_00C3:\n\tv261 = HutongGames.PlayMaker.Fsm::get_MyLog(fsm);\nL_00D3:\n\tHutongGames.PlayMaker.FsmLog::LogAction(v261, v234, text, v230);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DebugLog(Fsm fsm, LogLevel logLevel, string text, bool sendToUnityLog = false)
		{
			//IL_0236: Expected I, but got O
			bool flag = default(bool);
			if (!Application.isEditor && flag)
			{
				string message = FormatUnityLogString(text);
				switch (logLevel)
				{
				case LogLevel.Warning:
					Debug.LogWarning(message);
					break;
				case LogLevel.Error:
					Debug.LogError(message);
					break;
				default:
					Debug.Log(message);
					break;
				}
			}
			IntPtr intPtr = (IntPtr)typeof(FsmLog);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ X0_v8 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ X0_v8 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if (fsm == null)
					{
						return;
					}
					goto IL_00f1;
				}
			}
			if (fsm != null)
			{
				goto IL_00f1;
			}
			return;
			IL_00f1:
			if (FsmLog.LoggingEnabled)
			{
				FsmLog myLog;
				FsmLogType logType;
				switch (logLevel)
				{
				case LogLevel.Info:
					myLog = fsm.MyLog;
					logType = default(FsmLogType);
					break;
				default:
					return;
				case LogLevel.Error:
					myLog = fsm.MyLog;
					logType = FsmLogType.Error;
					break;
				case LogLevel.Warning:
					myLog = fsm.MyLog;
					logType = FsmLogType.Warning;
					break;
				}
				myLog.LogAction(logType, text, flag);
			}
		}

		[Token(Token = "0x6000323")]
		[Address(RVA = "0xA10F20", Offset = "0xA10F20", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED9F70]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D02]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(v53, 2, text, 1);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogError(string text)
		{
			Fsm executingFsm = FsmExecutionStack.ExecutingFsm;
			DebugLog(executingFsm, LogLevel.Error, text, sendToUnityLog: true);
		}

		[Token(Token = "0x6000324")]
		[Address(RVA = "0xA10F94", Offset = "0xA10F94", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF0EF0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D03]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(v53, 1, text, 1);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogWarning(string text)
		{
			Fsm executingFsm = FsmExecutionStack.ExecutingFsm;
			DebugLog(executingFsm, LogLevel.Warning, text, sendToUnityLog: true);
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0xA10D7C", Offset = "0xA10D7C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F01B60]);\n\tv21 = *([v20 @ X8_v29]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D04]) = v40;\nL_001A:\n\tgoto L_0021;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0021;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv55 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv56 = v55 == 0;\n\tif (v56) goto L_0090;\n\tgoto L_002F;\n\tv67 = *([v57 @ X0_v7+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002F;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv75 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tgoto L_0040;\n\tv115 = *([v111 @ X8_v9+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0040;\n\tv124 = v111;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v124, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0040:\n\tv123 = HutongGames.PlayMaker.Fsm::GetFullFsmLabel(v75);\n\tv127 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv128 = v127 == 0;\n\tif (v128) goto L_005E;\n\tgoto L_0051;\n\tv147 = *([v129 @ X0_v33+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0051;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v129, v122, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\tv154 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingStateName();\n\tv137 = System.String::Concat(v123, \" : \", v154);\nL_005E:\n\tgoto L_0065;\n\tv155 = *([v143 @ X0_v17+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tgoto L_0065;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v143, v88, v85, v82, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0065:\n\tv163 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv166 = v163 == 0;\n\tif (v166) goto L_0087;\n\tgoto L_0073;\n\tv182 = *([v167 @ X0_v24+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0073;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v167, v88, v85, v82, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0073:\n\tv189 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv176 = System.String::Concat(v178, v189.name);\nL_0087:\n\treturnVal2 = System.String::Concat(v178, \" : \", text);\n\treturn returnVal2;\nL_0090:\n\treturn text;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string FormatUnityLogString(string text)
		{
			Fsm executingFsm = FsmExecutionStack.ExecutingFsm;
			if (executingFsm != null)
			{
				Fsm executingFsm2 = FsmExecutionStack.ExecutingFsm;
				string fullFsmLabel = Fsm.GetFullFsmLabel(executingFsm2);
				FsmState executingState = FsmExecutionStack.ExecutingState;
				bool flag = executingState == null;
				string text2 = fullFsmLabel;
				if (!flag)
				{
					string executingStateName = FsmExecutionStack.ExecutingStateName;
					string text3 = fullFsmLabel + " : " + executingStateName;
					text2 = text3;
				}
				FsmStateAction executingAction = FsmExecutionStack.ExecutingAction;
				if (executingAction != null)
				{
					FsmStateAction executingAction2 = FsmExecutionStack.ExecutingAction;
					string text4 = text2 + executingAction2.Name;
					text2 = text4;
				}
				return text2 + " : " + text;
			}
			return text;
		}

		[Token(Token = "0x6000326")]
		[Address(RVA = "0xA11008", Offset = "0xA11008", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F083B8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021D05]) = v35;\nL_0018:\n\treturn \"\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetValueLabel(INamedVariable variable)
		{
			return "";
		}

		[Token(Token = "0x6000327")]
		[Address(RVA = "0xA11050", Offset = "0xA11050", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEE378]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, ownerDefault, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021D06]) = v38;\nL_0013:\n\tv39 = ownerDefault == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv41 = ownerDefault.ownerOption == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv63 = *([1F083B8]);\n\tv64 = *([v63 @ X8_v14]);\n\tv65 = \"il2cpp_codegen_initialize_method\"(v64, ownerDefault, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv67 = 0 | 1;\n\t*([2021D05]) = v67;\n\tgoto L_0032;\n\tgoto L_0032;\nL_0032:\n\treturn *([v55 @ X8_v3 (System.String)]);\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetValueLabel(Fsm fsm, FsmOwnerDefault ownerDefault)
		{
			if (ownerDefault != null)
			{
				if (ownerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
				{
					return "Owner";
				}
				return "";
			}
			return "[null]";
		}

		[Token(Token = "0x6000328")]
		[Address(RVA = "0xA110E4", Offset = "0xA110E4", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = action == 0;\n\tif (v10) goto L_001B;\n\tv13 = System.Object::GetType(action);\n\tv37 = System.Reflection.MemberInfo::get_Name(v13);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::AutoName(v37, exposedFields);\n\treturn returnVal2;\nL_001B:\n\treturn action;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoName(FsmStateAction action, params INamedVariable[] exposedFields)
		{
			if (action != null)
			{
				Type type = action.GetType();
				string name = type.Name;
				return AutoName(name, exposedFields);
			}
			return (string)(object)action;
		}

		[Token(Token = "0x6000329")]
		[Address(RVA = "0xA11130", Offset = "0xA11130", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EC74C0]);\n\tv33 = *([v32 @ X8_v13]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, exposedFields, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2021D07]) = v51;\nL_001F:\n\tv57 = System.String::Concat(actionName, \" :\");\n\tv125 = exposedFields.Length;\n\tv71 = exposedFields.Length < 1;\n\tif (v71) goto L_006C;\nL_003A:\n\tv196 = v83 < v125;\n\tv116 = ~v196;\n\tif (v116) goto L_006D;\n\tgoto L_0050;\n\tv227 = v127;\n\tv228 = \"il2cpp_codegen_initialize_method\"(v227, v186, v185, v73, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\t*([2021D05]) = v79;\nL_0050:\n\tv166 = System.String::Concat(v123, \" \", \"\");\n\tv125 = exposedFields.Length;\n\tv83 = v83 + 1;\n\tv148 = v83 < exposedFields.Length;\n\tif (v148) goto L_003A;\nL_006C:\n\treturn v169;\nL_006D:\n\tv226 = new System.IndexOutOfRangeException();\n\tthrow v226;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoName(string actionName, params INamedVariable[] exposedFields)
		{
			string text = actionName + " :";
			int num = exposedFields.Length;
			bool flag = exposedFields.Length < 1;
			string result = text;
			if (!flag)
			{
				int num2 = 0;
				string text2 = text;
				bool flag2;
				do
				{
					if (num2 >= num)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					string text3 = text2 + " " + "";
					num = exposedFields.Length;
					num2++;
					flag2 = num2 < exposedFields.Length;
					result = text3;
					text2 = text3;
				}
				while (flag2);
			}
			return result;
		}

		[Token(Token = "0x600032A")]
		[Address(RVA = "0xA11240", Offset = "0xA11240", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = action == 0;\n\tif (v14) goto L_0020;\n\tv17 = System.Object::GetType(action);\n\tv46 = System.Reflection.MemberInfo::get_Name(v17);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::AutoNameRange(v46, min, max);\n\treturn returnVal2;\nL_0020:\n\treturn action;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameRange(FsmStateAction action, NamedVariable min, NamedVariable max)
		{
			if (action != null)
			{
				Type type = action.GetType();
				string name = type.Name;
				return AutoNameRange(name, min, max);
			}
			return (string)(object)action;
		}

		[Token(Token = "0x600032B")]
		[Address(RVA = "0xA11294", Offset = "0xA11294", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE0418]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, min, max, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D08]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv50 = actionName == 0;\n\tif (v50) goto L_0025;\n\t// 34 IsInst v98 @ X0_v34, typeof(System.String), actionName @ X0 (System.String)\nL_0025:\n\tv181 = v47.Length;\n\tv105 = v47.Length == 0;\n\tif (v105) goto L_00AD;\n\tv47[0] = actionName;\n\tv109 = \" : \" == 0;\n\tif (v109) goto L_0034;\n\t// 48 IsInst v229 @ X0_v32, typeof(System.String), \" : \"\n\tv181 = v47.Length;\nL_0034:\n\tv246 = v181 < 1;\n\tv155 = ~v246;\n\tv150 = v181 - 1;\n\tv140 = v150 == 0;\n\tv247 = ~v155;\n\tv115 = v247 | v140;\n\tif (v115) goto L_00AD;\n\tv47[1] = \" : \";\n\tgoto L_0051;\n\tv256 = *([1F083B8]);\n\tv257 = *([v256 @ X8_v31]);\n\tv258 = \"il2cpp_codegen_initialize_method\"(v257, v162, max, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv261 = 0 | 1;\n\t*([2021D05]) = v261;\nL_0051:\n\tv263 = \"\" == 0;\n\tif (v263) goto L_0059;\n\t// 86 IsInst v230 @ X0_v29, typeof(System.String), \"\"\nL_0059:\n\tv182 = v47.Length;\n\tv266 = v47.Length < 2;\n\tv153 = ~v266;\n\tv148 = v47.Length - 2;\n\tv138 = v148 == 0;\n\tv267 = ~v153;\n\tv113 = v267 | v138;\n\tif (v113) goto L_00AD;\n\tv47[2] = \"\";\n\tv270 = \" - \" == 0;\n\tif (v270) goto L_0072;\n\t// 110 IsInst v231 @ X0_v27, typeof(System.String), \" - \"\n\tv182 = v47.Length;\nL_0072:\n\tv272 = v182 < 3;\n\tv156 = ~v272;\n\tv151 = v182 - 3;\n\tv141 = v151 == 0;\n\tv273 = ~v156;\n\tv116 = v273 | v141;\n\tif (v116) goto L_00AD;\n\tv47[3] = \" - \";\n\tgoto L_008C;\n\tv280 = *([1F083B8]);\n\tv281 = *([v280 @ X8_v25]);\n\tv282 = \"il2cpp_codegen_initialize_method\"(v281, v163, max, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv285 = 0 | 1;\n\t*([2021D05]) = v285;\nL_008C:\n\tv286 = \"\" == 0;\n\tif (v286) goto L_0095;\n\t// 145 IsInst v232 @ X0_v24, typeof(System.String), \"\"\nL_0095:\n\tv289 = v47.Length < 4;\n\tv154 = ~v289;\n\tv149 = v47.Length - 4;\n\tv139 = v149 == 0;\n\tv290 = ~v154;\n\tv114 = v290 | v139;\n\tif (v114) goto L_00AD;\n\tv47[4] = \"\";\n\treturnVal2 = System.String::Concat(v47);\n\treturn returnVal2;\nL_00AD:\n\tv183 = new System.IndexOutOfRangeException();\n\tgoto L_00B2;\n\tv244 = new System.ArrayTypeMismatchException();\nL_00B2:\n\tthrow v249;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameRange(string actionName, NamedVariable min, NamedVariable max)
		{
			//IL_003e: Expected O, but got I4
			//IL_0298: Expected O, but got I
			//IL_00aa: Expected O, but got I4
			//IL_00e4: Expected O, but got I4
			//IL_0110: Expected O, but got I4
			//IL_0314: Expected O, but got I
			//IL_0193: Expected O, but got I4
			//IL_01ef: Expected O, but got I4
			string[] array = new string[5];
			if (actionName != null)
			{
				object obj = actionName as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = actionName;
				if (" : " != null)
				{
					object obj3 = " : " as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = " : ";
					if ("" != null)
					{
						object obj5 = "" as string;
					}
					object obj6 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "";
						if (" - " != null)
						{
							object obj8 = " - " as string;
							obj6 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj6 < 3L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj6 - 3L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = " - ";
							if ("" != null)
							{
								object obj10 = "" as string;
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj11 = array.Length - 4;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "";
								return string.Concat(array);
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600032C")]
		[Address(RVA = "0xA1144C", Offset = "0xA1144C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = action == 0;\n\tif (v14) goto L_0020;\n\tv17 = System.Object::GetType(action);\n\tv46 = System.Reflection.MemberInfo::get_Name(v17);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::AutoNameSetVar(v46, var, value);\n\treturn returnVal2;\nL_0020:\n\treturn action;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameSetVar(FsmStateAction action, NamedVariable var, NamedVariable value)
		{
			if (action != null)
			{
				Type type = action.GetType();
				string name = type.Name;
				return AutoNameSetVar(name, var, value);
			}
			return (string)(object)action;
		}

		[Token(Token = "0x600032D")]
		[Address(RVA = "0xA114A0", Offset = "0xA114A0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF37F8]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, var, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D09]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv50 = actionName == 0;\n\tif (v50) goto L_0025;\n\t// 34 IsInst v98 @ X0_v34, typeof(System.String), actionName @ X0 (System.String)\nL_0025:\n\tv181 = v47.Length;\n\tv105 = v47.Length == 0;\n\tif (v105) goto L_00AD;\n\tv47[0] = actionName;\n\tv109 = \" : \" == 0;\n\tif (v109) goto L_0034;\n\t// 48 IsInst v229 @ X0_v32, typeof(System.String), \" : \"\n\tv181 = v47.Length;\nL_0034:\n\tv246 = v181 < 1;\n\tv155 = ~v246;\n\tv150 = v181 - 1;\n\tv140 = v150 == 0;\n\tv247 = ~v155;\n\tv115 = v247 | v140;\n\tif (v115) goto L_00AD;\n\tv47[1] = \" : \";\n\tgoto L_0051;\n\tv256 = *([1F083B8]);\n\tv257 = *([v256 @ X8_v31]);\n\tv258 = \"il2cpp_codegen_initialize_method\"(v257, v162, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv261 = 0 | 1;\n\t*([2021D05]) = v261;\nL_0051:\n\tv263 = \"\" == 0;\n\tif (v263) goto L_0059;\n\t// 86 IsInst v230 @ X0_v29, typeof(System.String), \"\"\nL_0059:\n\tv182 = v47.Length;\n\tv266 = v47.Length < 2;\n\tv153 = ~v266;\n\tv148 = v47.Length - 2;\n\tv138 = v148 == 0;\n\tv267 = ~v153;\n\tv113 = v267 | v138;\n\tif (v113) goto L_00AD;\n\tv47[2] = \"\";\n\tv270 = \" = \" == 0;\n\tif (v270) goto L_0072;\n\t// 110 IsInst v231 @ X0_v27, typeof(System.String), \" = \"\n\tv182 = v47.Length;\nL_0072:\n\tv272 = v182 < 3;\n\tv156 = ~v272;\n\tv151 = v182 - 3;\n\tv141 = v151 == 0;\n\tv273 = ~v156;\n\tv116 = v273 | v141;\n\tif (v116) goto L_00AD;\n\tv47[3] = \" = \";\n\tgoto L_008C;\n\tv280 = *([1F083B8]);\n\tv281 = *([v280 @ X8_v25]);\n\tv282 = \"il2cpp_codegen_initialize_method\"(v281, v163, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv285 = 0 | 1;\n\t*([2021D05]) = v285;\nL_008C:\n\tv286 = \"\" == 0;\n\tif (v286) goto L_0095;\n\t// 145 IsInst v232 @ X0_v24, typeof(System.String), \"\"\nL_0095:\n\tv289 = v47.Length < 4;\n\tv154 = ~v289;\n\tv149 = v47.Length - 4;\n\tv139 = v149 == 0;\n\tv290 = ~v154;\n\tv114 = v290 | v139;\n\tif (v114) goto L_00AD;\n\tv47[4] = \"\";\n\treturnVal2 = System.String::Concat(v47);\n\treturn returnVal2;\nL_00AD:\n\tv183 = new System.IndexOutOfRangeException();\n\tgoto L_00B2;\n\tv244 = new System.ArrayTypeMismatchException();\nL_00B2:\n\tthrow v249;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameSetVar(string actionName, NamedVariable var, NamedVariable value)
		{
			//IL_003e: Expected O, but got I4
			//IL_0298: Expected O, but got I
			//IL_00aa: Expected O, but got I4
			//IL_00e4: Expected O, but got I4
			//IL_0110: Expected O, but got I4
			//IL_0314: Expected O, but got I
			//IL_0193: Expected O, but got I4
			//IL_01ef: Expected O, but got I4
			string[] array = new string[5];
			if (actionName != null)
			{
				object obj = actionName as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = actionName;
				if (" : " != null)
				{
					object obj3 = " : " as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = " : ";
					if ("" != null)
					{
						object obj5 = "" as string;
					}
					object obj6 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "";
						if (" = " != null)
						{
							object obj8 = " = " as string;
							obj6 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj6 < 3L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj6 - 3L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = " = ";
							if ("" != null)
							{
								object obj10 = "" as string;
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj11 = array.Length - 4;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "";
								return string.Concat(array);
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600032E")]
		[Address(RVA = "0xA11658", Offset = "0xA11658", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = action == 0;\n\tif (v14) goto L_0020;\n\tv17 = System.Object::GetType(action);\n\tv46 = System.Reflection.MemberInfo::get_Name(v17);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::AutoNameConvert(v46, fromVariable, toVariable);\n\treturn returnVal2;\nL_0020:\n\treturn action;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameConvert(FsmStateAction action, NamedVariable fromVariable, NamedVariable toVariable)
		{
			if (action != null)
			{
				Type type = action.GetType();
				string name = type.Name;
				return AutoNameConvert(name, fromVariable, toVariable);
			}
			return (string)(object)action;
		}

		[Token(Token = "0x600032F")]
		[Address(RVA = "0xA116AC", Offset = "0xA116AC", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1F098D8]);\n\tv23 = *([v22 @ X8_v40]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fromVariable, toVariable, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D0A]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv58 = System.String::Replace(actionName, \"Convert\", \"\");\n\tv106 = v58 == 0;\n\tif (v106) goto L_0031;\n\t// 46 IsInst v150 @ X0_v37, typeof(System.String), v58 @ X0_v8 (System.String)\nL_0031:\n\tv220 = v47.Length;\n\tv157 = v47.Length == 0;\n\tif (v157) goto L_00B7;\n\tv47[0] = v58;\n\tv161 = \" : \" == 0;\n\tif (v161) goto L_0040;\n\t// 60 IsInst v239 @ X0_v35, typeof(System.String), \" : \"\n\tv220 = v47.Length;\nL_0040:\n\tv256 = v220 < 1;\n\tv196 = ~v256;\n\tv192 = v220 - 1;\n\tv184 = v192 == 0;\n\tv257 = ~v196;\n\tv164 = v257 | v184;\n\tif (v164) goto L_00B7;\n\tv47[1] = \" : \";\n\tgoto L_005B;\n\tv266 = *([1F083B8]);\n\tv267 = *([v266 @ X8_v33]);\n\tv268 = \"il2cpp_codegen_initialize_method\"(v267, v203, v57, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv271 = 0 | 1;\n\t*([2021D05]) = v271;\nL_005B:\n\tv272 = \"\" == 0;\n\tif (v272) goto L_0063;\n\t// 96 IsInst v240 @ X0_v32, typeof(System.String), \"\"\nL_0063:\n\tv221 = v47.Length;\n\tv275 = v47.Length < 2;\n\tv195 = ~v275;\n\tv191 = v47.Length - 2;\n\tv183 = v191 == 0;\n\tv276 = ~v195;\n\tv163 = v276 | v183;\n\tif (v163) goto L_00B7;\n\tv47[2] = \"\";\n\tv279 = \" to \" == 0;\n\tif (v279) goto L_007C;\n\t// 120 IsInst v241 @ X0_v30, typeof(System.String), \" to \"\n\tv221 = v47.Length;\nL_007C:\n\tv281 = v221 < 3;\n\tv197 = ~v281;\n\tv193 = v221 - 3;\n\tv185 = v193 == 0;\n\tv282 = ~v197;\n\tv165 = v282 | v185;\n\tif (v165) goto L_00B7;\n\tv47[3] = \" to \";\n\tgoto L_0096;\n\tv289 = *([1F083B8]);\n\tv290 = *([v289 @ X8_v27]);\n\tv291 = \"il2cpp_codegen_initialize_method\"(v290, v204, v57, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv294 = 0 | 1;\n\t*([2021D05]) = v294;\nL_0096:\n\tv295 = \"\" == 0;\n\tif (v295) goto L_009F;\n\t// 155 IsInst v242 @ X0_v27, typeof(System.String), \"\"\nL_009F:\n\tv298 = v47.Length < 4;\n\tv126 = ~v298;\n\tv124 = v47.Length - 4;\n\tv120 = v124 == 0;\n\tv299 = ~v126;\n\tv110 = v299 | v120;\n\tif (v110) goto L_00B7;\n\tv47[4] = \"\";\n\treturnVal2 = System.String::Concat(v47);\n\treturn returnVal2;\nL_00B7:\n\tv222 = new System.IndexOutOfRangeException();\n\tgoto L_00BC;\n\tv254 = new System.ArrayTypeMismatchException();\nL_00BC:\n\tthrow v259;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameConvert(string actionName, NamedVariable fromVariable, NamedVariable toVariable)
		{
			//IL_005a: Expected O, but got I4
			//IL_02b4: Expected O, but got I
			//IL_00c6: Expected O, but got I4
			//IL_0100: Expected O, but got I4
			//IL_012c: Expected O, but got I4
			//IL_0330: Expected O, but got I
			//IL_01af: Expected O, but got I4
			//IL_020b: Expected O, but got I4
			string[] array = new string[5];
			string text = actionName.Replace("Convert", "");
			if (text != null)
			{
				object obj = text as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = text;
				if (" : " != null)
				{
					object obj3 = " : " as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = " : ";
					if ("" != null)
					{
						object obj5 = "" as string;
					}
					object obj6 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "";
						if (" to " != null)
						{
							object obj8 = " to " as string;
							obj6 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj6 < 3L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj6 - 3L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = " to ";
							if ("" != null)
							{
								object obj10 = "" as string;
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj11 = array.Length - 4;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "";
								return string.Concat(array);
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000330")]
		[Address(RVA = "0xA1188C", Offset = "0xA1188C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = action == 0;\n\tif (v14) goto L_0020;\n\tv17 = System.Object::GetType(action);\n\tv46 = System.Reflection.MemberInfo::get_Name(v17);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::AutoNameGetProperty(v46, property, store);\n\treturn returnVal2;\nL_0020:\n\treturn action;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameGetProperty(FsmStateAction action, NamedVariable property, NamedVariable store)
		{
			if (action != null)
			{
				Type type = action.GetType();
				string name = type.Name;
				return AutoNameGetProperty(name, property, store);
			}
			return (string)(object)action;
		}

		[Token(Token = "0x6000331")]
		[Address(RVA = "0xA118E0", Offset = "0xA118E0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1F0B460]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, property, store, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D0B]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv50 = actionName == 0;\n\tif (v50) goto L_0025;\n\t// 34 IsInst v98 @ X0_v34, typeof(System.String), actionName @ X0 (System.String)\nL_0025:\n\tv181 = v47.Length;\n\tv105 = v47.Length == 0;\n\tif (v105) goto L_00AD;\n\tv47[0] = actionName;\n\tv109 = \" : \" == 0;\n\tif (v109) goto L_0034;\n\t// 48 IsInst v229 @ X0_v32, typeof(System.String), \" : \"\n\tv181 = v47.Length;\nL_0034:\n\tv246 = v181 < 1;\n\tv155 = ~v246;\n\tv150 = v181 - 1;\n\tv140 = v150 == 0;\n\tv247 = ~v155;\n\tv115 = v247 | v140;\n\tif (v115) goto L_00AD;\n\tv47[1] = \" : \";\n\tgoto L_0051;\n\tv256 = *([1F083B8]);\n\tv257 = *([v256 @ X8_v31]);\n\tv258 = \"il2cpp_codegen_initialize_method\"(v257, v162, store, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv261 = 0 | 1;\n\t*([2021D05]) = v261;\nL_0051:\n\tv263 = \"\" == 0;\n\tif (v263) goto L_0059;\n\t// 86 IsInst v230 @ X0_v29, typeof(System.String), \"\"\nL_0059:\n\tv182 = v47.Length;\n\tv266 = v47.Length < 2;\n\tv153 = ~v266;\n\tv148 = v47.Length - 2;\n\tv138 = v148 == 0;\n\tv267 = ~v153;\n\tv113 = v267 | v138;\n\tif (v113) goto L_00AD;\n\tv47[2] = \"\";\n\tv270 = \" -> \" == 0;\n\tif (v270) goto L_0072;\n\t// 110 IsInst v231 @ X0_v27, typeof(System.String), \" -> \"\n\tv182 = v47.Length;\nL_0072:\n\tv272 = v182 < 3;\n\tv156 = ~v272;\n\tv151 = v182 - 3;\n\tv141 = v151 == 0;\n\tv273 = ~v156;\n\tv116 = v273 | v141;\n\tif (v116) goto L_00AD;\n\tv47[3] = \" -> \";\n\tgoto L_008C;\n\tv280 = *([1F083B8]);\n\tv281 = *([v280 @ X8_v25]);\n\tv282 = \"il2cpp_codegen_initialize_method\"(v281, v163, store, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv285 = 0 | 1;\n\t*([2021D05]) = v285;\nL_008C:\n\tv286 = \"\" == 0;\n\tif (v286) goto L_0095;\n\t// 145 IsInst v232 @ X0_v24, typeof(System.String), \"\"\nL_0095:\n\tv289 = v47.Length < 4;\n\tv154 = ~v289;\n\tv149 = v47.Length - 4;\n\tv139 = v149 == 0;\n\tv290 = ~v154;\n\tv114 = v290 | v139;\n\tif (v114) goto L_00AD;\n\tv47[4] = \"\";\n\treturnVal2 = System.String::Concat(v47);\n\treturn returnVal2;\nL_00AD:\n\tv183 = new System.IndexOutOfRangeException();\n\tgoto L_00B2;\n\tv244 = new System.ArrayTypeMismatchException();\nL_00B2:\n\tthrow v249;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoNameGetProperty(string actionName, NamedVariable property, NamedVariable store)
		{
			//IL_003e: Expected O, but got I4
			//IL_0298: Expected O, but got I
			//IL_00aa: Expected O, but got I4
			//IL_00e4: Expected O, but got I4
			//IL_0110: Expected O, but got I4
			//IL_0314: Expected O, but got I
			//IL_0193: Expected O, but got I4
			//IL_01ef: Expected O, but got I4
			string[] array = new string[5];
			if (actionName != null)
			{
				object obj = actionName as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = actionName;
				if (" : " != null)
				{
					object obj3 = " : " as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = " : ";
					if ("" != null)
					{
						object obj5 = "" as string;
					}
					object obj6 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "";
						if (" -> " != null)
						{
							object obj8 = " -> " as string;
							obj6 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj6 < 3L;
						bool flag10 = !flag9;
						object obj9 = (long)(IntPtr)obj6 - 3L;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = " -> ";
							if ("" != null)
							{
								object obj10 = "" as string;
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj11 = array.Length - 4;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "";
								return string.Concat(array);
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Obsolete]
		[Token(Token = "0x6000332")]
		[Address(RVA = "0xA11A98", Offset = "0xA11A98", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEFB60]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, error, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021D0C]) = v41;\nL_001B:\n\tv48 = System.String::Concat(action, \" : \", error);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(action, v48);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RuntimeError(FsmStateAction action, string error)
		{
			string text = string.Concat(action, " : ", error);
			action.LogError(text);
		}
	}
}
