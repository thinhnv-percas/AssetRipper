using System;
using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class XamlTypeProjectFile : TypeProjectFile
{
	public XamlTypeProjectFile(TypeDef type, string filename, DecompilationContext decompilationContext, IDecompiler decompiler, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
		: base(type, filename, decompilationContext, decompiler, createDecompilerOutput)
	{
	}

	protected override void Decompile(DecompileContext ctx, IDecompilerOutput output)
	{
		DecompilePartialType decompilePartialType = new DecompilePartialType(output, decompilationContext, base.Type);
		foreach (IMemberDef item in GetDefsToRemove())
		{
			decompilePartialType.Definitions.Add(item);
		}
		decompilePartialType.InterfacesToRemove.Add(new TypeRefUser(base.Type.Module, "System.Windows.Markup", "IComponentConnector", new AssemblyNameInfo("WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35").ToAssemblyRef()));
		decompilePartialType.InterfacesToRemove.Add(new TypeRefUser(base.Type.Module, "System.Windows.Markup", "IComponentConnector", new AssemblyNameInfo("System.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089").ToAssemblyRef()));
		decompiler.Decompile(DecompilationType.PartialType, decompilePartialType);
	}

	private IEnumerable<IMemberDef> GetDefsToRemove()
	{
		MethodDef ep = base.Type.Module.EntryPoint;
		if (ep != null && ep.DeclaringType == base.Type)
		{
			yield return ep;
		}
		MethodDef d = FindInitializeComponent();
		if (d != null)
		{
			yield return d;
			foreach (FieldDef f in DotNetUtils.GetFields(d))
			{
				if (f.FieldType.RemovePinnedAndModifiers().GetElementType() == ElementType.Boolean)
				{
					yield return f;
				}
			}
		}
		MethodDef connMeth = FindConnectMethod();
		if (connMeth != null)
		{
			yield return connMeth;
			foreach (FieldDef field in DotNetUtils.GetFields(connMeth))
			{
				yield return field;
			}
		}
		MethodDef delMeth = FindCreateDelegateMethod();
		if (delMeth != null)
		{
			yield return delMeth;
		}
	}

	private MethodDef FindInitializeComponent()
	{
		foreach (MethodDef item in base.Type.FindMethods("InitializeComponent"))
		{
			if (item.IsStatic || item.Parameters.Count != 1 || item.ReturnType.RemovePinnedAndModifiers().GetElementType() != ElementType.Void)
			{
				continue;
			}
			return item;
		}
		return null;
	}

	private MethodDef FindConnectMethod()
	{
		foreach (MethodDef method in base.Type.Methods)
		{
			if (IsConnect(method))
			{
				return method;
			}
		}
		return null;
	}

	private static bool IsConnect(MethodDef md)
	{
		if (md == null || md.IsStatic || md.Parameters.Count != 3)
		{
			return false;
		}
		if (md.ReturnType.RemovePinnedAndModifiers().GetElementType() != ElementType.Void)
		{
			return false;
		}
		MethodSig methodSig = md.MethodSig;
		if (methodSig == null || methodSig.Params.Count != 2)
		{
			return false;
		}
		if (methodSig.Params[0].RemovePinnedAndModifiers().GetElementType() != ElementType.I4)
		{
			return false;
		}
		if (methodSig.Params[1].RemovePinnedAndModifiers().GetElementType() != ElementType.Object)
		{
			return false;
		}
		foreach (MethodOverride @override in md.Overrides)
		{
			if (@override.MethodDeclaration == null || @override.MethodDeclaration.DeclaringType == null || @override.MethodDeclaration.DeclaringType.FullName != "System.Windows.Markup.IComponentConnector" || @override.MethodDeclaration.Name != "Connect")
			{
				continue;
			}
			return true;
		}
		return md.Name == "Connect";
	}

	private MethodDef FindCreateDelegateMethod()
	{
		foreach (MethodDef method in base.Type.Methods)
		{
			if (!(method.Name != "_CreateDelegate") && !method.IsStatic && method.IsAssembly)
			{
				MethodSig methodSig = method.MethodSig;
				if (methodSig.GetParamCount() == 2 && methodSig.RetType.RemovePinnedAndModifiers() != null && !(methodSig.RetType.RemovePinnedAndModifiers().ToString() != "System.Delegate") && methodSig.Params[0].RemovePinnedAndModifiers() != null && !(methodSig.Params[0].RemovePinnedAndModifiers().ToString() != "System.Type") && methodSig.Params[1].RemovePinnedAndModifiers() != null && methodSig.Params[1].RemovePinnedAndModifiers().GetElementType() == ElementType.String)
				{
					return method;
				}
			}
		}
		return null;
	}
}
