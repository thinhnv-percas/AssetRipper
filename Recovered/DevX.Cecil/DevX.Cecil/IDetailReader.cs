namespace DevX.Cecil
{
	internal interface IDetailReader
	{
		void ReadSemantic(EventDefinition evt);

		void ReadSemantic(PropertyDefinition prop);

		void ReadMarshalSpec(ParameterDefinition param);

		void ReadMarshalSpec(FieldDefinition field);

		void ReadLayout(TypeDefinition type);

		void ReadLayout(FieldDefinition field);

		void ReadConstant(FieldDefinition field);

		void ReadConstant(PropertyDefinition prop);

		void ReadConstant(ParameterDefinition param);

		void ReadInitialValue(FieldDefinition field);
	}
}
