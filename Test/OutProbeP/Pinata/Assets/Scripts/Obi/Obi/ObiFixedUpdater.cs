using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x744880", Offset = "0x744880")]
	[ExecuteInEditMode]
	[Token(Token = "0x2000043")]
	public class ObiFixedUpdater : ObiUpdater
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x745EC0", Offset = "0x745EC0")]
		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x20")]
		public bool substepUnityPhysics;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x745EF8", Offset = "0x745EF8")]
		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x24")]
		public int substeps = 1;

		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x28")]
		private float accumulatedTime;

		[Token(Token = "0x600034F")]
		[Address(RVA = "0xE461DC", Offset = "0xE461DC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF9098]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024754]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Mathf::Max(1, this.substeps);\n\tthis.substeps = v56;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			int num = Mathf.Max(1, substeps);
			substeps = num;
		}

		[Token(Token = "0x6000350")]
		[Address(RVA = "0xE46254", Offset = "0xE46254", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.accumulatedTime = 0f;\n\treturn;\n")]
		private void Awake()
		{
			accumulatedTime = 0f;
		}

		[Token(Token = "0x6000351")]
		[Address(RVA = "0xE4625C", Offset = "0xE4625C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Physics::set_autoSimulation(1);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			Physics.autoSimulation = true;
		}

		[Token(Token = "0x6000352")]
		[Address(RVA = "0xE46268", Offset = "0xE46268", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiProfiler::EnableProfiler();\n\tv21 = this.substepUnityPhysics == 0;\n\tUnityEngine.Physics::set_autoSimulation(v21);\n\tv28 = UnityEngine.Time::get_fixedDeltaTime();\n\tObi.ObiUpdater::BeginStep(this, v28);\n\tv32 = UnityEngine.Time::get_fixedDeltaTime();\n\tv44 = this.substeps < 1;\n\tif (v44) goto L_0048;\n\tv47 = v32 / this.substeps;\nL_0031:\n\tObi.ObiUpdater::Substep(this, v47);\n\tv49 = ~this.substepUnityPhysics;\n\tif (v49) goto L_0039;\n\tUnityEngine.Physics::Simulate(v47);\nL_0039:\n\tv85 = v85 + 1;\n\tv57 = v85 < this.substeps;\n\tif (v57) goto L_0031;\nL_0048:\n\tObi.ObiUpdater::EndStep(this);\n\tObi.ObiProfiler::DisableProfiler();\n\tv105 = UnityEngine.Time::get_fixedDeltaTime();\n\tv110 = this.accumulatedTime - v105;\n\tthis.accumulatedTime = v110;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			ObiProfiler.EnableProfiler();
			bool autoSimulation = !substepUnityPhysics;
			Physics.autoSimulation = autoSimulation;
			float fixedDeltaTime = Time.fixedDeltaTime;
			BeginStep(fixedDeltaTime);
			float fixedDeltaTime2 = Time.fixedDeltaTime;
			if (substeps >= 1)
			{
				float num = fixedDeltaTime2 / (float)substeps;
				int num2 = 0;
				do
				{
					Substep(num);
					if (substepUnityPhysics)
					{
						Physics.Simulate(num);
					}
					num2++;
				}
				while (num2 < substeps);
			}
			EndStep();
			ObiProfiler.DisableProfiler();
			float fixedDeltaTime3 = Time.fixedDeltaTime;
			float num3 = accumulatedTime - fixedDeltaTime3;
			accumulatedTime = num3;
		}

		[Token(Token = "0x6000353")]
		[Address(RVA = "0xE46338", Offset = "0xE46338", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiProfiler::EnableProfiler();\n\tv14 = UnityEngine.Time::get_fixedDeltaTime();\n\tObi.ObiUpdater::Interpolate(this, v14, this.accumulatedTime);\n\tObi.ObiProfiler::DisableProfiler();\n\tv21 = UnityEngine.Time::get_deltaTime();\n\tv22 = this.accumulatedTime + v21;\n\tthis.accumulatedTime = v22;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			ObiProfiler.EnableProfiler();
			float fixedDeltaTime = Time.fixedDeltaTime;
			Interpolate(fixedDeltaTime, accumulatedTime);
			ObiProfiler.DisableProfiler();
			float deltaTime = Time.deltaTime;
			float num = accumulatedTime + deltaTime;
			accumulatedTime = num;
		}

		[Token(Token = "0x6000354")]
		[Address(RVA = "0xE46398", Offset = "0xE46398", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE2E88]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024755]) = v38;\nL_0014:\n\tthis.substeps = 1;\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tObi.ObiUpdater::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiFixedUpdater()
		{
		}
	}
}
