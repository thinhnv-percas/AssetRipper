using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x200006D")]
	public class FsmEvent : IComparable, INameable
	{
		[Token(Token = "0x400026A")]
		private static Dictionary<string, FsmEvent> _eventLookup;

		[Token(Token = "0x400026B")]
		private static readonly object syncObj;

		[SerializeField]
		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x10")]
		private string name;

		[SerializeField]
		[Token(Token = "0x400026D")]
		[FieldOffset(Offset = "0x18")]
		private bool isSystemEvent;

		[SerializeField]
		[Token(Token = "0x400026E")]
		[FieldOffset(Offset = "0x19")]
		private bool isGlobal;

		[Token(Token = "0x1700012F")]
		public static PlayMakerGlobals GlobalsComponent
		{
			[Token(Token = "0x600044A")]
			[Address(RVA = "0xCA4DE4", Offset = "0xCA4DE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = PlayMakerGlobals::get_Instance();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PlayMakerGlobals.Instance;
			}
		}

		[Token(Token = "0x17000130")]
		public static List<string> globalEvents
		{
			[Token(Token = "0x600044B")]
			[Address(RVA = "0xCA4DEC", Offset = "0xCA4DEC", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = PlayMakerGlobals::get_Instance();\n\treturn v7.events;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				PlayMakerGlobals instance = PlayMakerGlobals.Instance;
				return instance.Events;
			}
		}

		[Token(Token = "0x17000131")]
		private static Dictionary<string, FsmEvent> eventLookup
		{
			[Token(Token = "0x600044C")]
			[Address(RVA = "0xCA4E10", Offset = "0xCA4E10", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EA9A98]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023544]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv53 = v51._eventLookup == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0040;\n\tv59 = new System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::.ctor(v59, 0x64);\n\tgoto L_003A;\n\tv95 = *([v90 @ X0_v11 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_003A;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v90, v63, v61, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv99 = HutongGames.PlayMaker.FsmEvent;\nL_003A:\n\tv69._eventLookup = v59;\n\tHutongGames.PlayMaker.FsmEvent::Initialize();\nL_0040:\n\tgoto L_004E;\n\tv77 = *([v64 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tgoto L_004E;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v64, v62, v60, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv81 = HutongGames.PlayMaker.FsmEvent;\nL_004E:\n\treturn v84._eventLookup;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (_eventLookup == null)
				{
					Dictionary<string, FsmEvent> dictionary = new Dictionary<string, FsmEvent>(100);
					_eventLookup = dictionary;
					Initialize();
				}
				return _eventLookup;
			}
		}

		[Token(Token = "0x17000132")]
		public static List<FsmEvent> EventList
		{
			[Token(Token = "0x600044D")]
			[Address(RVA = "0xCA4F58", Offset = "0xCA4F58", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1ED5808]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023545]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tv51 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv56 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::get_Values(v51);\n\tv63 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::.ctor(v63, v56);\n\treturn v63;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0029: Expected I4, but got O
				Dictionary<string, FsmEvent> dictionary = eventLookup;
				Dictionary<string, FsmEvent>.ValueCollection values = dictionary.Values;
				return new List<FsmEvent>((int)values);
			}
		}

		[Token(Token = "0x17000133")]
		public string Name
		{
			[Token(Token = "0x600044F")]
			[Address(RVA = "0xCA6624", Offset = "0xCA6624", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[Token(Token = "0x6000450")]
			[Address(RVA = "0xCA662C", Offset = "0xCA662C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.name = value;\n\treturn;\n")]
			set
			{
				Name = value;
			}
		}

		[Token(Token = "0x17000134")]
		public bool IsSystemEvent
		{
			[Token(Token = "0x6000451")]
			[Address(RVA = "0xCA6634", Offset = "0xCA6634", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isSystemEvent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsSystemEvent;
			}
			[Token(Token = "0x6000452")]
			[Address(RVA = "0xCA663C", Offset = "0xCA663C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isSystemEvent = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				isSystemEvent = value;
			}
		}

		[Token(Token = "0x17000135")]
		public bool IsMouseEvent
		{
			[Token(Token = "0x6000453")]
			[Address(RVA = "0xCA6648", Offset = "0xCA6648", Length = "0x318")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EDBB20]);\n\tv21 = *([v20 @ X8_v97]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023547]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EA48A8]);\n\tv60 = *([v59 @ X8_v93]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([20236B6]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<MouseDown>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv164 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tif (v166) goto L_004F;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv204 = *([1EAB6A8]);\n\tv205 = *([v204 @ X8_v88]);\n\tv206 = \"il2cpp_codegen_initialize_method\"(v205, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv209 = 0 | 1;\n\t*([20236B7]) = v209;\nL_005A:\n\tgoto L_0067;\n\tv214 = *([v210 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tgoto L_0067;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v210, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv217 = HutongGames.PlayMaker.FsmEvent;\nL_0067:\n\tv116 = v219.<MouseDrag>k__BackingField == this;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv225 = *([v146 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv226 = v225 == 0;\n\tv227 = ~v226;\n\tif (v227) goto L_007A;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v146, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tgoto L_0085;\n\tv236 = *([1F10658]);\n\tv237 = *([v236 @ X8_v83]);\n\tv238 = \"il2cpp_codegen_initialize_method\"(v237, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv241 = 0 | 1;\n\t*([20236B8]) = v241;\nL_0085:\n\tgoto L_0092;\n\tv246 = *([v242 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tgoto L_0092;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v242, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv249 = HutongGames.PlayMaker.FsmEvent;\nL_0092:\n\tv117 = v251.<MouseEnter>k__BackingField == this;\n\tif (v117) goto L_FFFFFFFF;\n\tgoto L_00A5;\n\tv257 = *([v147 @ X0_v17 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv258 = v257 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_00A5;\n\tv261 = \"il2cpp_codegen_runtime_class_init\"(v147, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A5:\n\tgoto L_00B0;\n\tv268 = *([1EA8C48]);\n\tv269 = *([v268 @ X8_v78]);\n\tv270 = \"il2cpp_codegen_initialize_method\"(v269, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv273 = 0 | 1;\n\t*([20236B9]) = v273;\nL_00B0:\n\tgoto L_00BD;\n\tv278 = *([v274 @ X0_v20 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv279 = v278 == 0;\n\tv280 = ~v279;\n\tgoto L_00BD;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v274, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv281 = HutongGames.PlayMaker.FsmEvent;\nL_00BD:\n\tv118 = v283.<MouseExit>k__BackingField == this;\n\tif (v118) goto L_FFFFFFFF;\n\tgoto L_00D0;\n\tv289 = *([v148 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv290 = v289 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_00D0;\n\tv293 = \"il2cpp_codegen_runtime_class_init\"(v148, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D0:\n\tgoto L_00DB;\n\tv300 = *([1EF76A0]);\n\tv301 = *([v300 @ X8_v73]);\n\tv302 = \"il2cpp_codegen_initialize_method\"(v301, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv305 = 0 | 1;\n\t*([20236BA]) = v305;\nL_00DB:\n\tgoto L_00E8;\n\tv310 = *([v306 @ X0_v24 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tgoto L_00E8;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v306, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv313 = HutongGames.PlayMaker.FsmEvent;\nL_00E8:\n\tv119 = v315.<MouseOver>k__BackingField == this;\n\tif (v119) goto L_FFFFFFFF;\n\tgoto L_00FB;\n\tv321 = *([v149 @ X0_v25 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv322 = v321 == 0;\n\tv323 = ~v322;\n\tif (v323) goto L_00FB;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v149, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00FB:\n\tgoto L_0106;\n\tv332 = *([1ED25B0]);\n\tv333 = *([v332 @ X8_v68]);\n\tv334 = \"il2cpp_codegen_initialize_method\"(v333, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv337 = 0 | 1;\n\t*([20236BB]) = v337;\nL_0106:\n\tgoto L_0113;\n\tv342 = *([v338 @ X0_v28 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv343 = v342 == 0;\n\tv344 = ~v343;\n\tgoto L_0113;\n\tv349 = \"il2cpp_codegen_runtime_class_init\"(v338, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv345 = HutongGames.PlayMaker.FsmEvent;\nL_0113:\n\tv120 = v347.<MouseUp>k__BackingField == this;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_0126;\n\tv353 = *([v150 @ X0_v29 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv354 = v353 == 0;\n\tv355 = ~v354;\n\tif (v355) goto L_0126;\n\tv357 = \"il2cpp_codegen_runtime_class_init\"(v150, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0126:\n\tgoto L_0131;\n\tv364 = *([1EF9B78]);\n\tv365 = *([v364 @ X8_v63]);\n\tv366 = \"il2cpp_codegen_initialize_method\"(v365, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv369 = 0 | 1;\n\t*([20236BC]) = v369;\nL_0131:\n\tgoto L_013C;\n\tv374 = *([v370 @ X0_v32 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv375 = v374 == 0;\n\tv376 = ~v375;\n\tgoto L_013C;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v370, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv378 = HutongGames.PlayMaker.FsmEvent;\nL_013C:\n\tv187 = v380.<MouseUpAsButton>k__BackingField - this;\n\tv183 = v187 == 0;\n\tgoto L_014C;\nL_014C:\n\treturn returnVal1;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0125: Expected O, but got I
				if (MouseDown == this || MouseDrag == this || MouseEnter == this || MouseExit == this || MouseOver == this || MouseUp == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)MouseUpAsButton - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x17000136")]
		public bool IsApplicationEvent
		{
			[Token(Token = "0x6000454")]
			[Address(RVA = "0xCA6960", Offset = "0xCA6960", Length = "0x124")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EAEB80]);\n\tv21 = *([v20 @ X8_v31]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023548]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1ECCD60]);\n\tv60 = *([v59 @ X8_v27]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([20236BD]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<ApplicationFocus>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv92 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_004F;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv132 = *([1ED0930]);\n\tv133 = *([v132 @ X8_v22]);\n\tv134 = \"il2cpp_codegen_initialize_method\"(v133, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv137 = 0 | 1;\n\t*([20236BE]) = v137;\nL_005A:\n\tgoto L_0065;\n\tv142 = *([v138 @ X0_v11 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tgoto L_0065;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v138, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv146 = HutongGames.PlayMaker.FsmEvent;\nL_0065:\n\tv116 = v148.<ApplicationPause>k__BackingField - this;\n\tv112 = v116 == 0;\n\tgoto L_0075;\nL_0075:\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0058: Expected O, but got I
				if (ApplicationFocus == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)ApplicationPause - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x17000137")]
		public bool IsLegacyNetworkEvent
		{
			[Token(Token = "0x6000455")]
			[Address(RVA = "0xCA6A84", Offset = "0xCA6A84", Length = "0x3E0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC7BF8]);\n\tv21 = *([v20 @ X8_v123]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023549]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EAADF0]);\n\tv60 = *([v59 @ X8_v119]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([20236BF]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<NetworkInstantiate>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv188 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_004F;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv228 = *([1EB2520]);\n\tv229 = *([v228 @ X8_v114]);\n\tv230 = \"il2cpp_codegen_initialize_method\"(v229, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv233 = 0 | 1;\n\t*([20236C0]) = v233;\nL_005A:\n\tgoto L_0067;\n\tv238 = *([v234 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tgoto L_0067;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v234, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv241 = HutongGames.PlayMaker.FsmEvent;\nL_0067:\n\tv124 = v243.<PlayerConnected>k__BackingField == this;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv249 = *([v164 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv250 = v249 == 0;\n\tv251 = ~v250;\n\tif (v251) goto L_007A;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v164, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tgoto L_0085;\n\tv260 = *([1EB7CC0]);\n\tv261 = *([v260 @ X8_v109]);\n\tv262 = \"il2cpp_codegen_initialize_method\"(v261, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv265 = 0 | 1;\n\t*([20236C1]) = v265;\nL_0085:\n\tgoto L_0092;\n\tv270 = *([v266 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tgoto L_0092;\n\tv277 = \"il2cpp_codegen_runtime_class_init\"(v266, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv273 = HutongGames.PlayMaker.FsmEvent;\nL_0092:\n\tv125 = v275.<PlayerDisconnected>k__BackingField == this;\n\tif (v125) goto L_FFFFFFFF;\n\tgoto L_00A5;\n\tv281 = *([v165 @ X0_v17 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_00A5;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v165, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A5:\n\tgoto L_00B0;\n\tv292 = *([1EF4F48]);\n\tv293 = *([v292 @ X8_v104]);\n\tv294 = \"il2cpp_codegen_initialize_method\"(v293, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv297 = 0 | 1;\n\t*([20236C2]) = v297;\nL_00B0:\n\tgoto L_00BD;\n\tv302 = *([v298 @ X0_v20 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tgoto L_00BD;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v298, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv305 = HutongGames.PlayMaker.FsmEvent;\nL_00BD:\n\tv126 = v307.<ConnectedToServer>k__BackingField == this;\n\tif (v126) goto L_FFFFFFFF;\n\tgoto L_00D0;\n\tv313 = *([v166 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv314 = v313 == 0;\n\tv315 = ~v314;\n\tif (v315) goto L_00D0;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v166, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D0:\n\tgoto L_00DB;\n\tv324 = *([1EDEED8]);\n\tv325 = *([v324 @ X8_v99]);\n\tv326 = \"il2cpp_codegen_initialize_method\"(v325, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv329 = 0 | 1;\n\t*([20236C3]) = v329;\nL_00DB:\n\tgoto L_00E8;\n\tv334 = *([v330 @ X0_v24 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv335 = v334 == 0;\n\tv336 = ~v335;\n\tgoto L_00E8;\n\tv341 = \"il2cpp_codegen_runtime_class_init\"(v330, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv337 = HutongGames.PlayMaker.FsmEvent;\nL_00E8:\n\tv127 = v339.<DisconnectedFromServer>k__BackingField == this;\n\tif (v127) goto L_FFFFFFFF;\n\tgoto L_00FB;\n\tv345 = *([v167 @ X0_v25 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv346 = v345 == 0;\n\tv347 = ~v346;\n\tif (v347) goto L_00FB;\n\tv349 = \"il2cpp_codegen_runtime_class_init\"(v167, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00FB:\n\tgoto L_0106;\n\tv356 = *([1EF71B8]);\n\tv357 = *([v356 @ X8_v94]);\n\tv358 = \"il2cpp_codegen_initialize_method\"(v357, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv361 = 0 | 1;\n\t*([20236C4]) = v361;\nL_0106:\n\tgoto L_0113;\n\tv366 = *([v362 @ X0_v28 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tgoto L_0113;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v362, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv369 = HutongGames.PlayMaker.FsmEvent;\nL_0113:\n\tv128 = v371.<FailedToConnect>k__BackingField == this;\n\tif (v128) goto L_FFFFFFFF;\n\tgoto L_0126;\n\tv377 = *([v168 @ X0_v29 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv378 = v377 == 0;\n\tv379 = ~v378;\n\tif (v379) goto L_0126;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v168, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0126:\n\tgoto L_0131;\n\tv388 = *([1EBEED8]);\n\tv389 = *([v388 @ X8_v89]);\n\tv390 = \"il2cpp_codegen_initialize_method\"(v389, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv393 = 0 | 1;\n\t*([20236C5]) = v393;\nL_0131:\n\tgoto L_013E;\n\tv398 = *([v394 @ X0_v32 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv399 = v398 == 0;\n\tv400 = ~v399;\n\tgoto L_013E;\n\tv405 = \"il2cpp_codegen_runtime_class_init\"(v394, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv401 = HutongGames.PlayMaker.FsmEvent;\nL_013E:\n\tv129 = v403.<FailedToConnectToMasterServer>k__BackingField == this;\n\tif (v129) goto L_FFFFFFFF;\n\tgoto L_0151;\n\tv409 = *([v169 @ X0_v33 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv410 = v409 == 0;\n\tv411 = ~v410;\n\tif (v411) goto L_0151;\n\tv413 = \"il2cpp_codegen_runtime_class_init\"(v169, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0151:\n\tgoto L_015C;\n\tv420 = *([1EDD410]);\n\tv421 = *([v420 @ X8_v84]);\n\tv422 = \"il2cpp_codegen_initialize_method\"(v421, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv425 = 0 | 1;\n\t*([20236C6]) = v425;\nL_015C:\n\tgoto L_0169;\n\tv430 = *([v426 @ X0_v36 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv431 = v430 == 0;\n\tv432 = ~v431;\n\tgoto L_0169;\n\tv437 = \"il2cpp_codegen_runtime_class_init\"(v426, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv433 = HutongGames.PlayMaker.FsmEvent;\nL_0169:\n\tv130 = v435.<MasterServerEvent>k__BackingField == this;\n\tif (v130) goto L_FFFFFFFF;\n\tgoto L_017C;\n\tv441 = *([v170 @ X0_v37 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv442 = v441 == 0;\n\tv443 = ~v442;\n\tif (v443) goto L_017C;\n\tv445 = \"il2cpp_codegen_runtime_class_init\"(v170, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_017C:\n\tgoto L_0187;\n\tv452 = *([1F0F3F8]);\n\tv453 = *([v452 @ X8_v79]);\n\tv454 = \"il2cpp_codegen_initialize_method\"(v453, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32,\n// ... truncated")]
			get
			{
				//IL_0177: Expected O, but got I
				if (NetworkInstantiate == this || PlayerConnected == this || PlayerDisconnected == this || ConnectedToServer == this || DisconnectedFromServer == this || FailedToConnect == this || FailedToConnectToMasterServer == this || MasterServerEvent == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)ServerInitialized - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x17000138")]
		public bool IsCollisionEvent
		{
			[Token(Token = "0x6000456")]
			[Address(RVA = "0xCA6E64", Offset = "0xCA6E64", Length = "0x188")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA3BD8]);\n\tv21 = *([v20 @ X8_v45]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202354A]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1ED41F8]);\n\tv60 = *([v59 @ X8_v41]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021A93]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<CollisionEnter>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv116 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_004F;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv156 = *([1ED1F38]);\n\tv157 = *([v156 @ X8_v36]);\n\tv158 = \"il2cpp_codegen_initialize_method\"(v157, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv161 = 0 | 1;\n\t*([2021A95]) = v161;\nL_005A:\n\tgoto L_0067;\n\tv166 = *([v162 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tgoto L_0067;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v162, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv169 = HutongGames.PlayMaker.FsmEvent;\nL_0067:\n\tv100 = v171.<CollisionStay>k__BackingField == this;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv177 = *([v110 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_007A;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v110, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tgoto L_0085;\n\tv188 = *([1EA33F8]);\n\tv189 = *([v188 @ X8_v31]);\n\tv190 = \"il2cpp_codegen_initialize_method\"(v189, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv193 = 0 | 1;\n\t*([2021A94]) = v193;\nL_0085:\n\tgoto L_0090;\n\tv198 = *([v194 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tgoto L_0090;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v194, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv202 = HutongGames.PlayMaker.FsmEvent;\nL_0090:\n\tv139 = v204.<CollisionExit>k__BackingField - this;\n\tv135 = v139 == 0;\n\tgoto L_00A0;\nL_00A0:\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0081: Expected O, but got I
				if (CollisionEnter == this || CollisionStay == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)CollisionExit - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x17000139")]
		public bool IsTriggerEvent
		{
			[Token(Token = "0x6000457")]
			[Address(RVA = "0xCA6FEC", Offset = "0xCA6FEC", Length = "0x188")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F0C4C8]);\n\tv21 = *([v20 @ X8_v45]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202354B]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EB9880]);\n\tv60 = *([v59 @ X8_v41]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021A90]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<TriggerEnter>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv116 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_004F;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv156 = *([1EC2C80]);\n\tv157 = *([v156 @ X8_v36]);\n\tv158 = \"il2cpp_codegen_initialize_method\"(v157, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv161 = 0 | 1;\n\t*([2021A92]) = v161;\nL_005A:\n\tgoto L_0067;\n\tv166 = *([v162 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tgoto L_0067;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v162, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv169 = HutongGames.PlayMaker.FsmEvent;\nL_0067:\n\tv100 = v171.<TriggerStay>k__BackingField == this;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv177 = *([v110 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_007A;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v110, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tgoto L_0085;\n\tv188 = *([1EEF9A8]);\n\tv189 = *([v188 @ X8_v31]);\n\tv190 = \"il2cpp_codegen_initialize_method\"(v189, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv193 = 0 | 1;\n\t*([2021A91]) = v193;\nL_0085:\n\tgoto L_0090;\n\tv198 = *([v194 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tgoto L_0090;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v194, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv202 = HutongGames.PlayMaker.FsmEvent;\nL_0090:\n\tv139 = v204.<TriggerExit>k__BackingField - this;\n\tv135 = v139 == 0;\n\tgoto L_00A0;\nL_00A0:\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0081: Expected O, but got I
				if (TriggerEnter == this || TriggerStay == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)TriggerExit - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x1700013A")]
		public bool IsCollision2DEvent
		{
			[Token(Token = "0x6000458")]
			[Address(RVA = "0xCA7174", Offset = "0xCA7174", Length = "0x188")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECBE20]);\n\tv21 = *([v20 @ X8_v45]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202354C]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EC7600]);\n\tv60 = *([v59 @ X8_v41]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021A99]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<CollisionEnter2D>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv116 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_004F;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv156 = *([1EE6288]);\n\tv157 = *([v156 @ X8_v36]);\n\tv158 = \"il2cpp_codegen_initialize_method\"(v157, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv161 = 0 | 1;\n\t*([2021A9B]) = v161;\nL_005A:\n\tgoto L_0067;\n\tv166 = *([v162 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tgoto L_0067;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v162, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv169 = HutongGames.PlayMaker.FsmEvent;\nL_0067:\n\tv100 = v171.<CollisionStay2D>k__BackingField == this;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv177 = *([v110 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_007A;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v110, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tgoto L_0085;\n\tv188 = *([1EF6EA8]);\n\tv189 = *([v188 @ X8_v31]);\n\tv190 = \"il2cpp_codegen_initialize_method\"(v189, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv193 = 0 | 1;\n\t*([2021A9A]) = v193;\nL_0085:\n\tgoto L_0090;\n\tv198 = *([v194 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tgoto L_0090;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v194, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv202 = HutongGames.PlayMaker.FsmEvent;\nL_0090:\n\tv139 = v204.<CollisionExit2D>k__BackingField - this;\n\tv135 = v139 == 0;\n\tgoto L_00A0;\nL_00A0:\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0081: Expected O, but got I
				if (CollisionEnter2D == this || CollisionStay2D == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)CollisionExit2D - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x1700013B")]
		public bool IsTrigger2DEvent
		{
			[Token(Token = "0x6000459")]
			[Address(RVA = "0xCA72FC", Offset = "0xCA72FC", Length = "0x188")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EE9110]);\n\tv21 = *([v20 @ X8_v45]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202354D]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EE5AC8]);\n\tv60 = *([v59 @ X8_v41]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021A96]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<TriggerEnter2D>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv116 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_004F;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv156 = *([1EBC548]);\n\tv157 = *([v156 @ X8_v36]);\n\tv158 = \"il2cpp_codegen_initialize_method\"(v157, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv161 = 0 | 1;\n\t*([2021A98]) = v161;\nL_005A:\n\tgoto L_0067;\n\tv166 = *([v162 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tgoto L_0067;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v162, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv169 = HutongGames.PlayMaker.FsmEvent;\nL_0067:\n\tv100 = v171.<TriggerStay2D>k__BackingField == this;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv177 = *([v110 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_007A;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v110, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tgoto L_0085;\n\tv188 = *([1F04C38]);\n\tv189 = *([v188 @ X8_v31]);\n\tv190 = \"il2cpp_codegen_initialize_method\"(v189, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv193 = 0 | 1;\n\t*([2021A97]) = v193;\nL_0085:\n\tgoto L_0090;\n\tv198 = *([v194 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tgoto L_0090;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v194, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv202 = HutongGames.PlayMaker.FsmEvent;\nL_0090:\n\tv139 = v204.<TriggerExit2D>k__BackingField - this;\n\tv135 = v139 == 0;\n\tgoto L_00A0;\nL_00A0:\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0081: Expected O, but got I
				if (TriggerEnter2D == this || TriggerStay2D == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)TriggerExit2D - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x1700013C")]
		public bool IsUIEvent
		{
			[Token(Token = "0x600045A")]
			[Address(RVA = "0xCA7484", Offset = "0xCA7484", Length = "0x638")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA8940]);\n\tv21 = *([v20 @ X8_v201]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202354E]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EEEF58]);\n\tv60 = *([v59 @ X8_v197]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021713]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003C:\n\tv82 = v76.<UiClick>k__BackingField == this;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_004F;\n\tv260 = *([v72 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv261 = v260 == 0;\n\tv262 = ~v261;\n\tif (v262) goto L_004F;\n\tv264 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tgoto L_005A;\n\tv300 = *([1EB0DC8]);\n\tv301 = *([v300 @ X8_v192]);\n\tv302 = \"il2cpp_codegen_initialize_method\"(v301, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv305 = 0 | 1;\n\t*([2021714]) = v305;\nL_005A:\n\tgoto L_0067;\n\tv310 = *([v306 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tgoto L_0067;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v306, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv313 = HutongGames.PlayMaker.FsmEvent;\nL_0067:\n\tv148 = v315.<UiBeginDrag>k__BackingField == this;\n\tif (v148) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv321 = *([v218 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv322 = v321 == 0;\n\tv323 = ~v322;\n\tif (v323) goto L_007A;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v218, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tgoto L_0085;\n\tv332 = *([1EF2538]);\n\tv333 = *([v332 @ X8_v187]);\n\tv334 = \"il2cpp_codegen_initialize_method\"(v333, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv337 = 0 | 1;\n\t*([2021715]) = v337;\nL_0085:\n\tgoto L_0092;\n\tv342 = *([v338 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv343 = v342 == 0;\n\tv344 = ~v343;\n\tgoto L_0092;\n\tv349 = \"il2cpp_codegen_runtime_class_init\"(v338, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv345 = HutongGames.PlayMaker.FsmEvent;\nL_0092:\n\tv149 = v347.<UiDrag>k__BackingField == this;\n\tif (v149) goto L_FFFFFFFF;\n\tgoto L_00A5;\n\tv353 = *([v219 @ X0_v17 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv354 = v353 == 0;\n\tv355 = ~v354;\n\tif (v355) goto L_00A5;\n\tv357 = \"il2cpp_codegen_runtime_class_init\"(v219, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A5:\n\tgoto L_00B0;\n\tv364 = *([1EDB300]);\n\tv365 = *([v364 @ X8_v182]);\n\tv366 = \"il2cpp_codegen_initialize_method\"(v365, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv369 = 0 | 1;\n\t*([2021716]) = v369;\nL_00B0:\n\tgoto L_00BD;\n\tv374 = *([v370 @ X0_v20 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv375 = v374 == 0;\n\tv376 = ~v375;\n\tgoto L_00BD;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v370, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv377 = HutongGames.PlayMaker.FsmEvent;\nL_00BD:\n\tv150 = v379.<UiEndDrag>k__BackingField == this;\n\tif (v150) goto L_FFFFFFFF;\n\tgoto L_00D0;\n\tv385 = *([v220 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv386 = v385 == 0;\n\tv387 = ~v386;\n\tif (v387) goto L_00D0;\n\tv389 = \"il2cpp_codegen_runtime_class_init\"(v220, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D0:\n\tgoto L_00DB;\n\tv396 = *([1ED3EF8]);\n\tv397 = *([v396 @ X8_v177]);\n\tv398 = \"il2cpp_codegen_initialize_method\"(v397, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv401 = 0 | 1;\n\t*([2021717]) = v401;\nL_00DB:\n\tgoto L_00E8;\n\tv406 = *([v402 @ X0_v24 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv407 = v406 == 0;\n\tv408 = ~v407;\n\tgoto L_00E8;\n\tv413 = \"il2cpp_codegen_runtime_class_init\"(v402, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv409 = HutongGames.PlayMaker.FsmEvent;\nL_00E8:\n\tv151 = v411.<UiDrop>k__BackingField == this;\n\tif (v151) goto L_FFFFFFFF;\n\tgoto L_00FB;\n\tv417 = *([v221 @ X0_v25 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv418 = v417 == 0;\n\tv419 = ~v418;\n\tif (v419) goto L_00FB;\n\tv421 = \"il2cpp_codegen_runtime_class_init\"(v221, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00FB:\n\tgoto L_0106;\n\tv428 = *([1EAAC70]);\n\tv429 = *([v428 @ X8_v172]);\n\tv430 = \"il2cpp_codegen_initialize_method\"(v429, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv433 = 0 | 1;\n\t*([202171F]) = v433;\nL_0106:\n\tgoto L_0113;\n\tv438 = *([v434 @ X0_v28 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv439 = v438 == 0;\n\tv440 = ~v439;\n\tgoto L_0113;\n\tv445 = \"il2cpp_codegen_runtime_class_init\"(v434, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv441 = HutongGames.PlayMaker.FsmEvent;\nL_0113:\n\tv152 = v443.<UiPointerUp>k__BackingField == this;\n\tif (v152) goto L_FFFFFFFF;\n\tgoto L_0126;\n\tv449 = *([v222 @ X0_v29 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv450 = v449 == 0;\n\tv451 = ~v450;\n\tif (v451) goto L_0126;\n\tv453 = \"il2cpp_codegen_runtime_class_init\"(v222, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0126:\n\tgoto L_0131;\n\tv460 = *([1F08128]);\n\tv461 = *([v460 @ X8_v167]);\n\tv462 = \"il2cpp_codegen_initialize_method\"(v461, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv465 = 0 | 1;\n\t*([202171B]) = v465;\nL_0131:\n\tgoto L_013E;\n\tv470 = *([v466 @ X0_v32 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv471 = v470 == 0;\n\tv472 = ~v471;\n\tgoto L_013E;\n\tv477 = \"il2cpp_codegen_runtime_class_init\"(v466, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv473 = HutongGames.PlayMaker.FsmEvent;\nL_013E:\n\tv153 = v475.<UiPointerClick>k__BackingField == this;\n\tif (v153) goto L_FFFFFFFF;\n\tgoto L_0151;\n\tv481 = *([v223 @ X0_v33 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv482 = v481 == 0;\n\tv483 = ~v482;\n\tif (v483) goto L_0151;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v223, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0151:\n\tgoto L_015C;\n\tv492 = *([1EBDF10]);\n\tv493 = *([v492 @ X8_v162]);\n\tv494 = \"il2cpp_codegen_initialize_method\"(v493, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv497 = 0 | 1;\n\t*([202171C]) = v497;\nL_015C:\n\tgoto L_0169;\n\tv502 = *([v498 @ X0_v36 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv503 = v502 == 0;\n\tv504 = ~v503;\n\tgoto L_0169;\n\tv509 = \"il2cpp_codegen_runtime_class_init\"(v498, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv505 = HutongGames.PlayMaker.FsmEvent;\nL_0169:\n\tv154 = v507.<UiPointerDown>k__BackingField == this;\n\tif (v154) goto L_FFFFFFFF;\n\tgoto L_017C;\n\tv513 = *([v224 @ X0_v37 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv514 = v513 == 0;\n\tv515 = ~v514;\n\tif (v515) goto L_017C;\n\tv517 = \"il2cpp_codegen_runtime_class_init\"(v224, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_017C:\n\tgoto L_0187;\n\tv524 = *([1F01108]);\n\tv525 = *([v524 @ X8_v157]);\n\tv526 = \"il2cpp_codegen_initialize_method\"(v525, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv529 = 0 | 1;\n\t*([202171D]) = v529;\nL_018\n// ... truncated")]
			get
			{
				//IL_026d: Expected O, but got I
				if (UiClick == this || UiBeginDrag == this || UiDrag == this || UiEndDrag == this || UiDrop == this || UiPointerUp == this || UiPointerClick == this || UiPointerDown == this || UiPointerEnter == this || UiPointerExit == this || UiBoolValueChanged == this || UiFloatValueChanged == this || UiIntValueChanged == this || UiVector2ValueChanged == this)
				{
					return true;
				}
				object obj = (long)(IntPtr)UiEndEdit - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x1700013D")]
		public bool IsGlobal
		{
			[Token(Token = "0x600045B")]
			[Address(RVA = "0xCA7ABC", Offset = "0xCA7ABC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isGlobal;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsGlobal;
			}
			[Token(Token = "0x600045C")]
			[Address(RVA = "0xCA7AC4", Offset = "0xCA7AC4", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED7A88]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202354F]) = v41;\nL_0018:\n\tv45 = value == 0;\n\tif (v45) goto L_001C;\n\tPlayMakerGlobals::AddGlobalEvent(this.name);\n\tgoto L_001E;\nL_001C:\n\tPlayMakerGlobals::RemoveGlobalEvent(this.name);\nL_001E:\n\tthis.isGlobal = value;\n\tgoto L_0031;\n\tv53 = *([v49 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0031;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0031:\n\tHutongGames.PlayMaker.FsmEvent::SanityCheckEventList();\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value)
				{
					PlayMakerGlobals.AddGlobalEvent(Name);
				}
				else
				{
					PlayMakerGlobals.RemoveGlobalEvent(Name);
				}
				isGlobal = value;
				SanityCheckEventList();
			}
		}

		[Token(Token = "0x1700013E")]
		public string Path
		{
			[CompilerGenerated]
			[Token(Token = "0x600045E")]
			[Address(RVA = "0xCA7D68", Offset = "0xCA7D68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Path>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Path;
			}
			[CompilerGenerated]
			[Token(Token = "0x600045F")]
			[Address(RVA = "0xCA7D70", Offset = "0xCA7D70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Path>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Path = value;
			}
		}

		[Token(Token = "0x1700013F")]
		[field: Token(Token = "0x4000270")]
		public static FsmEvent BecameInvisible
		{
			[Token(Token = "0x600046D")]
			[Address(RVA = "0xCA8A2C", Offset = "0xCA8A2C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC0648]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202355D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<BecameInvisible>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600046E")]
			[Address(RVA = "0xCA8A94", Offset = "0xCA8A94", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB05B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202355E]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<BecameInvisible>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000140")]
		[field: Token(Token = "0x4000271")]
		public static FsmEvent BecameVisible
		{
			[Token(Token = "0x600046F")]
			[Address(RVA = "0xCA8B00", Offset = "0xCA8B00", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED7878]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202355F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<BecameVisible>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000470")]
			[Address(RVA = "0xCA8B68", Offset = "0xCA8B68", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDBB30]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023560]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<BecameVisible>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000141")]
		[field: Token(Token = "0x4000272")]
		public static FsmEvent CollisionEnter
		{
			[Token(Token = "0x6000471")]
			[Address(RVA = "0xCA8BD4", Offset = "0xCA8BD4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F093D8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023561]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<CollisionEnter>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000472")]
			[Address(RVA = "0xCA8C3C", Offset = "0xCA8C3C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC89F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023562]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<CollisionEnter>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000142")]
		[field: Token(Token = "0x4000273")]
		public static FsmEvent CollisionExit
		{
			[Token(Token = "0x6000473")]
			[Address(RVA = "0xCA8CA8", Offset = "0xCA8CA8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBEFD0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023563]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<CollisionExit>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000474")]
			[Address(RVA = "0xCA8D10", Offset = "0xCA8D10", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE9238]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023564]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<CollisionExit>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000143")]
		[field: Token(Token = "0x4000274")]
		public static FsmEvent CollisionStay
		{
			[Token(Token = "0x6000475")]
			[Address(RVA = "0xCA8D7C", Offset = "0xCA8D7C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBDAB8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023565]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<CollisionStay>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000476")]
			[Address(RVA = "0xCA8DE4", Offset = "0xCA8DE4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDC7B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023566]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<CollisionStay>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000144")]
		[field: Token(Token = "0x4000275")]
		public static FsmEvent CollisionEnter2D
		{
			[Token(Token = "0x6000477")]
			[Address(RVA = "0xCA8E50", Offset = "0xCA8E50", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB71F0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023567]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<CollisionEnter2D>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000478")]
			[Address(RVA = "0xCA8EB8", Offset = "0xCA8EB8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC4200]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023568]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<CollisionEnter2D>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000145")]
		[field: Token(Token = "0x4000276")]
		public static FsmEvent CollisionExit2D
		{
			[Token(Token = "0x6000479")]
			[Address(RVA = "0xCA8F24", Offset = "0xCA8F24", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F033E0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023569]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<CollisionExit2D>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600047A")]
			[Address(RVA = "0xCA8F8C", Offset = "0xCA8F8C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFE6B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202356A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<CollisionExit2D>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000146")]
		[field: Token(Token = "0x4000277")]
		public static FsmEvent CollisionStay2D
		{
			[Token(Token = "0x600047B")]
			[Address(RVA = "0xCA8FF8", Offset = "0xCA8FF8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF3960]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202356B]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<CollisionStay2D>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600047C")]
			[Address(RVA = "0xCA9060", Offset = "0xCA9060", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED8110]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202356C]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<CollisionStay2D>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000147")]
		[field: Token(Token = "0x4000278")]
		public static FsmEvent ControllerColliderHit
		{
			[Token(Token = "0x600047D")]
			[Address(RVA = "0xCA90CC", Offset = "0xCA90CC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDECB8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202356D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<ControllerColliderHit>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600047E")]
			[Address(RVA = "0xCA9134", Offset = "0xCA9134", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE0F88]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202356E]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<ControllerColliderHit>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000148")]
		[field: Token(Token = "0x4000279")]
		public static FsmEvent Finished
		{
			[Token(Token = "0x600047F")]
			[Address(RVA = "0xCA91A0", Offset = "0xCA91A0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F02800]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202356F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<Finished>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000480")]
			[Address(RVA = "0xCA9208", Offset = "0xCA9208", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA3A40]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023570]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<Finished>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000149")]
		[field: Token(Token = "0x400027A")]
		public static FsmEvent LevelLoaded
		{
			[Token(Token = "0x6000481")]
			[Address(RVA = "0xCA9274", Offset = "0xCA9274", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFA7F0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023571]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<LevelLoaded>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000482")]
			[Address(RVA = "0xCA92DC", Offset = "0xCA92DC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F061E8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023572]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<LevelLoaded>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700014A")]
		[field: Token(Token = "0x400027B")]
		public static FsmEvent MouseDown
		{
			[Token(Token = "0x6000483")]
			[Address(RVA = "0xCA9348", Offset = "0xCA9348", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F03298]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023573]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MouseDown>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000484")]
			[Address(RVA = "0xCA93B0", Offset = "0xCA93B0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED8EA0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023574]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MouseDown>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700014B")]
		[field: Token(Token = "0x400027C")]
		public static FsmEvent MouseDrag
		{
			[Token(Token = "0x6000485")]
			[Address(RVA = "0xCA941C", Offset = "0xCA941C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB5178]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023575]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MouseDrag>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000486")]
			[Address(RVA = "0xCA9484", Offset = "0xCA9484", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFF310]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023576]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MouseDrag>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700014C")]
		[field: Token(Token = "0x400027D")]
		public static FsmEvent MouseEnter
		{
			[Token(Token = "0x6000487")]
			[Address(RVA = "0xCA94F0", Offset = "0xCA94F0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F08408]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023577]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MouseEnter>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000488")]
			[Address(RVA = "0xCA9558", Offset = "0xCA9558", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC2320]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023578]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MouseEnter>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700014D")]
		[field: Token(Token = "0x400027E")]
		public static FsmEvent MouseExit
		{
			[Token(Token = "0x6000489")]
			[Address(RVA = "0xCA95C4", Offset = "0xCA95C4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC2510]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023579]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MouseExit>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600048A")]
			[Address(RVA = "0xCA962C", Offset = "0xCA962C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEF210]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202357A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MouseExit>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700014E")]
		[field: Token(Token = "0x400027F")]
		public static FsmEvent MouseOver
		{
			[Token(Token = "0x600048B")]
			[Address(RVA = "0xCA9698", Offset = "0xCA9698", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA63F0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202357B]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MouseOver>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600048C")]
			[Address(RVA = "0xCA9700", Offset = "0xCA9700", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F04B08]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202357C]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MouseOver>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700014F")]
		[field: Token(Token = "0x4000280")]
		public static FsmEvent MouseUp
		{
			[Token(Token = "0x600048D")]
			[Address(RVA = "0xCA976C", Offset = "0xCA976C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBF370]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202357D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MouseUp>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600048E")]
			[Address(RVA = "0xCA97D4", Offset = "0xCA97D4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF91B8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202357E]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MouseUp>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000150")]
		[field: Token(Token = "0x4000281")]
		public static FsmEvent MouseUpAsButton
		{
			[Token(Token = "0x600048F")]
			[Address(RVA = "0xCA9840", Offset = "0xCA9840", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDBC30]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202357F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MouseUpAsButton>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000490")]
			[Address(RVA = "0xCA98A8", Offset = "0xCA98A8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F013A8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023580]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MouseUpAsButton>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000151")]
		[field: Token(Token = "0x4000282")]
		public static FsmEvent TriggerEnter
		{
			[Token(Token = "0x6000491")]
			[Address(RVA = "0xCA9914", Offset = "0xCA9914", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECE928]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023581]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<TriggerEnter>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000492")]
			[Address(RVA = "0xCA997C", Offset = "0xCA997C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC85B8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023582]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<TriggerEnter>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000152")]
		[field: Token(Token = "0x4000283")]
		public static FsmEvent TriggerExit
		{
			[Token(Token = "0x6000493")]
			[Address(RVA = "0xCA99E8", Offset = "0xCA99E8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFF968]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023583]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<TriggerExit>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000494")]
			[Address(RVA = "0xCA9A50", Offset = "0xCA9A50", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC9F48]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023584]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<TriggerExit>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000153")]
		[field: Token(Token = "0x4000284")]
		public static FsmEvent TriggerStay
		{
			[Token(Token = "0x6000495")]
			[Address(RVA = "0xCA9ABC", Offset = "0xCA9ABC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDF5E8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023585]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<TriggerStay>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000496")]
			[Address(RVA = "0xCA9B24", Offset = "0xCA9B24", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF6FC8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023586]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<TriggerStay>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000154")]
		[field: Token(Token = "0x4000285")]
		public static FsmEvent TriggerEnter2D
		{
			[Token(Token = "0x6000497")]
			[Address(RVA = "0xCA9B90", Offset = "0xCA9B90", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBBCD0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023587]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<TriggerEnter2D>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000498")]
			[Address(RVA = "0xCA9BF8", Offset = "0xCA9BF8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBC430]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023588]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<TriggerEnter2D>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000155")]
		[field: Token(Token = "0x4000286")]
		public static FsmEvent TriggerExit2D
		{
			[Token(Token = "0x6000499")]
			[Address(RVA = "0xCA9C64", Offset = "0xCA9C64", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE19C8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023589]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<TriggerExit2D>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600049A")]
			[Address(RVA = "0xCA9CCC", Offset = "0xCA9CCC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA8A30]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202358A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<TriggerExit2D>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000156")]
		[field: Token(Token = "0x4000287")]
		public static FsmEvent TriggerStay2D
		{
			[Token(Token = "0x600049B")]
			[Address(RVA = "0xCA9D38", Offset = "0xCA9D38", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F01E48]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202358B]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<TriggerStay2D>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600049C")]
			[Address(RVA = "0xCA9DA0", Offset = "0xCA9DA0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF05D8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202358C]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<TriggerStay2D>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000157")]
		[field: Token(Token = "0x4000288")]
		public static FsmEvent ApplicationFocus
		{
			[Token(Token = "0x600049D")]
			[Address(RVA = "0xCA9E0C", Offset = "0xCA9E0C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA77C0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202358D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<ApplicationFocus>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600049E")]
			[Address(RVA = "0xCA9E74", Offset = "0xCA9E74", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEF590]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202358E]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<ApplicationFocus>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000158")]
		[field: Token(Token = "0x4000289")]
		public static FsmEvent ApplicationPause
		{
			[Token(Token = "0x600049F")]
			[Address(RVA = "0xCA9EE0", Offset = "0xCA9EE0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB9268]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202358F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<ApplicationPause>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004A0")]
			[Address(RVA = "0xCA9F48", Offset = "0xCA9F48", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F03030]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023590]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<ApplicationPause>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000159")]
		[field: Token(Token = "0x400028A")]
		public static FsmEvent ApplicationQuit
		{
			[Token(Token = "0x60004A1")]
			[Address(RVA = "0xCA9FB4", Offset = "0xCA9FB4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEEC28]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023591]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<ApplicationQuit>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004A2")]
			[Address(RVA = "0xCAA01C", Offset = "0xCAA01C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE29E0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023592]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<ApplicationQuit>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700015A")]
		[field: Token(Token = "0x400028B")]
		public static FsmEvent ParticleCollision
		{
			[Token(Token = "0x60004A3")]
			[Address(RVA = "0xCAA088", Offset = "0xCAA088", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F02CA0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023593]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<ParticleCollision>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004A4")]
			[Address(RVA = "0xCAA0F0", Offset = "0xCAA0F0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED5B70]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023594]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<ParticleCollision>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700015B")]
		[field: Token(Token = "0x400028C")]
		public static FsmEvent JointBreak
		{
			[Token(Token = "0x60004A5")]
			[Address(RVA = "0xCAA15C", Offset = "0xCAA15C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F062C0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023595]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<JointBreak>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004A6")]
			[Address(RVA = "0xCAA1C4", Offset = "0xCAA1C4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F01220]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023596]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<JointBreak>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700015C")]
		[field: Token(Token = "0x400028D")]
		public static FsmEvent JointBreak2D
		{
			[Token(Token = "0x60004A7")]
			[Address(RVA = "0xCAA230", Offset = "0xCAA230", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBBB48]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023597]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<JointBreak2D>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004A8")]
			[Address(RVA = "0xCAA298", Offset = "0xCAA298", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED1F90]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023598]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<JointBreak2D>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700015D")]
		[field: Token(Token = "0x400028E")]
		public static FsmEvent Disable
		{
			[Token(Token = "0x60004A9")]
			[Address(RVA = "0xCAA304", Offset = "0xCAA304", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0B920]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023599]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<Disable>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004AA")]
			[Address(RVA = "0xCAA36C", Offset = "0xCAA36C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFCB40]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202359A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<Disable>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700015E")]
		[field: Token(Token = "0x400028F")]
		public static FsmEvent PlayerConnected
		{
			[Token(Token = "0x60004AB")]
			[Address(RVA = "0xCAA3D8", Offset = "0xCAA3D8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F07140]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202359B]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<PlayerConnected>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004AC")]
			[Address(RVA = "0xCAA440", Offset = "0xCAA440", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECEAD0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202359C]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<PlayerConnected>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700015F")]
		[field: Token(Token = "0x4000290")]
		public static FsmEvent ServerInitialized
		{
			[Token(Token = "0x60004AD")]
			[Address(RVA = "0xCAA4AC", Offset = "0xCAA4AC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F01200]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202359D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<ServerInitialized>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004AE")]
			[Address(RVA = "0xCAA514", Offset = "0xCAA514", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF8588]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202359E]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<ServerInitialized>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000160")]
		[field: Token(Token = "0x4000291")]
		public static FsmEvent ConnectedToServer
		{
			[Token(Token = "0x60004AF")]
			[Address(RVA = "0xCAA580", Offset = "0xCAA580", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAD408]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202359F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<ConnectedToServer>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004B0")]
			[Address(RVA = "0xCAA5E8", Offset = "0xCAA5E8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC0F30]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235A0]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<ConnectedToServer>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000161")]
		[field: Token(Token = "0x4000292")]
		public static FsmEvent PlayerDisconnected
		{
			[Token(Token = "0x60004B1")]
			[Address(RVA = "0xCAA654", Offset = "0xCAA654", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F02A48]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235A1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<PlayerDisconnected>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004B2")]
			[Address(RVA = "0xCAA6BC", Offset = "0xCAA6BC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB4810]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235A2]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<PlayerDisconnected>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000162")]
		[field: Token(Token = "0x4000293")]
		public static FsmEvent DisconnectedFromServer
		{
			[Token(Token = "0x60004B3")]
			[Address(RVA = "0xCAA728", Offset = "0xCAA728", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF8C18]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235A3]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<DisconnectedFromServer>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004B4")]
			[Address(RVA = "0xCAA790", Offset = "0xCAA790", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF8EE0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235A4]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<DisconnectedFromServer>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000163")]
		[field: Token(Token = "0x4000294")]
		public static FsmEvent FailedToConnect
		{
			[Token(Token = "0x60004B5")]
			[Address(RVA = "0xCAA7FC", Offset = "0xCAA7FC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB24A8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235A5]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<FailedToConnect>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004B6")]
			[Address(RVA = "0xCAA864", Offset = "0xCAA864", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F03DB8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235A6]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<FailedToConnect>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000164")]
		[field: Token(Token = "0x4000295")]
		public static FsmEvent FailedToConnectToMasterServer
		{
			[Token(Token = "0x60004B7")]
			[Address(RVA = "0xCAA8D0", Offset = "0xCAA8D0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB01C8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235A7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<FailedToConnectToMasterServer>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004B8")]
			[Address(RVA = "0xCAA938", Offset = "0xCAA938", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED3EC8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235A8]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<FailedToConnectToMasterServer>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000165")]
		[field: Token(Token = "0x4000296")]
		public static FsmEvent MasterServerEvent
		{
			[Token(Token = "0x60004B9")]
			[Address(RVA = "0xCAA9A4", Offset = "0xCAA9A4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE0E60]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235A9]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<MasterServerEvent>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004BA")]
			[Address(RVA = "0xCAAA0C", Offset = "0xCAAA0C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF6D98]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235AA]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<MasterServerEvent>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000166")]
		[field: Token(Token = "0x4000297")]
		public static FsmEvent NetworkInstantiate
		{
			[Token(Token = "0x60004BB")]
			[Address(RVA = "0xCAAA78", Offset = "0xCAAA78", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE8368]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235AB]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<NetworkInstantiate>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004BC")]
			[Address(RVA = "0xCAAAE0", Offset = "0xCAAAE0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB8F40]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235AC]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<NetworkInstantiate>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000167")]
		[field: Token(Token = "0x4000298")]
		public static FsmEvent UiBeginDrag
		{
			[Token(Token = "0x60004BD")]
			[Address(RVA = "0xCAAB4C", Offset = "0xCAAB4C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE0240]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235AD]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiBeginDrag>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004BE")]
			[Address(RVA = "0xCAABB4", Offset = "0xCAABB4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED9CF0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235AE]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiBeginDrag>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000168")]
		[field: Token(Token = "0x4000299")]
		public static FsmEvent UiDrag
		{
			[Token(Token = "0x60004BF")]
			[Address(RVA = "0xCAAC20", Offset = "0xCAAC20", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFB088]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235AF]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiDrag>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004C0")]
			[Address(RVA = "0xCAAC88", Offset = "0xCAAC88", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBC248]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235B0]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiDrag>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000169")]
		[field: Token(Token = "0x400029A")]
		public static FsmEvent UiEndDrag
		{
			[Token(Token = "0x60004C1")]
			[Address(RVA = "0xCAACF4", Offset = "0xCAACF4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF6710]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235B1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiEndDrag>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004C2")]
			[Address(RVA = "0xCAAD5C", Offset = "0xCAAD5C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED2038]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235B2]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiEndDrag>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700016A")]
		[field: Token(Token = "0x400029B")]
		public static FsmEvent UiClick
		{
			[Token(Token = "0x60004C3")]
			[Address(RVA = "0xCAADC8", Offset = "0xCAADC8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAB630]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235B3]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiClick>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004C4")]
			[Address(RVA = "0xCAAE30", Offset = "0xCAAE30", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED39B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235B4]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiClick>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700016B")]
		[field: Token(Token = "0x400029C")]
		public static FsmEvent UiDrop
		{
			[Token(Token = "0x60004C5")]
			[Address(RVA = "0xCAAE9C", Offset = "0xCAAE9C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBAA28]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235B5]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiDrop>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004C6")]
			[Address(RVA = "0xCAAF04", Offset = "0xCAAF04", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED22A8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235B6]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiDrop>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700016C")]
		[field: Token(Token = "0x400029D")]
		public static FsmEvent UiPointerClick
		{
			[Token(Token = "0x60004C7")]
			[Address(RVA = "0xCAAF70", Offset = "0xCAAF70", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF5068]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235B7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiPointerClick>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004C8")]
			[Address(RVA = "0xCAAFD8", Offset = "0xCAAFD8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0D380]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235B8]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiPointerClick>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700016D")]
		[field: Token(Token = "0x400029E")]
		public static FsmEvent UiPointerDown
		{
			[Token(Token = "0x60004C9")]
			[Address(RVA = "0xCAB044", Offset = "0xCAB044", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFC740]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235B9]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiPointerDown>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004CA")]
			[Address(RVA = "0xCAB0AC", Offset = "0xCAB0AC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDFCA8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235BA]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiPointerDown>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700016E")]
		[field: Token(Token = "0x400029F")]
		public static FsmEvent UiPointerEnter
		{
			[Token(Token = "0x60004CB")]
			[Address(RVA = "0xCAB118", Offset = "0xCAB118", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEFE20]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235BB]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiPointerEnter>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004CC")]
			[Address(RVA = "0xCAB180", Offset = "0xCAB180", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED96A0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235BC]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiPointerEnter>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700016F")]
		[field: Token(Token = "0x40002A0")]
		public static FsmEvent UiPointerExit
		{
			[Token(Token = "0x60004CD")]
			[Address(RVA = "0xCAB1EC", Offset = "0xCAB1EC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBC288]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235BD]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiPointerExit>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004CE")]
			[Address(RVA = "0xCAB254", Offset = "0xCAB254", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA92B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235BE]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiPointerExit>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000170")]
		[field: Token(Token = "0x40002A1")]
		public static FsmEvent UiPointerUp
		{
			[Token(Token = "0x60004CF")]
			[Address(RVA = "0xCAB2C0", Offset = "0xCAB2C0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAB408]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235BF]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiPointerUp>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004D0")]
			[Address(RVA = "0xCAB328", Offset = "0xCAB328", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F08770]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235C0]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiPointerUp>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000171")]
		[field: Token(Token = "0x40002A2")]
		public static FsmEvent UiBoolValueChanged
		{
			[Token(Token = "0x60004D1")]
			[Address(RVA = "0xCAB394", Offset = "0xCAB394", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEDB48]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235C1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiBoolValueChanged>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004D2")]
			[Address(RVA = "0xCAB3FC", Offset = "0xCAB3FC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF6D78]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235C2]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiBoolValueChanged>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000172")]
		[field: Token(Token = "0x40002A3")]
		public static FsmEvent UiFloatValueChanged
		{
			[Token(Token = "0x60004D3")]
			[Address(RVA = "0xCAB468", Offset = "0xCAB468", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F08280]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235C3]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiFloatValueChanged>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004D4")]
			[Address(RVA = "0xCAB4D0", Offset = "0xCAB4D0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F07878]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235C4]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiFloatValueChanged>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000173")]
		[field: Token(Token = "0x40002A4")]
		public static FsmEvent UiIntValueChanged
		{
			[Token(Token = "0x60004D5")]
			[Address(RVA = "0xCAB53C", Offset = "0xCAB53C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0C710]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235C5]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiIntValueChanged>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004D6")]
			[Address(RVA = "0xCAB5A4", Offset = "0xCAB5A4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED8E80]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235C6]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiIntValueChanged>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000174")]
		[field: Token(Token = "0x40002A5")]
		public static FsmEvent UiVector2ValueChanged
		{
			[Token(Token = "0x60004D7")]
			[Address(RVA = "0xCAB610", Offset = "0xCAB610", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0C758]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235C7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiVector2ValueChanged>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004D8")]
			[Address(RVA = "0xCAB678", Offset = "0xCAB678", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA88C8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235C8]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiVector2ValueChanged>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000175")]
		[field: Token(Token = "0x40002A6")]
		public static FsmEvent UiEndEdit
		{
			[Token(Token = "0x60004D9")]
			[Address(RVA = "0xCAB6E4", Offset = "0xCAB6E4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECC078]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235C9]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmEvent;\nL_0024:\n\treturn v49.<UiEndEdit>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004DA")]
			[Address(RVA = "0xCAB74C", Offset = "0xCAB74C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB4368]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235CA]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmEvent;\nL_0021:\n\tv52.<UiEndEdit>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x600044E")]
		[Address(RVA = "0xCA4EF0", Offset = "0xCA4EF0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EA66F0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023546]) = v35;\nL_0012:\n\tPlayMakerGlobals::Initialize();\n\tgoto L_001F;\n\tv43 = *([v39 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tgoto L_001F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001F:\n\tHutongGames.PlayMaker.FsmEvent::AddSystemEvents();\n\tHutongGames.PlayMaker.FsmEvent::AddGlobalEvents();\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Initialize()
		{
			PlayMakerGlobals.Initialize();
			AddSystemEvents();
			AddGlobalEvents();
		}

		[Token(Token = "0x600045D")]
		[Address(RVA = "0xCA7D50", Offset = "0xCA7D50", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = fsmEvent == 0;\n\tif (v0) goto L_0007;\n\treturnVal2 = System.String::IsNullOrEmpty(fsmEvent.name);\n\treturn returnVal2;\nL_0007:\n\treturn 1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsNullOrEmpty(FsmEvent fsmEvent)
		{
			if (fsmEvent != null)
			{
				return string.IsNullOrEmpty(fsmEvent.Name);
			}
			return true;
		}

		[Token(Token = "0x6000460")]
		[Address(RVA = "0xCA7D78", Offset = "0xCA7D78", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF6298]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, name, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023550]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, v45, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv56 = HutongGames.PlayMaker.FsmEvent;\nL_002A:\n\tSystem.Threading.Monitor::Enter(v59.syncObj);\n\tthis.name = name;\n\tgoto L_0036;\n\tv68 = *([v64 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_0036;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v64, v60, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0036:\n\tv75 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv81 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::ContainsKey(v75, name);\n\tv84 = v81 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_005E;\n\tgoto L_004C;\n\tv117 = *([v95 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004C;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v95, v80, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004C:\n\tv89 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv91 = v89 == 0;\n\tif (v91) goto L_0061;\n\tSystem.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::set_Item(v89, name, this);\nL_005E:\n\tSystem.Threading.Monitor::Exit(v59.syncObj);\n\treturn;\n\tv82 = new System.NullReferenceException();\nL_0061:\n\tv94 = new System.NullReferenceException();\n\tgoto L_006E;\n\tgoto L_006E;\n\tgoto L_006E;\nL_006E:\n\tv132 = 0 != 1;\n\tif (v132) goto L_0081;\n\tv177 = 0x6D2BC0(v94, 0, v87, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv181 = 0x6D2490(v177, 0, v87, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tSystem.Threading.Monitor::Exit(v59.syncObj);\n\tv185 = *([v177 @ X0_v15]) == 0;\n\tv165 = ~v185;\n\tif (v165) goto L_0085;\n\treturn;\nL_0081:\n\tv178 = 0x6D2380(v94, 0, v87, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0085:\n\tthrow System.TypeLoadException;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEvent(string name)
		{
			Monitor.Enter(syncObj);
			Name = name;
			if (!eventLookup.ContainsKey(name))
			{
				Dictionary<string, FsmEvent> dictionary = eventLookup;
				if (dictionary == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						Monitor.Exit(syncObj);
						object obj = default(object);
						if (obj == null)
						{
							return;
						}
					}
					else
					{
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					}
					throw new TypeLoadException();
				}
				dictionary.set_Item(name, this);
			}
			Monitor.Exit(syncObj);
		}

		[Token(Token = "0x6000461")]
		[Address(RVA = "0xCA7EE0", Offset = "0xCA7EE0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F04568]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023551]) = v43;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tgoto L_002B;\n\tv53 = *([v49 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002B;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v49, v45, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv57 = HutongGames.PlayMaker.FsmEvent;\nL_002B:\n\tSystem.Threading.Monitor::Enter(v60.syncObj);\n\tthis.name = source.name;\n\tthis.isSystemEvent = source.isSystemEvent;\n\tthis.isGlobal = source.isGlobal;\n\tgoto L_003E;\n\tv75 = *([v69 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_003E;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v69, v61, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003E:\n\tv82 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv97 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::TryGetValue(v82, source.name, &v89 @ stack_-38_v5 (HutongGames.PlayMaker.FsmEvent));\n\tv118 = v97 == 0;\n\tif (v118) goto L_0056;\n\tv135 = this.isGlobal | v89.isGlobal;\n\tv89.isGlobal = v135;\n\tgoto L_0068;\nL_0056:\n\tgoto L_005C;\n\tv136 = *([v119 @ X0_v27 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_005C;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v119, v95, v91, v93, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005C:\n\tv111 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv113 = v111 == 0;\n\tif (v113) goto L_0076;\n\tv197 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::TryGetValue(v111, source.name, &v89 @ stack_-38_v5 (HutongGames.PlayMaker.FsmEvent));\n\treturn;\n\tX3 = *([1F0B000]);\n\tX2 = X20;\n\tSystem.Collections.Generic.Dictionary`2::Add /* +42 sharing this address */(X0, X1, X2, X3);\nL_0068:\n\tSystem.Threading.Monitor::Exit(v60.syncObj);\nL_0070:\n\treturn;\n\tv74 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv103 = new System.NullReferenceException();\nL_0076:\n\tv116 = new System.NullReferenceException();\n\tgoto L_0085;\n\tgoto L_0085;\n\tgoto L_0085;\n\tgoto L_0085;\n\tgoto L_0085;\nL_0085:\n\tv132 = v145 != 1;\n\tif (v132) goto L_0093;\n\tv142 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::TryGetValue(v116, v145, v143);\n\tv156 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::TryGetValue(v142, v145, v143);\n\tSystem.Threading.Monitor::Exit(v60.syncObj);\n\tv150 = ~v142.m_value;\n\tif (v150) goto L_0070;\n\tv148 = new System.TypeLoadException();\nL_0093:\n\tv153 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::TryGetValue(v147, 0, 0);\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe FsmEvent(FsmEvent source)
		{
			//IL_0154: Expected O, but got I4
			base._002Ector();
			Monitor.Enter(syncObj);
			Name = source.Name;
			isSystemEvent = source.IsSystemEvent;
			isGlobal = source.IsGlobal;
			if (eventLookup.TryGetValue(source.Name, out var value))
			{
				int num = ((IsGlobal | value.IsGlobal) ? 1 : 0);
				value.isGlobal = (byte)num != 0;
				Monitor.Exit(syncObj);
				return;
			}
			Dictionary<string, FsmEvent> dictionary = eventLookup;
			if (dictionary != null)
			{
				bool flag = dictionary.TryGetValue(source.Name, out value);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			string text = default(string);
			bool flag2 = (IntPtr)text != (IntPtr)1;
			Dictionary<string, FsmEvent> dictionary2 = (Dictionary<string, FsmEvent>)(object)ex;
			if (!flag2)
			{
				ref FsmEvent value2 = default(ref FsmEvent);
				bool flag3 = ((Dictionary<string, FsmEvent>)(object)ex).TryGetValue(text, out value2);
				bool flag4 = ((Dictionary<string, FsmEvent>)flag3).TryGetValue(text, out value2);
				Monitor.Exit(syncObj);
				if (!((bool*)(flag3 ? 1 : 0))->m_value)
				{
					return;
				}
				dictionary2 = (Dictionary<string, FsmEvent>)(object)new TypeLoadException();
			}
			bool flag5 = dictionary2.TryGetValue(null, out *(FsmEvent*)null);
		}

		[Token(Token = "0x6000462")]
		[Address(RVA = "0xCA8098", Offset = "0xCA8098", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBEEA8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023552]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_0038;\n\tgoto L_FFFFFFFF;\n\tv63 = v63_asT == 0;\n\tif (v63) goto L_005F;\nL_0038:\n\tv97 = ~this.isSystemEvent;\n\tif (v97) goto L_0045;\n\tv135 = *([obj @ X1 (System.Object)+18]) == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_005C;\n\tgoto L_0052;\nL_0045:\n\tv138 = *([obj @ X1 (System.Object)+18]) + 3;\n\tv139 = ~v138;\n\tv141 = v139 & 3;\n\tv142 = v141 == 0;\n\tif (v142) goto L_005C;\nL_0052:\n\treturn returnVal2;\nL_005C:\n\treturnVal3 = System.String::CompareOrdinal(this.name, *([obj @ X1 (System.Object)+10]));\n\treturn returnVal3;\nL_005F:\n\tthrow System.InvalidCastException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		int IComparable.CompareTo(object obj)
		{
			//IL_00a3: Expected O, but got I
			//IL_00ac: Expected I4, but got O
			//IL_00fc: Expected O, but got I
			if (obj != null)
			{
				FsmEvent fsmEvent = obj as FsmEvent;
				if (fsmEvent == null)
				{
					throw new InvalidCastException();
				}
			}
			if (IsSystemEvent)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+18]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					return -1;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+18]");
				object obj2 = 0L + 3L;
				int num = (int)(~obj2);
				if ((num & 3) != 0)
				{
					return 1;
				}
			}
			string strA = Name;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
			return string.CompareOrdinal(strA, (string)0);
		}

		[Token(Token = "0x6000463")]
		[Address(RVA = "0xCA8180", Offset = "0xCA8180", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EBD6F0]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, fsmEventName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023553]) = v43;\nL_001C:\n\tgoto L_0027;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, fsmEventName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = HutongGames.PlayMaker.FsmEvent;\nL_0027:\n\tSystem.Threading.Monitor::Enter(v57.syncObj);\n\tv62 = fsmEventList == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tv65 = System.String::IsNullOrEmpty(fsmEventName);\n\tv121 = v65 == 0;\n\tv115 = ~v121;\n\tif (v115) goto L_FFFFFFFF;\n\tv233 = fsmEventList._size;\n\tv76 = fsmEventList._size < 1;\n\tif (v76) goto L_FFFFFFFF;\nL_003F:\n\tv234 = v233 < v125;\n\tv143 = ~v234;\n\tv141 = v233 - v125;\n\tv137 = v141 == 0;\n\tv235 = ~v137;\n\tv127 = v143 & v235;\n\tif (v127) goto L_004D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004D:\n\tv238 = fsmEventList._items;\n\tv150 = v238[v125 @ X22_v6 (System.Int32)];\n\tv240 = v238[v125 @ X22_v6 (System.Int32)] == 0;\n\tif (v240) goto L_0079;\n\tv112 = System.String::op_Equality(v150.name, fsmEventName);\n\tv245 = v112 == 0;\n\tv114 = ~v245;\n\tif (v114) goto L_FFFFFFFF;\n\tv233 = fsmEventList._size;\n\tv125 = v125 + 1;\n\tv74 = v125 < fsmEventList._size;\n\tif (v74) goto L_003F;\nL_006C:\n\tSystem.Threading.Monitor::Exit(v57.syncObj);\nL_0075:\n\treturn v183;\n\tgoto L_006C;\nL_0079:\n\tv243 = new System.NullReferenceException();\n\tgoto L_0086;\n\tgoto L_0086;\n\tgoto L_0086;\nL_0086:\n\tv160 = v209 != 1;\n\tif (v160) goto L_0094;\n\tv249 = 0x6D2BC0(v243, v209, v196, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv183 = *([v249 @ X0_v18]);\n\tv254 = 0x6D2490(v249, v209, v196, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tSystem.Threading.Monitor::Exit(v57.syncObj);\n\tv182 = ~*([v249 @ X0_v18]);\n\tif (v182) goto L_0075;\n\tv253 = new System.TypeLoadException();\nL_0094:\n\treturnVal2 = 0x6D2380(v243, v209, v196, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn returnVal2;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool EventListContainsEvent(List<FsmEvent> fsmEventList, string fsmEventName)
		{
			//IL_01b8: Expected I4, but got O
			//IL_013c: Expected I, but got O
			//IL_01df: Expected I4, but got O
			//IL_01fb: Expected I, but got O
			Monitor.Enter(syncObj);
			bool result;
			if (fsmEventList != null && !string.IsNullOrEmpty(fsmEventName))
			{
				int count = fsmEventList.Count;
				if (fsmEventList.Count >= 1)
				{
					int num = 0;
					string text = null;
					while (true)
					{
						bool flag = count < num;
						bool flag2 = !flag;
						int num2 = count - num;
						bool flag3 = num2 == 0;
						bool flag4 = !flag3;
						if (!(flag2 && flag4))
						{
							throw new ArgumentOutOfRangeException();
						}
						FsmEvent[] items = fsmEventList._items;
						FsmEvent fsmEvent = items[num];
						if (items[num] == null)
						{
							break;
						}
						if (!(fsmEvent.Name == fsmEventName))
						{
							count = fsmEventList.Count;
							num++;
							bool flag5 = num < fsmEventList.Count;
							IntPtr intPtr = (IntPtr)null;
							text = fsmEventName;
							if (flag5)
							{
								continue;
							}
							goto IL_0152;
						}
						goto IL_0165;
					}
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)text == (IntPtr)1)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj = default(object);
						result = (byte)(int)obj != 0;
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						Monitor.Exit(syncObj);
						if ((int)(~obj) != 0)
						{
							goto IL_0160;
						}
						TypeLoadException ex2 = new TypeLoadException();
						IntPtr intPtr = (IntPtr)null;
						text = null;
						ex = (NullReferenceException)(object)ex2;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					bool result2 = default(bool);
					return result2;
				}
			}
			goto IL_0152;
			IL_0160:
			return result;
			IL_02a8:
			Monitor.Exit(syncObj);
			int num3;
			result = (byte)num3 != 0;
			goto IL_0160;
			IL_0165:
			num3 = 1;
			goto IL_02a8;
			IL_0152:
			num3 = 0;
			goto IL_02a8;
		}

		[Token(Token = "0x6000464")]
		[Address(RVA = "0xCA82D4", Offset = "0xCA82D4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB8E58]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023554]) = v38;\nL_0016:\n\tv41 = ~fsmEvent.isSystemEvent;\n\tif (v41) goto L_0035;\n\tv48 = System.String::Concat(\"RemoveEventFromEventList: Trying to delete System Event: \", fsmEvent.name);\n\tgoto L_002E;\n\tv91 = *([v60 @ X8_v17+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002E;\n\tv114 = v60;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v114, v44, v46, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tUnityEngine.Debug::LogError(v48);\nL_0035:\n\tgoto L_003B;\n\tv85 = *([v65 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_003B;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v65, v53, v52, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003B:\n\tv73 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv104 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::Remove(v73, fsmEvent.name);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoveEventFromEventList(FsmEvent fsmEvent)
		{
			if (fsmEvent.IsSystemEvent)
			{
				string message = "RemoveEventFromEventList: Trying to delete System Event: " + fsmEvent.Name;
				Debug.LogError(message);
			}
			Dictionary<string, FsmEvent> dictionary = eventLookup;
			bool flag = dictionary.Remove(fsmEvent.Name);
		}

		[Token(Token = "0x6000465")]
		[Address(RVA = "0xCA83AC", Offset = "0xCA83AC", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EF3F00]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023555]) = v40;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = HutongGames.PlayMaker.FsmEvent;\nL_0026:\n\tSystem.Threading.Monitor::Enter(v55.syncObj);\n\tgoto L_0031;\n\tv64 = *([v60 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0031;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv71 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv72 = v71 == 0;\n\tif (v72) goto L_0046;\n\tv79 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::TryGetValue(v71, eventName, &v77 @ stack_-28_v3 (HutongGames.PlayMaker.FsmEvent));\n\tSystem.Threading.Monitor::Exit(v55.syncObj);\nL_0045:\n\treturn v111;\nL_0046:\n\tv80 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_0060;\n\tv159 = 0x6D2BC0(v80, 0, v148, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv164 = 0x6D2490(v159, 0, v148, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tSystem.Threading.Monitor::Exit(v55.syncObj);\n\tv121 = *([v159 @ X0_v11]) == 0;\n\tif (v121) goto L_0045;\n\tv163 = new System.TypeLoadException();\nL_0060:\n\treturnVal2 = 0x6D2380(v80, v145, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmEvent FindEvent(string eventName)
		{
			Monitor.Enter(syncObj);
			Dictionary<string, FsmEvent> dictionary = eventLookup;
			if (dictionary != null)
			{
				bool flag = dictionary.TryGetValue(eventName, out var value);
				Monitor.Exit(syncObj);
				return value;
			}
			NullReferenceException ex = new NullReferenceException();
			int num = 0;
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			FsmEvent result = default(FsmEvent);
			return result;
		}

		[Token(Token = "0x6000466")]
		[Address(RVA = "0xCA84C0", Offset = "0xCA84C0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFB4C8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023556]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = HutongGames.PlayMaker.FsmEvent::get_globalEvents();\n\treturnVal1 = System.Collections.Generic.List`1<System.String>::Contains(v52, eventName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsEventGlobal(string eventName)
		{
			List<string> list = globalEvents;
			return list.Contains(eventName);
		}

		[Token(Token = "0x6000467")]
		[Address(RVA = "0xCA853C", Offset = "0xCA853C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB3C60]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023557]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = HutongGames.PlayMaker.FsmEvent::FindEvent(eventName);\n\tv60 = v53 == 0;\n\tv65 = ~v60;\n\treturn v65;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool EventListContains(string eventName)
		{
			FsmEvent fsmEvent = FindEvent(eventName);
			bool flag = fsmEvent == null;
			return !flag;
		}

		[Token(Token = "0x6000468")]
		[Address(RVA = "0xCA85AC", Offset = "0xCA85AC", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EE9530]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023558]) = v42;\nL_001C:\n\tgoto L_0027;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = HutongGames.PlayMaker.FsmEvent;\nL_0027:\n\tSystem.Threading.Monitor::Enter(v57.syncObj);\n\tgoto L_0032;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0032;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, v58, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0032:\n\tv73 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tv74 = v73 == 0;\n\tif (v74) goto L_0086;\n\tv81 = System.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::TryGetValue(v73, eventName, &v79 @ stack_-38_v3 (HutongGames.PlayMaker.FsmEvent));\n\tv84 = v81 == 0;\n\tif (v84) goto L_005B;\n\tgoto L_004F;\n\tv102 = *([1EA8858]);\n\tv103 = *([v102 @ X8_v30]);\n\tv104 = \"il2cpp_codegen_initialize_method\"(v103, v80, v78, v77, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv107 = 0 | 1;\n\t*([20236C8]) = v107;\nL_004F:\n\tv114 = ~v112.<IsPlaying>k__BackingField;\n\tv115 = ~v114;\n\tif (v115) goto L_007C;\n\tv134 = new HutongGames.PlayMaker.FsmEvent();\n\tHutongGames.PlayMaker.FsmEvent::.ctor(v134, v79);\n\tgoto L_007C;\nL_005B:\n\tv90 = new HutongGames.PlayMaker.FsmEvent();\n\tHutongGames.PlayMaker.FsmEvent::.ctor(v90, eventName);\n\tgoto L_0070;\n\tv196 = *([1EA8858]);\n\tv197 = *([v196 @ X8_v20]);\n\tv198 = \"il2cpp_codegen_initialize_method\"(v197, v118, v78, v77, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv200 = 0 | 1;\n\t*([20236C8]) = v200;\nL_0070:\n\tv205 = ~v204.<IsPlaying>k__BackingField;\n\tv146 = ~v205;\n\tif (v146) goto L_007C;\n\tv229 = new HutongGames.PlayMaker.FsmEvent();\n\tHutongGames.PlayMaker.FsmEvent::.ctor(v229, v90);\nL_007C:\n\tSystem.Threading.Monitor::Exit(v57.syncObj);\nL_0085:\n\treturn v177;\nL_0086:\n\tv82 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A6;\n\tv119 = 0x6D2BC0(v82, 0, v124, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv158 = 0x6D2490(v119, 0, v124, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tSystem.Threading.Monitor::Exit(v57.syncObj);\n\tv129 = *([v119 @ X0_v11]) == 0;\n\tif (v129) goto L_0085;\n\tv127 = new System.TypeLoadException();\nL_00A6:\n\treturnVal1 = 0x6D2380(v82, v122, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmEvent GetFsmEvent(string eventName)
		{
			Monitor.Enter(syncObj);
			Dictionary<string, FsmEvent> dictionary = eventLookup;
			if (dictionary != null)
			{
				FsmEvent result;
				if (!dictionary.TryGetValue(eventName, out var value))
				{
					FsmEvent fsmEvent = new FsmEvent(eventName);
					bool flag = !PlayMakerGlobals.IsPlaying;
					bool flag2 = !flag;
					result = fsmEvent;
					if (!flag2)
					{
						FsmEvent fsmEvent2 = new FsmEvent(fsmEvent);
						result = fsmEvent2;
					}
				}
				else
				{
					bool flag3 = !PlayMakerGlobals.IsPlaying;
					bool flag4 = !flag3;
					result = value;
					if (!flag4)
					{
						FsmEvent fsmEvent3 = new FsmEvent(value);
						result = fsmEvent3;
					}
				}
				Monitor.Exit(syncObj);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			int num = 0;
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			FsmEvent result2 = default(FsmEvent);
			return result2;
		}

		[Token(Token = "0x6000469")]
		[Address(RVA = "0xCA87B0", Offset = "0xCA87B0", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EADD28]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023559]) = v40;\nL_0014:\n\tv41 = fsmEvent == 0;\n\tif (v41) goto L_004B;\n\tgoto L_0027;\n\tv101 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0027;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv105 = HutongGames.PlayMaker.FsmEvent;\nL_0027:\n\tSystem.Threading.Monitor::Enter(v108.syncObj);\n\tgoto L_0035;\n\tv142 = *([v137 @ X0_v7+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tgoto L_0035;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v137, v109, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0035:\n\tv149 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEvent.name);\n\tv150 = v149 == 0;\n\tif (v150) goto L_004D;\n\tv91 = v149.isGlobal | fsmEvent.isGlobal;\n\tv149.isGlobal = v91;\n\tv85 = ~fsmEvent.isGlobal;\n\tif (v85) goto L_0043;\n\tPlayMakerGlobals::AddGlobalEvent(v149.name);\nL_0043:\n\tSystem.Threading.Monitor::Exit(v108.syncObj);\nL_004B:\n\treturn v87;\nL_004D:\n\tv153 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0068;\n\tv159 = 0x6D2BC0(v153, 0, v112, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv164 = 0x6D2490(v159, 0, v112, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tSystem.Threading.Monitor::Exit(v108.syncObj);\n\tv86 = *([v159 @ X0_v15]) == 0;\n\tif (v86) goto L_004B;\n\tv163 = new System.TypeLoadException();\nL_0068:\n\treturnVal2 = 0x6D2380(v153, v124, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmEvent GetFsmEvent(FsmEvent fsmEvent)
		{
			bool flag = fsmEvent == null;
			FsmEvent result = fsmEvent;
			if (!flag)
			{
				Monitor.Enter(syncObj);
				FsmEvent fsmEvent2 = GetFsmEvent(fsmEvent.Name);
				if (fsmEvent2 == null)
				{
					NullReferenceException ex = new NullReferenceException();
					int num = 0;
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					FsmEvent result2 = default(FsmEvent);
					return result2;
				}
				int num2 = ((fsmEvent2.IsGlobal | fsmEvent.IsGlobal) ? 1 : 0);
				fsmEvent2.isGlobal = (byte)num2 != 0;
				if (fsmEvent.IsGlobal)
				{
					PlayMakerGlobals.AddGlobalEvent(fsmEvent2.Name);
				}
				Monitor.Exit(syncObj);
				result = fsmEvent2;
			}
			return result;
		}

		[Token(Token = "0x600046A")]
		[Address(RVA = "0xCA88DC", Offset = "0xCA88DC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFF4D8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202355A]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = HutongGames.PlayMaker.FsmEvent::get_eventLookup();\n\tSystem.Collections.Generic.Dictionary`2<System.String, HutongGames.PlayMaker.FsmEvent>::Add(v52, fsmEvent.name, fsmEvent);\n\treturn fsmEvent;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmEvent AddFsmEvent(FsmEvent fsmEvent)
		{
			Dictionary<string, FsmEvent> dictionary = eventLookup;
			dictionary.Add(fsmEvent.Name, fsmEvent);
			return fsmEvent;
		}

		[Token(Token = "0x600046B")]
		[Address(RVA = "0xCA5004", Offset = "0xCA5004", Length = "0x1524")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED1FA0]);\n\tv23 = *([v22 @ X8_v503]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([202355B]) = v43;\nL_001B:\n\tgoto L_0027;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0027;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0027:\n\tv63 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"FINISHED\", \"System Events\");\n\tgoto L_0038;\n\tv70 = *([1EBFC00]);\n\tv71 = *([v70 @ X8_v499]);\n\tv72 = \"il2cpp_codegen_initialize_method\"(v71, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = 0 | 1;\n\t*([20236C9]) = v75;\nL_0038:\n\tgoto L_0042;\n\tv80 = *([v76 @ X0_v7 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tgoto L_0042;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v76, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv84 = HutongGames.PlayMaker.FsmEvent;\nL_0042:\n\tv87.<Finished>k__BackingField = v63;\n\tv92 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"DISABLE\", \"System Events\");\n\tgoto L_0056;\n\tv100 = *([1EE2AC0]);\n\tv101 = *([v100 @ X8_v495]);\n\tv102 = \"il2cpp_codegen_initialize_method\"(v101, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv105 = 0 | 1;\n\t*([20236CA]) = v105;\nL_0056:\n\tgoto L_0060;\n\tv110 = *([v106 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tgoto L_0060;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v106, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv114 = HutongGames.PlayMaker.FsmEvent;\nL_0060:\n\tv117.<Disable>k__BackingField = v92;\n\tv122 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"BECAME INVISIBLE\", \"System Events\");\n\tgoto L_0074;\n\tv130 = *([1EA5498]);\n\tv131 = *([v130 @ X8_v491]);\n\tv132 = \"il2cpp_codegen_initialize_method\"(v131, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv135 = 0 | 1;\n\t*([20236CB]) = v135;\nL_0074:\n\tgoto L_007E;\n\tv140 = *([v136 @ X0_v17 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tgoto L_007E;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v136, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv144 = HutongGames.PlayMaker.FsmEvent;\nL_007E:\n\tv147.<BecameInvisible>k__BackingField = v122;\n\tv152 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"BECAME VISIBLE\", \"System Events\");\n\tgoto L_0092;\n\tv160 = *([1EC9EB0]);\n\tv161 = *([v160 @ X8_v487]);\n\tv162 = \"il2cpp_codegen_initialize_method\"(v161, v150, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv165 = 0 | 1;\n\t*([20236CC]) = v165;\nL_0092:\n\tgoto L_009C;\n\tv170 = *([v166 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tgoto L_009C;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v166, v150, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv174 = HutongGames.PlayMaker.FsmEvent;\nL_009C:\n\tv177.<BecameVisible>k__BackingField = v152;\n\tv182 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"LEVEL LOADED\", \"System Events\");\n\tgoto L_00B0;\n\tv190 = *([1EFCE10]);\n\tv191 = *([v190 @ X8_v483]);\n\tv192 = \"il2cpp_codegen_initialize_method\"(v191, v180, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv195 = 0 | 1;\n\t*([20236CD]) = v195;\nL_00B0:\n\tgoto L_00BA;\n\tv200 = *([v196 @ X0_v27 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv201 = v200 == 0;\n\tv202 = ~v201;\n\tgoto L_00BA;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v196, v180, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv204 = HutongGames.PlayMaker.FsmEvent;\nL_00BA:\n\tv207.<LevelLoaded>k__BackingField = v182;\n\tv212 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"MOUSE DOWN\", \"System Events\");\n\tgoto L_00CE;\n\tv220 = *([1F08168]);\n\tv221 = *([v220 @ X8_v479]);\n\tv222 = \"il2cpp_codegen_initialize_method\"(v221, v210, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv225 = 0 | 1;\n\t*([20236CE]) = v225;\nL_00CE:\n\tgoto L_00D8;\n\tv230 = *([v226 @ X0_v32 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tgoto L_00D8;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v226, v210, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv234 = HutongGames.PlayMaker.FsmEvent;\nL_00D8:\n\tv237.<MouseDown>k__BackingField = v212;\n\tv242 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"MOUSE DRAG\", \"System Events\");\n\tgoto L_00EC;\n\tv250 = *([1F0C2D8]);\n\tv251 = *([v250 @ X8_v475]);\n\tv252 = \"il2cpp_codegen_initialize_method\"(v251, v240, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv255 = 0 | 1;\n\t*([20236CF]) = v255;\nL_00EC:\n\tgoto L_00F6;\n\tv260 = *([v256 @ X0_v37 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv261 = v260 == 0;\n\tv262 = ~v261;\n\tgoto L_00F6;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v256, v240, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv264 = HutongGames.PlayMaker.FsmEvent;\nL_00F6:\n\tv267.<MouseDrag>k__BackingField = v242;\n\tv272 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"MOUSE ENTER\", \"System Events\");\n\tgoto L_010A;\n\tv280 = *([1ECEB90]);\n\tv281 = *([v280 @ X8_v471]);\n\tv282 = \"il2cpp_codegen_initialize_method\"(v281, v270, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv285 = 0 | 1;\n\t*([20236D0]) = v285;\nL_010A:\n\tgoto L_0114;\n\tv290 = *([v286 @ X0_v42 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv291 = v290 == 0;\n\tv292 = ~v291;\n\tgoto L_0114;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v286, v270, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv294 = HutongGames.PlayMaker.FsmEvent;\nL_0114:\n\tv297.<MouseEnter>k__BackingField = v272;\n\tv302 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"MOUSE EXIT\", \"System Events\");\n\tgoto L_0128;\n\tv310 = *([1EF6668]);\n\tv311 = *([v310 @ X8_v467]);\n\tv312 = \"il2cpp_codegen_initialize_method\"(v311, v300, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv315 = 0 | 1;\n\t*([20236D1]) = v315;\nL_0128:\n\tgoto L_0132;\n\tv320 = *([v316 @ X0_v47 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tgoto L_0132;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v316, v300, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv324 = HutongGames.PlayMaker.FsmEvent;\nL_0132:\n\tv327.<MouseExit>k__BackingField = v302;\n\tv332 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"MOUSE OVER\", \"System Events\");\n\tgoto L_0146;\n\tv340 = *([1F03580]);\n\tv341 = *([v340 @ X8_v463]);\n\tv342 = \"il2cpp_codegen_initialize_method\"(v341, v330, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv345 = 0 | 1;\n\t*([20236D2]) = v345;\nL_0146:\n\tgoto L_0150;\n\tv350 = *([v346 @ X0_v52 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv351 = v350 == 0;\n\tv352 = ~v351;\n\tgoto L_0150;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v346, v330, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv354 = HutongGames.PlayMaker.FsmEvent;\nL_0150:\n\tv357.<MouseOver>k__BackingField = v332;\n\tv362 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"MOUSE UP\", \"System Events\");\n\tgoto L_0164;\n\tv370 = *([1EED910]);\n\tv371 = *([v370 @ X8_v459]);\n\tv372 = \"il2cpp_codegen_initialize_method\"(v371, v360, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv375 = 0 | 1;\n\t*([20236D3]) = v375;\nL_0164:\n\tgoto L_016E;\n\tv380 = *([v376 @ X0_v57 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv381 = v380 == 0;\n\tv382 = ~v381;\n\tgoto L_016E;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v376, v360, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv384 = HutongGames.PlayMaker.FsmEvent;\nL_016E:\n\tv387.<MouseUp>k__BackingField = v362;\n\tv392 = HutongGames.PlayMaker.FsmEvent::AddSystemEvent(\"MOUSE UP AS BUTTON\", \"System Events\");\n\tgoto L_0182;\n\tv400 = *([1EE1138]);\n\tv401 = *([v400 @ X8_v455]);\n\tv402 = \"il2cpp_codegen_initialize_method\"(v401, v390, v26, v\n// ... truncated")]
		private static void AddSystemEvents()
		{
			FsmEvent fsmEvent = AddSystemEvent("FINISHED", "System Events");
			Finished = fsmEvent;
			FsmEvent fsmEvent2 = AddSystemEvent("DISABLE", "System Events");
			Disable = fsmEvent2;
			FsmEvent fsmEvent3 = AddSystemEvent("BECAME INVISIBLE", "System Events");
			BecameInvisible = fsmEvent3;
			FsmEvent fsmEvent4 = AddSystemEvent("BECAME VISIBLE", "System Events");
			BecameVisible = fsmEvent4;
			FsmEvent fsmEvent5 = AddSystemEvent("LEVEL LOADED", "System Events");
			LevelLoaded = fsmEvent5;
			FsmEvent fsmEvent6 = AddSystemEvent("MOUSE DOWN", "System Events");
			MouseDown = fsmEvent6;
			FsmEvent fsmEvent7 = AddSystemEvent("MOUSE DRAG", "System Events");
			MouseDrag = fsmEvent7;
			FsmEvent fsmEvent8 = AddSystemEvent("MOUSE ENTER", "System Events");
			MouseEnter = fsmEvent8;
			FsmEvent fsmEvent9 = AddSystemEvent("MOUSE EXIT", "System Events");
			MouseExit = fsmEvent9;
			FsmEvent fsmEvent10 = AddSystemEvent("MOUSE OVER", "System Events");
			MouseOver = fsmEvent10;
			FsmEvent fsmEvent11 = AddSystemEvent("MOUSE UP", "System Events");
			MouseUp = fsmEvent11;
			FsmEvent fsmEvent12 = AddSystemEvent("MOUSE UP AS BUTTON", "System Events");
			MouseUpAsButton = fsmEvent12;
			FsmEvent fsmEvent13 = AddSystemEvent("COLLISION ENTER", "System Events");
			CollisionEnter = fsmEvent13;
			FsmEvent fsmEvent14 = AddSystemEvent("COLLISION EXIT", "System Events");
			CollisionExit = fsmEvent14;
			FsmEvent fsmEvent15 = AddSystemEvent("COLLISION STAY", "System Events");
			CollisionStay = fsmEvent15;
			FsmEvent fsmEvent16 = AddSystemEvent("CONTROLLER COLLIDER HIT", "System Events");
			ControllerColliderHit = fsmEvent16;
			FsmEvent fsmEvent17 = AddSystemEvent("TRIGGER ENTER", "System Events");
			TriggerEnter = fsmEvent17;
			FsmEvent fsmEvent18 = AddSystemEvent("TRIGGER EXIT", "System Events");
			TriggerExit = fsmEvent18;
			FsmEvent fsmEvent19 = AddSystemEvent("TRIGGER STAY", "System Events");
			TriggerStay = fsmEvent19;
			FsmEvent fsmEvent20 = AddSystemEvent("COLLISION ENTER 2D", "System Events");
			CollisionEnter2D = fsmEvent20;
			FsmEvent fsmEvent21 = AddSystemEvent("COLLISION EXIT 2D", "System Events");
			CollisionExit2D = fsmEvent21;
			FsmEvent fsmEvent22 = AddSystemEvent("COLLISION STAY 2D", "System Events");
			CollisionStay2D = fsmEvent22;
			FsmEvent fsmEvent23 = AddSystemEvent("TRIGGER ENTER 2D", "System Events");
			TriggerEnter2D = fsmEvent23;
			FsmEvent fsmEvent24 = AddSystemEvent("TRIGGER EXIT 2D", "System Events");
			TriggerExit2D = fsmEvent24;
			FsmEvent fsmEvent25 = AddSystemEvent("TRIGGER STAY 2D", "System Events");
			TriggerStay2D = fsmEvent25;
			FsmEvent fsmEvent26 = AddSystemEvent("PLAYER CONNECTED", "Network Events");
			PlayerConnected = fsmEvent26;
			FsmEvent fsmEvent27 = AddSystemEvent("SERVER INITIALIZED", "Network Events");
			ServerInitialized = fsmEvent27;
			FsmEvent fsmEvent28 = AddSystemEvent("CONNECTED TO SERVER", "Network Events");
			ConnectedToServer = fsmEvent28;
			FsmEvent fsmEvent29 = AddSystemEvent("PLAYER DISCONNECTED", "Network Events");
			PlayerDisconnected = fsmEvent29;
			FsmEvent fsmEvent30 = AddSystemEvent("DISCONNECTED FROM SERVER", "Network Events");
			DisconnectedFromServer = fsmEvent30;
			FsmEvent fsmEvent31 = AddSystemEvent("FAILED TO CONNECT", "Network Events");
			FailedToConnect = fsmEvent31;
			FsmEvent fsmEvent32 = AddSystemEvent("FAILED TO CONNECT TO MASTER SERVER", "Network Events");
			FailedToConnectToMasterServer = fsmEvent32;
			FsmEvent fsmEvent33 = AddSystemEvent("MASTER SERVER EVENT", "Network Events");
			MasterServerEvent = fsmEvent33;
			FsmEvent fsmEvent34 = AddSystemEvent("NETWORK INSTANTIATE", "Network Events");
			NetworkInstantiate = fsmEvent34;
			FsmEvent fsmEvent35 = AddSystemEvent("APPLICATION FOCUS", "System Events");
			ApplicationFocus = fsmEvent35;
			FsmEvent fsmEvent36 = AddSystemEvent("APPLICATION PAUSE", "System Events");
			ApplicationPause = fsmEvent36;
			FsmEvent fsmEvent37 = AddSystemEvent("APPLICATION QUIT", "System Events");
			ApplicationQuit = fsmEvent37;
			FsmEvent fsmEvent38 = AddSystemEvent("PARTICLE COLLISION", "System Events");
			ParticleCollision = fsmEvent38;
			FsmEvent fsmEvent39 = AddSystemEvent("JOINT BREAK", "System Events");
			JointBreak = fsmEvent39;
			FsmEvent fsmEvent40 = AddSystemEvent("JOINT BREAK 2D", "System Events");
			JointBreak2D = fsmEvent40;
			FsmEvent fsmEvent41 = AddSystemEvent("UI BEGIN DRAG", "UI Events");
			UiBeginDrag = fsmEvent41;
			FsmEvent fsmEvent42 = AddSystemEvent("UI DRAG", "UI Events");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20236F2]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CBCFDC (inside HutongGames.PlayMaker.FsmVar::DebugLog +0xE8)");
				return;
			}
			UiDrag = fsmEvent42;
			FsmEvent fsmEvent43 = AddSystemEvent("UI END DRAG", "UI Events");
			UiEndDrag = fsmEvent43;
			FsmEvent fsmEvent44 = AddSystemEvent("UI CLICK", "UI Events");
			UiClick = fsmEvent44;
			FsmEvent fsmEvent45 = AddSystemEvent("UI DROP", "UI Events");
			UiDrop = fsmEvent45;
			FsmEvent fsmEvent46 = AddSystemEvent("UI POINTER CLICK", "UI Events");
			UiPointerClick = fsmEvent46;
			FsmEvent fsmEvent47 = AddSystemEvent("UI POINTER DOWN", "UI Events");
			UiPointerDown = fsmEvent47;
			FsmEvent fsmEvent48 = AddSystemEvent("UI POINTER ENTER", "UI Events");
			UiPointerEnter = fsmEvent48;
			FsmEvent fsmEvent49 = AddSystemEvent("UI POINTER EXIT", "UI Events");
			UiPointerExit = fsmEvent49;
			FsmEvent fsmEvent50 = AddSystemEvent("UI POINTER UP", "UI Events");
			UiPointerUp = fsmEvent50;
			FsmEvent fsmEvent51 = AddSystemEvent("UI BOOL VALUE CHANGED", "UI Events");
			UiBoolValueChanged = fsmEvent51;
			FsmEvent fsmEvent52 = AddSystemEvent("UI FLOAT VALUE CHANGED", "UI Events");
			UiFloatValueChanged = fsmEvent52;
			FsmEvent fsmEvent53 = AddSystemEvent("UI INT VALUE CHANGED", "UI Events");
			UiIntValueChanged = fsmEvent53;
			FsmEvent fsmEvent54 = AddSystemEvent("UI VECTOR2 VALUE CHANGED", "UI Events");
			UiVector2ValueChanged = fsmEvent54;
			FsmEvent fsmEvent55 = AddSystemEvent("UI END EDIT", "UI Events");
			UiEndEdit = fsmEvent55;
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0xCA896C", Offset = "0xCA896C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBE3C0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, path, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202355C]) = v41;\nL_0018:\n\tv45 = new HutongGames.PlayMaker.FsmEvent();\n\tHutongGames.PlayMaker.FsmEvent::.ctor(v45, eventName);\n\tv45.isSystemEvent = 1;\n\tv55 = System.String::op_Equality(path, \"\");\n\tv59 = v55 == 0;\n\tif (v59) goto L_0030;\n\tgoto L_0031;\nL_0030:\n\tv86 = System.String::Concat(path, \"/\");\nL_0031:\n\tv45.<Path>k__BackingField = v86;\n\treturn v45;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static FsmEvent AddSystemEvent(string eventName, string path = "")
		{
			FsmEvent fsmEvent = new FsmEvent(eventName);
			fsmEvent.isSystemEvent = true;
			string path2 = ((!(path == "")) ? (path + "/") : "");
			fsmEvent.Path = path2;
			return fsmEvent;
		}

		[Token(Token = "0x60004DB")]
		[Address(RVA = "0xCA6528", Offset = "0xCA6528", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F00158]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20235CB]) = v43;\n\tgoto L_0048;\nL_001E:\n\tgoto L_0024;\n\tv185 = *([v142 @ X0_v11 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_0024;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v142, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0024:\n\tv127 = HutongGames.PlayMaker.FsmEvent::get_globalEvents();\n\tv192 = v127._size < v48;\n\tv82 = ~v192;\n\tv79 = v127._size - v48;\n\tv73 = v79 == 0;\n\tv193 = ~v73;\n\tv58 = v82 & v193;\n\tif (v58) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv196 = v127._items;\n\tv85 = new HutongGames.PlayMaker.FsmEvent();\n\tHutongGames.PlayMaker.FsmEvent::.ctor(v85, v196[v48 @ X21_v2 (System.Int32)]);\n\tv48 = v48 + 1;\n\tv85.isGlobal = 1;\nL_0048:\n\tgoto L_004E;\n\tv96 = *([v92 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tgoto L_004E;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v92, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004E:\n\tv103 = HutongGames.PlayMaker.FsmEvent::get_globalEvents();\n\tv116 = v48 < v103._size;\n\tif (v116) goto L_001E;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddGlobalEvents()
		{
			int num = 0;
			while (true)
			{
				List<string> list = globalEvents;
				if (num < list.Count)
				{
					List<string> list2 = globalEvents;
					bool flag = list2.Count < num;
					bool flag2 = !flag;
					int num2 = list2.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					string[] items = list2._items;
					FsmEvent fsmEvent = new FsmEvent(items[num]);
					num++;
					fsmEvent.isGlobal = true;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60004DC")]
		[Address(RVA = "0xCA7B50", Offset = "0xCA7B50", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = *([1EE8800]);\n\tv27 = *([v26 @ X8_v33]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20235CC]) = v47;\nL_0020:\n\tgoto L_0026;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0026;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0026:\n\tv64 = HutongGames.PlayMaker.FsmEvent::get_EventList();\n\tv65 = v64 == 0;\n\tif (v65) goto L_0086;\n\tv71 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::GetEnumerator(v64);\nL_003B:\n\tv131 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>+Enumerator<HutongGames.PlayMaker.FsmEvent>::MoveNext(&v70 @ stack_-88_v3 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>+Enumerator<HutongGames.PlayMaker.FsmEvent>));\n\tv143 = v131 == 0;\n\tif (v143) goto L_0080;\n\tgoto L_004E;\n\tv175 = *([v167 @ X0_v28+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_004E;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v167, v113, v108, v31, v32, v33, v34, v35, v89, v37, v38, v39, v40, v41, v42, v43);\nL_004E:\n\tv117 = HutongGames.PlayMaker.FsmEvent::IsEventGlobal(*([v104 @ stack_-78+10]));\n\tv261 = v117 == 0;\n\tif (v261) goto L_0054;\n\t*([v104 @ stack_-78+19]) = 1;\n\tgoto L_005B;\nL_0054:\n\t;\n\tv121 = *([v104 @ stack_-78+19]) == 0;\n\tif (v121) goto L_003B;\nL_005B:\n\tgoto L_0061;\n\tv269 = *([v265 @ X0_v32 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_0061;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v265, v113, v108, v31, v32, v33, v34, v35, v89, v37, v38, v39, v40, v41, v42, v43);\nL_0061:\n\tv184 = HutongGames.PlayMaker.FsmEvent::get_globalEvents();\n\tv118 = System.Collections.Generic.List`1<System.String>::Contains(v184, *([v104 @ stack_-78+10]));\n\tv276 = v118 == 0;\n\tv122 = ~v276;\n\tif (v122) goto L_003B;\n\tgoto L_0075;\n\tv281 = *([v277 @ X0_v36 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_0075;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v277, v114, v109, v31, v32, v33, v34, v35, v89, v37, v38, v39, v40, v41, v42, v43);\nL_0075:\n\tv119 = HutongGames.PlayMaker.FsmEvent::get_globalEvents();\n\tSystem.Collections.Generic.List`1<System.String>::Add(v119, *([v104 @ stack_-78+10]));\n\tgoto L_003B;\nL_0080:\n\tv151 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>+Enumerator<HutongGames.PlayMaker.FsmEvent>::Dispose(&v70 @ stack_-88_v3 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>+Enumerator<HutongGames.PlayMaker.FsmEvent>));\n\tgoto L_00AD;\n\tv172 = new System.NullReferenceException();\n\tv189 = new System.NullReferenceException();\n\tv95 = new System.NullReferenceException();\nL_0086:\n\tv102 = new System.NullReferenceException();\n\tgoto L_0096;\n\tgoto L_0096;\n\tgoto L_0096;\n\tgoto L_0096;\n\tgoto L_0096;\n\tgoto L_0096;\nL_0096:\n\tv141 = v92 != 1;\n\tif (v141) goto L_00AE;\n\tv144 = System.Collections.Generic.List`1<System.String>::Contains(v102, v92);\n\tv153 = System.Collections.Generic.List`1<System.String>::Contains(v144, v92);\n\tv157 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>+Enumerator<HutongGames.PlayMaker.FsmEvent>::Dispose(&v80 @ stack_-70_v3 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>+Enumerator<HutongGames.PlayMaker.FsmEvent>));\n\tv232 = ~v144.m_value;\n\tv159 = ~v232;\n\tif (v159) goto L_00B2;\nL_00AD:\n\treturn;\nL_00AE:\n\tv145 = System.Collections.Generic.List`1<System.String>::Contains(v102, v92);\nL_00B2:\n\tthrow System.TypeLoadException;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void SanityCheckEventList()
		{
			//IL_018b: Expected O, but got I4
			//IL_005c: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_012c: Expected O, but got I
			List<FsmEvent> eventList = EventList;
			bool flag = eventList == null;
			List<FsmEvent>.Enumerator enumerator2 = default(List<FsmEvent>.Enumerator);
			List<FsmEvent>.Enumerator enumerator = enumerator2;
			if (!flag)
			{
				List<FsmEvent>.Enumerator enumerator3 = eventList.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ stack_-78+10]");
					if (IsEventGlobal((string)0))
					{
						_ = 1;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ stack_-78+19]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							continue;
						}
					}
					List<string> list = globalEvents;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ stack_-78+10]");
					if (!list.Contains((string)0))
					{
						List<string> list2 = globalEvents;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ stack_-78+10]");
						list2.Add((string)0);
					}
				}
				enumerator2.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			string text = default(string);
			if ((IntPtr)text == (IntPtr)1)
			{
				bool flag2 = ((List<string>)(object)ex).Contains(text);
				bool flag3 = ((List<string>)flag2).Contains(text);
				enumerator.Dispose();
				if (!((bool*)(flag2 ? 1 : 0))->m_value)
				{
					return;
				}
			}
			else
			{
				bool flag4 = ((List<string>)(object)ex).Contains(text);
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60004DD")]
		[Address(RVA = "0xCAB7B8", Offset = "0xCAB7B8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC0DB8]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235CD]) = v35;\nL_0014:\n\tv39 = new System.Object();\n\tSystem.Object::.ctor(v39);\n\tv45.syncObj = v39;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FsmEvent()
		{
			object obj = new object();
			syncObj = obj;
		}
	}
}
