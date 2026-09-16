using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x200001F")]
	public static class LunarConsoleAnalytics
	{
		[Token(Token = "0x400005F")]
		public static readonly string TrackingURL;

		[Token(Token = "0x4000060")]
		public const int kUndefinedValue = int.MinValue;

		[Token(Token = "0x4000061")]
		private static readonly string DefaultPayload;

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x13E23CC", Offset = "0x13E23CC", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EEFD28]);\n\tv19 = *([v18 @ X8_v33]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2028ADB]) = v39;\nL_001E:\n\tv47.TrackingURL = \"https://www.google-analytics.com/collect\";\n\tv53 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v53, \"v=1&t=event\");\n\tv66 = System.Text.StringBuilder::AppendFormat(v53, \"&tid={0}\", \"UA-91768505-1\");\n\tv69 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\tv143 = UnityEngine.WWW::EscapeURL(v69);\n\tv150 = System.Text.StringBuilder::AppendFormat(v53, \"&cid={0}\", v143);\n\tv196 = UnityEngine.SystemInfo::get_operatingSystem();\n\tv198 = UnityEngine.WWW::EscapeURL(v196);\n\tv205 = System.Text.StringBuilder::AppendFormat(v53, \"&ua={0}\", v198);\n\tgoto L_0057;\n\tv211 = *([v207 @ X0_v19 (Il2CppClass<LunarConsolePluginInternal.Constants>)+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_0057;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v207, v204, v201, v203, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv215 = LunarConsolePluginInternal.Constants;\nL_0057:\n\tv221 = UnityEngine.WWW::EscapeURL(v218.Version);\n\tv229 = System.Text.StringBuilder::AppendFormat(v53, \"&av={0}\", v221);\n\tv235 = System.Text.StringBuilder::AppendFormat(v53, \"&ds={0}\", \"player\");\n\tv237 = UnityEngine.Application::get_productName();\n\tv239 = System.String::IsNullOrEmpty(v237);\n\tv241 = v239 == 0;\n\tv242 = ~v241;\n\tif (v242) goto L_008D;\n\tv244 = UnityEngine.Application::get_productName();\n\tv130 = UnityEngine.WWW::EscapeURL(v244);\n\tv246 = v130.m_stringLength > 0x64;\n\tif (v246) goto L_008D;\n\tv262 = System.Text.StringBuilder::AppendFormat(v53, \"&an={0}\", v130);\nL_008D:\n\tv266 = UnityEngine.Application::get_identifier();\n\tv268 = System.String::IsNullOrEmpty(v266);\n\tv270 = v268 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_00B1;\n\tv131 = UnityEngine.WWW::EscapeURL(v266);\n\tv276 = v131.m_stringLength > 0x96;\n\tif (v276) goto L_00B1;\n\tv292 = System.Text.StringBuilder::AppendFormat(v53, \"&aid={0}\", v131);\nL_00B1:\n\tv296 = UnityEngine.Application::get_companyName();\n\tv300 = System.String::IsNullOrEmpty(v296);\n\tv304 = v300 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_00D8;\n\tv309 = UnityEngine.Application::get_companyName();\n\tv132 = UnityEngine.WWW::EscapeURL(v309);\n\tv311 = v132.m_stringLength > 0x96;\n\tif (v311) goto L_00D8;\n\tv328 = System.Text.StringBuilder::AppendFormat(v53, \"&aiid={0}\", v132);\nL_00D8:\n\tv186 = System.Text.StringBuilder::ToString(v53);\n\tv190.DefaultPayload = v186;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LunarConsoleAnalytics()
		{
			TrackingURL = "https://www.google-analytics.com/collect";
			StringBuilder stringBuilder = new StringBuilder("v=1&t=event");
			StringBuilder stringBuilder2 = stringBuilder.AppendFormat("&tid={0}", "UA-91768505-1");
			string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
			string arg = WWW.EscapeURL(deviceUniqueIdentifier);
			StringBuilder stringBuilder3 = stringBuilder.AppendFormat("&cid={0}", arg);
			string operatingSystem = SystemInfo.operatingSystem;
			string arg2 = WWW.EscapeURL(operatingSystem);
			StringBuilder stringBuilder4 = stringBuilder.AppendFormat("&ua={0}", arg2);
			string arg3 = WWW.EscapeURL(Constants.Version);
			StringBuilder stringBuilder5 = stringBuilder.AppendFormat("&av={0}", arg3);
			StringBuilder stringBuilder6 = stringBuilder.AppendFormat("&ds={0}", "player");
			string productName = Application.productName;
			if (!string.IsNullOrEmpty(productName))
			{
				string productName2 = Application.productName;
				string text = WWW.EscapeURL(productName2);
				if (text.Length <= 100)
				{
					StringBuilder stringBuilder7 = stringBuilder.AppendFormat("&an={0}", text);
				}
			}
			string identifier = Application.identifier;
			if (!string.IsNullOrEmpty(identifier))
			{
				string text2 = WWW.EscapeURL(identifier);
				if (text2.Length <= 150)
				{
					StringBuilder stringBuilder8 = stringBuilder.AppendFormat("&aid={0}", text2);
				}
			}
			string companyName = Application.companyName;
			if (!string.IsNullOrEmpty(companyName))
			{
				string companyName2 = Application.companyName;
				string text3 = WWW.EscapeURL(companyName2);
				if (text3.Length <= 150)
				{
					StringBuilder stringBuilder9 = stringBuilder.AppendFormat("&aiid={0}", text3);
				}
			}
			string defaultPayload = stringBuilder.ToString();
			DefaultPayload = defaultPayload;
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x73CDAC", Offset = "0x73CDAC")]
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x13DAE60", Offset = "0x13DAE60", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EE29B8]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, action, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2028ADC]) = v44;\nL_001A:\n\tv48 = new LunarConsolePluginInternal.LunarConsoleAnalytics+<TrackEvent>d__4();\n\tSystem.Object::.ctor(v48);\n\tv48.<>1__state = 0;\n\tv48.category = category;\n\tv48.action = action;\n\tv48.value = value;\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IEnumerator TrackEvent(string category, string action, int value = int.MinValue)
		{
			_003CTrackEvent_003Ed__4 _003CTrackEvent_003Ed__5 = null;
			_003CTrackEvent_003Ed__5._003C_003E1__state = 0;
			_003CTrackEvent_003Ed__5.category = category;
			_003CTrackEvent_003Ed__5.action = action;
			_003CTrackEvent_003Ed__5.value = value;
			return _003CTrackEvent_003Ed__5;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x13E269C", Offset = "0x13E269C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv29 = *([1EF7280]);\n\tv30 = *([v29 @ X8_v18]);\n\tv31 = \"il2cpp_codegen_initialize_method\"(v30, action, value, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028ADD]) = v47;\nL_001F:\n\tgoto L_002B;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.LunarConsoleAnalytics>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v50, action, value, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = LunarConsolePluginInternal.LunarConsoleAnalytics;\nL_002B:\n\tv66 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v66, v62.DefaultPayload);\n\tv73 = UnityEngine.WWW::EscapeURL(category);\n\tv81 = System.Text.StringBuilder::AppendFormat(v66, \"&ec={0}\", v73);\n\tv86 = UnityEngine.WWW::EscapeURL(action);\n\tv93 = System.Text.StringBuilder::AppendFormat(v66, \"&ea={0}\", v86);\n\tv113 = value == 0x80000000;\n\tif (v113) goto L_005F;\n\tv148 = 0xDC3560(&value @ X2 (System.Int32), 0, v86, 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv154 = System.Text.StringBuilder::AppendFormat(v66, \"&ev={0}\", v148);\nL_005F:\n\treturnVal2 = System.Text.StringBuilder::ToString(v66);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string CreatePayload(string category, string action, int value)
		{
			StringBuilder stringBuilder = new StringBuilder(DefaultPayload);
			string arg = WWW.EscapeURL(category);
			StringBuilder stringBuilder2 = stringBuilder.AppendFormat("&ec={0}", arg);
			string arg2 = WWW.EscapeURL(action);
			StringBuilder stringBuilder3 = stringBuilder.AppendFormat("&ea={0}", arg2);
			if (value != 2147483648L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				object arg3 = default(object);
				StringBuilder stringBuilder4 = stringBuilder.AppendFormat("&ev={0}", arg3);
			}
			return stringBuilder.ToString();
		}
	}
}
