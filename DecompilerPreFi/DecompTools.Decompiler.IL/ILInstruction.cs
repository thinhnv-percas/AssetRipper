#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public abstract class ILInstruction
{
	public struct ChildrenCollection : IReadOnlyList<ILInstruction>, IEnumerable<ILInstruction>, IEnumerable, IReadOnlyCollection<ILInstruction>
	{
		private readonly ILInstruction inst;

		public int Count => inst.GetChildCount();

		public ILInstruction this[int index]
		{
			get
			{
				return inst.GetChild(index);
			}
			set
			{
				inst.SetChild(index, value);
			}
		}

		internal ChildrenCollection(ILInstruction inst)
		{
			Debug.Assert(inst != null);
			this.inst = inst;
		}

		public ChildrenEnumerator GetEnumerator()
		{
			return new ChildrenEnumerator(inst);
		}

		IEnumerator<ILInstruction> IEnumerable<ILInstruction>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public struct ChildrenEnumerator : IEnumerator<ILInstruction>, IEnumerator, IDisposable
	{
		private ILInstruction inst;

		private readonly int end;

		private int pos;

		public ILInstruction Current => inst.GetChild(pos);

		object IEnumerator.Current => Current;

		internal ChildrenEnumerator(ILInstruction inst)
		{
			Debug.Assert(inst != null);
			this.inst = inst;
			pos = -1;
			end = inst.GetChildCount();
			inst.StartEnumerator();
		}

		public bool MoveNext()
		{
			return checked(++pos) < end;
		}

		public void Dispose()
		{
			if (inst != null)
			{
				inst.StopEnumerator();
				inst = null;
			}
		}

		void IEnumerator.Reset()
		{
			pos = -1;
		}
	}

	public readonly OpCode OpCode;

	private const InstructionFlags invalidFlags = (InstructionFlags)(-1);

	private InstructionFlags flags = (InstructionFlags)(-1);

	private Interval ILRange;

	private int activeEnumerators;

	private byte refCount;

	private ILInstruction parent;

	public abstract StackType ResultType { get; }

	public bool IsDirty { get; private set; }

	public InstructionFlags Flags
	{
		get
		{
			if (flags == (InstructionFlags)(-1))
			{
				flags = ComputeFlags();
			}
			return flags;
		}
	}

	public abstract InstructionFlags DirectFlags { get; }

	public int StartILOffset => ILRange.Start;

	public int EndILOffset => ILRange.End;

	public bool HasILRange => ILRange.IsEmpty;

	public IEnumerable<Interval> ILRanges => new Interval[1] { ILRange };

	public ChildrenCollection Children => new ChildrenCollection(this);

	public IEnumerable<ILInstruction> Descendants
	{
		get
		{
			Stack<ChildrenEnumerator> stack = new Stack<ChildrenEnumerator>();
			ChildrenEnumerator enumerator = new ChildrenEnumerator(this);
			try
			{
				while (true)
				{
					if (enumerator.MoveNext())
					{
						ILInstruction element = enumerator.Current;
						stack.Push(enumerator);
						enumerator = new ChildrenEnumerator(element);
						continue;
					}
					enumerator.Dispose();
					if (stack.Count > 0)
					{
						enumerator = stack.Pop();
						yield return enumerator.Current;
						continue;
					}
					break;
				}
			}
			finally
			{
				enumerator.Dispose();
				while (stack.Count > 0)
				{
					stack.Pop().Dispose();
				}
			}
			yield return this;
		}
	}

	public IEnumerable<ILInstruction> Ancestors
	{
		get
		{
			for (ILInstruction node = this; node != null; node = node.Parent)
			{
				yield return node;
			}
		}
	}

	protected internal bool IsConnected => refCount > 0;

	public ILInstruction Parent => parent;

	public int ChildIndex { get; internal set; } = -1;

	public SlotInfo SlotInfo
	{
		get
		{
			Debug.Assert(parent.GetChild(ChildIndex) == this);
			return parent.GetChildSlot(ChildIndex);
		}
	}

	public bool MatchInvalidBranch()
	{
		if (this is InvalidBranch)
		{
			return true;
		}
		return false;
	}

	public bool MatchInvalidExpression()
	{
		if (this is InvalidExpression)
		{
			return true;
		}
		return false;
	}

	public bool MatchNop()
	{
		if (this is Nop)
		{
			return true;
		}
		return false;
	}

	public bool MatchPinnedRegion(out ILVariable variable, out ILInstruction init, out ILInstruction body)
	{
		if (this is PinnedRegion pinnedRegion)
		{
			variable = pinnedRegion.Variable;
			init = pinnedRegion.Init;
			body = pinnedRegion.Body;
			return true;
		}
		variable = null;
		init = null;
		body = null;
		return false;
	}

	public bool MatchArglist()
	{
		if (this is Arglist)
		{
			return true;
		}
		return false;
	}

	public bool MatchTryCatchHandler(out ILInstruction filter, out ILInstruction body, out ILVariable variable)
	{
		if (this is TryCatchHandler tryCatchHandler)
		{
			filter = tryCatchHandler.Filter;
			body = tryCatchHandler.Body;
			variable = tryCatchHandler.Variable;
			return true;
		}
		filter = null;
		body = null;
		variable = null;
		return false;
	}

	public bool MatchLockInstruction(out ILInstruction onExpression, out ILInstruction body)
	{
		if (this is LockInstruction lockInstruction)
		{
			onExpression = lockInstruction.OnExpression;
			body = lockInstruction.Body;
			return true;
		}
		onExpression = null;
		body = null;
		return false;
	}

	public bool MatchUsingInstruction(out ILVariable variable, out ILInstruction resourceExpression, out ILInstruction body)
	{
		if (this is UsingInstruction usingInstruction)
		{
			variable = usingInstruction.Variable;
			resourceExpression = usingInstruction.ResourceExpression;
			body = usingInstruction.Body;
			return true;
		}
		variable = null;
		resourceExpression = null;
		body = null;
		return false;
	}

	public bool MatchDebugBreak()
	{
		if (this is DebugBreak)
		{
			return true;
		}
		return false;
	}

	public bool MatchCkfinite(out ILInstruction argument)
	{
		if (this is Ckfinite ckfinite)
		{
			argument = ckfinite.Argument;
			return true;
		}
		argument = null;
		return false;
	}

	public bool MatchLdLoc(out ILVariable variable)
	{
		if (this is LdLoc ldLoc)
		{
			variable = ldLoc.Variable;
			return true;
		}
		variable = null;
		return false;
	}

	public bool MatchLdLoca(out ILVariable variable)
	{
		if (this is LdLoca ldLoca)
		{
			variable = ldLoca.Variable;
			return true;
		}
		variable = null;
		return false;
	}

	public bool MatchStLoc(out ILVariable variable, out ILInstruction value)
	{
		if (this is StLoc stLoc)
		{
			variable = stLoc.Variable;
			value = stLoc.Value;
			return true;
		}
		variable = null;
		value = null;
		return false;
	}

	public bool MatchAddressOf(out ILInstruction value)
	{
		if (this is AddressOf addressOf)
		{
			value = addressOf.Value;
			return true;
		}
		value = null;
		return false;
	}

	public bool MatchThreeValuedBoolAnd(out ILInstruction left, out ILInstruction right)
	{
		if (this is ThreeValuedBoolAnd threeValuedBoolAnd)
		{
			left = threeValuedBoolAnd.Left;
			right = threeValuedBoolAnd.Right;
			return true;
		}
		left = null;
		right = null;
		return false;
	}

	public bool MatchThreeValuedBoolOr(out ILInstruction left, out ILInstruction right)
	{
		if (this is ThreeValuedBoolOr threeValuedBoolOr)
		{
			left = threeValuedBoolOr.Left;
			right = threeValuedBoolOr.Right;
			return true;
		}
		left = null;
		right = null;
		return false;
	}

	public bool MatchNullableRewrap(out ILInstruction argument)
	{
		if (this is NullableRewrap nullableRewrap)
		{
			argument = nullableRewrap.Argument;
			return true;
		}
		argument = null;
		return false;
	}

	public bool MatchLdStr(out string value)
	{
		if (this is LdStr ldStr)
		{
			value = ldStr.Value;
			return true;
		}
		value = null;
		return false;
	}

	public bool MatchLdcI4(out int value)
	{
		if (this is LdcI4 ldcI)
		{
			value = ldcI.Value;
			return true;
		}
		value = 0;
		return false;
	}

	public bool MatchLdcI8(out long value)
	{
		if (this is LdcI8 ldcI)
		{
			value = ldcI.Value;
			return true;
		}
		value = 0L;
		return false;
	}

	public bool MatchLdcF4(out float value)
	{
		if (this is LdcF4 ldcF)
		{
			value = ldcF.Value;
			return true;
		}
		value = 0f;
		return false;
	}

	public bool MatchLdcF8(out double value)
	{
		if (this is LdcF8 ldcF)
		{
			value = ldcF.Value;
			return true;
		}
		value = 0.0;
		return false;
	}

	public bool MatchLdcDecimal(out decimal value)
	{
		if (this is LdcDecimal ldcDecimal)
		{
			value = ldcDecimal.Value;
			return true;
		}
		value = 0m;
		return false;
	}

	public bool MatchLdNull()
	{
		if (this is LdNull)
		{
			return true;
		}
		return false;
	}

	public bool MatchLdFtn(out IMethod method)
	{
		if (this is LdFtn ldFtn)
		{
			method = ldFtn.Method;
			return true;
		}
		method = null;
		return false;
	}

	public bool MatchLdVirtFtn(out ILInstruction argument, out IMethod method)
	{
		if (this is LdVirtFtn ldVirtFtn)
		{
			argument = ldVirtFtn.Argument;
			method = ldVirtFtn.Method;
			return true;
		}
		argument = null;
		method = null;
		return false;
	}

	public bool MatchLdTypeToken(out IType type)
	{
		if (this is LdTypeToken ldTypeToken)
		{
			type = ldTypeToken.Type;
			return true;
		}
		type = null;
		return false;
	}

	public bool MatchLdMemberToken(out IMember member)
	{
		if (this is LdMemberToken ldMemberToken)
		{
			member = ldMemberToken.Member;
			return true;
		}
		member = null;
		return false;
	}

	public bool MatchLocAlloc(out ILInstruction argument)
	{
		if (this is LocAlloc locAlloc)
		{
			argument = locAlloc.Argument;
			return true;
		}
		argument = null;
		return false;
	}

	public bool MatchLocAllocSpan(out ILInstruction argument, out IType type)
	{
		if (this is LocAllocSpan locAllocSpan)
		{
			argument = locAllocSpan.Argument;
			type = locAllocSpan.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchCpblk(out ILInstruction destAddress, out ILInstruction sourceAddress, out ILInstruction size)
	{
		if (this is Cpblk cpblk)
		{
			destAddress = cpblk.DestAddress;
			sourceAddress = cpblk.SourceAddress;
			size = cpblk.Size;
			return true;
		}
		destAddress = null;
		sourceAddress = null;
		size = null;
		return false;
	}

	public bool MatchInitblk(out ILInstruction address, out ILInstruction value, out ILInstruction size)
	{
		if (this is Initblk initblk)
		{
			address = initblk.Address;
			value = initblk.Value;
			size = initblk.Size;
			return true;
		}
		address = null;
		value = null;
		size = null;
		return false;
	}

	public bool MatchLdFlda(out ILInstruction target, out IField field)
	{
		if (this is LdFlda ldFlda)
		{
			target = ldFlda.Target;
			field = ldFlda.Field;
			return true;
		}
		target = null;
		field = null;
		return false;
	}

	public bool MatchLdsFlda(out IField field)
	{
		if (this is LdsFlda ldsFlda)
		{
			field = ldsFlda.Field;
			return true;
		}
		field = null;
		return false;
	}

	public bool MatchCastClass(out ILInstruction argument, out IType type)
	{
		if (this is CastClass castClass)
		{
			argument = castClass.Argument;
			type = castClass.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchIsInst(out ILInstruction argument, out IType type)
	{
		if (this is IsInst isInst)
		{
			argument = isInst.Argument;
			type = isInst.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchLdObj(out ILInstruction target, out IType type)
	{
		if (this is LdObj ldObj)
		{
			target = ldObj.Target;
			type = ldObj.Type;
			return true;
		}
		target = null;
		type = null;
		return false;
	}

	public bool MatchStObj(out ILInstruction target, out ILInstruction value, out IType type)
	{
		if (this is StObj stObj)
		{
			target = stObj.Target;
			value = stObj.Value;
			type = stObj.Type;
			return true;
		}
		target = null;
		value = null;
		type = null;
		return false;
	}

	public bool MatchBox(out ILInstruction argument, out IType type)
	{
		if (this is Box box)
		{
			argument = box.Argument;
			type = box.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchUnbox(out ILInstruction argument, out IType type)
	{
		if (this is Unbox unbox)
		{
			argument = unbox.Argument;
			type = unbox.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchUnboxAny(out ILInstruction argument, out IType type)
	{
		if (this is UnboxAny unboxAny)
		{
			argument = unboxAny.Argument;
			type = unboxAny.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchNewArr(out IType type)
	{
		if (this is NewArr newArr)
		{
			type = newArr.Type;
			return true;
		}
		type = null;
		return false;
	}

	public bool MatchDefaultValue(out IType type)
	{
		if (this is DefaultValue defaultValue)
		{
			type = defaultValue.Type;
			return true;
		}
		type = null;
		return false;
	}

	public bool MatchThrow(out ILInstruction argument)
	{
		if (this is Throw obj)
		{
			argument = obj.Argument;
			return true;
		}
		argument = null;
		return false;
	}

	public bool MatchRethrow()
	{
		if (this is Rethrow)
		{
			return true;
		}
		return false;
	}

	public bool MatchSizeOf(out IType type)
	{
		if (this is SizeOf sizeOf)
		{
			type = sizeOf.Type;
			return true;
		}
		type = null;
		return false;
	}

	public bool MatchLdElema(out IType type, out ILInstruction array)
	{
		if (this is LdElema ldElema)
		{
			type = ldElema.Type;
			array = ldElema.Array;
			return true;
		}
		type = null;
		array = null;
		return false;
	}

	public bool MatchArrayToPointer(out ILInstruction array)
	{
		if (this is ArrayToPointer arrayToPointer)
		{
			array = arrayToPointer.Array;
			return true;
		}
		array = null;
		return false;
	}

	public bool MatchUserDefinedLogicOperator(out IMethod method, out ILInstruction left, out ILInstruction right)
	{
		if (this is UserDefinedLogicOperator userDefinedLogicOperator)
		{
			method = userDefinedLogicOperator.Method;
			left = userDefinedLogicOperator.Left;
			right = userDefinedLogicOperator.Right;
			return true;
		}
		method = null;
		left = null;
		right = null;
		return false;
	}

	public bool MatchMakeRefAny(out ILInstruction argument, out IType type)
	{
		if (this is MakeRefAny makeRefAny)
		{
			argument = makeRefAny.Argument;
			type = makeRefAny.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchRefAnyType(out ILInstruction argument)
	{
		if (this is RefAnyType refAnyType)
		{
			argument = refAnyType.Argument;
			return true;
		}
		argument = null;
		return false;
	}

	public bool MatchRefAnyValue(out ILInstruction argument, out IType type)
	{
		if (this is RefAnyValue refAnyValue)
		{
			argument = refAnyValue.Argument;
			type = refAnyValue.Type;
			return true;
		}
		argument = null;
		type = null;
		return false;
	}

	public bool MatchYieldReturn(out ILInstruction value)
	{
		if (this is YieldReturn yieldReturn)
		{
			value = yieldReturn.Value;
			return true;
		}
		value = null;
		return false;
	}

	public bool MatchAwait(out ILInstruction value)
	{
		if (this is Await obj)
		{
			value = obj.Value;
			return true;
		}
		value = null;
		return false;
	}

	protected ILInstruction(OpCode opCode)
	{
		OpCode = opCode;
	}

	protected void ValidateChild(ILInstruction inst)
	{
		if (inst == null)
		{
			throw new ArgumentNullException("inst");
		}
		Debug.Assert(!IsDescendantOf(inst), "ILAst must form a tree");
	}

	[Conditional("DEBUG")]
	internal virtual void CheckInvariant(ILPhase phase)
	{
		foreach (ILInstruction child in Children)
		{
			Debug.Assert(child.Parent == this);
			Debug.Assert(GetChild(child.ChildIndex) == child);
			Debug.Assert(this is ILFunction || child.flags != (InstructionFlags)(-1) || flags == (InstructionFlags)(-1));
			Debug.Assert(child.IsConnected == IsConnected);
			child.CheckInvariant(phase);
		}
		Debug.Assert((DirectFlags & ~Flags) == 0, "All DirectFlags must also appear in this.Flags");
	}

	public bool IsDescendantOf(ILInstruction possibleAncestor)
	{
		for (ILInstruction iLInstruction = this; iLInstruction != null; iLInstruction = iLInstruction.Parent)
		{
			if (iLInstruction == possibleAncestor)
			{
				return true;
			}
		}
		return false;
	}

	internal static StackType CommonResultType(StackType a, StackType b)
	{
		if (a == StackType.I || b == StackType.I)
		{
			return StackType.I;
		}
		Debug.Assert(a == b);
		return a;
	}

	protected void MakeDirty()
	{
		ILInstruction iLInstruction = this;
		while (iLInstruction != null && !iLInstruction.IsDirty)
		{
			iLInstruction.IsDirty = true;
			iLInstruction = iLInstruction.parent;
		}
	}

	public void ResetDirty()
	{
		foreach (ILInstruction descendant in Descendants)
		{
			descendant.IsDirty = false;
		}
	}

	public bool HasFlag(InstructionFlags flags)
	{
		return (Flags & flags) != 0;
	}

	public bool HasDirectFlag(InstructionFlags flags)
	{
		return (DirectFlags & flags) != 0;
	}

	protected void InvalidateFlags()
	{
		ILInstruction iLInstruction = this;
		while (iLInstruction != null && iLInstruction.flags != (InstructionFlags)(-1))
		{
			iLInstruction.flags = (InstructionFlags)(-1);
			iLInstruction = iLInstruction.parent;
		}
	}

	protected abstract InstructionFlags ComputeFlags();

	public void AddILRange(Interval newRange)
	{
		if (ILRange.IsEmpty)
		{
			ILRange = newRange;
		}
		else
		{
			if (newRange.IsEmpty)
			{
				return;
			}
			if (newRange.Start <= StartILOffset)
			{
				if (newRange.End < StartILOffset)
				{
					ILRange = newRange;
				}
				else
				{
					ILRange = new Interval(newRange.Start, Math.Max(newRange.End, ILRange.End));
				}
			}
			else if (newRange.Start <= ILRange.End)
			{
				ILRange = new Interval(StartILOffset, Math.Max(newRange.End, ILRange.End));
			}
		}
	}

	public void AddILRange(ILInstruction sourceInstruction)
	{
		AddILRange(sourceInstruction.ILRange);
	}

	public void SetILRange(ILInstruction sourceInstruction)
	{
		ILRange = sourceInstruction.ILRange;
	}

	public void SetILRange(Interval range)
	{
		ILRange = range;
	}

	public void WriteILRange(ITextOutput output, ILAstWritingOptions options)
	{
		ILRange.WriteTo(output, options);
	}

	public abstract void WriteTo(ITextOutput output, ILAstWritingOptions options);

	public override string ToString()
	{
		PlainTextOutput plainTextOutput = new PlainTextOutput();
		WriteTo(plainTextOutput, new ILAstWritingOptions());
		if (!ILRange.IsEmpty)
		{
			int start = ILRange.Start;
			plainTextOutput.Write(" at IL_" + start.ToString("x4"));
		}
		return plainTextOutput.ToString();
	}

	public abstract void AcceptVisitor(ILVisitor visitor);

	public abstract T AcceptVisitor<T>(ILVisitor<T> visitor);

	public abstract T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context);

	protected abstract int GetChildCount();

	protected abstract ILInstruction GetChild(int index);

	protected abstract void SetChild(int index, ILInstruction value);

	protected abstract SlotInfo GetChildSlot(int index);

	[Conditional("DEBUG")]
	internal void StartEnumerator()
	{
		checked
		{
			activeEnumerators++;
		}
	}

	[Conditional("DEBUG")]
	internal void StopEnumerator()
	{
		Debug.Assert(activeEnumerators > 0);
		checked
		{
			activeEnumerators--;
		}
	}

	[Conditional("DEBUG")]
	internal void AssertNoEnumerators()
	{
		Debug.Assert(activeEnumerators == 0);
	}

	public void ReplaceWith(ILInstruction replacement)
	{
		Debug.Assert(parent.GetChild(ChildIndex) == this);
		if (replacement != this)
		{
			parent.SetChild(ChildIndex, replacement);
		}
	}

	internal void AddRef()
	{
		byte b = refCount;
		checked
		{
			refCount = (byte)(unchecked((uint)b) + 1u);
			if (b == 0)
			{
				Connected();
			}
		}
	}

	internal void ReleaseRef()
	{
		Debug.Assert(refCount > 0);
		checked
		{
			if ((refCount = (byte)(unchecked((uint)refCount) - 1u)) == 0)
			{
				Disconnected();
			}
		}
	}

	protected virtual void Connected()
	{
		foreach (ILInstruction child in Children)
		{
			child.AddRef();
		}
	}

	protected virtual void Disconnected()
	{
		foreach (ILInstruction child in Children)
		{
			child.ReleaseRef();
		}
	}

	protected internal void SetChildInstruction(ref ILInstruction childPointer, ILInstruction newValue, int index)
	{
		ILInstruction iLInstruction = childPointer;
		Debug.Assert(iLInstruction == GetChild(index));
		if (iLInstruction != newValue)
		{
			childPointer = newValue;
			if (newValue != null)
			{
				newValue.parent = this;
				newValue.ChildIndex = index;
			}
			InvalidateFlags();
			MakeDirty();
			if (refCount > 0)
			{
				newValue?.AddRef();
				iLInstruction?.ReleaseRef();
			}
		}
	}

	protected internal void InstructionCollectionAdded(ILInstruction newChild)
	{
		Debug.Assert(GetChild(newChild.ChildIndex) == newChild);
		Debug.Assert(!IsDescendantOf(newChild), "ILAst must form a tree");
		newChild.parent = this;
		if (refCount > 0)
		{
			newChild.AddRef();
		}
	}

	protected internal void InstructionCollectionRemoved(ILInstruction oldChild)
	{
		if (refCount > 0)
		{
			oldChild.ReleaseRef();
		}
	}

	protected internal virtual void InstructionCollectionUpdateComplete()
	{
		InvalidateFlags();
		MakeDirty();
	}

	public abstract ILInstruction Clone();

	protected ILInstruction ShallowClone()
	{
		ILInstruction iLInstruction = (ILInstruction)MemberwiseClone();
		iLInstruction.refCount = 0;
		iLInstruction.parent = null;
		iLInstruction.flags = (InstructionFlags)(-1);
		iLInstruction.activeEnumerators = 0;
		return iLInstruction;
	}

	public Match Match(ILInstruction node)
	{
		Match match = default(Match);
		match.Success = PerformMatch(node, ref match);
		return match;
	}

	protected internal abstract bool PerformMatch(ILInstruction other, ref Match match);

	protected internal virtual bool PerformMatch(ref ListMatch listMatch, ref Match match)
	{
		checked
		{
			if (listMatch.SyntaxIndex < listMatch.SyntaxList.Count && PerformMatch(listMatch.SyntaxList[listMatch.SyntaxIndex], ref match))
			{
				listMatch.SyntaxIndex++;
				return true;
			}
			return false;
		}
	}

	public bool MatchLdcI4(int val)
	{
		return OpCode == OpCode.LdcI4 && ((LdcI4)this).Value == val;
	}

	public bool MatchLdcF4(float value)
	{
		float value2;
		return MatchLdcF4(out value2) && value2 == value;
	}

	public bool MatchLdcF8(double value)
	{
		double value2;
		return MatchLdcF8(out value2) && value2 == value;
	}

	public bool MatchLdcI(out long val)
	{
		if (MatchLdcI8(out val))
		{
			return true;
		}
		if (MatchLdcI4(out var value))
		{
			val = value;
			return true;
		}
		if (this is Conv conv)
		{
			if (conv.Kind == ConversionKind.SignExtend)
			{
				return conv.Argument.MatchLdcI(out val);
			}
			if (conv.Kind == ConversionKind.ZeroExtend && conv.InputType == StackType.I4 && conv.Argument.MatchLdcI(out val))
			{
				val &= 4294967295L;
				return true;
			}
		}
		return false;
	}

	public bool MatchLdcI(long val)
	{
		long val2;
		return MatchLdcI(out val2) && val2 == val;
	}

	public bool MatchLdLoc(ILVariable variable)
	{
		return this is LdLoc ldLoc && ldLoc.Variable == variable;
	}

	public bool MatchLdLoca(ILVariable variable)
	{
		return this is LdLoca ldLoca && ldLoca.Variable == variable;
	}

	public bool MatchLdLocRef(ILVariable variable)
	{
		ILVariable variable2;
		return MatchLdLocRef(out variable2) && variable2 == variable;
	}

	public bool MatchLdLocRef(out ILVariable variable)
	{
		if (this != null)
		{
			if (this is LdLoc ldLoc)
			{
				LdLoc ldLoc2 = ldLoc;
				variable = ldLoc2.Variable;
				return variable.Type.IsReferenceType == true;
			}
			if (this is LdLoca ldLoca)
			{
				LdLoca ldLoca2 = ldLoca;
				variable = ldLoca2.Variable;
				return variable.Type.IsReferenceType != true || variable.Type.Kind == TypeKind.TypeParameter;
			}
		}
		variable = null;
		return false;
	}

	public bool MatchLdThis()
	{
		return this is LdLoc ldLoc && ldLoc.Variable.Kind == VariableKind.Parameter && ldLoc.Variable.Index < 0;
	}

	public bool MatchStLoc(out ILVariable variable)
	{
		if (this is StLoc stLoc)
		{
			variable = stLoc.Variable;
			return true;
		}
		variable = null;
		return false;
	}

	public bool MatchStLoc(ILVariable variable, out ILInstruction value)
	{
		if (this is StLoc stLoc && stLoc.Variable == variable)
		{
			value = stLoc.Value;
			return true;
		}
		value = null;
		return false;
	}

	public bool MatchLdLen(StackType type, out ILInstruction array)
	{
		if (this is LdLen ldLen && ldLen.ResultType == type)
		{
			array = ldLen.Array;
			return true;
		}
		array = null;
		return false;
	}

	public bool MatchReturn(out ILInstruction value)
	{
		if (this is Leave { IsLeavingFunction: not false } leave)
		{
			value = leave.Value;
			return true;
		}
		value = null;
		return false;
	}

	public bool MatchBranch(out Block targetBlock)
	{
		if (this is Branch branch)
		{
			targetBlock = branch.TargetBlock;
			return true;
		}
		targetBlock = null;
		return false;
	}

	public bool MatchBranch(Block targetBlock)
	{
		return this is Branch branch && branch.TargetBlock == targetBlock;
	}

	public bool MatchLeave(out BlockContainer targetContainer, out ILInstruction value)
	{
		if (this is Leave leave)
		{
			targetContainer = leave.TargetContainer;
			value = leave.Value;
			return true;
		}
		targetContainer = null;
		value = null;
		return false;
	}

	public bool MatchLeave(BlockContainer targetContainer, out ILInstruction value)
	{
		if (this is Leave leave && targetContainer == leave.TargetContainer)
		{
			value = leave.Value;
			return true;
		}
		value = null;
		return false;
	}

	public bool MatchLeave(out BlockContainer targetContainer)
	{
		if (this is Leave leave && leave.Value.MatchNop())
		{
			targetContainer = leave.TargetContainer;
			return true;
		}
		targetContainer = null;
		return false;
	}

	public bool MatchLeave(BlockContainer targetContainer)
	{
		return this is Leave leave && leave.TargetContainer == targetContainer && leave.Value.MatchNop();
	}

	public bool MatchIfInstruction(out ILInstruction condition, out ILInstruction trueInst, out ILInstruction falseInst)
	{
		if (this is IfInstruction ifInstruction)
		{
			condition = ifInstruction.Condition;
			trueInst = ifInstruction.TrueInst;
			falseInst = ifInstruction.FalseInst;
			return true;
		}
		condition = null;
		trueInst = null;
		falseInst = null;
		return false;
	}

	public bool MatchIfInstructionPositiveCondition(out ILInstruction condition, out ILInstruction trueInst, out ILInstruction falseInst)
	{
		if (MatchIfInstruction(out condition, out trueInst, out falseInst))
		{
			ILInstruction arg;
			while (condition.MatchLogicNot(out arg))
			{
				condition = arg;
				ILInstruction iLInstruction = trueInst;
				trueInst = falseInst;
				falseInst = iLInstruction;
			}
			return true;
		}
		return false;
	}

	public bool MatchIfInstruction(out ILInstruction condition, out ILInstruction trueInst)
	{
		if (this is IfInstruction ifInstruction && ifInstruction.FalseInst.MatchNop())
		{
			condition = ifInstruction.Condition;
			trueInst = ifInstruction.TrueInst;
			return true;
		}
		condition = null;
		trueInst = null;
		return false;
	}

	public bool MatchLogicAnd(out ILInstruction lhs, out ILInstruction rhs)
	{
		if (this is IfInstruction ifInstruction && ifInstruction.FalseInst.MatchLdcI4(0))
		{
			lhs = ifInstruction.Condition;
			rhs = ifInstruction.TrueInst;
			return true;
		}
		lhs = null;
		rhs = null;
		return false;
	}

	public bool MatchLogicOr(out ILInstruction lhs, out ILInstruction rhs)
	{
		if (this is IfInstruction ifInstruction && ifInstruction.TrueInst.MatchLdcI4(1))
		{
			lhs = ifInstruction.Condition;
			rhs = ifInstruction.FalseInst;
			return true;
		}
		lhs = null;
		rhs = null;
		return false;
	}

	public bool MatchLogicNot(out ILInstruction arg)
	{
		if (this is Comp { Kind: ComparisonKind.Equality, LiftingKind: ComparisonLiftingKind.None } comp && comp.Right.MatchLdcI4(0))
		{
			arg = comp.Left;
			return true;
		}
		arg = null;
		return false;
	}

	public bool MatchTryCatchHandler(out ILVariable variable)
	{
		if (this is TryCatchHandler tryCatchHandler)
		{
			variable = tryCatchHandler.Variable;
			return true;
		}
		variable = null;
		return false;
	}

	public bool MatchCompEquals(out ILInstruction left, out ILInstruction right)
	{
		ILInstruction iLInstruction = this;
		ComparisonKind comparisonKind = ComparisonKind.Equality;
		ILInstruction arg;
		while (iLInstruction.MatchLogicNot(out arg) && arg is Comp)
		{
			iLInstruction = arg;
			comparisonKind = ((comparisonKind == ComparisonKind.Equality) ? ComparisonKind.Inequality : ComparisonKind.Equality);
		}
		if (iLInstruction is Comp comp && comp.Kind == comparisonKind && !comp.IsLifted)
		{
			left = comp.Left;
			right = comp.Right;
			return true;
		}
		left = null;
		right = null;
		return false;
	}

	public bool MatchCompEqualsNull(out ILInstruction arg)
	{
		if (!MatchCompEquals(out var left, out var right))
		{
			arg = null;
			return false;
		}
		if (right.MatchLdNull())
		{
			arg = left;
			return true;
		}
		if (left.MatchLdNull())
		{
			arg = right;
			return true;
		}
		arg = null;
		return false;
	}

	public bool MatchCompNotEqualsNull(out ILInstruction arg)
	{
		if (!MatchCompNotEquals(out var left, out var right))
		{
			arg = null;
			return false;
		}
		if (right.MatchLdNull())
		{
			arg = left;
			return true;
		}
		if (left.MatchLdNull())
		{
			arg = right;
			return true;
		}
		arg = null;
		return false;
	}

	public bool MatchCompNotEquals(out ILInstruction left, out ILInstruction right)
	{
		ILInstruction iLInstruction = this;
		ComparisonKind comparisonKind = ComparisonKind.Inequality;
		ILInstruction arg;
		while (iLInstruction.MatchLogicNot(out arg) && arg is Comp)
		{
			iLInstruction = arg;
			comparisonKind = ((comparisonKind == ComparisonKind.Equality) ? ComparisonKind.Inequality : ComparisonKind.Equality);
		}
		if (iLInstruction is Comp comp && comp.Kind == comparisonKind && !comp.IsLifted)
		{
			left = comp.Left;
			right = comp.Right;
			return true;
		}
		left = null;
		right = null;
		return false;
	}

	public bool MatchLdFld(out ILInstruction target, out IField field)
	{
		if (this is LdObj { Target: LdFlda target2, UnalignedPrefix: 0, IsVolatile: false })
		{
			field = target2.Field;
			if (field.DeclaringType.IsReferenceType == true || !target2.Target.MatchAddressOf(out target))
			{
				target = target2.Target;
			}
			return true;
		}
		target = null;
		field = null;
		return false;
	}

	public bool MatchLdsFld(out IField field)
	{
		if (this is LdObj { Target: LdsFlda target, UnalignedPrefix: 0, IsVolatile: false })
		{
			field = target.Field;
			return true;
		}
		field = null;
		return false;
	}

	public bool MatchLdsFld(IField field)
	{
		IField field2;
		return MatchLdsFld(out field2) && field2.Equals(field);
	}

	public bool MatchStsFld(out IField field, out ILInstruction value)
	{
		if (this is StObj { Target: LdsFlda target, UnalignedPrefix: 0, IsVolatile: false } stObj)
		{
			field = target.Field;
			value = stObj.Value;
			return true;
		}
		field = null;
		value = null;
		return false;
	}

	public bool MatchStFld(out ILInstruction target, out IField field, out ILInstruction value)
	{
		if (this is StObj { Target: LdFlda target2, UnalignedPrefix: 0, IsVolatile: false } stObj)
		{
			target = target2.Target;
			field = target2.Field;
			value = stObj.Value;
			return true;
		}
		target = null;
		field = null;
		value = null;
		return false;
	}

	public bool MatchBinaryNumericInstruction(BinaryNumericOperator @operator)
	{
		return this is BinaryNumericInstruction binaryNumericInstruction && binaryNumericInstruction.Operator == @operator;
	}

	public bool MatchBinaryNumericInstruction(BinaryNumericOperator @operator, out ILInstruction left, out ILInstruction right)
	{
		if (this is BinaryNumericInstruction binaryNumericInstruction && binaryNumericInstruction.Operator == @operator)
		{
			left = binaryNumericInstruction.Left;
			right = binaryNumericInstruction.Right;
			return true;
		}
		left = null;
		right = null;
		return false;
	}

	public bool MatchBinaryNumericInstruction(out BinaryNumericOperator @operator, out ILInstruction left, out ILInstruction right)
	{
		if (this is BinaryNumericInstruction binaryNumericInstruction)
		{
			@operator = binaryNumericInstruction.Operator;
			left = binaryNumericInstruction.Left;
			right = binaryNumericInstruction.Right;
			return true;
		}
		@operator = BinaryNumericOperator.None;
		left = null;
		right = null;
		return false;
	}

	public virtual ILInstruction UnwrapConv(ConversionKind kind)
	{
		return this;
	}
}
