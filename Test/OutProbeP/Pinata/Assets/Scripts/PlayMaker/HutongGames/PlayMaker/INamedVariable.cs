using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000067")]
	public interface INamedVariable
	{
		[Token(Token = "0x170000AB")]
		string Name
		{
			[Token(Token = "0x600029C")]
			get;
		}

		[Token(Token = "0x170000AC")]
		bool UseVariable
		{
			[Token(Token = "0x600029D")]
			get;
			[Token(Token = "0x600029E")]
			set;
		}

		[Token(Token = "0x170000AD")]
		bool UsesVariable
		{
			[Token(Token = "0x600029F")]
			get;
		}

		[Token(Token = "0x170000AE")]
		bool NetworkSync
		{
			[Token(Token = "0x60002A0")]
			get;
			[Token(Token = "0x60002A1")]
			set;
		}

		[Token(Token = "0x170000AF")]
		bool IsNone
		{
			[Token(Token = "0x60002A2")]
			get;
		}

		[Token(Token = "0x170000B0")]
		VariableType VariableType
		{
			[Token(Token = "0x60002A4")]
			get;
		}

		[Token(Token = "0x170000B1")]
		VariableType TypeConstraint
		{
			[Token(Token = "0x60002A5")]
			get;
		}

		[Token(Token = "0x170000B2")]
		Type ObjectType
		{
			[Token(Token = "0x60002A6")]
			get;
			[Token(Token = "0x60002A7")]
			set;
		}

		[Token(Token = "0x170000B3")]
		object RawValue
		{
			[Token(Token = "0x60002A8")]
			get;
			[Token(Token = "0x60002A9")]
			set;
		}

		[Token(Token = "0x60002A3")]
		string GetDisplayName();

		[Token(Token = "0x60002AA")]
		bool TestTypeConstraint(VariableType variableType, Type objectType = null);

		[Token(Token = "0x60002AB")]
		void SafeAssign(object val);
	}
}
