using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000057")]
	internal class EventQueue
	{
		[CompilerGenerated]
		[Token(Token = "0x2000058")]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			[Token(Token = "0x400010C")]
			[FieldOffset(Offset = "0x10")]
			public int? delayInSeconds;

			[Token(Token = "0x400010D")]
			[FieldOffset(Offset = "0x18")]
			public EventQueue _003C_003E4__this;

			[Token(Token = "0x400010E")]
			[FieldOffset(Offset = "0x20")]
			public EventDestType dest;

			[Token(Token = "0x400010F")]
			[FieldOffset(Offset = "0x28")]
			public string json;

			[Token(Token = "0x4000110")]
			[FieldOffset(Offset = "0x30")]
			public string target;

			[Token(Token = "0x4000111")]
			[FieldOffset(Offset = "0x38")]
			public Action _003C_003E9__4;

			[Token(Token = "0x600014B")]
			[Address(RVA = "0xC5D850", Offset = "0xC5D850", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass11_0()
			{
			}

			internal unsafe void _003CSendEvent_003Eb__1(string error)
			{
				//IL_0011: Expected O, but got I
				//IL_0077: Expected native int or pointer, but got O
				//IL_008a: Expected I4, but got O
				//IL_0143: Expected I, but got O
				//IL_017e: Expected O, but got I
				//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0200: Expected O, but got Unknown
				//IL_021d: Expected O, but got I
				//IL_022c: Expected O, but got I
				//IL_01ca: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.EventQueue+<>c__DisplayClass11_0)+14]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					return;
				}
				int? num = (int?)(object)((long)(IntPtr)this + 16L);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115BDD8 (inside System.Nullable`1<System.Double>::Unbox +0xC0)");
				object obj = default(object);
				int val = (int)((long)(IntPtr)obj << 1);
				int value = Math.Max(5, val);
				int? num2 = null;
				num2 = value;
				delayInSeconds = null;
				*(int?*)(IntPtr)(void*)num = 0;
				int? num3 = default(int?);
				int value2 = Math.Min(300, (int)num3);
				int? num4 = null;
				num4 = value2;
				EventQueue eventQueue = _003C_003E4__this;
				delayInSeconds = null;
				Action action = _003C_003E9__4;
				IAsyncWebUtil asyncUtil = eventQueue.m_AsyncUtil;
				if (_003C_003E9__4 == null)
				{
					action = (_003C_003E9__4 = delegate
					{
						bool flag3 = _003C_003E4__this.SendEvent(dest, json, target, delayInSeconds);
					});
				}
				int value3 = ((int?*)num)->Value;
				IntPtr intPtr = (IntPtr)asyncUtil;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01e3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+B0]");
				object obj2 = 0L + 8L;
				int num5 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IAsyncWebUtil))
					{
						break;
					}
					num5++;
					int num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
					bool flag = (long)num6 < 0L;
					bool flag2 = !flag;
					obj2 = (long)(IntPtr)obj2 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_01e3;
				}
				object obj3 = obj2 + 2;
				int num7 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr + (long)num7;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_0292;
				IL_01e3:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0292;
				IL_0292:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v293 @ X0_v22] (should have been resolved before IL gen)");
			}

			internal void _003CSendEvent_003Eb__4()
			{
				bool flag = _003C_003E4__this.SendEvent(dest, json, target, delayInSeconds);
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000059")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000112")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000113")]
			public static Action<string> _003C_003E9__11_0;

			[Token(Token = "0x4000114")]
			public static Action<string> _003C_003E9__11_2;

			[Token(Token = "0x4000115")]
			public static Action<string> _003C_003E9__11_3;

			[Token(Token = "0x600014E")]
			[Address(RVA = "0xC5D8A8", Offset = "0xC5D8A8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F06178]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202330F]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.EventQueue+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600014F")]
			[Address(RVA = "0xC5D90C", Offset = "0xC5D90C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CSendEvent_003Eb__11_0(string response)
			{
			}

			internal void _003CSendEvent_003Eb__11_2(string response)
			{
			}

			internal void _003CSendEvent_003Eb__11_3(string error)
			{
			}
		}

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x10")]
		private IAsyncWebUtil m_AsyncUtil;

		[Token(Token = "0x4000107")]
		private static EventQueue QueueInstance;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x18")]
		internal ProfileData Profile;

		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x20")]
		internal string TrackingUrl;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x28")]
		internal string EventUrl;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x30")]
		internal object ProfileDict;

		[Token(Token = "0x6000145")]
		[Address(RVA = "0xC5CD10", Offset = "0xC5CD10", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB7760]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, util, webUtil, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202330C]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tthis.m_AsyncUtil = webUtil;\n\tv48 = UnityEngine.Purchasing.ProfileData::Instance(util);\n\tthis.Profile = v48;\n\tv50 = UnityEngine.Purchasing.ProfileData::GetProfileDict(v48);\n\tthis.ProfileDict = v50;\n\tgoto L_0036;\n\tv58 = *([v54 @ X0_v7+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0036;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, v46, webUtil, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0036:\n\tv72 = UnityEngine.Purchasing.AdsIPC::InitAdsIPC(util);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private EventQueue(IUtil util, IAsyncWebUtil webUtil)
		{
			m_AsyncUtil = webUtil;
			ProfileDict = (Profile = ProfileData.Instance(util)).GetProfileDict();
			bool flag = AdsIPC.InitAdsIPC(util);
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xC5D38C", Offset = "0xC5D38C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1ED1D48]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, webUtil, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202330D]) = v43;\nL_001A:\n\tv57 = v47.QueueInstance;\n\tv49 = v47.QueueInstance == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0031;\n\tv51 = new UnityEngine.Purchasing.EventQueue();\n\tUnityEngine.Purchasing.EventQueue::.ctor(v51, util, webUtil);\n\tv69.QueueInstance = v51;\n\tv57 = v71.QueueInstance;\nL_0031:\n\treturn v57;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static EventQueue Instance(IUtil util, IAsyncWebUtil webUtil)
		{
			EventQueue queueInstance = QueueInstance;
			if (QueueInstance == null)
			{
				EventQueue queueInstance2 = new EventQueue(util, webUtil);
				QueueInstance = queueInstance2;
				queueInstance = QueueInstance;
			}
			return queueInstance;
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0xC5D420", Offset = "0xC5D420", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.TrackingUrl = url;\n\treturn;\n")]
		internal void SetAdsUrl(string url)
		{
			TrackingUrl = url;
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0xC5D428", Offset = "0xC5D428", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.EventUrl = url;\n\treturn;\n")]
		internal void SetIapUrl(string url)
		{
			EventUrl = url;
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0xC5D430", Offset = "0xC5D430", Length = "0x420")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1ED7708]);\n\tv37 = *([v36 @ X8_v69]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, dest, json, url, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202330E]) = v52;\nL_001F:\n\tv56 = new UnityEngine.Purchasing.EventQueue+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v56);\n\tv56.delayInSeconds = delayInSeconds;\n\tv56.<>4__this = this;\n\tv56.dest = dest;\n\tv56.json = json;\n\tv61 = this.m_AsyncUtil == 0;\n\tif (v61) goto L_FFFFFFFF;\n\tv96 = dest == 1;\n\tif (v96) goto L_0052;\n\tv162 = dest == 6;\n\tif (v162) goto L_005C;\n\tv76 = dest != 2;\n\tif (v76) goto L_FFFFFFFF;\n\tv292 = url == 0;\n\tif (v292) goto L_006F;\n\tv56.target = url;\n\tv305 = json == 0;\n\tv150 = ~v305;\n\tif (v150) goto L_0077;\n\tgoto L_FFFFFFFF;\nL_0052:\n\tv167 = url == 0;\n\tif (v167) goto L_00D9;\n\tv56.target = url;\n\tgoto L_00E4;\nL_005C:\n\tgoto L_006D;\n\tv293 = *([v288 @ X0_v35+E0]);\n\tv294 = v293 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_006D;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v288, v57, json, url, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006D:\n\treturnVal3 = UnityEngine.Purchasing.AdsIPC::SendEvent(json);\n\treturn returnVal3;\nL_006F:\n\tv127 = this.EventUrl;\n\tv56.target = this.EventUrl;\n\tv151 = this.EventUrl == 0;\n\tif (v151) goto L_FFFFFFFF;\n\tv152 = json == 0;\n\tif (v152) goto L_FFFFFFFF;\nL_0077:\n\tv119 = this.m_AsyncUtil;\n\tgoto L_0084;\n\tv347 = *([v319 @ X0_v40 (Il2CppClass<UnityEngine.Purchasing.EventQueue+<>c>)+E0]);\n\tv348 = v347 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_0084;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v319, v57, json, url, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv351 = UnityEngine.Purchasing.EventQueue+<>c;\nL_0084:\n\tv122 = v354.<>9__11_0;\n\tv356 = v354.<>9__11_0 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_00A7;\n\tgoto L_0097;\n\tv422 = *([v350 @ X0_v41 (Il2CppClass<UnityEngine.Purchasing.EventQueue+<>c>)+E0]);\n\tv423 = v422 == 0;\n\tv424 = ~v423;\n\tif (v424) goto L_0097;\n\tv427 = \"il2cpp_codegen_runtime_class_init\"(v350, v57, json, url, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv489 = UnityEngine.Purchasing.EventQueue+<>c;\n\tv429 = *([v489 @ X8_v64+B8]);\nL_0097:\n\tv394 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v394, v428.<>9, Il2CppMethodInfo);\n\tv401.<>9__11_0 = v394;\nL_00A7:\n\tv113 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v113, v56, Il2CppMethodInfo);\n\tv492 = *([v119 @ X21_v10 (UnityEngine.Purchasing.IAsyncWebUtil)]);\n\tv496 = *([v492 @ X8_v53 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]) == 0;\n\tif (v496) goto L_00D7;\n\tv581 = *([v492 @ X8_v53 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+B0]) + 8;\nL_00C2:\n\tv596 = *([v581 @ X11_v13-8]) == UnityEngine.Purchasing.IAsyncWebUtil;\n\tif (v596) goto L_016F;\n\tv582 = v582 + 1;\n\tv624 = v582 < *([v492 @ X8_v53 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]);\n\tv546 = ~v624;\n\tv581 = v581 + 0x10;\n\tv530 = ~v546;\n\tif (v530) goto L_00C2;\nL_00D7:\n\tv631 = 0x8909C4(v119, UnityEngine.Purchasing.IAsyncWebUtil, 1, Il2CppMethodInfo, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_017B;\nL_00D9:\n\tv128 = this.TrackingUrl;\n\tv56.target = this.TrackingUrl;\n\tv153 = this.TrackingUrl == 0;\n\tif (v153) goto L_FFFFFFFF;\nL_00E4:\n\tgoto L_00EC;\n\tv306 = *([v301 @ X0_v11 (Il2CppClass<UnityEngine.Purchasing.EventQueue+<>c>)+E0]);\n\tv307 = v306 == 0;\n\tv308 = ~v307;\n\tif (v308) goto L_00EC;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v301, v57, json, url, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv310 = UnityEngine.Purchasing.EventQueue+<>c;\nL_00EC:\n\tv120 = v313.<>9__11_2;\n\tv315 = v313.<>9__11_2 == 0;\n\tv316 = ~v315;\n\tif (v316) goto L_010F;\n\tgoto L_00FF;\n\tv358 = *([v309 @ X0_v12 (Il2CppClass<UnityEngine.Purchasing.EventQueue+<>c>)+E0]);\n\tv359 = v358 == 0;\n\tv360 = ~v359;\n\tif (v360) goto L_00FF;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v309, v57, json, url, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv435 = UnityEngine.Purchasing.EventQueue+<>c;\n\tv365 = *([v435 @ X8_v37+B8]);\nL_00FF:\n\tv369 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v369, v364.<>9, Il2CppMethodInfo);\n\tv341.<>9__11_2 = v369;\nL_010F:\n\tgoto L_0117;\n\tv370 = *([v335 @ X0_v13 (Il2CppClass<UnityEngine.Purchasing.EventQueue+<>c>)+E0]);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tgoto L_0117;\n\tv408 = \"il2cpp_codegen_runtime_class_init\"(v335, v333, v329, v327, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv374 = UnityEngine.Purchasing.EventQueue+<>c;\nL_0117:\n\tv136 = v377.<>9__11_3;\n\tv379 = v377.<>9__11_3 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_013F;\n\tgoto L_012A;\n\tv436 = *([v373 @ X0_v14 (Il2CppClass<UnityEngine.Purchasing.EventQueue+<>c>)+E0]);\n\tv437 = v436 == 0;\n\tv438 = ~v437;\n\tif (v438) goto L_012A;\n\tv441 = \"il2cpp_codegen_runtime_class_init\"(v373, v333, v329, v327, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv497 = UnityEngine.Purchasing.EventQueue+<>c;\n\tv443 = *([v497 @ X8_v28+B8]);\nL_012A:\n\tv416 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v416, v442.<>9, Il2CppMethodInfo);\n\tv420.<>9__11_3 = v416;\nL_013F:\n\tgoto L_016C;\n\tv459 = *([v448 @ X8_v17+B0]);\n\tv460 = 0;\n\tv461 = v459 + 8;\n\tv463 = *([v500 @ X11_v7-8]);\n\tv515 = v463 == v451;\n\tif (v515) goto L_0161;\n\tv467 = v501 + 1;\n\tv550 = v467 < v450;\n\tv485 = ~v550;\n\tv465 = v500 + 0x10;\n\tv469 = ~v485;\n\tif (v469) goto L_FFFFFFFF;\n\tv486 = v125;\n\tv487 = 0;\n\tv488 = 0x8909C4(v486, v451, v487, v64, delayInSeconds, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_016C;\n\tgoto L_0187;\nL_0161:\n\tv551 = *([v500 @ X11_v7]);\n\tv552 = v551 << 4;\n\tv553 = v448 + v552;\n\tv554 = v553 + 0x130;\nL_016C:\n\tUnityEngine.Purchasing.IAsyncWebUtil::Get(this.m_AsyncUtil, v128, v120, v136, 0x1E);\n\tgoto L_FFFFFFFF;\nL_016F:\n\tv626 = *([v581 @ X11_v13]) + 1;\n\tv627 = v626 << 4;\n\tv628 = v492 + v627;\n\tv631 = v628 + 0x130;\nL_017B:\n\t*([v631 @ X0_v45])(v622, v119, v127, json, v122, v113, 0x1E, *([v631 @ X0_v45+8]), v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0187:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 231 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe bool SendEvent(EventDestType dest, string json, string url = null, int? delayInSeconds = null)
		{
			//IL_01cd: Expected I, but got O
			//IL_0208: Expected O, but got I
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Expected O, but got Unknown
			//IL_0301: Expected O, but got I
			//IL_0310: Expected O, but got I
			//IL_0254: Expected O, but got I
			_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass11_0();
			CS_0024_003C_003E8__locals20.delayInSeconds = delayInSeconds;
			CS_0024_003C_003E8__locals20._003C_003E4__this = this;
			CS_0024_003C_003E8__locals20.dest = dest;
			CS_0024_003C_003E8__locals20.json = json;
			if (m_AsyncUtil != null)
			{
				if (dest == EventDestType.AdsTracking)
				{
					string url2;
					if (url != null)
					{
						CS_0024_003C_003E8__locals20.target = url;
						url2 = url;
					}
					else
					{
						url2 = TrackingUrl;
						CS_0024_003C_003E8__locals20.target = TrackingUrl;
						if (TrackingUrl == null)
						{
							goto IL_02c8;
						}
					}
					Action<string> responseHandler = _003C_003Ec._003C_003E9__11_2;
					if (_003C_003Ec._003C_003E9__11_2 == null)
					{
						responseHandler = (_003C_003Ec._003C_003E9__11_2 = delegate
						{
						});
					}
					Action<string> errorHandler = _003C_003Ec._003C_003E9__11_3;
					if (_003C_003Ec._003C_003E9__11_3 == null)
					{
						errorHandler = (_003C_003Ec._003C_003E9__11_3 = delegate
						{
						});
					}
					m_AsyncUtil.Get(url2, responseHandler, errorHandler);
					goto IL_04b8;
				}
				if (dest == EventDestType.AdsIPC)
				{
					return AdsIPC.SendEvent(json);
				}
				if (dest == EventDestType.IAP)
				{
					if (url != null)
					{
						CS_0024_003C_003E8__locals20.target = url;
						bool flag = json == null;
						bool flag2 = !flag;
						string text = url;
						if (flag2)
						{
							goto IL_01b1;
						}
					}
					else
					{
						string text = EventUrl;
						CS_0024_003C_003E8__locals20.target = EventUrl;
						if (EventUrl != null && json != null)
						{
							goto IL_01b1;
						}
					}
				}
			}
			goto IL_02c8;
			IL_026d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_03ab;
			IL_04b8:
			return true;
			IL_02c8:
			return false;
			IL_03ab:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v631 @ X0_v45] (should have been resolved before IL gen)");
			goto IL_04b8;
			IL_01b1:
			IAsyncWebUtil asyncUtil = m_AsyncUtil;
			Action<string> _003C_003E9__11_ = _003C_003Ec._003C_003E9__11_0;
			if (_003C_003Ec._003C_003E9__11_0 == null)
			{
				_003C_003E9__11_ = (_003C_003Ec._003C_003E9__11_0 = delegate
				{
				});
			}
			Action<string> action = delegate
			{
				//IL_0011: Expected O, but got I
				//IL_0077: Expected native int or pointer, but got O
				//IL_008a: Expected I4, but got O
				//IL_0143: Expected I, but got O
				//IL_017e: Expected O, but got I
				//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0200: Expected O, but got Unknown
				//IL_021d: Expected O, but got I
				//IL_022c: Expected O, but got I
				//IL_01ca: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.EventQueue+<>c__DisplayClass11_0)+14]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					return;
				}
				int? num4 = (int?)(object)((long)(IntPtr)CS_0024_003C_003E8__locals20 + 16L);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115BDD8 (inside System.Nullable`1<System.Double>::Unbox +0xC0)");
				object obj5 = default(object);
				int val = (int)((long)(IntPtr)obj5 << 1);
				int value = Math.Max(5, val);
				int? num5 = null;
				num5 = value;
				CS_0024_003C_003E8__locals20.delayInSeconds = null;
				*(int?*)(IntPtr)(void*)num4 = 0;
				int? num6 = default(int?);
				int value2 = Math.Min(300, (int)num6);
				int? num7 = null;
				num7 = value2;
				EventQueue eventQueue = CS_0024_003C_003E8__locals20._003C_003E4__this;
				CS_0024_003C_003E8__locals20.delayInSeconds = null;
				Action action2 = CS_0024_003C_003E8__locals20._003C_003E9__4;
				IAsyncWebUtil asyncUtil2 = eventQueue.m_AsyncUtil;
				if (CS_0024_003C_003E8__locals20._003C_003E9__4 == null)
				{
					action2 = (CS_0024_003C_003E8__locals20._003C_003E9__4 = delegate
					{
						bool flag7 = CS_0024_003C_003E8__locals20._003C_003E4__this.SendEvent(CS_0024_003C_003E8__locals20.dest, CS_0024_003C_003E8__locals20.json, CS_0024_003C_003E8__locals20.target, CS_0024_003C_003E8__locals20.delayInSeconds);
					});
				}
				int value3 = ((int?*)num4)->Value;
				IntPtr intPtr2 = (IntPtr)asyncUtil2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01e3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+B0]");
				object obj6 = 0L + 8L;
				int num8 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IAsyncWebUtil))
					{
						break;
					}
					num8++;
					int num9 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
					bool flag5 = (long)num9 < 0L;
					bool flag6 = !flag5;
					obj6 = (long)(IntPtr)obj6 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_01e3;
				}
				object obj7 = obj6 + 2;
				int num10 = (int)((long)(IntPtr)obj7 << 4);
				object obj8 = (long)intPtr2 + (long)num10;
				object obj9 = (long)(IntPtr)obj8 + 304L;
				goto IL_0292;
				IL_01e3:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0292;
				IL_0292:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v293 @ X0_v22] (should have been resolved before IL gen)");
			};
			IntPtr intPtr = (IntPtr)asyncUtil;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ X8_v53 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_026d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ X8_v53 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ X11_v13-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAsyncWebUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ X8_v53 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
				bool flag3 = (long)num2 < 0L;
				bool flag4 = !flag3;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_026d;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_03ab;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0xC5D858", Offset = "0xC5D858", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = UnityEngine.Purchasing.EventQueue::SendEvent(this, 1, 0, 0, 0);\n\tv25 = UnityEngine.Purchasing.EventQueue::SendEvent(this, 2, json, 0, 0);\n\treturn 0;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal bool SendEvent(string json)
		{
			bool flag = SendEvent(EventDestType.AdsTracking, null);
			bool flag2 = SendEvent(EventDestType.IAP, json);
			return false;
		}
	}
}
