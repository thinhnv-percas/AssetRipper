using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class CustomAttrib
	{
		public struct FixedArg
		{
			public bool SzArray;

			public uint NumElem;

			public Elem[] Elems;

			internal static FixedArg[] Empty = new FixedArg[0];
		}

		public struct Elem
		{
			public bool Simple;

			public bool String;

			public bool Type;

			public bool BoxedValueType;

			public ElementType FieldOrPropType;

			public object Value;

			public TypeReference ElemType;
		}

		public struct NamedArg
		{
			public bool Field;

			public bool Property;

			public ElementType FieldOrPropType;

			public string FieldOrPropName;

			public FixedArg FixedArg;

			internal static NamedArg[] Empty = new NamedArg[0];
		}

		public const ushort StdProlog = 1;

		public MethodReference Constructor;

		public ushort Prolog;

		public FixedArg[] FixedArgs;

		public ushort NumNamed;

		public NamedArg[] NamedArgs;

		public bool Read;

		public CustomAttrib(MethodReference ctor)
		{
			Constructor = ctor;
		}
	}
}
