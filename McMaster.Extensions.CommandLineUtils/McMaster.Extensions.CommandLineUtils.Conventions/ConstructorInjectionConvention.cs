using System;
using System.Linq;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class ConstructorInjectionConvention : IConvention
{
	private readonly IServiceProvider _additionalServices;

	private static readonly MethodInfo s_applyMethod = typeof(ConstructorInjectionConvention).GetRuntimeMethods().Single((MethodInfo m) => m.Name == "ApplyImpl");

	public ConstructorInjectionConvention()
	{
	}

	public ConstructorInjectionConvention(IServiceProvider additionalServices)
	{
		_additionalServices = additionalServices;
	}

	public virtual void Apply(ConventionContext context)
	{
		if (_additionalServices != null)
		{
			context.Application.AdditionalServices = _additionalServices;
		}
		if (!(context.ModelType == null))
		{
			s_applyMethod.MakeGenericMethod(context.ModelType).Invoke(this, new object[1] { context });
		}
	}

	private void ApplyImpl<TModel>(ConventionContext context) where TModel : class
	{
		ConstructorInfo[] constructors = typeof(TModel).GetTypeInfo().GetConstructors(BindingFlags.Instance | BindingFlags.Public);
		Func<TModel> func = FindMatchedConstructor<TModel>(constructors, context.Application, constructors.Length == 1);
		if (func != null)
		{
			((CommandLineApplication<TModel>)context.Application).ModelFactory = func;
		}
	}

	private static Func<TModel> FindMatchedConstructor<TModel>(ConstructorInfo[] constructors, IServiceProvider services, bool throwIfNoParameterTypeRegistered = false)
	{
		if (constructors.Length == 0)
		{
			return delegate
			{
				throw new InvalidOperationException(Strings.NoAnyPublicConstuctorFound(typeof(TModel)));
			};
		}
		foreach (ConstructorInfo ctorCandidate in constructors.OrderByDescending((ConstructorInfo c) => c.GetParameters().Length))
		{
			ParameterInfo[] array = ctorCandidate.GetParameters().ToArray();
			if (array.Length == 0)
			{
				return null;
			}
			object[] args = new object[array.Length];
			for (int num = 0; num < array.Length; num++)
			{
				Type paramType = array[num].ParameterType;
				object service = services.GetService(paramType);
				if (service == null)
				{
					if (!throwIfNoParameterTypeRegistered)
					{
						break;
					}
					return delegate
					{
						throw new InvalidOperationException(Strings.NoParameterTypeRegistered(ctorCandidate.DeclaringType, paramType));
					};
				}
				args[num] = service;
				if (num == array.Length - 1)
				{
					return () => (TModel)ctorCandidate.Invoke(args);
				}
			}
		}
		return delegate
		{
			throw new InvalidOperationException(Strings.NoMatchedConstructorFound(typeof(TModel)));
		};
	}
}
