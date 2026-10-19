using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings;
using _game.CoreSystem.New.MoldSystem.Visual;

namespace _game.CoreSystem.New.MoldSystem
{
	[Token(Token = "0x20002A4")]
	public class MoldSceneReferenceHub : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400081E")]
		[FieldOffset(Offset = "0x20")]
		private MoldVisualCreator m_visualCreator;

		[SerializeField]
		[Token(Token = "0x400081F")]
		[FieldOffset(Offset = "0x28")]
		private MoldLinkVisualController m_linkVisualController;

		[SerializeField]
		[Token(Token = "0x4000820")]
		[FieldOffset(Offset = "0x30")]
		private MoldVisualGridController m_gridVisualController;

		[SerializeField]
		[Token(Token = "0x4000821")]
		[FieldOffset(Offset = "0x38")]
		private MoldAnimator m_moldAnimator;

		[SerializeField]
		[Token(Token = "0x4000822")]
		[FieldOffset(Offset = "0x40")]
		private MoldReconcileTick m_reconcileTick;

		[SerializeField]
		[Token(Token = "0x4000823")]
		[FieldOffset(Offset = "0x48")]
		private MoldVisualCmdProcessor m_cmdProcessor;

		[Token(Token = "0x170000EC")]
		public MoldVisualCreator VisualCreator
		{
			[Token(Token = "0x6000B97")]
			[Address(RVA = "0x3EC7CF0", Offset = "0x3EC7CF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.VisualCreator;\n")]
			get
			{
				return m_visualCreator;
			}
		}

		[Token(Token = "0x170000ED")]
		public MoldLinkVisualController LinkVisualController
		{
			[Token(Token = "0x6000B98")]
			[Address(RVA = "0x3EC7CF8", Offset = "0x3EC7CF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.LinkVisualController;\n")]
			get
			{
				return m_linkVisualController;
			}
		}

		[Token(Token = "0x170000EE")]
		public MoldVisualGridController GridVisualController
		{
			[Token(Token = "0x6000B99")]
			[Address(RVA = "0x3EC7D00", Offset = "0x3EC7D00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.GridVisualController;\n")]
			get
			{
				return m_gridVisualController;
			}
		}

		[Token(Token = "0x170000EF")]
		public MoldAnimator MoldAnimator
		{
			[Token(Token = "0x6000B9A")]
			[Address(RVA = "0x3EC7D08", Offset = "0x3EC7D08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MoldAnimator;\n")]
			get
			{
				return m_moldAnimator;
			}
		}

		[Token(Token = "0x170000F0")]
		public MoldReconcileTick ReconcileTick
		{
			[Token(Token = "0x6000B9B")]
			[Address(RVA = "0x3EC7D10", Offset = "0x3EC7D10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ReconcileTick;\n")]
			get
			{
				return m_reconcileTick;
			}
		}

		[Token(Token = "0x170000F1")]
		public MoldVisualCmdProcessor CmdProcessor
		{
			[Token(Token = "0x6000B9C")]
			[Address(RVA = "0x3EC7D18", Offset = "0x3EC7D18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CmdProcessor;\n")]
			get
			{
				return m_cmdProcessor;
			}
		}

		[Token(Token = "0x6000B9D")]
		[Address(RVA = "0x3EC7D20", Offset = "0x3EC7D20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldSceneReferenceHub()
		{
		}
	}
}
