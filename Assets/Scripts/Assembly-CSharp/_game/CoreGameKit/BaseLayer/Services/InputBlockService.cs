using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Token(Token = "0x2000655")]
	public class InputBlockService
	{
		[Token(Token = "0x2000656")]
		internal class BlockEntry
		{
			[Token(Token = "0x40015BF")]
			[FieldOffset(Offset = "0x10")]
			public readonly string Reason;

			[Token(Token = "0x40015C0")]
			[FieldOffset(Offset = "0x18")]
			public readonly InputChannel Channels;

			[Token(Token = "0x6001AE1")]
			[Address(RVA = "0x3D57534", Offset = "0x3D57534", Length = "0x48")]
			public BlockEntry(string reason, InputChannel channels)
			{
				Reason = reason;
				Channels = channels;
			}
		}

		[Token(Token = "0x2000657")]
		private class BlockHandle : IDisposable
		{
			[Token(Token = "0x40015C1")]
			[FieldOffset(Offset = "0x10")]
			internal InputBlockService _owner;

			[Token(Token = "0x40015C2")]
			[FieldOffset(Offset = "0x18")]
			internal BlockEntry _entry;

			[Token(Token = "0x6001AE2")]
			[Address(RVA = "0x3D5757C", Offset = "0x3D5757C", Length = "0x50")]
			public BlockHandle(InputBlockService owner, BlockEntry entry)
			{
				_owner = owner;
				_entry = entry;
			}

			[Token(Token = "0x6001AE3")]
			[Address(RVA = "0x3D57778", Offset = "0x3D57778", Length = "0x4C")]
			public void Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InputBlockService.BlockHandle::Dispose");
			}
		}

		[Token(Token = "0x40015BE")]
		[FieldOffset(Offset = "0x10")]
		internal readonly List<BlockEntry> _activeBlocks;

		[Token(Token = "0x6001ADD")]
		[Address(RVA = "0x3D56348", Offset = "0x3D56348", Length = "0x194")]
		public unsafe bool IsBlocked(InputChannel channel)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InputBlockService::IsBlocked");
			return default;
		}

		[Token(Token = "0x6001ADE")]
		[Address(RVA = "0x3D56F90", Offset = "0x3D56F90", Length = "0x1FC")]
		public unsafe IDisposable RequestBlock(string reason, InputChannel channels = InputChannel.All)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InputBlockService::RequestBlock");
			return default;
		}

		[Token(Token = "0x6001ADF")]
		[Address(RVA = "0x3D575CC", Offset = "0x3D575CC", Length = "0x120")]
		private unsafe void ReleaseBlock(BlockEntry entry)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InputBlockService::ReleaseBlock");
		}

		[Token(Token = "0x6001AE0")]
		[Address(RVA = "0x3D576EC", Offset = "0x3D576EC", Length = "0x8C")]
		public InputBlockService()
		{
			List<BlockEntry> activeBlocks = new List<BlockEntry>();
			_activeBlocks = activeBlocks;
		}
	}
}
