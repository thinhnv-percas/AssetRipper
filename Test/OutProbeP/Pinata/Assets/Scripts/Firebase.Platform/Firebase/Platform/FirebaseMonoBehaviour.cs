using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Scripting;

namespace Firebase.Platform
{
	[Preserve]
	[Token(Token = "0x2000008")]
	internal sealed class FirebaseMonoBehaviour : MonoBehaviour
	{
		[Token(Token = "0x6000038")]
		[Address(RVA = "0x15E83A4", Offset = "0x15E83A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FirebaseMonoBehaviour()
		{
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x15E83AC", Offset = "0x15E83AC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EFFF28]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029F7B]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EBC788]);\n\tv60 = *([v59 @ X8_v16]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2029FBF]) = v64;\nL_002F:\n\tgoto L_0038;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0038;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Firebase.Platform.FirebaseHandler;\nL_0038:\n\tv78 = v76.firebaseHandler == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0056;\n\tv83 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_004E;\n\tv108 = *([v96 @ X8_v13+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_004E;\n\tv113 = v96;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v113, v82, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004E:\n\tUnityEngine.Object::Destroy(v83);\nL_0056:\n\treturn v76.firebaseHandler;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FirebaseHandler GetFirebaseHandlerOrDestroyGameObject()
		{
			if (FirebaseHandler.firebaseHandler == null)
			{
				GameObject obj = base.gameObject;
				Object.Destroy(obj);
			}
			return FirebaseHandler.firebaseHandler;
		}

		[Preserve]
		[Token(Token = "0x600003A")]
		[Address(RVA = "0x15E84A4", Offset = "0x15E84A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = Firebase.Platform.FirebaseMonoBehaviour::GetFirebaseHandlerOrDestroyGameObject(this);\n\treturn;\n")]
		private void OnEnable()
		{
			FirebaseHandler firebaseHandlerOrDestroyGameObject = GetFirebaseHandlerOrDestroyGameObject();
		}

		[Preserve]
		[Token(Token = "0x600003B")]
		[Address(RVA = "0x15E84A8", Offset = "0x15E84A8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Firebase.Platform.FirebaseMonoBehaviour::GetFirebaseHandlerOrDestroyGameObject(this);\n\tv16 = v12 == 0;\n\tif (v16) goto L_002D;\n\tv18 = UnityEngine.Time::get_realtimeSinceStartup();\n\tgoto L_001E;\n\tv48 = *([1ED0700]);\n\tv49 = *([v48 @ X8_v8]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, methodInfo, v51, v52, v53, v54, v55, v56, v18, v57, v58, v59, v60, v61, v62, v63);\n\tv65 = 0 | 1;\n\t*([2029FC3]) = v65;\nL_001E:\n\tv34.<RealtimeSinceStartupSafe>k__BackingField = v18;\n\tFirebase.Platform.FirebaseHandler::Update(v12);\n\treturn;\nL_002D:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			FirebaseHandler firebaseHandlerOrDestroyGameObject = GetFirebaseHandlerOrDestroyGameObject();
			if (firebaseHandlerOrDestroyGameObject != null)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				PlatformInformation._003CRealtimeSinceStartupSafe_003Ek__BackingField = realtimeSinceStartup;
				firebaseHandlerOrDestroyGameObject.Update();
			}
		}

		[Preserve]
		[Token(Token = "0x600003C")]
		[Address(RVA = "0x15E8534", Offset = "0x15E8534", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Firebase.Platform.FirebaseMonoBehaviour::GetFirebaseHandlerOrDestroyGameObject(this);\n\tv12 = v10 == 0;\n\tif (v12) goto L_0014;\n\tFirebase.Platform.FirebaseHandler::OnApplicationFocus(v10, hasFocus);\n\treturn;\nL_0014:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationFocus(bool hasFocus)
		{
			GetFirebaseHandlerOrDestroyGameObject()?.OnApplicationFocus(hasFocus);
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x15E8568", Offset = "0x15E8568", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAF0D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F7C]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tFirebase.Platform.FirebaseHandler::OnMonoBehaviourDestroyed(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			FirebaseHandler.OnMonoBehaviourDestroyed(this);
		}
	}
}
