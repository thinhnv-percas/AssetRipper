using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Transforms;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public struct AccessPathElement : IEquatable<AccessPathElement>
{
	public readonly OpCode OpCode;

	public readonly IMember Member;

	public readonly ILInstruction[] Indices;

	public AccessPathElement(OpCode opCode, IMember member, ILInstruction[] indices = null)
	{
		OpCode = opCode;
		Member = member;
		Indices = indices;
	}

	public override string ToString()
	{
		return $"[{Member}, {Indices}]";
	}

	public static (AccessPathKind Kind, List<AccessPathElement> Path, List<ILInstruction> Values, ILVariable Target) GetAccessPath(ILInstruction instruction, IType rootType, DecompilerSettings settings, CSharpTypeResolveContext resolveContext = null, Dictionary<ILVariable, (int Index, ILInstruction Value)> possibleIndexVariables = null)
	{
		List<AccessPathElement> list = new List<AccessPathElement>();
		ILVariable target = null;
		AccessPathKind accessPathKind = AccessPathKind.Invalid;
		List<ILInstruction> list2 = null;
		ILInstruction iLInstruction = instruction;
		while (instruction != null)
		{
			ILInstruction iLInstruction2 = instruction;
			ILInstruction iLInstruction3 = iLInstruction2;
			CallInstruction callInstruction2;
			IMethod method;
			if (iLInstruction3 != null)
			{
				if (!(iLInstruction3 is CallInstruction callInstruction))
				{
					if (!(iLInstruction3 is LdObj ldObj))
					{
						if (!(iLInstruction3 is StObj stObj))
						{
							if (iLInstruction3 is LdLoc ldLoc)
							{
								LdLoc ldLoc2 = ldLoc;
								target = ldLoc2.Variable;
								instruction = null;
								continue;
							}
							if (iLInstruction3 is LdLoca ldLoca)
							{
								LdLoca ldLoca2 = ldLoca;
								target = ldLoca2.Variable;
								instruction = null;
								continue;
							}
							if (iLInstruction3 is LdFlda ldFlda)
							{
								LdFlda ldFlda2 = ldFlda;
								list.Insert(0, new AccessPathElement(ldFlda2.OpCode, ldFlda2.Field));
								instruction = ldFlda2.Target;
								continue;
							}
						}
						else
						{
							StObj stObj2 = stObj;
							if (stObj2.Target is LdFlda ldFlda3)
							{
								list.Insert(0, new AccessPathElement(stObj2.OpCode, ldFlda3.Field));
								instruction = ldFlda3.Target;
								if (list2 == null)
								{
									list2 = new List<ILInstruction>(new ILInstruction[1] { stObj2.Value });
									accessPathKind = AccessPathKind.Setter;
								}
								continue;
							}
						}
					}
					else
					{
						LdObj ldObj2 = ldObj;
						if (ldObj2.Target is LdFlda ldFlda4 && (accessPathKind != AccessPathKind.Setter || !ldFlda4.Field.IsReadOnly))
						{
							list.Insert(0, new AccessPathElement(ldObj2.OpCode, ldFlda4.Field));
							instruction = ldFlda4.Target;
							continue;
						}
					}
				}
				else
				{
					callInstruction2 = callInstruction;
					if (callInstruction2 is CallVirt || callInstruction2 is Call)
					{
						method = callInstruction2.Method;
						if (resolveContext == null || IsMethodApplicable(method, callInstruction2.Arguments, rootType, resolveContext, settings))
						{
							instruction = callInstruction2.Arguments[0];
							if (!method.IsAccessor)
							{
								list.Insert(0, new AccessPathElement(callInstruction2.OpCode, method));
								goto IL_0241;
							}
							IProperty property = method.AccessorOwner as IProperty;
							if (CanBeUsedInInitializer(property, resolveContext, accessPathKind, list))
							{
								bool flag = method.Equals(property?.Getter);
								ILInstruction[] array = Enumerable.ToArray<ILInstruction>(Enumerable.Take<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)callInstruction2.Arguments, 1), checked(callInstruction2.Arguments.Count - (flag ? 1 : 2))));
								if (array.Length == 0 || settings.DictionaryInitializers)
								{
									if (possibleIndexVariables != null)
									{
										foreach (IInstructionWithVariableOperand item in Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)array))
										{
											if (possibleIndexVariables.TryGetValue(item.Variable, out (int, ILInstruction) value))
											{
												possibleIndexVariables[item.Variable] = (-1, value.Item2);
											}
										}
									}
									list.Insert(0, new AccessPathElement(callInstruction2.OpCode, method.AccessorOwner, array));
									goto IL_0241;
								}
							}
						}
					}
				}
			}
			goto IL_03da;
			IL_03da:
			accessPathKind = AccessPathKind.Invalid;
			instruction = null;
			continue;
			IL_0241:
			if (list2 == null)
			{
				if (method.IsAccessor)
				{
					accessPathKind = AccessPathKind.Setter;
					list2 = new List<ILInstruction> { callInstruction2.Arguments.Last() };
					continue;
				}
				accessPathKind = AccessPathKind.Adder;
				list2 = new List<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)callInstruction2.Arguments, 1));
				if (list2.Count == 0)
				{
					goto IL_03da;
				}
				continue;
			}
		}
		if (accessPathKind != AccessPathKind.Invalid && Enumerable.Any<IInstructionWithVariableOperand>(Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)Enumerable.SelectMany<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)list2, (Func<ILInstruction, IEnumerable<ILInstruction>>)((ILInstruction v) => v.Descendants))), (Func<IInstructionWithVariableOperand, bool>)((IInstructionWithVariableOperand ld) => ld.Variable == target && (ld is LdLoc || ld is LdLoca))))
		{
			accessPathKind = AccessPathKind.Invalid;
		}
		return (Kind: accessPathKind, Path: list, Values: list2, Target: target);
	}

	private static bool CanBeUsedInInitializer(IProperty property, CSharpTypeResolveContext resolveContext, AccessPathKind kind, List<AccessPathElement> path)
	{
		if (property.CanSet && (property.Accessibility == property.Setter.Accessibility || IsAccessorAccessible(property.Setter, resolveContext)))
		{
			return true;
		}
		return kind != AccessPathKind.Setter;
	}

	private static bool IsAccessorAccessible(IMethod setter, CSharpTypeResolveContext resolveContext)
	{
		if (resolveContext == null)
		{
			return true;
		}
		MemberLookup memberLookup = new MemberLookup(resolveContext.CurrentTypeDefinition, resolveContext.CurrentModule);
		return memberLookup.IsAccessible(setter, setter.DeclaringTypeDefinition == resolveContext.CurrentTypeDefinition);
	}

	private static bool IsMethodApplicable(IMethod method, IReadOnlyList<ILInstruction> arguments, IType rootType, CSharpTypeResolveContext resolveContext, DecompilerSettings settings)
	{
		if (method.IsStatic && !method.IsExtensionMethod)
		{
			return false;
		}
		if (method.AccessorOwner is IProperty)
		{
			return true;
		}
		if (!"Add".Equals(method.Name, StringComparison.Ordinal) || arguments.Count == 0)
		{
			return false;
		}
		if (method.IsExtensionMethod)
		{
			return settings.ExtensionMethodsInCollectionInitializers && IntroduceExtensionMethods.CanTransformToExtensionMethodCall(method, resolveContext, ignoreTypeArguments: true);
		}
		IType type = GetReturnTypeFromInstruction(arguments[0]) ?? rootType;
		if (type == null)
		{
			return false;
		}
		if (!Enumerable.Any<IType>(type.GetAllBaseTypes(), (Func<IType, bool>)((IType i) => i.IsKnownType(KnownTypeCode.IEnumerable) || i.IsKnownType(KnownTypeCode.IEnumerableOfT))))
		{
			return false;
		}
		return CallBuilder.CanInferTypeArgumentsFromParameters(method, method.Parameters.SelectReadOnlyArray((IParameter p) => new ResolveResult(p.Type)), new TypeInference(resolveContext.Compilation));
	}

	private static IType GetReturnTypeFromInstruction(ILInstruction instruction)
	{
		if (instruction != null)
		{
			if (!(instruction is CallInstruction callInstruction))
			{
				if (!(instruction is LdObj ldObj))
				{
					if (instruction is StObj stObj)
					{
						StObj stObj2 = stObj;
						if (stObj2.Target is LdFlda ldFlda)
						{
							return ldFlda.Field.ReturnType;
						}
					}
				}
				else
				{
					LdObj ldObj2 = ldObj;
					if (ldObj2.Target is LdFlda ldFlda2)
					{
						return ldFlda2.Field.ReturnType;
					}
				}
			}
			else
			{
				CallInstruction callInstruction2 = callInstruction;
				if (callInstruction2 is CallVirt || callInstruction2 is Call)
				{
					return callInstruction2.Method.ReturnType;
				}
			}
		}
		return null;
	}

	public override bool Equals(object obj)
	{
		if (obj is AccessPathElement)
		{
			return Equals((AccessPathElement)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 0;
		if (Member != null)
		{
			num += 1000000007 * Member.GetHashCode();
		}
		return num;
	}

	public bool Equals(AccessPathElement other)
	{
		return other.Member.Equals(Member) && (other.Indices == Indices || Enumerable.SequenceEqual<ILInstruction>((IEnumerable<ILInstruction>)other.Indices, (IEnumerable<ILInstruction>)Indices, (IEqualityComparer<ILInstruction>)ILInstructionMatchComparer.Instance));
	}

	public static bool operator ==(AccessPathElement lhs, AccessPathElement rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(AccessPathElement lhs, AccessPathElement rhs)
	{
		return !(lhs == rhs);
	}
}
