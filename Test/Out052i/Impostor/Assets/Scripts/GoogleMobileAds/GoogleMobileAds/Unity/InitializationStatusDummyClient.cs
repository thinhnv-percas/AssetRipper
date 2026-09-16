using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Unity
{
	[Token(Token = "0x200000C")]
	public class InitializationStatusDummyClient : IInitializationStatusClient
	{
		[Token(Token = "0x6000046")]
		[Address(RVA = "0x13407DC", Offset = "0x13407DC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = GoogleMobileAds.Api.AdapterStatus;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, className, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = \"Ready\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, className, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A36753]) = v39;\nL_0019:\n\tv42 = new GoogleMobileAds.Api.AdapterStatus();\n\tSystem.Object::.ctor(v42);\n\tv42.<Description>k__BackingField = \"Ready\";\n\tv42.<InitializationState>k__BackingField = 1;\n\tv42.<Latency>k__BackingField = 0;\n\treturn v42;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdapterStatus getAdapterStatusForClassName(string className)
		{
			AdapterStatus adapterStatus = null;
			adapterStatus.Description = "Ready";
			adapterStatus.InitializationState = AdapterState.Ready;
			adapterStatus.Latency = 0;
			return adapterStatus;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x1340898", Offset = "0x1340898", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = System.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv52 = \"ExampleClass\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A36754]) = v39;\nL_001E:\n\tv41 = new System.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>::.ctor(v41);\n\tv50 = GoogleMobileAds.Unity.InitializationStatusDummyClient::getAdapterStatusForClassName(v41, Il2CppMethodInfo);\n\tSystem.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>::Add(v41, \"ExampleClass\", v50);\n\treturn v41;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Dictionary<string, AdapterStatus> getAdapterStatusMap()
		{
			//IL_0031: Expected O, but got I
			Dictionary<string, AdapterStatus> dictionary = new Dictionary<string, AdapterStatus>();
			AdapterStatus adapterStatusForClassName = ((InitializationStatusDummyClient)(object)dictionary).getAdapterStatusForClassName((string)0);
			dictionary.Add("ExampleClass", adapterStatusForClassName);
			return dictionary;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x1340948", Offset = "0x1340948", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InitializationStatusDummyClient()
		{
		}
	}
}
