using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public abstract class InterningProvider
{
	private sealed class DummyInterningProvider : InterningProvider
	{
		public override ISupportsInterning Intern(ISupportsInterning obj)
		{
			return obj;
		}

		public override string Intern(string text)
		{
			return text;
		}

		public override object InternValue(object obj)
		{
			return obj;
		}

		public override IList<T> InternList<T>(IList<T> list)
		{
			return list;
		}
	}

	public static readonly InterningProvider Dummy = new DummyInterningProvider();

	public abstract ISupportsInterning Intern(ISupportsInterning obj);

	public T Intern<T>(T obj) where T : class, ISupportsInterning
	{
		return (T)Intern((ISupportsInterning)obj);
	}

	public abstract string Intern(string text);

	public abstract object InternValue(object obj);

	public abstract IList<T> InternList<T>(IList<T> list) where T : class;
}
