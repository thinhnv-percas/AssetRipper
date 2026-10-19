using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.TutorialSystem.Scripts.TutorialActions
{
	[Serializable]
	[Token(Token = "0x200001C")]
	public class TutorialAction
	{
		[SerializeField]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x10")]
		private float m_Delay;

		[Token(Token = "0x17000010")]
		public float Delay
		{
			[Token(Token = "0x600008B")]
			[Address(RVA = "0x81E2E60", Offset = "0x81E2E60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Delay;\n")]
			get
			{
				return m_Delay;
			}
		}

		[Token(Token = "0x17000011")]
		public bool HasDelay
		{
			[Token(Token = "0x600008C")]
			[Address(RVA = "0x81E0398", Offset = "0x81E0398", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Delay < 0;\n\tv3 = this.Delay == 0;\n\tv6 = this.Delay == this.Delay;\n\tv7 = ~v6;\n\tv8 = v2 == v7;\n\tv9 = ~v3;\n\tv10 = v8 & v9;\n\treturn v10;\n")]
			get
			{
				bool flag = Delay < 0f;
				bool flag2 = Delay == 0f;
				bool flag3 = Delay == Delay;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				return flag5 && flag6;
			}
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x81E2E68", Offset = "0x81E2E68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Delay = delay;\n\treturn;\n")]
		public void SetDelay(float delay)
		{
			m_Delay = delay;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x81E2E70", Offset = "0x81E2E70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Apply()
		{
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x81E2E74", Offset = "0x81E2E74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Reset()
		{
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x81E2E78", Offset = "0x81E2E78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TutorialAction()
		{
		}
	}
}
