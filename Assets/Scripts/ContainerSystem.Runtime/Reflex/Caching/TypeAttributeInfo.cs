using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Caching
{
	[Token(Token = "0x200003B")]
	internal sealed class TypeAttributeInfo
	{
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x10")]
		public readonly FieldInfo[] InjectableFields;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x18")]
		public readonly FieldInfo[] OptionalInjectableFields;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x20")]
		public readonly PropertyInfo[] InjectableProperties;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x28")]
		public readonly InjectableMethodInfo[] InjectableMethods;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x30")]
		public readonly InjectableMethodInfo[] OptionalInjectableMethods;

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x3F37D64", Offset = "0x3F37D64", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.InjectableFields = injectableFields;\n\tthis.OptionalInjectableFields = optionalInjectableFields;\n\tthis.InjectableProperties = injectableProperties;\n\tthis.InjectableMethods = injectableMethods;\n\tthis.OptionalInjectableMethods = optionalInjectableMethods;\n\treturn;\n")]
		public TypeAttributeInfo(FieldInfo[] injectableFields, FieldInfo[] optionalInjectableFields, PropertyInfo[] injectableProperties, InjectableMethodInfo[] injectableMethods, InjectableMethodInfo[] optionalInjectableMethods)
		{
			InjectableFields = injectableFields;
			OptionalInjectableFields = optionalInjectableFields;
			InjectableProperties = injectableProperties;
			InjectableMethods = injectableMethods;
			OptionalInjectableMethods = optionalInjectableMethods;
		}
	}
}
