using System;
using System.Runtime.Serialization;

namespace ICSharpCode.NRefactory.TypeSystem;

[Serializable]
public class ReflectionNameParseException : Exception
{
	private int position;

	public int Position => position;

	public ReflectionNameParseException(int position)
	{
		this.position = position;
	}

	public ReflectionNameParseException(int position, string message)
		: base(message)
	{
		this.position = position;
	}

	public ReflectionNameParseException(int position, string message, Exception innerException)
		: base(message, innerException)
	{
		this.position = position;
	}

	protected ReflectionNameParseException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		position = info.GetInt32("position");
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("position", position);
	}
}
