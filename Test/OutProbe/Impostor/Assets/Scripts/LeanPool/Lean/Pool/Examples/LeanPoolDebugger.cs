using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Lean.Pool.Examples
{
	[RequireComponent(typeof(Rigidbody))]
	[HelpURL("https://carloswilkes.github.io/Documentation/LeanPool#LeanPoolDebugger")]
	[AddComponentMenu("Lean/Pool/Lean Pool Debugger")]
	[Token(Token = "0x200000C")]
	public class LeanPoolDebugger : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x20")]
		private LeanGameObjectPool cachedPool;

		[NonSerialized]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x28")]
		private bool skip;

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x1363204", Offset = "0x1363204", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = UnityEngine.Debug;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = \"This clone was NOT spawned using LeanPool.Spawn?!\\n\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A369A2]) = v36;\nL_0015:\n\tv38 = Lean.Pool.Examples.LeanPoolDebugger::Exists(this);\n\tv42 = v38 == 0;\n\tif (v42) goto L_0025;\n\treturn;\nL_0025:\n\tv53 = UnityEngine.Object::get_name(this);\n\tv79 = System.String::Concat(\"This clone was NOT spawned using LeanPool.Spawn?!\\n\", v53);\n\tgoto L_0036;\n\tv82 = v72;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v82, v76, v77, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0036:\n\tUnityEngine.Debug::LogWarning(v79, this);\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Start()
		{
			if (!Exists())
			{
				string text = base.name;
				string message = "This clone was NOT spawned using LeanPool.Spawn?!\n" + text;
				Debug.LogWarning(message, this);
				base.enabled = false;
			}
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x13633B4", Offset = "0x13633B4", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = \"This pool this prefab was spawned using has been destroyed.\\n\";\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = \"This clone was despawned using LeanPool.Despawn, but it's still active?!\\n\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A369A3]) = v38;\nL_0021:\n\tgoto L_0026;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv52 = UnityEngine.Object::op_Equality(this.cachedPool, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_0031;\n\tv71 = UnityEngine.Object::get_name(this);\n\tgoto L_0044;\nL_0031:\n\tv64 = Lean.Pool.Examples.LeanPoolDebugger::Exists(this);\n\tv68 = v64 == 0;\n\tif (v68) goto L_003D;\n\treturn;\nL_003D:\n\tv71 = UnityEngine.Object::get_name(this);\nL_0044:\n\tv80 = System.String::Concat(*([v74 @ X8_v4 (System.String)]), v71);\n\tgoto L_0052;\n\tv112 = v89;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v112, v77, v78, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0052:\n\tUnityEngine.Debug::LogWarning(v80, this);\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Update()
		{
			string text;
			string text2;
			if (cachedPool == null)
			{
				text = base.name;
				text2 = "This pool this prefab was spawned using has been destroyed.\n";
			}
			else
			{
				if (Exists())
				{
					return;
				}
				text = base.name;
				text2 = "This clone was despawned using LeanPool.Despawn, but it's still active?!\n";
			}
			string message = text2 + text;
			Debug.LogWarning(message, this);
			base.enabled = false;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x13634D4", Offset = "0x13634D4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skip = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnApplicationQuit()
		{
			skip = true;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x13634E0", Offset = "0x13634E0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = \"This clone has been destroyed, and it was NOT despawned using LeanPool.Despawn?!\\n\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A369A4]) = v34;\nL_0014:\n\tv36 = ~this.skip;\n\tv37 = ~v36;\n\tif (v37) goto L_003D;\n\tv41 = Lean.Pool.Examples.LeanPoolDebugger::Exists(this);\n\tv44 = v41 == 0;\n\tif (v44) goto L_003D;\n\tv70 = UnityEngine.Object::get_name(this);\n\tv77 = System.String::Concat(\"This clone has been destroyed, and it was NOT despawned using LeanPool.Despawn?!\\n\", v70);\n\tgoto L_0037;\n\tv82 = v65;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v82, v73, v74, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0037:\n\tUnityEngine.Debug::LogWarning(v77, this);\n\treturn;\nL_003D:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnDestroy()
		{
			if (!skip && Exists())
			{
				string text = base.name;
				string message = "This clone has been destroyed, and it was NOT despawned using LeanPool.Despawn?!\n" + text;
				Debug.LogWarning(message, this);
			}
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x13632C4", Offset = "0x13632C4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = Lean.Pool.LeanGameObjectPool;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = Lean.Pool.LeanPool;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A369A5]) = v38;\nL_001D:\n\tgoto L_0024;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = Lean.Pool.LeanPool;\nL_0024:\n\tv53 = UnityEngine.Component::get_gameObject(this);\n\tv59 = this + 0x20;\n\tv64 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::TryGetValue(v49.Links, v53, v59);\n\tv67 = v64 == 0;\n\tif (v67) goto L_003B;\n\treturn 1;\nL_003B:\n\tv75 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_004D;\n\tv101 = v92;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v101, v74, v63, v62, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_004D:\n\treturnVal3 = Lean.Pool.LeanGameObjectPool::TryFindPoolByClone(v75, v59);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool Exists()
		{
			GameObject key = base.gameObject;
			ref object reference = ref *(object*)((nint)this + 32);
			if (LeanPool.Links.TryGetValue(key, out System.Runtime.CompilerServices.Unsafe.As<object, LeanGameObjectPool>(ref reference)))
			{
				return true;
			}
			GameObject clone = base.gameObject;
			return LeanGameObjectPool.TryFindPoolByClone(clone, ref System.Runtime.CompilerServices.Unsafe.As<object, LeanGameObjectPool>(ref reference));
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x1363598", Offset = "0x1363598", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LeanPoolDebugger()
		{
		}
	}
}
