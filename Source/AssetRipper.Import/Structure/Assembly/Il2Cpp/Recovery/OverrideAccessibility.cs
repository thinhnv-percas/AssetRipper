using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Metadata.Tables;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Iteration 063: an override has to state its base's accessibility, and widening one without the other
/// makes the declaration uncompilable.
/// </summary>
/// <remarks>
/// <see cref="Il2CppIlRecoveryOutputFormat"/> widens a member that a recovered body reaches and a compiler
/// would not: protected becomes protected internal when a caller in the same assembly is not derived. It
/// does that one member at a time, so <c>Viewport.OnStartShow</c> became protected internal while the ten
/// screens that override it stayed protected - CS0507 ten times, and because Roslyn stops at declaration
/// errors, every body error in JellyBlast's Assembly-CSharp went unreported with them. C# requires an
/// override to repeat its base's accessibility, with one exception: overriding a protected internal member
/// from another assembly is written protected, because the internal half does not cross. The chain
/// therefore takes the widest accessibility any member of it has, applied under that rule.
/// </remarks>
public static class OverrideAccessibility
{
	/// <summary>How far an accessibility reaches, for choosing the wider of two.</summary>
	public static int Rank(MethodAttributes access) => access switch
	{
		MethodAttributes.Public => 5,
		MethodAttributes.FamilyOrAssembly => 4,
		MethodAttributes.Family => 3,
		MethodAttributes.Assembly => 3,
		MethodAttributes.FamilyAndAssembly => 2,
		MethodAttributes.Private => 1,
		_ => 0,
	};

	/// <summary>The accessibility an override must declare, given its base's.</summary>
	public static MethodAttributes RequiredForOverride(MethodAttributes baseAccess, bool sameAssembly)
		=> !sameAssembly && baseAccess == MethodAttributes.FamilyOrAssembly ? MethodAttributes.Family : baseAccess;

	/// <summary>
	/// What a base and its override should both say. The wider of the two wins, because each was widened
	/// for a caller that needs it; the override is then stated from the base.
	/// </summary>
	public static (MethodAttributes Base, MethodAttributes Override) Reconcile(
		MethodAttributes baseAccess, MethodAttributes overrideAccess, bool sameAssembly, bool baseEditable)
	{
		// Seen from the base's side: protected in another assembly is the protected internal it overrides.
		MethodAttributes overrideAsBase = !sameAssembly && overrideAccess == MethodAttributes.Family
			? MethodAttributes.FamilyOrAssembly
			: overrideAccess;

		MethodAttributes wanted = baseEditable && Rank(overrideAsBase) > Rank(baseAccess) ? overrideAsBase : baseAccess;
		return (wanted, RequiredForOverride(wanted, sameAssembly));
	}

	/// <summary>
	/// Makes every override chain whose members this export may edit agree, to a fixpoint. Returns how
	/// many methods changed.
	/// </summary>
	public static int Apply(IEnumerable<ModuleDefinition> modules, Func<ModuleDefinition, bool> editable)
	{
		List<(MethodDefinition Base, MethodDefinition Override)> pairs = [];

		foreach (ModuleDefinition module in modules)
		{
			if (!editable(module))
			{
				continue;
			}

			foreach (TypeDefinition type in module.GetAllTypes())
			{
				foreach (MethodDefinition method in type.Methods)
				{
					if (method.IsVirtual && !method.IsNewSlot && OverriddenBy(method) is { } overridden)
					{
						pairs.Add((overridden, method));
					}
				}
			}
		}

		int changed = 0;
		bool again = true;

		// A chain is several pairs, and widening a base can require widening the pair above it.
		for (int round = 0; again && round < 16; round++)
		{
			again = false;
			foreach ((MethodDefinition baseMethod, MethodDefinition overrideMethod) in pairs)
			{
				bool sameAssembly = baseMethod.DeclaringModule == overrideMethod.DeclaringModule;
				bool baseEditable = baseMethod.DeclaringModule is { } baseModule && editable(baseModule);
				MethodAttributes baseAccess = baseMethod.Attributes & MethodAttributes.MemberAccessMask;
				MethodAttributes overrideAccess = overrideMethod.Attributes & MethodAttributes.MemberAccessMask;

				(MethodAttributes newBase, MethodAttributes newOverride) = Reconcile(baseAccess, overrideAccess, sameAssembly, baseEditable);

				if (newBase != baseAccess)
				{
					baseMethod.Attributes = (baseMethod.Attributes & ~MethodAttributes.MemberAccessMask) | newBase;
					changed++;
					again = true;
				}

				if (newOverride != overrideAccess)
				{
					overrideMethod.Attributes = (overrideMethod.Attributes & ~MethodAttributes.MemberAccessMask) | newOverride;
					changed++;
					again = true;
				}
			}
		}

		return changed;
	}

	/// <summary>
	/// The nearest virtual method of a base class that this one overrides: same name, same number of
	/// parameters, and - where more than one candidate has both - the same parameter type names. An
	/// interface method is not a base: an implementation is public by construction.
	/// </summary>
	private static MethodDefinition? OverriddenBy(MethodDefinition method)
	{
		if (method.DeclaringType is not { } type || method.DeclaringModule?.RuntimeContext is not { } runtime)
		{
			return null;
		}

		int parameterCount = method.Signature?.ParameterTypes.Count ?? -1;

		for (ITypeDefOrRef? baseRef = type.BaseType; baseRef is not null;)
		{
			if (baseRef.Resolve(runtime, out TypeDefinition? baseType) != AsmResolver.DotNet.ResolutionStatus.Success || baseType is null)
			{
				return null;
			}

			List<MethodDefinition> candidates = baseType.Methods
				.Where(m => m.IsVirtual && m.Name == method.Name && (m.Signature?.ParameterTypes.Count ?? -2) == parameterCount)
				.ToList();

			if (candidates.Count == 1)
			{
				return candidates[0];
			}

			if (candidates.Count > 1)
			{
				string wanted = ParameterNames(method);
				return candidates.SingleOrDefault(c => ParameterNames(c) == wanted);
			}

			baseRef = baseType.BaseType;
		}

		return null;
	}

	private static string ParameterNames(MethodDefinition method)
		=> string.Join(",", method.Signature?.ParameterTypes.Select(p => p.Name) ?? []);
}
