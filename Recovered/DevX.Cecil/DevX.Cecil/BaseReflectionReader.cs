namespace DevX.Cecil
{
	internal abstract class BaseReflectionReader : BaseReflectionVisitor, IDetailReader
	{
		public virtual void ReadSemantic(EventDefinition evt)
		{
		}

		public virtual void ReadSemantic(PropertyDefinition prop)
		{
		}

		public virtual void ReadMarshalSpec(ParameterDefinition param)
		{
		}

		public virtual void ReadMarshalSpec(FieldDefinition field)
		{
		}

		public virtual void ReadLayout(TypeDefinition type)
		{
		}

		public virtual void ReadLayout(FieldDefinition field)
		{
		}

		public virtual void ReadConstant(FieldDefinition field)
		{
		}

		public virtual void ReadConstant(PropertyDefinition prop)
		{
		}

		public virtual void ReadConstant(ParameterDefinition param)
		{
		}

		public virtual void ReadInitialValue(FieldDefinition field)
		{
		}
	}
}
