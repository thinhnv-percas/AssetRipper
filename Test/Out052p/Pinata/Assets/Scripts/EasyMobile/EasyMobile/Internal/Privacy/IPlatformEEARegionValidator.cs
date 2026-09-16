using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000D8")]
	internal interface IPlatformEEARegionValidator
	{
		[Token(Token = "0x60007B4")]
		void ValidateEEARegionStatus(List<EEARegionValidationMethods> methods, Action<EEARegionStatus> callback);
	}
}
