using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal.Gif;
using EasyMobile.Internal.Gif.Android;
using UnityEngine;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7311AC", Offset = "0x7311AC")]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000057")]
	public class Gif : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000127")]
		private sealed class _003C_003Ec__DisplayClass16_0
		{
			[Token(Token = "0x4000503")]
			[FieldOffset(Offset = "0x10")]
			public Action<AnimatedClip> completeCallback;

			[Token(Token = "0x6000988")]
			[Address(RVA = "0xBF2750", Offset = "0xBF2750", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass16_0()
			{
			}

			internal void _003CDecodeGif_003Eb__0(int taskId, GifMetadata gifMetadata, GifFrameMetadata[] gifFrameMetadata, Color32[][] imageData)
			{
				//IL_001d: Expected O, but got I8
				if (completeCallback != null)
				{
					GifFrameMetadata[] gifFrameMetadata2 = (GifFrameMetadata[])((long)(IntPtr)gifFrameMetadata & 0xFFFFFFFFL);
					AnimatedClip obj = ToAnimatedClip(gifMetadata, gifFrameMetadata2, imageData);
					completeCallback(obj);
				}
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000128")]
		private sealed class _003C_003Ec__DisplayClass17_0
		{
			[Token(Token = "0x4000504")]
			[FieldOffset(Offset = "0x10")]
			public Action<Texture[]> completeCallback;

			[Token(Token = "0x600098A")]
			[Address(RVA = "0xBF2960", Offset = "0xBF2960", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass17_0()
			{
			}

			internal void _003CDecodeGif_003Eb__0(int taskId, GifMetadata gifMetadata, GifFrameMetadata[] gifFrameMetadata, Color32[][] imageData)
			{
				//IL_001d: Expected O, but got I8
				if (completeCallback != null)
				{
					GifFrameMetadata[] gifFrameMetadata2 = (GifFrameMetadata[])((long)(IntPtr)gifFrameMetadata & 0xFFFFFFFFL);
					Texture[] obj = ToTextureArray(gifMetadata, gifFrameMetadata2, imageData);
					completeCallback(obj);
				}
			}
		}

		[Token(Token = "0x4000209")]
		private static Gif _instance;

		[Token(Token = "0x400020A")]
		private static Dictionary<int, GifExportTask> gifExportTasks;

		[Token(Token = "0x400020B")]
		private static int curExportId;

		[Token(Token = "0x400020C")]
		private static int curDecodeId;

		[Token(Token = "0x17000148")]
		public static Gif Instance
		{
			[Token(Token = "0x6000451")]
			[Address(RVA = "0xBF1B64", Offset = "0xBF1B64", Length = "0x164")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC6EC0]);\n\tv21 = *([v20 @ X8_v27]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2022EB5]) = v41;\nL_001A:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = EasyMobile.Gif;\nL_0029:\n\tgoto L_0033;\n\tv64 = *([v58 @ X8_v5+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0033;\n\tv75 = v58;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v75, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv74 = UnityEngine.Object::op_Equality(v57._instance, 0);\n\tv77 = v74 == 0;\n\tif (v77) goto L_0068;\n\tv81 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v81, \"Gif\");\n\tv139 = UnityEngine.GameObject::AddComponent(v81);\n\tgoto L_0056;\n\tv145 = *([v141 @ X8_v17 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0056;\n\tv158 = v141;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v158, v138, v85, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv152 = EasyMobile.Gif;\nL_0056:\n\tv153._instance = v139;\n\tgoto L_0063;\n\tv159 = *([v154 @ X0_v20+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tgoto L_0063;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v154, v138, v85, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0063:\n\tUnityEngine.Object::DontDestroyOnLoad(v81);\nL_0068:\n\tgoto L_0078;\n\tv105 = *([v98 @ X0_v8 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0078;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v98, v86, v84, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv109 = EasyMobile.Gif;\nL_0078:\n\treturn v112._instance;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (_instance == null)
				{
					GameObject gameObject = new GameObject("Gif");
					Gif instance = gameObject.AddComponent<Gif>();
					_instance = instance;
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
				return _instance;
			}
		}

		[Token(Token = "0x6000452")]
		[Address(RVA = "0xBF1CC8", Offset = "0xBF1CC8", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF5480]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EB6]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Equality(recorder, 0);\n\tv57 = v55 == 0;\n\tif (v57) goto L_0041;\n\tgoto L_003B;\n\tv65 = *([v60 @ X0_v15+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003B;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v60, v53, v54, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003B:\n\tUnityEngine.Debug::LogError(\"StartRecording FAILED: recorder is null.\");\n\treturn;\nL_0041:\n\tv82 = EasyMobile.Recorder::IsRecording(recorder);\n\tv86 = v82 == 0;\n\tif (v86) goto L_0063;\n\tgoto L_005A;\n\tv115 = *([v111 @ X0_v11+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_005A;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v111, v81, v54, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005A:\n\tUnityEngine.Debug::LogWarning(\"Attempted to start recording while it is already in progress.\");\n\treturn;\nL_0063:\n\tEasyMobile.Recorder::Record(recorder);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartRecording(Recorder recorder)
		{
			if (recorder == null)
			{
				Debug.LogError("StartRecording FAILED: recorder is null.");
			}
			else if (recorder.IsRecording())
			{
				Debug.LogWarning("Attempted to start recording while it is already in progress.");
			}
			else
			{
				recorder.Record();
			}
		}

		[Token(Token = "0x6000453")]
		[Address(RVA = "0xBF1DD8", Offset = "0xBF1DD8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB50A0]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EB7]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Equality(recorder, 0);\n\tv57 = v55 == 0;\n\tif (v57) goto L_0047;\n\tgoto L_0036;\n\tv65 = *([v60 @ X0_v10+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0036;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v60, v53, v54, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0036:\n\tUnityEngine.Debug::LogError(\"StopRecording FAILED: recorder is null.\");\n\treturn 0;\nL_0047:\n\treturnVal2 = EasyMobile.Recorder::Stop(recorder);\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AnimatedClip StopRecording(Recorder recorder)
		{
			if (recorder == null)
			{
				Debug.LogError("StopRecording FAILED: recorder is null.");
				return null;
			}
			return recorder.Stop();
		}

		[Token(Token = "0x6000454")]
		[Address(RVA = "0xBF1EA4", Offset = "0xBF1EA4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0EF38]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EB8]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Inequality(recorder, 0);\n\tv57 = v55 == 0;\n\tif (v57) goto L_0037;\n\treturnVal2 = EasyMobile.Recorder::IsRecording(recorder);\n\treturn returnVal2;\nL_0037:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRecording(Recorder recorder)
		{
			if (recorder != null)
			{
				return recorder.IsRecording();
			}
			return false;
		}

		[Token(Token = "0x6000455")]
		[Address(RVA = "0xBF1F3C", Offset = "0xBF1F3C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F07390]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022EB9]) = v47;\nL_0019:\n\tv48 = player == 0;\n\tif (v48) goto L_0047;\n\tv50 = player->klass;\n\tv54 = *([v50 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]) == 0;\n\tif (v54) goto L_003F;\n\tv130 = *([v50 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+B0]) + 8;\nL_002A:\n\tv136 = *([v130 @ X11_v5-8]) == EasyMobile.IClipPlayer;\n\tif (v136) goto L_005C;\n\tv131 = v131 + 1;\n\tv141 = v131 < *([v50 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]);\n\tv92 = ~v141;\n\tv130 = v130 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_002A;\nL_003F:\n\tv163 = 0x8909C4(player, EasyMobile.IClipPlayer, 2, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0060;\nL_0047:\n\tgoto L_0059;\n\tv102 = *([v57 @ X0_v2+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0059;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v57, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\nL_0059:\n\tUnityEngine.Debug::LogError(\"Player is null.\");\n\treturn;\nL_005C:\n\tv143 = *([v130 @ X11_v5]) + 2;\n\tv144 = v143 << 4;\n\tv145 = v50 + v144;\n\tv163 = v145 + 0x130;\nL_0060:\n\tv165 = *([v163 @ X0_v6]);\n\tv166 = *([v163 @ X0_v6+8]);\n\t// 110 IndirectJump v165 @ X4_v1, player @ X0 (EasyMobile.IClipPlayer), player @ X0 (EasyMobile.IClipPlayer), clip @ X1 (EasyMobile.AnimatedClip), loop @ X2 (System.Boolean), v166 @ X3_v1, v165 @ X4_v1, v35 @ X5, v36 @ X6, v37 @ X7, startDelay @ V0 (System.Single), v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PlayClip(IClipPlayer player, AnimatedClip clip, float startDelay = 0f, bool loop = true)
		{
			//IL_000d: Expected I, but got O
			//IL_016f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_00fc: Expected O, but got I
			//IL_010b: Expected O, but got I
			//IL_0094: Expected O, but got I
			object obj4 = default(object);
			if (player != null)
			{
				IntPtr intPtr = (IntPtr)player;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IClipPlayer))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 2;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0157;
			}
			Debug.LogError("Player is null.");
			return;
			IL_0157:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v165 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0157;
		}

		[Token(Token = "0x6000456")]
		[Address(RVA = "0xBF2054", Offset = "0xBF2054", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB0748]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EBA]) = v38;\nL_0013:\n\tv39 = player == 0;\n\tif (v39) goto L_0041;\n\tv41 = player->klass;\n\tv45 = *([v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]) == 0;\n\tif (v45) goto L_0039;\n\tv118 = *([v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+B0]) + 8;\nL_0024:\n\tv124 = *([v118 @ X11_v5-8]) == EasyMobile.IClipPlayer;\n\tif (v124) goto L_0053;\n\tv119 = v119 + 1;\n\tv129 = v119 < *([v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]);\n\tv83 = ~v129;\n\tv118 = v118 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0024;\nL_0039:\n\tv151 = 0x8909C4(player, EasyMobile.IClipPlayer, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0057;\nL_0041:\n\tgoto L_0050;\n\tv93 = *([v48 @ X0_v2+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0050;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tUnityEngine.Debug::LogError(\"Player is null.\");\n\treturn;\nL_0053:\n\tv131 = *([v118 @ X11_v5]) + 3;\n\tv132 = v131 << 4;\n\tv133 = v41 + v132;\n\tv151 = v133 + 0x130;\nL_0057:\n\tv153 = *([v151 @ X0_v6]);\n\tv154 = *([v151 @ X0_v6+8]);\n\t// 95 IndirectJump v153 @ X2_v2, player @ X0 (EasyMobile.IClipPlayer), player @ X0 (EasyMobile.IClipPlayer), v154 @ X1_v3, v153 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PausePlayer(IClipPlayer player)
		{
			//IL_000d: Expected I, but got O
			//IL_016f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_00fc: Expected O, but got I
			//IL_010b: Expected O, but got I
			//IL_0094: Expected O, but got I
			object obj4 = default(object);
			if (player != null)
			{
				IntPtr intPtr = (IntPtr)player;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IClipPlayer))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0157;
			}
			Debug.LogError("Player is null.");
			return;
			IL_0157:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v153 @ X2_v2 (should have been resolved before IL gen)");
			return;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0157;
		}

		[Token(Token = "0x6000457")]
		[Address(RVA = "0xBF213C", Offset = "0xBF213C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB8660]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EBB]) = v38;\nL_0013:\n\tv39 = player == 0;\n\tif (v39) goto L_0041;\n\tv41 = player->klass;\n\tv45 = *([v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]) == 0;\n\tif (v45) goto L_0039;\n\tv118 = *([v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+B0]) + 8;\nL_0024:\n\tv124 = *([v118 @ X11_v5-8]) == EasyMobile.IClipPlayer;\n\tif (v124) goto L_0053;\n\tv119 = v119 + 1;\n\tv129 = v119 < *([v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]);\n\tv83 = ~v129;\n\tv118 = v118 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0024;\nL_0039:\n\tv151 = 0x8909C4(player, EasyMobile.IClipPlayer, 4, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0057;\nL_0041:\n\tgoto L_0050;\n\tv93 = *([v48 @ X0_v2+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0050;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tUnityEngine.Debug::LogError(\"Player is null.\");\n\treturn;\nL_0053:\n\tv131 = *([v118 @ X11_v5]) + 4;\n\tv132 = v131 << 4;\n\tv133 = v41 + v132;\n\tv151 = v133 + 0x130;\nL_0057:\n\tv153 = *([v151 @ X0_v6]);\n\tv154 = *([v151 @ X0_v6+8]);\n\t// 95 IndirectJump v153 @ X2_v2, player @ X0 (EasyMobile.IClipPlayer), player @ X0 (EasyMobile.IClipPlayer), v154 @ X1_v3, v153 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ResumePlayer(IClipPlayer player)
		{
			//IL_000d: Expected I, but got O
			//IL_016f: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_00fc: Expected O, but got I
			//IL_010b: Expected O, but got I
			//IL_0094: Expected O, but got I
			object obj4 = default(object);
			if (player != null)
			{
				IntPtr intPtr = (IntPtr)player;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IClipPlayer))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v10 (Il2CppClass<EasyMobile.IClipPlayer>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 4;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0157;
			}
			Debug.LogError("Player is null.");
			return;
			IL_0157:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v153 @ X2_v2 (should have been resolved before IL gen)");
			return;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0157;
		}

		[Token(Token = "0x6000458")]
		[Address(RVA = "0xBF2224", Offset = "0xBF2224", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECEFB8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EBC]) = v38;\nL_0013:\n\tv39 = player == 0;\n\tif (v39) goto L_0041;\n\tgoto L_005F;\n\tv52 = *([v41 @ X8_v10+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v118 @ X11_v5-8]);\n\tv124 = v56 == v44;\n\tif (v124) goto L_0052;\n\tv89 = v119 + 1;\n\tv129 = v89 < v43;\n\tv83 = ~v129;\n\tv86 = v118 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 5;\n\tv91 = v12;\n\tv92 = 0x8909C4(v91, v44, v90, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_005F;\nL_0041:\n\tgoto L_0050;\n\tv93 = *([v48 @ X0_v2+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0050;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tUnityEngine.Debug::LogError(\"Player is null.\");\n\treturn;\nL_0052:\n\tv130 = *([v118 @ X11_v5]);\n\tv131 = v130 + 5;\n\tv132 = v131 << 4;\n\tv133 = v41 + v132;\n\tv134 = v133 + 0x130;\nL_005F:\n\tEasyMobile.IClipPlayer::Stop(player);\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StopPlayer(IClipPlayer player)
		{
			if (player == null)
			{
				Debug.LogError("Player is null.");
			}
			else
			{
				player.Stop();
			}
		}

		[Token(Token = "0x6000459")]
		[Address(RVA = "0xBF230C", Offset = "0xBF230C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1F0E398]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, filename, quality, threadPriority, exportProgressCallback, exportCompletedCallback, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2022EBD]) = v53;\nL_0023:\n\tgoto L_003A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_003A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, filename, quality, threadPriority, exportProgressCallback, exportCompletedCallback, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_003A:\n\tEasyMobile.Gif::ExportGif(clip, filename, 0, quality, threadPriority, exportProgressCallback, exportCompletedCallback);\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ExportGif(AnimatedClip clip, string filename, int quality, ThreadPriority threadPriority, Action<AnimatedClip, float> exportProgressCallback, Action<AnimatedClip, string> exportCompletedCallback)
		{
			ExportGif(clip, filename, 0, quality, threadPriority, exportProgressCallback, exportCompletedCallback);
		}

		[Token(Token = "0x600045A")]
		[Address(RVA = "0xBF23B4", Offset = "0xBF23B4", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv42 = *([1EA4748]);\n\tv43 = *([v42 @ X8_v30]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, filename, loop, quality, threadPriority, exportProgressCallback, exportCompletedCallback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022EBE]) = v56;\nL_001F:\n\tv57 = clip == 0;\n\tif (v57) goto L_0030;\n\tv58 = clip.<Frames>k__BackingField;\n\tv62 = v58.Length == 0;\n\tif (v62) goto L_0030;\n\tv61 = ~clip.isDisposed;\n\tif (v61) goto L_0049;\nL_0030:\n\tgoto L_FFFFFFFF;\n\tv94 = *([v68 @ X0_v4+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_FFFFFFFF;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v68, filename, loop, quality, threadPriority, exportProgressCallback, exportCompletedCallback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0045:\n\tUnityEngine.Debug::LogError(*([v109 @ X8_v3 (System.String)]));\n\treturn;\nL_0049:\n\tv124 = System.String::IsNullOrEmpty(filename);\n\tv157 = v124 == 0;\n\tif (v157) goto L_0062;\n\tgoto L_FFFFFFFF;\n\tv170 = *([v160 @ X0_v20+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_FFFFFFFF;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v160, v104, loop, quality, threadPriority, exportProgressCallback, exportCompletedCallback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0045;\nL_0062:\n\tgoto L_0068;\n\tv176 = *([v166 @ X0_v12 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0068;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v166, v104, loop, quality, threadPriority, exportProgressCallback, exportCompletedCallback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0068:\n\tv182 = EasyMobile.Gif::get_Instance();\n\tv85 = EasyMobile.Gif::CRExportGif(clip, filename, loop, quality, threadPriority, exportProgressCallback, exportCompletedCallback);\n\tv135 = UnityEngine.MonoBehaviour::StartCoroutine(v182, v85);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ExportGif(AnimatedClip clip, string filename, int loop, int quality, ThreadPriority threadPriority, Action<AnimatedClip, float> exportProgressCallback, Action<AnimatedClip, string> exportCompletedCallback)
		{
			string message;
			if (clip != null)
			{
				Texture[] frames = clip.Frames;
				if (frames.Length != 0 && !clip.isDisposed)
				{
					if (string.IsNullOrEmpty(filename))
					{
						message = "Exporting GIF failed: filename is null or empty.";
						goto IL_010b;
					}
					Gif instance = Instance;
					IEnumerator routine = CRExportGif(clip, filename, loop, quality, threadPriority, exportProgressCallback, exportCompletedCallback);
					Coroutine coroutine = instance.StartCoroutine(routine);
					return;
				}
			}
			message = "Attempted to export GIF from an empty or disposed clip.";
			goto IL_010b;
			IL_010b:
			Debug.LogError(message);
		}

		[Token(Token = "0x600045B")]
		[Address(RVA = "0xBF25D4", Offset = "0xBF25D4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EE4D50]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, threadPriority, completeCallback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EBF]) = v44;\nL_001D:\n\tgoto L_002E;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002E;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, threadPriority, completeCallback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002E:\n\tEasyMobile.Gif::DecodeGif(filepath, 0xFFFFFFFF, threadPriority, completeCallback);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DecodeGif(string filepath, ThreadPriority threadPriority, Action<AnimatedClip> completeCallback)
		{
			DecodeGif(filepath, -1, threadPriority, completeCallback);
		}

		[Token(Token = "0x600045C")]
		[Address(RVA = "0xBF2654", Offset = "0xBF2654", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EFB5F0]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, framesToRead, threadPriority, completeCallback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022EC0]) = v47;\nL_001C:\n\tv51 = new EasyMobile.Gif+<>c__DisplayClass16_0();\n\tSystem.Object::.ctor(v51);\n\tv51.completeCallback = completeCallback;\n\tgoto L_0032;\n\tv63 = *([v57 @ X0_v6 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0032;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v57, v52, threadPriority, completeCallback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv67 = EasyMobile.Gif;\nL_0032:\n\tv72 = v70.curDecodeId + 1;\n\tv70.curDecodeId = v72;\n\tv76 = new EasyMobile.Internal.Gif.DecodeCompleteCallback();\n\tv83 = Il2CppMethodInfo;\n\tv76.m_target = v51;\n\tv76.method = Il2CppMethodInfo;\n\tv76.method_ptr = *([v83 @ X9_v4 (Il2CppMethodInfo)]);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif::DecodeGif(v70.curDecodeId, filepath, framesToRead, threadPriority, v76);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void DecodeGif(string filepath, int framesToRead, ThreadPriority threadPriority, Action<AnimatedClip> completeCallback)
		{
			_003C_003Ec__DisplayClass16_0 _003C_003Ec__DisplayClass16_1 = new _003C_003Ec__DisplayClass16_0();
			_003C_003Ec__DisplayClass16_1.completeCallback = completeCallback;
			int num = curDecodeId + 1;
			curDecodeId = num;
			DecodeCompleteCallback decodeCompleteCallback = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)decodeCompleteCallback).m_target = _003C_003Ec__DisplayClass16_1;
			((Delegate)decodeCompleteCallback).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass16_0._003CDecodeGif_003Eb__0);
			((Delegate)decodeCompleteCallback).method_ptr = method_ptr;
			AndroidNativeGif.DecodeGif(curDecodeId, filepath, framesToRead, threadPriority, decodeCompleteCallback);
		}

		[Token(Token = "0x600045D")]
		[Address(RVA = "0xBF2864", Offset = "0xBF2864", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EC9BC0]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, framesToRead, threadPriority, completeCallback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022EC1]) = v47;\nL_001C:\n\tv51 = new EasyMobile.Gif+<>c__DisplayClass17_0();\n\tSystem.Object::.ctor(v51);\n\tv51.completeCallback = completeCallback;\n\tgoto L_0032;\n\tv63 = *([v57 @ X0_v6 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0032;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v57, v52, threadPriority, completeCallback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv67 = EasyMobile.Gif;\nL_0032:\n\tv72 = v70.curDecodeId + 1;\n\tv70.curDecodeId = v72;\n\tv76 = new EasyMobile.Internal.Gif.DecodeCompleteCallback();\n\tv83 = Il2CppMethodInfo;\n\tv76.m_target = v51;\n\tv76.method = Il2CppMethodInfo;\n\tv76.method_ptr = *([v83 @ X9_v4 (Il2CppMethodInfo)]);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif::DecodeGif(v70.curDecodeId, filepath, framesToRead, threadPriority, v76);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void DecodeGif(string filepath, int framesToRead, ThreadPriority threadPriority, Action<Texture[]> completeCallback)
		{
			_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_1 = new _003C_003Ec__DisplayClass17_0();
			_003C_003Ec__DisplayClass17_1.completeCallback = completeCallback;
			int num = curDecodeId + 1;
			curDecodeId = num;
			DecodeCompleteCallback decodeCompleteCallback = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)decodeCompleteCallback).m_target = _003C_003Ec__DisplayClass17_1;
			((Delegate)decodeCompleteCallback).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass17_0._003CDecodeGif_003Eb__0);
			((Delegate)decodeCompleteCallback).method_ptr = method_ptr;
			AndroidNativeGif.DecodeGif(curDecodeId, filepath, framesToRead, threadPriority, decodeCompleteCallback);
		}

		[Token(Token = "0x600045E")]
		[Address(RVA = "0xBF2968", Offset = "0xBF2968", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F09068]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022EC2]) = v42;\nL_001B:\n\tgoto L_002A;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = EasyMobile.Gif;\nL_002A:\n\tgoto L_0034;\n\tv65 = *([v59 @ X8_v5+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0034;\n\tv76 = v59;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v76, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0034:\n\tv75 = UnityEngine.Object::op_Equality(v58._instance, 0);\n\tv78 = v75 == 0;\n\tif (v78) goto L_0061;\n\tgoto L_0046;\n\tv86 = *([v79 @ X0_v13 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0046;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v79, v73, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv90 = EasyMobile.Gif;\nL_0046:\n\tv93._instance = this;\n\tv96 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_005D;\n\tv123 = *([v103 @ X8_v10+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tgoto L_005D;\n\tv139 = v103;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v139, v95, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005D:\n\tUnityEngine.Object::DontDestroyOnLoad(v96);\n\treturn;\nL_0061:\n\tv85 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0077;\n\tv108 = *([v97 @ X8_v6+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0077;\n\tv138 = v97;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v138, v84, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0077:\n\tUnityEngine.Object::Destroy(v85);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
				GameObject target = base.gameObject;
				UnityEngine.Object.DontDestroyOnLoad(target);
			}
			else
			{
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
		}

		[Token(Token = "0x600045F")]
		[Address(RVA = "0xBF2AB0", Offset = "0xBF2AB0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EB4B18]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EC3]) = v35;\nL_0014:\n\tv39 = new System.Action`2<System.Int32, System.Single>();\n\tSystem.Action`2<System.Int32, System.Single>::.ctor(v39, 0, Il2CppMethodInfo);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif::add_GifExportProgress(v39);\n\tv52 = new System.Action`2<System.Int32, System.String>();\n\tSystem.Action`2<System.Int32, System.String>::.ctor(v52, 0, Il2CppMethodInfo);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif::add_GifExportCompleted(v52);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			Action<int, float> value = OnGifExportProgress;
			AndroidNativeGif.GifExportProgress += value;
			Action<int, string> value2 = OnGifExportCompleted;
			AndroidNativeGif.GifExportCompleted += value2;
		}

		[Token(Token = "0x6000460")]
		[Address(RVA = "0xBF2CCC", Offset = "0xBF2CCC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EE1238]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EC4]) = v35;\nL_0014:\n\tv39 = new System.Action`2<System.Int32, System.Single>();\n\tSystem.Action`2<System.Int32, System.Single>::.ctor(v39, 0, Il2CppMethodInfo);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif::remove_GifExportProgress(v39);\n\tv52 = new System.Action`2<System.Int32, System.String>();\n\tSystem.Action`2<System.Int32, System.String>::.ctor(v52, 0, Il2CppMethodInfo);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif::remove_GifExportCompleted(v52);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			Action<int, float> value = OnGifExportProgress;
			AndroidNativeGif.GifExportProgress -= value;
			Action<int, string> value2 = OnGifExportCompleted;
			AndroidNativeGif.GifExportCompleted -= value2;
		}

		[Token(Token = "0x6000461")]
		[Address(RVA = "0xBF2EE8", Offset = "0xBF2EE8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC8810]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022EC5]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = EasyMobile.Gif;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Equality(this, v56._instance);\n\tv76 = v73 == 0;\n\tif (v76) goto L_004A;\n\tgoto L_0043;\n\tv92 = *([v77 @ X0_v8 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0043;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v77, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv95 = EasyMobile.Gif;\nL_0043:\n\tv86._instance = 0;\nL_004A:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (this == _instance)
			{
				_instance = null;
			}
		}

		[Token(Token = "0x6000462")]
		[Address(RVA = "0xBF2FB8", Offset = "0xBF2FB8", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1EF0AF8]);\n\tv31 = *([v30 @ X8_v43]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0 | 1;\n\t*([2022EC6]) = v51;\nL_0022:\n\tgoto L_0030;\n\tv61 = *([v57 @ X0_v2 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\t// 38 Jump @b64\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv65 = EasyMobile.Gif;\nL_0030:\n\tv75 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::get_Keys(v68.gifExportTasks);\n\tv119 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v119, v75);\n\tv138 = v119 == 0;\n\tif (v138) goto L_00B0;\n\tv161 = System.Collections.Generic.List`1<System.Int32>::GetEnumerator(v119);\nL_0057:\n\tv212 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v97 @ stack_-98_v4 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv216 = v212 == 0;\n\tif (v216) goto L_00A7;\n\tgoto L_006D;\n\tv304 = *([v278 @ X0_v29 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv305 = v304 == 0;\n\tv306 = ~v305;\n\t// 100 ConditionalJump @b65, v306 @ TEMP_v39\n\tv314 = \"il2cpp_codegen_runtime_class_init\"(v278, v210, v192, v188, v36, v37, v38, v39, v190, v41, v42, v43, v44, v45, v46, v47);\n\tv308 = EasyMobile.Gif;\nL_006D:\n\tv317 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::get_Item(v311.gifExportTasks, v165);\n\tv328 = ~v317.isExporting;\n\tif (v328) goto L_007C;\n\tv345 = v317.exportProgressCallback == 0;\n\tif (v345) goto L_007C;\n\tSystem.Action`2<EasyMobile.AnimatedClip, System.Single>::Invoke(v317.exportProgressCallback, v317.clip, Il2CppMethodInfo);\nL_007C:\n\tv204 = ~v317.isDone;\n\tif (v204) goto L_0057;\n\tv355 = v317.exportCompletedCallback == 0;\n\tif (v355) goto L_0085;\n\tSystem.Action`2<EasyMobile.AnimatedClip, System.String>::Invoke(v317.exportCompletedCallback, v317.clip, v317.filepath);\nL_0085:\n\tv317.clip = 0;\n\tv317.imageData = 0;\n\tgoto L_0099;\n\tv363 = *([v359 @ X0_v43 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv364 = v363 == 0;\n\tv365 = ~v364;\n\t// 143 ConditionalJump @b67, v365 @ TEMP_v36\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v359, v336, v333, v330, v36, v37, v38, v39, v191, v41, v42, v43, v44, v45, v46, v47);\n\tv367 = EasyMobile.Gif;\nL_0099:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::set_Item(v342.gifExportTasks, v165, 0);\n\tv202 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::Remove(v208.gifExportTasks, v165);\n\tgoto L_0057;\nL_00A7:\n\tv286 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v97 @ stack_-98_v4 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tgoto L_00DE;\n\tthrow System.NullReferenceException;\n\tv326 = new System.NullReferenceException();\n\tv343 = new System.NullReferenceException();\n\tv106 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00B0:\n\tv144 = new System.NullReferenceException();\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\n\tgoto L_00C5;\nL_00C5:\n\tv155 = v134 != 1;\n\tif (v155) goto L_00DF;\n\tv162 = System.Collections.Generic.List`1<System.Int32>::.ctor(v144, v134);\n\tv174 = System.Collections.Generic.List`1<System.Int32>::.ctor(v162, v134);\n\tv178 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v80 @ stack_-80_v4 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv217 = *([v162 @ X0_v13 (System.Collections.Generic.List`1<System.Int32>)]) == 0;\n\tv180 = ~v217;\n\tif (v180) goto L_00E3;\nL_00DE:\n\treturn;\nL_00DF:\n\tv163 = System.Collections.Generic.List`1<System.Int32>::.ctor(v144, v134);\nL_00E3:\n\tthrow System.TypeLoadException;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_001c: Expected I4, but got O
			//IL_00ca: Expected F4, but got I
			Dictionary<int, GifExportTask>.KeyCollection keys = gifExportTasks.Keys;
			List<int> list = new List<int>((int)keys);
			if (list != null)
			{
				List<int>.Enumerator enumerator = list.GetEnumerator();
				List<int>.Enumerator enumerator2 = default(List<int>.Enumerator);
				int key = default(int);
				while (enumerator2.MoveNext())
				{
					GifExportTask gifExportTask = gifExportTasks.get_Item(key);
					if (gifExportTask.isExporting && gifExportTask.exportProgressCallback != null)
					{
						gifExportTask.exportProgressCallback(gifExportTask.clip, 0f);
					}
					if (gifExportTask.isDone)
					{
						if (gifExportTask.exportCompletedCallback != null)
						{
							gifExportTask.exportCompletedCallback(gifExportTask.clip, gifExportTask.filepath);
						}
						gifExportTask.clip = null;
						gifExportTask.imageData = null;
						gifExportTasks.set_Item(key, (GifExportTask)null);
						bool flag = gifExportTasks.Remove(key);
					}
				}
				enumerator2.Dispose();
				return;
			}
			IEnumerable<int> enumerable = default(IEnumerable<int>);
			NullReferenceException ex = (NullReferenceException)(object)new List<int>(enumerable);
			if ((IntPtr)enumerable == (IntPtr)1)
			{
				List<int>.Enumerator enumerator3 = default(List<int>.Enumerator);
				enumerator3.Dispose();
				List<int> list2 = default(List<int>);
				if (list2 == null)
				{
					return;
				}
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000463")]
		[Address(RVA = "0xBF3280", Offset = "0xBF3280", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBDBE0]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, progress, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022EC7]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\t// 31 Jump @b20\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v26, v27, v28, v29, v30, v31, progress, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = EasyMobile.Gif;\nL_002A:\n\tv63 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::ContainsKey(v55.gifExportTasks, taskId);\n\tv79 = v63 == 0;\n\tif (v79) goto L_004D;\n\tgoto L_0041;\n\tv107 = *([v80 @ X0_v9 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\t// 54 ConditionalJump @b22, v109 @ TEMP_v18\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v80, v61, v62, v27, v28, v29, v30, v31, progress, v32, v33, v34, v35, v36, v37, v38);\n\tv111 = EasyMobile.Gif;\nL_0041:\n\tv69 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::get_Item(v76.gifExportTasks, taskId);\n\tv85 = progress * 0.5f;\n\tv69.progress = v85;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnGifPreProcessing(int taskId, float progress)
		{
			if (gifExportTasks.ContainsKey(taskId))
			{
				GifExportTask gifExportTask = gifExportTasks.get_Item(taskId);
				float progress2 = progress * 0.5f;
				gifExportTask.progress = progress2;
			}
		}

		[Token(Token = "0x6000464")]
		[Address(RVA = "0xBF3364", Offset = "0xBF3364", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED6F20]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, progress, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022EC8]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\t// 31 Jump @b20\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v26, v27, v28, v29, v30, v31, progress, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = EasyMobile.Gif;\nL_002A:\n\tv63 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::ContainsKey(v55.gifExportTasks, taskId);\n\tv79 = v63 == 0;\n\tif (v79) goto L_004E;\n\tgoto L_0041;\n\tv110 = *([v80 @ X0_v9 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\t// 54 ConditionalJump @b22, v112 @ TEMP_v18\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v80, v61, v62, v27, v28, v29, v30, v31, progress, v32, v33, v34, v35, v36, v37, v38);\n\tv114 = EasyMobile.Gif;\nL_0041:\n\tv69 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::get_Item(v76.gifExportTasks, taskId);\n\tv85 = progress * 0.5f;\n\tv87 = v85 + 0.5f;\n\tv69.progress = v87;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnGifExportProgress(int taskId, float progress)
		{
			if (gifExportTasks.ContainsKey(taskId))
			{
				GifExportTask gifExportTask = gifExportTasks.get_Item(taskId);
				float num = progress * 0.5f;
				float progress2 = num + 0.5f;
				gifExportTask.progress = progress2;
			}
		}

		[Token(Token = "0x6000465")]
		[Address(RVA = "0xBF344C", Offset = "0xBF344C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED6568]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, filepath, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EC9]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b20\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, filepath, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Gif;\nL_0028:\n\tv60 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::ContainsKey(v52.gifExportTasks, taskId);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0049;\n\tgoto L_003F;\n\tv100 = *([v77 @ X0_v9 (Il2CppClass<EasyMobile.Gif>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\t// 52 ConditionalJump @b22, v102 @ TEMP_v18\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v77, v58, v59, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv104 = EasyMobile.Gif;\nL_003F:\n\tv66 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::get_Item(v73.gifExportTasks, taskId);\n\tv66.isDone = 1;\nL_0049:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnGifExportCompleted(int taskId, string filepath)
		{
			if (gifExportTasks.ContainsKey(taskId))
			{
				GifExportTask gifExportTask = gifExportTasks.get_Item(taskId);
				gifExportTask.isDone = true;
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x73482C", Offset = "0x73482C")]
		[Token(Token = "0x6000466")]
		[Address(RVA = "0xBF2524", Offset = "0xBF2524", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv42 = *([1EB5168]);\n\tv43 = *([v42 @ X8_v6]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, filename, loop, quality, threadPriority, exportProgressCallback, exportCompletedCallback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022ECA]) = v56;\nL_0022:\n\tv60 = new EasyMobile.Gif+<CRExportGif>d__26();\n\tSystem.Object::.ctor(v60);\n\tv60.<>1__state = 0;\n\tv60.filename = filename;\n\tv60.clip = clip;\n\tv60.loop = loop;\n\tv60.quality = quality;\n\tv60.threadPriority = threadPriority;\n\tv60.exportProgressCallback = exportProgressCallback;\n\tv60.exportCompletedCallback = exportCompletedCallback;\n\treturn v60;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IEnumerator CRExportGif(AnimatedClip clip, string filename, int loop, int quality, ThreadPriority threadPriority, Action<AnimatedClip, float> exportProgressCallback, Action<AnimatedClip, string> exportCompletedCallback)
		{
			_003CCRExportGif_003Ed__26 _003CCRExportGif_003Ed__27 = null;
			_003CCRExportGif_003Ed__27._003C_003E1__state = 0;
			_003CCRExportGif_003Ed__27.filename = filename;
			_003CCRExportGif_003Ed__27.clip = clip;
			_003CCRExportGif_003Ed__27.loop = loop;
			_003CCRExportGif_003Ed__27.quality = quality;
			_003CCRExportGif_003Ed__27.threadPriority = threadPriority;
			_003CCRExportGif_003Ed__27.exportProgressCallback = exportProgressCallback;
			_003CCRExportGif_003Ed__27.exportCompletedCallback = exportCompletedCallback;
			return _003CCRExportGif_003Ed__27;
		}

		[Token(Token = "0x6000467")]
		[Address(RVA = "0xBF354C", Offset = "0xBF354C", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EB4CE8]);\n\tv35 = *([v34 @ X8_v19]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, gifFrameMetadata, imageData, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022ECB]) = v52;\nL_001E:\n\tv56 = imageData == 0;\n\tif (v56) goto L_008E;\n\tv57 = methodInfo == 0;\n\tif (v57) goto L_008E;\n\t// 35 NewArr v62 @ X0_v6 (UnityEngine.Texture[]), typeof(UnityEngine.Texture[]), typeof(Il2CppClass<EasyMobile.Gif>)\n\tv76 = Il2CppClass<EasyMobile.Gif> < 1;\n\tif (v76) goto L_009C;\n\tv133 = gifMetadata >> 0x20;\nL_0037:\n\tv213 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v213, gifMetadata, v133, 4, 0);\n\tUnityEngine.Object::set_hideFlags(v213, 0x3D);\n\tUnityEngine.Texture::set_wrapMode(v213, 1);\n\tUnityEngine.Texture::set_filterMode(v213, 1);\n\tUnityEngine.Texture::set_anisoLevel(v213, 0);\n\tv293 = v160 < Il2CppClass<EasyMobile.Gif>;\n\tv241 = ~v293;\n\tif (v241) goto L_009F;\n\tv222 = v160 << 3;\n\tv249 = methodInfo + v222;\n\tUnityEngine.Texture2D::SetPixels32(v213, *([v249 @ X8_v12+20]));\n\tUnityEngine.Texture2D::Apply(v213, 0, 0);\n\t// 109 IsInst v126 @ X0_v24, typeof(UnityEngine.Texture), v213 @ X0_v9 (UnityEngine.Texture2D)\n\tv298 = v160 < v62.Length;\n\tv275 = ~v298;\n\tif (v275) goto L_009F;\n\tv62[v160 @ X24_v4 (System.Int32)] = v213;\n\tv160 = v160 + 1;\n\tv98 = v160 < Il2CppClass<EasyMobile.Gif>;\n\tif (v98) goto L_0037;\n\tgoto L_009C;\nL_008E:\n\t// 142 NewArr v60 @ X0_v5 (UnityEngine.Texture[]), typeof(UnityEngine.Texture[]), 0\nL_009C:\n\treturn v129;\n\tv251 = new System.NullReferenceException();\nL_009F:\n\tv284 = new System.IndexOutOfRangeException();\n\tgoto L_00A4;\n\tv291 = new System.ArrayTypeMismatchException();\nL_00A4:\n\tthrow v290;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Texture[] ToTextureArray(GifMetadata gifMetadata, GifFrameMetadata[] gifFrameMetadata, Color32[][] imageData)
		{
			//IL_005e: Expected I4, but got O
			//IL_0204: Expected I4, but got O
			//IL_00ef: Expected O, but got I
			//IL_0104: Expected O, but got I
			IntPtr intPtr = default(IntPtr);
			Texture[] result;
			if (imageData != null && intPtr != (IntPtr)0)
			{
				Texture[] array = new Texture[0];
				bool flag = 0L < 1L;
				result = array;
				if (!flag)
				{
					int height = (object)gifMetadata >> 32;
					int num = 0;
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					while (true)
					{
						Texture2D texture2D = new Texture2D((int)gifMetadata, height, TextureFormat.RGBA32, mipChain: false);
						texture2D.hideFlags = HideFlags.HideAndDontSave;
						texture2D.wrapMode = TextureWrapMode.Clamp;
						texture2D.filterMode = FilterMode.Bilinear;
						texture2D.anisoLevel = 0;
						if ((long)num < 0L)
						{
							int num2 = num << 3;
							object obj = (long)intPtr + (long)num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X8_v12+20]");
							texture2D.SetPixels32((Color32[])0);
							texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: false);
							object obj2 = texture2D as Texture;
							if (num < array.Length)
							{
								array[num] = texture2D;
								num++;
								if ((long)num >= 0L)
								{
									break;
								}
								continue;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex2;
					}
					result = array;
				}
			}
			else
			{
				Texture[] array2 = new Texture[0];
				result = array2;
			}
			return result;
		}

		[Token(Token = "0x6000468")]
		[Address(RVA = "0xBF36F8", Offset = "0xBF36F8", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EFC2A8]);\n\tv33 = *([v32 @ X8_v17]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, gifFrameMetadata, imageData, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2022ECC]) = v49;\nL_001A:\n\tv50 = imageData == 0;\n\tif (v50) goto L_0056;\n\tv52 = imageData.Length == 0;\n\tif (v52) goto L_0057;\n\tgoto L_002C;\n\tv130 = *([v103 @ X0_v6+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_002C;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v103, gifFrameMetadata, imageData, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_002C:\n\tv70 = gifFrameMetadata & 0xFFFFFFFF;\n\tv75 = EasyMobile.Gif::ToTextureArray(gifMetadata, v70, imageData);\n\tv138 = v75 == 0;\n\tif (v138) goto L_FFFFFFFF;\n\tv79 = v75.Length == 0;\n\tif (v79) goto L_FFFFFFFF;\n\tv143 = imageData[0] * 0.01f;\n\tv60 = 1f / v143;\n\tv81 = gifMetadata >> 0x20;\n\tv76 = new EasyMobile.AnimatedClip();\n\tEasyMobile.AnimatedClip::.ctor(v76, gifMetadata, v81, v60, v75);\n\tgoto L_0056;\nL_0056:\n\treturn v82;\nL_0057:\n\tv107 = new System.IndexOutOfRangeException();\n\tthrow v107;\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AnimatedClip ToAnimatedClip(GifMetadata gifMetadata, GifFrameMetadata[] gifFrameMetadata, Color32[][] imageData)
		{
			//IL_003c: Expected O, but got I8
			//IL_00c5: Expected I4, but got O
			//IL_00da: Expected I4, but got F4
			//IL_00da: Expected I4, but got O
			bool flag = imageData == null;
			Color32[][] result = imageData;
			if (!flag)
			{
				if (imageData.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				GifFrameMetadata[] gifFrameMetadata2 = (GifFrameMetadata[])((long)(IntPtr)gifFrameMetadata & 0xFFFFFFFFL);
				Texture[] array = ToTextureArray(gifMetadata, gifFrameMetadata2, imageData);
				if (array != null && array.Length != 0)
				{
					float num = (float)imageData[0] * 0.01f;
					float num2 = 1f / num;
					int height = (object)gifMetadata >> 32;
					AnimatedClip animatedClip = new AnimatedClip((int)gifMetadata, height, (int)num2, array);
					result = (Color32[][])(object)animatedClip;
				}
				else
				{
					result = null;
				}
			}
			return (AnimatedClip)(object)result;
		}

		[Token(Token = "0x6000469")]
		[Address(RVA = "0xBF3818", Offset = "0xBF3818", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Gif()
		{
		}

		[Token(Token = "0x600046A")]
		[Address(RVA = "0xBF3820", Offset = "0xBF3820", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EA7B70]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022ECD]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.GifExportTask>::.ctor(v39);\n\tv47.gifExportTasks = v39;\n\tv48.curExportId = 0;\n\tv49.curDecodeId = 0;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Gif()
		{
			Dictionary<int, GifExportTask> dictionary = new Dictionary<int, GifExportTask>();
			gifExportTasks = dictionary;
			curExportId = 0;
			curDecodeId = 0;
		}
	}
}
