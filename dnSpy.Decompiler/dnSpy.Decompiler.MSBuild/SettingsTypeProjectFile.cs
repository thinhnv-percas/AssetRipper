using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class SettingsTypeProjectFile : TypeProjectFile
{
	private bool isEmpty;

	private readonly object defsToRemoveLock = new object();

	private IMemberDef[] defsToRemove;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_CreateSettingsTypeFile;

	public IDecompiler Decompiler => decompiler;

	public DecompilationContext DecompilationContext => decompilationContext;

	public override BuildAction BuildAction => (!isEmpty) ? base.BuildAction : BuildAction.DontIncludeInProjectFile;

	public SettingsTypeProjectFile(TypeDef type, string filename, DecompilationContext decompilationContext, IDecompiler decompiler, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
		: base(type, filename, decompilationContext, decompiler, createDecompilerOutput)
	{
	}

	public override void Create(DecompileContext ctx)
	{
		InitializeIsEmpty();
		if (!isEmpty)
		{
			base.Create(ctx);
		}
	}

	protected override void Decompile(DecompileContext ctx, IDecompilerOutput output)
	{
		DecompilePartialType decompilePartialType = new DecompilePartialType(output, decompilationContext, base.Type);
		IMemberDef[] array = GetDefsToRemove();
		foreach (IMemberDef item in array)
		{
			decompilePartialType.Definitions.Add(item);
		}
		decompiler.Decompile(DecompilationType.PartialType, decompilePartialType);
	}

	private void InitializeIsEmpty()
	{
		HashSet<object> hashSet = new HashSet<object>();
		foreach (MethodDef method in base.Type.Methods)
		{
			hashSet.Add(method);
		}
		foreach (FieldDef field in base.Type.Fields)
		{
			hashSet.Add(field);
		}
		foreach (PropertyDef property in base.Type.Properties)
		{
			hashSet.Add(property);
		}
		foreach (EventDef @event in base.Type.Events)
		{
			hashSet.Add(@event);
		}
		foreach (TypeDef nestedType in base.Type.NestedTypes)
		{
			hashSet.Add(nestedType);
		}
		IMemberDef[] array = GetDefsToRemove();
		foreach (IMemberDef memberDef in array)
		{
			hashSet.Remove(memberDef);
			if (!(memberDef is PropertyDef))
			{
				continue;
			}
			foreach (IMemberDef item in DotNetUtils.GetMethodsAndSelf((PropertyDef)memberDef))
			{
				hashSet.Remove(item);
			}
		}
		hashSet.Remove(base.Type.FindStaticConstructor());
		hashSet.Remove(base.Type.FindDefaultConstructor());
		isEmpty = hashSet.Count == 0;
	}

	public IMemberDef[] GetDefsToRemove()
	{
		if (defsToRemove != null)
		{
			return defsToRemove;
		}
		lock (defsToRemoveLock)
		{
			if (defsToRemove == null)
			{
				defsToRemove = CalculateDefsToRemove().Distinct().ToArray();
			}
		}
		return defsToRemove;
	}

	private IEnumerable<IMemberDef> CalculateDefsToRemove()
	{
		PropertyDef defaultProp = FindDefaultProperty();
		if (defaultProp != null)
		{
			foreach (IMemberDef item in DotNetUtils.GetMethodsAndSelf(defaultProp))
			{
				yield return item;
			}
			foreach (IMemberDef def in DotNetUtils.GetDefs(defaultProp))
			{
				yield return def;
			}
		}
		foreach (PropertyDef p in base.Type.Properties)
		{
			if (!p.CustomAttributes.IsDefined("System.Configuration.DefaultSettingValueAttribute"))
			{
				continue;
			}
			foreach (IMemberDef item2 in DotNetUtils.GetMethodsAndSelf(p))
			{
				yield return item2;
			}
		}
	}

	private PropertyDef FindDefaultProperty()
	{
		foreach (PropertyDef property in base.Type.Properties)
		{
			if (!(property.Name != "Default"))
			{
				MethodDef getMethod = property.GetMethod;
				if (getMethod != null && getMethod.IsStatic && property.SetMethod == null && property.OtherMethods.Count == 0 && getMethod.MethodSig.GetParamCount() == 0 && getMethod.ReturnType.RemovePinnedAndModifiers().TryGetTypeDef() == base.Type && getMethod.Body != null)
				{
					return property;
				}
			}
		}
		return null;
	}
}
