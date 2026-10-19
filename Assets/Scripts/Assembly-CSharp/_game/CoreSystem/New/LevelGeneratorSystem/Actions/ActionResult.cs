using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003C8")]
	public readonly struct ActionResult
	{
		[Token(Token = "0x17000141")]
		[field: Token(Token = "0x4000BE5")]
		[field: FieldOffset(Offset = "0x0")]
		public bool IsSuccess
		{
			[Token(Token = "0x6000FA6")]
			[Address(RVA = "0x3CA33D8", Offset = "0x3CA33D8", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000142")]
		[field: Token(Token = "0x4000BE6")]
		[field: FieldOffset(Offset = "0x8")]
		public ActionError Error
		{
			[Token(Token = "0x6000FA7")]
			[Address(RVA = "0x3CA33E0", Offset = "0x3CA33E0", Length = "0x8")]
			get;
		}

		[Token(Token = "0x6000FA8")]
		[Address(RVA = "0x3CA33E8", Offset = "0x3CA33E8", Length = "0x10")]
		private ActionResult(bool ok, ActionError error)
		{
			IsSuccess = ok;
			Error = error;
		}

		[Token(Token = "0x6000FA9")]
		[Address(RVA = "0x3CA33F8", Offset = "0x3CA33F8", Length = "0x38")]
		public static ActionResult Ok()
		{
			ActionResult result = default(ActionResult);
			return result;
		}

		[Token(Token = "0x6000FAA")]
		[Address(RVA = "0x3CA3430", Offset = "0x3CA3430", Length = "0x30")]
		public static ActionResult Fail(ActionError error)
		{
			return default(ActionResult);
		}

		[Token(Token = "0x6000FAB")]
		[Address(RVA = "0x3CA3460", Offset = "0x3CA3460", Length = "0xD8")]
		public static ActionResult Fail(string code, string message, string fixHint = "")
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ActionResult::Fail");
			return default;
		}
	}
	[Token(Token = "0x20003C9")]
	public readonly struct ActionResult<T>
	{
		[Token(Token = "0x17000143")]
		public bool IsSuccess
		{
			[Token(Token = "0x6000FAC")]
			[Address(RVA = "0x531CE74", Offset = "0x531CE74", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000144")]
		public T Value
		{
			[CompilerGenerated]
			[Token(Token = "0x6000FAD")]
			[Address(RVA = "0x531CE7C", Offset = "0x531CE7C", Length = "0x8")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ActionResult::get_Value");
				return default;
			}
		}

		[Token(Token = "0x17000145")]
		public ActionError Error
		{
			[Token(Token = "0x6000FAE")]
			[Address(RVA = "0x531CE84", Offset = "0x531CE84", Length = "0x8")]
			get;
		}

		[Token(Token = "0x6000FAF")]
		[Address(RVA = "0x531CE8C", Offset = "0x531CE8C", Length = "0x14")]
		private ActionResult(bool ok, T value, ActionError error)
		{
			IsSuccess = ok;
			Error = error;
		}

		[Token(Token = "0x6000FB0")]
		[Address(RVA = "0x531CEA0", Offset = "0x531CEA0", Length = "0x50")]
		public static ActionResult<T> Ok(T value)
		{
			//IL_0009: Expected O, but got I4
			//IL_001d: Expected O, but got I4
			//IL_0031: Expected O, but got I
			//IL_003a: Expected O, but got I4
			object obj = 0;
			_ = 0;
			obj = 1;
			object obj2 = (nint)obj + 16;
			obj2 = 0;
			ActionResult<T> result = default(ActionResult<T>);
			return result;
		}

		[Token(Token = "0x6000FB1")]
		[Address(RVA = "0x531CEF0", Offset = "0x531CEF0", Length = "0x4C")]
		public static ActionResult<T> Fail(ActionError error)
		{
			//IL_0009: Expected O, but got I4
			//IL_001d: Expected O, but got I4
			//IL_0032: Expected O, but got I
			object obj = 0;
			_ = 0;
			obj = 0;
			_ = 0;
			object obj2 = (nint)obj + 16;
			obj2 = error;
			ActionResult<T> result = default(ActionResult<T>);
			return result;
		}

		[Token(Token = "0x6000FB2")]
		[Address(RVA = "0x531CF3C", Offset = "0x531CF3C", Length = "0xB8")]
		public static ActionResult<T> Fail(string code, string message, string fixHint = "")
		{
			//IL_004f: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_0023: Expected O, but got I
			ActionError actionError = new ActionError(code, message, fixHint);
			object obj = 0;
			_ = 0;
			obj = 0;
			_ = 0;
			object obj2 = (nint)obj + 16;
			obj2 = actionError;
			ActionResult<T> result = default(ActionResult<T>);
			return result;
		}
	}
}
