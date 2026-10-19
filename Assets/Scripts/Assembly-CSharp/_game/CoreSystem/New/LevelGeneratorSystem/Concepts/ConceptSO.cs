using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Concepts
{
	[CreateAssetMenu(menuName = "LevelGen/Concept", fileName = "Concept", order = 130)]
	[Token(Token = "0x200039F")]
	public class ConceptSO : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4000B11")]
		[FieldOffset(Offset = "0x18")]
		private string id;

		[SerializeField]
		[Token(Token = "0x4000B12")]
		[FieldOffset(Offset = "0x20")]
		private string displayName;

		[TextArea(4, 20)]
		[SerializeField]
		[Token(Token = "0x4000B13")]
		[FieldOffset(Offset = "0x28")]
		private string definition;

		[TextArea(2, 6)]
		[SerializeField]
		[Token(Token = "0x4000B14")]
		[FieldOffset(Offset = "0x30")]
		private string designerNotes;

		[Token(Token = "0x17000137")]
		public string Id
		{
			[Token(Token = "0x6000F37")]
			[Address(RVA = "0x3C99030", Offset = "0x3C99030", Length = "0x8")]
			get
			{
				return id;
			}
		}

		[Token(Token = "0x17000138")]
		public string DisplayName
		{
			[Token(Token = "0x6000F38")]
			[Address(RVA = "0x3C99038", Offset = "0x3C99038", Length = "0x8")]
			get
			{
				return displayName;
			}
		}

		[Token(Token = "0x17000139")]
		public string Definition
		{
			[Token(Token = "0x6000F39")]
			[Address(RVA = "0x3C99040", Offset = "0x3C99040", Length = "0x8")]
			get
			{
				return definition;
			}
		}

		[Token(Token = "0x1700013A")]
		public string DesignerNotes
		{
			[Token(Token = "0x6000F3A")]
			[Address(RVA = "0x3C99048", Offset = "0x3C99048", Length = "0x8")]
			get
			{
				return designerNotes;
			}
		}

		[Token(Token = "0x6000F3B")]
		[Address(RVA = "0x3C98D74", Offset = "0x3C98D74", Length = "0xE4")]
		public ConceptSummary ToSummary()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConceptSO::ToSummary");
			return default;
		}

		[Token(Token = "0x6000F3C")]
		[Address(RVA = "0x3C99050", Offset = "0x3C99050", Length = "0x128")]
		internal static string FirstSentence(string text)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConceptSO::FirstSentence");
			return default;
		}

		[Token(Token = "0x6000F3D")]
		[Address(RVA = "0x3C9923C", Offset = "0x3C9923C", Length = "0x88")]
		public ConceptSO()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConceptSO::.ctor");
		}
	}
}
