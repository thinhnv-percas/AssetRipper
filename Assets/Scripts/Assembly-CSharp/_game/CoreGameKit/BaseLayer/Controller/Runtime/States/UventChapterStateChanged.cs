using System;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Token(Token = "0x20006CB")]
	public struct UventChapterStateChanged : IEvent
	{
		[Token(Token = "0x40016EE")]
		[FieldOffset(Offset = "0x0")]
		public Type State;

		[Token(Token = "0x170002DD")]
		[field: Token(Token = "0x40016EF")]
		[field: FieldOffset(Offset = "0x8")]
		public ILevel Level
		{
			[Token(Token = "0x6001CDE")]
			[Address(RVA = "0x3D72638", Offset = "0x3D72638", Length = "0x8")]
			get;
			[Token(Token = "0x6001CDF")]
			[Address(RVA = "0x3D72640", Offset = "0x3D72640", Length = "0x8")]
			set;
		}
	}
}
