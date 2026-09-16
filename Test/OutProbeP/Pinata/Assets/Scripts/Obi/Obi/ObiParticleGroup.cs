using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200001A")]
	public class ObiParticleGroup : ScriptableObject
	{
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x18")]
		public List<int> particleIndices;

		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x20")]
		public ObiActorBlueprint m_Blueprint;

		[Token(Token = "0x1700002B")]
		public ObiActorBlueprint blueprint
		{
			[Token(Token = "0x60001E3")]
			[Address(RVA = "0xC29D3C", Offset = "0xC29D3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Blueprint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_Blueprint;
			}
		}

		[Token(Token = "0x1700002C")]
		public int Count
		{
			[Token(Token = "0x60001E5")]
			[Address(RVA = "0xC29054", Offset = "0xC29054", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEA310]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023147]) = v38;\nL_0013:\n\tv39 = this.particleIndices;\n\treturn v39._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<int> list = particleIndices;
				return list.Count;
			}
		}

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0xC29D44", Offset = "0xC29D44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Blueprint = blueprint;\n\treturn;\n")]
		public void SetSourceBlueprint(ObiActorBlueprint blueprint)
		{
			m_Blueprint = blueprint;
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0xC29D4C", Offset = "0xC29D4C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EB6580]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023148]) = v41;\nL_0022:\n\treturnVal1 = System.Collections.Generic.List`1<System.Int32>::Contains(this.particleIndices, index);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ContainsParticle(int index)
		{
			return particleIndices.Contains(index);
		}

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0xC29DB4", Offset = "0xC29DB4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EABC30]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023149]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v42);\n\tthis.particleIndices = v42;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticleGroup()
		{
			List<int> list = new List<int>();
			particleIndices = list;
		}
	}
}
