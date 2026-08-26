using System;

namespace dnlib.DotNet;

[Flags]
public enum SigComparerOptions : uint
{
	DontCompareTypeScope = 1u,
	CompareMethodFieldDeclaringType = 2u,
	ComparePropertyDeclaringType = 4u,
	CompareEventDeclaringType = 8u,
	CompareDeclaringTypes = CompareMethodFieldDeclaringType | ComparePropertyDeclaringType | CompareEventDeclaringType,
	CompareSentinelParams = 0x10u,
	CompareAssemblyPublicKeyToken = 0x20u,
	CompareAssemblyVersion = 0x40u,
	CompareAssemblyLocale = 0x80u,
	TypeRefCanReferenceGlobalType = 0x100u,
	DontCompareReturnType = 0x200u,
	CaseInsensitiveTypeNamespaces = 0x800u,
	CaseInsensitiveTypeNames = 0x1000u,
	CaseInsensitiveTypes = CaseInsensitiveTypeNamespaces | CaseInsensitiveTypeNames,
	CaseInsensitiveMethodFieldNames = 0x2000u,
	CaseInsensitivePropertyNames = 0x4000u,
	CaseInsensitiveEventNames = 0x8000u,
	CaseInsensitiveAll = CaseInsensitiveTypes | CaseInsensitiveMethodFieldNames | CaseInsensitivePropertyNames | CaseInsensitiveEventNames,
	PrivateScopeFieldIsComparable = 0x10000u,
	PrivateScopeMethodIsComparable = 0x20000u,
	PrivateScopeIsComparable = PrivateScopeFieldIsComparable | PrivateScopeMethodIsComparable,
	RawSignatureCompare = 0x40000u,
	IgnoreModifiers = 0x80000u,
	MscorlibIsNotSpecial = 0x100000u,
	DontProjectWinMDRefs = 0x200000u,
	DontCheckTypeEquivalence = 0x400000u,
	IgnoreMultiDimensionalArrayLowerBoundsAndSizes = 0x800000u
}
