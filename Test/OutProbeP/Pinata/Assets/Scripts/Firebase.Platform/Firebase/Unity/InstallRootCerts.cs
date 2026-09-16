using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Platform;
using UnityEngine;

namespace Firebase.Unity
{
	[Token(Token = "0x2000002")]
	internal class InstallRootCerts : ICertificateService
	{
		[Token(Token = "0x4000001")]
		private static readonly object Sync;

		[Token(Token = "0x4000002")]
		private static Dictionary<IFirebaseAppPlatform, X509CertificateCollection> _installedRoots;

		[Token(Token = "0x4000003")]
		private static InstallRootCerts _instance;

		[Token(Token = "0x4000004")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private bool _needsCertificateWorkaround;

		[Token(Token = "0x4000005")]
		private static readonly string TrustedRoot;

		[Token(Token = "0x4000006")]
		private static readonly string IntermediateCA;

		[CompilerGenerated]
		[Token(Token = "0x4000007")]
		private static Func<_003C_003E__AnonType0<RuntimePlatform, bool, bool>> _003C_003Ef__am_0024cache0;

		[Token(Token = "0x17000001")]
		private static bool InstallationRequired
		{
			[Token(Token = "0x6000002")]
			[Address(RVA = "0x15E96B8", Offset = "0x15E96B8", Length = "0x230")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF0A90]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2029F8F]) = v41;\nL_0015:\n\tv43 = UnityEngine.Application::get_platform();\n\tv48 = v43 == 0xB;\n\tif (v48) goto L_FFFFFFFF;\n\tv54 = UnityEngine.Application::get_platform();\n\tv56 = v54 != 8;\n\tif (v56) goto L_0030;\n\tgoto L_00DE;\nL_0030:\n\tv141 = System.AppDomain::get_CurrentDomain();\n\tv192 = System.AppDomain::GetAssemblies(v141);\n\tv260 = v192.Length;\n\tv271 = v192.Length < 1;\n\tif (v271) goto L_FFFFFFFF;\nL_0049:\n\tv321 = v200 < v260;\n\tv224 = ~v321;\n\tif (v224) goto L_00E8;\n\tv319 = System.Reflection.Assembly::GetType(v192[v200 @ X20_v10 (System.Int32)], \"Firebase.Database.Internal.TubeSock.WebSocket\");\n\tv260 = v192.Length;\n\tv352 = v319 == 0;\n\tv357 = ~v352;\n\tv200 = v200 + 1;\n\tv105 = v105 | v357;\n\tv302 = v200 < v192.Length;\n\tif (v302) goto L_0049;\n\tgoto L_007F;\nL_007F:\n\tgoto L_0089;\n\tv335 = *([v331 @ X0_v21+E0]);\n\tv336 = v335 == 0;\n\tv337 = ~v336;\n\tgoto L_0089;\n\tv339 = \"il2cpp_codegen_runtime_class_init\"(v331, v325, v322, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0089:\n\tgoto L_0094;\n\tv361 = *([1F0BA98]);\n\tv362 = *([v361 @ X8_v26]);\n\tv363 = \"il2cpp_codegen_initialize_method\"(v362, v325, v322, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv366 = 0 | 1;\n\t*([2029FC4]) = v366;\nL_0094:\n\tgoto L_00A1;\n\tv371 = *([v367 @ X0_v24 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv372 = v371 == 0;\n\tv373 = ~v372;\n\tgoto L_00A1;\n\tv384 = \"il2cpp_codegen_runtime_class_init\"(v367, v325, v322, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv375 = Firebase.Platform.Services;\nL_00A1:\n\tv260 = v105 & 1;\n\t// 163 Box v383 @ X0_v27 (System.Object), typeof(System.Boolean), &v260 @ X8_v7 (System.Int32)\n\tv293 = System.String::Format(\"Root cert install required: {0}\", v383);\n\tgoto L_00DD;\n\tv393 = *([v389 @ X8_v20+B0]);\n\tv394 = 0;\n\tv395 = v393 + 8;\n\tv397 = *([v424 @ X11_v6-8]);\n\tv439 = v397 == v392;\n\tif (v439) goto L_00D4;\n\tv401 = v425 + 1;\n\tv444 = v401 < v391;\n\tv419 = ~v444;\n\tv399 = v424 + 0x10;\n\tv403 = ~v419;\n\tif (v403) goto L_FFFFFFFF;\n\tv420 = v132;\n\tv421 = 0;\n\tv422 = 0x8909C4(v420, v392, v421, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00DD;\nL_00D4:\n\tv445 = *([v424 @ X11_v6]);\n\tv446 = v445 << 4;\n\tv447 = v389 + v446;\n\tv448 = v447 + 0x130;\nL_00DD:\n\tFirebase.Platform.ILoggingService::LogMessage(v379.<Logging>k__BackingField, 1, v293);\nL_00DE:\n\treturnVal1 = v105 & 1;\n\treturn returnVal1;\n\tv234 = new System.NullReferenceException();\nL_00E8:\n\tv259 = new System.IndexOutOfRangeException();\n\tthrow v259;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				RuntimePlatform platform = Application.platform;
				int num3;
				if (platform != RuntimePlatform.Android)
				{
					RuntimePlatform platform2 = Application.platform;
					if (platform2 != RuntimePlatform.IPhonePlayer)
					{
						AppDomain currentDomain = AppDomain.CurrentDomain;
						Assembly[] assemblies = currentDomain.GetAssemblies();
						int num = assemblies.Length;
						if (assemblies.Length >= 1)
						{
							int num2 = 0;
							num3 = 0;
							do
							{
								if (num2 < num)
								{
									Type type = assemblies[num2].GetType("Firebase.Database.Internal.TubeSock.WebSocket");
									num = assemblies.Length;
									bool flag = (object)type == null;
									bool flag2 = !flag;
									num2++;
									num3 |= (flag2 ? 1 : 0);
									continue;
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
							}
							while (num2 < assemblies.Length);
						}
						else
						{
							num3 = 0;
						}
						num = num3 & 1;
						object arg = (byte)num != 0;
						string message = $"Root cert install required: {arg}";
						Services.Logging.LogMessage(PlatformLogLevel.Debug, message);
						goto IL_0165;
					}
				}
				num3 = 0;
				goto IL_0165;
				IL_0165:
				return (byte)(num3 & 1) != 0;
			}
		}

		[Token(Token = "0x17000002")]
		public static InstallRootCerts Instance
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x15E98E8", Offset = "0x15E98E8", Length = "0x144")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EED750]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029F90]) = v39;\nL_0019:\n\tgoto L_0024;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = Firebase.Unity.InstallRootCerts;\nL_0024:\n\tSystem.Threading.Monitor::Enter(v53.Sync);\n\tgoto L_0032;\n\tv62 = *([v58 @ X0_v5 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v58, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv66 = Firebase.Unity.InstallRootCerts;\nL_0032:\n\tv71 = v69._instance == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0048;\n\tv74 = new Firebase.Unity.InstallRootCerts();\n\tFirebase.Unity.InstallRootCerts::.ctor(v74);\n\tgoto L_0045;\n\tv108 = *([v90 @ X0_v16 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0045;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v90, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv111 = Firebase.Unity.InstallRootCerts;\nL_0045:\n\tv82._instance = v74;\nL_0048:\n\tSystem.Threading.Monitor::Exit(v53.Sync);\nL_0049:\n\t;\n\tgoto L_005C;\n\tv94 = *([v86 @ X0_v9 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tgoto L_005C;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v86, v84, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv98 = Firebase.Unity.InstallRootCerts;\nL_005C:\n\treturn v101._instance;\n\tgoto L_005E;\nL_005E:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0075;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\n\tif (TEMP) goto L_0049;\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0075:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Monitor.Enter(Sync);
				if (_instance == null)
				{
					InstallRootCerts instance = new InstallRootCerts();
					_instance = instance;
				}
				Monitor.Exit(Sync);
				return _instance;
			}
		}

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x15E91C0", Offset = "0x15E91C0", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F02E90]);\n\tv21 = *([v20 @ X8_v64]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029F8E]) = v40;\nL_0016:\n\tSystem.Object::.ctor(this);\n\tgoto L_0026;\n\tv49 = *([v45 @ X0_v3 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v45, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv53 = Firebase.Unity.InstallRootCerts;\nL_0026:\n\tv58 = v56.<>f__am$cache0 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0046;\n\tv64 = new System.Func`1<<>__AnonType0`3<UnityEngine.RuntimePlatform, System.Boolean, System.Boolean>>();\n\tSystem.Func`1<<>__AnonType0`3<UnityEngine.RuntimePlatform, System.Boolean, System.Boolean>>::.ctor(v64, 0, Il2CppMethodInfo);\n\tgoto L_0042;\n\tv120 = *([v103 @ X0_v57 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0042;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v103, v70, v68, v66, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv123 = Firebase.Unity.InstallRootCerts;\nL_0042:\n\tv79.<>f__am$cache0 = v64;\nL_0046:\n\tgoto L_0055;\n\tv88 = *([v74 @ X0_v5 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tgoto L_0055;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v74, v69, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv92 = Firebase.Unity.InstallRootCerts;\nL_0055:\n\tgoto L_0060;\n\tv108 = *([v98 @ X8_v12+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tgoto L_0060;\n\tv125 = v98;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v125, v69, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0060:\n\tv119 = Firebase.Platform.FirebaseHandler::RunOnMainThread(v97.<>f__am$cache0);\n\tv130 = ~v119.<InstallationRequired>;\n\tif (v130) goto L_0126;\n\tgoto L_0073;\n\tv219 = *([v132 @ X0_v15+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_0073;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v132, v118, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0073:\n\tv187 = Firebase.Unity.InstallRootCerts::IsCertBugPresent(v119.<Platform>);\n\tv190 = v187 == 0;\n\tif (v190) goto L_0126;\n\tv282 = ~v119.<IsEditor>;\n\tif (v282) goto L_00CB;\n\tgoto L_008A;\n\tv287 = *([v280 @ X0_v19+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_008A;\n\tv291 = \"il2cpp_codegen_runtime_class_init\"(v280, v118, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008A:\n\tgoto L_0095;\n\tv310 = *([1F0BA98]);\n\tv311 = *([v310 @ X8_v48]);\n\tv312 = \"il2cpp_codegen_initialize_method\"(v311, v118, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv315 = 0 | 1;\n\t*([2029FC4]) = v315;\nL_0095:\n\tgoto L_00A9;\n\tv331 = *([v316 @ X0_v36 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv332 = v331 == 0;\n\tv333 = ~v332;\n\t// 153 Jump @b68\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v316, v118, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv334 = Firebase.Platform.Services;\nL_00A9:\n\tgoto L_011D;\n\tv360 = *([v345 @ X8_v41+B0]);\n\tv361 = 0;\n\tv362 = v360 + 8;\n\tv364 = *([v430 @ X11_v12-8]);\n\tv436 = v364 == v348;\n\tif (v436) goto L_0114;\n\tv386 = v431 + 1;\n\tv462 = v386 < v350;\n\tv382 = ~v462;\n\tv384 = v430 + 0x10;\n\tv366 = ~v382;\n\tif (v366) goto L_FFFFFFFF;\n\tv387 = v195;\n\tv388 = 0;\n\tv389 = 0x8909C4(v387, v348, v388, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_011D;\nL_00CB:\n\tgoto L_00D5;\n\tv298 = *([v280 @ X0_v19+E0]);\n\tv299 = v298 == 0;\n\tv300 = ~v299;\n\tif (v300) goto L_00D5;\n\tv302 = \"il2cpp_codegen_runtime_class_init\"(v280, v118, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D5:\n\tgoto L_00E0;\n\tv321 = *([1F0BA98]);\n\tv322 = *([v321 @ X8_v32]);\n\tv323 = \"il2cpp_codegen_initialize_method\"(v322, v118, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv326 = 0 | 1;\n\t*([2029FC4]) = v326;\nL_00E0:\n\tgoto L_00F4;\n\tv337 = *([v327 @ X0_v22 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv338 = v337 == 0;\n\tv339 = ~v338;\n\t// 228 Jump @b72\n\tv351 = \"il2cpp_codegen_runtime_class_init\"(v327, v118, v67, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv340 = Firebase.Platform.Services;\nL_00F4:\n\tgoto L_0136;\n\tv390 = *([v353 @ X8_v27+B0]);\n\tv391 = 0;\n\tv392 = v390 + 8;\n\tv394 = *([v451 @ X11_v6-8]);\n\tv457 = v394 == v356;\n\tif (v457) goto L_0127;\n\tv416 = v452 + 1;\n\tv472 = v416 < v358;\n\tv412 = ~v472;\n\tv414 = v451 + 0x10;\n\tv396 = ~v412;\n\tif (v396) goto L_FFFFFFFF;\n\tv417 = v212;\n\tv418 = 0;\n\tv419 = 0x8909C4(v417, v356, v418, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0136;\nL_0114:\n\tv463 = *([v430 @ X11_v12]);\n\tv464 = v463 << 4;\n\tv465 = v345 + v464;\n\tv466 = v465 + 0x130;\nL_011D:\n\tFirebase.Platform.ILoggingService::LogMessage(v214.<Logging>k__BackingField, 2, \"Using workaround for .NET 4.6 certificate bug.\");\n\tthis._needsCertificateWorkaround = 1;\nL_0126:\n\treturn;\nL_0127:\n\tv473 = *([v451 @ X11_v6]);\n\tv474 = v473 << 4;\n\tv475 = v353 + v474;\n\tv476 = v475 + 0x130;\nL_0136:\n\tFirebase.Platform.ILoggingService::LogMessage(v215.<Logging>k__BackingField, 3, \"Detected .NET 4.6 certificate bug, Firebase might not work.\");\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private InstallRootCerts()
		{
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = [Token(Token = "0x600000F")] [Address(RVA = "0x15EC18C", Offset = "0x15EC18C", Length = "0xC0")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ECD378]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2029FAA]) = v41;\nL_0015:\n\tv43 = UnityEngine.Application::get_platform();\n\tv58 = UnityEngine.Application::get_isEditor();\n\tgoto L_0027;\n\tv54 = *([v50 @ X8_v5+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv62 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v62, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tv61 = Firebase.Unity.InstallRootCerts::get_InstallationRequired();\n\tv68 = new <>__AnonType0`3<UnityEngine.RuntimePlatform, System.Boolean, System.Boolean>();\n\t<>__AnonType0`3<UnityEngine.RuntimePlatform, System.Boolean, System.Boolean>::.ctor(v68, v43, v58, v61);\n\treturn v68;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () =>
				{
					RuntimePlatform platform = Application.platform;
					bool isEditor = Application.isEditor;
					bool installationRequired = InstallationRequired;
					return new
					{
						Platform = platform,
						IsEditor = isEditor,
						InstallationRequired = installationRequired
					};
				};
			}
			var anon = FirebaseHandler.RunOnMainThread(_003C_003Ef__am_0024cache0);
			if (anon._003CInstallationRequired_003E && IsCertBugPresent(anon.Platform))
			{
				if (anon._003CIsEditor_003E)
				{
					Services.Logging.LogMessage(PlatformLogLevel.Info, "Using workaround for .NET 4.6 certificate bug.");
					_needsCertificateWorkaround = true;
				}
				else
				{
					Services.Logging.LogMessage(PlatformLogLevel.Warning, "Detected .NET 4.6 certificate bug, Firebase might not work.");
				}
			}
		}

		[PreserveSig]
		[Token(Token = "0x6000004")]
		[Address(RVA = "0x15E9A2C", Offset = "0x15E9A2C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2029F98]);\n\tv10 = *([2029F98]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x181B000 + 0x998;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2029F98]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(v70, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static extern void AFunctionThatDoesNotExistInternal();

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15E9AB4", Offset = "0x15E9AB4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F01980]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029FA0]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tFirebase.Unity.InstallRootCerts::AFunctionThatDoesNotExistInternal();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AFunctionThatDoesNotExist()
		{
			AFunctionThatDoesNotExistInternal();
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x15E9514", Offset = "0x15E9514", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBC0C8]);\n\tv19 = *([v18 @ X8_v28]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029FA1]) = v38;\nL_0013:\n\tv39 = platform < 1;\n\tv40 = ~v39;\n\tv41 = platform - 1;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_FFFFFFFF;\n\tgoto L_0030;\n\tv74 = *([v52 @ X0_v5+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0030;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0030:\n\tv83 = System.Type::GetTypeFromHandle(System.Security.Cryptography.X509Certificates.X509Certificate2);\n\tv124 = v83 == 0;\n\tif (v124) goto L_0059;\n\tv151 = *([v83 @ X0_v8 (System.Type)]);\n\tv138 = *([v151 @ X8_v18 (Il2CppClass<System.Type>)+2A8]);\n\tv154 = System.Type::get_Assembly(v83);\n\tv155 = v154 == 0;\n\tif (v155) goto L_0059;\n\tv67 = System.Reflection.Assembly::GetType(v154, \"System.Security.Cryptography.X509Certificates.OSX509Certificates\");\n\tv69 = v67 == 0;\n\tif (v69) goto L_FFFFFFFF;\n\tgoto L_004E;\n\tv184 = *([v168 @ X0_v32 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_004E;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v168, v62, v60, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004E:\n\tFirebase.Unity.InstallRootCerts::AFunctionThatDoesNotExist();\n\tgoto L_0058;\nL_0058:\n\treturn v113;\nL_0059:\n\tv161 = new System.NullReferenceException();\n\tv85 = v138 != 1;\n\tif (v85) goto L_0095;\n\tv173 = 0x6D2BC0(v161, v138, v136, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv190 = *([v173 @ X0_v16]);\n\tv104 = *([v190 @ X8_v12]);\n\tv215 = \"il2cpp_vm_class_is_assignable_from\"(System.DllNotFoundException, *([v190 @ X8_v12]), v136, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv195 = v215 & 1;\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_FFFFFFFF;\n\tv199 = *([v173 @ X0_v16]);\n\tv104 = *([v199 @ X8_v15]);\n\tv215 = \"il2cpp_vm_class_is_assignable_from\"(System.EntryPointNotFoundException, *([v199 @ X8_v15]), v136, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv213 = v215 & 1;\n\tv214 = v213 == 0;\n\tif (v214) goto L_007F;\n\tgoto L_0088;\nL_007F:\n\tv211 = *([v173 @ X0_v16]);\n\tv104 = *([v211 @ X8_v16]);\n\tv215 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v211 @ X8_v16]), v136, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv219 = v215 & 1;\n\tv179 = v219 == 0;\n\tif (v179) goto L_008B;\nL_0088:\n\tv109 = 0x6D2490(v215, v104, v136, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0058;\nL_008B:\n\tv221 = 0x6D1E60(8, *([v211 @ X8_v16]), v136, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v221 @ X0_v27]) = *([v173 @ X0_v16]);\n\tv138 = 0x1E8A000 + 0x870;\n\tv223 = 0x6D2A00(v221, v138, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv178 = 0x6D2490(v223, v138, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0095:\n\tv183 = 0x6D2380(v146, v138, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturnVal2 = 0x846AA4(v183, v138, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsCertBugPresent(RuntimePlatform platform)
		{
			//IL_0046: Expected I, but got O
			bool flag = platform < RuntimePlatform.OSXPlayer;
			bool flag2 = !flag;
			int num = (int)(platform - 1);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (flag2 && flag4)
			{
				goto IL_00c7;
			}
			Type typeFromHandle = typeof(X509Certificate2);
			bool flag5 = (object)typeFromHandle == null;
			int num2 = 0;
			if (!flag5)
			{
				IntPtr intPtr = (IntPtr)typeFromHandle;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v18 (Il2CppClass<System.Type>)+2A8]");
				num2 = 0;
				Assembly assembly = typeFromHandle.Assembly;
				if ((object)assembly != null)
				{
					Type type = assembly.GetType("System.Security.Cryptography.X509Certificates.OSX509Certificates");
					if ((object)type != null)
					{
						AFunctionThatDoesNotExist();
						return true;
					}
					goto IL_00c7;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag6 = num2 != 1;
			NullReferenceException ex2 = ex;
			if (flag6)
			{
				goto IL_0278;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = obj;
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
			object obj4 = default(object);
			int result;
			if ((int)((long)(IntPtr)obj4 & 1L) == 0)
			{
				object obj5 = obj2;
				obj3 = obj5;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
				{
					result = 0;
					goto IL_0302;
				}
				object obj6 = obj2;
				obj3 = obj6;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				if ((int)((long)(IntPtr)obj4 & 1L) == 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj7 = obj2;
					num2 = 32022528 + 2160;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					NullReferenceException ex3 = default(NullReferenceException);
					ex2 = ex3;
					goto IL_0278;
				}
			}
			result = 1;
			goto IL_0302;
			IL_0278:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			bool result2 = default(bool);
			return result2;
			IL_00c7:
			return false;
			IL_0302:
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			return (byte)result != 0;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x15E9B10", Offset = "0x15E9B10", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1ECA2F8]);\n\tv39 = *([v38 @ X8_v27]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, startLine, endLine, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2029FA2]) = v56;\nL_0020:\n\tv60 = new System.Collections.Generic.List`1<System.Byte[]>();\n\tSystem.Collections.Generic.List`1<System.Byte[]>::.ctor(v60);\n\tv68 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v68);\n\tgoto L_003E;\n\tv77 = *([v73 @ X0_v6+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_003E;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v73, v69, endLine, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_003E:\n\tv89 = System.Text.RegularExpressions.Regex::Split(base64BlobList, \"\\n|\\r|\\r\\n\");\n\tv242 = v89.Length;\n\tv103 = v89.Length < 1;\n\tif (v103) goto L_00B7;\nL_0055:\n\tv252 = v113 < v242;\n\tv143 = ~v252;\n\tif (v143) goto L_00BA;\n\tv287 = v238 == 0;\n\tif (v287) goto L_0094;\n\tv294 = System.String::StartsWith(v89[v113 @ X26_v6 (System.Int32)], endLine);\n\tv305 = v294 == 0;\n\tif (v305) goto L_0099;\n\tv320 = System.Text.StringBuilder::ToString(v191);\n\tgoto L_0083;\n\tv326 = *([v298 @ X8_v23+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_0083;\n\tv334 = v298;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v334, v319, v289, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0083:\n\tv295 = System.Convert::FromBase64String(v320);\n\tSystem.Collections.Generic.List`1<System.Byte[]>::Add(v60, v295);\n\tv337 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v337);\n\tgoto L_009B;\nL_0094:\n\tv238 = System.String::StartsWith(v89[v113 @ X26_v6 (System.Int32)], startLine);\n\tgoto L_009B;\nL_0099:\n\tv325 = System.Text.StringBuilder::Append(v191, v89[v113 @ X26_v6 (System.Int32)]);\nL_009B:\n\tv242 = v89.Length;\n\tv113 = v113 + 1;\n\tv171 = v113 < v89.Length;\n\tif (v171) goto L_0055;\nL_00B7:\n\treturn v60;\n\tv157 = new System.NullReferenceException();\nL_00BA:\n\tv243 = new System.IndexOutOfRangeException();\n\tthrow v243;\n\treturn returnVal2;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static List<byte[]> DecodeBase64Blobs(string base64BlobList, string startLine, string endLine)
		{
			List<byte[]> list = new List<byte[]>();
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = Regex.Split(base64BlobList, "\n|\r|\r\n");
			int num = array.Length;
			if (array.Length >= 1)
			{
				int num2 = 0;
				StringBuilder stringBuilder2 = stringBuilder;
				bool flag = false;
				do
				{
					if (num2 < num)
					{
						if (flag)
						{
							if (array[num2].StartsWith(endLine))
							{
								string s = stringBuilder2.ToString();
								byte[] item = Convert.FromBase64String(s);
								list.Add(item);
								StringBuilder stringBuilder3 = new StringBuilder();
								stringBuilder2 = stringBuilder3;
								flag = false;
							}
							else
							{
								StringBuilder stringBuilder4 = stringBuilder2.Append(array[num2]);
								flag = true;
							}
						}
						else
						{
							flag = array[num2].StartsWith(startLine);
						}
						num = array.Length;
						num2++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < array.Length);
			}
			return list;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x15E9D0C", Offset = "0x15E9D0C", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EF3260]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029FA3]) = v44;\nL_001A:\n\tv49 = 0;\n\tv51 = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();\n\tSystem.Security.Cryptography.X509Certificates.X509CertificateCollection::.ctor(v51);\n\tgoto L_0033;\n\tv60 = *([v56 @ X0_v4+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0033;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, v52, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\tv74 = Firebase.Unity.InstallRootCerts::DecodeBase64Blobs(certString, \"-----BEGIN CERTIFICATE-----\", \"-----END CERTIFICATE-----\");\n\tv75 = v74 == 0;\n\tif (v75) goto L_005C;\n\tv80 = System.Collections.Generic.List`1<System.Byte[]>::GetEnumerator(v74);\nL_0041:\n\tv112 = System.Collections.Generic.List`1<System.Byte[]>+Enumerator<System.Byte[]>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Byte[]>+Enumerator<System.Byte[]>));\n\tv124 = v112 == 0;\n\tif (v124) goto L_0058;\n\tv128 = new System.Security.Cryptography.X509Certificates.X509Certificate2();\n\tSystem.Security.Cryptography.X509Certificates.X509Certificate2::.ctor(v128, 0);\n\tv107 = System.Security.Cryptography.X509Certificates.X509CertificateCollection::Add(v51, v128);\n\tgoto L_0041;\nL_0058:\n\tv133 = System.Collections.Generic.List`1<System.Byte[]>+Enumerator<System.Byte[]>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Byte[]>+Enumerator<System.Byte[]>));\n\tgoto L_007F;\n\tv92 = new System.NullReferenceException();\nL_005C:\n\tv98 = new System.NullReferenceException();\n\tgoto L_0069;\n\tgoto L_0069;\n\tgoto L_0069;\nL_0069:\n\tv122 = 0 != 1;\n\tif (v122) goto L_0080;\n\tv125 = 0x6D2BC0(v98, 0, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv135 = 0x6D2490(v125, 0, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv139 = System.Collections.Generic.List`1<System.Byte[]>+Enumerator<System.Byte[]>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Byte[]>+Enumerator<System.Byte[]>));\n\tv187 = *([v125 @ X0_v16]) == 0;\n\tv141 = ~v187;\n\tif (v141) goto L_0084;\nL_007F:\n\treturn v51;\nL_0080:\n\tv126 = 0x6D2380(v98, 0, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0084:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static X509CertificateCollection DecodeCertificateCollectionFromString(string certString)
		{
			List<byte[]>.Enumerator enumerator = default(List<byte[]>.Enumerator);
			X509CertificateCollection x509CertificateCollection = new X509CertificateCollection();
			List<byte[]> list = DecodeBase64Blobs(certString, "-----BEGIN CERTIFICATE-----", "-----END CERTIFICATE-----");
			if (list != null)
			{
				List<byte[]>.Enumerator enumerator2 = list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					X509Certificate2 value = new X509Certificate2(null);
					int num = x509CertificateCollection.Add(value);
				}
				enumerator.Dispose();
				goto IL_0102;
			}
			NullReferenceException ex = new NullReferenceException();
			if (0 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0102;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (X509CertificateCollection)(object)new TypeLoadException();
			IL_0102:
			return x509CertificateCollection;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x15E9EAC", Offset = "0x15E9EAC", Length = "0x3C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDD198]);\n\tv23 = *([v22 @ X8_v59]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2029FA4]) = v43;\nL_0015:\n\tv44 = &v45 @ stack_-50;\n\tgoto L_0028;\n\tv56 = *([v49 @ X0_v2+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0028;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v49, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0028:\n\tv65 = System.Type::GetTypeFromHandle(Firebase.Unity.InstallRootCerts);\n\tv70 = System.Type::get_Assembly(v65);\n\tv138 = System.Reflection.Assembly::GetManifestResourceStream(v70, \"Firebase.Platform.cacert_pem.txt\");\n\tv143 = new System.IO.StreamReader();\n\tSystem.IO.StreamReader::.ctor(v143, v138);\n\tv251 = System.IO.StreamReader::ReadToEnd(v143);\n\tgoto L_0057;\n\tv259 = *([v255 @ X0_v62+E0]);\n\tv260 = v259 == 0;\n\tv261 = ~v260;\n\tif (v261) goto L_0057;\n\tv263 = \"il2cpp_codegen_runtime_class_init\"(v255, v249, v171, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0057:\n\tv267 = Firebase.Unity.InstallRootCerts::DecodeCertificateCollectionFromString(v251);\n\tv225 = 0;\n\t*([v44 @ X22_v1]) = 0x5A;\nL_0063:\n\tgoto L_008A;\n\tv305 = *([v282 @ X8_v49+B0]);\n\tv306 = 0;\n\tv307 = v305 + 8;\n\tv309 = *([v353 @ X11_v17-8]);\n\tv358 = v309 == v285;\n\tif (v358) goto L_0083;\n\tv329 = v352 + 1;\n\tv364 = v329 < v284;\n\tv327 = ~v364;\n\tv331 = v353 + 0x10;\n\tv311 = ~v327;\n\tif (v311) goto L_FFFFFFFF;\n\tv332 = v168;\n\tv333 = 0;\n\tv334 = 0x8909C4(v332, v285, v333, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_008A;\nL_0083:\n\tv365 = *([v353 @ X11_v17]);\n\tv366 = v365 << 4;\n\tv367 = v282 + v366;\n\tv368 = v367 + 0x130;\nL_008A:\n\tSystem.IDisposable::Dispose(v143);\n\tgoto L_0096;\nL_0096:\n\tv448 = *([v44 @ X22_v1+v225 @ X23_v8 (System.Int32)*4]) == 0x5A;\n\tif (v448) goto L_010F;\nL_009E:\n\tgoto L_0119;\nL_00A6:\n\tgoto L_00B0;\n\tv500 = *([v496 @ X0_v7+E0]);\n\tv501 = v500 == 0;\n\tv502 = ~v501;\n\tgoto L_00B0;\n\tv504 = \"il2cpp_codegen_runtime_class_init\"(v496, v489, v118, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00B0:\n\tgoto L_00BB;\n\tv511 = *([1F0BA98]);\n\tv512 = *([v511 @ X8_v26]);\n\tv513 = \"il2cpp_codegen_initialize_method\"(v512, v489, v118, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv516 = 0 | 1;\n\t*([2029FC4]) = v516;\nL_00BB:\n\tgoto L_00C5;\n\tv521 = *([v517 @ X0_v10 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv522 = v521 == 0;\n\tv523 = ~v522;\n\t// 191 Jump @b77\n\tv529 = \"il2cpp_codegen_runtime_class_init\"(v517, v489, v118, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv525 = Firebase.Platform.Services;\nL_00C5:\n\tv531 = *([v493 @ X19_v3 (System.Int32)]);\n\t*([v531 @ X9_v4+160])(v535, v493, *([v531 @ X9_v4+168]), v118, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00FD;\n\tv544 = *([v540 @ X8_v18+B0]);\n\tv545 = 0;\n\tv546 = v544 + 8;\n\tv548 = *([v585 @ X11_v6-8]);\n\tv590 = v548 == v543;\n\tif (v590) goto L_00F4;\n\tv568 = v584 + 1;\n\tv595 = v568 < v542;\n\tv566 = ~v595;\n\tv570 = v585 + 0x10;\n\tv550 = ~v566;\n\tif (v550) goto L_FFFFFFFF;\n\tv571 = v474;\n\tv572 = 0;\n\tv573 = 0x8909C4(v571, v543, v572, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00FD;\nL_00F4:\n\tv596 = *([v585 @ X11_v6]);\n\tv597 = v596 << 4;\n\tv598 = v540 + v597;\n\tv599 = v598 + 0x130;\nL_00FD:\n\tFirebase.Platform.ILoggingService::LogMessage(v530.<Logging>k__BackingField, 4, v535);\n\tv479 = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();\n\tSystem.Security.Cryptography.X509Certificates.X509CertificateCollection::.ctor(v479);\nL_010F:\n\treturn v471;\n\tv124 = new System.NullReferenceException();\n\tv131 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0119:\n\tv246 = new System.TypeLoadException();\n\tgoto L_FFFFFFFF;\n\tgoto L_0120;\n\t// 284 Jump @b61\n\t// 285 Jump @b61\n\t// 286 Jump @b61\n\t// 287 Jump @b61\nL_0120:\n\tX8 = X1;\n\tX20 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_009E;\n\tX21 = 0;\n\tX23 = 0xFFFFFFFF;\n\tgoto L_0063;\n\t// 310 Jump @b61\n\t// 311 Jump @b61\n\tgoto L_015E;\n\tv288 = 0x6D2BC0(v246, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv493 = *([v288 @ X0_v38]);\n\tv340 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v493 @ X19_v3 (System.Int32)]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv363 = v340 & 1;\n\tv298 = v363 == 0;\n\tif (v298) goto L_0154;\n\tv386 = 0x6D2490(v340, *([v493 @ X19_v3 (System.Int32)]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A6;\nL_0154:\n\tv388 = 0x6D1E60(8, *([v493 @ X19_v3 (System.Int32)]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v388 @ X0_v42]) = *([v288 @ X0_v38]);\n\tv293 = 0x1E8A000 + 0x870;\n\tv455 = 0x6D2A00(v388, v293, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv296 = 0x6D2490(v455, v293, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_015E:\n\tv304 = 0x6D2380(v289, v293, v291, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturnVal1 = 0x846AA4(v304, v293, v291, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal1;\n// 203 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static X509CertificateCollection DecodeDefaultCollection()
		{
			//IL_0081: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			Type typeFromHandle = typeof(InstallRootCerts);
			Assembly assembly = typeFromHandle.Assembly;
			Stream manifestResourceStream = assembly.GetManifestResourceStream("Firebase.Platform.cacert_pem.txt");
			StreamReader streamReader = new StreamReader(manifestResourceStream);
			string certString = streamReader.ReadToEnd();
			X509CertificateCollection x509CertificateCollection = DecodeCertificateCollectionFromString(certString);
			int num = 0;
			obj = 90;
			((IDisposable)streamReader).Dispose();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X22_v1+v225 @ X23_v8 (System.Int32)*4]");
			bool flag = (IntPtr)0 == (IntPtr)90;
			X509CertificateCollection result = x509CertificateCollection;
			if (flag)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			TypeLoadException ex2 = ex;
			int num2 = 0;
			int num3 = 0;
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			X509CertificateCollection result2 = default(X509CertificateCollection);
			return result2;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x15EA270", Offset = "0x15EA270", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F0A5D8]);\n\tv21 = *([v20 @ X8_v38]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029FA5]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EF33D0]);\n\tv60 = *([v59 @ X8_v34]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2029FCE]) = v64;\nL_002F:\n\tgoto L_0037;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0037;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Firebase.Platform.Services;\nL_0037:\n\tv77 = v76.<AppConfig>k__BackingField;\n\tv81 = *([v77 @ X20_v4 (Firebase.Platform.IAppConfigExtensions)]);\n\tv85 = *([v81 @ X8_v11 (Il2CppClass<Firebase.Platform.IAppConfigExtensions>)+126]) == 0;\n\tif (v85) goto L_005E;\n\tv185 = *([v81 @ X8_v11 (Il2CppClass<Firebase.Platform.IAppConfigExtensions>)+B0]) + 8;\nL_0049:\n\tv191 = *([v185 @ X11_v10-8]) == Firebase.Platform.IAppConfigExtensions;\n\tif (v191) goto L_0061;\n\tv186 = v186 + 1;\n\tv254 = v186 < *([v81 @ X8_v11 (Il2CppClass<Firebase.Platform.IAppConfigExtensions>)+126]);\n\tv167 = ~v254;\n\tv185 = v185 + 0x10;\n\tv151 = ~v167;\n\tif (v151) goto L_0049;\nL_005E:\n\tv273 = 0x8909C4(v77, Firebase.Platform.IAppConfigExtensions, 1, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0069;\nL_0061:\n\tv256 = *([v185 @ X11_v10]) + 1;\n\tv257 = v256 << 4;\n\tv258 = v81 + v257;\n\tv273 = v258 + 0x130;\nL_0069:\n\t*([v273 @ X0_v10])(v279, v77, app, *([v273 @ X0_v10+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv282 = System.String::IsNullOrEmpty(v279);\n\tv284 = v282 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_00CD;\n\tv288 = UnityEngine.Resources::Load(v279);\n\tv297 = v288 == 0;\n\tif (v297) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A1;\n\tv340 = v340_asT == 0;\n\tif (v340) goto L_FFFFFFFF;\n\tgoto L_00A1;\nL_00A1:\n\tgoto L_00AA;\n\tv350 = *([v346 @ X0_v20+E0]);\n\tv351 = v350 == 0;\n\tv352 = ~v351;\n\tgoto L_00AA;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v346, v287, v276, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00AA:\n\tv136 = UnityEngine.Object::op_Inequality(v140, 0);\n\tv291 = v136 == 0;\n\tif (v291) goto L_00CD;\n\tv359 = UnityEngine.TextAsset::get_text(v140);\n\tgoto L_00C8;\n\tv366 = *([v246 @ X8_v24+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_00C8;\n\tv372 = v246;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v372, v226, v96, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00C8:\n\treturnVal3 = Firebase.Unity.InstallRootCerts::DecodeCertificateCollectionFromString(v359);\n\treturn returnVal3;\nL_00CD:\n\tv296 = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();\n\tSystem.Security.Cryptography.X509Certificates.X509CertificateCollection::.ctor(v296);\n\treturn v296;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static X509CertificateCollection DecodeCollection(IFirebaseAppPlatform app)
		{
			//IL_0012: Expected I, but got O
			//IL_004d: Expected O, but got I
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00f1: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_0099: Expected O, but got I
			IAppConfigExtensions _003CAppConfig_003Ek__BackingField = Services.AppConfig;
			IntPtr intPtr = (IntPtr)_003CAppConfig_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v11 (Il2CppClass<Firebase.Platform.IAppConfigExtensions>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v11 (Il2CppClass<Firebase.Platform.IAppConfigExtensions>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ X11_v10-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAppConfigExtensions))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v11 (Il2CppClass<Firebase.Platform.IAppConfigExtensions>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0224;
			IL_00b2:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0224;
			IL_0224:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v273 @ X0_v10] (should have been resolved before IL gen)");
			string text = default(string);
			if (!string.IsNullOrEmpty(text))
			{
				UnityEngine.Object obj5 = Resources.Load(text);
				UnityEngine.Object obj6;
				if ((object)obj5 == null)
				{
					obj6 = null;
				}
				else
				{
					TextAsset textAsset = obj5 as TextAsset;
					obj6 = (((object)textAsset == null) ? null : obj5);
				}
				if (obj6 != null)
				{
					string text2 = ((TextAsset)obj6).text;
					return DecodeCertificateCollectionFromString(text2);
				}
			}
			return new X509CertificateCollection();
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x15EA498", Offset = "0x15EA498", Length = "0xA84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001D;\n\tv35 = *([1EF4E88]);\n\tv36 = *([v35 @ X8_v166]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, directory, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2029FA6]) = v54;\nL_001D:\n\tv55 = &v56 @ stack_-C0;\n\t*([v21 @ X29-68]) = 0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\tv60 = System.IO.Directory::CreateDirectory(directory);\n\tgoto L_0035;\n\tv67 = *([v63 @ X0_v4+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_0035;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v63, v59, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0035:\n\tgoto L_0040;\n\tv79 = *([1F0BA98]);\n\tv80 = *([v79 @ X8_v162]);\n\tv81 = \"il2cpp_codegen_initialize_method\"(v80, v59, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv84 = 0 | 1;\n\t*([2029FC4]) = v84;\nL_0040:\n\tgoto L_004E;\n\tv89 = *([v85 @ X0_v7 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tgoto L_004E;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v85, v59, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv93 = Firebase.Platform.Services;\nL_004E:\n\tv103 = System.String::Concat(\"Installing CRLs in \", directory);\n\tgoto L_0081;\n\tv196 = *([v108 @ X8_v14+B0]);\n\tv197 = 0;\n\tv198 = v196 + 8;\n\tv200 = *([v271 @ X11_v51-8]);\n\tv277 = v200 == v111;\n\tif (v277) goto L_0078;\n\tv222 = v272 + 1;\n\tv287 = v222 < v110;\n\tv218 = ~v287;\n\tv220 = v271 + 0x10;\n\tv202 = ~v218;\n\tif (v202) goto L_FFFFFFFF;\n\tv223 = v101;\n\tv224 = 0;\n\tv225 = 0x8909C4(v223, v111, v224, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0081;\nL_0078:\n\tv288 = *([v271 @ X11_v51]);\n\tv289 = v288 << 4;\n\tv290 = v108 + v289;\n\tv291 = v290 + 0x130;\nL_0081:\n\tFirebase.Platform.ILoggingService::LogMessage(v97.<Logging>k__BackingField, 1, v103);\n\tgoto L_0093;\n\tv326 = *([v317 @ X0_v26+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tgoto L_0093;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v317, v311, v313, v310, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0093:\n\tv335 = System.Type::GetTypeFromHandle(Firebase.Unity.InstallRootCerts);\n\tv379 = System.Type::get_Assembly(v335);\n\tv444 = System.Reflection.Assembly::GetManifestResourceStream(v379, resource_name);\n\tv449 = new System.IO.StreamReader();\n\tSystem.IO.StreamReader::.ctor(v449, v444);\n\tv622 = System.IO.StreamReader::ReadToEnd(v449);\n\tgoto L_00C6;\n\tv713 = *([v625 @ X0_v124+E0]);\n\tv714 = v713 == 0;\n\tv715 = ~v714;\n\tif (v715) goto L_00C6;\n\tv717 = \"il2cpp_codegen_runtime_class_init\"(v625, v620, v548, v310, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00C6:\n\tv609 = Firebase.Unity.InstallRootCerts::DecodeBase64Blobs(v622, \"-----BEGIN X509 CRL-----\", \"-----END X509 CRL-----\");\n\tv773 = System.Collections.Generic.List`1<System.Byte[]>::GetEnumerator(v609);\n\t*([v21 @ X29-90]) = 0;\n\tv645 = *([v21 @ X29-88]);\n\t*([v21 @ X29-60]) = *([v21 @ X29-78]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-88]);\n\tgoto L_0207;\nL_00D9:\n\t;\n\tv965 = System.Security.Cryptography.MD5::Create();\n\tv701 = v965 == 0;\n\tif (v701) goto L_01D3;\n\tv1078 = System.Security.Cryptography.HashAlgorithm::ComputeHash(v965, *([v21 @ X29-60]));\n\tgoto L_00F2;\n\tv1202 = *([v1150 @ X0_v138+E0]);\n\tv1203 = v1202 == 0;\n\tv1204 = ~v1203;\n\tif (v1204) goto L_00F2;\n\tv1206 = \"il2cpp_codegen_runtime_class_init\"(v1150, v1077, v652, v634, v40, v41, v42, v43, v396, v45, v46, v47, v48, v49, v50, v51);\nL_00F2:\n\tv1209 = System.BitConverter::ToString(v1078);\n\tv702 = v1209 == 0;\n\tif (v702) goto L_01D5;\n\tv1269 = System.String::Replace(v1209, \"-\", v1264.Empty);\n\tv992 = v992 + 1;\n\t*([v55 @ X27_v1+v992 @ X26_v9*4]) = 0x9E;\nL_0109:\n\tgoto L_0130;\n\tv1309 = *([v1303 @ X8_v122+B0]);\n\tv1310 = 0;\n\tv1311 = v1309 + 8;\n\tv1313 = *([v1362 @ X11_v46-8]);\n\tv1368 = v1313 == v1307;\n\tif (v1368) goto L_0129;\n\tv1335 = v1363 + 1;\n\tv1433 = v1335 < v1305;\n\tv1331 = ~v1433;\n\tv1333 = v1362 + 0x10;\n\tv1315 = ~v1331;\n\tif (v1315) goto L_FFFFFFFF;\n\tv1336 = v388;\n\tv1337 = 0;\n\tv1338 = 0x8909C4(v1336, v1307, v1337, v384, v40, v41, v42, v43, v396, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0130;\nL_0129:\n\tv1434 = *([v1362 @ X11_v46]);\n\tv1435 = v1434 << 4;\n\tv1436 = v1303 + v1435;\n\tv1437 = v1436 + 0x130;\nL_0130:\n\tSystem.IDisposable::Dispose(v965);\nL_0131:\n\tv1497 = v992 + 1;\n\tv1499 = v1497 == 0;\n\tif (v1499) goto L_0149;\n\tv1568 = *([v55 @ X27_v1+v992 @ X26_v9*4]) != 0x9E;\n\tif (v1568) goto L_0149;\n\tv1589 = 0xFFFFFFFF ^ v992;\n\tv992 = v992 + v1589;\n\tgoto L_014F;\nL_0149:\n\tgoto L_0217;\nL_014F:\n\tv1598 = System.String::Concat(v1269, \".crl\");\n\tgoto L_0160;\n\tv1607 = *([v1603 @ X0_v149+E0]);\n\tv1608 = v1607 == 0;\n\tv1609 = ~v1608;\n\tif (v1609) goto L_0160;\n\tv1611 = \"il2cpp_codegen_runtime_class_init\"(v1603, v1595, v1597, v384, v40, v41, v42, v43, v396, v45, v46, v47, v48, v49, v50, v51);\nL_0160:\n\tv1615 = System.IO.Path::Combine(directory, v1598);\n\tv878 = System.IO.File::Exists(v1615);\n\tv1618 = v878 == 0;\n\tv880 = ~v1618;\n\tif (v880) goto L_0207;\n\tv1622 = new System.IO.FileStream();\n\tSystem.IO.FileStream::.ctor(v1622, v1615, 1);\n\tv1628 = new System.IO.BinaryWriter();\n\tSystem.IO.BinaryWriter::.ctor(v1628, v1622);\n\tv762 = v1628 == 0;\n\tif (v762) goto L_01D8;\n\tv1635 = System.IO.BinaryWriter::Write(v1628, *([v21 @ X29-60]));\n\tv992 = v992 + 1;\n\t*([v55 @ X27_v1+v992 @ X26_v9*4]) = 0xEE;\nL_018D:\n\tgoto L_01B4;\n\tv1644 = *([v1638 @ X8_v138+B0]);\n\tv1645 = 0;\n\tv1646 = v1644 + 8;\n\tv1648 = *([v1684 @ X11_v41-8]);\n\tv1690 = v1648 == v1642;\n\tif (v1690) goto L_01AD;\n\tv1670 = v1685 + 1;\n\tv1695 = v1670 < v1640;\n\tv1666 = ~v1695;\n\tv1668 = v1684 + 0x10;\n\tv1650 = ~v1666;\n\tif (v1650) goto L_FFFFFFFF;\n\tv1671 = v639;\n\tv1672 = 0;\n\tv1673 = 0x8909C4(v1671, v1642, v1672, v633, v40, v41, v42, v43, v396, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01B4;\nL_01AD:\n\tv1696 = *([v1684 @ X11_v41]);\n\tv1697 = v1696 << 4;\n\tv1698 = v1638 + v1697;\n\tv1699 = v1698 + 0x130;\nL_01B4:\n\tSystem.IDisposable::Dispose(v1628);\nL_01B5:\n\tv1713 = v992 + 1;\n\tv1715 = v1713 == 0;\n\tif (v1715) goto L_FFFFFFFF;\n\tv1728 = *([v55 @ X27_v1+v992 @ X26_v9*4]) != 0xEE;\n\tif (v1728) goto L_FFFFFFFF;\n\tv1731 = 0xFFFFFFFF ^ v992;\n\tv992 = v992 + v1731;\n\tgoto L_01CE;\n\tgoto L_0220;\nL_01CE:\n\t;\n\tv883 = *([v21 @ X29-90]) + 1;\n\t*([v21 @ X29-90]) = v883;\n\tgoto L_0207;\nL_01D3:\n\tthrow System.NullReferenceException;\nL_01D5:\n\tthrow System.NullReferenceException;\nL_01D8:\n\tv760 = new System.NullReferenceException();\n\tgoto L_0221;\n\tX8 = X1;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX21 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_024A;\n\tX0 = X21;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_018D;\n\tgoto L_01B5;\n\tgoto L_01F1;\n\tgoto L_01F1;\nL_01F1:\n\tX8 = X1;\n\tX21 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_024A;\n\tX0 = X21;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0109;\n\tgoto L_0131;\nL_0207:\n\tv884 = &v21 @ X29 - 0x70;\n\tv885 = System.Collections.Generic.List`1<System.Byte[]>+Enumerator<System.Byte[]>::MoveNext(v884);\n\tv931 = v885 == 0;\n\tv932 = ~v931;\n\tif (v932) goto L_00D9;\n\tv992 = v992 + 1;\n\t*([v55 @ X27_v1+v992 @ X26_v9*4]) = 0x111;\n\tgoto L_0253;\nL_0217:\n\tv430 = new System.TypeLoadException();\n\tv439 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv580 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0220:\n\tv759 = new System.TypeLoadException();\nL_0221:\n\tgoto L_024A;\n\t// 546 Jump @b123\n\t// 547 Jump @b123\n\tgoto L_022A;\n\tgoto L_022A;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_022A:\n\tX8 = X1;\n\tX21 = X0;\n\t*([X29-90]) = 0;\n\tX26 = 0xFFFFFFFF;\n\tgoto L_0287;\n\tgoto L_FFFFFFFF;\n\t// 563 Jump @b123\n\t// 564 Jump @b123\n\t// 565 Jum\n// ... truncated")]
		private unsafe static void InstallDefaultCRLs(string resource_name, string directory)
		{
			//IL_00b1: Expected O, but got I
			//IL_00d4: Expected O, but got I4
			//IL_00e1: Expected O, but got I8
			//IL_039a: Expected O, but got I
			//IL_03de: Expected O, but got I
			//IL_03f2: Expected I, but got O
			//IL_0122: Expected O, but got I
			//IL_0497: Expected O, but got I
			//IL_04af: Expected O, but got I
			//IL_017b: Expected O, but got I
			//IL_09b9: Expected I, but got O
			//IL_0551: Expected O, but got I
			//IL_0507: Expected I4, but got I8
			//IL_0515: Expected O, but got I
			//IL_0938: Expected O, but got I
			//IL_05d1: Expected I4, but got O
			//IL_0984: Expected O, but got I
			//IL_061c: Expected I4, but got O
			//IL_07d0: Expected O, but got I4
			//IL_01c2: Expected I4, but got I8
			//IL_01d0: Expected O, but got I
			//IL_0a09: Expected O, but got I
			//IL_0ac5: Expected O, but got I
			//IL_0a1e: Expected O, but got I
			//IL_0a3a: Expected O, but got I
			//IL_0a43: Expected I4, but got O
			//IL_0237: Expected O, but got I4
			//IL_077c: Expected O, but got I
			//IL_06e7: Expected I, but got O
			//IL_0ae4: Expected O, but got I
			//IL_0a98: Expected O, but got I
			//IL_0369: Expected O, but got I4
			//IL_02a2: Expected O, but got I
			//IL_02b1: Expected O, but got I
			//IL_08d5: Expected I, but got O
			//IL_0466: Expected I4, but got O
			//IL_0483: Expected I, but got O
			//IL_0907: Expected O, but got I
			//IL_0314: Expected O, but got I4
			//IL_02f8: Expected I4, but got I8
			//IL_0306: Expected O, but got I
			//IL_0338: Expected O, but got I
			//IL_0346: Expected O, but got I4
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			DirectoryInfo directoryInfo = Directory.CreateDirectory(directory);
			string message = "Installing CRLs in " + directory;
			Services.Logging.LogMessage(PlatformLogLevel.Debug, message);
			Type typeFromHandle = typeof(InstallRootCerts);
			Assembly assembly = typeFromHandle.Assembly;
			Stream manifestResourceStream = assembly.GetManifestResourceStream(resource_name);
			StreamReader streamReader = new StreamReader(manifestResourceStream);
			string base64BlobList = streamReader.ReadToEnd();
			List<byte[]> list = DecodeBase64Blobs(base64BlobList, "-----BEGIN X509 CRL-----", "-----END X509 CRL-----");
			List<byte[]>.Enumerator enumerator = list.GetEnumerator();
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
			_ = 0;
			object obj5 = 0;
			object obj6 = 4294967295L;
			IntPtr intPtr;
			Stream stream2;
			object obj10 = default(object);
			object obj19 = default(object);
			while (true)
			{
				List<byte[]>.Enumerator enumerator2 = (List<byte[]>.Enumerator)((long)(IntPtr)obj - 112L);
				StreamReader streamReader2;
				int num3;
				string text3;
				Stream stream;
				TypeLoadException ex3;
				if (((List<byte[]>.Enumerator*)enumerator2)->MoveNext())
				{
					MD5 mD = MD5.Create();
					if (mD != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
						byte[] array = mD.ComputeHash((byte[])0);
						string text = BitConverter.ToString(array);
						if (text != null)
						{
							string text2 = text.Replace("-", string.Empty);
							obj6 = (long)(IntPtr)obj6 + 1L;
							_ = 158;
							((IDisposable)mD).Dispose();
							object obj7 = (long)(IntPtr)obj6 + 1L;
							if (obj7 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X27_v1+v992 @ X26_v9*4]");
								if ((IntPtr)0 == (IntPtr)158)
								{
									int num = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj6);
									obj6 = (long)(IntPtr)obj6 + (long)num;
									string path = text2 + ".crl";
									string path2 = Path.Combine(directory, path);
									bool flag = File.Exists(path2);
									bool flag2 = !flag;
									bool flag3 = !flag2;
									obj5 = 0;
									if (flag3)
									{
										continue;
									}
									FileStream fileStream = new FileStream(path2, FileMode.CreateNew);
									BinaryWriter binaryWriter = new BinaryWriter(fileStream);
									TypeLoadException ex;
									if (binaryWriter != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
										binaryWriter.Write((byte[])0);
										obj6 = (long)(IntPtr)obj6 + 1L;
										_ = 238;
										((IDisposable)binaryWriter).Dispose();
										object obj8 = (long)(IntPtr)obj6 + 1L;
										if (obj8 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X27_v1+v992 @ X26_v9*4]");
											if ((IntPtr)0 == (IntPtr)238)
											{
												int num2 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj6);
												obj6 = (long)(IntPtr)obj6 + (long)num2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
												object obj9 = 0L + 1L;
												obj5 = 0;
												continue;
											}
										}
										obj5 = 0;
										streamReader2 = streamReader;
										ex = new TypeLoadException();
										obj6 = obj6;
										text3 = null;
										stream = null;
									}
									else
									{
										NullReferenceException ex2 = new NullReferenceException();
										obj5 = 0;
										text3 = null;
										stream = fileStream;
										ex = (TypeLoadException)(object)ex2;
										streamReader2 = streamReader;
									}
									bool flag4 = (IntPtr)stream != (IntPtr)1;
									intPtr = (IntPtr)typeof(Services);
									stream2 = stream;
									ex3 = ex;
									if (!flag4)
									{
										Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
										num3 = (int)obj10;
										Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
										intPtr = (IntPtr)typeof(Services);
										goto IL_0488;
									}
									goto IL_0955;
								}
							}
							TypeLoadException ex4 = new TypeLoadException();
							NullReferenceException ex5 = new NullReferenceException();
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				obj6 = (long)(IntPtr)obj6 + 1L;
				_ = 273;
				intPtr = (IntPtr)typeof(Services);
				streamReader2 = streamReader;
				num3 = 0;
				goto IL_0488;
				IL_0975:
				object obj12;
				object obj11 = (long)(IntPtr)obj12 + 1L;
				int num4;
				if (obj11 != null)
				{
					if (num4 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X27_v1+v895 @ X26_v7*4]");
						if ((IntPtr)0 != (IntPtr)291)
						{
							goto IL_0671;
						}
					}
				}
				else if (num4 != 0)
				{
					goto IL_0671;
				}
				IntPtr intPtr2;
				object obj13 = (long)intPtr2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ X0_v63+B8]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
				_ = 0;
				object obj15 = (long)(IntPtr)obj - 140L;
				object obj16 = (int)obj15;
				string message2 = $"Installed {obj16} CRLs";
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ X8_v54+28]");
				object obj17;
				object obj18;
				if ((IntPtr)0 == (IntPtr)0)
				{
					NullReferenceException ex6 = new NullReferenceException();
					obj5 = obj17;
					obj4 = obj18;
					text3 = null;
					stream = (Stream)obj16;
					intPtr = (IntPtr)typeof(Services);
					stream2 = (Stream)obj16;
					ex3 = (TypeLoadException)(object)ex6;
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ X8_v54+28]");
				((ILoggingService)0).LogMessage(PlatformLogLevel.Debug, message2);
				return;
				IL_09cb:
				((IDisposable)streamReader2).Dispose();
				obj17 = obj5;
				obj12 = obj6;
				obj18 = obj4;
				intPtr2 = intPtr;
				num4 = num3;
				goto IL_0975;
				IL_0955:
				if ((IntPtr)stream2 != (IntPtr)1)
				{
					break;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				num3 = (int)obj19;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag5 = streamReader2 == null;
				obj17 = obj5;
				obj12 = obj6;
				obj18 = obj4;
				intPtr2 = intPtr;
				num4 = (int)obj19;
				if (flag5)
				{
					goto IL_0975;
				}
				goto IL_09cb;
				IL_0671:
				throw new TypeLoadException();
				IL_0542:
				obj6 = (long)(IntPtr)obj6 + 1L;
				_ = 291;
				if (streamReader2 == null)
				{
					obj17 = obj5;
					obj12 = obj6;
					obj18 = obj4;
					intPtr2 = intPtr;
					num4 = num3;
					goto IL_0975;
				}
				goto IL_09cb;
				IL_0488:
				List<byte[]>.Enumerator enumerator3 = (List<byte[]>.Enumerator)((long)(IntPtr)obj - 112L);
				((List<byte[]>.Enumerator*)enumerator3)->Dispose();
				object obj20 = (long)(IntPtr)obj6 + 1L;
				if (obj20 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X27_v1+v992 @ X26_v9*4]");
					if ((IntPtr)0 == (IntPtr)273)
					{
						int num5 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj6);
						obj6 = (long)(IntPtr)obj6 + (long)num5;
						goto IL_0542;
					}
				}
				if (num3 == 0)
				{
					goto IL_0542;
				}
				TypeLoadException ex7 = new TypeLoadException();
				text3 = null;
				stream = null;
				intPtr = (IntPtr)typeof(Services);
				stream2 = null;
				ex3 = ex7;
				goto IL_0955;
			}
			if ((IntPtr)stream2 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj22 = default(object);
				object obj21 = obj22;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj23 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj23 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					object obj24 = (long)intPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X0_v41+B8]");
					object obj25 = 0;
					object obj26 = obj21;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v170 @ X9_v11+160] (should have been resolved before IL gen)");
					object arg = default(object);
					string message3 = $"Error installing CRLs: {arg}";
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ X8_v32+28]");
					((ILoggingService)0).LogMessage(PlatformLogLevel.Error, message3);
					return;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj28 = default(object);
				object obj27 = obj28;
				Stream stream = (Stream)(32022528 + 2160);
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				object obj29 = default(object);
				obj5 = obj29;
				object obj30 = default(object);
				obj4 = obj30;
				string text3 = null;
				TypeLoadException ex8 = default(TypeLoadException);
				TypeLoadException ex3 = ex8;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x15EAF1C", Offset = "0x15EAF1C", Length = "0x458")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EB8400]);\n\tv27 = *([v26 @ X8_v61]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2029FA7]) = v47;\nL_0018:\n\tv49 = System.AppDomain::get_CurrentDomain();\n\tv52 = System.AppDomain::GetAssemblies(v49);\n\tv113 = v52 == 0;\n\tif (v113) goto L_009D;\n\tv261 = v52.Length;\n\tv151 = v52.Length < 1;\n\tif (v151) goto L_012F;\nL_0036:\n\tv262 = v66 < v261;\n\tv100 = ~v262;\n\tif (v100) goto L_0093;\n\tv359 = System.Reflection.Assembly::GetName(v52[v66 @ X21_v10 (System.Int32)]);\n\tv531 = System.String::Equals(v359.name, \"Mono.Security\");\n\tv570 = v531 == 0;\n\tif (v570) goto L_0075;\n\tv607 = System.Reflection.Assembly::GetType(v52[v66 @ X21_v10 (System.Int32)], \"Mono.Security.X509.X509StoreManager\");\n\tv609 = v607 == 0;\n\tif (v609) goto L_0075;\n\tv640 = System.Type::GetField(v607, \"_userPath\", 0x28);\n\tv641 = v640 == 0;\n\tif (v641) goto L_0071;\n\tSystem.Reflection.FieldInfo::SetValue(v640, 0, 0);\nL_0071:\n\tv516 = System.Type::GetField(v607, \"_userStore\", 0x28);\n\tv654 = v516 == 0;\n\tv519 = ~v654;\n\tif (v519) goto L_0087;\nL_0075:\n\tv261 = v52.Length;\n\tv66 = v66 + 1;\n\tv190 = v66 < v52.Length;\n\tif (v190) goto L_0036;\n\tgoto L_012F;\nL_0087:\n\tSystem.Reflection.FieldInfo::SetValue(v516, 0, 0);\n\treturn;\nL_0093:\n\tv335 = new System.IndexOutOfRangeException();\n\tthrow v335;\n\tv372 = new System.NullReferenceException();\n\tv393 = new System.NullReferenceException();\n\tv105 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_009D:\n\tv139 = new System.NullReferenceException();\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\n\tgoto L_00B5;\nL_00B5:\n\tv245 = 0 != 1;\n\tif (v245) goto L_0199;\n\tv275 = 0x6D2BC0(v139, 0, v284, v282, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv349 = *([v275 @ X0_v36]);\n\tv353 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v349 @ X19_v13]), v284, v282, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv383 = v353 & 1;\n\tv384 = v383 == 0;\n\tif (v384) goto L_018F;\n\tv446 = 0x6D2490(v353, *([v349 @ X19_v13]), v284, v282, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00D4;\n\tv592 = *([v563 @ X0_v40+E0]);\n\tv593 = v592 == 0;\n\tv594 = ~v593;\n\tif (v594) goto L_00D4;\n\tv596 = \"il2cpp_codegen_runtime_class_init\"(v563, v351, v115, v114, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00D4:\n\tgoto L_00DF;\n\tv624 = *([1F0BA98]);\n\tv625 = *([v624 @ X8_v43]);\n\tv626 = \"il2cpp_codegen_initialize_method\"(v625, v351, v115, v114, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv629 = 0 | 1;\n\t*([2029FC4]) = v629;\nL_00DF:\n\tgoto L_00E9;\n\tv642 = *([v630 @ X0_v43 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv643 = v642 == 0;\n\tv644 = ~v643;\n\t// 227 Jump @b90\n\tv655 = \"il2cpp_codegen_runtime_class_init\"(v630, v351, v115, v114, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv645 = Firebase.Platform.Services;\nL_00E9:\n\tv414 = *([v349 @ X19_v13]);\n\t*([v414 @ X9_v11+160])(v660, v349, *([v414 @ X9_v11+168]), v284, v282, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv435 = System.String::Concat(\"Error resetting cert store: \", v660);\n\tgoto L_0128;\n\tv669 = *([v665 @ X8_v37+B0]);\n\tv670 = 0;\n\tv671 = v669 + 8;\n\tv673 = *([v700 @ X11_v15-8]);\n\tv715 = v673 == v668;\n\tif (v715) goto L_011F;\n\tv677 = v701 + 1;\n\tv720 = v677 < v667;\n\tv695 = ~v720;\n\tv675 = v700 + 0x10;\n\tv679 = ~v695;\n\tif (v679) goto L_FFFFFFFF;\n\tv696 = v176;\n\tv697 = 0;\n\tv698 = 0x8909C4(v696, v668, v697, v114, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0128;\nL_011F:\n\tv721 = *([v700 @ X11_v15]);\n\tv722 = v721 << 4;\n\tv723 = v665 + v722;\n\tv724 = v723 + 0x130;\nL_0128:\n\tFirebase.Platform.ILoggingService::LogMessage(v656.<Logging>k__BackingField, 4, v435);\nL_012F:\n\tgoto L_0139;\n\tv263 = *([v231 @ X0_v5+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tgoto L_0139;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v231, v215, v169, v166, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0139:\n\tgoto L_0144;\n\tv337 = *([1F0BA98]);\n\tv338 = *([v337 @ X8_v16]);\n\tv339 = \"il2cpp_codegen_initialize_method\"(v338, v215, v169, v166, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv342 = 0 | 1;\n\t*([2029FC4]) = v342;\nL_0144:\n\tgoto L_0158;\n\tv373 = *([v343 @ X0_v8 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv374 = v373 == 0;\n\tv375 = ~v374;\n\t// 328 Jump @b94\n\tv397 = \"il2cpp_codegen_runtime_class_init\"(v343, v215, v169, v166, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv377 = Firebase.Platform.Services;\nL_0158:\n\tgoto L_018B;\n\tv532 = *([v399 @ X8_v11+B0]);\n\tv533 = 0;\n\tv534 = v532 + 8;\n\tv536 = *([v572 @ X11_v6-8]);\n\tv587 = v536 == v402;\n\tif (v587) goto L_0178;\n\tv540 = v573 + 1;\n\tv616 = v540 < v404;\n\tv558 = ~v616;\n\tv538 = v572 + 0x10;\n\tv542 = ~v558;\n\tif (v542) goto L_FFFFFFFF;\n\tv559 = v381;\n\tv560 = 0;\n\tv561 = 0x8909C4(v559, v402, v560, v166, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_018B;\nL_0178:\n\tv617 = *([v572 @ X11_v6]);\n\tv618 = v617 << 4;\n\tv619 = v399 + v618;\n\tv620 = v619 + 0x130;\nL_018B:\n\tFirebase.Platform.ILoggingService::LogMessage(v380.<Logging>k__BackingField, 3, \"Could not refresh the cert store. You may have to restart the app to connect to Firebase.\");\n\tthrow System.NullReferenceException;\nL_018F:\n\tv453 = 0x6D1E60(8, v448, v447, v283, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t*([v453 @ X0_v26]) = *([v289 @ X20_v6]);\n\tv320 = 0x1E8A000 + 0x870;\n\tv568 = 0x6D2A00(v453, v320, 0, v283, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv323 = 0x6D2490(v568, v320, 0, v283, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0199:\n\tv331 = 0x6D2380(v328, v320, 0, v283, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv354 = 0x846AA4(v331, v320, 0, v283, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 251 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HackRefreshMonoRootStore()
		{
			//IL_0026: Expected I, but got O
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			bool flag = assemblies == null;
			IntPtr intPtr = (IntPtr)null;
			if (!flag)
			{
				int num = assemblies.Length;
				if (assemblies.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							AssemblyName name = assemblies[num2].GetName();
							if (name.Name.Equals("Mono.Security"))
							{
								Type type = assemblies[num2].GetType("Mono.Security.X509.X509StoreManager");
								if ((object)type != null)
								{
									type.GetField("_userPath", BindingFlags.Static | BindingFlags.NonPublic)?.SetValue(null, null);
									FieldInfo field = type.GetField("_userStore", BindingFlags.Static | BindingFlags.NonPublic);
									if ((object)field != null)
									{
										field.SetValue(null, null);
										return;
									}
								}
							}
							num = assemblies.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < assemblies.Length);
				}
				goto IL_037f;
			}
			NullReferenceException ex2 = new NullReferenceException();
			bool flag2 = 0 != 1;
			NullReferenceException ex3 = ex2;
			if (!flag2)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj2 = default(object);
				object obj = obj2;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v414 @ X9_v11+160] (should have been resolved before IL gen)");
					string text = default(string);
					string message = "Error resetting cert store: " + text;
					Services.Logging.LogMessage(PlatformLogLevel.Error, message);
					goto IL_037f;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj6 = default(object);
				object obj5 = obj6;
				intPtr = (IntPtr)(32022528 + 2160);
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				NullReferenceException ex4 = default(NullReferenceException);
				ex3 = ex4;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			return;
			IL_037f:
			Services.Logging.LogMessage(PlatformLogLevel.Warning, "Could not refresh the cert store. You may have to restart the app to connect to Firebase.");
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x15EB374", Offset = "0x15EB374", Length = "0xD4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv33 = *([1EA74B8]);\n\tv34 = *([v33 @ X8_v171]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, app, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([2029FA8]) = v53;\nL_001C:\n\tv54 = &v55 @ stack_-A0;\n\t*([v21 @ X29-58]) = 0;\n\tgoto L_002B;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, app, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_002B:\n\tv70 = Firebase.Unity.InstallRootCerts::get_InstallationRequired();\n\tv72 = v70 == 0;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_003C;\n\tv78 = *([v73 @ X0_v7 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_003C;\n\tv217 = \"il2cpp_codegen_runtime_class_init\"(v73, app, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv82 = Firebase.Unity.InstallRootCerts;\nL_003C:\n\tv97 = v85.Sync;\n\tSystem.Threading.Monitor::Enter(v85.Sync);\n\tgoto L_0051;\n\tv283 = *([v218 @ X0_v10 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\t// 71 Jump @b290\n\tv293 = \"il2cpp_codegen_runtime_class_init\"(v218, v86, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv287 = Firebase.Unity.InstallRootCerts;\nL_0051:\n\tv297 = &v21 @ X29 - 0x58;\n\tv299 = System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>::TryGetValue(v290._installedRoots, app, v297);\n\tv360 = v299 == 0;\n\tv361 = ~v360;\n\tif (v361) goto L_023D;\n\tv421 = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();\n\t*([v21 @ X29-68]) = v85.Sync;\n\tSystem.Security.Cryptography.X509Certificates.X509CertificateCollection::.ctor(v421);\n\t*([v21 @ X29-58]) = v421;\n\tv539 = System.Environment::GetFolderPath(0x1A);\n\tgoto L_0077;\n\tv581 = *([v575 @ X0_v92+E0]);\n\tv582 = v581 == 0;\n\tv583 = ~v582;\n\tif (v583) goto L_0077;\n\tv585 = \"il2cpp_codegen_runtime_class_init\"(v575, v538, v297, v296, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0077:\n\tv593 = System.IO.Path::Combine(v539, \".mono\");\n\tv603 = System.IO.Path::Combine(v593, \"certs\");\n\tv608 = System.IO.Directory::Exists(v603);\n\tv612 = v608 == 0;\n\tv613 = ~v612;\n\tif (v613) goto L_FFFFFFFF;\n\tv655 = System.IO.Directory::CreateDirectory(v603);\n\tv738 = v655 == 0;\n\tv694 = ~v738;\n\tif (v694) goto L_FFFFFFFF;\nL_0091:\n\tgoto L_009B;\n\tv865 = *([v820 @ X0_v198+E0]);\n\tv866 = v865 == 0;\n\tv867 = ~v866;\n\tif (v867) goto L_009B;\n\tv869 = \"il2cpp_codegen_runtime_class_init\"(v820, v654, v602, v296, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_009B:\n\tgoto L_00A6;\n\tv912 = *([1EF33D0]);\n\tv913 = *([v912 @ X8_v162]);\n\tv914 = \"il2cpp_codegen_initialize_method\"(v913, v654, v602, v296, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv917 = 0 | 1;\n\t*([2029FCE]) = v917;\nL_00A6:\n\tgoto L_00B7;\n\tv958 = *([v918 @ X0_v201 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv959 = v958 == 0;\n\tv960 = ~v959;\n\t// 170 Jump @b292\n\tv1006 = \"il2cpp_codegen_runtime_class_init\"(v918, v654, v602, v296, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv962 = Firebase.Platform.Services;\nL_00B7:\n\tgoto L_00E1;\n\tv1074 = *([v1008 @ X8_v138+B0]);\n\tv1075 = 0;\n\tv1076 = v1074 + 8;\n\tv1078 = *([v1173 @ X11_v59-8]);\n\tv1179 = v1078 == v1011;\n\tif (v1179) goto L_00D9;\n\tv1100 = v1174 + 1;\n\tv1245 = v1100 < v1010;\n\tv1096 = ~v1245;\n\tv1098 = v1173 + 0x10;\n\tv1080 = ~v1096;\n\tif (v1080) goto L_FFFFFFFF;\n\tv1101 = v966;\n\tv1102 = 0;\n\tv1103 = 0x8909C4(v1101, v1011, v1102, v296, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00E1;\n\tgoto L_04BC;\nL_00D9:\n\tv1246 = *([v1173 @ X11_v59]);\n\tv1247 = v1246 << 4;\n\tv1248 = v1008 + v1247;\n\tv1249 = v1248 + 0x130;\nL_00E1:\n\tv1255 = Firebase.Platform.IAppConfigExtensions::GetWriteablePath(v965.<AppConfig>k__BackingField, app);\n\tv691 = System.String::IsNullOrEmpty(v1255);\n\tv693 = v691 == 0;\n\tif (v693) goto L_032D;\nL_00EE:\n\tgoto L_00F4;\n\tv824 = *([v766 @ X0_v100 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv825 = v824 == 0;\n\tv826 = ~v825;\n\tgoto L_00F4;\n\tv828 = \"il2cpp_codegen_runtime_class_init\"(v766, v402, v404, v406, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00F4:\n\tv830 = Firebase.Unity.InstallRootCerts::DecodeDefaultCollection();\n\tv408 = Firebase.Unity.InstallRootCerts::DecodeCollection(app);\n\tgoto L_0128;\n\tv1044 = *([v969 @ X8_v59+B0]);\n\tv1045 = 0;\n\tv1046 = v1044 + 8;\n\tv1048 = *([v1152 @ X11_v46-8]);\n\tv1158 = v1048 == v972;\n\tif (v1158) goto L_0121;\n\tv1070 = v1153 + 1;\n\tv1230 = v1070 < v971;\n\tv1066 = ~v1230;\n\tv1068 = v1152 + 0x10;\n\tv1050 = ~v1066;\n\tif (v1050) goto L_FFFFFFFF;\n\tv1071 = v27;\n\tv1072 = 0;\n\tv1073 = 0x8909C4(v1071, v972, v1072, v406, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0128;\nL_0121:\n\tv1231 = *([v1152 @ X11_v46]);\n\tv1232 = v1231 << 4;\n\tv1233 = v969 + v1232;\n\tv1234 = v1233 + 0x130;\nL_0128:\n\tv1239 = Firebase.Platform.IFirebaseAppPlatform::get_Name(app);\n\tgoto L_013A;\n\tv1259 = *([v1241 @ X0_v108+E0]);\n\tv1260 = v1259 == 0;\n\tv1261 = ~v1260;\n\tgoto L_013A;\n\tv1263 = \"il2cpp_codegen_runtime_class_init\"(v1241, v485, v487, v406, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_013A:\n\tgoto L_0145;\n\tv1273 = *([1EF3128]);\n\tv1274 = *([v1273 @ X8_v125]);\n\tv1275 = \"il2cpp_codegen_initialize_method\"(v1274, v485, v487, v406, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1278 = 0 | 1;\n\t*([2022B9C]) = v1278;\nL_0145:\n\tgoto L_014D;\n\tv1297 = *([v1279 @ X0_v111 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv1298 = v1297 == 0;\n\tv1299 = ~v1298;\n\tgoto L_014D;\n\tv1317 = \"il2cpp_codegen_runtime_class_init\"(v1279, v485, v487, v406, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1300 = Firebase.Platform.FirebaseHandler;\nL_014D:\n\tv452 = v495.<AppUtils>k__BackingField;\n\tv1319 = *([v452 @ X25_v27 (System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>)]);\n\tv1323 = *([v1319 @ X8_v69 (Il2CppClass<System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>>)+126]) == 0;\n\tif (v1323) goto L_0174;\n\tv1461 = *([v1319 @ X8_v69 (Il2CppClass<System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>>)+B0]) + 8;\nL_015F:\n\tv1467 = *([v1461 @ X11_v41-8]) == Firebase.Platform.IFirebaseAppUtils;\n\tif (v1467) goto L_0177;\n\tv1462 = v1462 + 1;\n\tv1510 = v1462 < *([v1319 @ X8_v69 (Il2CppClass<System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>>)+126]);\n\tv1428 = ~v1510;\n\tv1461 = v1461 + 0x10;\n\tv1412 = ~v1428;\n\tif (v1412) goto L_015F;\nL_0174:\n\tv1517 = System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>::TryGetValue(v452, Firebase.Platform.IFirebaseAppUtils, 3);\n\tgoto L_017E;\nL_0177:\n\tv1512 = *([v1461 @ X11_v41]) + 3;\n\tv1513 = v1512 << 4;\n\tv1514 = v1319 + v1513;\n\tv1517 = v1514 + 0x130;\nL_017E:\n\tv1517.m_value(v1521, v452, *([v1517 @ X0_v113 (System.Boolean)+8]), v1516, v406, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv949 = System.String::Equals(v1239, v1521);\n\tv97 = *([v21 @ X29-68]);\n\tv1531 = v949 == 0;\n\tif (v1531) goto L_0194;\n\tSystem.Security.Cryptography.X509Certificates.X509CertificateCollection::AddRange(v408, v830);\n\t*([v21 @ X29-58]) = v408;\n\tgoto L_0199;\nL_0194:\n\tSystem.Security.Cryptography.X509Certificates.X509CertificateCollection::AddRange(*([v21 @ X29-58]), v830);\nL_0199:\n\tgoto L_01A9;\n\tv1759 = *([v1745 @ X0_v119 (Il2CppClass<Firebase.Unity.InstallRootCerts>)+E0]);\n\tv1760 = v1759 == 0;\n\tv1761 = ~v1760;\n\t// 413 ConditionalJump @b301, v1761 @ TEMP_v120\n\tv1766 = \"il2cpp_codegen_runti\n// ... truncated")]
		public unsafe X509CertificateCollection Install(IFirebaseAppPlatform app)
		{
			//IL_0409: Expected O, but got I
			//IL_0412: Expected O, but got I4
			//IL_01a0: Expected I, but got O
			//IL_083e: Expected O, but got I
			//IL_01db: Expected O, but got I
			//IL_02de: Expected O, but got I
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Expected O, but got Unknown
			//IL_0295: Expected O, but got I
			//IL_0227: Expected O, but got I
			//IL_094e: Expected I, but got O
			//IL_0330: Expected O, but got I
			//IL_03cb: Expected O, but got I
			//IL_03d4: Expected I4, but got O
			//IL_0451: Expected O, but got I
			//IL_0545: Expected O, but got I
			//IL_054e: Expected O, but got I4
			//IL_0553: Expected I, but got O
			//IL_067d: Expected O, but got I
			//IL_064b: Expected O, but got I
			//IL_06b7: Expected I, but got O
			//IL_08c6: Expected O, but got I
			//IL_05a8: Expected I, but got O
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			object obj4;
			string path2;
			if (InstallationRequired)
			{
				obj4 = Sync;
				Monitor.Enter(Sync);
				if (!_installedRoots.TryGetValue(app, out *(X509CertificateCollection*)((long)(IntPtr)obj - 88L)))
				{
					X509CertificateCollection x509CertificateCollection = new X509CertificateCollection();
					_ = Sync;
					string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
					string path = Path.Combine(folderPath, ".mono");
					string text = Path.Combine(path, "certs");
					IntPtr intPtr;
					if (!Directory.Exists(text))
					{
						DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
						if (directoryInfo == null)
						{
							string writeablePath = Services.AppConfig.GetWriteablePath(app);
							if (!string.IsNullOrEmpty(writeablePath))
							{
								string message = $"Saving root certs in {writeablePath} ({text} is not writable)";
								Services.Logging.LogMessage(PlatformLogLevel.Debug, message);
								Environment.SetEnvironmentVariable("XDG_CONFIG_HOME", writeablePath);
								((InstallRootCerts)(object)"XDG_CONFIG_HOME").HackRefreshMonoRootStore();
								path2 = writeablePath;
								intPtr = (IntPtr)null;
								goto IL_0173;
							}
						}
					}
					path2 = text;
					intPtr = (IntPtr)0;
					goto IL_0173;
				}
				goto IL_03f9;
			}
			X509CertificateCollection result = null;
			goto IL_0724;
			IL_0240:
			Dictionary<IFirebaseAppPlatform, X509CertificateCollection> _003CAppUtils_003Ek__BackingField;
			bool flag = _003CAppUtils_003Ek__BackingField.TryGetValue((IFirebaseAppPlatform)typeof(IFirebaseAppUtils), out *(X509CertificateCollection*)3);
			int num = 3;
			goto IL_0813;
			IL_0724:
			return result;
			IL_0173:
			X509CertificateCollection value = DecodeDefaultCollection();
			X509CertificateCollection x509CertificateCollection2 = DecodeCollection(app);
			string name = app.Name;
			_003CAppUtils_003Ek__BackingField = (Dictionary<IFirebaseAppPlatform, X509CertificateCollection>)FirebaseHandler.AppUtils;
			IntPtr intPtr2 = (IntPtr)_003CAppUtils_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1319 @ X8_v69 (Il2CppClass<System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0240;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1319 @ X8_v69 (Il2CppClass<System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>>)+B0]");
			object obj5 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1461 @ X11_v41-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFirebaseAppUtils))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1319 @ X8_v69 (Il2CppClass<System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>>)+126]");
				bool flag2 = (long)num3 < 0L;
				bool flag3 = !flag2;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_0240;
			}
			object obj6 = obj5 + 3;
			int num4 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num4;
			flag = (byte)((ulong)(long)(IntPtr)obj7 + 304uL) != 0;
			num = 0;
			goto IL_0813;
			IL_0813:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1517.m_value (System.Boolean) (should have been resolved before IL gen)");
			string b = default(string);
			bool flag4 = string.Equals(name, b);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
			obj4 = 0;
			if (flag4)
			{
				x509CertificateCollection2.AddRange(value);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
				((X509CertificateCollection)0).AddRange(value);
			}
			_installedRoots.set_Item(app, x509CertificateCollection2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
				if (((CollectionBase)0).Count == 0)
				{
					goto IL_03f9;
				}
				string directory = Path.Combine(path2, TrustedRoot);
				InstallDefaultCRLs("Firebase.Platform.cacrl_pem.txt", directory);
				string directory2 = Path.Combine(path2, IntermediateCA);
				InstallDefaultCRLs("Firebase.Platform.caintermediatecrl_pem.txt", directory2);
				int count = x509CertificateCollection2.Count;
				object obj8 = (long)(IntPtr)obj - 92L;
				object arg = (int)obj8;
				string message2 = $"Installing {arg} certs";
				Services.Logging.LogMessage(PlatformLogLevel.Debug, message2);
				X509Store x509Store = new X509Store(TrustedRoot);
				x509Store.Open(OpenFlags.ReadWrite);
				X509Certificate2Collection certificates = x509Store.Certificates;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
				X509CertificateCollection.X509CertificateEnumerator enumerator = ((X509CertificateCollection)0).GetEnumerator();
				Dictionary<IFirebaseAppPlatform, X509CertificateCollection> dictionary = default(Dictionary<IFirebaseAppPlatform, X509CertificateCollection>);
				X509CertificateCollection result2 = default(X509CertificateCollection);
				Dictionary<IFirebaseAppPlatform, X509CertificateCollection> dictionary3 = default(Dictionary<IFirebaseAppPlatform, X509CertificateCollection>);
				while (true)
				{
					string text2;
					IFirebaseAppPlatform key;
					string value2;
					X509Store x509Store2;
					object obj9;
					IntPtr intPtr3;
					int num5;
					IFirebaseAppPlatform firebaseAppPlatform;
					Dictionary<IFirebaseAppPlatform, X509CertificateCollection> dictionary2;
					if (enumerator.MoveNext())
					{
						X509Certificate current = enumerator.Current;
						if (certificates.Contains(current))
						{
							continue;
						}
						if (current != null)
						{
							X509Certificate2 x509Certificate = current as X509Certificate2;
							if (x509Certificate == null)
							{
								InvalidCastException ex = new InvalidCastException();
								text2 = (string)(object)enumerator;
								key = (IFirebaseAppPlatform)typeof(X509Certificate2);
								value2 = null;
								x509Store2 = x509Store;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
								obj9 = 0;
								if ((IntPtr)typeof(X509Certificate2) == (IntPtr)1)
								{
									((Dictionary<IFirebaseAppPlatform, X509CertificateCollection>)(object)ex).set_Item((IFirebaseAppPlatform)typeof(X509Certificate2), (X509CertificateCollection)null);
									intPtr3 = (IntPtr)dictionary;
									dictionary.set_Item((IFirebaseAppPlatform)typeof(X509Certificate2), (X509CertificateCollection)null);
									num5 = -1;
									goto IL_08cb;
								}
								firebaseAppPlatform = (IFirebaseAppPlatform)typeof(X509Certificate2);
								dictionary2 = (Dictionary<IFirebaseAppPlatform, X509CertificateCollection>)(object)ex;
								num5 = -1;
								goto IL_0a0f;
							}
						}
						x509Store.Add((X509Certificate2)current);
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					obj9 = 0;
					obj2 = 523;
					intPtr3 = (IntPtr)null;
					num5 = 0;
					text2 = (string)(object)enumerator;
					x509Store2 = x509Store;
					goto IL_08cb;
					IL_0741:
					TypeLoadException ex2;
					((Dictionary<IFirebaseAppPlatform, X509CertificateCollection>)(object)ex2).set_Item(key, (X509CertificateCollection)(object)value2);
					return result2;
					IL_08cb:
					(text2 as IDisposable)?.Dispose();
					if (num5 + 1 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X26_v1+v165 @ X24_v4 (System.Int32)*4]");
						if ((IntPtr)0 == (IntPtr)523)
						{
							num5 = -1;
							goto IL_0632;
						}
					}
					if (intPtr3 == (IntPtr)0)
					{
						goto IL_0632;
					}
					TypeLoadException ex3 = new TypeLoadException();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					obj9 = 0;
					firebaseAppPlatform = null;
					dictionary2 = (Dictionary<IFirebaseAppPlatform, X509CertificateCollection>)(object)ex3;
					key = null;
					value2 = null;
					goto IL_0a0f;
					IL_0632:
					x509Store2.Close();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
					result = (X509CertificateCollection)0;
					num5++;
					_ = 544;
					goto IL_09db;
					IL_09db:
					Monitor.Exit(obj9);
					if (num5 + 1 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X26_v1+v165 @ X24_v4 (System.Int32)*4]");
						if ((IntPtr)0 == (IntPtr)544)
						{
							break;
						}
					}
					if (intPtr3 == (IntPtr)0)
					{
						break;
					}
					ex2 = new TypeLoadException();
					key = null;
					value2 = null;
					goto IL_0741;
					IL_0a0f:
					bool flag5 = (IntPtr)firebaseAppPlatform != (IntPtr)1;
					ex2 = (TypeLoadException)(object)dictionary2;
					if (flag5)
					{
						goto IL_0741;
					}
					dictionary2.set_Item(key, (X509CertificateCollection)(object)value2);
					intPtr3 = (IntPtr)dictionary3;
					dictionary3.set_Item(key, (X509CertificateCollection)(object)value2);
					result = null;
					goto IL_09db;
				}
				goto IL_0724;
			}
			throw new NullReferenceException();
			IL_03f9:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
			result = (X509CertificateCollection)0;
			obj2 = 544;
			Monitor.Exit(obj4);
			goto IL_0724;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x15EC0C0", Offset = "0x15EC0C0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EFD2D0]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029FA9]) = v37;\nL_0015:\n\tv41 = new System.Object();\n\tSystem.Object::.ctor(v41);\n\tv47.Sync = v41;\n\tv51 = new System.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>();\n\tSystem.Collections.Generic.Dictionary`2<Firebase.Platform.IFirebaseAppPlatform, System.Security.Cryptography.X509Certificates.X509CertificateCollection>::.ctor(v51);\n\tv59._installedRoots = v51;\n\tv60._instance = 0;\n\tv62.TrustedRoot = \"Trust\";\n\tv65.IntermediateCA = \"CA\";\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static InstallRootCerts()
		{
			object sync = new object();
			Sync = sync;
			Dictionary<IFirebaseAppPlatform, X509CertificateCollection> installedRoots = new Dictionary<IFirebaseAppPlatform, X509CertificateCollection>();
			_installedRoots = installedRoots;
			_instance = null;
			TrustedRoot = "Trust";
			IntermediateCA = "CA";
		}
	}
}
