using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem.SimpleSequenceSystem
{
	[Token(Token = "0x2000028")]
	public class SequenceTester : MonoBehaviour
	{
		[Token(Token = "0x600009F")]
		[Address(RVA = "0x81D9BC8", Offset = "0x81D9BC8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tUnco.RewardSystem.SimpleSequenceSystem.USequence::.ctor(v52);\n\tv67 = new Unco.RewardSystem.SimpleSequenceSystem.TimeElement();\n\tSystem.Object::.ctor(v67);\n\tv67._time = 4f;\n\tv59 = v52 == 0;\n\tif (v59) goto L_0059;\n\tv62 = Unco.RewardSystem.SimpleSequenceSystem.USequence::Append(v52, v67);\n\tv67 = new Unco.RewardSystem.SimpleSequenceSystem.TimeElement();\n\tSystem.Object::.ctor(v67);\n\tv67._time = 2f;\n\tv70 = v47 == 0;\n\tif (v70) goto L_0059;\n\tv96 = Unco.RewardSystem.SimpleSequenceSystem.USequence::Join(v47, v67);\n\tv98 = new Unco.RewardSystem.SimpleSequenceSystem.TimeElement();\n\tSystem.Object::.ctor(v98);\n\tv98._time = 3f;\n\tv104 = Unco.RewardSystem.SimpleSequenceSystem.USequence::Append(v47, v98);\n\tv106 = new Unco.RewardSystem.SimpleSequenceSystem.TimeElement();\n\tSystem.Object::.ctor(v106);\n\tv106._time = 4f;\n\tv111 = Unco.RewardSystem.SimpleSequenceSystem.USequence::Join(v47, v106);\n\tv82 = Unco.RewardSystem.SimpleSequenceSystem.USequence::Append(v111, v52);\n\tUnco.RewardSystem.SimpleSequenceSystem.USequence::Start(v82);\n\treturn;\nL_0059:\n\tthrow v67;\nL_001B:\n\tv47 = new Unco.RewardSystem.SimpleSequenceSystem.USequence();\n\tUnco.RewardSystem.SimpleSequenceSystem.USequence::.ctor(v47);\n\tv52 = new Unco.RewardSystem.SimpleSequenceSystem.USequence();\n")]
		private void Test()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SequenceTester::Test");
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x81DA9B8", Offset = "0x81DA9B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SequenceTester()
		{
		}
	}
}
