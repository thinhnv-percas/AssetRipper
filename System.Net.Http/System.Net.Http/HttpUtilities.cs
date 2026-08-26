using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal static class HttpUtilities
{
	internal static Version DefaultRequestVersion => HttpVersionInternal.Version11;

	internal static Version DefaultResponseVersion => HttpVersionInternal.Version11;

	internal static bool IsHttpUri(Uri uri)
	{
		string scheme = uri.Scheme;
		if (!string.Equals("http", scheme, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals("https", scheme, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	internal static bool HandleFaultsAndCancelation<T>(Task task, TaskCompletionSource<T> tcs)
	{
		if (task.IsFaulted)
		{
			tcs.TrySetException(task.Exception.GetBaseException());
			return true;
		}
		if (task.IsCanceled)
		{
			tcs.TrySetCanceled();
			return true;
		}
		return false;
	}

	internal static Task ContinueWithStandard(this Task task, Action<Task> continuation)
	{
		return task.ContinueWith(continuation, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
	}

	internal static Task ContinueWithStandard(this Task task, object state, Action<Task, object> continuation)
	{
		return task.ContinueWith(continuation, state, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
	}

	internal static Task ContinueWithStandard<T>(this Task<T> task, Action<Task<T>> continuation)
	{
		return task.ContinueWith(continuation, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
	}

	internal static Task ContinueWithStandard<T>(this Task<T> task, object state, Action<Task<T>, object> continuation)
	{
		return task.ContinueWith(continuation, state, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
	}
}
