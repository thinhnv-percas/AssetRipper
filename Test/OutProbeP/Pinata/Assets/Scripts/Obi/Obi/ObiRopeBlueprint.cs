using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[CreateAssetMenu]
	[Token(Token = "0x2000064")]
	public class ObiRopeBlueprint : ObiRopeBlueprintBase
	{
		[Token(Token = "0x40001D6")]
		[FieldOffset(Offset = "0x128")]
		public int pooledParticles;

		[Token(Token = "0x40001D7")]
		public const float DEFAULT_PARTICLE_MASS = 0.1f;

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747720", Offset = "0x747720")]
		[Token(Token = "0x600044E")]
		[Address(RVA = "0xC389E0", Offset = "0xC389E0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE5858]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231C4]) = v38;\nL_0016:\n\tv42 = new Obi.ObiRopeBlueprint+<Initialize>d__2();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override IEnumerator Initialize()
		{
			_003CInitialize_003Ed__2 _003CInitialize_003Ed__3 = null;
			_003CInitialize_003Ed__3._003C_003E1__state = 0;
			_003CInitialize_003Ed__3._003C_003E4__this = this;
			return _003CInitialize_003Ed__3;
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747784", Offset = "0x747784")]
		[Token(Token = "0x600044F")]
		[Address(RVA = "0xC38A80", Offset = "0xC38A80", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F00880]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231C5]) = v38;\nL_0016:\n\tv42 = new Obi.ObiRopeBlueprint+<CreateDistanceConstraints>d__3();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual IEnumerator CreateDistanceConstraints()
		{
			_003CCreateDistanceConstraints_003Ed__3 _003CCreateDistanceConstraints_003Ed__4 = null;
			_003CCreateDistanceConstraints_003Ed__4._003C_003E1__state = 0;
			_003CCreateDistanceConstraints_003Ed__4._003C_003E4__this = this;
			return _003CCreateDistanceConstraints_003Ed__4;
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7477E8", Offset = "0x7477E8")]
		[Token(Token = "0x6000450")]
		[Address(RVA = "0xC38B20", Offset = "0xC38B20", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F00948]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231C6]) = v38;\nL_0016:\n\tv42 = new Obi.ObiRopeBlueprint+<CreateBendingConstraints>d__4();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual IEnumerator CreateBendingConstraints()
		{
			_003CCreateBendingConstraints_003Ed__4 _003CCreateBendingConstraints_003Ed__5 = null;
			_003CCreateBendingConstraints_003Ed__5._003C_003E1__state = 0;
			_003CCreateBendingConstraints_003Ed__5._003C_003E4__this = this;
			return _003CCreateBendingConstraints_003Ed__5;
		}

		[Token(Token = "0x6000451")]
		[Address(RVA = "0xC38BC0", Offset = "0xC38BC0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.pooledParticles = 0x64;\n\tObi.ObiRopeBlueprintBase::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeBlueprint()
		{
			pooledParticles = 100;
		}
	}
}
