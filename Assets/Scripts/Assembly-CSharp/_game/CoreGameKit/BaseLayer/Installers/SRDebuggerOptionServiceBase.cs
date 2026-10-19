using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using SRDebugger;
using SRDebugger.Services;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006BC")]
	public abstract class SRDebuggerOptionServiceBase : IDisposable
	{
		[Token(Token = "0x40016C5")]
		private static readonly HashSet<string> s_persistentOptionKeys;

		[Token(Token = "0x40016C6")]
		[FieldOffset(Offset = "0x10")]
		internal readonly List<OptionDefinition> _removableOptions;

		[Token(Token = "0x6001C81")]
		[Address(RVA = "0x3D6D818", Offset = "0x3D6D818", Length = "0x2D4")]
		protected internal void AddOption(OptionDefinition option, bool persistent = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerOptionServiceBase::AddOption");
		}

		[Token(Token = "0x6001C82")]
		[Address(RVA = "0x3D6F054", Offset = "0x3D6F054", Length = "0x2EC")]
		public unsafe virtual void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerOptionServiceBase::Dispose");
		}

		[Token(Token = "0x6001C83")]
		[Address(RVA = "0x3D6EFFC", Offset = "0x3D6EFFC", Length = "0x58")]
		private static string BuildKey(OptionDefinition option)
		{
			return option.Category + "/" + option.Name;
		}

		[Token(Token = "0x6001C84")]
		[Address(RVA = "0x3D6D324", Offset = "0x3D6D324", Length = "0x8C")]
		protected internal SRDebuggerOptionServiceBase()
		{
			List<OptionDefinition> removableOptions = new List<OptionDefinition>();
			_removableOptions = removableOptions;
		}

		[Token(Token = "0x6001C85")]
		[Address(RVA = "0x3D6F340", Offset = "0x3D6F340", Length = "0x94")]
		static SRDebuggerOptionServiceBase()
		{
			HashSet<string> hashSet = new HashSet<string>();
			s_persistentOptionKeys = hashSet;
		}
	}
}
