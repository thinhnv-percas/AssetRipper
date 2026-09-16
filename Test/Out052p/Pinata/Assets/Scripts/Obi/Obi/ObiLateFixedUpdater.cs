using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x7448D0", Offset = "0x7448D0")]
	[ExecuteInEditMode]
	[Token(Token = "0x2000044")]
	public class ObiLateFixedUpdater : ObiUpdater
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x745F30", Offset = "0x745F30")]
		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x20")]
		public int substeps = 1;

		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x24")]
		private float accumulatedTime;

		[Token(Token = "0x6000355")]
		[Address(RVA = "0xE46CF4", Offset = "0xE46CF4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EEBD18]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202475B]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Mathf::Max(1, this.substeps);\n\tthis.substeps = v56;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			int num = Mathf.Max(1, substeps);
			substeps = num;
		}

		[Token(Token = "0x6000356")]
		[Address(RVA = "0xE46D6C", Offset = "0xE46D6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.accumulatedTime = 0f;\n\treturn;\n")]
		private void Awake()
		{
			accumulatedTime = 0f;
		}

		[Token(Token = "0x6000357")]
		[Address(RVA = "0xE46D74", Offset = "0xE46D74", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Obi.ObiLateFixedUpdater::RunLateFixedUpdate(this);\n\tv18 = UnityEngine.MonoBehaviour::StartCoroutine(this, v10);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			IEnumerator routine = RunLateFixedUpdate();
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x6000358")]
		[Address(RVA = "0xE46E14", Offset = "0xE46E14", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Obi.ObiLateFixedUpdater::RunLateFixedUpdate(this);\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, v10);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			IEnumerator routine = RunLateFixedUpdate();
			StopCoroutine(routine);
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747354", Offset = "0x747354")]
		[Token(Token = "0x6000359")]
		[Address(RVA = "0xE46DA0", Offset = "0xE46DA0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDC5F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202475C]) = v38;\nL_0016:\n\tv42 = new Obi.ObiLateFixedUpdater+<RunLateFixedUpdate>d__6();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator RunLateFixedUpdate()
		{
			_003CRunLateFixedUpdate_003Ed__6 _003CRunLateFixedUpdate_003Ed__7 = null;
			_003CRunLateFixedUpdate_003Ed__7._003C_003E1__state = 0;
			_003CRunLateFixedUpdate_003Ed__7._003C_003E4__this = this;
			return _003CRunLateFixedUpdate_003Ed__7;
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0xE46E6C", Offset = "0xE46E6C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiProfiler::EnableProfiler();\n\tv16 = UnityEngine.Time::get_fixedDeltaTime();\n\tObi.ObiUpdater::BeginStep(this, v16);\n\tv20 = UnityEngine.Time::get_fixedDeltaTime();\n\tv32 = this.substeps < 1;\n\tif (v32) goto L_0035;\n\tv35 = v20 / this.substeps;\nL_0024:\n\tObi.ObiUpdater::Substep(this, v35);\n\tv69 = v69 + 1;\n\tv42 = v69 < this.substeps;\n\tif (v42) goto L_0024;\nL_0035:\n\tObi.ObiUpdater::EndStep(this);\n\tObi.ObiProfiler::DisableProfiler();\n\tv88 = UnityEngine.Time::get_fixedDeltaTime();\n\tv89 = this.accumulatedTime - v88;\n\tthis.accumulatedTime = v89;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateFixedUpdate()
		{
			ObiProfiler.EnableProfiler();
			float fixedDeltaTime = Time.fixedDeltaTime;
			BeginStep(fixedDeltaTime);
			float fixedDeltaTime2 = Time.fixedDeltaTime;
			if (substeps >= 1)
			{
				float substepDeltaTime = fixedDeltaTime2 / (float)substeps;
				int num = 0;
				do
				{
					Substep(substepDeltaTime);
					num++;
				}
				while (num < substeps);
			}
			EndStep();
			ObiProfiler.DisableProfiler();
			float fixedDeltaTime3 = Time.fixedDeltaTime;
			float num2 = accumulatedTime - fixedDeltaTime3;
			accumulatedTime = num2;
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0xE46F14", Offset = "0xE46F14", Length = "0x60")]
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

		[Token(Token = "0x600035C")]
		[Address(RVA = "0xE46F74", Offset = "0xE46F74", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAF228]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202475D]) = v38;\nL_0014:\n\tthis.substeps = 1;\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tObi.ObiUpdater::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiLateFixedUpdater()
		{
		}
	}
}
