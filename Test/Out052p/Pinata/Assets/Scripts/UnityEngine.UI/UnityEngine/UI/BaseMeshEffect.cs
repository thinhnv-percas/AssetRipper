using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[ExecuteAlways]
	[Token(Token = "0x2000040")]
	public abstract class BaseMeshEffect : UIBehaviour, IMeshModifier
	{
		[NonSerialized]
		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x18")]
		private Graphic m_Graphic;

		[Token(Token = "0x1700013D")]
		protected Graphic graphic
		{
			[Token(Token = "0x6000481")]
			[Address(RVA = "0xC4C684", Offset = "0xC4C684", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000482")]
		[Address(RVA = "0xC4C71C", Offset = "0xC4C71C", Length = "0xAC")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000483")]
		[Address(RVA = "0xC4C7C8", Offset = "0xC4C7C8", Length = "0xAC")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000484")]
		[Address(RVA = "0xC4C874", Offset = "0xC4C874", Length = "0xAC")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000485")]
		[Address(RVA = "0xC4C920", Offset = "0xC4C920", Length = "0x154")]
		public virtual void ModifyMesh(Mesh mesh)
		{
		}

		[Token(Token = "0x6000486")]
		public abstract void ModifyMesh(VertexHelper vh);

		[Token(Token = "0x6000487")]
		[Address(RVA = "0xC4CA74", Offset = "0xC4CA74", Length = "0x8")]
		protected internal BaseMeshEffect()
		{
		}
	}
}
