using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Profiling;

namespace Tayx.Graphy.Ram
{
	[Token(Token = "0x2000037")]
	public class G_RamMonitor : MonoBehaviour
	{
		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x18")]
		private float m_allocatedRam;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x1C")]
		private float m_reservedRam;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x20")]
		private float m_monoRam;

		[Token(Token = "0x1700003A")]
		public float AllocatedRam
		{
			[Token(Token = "0x6000184")]
			[Address(RVA = "0x16435D4", Offset = "0x16435D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_allocatedRam;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AllocatedRam;
			}
		}

		[Token(Token = "0x1700003B")]
		public float ReservedRam
		{
			[Token(Token = "0x6000185")]
			[Address(RVA = "0x16435DC", Offset = "0x16435DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_reservedRam;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ReservedRam;
			}
		}

		[Token(Token = "0x1700003C")]
		public float MonoRam
		{
			[Token(Token = "0x6000186")]
			[Address(RVA = "0x16435E4", Offset = "0x16435E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_monoRam;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MonoRam;
			}
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x16435EC", Offset = "0x16435EC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Profiling.Profiler::GetTotalAllocatedMemoryLong();\n\tv18 = v13 * 9.536743E-07f;\n\tthis.m_allocatedRam = v18;\n\tv19 = UnityEngine.Profiling.Profiler::GetTotalReservedMemoryLong();\n\tv21 = v19 * 9.536743E-07f;\n\tthis.m_reservedRam = v21;\n\tv23 = UnityEngine.Profiling.Profiler::GetMonoUsedSizeLong();\n\tv25 = v23 * 9.536743E-07f;\n\tthis.m_monoRam = v25;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			long totalAllocatedMemoryLong = Profiler.GetTotalAllocatedMemoryLong();
			float allocatedRam = (float)totalAllocatedMemoryLong * 9.536743E-07f;
			m_allocatedRam = allocatedRam;
			long totalReservedMemoryLong = Profiler.GetTotalReservedMemoryLong();
			float reservedRam = (float)totalReservedMemoryLong * 9.536743E-07f;
			m_reservedRam = reservedRam;
			long monoUsedSizeLong = Profiler.GetMonoUsedSizeLong();
			float monoRam = (float)monoUsedSizeLong * 9.536743E-07f;
			m_monoRam = monoRam;
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0x1643654", Offset = "0x1643654", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_RamMonitor()
		{
		}
	}
}
