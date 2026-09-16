using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x744920", Offset = "0x744920")]
	[Token(Token = "0x2000045")]
	public class ObiLateUpdater : ObiUpdater
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x745F68", Offset = "0x745F68")]
		[Attribute(Type = typeof(RangeAttribute), RVA = "0x745F68", Offset = "0x745F68")]
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x20")]
		public float deltaSmoothing = 0.95f;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x745FBC", Offset = "0x745FBC")]
		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x24")]
		private float smoothDelta;

		[Token(Token = "0x600035D")]
		[Address(RVA = "0xE47100", Offset = "0xE47100", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EAB6A0]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024760]) = v40;\nL_001B:\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv59 = UnityEngine.Mathf::Max(0.0001f, this.smoothDelta);\n\tthis.smoothDelta = v59;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			float num = Mathf.Max(0.0001f, smoothDelta);
			smoothDelta = num;
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0xE47184", Offset = "0xE47184", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F01270]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024761]) = v44;\nL_0017:\n\tv46 = UnityEngine.Time::get_deltaTime();\n\tv58 = v46 <= 0;\n\tif (v58) goto L_005D;\n\tv60 = UnityEngine.Time::get_fixedDeltaTime();\n\tObi.ObiUpdater::BeginStep(this, v60);\n\tv99 = UnityEngine.Time::get_deltaTime();\n\tgoto L_003F;\n\tv109 = *([v105 @ X0_v6+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_003F;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v105, v69, v28, v29, v30, v31, v32, v33, v99, v35, v36, v37, v38, v39, v40, v41);\nL_003F:\n\tv117 = UnityEngine.Mathf::Lerp(v99, this.smoothDelta, this.deltaSmoothing);\n\tthis.smoothDelta = v117;\n\tObi.ObiUpdater::Substep(this, v117);\n\tObi.ObiUpdater::EndStep(this);\n\tObi.ObiUpdater::Interpolate(this, this.smoothDelta, this.smoothDelta);\n\treturn;\nL_005D:\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			float deltaTime = Time.deltaTime;
			if (deltaTime > 0f)
			{
				float fixedDeltaTime = Time.fixedDeltaTime;
				BeginStep(fixedDeltaTime);
				float deltaTime2 = Time.deltaTime;
				Substep(smoothDelta = Mathf.Lerp(deltaTime2, smoothDelta, deltaSmoothing));
				EndStep();
				Interpolate(smoothDelta, smoothDelta);
			}
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0xE4727C", Offset = "0xE4727C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC9C30]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024762]) = v38;\nL_0017:\n\tthis.deltaSmoothing = 0.95f;\n\tgoto L_002B;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tObi.ObiUpdater::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiLateUpdater()
		{
		}
	}
}
