#define STEP
#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

internal class EarlyExpressionTransforms : ILVisitor, IILTransform
{
	private ILTransformContext context;

	public void Run(ILFunction function, ILTransformContext context)
	{
		this.context = context;
		Default(function);
	}

	protected override void Default(ILInstruction inst)
	{
		foreach (ILInstruction child in inst.Children)
		{
			child.AcceptVisitor(this);
		}
	}

	protected internal override void VisitStObj(StObj inst)
	{
		base.VisitStObj(inst);
		StObjToStLoc(inst, context);
	}

	internal static bool StObjToStLoc(StObj inst, ILTransformContext context)
	{
		if (inst.Target.MatchLdLoca(out var variable) && TypeUtils.IsCompatibleTypeForMemoryAccess(variable.Type, inst.Type) && inst.UnalignedPrefix == 0 && !inst.IsVolatile)
		{
			context.Step("stobj(ldloca " + variable.Name + ", ...) => stloc " + variable.Name + "(...)", inst);
			inst.ReplaceWith(new StLoc(variable, inst.Value).WithILRange(inst));
			return true;
		}
		return false;
	}

	protected internal override void VisitLdObj(LdObj inst)
	{
		base.VisitLdObj(inst);
		LdObjToLdLoc(inst, context);
	}

	internal static bool LdObjToLdLoc(LdObj inst, ILTransformContext context)
	{
		if (inst.Target.MatchLdLoca(out var variable) && TypeUtils.IsCompatibleTypeForMemoryAccess(variable.Type, inst.Type) && inst.UnalignedPrefix == 0 && !inst.IsVolatile)
		{
			context.Step("ldobj(ldloca " + variable.Name + ") => ldloc " + variable.Name, inst);
			inst.ReplaceWith(new LdLoc(variable).WithILRange(inst));
			return true;
		}
		return false;
	}

	protected internal override void VisitCall(Call inst)
	{
		ILInstruction iLInstruction = HandleCall(inst, context);
		if (iLInstruction != null)
		{
			iLInstruction.AcceptVisitor(this);
		}
		else
		{
			base.VisitCall(inst);
		}
	}

	internal static ILInstruction HandleCall(Call inst, ILTransformContext context)
	{
		if (inst.Method.IsConstructor && !inst.Method.IsStatic && inst.Method.DeclaringType.Kind == TypeKind.Struct)
		{
			Debug.Assert(inst.Arguments.Count == checked(inst.Method.Parameters.Count + 1));
			context.Step("Transform call to struct constructor", inst);
			NewObj newObj = new NewObj(inst.Method);
			newObj.AddILRange(inst);
			newObj.Arguments.AddRange(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)inst.Arguments, 1));
			newObj.ILStackWasEmpty = inst.ILStackWasEmpty;
			StObj stObj = new StObj(inst.Arguments[0], newObj, inst.Method.DeclaringType);
			inst.ReplaceWith(stObj);
			return stObj;
		}
		return null;
	}
}
