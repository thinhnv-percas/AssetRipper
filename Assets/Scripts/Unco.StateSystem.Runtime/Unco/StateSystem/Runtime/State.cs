using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.StateSystem.Runtime
{
	[Token(Token = "0x2000006")]
	public abstract class State
	{
		[Token(Token = "0x6000013")]
		[Address(RVA = "0x81DD910", Offset = "0x81DD910", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStateEnter()
		{
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x81DD914", Offset = "0x81DD914", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStateUpdate()
		{
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x81DD918", Offset = "0x81DD918", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStateFixedUpdate()
		{
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x81DD91C", Offset = "0x81DD91C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStateLateUpdate()
		{
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x81DD920", Offset = "0x81DD920", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStateExit()
		{
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x81DD924", Offset = "0x81DD924", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public State()
		{
		}
	}
}
