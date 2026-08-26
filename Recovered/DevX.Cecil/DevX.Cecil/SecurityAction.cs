namespace DevX.Cecil
{
	public enum SecurityAction : short
	{
		Request = 1,
		Demand,
		Assert,
		Deny,
		PermitOnly,
		LinkDemand,
		InheritDemand,
		RequestMinimum,
		RequestOptional,
		RequestRefuse,
		PreJitGrant,
		PreJitDeny,
		NonCasDemand,
		NonCasLinkDemand,
		NonCasInheritance
	}
}
