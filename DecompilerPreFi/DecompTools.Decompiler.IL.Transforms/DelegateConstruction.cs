#define DEBUG
#define STEP
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

public class DelegateConstruction : IILTransform
{
	private class ReplaceDelegateTargetVisitor : ILVisitor
	{
		private readonly ILVariable thisVariable;

		private readonly ILInstruction target;

		public ReplaceDelegateTargetVisitor(ILInstruction target, ILVariable thisVariable)
		{
			this.target = target;
			this.thisVariable = thisVariable;
		}

		protected override void Default(ILInstruction inst)
		{
			foreach (ILInstruction child in inst.Children)
			{
				child.AcceptVisitor(this);
			}
		}

		protected internal override void VisitLdLoc(LdLoc inst)
		{
			if (inst.Variable == thisVariable)
			{
				inst.ReplaceWith(target.Clone());
			}
			else
			{
				base.VisitLdLoc(inst);
			}
		}

		protected internal override void VisitLdObj(LdObj inst)
		{
			if (inst.Target.MatchLdLoca(thisVariable))
			{
				inst.ReplaceWith(target.Clone());
			}
			else
			{
				base.VisitLdObj(inst);
			}
		}
	}

	private class TransformDisplayClassUsages : ILVisitor
	{
		private struct DisplayClassVariable
		{
			public ILVariable variable;

			public ILInstruction value;
		}

		private ILFunction currentFunction;

		private BlockContainer captureScope;

		private readonly IInstructionWithVariableOperand targetLoad;

		private readonly List<ILVariable> targetAndCopies = new List<ILVariable>();

		private readonly List<ILInstruction> orphanedVariableInits;

		private readonly HashSet<ITypeDefinition> translatedDisplayClasses;

		private readonly Dictionary<IField, DisplayClassVariable> initValues = new Dictionary<IField, DisplayClassVariable>();

		public TransformDisplayClassUsages(ILFunction function, IInstructionWithVariableOperand targetLoad, BlockContainer captureScope, List<ILInstruction> orphanedVariableInits, HashSet<ITypeDefinition> translatedDisplayClasses)
		{
			currentFunction = function;
			this.targetLoad = targetLoad;
			this.captureScope = captureScope;
			this.orphanedVariableInits = orphanedVariableInits;
			this.translatedDisplayClasses = translatedDisplayClasses;
			targetAndCopies.Add(targetLoad.Variable);
		}

		protected override void Default(ILInstruction inst)
		{
			foreach (ILInstruction child in inst.Children)
			{
				child.AcceptVisitor(this);
			}
		}

		protected internal override void VisitStLoc(StLoc inst)
		{
			base.VisitStLoc(inst);
			if (!(targetLoad is ILInstruction iLInstruction) || !iLInstruction.MatchLdThis())
			{
				if (inst.Variable == targetLoad.Variable)
				{
					orphanedVariableInits.Add(inst);
				}
				if (MatchesTargetOrCopyLoad(inst.Value))
				{
					targetAndCopies.Add(inst.Variable);
					orphanedVariableInits.Add(inst);
				}
			}
		}

		private bool MatchesTargetOrCopyLoad(ILInstruction inst)
		{
			return Enumerable.Any<ILVariable>((IEnumerable<ILVariable>)targetAndCopies, (Func<ILVariable, bool>)((ILVariable v) => inst.MatchLdLoc(v)));
		}

		protected internal override void VisitStObj(StObj inst)
		{
			base.VisitStObj(inst);
			if (!inst.Target.MatchLdFlda(out var target, out var field) || !MatchesTargetOrCopyLoad(target) || target.MatchLdThis())
			{
				return;
			}
			field = (IField)field.MemberDefinition;
			if (initValues.TryGetValue(field, out var value))
			{
				inst.ReplaceWith(new StLoc(value.variable, inst.Value).WithILRange(inst));
				return;
			}
			ILInstruction value2;
			if (inst.Value.MatchLdLoc(out var variable) && variable.Kind == VariableKind.Parameter && currentFunction == variable.Function)
			{
				orphanedVariableInits.Add(inst);
				value2 = inst.Value;
			}
			else
			{
				if (!translatedDisplayClasses.Contains(field.DeclaringTypeDefinition))
				{
					return;
				}
				variable = currentFunction.RegisterVariable(VariableKind.Local, field.Type, field.Name);
				variable.CaptureScope = captureScope;
				inst.ReplaceWith(new StLoc(variable, inst.Value).WithILRange(inst));
				value2 = new LdLoc(variable);
			}
			initValues.Add(field, new DisplayClassVariable
			{
				value = value2,
				variable = variable
			});
		}

		protected internal override void VisitLdObj(LdObj inst)
		{
			base.VisitLdObj(inst);
			if (inst.Target.MatchLdFlda(out var _, out var field) && initValues.TryGetValue((IField)field.MemberDefinition, out var value))
			{
				ILInstruction iLInstruction = value.value.Clone();
				iLInstruction.SetILRange(inst);
				inst.ReplaceWith(iLInstruction);
			}
		}

		protected internal override void VisitLdFlda(LdFlda inst)
		{
			base.VisitLdFlda(inst);
			if (inst.Target.MatchLdThis() && inst.Field.Name == "$this" && inst.Field.MemberDefinition.ReflectionName.Contains("c__Iterator"))
			{
				ILVariable variable = Enumerable.First<ILVariable>((IEnumerable<ILVariable>)currentFunction.Variables, (Func<ILVariable, bool>)((ILVariable f) => f.Index == -1));
				inst.ReplaceWith(new LdLoca(variable).WithILRange(inst));
			}
			if (inst.Parent is LdObj || inst.Parent is StObj || !MatchesTargetOrCopyLoad(inst.Target))
			{
				return;
			}
			IField field = (IField)inst.Field.MemberDefinition;
			if (!initValues.TryGetValue(field, out var value))
			{
				if (translatedDisplayClasses.Contains(field.DeclaringTypeDefinition))
				{
					ILVariable iLVariable = currentFunction.RegisterVariable(VariableKind.Local, field.Type, field.Name);
					iLVariable.CaptureScope = captureScope;
					inst.ReplaceWith(new LdLoca(iLVariable).WithILRange(inst));
					LdLoc value2 = new LdLoc(iLVariable);
					initValues.Add(field, new DisplayClassVariable
					{
						value = value2,
						variable = iLVariable
					});
				}
			}
			else if (value.value is LdLoc ldLoc)
			{
				inst.ReplaceWith(new LdLoca(ldLoc.Variable).WithILRange(inst));
			}
			else
			{
				Debug.Fail("LdFlda pattern not supported!");
			}
		}

		protected internal override void VisitNumericCompoundAssign(NumericCompoundAssign inst)
		{
			base.VisitNumericCompoundAssign(inst);
			if (inst.Target.MatchLdLoc(out var variable))
			{
				inst.ReplaceWith(new StLoc(variable, new BinaryNumericInstruction(inst.Operator, inst.Target, inst.Value, inst.CheckForOverflow, inst.Sign).WithILRange(inst)));
			}
		}
	}

	private ILTransformContext context;

	private ITypeResolveContext decompilationContext;

	void IILTransform.Run(ILFunction function, ILTransformContext context)
	{
		if (!context.Settings.AnonymousMethods)
		{
			return;
		}
		this.context = context;
		decompilationContext = new SimpleTypeResolveContext(function.Method);
		List<ILInstruction> list = new List<ILInstruction>();
		List<IInstructionWithVariableOperand> list2 = new List<IInstructionWithVariableOperand>();
		HashSet<ITypeDefinition> val = new HashSet<ITypeDefinition>();
		CancellationToken cancellationToken = context.CancellationToken;
		foreach (ILInstruction descendant in function.Descendants)
		{
			cancellationToken.ThrowIfCancellationRequested();
			if (descendant is NewObj newObj)
			{
				context.StepStartGroup($"TransformDelegateConstruction {newObj.StartILOffset}", newObj);
				ILFunction iLFunction = TransformDelegateConstruction(newObj, out var target);
				if (iLFunction != null && target is IInstructionWithVariableOperand instructionWithVariableOperand)
				{
					if (instructionWithVariableOperand.Variable.Kind == VariableKind.Local)
					{
						instructionWithVariableOperand.Variable.Kind = VariableKind.DisplayClassLocal;
					}
					list2.Add(instructionWithVariableOperand);
				}
				context.StepEndGroup();
			}
			if (descendant.MatchStLoc(out var variable, out var value) && value is NewObj newObj2 && IsInSimpleDisplayClass(newObj2.Method))
			{
				variable.CaptureScope = BlockContainer.FindClosestContainer(descendant);
				list2.Add((IInstructionWithVariableOperand)descendant);
				val.Add(newObj2.Method.DeclaringTypeDefinition);
			}
		}
		foreach (IInstructionWithVariableOperand item in (IEnumerable<IInstructionWithVariableOperand>)Enumerable.OrderByDescending<IInstructionWithVariableOperand, int>((IEnumerable<IInstructionWithVariableOperand>)list2, (Func<IInstructionWithVariableOperand, int>)((IInstructionWithVariableOperand t) => ((ILInstruction)t).StartILOffset)))
		{
			context.Step($"TransformDisplayClassUsages {item.Variable}", (ILInstruction)item);
			function.AcceptVisitor(new TransformDisplayClassUsages(function, item, item.Variable.CaptureScope, list, val));
		}
		context.Step("Remove orphanedVariableInits", function);
		foreach (ILInstruction item2 in list)
		{
			if (item2.Parent is Block block)
			{
				block.Instructions.Remove(item2);
			}
		}
	}

	private static bool IsInSimpleDisplayClass(IMethod method)
	{
		if (!method.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
		{
			return false;
		}
		return IsSimpleDisplayClass(method.DeclaringType);
	}

	internal static bool IsSimpleDisplayClass(IType type)
	{
		if (!type.HasGeneratedName() || (!type.Name.Contains("DisplayClass") && !type.Name.Contains("AnonStorey")))
		{
			return false;
		}
		if (Enumerable.Any<IType>(type.DirectBaseTypes, (Func<IType, bool>)((IType t) => !t.IsKnownType(KnownTypeCode.Object))))
		{
			return false;
		}
		return true;
	}

	internal static bool IsDelegateConstruction(NewObj inst, bool allowTransformed = false)
	{
		if (inst == null || inst.Arguments.Count != 2 || inst.Method.DeclaringType.Kind != TypeKind.Delegate)
		{
			return false;
		}
		OpCode opCode = inst.Arguments[1].OpCode;
		return opCode == OpCode.LdFtn || opCode == OpCode.LdVirtFtn || (allowTransformed && opCode == OpCode.ILFunction);
	}

	internal static bool IsPotentialClosure(ILTransformContext context, NewObj inst)
	{
		SimpleTypeResolveContext simpleTypeResolveContext = new SimpleTypeResolveContext(context.Function.Method);
		return IsPotentialClosure(simpleTypeResolveContext.CurrentTypeDefinition, inst.Method.DeclaringTypeDefinition);
	}

	private static bool IsAnonymousMethod(ITypeDefinition decompiledTypeDefinition, IMethod method)
	{
		if (method == null || (!method.HasGeneratedName() && !method.Name.Contains("$") && !ContainsAnonymousType(method)))
		{
			return false;
		}
		if (!method.IsCompilerGeneratedOrIsInCompilerGeneratedClass() && !IsPotentialClosure(decompiledTypeDefinition, method.DeclaringTypeDefinition))
		{
			return false;
		}
		return true;
	}

	private static bool ContainsAnonymousType(IMethod method)
	{
		if (method.ReturnType.ContainsAnonymousType())
		{
			return true;
		}
		foreach (IParameter parameter in method.Parameters)
		{
			if (parameter.Type.ContainsAnonymousType())
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsPotentialClosure(ITypeDefinition decompiledTypeDefinition, ITypeDefinition potentialDisplayClass)
	{
		if (potentialDisplayClass == null || !potentialDisplayClass.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
		{
			return false;
		}
		while (potentialDisplayClass != decompiledTypeDefinition)
		{
			potentialDisplayClass = potentialDisplayClass.DeclaringTypeDefinition;
			if (potentialDisplayClass == null)
			{
				return false;
			}
		}
		return true;
	}

	internal static GenericContext? GenericContextFromTypeArguments(TypeParameterSubstitution subst)
	{
		List<ITypeParameter> list = new List<ITypeParameter>();
		List<ITypeParameter> list2 = new List<ITypeParameter>();
		if (subst.ClassTypeArguments != null)
		{
			foreach (IType classTypeArgument in subst.ClassTypeArguments)
			{
				if (classTypeArgument is ITypeParameter item)
				{
					list.Add(item);
					continue;
				}
				return null;
			}
		}
		if (subst.MethodTypeArguments != null)
		{
			foreach (IType methodTypeArgument in subst.MethodTypeArguments)
			{
				if (methodTypeArgument is ITypeParameter item2)
				{
					list2.Add(item2);
					continue;
				}
				return null;
			}
		}
		return new GenericContext(list, list2);
	}

	private ILFunction TransformDelegateConstruction(NewObj value, out ILInstruction target)
	{
		target = null;
		if (!IsDelegateConstruction(value))
		{
			return null;
		}
		IMethod method = ((IInstructionWithMethodOperand)value.Arguments[1]).Method;
		if (!IsAnonymousMethod(decompilationContext.CurrentTypeDefinition, method))
		{
			return null;
		}
		if (LocalFunctionDecompiler.IsLocalFunctionMethod(method.ParentModule.PEFile, (MethodDefinitionHandle)method.MetadataToken))
		{
			return null;
		}
		target = value.Arguments[0];
		if (method.MetadataToken.IsNil)
		{
			return null;
		}
		MethodDefinition methodDefinition = context.PEFile.Metadata.GetMethodDefinition((MethodDefinitionHandle)method.MetadataToken);
		if (!methodDefinition.HasBody())
		{
			return null;
		}
		GenericContext? genericContext = GenericContextFromTypeArguments(method.Substitution);
		if (!genericContext.HasValue)
		{
			return null;
		}
		ILReader iLReader = context.CreateILReader();
		MethodBodyBlock methodBody = context.PEFile.Reader.GetMethodBody(methodDefinition.RelativeVirtualAddress);
		ILFunction iLFunction = iLReader.ReadIL((MethodDefinitionHandle)method.MetadataToken, methodBody, genericContext.Value, context.CancellationToken);
		iLFunction.DelegateType = value.Method.DeclaringType;
		iLFunction.CheckInvariant(ILPhase.Normal);
		value.ReplaceWith(iLFunction);
		string name = method.Name;
		foreach (ILVariable item in Enumerable.Where<ILVariable>((IEnumerable<ILVariable>)iLFunction.Variables, (Func<ILVariable, bool>)((ILVariable v) => v.Kind != VariableKind.Parameter)))
		{
			item.Name = name + item.Name;
		}
		ILTransformContext iLTransformContext = new ILTransformContext(context, iLFunction);
		iLFunction.RunTransforms(Enumerable.Concat<IILTransform>(Enumerable.TakeWhile<IILTransform>((IEnumerable<IILTransform>)CSharpDecompiler.GetILTransforms(), (Func<IILTransform, bool>)((IILTransform t) => !(t is DelegateConstruction))), GetTransforms()), iLTransformContext);
		iLTransformContext.Step("DelegateConstruction (ReplaceDelegateTargetVisitor)", iLFunction);
		iLFunction.AcceptVisitor(new ReplaceDelegateTargetVisitor(target, Enumerable.SingleOrDefault<ILVariable>((IEnumerable<ILVariable>)iLFunction.Variables, (Func<ILVariable, bool>)((ILVariable v) => v.Index == -1 && v.Kind == VariableKind.Parameter))));
		iLTransformContext.StepStartGroup("DelegateConstruction (nested lambdas)", iLFunction);
		((IILTransform)new DelegateConstruction()).Run(iLFunction, iLTransformContext);
		iLTransformContext.StepEndGroup();
		iLFunction.AddILRange(target);
		iLFunction.AddILRange(value);
		iLFunction.AddILRange(value.Arguments[1]);
		return iLFunction;
	}

	private IEnumerable<IILTransform> GetTransforms()
	{
		yield return new CombineExitsTransform();
	}
}
