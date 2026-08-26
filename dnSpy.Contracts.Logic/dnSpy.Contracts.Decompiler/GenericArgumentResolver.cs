using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public struct GenericArgumentResolver
{
	private IList<TypeSig> typeGenArgs;

	private IList<TypeSig> methodGenArgs;

	private RecursionCounter recursionCounter;

	private GenericArgumentResolver(IList<TypeSig> typeGenArgs, IList<TypeSig> methodGenArgs)
	{
		this.typeGenArgs = typeGenArgs ?? Array.Empty<TypeSig>();
		this.methodGenArgs = methodGenArgs ?? Array.Empty<TypeSig>();
		recursionCounter = default(RecursionCounter);
	}

	public static TypeSig Resolve(TypeSig typeSig, IList<TypeSig> typeGenArgs, IList<TypeSig> methodGenArgs)
	{
		if (typeSig == null)
		{
			return typeSig;
		}
		if ((typeGenArgs == null || typeGenArgs.Count == 0) && (methodGenArgs == null || methodGenArgs.Count == 0))
		{
			return typeSig;
		}
		return new GenericArgumentResolver(typeGenArgs, methodGenArgs).ResolveGenericArgs(typeSig);
	}

	public static MethodBaseSig Resolve(MethodBaseSig methodSig, IList<TypeSig> typeGenArgs, IList<TypeSig> methodGenArgs)
	{
		if (methodSig == null)
		{
			return null;
		}
		if ((typeGenArgs == null || typeGenArgs.Count == 0) && (methodGenArgs == null || methodGenArgs.Count == 0))
		{
			return methodSig;
		}
		return new GenericArgumentResolver(typeGenArgs, methodGenArgs).ResolveGenericArgs(methodSig);
	}

	private bool ReplaceGenericArg(ref TypeSig typeSig)
	{
		if (typeSig is GenericMVar genericMVar)
		{
			TypeSig typeSig2 = Read(methodGenArgs, genericMVar.Number);
			if (typeSig2 != null)
			{
				typeSig = typeSig2;
				return true;
			}
			return false;
		}
		if (typeSig is GenericVar genericVar)
		{
			TypeSig typeSig3 = Read(typeGenArgs, genericVar.Number);
			if (typeSig3 != null)
			{
				typeSig = typeSig3;
				return true;
			}
			return false;
		}
		return false;
	}

	private static TypeSig Read(IList<TypeSig> sigs, uint index)
	{
		if (index < (uint)sigs.Count)
		{
			return sigs[(int)index];
		}
		return null;
	}

	private MethodSig ResolveGenericArgs(MethodBaseSig sig)
	{
		if (sig == null)
		{
			return null;
		}
		if (!recursionCounter.Increment())
		{
			return null;
		}
		MethodSig result = ResolveGenericArgs(new MethodSig(sig.CallingConvention), sig);
		recursionCounter.Decrement();
		return result;
	}

	private MethodSig ResolveGenericArgs(MethodSig sig, MethodBaseSig old)
	{
		sig.RetType = ResolveGenericArgs(old.RetType);
		foreach (TypeSig item in old.Params)
		{
			sig.Params.Add(ResolveGenericArgs(item));
		}
		sig.GenParamCount = old.GenParamCount;
		if (sig.ParamsAfterSentinel != null)
		{
			foreach (TypeSig item2 in old.ParamsAfterSentinel)
			{
				sig.ParamsAfterSentinel.Add(ResolveGenericArgs(item2));
			}
		}
		return sig;
	}

	private TypeSig ResolveGenericArgs(TypeSig typeSig)
	{
		if (typeSig == null)
		{
			return null;
		}
		if (!recursionCounter.Increment())
		{
			return null;
		}
		if (ReplaceGenericArg(ref typeSig))
		{
			recursionCounter.Decrement();
			return typeSig;
		}
		TypeSig result;
		switch (typeSig.ElementType)
		{
		case ElementType.Ptr:
			result = new PtrSig(ResolveGenericArgs(typeSig.Next));
			break;
		case ElementType.ByRef:
			result = new ByRefSig(ResolveGenericArgs(typeSig.Next));
			break;
		case ElementType.Var:
			result = new GenericVar((typeSig as GenericVar).Number, (typeSig as GenericVar).OwnerType);
			break;
		case ElementType.ValueArray:
			result = new ValueArraySig(ResolveGenericArgs(typeSig.Next), (typeSig as ValueArraySig).Size);
			break;
		case ElementType.SZArray:
			result = new SZArraySig(ResolveGenericArgs(typeSig.Next));
			break;
		case ElementType.MVar:
			result = new GenericMVar((typeSig as GenericMVar).Number, (typeSig as GenericMVar).OwnerMethod);
			break;
		case ElementType.CModReqd:
			result = new CModReqdSig((typeSig as ModifierSig).Modifier, ResolveGenericArgs(typeSig.Next));
			break;
		case ElementType.CModOpt:
			result = new CModOptSig((typeSig as ModifierSig).Modifier, ResolveGenericArgs(typeSig.Next));
			break;
		case ElementType.Module:
			result = new ModuleSig((typeSig as ModuleSig).Index, ResolveGenericArgs(typeSig.Next));
			break;
		case ElementType.Pinned:
			result = new PinnedSig(ResolveGenericArgs(typeSig.Next));
			break;
		case ElementType.FnPtr:
			result = new FnPtrSig(ResolveGenericArgs(((FnPtrSig)typeSig).MethodSig));
			break;
		case ElementType.Array:
		{
			ArraySig arraySig = (ArraySig)typeSig;
			List<uint> sizes = new List<uint>(arraySig.Sizes);
			List<int> lowerBounds = new List<int>(arraySig.LowerBounds);
			result = new ArraySig(ResolveGenericArgs(typeSig.Next), arraySig.Rank, sizes, lowerBounds);
			break;
		}
		case ElementType.GenericInst:
		{
			GenericInstSig genericInstSig = (GenericInstSig)typeSig;
			List<TypeSig> list = new List<TypeSig>(genericInstSig.GenericArguments.Count);
			foreach (TypeSig genericArgument in genericInstSig.GenericArguments)
			{
				list.Add(ResolveGenericArgs(genericArgument));
			}
			result = new GenericInstSig(ResolveGenericArgs(genericInstSig.GenericType) as ClassOrValueTypeSig, list);
			break;
		}
		default:
			result = typeSig;
			break;
		}
		recursionCounter.Decrement();
		return result;
	}

	private CallingConventionSig ResolveGenericArgs(CallingConventionSig sig)
	{
		if (!recursionCounter.Increment())
		{
			return null;
		}
		CallingConventionSig result = ((!(sig is MethodSig sig2)) ? ((!(sig is FieldSig sig3)) ? ((!(sig is LocalSig sig4)) ? ((!(sig is PropertySig sig5)) ? ((CallingConventionSig)((!(sig is GenericInstMethodSig sig6)) ? null : ResolveGenericArgs(sig6))) : ((CallingConventionSig)ResolveGenericArgs(sig5))) : ResolveGenericArgs(sig4)) : ResolveGenericArgs(sig3)) : ResolveGenericArgs(sig2));
		recursionCounter.Decrement();
		return result;
	}

	private MethodSig ResolveGenericArgs(MethodSig sig)
	{
		MethodSig methodSig = ResolveGenericArgs2(new MethodSig(), sig);
		methodSig.OriginalToken = sig.OriginalToken;
		return methodSig;
	}

	private PropertySig ResolveGenericArgs(PropertySig sig)
	{
		return ResolveGenericArgs2(new PropertySig(), sig);
	}

	private T ResolveGenericArgs2<T>(T outSig, T inSig) where T : MethodBaseSig
	{
		outSig.RetType = ResolveGenericArgs(inSig.RetType);
		outSig.GenParamCount = inSig.GenParamCount;
		UpdateSigList(outSig.Params, inSig.Params);
		if (inSig.ParamsAfterSentinel != null)
		{
			outSig.ParamsAfterSentinel = new List<TypeSig>(inSig.ParamsAfterSentinel.Count);
			UpdateSigList(outSig.ParamsAfterSentinel, inSig.ParamsAfterSentinel);
		}
		return outSig;
	}

	private void UpdateSigList(IList<TypeSig> inList, IList<TypeSig> outList)
	{
		foreach (TypeSig @out in outList)
		{
			inList.Add(ResolveGenericArgs(@out));
		}
	}

	private FieldSig ResolveGenericArgs(FieldSig sig)
	{
		return new FieldSig(ResolveGenericArgs(sig.Type));
	}

	private LocalSig ResolveGenericArgs(LocalSig sig)
	{
		LocalSig localSig = new LocalSig();
		UpdateSigList(localSig.Locals, sig.Locals);
		return localSig;
	}

	private GenericInstMethodSig ResolveGenericArgs(GenericInstMethodSig sig)
	{
		GenericInstMethodSig genericInstMethodSig = new GenericInstMethodSig();
		UpdateSigList(genericInstMethodSig.GenericArguments, sig.GenericArguments);
		return genericInstMethodSig;
	}
}
