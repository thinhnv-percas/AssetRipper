using System;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Decompiler.Settings;

public sealed class DecompilerOption<T> : IDecompilerOption
{
	private readonly Func<T> getter;

	private readonly Action<T> setter;

	public string Description { get; set; }

	public string Name { get; set; }

	public Guid Guid { get; }

	public Type Type => typeof(T);

	public object Value
	{
		get
		{
			return getter();
		}
		set
		{
			setter((T)value);
		}
	}

	public DecompilerOption(Guid guid, Func<T> getter, Action<T> setter)
	{
		Guid = guid;
		this.getter = getter ?? throw new ArgumentNullException("getter");
		this.setter = setter ?? throw new ArgumentNullException("setter");
	}
}
