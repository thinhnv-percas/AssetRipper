using System.Collections.Generic;

namespace ImageMagick;

public interface IDefines
{
	IEnumerable<IDefine> Defines { get; }
}
