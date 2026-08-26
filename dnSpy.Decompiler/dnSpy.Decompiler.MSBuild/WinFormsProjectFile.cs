using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class WinFormsProjectFile : TypeProjectFile
{
	private readonly object defsToRemoveLock = new object();

	private IMemberDef[] defsToRemove;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_CreateWinFormsFile;

	public IDecompiler Decompiler => decompiler;

	public DecompilationContext DecompilationContext => decompilationContext;

	public WinFormsProjectFile(TypeDef type, string filename, DecompilationContext decompilationContext, IDecompiler decompiler, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
		: base(type, filename, decompilationContext, decompiler, createDecompilerOutput)
	{
		base.SubType = "Form";
	}

	protected override void Decompile(DecompileContext ctx, IDecompilerOutput output)
	{
		if (!decompiler.CanDecompile(DecompilationType.PartialType))
		{
			base.Decompile(ctx, output);
			return;
		}
		DecompilePartialType decompilePartialType = new DecompilePartialType(output, decompilationContext, base.Type);
		IMemberDef[] array = GetDefsToRemove();
		foreach (IMemberDef item in array)
		{
			decompilePartialType.Definitions.Add(item);
		}
		decompiler.Decompile(DecompilationType.PartialType, decompilePartialType);
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
		MethodDef m = GetInitializeComponent();
		if (m != null)
		{
			yield return m;
			foreach (FieldDef field in DotNetUtils.GetFields(m))
			{
				yield return field;
			}
		}
		m = GetDispose();
		if (m == null)
		{
			yield break;
		}
		yield return m;
		foreach (FieldDef field2 in DotNetUtils.GetFields(m))
		{
			yield return field2;
		}
	}

	private MethodDef GetInitializeComponent()
	{
		foreach (MethodDef method in base.Type.Methods)
		{
			if (method.Access != MethodAttributes.Private || method.IsStatic || method.Parameters.Count != 1 || method.ReturnType.RemovePinnedAndModifiers().GetElementType() != ElementType.Void || method.Name != "InitializeComponent" || method.Body == null)
			{
				continue;
			}
			return method;
		}
		return null;
	}

	private MethodDef GetDispose()
	{
		foreach (MethodDef method in base.Type.Methods)
		{
			if (method.Access != MethodAttributes.Family || method.IsStatic || method.Parameters.Count != 2 || method.Parameters[1].Type.RemovePinnedAndModifiers().GetElementType() != ElementType.Boolean || method.ReturnType.RemovePinnedAndModifiers().GetElementType() != ElementType.Void || method.Name != "Dispose" || method.Body == null)
			{
				continue;
			}
			return method;
		}
		return null;
	}
}
