using System;
using System.Collections;
using System.Collections.Generic;

namespace DecompTools.Decompiler.Util;

public sealed class ProjectedList<TInput, TOutput> : IReadOnlyList<TOutput>, IEnumerable<TOutput>, IEnumerable, IReadOnlyCollection<TOutput> where TOutput : class
{
	private readonly IList<TInput> input;

	private readonly Func<TInput, TOutput> projection;

	private readonly TOutput[] items;

	public TOutput this[int index]
	{
		get
		{
			TOutput val = LazyInit.VolatileRead(ref items[index]);
			if (val != null)
			{
				return val;
			}
			return LazyInit.GetOrSet(ref items[index], projection(input[index]));
		}
	}

	public int Count => items.Length;

	public ProjectedList(IList<TInput> input, Func<TInput, TOutput> projection)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		if (projection == null)
		{
			throw new ArgumentNullException("projection");
		}
		this.input = input;
		this.projection = projection;
		items = new TOutput[input.Count];
	}

	public IEnumerator<TOutput> GetEnumerator()
	{
		for (int i = 0; i < Count; i = checked(i + 1))
		{
			yield return this[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
public sealed class ProjectedList<TContext, TInput, TOutput> : IReadOnlyList<TOutput>, IEnumerable<TOutput>, IEnumerable, IReadOnlyCollection<TOutput> where TOutput : class
{
	private readonly IList<TInput> input;

	private readonly TContext context;

	private readonly Func<TContext, TInput, TOutput> projection;

	private readonly TOutput[] items;

	public TOutput this[int index]
	{
		get
		{
			TOutput val = LazyInit.VolatileRead(ref items[index]);
			if (val != null)
			{
				return val;
			}
			return LazyInit.GetOrSet(ref items[index], projection(context, input[index]));
		}
	}

	public int Count => items.Length;

	public ProjectedList(TContext context, IList<TInput> input, Func<TContext, TInput, TOutput> projection)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		if (projection == null)
		{
			throw new ArgumentNullException("projection");
		}
		this.input = input;
		this.context = context;
		this.projection = projection;
		items = new TOutput[input.Count];
	}

	public IEnumerator<TOutput> GetEnumerator()
	{
		for (int i = 0; i < Count; i = checked(i + 1))
		{
			yield return this[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
