using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000034")]
	public interface AttachmentLoader
	{
		[Token(Token = "0x600016A")]
		RegionAttachment NewRegionAttachment(Skin skin, string name, string path);

		[Token(Token = "0x600016B")]
		MeshAttachment NewMeshAttachment(Skin skin, string name, string path);

		[Token(Token = "0x600016C")]
		BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name);

		[Token(Token = "0x600016D")]
		PathAttachment NewPathAttachment(Skin skin, string name);

		[Token(Token = "0x600016E")]
		PointAttachment NewPointAttachment(Skin skin, string name);

		[Token(Token = "0x600016F")]
		ClippingAttachment NewClippingAttachment(Skin skin, string name);
	}
}
