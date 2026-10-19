using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x200000F")]
	public static class ResourceServiceFactory
	{
		[Token(Token = "0x600003B")]
		[Address(RVA = "0x81D2218", Offset = "0x81D2218", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tSystem.Object::.ctor(v65);\n\tv69 = new Unco.ResourceSystem.ResourceService();\n\tUnco.ResourceSystem.ResourceService::.ctor(v69, v55, v65, config);\n\treturn v69;\nL_0024:\n\tv55 = new Unco.ResourceSystem.GameDataResourceRepository();\n\tUnco.ResourceSystem.GameDataResourceRepository::.ctor(v55, config, resourceData);\n\tv65 = new Unco.ResourceSystem.ResourceAnalytics();\n")]
		public static ResourceService Create(ResourceConfig config, ResourceStorageData resourceData)
		{
			GameDataResourceRepository repository = new GameDataResourceRepository(config, resourceData);
			ResourceAnalytics analytics = new ResourceAnalytics();
			return new ResourceService(repository, analytics, config);
		}
	}
}
