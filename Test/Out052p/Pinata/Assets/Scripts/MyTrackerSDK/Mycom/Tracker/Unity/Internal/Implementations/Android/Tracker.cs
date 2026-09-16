using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Mycom.Tracker.Unity.Internal.Interfaces;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Mycom.Tracker.Unity.Internal.Implementations.Android
{
	[Token(Token = "0x200000F")]
	internal sealed class Tracker : ITracker, IDisposable
	{
		[Token(Token = "0x2000011")]
		private sealed class AttributionListenerImpl : AndroidJavaProxy
		{
			[Token(Token = "0x400001D")]
			[FieldOffset(Offset = "0x20")]
			private readonly Tracker _tracker;

			[Token(Token = "0x6000105")]
			[Address(RVA = "0x161BC30", Offset = "0x161BC30", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBFEB8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, tracker, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2E0]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, tracker, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.my.tracker.MyTracker$AttributionListener\");\n\tthis._tracker = tracker;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AttributionListenerImpl(Tracker tracker)
				: base("com.my.tracker.MyTracker$AttributionListener")
			{
				_tracker = tracker;
			}

			[Token(Token = "0x6000106")]
			[Address(RVA = "0x161F738", Offset = "0x161F738", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED3130]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, attributionJavaObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2E1]) = v41;\nL_0015:\n\tv42 = attributionJavaObject == 0;\n\tif (v42) goto L_0044;\n\tv43 = v39._tracker;\n\tv53 = 0x8D8210(v39, attributionJavaObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = v43._attributionListener == 0;\n\tif (v56) goto L_0044;\n\tv54 = UnityEngine.AndroidJavaObject::Get(attributionJavaObject, \"deeplink\");\n\tv57 = v54 == 0;\n\tif (v57) goto L_0044;\n\tv97 = new Mycom.Tracker.Unity.MyTrackerAttribution();\n\tSystem.Object::.ctor(v97);\n\tv97.<Deeplink>k__BackingField = v54;\n\tSystem.Action`1<Mycom.Tracker.Unity.MyTrackerAttribution>::Invoke(v43._attributionListener, v97);\n\treturn;\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void onReceiveAttribution(AndroidJavaObject attributionJavaObject)
			{
				if (attributionJavaObject == null)
				{
					return;
				}
				Tracker tracker = _tracker;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8210");
				if (tracker._attributionListener != null)
				{
					string text = attributionJavaObject.Get<string>("deeplink");
					if (text != null)
					{
						MyTrackerAttribution myTrackerAttribution = null;
						myTrackerAttribution.Deeplink = text;
						tracker._attributionListener(myTrackerAttribution);
					}
				}
			}
		}

		[Token(Token = "0x4000011")]
		private const string PriceAmountKey = "price_amount_micros";

		[Token(Token = "0x4000012")]
		private const string PriceCurrencyCode = "price_currency_code";

		[Token(Token = "0x4000013")]
		private const int PriceMultiplier = 1000000;

		[Token(Token = "0x4000014")]
		internal static readonly Tracker Instance;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x10")]
		private readonly AttributionListenerImpl _attributionListenerImpl;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x18")]
		private readonly AndroidJavaClass _trackerClass;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x20")]
		private Action<MyTrackerAttribution> _attributionListener;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x28")]
		private MyTrackerParams _myTrackerParams;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x30")]
		private bool _isDisposed;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x38")]
		private TrackerParams _trackerParams;

		[Token(Token = "0x17000022")]
		public MyTrackerParams MyTrackerParams
		{
			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x161E2D8", Offset = "0x161E2D8", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0x8D8210(this, methodInfo, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\treturn this._myTrackerParams;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8210");
				return _myTrackerParams;
			}
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x161BB98", Offset = "0x161BB98", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED7268]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A2CE]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v44, \"com.my.tracker.MyTracker\");\n\tthis._trackerClass = v44;\n\tv53 = new Mycom.Tracker.Unity.Internal.Implementations.Android.Tracker+AttributionListenerImpl();\n\tMycom.Tracker.Unity.Internal.Implementations.Android.Tracker+AttributionListenerImpl::.ctor(v53, this);\n\tthis._attributionListenerImpl = v53;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Tracker()
		{
			AndroidJavaClass trackerClass = new AndroidJavaClass("com.my.tracker.MyTracker");
			_trackerClass = trackerClass;
			_attributionListenerImpl = new AttributionListenerImpl(this);
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x161BCB8", Offset = "0x161BCB8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this._isDisposed;\n\tif (v11) goto L_000E;\n\treturn;\nL_000E:\n\tv15 = this._trackerParams;\n\tthis._isDisposed = 1;\n\tv17 = this._trackerParams == 0;\n\tif (v17) goto L_0026;\n\tv38 = ~v15._isDisposed;\n\tv39 = ~v38;\n\tif (v39) goto L_0026;\n\tv15._isDisposed = 1;\n\tv45 = v15._trackerParamsObject == 0;\n\tif (v45) goto L_0026;\n\tUnityEngine.AndroidJavaObject::Dispose(v15._trackerParamsObject);\nL_0026:\n\tUnityEngine.AndroidJavaObject::Dispose(this._trackerClass);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (_isDisposed)
			{
				return;
			}
			TrackerParams trackerParams = _trackerParams;
			_isDisposed = true;
			if (_trackerParams != null && !trackerParams._isDisposed)
			{
				trackerParams._isDisposed = true;
				if (trackerParams._trackerParamsObject != null)
				{
					trackerParams._trackerParamsObject.Dispose();
				}
			}
			_trackerClass.Dispose();
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x161BD50", Offset = "0x161BD50", Length = "0x7BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001D;\n\tv35 = *([1EABF30]);\n\tv36 = *([v35 @ X8_v110]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, id, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202A2CF]) = v54;\nL_001D:\n\tv55 = &v56 @ stack_-80;\n\t*([v21 @ X29-54]) = 0;\n\tv61 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v61, \"com.unity3d.player.UnityPlayer\");\n\tv75 = UnityEngine.AndroidJavaObject::GetStatic(v61, \"currentActivity\");\n\tv83 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0042;\n\tv105 = v83;\n\tv106 = UnityEngine.AndroidJavaObject::GetStatic(v105, v72, v73);\n\tv109 = *([v83 @ X21_v22 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0042:\n\tv110 = *([v83 @ X21_v22 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv111 = v110 == 0;\n\tif (v111) goto L_0063;\n\tv142 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004F;\n\tv181 = v142;\n\tv182 = UnityEngine.AndroidJavaObject::GetStatic(v181, v72, v73);\nL_004F:\n\tv183 = *([v142 @ X21_v26 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv154 = ~v183;\n\tif (v154) goto L_0063;\n\tgoto L_0063;\n\tv244 = v148;\n\tv245 = UnityEngine.AndroidJavaObject::GetStatic(v244, v72, v73);\nL_0063:\n\tgoto L_0071;\n\tv184 = v89;\n\tv185 = UnityEngine.AndroidJavaObject::GetStatic(v184, v72, v73);\nL_0071:\n\tv197 = UnityEngine.AndroidJavaObject::Call(v75, \"getApplication\", v138.Value);\n\t*([v21 @ X29-54]) = 0;\n\tv248 = &v21 @ X29 - 0x54;\n\tSystem.Threading.Monitor::Enter(this, v248);\n\t// 125 NewArr v134 @ X0_v98 (System.Object[]), typeof(System.Object[]), 2\n\tv316 = id == 0;\n\tif (v316) goto L_0089;\n\t// 134 IsInst v392 @ X0_v144, typeof(System.Object), id @ X1 (System.String)\n\tv394 = v392 == 0;\n\tif (v394) goto L_0265;\nL_0089:\n\tv242 = v134.Length;\n\tv177 = v134.Length == 0;\n\tif (v177) goto L_024D;\n\tv134[0] = id;\n\tv464 = v197 == 0;\n\tif (v464) goto L_0096;\n\t// 146 IsInst v553 @ X0_v142, typeof(System.Object), v197 @ X0_v95 (UnityEngine.AndroidJavaObject)\n\tv554 = v553 == 0;\n\tif (v554) goto L_0269;\n\tv242 = v134.Length;\nL_0096:\n\tv556 = v242 < 1;\n\tv218 = ~v556;\n\tv212 = v242 - 1;\n\tv221 = v212 == 0;\n\tv557 = ~v218;\n\tv200 = v557 | v221;\n\tif (v200) goto L_0251;\n\tv134[1] = v197;\n\tUnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"createTracker\", v134);\n\tv596 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00B8;\n\tv639 = v596;\n\tv640 = UnityEngine.AndroidJavaObject::Call(v639, v303, v305, v294);\n\tv643 = *([v596 @ X24_v26 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00B8:\n\tv644 = *([v596 @ X24_v26 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv645 = v644 == 0;\n\tif (v645) goto L_00D9;\n\tv679 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00C5;\n\tv702 = v679;\n\tv703 = UnityEngine.AndroidJavaObject::Call(v702, v303, v305, v294);\nL_00C5:\n\tv704 = *([v679 @ X24_v36 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv691 = ~v704;\n\tif (v691) goto L_00D9;\n\tgoto L_00D9;\n\tv751 = v685;\n\tv752 = UnityEngine.AndroidJavaObject::Call(v751, v303, v305, v294);\nL_00D9:\n\tgoto L_00E7;\n\tv705 = v298;\n\tv706 = UnityEngine.AndroidJavaObject::Call(v705, v303, v305, v294);\nL_00E7:\n\tv747 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"getTrackerParams\", v743.Value);\n\tv755 = v747 == 0;\n\tif (v755) goto L_0129;\n\t// 237 NewArr v758 @ X0_v115 (System.Object[]), typeof(System.Object[]), 1\n\t*([v21 @ X29-58]) = 0;\n\tv626 = &v21 @ X29 - 0x58;\n\t// 244 Box v630 @ X0_v117, typeof(System.Boolean), v626 @ X1_v54\n\tv827 = v630 == 0;\n\tif (v827) goto L_0101;\n\t// 253 IsInst v732 @ X0_v128, typeof(System.Object), v630 @ X0_v117\n\tv734 = v732 == 0;\n\tif (v734) goto L_0273;\nL_0101:\n\tv673 = v758.Length == 0;\n\tif (v673) goto L_026F;\n\tv758[0] = v630;\n\tUnityEngine.AndroidJavaObject::Call(v747, \"setAutotrackingPurchaseEnabled\", v758);\n\tv895 = new Mycom.Tracker.Unity.Internal.Implementations.Android.TrackerParams();\n\tSystem.Object::.ctor(v895);\n\tv895._trackerParamsObject = v747;\n\tthis._trackerParams = v895;\n\tv1103 = new Mycom.Tracker.Unity.MyTrackerParams();\n\tSystem.Object::.ctor(v1103);\n\tv1103._trackerParams = v895;\n\tv835 = UnityEngine.AndroidJavaObject::CallStatic(v1103, 0, v758);\n\tthis._myTrackerParams = v1103;\n\tgoto L_0136;\nL_0129:\n\tgoto L_0132;\n\tv769 = *([v761 @ X0_v110+E0]);\n\tv770 = v769 == 0;\n\tv771 = ~v770;\n\tif (v771) goto L_0132;\n\tv773 = \"il2cpp_codegen_runtime_class_init\"(v761, v745, v628, v617, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0132:\n\tMycom.Tracker.Unity.LibraryLogger::Log(\"Tracker params is null\");\nL_0136:\n\t*([v55 @ X26_v1]) = 0xE0;\nL_0138:\n\tv850 = *([v21 @ X29-54]) == 0;\n\tif (v850) goto L_013D;\n\tSystem.Threading.Monitor::Exit(this);\nL_013D:\n\tv860 = v499 + 1;\n\tv486 = v860 == 0;\n\tif (v486) goto L_0156;\n\tv511 = v887 == 0;\n\tif (v511) goto L_0152;\n\tv469 = *([v55 @ X26_v1+v499 @ X24_v29 (Il2CppClass<System.EmptyArray`1<System.Object>>)*4]) != 0xE0;\n\tif (v469) goto L_0264;\nL_0152:\n\tv993 = v197 == 0;\n\tv932 = ~v993;\n\tif (v932) goto L_0162;\n\tgoto L_018A;\nL_0156:\n\tv896 = v887 == 0;\n\tv512 = ~v896;\n\tif (v512) goto L_0264;\nL_015A:\n\tv889 = v197 == 0;\n\tif (v889) goto L_018A;\nL_0162:\n\tgoto L_0189;\n\tv994 = *([v937 @ X8_v46+B0]);\n\tv995 = 0;\n\tv996 = v994 + 8;\n\tv998 = *([v1105 @ X11_v32-8]);\n\tv1120 = v998 == v940;\n\tif (v1120) goto L_0182;\n\tv1020 = v1115 + 1;\n\tv1238 = v1020 < v939;\n\tv1014 = ~v1238;\n\tv1000 = v1105 + 0x10;\n\tv1002 = ~v1014;\n\tif (v1002) goto L_FFFFFFFF;\n\tv1021 = v922;\n\tv1022 = 0;\n\tv1023 = 0x8909C4(v1021, v940, v1022, v920, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0189;\nL_0182:\n\tv1239 = *([v1105 @ X11_v32]);\n\tv1240 = v1239 << 4;\n\tv1241 = v937 + v1240;\n\tv1242 = v1241 + 0x130;\nL_0189:\n\tSystem.IDisposable::Dispose(v922);\nL_018A:\n\tv965 = v1081 + 1;\n\tv424 = v965 == 0;\n\tif (v424) goto L_019E;\n\tv453 = v1092 == 0;\n\tif (v453) goto L_01A2;\n\tv423 = *([v55 @ X26_v1+v1081 @ X24_v22 (System.Object[])*4]) == 0xE0;\n\tif (v423) goto L_01A2;\n\tgoto L_0260;\nL_019E:\n\tv1024 = v1092 == 0;\n\tv454 = ~v1024;\n\tif (v454) goto L_0260;\nL_01A2:\n\tv986 = v368 == 0;\n\tif (v986) goto L_01D2;\n\tgoto L_01D1;\n\tv1126 = *([v1026 @ X8_v17+B0]);\n\tv1127 = 0;\n\tv1128 = v1126 + 8;\n\tv1130 = *([v1247 @ X11_v9-8]);\n\tv1262 = v1130 == v1029;\n\tif (v1262) goto L_01CA;\n\tv1152 = v1257 + 1;\n\tv1319 = v1152 < v1028;\n\tv1146 = ~v1319;\n\tv1132 = v1247 + 0x10;\n\tv1134 = ~v1146;\n\tif (v1134) goto L_FFFFFFFF;\n\tv1153 = v368;\n\tv1154 = 0;\n\tv1155 = 0x8909C4(v1153, v1029, v1154, v358, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01D1;\nL_01CA:\n\tv1320 = *([v1247 @ X11_v9]);\n\tv1321 = v1320 << 4;\n\tv1322 = v1026 + v1321;\n\tv1323 = v1322 + 0x130;\nL_01D1:\n\tSystem.IDisposable::Dispose(v368);\nL_01D2:\n\tv1054 = v1081 + 1;\n\tv349 = v1054 == 0;\n\tif (v349) goto L_01EA;\n\tv378 = v1092 == 0;\n\tif (v378) goto L_01E6;\n\tv327 = *([v55 @ X26_v1+v1081 @ X24_v22 (System.Object[])*4]) != 0xE0;\n\tif (v327) goto L_025C;\nL_01E6:\n\tv1268 = v61 == 0;\n\tv1091 = ~v1268;\n\tif (v1091) goto L_01F6;\n\tgoto L_021E;\nL_01EA:\n\tv1156 = v1092 == 0;\n\tv379 = ~v1156;\n\tif (v379) goto L_025C;\n\tv1090 = v61 == 0;\n\tif (v1090) goto L_021E;\nL_01F6:\n\tgoto L_021D;\n\tv1207 = *([v1096 @ X8_v41+B0]);\n\tv1208 = 0;\n\tv1209 = v1207 + 8;\n\tv1211 = *([v1299 @ X11_v25-8]);\n\tv1314 = v1211 == v1099;\n\tif (v1314) goto L_0216;\n\tv1233 = v1309 + 1;\n\tv1369 = v1233 < v1098;\n\tv1227 = ~v1369;\n\tv1213 = v1299 + 0x10;\n\tv1215 = ~v1227;\n\tif (v1215) goto L_FFFFFFFF;\n\tv1234 = v65;\n\tv1235 = 0;\n\tv1236 = 0x8909C4(v1234, v1099, v1235, v1078, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_021D;\nL_0216:\n\tv1370 = *([v1299 @ X11_v25]);\n\tv1371 = v1370 << 4;\n\tv1372 = v1096 + v1371;\n\tv1373 = v1372 + 0x130;\nL_021D:\n\tSystem.IDisposable::Dispose(v61);\nL_021E:\n\tv1202 = v1187 + 1;\n\tv1204 = v1202 == 0;\n\tif (v1204) goto L_0235;\n\tv1269 = v1199 == 0;\n\tif (v1269) goto L_0246;\n\tv1332 = *([v55 @ X26_v1+v1187 @ X24_v2 (System.Object[])*4]) == 0xE0;\n\tif (v1332) goto L_0246;\nL_0234:\n\tthrow System.TypeLoadException;\nL_0235:\n\tv1296 = v1199 == 0;\n\tv1297 = ~v1296;\n\tif (v1297) goto L_0234;\nL_0246:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv140 = new System.NullReferenceExce\n// ... truncated")]
		public unsafe void Create(string id)
		{
			//IL_010e: Expected O, but got I4
			//IL_077e: Expected O, but got I
			//IL_0190: Expected O, but got I4
			//IL_0381: Expected I, but got O
			//IL_0386: Expected I, but got O
			//IL_0269: Expected O, but got I
			//IL_0272: Expected I4, but got O
			//IL_07ef: Expected O, but got I4
			//IL_03a5: Expected O, but got I
			//IL_049b: Expected O, but got I8
			//IL_08fc: Expected O, but got I8
			//IL_0363: Expected I, but got O
			//IL_0368: Expected I, but got O
			//IL_0803: Expected O, but got I
			//IL_0529: Expected O, but got I8
			//IL_0929: Expected O, but got I
			//IL_05f9: Expected O, but got I8
			//IL_0606: Expected O, but got I8
			//IL_0880: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X21_v22 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X21_v26 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getApplication", Array.Empty<object>());
			_ = 0;
			Monitor.Enter(this, ref *(bool*)((long)(IntPtr)obj - 84L));
			object[] array = new object[2];
			if (id != null)
			{
				object obj4 = id as object;
				if (obj4 == null)
				{
					goto IL_06c8;
				}
			}
			object obj5 = array.Length;
			object[] array4;
			AndroidJavaObject androidJavaObject7;
			IntPtr intPtr7;
			if (array.Length != 0)
			{
				array[0] = id;
				if (androidJavaObject2 != null)
				{
					object obj6 = androidJavaObject2 as object;
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
					obj5 = array.Length;
				}
				bool flag = (long)(IntPtr)obj5 < 1L;
				bool flag2 = !flag;
				object obj7 = (long)(IntPtr)obj5 - 1L;
				bool flag3 = obj7 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = androidJavaObject2;
					_trackerClass.CallStatic("createTracker", array);
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ X24_v26 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr4 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ X24_v36 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					AndroidJavaObject androidJavaObject3 = _trackerClass.CallStatic<AndroidJavaObject>("getTrackerParams", Array.Empty<object>());
					IntPtr intPtr5;
					IntPtr intPtr6;
					if (androidJavaObject3 != null)
					{
						object[] array2 = new object[1];
						_ = 0;
						object obj8 = (long)(IntPtr)obj - 88L;
						object obj9 = (byte)(int)obj8 != 0;
						if (obj9 != null)
						{
							object obj10 = obj9 as object;
							if (obj10 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						if (array2.Length == 0)
						{
							IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
							throw ex3;
						}
						array2[0] = obj9;
						androidJavaObject3.Call("setAutotrackingPurchaseEnabled", array2);
						TrackerParams trackerParams = null;
						trackerParams._trackerParamsObject = androidJavaObject3;
						_trackerParams = trackerParams;
						MyTrackerParams myTrackerParams = null;
						myTrackerParams._trackerParams = trackerParams;
						AndroidJavaObject androidJavaObject4 = ((AndroidJavaObject)(object)myTrackerParams).CallStatic<AndroidJavaObject>((string)null, array2);
						_myTrackerParams = myTrackerParams;
						intPtr5 = (IntPtr)null;
						intPtr6 = (IntPtr)null;
					}
					else
					{
						LibraryLogger.Log("Tracker params is null");
						intPtr5 = (IntPtr)null;
						intPtr6 = (IntPtr)null;
					}
					obj2 = 224;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Monitor.Exit(this);
					}
					object obj11 = (long)intPtr5 + 1L;
					AndroidJavaObject androidJavaObject5;
					object[] array3;
					AndroidJavaObject androidJavaObject6;
					if (obj11 != null)
					{
						if (intPtr6 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v499 @ X24_v29 (Il2CppClass<System.EmptyArray`1<System.Object>>)*4]");
							if ((IntPtr)0 != (IntPtr)224)
							{
								goto IL_06ba;
							}
						}
						bool flag5 = androidJavaObject2 == null;
						bool flag6 = !flag5;
						androidJavaObject5 = androidJavaObject2;
						array3 = null;
						androidJavaObject6 = androidJavaObject;
						if (!flag6)
						{
							array4 = null;
							androidJavaObject7 = androidJavaObject;
							intPtr7 = intPtr6;
							goto IL_07f4;
						}
					}
					else
					{
						if (intPtr6 != (IntPtr)0)
						{
							goto IL_06ba;
						}
						androidJavaObject5 = androidJavaObject2;
						array3 = (object[])4294967295L;
						androidJavaObject6 = androidJavaObject;
						bool flag7 = androidJavaObject2 == null;
						array4 = (object[])4294967295L;
						androidJavaObject7 = androidJavaObject;
						intPtr7 = intPtr6;
						if (flag7)
						{
							goto IL_07f4;
						}
					}
					((IDisposable)androidJavaObject5).Dispose();
					array4 = array3;
					androidJavaObject7 = androidJavaObject6;
					intPtr7 = intPtr6;
					goto IL_07f4;
				}
				IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
				throw ex4;
			}
			IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
			throw ex5;
			IL_07f4:
			object obj12 = (long)(IntPtr)array4 + 1L;
			if (obj12 != null)
			{
				if (intPtr7 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v1081 @ X24_v22 (System.Object[])*4]");
					if ((IntPtr)0 != (IntPtr)224)
					{
						goto IL_06b4;
					}
				}
			}
			else
			{
				if (intPtr7 != (IntPtr)0)
				{
					goto IL_06b4;
				}
				array4 = (object[])4294967295L;
			}
			((IDisposable)androidJavaObject7)?.Dispose();
			object obj13 = (long)(IntPtr)array4 + 1L;
			object[] array5;
			IntPtr intPtr8;
			if (obj13 != null)
			{
				if (intPtr7 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v1081 @ X24_v22 (System.Object[])*4]");
					if ((IntPtr)0 != (IntPtr)224)
					{
						goto IL_06ae;
					}
				}
				if (androidJavaClass == null)
				{
					array5 = array4;
					intPtr8 = intPtr7;
					goto IL_0871;
				}
			}
			else
			{
				if (intPtr7 != (IntPtr)0)
				{
					goto IL_06ae;
				}
				bool flag8 = androidJavaClass == null;
				array4 = (object[])4294967295L;
				array5 = (object[])4294967295L;
				intPtr8 = intPtr7;
				if (flag8)
				{
					goto IL_0871;
				}
			}
			((IDisposable)androidJavaClass).Dispose();
			array5 = array4;
			intPtr8 = intPtr7;
			goto IL_0871;
			IL_06ba:
			TypeLoadException ex6 = new TypeLoadException();
			goto IL_06c8;
			IL_06ae:
			throw new TypeLoadException();
			IL_06c8:
			ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
			throw ex7;
			IL_0871:
			object obj14 = (long)(IntPtr)array5 + 1L;
			if (obj14 != null)
			{
				if (intPtr8 == (IntPtr)0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v1187 @ X24_v2 (System.Object[])*4]");
				if ((IntPtr)0 == (IntPtr)224)
				{
					return;
				}
			}
			else if (intPtr8 == (IntPtr)0)
			{
				return;
			}
			throw new TypeLoadException();
			IL_06b4:
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x161C628", Offset = "0x161C628", Length = "0x38C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EC6340]);\n\tv25 = *([v24 @ X8_v54]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A2D0]) = v44;\nL_001B:\n\tv50 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv55 = v50;\n\tv56 = 0x8907BC(v55, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv59 = *([v50 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv60 = *([v50 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv61 = v60 == 0;\n\tif (v61) goto L_0045;\n\tv63 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv85 = v63;\n\tv86 = 0x8907BC(v85, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0031:\n\tv87 = *([v63 @ X20_v15 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv75 = ~v87;\n\tif (v75) goto L_0045;\n\tgoto L_0045;\n\tv104 = v69;\n\tv105 = 0x8907BC(v104, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0045:\n\tgoto L_0051;\n\tv88 = v80;\n\tv89 = 0x8907BC(v88, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0051:\n\tUnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"initTracker\", v96.Value);\n\tv111 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v111, \"com.unity3d.player.UnityPlayer\");\n\tv239 = UnityEngine.AndroidJavaObject::GetStatic(v111, \"currentActivity\");\n\t// 107 NewArr v274 @ X0_v45 (System.Object[]), typeof(System.Object[]), 1\n\tv281 = new UnityEngine.AndroidJavaRunnable();\n\tUnityEngine.AndroidJavaRunnable::.ctor(v281, this, Il2CppMethodInfo);\n\tv344 = v281 == 0;\n\tif (v344) goto L_0084;\n\t// 128 IsInst v333 @ X0_v58, typeof(System.Object), v281 @ X0_v47 (UnityEngine.AndroidJavaRunnable)\n\tv335 = v333 == 0;\n\tif (v335) goto L_011E;\nL_0084:\n\tv264 = v274.Length == 0;\n\tif (v264) goto L_0118;\n\tv274[0] = v281;\n\tUnityEngine.AndroidJavaObject::Call(v239, \"runOnUiThread\", v274);\nL_0098:\n\tgoto L_00BF;\n\tv425 = *([v418 @ X8_v41+B0]);\n\tv426 = 0;\n\tv427 = v425 + 8;\n\tv429 = *([v503 @ X11_v19-8]);\n\tv508 = v429 == v421;\n\tif (v508) goto L_00B8;\n\tv449 = v502 + 1;\n\tv546 = v449 < v420;\n\tv447 = ~v546;\n\tv451 = v503 + 0x10;\n\tv431 = ~v447;\n\tif (v431) goto L_FFFFFFFF;\n\tv452 = v222;\n\tv453 = 0;\n\tv454 = 0x8909C4(v452, v421, v453, v379, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00BF;\nL_00B8:\n\tv547 = *([v503 @ X11_v19]);\n\tv548 = v547 << 4;\n\tv549 = v418 + v548;\n\tv550 = v549 + 0x130;\nL_00BF:\n\tSystem.IDisposable::Dispose(v239);\n\tgoto L_00CB;\n\tgoto L_0125;\nL_00CB:\n\tv536 = v111 == 0;\n\tif (v536) goto L_00FB;\nL_00D3:\n\tgoto L_00FA;\n\tv585 = *([v541 @ X8_v20+B0]);\n\tv586 = 0;\n\tv587 = v585 + 8;\n\tv589 = *([v630 @ X11_v13-8]);\n\tv635 = v589 == v544;\n\tif (v635) goto L_00F3;\n\tv609 = v629 + 1;\n\tv640 = v609 < v543;\n\tv607 = ~v640;\n\tv611 = v630 + 0x10;\n\tv591 = ~v607;\n\tif (v591) goto L_FFFFFFFF;\n\tv612 = v539;\n\tv613 = 0;\n\tv614 = 0x8909C4(v612, v544, v613, v531, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00FA;\nL_00F3:\n\tv641 = *([v630 @ X11_v13]);\n\tv642 = v641 << 4;\n\tv643 = v541 + v642;\n\tv644 = v643 + 0x130;\nL_00FA:\n\tSystem.IDisposable::Dispose(v539);\nL_00FB:\n\tv584 = v171 + 1;\n\tv152 = v584 == 0;\n\tv137 = ~v152;\n\tif (v137) goto L_010D;\n\tv618 = v187 == 0;\n\tv185 = ~v618;\n\tif (v185) goto L_0115;\nL_010D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0115:\n\tthrow System.TypeLoadException;\n\tv232 = new System.NullReferenceException();\nL_0118:\n\tv269 = new System.IndexOutOfRangeException();\n\tthrow v269;\n\tv309 = new System.NullReferenceException();\nL_011E:\n\tv340 = new System.ArrayTypeMismatchException();\n\tthrow v340;\nL_0125:\n\tv395 = new System.TypeLoadException();\n\tgoto L_0148;\n\tgoto L_012B;\n\tgoto L_012B;\n\t// 297 Jump @b67\n\tgoto L_0148;\nL_012B:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\t// 309 ConditionalJump @b67, TEMPCOND\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX22 = 0xFFFFFFFF;\n\tgoto L_0098;\nL_0148:\n\tgoto L_0150;\n\tv415 = 0x6D2BC0(v395, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv537 = *([v415 @ X0_v10]);\n\tv424 = 0x6D2490(v415, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv455 = v111 == 0;\n\tv456 = ~v455;\n\tif (v456) goto L_00D3;\n\tgoto L_00FB;\nL_0150:\n\tv416 = 0x6D2380(v395, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X20_v15 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			_trackerClass.CallStatic("initTracker");
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			object[] array = new object[1];
			AndroidJavaRunnable androidJavaRunnable = delegate
			{
				AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject androidJavaObject2 = androidJavaClass3.GetStatic<AndroidJavaObject>("currentActivity");
				object[] array2 = new object[1];
				if (androidJavaObject2 != null)
				{
					object obj2 = androidJavaObject2 as object;
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				if (array2.Length != 0)
				{
					array2[0] = androidJavaObject2;
					_trackerClass.CallStatic("trackLaunchManually", array2);
					((IDisposable)androidJavaObject2)?.Dispose();
					int num5 = 0;
					bool flag3 = androidJavaClass3 == null;
					int num6 = 0;
					int num7 = num5;
					int num8 = 0;
					if (!flag3)
					{
						((IDisposable)androidJavaClass3).Dispose();
						num7 = num5;
						num8 = num6;
					}
					if (num7 + 1 != 0 || num8 == 0)
					{
						return;
					}
					TypeLoadException ex4 = new TypeLoadException();
				}
				IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
				throw ex5;
			};
			if (androidJavaRunnable != null)
			{
				object obj = androidJavaRunnable as object;
				bool flag = obj == null;
				AndroidJavaClass androidJavaClass2 = androidJavaClass;
				if (flag)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaRunnable;
				androidJavaObject.Call("runOnUiThread", array);
				((IDisposable)androidJavaObject).Dispose();
				int num = 0;
				bool flag2 = androidJavaClass == null;
				int num2 = 0;
				AndroidJavaClass androidJavaClass2 = androidJavaClass;
				int num3 = num;
				int num4 = 0;
				if (!flag2)
				{
					((IDisposable)androidJavaClass2).Dispose();
					num3 = num;
					num4 = num2;
				}
				if (num3 + 1 != 0 || num4 == 0)
				{
					return;
				}
				throw new TypeLoadException();
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x161C9B4", Offset = "0x161C9B4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC9538]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2D1]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"isDebugMode\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsDebugMode()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerClass.CallStatic<bool>("isDebugMode", Array.Empty<object>());
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x161CAB4", Offset = "0x161CAB4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EAD690]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2D2]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"isEnabled\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsEnabled()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerClass.CallStatic<bool>("isEnabled", Array.Empty<object>());
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x161CBB4", Offset = "0x161CBB4", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EA3488]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, listener, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202A2D3]) = v45;\nL_001B:\n\tSystem.Threading.Monitor::Enter(this, &v48 @ stack_-34_v2 (System.Boolean));\n\tv51 = 0x8D8210(this, &v48 @ stack_-34_v2 (System.Boolean), 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis._attributionListener = listener;\n\t// 35 NewArr v57 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv62 = listener == 0;\n\tif (v62) goto L_002D;\nL_002D:\n\tv66 = v64 == 0;\n\tif (v66) goto L_0036;\n\t// 50 IsInst v115 @ X0_v29, typeof(System.Object), v64 @ X22_v2 (System.Action`1<Mycom.Tracker.Unity.MyTrackerAttribution>)\n\tv119 = v115 == 0;\n\tif (v119) goto L_0067;\nL_0036:\n\tv122 = v57.Length == 0;\n\tif (v122) goto L_0061;\n\tv57[0] = v64;\n\tUnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"setAttributionListener\", v57);\nL_0043:\n\tv213 = ~v48;\n\tif (v213) goto L_0048;\n\tSystem.Threading.Monitor::Exit(this);\nL_0048:\n\tv219 = 0 + 1;\n\tv89 = v219 == 0;\n\tv80 = ~v89;\n\tif (v80) goto L_005A;\n\tv222 = 0 == 0;\n\tv105 = ~v222;\n\tif (v105) goto L_005E;\nL_005A:\n\treturn;\nL_005E:\n\tthrow System.TypeLoadException;\n\tv111 = new System.NullReferenceException();\nL_0061:\n\tv140 = new System.IndexOutOfRangeException();\n\tthrow v140;\n\tv172 = new System.NullReferenceException();\nL_0067:\n\tv179 = new System.ArrayTypeMismatchException();\n\tthrow v179;\n\tgoto L_0078;\n\tgoto L_0078;\n\tgoto L_0078;\nL_0078:\n\tif (1) goto L_007E;\n\tv220 = 0x6D2BC0(v188, 0, 0, v163, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv212 = *([v220 @ X0_v15]);\n\tv209 = 0x6D2490(v220, 0, 0, v163, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0043;\nL_007E:\n\tv221 = 0x6D2380(v188, 0, 0, v163, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetAttributionListener(Action<MyTrackerAttribution> listener)
		{
			bool lockTaken = default(bool);
			Monitor.Enter(this, ref lockTaken);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8210");
			_attributionListener = listener;
			object[] array = new object[1];
			bool flag = listener == null;
			Action<MyTrackerAttribution> action = listener;
			if (!flag)
			{
				action = (Action<MyTrackerAttribution>)(object)_attributionListenerImpl;
			}
			if (action != null)
			{
				object obj = action as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = action;
				_trackerClass.CallStatic("setAttributionListener", array);
				if (lockTaken)
				{
					Monitor.Exit(this);
				}
				if (true || 0 == 0)
				{
					return;
				}
				throw new TypeLoadException();
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x161CD28", Offset = "0x161CD28", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB49F8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2D4]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"setDebugMode\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetDebugMode(bool value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerClass.CallStatic("setDebugMode", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x161CE14", Offset = "0x161CE14", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F09020]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2D5]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"setEnabled\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEnabled(bool value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerClass.CallStatic("setEnabled", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x161CF00", Offset = "0x161CF00", Length = "0x474")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ED6A10]);\n\tv31 = *([v30 @ X8_v56]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, name, eventParams, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202A2D6]) = v48;\nL_0019:\n\tv49 = &v50 @ stack_-50;\n\tv54 = System.String::IsNullOrEmpty(name);\n\tv56 = v54 == 0;\n\tif (v56) goto L_0024;\n\tgoto L_0138;\nL_0024:\n\tv59 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(name);\n\tv156 = eventParams == 0;\n\tif (v156) goto L_00C3;\n\tgoto L_0055;\n\tv259 = *([v210 @ X8_v33+B0]);\n\tv260 = 0;\n\tv261 = v259 + 8;\n\tv263 = *([v301 @ X11_v31-8]);\n\tv307 = v263 == v213;\n\tif (v307) goto L_004E;\n\tv285 = v302 + 1;\n\tv315 = v285 < v212;\n\tv281 = ~v315;\n\tv283 = v301 + 0x10;\n\tv265 = ~v281;\n\tif (v265) goto L_FFFFFFFF;\n\tv286 = v20;\n\tv287 = 0;\n\tv288 = 0x8909C4(v286, v213, v287, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0055;\nL_004E:\n\tv316 = *([v301 @ X11_v31]);\n\tv317 = v316 << 4;\n\tv318 = v210 + v317;\n\tv319 = v318 + 0x130;\nL_0055:\n\tv248 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(eventParams);\n\tv250 = v248 == 0;\n\tif (v250) goto L_00C3;\n\tv340 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(eventParams);\n\t// 96 NewArr v351 @ X0_v70 (System.Object[]), typeof(System.Object[]), 2\n\tv450 = v59 == 0;\n\tif (v450) goto L_006C;\n\t// 105 IsInst v471 @ X0_v85, typeof(System.Object), v59 @ X0_v7 (UnityEngine.AndroidJavaObject)\n\tv473 = v471 == 0;\n\tif (v473) goto L_018F;\nL_006C:\n\tv740 = v351.Length;\n\tv558 = v351.Length == 0;\n\tif (v558) goto L_017D;\n\tv351[0] = v59;\n\tv643 = v340 == 0;\n\tif (v643) goto L_0079;\n\t// 117 IsInst v657 @ X0_v83, typeof(System.Object), v340 @ X0_v68 (UnityEngine.AndroidJavaObject)\n\tv658 = v657 == 0;\n\tif (v658) goto L_0193;\n\tv740 = v351.Length;\nL_0079:\n\tv745 = v740 < 1;\n\tv727 = ~v745;\n\tv725 = v740 - 1;\n\tv721 = v725 == 0;\n\tv746 = ~v727;\n\tv711 = v746 | v721;\n\tif (v711) goto L_0181;\n\tv351[1] = v340;\n\tv817 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackEvent\", v351);\n\tv536 = 0;\n\t*([v49 @ X23_v1]) = 0x75;\n\tv834 = v340 == 0;\n\tif (v834) goto L_0146;\nL_009E:\n\tgoto L_0140;\n\tv876 = *([v837 @ X8_v46+B0]);\n\tv877 = 0;\n\tv878 = v876 + 8;\n\tv880 = *([v919 @ X11_v26-8]);\n\tv925 = v880 == v840;\n\tif (v925) goto L_0139;\n\tv902 = v920 + 1;\n\tv933 = v902 < v839;\n\tv898 = ~v933;\n\tv900 = v919 + 0x10;\n\tv882 = ~v898;\n\tif (v882) goto L_FFFFFFFF;\n\tv903 = v345;\n\tv904 = 0;\n\tv905 = 0x8909C4(v903, v840, v904, v485, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0140;\nL_00C3:\n\t// 195 NewArr v258 @ X0_v50 (System.Object[]), typeof(System.Object[]), 1\n\tv312 = v59 == 0;\n\tif (v312) goto L_00D0;\n\t// 204 IsInst v326 @ X0_v63, typeof(System.Object), v59 @ X0_v7 (UnityEngine.AndroidJavaObject)\n\tv330 = v326 == 0;\n\tif (v330) goto L_018B;\nL_00D0:\n\tv333 = v258.Length == 0;\n\tif (v333) goto L_0175;\n\tv258[0] = v59;\n\tv409 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackEvent\", v258);\n\t*([v49 @ X23_v1]) = 0x75;\nL_00E3:\n\tv537 = v59 == 0;\n\tif (v537) goto L_0113;\nL_00EB:\n\tgoto L_0112;\n\tv662 = *([v611 @ X8_v18+B0]);\n\tv663 = 0;\n\tv664 = v662 + 8;\n\tv666 = *([v758 @ X11_v17-8]);\n\tv764 = v666 == v614;\n\tif (v764) goto L_010B;\n\tv688 = v759 + 1;\n\tv778 = v688 < v613;\n\tv684 = ~v778;\n\tv686 = v758 + 0x10;\n\tv668 = ~v684;\n\tif (v668) goto L_FFFFFFFF;\n\tv689 = v137;\n\tv690 = 0;\n\tv691 = 0x8909C4(v689, v614, v690, v573, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0112;\nL_010B:\n\tv779 = *([v758 @ X11_v17]);\n\tv780 = v779 << 4;\n\tv781 = v611 + v780;\n\tv782 = v781 + 0x130;\nL_0112:\n\tSystem.IDisposable::Dispose(v59);\nL_0113:\n\tv639 = v145 + 1;\n\tv99 = v639 == 0;\n\tif (v99) goto L_012A;\n\tv133 = v135 == 0;\n\tif (v133) goto L_0138;\n\tv100 = *([v49 @ X23_v1+v145 @ X22_v5 (System.Object[])*4]) == 0x75;\n\tif (v100) goto L_0138;\nL_0129:\n\tthrow System.TypeLoadException;\nL_012A:\n\tv706 = v135 == 0;\n\tv132 = ~v706;\n\tif (v132) goto L_0129;\nL_0138:\n\treturn v138;\nL_0139:\n\tv934 = *([v919 @ X11_v26]);\n\tv935 = v934 << 4;\n\tv936 = v837 + v935;\n\tv937 = v936 + 0x130;\nL_0140:\n\tSystem.IDisposable::Dispose(v340);\nL_0146:\n\tgoto L_014B;\nL_014B:\n\tv505 = v817 == 0;\n\tv491 = ~v505;\n\tgoto L_00E3;\n\tv506 = *([v49 @ X23_v1+v536 @ X22_v17 (System.Object[])*4]) == 0x75;\n\tif (v506) goto L_00E3;\n\tgoto L_018A;\n\tv587 = v817 == 0;\n\tv577 = ~v587;\n\tgoto L_018A;\n\tv931 = v59 == 0;\n\tv601 = ~v931;\n\tif (v601) goto L_00EB;\n\tgoto L_0113;\n\tv314 = new System.NullReferenceException();\nL_0175:\n\tv338 = new System.IndexOutOfRangeException();\n\tthrow v338;\n\tthrow System.NullReferenceException;\n\tv449 = new System.NullReferenceException();\nL_017D:\n\tv564 = new System.IndexOutOfRangeException();\n\tthrow v564;\nL_0181:\n\tv742 = new System.IndexOutOfRangeException();\n\tthrow v742;\n\tthrow System.NullReferenceException;\nL_018A:\n\tv389 = new System.TypeLoadException();\nL_018B:\n\tv400 = new System.ArrayTypeMismatchException();\n\tthrow v400;\nL_018F:\n\tv479 = new System.ArrayTypeMismatchException();\n\tthrow v479;\nL_0193:\n\tv661 = new System.ArrayTypeMismatchException();\n\tthrow v661;\n\tgoto L_019F;\n\tgoto L_01A8;\n\tgoto L_01A8;\n\tgoto L_01BE;\nL_019F:\n\tv822 = v162 == 0;\n\tv827 = ~v822;\n\tgoto L_01CA;\n\tgoto L_01BE;\nL_01A8:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01BE;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = 0;\n\tX22 = 0xFFFFFFFF;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009E;\n\tgoto L_0146;\n\tgoto L_01BE;\n\tgoto L_01BE;\nL_01BE:\n\tX20 = 0;\n\tX22 = 0xFFFFFFFF;\nL_01CA:\n\tif (1) goto L_01D2;\n\tv875 = 0x6D2BC0(v747, 0, 0, v164, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv604 = *([v875 @ X0_v18]);\n\tv599 = 0x6D2490(v875, 0, 0, v164, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv932 = v59 == 0;\n\tv602 = ~v932;\n\tif (v602) goto L_00EB;\n\tgoto L_0113;\nL_01D2:\n\treturnVal2 = 0x6D2380(v747, 0, 0, v164, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal2;\n// 260 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackEvent(string name, IDictionary<string, string> eventParams = null)
		{
			//IL_024b: Expected O, but got I4
			//IL_00b4: Expected O, but got I4
			//IL_051c: Expected O, but got I
			//IL_04c5: Expected O, but got I
			//IL_0178: Expected O, but got I4
			//IL_0136: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			bool result;
			if (string.IsNullOrEmpty(name))
			{
				result = false;
			}
			else
			{
				AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaString(name);
				int num;
				bool flag8;
				object[] array3;
				if (eventParams != null && eventParams.Count != 0)
				{
					AndroidJavaObject androidJavaObject2 = JavaHelper.CreateJavaStringMap(eventParams);
					object[] array = new object[2];
					if (androidJavaObject != null)
					{
						object obj3 = androidJavaObject as object;
						if (obj3 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					object obj4 = array.Length;
					if (array.Length == 0)
					{
						IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
						throw ex2;
					}
					array[0] = androidJavaObject;
					if (androidJavaObject2 != null)
					{
						object obj5 = androidJavaObject2 as object;
						if (obj5 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
						obj4 = array.Length;
					}
					bool flag = (long)(IntPtr)obj4 < 1L;
					bool flag2 = !flag;
					object obj6 = (long)(IntPtr)obj4 - 1L;
					bool flag3 = obj6 == null;
					bool flag4 = !flag2;
					if (flag4 || flag3)
					{
						IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
						throw ex4;
					}
					array[1] = androidJavaObject2;
					bool flag5 = _trackerClass.CallStatic<bool>("trackEvent", array);
					object[] array2 = null;
					obj = 117;
					((IDisposable)androidJavaObject2)?.Dispose();
					bool flag6 = !flag5;
					bool flag7 = !flag6;
					num = 0;
					flag8 = flag7;
					array3 = null;
				}
				else
				{
					object[] array4 = new object[1];
					if (androidJavaObject != null)
					{
						object obj7 = androidJavaObject as object;
						if (obj7 == null)
						{
							ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
							throw ex5;
						}
					}
					if (array4.Length == 0)
					{
						IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
						throw ex6;
					}
					array4[0] = androidJavaObject;
					bool flag9 = _trackerClass.CallStatic<bool>("trackEvent", array4);
					obj = 117;
					num = 0;
					flag8 = flag9;
					array3 = null;
				}
				bool flag10 = androidJavaObject == null;
				int num2 = num;
				result = flag8;
				object[] array5 = array3;
				if (!flag10)
				{
					((IDisposable)androidJavaObject).Dispose();
					num2 = num;
					result = flag8;
					array5 = array3;
				}
				object obj8 = (long)(IntPtr)array5 + 1L;
				if (obj8 != null)
				{
					if (num2 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X23_v1+v145 @ X22_v5 (System.Object[])*4]");
						if ((IntPtr)0 != (IntPtr)117)
						{
							goto IL_02ad;
						}
					}
				}
				else if (num2 != 0)
				{
					goto IL_02ad;
				}
			}
			return result;
			IL_02ad:
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x161D374", Offset = "0x161D374", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F01390]);\n\tv25 = *([v24 @ X8_v44]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventParams, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202A2D7]) = v43;\nL_0016:\n\tv44 = eventParams == 0;\n\tif (v44) goto L_009C;\n\tgoto L_0045;\n\tv113 = *([v46 @ X8_v30+B0]);\n\tv114 = 0;\n\tv115 = v113 + 8;\n\tv117 = *([v160 @ X11_v19-8]);\n\tv166 = v117 == v49;\n\tif (v166) goto L_003E;\n\tv139 = v161 + 1;\n\tv194 = v139 < v48;\n\tv135 = ~v194;\n\tv137 = v160 + 0x10;\n\tv119 = ~v135;\n\tif (v119) goto L_FFFFFFFF;\n\tv140 = v16;\n\tv141 = 0;\n\tv142 = 0x8909C4(v140, v49, v141, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0045;\nL_003E:\n\tv195 = *([v160 @ X11_v19]);\n\tv196 = v195 << 4;\n\tv197 = v46 + v196;\n\tv198 = v197 + 0x130;\nL_0045:\n\tv98 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(eventParams);\n\tv100 = v98 == 0;\n\tif (v100) goto L_009C;\n\tv210 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(eventParams);\n\t// 81 NewArr v239 @ X0_v55 (System.Object[]), typeof(System.Object[]), 1\n\tv380 = v210 == 0;\n\tif (v380) goto L_005E;\n\t// 90 IsInst v413 @ X0_v60, typeof(System.Object), v210 @ X0_v53 (UnityEngine.AndroidJavaObject)\n\tv415 = v413 == 0;\n\tif (v415) goto L_0106;\nL_005E:\n\tv403 = v239.Length == 0;\n\tif (v403) goto L_0100;\n\tv239[0] = v210;\n\tv468 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackInviteEvent\", v239);\n\tv473 = v210 == 0;\n\tif (v473) goto L_00E5;\nL_0077:\n\tgoto L_00E4;\n\tv535 = *([v504 @ X8_v26+B0]);\n\tv536 = 0;\n\tv537 = v535 + 8;\n\tv539 = *([v577 @ X11_v13-8]);\n\tv583 = v539 == v507;\n\tif (v583) goto L_00DD;\n\tv561 = v578 + 1;\n\tv588 = v561 < v506;\n\tv557 = ~v588;\n\tv559 = v577 + 0x10;\n\tv541 = ~v557;\n\tif (v541) goto L_FFFFFFFF;\n\tv562 = v497;\n\tv563 = 0;\n\tv564 = 0x8909C4(v562, v507, v563, v477, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00E4;\nL_009C:\n\tv108 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00A5;\n\tv143 = v108;\n\tv144 = UnityEngine.AndroidJavaObject::CallStatic(v143, v89, v57, v28);\n\tv147 = *([v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00A5:\n\tv148 = *([v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv149 = v148 == 0;\n\tif (v149) goto L_00C6;\n\tv172 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00B2;\n\tv202 = v172;\n\tv203 = UnityEngine.AndroidJavaObject::CallStatic(v202, v89, v57, v28);\nL_00B2:\n\tv204 = *([v172 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv182 = ~v204;\n\tif (v182) goto L_00C6;\n\tgoto L_00C6;\n\tv240 = v184;\n\tv241 = UnityEngine.AndroidJavaObject::CallStatic(v240, v89, v57, v28);\nL_00C6:\n\tgoto L_00DB;\n\tv205 = v189;\n\tv206 = UnityEngine.AndroidJavaObject::CallStatic(v205, v89, v57, v28);\nL_00DB:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackInviteEvent\", v216.Value);\n\treturn returnVal1;\nL_00DD:\n\tv589 = *([v577 @ X11_v13]);\n\tv590 = v589 << 4;\n\tv591 = v504 + v590;\n\tv592 = v591 + 0x130;\nL_00E4:\n\tSystem.IDisposable::Dispose(v210);\nL_00E5:\n\tv533 = v348 + 1;\n\tv303 = v533 == 0;\n\tv288 = ~v303;\n\tif (v288) goto L_00F7;\n\tv565 = ~v375;\n\tv368 = ~v565;\n\tif (v368) goto L_00FF;\nL_00F7:\n\treturn v372;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00FF:\n\tv379 = new System.TypeLoadException();\nL_0100:\n\tv409 = new System.IndexOutOfRangeException();\n\tthrow v409;\n\tv446 = new System.NullReferenceException();\nL_0106:\n\tv459 = new System.ArrayTypeMismatchException();\n\tthrow v459;\n\tgoto L_0115;\nL_0115:\n\tif (1) goto L_011F;\n\tv566 = UnityEngine.AndroidJavaObject::CallStatic(v469, 0, 0, v280);\n\tv502 = v566.m_value;\n\tv494 = UnityEngine.AndroidJavaObject::CallStatic(v566, 0, 0, v280);\n\tv596 = v334 == 0;\n\tv496 = ~v596;\n\tif (v496) goto L_0077;\n\tgoto L_00E5;\nL_011F:\n\treturnVal3 = UnityEngine.AndroidJavaObject::CallStatic(v469, 0, 0, v280);\n\treturn returnVal3;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackInviteEvent(IDictionary<string, string> eventParams = null)
		{
			if (eventParams != null && eventParams.Count != 0)
			{
				AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringMap(eventParams);
				object[] array = new object[1];
				if (androidJavaObject != null)
				{
					object obj = androidJavaObject as object;
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				if (array.Length != 0)
				{
					array[0] = androidJavaObject;
					bool flag = _trackerClass.CallStatic<bool>("trackInviteEvent", array);
					bool flag2 = androidJavaObject == null;
					int num = 0;
					bool result = flag;
					bool flag3 = false;
					if (!flag2)
					{
						((IDisposable)androidJavaObject).Dispose();
						num = 0;
						result = flag;
						flag3 = false;
					}
					if (num + 1 != 0 || !flag3)
					{
						return result;
					}
					TypeLoadException ex2 = new TypeLoadException();
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerClass.CallStatic<bool>("trackInviteEvent", Array.Empty<object>());
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x161D668", Offset = "0x161D668", Length = "0x588")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = &v15 @ X29;\n\t*([v15 @ X29-38]) = v104;\n\tgoto L_001C;\n\tv31 = *([1EBECD0]);\n\tv32 = *([v31 @ X8_v86]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, level, eventParams, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202A2D8]) = v49;\nL_001C:\n\tv50 = &v51 @ stack_-70;\n\tv53 = v104 & 0xFF00000000;\n\tv54 = v53 == 0;\n\tif (v54) goto L_00A4;\nL_0023:\n\tv124 = v187 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0030;\n\tv183 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v183);\nL_0030:\n\tv192 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(v187);\n\t// 56 NewArr v238 @ X0_v9 (System.Object[]), typeof(System.Object[]), 2\n\tv287 = &v15 @ X29 - 0x38;\n\tv288 = System.Nullable`1<System.Int32>::get_Value(v287);\n\t*([v15 @ X29-44]) = v288;\n\tv307 = &v15 @ X29 - 0x44;\n\t// 69 Box v309 @ X0_v13, typeof(System.Int32), v307 @ X1_v7\n\tv435 = v309 == 0;\n\tif (v435) goto L_0051;\n\t// 78 IsInst v556 @ X0_v32, typeof(System.Object), v309 @ X0_v13\n\tv560 = v556 == 0;\n\tif (v560) goto L_01E2;\nL_0051:\n\tv780 = v238.Length;\n\tv563 = v238.Length == 0;\n\tif (v563) goto L_01D8;\n\tv238[0] = v309;\n\tv625 = v192 == 0;\n\tif (v625) goto L_005E;\n\t// 90 IsInst v775 @ X0_v30, typeof(System.Object), v192 @ X0_v7 (UnityEngine.AndroidJavaObject)\n\tv779 = v775 == 0;\n\tif (v779) goto L_01E6;\n\tv780 = v238.Length;\nL_005E:\n\tv782 = v780 < 1;\n\tv783 = ~v782;\n\tv784 = v780 - 1;\n\tv786 = v784 == 0;\n\tv791 = ~v783;\n\tv792 = v791 | v786;\n\tif (v792) goto L_01DC;\n\tv238[1] = v192;\n\tv861 = UnityEngine.AndroidJavaObject::CallStatic(v114._trackerClass, \"trackLevelEvent\", v238);\n\tv607 = v106 + 1;\n\t*([v50 @ X24_v1+v607 @ X23_v4 (System.Int32)*4]) = 0x9E;\n\tv874 = v192 == 0;\n\tif (v874) goto L_00D4;\nL_0084:\n\tgoto L_00D3;\n\tv1030 = *([v949 @ X8_v25+B0]);\n\tv1031 = 0;\n\tv1032 = v1030 + 8;\n\tv1034 = *([v1103 @ X11_v9-8]);\n\tv1109 = v1034 == v952;\n\tif (v1109) goto L_00CC;\n\tv1056 = v1104 + 1;\n\tv1132 = v1056 < v951;\n\tv1052 = ~v1132;\n\tv1054 = v1103 + 0x10;\n\tv1036 = ~v1052;\n\tif (v1036) goto L_FFFFFFFF;\n\tv1057 = v234;\n\tv1058 = 0;\n\tv1059 = 0x8909C4(v1057, v952, v1058, v601, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00D3;\nL_00A4:\n\tv57 = v97 == 0;\n\tif (v57) goto L_0158;\n\tgoto L_00FF;\n\tv193 = *([v127 @ X8_v71+B0]);\n\tv194 = 0;\n\tv195 = v193 + 8;\n\tv197 = *([v249 @ X11_v35-8]);\n\tv255 = v197 == v130;\n\tif (v255) goto L_00F8;\n\tv219 = v250 + 1;\n\tv289 = v219 < v129;\n\tv215 = ~v289;\n\tv217 = v249 + 0x10;\n\tv199 = ~v215;\n\tif (v199) goto L_FFFFFFFF;\n\tv220 = v21;\n\tv221 = 0;\n\tv222 = 0x8909C4(v220, v130, v221, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00FF;\nL_00CC:\n\tv1133 = *([v1103 @ X11_v9]);\n\tv1134 = v1133 << 4;\n\tv1135 = v949 + v1134;\n\tv1136 = v1135 + 0x130;\nL_00D3:\n\tSystem.IDisposable::Dispose(v192);\nL_00D4:\n\tv977 = v607 + 1;\n\tv584 = v977 == 0;\n\tif (v584) goto L_FFFFFFFF;\n\tgoto L_00F7;\n\tv583 = *([v50 @ X24_v1+v607 @ X23_v4 (System.Int32)*4]) == 0x9E;\n\tif (v583) goto L_00F7;\n\tgoto L_01D7;\n\tgoto L_01D7;\nL_00F7:\n\treturn v1116;\nL_00F8:\n\tv290 = *([v249 @ X11_v35]);\n\tv291 = v290 << 4;\n\tv292 = v127 + v291;\n\tv293 = v292 + 0x130;\nL_00FF:\n\tv165 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(v97);\n\tv167 = v165 == 0;\n\tif (v167) goto L_0158;\n\tv311 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(v97);\n\t// 267 NewArr v400 @ X0_v103 (System.Object[]), typeof(System.Object[]), 1\n\tv621 = v311 == 0;\n\tif (v621) goto L_0118;\n\t// 276 IsInst v686 @ X0_v108, typeof(System.Object), v311 @ X0_v101 (UnityEngine.AndroidJavaObject)\n\tv688 = v686 == 0;\n\tif (v688) goto L_01F4;\nL_0118:\n\tv545 = v400.Length == 0;\n\tif (v545) goto L_01EE;\n\tv400[0] = v311;\n\tv848 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackLevelEvent\", v400);\n\t*([v50 @ X24_v1]) = 0x9E;\n\tv871 = v311 == 0;\n\tif (v871) goto L_01A5;\nL_0133:\n\tgoto L_01A4;\n\tv978 = *([v907 @ X8_v50+B0]);\n\tv979 = 0;\n\tv980 = v978 + 8;\n\tv982 = *([v1071 @ X11_v27-8]);\n\tv1077 = v982 == v910;\n\tif (v1077) goto L_019D;\n\tv1004 = v1072 + 1;\n\tv1123 = v1004 < v909;\n\tv1000 = ~v1123;\n\tv1002 = v1071 + 0x10;\n\tv984 = ~v1000;\n\tif (v984) goto L_FFFFFFFF;\n\tv1005 = v901;\n\tv1006 = 0;\n\tv1007 = 0x8909C4(v1005, v910, v1006, v889, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_01A4;\nL_0158:\n\tv175 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0161;\n\tv223 = v175;\n\tv224 = 0x8907BC(v223, v162, v158, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv227 = *([v175 @ X20_v23 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0161:\n\tv228 = *([v175 @ X20_v23 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv229 = v228 == 0;\n\tif (v229) goto L_0182;\n\tv261 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_016E;\n\tv297 = v261;\n\tv298 = 0x8907BC(v297, v162, v158, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_016E:\n\tv299 = *([v261 @ X20_v27 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv271 = ~v299;\n\tif (v271) goto L_0182;\n\tgoto L_0182;\n\tv401 = v273;\n\tv402 = 0x8907BC(v401, v162, v158, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0182:\n\tgoto L_019B;\n\tv300 = v278;\n\tv301 = 0x8907BC(v300, v162, v158, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_019B:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackLevelEvent\", v317.Value);\n\treturn returnVal1;\nL_019D:\n\tv1124 = *([v1071 @ X11_v27]);\n\tv1125 = v1124 << 4;\n\tv1126 = v907 + v1125;\n\tv1127 = v1126 + 0x130;\nL_01A4:\n\tSystem.IDisposable::Dispose(v311);\nL_01A5:\n\tv942 = v106 + 1;\n\tv944 = v942 == 0;\n\tif (v944) goto L_01CE;\n\tv1018 = *([v50 @ X24_v1+v106 @ X23_v2 (System.Int32)*4]) != 0x9E;\n\tif (v1018) goto L_01CE;\n\tv1086 = v937 == 0;\n\tv1091 = ~v1086;\n\tgoto L_00F7;\nL_01CE:\n\tv113 = v123 == 0;\n\tif (v113) goto L_0023;\n\tgoto L_01D7;\n\tthrow System.NullReferenceException;\nL_01D7:\n\tv665 = new System.TypeLoadException();\nL_01D8:\n\tv678 = new System.IndexOutOfRangeException();\n\tthrow v678;\nL_01DC:\n\tv839 = new System.IndexOutOfRangeException();\n\tthrow v839;\n\tv758 = new System.NullReferenceException();\nL_01E2:\n\tv771 = new System.ArrayTypeMismatchException();\n\tthrow v771;\nL_01E6:\n\tv853 = new System.ArrayTypeMismatchException();\n\tthrow v853;\n\tthrow System.NullReferenceException;\n\tv434 = new System.NullReferenceException();\nL_01EE:\n\tv552 = new System.IndexOutOfRangeException();\n\tthrow v552;\n\tv718 = new System.NullReferenceException();\nL_01F4:\n\tv808 = new System.ArrayTypeMismatchException();\n\tthrow v808;\n\tgoto L_0203;\nL_0203:\n\tif (1) goto L_0223;\n\tv1029 = 0x6D2BC0(v849, 0, 0, v486, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv905 = *([v1029 @ X0_v41]);\n\tv897 = 0x6D2490(v1029, 0, 0, v486, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv1131 = v510 == 0;\n\tv899 = ~v1131;\n\tif (v899) goto L_0133;\n\tgoto L_01A5;\n\tgoto L_0211;\n\tgoto L_0211;\n\tgoto L_0211;\n\tgoto L_0211;\nL_0211:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0223;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0084;\n\tgoto L_00D4;\nL_0223:\n\treturnVal2 = 0x6D2380(v849, 0, 0, v486, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal2;\n// 321 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool TrackLevelEvent(int? level = null, IDictionary<string, string> eventParams = null)
		{
			//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c6: Expected I4, but got Unknown
			//IL_0079: Expected O, but got I
			//IL_009a: Expected O, but got I
			//IL_00a3: Expected I4, but got O
			//IL_003d: Expected O, but got I
			//IL_00fd: Expected O, but got I4
			//IL_050c: Expected O, but got I
			//IL_031d: Expected O, but got I4
			//IL_017f: Expected O, but got I4
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			int num2;
			Tracker tracker;
			IDictionary<string, string> dictionary;
			IDictionary<string, string> dictionary2 = default(IDictionary<string, string>);
			int? num = default(int?);
			if ((int)((_003F?)num & 0xFF00000000L) != 0)
			{
				num2 = -1;
				tracker = this;
				dictionary = dictionary2;
			}
			else
			{
				if (dictionary2 == null || dictionary2.Count == 0)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X20_v23 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X20_v27 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					return _trackerClass.CallStatic<bool>("trackLevelEvent", Array.Empty<object>());
				}
				AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringMap(dictionary2);
				object[] array = new object[1];
				if (androidJavaObject != null)
				{
					object obj4 = androidJavaObject as object;
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				array[0] = androidJavaObject;
				bool flag = _trackerClass.CallStatic<bool>("trackLevelEvent", array);
				obj2 = 158;
				bool flag2 = androidJavaObject == null;
				string text = "trackLevelEvent";
				num2 = 0;
				int num3 = (flag ? 1 : 0);
				tracker = this;
				dictionary = dictionary2;
				int num4 = 0;
				if (!flag2)
				{
					((IDisposable)androidJavaObject).Dispose();
					text = null;
					num2 = 0;
					num3 = (flag ? 1 : 0);
					tracker = this;
					dictionary = dictionary2;
					num4 = 0;
				}
				if (num2 + 1 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X24_v1+v106 @ X23_v2 (System.Int32)*4]");
					if ((IntPtr)0 == (IntPtr)158)
					{
						bool flag3 = num3 == 0;
						return !flag3;
					}
				}
				bool flag4 = num4 == 0;
				num = (int?)text;
				if (!flag4)
				{
					goto IL_0666;
				}
			}
			if (dictionary == null)
			{
				Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
				num = (int?)(object)0;
				dictionary = dictionary3;
			}
			AndroidJavaObject androidJavaObject2 = JavaHelper.CreateJavaStringMap(dictionary);
			object[] array2 = new object[2];
			int? num5 = (int?)(object)((long)(IntPtr)obj - 56L);
			int value = ((int?*)num5)->Value;
			object obj5 = (long)(IntPtr)obj - 68L;
			object obj6 = (int)obj5;
			if (obj6 != null)
			{
				object obj7 = obj6 as object;
				if (obj7 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			object obj8 = array2.Length;
			if (array2.Length == 0)
			{
				goto IL_0458;
			}
			array2[0] = obj6;
			if (androidJavaObject2 != null)
			{
				object obj9 = androidJavaObject2 as object;
				if (obj9 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
				obj8 = array2.Length;
			}
			bool flag5 = (long)(IntPtr)obj8 < 1L;
			bool flag6 = !flag5;
			object obj10 = (long)(IntPtr)obj8 - 1L;
			bool flag7 = obj10 == null;
			bool flag8 = !flag6;
			if (!(flag8 || flag7))
			{
				array2[1] = androidJavaObject2;
				bool flag9 = tracker._trackerClass.CallStatic<bool>("trackLevelEvent", array2);
				int num6 = num2 + 1;
				_ = 158;
				((IDisposable)androidJavaObject2)?.Dispose();
				if (num6 + 1 != 0)
				{
					return flag9;
				}
				bool flag10 = flag9;
				goto IL_0666;
			}
			IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
			throw ex5;
			IL_0458:
			IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
			throw ex6;
			IL_0666:
			TypeLoadException ex7 = new TypeLoadException();
			goto IL_0458;
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x161DBF0", Offset = "0x161DBF0", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EA8328]);\n\tv25 = *([v24 @ X8_v44]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventParams, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202A2D9]) = v43;\nL_0016:\n\tv44 = eventParams == 0;\n\tif (v44) goto L_009C;\n\tgoto L_0045;\n\tv113 = *([v46 @ X8_v30+B0]);\n\tv114 = 0;\n\tv115 = v113 + 8;\n\tv117 = *([v160 @ X11_v19-8]);\n\tv166 = v117 == v49;\n\tif (v166) goto L_003E;\n\tv139 = v161 + 1;\n\tv194 = v139 < v48;\n\tv135 = ~v194;\n\tv137 = v160 + 0x10;\n\tv119 = ~v135;\n\tif (v119) goto L_FFFFFFFF;\n\tv140 = v16;\n\tv141 = 0;\n\tv142 = 0x8909C4(v140, v49, v141, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0045;\nL_003E:\n\tv195 = *([v160 @ X11_v19]);\n\tv196 = v195 << 4;\n\tv197 = v46 + v196;\n\tv198 = v197 + 0x130;\nL_0045:\n\tv98 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(eventParams);\n\tv100 = v98 == 0;\n\tif (v100) goto L_009C;\n\tv210 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(eventParams);\n\t// 81 NewArr v239 @ X0_v55 (System.Object[]), typeof(System.Object[]), 1\n\tv380 = v210 == 0;\n\tif (v380) goto L_005E;\n\t// 90 IsInst v413 @ X0_v60, typeof(System.Object), v210 @ X0_v53 (UnityEngine.AndroidJavaObject)\n\tv415 = v413 == 0;\n\tif (v415) goto L_0106;\nL_005E:\n\tv403 = v239.Length == 0;\n\tif (v403) goto L_0100;\n\tv239[0] = v210;\n\tv468 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackLoginEvent\", v239);\n\tv473 = v210 == 0;\n\tif (v473) goto L_00E5;\nL_0077:\n\tgoto L_00E4;\n\tv535 = *([v504 @ X8_v26+B0]);\n\tv536 = 0;\n\tv537 = v535 + 8;\n\tv539 = *([v577 @ X11_v13-8]);\n\tv583 = v539 == v507;\n\tif (v583) goto L_00DD;\n\tv561 = v578 + 1;\n\tv588 = v561 < v506;\n\tv557 = ~v588;\n\tv559 = v577 + 0x10;\n\tv541 = ~v557;\n\tif (v541) goto L_FFFFFFFF;\n\tv562 = v497;\n\tv563 = 0;\n\tv564 = 0x8909C4(v562, v507, v563, v477, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00E4;\nL_009C:\n\tv108 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00A5;\n\tv143 = v108;\n\tv144 = UnityEngine.AndroidJavaObject::CallStatic(v143, v89, v57, v28);\n\tv147 = *([v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00A5:\n\tv148 = *([v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv149 = v148 == 0;\n\tif (v149) goto L_00C6;\n\tv172 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00B2;\n\tv202 = v172;\n\tv203 = UnityEngine.AndroidJavaObject::CallStatic(v202, v89, v57, v28);\nL_00B2:\n\tv204 = *([v172 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv182 = ~v204;\n\tif (v182) goto L_00C6;\n\tgoto L_00C6;\n\tv240 = v184;\n\tv241 = UnityEngine.AndroidJavaObject::CallStatic(v240, v89, v57, v28);\nL_00C6:\n\tgoto L_00DB;\n\tv205 = v189;\n\tv206 = UnityEngine.AndroidJavaObject::CallStatic(v205, v89, v57, v28);\nL_00DB:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackLoginEvent\", v216.Value);\n\treturn returnVal1;\nL_00DD:\n\tv589 = *([v577 @ X11_v13]);\n\tv590 = v589 << 4;\n\tv591 = v504 + v590;\n\tv592 = v591 + 0x130;\nL_00E4:\n\tSystem.IDisposable::Dispose(v210);\nL_00E5:\n\tv533 = v348 + 1;\n\tv303 = v533 == 0;\n\tv288 = ~v303;\n\tif (v288) goto L_00F7;\n\tv565 = ~v375;\n\tv368 = ~v565;\n\tif (v368) goto L_00FF;\nL_00F7:\n\treturn v372;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00FF:\n\tv379 = new System.TypeLoadException();\nL_0100:\n\tv409 = new System.IndexOutOfRangeException();\n\tthrow v409;\n\tv446 = new System.NullReferenceException();\nL_0106:\n\tv459 = new System.ArrayTypeMismatchException();\n\tthrow v459;\n\tgoto L_0115;\nL_0115:\n\tif (1) goto L_011F;\n\tv566 = UnityEngine.AndroidJavaObject::CallStatic(v469, 0, 0, v280);\n\tv502 = v566.m_value;\n\tv494 = UnityEngine.AndroidJavaObject::CallStatic(v566, 0, 0, v280);\n\tv596 = v334 == 0;\n\tv496 = ~v596;\n\tif (v496) goto L_0077;\n\tgoto L_00E5;\nL_011F:\n\treturnVal3 = UnityEngine.AndroidJavaObject::CallStatic(v469, 0, 0, v280);\n\treturn returnVal3;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackLoginEvent(IDictionary<string, string> eventParams = null)
		{
			if (eventParams != null && eventParams.Count != 0)
			{
				AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringMap(eventParams);
				object[] array = new object[1];
				if (androidJavaObject != null)
				{
					object obj = androidJavaObject as object;
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				if (array.Length != 0)
				{
					array[0] = androidJavaObject;
					bool flag = _trackerClass.CallStatic<bool>("trackLoginEvent", array);
					bool flag2 = androidJavaObject == null;
					int num = 0;
					bool result = flag;
					bool flag3 = false;
					if (!flag2)
					{
						((IDisposable)androidJavaObject).Dispose();
						num = 0;
						result = flag;
						flag3 = false;
					}
					if (num + 1 != 0 || !flag3)
					{
						return result;
					}
					TypeLoadException ex2 = new TypeLoadException();
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerClass.CallStatic<bool>("trackLoginEvent", Array.Empty<object>());
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x161DEE4", Offset = "0x161DEE4", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EE09B8]);\n\tv25 = *([v24 @ X8_v44]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventParams, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202A2DA]) = v43;\nL_0016:\n\tv44 = eventParams == 0;\n\tif (v44) goto L_009C;\n\tgoto L_0045;\n\tv113 = *([v46 @ X8_v30+B0]);\n\tv114 = 0;\n\tv115 = v113 + 8;\n\tv117 = *([v160 @ X11_v19-8]);\n\tv166 = v117 == v49;\n\tif (v166) goto L_003E;\n\tv139 = v161 + 1;\n\tv194 = v139 < v48;\n\tv135 = ~v194;\n\tv137 = v160 + 0x10;\n\tv119 = ~v135;\n\tif (v119) goto L_FFFFFFFF;\n\tv140 = v16;\n\tv141 = 0;\n\tv142 = 0x8909C4(v140, v49, v141, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0045;\nL_003E:\n\tv195 = *([v160 @ X11_v19]);\n\tv196 = v195 << 4;\n\tv197 = v46 + v196;\n\tv198 = v197 + 0x130;\nL_0045:\n\tv98 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(eventParams);\n\tv100 = v98 == 0;\n\tif (v100) goto L_009C;\n\tv210 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(eventParams);\n\t// 81 NewArr v239 @ X0_v55 (System.Object[]), typeof(System.Object[]), 1\n\tv380 = v210 == 0;\n\tif (v380) goto L_005E;\n\t// 90 IsInst v413 @ X0_v60, typeof(System.Object), v210 @ X0_v53 (UnityEngine.AndroidJavaObject)\n\tv415 = v413 == 0;\n\tif (v415) goto L_0106;\nL_005E:\n\tv403 = v239.Length == 0;\n\tif (v403) goto L_0100;\n\tv239[0] = v210;\n\tv468 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackRegistrationEvent\", v239);\n\tv473 = v210 == 0;\n\tif (v473) goto L_00E5;\nL_0077:\n\tgoto L_00E4;\n\tv535 = *([v504 @ X8_v26+B0]);\n\tv536 = 0;\n\tv537 = v535 + 8;\n\tv539 = *([v577 @ X11_v13-8]);\n\tv583 = v539 == v507;\n\tif (v583) goto L_00DD;\n\tv561 = v578 + 1;\n\tv588 = v561 < v506;\n\tv557 = ~v588;\n\tv559 = v577 + 0x10;\n\tv541 = ~v557;\n\tif (v541) goto L_FFFFFFFF;\n\tv562 = v497;\n\tv563 = 0;\n\tv564 = 0x8909C4(v562, v507, v563, v477, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00E4;\nL_009C:\n\tv108 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00A5;\n\tv143 = v108;\n\tv144 = UnityEngine.AndroidJavaObject::CallStatic(v143, v89, v57, v28);\n\tv147 = *([v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00A5:\n\tv148 = *([v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv149 = v148 == 0;\n\tif (v149) goto L_00C6;\n\tv172 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00B2;\n\tv202 = v172;\n\tv203 = UnityEngine.AndroidJavaObject::CallStatic(v202, v89, v57, v28);\nL_00B2:\n\tv204 = *([v172 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv182 = ~v204;\n\tif (v182) goto L_00C6;\n\tgoto L_00C6;\n\tv240 = v184;\n\tv241 = UnityEngine.AndroidJavaObject::CallStatic(v240, v89, v57, v28);\nL_00C6:\n\tgoto L_00DB;\n\tv205 = v189;\n\tv206 = UnityEngine.AndroidJavaObject::CallStatic(v205, v89, v57, v28);\nL_00DB:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackRegistrationEvent\", v216.Value);\n\treturn returnVal1;\nL_00DD:\n\tv589 = *([v577 @ X11_v13]);\n\tv590 = v589 << 4;\n\tv591 = v504 + v590;\n\tv592 = v591 + 0x130;\nL_00E4:\n\tSystem.IDisposable::Dispose(v210);\nL_00E5:\n\tv533 = v348 + 1;\n\tv303 = v533 == 0;\n\tv288 = ~v303;\n\tif (v288) goto L_00F7;\n\tv565 = ~v375;\n\tv368 = ~v565;\n\tif (v368) goto L_00FF;\nL_00F7:\n\treturn v372;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00FF:\n\tv379 = new System.TypeLoadException();\nL_0100:\n\tv409 = new System.IndexOutOfRangeException();\n\tthrow v409;\n\tv446 = new System.NullReferenceException();\nL_0106:\n\tv459 = new System.ArrayTypeMismatchException();\n\tthrow v459;\n\tgoto L_0115;\nL_0115:\n\tif (1) goto L_011F;\n\tv566 = UnityEngine.AndroidJavaObject::CallStatic(v469, 0, 0, v280);\n\tv502 = v566.m_value;\n\tv494 = UnityEngine.AndroidJavaObject::CallStatic(v566, 0, 0, v280);\n\tv596 = v334 == 0;\n\tv496 = ~v596;\n\tif (v496) goto L_0077;\n\tgoto L_00E5;\nL_011F:\n\treturnVal3 = UnityEngine.AndroidJavaObject::CallStatic(v469, 0, 0, v280);\n\treturn returnVal3;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackRegistrationEvent(IDictionary<string, string> eventParams = null)
		{
			if (eventParams != null && eventParams.Count != 0)
			{
				AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringMap(eventParams);
				object[] array = new object[1];
				if (androidJavaObject != null)
				{
					object obj = androidJavaObject as object;
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				if (array.Length != 0)
				{
					array[0] = androidJavaObject;
					bool flag = _trackerClass.CallStatic<bool>("trackRegistrationEvent", array);
					bool flag2 = androidJavaObject == null;
					int num = 0;
					bool result = flag;
					bool flag3 = false;
					if (!flag2)
					{
						((IDisposable)androidJavaObject).Dispose();
						num = 0;
						result = flag;
						flag3 = false;
					}
					if (num + 1 != 0 || !flag3)
					{
						return result;
					}
					TypeLoadException ex2 = new TypeLoadException();
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X20_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerClass.CallStatic<bool>("trackRegistrationEvent", Array.Empty<object>());
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x161E1D8", Offset = "0x161E1D8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECE7D8]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2DB]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"flush\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Flush()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerClass.CallStatic<bool>("flush", Array.Empty<object>());
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x161E2FC", Offset = "0x161E2FC", Length = "0x758")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = *([1F01FA8]);\n\tv39 = *([v38 @ X8_v94]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, skuDetails, purchaseData, dataSignature, eventParams, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202A2DC]) = v54;\nL_001D:\n\tv55 = &v56 @ stack_-60;\n\tv59 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaJsonObbject(skuDetails);\n\tv62 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaJsonObbject(purchaseData);\n\tv65 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(dataSignature);\n\tv67 = eventParams == 0;\n\tif (v67) goto L_00F1;\n\tgoto L_0057;\n\tv132 = *([v69 @ X8_v65+B0]);\n\tv133 = 0;\n\tv134 = v132 + 8;\n\tv136 = *([v174 @ X11_v58-8]);\n\tv180 = v136 == v72;\n\tif (v180) goto L_0050;\n\tv158 = v175 + 1;\n\tv238 = v158 < v71;\n\tv154 = ~v238;\n\tv156 = v174 + 0x10;\n\tv138 = ~v154;\n\tif (v138) goto L_FFFFFFFF;\n\tv159 = v24;\n\tv160 = 0;\n\tv161 = 0x8909C4(v159, v72, v160, dataSignature, eventParams, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0057;\nL_0050:\n\tv239 = *([v174 @ X11_v58]);\n\tv240 = v239 << 4;\n\tv241 = v69 + v240;\n\tv242 = v241 + 0x130;\nL_0057:\n\tv121 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(eventParams);\n\tv123 = v121 == 0;\n\tif (v123) goto L_00F1;\n\tv284 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(eventParams);\n\t// 98 NewArr v295 @ X0_v128 (System.Object[]), typeof(System.Object[]), 4\n\tv403 = v59 == 0;\n\tif (v403) goto L_006E;\n\t// 107 IsInst v532 @ X0_v149, typeof(System.Object), v59 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv536 = v532 == 0;\n\tif (v536) goto L_029F;\nL_006E:\n\tv1012 = v295.Length;\n\tv539 = v295.Length == 0;\n\tif (v539) goto L_027D;\n\tv295[0] = v59;\n\tv573 = purchaseData == 0;\n\tif (v573) goto L_007B;\n\t// 119 IsInst v646 @ X0_v147, typeof(System.Object), purchaseData @ X2 (System.String)\n\tv650 = v646 == 0;\n\tif (v650) goto L_02A3;\n\tv1012 = v295.Length;\nL_007B:\n\tv653 = v1012 < 1;\n\tv654 = ~v653;\n\tv655 = v1012 - 1;\n\tv657 = v655 == 0;\n\tv662 = ~v654;\n\tv663 = v662 | v657;\n\tif (v663) goto L_0281;\n\tv295[1] = purchaseData;\n\tv697 = v65 == 0;\n\tif (v697) goto L_0091;\n\t// 141 IsInst v813 @ X0_v145, typeof(System.Object), v65 @ X0_v7 (UnityEngine.AndroidJavaObject)\n\tv817 = v813 == 0;\n\tif (v817) goto L_02A7;\n\tv1012 = v295.Length;\nL_0091:\n\tv820 = v1012 < 2;\n\tv821 = ~v820;\n\tv822 = v1012 - 2;\n\tv824 = v822 == 0;\n\tv829 = ~v821;\n\tv830 = v829 | v824;\n\tif (v830) goto L_0285;\n\tv295[2] = v65;\n\tv941 = v284 == 0;\n\tif (v941) goto L_00A7;\n\t// 163 IsInst v1007 @ X0_v143, typeof(System.Object), v284 @ X0_v126 (UnityEngine.AndroidJavaObject)\n\tv1011 = v1007 == 0;\n\tif (v1011) goto L_02AB;\n\tv1012 = v295.Length;\nL_00A7:\n\tv1014 = v1012 < 3;\n\tv1015 = ~v1014;\n\tv1016 = v1012 - 3;\n\tv1018 = v1016 == 0;\n\tv1023 = ~v1015;\n\tv1024 = v1023 | v1018;\n\tif (v1024) goto L_0289;\n\tv295[3] = v284;\n\tv1224 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackPurchaseEvent\", v295);\n\tv770 = 0;\n\t*([v55 @ X26_v1]) = 0xA4;\n\tv1309 = v284 == 0;\n\tif (v1309) goto L_024C;\nL_00CC:\n\tgoto L_0246;\n\tv1492 = *([v1363 @ X8_v80+B0]);\n\tv1493 = 0;\n\tv1494 = v1492 + 8;\n\tv1496 = *([v1604 @ X11_v53-8]);\n\tv1610 = v1496 == v1366;\n\tif (v1610) goto L_023F;\n\tv1518 = v1605 + 1;\n\tv1679 = v1518 < v1365;\n\tv1514 = ~v1679;\n\tv1516 = v1604 + 0x10;\n\tv1498 = ~v1514;\n\tif (v1498) goto L_FFFFFFFF;\n\tv1519 = v289;\n\tv1520 = 0;\n\tv1521 = 0x8909C4(v1519, v1366, v1520, v705, eventParams, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0246;\nL_00F1:\n\t// 241 NewArr v131 @ X0_v110 (System.Object[]), typeof(System.Object[]), 3\n\tv185 = v59 == 0;\n\tif (v185) goto L_00FD;\n\t// 250 IsInst v249 @ X0_v121, typeof(System.Object), v59 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv253 = v249 == 0;\n\tif (v253) goto L_0293;\nL_00FD:\n\tv490 = v131.Length;\n\tv256 = v131.Length == 0;\n\tif (v256) goto L_026D;\n\tv131[0] = v59;\n\tv285 = purchaseData == 0;\n\tif (v285) goto L_010A;\n\t// 262 IsInst v350 @ X0_v119, typeof(System.Object), purchaseData @ X2 (System.String)\n\tv354 = v350 == 0;\n\tif (v354) goto L_0297;\n\tv490 = v131.Length;\nL_010A:\n\tv357 = v490 < 1;\n\tv358 = ~v357;\n\tv359 = v490 - 1;\n\tv361 = v359 == 0;\n\tv366 = ~v358;\n\tv367 = v366 | v361;\n\tif (v367) goto L_0271;\n\tv131[1] = purchaseData;\n\tv399 = v65 == 0;\n\tif (v399) goto L_0120;\n\t// 284 IsInst v485 @ X0_v117, typeof(System.Object), v65 @ X0_v7 (UnityEngine.AndroidJavaObject)\n\tv489 = v485 == 0;\n\tif (v489) goto L_029B;\n\tv490 = v131.Length;\nL_0120:\n\tv492 = v490 < 2;\n\tv493 = ~v492;\n\tv494 = v490 - 2;\n\tv496 = v494 == 0;\n\tv501 = ~v493;\n\tv502 = v501 | v496;\n\tif (v502) goto L_0275;\n\tv131[2] = v65;\n\tv611 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackPurchaseEvent\", v131);\n\t*([v55 @ X26_v1]) = 0xA4;\nL_013D:\n\tv783 = v881 == 0;\n\tif (v783) goto L_016D;\nL_0145:\n\tgoto L_016C;\n\tv945 = *([v885 @ X8_v46+B0]);\n\tv946 = 0;\n\tv947 = v945 + 8;\n\tv949 = *([v1061 @ X11_v44-8]);\n\tv1067 = v949 == v888;\n\tif (v1067) goto L_0165;\n\tv971 = v1062 + 1;\n\tv1152 = v971 < v887;\n\tv967 = ~v1152;\n\tv969 = v1061 + 0x10;\n\tv951 = ~v967;\n\tif (v951) goto L_FFFFFFFF;\n\tv972 = v881;\n\tv973 = 0;\n\tv974 = 0x8909C4(v972, v888, v973, v858, eventParams, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_016C;\nL_0165:\n\tv1153 = *([v1061 @ X11_v44]);\n\tv1154 = v1153 << 4;\n\tv1155 = v885 + v1154;\n\tv1156 = v1155 + 0x130;\nL_016C:\n\tSystem.IDisposable::Dispose(v881);\nL_016D:\n\tv933 = v1431 + 1;\n\tv935 = v933 == 0;\n\tif (v935) goto L_0181;\n\tv975 = v1432 == 0;\n\tif (v975) goto L_0185;\n\tv1077 = *([v55 @ X26_v1+v1431 @ X24_v29 (UnityEngine.AndroidJavaObject)*4]) == 0xA4;\n\tif (v1077) goto L_0185;\n\tgoto L_026A;\nL_0181:\n\tv976 = v1432 == 0;\n\tv977 = ~v976;\n\tif (v977) goto L_026A;\nL_0185:\n\tv1120 = v62 == 0;\n\tif (v1120) goto L_01B5;\n\tgoto L_01B4;\n\tv1252 = *([v1161 @ X8_v14+B0]);\n\tv1253 = 0;\n\tv1254 = v1252 + 8;\n\tv1256 = *([v1325 @ X11_v9-8]);\n\tv1331 = v1256 == v1164;\n\tif (v1331) goto L_01AD;\n\tv1278 = v1326 + 1;\n\tv1392 = v1278 < v1163;\n\tv1274 = ~v1392;\n\tv1276 = v1325 + 0x10;\n\tv1258 = ~v1274;\n\tif (v1258) goto L_FFFFFFFF;\n\tv1279 = v63;\n\tv1280 = 0;\n\tv1281 = 0x8909C4(v1279, v1164, v1280, v1083, eventParams, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01B4;\nL_01AD:\n\tv1393 = *([v1325 @ X11_v9]);\n\tv1394 = v1393 << 4;\n\tv1395 = v1161 + v1394;\n\tv1396 = v1395 + 0x130;\nL_01B4:\n\tSystem.IDisposable::Dispose(v62);\nL_01B5:\n\tv1198 = v1431 + 1;\n\tv1200 = v1198 == 0;\n\tif (v1200) goto L_01DC;\n\tv1286 = v1084 == 0;\n\tv1291 = ~v1286;\n\tv1293 = v1432 == 0;\n\tif (v1293) goto L_01D4;\n\tv1346 = *([v55 @ X26_v1+v1431 @ X24_v29 (UnityEngine.AndroidJavaObject)*4]) != 0xA4;\n\tif (v1346) goto L_0266;\nL_01D4:\n\tv1357 = v59 == 0;\n\tv1358 = ~v1357;\n\tif (v1358) goto L_01EF;\n\tgoto L_0217;\nL_01DC:\n\tv1298 = v1084 == 0;\n\tv1303 = ~v1298;\n\tv1305 = v1432 == 0;\n\tv1306 = ~v1305;\n\tif (v1306) goto L_0266;\n\tv1360 = v59 == 0;\n\tif (v1360) goto L_0217;\nL_01EF:\n\tgoto L_0216;\n\tv1523 = *([v1438 @ X8_v41+B0]);\n\tv1524 = 0;\n\tv1525 = v1523 + 8;\n\tv1527 = *([v1627 @ X11_v37-8]);\n\tv1633 = v1527 == v1441;\n\tif (v1633) goto L_020F;\n\tv1549 = v1628 + 1;\n\tv1687 = v1549 < v1440;\n\tv1545 = ~v1687;\n\tv1547 = v1627 + 0x10;\n\tv1529 = ~v1545;\n\tif (v1529) goto L_FFFFFFFF;\n\tv1550 = v60;\n\tv1551 = 0;\n\tv1552 = 0x8909C4(v1550, v1441, v1551, v1401, eventParams, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0216;\nL_020F:\n\tv1688 = *([v1627 @ X11_v37]);\n\tv1689 = v1688 << 4;\n\tv1690 = v1438 + v1689;\n\tv1691 = v1690 + 0x130;\nL_0216:\n\tSystem.IDisposable::Dispose(v59);\nL_0217:\n\tv1486 = v1480 + 1;\n\tv1488 = v1486 == 0;\n\tif (v1488) goto L_022E;\n\tv1553 = v1481 == 0;\n\tif (v1553) goto L_023E;\n\tv1643 = *([v55 @ X26_v1+v1480 @ X24_v3 (UnityEngine.AndroidJavaObject)*4]) == 0xA4;\n\tif (v1643) goto L_023E;\nL_022D:\n\tthrow System.TypeLoadException;\nL_022E:\n\tv1580 = v1481 == 0;\n\tv1581 = ~v1580;\n\tif (v1581) goto L_022D;\nL_023E:\n\treturn v1482;\nL_023F:\n\tv1680 = *([v1604 @ X11_v53]);\n\tv1681 = v1680 << 4;\n\tv1682 = v1363 + v1681;\n\tv1683 = v1682 + 0x130;\nL_0246:\n\tSystem.IDisposable::Dispose(v284);\nL_024C:\n\tgoto L_FFFFFFFF;\n\tgoto L_013D;\n\tv737 = *([v55 @ X\n// ... truncated")]
		public bool TrackPurchaseEvent(string skuDetails, string purchaseData, string dataSignature, IDictionary<string, string> eventParams = null)
		{
			//IL_02b3: Expected O, but got I4
			//IL_09b3: Expected O, but got I
			//IL_0099: Expected O, but got I4
			//IL_0a11: Expected O, but got I
			//IL_0335: Expected O, but got I4
			//IL_0886: Expected O, but got I
			//IL_03da: Expected O, but got I4
			//IL_039d: Expected O, but got I4
			//IL_08e4: Expected O, but got I
			//IL_011b: Expected O, but got I4
			//IL_0a55: Expected O, but got I
			//IL_0942: Expected O, but got I
			//IL_0183: Expected O, but got I4
			//IL_047e: Expected O, but got I8
			//IL_0b59: Expected O, but got I
			//IL_022d: Expected O, but got I4
			//IL_01eb: Expected O, but got I4
			//IL_0592: Expected O, but got I8
			//IL_05a7: Expected O, but got I8
			//IL_0ad2: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaJsonObbject(skuDetails);
			AndroidJavaObject androidJavaObject2 = JavaHelper.CreateJavaJsonObbject(purchaseData);
			AndroidJavaObject androidJavaObject3 = JavaHelper.CreateJavaString(dataSignature);
			int num;
			AndroidJavaObject androidJavaObject6;
			int num2;
			AndroidJavaObject androidJavaObject7;
			if (eventParams != null && eventParams.Count != 0)
			{
				AndroidJavaObject androidJavaObject4 = JavaHelper.CreateJavaStringMap(eventParams);
				object[] array = new object[4];
				if (androidJavaObject != null)
				{
					object obj3 = androidJavaObject as object;
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				object obj4 = array.Length;
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				array[0] = androidJavaObject;
				if (purchaseData != null)
				{
					object obj5 = purchaseData as object;
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
					obj4 = array.Length;
				}
				bool flag = (long)(IntPtr)obj4 < 1L;
				bool flag2 = !flag;
				object obj6 = (long)(IntPtr)obj4 - 1L;
				bool flag3 = obj6 == null;
				bool flag4 = !flag2;
				if (flag4 || flag3)
				{
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				array[1] = purchaseData;
				if (androidJavaObject3 != null)
				{
					object obj7 = androidJavaObject3 as object;
					if (obj7 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
					obj4 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj4 < 2L;
				bool flag6 = !flag5;
				object obj8 = (long)(IntPtr)obj4 - 2L;
				bool flag7 = obj8 == null;
				bool flag8 = !flag6;
				if (flag8 || flag7)
				{
					IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
					throw ex6;
				}
				array[2] = androidJavaObject3;
				if (androidJavaObject4 != null)
				{
					object obj9 = androidJavaObject4 as object;
					if (obj9 == null)
					{
						ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
						throw ex7;
					}
					obj4 = array.Length;
				}
				bool flag9 = (long)(IntPtr)obj4 < 3L;
				bool flag10 = !flag9;
				object obj10 = (long)(IntPtr)obj4 - 3L;
				bool flag11 = obj10 == null;
				bool flag12 = !flag10;
				if (flag12 || flag11)
				{
					IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
					throw ex8;
				}
				array[3] = androidJavaObject4;
				bool flag13 = _trackerClass.CallStatic<bool>("trackPurchaseEvent", array);
				AndroidJavaObject androidJavaObject5 = null;
				obj = 164;
				((IDisposable)androidJavaObject4)?.Dispose();
				num = (flag13 ? 1 : 0);
				androidJavaObject6 = null;
				num2 = 0;
				androidJavaObject7 = androidJavaObject3;
			}
			else
			{
				object[] array2 = new object[3];
				if (androidJavaObject != null)
				{
					object obj11 = androidJavaObject as object;
					if (obj11 == null)
					{
						ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
						throw ex9;
					}
				}
				object obj12 = array2.Length;
				if (array2.Length == 0)
				{
					IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
					throw ex10;
				}
				array2[0] = androidJavaObject;
				if (purchaseData != null)
				{
					object obj13 = purchaseData as object;
					if (obj13 == null)
					{
						ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
						throw ex11;
					}
					obj12 = array2.Length;
				}
				bool flag14 = (long)(IntPtr)obj12 < 1L;
				bool flag15 = !flag14;
				object obj14 = (long)(IntPtr)obj12 - 1L;
				bool flag16 = obj14 == null;
				bool flag17 = !flag15;
				if (flag17 || flag16)
				{
					IndexOutOfRangeException ex12 = new IndexOutOfRangeException();
					throw ex12;
				}
				array2[1] = purchaseData;
				if (androidJavaObject3 != null)
				{
					object obj15 = androidJavaObject3 as object;
					if (obj15 == null)
					{
						ArrayTypeMismatchException ex13 = new ArrayTypeMismatchException();
						throw ex13;
					}
					obj12 = array2.Length;
				}
				bool flag18 = (long)(IntPtr)obj12 < 2L;
				bool flag19 = !flag18;
				object obj16 = (long)(IntPtr)obj12 - 2L;
				bool flag20 = obj16 == null;
				bool flag21 = !flag19;
				if (flag21 || flag20)
				{
					IndexOutOfRangeException ex14 = new IndexOutOfRangeException();
					throw ex14;
				}
				array2[2] = androidJavaObject3;
				bool flag22 = _trackerClass.CallStatic<bool>("trackPurchaseEvent", array2);
				obj = 164;
				num = (flag22 ? 1 : 0);
				androidJavaObject6 = null;
				num2 = 0;
				androidJavaObject7 = androidJavaObject3;
			}
			bool flag23 = androidJavaObject7 == null;
			int num3 = num;
			AndroidJavaObject androidJavaObject8 = androidJavaObject6;
			int num4 = num2;
			if (!flag23)
			{
				((IDisposable)androidJavaObject7).Dispose();
				num3 = num;
				androidJavaObject8 = androidJavaObject6;
				num4 = num2;
			}
			object obj17 = (long)(IntPtr)androidJavaObject8 + 1L;
			if (obj17 != null)
			{
				if (num4 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v1431 @ X24_v29 (UnityEngine.AndroidJavaObject)*4]");
					if ((IntPtr)0 != (IntPtr)164)
					{
						goto IL_0726;
					}
				}
			}
			else
			{
				if (num4 != 0)
				{
					goto IL_0726;
				}
				androidJavaObject8 = (AndroidJavaObject)4294967295L;
			}
			((IDisposable)androidJavaObject2)?.Dispose();
			object obj18 = (long)(IntPtr)androidJavaObject8 + 1L;
			bool flag28;
			AndroidJavaObject androidJavaObject9;
			int num5;
			bool result;
			if (obj18 != null)
			{
				bool flag24 = num3 == 0;
				bool flag25 = !flag24;
				if (num4 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v1431 @ X24_v29 (UnityEngine.AndroidJavaObject)*4]");
					if ((IntPtr)0 != (IntPtr)164)
					{
						goto IL_0720;
					}
				}
				bool flag26 = androidJavaObject == null;
				bool flag27 = !flag26;
				flag28 = flag25;
				if (!flag27)
				{
					androidJavaObject9 = androidJavaObject8;
					num5 = num4;
					result = flag25;
					goto IL_0ac3;
				}
			}
			else
			{
				bool flag29 = num3 == 0;
				bool flag30 = !flag29;
				if (num4 != 0)
				{
					goto IL_0720;
				}
				bool flag31 = androidJavaObject == null;
				androidJavaObject8 = (AndroidJavaObject)4294967295L;
				flag28 = flag30;
				androidJavaObject9 = (AndroidJavaObject)4294967295L;
				num5 = num4;
				result = flag30;
				if (flag31)
				{
					goto IL_0ac3;
				}
			}
			((IDisposable)androidJavaObject).Dispose();
			androidJavaObject9 = androidJavaObject8;
			num5 = num4;
			result = flag28;
			goto IL_0ac3;
			IL_060c:
			throw new TypeLoadException();
			IL_0ac3:
			object obj19 = (long)(IntPtr)androidJavaObject9 + 1L;
			if (obj19 != null)
			{
				if (num5 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v1480 @ X24_v3 (UnityEngine.AndroidJavaObject)*4]");
					if ((IntPtr)0 != (IntPtr)164)
					{
						goto IL_060c;
					}
				}
			}
			else if (num5 != 0)
			{
				goto IL_060c;
			}
			return result;
			IL_0720:
			throw new TypeLoadException();
			IL_0726:
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x161EA54", Offset = "0x161EA54", Length = "0x9E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = &v19 @ X29;\n\tgoto L_001D;\n\tv35 = *([1F01E80]);\n\tv36 = *([v35 @ X8_v142]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, product, eventParams, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202A2DD]) = v53;\nL_001D:\n\tv54 = &v55 @ stack_-90;\n\t*([v19 @ X29-60]) = 0;\n\t*([v19 @ X29-58]) = 0;\n\tv57 = product == 0;\n\tif (v57) goto L_FFFFFFFF;\n\tv59 = product.<receipt>k__BackingField == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv64 = UnityEngine.Purchasing.MiniJson::JsonDecode(product.<receipt>k__BackingField);\n\tgoto L_FFFFFFFF;\n\tv324 = v324_asT == 0;\n\tif (v324) goto L_0367;\n\tgoto L_FFFFFFFF;\n\tv331 = v331_asT == 0;\n\tif (v331) goto L_0367;\n\tv370 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v64, \"Payload\");\n\tv372 = v370 == 0;\n\tif (v372) goto L_0080;\n\tv332 = *([v370 @ X0_v123 (System.String)]) != System.String;\n\tif (v332) goto L_0367;\nL_0080:\n\tv301 = UnityEngine.Purchasing.MiniJson::JsonDecode(v370);\n\tgoto L_FFFFFFFF;\n\tv591 = v591_asT == 0;\n\tif (v591) goto L_036B;\n\tv660 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v301, \"json\");\n\tv662 = v660 == 0;\n\tif (v662) goto L_00BD;\n\tv638 = *([v660 @ X0_v126 (System.String)]) != System.String;\n\tif (v638) goto L_0376;\nL_00BD:\n\tv620 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v301, \"signature\");\n\tv621 = v620 == 0;\n\tif (v621) goto L_00D1;\n\tv592 = *([v620 @ X0_v128 (System.String)]) != System.String;\n\tif (v592) goto L_036B;\nL_00D1:\n\tv500 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v500);\n\tv508 = product.<metadata>k__BackingField;\n\tv1064 = &v19 @ X29 - 0x70;\n\t*([v19 @ X29-70]) = 0;\n\t*([v19 @ X29-68]) = 0;\n\tv1067 = 0xEA3B2C(v1064, 0xF4240, 0, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00F4;\n\tv1120 = *([v1113 @ X0_v133+E0]);\n\tv1121 = v1120 == 0;\n\tv1122 = ~v1121;\n\tif (v1122) goto L_00F4;\n\tv1124 = \"il2cpp_codegen_runtime_class_init\"(v1113, v1065, v1066, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00F4:\n\tv1130 = System.Decimal::op_Multiply(v508.<localizedPrice>k__BackingField, v508.<localizedPrice>k__BackingField.lo);\n\t*([v19 @ X29-60]) = v1130;\n\t*([v19 @ X29-58]) = v508.<localizedPrice>k__BackingField.lo;\n\tgoto L_0105;\n\tv1183 = *([v1176 @ X0_v137 (Il2CppClass<System.Globalization.CultureInfo>)+E0]);\n\tv1184 = v1183 == 0;\n\tv1185 = ~v1184;\n\tif (v1185) goto L_0105;\n\tv1187 = \"il2cpp_codegen_runtime_class_init\"(v1176, v1129, v1127, v456, v454, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0105:\n\tv1190 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1223 = &v19 @ X29 - 0x60;\n\tv501 = 0xEA4640(v1223, v1190, 0, *([v19 @ X29-68]), 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v500, \"price_amount_micros\", v501);\n\tv510 = product.<metadata>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v500, \"price_currency_code\", v510.<isoCurrencyCode>k__BackingField);\n\tv1381 = UnityEngine.Purchasing.MiniJson::JsonEncode(v500);\n\tv1416 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaJsonObbject(v1381);\n\tv1421 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaJsonObbject(v660);\n\tv1457 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(v620);\n\tv1461 = eventParams == 0;\n\tif (v1461) goto L_0203;\n\tgoto L_0169;\n\tv1515 = *([v1497 @ X8_v113+B0]);\n\tv1516 = 0;\n\tv1517 = v1515 + 8;\n\tv1519 = *([v1580 @ X11_v62-8]);\n\tv1595 = v1519 == v1500;\n\tif (v1595) goto L_0162;\n\tv1541 = v1590 + 1;\n\tv1604 = v1541 < v1499;\n\tv1539 = ~v1604;\n\tv1521 = v1580 + 0x10;\n\tv1523 = ~v1539;\n\tif (v1523) goto L_FFFFFFFF;\n\tv1542 = v25;\n\tv1543 = 0;\n\tv1544 = 0x8909C4(v1542, v1500, v1543, v681, v454, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0169;\nL_0161:\n\treturn v77;\nL_0162:\n\tv1605 = *([v1580 @ X11_v62]);\n\tv1606 = v1605 << 4;\n\tv1607 = v1497 + v1606;\n\tv1608 = v1607 + 0x130;\nL_0169:\n\tv1505 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(eventParams);\n\tv1507 = v1505 == 0;\n\tif (v1507) goto L_0203;\n\tv1634 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(eventParams);\n\t// 372 NewArr v959 @ X0_v172 (System.Object[]), typeof(System.Object[]), 4\n\tv1654 = v1416 == 0;\n\tif (v1654) goto L_0180;\n\t// 381 IsInst v1446 @ X0_v188, typeof(System.Object), v1416 @ X0_v147 (UnityEngine.AndroidJavaObject)\n\tv1448 = v1446 == 0;\n\tif (v1448) goto L_03AB;\nL_0180:\n\tv1171 = v959.Length;\n\tv998 = v959.Length == 0;\n\tif (v998) goto L_0389;\n\tv959[0] = v1416;\n\tv1687 = v1421 == 0;\n\tif (v1687) goto L_018D;\n\t// 393 IsInst v1486 @ X0_v186, typeof(System.Object), v1421 @ X0_v149 (UnityEngine.AndroidJavaObject)\n\tv1488 = v1486 == 0;\n\tif (v1488) goto L_03AF;\n\tv1171 = v959.Length;\nL_018D:\n\tv1702 = v1171 < 1;\n\tv1044 = ~v1702;\n\tv1042 = v1171 - 1;\n\tv1038 = v1042 == 0;\n\tv1703 = ~v1044;\n\tv1028 = v1703 | v1038;\n\tif (v1028) goto L_038D;\n\tv959[1] = v1421;\n\tv1740 = v1457 == 0;\n\tif (v1740) goto L_01A3;\n\t// 415 IsInst v1569 @ X0_v184, typeof(System.Object), v1457 @ X0_v151 (UnityEngine.AndroidJavaObject)\n\tv1571 = v1569 == 0;\n\tif (v1571) goto L_03B3;\n\tv1171 = v959.Length;\nL_01A3:\n\tv1828 = v1171 < 2;\n\tv1095 = ~v1828;\n\tv1093 = v1171 - 2;\n\tv1089 = v1093 == 0;\n\tv1829 = ~v1095;\n\tv1079 = v1829 | v1089;\n\tif (v1079) goto L_0391;\n\tv959[2] = v1457;\n\tv1948 = v1634 == 0;\n\tif (v1948) goto L_01B9;\n\t// 437 IsInst v1629 @ X0_v182, typeof(System.Object), v1634 @ X0_v170 (UnityEngine.AndroidJavaObject)\n\tv1630 = v1629 == 0;\n\tif (v1630) goto L_03B7;\n\tv1171 = v959.Length;\nL_01B9:\n\tv2069 = v1171 < 3;\n\tv1158 = ~v2069;\n\tv1156 = v1171 - 3;\n\tv1152 = v1156 == 0;\n\tv2070 = ~v1158;\n\tv1142 = v2070 | v1152;\n\tif (v1142) goto L_0395;\n\tv959[3] = v1634;\n\tv2162 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackPurchaseEvent\", v959);\n\t*([v54 @ X27_v1]) = 0x157;\n\tv2216 = v1634 == 0;\n\tif (v2216) goto L_034B;\nL_01D9:\n\tv2209 = *([v1634 @ X0_v170 (UnityEngine.AndroidJavaObject)]);\n\tv2203 = *([v2209 @ X8_v126 (Il2CppClass<UnityEngine.AndroidJavaObject>)+126]) == 0;\n\tif (v2203) goto L_01FC;\n\tv2165 = *([v2209 @ X8_v126 (Il2CppClass<UnityEngine.AndroidJavaObject>)+B0]) + 8;\nL_01E7:\n\tv2188 = *([v2165 @ X11_v37 (System.Int32)-8]) == System.IDisposable;\n\tif (v2188) goto L_0344;\n\tv2198 = v2198 + 1;\n\tv2300 = v2198 < *([v2209 @ X8_v126 (Il2CppClass<UnityEngine.AndroidJavaObject>)+126]);\n\tv2284 = ~v2300;\n\tv70 = v2165 + 0x10;\n\tv2276 = ~v2284;\n\tif (v2276) goto L_01E7;\nL_01FC:\n\tv2252 = UnityEngine.AndroidJavaObject::CallStatic(v1634, System.IDisposable, 0);\n\tgoto L_0347;\nL_0203:\n\t// 515 NewArr v716 @ X0_v154 (System.Object[]), typeof(System.Object[]), 3\n\tv1600 = v1416 == 0;\n\tif (v1600) goto L_020F;\n\t// 524 IsInst v1321 @ X0_v165, typeof(System.Object), v1416 @ X0_v147 (UnityEngine.AndroidJavaObject)\n\tv1323 = v1321 == 0;\n\tif (v1323) goto L_039F;\nL_020F:\n\tv861 = v716.Length;\n\tv758 = v716.Length == 0;\n\tif (v758) goto L_0379;\n\tv716[0] = v1416;\n\tv1635 = v1421 == 0;\n\tif (v1635) goto L_021C;\n\t// 536 IsInst v1361 @ X0_v163, typeof(System.Object), v1421 @ X0_v149 (UnityEngine.AndroidJavaObject)\n\tv1363 = v1361 == 0;\n\tif (v1363) goto L_03A3;\n\tv861 = v716.Length;\nL_021C:\n\tv1641 = v861 < 1;\n\tv798 = ~v1641;\n\tv796 = v861 - 1;\n\tv792 = v796 == 0;\n\tv1642 = ~v798;\n\tv782 = v1642 | v792;\n\tif (v782) goto L_037D;\n\tv716[1] = v1421;\n\tv1643 = v1457 == 0;\n\tif (v1643) goto L_0232;\n\t// 558 IsInst v1406 @ X0_v161, typeof(System.Object), v1457 @ X0_v151 (UnityEngine.AndroidJavaObject)\n\tv1408 = v1406 == 0;\n\tif (v1408) goto L_03A7;\n\tv861 = v716.Length;\nL_0232:\n\tv1657 = v861 < 2;\n\tv848 = ~v1657;\n\tv846 = v861 - 2;\n\tv842 = v846 == 0;\n\tv1658 = ~v848;\n\tv832 = v1658 | v842;\n\tif (v832) goto L_0381;\n\tv716[2] = v1457;\n\tv1696 = UnityEngine.AndroidJavaObject::CallStatic(this._trackerClass, \"trackPurchaseEvent\", v716);\n\t*([v54 @ X27_v1]) = 0x157;\n// ... truncated")]
		public bool TrackPurchaseEvent(Product product, IDictionary<string, string> eventParams = null)
		{
			//IL_0220: Expected O, but got I
			//IL_0257: Expected O, but got I4
			//IL_028c: Expected O, but got I
			//IL_0f5e: Expected O, but got I
			//IL_0fbc: Expected O, but got I
			//IL_0d91: Expected O, but got I
			//IL_085b: Expected O, but got I4
			//IL_0864: Expected O, but got I4
			//IL_0def: Expected O, but got I
			//IL_1000: Expected O, but got I
			//IL_0e4d: Expected O, but got I
			//IL_0938: Expected O, but got I8
			//IL_1147: Expected O, but got I
			//IL_0545: Expected O, but got I4
			//IL_0566: Expected O, but got I4
			//IL_0e91: Expected O, but got I
			//IL_0a5d: Expected O, but got I8
			//IL_0a72: Expected O, but got I8
			//IL_05b9: Expected I, but got O
			//IL_10a1: Expected O, but got I
			//IL_068a: Expected O, but got I4
			//IL_0bc4: Expected O, but got I8
			//IL_0ed3: Expected O, but got I4
			//IL_0bdf: Expected O, but got I8
			//IL_0b18: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			AndroidJavaObject androidJavaObject;
			AndroidJavaObject androidJavaObject2;
			AndroidJavaObject androidJavaObject3;
			AndroidJavaObject androidJavaObject4;
			bool flag14;
			AndroidJavaObject androidJavaObject5;
			int num3;
			AndroidJavaObject androidJavaObject6;
			AndroidJavaObject androidJavaObject8;
			Dictionary<string, string> dictionary5;
			int num4;
			bool flag21;
			object obj15;
			IntPtr intPtr2;
			AndroidJavaObject androidJavaObject7;
			int num2;
			object[] array2;
			if (product != null && product.receipt != null)
			{
				object obj4 = MiniJson.JsonDecode(product.receipt);
				Dictionary<string, object> dictionary = obj4 as Dictionary<string, object>;
				if (dictionary != null)
				{
					Dictionary<string, object> dictionary2 = obj4 as Dictionary<string, object>;
					if (dictionary2 != null)
					{
						string text = (string)((Dictionary<string, object>)obj4).get_Item("Payload");
						if (text == null || (object)text.GetType() == typeof(string))
						{
							object obj5 = MiniJson.JsonDecode(text);
							Dictionary<string, object> dictionary3 = obj5 as Dictionary<string, object>;
							if (dictionary3 != null)
							{
								string text2 = (string)((Dictionary<string, object>)obj5).get_Item("json");
								if (text2 != null && (object)text2.GetType() != typeof(string))
								{
									throw new InvalidCastException();
								}
								string text3 = (string)((Dictionary<string, object>)obj5).get_Item("signature");
								if (text3 == null || (object)text3.GetType() == typeof(string))
								{
									Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
									ProductMetadata metadata = product.metadata;
									object obj6 = (long)(IntPtr)obj - 112L;
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EA3B2C (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0x38)");
									decimal num = metadata.localizedPrice * (decimal)metadata.localizedPrice.lo;
									_ = metadata.localizedPrice.lo;
									CultureInfo invariantCulture = CultureInfo.InvariantCulture;
									object obj7 = (long)(IntPtr)obj - 96L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EA4640 (inside System.Decimal::FCallDivide +0x178)");
									string value = default(string);
									dictionary4.Add("price_amount_micros", value);
									ProductMetadata metadata2 = product.metadata;
									dictionary4.Add("price_currency_code", metadata2.isoCurrencyCode);
									string value2 = MiniJson.JsonEncode(dictionary4);
									androidJavaObject = JavaHelper.CreateJavaJsonObbject(value2);
									androidJavaObject2 = JavaHelper.CreateJavaJsonObbject(text2);
									androidJavaObject3 = JavaHelper.CreateJavaString(text3);
									if (eventParams != null)
									{
										int count = eventParams.Count;
										bool flag = count == 0;
										num2 = 0;
										if (!flag)
										{
											androidJavaObject4 = JavaHelper.CreateJavaStringMap(eventParams);
											object[] array = new object[4];
											if (androidJavaObject != null)
											{
												object obj8 = androidJavaObject as object;
												if (obj8 == null)
												{
													ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
													throw ex;
												}
											}
											IntPtr intPtr = (IntPtr)array.Length;
											if (array.Length != 0)
											{
												array[0] = androidJavaObject;
												if (androidJavaObject2 != null)
												{
													object obj9 = androidJavaObject2 as object;
													if (obj9 == null)
													{
														ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
														throw ex2;
													}
													intPtr = (IntPtr)array.Length;
												}
												bool flag2 = (long)intPtr < 1L;
												bool flag3 = !flag2;
												object obj10 = (long)intPtr - 1L;
												bool flag4 = obj10 == null;
												bool flag5 = !flag3;
												if (!(flag5 || flag4))
												{
													array[1] = androidJavaObject2;
													if (androidJavaObject3 != null)
													{
														object obj11 = androidJavaObject3 as object;
														if (obj11 == null)
														{
															ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
															throw ex3;
														}
														intPtr = (IntPtr)array.Length;
													}
													bool flag6 = (long)intPtr < 2L;
													bool flag7 = !flag6;
													object obj12 = (long)intPtr - 2L;
													bool flag8 = obj12 == null;
													bool flag9 = !flag7;
													if (!(flag9 || flag8))
													{
														array[2] = androidJavaObject3;
														if (androidJavaObject4 != null)
														{
															object obj13 = androidJavaObject4 as object;
															if (obj13 == null)
															{
																ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
																throw ex4;
															}
															intPtr = (IntPtr)array.Length;
														}
														bool flag10 = (long)intPtr < 3L;
														bool flag11 = !flag10;
														object obj14 = (long)intPtr - 3L;
														bool flag12 = obj14 == null;
														bool flag13 = !flag11;
														if (!(flag13 || flag12))
														{
															array[3] = androidJavaObject4;
															flag14 = _trackerClass.CallStatic<bool>("trackPurchaseEvent", array);
															obj2 = 343;
															bool flag15 = androidJavaObject4 == null;
															num2 = 0;
															obj15 = 0;
															intPtr2 = (IntPtr)0;
															androidJavaObject5 = androidJavaObject3;
															dictionary5 = null;
															num3 = (flag14 ? 1 : 0);
															num4 = 0;
															androidJavaObject6 = androidJavaObject;
															androidJavaObject7 = androidJavaObject4;
															androidJavaObject8 = androidJavaObject2;
															if (flag15)
															{
																goto IL_0e82;
															}
															IntPtr intPtr3 = (IntPtr)androidJavaObject4;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2209 @ X8_v126 (Il2CppClass<UnityEngine.AndroidJavaObject>)+126]");
															bool flag16 = (IntPtr)0 == (IntPtr)0;
															num2 = 0;
															if (flag16)
															{
																goto IL_0669;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2209 @ X8_v126 (Il2CppClass<UnityEngine.AndroidJavaObject>)+B0]");
															int num5 = 8;
															int num6 = 0;
															while (true)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2165 @ X11_v37 (System.Int32)-8]");
																bool flag17 = (IntPtr)0 == (IntPtr)typeof(IDisposable);
																obj15 = 0;
																intPtr2 = (IntPtr)0;
																androidJavaObject5 = androidJavaObject3;
																dictionary5 = null;
																array2 = array;
																num3 = (flag14 ? 1 : 0);
																num4 = 0;
																androidJavaObject6 = androidJavaObject;
																androidJavaObject7 = androidJavaObject4;
																androidJavaObject8 = androidJavaObject2;
																if (flag17)
																{
																	break;
																}
																num6++;
																int num7 = num6;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2209 @ X8_v126 (Il2CppClass<UnityEngine.AndroidJavaObject>)+126]");
																bool flag18 = (long)num7 < 0L;
																bool flag19 = !flag18;
																num2 = num5 + 16;
																bool flag20 = !flag19;
																num5 = num2;
																if (flag20)
																{
																	continue;
																}
																goto IL_0669;
															}
															int num8 = num5 << 4;
															object obj16 = (long)intPtr3 + (long)num8;
															flag21 = (byte)((ulong)(long)(IntPtr)obj16 + 304uL) != 0;
															goto IL_0f25;
														}
														IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
														throw ex5;
													}
													IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
													throw ex6;
												}
												IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
												throw ex7;
											}
											IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
											throw ex8;
										}
									}
									object[] array3 = new object[3];
									if (androidJavaObject != null)
									{
										object obj17 = androidJavaObject as object;
										if (obj17 == null)
										{
											goto IL_0ca1;
										}
									}
									IntPtr intPtr4 = (IntPtr)array3.Length;
									if (array3.Length != 0)
									{
										array3[0] = androidJavaObject;
										if (androidJavaObject2 != null)
										{
											object obj18 = androidJavaObject2 as object;
											if (obj18 == null)
											{
												ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
												throw ex9;
											}
											intPtr4 = (IntPtr)array3.Length;
										}
										bool flag22 = (long)intPtr4 < 1L;
										bool flag23 = !flag22;
										object obj19 = (long)intPtr4 - 1L;
										bool flag24 = obj19 == null;
										bool flag25 = !flag23;
										if (!(flag25 || flag24))
										{
											array3[1] = androidJavaObject2;
											if (androidJavaObject3 != null)
											{
												object obj20 = androidJavaObject3 as object;
												if (obj20 == null)
												{
													ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
													throw ex10;
												}
												intPtr4 = (IntPtr)array3.Length;
											}
											bool flag26 = (long)intPtr4 < 2L;
											bool flag27 = !flag26;
											object obj21 = (long)intPtr4 - 2L;
											bool flag28 = obj21 == null;
											bool flag29 = !flag27;
											if (!(flag29 || flag28))
											{
												array3[2] = androidJavaObject3;
												bool flag30 = _trackerClass.CallStatic<bool>("trackPurchaseEvent", array3);
												obj2 = 343;
												obj15 = 0;
												intPtr2 = (IntPtr)0;
												androidJavaObject5 = androidJavaObject3;
												dictionary5 = null;
												num3 = (flag30 ? 1 : 0);
												num4 = 0;
												androidJavaObject6 = androidJavaObject;
												androidJavaObject7 = (AndroidJavaObject)(object)array3;
												androidJavaObject8 = androidJavaObject2;
												goto IL_10f3;
											}
											IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
											throw ex11;
										}
										IndexOutOfRangeException ex12 = new IndexOutOfRangeException();
										throw ex12;
									}
									IndexOutOfRangeException ex13 = new IndexOutOfRangeException();
									throw ex13;
								}
							}
							InvalidCastException ex14 = new InvalidCastException();
							throw new NullReferenceException();
						}
					}
				}
				throw new InvalidCastException();
			}
			bool result = false;
			goto IL_10ee;
			IL_101d:
			((IDisposable)androidJavaObject5).Dispose();
			num2 = 0;
			Dictionary<string, string> dictionary6 = dictionary5;
			int num9 = num3;
			int num10 = num4;
			AndroidJavaObject androidJavaObject9 = androidJavaObject6;
			AndroidJavaObject androidJavaObject10 = androidJavaObject8;
			goto IL_0ff1;
			IL_0c1f:
			throw new TypeLoadException();
			IL_1092:
			object obj22 = (long)(IntPtr)dictionary5 + 1L;
			if (obj22 != null)
			{
				if (num4 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v1747 @ X24_v37 (System.Collections.Generic.Dictionary`2<System.String, System.String>)*4]");
					if ((IntPtr)0 != (IntPtr)343)
					{
						goto IL_0af1;
					}
				}
			}
			else if (num4 != 0)
			{
				goto IL_0af1;
			}
			goto IL_10ee;
			IL_0e82:
			object obj23 = (long)(IntPtr)dictionary5 + 1L;
			if (obj23 == null)
			{
				if (num4 != 0)
				{
					goto IL_0c93;
				}
				bool flag31 = androidJavaObject5 == null;
				bool flag32 = !flag31;
				dictionary5 = (Dictionary<string, string>)4294967295L;
				if (flag32)
				{
					goto IL_101d;
				}
				dictionary6 = (Dictionary<string, string>)4294967295L;
				num9 = num3;
				num10 = num4;
				androidJavaObject9 = androidJavaObject6;
				androidJavaObject10 = androidJavaObject8;
				goto IL_0ff1;
			}
			if (num4 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v1747 @ X24_v37 (System.Collections.Generic.Dictionary`2<System.String, System.String>)*4]");
				if ((IntPtr)0 != (IntPtr)343)
				{
					goto IL_0c93;
				}
			}
			goto IL_10f3;
			IL_0f25:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2252.m_value (System.Boolean) (should have been resolved before IL gen)");
			goto IL_0e82;
			IL_10ee:
			return result;
			IL_0c93:
			TypeLoadException ex15 = new TypeLoadException();
			goto IL_0ca1;
			IL_0ca1:
			ArrayTypeMismatchException ex16 = new ArrayTypeMismatchException();
			throw ex16;
			IL_10f3:
			bool flag33 = androidJavaObject5 == null;
			dictionary6 = dictionary5;
			num9 = num3;
			num10 = num4;
			androidJavaObject9 = androidJavaObject6;
			androidJavaObject10 = androidJavaObject8;
			if (flag33)
			{
				goto IL_0ff1;
			}
			goto IL_101d;
			IL_0669:
			flag21 = androidJavaObject4.CallStatic<bool>((string)(object)typeof(IDisposable), (object[])null);
			obj15 = 0;
			intPtr2 = (IntPtr)0;
			androidJavaObject5 = androidJavaObject3;
			dictionary5 = null;
			array2 = null;
			num3 = (flag14 ? 1 : 0);
			num4 = 0;
			androidJavaObject6 = androidJavaObject;
			androidJavaObject7 = androidJavaObject4;
			androidJavaObject8 = androidJavaObject2;
			goto IL_0f25;
			IL_0ff1:
			object obj24 = (long)(IntPtr)dictionary6 + 1L;
			IntPtr intPtr5;
			if (obj24 != null)
			{
				bool flag34 = num10 == 0;
				intPtr5 = (IntPtr)num9;
				if (!flag34)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v1906 @ X24_v36 (System.Collections.Generic.Dictionary`2<System.String, System.String>)*4]");
					bool flag35 = (IntPtr)0 == (IntPtr)343;
					intPtr5 = (IntPtr)num9;
					if (!flag35)
					{
						goto IL_0c25;
					}
				}
			}
			else
			{
				if (num10 != 0)
				{
					goto IL_0c25;
				}
				dictionary6 = (Dictionary<string, string>)4294967295L;
				intPtr5 = (IntPtr)num9;
			}
			if (androidJavaObject10 != null)
			{
				((IDisposable)androidJavaObject10).Dispose();
				num2 = 0;
			}
			object obj25 = (long)(IntPtr)dictionary6 + 1L;
			bool flag40;
			if (obj25 != null)
			{
				bool flag36 = intPtr5 == (IntPtr)0;
				bool flag37 = !flag36;
				if (num10 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v1906 @ X24_v36 (System.Collections.Generic.Dictionary`2<System.String, System.String>)*4]");
					if ((IntPtr)0 != (IntPtr)343)
					{
						goto IL_0c1f;
					}
				}
				bool flag38 = androidJavaObject9 == null;
				bool flag39 = !flag38;
				flag40 = flag37;
				if (!flag39)
				{
					result = flag37;
					dictionary5 = dictionary6;
					num4 = num10;
					goto IL_1092;
				}
			}
			else
			{
				bool flag41 = intPtr5 == (IntPtr)0;
				bool flag42 = !flag41;
				if (num10 != 0)
				{
					goto IL_0c1f;
				}
				bool flag43 = androidJavaObject9 == null;
				flag40 = flag42;
				dictionary6 = (Dictionary<string, string>)4294967295L;
				result = flag42;
				dictionary5 = (Dictionary<string, string>)4294967295L;
				num4 = num10;
				if (flag43)
				{
					goto IL_1092;
				}
			}
			((IDisposable)androidJavaObject9).Dispose();
			num2 = 0;
			result = flag40;
			dictionary5 = dictionary6;
			num4 = num10;
			goto IL_1092;
			IL_0c25:
			throw new TypeLoadException();
			IL_0af1:
			array2 = null;
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x161F434", Offset = "0x161F434", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB6360]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A2DE]) = v37;\nL_0015:\n\tv41 = new Mycom.Tracker.Unity.Internal.Implementations.Android.Tracker();\n\tMycom.Tracker.Unity.Internal.Implementations.Android.Tracker::.ctor(v41);\n\tv44.Instance = v41;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Tracker()
		{
			Tracker instance = new Tracker();
			Instance = instance;
		}
	}
}
