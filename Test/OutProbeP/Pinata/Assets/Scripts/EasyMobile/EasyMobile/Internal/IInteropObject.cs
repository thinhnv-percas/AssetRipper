using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000CF")]
	internal interface IInteropObject : IDisposable
	{
		[Token(Token = "0x17000227")]
		HandleRef SelfPointer
		{
			[Token(Token = "0x600077F")]
			get;
		}

		[Token(Token = "0x6000780")]
		bool IsDisposed();

		[Token(Token = "0x6000781")]
		bool HasSamePointerWith(IInteropObject other);

		[Token(Token = "0x6000782")]
		IntPtr ToPointer();
	}
}
