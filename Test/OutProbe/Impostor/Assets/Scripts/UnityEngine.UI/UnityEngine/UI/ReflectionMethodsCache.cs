using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200007A")]
	internal class ReflectionMethodsCache
	{
		[Token(Token = "0x200007B")]
		public delegate bool Raycast3DCallback(Ray r, out RaycastHit hit, float f, int i);

		[Token(Token = "0x200007C")]
		public delegate RaycastHit[] RaycastAllCallback(Ray r, float f, int i);

		[Token(Token = "0x200007D")]
		public delegate int GetRaycastNonAllocCallback(Ray r, RaycastHit[] results, float f, int i);

		[Token(Token = "0x200007E")]
		public delegate RaycastHit2D Raycast2DCallback(Vector2 p1, Vector2 p2, float f, int i);

		[Token(Token = "0x200007F")]
		public delegate RaycastHit2D[] GetRayIntersectionAllCallback(Ray r, float f, int i);

		[Token(Token = "0x2000080")]
		public delegate int GetRayIntersectionAllNonAllocCallback(Ray r, RaycastHit2D[] results, float f, int i);

		[Token(Token = "0x400025C")]
		[FieldOffset(Offset = "0x10")]
		public Raycast3DCallback raycast3D;

		[Token(Token = "0x400025D")]
		[FieldOffset(Offset = "0x18")]
		public RaycastAllCallback raycast3DAll;

		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x20")]
		public GetRaycastNonAllocCallback getRaycastNonAlloc;

		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x28")]
		public Raycast2DCallback raycast2D;

		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x30")]
		public GetRayIntersectionAllCallback getRayIntersectionAll;

		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x38")]
		public GetRayIntersectionAllNonAllocCallback getRayIntersectionAllNonAlloc;

		[Token(Token = "0x4000262")]
		private static ReflectionMethodsCache s_ReflectionMethodsCache;

		[Token(Token = "0x17000151")]
		public static ReflectionMethodsCache Singleton
		{
			[Token(Token = "0x60004FD")]
			[Address(RVA = "0x183C138", Offset = "0x183C138", Length = "0x74")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60004FC")]
		[Address(RVA = "0x183B524", Offset = "0x183B524", Length = "0xC14")]
		public ReflectionMethodsCache()
		{
		}
	}
}
