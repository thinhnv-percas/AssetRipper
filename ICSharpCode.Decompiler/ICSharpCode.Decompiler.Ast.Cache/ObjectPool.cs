using System;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.Ast.Cache;

internal sealed class ObjectPool<T> where T : class
{
	private readonly Func<T> create;

	private readonly Action<T> initialize;

	private readonly List<T> allObjs;

	private readonly List<T> freeObjs;

	public ObjectPool(Func<T> create, Action<T> initialize)
	{
		this.create = create;
		this.initialize = initialize;
		allObjs = new List<T>();
		freeObjs = new List<T>();
	}

	public T Allocate()
	{
		if (freeObjs.Count > 0)
		{
			int index = freeObjs.Count - 1;
			T val = freeObjs[index];
			freeObjs.RemoveAt(index);
			if (initialize != null)
			{
				initialize(val);
			}
			return val;
		}
		T val2 = create();
		allObjs.Add(val2);
		return val2;
	}

	public void Free(T obj)
	{
		freeObjs.Add(obj);
	}

	public void ReuseAllObjects()
	{
		freeObjs.Clear();
		freeObjs.AddRange(allObjs);
	}
}
