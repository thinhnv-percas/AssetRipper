using System;
using System.Threading.Tasks;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public static class ExtMethods
	{
		public static void ContinueScript(this Task task, Action act)
		{
			if (task.IsCompleted)
			{
				act();
			}
			else
			{
				task.ContinueWith(delegate
				{
					act();
				}, TaskScheduler.FromCurrentSynchronizationContext());
			}
		}

		public static void ContinueScript(this Task<Script> task, Action<Script> act)
		{
			if (task.IsCompleted)
			{
				act(task.Result);
			}
			else
			{
				task.ContinueWith(delegate
				{
					act(task.Result);
				}, TaskScheduler.FromCurrentSynchronizationContext());
			}
		}
	}
}
