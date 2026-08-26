using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class ExecuteMethodConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (!(context.ModelType == null))
		{
			context.Application.OnExecute(async () => await OnExecute(context));
		}
	}

	private async Task<int> OnExecute(ConventionContext context)
	{
		TypeInfo typeInfo = context.ModelType.GetTypeInfo();
		MethodInfo method2;
		MethodInfo method;
		try
		{
			method = typeInfo.GetMethod("OnExecute", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			method2 = typeInfo.GetMethod("OnExecuteAsync", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}
		catch (AmbiguousMatchException innerException)
		{
			throw new InvalidOperationException("Could not determine which 'OnExecute' or 'OnExecuteAsync' method to use. Multiple methods with this name were found", innerException);
		}
		if (method != null && method2 != null)
		{
			throw new InvalidOperationException("Could not determine which 'OnExecute' or 'OnExecuteAsync' method to use. Multiple methods with this name were found");
		}
		method = method ?? method2;
		if (method == null)
		{
			throw new InvalidOperationException("No method named 'OnExecute' or 'OnExecuteAsync' could be found");
		}
		object[] arguments = ReflectionHelper.BindParameters(method, context.Application);
		object model = context.ModelAccessor.GetModel();
		if (method.ReturnType == typeof(Task) || method.ReturnType == typeof(Task<int>))
		{
			return await InvokeAsync(method, model, arguments);
		}
		if (method.ReturnType == typeof(void) || method.ReturnType == typeof(int))
		{
			return Invoke(method, model, arguments);
		}
		throw new InvalidOperationException(Strings.InvalidOnExecuteReturnType(method.Name));
	}

	private async Task<int> InvokeAsync(MethodInfo method, object instance, object[] arguments)
	{
		_ = 1;
		try
		{
			Task task = (Task)method.Invoke(instance, arguments);
			if (task is Task<int> task2)
			{
				return await task2;
			}
			await task;
		}
		catch (TargetInvocationException ex)
		{
			ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
		}
		return 0;
	}

	private int Invoke(MethodInfo method, object instance, object[] arguments)
	{
		try
		{
			object obj = method.Invoke(instance, arguments);
			if (method.ReturnType == typeof(int))
			{
				return (int)obj;
			}
		}
		catch (TargetInvocationException ex)
		{
			ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
		}
		return 0;
	}
}
