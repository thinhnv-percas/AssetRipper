using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[CreateAssetMenu]
	[Token(Token = "0x2000063")]
	public class ObiRodBlueprint : ObiRopeBlueprintBase
	{
		[Token(Token = "0x40001D3")]
		[FieldOffset(Offset = "0x128")]
		public bool keepInitialShape;

		[Token(Token = "0x40001D4")]
		public const float DEFAULT_PARTICLE_MASS = 0.1f;

		[Token(Token = "0x40001D5")]
		public const float DEFAULT_PARTICLE_ROTATIONAL_MASS = 0.01f;

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747590", Offset = "0x747590")]
		[Token(Token = "0x6000449")]
		[Address(RVA = "0xC3423C", Offset = "0xC3423C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDEA30]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231A9]) = v38;\nL_0016:\n\tv42 = new Obi.ObiRodBlueprint+<Initialize>d__3();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override IEnumerator Initialize()
		{
			_003CInitialize_003Ed__3 _003CInitialize_003Ed__4 = null;
			_003CInitialize_003Ed__4._003C_003E1__state = 0;
			_003CInitialize_003Ed__4._003C_003E4__this = this;
			return _003CInitialize_003Ed__4;
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7475F4", Offset = "0x7475F4")]
		[Token(Token = "0x600044A")]
		[Address(RVA = "0xC342DC", Offset = "0xC342DC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB8EB0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, particleNormals, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20231AA]) = v41;\nL_0018:\n\tv45 = new Obi.ObiRodBlueprint+<CreateStretchShearConstraints>d__4();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n\tv45.particleNormals = particleNormals;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual IEnumerator CreateStretchShearConstraints(List<Vector3> particleNormals)
		{
			_003CCreateStretchShearConstraints_003Ed__4 _003CCreateStretchShearConstraints_003Ed__5 = null;
			_003CCreateStretchShearConstraints_003Ed__5._003C_003E1__state = 0;
			_003CCreateStretchShearConstraints_003Ed__5._003C_003E4__this = this;
			_003CCreateStretchShearConstraints_003Ed__5.particleNormals = particleNormals;
			return _003CCreateStretchShearConstraints_003Ed__5;
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747658", Offset = "0x747658")]
		[Token(Token = "0x600044B")]
		[Address(RVA = "0xC34388", Offset = "0xC34388", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE7798]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231AB]) = v38;\nL_0016:\n\tv42 = new Obi.ObiRodBlueprint+<CreateBendTwistConstraints>d__5();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual IEnumerator CreateBendTwistConstraints()
		{
			_003CCreateBendTwistConstraints_003Ed__5 _003CCreateBendTwistConstraints_003Ed__6 = null;
			_003CCreateBendTwistConstraints_003Ed__6._003C_003E1__state = 0;
			_003CCreateBendTwistConstraints_003Ed__6._003C_003E4__this = this;
			return _003CCreateBendTwistConstraints_003Ed__6;
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7476BC", Offset = "0x7476BC")]
		[Token(Token = "0x600044C")]
		[Address(RVA = "0xC34428", Offset = "0xC34428", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F02398]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231AC]) = v38;\nL_0016:\n\tv42 = new Obi.ObiRodBlueprint+<CreateChainConstraints>d__6();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual IEnumerator CreateChainConstraints()
		{
			_003CCreateChainConstraints_003Ed__6 _003CCreateChainConstraints_003Ed__7 = null;
			_003CCreateChainConstraints_003Ed__7._003C_003E1__state = 0;
			_003CCreateChainConstraints_003Ed__7._003C_003E4__this = this;
			return _003CCreateChainConstraints_003Ed__7;
		}

		[Token(Token = "0x600044D")]
		[Address(RVA = "0xC344C8", Offset = "0xC344C8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.keepInitialShape = 1;\n\tObi.ObiRopeBlueprintBase::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRodBlueprint()
		{
			keepInitialShape = true;
		}
	}
}
