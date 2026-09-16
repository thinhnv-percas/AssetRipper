using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000005")]
public class IosTenjin : BaseTenjin
{
	[Token(Token = "0x6000039")]
	[Address(RVA = "0x165FCB8", Offset = "0x165FCB8", Length = "0x84")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDF738]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, apiKey, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF59]) = v41;\nL_001B:\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, apiKey, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tUnityEngine.Debug::Log(\"iOS Initializing\");\n\tthis.apiKey = apiKey;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Init(string apiKey)
	{
		Debug.Log("iOS Initializing");
		ApiKey = apiKey;
	}

	[Token(Token = "0x600003A")]
	[Address(RVA = "0x165FD3C", Offset = "0x165FD3C", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ECDEB8]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, apiKey, sharedSecret, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AF5A]) = v44;\nL_001D:\n\tgoto L_0027;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, apiKey, sharedSecret, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0027:\n\tUnityEngine.Debug::Log(\"iOS Initializing with Shared Secret\");\n\tthis.apiKey = apiKey;\n\tthis.sharedSecret = sharedSecret;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void InitWithSharedSecret(string apiKey, string sharedSecret)
	{
		Debug.Log("iOS Initializing with Shared Secret");
		ApiKey = apiKey;
		SharedSecret = sharedSecret;
	}

	[Token(Token = "0x600003B")]
	[Address(RVA = "0x165FDC4", Offset = "0x165FDC4", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB1178]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, apiKey, appSubversion, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AF5B]) = v44;\nL_001D:\n\tgoto L_0027;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, apiKey, appSubversion, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0027:\n\tUnityEngine.Debug::Log(\"iOS Initializing with App Subversion\");\n\tthis.apiKey = apiKey;\n\tthis.appSubversion = appSubversion;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void InitWithAppSubversion(string apiKey, int appSubversion)
	{
		Debug.Log("iOS Initializing with App Subversion");
		ApiKey = apiKey;
		AppSubversion = appSubversion;
	}

	[Token(Token = "0x600003C")]
	[Address(RVA = "0x165FE50", Offset = "0x165FE50", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EB03C8]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, apiKey, sharedSecret, appSubversion, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202AF5C]) = v47;\nL_001F:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, apiKey, sharedSecret, appSubversion, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0029:\n\tUnityEngine.Debug::Log(\"iOS Initializing with Shared Secret + App Subversion\");\n\tthis.apiKey = apiKey;\n\tthis.sharedSecret = sharedSecret;\n\tthis.appSubversion = appSubversion;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void InitWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion)
	{
		Debug.Log("iOS Initializing with Shared Secret + App Subversion");
		ApiKey = apiKey;
		SharedSecret = sharedSecret;
		AppSubversion = appSubversion;
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0x165FEE8", Offset = "0x165FEE8", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF28C0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF5D]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"iOS Connecting\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Connect()
	{
		Debug.Log("iOS Connecting");
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0x165FF54", Offset = "0x165FF54", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAE408]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, deferredDeeplink, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF5E]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"Connecting with deferredDeeplink \", deferredDeeplink);\n\tgoto L_002E;\n\tv52 = *([v48 @ X8_v7+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002E;\n\tv65 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v65, v41, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002E:\n\tUnityEngine.Debug::Log(v44);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Connect(string deferredDeeplink)
	{
		string message = "Connecting with deferredDeeplink " + deferredDeeplink;
		Debug.Log(message);
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0x165FFDC", Offset = "0x165FFDC", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([202AF5F]) & 1;\n\tv15 = v14 == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0019;\n\tv19 = 0x1660FC0(this, eventName, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([202AF5F]) = X8;\nL_0019:\n\tv40 = System.String::Concat(\"iOS Sending Event \", eventName);\n\tgoto L_002F;\n\tv67 = *([v44 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_002F;\n\tv72 = v44;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v72, v37, v38, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\tUnityEngine.Debug::Log(v40);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SendEvent(string eventName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202AF5F]");
		if (0 == 0)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1660FC0 (inside Tenjin+DeferredDeeplinkDelegate::EndInvoke +0x10)");
			return;
		}
		string message = "iOS Sending Event " + eventName;
		Debug.Log(message);
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x1660064", Offset = "0x1660064", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F024D0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventName, eventValue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202AF60]) = v41;\nL_001E:\n\tv51 = System.String::Concat(\"iOS Sending Event \", eventName, \" : \", eventValue);\n\tgoto L_0035;\n\tv59 = *([v55 @ X8_v7+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0035;\n\tv73 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v73, v46, v49, v47, v50, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0035:\n\tUnityEngine.Debug::Log(v51);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SendEvent(string eventName, string eventValue)
	{
		string message = "iOS Sending Event " + eventName + " : " + eventValue;
		Debug.Log(message);
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0x1660108", Offset = "0x1660108", Length = "0x388")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv44 = *([1EB8E00]);\n\tv45 = *([v44 @ X8_v62]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, productId, currencyCode, quantity, transactionId, receipt, signature, methodInfo, unitPrice, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 0 | 1;\n\t*([202AF61]) = v58;\nL_0024:\n\t// 36 NewArr v63 @ X0_v3 (System.Object[]), typeof(System.Object[]), 14\n\tv69 = \"iOS Transaction \" == 0;\n\tif (v69) goto L_0032;\n\t// 47 IsInst v124 @ X0_v63, typeof(System.Object), \"iOS Transaction \"\nL_0032:\n\tv322 = v63.Length;\n\tv131 = v63.Length == 0;\n\tif (v131) goto L_018C;\n\tv63[0] = \"iOS Transaction \";\n\tv133 = productId == 0;\n\tif (v133) goto L_0040;\n\t// 60 IsInst v402 @ X0_v62, typeof(System.Object), productId @ X1 (System.String)\n\tv322 = v63.Length;\nL_0040:\n\tv448 = v322 < 1;\n\tv251 = ~v448;\n\tv237 = v322 - 1;\n\tv209 = v237 == 0;\n\tv449 = ~v251;\n\tv139 = v449 | v209;\n\tif (v139) goto L_018C;\n\tv63[1] = productId;\n\tv454 = \", \" == 0;\n\tif (v454) goto L_0058;\n\t// 84 IsInst v403 @ X0_v60, typeof(System.Object), \", \"\n\tv322 = v63.Length;\nL_0058:\n\tv456 = v322 < 2;\n\tv252 = ~v456;\n\tv238 = v322 - 2;\n\tv210 = v238 == 0;\n\tv457 = ~v252;\n\tv140 = v457 | v210;\n\tif (v140) goto L_018C;\n\tv63[2] = \", \";\n\tv458 = currencyCode == 0;\n\tif (v458) goto L_006F;\n\t// 107 IsInst v404 @ X0_v59, typeof(System.Object), currencyCode @ X2 (System.String)\n\tv322 = v63.Length;\nL_006F:\n\tv461 = v322 < 3;\n\tv253 = ~v461;\n\tv239 = v322 - 3;\n\tv211 = v239 == 0;\n\tv462 = ~v253;\n\tv141 = v462 | v211;\n\tif (v141) goto L_018C;\n\tv63[3] = currencyCode;\n\tv464 = \", \" == 0;\n\tif (v464) goto L_0085;\n\t// 129 IsInst v405 @ X0_v57, typeof(System.Object), \", \"\n\tv322 = v63.Length;\nL_0085:\n\tv466 = v322 < 4;\n\tv254 = ~v466;\n\tv240 = v322 - 4;\n\tv212 = v240 == 0;\n\tv467 = ~v254;\n\tv142 = v467 | v212;\n\tif (v142) goto L_018C;\n\tv63[4] = \", \";\n\t// 152 Box v473 @ X0_v21, typeof(System.Int32), &quantity @ X3 (System.Int32)\n\tv474 = v473 == 0;\n\tif (v474) goto L_00A2;\n\t// 159 IsInst v406 @ X0_v56, typeof(System.Object), v473 @ X0_v21\nL_00A2:\n\tv323 = v63.Length;\n\tv477 = v63.Length < 5;\n\tv249 = ~v477;\n\tv235 = v63.Length - 5;\n\tv207 = v235 == 0;\n\tv478 = ~v249;\n\tv137 = v478 | v207;\n\tif (v137) goto L_018C;\n\tv63[5] = v473;\n\tv480 = \", \" == 0;\n\tif (v480) goto L_00B9;\n\t// 181 IsInst v407 @ X0_v54, typeof(System.Object), \", \"\n\tv323 = v63.Length;\nL_00B9:\n\tv482 = v323 < 6;\n\tv255 = ~v482;\n\tv241 = v323 - 6;\n\tv213 = v241 == 0;\n\tv483 = ~v255;\n\tv143 = v483 | v213;\n\tif (v143) goto L_018C;\n\tv63[6] = \", \";\n\t// 204 Box v489 @ X0_v26, typeof(System.Double), &unitPrice @ V0 (System.Double)\n\tv490 = v489 == 0;\n\tif (v490) goto L_00D6;\n\t// 211 IsInst v408 @ X0_v53, typeof(System.Object), v489 @ X0_v26\nL_00D6:\n\tv329 = v63.Length;\n\tv493 = v63.Length < 7;\n\tv250 = ~v493;\n\tv236 = v63.Length - 7;\n\tv208 = v236 == 0;\n\tv494 = ~v250;\n\tv138 = v494 | v208;\n\tif (v138) goto L_018C;\n\tv63[7] = v489;\n\tv496 = \", \" == 0;\n\tif (v496) goto L_00ED;\n\t// 233 IsInst v409 @ X0_v51, typeof(System.Object), \", \"\n\tv329 = v63.Length;\nL_00ED:\n\tv498 = v329 < 8;\n\tv256 = ~v498;\n\tv242 = v329 - 8;\n\tv214 = v242 == 0;\n\tv499 = ~v256;\n\tv144 = v499 | v214;\n\tif (v144) goto L_018C;\n\tv63[8] = \", \";\n\tv500 = transactionId == 0;\n\tif (v500) goto L_0104;\n\t// 256 IsInst v410 @ X0_v50, typeof(System.Object), transactionId @ X4 (System.String)\n\tv329 = v63.Length;\nL_0104:\n\tv503 = v329 < 9;\n\tv257 = ~v503;\n\tv243 = v329 - 9;\n\tv215 = v243 == 0;\n\tv504 = ~v257;\n\tv145 = v504 | v215;\n\tif (v145) goto L_018C;\n\tv63[9] = transactionId;\n\tv506 = \", \" == 0;\n\tif (v506) goto L_011A;\n\t// 278 IsInst v411 @ X0_v48, typeof(System.Object), \", \"\n\tv329 = v63.Length;\nL_011A:\n\tv508 = v329 < 0xA;\n\tv258 = ~v508;\n\tv244 = v329 - 0xA;\n\tv216 = v244 == 0;\n\tv509 = ~v258;\n\tv146 = v509 | v216;\n\tif (v146) goto L_018C;\n\tv63[10] = \", \";\n\tv510 = receipt == 0;\n\tif (v510) goto L_0131;\n\t// 301 IsInst v412 @ X0_v47, typeof(System.Object), receipt @ X5 (System.String)\n\tv329 = v63.Length;\nL_0131:\n\tv513 = v329 < 0xB;\n\tv259 = ~v513;\n\tv245 = v329 - 0xB;\n\tv217 = v245 == 0;\n\tv514 = ~v259;\n\tv147 = v514 | v217;\n\tif (v147) goto L_018C;\n\tv63[11] = receipt;\n\tv516 = \", \" == 0;\n\tif (v516) goto L_0147;\n\t// 323 IsInst v413 @ X0_v45, typeof(System.Object), \", \"\n\tv329 = v63.Length;\nL_0147:\n\tv518 = v329 < 0xC;\n\tv260 = ~v518;\n\tv246 = v329 - 0xC;\n\tv218 = v246 == 0;\n\tv519 = ~v260;\n\tv148 = v519 | v218;\n\tif (v148) goto L_018C;\n\tv63[12] = \", \";\n\tv520 = signature == 0;\n\tif (v520) goto L_015E;\n\t// 346 IsInst v414 @ X0_v44, typeof(System.Object), signature @ X6 (System.String)\n\tv329 = v63.Length;\nL_015E:\n\tv523 = v329 < 0xD;\n\tv261 = ~v523;\n\tv247 = v329 - 0xD;\n\tv219 = v247 == 0;\n\tv524 = ~v261;\n\tv149 = v524 | v219;\n\tif (v149) goto L_018C;\n\tv63[13] = signature;\n\tv527 = System.String::Concat(v63);\n\tgoto L_017E;\n\tv534 = *([v370 @ X8_v34+E0]);\n\tv535 = v534 == 0;\n\tv536 = ~v535;\n\tif (v536) goto L_017E;\n\tv539 = v370;\n\tv538 = \"il2cpp_codegen_runtime_class_init\"(v539, v526, currencyCode, quantity, transactionId, receipt, signature, methodInfo, unitPrice, v48, v49, v50, v51, v52, v53, v54);\nL_017E:\n\tUnityEngine.Debug::Log(v527);\n\treturn;\nL_018C:\n\tv330 = new System.IndexOutOfRangeException();\n\tgoto L_0191;\n\tv445 = new System.ArrayTypeMismatchException();\nL_0191:\n\tthrow v451;\n\tthrow System.NullReferenceException;\n// 217 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Transaction(string productId, string currencyCode, int quantity, double unitPrice, string transactionId, string receipt, string signature)
	{
		//IL_0040: Expected O, but got I4
		//IL_05d1: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_062f: Expected O, but got I
		//IL_00fd: Expected O, but got I4
		//IL_068d: Expected O, but got I
		//IL_014e: Expected O, but got I4
		//IL_06eb: Expected O, but got I
		//IL_01a0: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_0749: Expected O, but got I
		//IL_02ac: Expected O, but got I4
		//IL_030a: Expected O, but got I4
		//IL_0336: Expected O, but got I4
		//IL_07a7: Expected O, but got I
		//IL_03b8: Expected O, but got I4
		//IL_0805: Expected O, but got I
		//IL_0409: Expected O, but got I4
		//IL_0863: Expected O, but got I
		//IL_045b: Expected O, but got I4
		//IL_08c1: Expected O, but got I
		//IL_04ac: Expected O, but got I4
		//IL_091f: Expected O, but got I
		//IL_04fe: Expected O, but got I4
		//IL_097d: Expected O, but got I
		//IL_054f: Expected O, but got I4
		object[] array = new object[14];
		if ("iOS Transaction " != null)
		{
			object obj = "iOS Transaction " as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = "iOS Transaction ";
			if (productId != null)
			{
				object obj3 = productId as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = productId;
				if (", " != null)
				{
					object obj5 = ", " as object;
					obj2 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj2 < 2L;
				bool flag6 = !flag5;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = ", ";
					if (currencyCode != null)
					{
						object obj7 = currencyCode as object;
						obj2 = array.Length;
					}
					bool flag9 = (long)(IntPtr)obj2 < 3L;
					bool flag10 = !flag9;
					object obj8 = (long)(IntPtr)obj2 - 3L;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array[3] = currencyCode;
						if (", " != null)
						{
							object obj9 = ", " as object;
							obj2 = array.Length;
						}
						bool flag13 = (long)(IntPtr)obj2 < 4L;
						bool flag14 = !flag13;
						object obj10 = (long)(IntPtr)obj2 - 4L;
						bool flag15 = obj10 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							array[4] = ", ";
							object obj11 = quantity;
							if (obj11 != null)
							{
								object obj12 = obj11 as object;
							}
							object obj13 = array.Length;
							bool flag17 = array.Length < 5;
							bool flag18 = !flag17;
							object obj14 = array.Length - 5;
							bool flag19 = obj14 == null;
							bool flag20 = !flag18;
							if (!(flag20 || flag19))
							{
								array[5] = obj11;
								if (", " != null)
								{
									object obj15 = ", " as object;
									obj13 = array.Length;
								}
								bool flag21 = (long)(IntPtr)obj13 < 6L;
								bool flag22 = !flag21;
								object obj16 = (long)(IntPtr)obj13 - 6L;
								bool flag23 = obj16 == null;
								bool flag24 = !flag22;
								if (!(flag24 || flag23))
								{
									array[6] = ", ";
									object obj17 = unitPrice;
									if (obj17 != null)
									{
										object obj18 = obj17 as object;
									}
									object obj19 = array.Length;
									bool flag25 = array.Length < 7;
									bool flag26 = !flag25;
									object obj20 = array.Length - 7;
									bool flag27 = obj20 == null;
									bool flag28 = !flag26;
									if (!(flag28 || flag27))
									{
										array[7] = obj17;
										if (", " != null)
										{
											object obj21 = ", " as object;
											obj19 = array.Length;
										}
										bool flag29 = (long)(IntPtr)obj19 < 8L;
										bool flag30 = !flag29;
										object obj22 = (long)(IntPtr)obj19 - 8L;
										bool flag31 = obj22 == null;
										bool flag32 = !flag30;
										if (!(flag32 || flag31))
										{
											array[8] = ", ";
											if (transactionId != null)
											{
												object obj23 = transactionId as object;
												obj19 = array.Length;
											}
											bool flag33 = (long)(IntPtr)obj19 < 9L;
											bool flag34 = !flag33;
											object obj24 = (long)(IntPtr)obj19 - 9L;
											bool flag35 = obj24 == null;
											bool flag36 = !flag34;
											if (!(flag36 || flag35))
											{
												array[9] = transactionId;
												if (", " != null)
												{
													object obj25 = ", " as object;
													obj19 = array.Length;
												}
												bool flag37 = (long)(IntPtr)obj19 < 10L;
												bool flag38 = !flag37;
												object obj26 = (long)(IntPtr)obj19 - 10L;
												bool flag39 = obj26 == null;
												bool flag40 = !flag38;
												if (!(flag40 || flag39))
												{
													array[10] = ", ";
													if (receipt != null)
													{
														object obj27 = receipt as object;
														obj19 = array.Length;
													}
													bool flag41 = (long)(IntPtr)obj19 < 11L;
													bool flag42 = !flag41;
													object obj28 = (long)(IntPtr)obj19 - 11L;
													bool flag43 = obj28 == null;
													bool flag44 = !flag42;
													if (!(flag44 || flag43))
													{
														array[11] = receipt;
														if (", " != null)
														{
															object obj29 = ", " as object;
															obj19 = array.Length;
														}
														bool flag45 = (long)(IntPtr)obj19 < 12L;
														bool flag46 = !flag45;
														object obj30 = (long)(IntPtr)obj19 - 12L;
														bool flag47 = obj30 == null;
														bool flag48 = !flag46;
														if (!(flag48 || flag47))
														{
															array[12] = ", ";
															if (signature != null)
															{
																object obj31 = signature as object;
																obj19 = array.Length;
															}
															bool flag49 = (long)(IntPtr)obj19 < 13L;
															bool flag50 = !flag49;
															object obj32 = (long)(IntPtr)obj19 - 13L;
															bool flag51 = obj32 == null;
															bool flag52 = !flag50;
															if (!(flag52 || flag51))
															{
																array[13] = signature;
																string message = string.Concat(array);
																Debug.Log(message);
																return;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0x1660490", Offset = "0x1660490", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED0B08]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, deferredDeeplinkDelegate, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF62]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, deferredDeeplinkDelegate, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Sending IosTenjin::GetDeeplink\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void GetDeeplink(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkDelegate)
	{
		Debug.Log("Sending IosTenjin::GetDeeplink");
	}

	[Token(Token = "0x6000043")]
	[Address(RVA = "0x16604FC", Offset = "0x16604FC", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA4280]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF63]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"iOS OptIn\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptIn()
	{
		Debug.Log("iOS OptIn");
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0x1660568", Offset = "0x1660568", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAC228]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF64]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"iOS OptOut\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptOut()
	{
		Debug.Log("iOS OptOut");
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0x16605D4", Offset = "0x16605D4", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEA908]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, parameters, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF65]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, parameters, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"iOS OptInParams\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptInParams(List<string> parameters)
	{
		Debug.Log("iOS OptInParams");
	}

	[Token(Token = "0x6000046")]
	[Address(RVA = "0x1660640", Offset = "0x1660640", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE98A8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, parameters, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF66]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, parameters, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"iOS OptOutParams\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OptOutParams(List<string> parameters)
	{
		Debug.Log("iOS OptOutParams");
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0x16606AC", Offset = "0x16606AC", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDE7F8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, subversion, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF67]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, subversion, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"iOS AppendAppSubversion\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void AppendAppSubversion(int subversion)
	{
		Debug.Log("iOS AppendAppSubversion");
	}

	[Token(Token = "0x6000048")]
	[Address(RVA = "0x1660718", Offset = "0x1660718", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IosTenjin()
	{
	}
}
