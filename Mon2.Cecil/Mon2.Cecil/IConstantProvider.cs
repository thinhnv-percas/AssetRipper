namespace Mon2.Cecil;

public interface IConstantProvider : IMetadataTokenProvider
{
	bool HasConstant { get; set; }

	object Constant { get; set; }
}
