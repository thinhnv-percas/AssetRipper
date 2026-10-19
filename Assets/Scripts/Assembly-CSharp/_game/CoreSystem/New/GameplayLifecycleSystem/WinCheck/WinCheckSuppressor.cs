using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003ED")]
	public class WinCheckSuppressor : IWinCheckSuppressor
	{
		[Token(Token = "0x20003EE")]
		internal class Handle : IDisposable
		{
			[Token(Token = "0x4000C79")]
			[FieldOffset(Offset = "0x10")]
			internal readonly WinCheckSuppressor _owner;

			[Token(Token = "0x4000C7A")]
			[FieldOffset(Offset = "0x18")]
			private bool _disposed;

			[Token(Token = "0x17000152")]
			[field: Token(Token = "0x4000C7B")]
			[field: FieldOffset(Offset = "0x20")]
			public string Reason
			{
				[Token(Token = "0x600108C")]
				[Address(RVA = "0x3CB4FA4", Offset = "0x3CB4FA4", Length = "0x8")]
				get;
			}

			[Token(Token = "0x600108D")]
			[Address(RVA = "0x3CB4E64", Offset = "0x3CB4E64", Length = "0x50")]
			public Handle(WinCheckSuppressor owner, string reason)
			{
				_owner = owner;
				Reason = reason;
			}

			[Token(Token = "0x600108E")]
			[Address(RVA = "0x3CB4FAC", Offset = "0x3CB4FAC", Length = "0x88")]
			public void Dispose()
			{
				if (!_disposed)
				{
					_disposed = true;
					WinCheckSuppressor owner = _owner;
					bool flag = owner._active.Remove(this);
				}
			}
		}

		[Token(Token = "0x4000C78")]
		[FieldOffset(Offset = "0x10")]
		internal readonly HashSet<Handle> _active;

		[Token(Token = "0x17000151")]
		public bool IsSuppressed
		{
			[Token(Token = "0x6001087")]
			[Address(RVA = "0x3CB4B30", Offset = "0x3CB4B30", Length = "0x54")]
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

		[Token(Token = "0x6001088")]
		[Address(RVA = "0x3CB4B84", Offset = "0x3CB4B84", Length = "0x22C")]
		public unsafe string ActiveReasons()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinCheckSuppressor::ActiveReasons");
			return default;
		}

		[Token(Token = "0x6001089")]
		[Address(RVA = "0x3CB4DB0", Offset = "0x3CB4DB0", Length = "0xB4")]
		public IDisposable RequestSuppress(string reason)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinCheckSuppressor::RequestSuppress");
			return default;
		}

		[Token(Token = "0x600108A")]
		[Address(RVA = "0x3CB4EB4", Offset = "0x3CB4EB4", Length = "0x64")]
		private void Release(Handle handle)
		{
			Handle item = default(Handle);
			bool flag = _active.Remove(item);
		}

		[Token(Token = "0x600108B")]
		[Address(RVA = "0x3CB4F18", Offset = "0x3CB4F18", Length = "0x8C")]
		public WinCheckSuppressor()
		{
			HashSet<Handle> active = new HashSet<Handle>();
			_active = active;
		}
	}
}
