using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[CreateAssetMenu(fileName = "BoosterDefinition", menuName = "CoreGameKit/Booster/BoosterDefinition")]
	[Token(Token = "0x2000625")]
	public class BoosterDefinition : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x400153A")]
		[FieldOffset(Offset = "0x18")]
		private string m_id;

		[SerializeField]
		[Token(Token = "0x400153B")]
		[FieldOffset(Offset = "0x20")]
		private string m_displayName;

		[SerializeField]
		[TextArea]
		[Token(Token = "0x400153C")]
		[FieldOffset(Offset = "0x28")]
		private string m_description;

		[SerializeField]
		[Token(Token = "0x400153D")]
		[FieldOffset(Offset = "0x30")]
		private Sprite m_icon;

		[SerializeField]
		[Token(Token = "0x400153E")]
		[FieldOffset(Offset = "0x38")]
		private int m_maxStack;

		[Token(Token = "0x1700028D")]
		public string Id
		{
			[Token(Token = "0x6001A50")]
			[Address(RVA = "0x3D52894", Offset = "0x3D52894", Length = "0x8")]
			get
			{
				return m_id;
			}
		}

		[Token(Token = "0x1700028E")]
		public string DisplayName
		{
			[Token(Token = "0x6001A51")]
			[Address(RVA = "0x3D5289C", Offset = "0x3D5289C", Length = "0x8")]
			get
			{
				return m_displayName;
			}
		}

		[Token(Token = "0x1700028F")]
		public string Description
		{
			[Token(Token = "0x6001A52")]
			[Address(RVA = "0x3D528A4", Offset = "0x3D528A4", Length = "0x8")]
			get
			{
				return m_description;
			}
		}

		[Token(Token = "0x17000290")]
		public Sprite Icon
		{
			[Token(Token = "0x6001A53")]
			[Address(RVA = "0x3D528AC", Offset = "0x3D528AC", Length = "0x8")]
			get
			{
				return m_icon;
			}
		}

		[Token(Token = "0x17000291")]
		public int MaxStack
		{
			[Token(Token = "0x6001A54")]
			[Address(RVA = "0x3D528B4", Offset = "0x3D528B4", Length = "0x8")]
			get
			{
				return m_maxStack;
			}
		}

		[Token(Token = "0x6001A55")]
		[Address(RVA = "0x3D528BC", Offset = "0x3D528BC", Length = "0x8")]
		public BoosterDefinition()
		{
		}
	}
}
