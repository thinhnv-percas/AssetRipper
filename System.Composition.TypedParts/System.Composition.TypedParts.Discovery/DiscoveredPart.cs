using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Debugging;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Composition.Properties;
using System.Composition.TypedParts.ActivationFeatures;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Composition.TypedParts.Discovery;

[DebuggerDisplay("{PartType.Name}")]
[DebuggerTypeProxy(typeof(DiscoveredPartDebuggerProxy))]
internal class DiscoveredPart
{
	private readonly TypeInfo _partType;

	private readonly AttributedModelProvider _attributeContext;

	private readonly ICollection<DiscoveredExport> _exports = new List<DiscoveredExport>();

	private readonly ActivationFeature[] _activationFeatures;

	private readonly Lazy<IDictionary<string, object>> _partMetadata;

	private readonly IList<Type[]> _appliedArguments = new List<Type[]>();

	private ConstructorInfo _constructor;

	private CompositeActivator _partActivator;

	private static readonly IDictionary<string, object> s_noMetadata = new Dictionary<string, object>();

	private static readonly MethodInfo s_activatorInvoke = typeof(CompositeActivator).GetTypeInfo().GetDeclaredMethod("Invoke");

	public TypeInfo PartType => _partType;

	public bool IsShared => ContractHelpers.IsShared(_partMetadata.Value);

	public IEnumerable<DiscoveredExport> DiscoveredExports => _exports;

	private DiscoveredPart(TypeInfo partType, AttributedModelProvider attributeContext, ActivationFeature[] activationFeatures, Lazy<IDictionary<string, object>> partMetadata)
	{
		_partType = partType;
		_attributeContext = attributeContext;
		_activationFeatures = activationFeatures;
		_partMetadata = partMetadata;
	}

	public DiscoveredPart(TypeInfo partType, AttributedModelProvider attributeContext, ActivationFeature[] activationFeatures)
	{
		DiscoveredPart discoveredPart = this;
		_partType = partType;
		_attributeContext = attributeContext;
		_activationFeatures = activationFeatures;
		_partMetadata = new Lazy<IDictionary<string, object>>(() => discoveredPart.GetPartMetadata(partType));
	}

	public void AddDiscoveredExport(DiscoveredExport export)
	{
		_exports.Add(export);
		export.Part = this;
	}

	public CompositionDependency[] GetDependencies(DependencyAccessor definitionAccessor)
	{
		return (from a in GetPartActivatorDependencies(definitionAccessor).Concat(_activationFeatures.SelectMany((ActivationFeature feature) => feature.GetDependencies(_partType, definitionAccessor)))
			where a != null
			select a).ToArray();
	}

	private IEnumerable<CompositionDependency> GetPartActivatorDependencies(DependencyAccessor definitionAccessor)
	{
		Type partTypeAsType = _partType.AsType();
		if ((object)_constructor == null)
		{
			foreach (ConstructorInfo item in _partType.DeclaredConstructors.Where((ConstructorInfo ci) => ci.IsPublic && !ci.IsStatic))
			{
				if (_attributeContext.GetDeclaredAttribute<ImportingConstructorAttribute>(partTypeAsType, item) != null)
				{
					if ((object)_constructor != null)
					{
						string message = string.Format(System.Composition.Properties.Resources.DiscoveredPart_MultipleImportingConstructorsFound, new object[1] { _partType });
						throw new CompositionFailedException(message);
					}
					_constructor = item;
				}
			}
			if ((object)_constructor == null)
			{
				_constructor = _partType.DeclaredConstructors.FirstOrDefault((ConstructorInfo ci) => ci.IsPublic && !ci.IsStatic && !ci.GetParameters().Any());
			}
			if ((object)_constructor == null)
			{
				string message2 = string.Format(System.Composition.Properties.Resources.DiscoveredPart_NoImportingConstructorsFound, new object[1] { _partType });
				throw new CompositionFailedException(message2);
			}
		}
		ParameterInfo[] cps = _constructor.GetParameters();
		int i = 0;
		while (i < cps.Length)
		{
			ParameterInfo parameterInfo = cps[i];
			ParameterImportSite site = new ParameterImportSite(parameterInfo);
			ImportInfo importInfo = ContractHelpers.GetImportInfo(parameterInfo.ParameterType, _attributeContext.GetDeclaredAttributes(partTypeAsType, parameterInfo), site);
			CompositionDependency dependency;
			if (!importInfo.AllowDefault)
			{
				yield return definitionAccessor.ResolveRequiredDependency(site, importInfo.Contract, isPrerequisite: true);
			}
			else if (definitionAccessor.TryResolveOptionalDependency(site, importInfo.Contract, isPrerequisite: true, out dependency))
			{
				yield return dependency;
			}
			int num = i + 1;
			i = num;
		}
	}

	public CompositeActivator GetActivator(DependencyAccessor definitionAccessor, IEnumerable<CompositionDependency> dependencies)
	{
		if (_partActivator != null)
		{
			return _partActivator;
		}
		ParameterExpression parameterExpression = Expression.Parameter(typeof(LifetimeContext), "cc");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(CompositionOperation), "op");
		ParameterInfo[] parameters = _constructor.GetParameters();
		Expression[] array = new Expression[parameters.Length];
		Dictionary<ParameterInfo, CompositionDependency> dictionary = dependencies.Where((CompositionDependency dep) => dep.Site is ParameterImportSite).ToDictionary((CompositionDependency d) => ((ParameterImportSite)d.Site).Parameter);
		for (int num = 0; num < parameters.Length; num++)
		{
			ParameterInfo parameterInfo = parameters[num];
			if (dictionary.TryGetValue(parameterInfo, out var value))
			{
				CompositeActivator activator = value.Target.GetDescriptor().Activator;
				array[num] = Expression.Convert(Expression.Call(Expression.Constant(activator), s_activatorInvoke, parameterExpression, parameterExpression2), parameterInfo.ParameterType);
			}
			else
			{
				array[num] = Expression.Default(parameterInfo.ParameterType);
			}
		}
		Expression body = Expression.Convert(Expression.New(_constructor, array), typeof(object));
		CompositeActivator compositeActivator = Expression.Lambda<CompositeActivator>(body, new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
		ActivationFeature[] activationFeatures = _activationFeatures;
		foreach (ActivationFeature activationFeature in activationFeatures)
		{
			compositeActivator = activationFeature.RewriteActivator(_partType, compositeActivator, _partMetadata.Value, dependencies);
		}
		_partActivator = compositeActivator;
		return _partActivator;
	}

	public IDictionary<string, object> GetPartMetadata(TypeInfo partType)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Attribute[] declaredAttributes = _attributeContext.GetDeclaredAttributes(partType.AsType(), partType);
		foreach (Attribute attribute in declaredAttributes)
		{
			if (attribute is PartMetadataAttribute)
			{
				PartMetadataAttribute partMetadataAttribute = (PartMetadataAttribute)attribute;
				dictionary.Add(partMetadataAttribute.Name, partMetadataAttribute.Value);
			}
		}
		if (dictionary.Count != 0)
		{
			return dictionary;
		}
		return s_noMetadata;
	}

	public bool TryCloseGenericPart(Type[] typeArguments, out DiscoveredPart closed)
	{
		if (_appliedArguments.Any((Type[] args) => args.SequenceEqual(typeArguments)))
		{
			closed = null;
			return false;
		}
		_appliedArguments.Add(typeArguments);
		TypeInfo typeInfo = _partType.MakeGenericType(typeArguments).GetTypeInfo();
		DiscoveredPart discoveredPart = new DiscoveredPart(typeInfo, _attributeContext, _activationFeatures, _partMetadata);
		foreach (DiscoveredExport export2 in _exports)
		{
			DiscoveredExport export = export2.CloseGenericExport(typeInfo, typeArguments);
			discoveredPart.AddDiscoveredExport(export);
		}
		closed = discoveredPart;
		return true;
	}
}
