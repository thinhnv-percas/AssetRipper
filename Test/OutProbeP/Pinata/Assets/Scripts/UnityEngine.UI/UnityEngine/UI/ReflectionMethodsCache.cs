using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200003D")]
	internal class ReflectionMethodsCache
	{
		[Token(Token = "0x20000AE")]
		public delegate bool Raycast3DCallback(Ray r, out RaycastHit hit, float f, int i);

		[Token(Token = "0x20000AF")]
		public delegate RaycastHit2D Raycast2DCallback(Vector2 p1, Vector2 p2, float f, int i);

		[Token(Token = "0x20000B0")]
		public delegate RaycastHit[] RaycastAllCallback(Ray r, float f, int i);

		[Token(Token = "0x20000B1")]
		public delegate RaycastHit2D[] GetRayIntersectionAllCallback(Ray r, float f, int i);

		[Token(Token = "0x20000B2")]
		public delegate int GetRayIntersectionAllNonAllocCallback(Ray r, RaycastHit2D[] results, float f, int i);

		[Token(Token = "0x20000B3")]
		public delegate int GetRaycastNonAllocCallback(Ray r, RaycastHit[] results, float f, int i);

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x10")]
		public Raycast3DCallback raycast3D;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x18")]
		public RaycastAllCallback raycast3DAll;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x20")]
		public Raycast2DCallback raycast2D;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x28")]
		public GetRayIntersectionAllCallback getRayIntersectionAll;

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x30")]
		public GetRayIntersectionAllNonAllocCallback getRayIntersectionAllNonAlloc;

		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x38")]
		public GetRaycastNonAllocCallback getRaycastNonAlloc;

		[Token(Token = "0x4000175")]
		private static ReflectionMethodsCache s_ReflectionMethodsCache;

		[Token(Token = "0x1700013A")]
		public static ReflectionMethodsCache Singleton
		{
			[Token(Token = "0x6000469")]
			[Address(RVA = "0xECD834", Offset = "0xECD834", Length = "0xC0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000468")]
		[Address(RVA = "0xECCD3C", Offset = "0xECCD3C", Length = "0xAF8")]
		public ReflectionMethodsCache()
		{
		}
	}
}
