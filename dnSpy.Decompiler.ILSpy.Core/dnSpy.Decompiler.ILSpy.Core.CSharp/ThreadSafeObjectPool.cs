using System;
using System.Collections.Generic;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class ThreadSafeObjectPool<T> where T : class
{
	private readonly List<T> freeObjs;

	private readonly Func<T> createObject;

	private readonly Action<T> resetObject;

	private readonly object lockObj = new object();

	public ThreadSafeObjectPool(int size, Func<T> createObject, Action<T> resetObject)
	{
		if (size <= 0)
		{
			throw new ArgumentException();
		}
		freeObjs = new List<T>(size);
		this.createObject = createObject;
		this.resetObject = resetObject;
	}

	public T Allocate()
	{
		lock (lockObj)
		{
			if (freeObjs.Count > 0)
			{
				int index = freeObjs.Count - 1;
				T result = freeObjs[index];
				freeObjs.RemoveAt(index);
				return result;
			}
			return createObject();
		}
	}

	public void Free(T obj)
	{
		resetObject(obj);
		lock (lockObj)
		{
			freeObjs.Add(obj);
		}
	}
}
