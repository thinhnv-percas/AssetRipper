using System;

namespace Mon2.Cecil;

[Flags]
public enum ManifestResourceAttributes : uint
{
	VisibilityMask = 7u,
	Public = 1u,
	Private = 2u
}
