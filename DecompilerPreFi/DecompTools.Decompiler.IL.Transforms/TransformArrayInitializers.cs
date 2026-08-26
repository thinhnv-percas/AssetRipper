#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class TransformArrayInitializers : IStatementTransform
{
	private delegate ILInstruction ValueDecoder(ref BlobReader reader);

	private StatementTransformContext context;

	void IStatementTransform.Run(Block block, int pos, StatementTransformContext context)
	{
		if (!context.Settings.ArrayInitializers)
		{
			return;
		}
		this.context = context;
		try
		{
			if (!DoTransform(context.Function, block, pos) && !DoTransformMultiDim(context.Function, block, pos) && context.Settings.StackAllocInitializers && !DoTransformStackAllocInitializer(block, pos))
			{
			}
		}
		finally
		{
			this.context = null;
		}
	}

	private bool DoTransform(ILFunction function, Block body, int pos)
	{
		checked
		{
			if (pos >= body.Instructions.Count - 2)
			{
				return false;
			}
			ILInstruction iLInstruction = body.Instructions[pos];
			if (iLInstruction.MatchStLoc(out var variable, out var value) && MatchNewArr(value, out var elementType, out var length))
			{
				if (HandleRuntimeHelperInitializeArray(body, pos + 1, variable, elementType, length, out var values, out var foundPos))
				{
					context.Step("HandleRuntimeHelperInitializeArray: single-dim", iLInstruction);
					ILVariable v = context.Function.RegisterVariable(VariableKind.InitializerTarget, variable.Type);
					Block value2 = BlockFromInitializer(v, elementType, length, values);
					body.Instructions[pos] = new StLoc(variable, value2);
					body.Instructions.RemoveAt(foundPos);
					ILInlining.InlineIfPossible(body, pos, context);
					return true;
				}
				if (length.Length == 1)
				{
					if (HandleSimpleArrayInitializer(function, body, pos + 1, variable, elementType, length, out (ILInstruction[], ILInstruction)[] values2, out int elementCount))
					{
						context.Step("HandleSimpleArrayInitializer: single-dim", iLInstruction);
						Block block = new Block(BlockKind.ArrayInitializer);
						ILVariable tempStore = context.Function.RegisterVariable(VariableKind.InitializerTarget, variable.Type);
						InstructionCollection<ILInstruction> instructions = block.Instructions;
						ILVariable variable2 = tempStore;
						IType type = elementType;
						ILInstruction[] indices = Enumerable.ToArray<LdcI4>(Enumerable.Select<int, LdcI4>((IEnumerable<int>)length, (Func<int, LdcI4>)((int l) => new LdcI4(l))));
						instructions.Add(new StLoc(variable2, new NewArr(type, indices)));
						block.Instructions.AddRange(Enumerable.Select<(ILInstruction[], ILInstruction), ILInstruction>((IEnumerable<(ILInstruction[], ILInstruction)>)values2, (Func<(ILInstruction[], ILInstruction), ILInstruction>)delegate((ILInstruction[] Indices, ILInstruction Value) t)
						{
							var (indices2, iLInstruction2) = t;
							if (iLInstruction2 == null)
							{
								iLInstruction2 = GetNullExpression(elementType);
							}
							return StElem(new LdLoc(tempStore), indices2, iLInstruction2, elementType);
						}));
						block.FinalInstruction = new LdLoc(tempStore);
						body.Instructions[pos] = new StLoc(variable, block);
						body.Instructions.RemoveRange(pos + 1, elementCount);
						ILInlining.InlineIfPossible(body, pos, context);
						return true;
					}
					if (HandleJaggedArrayInitializer(body, pos + 1, variable, elementType, length[0], out var finalStore, out values, out elementCount))
					{
						context.Step("HandleJaggedArrayInitializer: single-dim", iLInstruction);
						Block block2 = new Block(BlockKind.ArrayInitializer);
						ILVariable tempStore2 = context.Function.RegisterVariable(VariableKind.InitializerTarget, variable.Type);
						InstructionCollection<ILInstruction> instructions2 = block2.Instructions;
						ILVariable variable3 = tempStore2;
						IType type2 = elementType;
						ILInstruction[] indices = Enumerable.ToArray<LdcI4>(Enumerable.Select<int, LdcI4>((IEnumerable<int>)length, (Func<int, LdcI4>)((int l) => new LdcI4(l))));
						instructions2.Add(new StLoc(variable3, new NewArr(type2, indices)));
						block2.Instructions.AddRange(values.SelectWithIndex(delegate(int i, ILInstruction value3)
						{
							LdLoc array = new LdLoc(tempStore2);
							ILInstruction[] indices2 = new LdcI4[1]
							{
								new LdcI4(i)
							};
							return StElem(array, indices2, value3, elementType);
						}));
						block2.FinalInstruction = new LdLoc(tempStore2);
						body.Instructions[pos] = new StLoc(finalStore, block2);
						body.Instructions.RemoveRange(pos + 1, elementCount);
						ILInlining.InlineIfPossible(body, pos, context);
						return true;
					}
				}
			}
			return false;
		}
	}

	internal static bool TransformSpanTArrayInitialization(NewObj inst, StatementTransformContext context, out Block block)
	{
		block = null;
		if (MatchSpanTCtorWithPointerAndSize(inst, context, out var elementType, out var field, out var size) && field.HasFlag(FieldAttributes.HasFieldRVA))
		{
			List<ILInstruction> list = new List<ILInstruction>();
			BlobReader initialValue = field.GetInitialValue(context.PEFile.Reader, context.TypeSystem);
			if (DecodeArrayInitializer(elementType, initialValue, new int[1] { size }, list))
			{
				ILVariable v = context.Function.RegisterVariable(VariableKind.InitializerTarget, new ArrayType(context.TypeSystem, elementType));
				block = BlockFromInitializer(v, elementType, new int[1] { size }, list.ToArray());
				return true;
			}
		}
		return false;
	}

	private static bool MatchSpanTCtorWithPointerAndSize(NewObj newObj, StatementTransformContext context, out IType elementType, out FieldDefinition field, out int size)
	{
		field = default(FieldDefinition);
		size = 0;
		elementType = null;
		IType declaringType = newObj.Method.DeclaringType;
		if (!declaringType.IsKnownType(KnownTypeCode.SpanOfT) && !declaringType.IsKnownType(KnownTypeCode.ReadOnlySpanOfT))
		{
			return false;
		}
		if (newObj.Arguments.Count != 2 || declaringType.TypeArguments.Count != 1)
		{
			return false;
		}
		elementType = declaringType.TypeArguments[0];
		if (!newObj.Arguments[0].UnwrapConv(ConversionKind.StopGCTracking).MatchLdsFlda(out var field2))
		{
			return false;
		}
		if (field2.MetadataToken.IsNil)
		{
			return false;
		}
		if (!newObj.Arguments[1].MatchLdcI4(out size))
		{
			return false;
		}
		field = context.PEFile.Metadata.GetFieldDefinition((FieldDefinitionHandle)field2.MetadataToken);
		return true;
	}

	private bool DoTransformMultiDim(ILFunction function, Block body, int pos)
	{
		checked
		{
			if (pos >= body.Instructions.Count - 2)
			{
				return false;
			}
			ILInstruction iLInstruction = body.Instructions[pos];
			if (iLInstruction.MatchStLoc(out var variable, out var value) && MatchNewArr(value, out var elementType, out var length))
			{
				if (HandleRuntimeHelperInitializeArray(body, pos + 1, variable, elementType, length, out var values, out var foundPos))
				{
					context.Step("HandleRuntimeHelperInitializeArray: multi-dim", iLInstruction);
					Block value2 = BlockFromInitializer(variable, elementType, length, values);
					body.Instructions[pos].ReplaceWith(new StLoc(variable, value2));
					body.Instructions.RemoveAt(foundPos);
					ILInlining.InlineIfPossible(body, pos, context);
					return true;
				}
				if (HandleSimpleArrayInitializer(function, body, pos + 1, variable, elementType, length, out (ILInstruction[], ILInstruction)[] values2, out int elementCount))
				{
					context.Step("HandleSimpleArrayInitializer: multi-dim", iLInstruction);
					Block block = new Block(BlockKind.ArrayInitializer);
					ILVariable tempStore = context.Function.RegisterVariable(VariableKind.InitializerTarget, variable.Type);
					InstructionCollection<ILInstruction> instructions = block.Instructions;
					ILVariable variable2 = tempStore;
					IType type = elementType;
					ILInstruction[] indices = Enumerable.ToArray<LdcI4>(Enumerable.Select<int, LdcI4>((IEnumerable<int>)length, (Func<int, LdcI4>)((int l) => new LdcI4(l))));
					instructions.Add(new StLoc(variable2, new NewArr(type, indices)));
					block.Instructions.AddRange(Enumerable.Select<(ILInstruction[], ILInstruction), ILInstruction>((IEnumerable<(ILInstruction[], ILInstruction)>)values2, (Func<(ILInstruction[], ILInstruction), ILInstruction>)delegate((ILInstruction[] Indices, ILInstruction Value) t)
					{
						var (indices2, iLInstruction2) = t;
						if (iLInstruction2 == null)
						{
							iLInstruction2 = GetNullExpression(elementType);
						}
						return StElem(new LdLoc(tempStore), indices2, iLInstruction2, elementType);
					}));
					block.FinalInstruction = new LdLoc(tempStore);
					body.Instructions[pos] = new StLoc(variable, block);
					body.Instructions.RemoveRange(pos + 1, elementCount);
					ILInlining.InlineIfPossible(body, pos, context);
					return true;
				}
			}
			return false;
		}
	}

	private bool DoTransformStackAllocInitializer(Block body, int pos)
	{
		checked
		{
			if (pos >= body.Instructions.Count - 2)
			{
				return false;
			}
			ILInstruction iLInstruction = body.Instructions[pos];
			if (iLInstruction.MatchStLoc(out var variable, out var value) && value.MatchLocAlloc(out var argument))
			{
				if (argument.MatchLdcI(out var val) && HandleCpblkInitializer(body, pos + 1, variable, val, out var blob, out var elementType))
				{
					context.Step("HandleCpblkInitializer", iLInstruction);
					Block block = new Block(BlockKind.StackAllocInitializer);
					ILVariable iLVariable = context.Function.RegisterVariable(VariableKind.InitializerTarget, new PointerType(elementType));
					block.Instructions.Add(new StLoc(iLVariable, value));
					while (blob.RemainingBytes > 0)
					{
						block.Instructions.Add(StElemPtr(iLVariable, blob.Offset, new LdcI4(blob.ReadByte()), elementType));
					}
					block.FinalInstruction = new LdLoc(iLVariable);
					body.Instructions[pos] = new StLoc(variable, block);
					body.Instructions.RemoveAt(pos + 1);
					ILInlining.InlineIfPossible(body, pos, context);
					ExpressionTransforms.RunOnSingleStatement(body.Instructions[pos], context);
					return true;
				}
				if (HandleSequentialLocAllocInitializer(body, pos + 1, variable, value, out elementType, out var values, out var instructionsToRemove))
				{
					context.Step("HandleSequentialLocAllocInitializer", iLInstruction);
					Block block2 = new Block(BlockKind.StackAllocInitializer);
					ILVariable tempStore = context.Function.RegisterVariable(VariableKind.InitializerTarget, new PointerType(elementType));
					block2.Instructions.Add(new StLoc(tempStore, value));
					block2.Instructions.AddRange(Enumerable.Select<StObj, ILInstruction>(Enumerable.Where<StObj>((IEnumerable<StObj>)values, (Func<StObj, bool>)((StObj stObj) => stObj != null)), (Func<StObj, ILInstruction>)((StObj storeInstruction) => RewrapStore(tempStore, storeInstruction, elementType))));
					block2.FinalInstruction = new LdLoc(tempStore);
					body.Instructions[pos] = new StLoc(variable, block2);
					body.Instructions.RemoveRange(pos + 1, instructionsToRemove);
					ILInlining.InlineIfPossible(body, pos, context);
					ExpressionTransforms.RunOnSingleStatement(body.Instructions[pos], context);
					return true;
				}
			}
			return false;
		}
	}

	private bool HandleCpblkInitializer(Block block, int pos, ILVariable v, long length, out BlobReader blob, out IType elementType)
	{
		blob = default(BlobReader);
		elementType = null;
		if (!block.Instructions[pos].MatchCpblk(out var destAddress, out var sourceAddress, out var size))
		{
			return false;
		}
		checked
		{
			if (!destAddress.MatchLdLoc(v) || !sourceAddress.MatchLdsFlda(out var field) || !size.MatchLdcI4((int)length))
			{
				return false;
			}
			if (field.MetadataToken.IsNil)
			{
				return false;
			}
			if (!block.Instructions[pos + 1].MatchStLoc(out var variable, out var value))
			{
				return false;
			}
			if (!value.MatchLdLoc(v))
			{
				return false;
			}
			FieldDefinition fieldDefinition = context.PEFile.Metadata.GetFieldDefinition((FieldDefinitionHandle)field.MetadataToken);
			if (!fieldDefinition.HasFlag(FieldAttributes.HasFieldRVA))
			{
				return false;
			}
			blob = fieldDefinition.GetInitialValue(context.PEFile.Reader, context.TypeSystem);
			elementType = ((PointerType)variable.Type).ElementType;
			return true;
		}
	}

	private bool HandleSequentialLocAllocInitializer(Block block, int pos, ILVariable store, ILInstruction locAllocInstruction, out IType elementType, out StObj[] values, out int instructionsToRemove)
	{
		int num = 0;
		long num2 = 0L;
		values = null;
		elementType = null;
		instructionsToRemove = 0;
		if (!locAllocInstruction.MatchLocAlloc(out var argument))
		{
			return false;
		}
		checked
		{
			if (block.Instructions[pos].MatchInitblk(out var address, out var value, out var size) && argument.MatchLdcI(out var val))
			{
				if (!address.MatchLdLoc(store) || !size.MatchLdcI(val))
				{
					return false;
				}
				instructionsToRemove++;
				pos++;
			}
			ILInstruction target;
			IType type;
			for (int i = pos; i < block.Instructions.Count && block.Instructions[i].MatchStObj(out target, out value, out type); i++)
			{
				if (Enumerable.Any<IInstructionWithVariableOperand>(Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)value.Descendants), (Func<IInstructionWithVariableOperand, bool>)((IInstructionWithVariableOperand inst) => inst.Variable == store)))
				{
					break;
				}
				if (elementType != null && !type.Equals(elementType))
				{
					break;
				}
				elementType = type;
				if (!target.MatchLdLoc(store))
				{
					if (!target.MatchBinaryNumericInstruction(BinaryNumericOperator.Add, out var left, out var right))
					{
						return false;
					}
					if (!left.MatchLdLoc(store))
					{
						break;
					}
					ILInstruction iLInstruction = PointerArithmeticOffset.Detect(right, new PointerType(elementType), ((BinaryNumericInstruction)target).CheckForOverflow);
					if (iLInstruction == null)
					{
						return false;
					}
					if (!iLInstruction.MatchLdcI(out var val2) || val2 < 0 || val2 < num2)
					{
						break;
					}
					num2 = val2;
				}
				if (values == null)
				{
					ILInstruction iLInstruction2 = PointerArithmeticOffset.Detect(argument, new PointerType(elementType), checkForOverflow: true);
					if (iLInstruction2 == null || !iLInstruction2.MatchLdcI(out var val3) || val3 < 1)
					{
						return false;
					}
					values = new StObj[(int)val3];
				}
				if (num2 >= values.Length)
				{
					break;
				}
				values[num2] = (StObj)block.Instructions[i];
				num++;
			}
			if (values == null || store.Kind != VariableKind.StackSlot || store.StoreCount != 1 || store.AddressCount != 0 || store.LoadCount > values.Length + 1)
			{
				return false;
			}
			if (Enumerable.Last<LdLoc>((IEnumerable<LdLoc>)store.LoadInstructions).Parent is StLoc stLoc)
			{
				elementType = ((PointerType)stLoc.Variable.Type).ElementType;
			}
			instructionsToRemove += num;
			return num <= values.Length;
		}
	}

	private ILInstruction RewrapStore(ILVariable target, StObj storeInstruction, IType type)
	{
		ILInstruction target2;
		if (storeInstruction.Target.MatchLdLoc(out var _))
		{
			target2 = new LdLoc(target);
		}
		else
		{
			if (!storeInstruction.Target.MatchBinaryNumericInstruction(BinaryNumericOperator.Add, out var _, out var right))
			{
				throw new NotSupportedException("This should never happen: Bug in HandleSequentialLocAllocInitializer!");
			}
			BinaryNumericInstruction binaryNumericInstruction = (BinaryNumericInstruction)storeInstruction.Target;
			target2 = new BinaryNumericInstruction(BinaryNumericOperator.Add, new LdLoc(target), right, binaryNumericInstruction.CheckForOverflow, binaryNumericInstruction.Sign);
		}
		return new StObj(target2, storeInstruction.Value, storeInstruction.Type);
	}

	private ILInstruction StElemPtr(ILVariable target, int offset, LdcI4 value, IType type)
	{
		ILInstruction target2 = ((offset == 0) ? ((ILInstruction)new LdLoc(target)) : ((ILInstruction)new BinaryNumericInstruction(BinaryNumericOperator.Add, new LdLoc(target), new Conv(new LdcI4(offset), PrimitiveType.I, checkForOverflow: false, Sign.Signed), checkForOverflow: false, Sign.None)));
		return new StObj(target2, value, type);
	}

	internal static bool HandleSimpleArrayInitializer(ILFunction function, Block block, int pos, ILVariable store, IType elementType, int[] arrayLength, out (ILInstruction[] Indices, ILInstruction Value)[] values, out int elementCount)
	{
		elementCount = 0;
		int[] nextMinimumIndex;
		checked
		{
			int num = Enumerable.Aggregate<int, int>((IEnumerable<int>)arrayLength, 1, (Func<int, int, int>)((int t, int l) => t * l));
			values = new(ILInstruction[], ILInstruction)[num];
			nextMinimumIndex = new int[arrayLength.Length];
			int num2 = 0;
			int num3;
			ILInstruction target;
			ILInstruction value;
			IType type;
			for (num3 = pos; num3 < block.Instructions.Count && block.Instructions[num3].MatchStObj(out target, out value, out type); num3++)
			{
				if (Enumerable.Any<IInstructionWithVariableOperand>(Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)value.Descendants), (Func<IInstructionWithVariableOperand, bool>)((IInstructionWithVariableOperand inst) => inst.Variable == store)))
				{
					break;
				}
				if (!(target is LdElema ldElema))
				{
					break;
				}
				if (!ldElema.Array.MatchLdLoc(store))
				{
					break;
				}
				InstructionCollection<ILInstruction> indices = ldElema.Indices;
				if (indices.Count != arrayLength.Length || num2 >= values.Length)
				{
					break;
				}
				bool exactMatch;
				do
				{
					ILInstruction[] array = CalculateNextIndices(indices, out exactMatch);
					if (array == null)
					{
						return false;
					}
					if (exactMatch)
					{
						values[num2] = (Indices: array, Value: value);
						elementCount++;
					}
					else
					{
						values[num2] = (Indices: array, Value: null);
					}
					num2++;
				}
				while (num2 < values.Length && !exactMatch);
			}
			if (num3 < block.Instructions.Count && block.Instructions[num3].MatchStObj(out var target2, out var _, out var _) && target2 is LdElema ldElema2 && ldElema2.Array.MatchLdLoc(store))
			{
				return false;
			}
			for (; num2 < values.Length; num2++)
			{
				ILInstruction[] array2 = CalculateNextIndices(null, out var _);
				if (array2 == null)
				{
					return false;
				}
				values[num2] = (Indices: array2, Value: null);
			}
			if (pos + elementCount >= block.Instructions.Count)
			{
				return false;
			}
			return ShouldTransformToInitializer(function, block, pos, elementCount, num);
		}
		ILInstruction[] CalculateNextIndices(InstructionCollection<ILInstruction> instructionCollection, out bool reference)
		{
			ILInstruction[] array3 = new ILInstruction[arrayLength.Length];
			reference = true;
			checked
			{
				if (instructionCollection == null)
				{
					for (int i = 0; i < array3.Length; i++)
					{
						array3[i] = new LdcI4(nextMinimumIndex[i]);
					}
				}
				else
				{
					bool flag = false;
					for (int j = 0; j < instructionCollection.Count; j++)
					{
						if (!instructionCollection[j].MatchLdcI4(out var value3))
						{
							return null;
						}
						if (value3 < 0 || value3 >= arrayLength[j] || (!flag && value3 < nextMinimumIndex[j]))
						{
							return null;
						}
						array3[j] = new LdcI4(nextMinimumIndex[j]);
						if (value3 != nextMinimumIndex[j])
						{
							reference = false;
							if (value3 > nextMinimumIndex[j])
							{
								flag = true;
							}
						}
					}
				}
				for (int num4 = nextMinimumIndex.Length - 1; num4 >= 0; num4--)
				{
					nextMinimumIndex[num4]++;
					if (nextMinimumIndex[num4] < arrayLength[num4])
					{
						break;
					}
					nextMinimumIndex[num4] = 0;
				}
				return array3;
			}
		}
	}

	private static bool ShouldTransformToInitializer(ILFunction function, Block block, int startPos, int elementCount, int length)
	{
		if (elementCount == 0)
		{
			return false;
		}
		checked
		{
			if (elementCount >= unchecked(length / 3) - 5)
			{
				return true;
			}
			int? ctorCallStart = null;
			if (ILInlining.IsCatchWhenBlock(block) || ILInlining.IsInConstructorInitializer(function, block.Instructions[startPos], ref ctorCallStart))
			{
				return true;
			}
			return false;
		}
	}

	private bool HandleJaggedArrayInitializer(Block block, int pos, ILVariable store, IType elementType, int length, out ILVariable finalStore, out ILInstruction[] values, out int instructionsToRemove)
	{
		instructionsToRemove = 0;
		finalStore = null;
		values = new ILInstruction[length];
		checked
		{
			for (int i = 0; i < length; i++)
			{
				bool flag = block.Instructions[pos].MatchStLoc(out var variable, out var value) && value.MatchLdLoc(store);
				ILInstruction initializer;
				IType type;
				if (flag)
				{
					if (!MatchJaggedArrayStore(block, pos + 1, variable, i, out initializer, out type))
					{
						return false;
					}
				}
				else if (!MatchJaggedArrayStore(block, pos, store, i, out initializer, out type))
				{
					return false;
				}
				values[i] = initializer;
				int num = (flag ? 3 : 2);
				pos += num;
				instructionsToRemove += num;
			}
			if (block.Instructions[pos].MatchStLoc(out finalStore, out var value2))
			{
				instructionsToRemove++;
				return value2.MatchLdLoc(store);
			}
			finalStore = store;
			return true;
		}
	}

	private bool MatchJaggedArrayStore(Block block, int pos, ILVariable store, int index, out ILInstruction initializer, out IType type)
	{
		initializer = null;
		type = null;
		ILInstruction iLInstruction = block.Instructions.ElementAtOrDefault(checked(pos + 1));
		if (iLInstruction == null || !iLInstruction.MatchStObj(out var target, out var value, out type) || !value.MatchLdLoc(out var variable))
		{
			return false;
		}
		if (!(target is LdElema ldElema) || !ldElema.Array.MatchLdLoc(store) || ldElema.Indices.Count != 1 || !ldElema.Indices[0].MatchLdcI4(index))
		{
			return false;
		}
		ILInstruction iLInstruction2 = block.Instructions.ElementAtOrDefault(pos);
		return iLInstruction2 != null && iLInstruction2.MatchStLoc(variable, out initializer) && initializer.OpCode == OpCode.Block;
	}

	private static Block BlockFromInitializer(ILVariable v, IType elementType, int[] arrayLength, ILInstruction[] values)
	{
		Block block = new Block(BlockKind.ArrayInitializer);
		InstructionCollection<ILInstruction> instructions = block.Instructions;
		ILInstruction[] indices = Enumerable.ToArray<LdcI4>(Enumerable.Select<int, LdcI4>((IEnumerable<int>)arrayLength, (Func<int, LdcI4>)((int l) => new LdcI4(l))));
		instructions.Add(new StLoc(v, new NewArr(elementType, indices)));
		checked
		{
			int num = arrayLength.Length + 1;
			for (int num2 = 0; num2 < unchecked(values.Length / num); num2++)
			{
				ILInstruction value = values[num * num2];
				List<ILInstruction> list = new List<ILInstruction>();
				for (int num3 = num - 1; num3 >= 1; num3--)
				{
					list.Add(values[num * num2 + num3]);
				}
				block.Instructions.Add(StElem(new LdLoc(v), list.ToArray(), value, elementType));
			}
			block.FinalInstruction = new LdLoc(v);
			return block;
		}
	}

	private static bool MatchNewArr(ILInstruction instruction, out IType arrayType, out int[] length)
	{
		length = null;
		arrayType = null;
		if (!(instruction is NewArr newArr))
		{
			return false;
		}
		arrayType = newArr.Type;
		InstructionCollection<ILInstruction> indices = newArr.Indices;
		length = new int[indices.Count];
		for (int i = 0; i < indices.Count; i = checked(i + 1))
		{
			if (!indices[i].MatchLdcI4(out var value) || value <= 0)
			{
				return false;
			}
			length[i] = value;
		}
		return true;
	}

	private bool MatchInitializeArrayCall(ILInstruction instruction, out ILVariable array, out FieldDefinition field)
	{
		array = null;
		field = default(FieldDefinition);
		if (!(instruction is Call call) || call.Arguments.Count != 2)
		{
			return false;
		}
		IMethod method = call.Method;
		if (!method.IsStatic || method.Name != "InitializeArray" || method.DeclaringTypeDefinition == null)
		{
			return false;
		}
		ITypeDefinition declaringTypeDefinition = method.DeclaringTypeDefinition;
		if (declaringTypeDefinition.DeclaringType != null || declaringTypeDefinition.Name != "RuntimeHelpers" || declaringTypeDefinition.Namespace != "System.Runtime.CompilerServices")
		{
			return false;
		}
		if (!call.Arguments[0].MatchLdLoc(out array))
		{
			return false;
		}
		if (!call.Arguments[1].MatchLdMemberToken(out var member))
		{
			return false;
		}
		if (member.MetadataToken.IsNil)
		{
			return false;
		}
		field = context.PEFile.Metadata.GetFieldDefinition((FieldDefinitionHandle)member.MetadataToken);
		return true;
	}

	private bool HandleRuntimeHelperInitializeArray(Block body, int pos, ILVariable array, IType arrayType, int[] arrayLength, out ILInstruction[] values, out int foundPos)
	{
		if (MatchInitializeArrayCall(body.Instructions[pos], out var array2, out var field) && array == array2 && field.HasFlag(FieldAttributes.HasFieldRVA))
		{
			List<ILInstruction> list = new List<ILInstruction>();
			BlobReader initialValue = field.GetInitialValue(context.PEFile.Reader, context.TypeSystem);
			if (DecodeArrayInitializer(arrayType, initialValue, arrayLength, list))
			{
				values = list.ToArray();
				foundPos = pos;
				return true;
			}
		}
		values = null;
		foundPos = -1;
		return false;
	}

	private static bool DecodeArrayInitializer(IType type, BlobReader initialValue, int[] arrayLength, List<ILInstruction> output)
	{
		TypeCode typeCode = type.GetTypeCode();
		switch (typeCode)
		{
		case TypeCode.Boolean:
		case TypeCode.Byte:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcI4(r.ReadByte());
			});
		case TypeCode.SByte:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcI4(r.ReadSByte());
			});
		case TypeCode.Int16:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcI4(r.ReadInt16());
			});
		case TypeCode.Char:
		case TypeCode.UInt16:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcI4(r.ReadUInt16());
			});
		case TypeCode.Int32:
		case TypeCode.UInt32:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcI4(r.ReadInt32());
			});
		case TypeCode.Int64:
		case TypeCode.UInt64:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcI8(r.ReadInt64());
			});
		case TypeCode.Single:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcF4(r.ReadSingle());
			});
		case TypeCode.Double:
			return DecodeArrayInitializer(initialValue, arrayLength, output, typeCode, type, delegate(ref BlobReader r)
			{
				return new LdcF8(r.ReadDouble());
			});
		case TypeCode.Empty:
		case TypeCode.Object:
		{
			ITypeDefinition definition = type.GetDefinition();
			if (definition != null && definition.Kind == TypeKind.Enum)
			{
				return DecodeArrayInitializer(definition.EnumUnderlyingType, initialValue, arrayLength, output);
			}
			return false;
		}
		default:
			return false;
		}
	}

	private static bool DecodeArrayInitializer(BlobReader initialValue, int[] arrayLength, List<ILInstruction> output, TypeCode elementType, IType type, ValueDecoder decoder)
	{
		int num = ElementSizeOf(elementType);
		checked
		{
			int num2 = Enumerable.Aggregate<int, int>((IEnumerable<int>)arrayLength, 1, (Func<int, int, int>)((int t, int l) => t * l));
			if (initialValue.RemainingBytes < num2 * num)
			{
				return false;
			}
			for (int num3 = 0; num3 < num2; num3++)
			{
				output.Add(decoder(ref initialValue));
				int num4 = num3;
				for (int num5 = arrayLength.Length - 1; num5 >= 0; num5--)
				{
					unchecked
					{
						output.Add(new LdcI4(num4 % arrayLength[num5]));
						num4 /= arrayLength[num5];
					}
				}
			}
			return true;
		}
	}

	private static ILInstruction StElem(ILInstruction array, ILInstruction[] indices, ILInstruction value, IType type)
	{
		if (type.GetStackType() != value.ResultType)
		{
			value = new Conv(value, type.ToPrimitiveType(), checkForOverflow: false, Sign.None);
		}
		return new StObj(new LdElema(type, array, indices), value, type);
	}

	internal static ILInstruction GetNullExpression(IType elementType)
	{
		ITypeDefinition definition = elementType.GetEnumUnderlyingType().GetDefinition();
		if (definition == null)
		{
			return new DefaultValue(elementType);
		}
		switch (definition.KnownTypeCode)
		{
		case KnownTypeCode.Boolean:
		case KnownTypeCode.Char:
		case KnownTypeCode.SByte:
		case KnownTypeCode.Byte:
		case KnownTypeCode.Int16:
		case KnownTypeCode.UInt16:
		case KnownTypeCode.Int32:
		case KnownTypeCode.UInt32:
			return new LdcI4(0);
		case KnownTypeCode.Int64:
		case KnownTypeCode.UInt64:
			return new LdcI8(0L);
		case KnownTypeCode.Single:
			return new LdcF4(0f);
		case KnownTypeCode.Double:
			return new LdcF8(0.0);
		case KnownTypeCode.Decimal:
			return new LdcDecimal(0m);
		case KnownTypeCode.Void:
			throw new ArgumentException("void is not a valid element type!");
		default:
			return new DefaultValue(elementType);
		}
	}

	private static int ElementSizeOf(TypeCode elementType)
	{
		switch (elementType)
		{
		case TypeCode.Boolean:
		case TypeCode.SByte:
		case TypeCode.Byte:
			return 1;
		case TypeCode.Char:
		case TypeCode.Int16:
		case TypeCode.UInt16:
			return 2;
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Single:
			return 4;
		case TypeCode.Int64:
		case TypeCode.UInt64:
		case TypeCode.Double:
			return 8;
		default:
			throw new ArgumentOutOfRangeException("elementType");
		}
	}
}
