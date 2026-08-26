using System.Collections.Generic;
using System.Composition.Hosting.Properties;
using System.Composition.Hosting.Util;
using System.Linq;
using System.Text;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

public class CompositionDependency
{
	private readonly ExportDescriptorPromise _target;

	private readonly bool _isPrerequisite;

	private readonly object _site;

	private readonly CompositionContract _contract;

	private readonly ExportDescriptorPromise[] _oversuppliedTargets;

	public ExportDescriptorPromise Target => _target;

	public bool IsPrerequisite => _isPrerequisite;

	public object Site => _site;

	public CompositionContract Contract => _contract;

	internal bool IsError => _target == null;

	public static CompositionDependency Satisfied(CompositionContract contract, ExportDescriptorPromise target, bool isPrerequisite, object site)
	{
		Microsoft.Internal.Requires.NotNull(target, "target");
		Microsoft.Internal.Requires.NotNull(site, "site");
		Microsoft.Internal.Requires.NotNull(contract, "contract");
		return new CompositionDependency(contract, target, isPrerequisite, site);
	}

	public static CompositionDependency Missing(CompositionContract contract, object site)
	{
		Microsoft.Internal.Requires.NotNull(contract, "contract");
		Microsoft.Internal.Requires.NotNull(site, "site");
		return new CompositionDependency(contract, site);
	}

	public static CompositionDependency Oversupplied(CompositionContract contract, IEnumerable<ExportDescriptorPromise> targets, object site)
	{
		Microsoft.Internal.Requires.NotNull(targets, "targets");
		Microsoft.Internal.Requires.NotNull(site, "site");
		Microsoft.Internal.Requires.NotNull(contract, "contract");
		return new CompositionDependency(contract, targets, site);
	}

	private CompositionDependency(CompositionContract contract, ExportDescriptorPromise target, bool isPrerequisite, object site)
	{
		_target = target;
		_isPrerequisite = isPrerequisite;
		_site = site;
		_contract = contract;
	}

	private CompositionDependency(CompositionContract contract, object site)
	{
		_contract = contract;
		_site = site;
	}

	private CompositionDependency(CompositionContract contract, IEnumerable<ExportDescriptorPromise> targets, object site)
	{
		_oversuppliedTargets = targets.ToArray();
		_site = site;
		_contract = contract;
	}

	public override string ToString()
	{
		if (IsError)
		{
			return Site.ToString();
		}
		return string.Format(System.Composition.Hosting.Properties.Resources.Dependency_ToStringFormat, new object[3] { Site, Target.Contract, Target.Origin });
	}

	internal void DescribeError(StringBuilder message)
	{
		Microsoft.Internal.Assumes.IsTrue(IsError, "Dependency is not in an error state.");
		if (_oversuppliedTargets != null)
		{
			string text = Formatters.ReadableList(_oversuppliedTargets.Select((ExportDescriptorPromise t) => string.Format(System.Composition.Hosting.Properties.Resources.Dependency_QuoteParameter, new object[1] { t.Origin })));
			message.AppendFormat(System.Composition.Hosting.Properties.Resources.Dependency_TooManyExports, new object[2] { Contract, text });
		}
		else
		{
			message.AppendFormat(System.Composition.Hosting.Properties.Resources.Dependency_ExportNotFound, new object[1] { Contract });
		}
	}
}
