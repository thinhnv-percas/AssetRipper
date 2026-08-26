using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Composition.Diagnostics;
using Microsoft.Internal;

namespace System.Composition.Convention;

public class PartConventionBuilder
{
	private readonly Type[] _emptyTypeArray = EmptyArray<Type>.Value;

	private static List<Attribute> s_onImportsSatisfiedAttributeList;

	private static readonly List<Attribute> s_importingConstructorList = new List<Attribute>
	{
		new ImportingConstructorAttribute()
	};

	private static readonly Type s_exportAttributeType = typeof(ExportAttribute);

	private readonly List<ExportConventionBuilder> _typeExportBuilders;

	private readonly List<ImportConventionBuilder> _constructorImportBuilders;

	private bool _isShared;

	private string _sharingBoundary;

	private List<Tuple<string, object>> _metadataItems;

	private List<Tuple<string, Func<Type, object>>> _metadataItemFuncs;

	private Func<IEnumerable<ConstructorInfo>, ConstructorInfo> _constructorFilter;

	private Action<ParameterInfo, ImportConventionBuilder> _configureConstuctorImports;

	private readonly List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ExportConventionBuilder>, Type>> _propertyExports;

	private readonly List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ImportConventionBuilder>>> _propertyImports;

	private readonly List<Tuple<Predicate<Type>, Action<Type, ExportConventionBuilder>>> _interfaceExports;

	private readonly List<Predicate<MethodInfo>> _methodImportsSatisfiedNotifications;

	internal Predicate<Type> SelectType { get; private set; }

	internal PartConventionBuilder(Predicate<Type> selectType)
	{
		SelectType = selectType;
		_typeExportBuilders = new List<ExportConventionBuilder>();
		_constructorImportBuilders = new List<ImportConventionBuilder>();
		_propertyExports = new List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ExportConventionBuilder>, Type>>();
		_propertyImports = new List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ImportConventionBuilder>>>();
		_interfaceExports = new List<Tuple<Predicate<Type>, Action<Type, ExportConventionBuilder>>>();
		_methodImportsSatisfiedNotifications = new List<Predicate<MethodInfo>>();
	}

	public PartConventionBuilder Export()
	{
		ExportConventionBuilder item = new ExportConventionBuilder();
		_typeExportBuilders.Add(item);
		return this;
	}

	public PartConventionBuilder Export(Action<ExportConventionBuilder> exportConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(exportConfiguration, "exportConfiguration");
		ExportConventionBuilder exportConventionBuilder = new ExportConventionBuilder();
		exportConfiguration(exportConventionBuilder);
		_typeExportBuilders.Add(exportConventionBuilder);
		return this;
	}

	public PartConventionBuilder Export<T>()
	{
		ExportConventionBuilder item = new ExportConventionBuilder().AsContractType<T>();
		_typeExportBuilders.Add(item);
		return this;
	}

	public PartConventionBuilder Export<T>(Action<ExportConventionBuilder> exportConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(exportConfiguration, "exportConfiguration");
		ExportConventionBuilder exportConventionBuilder = new ExportConventionBuilder().AsContractType<T>();
		exportConfiguration(exportConventionBuilder);
		_typeExportBuilders.Add(exportConventionBuilder);
		return this;
	}

	public PartConventionBuilder SelectConstructor(Func<IEnumerable<ConstructorInfo>, ConstructorInfo> constructorSelector)
	{
		Microsoft.Internal.Requires.NotNull(constructorSelector, "constructorSelector");
		_constructorFilter = constructorSelector;
		return this;
	}

	public PartConventionBuilder SelectConstructor(Func<IEnumerable<ConstructorInfo>, ConstructorInfo> constructorSelector, Action<ParameterInfo, ImportConventionBuilder> importConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(importConfiguration, "importConfiguration");
		SelectConstructor(constructorSelector);
		_configureConstuctorImports = importConfiguration;
		return this;
	}

	public PartConventionBuilder ExportInterfaces(Predicate<Type> interfaceFilter)
	{
		Microsoft.Internal.Requires.NotNull(interfaceFilter, "interfaceFilter");
		return ExportInterfacesImpl(interfaceFilter, null);
	}

	public PartConventionBuilder ExportInterfaces()
	{
		return ExportInterfaces((Type t) => true);
	}

	public PartConventionBuilder ExportInterfaces(Predicate<Type> interfaceFilter, Action<Type, ExportConventionBuilder> exportConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(interfaceFilter, "interfaceFilter");
		Microsoft.Internal.Requires.NotNull(exportConfiguration, "exportConfiguration");
		return ExportInterfacesImpl(interfaceFilter, exportConfiguration);
	}

	private PartConventionBuilder ExportInterfacesImpl(Predicate<Type> interfaceFilter, Action<Type, ExportConventionBuilder> exportConfiguration)
	{
		_interfaceExports.Add(Tuple.Create(interfaceFilter, exportConfiguration));
		return this;
	}

	public PartConventionBuilder ExportProperties(Predicate<PropertyInfo> propertyFilter)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		return ExportPropertiesImpl(propertyFilter, null);
	}

	public PartConventionBuilder ExportProperties(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ExportConventionBuilder> exportConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		Microsoft.Internal.Requires.NotNull(exportConfiguration, "exportConfiguration");
		return ExportPropertiesImpl(propertyFilter, exportConfiguration);
	}

	private PartConventionBuilder ExportPropertiesImpl(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ExportConventionBuilder> exportConfiguration)
	{
		_propertyExports.Add(Tuple.Create<Predicate<PropertyInfo>, Action<PropertyInfo, ExportConventionBuilder>, Type>(propertyFilter, exportConfiguration, null));
		return this;
	}

	public PartConventionBuilder ExportProperties<T>(Predicate<PropertyInfo> propertyFilter)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		return ExportPropertiesImpl<T>(propertyFilter, null);
	}

	public PartConventionBuilder ExportProperties<T>(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ExportConventionBuilder> exportConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		Microsoft.Internal.Requires.NotNull(exportConfiguration, "exportConfiguration");
		return ExportPropertiesImpl<T>(propertyFilter, exportConfiguration);
	}

	private PartConventionBuilder ExportPropertiesImpl<T>(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ExportConventionBuilder> exportConfiguration)
	{
		_propertyExports.Add(Tuple.Create(propertyFilter, exportConfiguration, typeof(T)));
		return this;
	}

	public PartConventionBuilder ImportProperties(Predicate<PropertyInfo> propertyFilter)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		return ImportPropertiesImpl(propertyFilter, null);
	}

	public PartConventionBuilder ImportProperties(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ImportConventionBuilder> importConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		Microsoft.Internal.Requires.NotNull(importConfiguration, "importConfiguration");
		return ImportPropertiesImpl(propertyFilter, importConfiguration);
	}

	private PartConventionBuilder ImportPropertiesImpl(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ImportConventionBuilder> importConfiguration)
	{
		_propertyImports.Add(Tuple.Create(propertyFilter, importConfiguration));
		return this;
	}

	public PartConventionBuilder ImportProperties<T>(Predicate<PropertyInfo> propertyFilter)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		return ImportPropertiesImpl<T>(propertyFilter, null);
	}

	public PartConventionBuilder ImportProperties<T>(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ImportConventionBuilder> importConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertyFilter, "propertyFilter");
		Microsoft.Internal.Requires.NotNull(importConfiguration, "importConfiguration");
		return ImportPropertiesImpl<T>(propertyFilter, importConfiguration);
	}

	private PartConventionBuilder ImportPropertiesImpl<T>(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ImportConventionBuilder> importConfiguration)
	{
		Predicate<PropertyInfo> item = (PropertyInfo pi) => pi.PropertyType.Equals(typeof(T)) && (propertyFilter == null || propertyFilter(pi));
		_propertyImports.Add(Tuple.Create(item, importConfiguration));
		return this;
	}

	public PartConventionBuilder NotifyImportsSatisfied(Predicate<MethodInfo> methodFilter)
	{
		_methodImportsSatisfiedNotifications.Add(methodFilter);
		return this;
	}

	public PartConventionBuilder Shared()
	{
		return SharedImpl(null);
	}

	public PartConventionBuilder Shared(string sharingBoundary)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(sharingBoundary, "sharingBoundary");
		return SharedImpl(sharingBoundary);
	}

	private PartConventionBuilder SharedImpl(string sharingBoundary)
	{
		_isShared = true;
		_sharingBoundary = sharingBoundary;
		return this;
	}

	public PartConventionBuilder AddPartMetadata(string name, object value)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(name, "name");
		if (_metadataItems == null)
		{
			_metadataItems = new List<Tuple<string, object>>();
		}
		_metadataItems.Add(Tuple.Create(name, value));
		return this;
	}

	public PartConventionBuilder AddPartMetadata(string name, Func<Type, object> getValueFromPartType)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(name, "name");
		Microsoft.Internal.Requires.NotNull(getValueFromPartType, "getValueFromPartType");
		if (_metadataItemFuncs == null)
		{
			_metadataItemFuncs = new List<Tuple<string, Func<Type, object>>>();
		}
		_metadataItemFuncs.Add(Tuple.Create(name, getValueFromPartType));
		return this;
	}

	private static bool MemberHasExportMetadata(MemberInfo member)
	{
		foreach (Attribute attribute in member.GetAttributes<Attribute>())
		{
			if (attribute is ExportMetadataAttribute)
			{
				return true;
			}
			Type type = attribute.GetType();
			if ((object)type != s_exportAttributeType && type.GetTypeInfo().IsAttributeDefined<MetadataAttributeAttribute>(inherit: true))
			{
				return true;
			}
		}
		return false;
	}

	internal IEnumerable<Attribute> BuildTypeAttributes(Type type)
	{
		List<Attribute> attributes = new List<Attribute>();
		if (_typeExportBuilders != null)
		{
			if (type.GetTypeInfo().GetFirstAttribute<ExportAttribute>() != null || MemberHasExportMetadata(type.GetTypeInfo()))
			{
				CompositionTrace.Registration_TypeExportConventionOverridden(type);
			}
			else
			{
				foreach (ExportConventionBuilder typeExportBuilder in _typeExportBuilders)
				{
					typeExportBuilder.BuildAttributes(type, ref attributes);
				}
			}
		}
		if (_isShared)
		{
			if (type.GetTypeInfo().GetFirstAttribute<SharedAttribute>() != null)
			{
				CompositionTrace.Registration_PartCreationConventionOverridden(type);
			}
			else
			{
				attributes.Add((_sharingBoundary == null) ? new SharedAttribute() : new SharedAttribute(_sharingBoundary));
			}
		}
		if (_metadataItems != null)
		{
			if (type.GetTypeInfo().GetFirstAttribute<PartMetadataAttribute>() != null)
			{
				CompositionTrace.Registration_PartMetadataConventionOverridden(type);
			}
			else
			{
				foreach (Tuple<string, object> metadataItem in _metadataItems)
				{
					attributes.Add(new PartMetadataAttribute(metadataItem.Item1, metadataItem.Item2));
				}
			}
		}
		if (_metadataItemFuncs != null)
		{
			if (type.GetTypeInfo().GetFirstAttribute<PartMetadataAttribute>() != null)
			{
				CompositionTrace.Registration_PartMetadataConventionOverridden(type);
			}
			else
			{
				foreach (Tuple<string, Func<Type, object>> metadataItemFunc in _metadataItemFuncs)
				{
					string item = metadataItemFunc.Item1;
					object value = ((metadataItemFunc.Item2 != null) ? metadataItemFunc.Item2(type) : null);
					attributes.Add(new PartMetadataAttribute(item, value));
				}
			}
		}
		if (_interfaceExports.Any() && _typeExportBuilders != null)
		{
			if (type.GetTypeInfo().GetFirstAttribute<ExportAttribute>() != null || MemberHasExportMetadata(type.GetTypeInfo()))
			{
				CompositionTrace.Registration_TypeExportConventionOverridden(type);
			}
			else
			{
				foreach (Type implementedInterface in type.GetTypeInfo().ImplementedInterfaces)
				{
					if ((object)implementedInterface == typeof(IDisposable))
					{
						continue;
					}
					foreach (Tuple<Predicate<Type>, Action<Type, ExportConventionBuilder>> interfaceExport in _interfaceExports)
					{
						if (interfaceExport.Item1 != null && interfaceExport.Item1(implementedInterface))
						{
							ExportConventionBuilder exportConventionBuilder = new ExportConventionBuilder();
							exportConventionBuilder.AsContractType(implementedInterface);
							if (interfaceExport.Item2 != null)
							{
								interfaceExport.Item2(implementedInterface, exportConventionBuilder);
							}
							exportConventionBuilder.BuildAttributes(implementedInterface, ref attributes);
						}
					}
				}
			}
		}
		return attributes;
	}

	internal bool BuildConstructorAttributes(Type type, ref List<Tuple<object, List<Attribute>>> configuredMembers)
	{
		IEnumerable<ConstructorInfo> declaredConstructors = type.GetTypeInfo().DeclaredConstructors;
		foreach (ConstructorInfo item in declaredConstructors)
		{
			IEnumerable<Attribute> customAttributes = CustomAttributeExtensions.GetCustomAttributes(item, typeof(ImportingConstructorAttribute), inherit: false);
			if (customAttributes.Count() != 0)
			{
				CompositionTrace.Registration_ConstructorConventionOverridden(type);
				return true;
			}
		}
		if (_constructorFilter != null)
		{
			ConstructorInfo constructorInfo = _constructorFilter(declaredConstructors);
			if ((object)constructorInfo != null)
			{
				ConfigureConstructorAttributes(constructorInfo, ref configuredMembers, _configureConstuctorImports);
			}
			return true;
		}
		if (_configureConstuctorImports != null)
		{
			bool result = false;
			{
				foreach (ConstructorInfo item2 in FindLongestConstructors(declaredConstructors))
				{
					ConfigureConstructorAttributes(item2, ref configuredMembers, _configureConstuctorImports);
					result = true;
				}
				return result;
			}
		}
		return false;
	}

	internal static void BuildDefaultConstructorAttributes(Type type, ref List<Tuple<object, List<Attribute>>> configuredMembers)
	{
		IEnumerable<ConstructorInfo> declaredConstructors = type.GetTypeInfo().DeclaredConstructors;
		foreach (ConstructorInfo item in FindLongestConstructors(declaredConstructors))
		{
			ConfigureConstructorAttributes(item, ref configuredMembers, null);
		}
	}

	private static void ConfigureConstructorAttributes(ConstructorInfo constructorInfo, ref List<Tuple<object, List<Attribute>>> configuredMembers, Action<ParameterInfo, ImportConventionBuilder> configureConstuctorImports)
	{
		if (configuredMembers == null)
		{
			configuredMembers = new List<Tuple<object, List<Attribute>>>();
		}
		configuredMembers.Add(Tuple.Create((object)constructorInfo, s_importingConstructorList));
		ParameterInfo[] parameters = constructorInfo.GetParameters();
		ParameterInfo[] array = parameters;
		foreach (ParameterInfo parameterInfo in array)
		{
			if (parameterInfo.GetFirstAttribute<ImportAttribute>() != null || parameterInfo.GetFirstAttribute<ImportManyAttribute>() != null)
			{
				CompositionTrace.Registration_ParameterImportConventionOverridden(parameterInfo, constructorInfo);
				continue;
			}
			ImportConventionBuilder importConventionBuilder = new ImportConventionBuilder();
			configureConstuctorImports?.Invoke(parameterInfo, importConventionBuilder);
			List<Attribute> attributes = null;
			importConventionBuilder.BuildAttributes(parameterInfo.ParameterType, ref attributes);
			configuredMembers.Add(Tuple.Create((object)parameterInfo, attributes));
		}
	}

	internal void BuildOnImportsSatisfiedNotification(Type type, ref List<Tuple<object, List<Attribute>>> configuredMembers)
	{
		if (_methodImportsSatisfiedNotifications == null)
		{
			return;
		}
		foreach (MethodInfo runtimeMethod2 in type.GetRuntimeMethods())
		{
			if ((object)runtimeMethod2.ReturnParameter.ParameterType != typeof(void) || runtimeMethod2.GetParameters().Length != 0)
			{
				continue;
			}
			MethodInfo runtimeMethod = runtimeMethod2.DeclaringType.GetRuntimeMethod(runtimeMethod2.Name, _emptyTypeArray);
			if ((object)runtimeMethod == null)
			{
				continue;
			}
			bool flag = false;
			bool flag2 = false;
			foreach (Predicate<MethodInfo> methodImportsSatisfiedNotification in _methodImportsSatisfiedNotifications)
			{
				if (methodImportsSatisfiedNotification(runtimeMethod))
				{
					if (!flag)
					{
						flag2 = runtimeMethod2.GetFirstAttribute<OnImportsSatisfiedAttribute>() != null;
						flag = true;
					}
					if (flag2)
					{
						CompositionTrace.Registration_OnSatisfiedImportNotificationOverridden(type, runtimeMethod2);
						break;
					}
					if (s_onImportsSatisfiedAttributeList == null)
					{
						List<Attribute> list = new List<Attribute>();
						list.Add(new OnImportsSatisfiedAttribute());
						s_onImportsSatisfiedAttributeList = list;
					}
					configuredMembers.Add(new Tuple<object, List<Attribute>>(runtimeMethod2, s_onImportsSatisfiedAttributeList));
				}
			}
		}
	}

	internal void BuildPropertyAttributes(Type type, ref List<Tuple<object, List<Attribute>>> configuredMembers)
	{
		if (!_propertyImports.Any() && !_propertyExports.Any())
		{
			return;
		}
		foreach (PropertyInfo runtimeProperty in type.GetRuntimeProperties())
		{
			List<Attribute> attributes = null;
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			PropertyInfo propertyInfo = null;
			foreach (Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ImportConventionBuilder>> propertyImport in _propertyImports)
			{
				if ((object)propertyInfo == null)
				{
					propertyInfo = runtimeProperty.DeclaringType.GetRuntimeProperty(runtimeProperty.Name);
				}
				if (propertyImport.Item1 != null && propertyImport.Item1(propertyInfo))
				{
					ImportConventionBuilder importConventionBuilder = new ImportConventionBuilder();
					if (propertyImport.Item2 != null)
					{
						propertyImport.Item2(runtimeProperty, importConventionBuilder);
					}
					if (!flag)
					{
						flag2 = runtimeProperty.GetFirstAttribute<ImportAttribute>() != null || runtimeProperty.GetFirstAttribute<ImportManyAttribute>() != null;
						flag = true;
					}
					if (flag2)
					{
						CompositionTrace.Registration_MemberImportConventionOverridden(type, runtimeProperty);
						break;
					}
					importConventionBuilder.BuildAttributes(runtimeProperty.PropertyType, ref attributes);
					num++;
				}
				if (num > 1)
				{
					CompositionTrace.Registration_MemberImportConventionMatchedTwice(type, runtimeProperty);
				}
			}
			flag = false;
			flag2 = false;
			foreach (Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ExportConventionBuilder>, Type> propertyExport in _propertyExports)
			{
				if ((object)propertyInfo == null)
				{
					propertyInfo = runtimeProperty.DeclaringType.GetRuntimeProperty(runtimeProperty.Name);
				}
				if (propertyExport.Item1 != null && propertyExport.Item1(propertyInfo))
				{
					ExportConventionBuilder exportConventionBuilder = new ExportConventionBuilder();
					if ((object)propertyExport.Item3 != null)
					{
						exportConventionBuilder.AsContractType(propertyExport.Item3);
					}
					if (propertyExport.Item2 != null)
					{
						propertyExport.Item2(runtimeProperty, exportConventionBuilder);
					}
					if (!flag)
					{
						flag2 = runtimeProperty.GetFirstAttribute<ExportAttribute>() != null || MemberHasExportMetadata(runtimeProperty);
						flag = true;
					}
					if (flag2)
					{
						CompositionTrace.Registration_MemberExportConventionOverridden(type, runtimeProperty);
						break;
					}
					exportConventionBuilder.BuildAttributes(runtimeProperty.PropertyType, ref attributes);
				}
			}
			if (attributes != null)
			{
				if (configuredMembers == null)
				{
					configuredMembers = new List<Tuple<object, List<Attribute>>>();
				}
				configuredMembers.Add(Tuple.Create((object)runtimeProperty, attributes));
			}
		}
	}

	private static IEnumerable<ConstructorInfo> FindLongestConstructors(IEnumerable<ConstructorInfo> constructors)
	{
		ConstructorInfo longestConstructor = null;
		int argumentsCount = 0;
		int constructorsFound = 0;
		foreach (ConstructorInfo constructor in constructors)
		{
			int num = constructor.GetParameters().Length;
			if (num != 0)
			{
				if (num > argumentsCount)
				{
					longestConstructor = constructor;
					argumentsCount = num;
					constructorsFound = 1;
				}
				else if (num == argumentsCount)
				{
					int num2 = constructorsFound + 1;
					constructorsFound = num2;
				}
			}
		}
		if (constructorsFound > 1)
		{
			foreach (ConstructorInfo constructor2 in constructors)
			{
				int num3 = constructor2.GetParameters().Length;
				if (num3 == argumentsCount)
				{
					yield return constructor2;
				}
			}
		}
		else if (constructorsFound == 1)
		{
			yield return longestConstructor;
		}
	}
}
public class PartConventionBuilder<T> : PartConventionBuilder
{
	private class MethodExpressionAdapter
	{
		private readonly MethodInfo _methodInfo;

		public MethodExpressionAdapter(Expression<Action<T>> methodSelector)
		{
			_methodInfo = SelectMethods(methodSelector);
		}

		public bool VerifyMethodInfo(MethodInfo mi)
		{
			return (object)mi == _methodInfo;
		}

		private static MethodInfo SelectMethods(Expression<Action<T>> methodSelector)
		{
			Microsoft.Internal.Requires.NotNull(methodSelector, "methodSelector");
			Expression body = Reduce(methodSelector).Body;
			if (body.NodeType == ExpressionType.Call)
			{
				MethodInfo method = ((MethodCallExpression)body).Method;
				if ((object)method != null)
				{
					return method;
				}
			}
			throw ExceptionBuilder.Argument_ExpressionMustBeVoidMethodWithNoArguments("methodSelector");
		}

		protected static Expression<Func<T, object>> Reduce(Expression<Func<T, object>> expr)
		{
			while (expr.CanReduce)
			{
				expr = (Expression<Func<T, object>>)expr.Reduce();
			}
			return expr;
		}

		protected static Expression<Action<T>> Reduce(Expression<Action<T>> expr)
		{
			while (expr.CanReduce)
			{
				expr = (Expression<Action<T>>)expr.Reduce();
			}
			return expr;
		}
	}

	private class PropertyExpressionAdapter
	{
		private readonly PropertyInfo _propertyInfo;

		private readonly Action<ImportConventionBuilder> _configureImport;

		private readonly Action<ExportConventionBuilder> _configureExport;

		public PropertyExpressionAdapter(Expression<Func<T, object>> propertySelector, Action<ImportConventionBuilder> configureImport = null, Action<ExportConventionBuilder> configureExport = null)
		{
			_propertyInfo = SelectProperties(propertySelector);
			_configureImport = configureImport;
			_configureExport = configureExport;
		}

		public bool VerifyPropertyInfo(PropertyInfo pi)
		{
			return (object)pi == _propertyInfo;
		}

		public void ConfigureImport(PropertyInfo propertyInfo, ImportConventionBuilder importBuilder)
		{
			if (_configureImport != null)
			{
				_configureImport(importBuilder);
			}
		}

		public void ConfigureExport(PropertyInfo propertyInfo, ExportConventionBuilder exportBuilder)
		{
			if (_configureExport != null)
			{
				_configureExport(exportBuilder);
			}
		}

		private static PropertyInfo SelectProperties(Expression<Func<T, object>> propertySelector)
		{
			Microsoft.Internal.Requires.NotNull(propertySelector, "propertySelector");
			Expression body = Reduce(propertySelector).Body;
			if (body.NodeType == ExpressionType.MemberAccess && ((MemberExpression)body).Member is PropertyInfo result)
			{
				return result;
			}
			throw ExceptionBuilder.Argument_ExpressionMustBePropertyMember("propertySelector");
		}

		protected static Expression<Func<T, object>> Reduce(Expression<Func<T, object>> expr)
		{
			while (expr.CanReduce)
			{
				expr = (Expression<Func<T, object>>)expr.Reduce();
			}
			return expr;
		}
	}

	private class ConstructorExpressionAdapter
	{
		private ConstructorInfo _constructorInfo;

		private Dictionary<ParameterInfo, Action<ImportConventionBuilder>> _importBuilders;

		public ConstructorExpressionAdapter(Expression<Func<ParameterImportConventionBuilder, T>> selectConstructor)
		{
			ParseSelectConstructor(selectConstructor);
		}

		public ConstructorInfo SelectConstructor(IEnumerable<ConstructorInfo> constructorInfos)
		{
			return _constructorInfo;
		}

		public void ConfigureConstructorImports(ParameterInfo parameterInfo, ImportConventionBuilder importBuilder)
		{
			if (_importBuilders != null && _importBuilders.TryGetValue(parameterInfo, out var value))
			{
				value(importBuilder);
			}
		}

		private void ParseSelectConstructor(Expression<Func<ParameterImportConventionBuilder, T>> constructorSelector)
		{
			Microsoft.Internal.Requires.NotNull(constructorSelector, "constructorSelector");
			Expression body = Reduce(constructorSelector).Body;
			if (body.NodeType != ExpressionType.New)
			{
				throw ExceptionBuilder.Argument_ExpressionMustBeNew("constructorSelector");
			}
			NewExpression newExpression = (NewExpression)body;
			_constructorInfo = newExpression.Constructor;
			int num = 0;
			ParameterInfo[] parameters = _constructorInfo.GetParameters();
			foreach (Expression argument in newExpression.Arguments)
			{
				if (argument.NodeType != ExpressionType.Call)
				{
					continue;
				}
				MethodCallExpression methodCallExpression = (MethodCallExpression)argument;
				if (methodCallExpression.Arguments.Count() != 1)
				{
					continue;
				}
				Expression expression = methodCallExpression.Arguments[0];
				if (expression.NodeType == ExpressionType.Lambda)
				{
					LambdaExpression lambdaExpression = (LambdaExpression)expression;
					Delegate obj = lambdaExpression.Compile();
					if (_importBuilders == null)
					{
						_importBuilders = new Dictionary<ParameterInfo, Action<ImportConventionBuilder>>();
					}
					_importBuilders.Add(parameters[num], (Action<ImportConventionBuilder>)obj);
					num++;
				}
			}
		}

		private static Expression<Func<ParameterImportConventionBuilder, T>> Reduce(Expression<Func<ParameterImportConventionBuilder, T>> expr)
		{
			while (expr.CanReduce)
			{
				expr.Reduce();
			}
			return expr;
		}
	}

	internal PartConventionBuilder(Predicate<Type> selectType)
		: base(selectType)
	{
	}

	public PartConventionBuilder<T> SelectConstructor(Expression<Func<ParameterImportConventionBuilder, T>> constructorSelector)
	{
		Microsoft.Internal.Requires.NotNull(constructorSelector, "constructorSelector");
		ConstructorExpressionAdapter constructorExpressionAdapter = new ConstructorExpressionAdapter(constructorSelector);
		SelectConstructor(constructorExpressionAdapter.SelectConstructor, constructorExpressionAdapter.ConfigureConstructorImports);
		return this;
	}

	public PartConventionBuilder<T> ExportProperty(Expression<Func<T, object>> propertySelector)
	{
		return ExportProperty(propertySelector, null);
	}

	public PartConventionBuilder<T> ExportProperty(Expression<Func<T, object>> propertySelector, Action<ExportConventionBuilder> exportConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertySelector, "propertySelector");
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertySelector, null, exportConfiguration);
		ExportProperties(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureExport);
		return this;
	}

	public PartConventionBuilder<T> ExportProperty<TContract>(Expression<Func<T, object>> propertySelector)
	{
		return ExportProperty<TContract>(propertySelector, null);
	}

	public PartConventionBuilder<T> ExportProperty<TContract>(Expression<Func<T, object>> propertySelector, Action<ExportConventionBuilder> exportConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertySelector, "propertySelector");
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertySelector, null, exportConfiguration);
		ExportProperties<TContract>(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureExport);
		return this;
	}

	public PartConventionBuilder<T> ImportProperty(Expression<Func<T, object>> propertySelector)
	{
		return ImportProperty(propertySelector, null);
	}

	public PartConventionBuilder<T> ImportProperty(Expression<Func<T, object>> propertySelector, Action<ImportConventionBuilder> importConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertySelector, "propertySelector");
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertySelector, importConfiguration);
		ImportProperties(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureImport);
		return this;
	}

	public PartConventionBuilder<T> ImportProperty<TContract>(Expression<Func<T, object>> propertySelector)
	{
		return ImportProperty<TContract>(propertySelector, null);
	}

	public PartConventionBuilder<T> ImportProperty<TContract>(Expression<Func<T, object>> propertySelector, Action<ImportConventionBuilder> importConfiguration)
	{
		Microsoft.Internal.Requires.NotNull(propertySelector, "propertySelector");
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertySelector, importConfiguration);
		ImportProperties<TContract>(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureImport);
		return this;
	}

	public PartConventionBuilder<T> NotifyImportsSatisfied(Expression<Action<T>> methodSelector)
	{
		Microsoft.Internal.Requires.NotNull(methodSelector, "methodSelector");
		MethodExpressionAdapter methodExpressionAdapter = new MethodExpressionAdapter(methodSelector);
		NotifyImportsSatisfied(methodExpressionAdapter.VerifyMethodInfo);
		return this;
	}
}
