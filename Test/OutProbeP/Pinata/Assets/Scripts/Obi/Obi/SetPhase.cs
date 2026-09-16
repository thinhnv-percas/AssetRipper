using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Attribute(Type = typeof(RequireComponent), RVA = "0x744BCC", Offset = "0x744BCC")]
	[Token(Token = "0x200005E")]
	public class SetPhase : MonoBehaviour
	{
		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0x18")]
		public int phase;

		[Token(Token = "0x60003F2")]
		[Address(RVA = "0x10358C0", Offset = "0x10358C0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F07E20]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20262A1]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv51 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v51, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintLoaded(v45, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ObiActor component = GetComponent<ObiActor>();
			ObiActor.ActorBlueprintCallback value = Set;
			component.OnBlueprintLoaded += value;
		}

		[Token(Token = "0x60003F3")]
		[Address(RVA = "0x1035968", Offset = "0x1035968", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE1468]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20262A2]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv51 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v51, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnBlueprintLoaded(v45, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			ObiActor component = GetComponent<ObiActor>();
			ObiActor.ActorBlueprintCallback value = Set;
			component.OnBlueprintLoaded -= value;
		}

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0x1035A10", Offset = "0x1035A10", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EEF320]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20262A3]) = v38;\nL_001A:\n\tgoto L_0024;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0024;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv57 = UnityEngine.Mathf::Clamp(this.phase, 0, 0xFFFFFF);\n\tthis.phase = v57;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			int num = Mathf.Clamp(phase, 0, 16777215);
			phase = num;
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0x1035A8C", Offset = "0x1035A8C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::SetPhase(actor, this.phase);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Set(ObiActor actor, ObiActorBlueprint blueprint)
		{
			actor.SetPhase(phase);
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0x1035AB4", Offset = "0x1035AB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetPhase()
		{
		}
	}
}
