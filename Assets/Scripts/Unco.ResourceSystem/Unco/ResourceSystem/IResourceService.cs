using System;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000009")]
	public interface IResourceService : IResourceQuery, IResourceCommand
	{
		[Token(Token = "0x14000001")]
		event Action<ResourceChangedEvent> OnResourceChanged;

		[Token(Token = "0x14000002")]
		event Action<ResourceChangedEvent> OnResourceChanged_MuteIgnored;

		[Token(Token = "0x6000014")]
		void Dispose();
	}
}
