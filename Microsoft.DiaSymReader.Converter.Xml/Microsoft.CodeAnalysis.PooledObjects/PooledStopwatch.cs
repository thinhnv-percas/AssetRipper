using System;
using System.Diagnostics;

namespace Microsoft.CodeAnalysis.PooledObjects;

internal class PooledStopwatch : Stopwatch
{
	private static readonly ObjectPool<PooledStopwatch> s_poolInstance = CreatePool();

	private readonly ObjectPool<PooledStopwatch> _pool;

	public Func<object, TimeSpan, TimeSpan> UpdateValueFactory { get; }

	private PooledStopwatch(ObjectPool<PooledStopwatch> pool)
	{
		_pool = pool;
		UpdateValueFactory = (object _, TimeSpan accumulated) => accumulated + base.Elapsed;
	}

	public void Free()
	{
		Reset();
		_pool?.Free(this);
	}

	public static ObjectPool<PooledStopwatch> CreatePool()
	{
		ObjectPool<PooledStopwatch> pool = null;
		pool = new ObjectPool<PooledStopwatch>(() => new PooledStopwatch(pool), 128);
		return pool;
	}

	public static PooledStopwatch StartInstance()
	{
		PooledStopwatch pooledStopwatch = s_poolInstance.Allocate();
		pooledStopwatch.Restart();
		return pooledStopwatch;
	}
}
