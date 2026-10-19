using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x200041F")]
	public class FailCheckSuppressor : IFailCheckSuppressor
	{
		[Token(Token = "0x2000420")]
		internal class Handle : IDisposable
		{
			[Token(Token = "0x4000CFC")]
			[FieldOffset(Offset = "0x10")]
			internal readonly FailCheckSuppressor _owner;

			[Token(Token = "0x4000CFD")]
			[FieldOffset(Offset = "0x18")]
			private bool _disposed;

			[Token(Token = "0x1700015E")]
			[field: Token(Token = "0x4000CFE")]
			[field: FieldOffset(Offset = "0x20")]
			public string Reason
			{
				[Token(Token = "0x6001142")]
				[Address(RVA = "0x3CBEB18", Offset = "0x3CBEB18", Length = "0x8")]
				get;
			}

			[Token(Token = "0x6001143")]
			[Address(RVA = "0x3CBEA64", Offset = "0x3CBEA64", Length = "0x50")]
			public Handle(FailCheckSuppressor owner, string reason)
			{
				_owner = owner;
				Reason = reason;
			}

			[Token(Token = "0x6001144")]
			[Address(RVA = "0x3CBEB20", Offset = "0x3CBEB20", Length = "0x88")]
			public void Dispose()
			{
				if (!_disposed)
				{
					_disposed = true;
					FailCheckSuppressor owner = _owner;
					bool flag = owner._active.Remove(this);
				}
			}
		}

		[Token(Token = "0x4000CFB")]
		[FieldOffset(Offset = "0x10")]
		internal readonly HashSet<Handle> _active;

		[Token(Token = "0x1700015D")]
		public bool IsSuppressed
		{
			[Token(Token = "0x600113E")]
			[Address(RVA = "0x3CBE95C", Offset = "0x3CBE95C", Length = "0x54")]
			get
			{
				HashSet<Handle> active = _active;
				bool flag = active.Count < 0;
				bool flag2 = active.Count == 0;
				int num = active.Count ^ active.Count;
				int num2 = active.Count & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Token(Token = "0x600113F")]
		[Address(RVA = "0x3CBE9B0", Offset = "0x3CBE9B0", Length = "0xB4")]
		public IDisposable RequestSuppress(string reason)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailCheckSuppressor::RequestSuppress");
			return default;
		}

		[Token(Token = "0x6001140")]
		[Address(RVA = "0x3CBEAB4", Offset = "0x3CBEAB4", Length = "0x64")]
		private void Release(Handle handle)
		{
			Handle item = default(Handle);
			bool flag = _active.Remove(item);
		}

		[Token(Token = "0x6001141")]
		[Address(RVA = "0x3CBDBB8", Offset = "0x3CBDBB8", Length = "0x8C")]
		public FailCheckSuppressor()
		{
			HashSet<Handle> active = new HashSet<Handle>();
			_active = active;
		}
	}
}
