namespace dnlib.DotNet;

public enum SecurityAction : short
{
	ActionMask = 31,
	ActionNil = 0,
	Request = 1,
	Demand = 2,
	Assert = 3,
	Deny = 4,
	PermitOnly = 5,
	LinktimeCheck = 6,
	LinkDemand = LinktimeCheck,
	InheritanceCheck = 7,
	InheritDemand = InheritanceCheck,
	RequestMinimum = 8,
	RequestOptional = 9,
	RequestRefuse = 10,
	PrejitGrant = 11,
	PreJitGrant = PrejitGrant,
	PrejitDenied = 12,
	PreJitDeny = PrejitDenied,
	NonCasDemand = 13,
	NonCasLinkDemand = 14,
	NonCasInheritance = 15,
	MaximumValue = NonCasInheritance
}
