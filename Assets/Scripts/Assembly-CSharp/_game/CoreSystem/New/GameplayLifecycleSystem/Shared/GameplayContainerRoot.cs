using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.Shared
{
	[Token(Token = "0x20003FD")]
	public sealed class GameplayContainerRoot : IDisposable
	{
		[Token(Token = "0x4000CA6")]
		[FieldOffset(Offset = "0x18")]
		private readonly bool _isPlaying;

		[Token(Token = "0x17000155")]
		[field: Token(Token = "0x4000CA5")]
		[field: FieldOffset(Offset = "0x10")]
		public Transform Transform
		{
			[Token(Token = "0x60010C6")]
			[Address(RVA = "0x3CB8480", Offset = "0x3CB8480", Length = "0x8")]
			get;
		}

		[Token(Token = "0x60010C7")]
		[Address(RVA = "0x3CB8488", Offset = "0x3CB8488", Length = "0xC4")]
		public GameplayContainerRoot(string name, bool isPlaying)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayContainerRoot::.ctor");
		}

		[Token(Token = "0x60010C8")]
		[Address(RVA = "0x3CB854C", Offset = "0x3CB854C", Length = "0x138")]
		public void Dispose()
		{
			if (!(Transform == null))
			{
				GameObject gameObject = Transform.gameObject;
				if (_isPlaying)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(gameObject);
				}
			}
		}
	}
}
