using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[ExecuteAlways]
	[Token(Token = "0x2000083")]
	public abstract class BaseMeshEffect : UIBehaviour, IMeshModifier
	{
		[NonSerialized]
		[Token(Token = "0x400026F")]
		[FieldOffset(Offset = "0x20")]
		private Graphic m_Graphic;

		[Token(Token = "0x17000154")]
		protected Graphic graphic
		{
			[Token(Token = "0x600052C")]
			[Address(RVA = "0x183DF3C", Offset = "0x183DF3C", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600052D")]
		[Address(RVA = "0x183DFD0", Offset = "0x183DFD0", Length = "0xA8")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600052E")]
		[Address(RVA = "0x183E078", Offset = "0x183E078", Length = "0x9C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600052F")]
		[Address(RVA = "0x183E114", Offset = "0x183E114", Length = "0x9C")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000530")]
		[Address(RVA = "0x183E1B0", Offset = "0x183E1B0", Length = "0x1B0")]
		public virtual void ModifyMesh(Mesh mesh)
		{
		}

		[Token(Token = "0x6000531")]
		public abstract void ModifyMesh(VertexHelper vh);

		[Token(Token = "0x6000532")]
		[Address(RVA = "0x183E360", Offset = "0x183E360", Length = "0x8")]
		protected internal BaseMeshEffect()
		{
		}
	}
}
