using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.UI;

namespace GoogleMobileAds.Unity
{
	[Token(Token = "0x200000B")]
	public class BaseAdDummyClient
	{
		[Token(Token = "0x4000015")]
		protected static DummyAdBehaviour AdBehaviour;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x10")]
		protected internal GameObject prefabAd;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x18")]
		protected internal GameObject dummyAd;

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x133F688", Offset = "0x133F688", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, prefabName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv44 = UnityEngine.GameObject;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, prefabName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = UnityEngine.Object;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, prefabName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv66 = \"No Prefab found\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, prefabName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3674E]) = v37;\nL_001F:\n\tv42 = UnityEngine.Resources::Load(prefabName);\n\tv46 = v42 == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tv63 = *([v42 @ X0_v3 (UnityEngine.Object)]) != UnityEngine.GameObject;\n\tif (v63) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tgoto L_0037;\nL_0037:\n\tthis.prefabAd = v89;\n\tgoto L_0041;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v92, v41, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0041:\n\tv101 = UnityEngine.Object::op_Equality(v89, 0);\n\tv103 = v101 == 0;\n\tif (v103) goto L_005D;\n\tgoto L_0056;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v107, v99, v100, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0056:\n\tUnityEngine.Debug::Log(\"No Prefab found\");\n\treturn;\nL_005D:\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAndSetPrefabAd(string prefabName)
		{
			Object obj = Resources.Load(prefabName);
			if ((prefabAd = (GameObject)(((object)obj == null) ? null : (((object)obj.GetType() != typeof(GameObject)) ? null : obj))) == null)
			{
				Debug.Log("No Prefab found");
			}
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x133FFB0", Offset = "0x133FFB0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, prefabAd, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv37 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v37, prefabAd, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv34 = 1;\n\t*([1A3674F]) = v34;\nL_0019:\n\tv42 = UnityEngine.GameObject::GetComponentInChildren(prefabAd);\n\treturnVal2 = UnityEngine.Component::GetComponent(v42);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransform getRectTransform(GameObject prefabAd)
		{
			Image componentInChildren = prefabAd.GetComponentInChildren<Image>();
			return componentInChildren.GetComponent<RectTransform>();
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x1340624", Offset = "0x1340624", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GoogleMobileAds.Unity.ResponseInfoDummyClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36750]) = v34;\nL_0012:\n\tv36 = new GoogleMobileAds.Unity.ResponseInfoDummyClient();\n\tSystem.Object::.ctor(v36);\n\tgoto L_002A;\n\tv49 = \"Dummy Mediation Adapter Class Name\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, v37, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv53 = 1;\n\t*([1A36769]) = v53;\nL_002A:\n\treturn \"Dummy Mediation Adapter Class Name\";\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
		{
			ResponseInfoDummyClient responseInfoDummyClient = new ResponseInfoDummyClient();
			return "Dummy Mediation Adapter Class Name";
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x13406F0", Offset = "0x13406F0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GoogleMobileAds.Unity.ResponseInfoDummyClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36751]) = v34;\nL_0012:\n\tv36 = new GoogleMobileAds.Unity.ResponseInfoDummyClient();\n\tSystem.Object::.ctor(v36);\n\treturn v36;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IResponseInfoClient GetResponseInfoClient()
		{
			return new ResponseInfoDummyClient();
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x1340604", Offset = "0x1340604", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BaseAdDummyClient()
		{
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x1340744", Offset = "0x1340744", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv44 = UnityEngine.GameObject;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36752]) = v35;\nL_0018:\n\tv37 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v37);\n\tv52 = UnityEngine.GameObject::AddComponent(v37);\n\tv57.AdBehaviour = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static BaseAdDummyClient()
		{
			GameObject gameObject = new GameObject();
			DummyAdBehaviour adBehaviour = gameObject.AddComponent<DummyAdBehaviour>();
			AdBehaviour = adBehaviour;
		}
	}
}
