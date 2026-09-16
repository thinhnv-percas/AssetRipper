using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200004C")]
	public class CloudCatalogImpl
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200004E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000EA")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000EB")]
			public static Func<char, int, string> _003C_003E9__12_0;

			[Token(Token = "0x40000EC")]
			public static Func<string, string, string> _003C_003E9__12_1;

			[Token(Token = "0x6000133")]
			[Address(RVA = "0xC5C624", Offset = "0xC5C624", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EBD240]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023308]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.CloudCatalogImpl+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000134")]
			[Address(RVA = "0xC5C688", Offset = "0xC5C688", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CCamelCaseToSnakeCase_003Eb__12_0(char a, int b)
			{
				bool flag = char.IsUpper(a);
				if (b >= 1 && flag)
				{
					char c = char.ToLower(a);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
					string text = default(string);
					return "_" + text;
				}
				char c2 = char.ToLower(a);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
				string result = default(string);
				return result;
			}

			internal string _003CCamelCaseToSnakeCase_003Eb__12_1(string a, string b)
			{
				return a + b;
			}
		}

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x10")]
		private IAsyncWebUtil m_AsyncUtil;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x18")]
		private string m_CacheFileName;

		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x20")]
		private ILogger m_Logger;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x28")]
		private string m_CatalogURL;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x30")]
		private string m_StoreName;

		[Token(Token = "0x40000E4")]
		private const int kMaxRetryDelayInSeconds = 300;

		[Token(Token = "0x40000E5")]
		private const string kCatalogURL = "https://catalog.iap.cloud.unity3d.com";

		[Token(Token = "0x6000127")]
		[Address(RVA = "0xC5B610", Offset = "0xC5B610", Length = "0x35C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EB0440]);\n\tv27 = *([v26 @ X8_v50]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023302]) = v46;\nL_001A:\n\tv50 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v50);\n\tgoto L_002C;\n\tv59 = *([v55 @ X0_v4+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002C;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, v51, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002C:\n\tUnityEngine.Object::DontDestroyOnLoad(v50);\n\tv68 = v50 == 0;\n\tif (v68) goto L_00AB;\n\tUnityEngine.Object::set_name(v50, \"Unity IAP\");\n\tUnityEngine.Object::set_hideFlags(v50, 3);\n\tv83 = UnityEngine.GameObject::AddComponent(v50);\n\tv97 = UnityEngine.Application::get_persistentDataPath();\n\tgoto L_0054;\n\tv131 = *([v119 @ X8_v37+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_0054;\n\tv146 = v119;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v146, v82, v78, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0054:\n\tv143 = System.IO.Path::Combine(v97, \"Unity\");\n\tv149 = UnityEngine.Application::get_cloudProjectId();\n\tv218 = System.IO.Path::Combine(v149, \"IAP\");\n\tv233 = System.IO.Path::Combine(v143, v218);\n\tv249 = System.IO.Directory::CreateDirectory(v233);\n\tgoto L_0073;\n\tv263 = *([v250 @ X0_v63+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_0073;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v250, v248, v232, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0073:\n\tv275 = System.IO.Path::Combine(v233, \"catalog.json\");\nL_0076:\n\tv369 = UnityEngine.Application::get_cloudProjectId();\n\tv387 = System.String::Format(\"{0}/{1}\", \"https://catalog.iap.cloud.unity3d.com\", v369);\n\tgoto L_0090;\n\tv395 = *([v391 @ X8_v15+E0]);\n\tv396 = v395 == 0;\n\tv397 = ~v396;\n\tgoto L_0090;\n\tv402 = v391;\n\tv399 = \"il2cpp_codegen_runtime_class_init\"(v402, v385, v199, v190, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0090:\n\tv401 = UnityEngine.Debug::get_unityLogger();\n\tv407 = new UnityEngine.Purchasing.CloudCatalogImpl();\n\tSystem.Object::.ctor(v407);\n\t*([v407 @ X0_v16 (System.Object)+10]) = v367;\n\t*([v407 @ X0_v16 (System.Object)+18]) = v355;\n\t*([v407 @ X0_v16 (System.Object)+20]) = v401;\n\t*([v407 @ X0_v16 (System.Object)+28]) = v387;\n\t*([v407 @ X0_v16 (System.Object)+30]) = storeName;\n\treturn v407;\nL_00AB:\n\tv75 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_0119;\n\tv99 = 0x6D2BC0(v75, 0, v105, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv125 = *([v99 @ X0_v27]);\n\tv106 = *([v125 @ X21_v5 (System.Object)]);\n\tv129 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v125 @ X21_v5 (System.Object)]), v105, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv144 = v129 & 1;\n\tv145 = v144 == 0;\n\tif (v145) goto L_010E;\n\tv150 = 0x6D2490(v129, v106, v105, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00D3;\n\tv234 = *([v221 @ X0_v37+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_00D3;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v221, v127, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00D3:\n\tv242 = UnityEngine.Debug::get_unityLogger();\n\tv245 = v242 == 0;\n\tif (v245) goto L_0115;\n\tgoto L_010A;\n\tv276 = *([v255 @ X8_v28+B0]);\n\tv277 = 0;\n\tv278 = v276 + 8;\n\tv280 = *([v308 @ X11_v6-8]);\n\tv323 = v280 == v258;\n\tif (v323) goto L_0100;\n\tv284 = v309 + 1;\n\tv370 = v284 < v260;\n\tv302 = ~v370;\n\tv282 = v308 + 0x10;\n\tv286 = ~v302;\n\tif (v286) goto L_FFFFFFFF;\n\tv303 = 5;\n\tv304 = v243;\n\tv305 = 0x8909C4(v304, v258, v303, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_010A;\nL_0100:\n\tv371 = *([v308 @ X11_v6]);\n\tv372 = v371 + 5;\n\tv373 = v372 << 4;\n\tv374 = v255 + v373;\n\tv375 = v374 + 0x130;\nL_010A:\n\tUnityEngine.ILogger::Log(v242, \"Unable to cache IAP catalog\", v125);\n\tgoto L_0076;\nL_010E:\n\tv152 = 0x6D1E60(8, *([v125 @ X21_v5 (System.Object)]), v105, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t*([v152 @ X0_v34]) = *([v99 @ X0_v27]);\n\tv106 = 0x1E8A000 + 0x870;\n\tv229 = 0x6D2A00(v152, v106, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0115:\n\tv246 = new System.NullReferenceException();\n\tv109 = 0x6D2490(v246, v106, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0119:\n\tv115 = 0x6D2380(v100, v106, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturnVal1 = 0x846AA4(v115, v106, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal1;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CloudCatalogImpl CreateInstance(string storeName)
		{
			//IL_0139: Expected I, but got O
			GameObject gameObject = new GameObject();
			Object.DontDestroyOnLoad(gameObject);
			if ((object)gameObject != null)
			{
				gameObject.name = "Unity IAP";
				gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
				AsyncWebUtil asyncWebUtil = gameObject.AddComponent<AsyncWebUtil>();
				string persistentDataPath = Application.persistentDataPath;
				string path = Path.Combine(persistentDataPath, "Unity");
				string cloudProjectId = Application.cloudProjectId;
				string path2 = Path.Combine(cloudProjectId, "IAP");
				string text = Path.Combine(path, path2);
				DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
				string text2 = Path.Combine(text, "catalog.json");
				string text3 = text2;
				object obj = asyncWebUtil;
				string cloudProjectId2 = Application.cloudProjectId;
				string text4 = string.Format("{0}/{1}", "https://catalog.iap.cloud.unity3d.com", cloudProjectId2);
				ILogger unityLogger = Debug.unityLogger;
				return null;
			}
			NullReferenceException ex = new NullReferenceException();
			NullReferenceException ex2 = ex;
			IntPtr intPtr = (IntPtr)null;
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			CloudCatalogImpl result = default(CloudCatalogImpl);
			return result;
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0xC5B96C", Offset = "0xC5B96C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_AsyncUtil = util;\n\tthis.m_CacheFileName = cacheFile;\n\tthis.m_Logger = logger;\n\tthis.m_CatalogURL = catalogURL;\n\tthis.m_StoreName = storeName;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal CloudCatalogImpl(IAsyncWebUtil util, string cacheFile, ILogger logger, string catalogURL, string storeName)
		{
			m_AsyncUtil = util;
			m_CacheFileName = cacheFile;
			m_Logger = logger;
			m_CatalogURL = catalogURL;
			m_StoreName = storeName;
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0xC5B9C0", Offset = "0xC5B9C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.CloudCatalogImpl::FetchProducts(this, callback, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FetchProducts(Action<HashSet<ProductDefinition>> callback)
		{
			FetchProducts(callback, 0);
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0xC5B9C8", Offset = "0xC5B9C8", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1F10208]);\n\tv31 = *([v30 @ X8_v19]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, callback, delayInSeconds, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023303]) = v48;\nL_001C:\n\tv52 = new UnityEngine.Purchasing.CloudCatalogImpl+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v52);\n\tv52.<>4__this = this;\n\tv52.callback = callback;\n\tv52.delayInSeconds = delayInSeconds;\n\tv56 = this.m_Logger;\n\tv125 = *([v56 @ X20_v3 (UnityEngine.ILogger)]);\n\tv132 = *([v125 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v132) goto L_004F;\n\tv235 = *([v125 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_003A:\n\tv241 = *([v235 @ X11_v12-8]) == UnityEngine.ILogger;\n\tif (v241) goto L_0052;\n\tv236 = v236 + 1;\n\tv246 = v236 < *([v125 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv155 = ~v246;\n\tv235 = v235 + 0x10;\n\tv139 = ~v155;\n\tif (v139) goto L_003A;\nL_004F:\n\tv253 = 0x8909C4(v56, UnityEngine.ILogger, 4, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_005A;\nL_0052:\n\tv248 = *([v235 @ X11_v12]) + 4;\n\tv249 = v248 << 4;\n\tv250 = v125 + v249;\n\tv253 = v250 + 0x130;\nL_005A:\n\t*([v253 @ X0_v7])(v259, v56, \"Fetching IAP cloud catalog...\", *([v253 @ X0_v7+8]), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv263 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v263, v52, Il2CppMethodInfo);\n\tv111 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v111, v52, Il2CppMethodInfo);\n\tgoto L_00AF;\n\tv277 = *([v273 @ X8_v13+B0]);\n\tv278 = 0;\n\tv279 = v277 + 8;\n\tv281 = *([v317 @ X11_v7-8]);\n\tv323 = v281 == v276;\n\tif (v323) goto L_009B;\n\tv303 = v318 + 1;\n\tv328 = v303 < v275;\n\tv299 = ~v328;\n\tv301 = v317 + 0x10;\n\tv283 = ~v299;\n\tif (v283) goto L_FFFFFFFF;\n\tv304 = v119;\n\tv305 = 0;\n\tv306 = 0x8909C4(v304, v276, v305, v64, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00AF;\nL_009B:\n\tv329 = *([v317 @ X11_v7]);\n\tv330 = v329 << 4;\n\tv331 = v273 + v330;\n\tv332 = v331 + 0x130;\nL_00AF:\n\tUnityEngine.Purchasing.IAsyncWebUtil::Get(this.m_AsyncUtil, this.m_CatalogURL, v263, v111, 0x1E);\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void FetchProducts(Action<HashSet<ProductDefinition>> callback, int delayInSeconds)
		{
			//IL_0040: Expected I, but got O
			//IL_007b: Expected O, but got I
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_011f: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_00c7: Expected O, but got I
			ILogger logger = m_Logger;
			IntPtr intPtr = (IntPtr)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X11_v12-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e0;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0176;
			IL_00e0:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0176;
			IL_0176:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v253 @ X0_v7] (should have been resolved before IL gen)");
			Action<string> responseHandler = delegate(string response)
			{
				//IL_001f: Expected I, but got O
				//IL_0520: Expected O, but got I
				//IL_005a: Expected O, but got I
				//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e1: Expected O, but got Unknown
				//IL_00fe: Expected O, but got I
				//IL_010d: Expected O, but got I
				//IL_00a6: Expected O, but got I
				//IL_047a: Expected O, but got I4
				//IL_04a6: Expected O, but got I4
				//IL_0230: Expected I, but got O
				//IL_026b: Expected O, but got I
				//IL_033d: Expected I, but got O
				//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
				//IL_02f2: Expected O, but got Unknown
				//IL_030f: Expected O, but got I
				//IL_031e: Expected O, but got I
				//IL_02b7: Expected O, but got I
				//IL_0378: Expected O, but got I
				//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_03ff: Expected O, but got Unknown
				//IL_041c: Expected O, but got I
				//IL_042b: Expected O, but got I
				//IL_03c4: Expected O, but got I
				CloudCatalogImpl cloudCatalogImpl = this;
				ILogger logger2 = cloudCatalogImpl.m_Logger;
				IntPtr intPtr2 = (IntPtr)logger2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X9_v5 (Il2CppClass<UnityEngine.ILogger>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00bf;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X9_v5 (Il2CppClass<UnityEngine.ILogger>)+B0]");
				object obj5 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X11_v21-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILogger))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X9_v5 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj5 = (long)(IntPtr)obj5 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_00bf;
				}
				object obj6 = obj5 + 4;
				int num6 = (int)((long)(IntPtr)obj6 << 4);
				object obj7 = (long)intPtr2 + (long)num6;
				object obj8 = (long)(IntPtr)obj7 + 304L;
				goto IL_0510;
				IL_02d0:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0563;
				IL_0563:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v471 @ X0_v25] (should have been resolved before IL gen)");
				CloudCatalogImpl cloudCatalogImpl2 = this;
				ILogger logger3 = cloudCatalogImpl2.m_Logger;
				IntPtr intPtr3 = (IntPtr)logger3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_03dd;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+B0]");
				object obj9 = 0L + 8L;
				int num7 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ X11_v11-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILogger))
					{
						break;
					}
					num7++;
					int num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag5 = (long)num8 < 0L;
					bool flag6 = !flag5;
					obj9 = (long)(IntPtr)obj9 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_03dd;
				}
				object obj10 = obj9 + 4;
				int num9 = (int)((long)(IntPtr)obj10 << 4);
				object obj11 = (long)intPtr3 + (long)num9;
				object obj12 = (long)(IntPtr)obj11 + 304L;
				goto IL_05a6;
				IL_05a6:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v539 @ X0_v28] (should have been resolved before IL gen)");
				HashSet<ProductDefinition> obj13 = TryLoadCachedCatalog();
				callback(obj13);
				return;
				IL_03dd:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_05a6;
				IL_00bf:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0510;
				IL_0510:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X0_v15+8]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ X0_v15] (should have been resolved before IL gen)");
				CloudCatalogImpl cloudCatalogImpl3 = this;
				HashSet<ProductDefinition> obj15 = ParseProductsFromJSON(response, cloudCatalogImpl3.m_StoreName);
				TryPersistCatalog(response);
				if (callback != null)
				{
					callback(obj15);
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
					string text = default(string);
					bool flag7 = (IntPtr)text != (IntPtr)1;
					NullReferenceException ex2 = ex;
					if (!flag7)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj17 = default(object);
						object obj16 = obj17;
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj18 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj18 & 1uL) != 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							CloudCatalogImpl cloudCatalogImpl4 = this;
							ILogger logger4 = cloudCatalogImpl4.m_Logger;
							IntPtr intPtr4 = (IntPtr)logger4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_02d0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+B0]");
							object obj19 = 0L + 8L;
							int num10 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ X11_v16-8]");
								if ((IntPtr)0 == (IntPtr)typeof(ILogger))
								{
									break;
								}
								num10++;
								int num11 = num10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+126]");
								bool flag8 = (long)num11 < 0L;
								bool flag9 = !flag8;
								obj19 = (long)(IntPtr)obj19 + 16L;
								if (!flag9)
								{
									continue;
								}
								goto IL_02d0;
							}
							object obj20 = obj19 + 7;
							int num12 = (int)((long)(IntPtr)obj20 << 4);
							object obj21 = (long)intPtr4 + (long)num12;
							object obj22 = (long)(IntPtr)obj21 + 304L;
							goto IL_0563;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj24 = default(object);
						object obj23 = obj24;
						text = (string)(32022528 + 2160);
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						obj14 = 0;
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				}
			};
			Action action = default(Action);
			Action<string> errorHandler = delegate
			{
				//IL_01f5: Expected I, but got O
				//IL_007c: Expected I, but got O
				//IL_0230: Expected O, but got I
				//IL_00b7: Expected O, but got I
				//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
				//IL_02b7: Expected O, but got Unknown
				//IL_02d4: Expected O, but got I
				//IL_02e3: Expected O, but got I
				//IL_027c: Expected O, but got I
				//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
				//IL_02f6: Expected O, but got Unknown
				//IL_0313: Expected O, but got I
				//IL_0322: Expected O, but got I
				//IL_0103: Expected O, but got I
				HashSet<ProductDefinition> hashSet = TryLoadCachedCatalog();
				if (hashSet != null && hashSet.Count >= 1)
				{
					CloudCatalogImpl cloudCatalogImpl = this;
					ILogger logger2 = cloudCatalogImpl.m_Logger;
					IntPtr intPtr2 = (IntPtr)logger2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X8_v23 (Il2CppClass<UnityEngine.ILogger>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_011c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X8_v23 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					object obj5 = 0L + 8L;
					int num4 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X11_v12-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILogger))
						{
							break;
						}
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X8_v23 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag3 = (long)num5 < 0L;
						bool flag4 = !flag3;
						obj5 = (long)(IntPtr)obj5 + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_011c;
					}
					object obj6 = obj5 + 4;
					int num6 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)intPtr2 + (long)num6;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_0361;
				}
				int val = delayInSeconds << 1;
				int num7 = Math.Min(300, delayInSeconds = Math.Max(5, val));
				CloudCatalogImpl cloudCatalogImpl2 = this;
				delayInSeconds = num7;
				IAsyncWebUtil asyncUtil = cloudCatalogImpl2.m_AsyncUtil;
				if (action == null)
				{
					Action action2 = delegate
					{
						FetchProducts(callback, delayInSeconds);
					};
					action = action2;
				}
				IntPtr intPtr3 = (IntPtr)asyncUtil;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ X8_v13 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0295;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ X8_v13 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+B0]");
				object obj9 = 0L + 8L;
				int num8 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IAsyncWebUtil))
					{
						break;
					}
					num8++;
					int num9 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ X8_v13 (Il2CppClass<UnityEngine.Purchasing.IAsyncWebUtil>)+126]");
					bool flag5 = (long)num9 < 0L;
					bool flag6 = !flag5;
					obj9 = (long)(IntPtr)obj9 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_0295;
				}
				object obj10 = obj9 + 2;
				int num10 = (int)((long)(IntPtr)obj10 << 4);
				object obj11 = (long)intPtr3 + (long)num10;
				object obj12 = (long)(IntPtr)obj11 + 304L;
				goto IL_039a;
				IL_039a:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v398 @ X0_v16] (should have been resolved before IL gen)");
				return;
				IL_0295:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_039a;
				IL_0361:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v329 @ X0_v24] (should have been resolved before IL gen)");
				callback(hashSet);
				return;
				IL_011c:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0361;
			};
			m_AsyncUtil.Get(m_CatalogURL, responseHandler, errorHandler);
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0xC5BBB4", Offset = "0xC5BBB4", Length = "0x5D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001E;\n\tv35 = *([1EF6C40]);\n\tv36 = *([v35 @ X8_v91]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, storeName, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023304]) = v54;\nL_001E:\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-58]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-68]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-78]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\t*([v21 @ X29-88]) = 0;\n\t*([v21 @ X29-B0]) = &v56 @ stack_-D0;\n\tv61 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v61);\n\tv68 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tgoto L_FFFFFFFF;\n\tv178 = v178_asT == 0;\n\tif (v178) goto L_01A7;\n\tv256 = &v21 @ X29 - 0x58;\n\tv300 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v68, \"products\", v256);\n\tv408 = *([v21 @ X29-58]) == 0;\n\tif (v408) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0087;\n\tv533 = v533_asT == 0;\n\tif (v533) goto L_FFFFFFFF;\n\tgoto L_0087;\nL_0087:\n\tv287 = UnityEngine.Purchasing.CloudCatalogImpl::CamelCaseToSnakeCase(storeName);\n\tv576 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v291);\n\t*([v21 @ X29-60]) = *([v21 @ X29-98]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-A8]);\nL_009A:\n\tv672 = &v21 @ X29 - 0x70;\n\tv635 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(v672);\n\tv637 = v635 == 0;\n\tif (v637) goto L_0199;\n\tgoto L_FFFFFFFF;\n\tv881 = v881_asT == 0;\n\tif (v881) goto L_01A0;\n\tv925 = &v21 @ X29 - 0x78;\n\tv927 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(*([v21 @ X29-60]), \"id\", v925);\n\tv968 = &v21 @ X29 - 0x80;\n\tv970 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(*([v21 @ X29-60]), \"store_ids\", v968);\n\tv319 = &v21 @ X29 - 0x88;\n\tv350 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(*([v21 @ X29-60]), \"type\", v319);\n\tv982 = *([v21 @ X29-80]) == 0;\n\tif (v982) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00FB;\n\tv1022 = v1022_asT == 0;\n\tif (v1022) goto L_FFFFFFFF;\n\tgoto L_00FB;\nL_00FB:\n\tv455 = *([v21 @ X29-78]);\n\tv352 = *([v21 @ X29-78]) == 0;\n\tif (v352) goto L_010B;\n\tv326 = *([v455 @ X21_v20 (System.String)]) != System.String;\n\tif (v326) goto L_01A9;\nL_010B:\n\tv1045 = v308 == 0;\n\tif (v1045) goto L_0136;\n\tv1051 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v308, v287);\n\tv1065 = v1051 == 0;\n\tif (v1065) goto L_0136;\n\t*([v21 @ X29-90]) = 0;\n\tv679 = &v21 @ X29 - 0x90;\n\tv1088 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v308, v287, v679);\n\tv400 = *([v21 @ X29-90]);\n\tv402 = *([v21 @ X29-90]) == 0;\n\tif (v402) goto L_0136;\n\tv377 = *([v400 @ X0_v101 (System.String)]) != System.String;\n\tif (v377) goto L_01B1;\nL_0136:\n\tgoto L_013E;\n\tv1077 = *([v1071 @ X0_v81+E0]);\n\tv1078 = v1077 == 0;\n\tv1079 = ~v1078;\n\tgoto L_013E;\n\tv1081 = \"il2cpp_codegen_runtime_class_init\"(v1071, v1061, v422, v424, v302, v41, v42, v43, v192, v45, v46, v47, v48, v49, v50, v51);\nL_013E:\n\tv1086 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.ProductType);\n\tv412 = *([v21 @ X29-88]);\n\tgoto L_014D;\n\tv1095 = *([v1091 @ X0_v85+E0]);\n\tv1096 = v1095 == 0;\n\tv1097 = ~v1096;\n\tif (v1097) goto L_014D;\n\tv1098 = \"il2cpp_codegen_runtime_class_init\"(v1091, v1085, v422, v424, v302, v41, v42, v43, v192, v45, v46, v47, v48, v49, v50, v51);\nL_014D:\n\tv453 = *([v21 @ X29-88]) == 0;\n\tif (v453) goto L_015F;\n\tv428 = *([v412 @ X23_v14 (System.String)]) != System.String;\n\tif (v428) goto L_01AB;\nL_015F:\n\tv914 = System.Enum::Parse(v1086, *([v21 @ X29-88]));\n\tv892 = v892_asT == 0;\n\tif (v892) goto L_01A3;\n\tv1109 = \"il2cpp_vm_object_unbox\"(v914, UnityEngine.Purchasing.ProductType, 0, v424, 0, v41, v42, v43, *([v21 @ X29-A8]), v45, v46, v47, v48, v49, v50, v51);\n\tv489 = *([v21 @ X29-78]);\n\tv505 = new UnityEngine.Purchasing.ProductDefinition();\n\tv506 = *([v21 @ X29-78]) == 0;\n\tif (v506) goto L_018F;\n\tv493 = *([v489 @ X24_v12 (System.String)]) != System.String;\n\tif (v493) goto L_01AD;\nL_018F:\n\tUnityEngine.Purchasing.ProductDefinition::.ctor(v505, *([v21 @ X29-78]), v455, *([v1109 @ X0_v89]));\n\tv666 = System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::Add(v61, v505);\n\tgoto L_009A;\nL_0199:\n\tv628 = *([v21 @ X29-B0]);\n\t*([v628 @ X9_v12]) = 0x122;\n\tgoto L_01DE;\nL_01A0:\n\tthrow System.InvalidCastException;\n\tv865 = new System.NullReferenceException();\nL_01A3:\n\tv920 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tv232 = new System.NullReferenceException();\nL_01A7:\n\tthrow System.InvalidCastException;\nL_01A9:\n\tthrow System.InvalidCastException;\nL_01AB:\n\tthrow System.InvalidCastException;\nL_01AD:\n\tv155 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tv296 = new System.NullReferenceException();\nL_01B1:\n\tv407 = new System.InvalidCastException();\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_020C;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_020C;\n\tgoto L_020C;\n\tgoto L_020C;\n\tgoto L_020C;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\n\tgoto L_01D4;\nL_01D4:\n\tv519 = System.String != 1;\n\tif (v519) goto L_0216;\n\tv538 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v407, v557, v679);\n\tv640 = v538.m_value;\n\tv550 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v538, v557, v679);\nL_01DE:\n\tv647 = &v21 @ X29 - 0x70;\n\tv648 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v647);\n\tv673 = v638 + 1;\n\tv675 = v673 == 0;\n\tif (v675) goto L_01F8;\n\tv753 = ~v640;\n\tif (v753) goto L_020A;\n\tv790 = *([v21 @ X29-B0]);\n\tv796 = *([v790 @ X8_v14+v638 @ X21_v2 (System.Int32)*4]) == 0x122;\n\tif (v796) goto L_020A;\nL_01F7:\n\tthrow System.TypeLoadException;\nL_01F8:\n\tv780 = ~v640;\n\tv781 = ~v780;\n\tif (v781) goto L_01F7;\nL_020A:\n\treturn v61;\n\tgoto L_020C;\nL_020C:\n\tX20 = X0;\nL_0216:\n\tv548 = System.String != 1;\n\tif (v548) goto L_0241;\n\tv552 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v407, System.String, v679);\n\tv568 = v552.m_value;\n\tv583 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v568 @ X19_v5 (System.Exception)]), v679, Il2CppMethodInfo, 0, v41, v42, v43, *([v21 @ X29-A8]), v45, v46, v47, v48, v49, v50, v51);\n\tv649 = v583 & 1;\n\tv562 = v649 == 0;\n\tif (v562) goto L_0237;\n\tv678 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v583, *([v568 @ X19_v5 (System.Exception)]), v679);\n\tv785 = new System.Runtime.Serialization.SerializationException();\n\tSystem.Runtime.Serialization.SerializationException::.ctor(v785, \"Error parsing JSON\", v568);\n\tthrow v785;\nL_0237:\n\tv691 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(8, *([v568 @ X19_v5 (System.Exception)]), v679);\n\tv691.m_value = *([v552 @ X0_v22 (System.Boolean)]);\n\tv558 = 0x1E8A000 + 0x870;\n\tv787 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v691, v558, 0);\n\tv560 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v787, v558, 0);\nL_0241:\n\tv570 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v563, v557, v679);\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v570, v557, v679);\n\treturn returnVal1;\n// 395 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static HashSet<ProductDefinition> ParseProductsFromJSON(string json, string storeName)
		{
			//IL_00f7: Expected O, but got I4
			//IL_00aa: Expected O, but got I
			//IL_086c: Expected O, but got I
			//IL_051a: Expected O, but got I
			//IL_0523: Expected O, but got I4
			//IL_08a5: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_017a: Expected O, but got I
			//IL_01a7: Expected O, but got I
			//IL_0621: Expected O, but got I
			//IL_01d9: Expected O, but got I
			//IL_0833: Expected O, but got I
			//IL_0226: Expected O, but got I
			//IL_03c2: Expected O, but got I
			//IL_02c4: Expected O, but got I4
			//IL_042b: Expected O, but got I
			//IL_0311: Expected O, but got I4
			//IL_0325: Expected O, but got I
			//IL_0441: Expected I4, but got O
			//IL_037b: Expected I, but got O
			//IL_047d: Expected O, but got I
			//IL_0496: Expected I4, but got O
			//IL_0496: Expected O, but got I
			//IL_039f: Expected O, but got I
			//IL_079d: Expected O, but got I
			//IL_07b2: Expected O, but got I
			//IL_07b2: Expected O, but got I4
			//IL_07b6: Expected O, but got I4
			//IL_05bf: Expected O, but got I
			//IL_05e1: Expected O, but got I
			//IL_05e1: Expected O, but got I4
			//IL_069d: Expected O, but got I4
			//IL_0729: Expected O, but got I4
			//IL_0749: Expected O, but got I4
			//IL_0757: Expected O, but got I4
			//IL_076e: Expected O, but got I4
			//IL_077f: Expected I, but got O
			//IL_0787: Expected O, but got I4
			object obj = obj;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			HashSet<ProductDefinition> hashSet = new HashSet<ProductDefinition>();
			object obj2 = MiniJson.JsonDecode(json);
			Dictionary<string, object> dictionary = obj2 as Dictionary<string, object>;
			if (dictionary != null)
			{
				bool flag = ((Dictionary<string, object>)obj2).TryGetValue("products", out *(object*)((long)(IntPtr)obj - 88L));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
				int num;
				if ((IntPtr)0 == (IntPtr)0)
				{
					num = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
					List<object> list = 0 as List<object>;
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
						num = 0;
					}
					else
					{
						num = 0;
					}
				}
				string key = CamelCaseToSnakeCase(storeName);
				object enumerator = ((List<object>)num).GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
				_ = 0;
				IntPtr intPtr2;
				InvalidCastException ex;
				object obj5 = default(object);
				ref object value4;
				while (true)
				{
					object obj3 = (long)(IntPtr)obj - 112L;
					bool flag12;
					int num3;
					if (((List<object>.Enumerator*)obj3)->MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
						Dictionary<string, object> dictionary2 = 0 as Dictionary<string, object>;
						if (dictionary2 != null)
						{
							ref object value = ref *(object*)((long)(IntPtr)obj - 120L);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
							bool flag2 = ((Dictionary<string, object>)0).TryGetValue("id", out value);
							ref object value2 = ref *(object*)((long)(IntPtr)obj - 128L);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
							bool flag3 = ((Dictionary<string, object>)0).TryGetValue("store_ids", out value2);
							ref object value3 = ref *(object*)((long)(IntPtr)obj - 136L);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
							bool flag4 = ((Dictionary<string, object>)0).TryGetValue("type", out value3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
							int num2;
							if ((IntPtr)0 == (IntPtr)0)
							{
								num2 = 0;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
								Dictionary<string, object> dictionary3 = 0 as Dictionary<string, object>;
								if (dictionary3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
									num2 = 0;
								}
								else
								{
									num2 = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
							string text = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
							if ((IntPtr)0 == (IntPtr)0 || (object)text.GetType() == typeof(string))
							{
								bool flag5 = num2 == 0;
								IntPtr intPtr = (IntPtr)0;
								if (!flag5)
								{
									bool flag6 = ((Dictionary<string, object>)num2).ContainsKey(key);
									bool flag7 = !flag6;
									intPtr = (IntPtr)0;
									if (!flag7)
									{
										_ = 0;
										value4 = ref *(object*)((long)(IntPtr)obj - 144L);
										bool flag8 = ((Dictionary<string, object>)num2).TryGetValue(key, out value4);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
										string text2 = (string)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
										bool flag9 = (IntPtr)0 == (IntPtr)0;
										intPtr = (IntPtr)0;
										if (!flag9)
										{
											bool flag10 = (object)text2.GetType() != typeof(string);
											intPtr2 = (IntPtr)typeof(string);
											if (flag10)
											{
												ex = new InvalidCastException();
												if ((IntPtr)typeof(string) != (IntPtr)1)
												{
													break;
												}
												bool flag11 = ((Dictionary<string, object>)(object)ex).TryGetValue((string)(long)intPtr2, out value4);
												flag12 = ((bool*)(flag11 ? 1 : 0))->m_value;
												bool flag13 = ((Dictionary<string, object>)flag11).TryGetValue((string)(long)intPtr2, out value4);
												num3 = -1;
												goto IL_0896;
											}
											intPtr = (IntPtr)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
											text = (string)0;
										}
									}
								}
								Type typeFromHandle = typeof(ProductType);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
								string text3 = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
								if ((IntPtr)0 == (IntPtr)0 || (object)text3.GetType() == typeof(string))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
									object obj4 = Enum.Parse(typeFromHandle, (string)0);
									if ((int)((obj4 is ProductType) ? obj4 : null) != 0)
									{
										Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
										string text4 = (string)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
										ProductDefinition item = new ProductDefinition((string)0, text, (ProductType)obj5);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
										if ((IntPtr)0 == (IntPtr)0 || (object)text4.GetType() == typeof(string))
										{
											bool flag14 = hashSet.Add(item);
											continue;
										}
										InvalidCastException ex2 = new InvalidCastException();
										throw new NullReferenceException();
									}
									InvalidCastException ex3 = new InvalidCastException();
									throw new NullReferenceException();
								}
								throw new InvalidCastException();
							}
							throw new InvalidCastException();
						}
						throw new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
					object obj6 = 0;
					obj6 = 290;
					num3 = 0;
					flag12 = false;
					goto IL_0896;
					IL_0646:
					throw new TypeLoadException();
					IL_0896:
					object obj7 = (long)(IntPtr)obj - 112L;
					((List<object>.Enumerator*)obj7)->Dispose();
					if (num3 + 1 != 0)
					{
						if (flag12)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ X8_v14+v638 @ X21_v2 (System.Int32)*4]");
							if ((IntPtr)0 != (IntPtr)290)
							{
								goto IL_0646;
							}
						}
					}
					else if (flag12)
					{
						goto IL_0646;
					}
					return hashSet;
				}
				bool flag15 = (IntPtr)typeof(string) != (IntPtr)1;
				InvalidCastException ex4 = ex;
				if (!flag15)
				{
					bool flag16 = ((Dictionary<string, object>)(object)ex).TryGetValue((string)(object)typeof(string), out value4);
					Exception ex5 = (Exception)((bool*)(flag16 ? 1 : 0))->m_value;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj9 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj9 & 1uL) != 0)
					{
						bool flag17 = ((Dictionary<string, object>)obj9).TryGetValue((string)(object)ex5, out value4);
						SerializationException ex6 = new SerializationException("Error parsing JSON", ex5);
						value4 = ref *(object*)null;
						throw ex6;
					}
					bool flag18 = ((Dictionary<string, object>)8).TryGetValue((string)(object)ex5, out value4);
					((bool*)(flag18 ? 1 : 0))->m_value = flag16;
					string text5 = (string)(32022528 + 2160);
					bool flag19 = ((Dictionary<string, object>)flag18).TryGetValue(text5, out *(object*)null);
					bool flag20 = ((Dictionary<string, object>)flag19).TryGetValue(text5, out *(object*)null);
					value4 = ref *(object*)null;
					intPtr2 = (IntPtr)text5;
					ex4 = (InvalidCastException)flag19;
				}
				bool flag21 = ((Dictionary<string, object>)(object)ex4).TryGetValue((string)(long)intPtr2, out value4);
				return (HashSet<ProductDefinition>)((Dictionary<string, object>)flag21).TryGetValue((string)(long)intPtr2, out value4);
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0xC5C184", Offset = "0xC5C184", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F092A8]);\n\tv23 = *([v22 @ X8_v34]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023305]) = v42;\nL_001B:\n\tgoto L_0023;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.CloudCatalogImpl+<>c>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0023;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = UnityEngine.Purchasing.CloudCatalogImpl+<>c;\nL_0023:\n\tv81 = v56.<>9__12_0;\n\tv58 = v56.<>9__12_0 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0048;\n\tgoto L_0036;\n\tv89 = *([v52 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.CloudCatalogImpl+<>c>)+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0036;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv121 = UnityEngine.Purchasing.CloudCatalogImpl+<>c;\n\tv96 = *([v121 @ X8_v30+B8]);\nL_0036:\n\tv76 = new System.Func`3<System.Char, System.Int32, System.String>();\n\tSystem.Func`3<System.Char, System.Int32, System.String>::.ctor(v76, v95.<>9, Il2CppMethodInfo);\n\tv80.<>9__12_0 = v76;\nL_0048:\n\tv88 = System.Linq.Enumerable::Select(s, v81);\n\tgoto L_0057;\n\tv108 = *([v100 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.CloudCatalogImpl+<>c>)+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tgoto L_0057;\n\tv123 = v100;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v123, v86, v87, v66, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv116 = UnityEngine.Purchasing.CloudCatalogImpl+<>c;\nL_0057:\n\tv146 = v117.<>9__12_1;\n\tv119 = v117.<>9__12_1 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0084;\n\tgoto L_006B;\n\tv160 = *([v115 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.CloudCatalogImpl+<>c>)+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_006B;\n\tv172 = v115;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v172, v86, v87, v66, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv168 = UnityEngine.Purchasing.CloudCatalogImpl+<>c;\n\tv164 = *([v168 @ X8_v21+B8]);\nL_006B:\n\tv141 = new System.Func`3<System.String, System.String, System.String>();\n\tSystem.Func`3<System.String, System.String, System.String>::.ctor(v141, v163.<>9, Il2CppMethodInfo);\n\tv145.<>9__12_1 = v141;\nL_0084:\n\treturnVal1 = System.Linq.Enumerable::Aggregate(v88, v146);\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string CamelCaseToSnakeCase(string s)
		{
			Func<char, int, string> selector = _003C_003Ec._003C_003E9__12_0;
			if (_003C_003Ec._003C_003E9__12_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__12_0 = delegate(char a, int b)
				{
					bool flag = char.IsUpper(a);
					if (b >= 1 && flag)
					{
						char c = char.ToLower(a);
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
						string text = default(string);
						return "_" + text;
					}
					char c2 = char.ToLower(a);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
					string result = default(string);
					return result;
				});
			}
			IEnumerable<string> source = s.Select(selector);
			Func<string, string, string> func = _003C_003Ec._003C_003E9__12_1;
			if (_003C_003Ec._003C_003E9__12_1 == null)
			{
				func = (_003C_003Ec._003C_003E9__12_1 = (string a, string b) => a + b);
			}
			return source.Aggregate(func);
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0xC5C31C", Offset = "0xC5C31C", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED0738]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, response, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023306]) = v41;\nL_0016:\n\tv43 = this.m_CacheFileName == 0;\n\tif (v43) goto L_0021;\n\tSystem.IO.File::WriteAllText(this.m_CacheFileName, response);\nL_0021:\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0084;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX19 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0078;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X20+20]);\n\tif (TEMP) goto L_0080;\n\tX8 = *([X20]);\n\tX9 = *([1EA8610]);\n\tX1 = *([X9]);\n\tX10 = *([1F04DD8]);\n\tX9 = *([X8+126]);\n\tX21 = *([X10]);\n\tif (TEMP) goto L_0063;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_004B:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0067;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_004B;\nL_0063:\n\tX2 = 0 | 7;\n\tX0 = X20;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_006C;\nL_0067:\n\tX9 = *([X11]);\n\tX9 = X9 + 7;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_006C:\n\tX4 = *([X0]);\n\tX3 = *([X0+8]);\n\tX0 = X20;\n\tX2 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX21 = stack[0];\n\t// 118 ShiftStack 48\n\t// 119 IndirectJump X4, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\nL_0078:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0080:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0084:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TryPersistCatalog(string response)
		{
			if (m_CacheFileName != null)
			{
				File.WriteAllText(m_CacheFileName, response);
			}
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xC5C484", Offset = "0xC5C484", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF3C38]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023307]) = v40;\nL_0015:\n\tv42 = this.m_CacheFileName == 0;\n\tif (v42) goto L_0077;\n\tv44 = System.IO.File::Exists(this.m_CacheFileName);\n\tv48 = v44 == 0;\n\tif (v48) goto L_0077;\n\tv60 = System.IO.File::ReadAllText(this.m_CacheFileName);\n\tv64 = UnityEngine.Purchasing.CloudCatalogImpl::ParseProductsFromJSON(v60, this.m_StoreName);\n\tgoto L_0084;\n\tgoto L_0024;\nL_0024:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0091;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0085;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X19+20]);\n\tif (TEMP) goto L_008D;\n\tX8 = *([X19]);\n\tX9 = *([1EA8610]);\n\tX1 = *([X9]);\n\tX10 = *([1EEFF48]);\n\tX9 = *([X8+126]);\n\tX21 = *([X10]);\n\tif (TEMP) goto L_0065;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_004D:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0069;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_004D;\nL_0065:\n\tX2 = 0 | 7;\n\tX0 = X19;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_006E;\nL_0069:\n\tX9 = *([X11]);\n\tX9 = X9 + 7;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_006E:\n\tX8 = *([X0]);\n\tX3 = *([X0+8]);\n\tX0 = X19;\n\tX1 = X21;\n\tX2 = X20;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0077:\n\tv52 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v52);\nL_0084:\n\treturn v67;\nL_0085:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008D:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0091:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private HashSet<ProductDefinition> TryLoadCachedCatalog()
		{
			if (m_CacheFileName != null && File.Exists(m_CacheFileName))
			{
				string json = File.ReadAllText(m_CacheFileName);
				return ParseProductsFromJSON(json, m_StoreName);
			}
			return new HashSet<ProductDefinition>();
		}
	}
}
