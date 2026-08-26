using System;
using System.Collections.Generic;

namespace ImageMagick;

[Serializable]
public abstract class MagickException : Exception
{
	[NonSerialized]
	private List<MagickException> _relatedExceptions;

	public IEnumerable<MagickException> RelatedExceptions
	{
		get
		{
			if (_relatedExceptions == null)
			{
				return new MagickException[0];
			}
			return _relatedExceptions;
		}
	}

	internal MagickException(string message)
		: base(message)
	{
	}

	internal void SetRelatedException(List<MagickException> relatedExceptions)
	{
		_relatedExceptions = relatedExceptions;
	}
}
