using System.Collections.Generic;
using System.ComponentModel;
using System.Composition.Hosting.Properties;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Internal;

namespace System.Composition.Hosting.Providers.Metadata;

internal static class MetadataViewProvider
{
	private static readonly MethodInfo s_getMetadataValueMethod = typeof(MetadataViewProvider).GetTypeInfo().GetDeclaredMethod("GetMetadataValue");

	public static Func<IDictionary<string, object>, TMetadata> GetMetadataViewProvider<TMetadata>()
	{
		if ((object)typeof(TMetadata) == typeof(IDictionary<string, object>))
		{
			return (IDictionary<string, object> m) => (TMetadata)m;
		}
		if (!typeof(TMetadata).GetTypeInfo().IsClass)
		{
			throw new CompositionFailedException(string.Format(System.Composition.Hosting.Properties.Resources.MetadataViewProvider_InvalidViewImplementation, new object[1] { typeof(TMetadata).Name }));
		}
		TypeInfo typeInfo = typeof(TMetadata).GetTypeInfo();
		ConstructorInfo constructorInfo = typeInfo.DeclaredConstructors.SingleOrDefault(delegate(ConstructorInfo ci)
		{
			ParameterInfo[] parameters = ci.GetParameters();
			return ci.IsPublic && parameters.Length == 1 && (object)parameters[0].ParameterType == typeof(IDictionary<string, object>);
		});
		if ((object)constructorInfo != null)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IDictionary<string, object>), "metadata");
			return Expression.Lambda<Func<IDictionary<string, object>, TMetadata>>(Expression.New(constructorInfo, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
		}
		ConstructorInfo constructorInfo2 = typeInfo.DeclaredConstructors.SingleOrDefault((ConstructorInfo ci) => ci.IsPublic && ci.GetParameters().Length == 0);
		if ((object)constructorInfo2 != null)
		{
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(IDictionary<string, object>), "metadata");
			ParameterExpression parameterExpression3 = Expression.Variable(typeof(TMetadata), "result");
			List<Expression> list = new List<Expression>();
			list.Add(Expression.Assign(parameterExpression3, Expression.New(constructorInfo2)));
			foreach (PropertyInfo item2 in typeof(TMetadata).GetTypeInfo().DeclaredProperties.Where((PropertyInfo prop) => (object)prop.GetMethod != null && prop.GetMethod.IsPublic && !prop.GetMethod.IsStatic && (object)prop.SetMethod != null && prop.SetMethod.IsPublic && !prop.SetMethod.IsStatic))
			{
				ConstantExpression arg = Expression.Constant(item2.GetCustomAttribute<DefaultValueAttribute>(inherit: false), typeof(DefaultValueAttribute));
				ConstantExpression arg2 = Expression.Constant(item2.Name, typeof(string));
				MethodInfo method = s_getMetadataValueMethod.MakeGenericMethod(item2.PropertyType);
				BinaryExpression item = Expression.Assign(Expression.Property(parameterExpression3, item2), Expression.Call(null, method, parameterExpression2, arg2, arg));
				list.Add(item);
			}
			list.Add(parameterExpression3);
			return Expression.Lambda<Func<IDictionary<string, object>, TMetadata>>(Expression.Block(new ParameterExpression[1] { parameterExpression3 }, list), new ParameterExpression[1] { parameterExpression2 }).Compile();
		}
		throw new CompositionFailedException(string.Format(System.Composition.Hosting.Properties.Resources.MetadataViewProvider_InvalidViewImplementation, new object[1] { typeof(TMetadata).Name }));
	}

	private static TValue GetMetadataValue<TValue>(IDictionary<string, object> metadata, string name, DefaultValueAttribute defaultValue)
	{
		if (metadata.TryGetValue(name, out var value))
		{
			return (TValue)value;
		}
		if (defaultValue != null)
		{
			return (TValue)defaultValue.Value;
		}
		string message = string.Format(System.Composition.Hosting.Properties.Resources.MetadataViewProvider_MissingMetadata, new object[1] { name });
		throw ThrowHelper.CompositionException(message);
	}
}
