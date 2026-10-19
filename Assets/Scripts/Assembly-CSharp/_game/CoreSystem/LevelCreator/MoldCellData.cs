using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.LevelCreator
{
	[Serializable]
	[Token(Token = "0x20004C0")]
	public class MoldCellData
	{
		[SerializeReference]
		[Token(Token = "0x4000FEA")]
		[FieldOffset(Offset = "0x10")]
		public List<ICellComponent> components;

		[Token(Token = "0x60013FA")]
		[Address(RVA = "0x4AE25B4", Offset = "0x4AE25B4", Length = "0x230")]
		public T GetComponent<T>() where T : ICellComponent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldCellData::GetComponent");
			return default;
		}

		[Token(Token = "0x60013FB")]
		[Address(RVA = "0x4AE2A4C", Offset = "0x4AE2A4C", Length = "0x2DC")]
		public bool TryGetComponent<T>(out T c) where T : ICellComponent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldCellData::TryGetComponent");
			c = default;
			return default;
		}

		[Token(Token = "0x60013FC")]
		[Address(RVA = "0x3CF1AD4", Offset = "0x3CF1AD4", Length = "0x8")]
		public MoldCellData()
		{
		}
	}
}
