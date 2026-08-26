using System;
using System.Collections.Generic;
using System.Threading;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public class DecompilationContext
{
	private const int STRINGBUILDER_POOL_SIZE = 256;

	private readonly object lockObj = new object();

	private readonly Dictionary<Type, object> cachedObjs = new Dictionary<Type, object>();

	public CancellationToken CancellationToken { get; set; }

	public Func<MethodDef, bool> IsBodyModified { get; set; }

	public Func<IDisposable> GetDisableAssemblyLoad { get; set; }

	public bool CalculateILSpans { get; set; }

	public bool AsyncMethodBodyDecompilation { get; set; }

	public DecompilationContext()
	{
		CancellationToken = CancellationToken.None;
		IsBodyModified = (MethodDef m) => false;
		AsyncMethodBodyDecompilation = true;
	}

	public IDisposable DisableAssemblyLoad()
	{
		return GetDisableAssemblyLoad?.Invoke();
	}

	public T GetOrCreate<T>() where T : class, new()
	{
		lock (lockObj)
		{
			if (cachedObjs.TryGetValue(typeof(T), out var value))
			{
				return (T)value;
			}
			T val = new T();
			cachedObjs.Add(typeof(T), val);
			return val;
		}
	}

	public T GetOrCreate<T>(Func<T> creator) where T : class
	{
		lock (lockObj)
		{
			if (cachedObjs.TryGetValue(typeof(T), out var value))
			{
				return (T)value;
			}
			T val = creator();
			cachedObjs.Add(typeof(T), val);
			return val;
		}
	}
}
