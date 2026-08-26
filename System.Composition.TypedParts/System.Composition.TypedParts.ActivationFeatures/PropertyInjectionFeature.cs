using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Composition.TypedParts.ActivationFeatures;

internal class PropertyInjectionFeature : ActivationFeature
{
	private readonly AttributedModelProvider _attributeContext;

	private static readonly MethodInfo s_activatorInvokeMethod = typeof(CompositeActivator).GetTypeInfo().GetDeclaredMethod("Invoke");

	public PropertyInjectionFeature(AttributedModelProvider attributeContext)
	{
		_attributeContext = attributeContext;
	}

	public override IEnumerable<CompositionDependency> GetDependencies(TypeInfo partType, DependencyAccessor definitionAccessor)
	{
		Type type = partType.AsType();
		var array = (from pi in type.GetRuntimeProperties()
			where pi.CanWrite && pi.SetMethod.IsPublic && !pi.SetMethod.IsStatic
			let attrs = _attributeContext.GetDeclaredAttributes(pi.DeclaringType, pi).ToArray()
			let site = new PropertyImportSite(pi)
			where attrs.Any((Attribute a) => a is ImportAttribute || a is ImportManyAttribute)
			select new
			{
				Site = site,
				ImportInfo = ContractHelpers.GetImportInfo(pi.PropertyType, attrs, site)
			}).ToArray();
		if (array.Length == 0)
		{
			return ActivationFeature.NoDependencies;
		}
		List<CompositionDependency> list = new List<CompositionDependency>();
		var array2 = array;
		foreach (var anon in array2)
		{
			CompositionDependency dependency;
			if (!anon.ImportInfo.AllowDefault)
			{
				list.Add(definitionAccessor.ResolveRequiredDependency(anon.Site, anon.ImportInfo.Contract, isPrerequisite: false));
			}
			else if (definitionAccessor.TryResolveOptionalDependency(anon.Site, anon.ImportInfo.Contract, isPrerequisite: false, out dependency))
			{
				list.Add(dependency);
			}
		}
		return list;
	}

	public override CompositeActivator RewriteActivator(TypeInfo partType, CompositeActivator activator, IDictionary<string, object> partMetadata, IEnumerable<CompositionDependency> dependencies)
	{
		Dictionary<PropertyInfo, CompositionDependency> dictionary = dependencies.Where((CompositionDependency dep) => dep.Site is PropertyImportSite).ToDictionary((CompositionDependency d) => ((PropertyImportSite)d.Site).Property);
		if (dictionary.Count == 0)
		{
			return activator;
		}
		ParameterExpression parameterExpression = Expression.Parameter(typeof(LifetimeContext));
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(CompositionOperation));
		ParameterExpression parameterExpression3 = Expression.Parameter(typeof(object));
		ParameterExpression parameterExpression4 = Expression.Variable(partType.AsType());
		List<Expression> list = new List<Expression>();
		BinaryExpression item = Expression.Assign(parameterExpression4, Expression.Convert(parameterExpression3, partType.AsType()));
		list.Add(item);
		foreach (KeyValuePair<PropertyInfo, CompositionDependency> item3 in dictionary)
		{
			PropertyInfo key = item3.Key;
			BinaryExpression item2 = Expression.Assign(Expression.MakeMemberAccess(parameterExpression4, key), Expression.Convert(Expression.Call(Expression.Constant(item3.Value.Target.GetDescriptor().Activator), s_activatorInvokeMethod, parameterExpression, parameterExpression2), key.PropertyType));
			list.Add(item2);
		}
		list.Add(parameterExpression3);
		BlockExpression body = Expression.Block(new ParameterExpression[1] { parameterExpression4 }, list);
		Func<object, LifetimeContext, CompositionOperation, object> setAction = Expression.Lambda<Func<object, LifetimeContext, CompositionOperation, object>>(body, new ParameterExpression[3] { parameterExpression3, parameterExpression, parameterExpression2 }).Compile();
		return delegate(LifetimeContext c, CompositionOperation o)
		{
			object i = activator(c, o);
			o.AddNonPrerequisiteAction(delegate
			{
				setAction(i, c, o);
			});
			return i;
		};
	}
}
