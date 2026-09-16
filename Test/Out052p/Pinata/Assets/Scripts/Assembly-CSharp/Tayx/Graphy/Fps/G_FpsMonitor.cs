using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Tayx.Graphy.Fps
{
	[Token(Token = "0x200003C")]
	public class G_FpsMonitor : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x18")]
		private int m_averageSamples;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x20")]
		internal GraphyManager m_graphyManager;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x28")]
		private float m_currentFps;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x2C")]
		private float m_avgFps;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x30")]
		private float m_minFps;

		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x34")]
		private float m_maxFps;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x38")]
		private float[] m_averageFpsSamples;

		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x40")]
		private int m_avgFpsSamplesOffset;

		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x44")]
		private int m_indexMask;

		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x48")]
		private int m_avgFpsSamplesCapacity;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x4C")]
		private int m_avgFpsSamplesCount;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x50")]
		internal int m_timeToResetMinMaxFps;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x54")]
		private float m_timeToResetMinFpsPassed;

		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x58")]
		private float m_timeToResetMaxFpsPassed;

		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x5C")]
		private float unscaledDeltaTime;

		[Token(Token = "0x1700003D")]
		public float CurrentFPS
		{
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0xB13C20", Offset = "0xB13C20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_currentFps;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentFPS;
			}
		}

		[Token(Token = "0x1700003E")]
		public float AverageFPS
		{
			[Token(Token = "0x60001A3")]
			[Address(RVA = "0xB13C28", Offset = "0xB13C28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_avgFps;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AverageFPS;
			}
		}

		[Token(Token = "0x1700003F")]
		public float MinFPS
		{
			[Token(Token = "0x60001A4")]
			[Address(RVA = "0xB13C30", Offset = "0xB13C30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_minFps;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinFPS;
			}
		}

		[Token(Token = "0x17000040")]
		public float MaxFPS
		{
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0xB13C38", Offset = "0xB13C38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_maxFps;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxFPS;
			}
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0xB13C40", Offset = "0xB13C40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsMonitor::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0xB13CDC", Offset = "0xB13CDC", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv14 = this.m_averageFpsSamples;\n\tthis.unscaledDeltaTime = v11;\n\tv16 = 1f / v11;\n\tv17 = v11 + this.m_timeToResetMinFpsPassed;\n\tv18 = this.m_timeToResetMaxFpsPassed + v11;\n\tthis.m_currentFps = v16;\n\tthis.m_timeToResetMinFpsPassed = v17;\n\tthis.m_timeToResetMaxFpsPassed = v18;\n\tthis.m_avgFps = 0f;\n\tv24 = this.m_avgFpsSamplesOffset + this.m_avgFpsSamplesCount;\n\tv25 = v24 & this.m_indexMask;\n\tv26 = v25 < v14.Length;\n\tv27 = ~v26;\n\tif (v27) goto L_00DC;\n\tv14[v25 @ X9_v5 (System.Int32)] = v16;\n\tv82 = this.m_avgFpsSamplesCount;\n\tv104 = this.m_avgFpsSamplesOffset & 0x7FFFFFFF;\n\tv105 = v104 << 1;\n\tv107 = 1 | v105;\n\tv108 = v107 & this.m_indexMask;\n\tthis.m_avgFpsSamplesOffset = v108;\n\tv118 = this.m_avgFpsSamplesCount >= this.m_avgFpsSamplesCapacity;\n\tif (v118) goto L_0041;\n\tv82 = v82 + 1;\n\tthis.m_avgFpsSamplesCount = v82;\nL_0041:\n\tv191 = this.m_avgFps;\n\tv160 = v82 < 1;\n\tif (v160) goto L_0070;\n\tv73 = this.m_averageFpsSamples;\nL_0054:\n\tv294 = v76 < v73.Length;\n\tv136 = ~v294;\n\tif (v136) goto L_00DC;\n\tv187 = v76 + 1;\n\tv191 = v84 + v73[v76 @ X9_v11 (System.Int32)];\n\tthis.m_avgFps = v191;\n\tv166 = v187 < v82;\n\tif (v166) goto L_0054;\nL_0070:\n\tv195 = v191 / v82;\n\tthis.m_avgFps = v195;\n\tv206 = this.m_timeToResetMinMaxFps < 1;\n\tif (v206) goto L_00A4;\n\tv221 = this.m_timeToResetMinFpsPassed <= this.m_timeToResetMinMaxFps;\n\tif (v221) goto L_009B;\n\tthis.m_minFps = 0f;\n\tthis.m_timeToResetMinFpsPassed = 0f;\nL_009B:\n\tv223 = this.m_timeToResetMaxFpsPassed <= this.m_timeToResetMinMaxFps;\n\tif (v223) goto L_00A4;\n\tthis.m_maxFps = 0f;\n\tthis.m_timeToResetMaxFpsPassed = 0f;\nL_00A4:\n\tv248 = this.m_currentFps < this.m_minFps;\n\tif (v248) goto L_00B7;\n\tv298 = this.m_minFps < 0;\n\tv299 = ~v298;\n\tv302 = this.m_minFps == 0;\n\tv307 = ~v302;\n\tv308 = v299 & v307;\n\tif (v308) goto L_00C5;\nL_00B7:\n\tthis.m_minFps = this.m_currentFps;\n\tthis.m_timeToResetMinFpsPassed = 0f;\nL_00C5:\n\tv339 = this.m_currentFps > this.m_maxFps;\n\tif (v339) goto L_00D3;\n\tv340 = this.m_maxFps < 0;\n\tv341 = ~v340;\n\tv344 = this.m_maxFps == 0;\n\tv349 = ~v344;\n\tv350 = v341 & v349;\n\tif (v350) goto L_00D9;\nL_00D3:\n\tthis.m_maxFps = this.m_currentFps;\n\tthis.m_timeToResetMaxFpsPassed = 0f;\nL_00D9:\n\treturn;\n\tv86 = new System.NullReferenceException();\nL_00DC:\n\tv147 = new System.IndexOutOfRangeException();\n\tthrow v147;\n\treturn;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			float num = Time.unscaledDeltaTime;
			float[] averageFpsSamples = m_averageFpsSamples;
			unscaledDeltaTime = num;
			float num2 = 1f / num;
			float timeToResetMinFpsPassed = num + m_timeToResetMinFpsPassed;
			float timeToResetMaxFpsPassed = m_timeToResetMaxFpsPassed + num;
			m_currentFps = num2;
			m_timeToResetMinFpsPassed = timeToResetMinFpsPassed;
			m_timeToResetMaxFpsPassed = timeToResetMaxFpsPassed;
			m_avgFps = 0f;
			int num3 = m_avgFpsSamplesOffset + m_avgFpsSamplesCount;
			int num4 = num3 & m_indexMask;
			int num5;
			float num9;
			if (num4 < averageFpsSamples.Length)
			{
				averageFpsSamples[num4] = num2;
				num5 = m_avgFpsSamplesCount;
				int num6 = m_avgFpsSamplesOffset & 0x7FFFFFFF;
				int num7 = num6 << 1;
				int num8 = 1 | num7;
				int avgFpsSamplesOffset = num8 & m_indexMask;
				m_avgFpsSamplesOffset = avgFpsSamplesOffset;
				if (m_avgFpsSamplesCount < m_avgFpsSamplesCapacity)
				{
					num5 = (m_avgFpsSamplesCount = num5 + 1);
				}
				num9 = AverageFPS;
				if (num5 < 1)
				{
					goto IL_020d;
				}
				float[] averageFpsSamples2 = m_averageFpsSamples;
				int num10 = 0;
				float num11 = AverageFPS;
				while (num10 < averageFpsSamples2.Length)
				{
					int num12 = num10 + 1;
					num9 = (m_avgFps = num11 + averageFpsSamples2[num10]);
					bool flag = num12 < num5;
					num10 = num12;
					num11 = num9;
					if (flag)
					{
						continue;
					}
					goto IL_020d;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0403:
			if (!(CurrentFPS > MaxFPS))
			{
				bool flag2 = MaxFPS < 0f;
				bool flag3 = !flag2;
				bool flag4 = MaxFPS == 0f;
				bool flag5 = !flag4;
				if (flag3 && flag5)
				{
					return;
				}
			}
			m_maxFps = CurrentFPS;
			m_timeToResetMaxFpsPassed = 0f;
			return;
			IL_020d:
			float avgFps = num9 / (float)num5;
			m_avgFps = avgFps;
			if (m_timeToResetMinMaxFps >= 1)
			{
				if (m_timeToResetMinFpsPassed > (float)m_timeToResetMinMaxFps)
				{
					m_minFps = 0f;
					m_timeToResetMinFpsPassed = 0f;
				}
				if (m_timeToResetMaxFpsPassed > (float)m_timeToResetMinMaxFps)
				{
					m_maxFps = 0f;
					m_timeToResetMaxFpsPassed = 0f;
				}
			}
			if (!(CurrentFPS < MinFPS))
			{
				bool flag6 = MinFPS < 0f;
				bool flag7 = !flag6;
				bool flag8 = MinFPS == 0f;
				bool flag9 = !flag8;
				if (flag7 && flag9)
				{
					goto IL_0403;
				}
			}
			m_minFps = CurrentFPS;
			m_timeToResetMinFpsPassed = 0f;
			goto IL_0403;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0xB139A8", Offset = "0xB139A8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_graphyManager;\n\tthis.m_timeToResetMinMaxFps = v0.m_timeToResetMinMaxFps;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			GraphyManager graphyManager = m_graphyManager;
			m_timeToResetMinMaxFps = graphyManager.TimeToResetMinMaxFps;
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0xB13C44", Offset = "0xB13C44", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EEA3F0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022538]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_transform(this);\n\tv44 = UnityEngine.Transform::get_root(v41);\n\tv63 = UnityEngine.Component::GetComponentInChildren(v44);\n\tthis.m_graphyManager = v63;\n\tTayx.Graphy.Fps.G_FpsMonitor::ResizeSamplesBuffer(this, this.m_averageSamples);\n\tv57 = this.m_graphyManager;\n\tthis.m_timeToResetMinMaxFps = v57.m_timeToResetMinMaxFps;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			ResizeSamplesBuffer(m_averageSamples);
			GraphyManager graphyManager = m_graphyManager;
			m_timeToResetMinMaxFps = graphyManager.TimeToResetMinMaxFps;
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0xB13E50", Offset = "0xB13E50", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F01680]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, size, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022539]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, size, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = UnityEngine.Mathf::NextPowerOfTwo(size);\n\tthis.m_avgFpsSamplesCapacity = v57;\n\t// 42 NewArr v63 @ X0_v7 (System.Single[]), typeof(System.Single[]), v57 @ X0_v5 (System.Int32)\n\tthis.m_averageFpsSamples = v63;\n\tv65 = this.m_avgFpsSamplesCapacity - 1;\n\tthis.m_avgFpsSamplesOffset = 0;\n\tthis.m_indexMask = v65;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResizeSamplesBuffer(int size)
		{
			float[] averageFpsSamples = new float[m_avgFpsSamplesCapacity = Mathf.NextPowerOfTwo(size)];
			m_averageFpsSamples = averageFpsSamples;
			int indexMask = m_avgFpsSamplesCapacity - 1;
			m_avgFpsSamplesOffset = 0;
			m_indexMask = indexMask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60001AB")]
		[Address(RVA = "0xB13EF4", Offset = "0xB13EF4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.m_avgFpsSamplesOffset + index;\n\treturnVal1 = v3 & this.m_indexMask;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int ToBufferIndex(int index)
		{
			int num = m_avgFpsSamplesOffset + index;
			return num & m_indexMask;
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0xB13F04", Offset = "0xB13F04", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_averageSamples = 0xC8;\n\tthis.m_timeToResetMinMaxFps = 0xA;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_FpsMonitor()
		{
			m_averageSamples = 200;
			m_timeToResetMinMaxFps = 10;
		}
	}
}
