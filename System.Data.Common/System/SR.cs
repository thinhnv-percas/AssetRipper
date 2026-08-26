using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.Data.Common;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	private const string s_resourcesName = "FxResources.System.Data.Common.SR";

	private static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(ResourceType));

	internal static string ADP_CollectionIndexString => GetResourceString("ADP_CollectionIndexString", null);

	internal static string ADP_CollectionInvalidType => GetResourceString("ADP_CollectionInvalidType", null);

	internal static string ADP_CollectionIsNotParent => GetResourceString("ADP_CollectionIsNotParent", null);

	internal static string ADP_CollectionNullValue => GetResourceString("ADP_CollectionNullValue", null);

	internal static string ADP_CollectionRemoveInvalidObject => GetResourceString("ADP_CollectionRemoveInvalidObject", null);

	internal static string ADP_CollectionUniqueValue => GetResourceString("ADP_CollectionUniqueValue", null);

	internal static string ADP_ConnectionStateMsg_Closed => GetResourceString("ADP_ConnectionStateMsg_Closed", null);

	internal static string ADP_ConnectionStateMsg_Connecting => GetResourceString("ADP_ConnectionStateMsg_Connecting", null);

	internal static string ADP_ConnectionStateMsg_Open => GetResourceString("ADP_ConnectionStateMsg_Open", null);

	internal static string ADP_ConnectionStateMsg_OpenExecuting => GetResourceString("ADP_ConnectionStateMsg_OpenExecuting", null);

	internal static string ADP_ConnectionStateMsg_OpenFetching => GetResourceString("ADP_ConnectionStateMsg_OpenFetching", null);

	internal static string ADP_ConnectionStateMsg => GetResourceString("ADP_ConnectionStateMsg", null);

	internal static string ADP_ConnectionStringSyntax => GetResourceString("ADP_ConnectionStringSyntax", null);

	internal static string ADP_DataReaderClosed => GetResourceString("ADP_DataReaderClosed", null);

	internal static string ADP_EmptyString => GetResourceString("ADP_EmptyString", null);

	internal static string ADP_InvalidEnumerationValue => GetResourceString("ADP_InvalidEnumerationValue", null);

	internal static string ADP_InvalidKey => GetResourceString("ADP_InvalidKey", null);

	internal static string ADP_InvalidValue => GetResourceString("ADP_InvalidValue", null);

	internal static string Xml_SimpleTypeNotSupported => GetResourceString("Xml_SimpleTypeNotSupported", null);

	internal static string Xml_MissingAttribute => GetResourceString("Xml_MissingAttribute", null);

	internal static string Xml_ValueOutOfRange => GetResourceString("Xml_ValueOutOfRange", null);

	internal static string Xml_AttributeValues => GetResourceString("Xml_AttributeValues", null);

	internal static string Xml_RelationParentNameMissing => GetResourceString("Xml_RelationParentNameMissing", null);

	internal static string Xml_RelationChildNameMissing => GetResourceString("Xml_RelationChildNameMissing", null);

	internal static string Xml_RelationTableKeyMissing => GetResourceString("Xml_RelationTableKeyMissing", null);

	internal static string Xml_RelationChildKeyMissing => GetResourceString("Xml_RelationChildKeyMissing", null);

	internal static string Xml_UndefinedDatatype => GetResourceString("Xml_UndefinedDatatype", null);

	internal static string Xml_DatatypeNotDefined => GetResourceString("Xml_DatatypeNotDefined", null);

	internal static string Xml_InvalidField => GetResourceString("Xml_InvalidField", null);

	internal static string Xml_InvalidSelector => GetResourceString("Xml_InvalidSelector", null);

	internal static string Xml_InvalidKey => GetResourceString("Xml_InvalidKey", null);

	internal static string Xml_DuplicateConstraint => GetResourceString("Xml_DuplicateConstraint", null);

	internal static string Xml_CannotConvert => GetResourceString("Xml_CannotConvert", null);

	internal static string Xml_MissingRefer => GetResourceString("Xml_MissingRefer", null);

	internal static string Xml_MismatchKeyLength => GetResourceString("Xml_MismatchKeyLength", null);

	internal static string Xml_CircularComplexType => GetResourceString("Xml_CircularComplexType", null);

	internal static string Xml_CannotInstantiateAbstract => GetResourceString("Xml_CannotInstantiateAbstract", null);

	internal static string Xml_MultipleTargetConverterError => GetResourceString("Xml_MultipleTargetConverterError", null);

	internal static string Xml_MultipleTargetConverterEmpty => GetResourceString("Xml_MultipleTargetConverterEmpty", null);

	internal static string Xml_MergeDuplicateDeclaration => GetResourceString("Xml_MergeDuplicateDeclaration", null);

	internal static string Xml_MissingTable => GetResourceString("Xml_MissingTable", null);

	internal static string Xml_MissingSQL => GetResourceString("Xml_MissingSQL", null);

	internal static string Xml_ColumnConflict => GetResourceString("Xml_ColumnConflict", null);

	internal static string Xml_InvalidPrefix => GetResourceString("Xml_InvalidPrefix", null);

	internal static string Xml_NestedCircular => GetResourceString("Xml_NestedCircular", null);

	internal static string Xml_FoundEntity => GetResourceString("Xml_FoundEntity", null);

	internal static string Xml_PolymorphismNotSupported => GetResourceString("Xml_PolymorphismNotSupported", null);

	internal static string Xml_CanNotDeserializeObjectType => GetResourceString("Xml_CanNotDeserializeObjectType", null);

	internal static string Xml_DataTableInferenceNotSupported => GetResourceString("Xml_DataTableInferenceNotSupported", null);

	internal static string Xml_MultipleParentRows => GetResourceString("Xml_MultipleParentRows", null);

	internal static string Xml_IsDataSetAttributeMissingInSchema => GetResourceString("Xml_IsDataSetAttributeMissingInSchema", null);

	internal static string Xml_TooManyIsDataSetAtributeInSchema => GetResourceString("Xml_TooManyIsDataSetAtributeInSchema", null);

	internal static string Xml_DynamicWithoutXmlSerializable => GetResourceString("Xml_DynamicWithoutXmlSerializable", null);

	internal static string Expr_NYI => GetResourceString("Expr_NYI", null);

	internal static string Expr_MissingOperand => GetResourceString("Expr_MissingOperand", null);

	internal static string Expr_TypeMismatch => GetResourceString("Expr_TypeMismatch", null);

	internal static string Expr_ExpressionTooComplex => GetResourceString("Expr_ExpressionTooComplex", null);

	internal static string Expr_UnboundName => GetResourceString("Expr_UnboundName", null);

	internal static string Expr_InvalidString => GetResourceString("Expr_InvalidString", null);

	internal static string Expr_UndefinedFunction => GetResourceString("Expr_UndefinedFunction", null);

	internal static string Expr_Syntax => GetResourceString("Expr_Syntax", null);

	internal static string Expr_FunctionArgumentCount => GetResourceString("Expr_FunctionArgumentCount", null);

	internal static string Expr_MissingRightParen => GetResourceString("Expr_MissingRightParen", null);

	internal static string Expr_UnknownToken => GetResourceString("Expr_UnknownToken", null);

	internal static string Expr_UnknownToken1 => GetResourceString("Expr_UnknownToken1", null);

	internal static string Expr_DatatypeConvertion => GetResourceString("Expr_DatatypeConvertion", null);

	internal static string Expr_DatavalueConvertion => GetResourceString("Expr_DatavalueConvertion", null);

	internal static string Expr_InvalidName => GetResourceString("Expr_InvalidName", null);

	internal static string Expr_InvalidDate => GetResourceString("Expr_InvalidDate", null);

	internal static string Expr_NonConstantArgument => GetResourceString("Expr_NonConstantArgument", null);

	internal static string Expr_InvalidPattern => GetResourceString("Expr_InvalidPattern", null);

	internal static string Expr_InWithoutParentheses => GetResourceString("Expr_InWithoutParentheses", null);

	internal static string Expr_ArgumentType => GetResourceString("Expr_ArgumentType", null);

	internal static string Expr_ArgumentTypeInteger => GetResourceString("Expr_ArgumentTypeInteger", null);

	internal static string Expr_TypeMismatchInBinop => GetResourceString("Expr_TypeMismatchInBinop", null);

	internal static string Expr_AmbiguousBinop => GetResourceString("Expr_AmbiguousBinop", null);

	internal static string Expr_InWithoutList => GetResourceString("Expr_InWithoutList", null);

	internal static string Expr_UnsupportedOperator => GetResourceString("Expr_UnsupportedOperator", null);

	internal static string Expr_InvalidNameBracketing => GetResourceString("Expr_InvalidNameBracketing", null);

	internal static string Expr_MissingOperandBefore => GetResourceString("Expr_MissingOperandBefore", null);

	internal static string Expr_TooManyRightParentheses => GetResourceString("Expr_TooManyRightParentheses", null);

	internal static string Expr_UnresolvedRelation => GetResourceString("Expr_UnresolvedRelation", null);

	internal static string Expr_AggregateArgument => GetResourceString("Expr_AggregateArgument", null);

	internal static string Expr_AggregateUnbound => GetResourceString("Expr_AggregateUnbound", null);

	internal static string Expr_EvalNoContext => GetResourceString("Expr_EvalNoContext", null);

	internal static string Expr_ExpressionUnbound => GetResourceString("Expr_ExpressionUnbound", null);

	internal static string Expr_ComputeNotAggregate => GetResourceString("Expr_ComputeNotAggregate", null);

	internal static string Expr_FilterConvertion => GetResourceString("Expr_FilterConvertion", null);

	internal static string Expr_InvalidType => GetResourceString("Expr_InvalidType", null);

	internal static string Expr_LookupArgument => GetResourceString("Expr_LookupArgument", null);

	internal static string Expr_InvokeArgument => GetResourceString("Expr_InvokeArgument", null);

	internal static string Expr_ArgumentOutofRange => GetResourceString("Expr_ArgumentOutofRange", null);

	internal static string Expr_IsSyntax => GetResourceString("Expr_IsSyntax", null);

	internal static string Expr_Overflow => GetResourceString("Expr_Overflow", null);

	internal static string Expr_BindFailure => GetResourceString("Expr_BindFailure", null);

	internal static string Expr_InvalidHoursArgument => GetResourceString("Expr_InvalidHoursArgument", null);

	internal static string Expr_InvalidMinutesArgument => GetResourceString("Expr_InvalidMinutesArgument", null);

	internal static string Expr_InvalidTimeZoneRange => GetResourceString("Expr_InvalidTimeZoneRange", null);

	internal static string Expr_MismatchKindandTimeSpan => GetResourceString("Expr_MismatchKindandTimeSpan", null);

	internal static string Expr_UnsupportedType => GetResourceString("Expr_UnsupportedType", null);

	internal static string Data_EnforceConstraints => GetResourceString("Data_EnforceConstraints", null);

	internal static string Data_CannotModifyCollection => GetResourceString("Data_CannotModifyCollection", null);

	internal static string Data_CaseInsensitiveNameConflict => GetResourceString("Data_CaseInsensitiveNameConflict", null);

	internal static string Data_NamespaceNameConflict => GetResourceString("Data_NamespaceNameConflict", null);

	internal static string Data_InvalidOffsetLength => GetResourceString("Data_InvalidOffsetLength", null);

	internal static string Data_ArgumentOutOfRange => GetResourceString("Data_ArgumentOutOfRange", null);

	internal static string Data_ArgumentNull => GetResourceString("Data_ArgumentNull", null);

	internal static string Data_ArgumentContainsNull => GetResourceString("Data_ArgumentContainsNull", null);

	internal static string DataColumns_OutOfRange => GetResourceString("DataColumns_OutOfRange", null);

	internal static string DataColumns_Add1 => GetResourceString("DataColumns_Add1", null);

	internal static string DataColumns_Add2 => GetResourceString("DataColumns_Add2", null);

	internal static string DataColumns_Add3 => GetResourceString("DataColumns_Add3", null);

	internal static string DataColumns_Add4 => GetResourceString("DataColumns_Add4", null);

	internal static string DataColumns_AddDuplicate => GetResourceString("DataColumns_AddDuplicate", null);

	internal static string DataColumns_AddDuplicate2 => GetResourceString("DataColumns_AddDuplicate2", null);

	internal static string DataColumns_AddDuplicate3 => GetResourceString("DataColumns_AddDuplicate3", null);

	internal static string DataColumns_Remove => GetResourceString("DataColumns_Remove", null);

	internal static string DataColumns_RemovePrimaryKey => GetResourceString("DataColumns_RemovePrimaryKey", null);

	internal static string DataColumns_RemoveChildKey => GetResourceString("DataColumns_RemoveChildKey", null);

	internal static string DataColumns_RemoveConstraint => GetResourceString("DataColumns_RemoveConstraint", null);

	internal static string DataColumn_AutoIncrementAndExpression => GetResourceString("DataColumn_AutoIncrementAndExpression", null);

	internal static string DataColumn_AutoIncrementAndDefaultValue => GetResourceString("DataColumn_AutoIncrementAndDefaultValue", null);

	internal static string DataColumn_DefaultValueAndAutoIncrement => GetResourceString("DataColumn_DefaultValueAndAutoIncrement", null);

	internal static string DataColumn_AutoIncrementSeed => GetResourceString("DataColumn_AutoIncrementSeed", null);

	internal static string DataColumn_NameRequired => GetResourceString("DataColumn_NameRequired", null);

	internal static string DataColumn_ChangeDataType => GetResourceString("DataColumn_ChangeDataType", null);

	internal static string DataColumn_NullDataType => GetResourceString("DataColumn_NullDataType", null);

	internal static string DataColumn_DefaultValueDataType => GetResourceString("DataColumn_DefaultValueDataType", null);

	internal static string DataColumn_DefaultValueDataType1 => GetResourceString("DataColumn_DefaultValueDataType1", null);

	internal static string DataColumn_DefaultValueColumnDataType => GetResourceString("DataColumn_DefaultValueColumnDataType", null);

	internal static string DataColumn_ReadOnlyAndExpression => GetResourceString("DataColumn_ReadOnlyAndExpression", null);

	internal static string DataColumn_UniqueAndExpression => GetResourceString("DataColumn_UniqueAndExpression", null);

	internal static string DataColumn_ExpressionAndUnique => GetResourceString("DataColumn_ExpressionAndUnique", null);

	internal static string DataColumn_ExpressionAndReadOnly => GetResourceString("DataColumn_ExpressionAndReadOnly", null);

	internal static string DataColumn_ExpressionAndConstraint => GetResourceString("DataColumn_ExpressionAndConstraint", null);

	internal static string DataColumn_ExpressionInConstraint => GetResourceString("DataColumn_ExpressionInConstraint", null);

	internal static string DataColumn_ExpressionCircular => GetResourceString("DataColumn_ExpressionCircular", null);

	internal static string DataColumn_NullKeyValues => GetResourceString("DataColumn_NullKeyValues", null);

	internal static string DataColumn_NullValues => GetResourceString("DataColumn_NullValues", null);

	internal static string DataColumn_ReadOnly => GetResourceString("DataColumn_ReadOnly", null);

	internal static string DataColumn_NonUniqueValues => GetResourceString("DataColumn_NonUniqueValues", null);

	internal static string DataColumn_NotInTheTable => GetResourceString("DataColumn_NotInTheTable", null);

	internal static string DataColumn_NotInAnyTable => GetResourceString("DataColumn_NotInAnyTable", null);

	internal static string DataColumn_SetFailed => GetResourceString("DataColumn_SetFailed", null);

	internal static string DataColumn_CannotSetToNull => GetResourceString("DataColumn_CannotSetToNull", null);

	internal static string DataColumn_LongerThanMaxLength => GetResourceString("DataColumn_LongerThanMaxLength", null);

	internal static string DataColumn_HasToBeStringType => GetResourceString("DataColumn_HasToBeStringType", null);

	internal static string DataColumn_CannotSetMaxLength => GetResourceString("DataColumn_CannotSetMaxLength", null);

	internal static string DataColumn_CannotSetMaxLength2 => GetResourceString("DataColumn_CannotSetMaxLength2", null);

	internal static string DataColumn_CannotSimpleContentType => GetResourceString("DataColumn_CannotSimpleContentType", null);

	internal static string DataColumn_CannotSimpleContent => GetResourceString("DataColumn_CannotSimpleContent", null);

	internal static string DataColumn_ExceedMaxLength => GetResourceString("DataColumn_ExceedMaxLength", null);

	internal static string DataColumn_NotAllowDBNull => GetResourceString("DataColumn_NotAllowDBNull", null);

	internal static string DataColumn_CannotChangeNamespace => GetResourceString("DataColumn_CannotChangeNamespace", null);

	internal static string DataColumn_AutoIncrementCannotSetIfHasData => GetResourceString("DataColumn_AutoIncrementCannotSetIfHasData", null);

	internal static string DataColumn_NotInTheUnderlyingTable => GetResourceString("DataColumn_NotInTheUnderlyingTable", null);

	internal static string DataColumn_InvalidDataColumnMapping => GetResourceString("DataColumn_InvalidDataColumnMapping", null);

	internal static string DataColumn_CannotSetDateTimeModeForNonDateTimeColumns => GetResourceString("DataColumn_CannotSetDateTimeModeForNonDateTimeColumns", null);

	internal static string DataColumn_DateTimeMode => GetResourceString("DataColumn_DateTimeMode", null);

	internal static string DataColumn_INullableUDTwithoutStaticNull => GetResourceString("DataColumn_INullableUDTwithoutStaticNull", null);

	internal static string DataColumn_UDTImplementsIChangeTrackingButnotIRevertible => GetResourceString("DataColumn_UDTImplementsIChangeTrackingButnotIRevertible", null);

	internal static string DataColumn_SetAddedAndModifiedCalledOnNonUnchanged => GetResourceString("DataColumn_SetAddedAndModifiedCalledOnNonUnchanged", null);

	internal static string DataColumn_OrdinalExceedMaximun => GetResourceString("DataColumn_OrdinalExceedMaximun", null);

	internal static string DataColumn_NullableTypesNotSupported => GetResourceString("DataColumn_NullableTypesNotSupported", null);

	internal static string DataConstraint_NoName => GetResourceString("DataConstraint_NoName", null);

	internal static string DataConstraint_Violation => GetResourceString("DataConstraint_Violation", null);

	internal static string DataConstraint_ViolationValue => GetResourceString("DataConstraint_ViolationValue", null);

	internal static string DataConstraint_NotInTheTable => GetResourceString("DataConstraint_NotInTheTable", null);

	internal static string DataConstraint_OutOfRange => GetResourceString("DataConstraint_OutOfRange", null);

	internal static string DataConstraint_Duplicate => GetResourceString("DataConstraint_Duplicate", null);

	internal static string DataConstraint_DuplicateName => GetResourceString("DataConstraint_DuplicateName", null);

	internal static string DataConstraint_UniqueViolation => GetResourceString("DataConstraint_UniqueViolation", null);

	internal static string DataConstraint_ForeignTable => GetResourceString("DataConstraint_ForeignTable", null);

	internal static string DataConstraint_ParentValues => GetResourceString("DataConstraint_ParentValues", null);

	internal static string DataConstraint_AddFailed => GetResourceString("DataConstraint_AddFailed", null);

	internal static string DataConstraint_RemoveFailed => GetResourceString("DataConstraint_RemoveFailed", null);

	internal static string DataConstraint_NeededForForeignKeyConstraint => GetResourceString("DataConstraint_NeededForForeignKeyConstraint", null);

	internal static string DataConstraint_CascadeDelete => GetResourceString("DataConstraint_CascadeDelete", null);

	internal static string DataConstraint_CascadeUpdate => GetResourceString("DataConstraint_CascadeUpdate", null);

	internal static string DataConstraint_ClearParentTable => GetResourceString("DataConstraint_ClearParentTable", null);

	internal static string DataConstraint_ForeignKeyViolation => GetResourceString("DataConstraint_ForeignKeyViolation", null);

	internal static string DataConstraint_BadObjectPropertyAccess => GetResourceString("DataConstraint_BadObjectPropertyAccess", null);

	internal static string DataConstraint_RemoveParentRow => GetResourceString("DataConstraint_RemoveParentRow", null);

	internal static string DataConstraint_AddPrimaryKeyConstraint => GetResourceString("DataConstraint_AddPrimaryKeyConstraint", null);

	internal static string DataConstraint_CantAddConstraintToMultipleNestedTable => GetResourceString("DataConstraint_CantAddConstraintToMultipleNestedTable", null);

	internal static string DataKey_TableMismatch => GetResourceString("DataKey_TableMismatch", null);

	internal static string DataKey_NoColumns => GetResourceString("DataKey_NoColumns", null);

	internal static string DataKey_TooManyColumns => GetResourceString("DataKey_TooManyColumns", null);

	internal static string DataKey_DuplicateColumns => GetResourceString("DataKey_DuplicateColumns", null);

	internal static string DataKey_RemovePrimaryKey => GetResourceString("DataKey_RemovePrimaryKey", null);

	internal static string DataKey_RemovePrimaryKey1 => GetResourceString("DataKey_RemovePrimaryKey1", null);

	internal static string DataRelation_ColumnsTypeMismatch => GetResourceString("DataRelation_ColumnsTypeMismatch", null);

	internal static string DataRelation_KeyColumnsIdentical => GetResourceString("DataRelation_KeyColumnsIdentical", null);

	internal static string DataRelation_KeyLengthMismatch => GetResourceString("DataRelation_KeyLengthMismatch", null);

	internal static string DataRelation_KeyZeroLength => GetResourceString("DataRelation_KeyZeroLength", null);

	internal static string DataRelation_ForeignRow => GetResourceString("DataRelation_ForeignRow", null);

	internal static string DataRelation_NoName => GetResourceString("DataRelation_NoName", null);

	internal static string DataRelation_ForeignTable => GetResourceString("DataRelation_ForeignTable", null);

	internal static string DataRelation_ForeignDataSet => GetResourceString("DataRelation_ForeignDataSet", null);

	internal static string DataRelation_GetParentRowTableMismatch => GetResourceString("DataRelation_GetParentRowTableMismatch", null);

	internal static string DataRelation_SetParentRowTableMismatch => GetResourceString("DataRelation_SetParentRowTableMismatch", null);

	internal static string DataRelation_DataSetMismatch => GetResourceString("DataRelation_DataSetMismatch", null);

	internal static string DataRelation_TablesInDifferentSets => GetResourceString("DataRelation_TablesInDifferentSets", null);

	internal static string DataRelation_AlreadyExists => GetResourceString("DataRelation_AlreadyExists", null);

	internal static string DataRelation_DoesNotExist => GetResourceString("DataRelation_DoesNotExist", null);

	internal static string DataRelation_AlreadyInOtherDataSet => GetResourceString("DataRelation_AlreadyInOtherDataSet", null);

	internal static string DataRelation_AlreadyInTheDataSet => GetResourceString("DataRelation_AlreadyInTheDataSet", null);

	internal static string DataRelation_DuplicateName => GetResourceString("DataRelation_DuplicateName", null);

	internal static string DataRelation_NotInTheDataSet => GetResourceString("DataRelation_NotInTheDataSet", null);

	internal static string DataRelation_OutOfRange => GetResourceString("DataRelation_OutOfRange", null);

	internal static string DataRelation_TableNull => GetResourceString("DataRelation_TableNull", null);

	internal static string DataRelation_TableWasRemoved => GetResourceString("DataRelation_TableWasRemoved", null);

	internal static string DataRelation_ChildTableMismatch => GetResourceString("DataRelation_ChildTableMismatch", null);

	internal static string DataRelation_ParentTableMismatch => GetResourceString("DataRelation_ParentTableMismatch", null);

	internal static string DataRelation_RelationNestedReadOnly => GetResourceString("DataRelation_RelationNestedReadOnly", null);

	internal static string DataRelation_TableCantBeNestedInTwoTables => GetResourceString("DataRelation_TableCantBeNestedInTwoTables", null);

	internal static string DataRelation_LoopInNestedRelations => GetResourceString("DataRelation_LoopInNestedRelations", null);

	internal static string DataRelation_CaseLocaleMismatch => GetResourceString("DataRelation_CaseLocaleMismatch", null);

	internal static string DataRelation_ParentOrChildColumnsDoNotHaveDataSet => GetResourceString("DataRelation_ParentOrChildColumnsDoNotHaveDataSet", null);

	internal static string DataRelation_InValidNestedRelation => GetResourceString("DataRelation_InValidNestedRelation", null);

	internal static string DataRelation_InValidNamespaceInNestedRelation => GetResourceString("DataRelation_InValidNamespaceInNestedRelation", null);

	internal static string DataRow_NotInTheDataSet => GetResourceString("DataRow_NotInTheDataSet", null);

	internal static string DataRow_NotInTheTable => GetResourceString("DataRow_NotInTheTable", null);

	internal static string DataRow_ParentRowNotInTheDataSet => GetResourceString("DataRow_ParentRowNotInTheDataSet", null);

	internal static string DataRow_EditInRowChanging => GetResourceString("DataRow_EditInRowChanging", null);

	internal static string DataRow_EndEditInRowChanging => GetResourceString("DataRow_EndEditInRowChanging", null);

	internal static string DataRow_BeginEditInRowChanging => GetResourceString("DataRow_BeginEditInRowChanging", null);

	internal static string DataRow_CancelEditInRowChanging => GetResourceString("DataRow_CancelEditInRowChanging", null);

	internal static string DataRow_DeleteInRowDeleting => GetResourceString("DataRow_DeleteInRowDeleting", null);

	internal static string DataRow_ValuesArrayLength => GetResourceString("DataRow_ValuesArrayLength", null);

	internal static string DataRow_NoCurrentData => GetResourceString("DataRow_NoCurrentData", null);

	internal static string DataRow_NoOriginalData => GetResourceString("DataRow_NoOriginalData", null);

	internal static string DataRow_NoProposedData => GetResourceString("DataRow_NoProposedData", null);

	internal static string DataRow_RemovedFromTheTable => GetResourceString("DataRow_RemovedFromTheTable", null);

	internal static string DataRow_DeletedRowInaccessible => GetResourceString("DataRow_DeletedRowInaccessible", null);

	internal static string DataRow_InvalidVersion => GetResourceString("DataRow_InvalidVersion", null);

	internal static string DataRow_OutOfRange => GetResourceString("DataRow_OutOfRange", null);

	internal static string DataRow_RowInsertOutOfRange => GetResourceString("DataRow_RowInsertOutOfRange", null);

	internal static string DataRow_RowInsertMissing => GetResourceString("DataRow_RowInsertMissing", null);

	internal static string DataRow_RowOutOfRange => GetResourceString("DataRow_RowOutOfRange", null);

	internal static string DataRow_AlreadyInOtherCollection => GetResourceString("DataRow_AlreadyInOtherCollection", null);

	internal static string DataRow_AlreadyInTheCollection => GetResourceString("DataRow_AlreadyInTheCollection", null);

	internal static string DataRow_AlreadyDeleted => GetResourceString("DataRow_AlreadyDeleted", null);

	internal static string DataRow_Empty => GetResourceString("DataRow_Empty", null);

	internal static string DataRow_AlreadyRemoved => GetResourceString("DataRow_AlreadyRemoved", null);

	internal static string DataRow_MultipleParents => GetResourceString("DataRow_MultipleParents", null);

	internal static string DataRow_InvalidRowBitPattern => GetResourceString("DataRow_InvalidRowBitPattern", null);

	internal static string DataSet_SetNameToEmpty => GetResourceString("DataSet_SetNameToEmpty", null);

	internal static string DataSet_SetDataSetNameConflicting => GetResourceString("DataSet_SetDataSetNameConflicting", null);

	internal static string DataSet_UnsupportedSchema => GetResourceString("DataSet_UnsupportedSchema", null);

	internal static string DataSet_CannotChangeCaseLocale => GetResourceString("DataSet_CannotChangeCaseLocale", null);

	internal static string DataSet_CannotChangeSchemaSerializationMode => GetResourceString("DataSet_CannotChangeSchemaSerializationMode", null);

	internal static string DataTable_ForeignPrimaryKey => GetResourceString("DataTable_ForeignPrimaryKey", null);

	internal static string DataTable_CannotAddToSimpleContent => GetResourceString("DataTable_CannotAddToSimpleContent", null);

	internal static string DataTable_NoName => GetResourceString("DataTable_NoName", null);

	internal static string DataTable_MultipleSimpleContentColumns => GetResourceString("DataTable_MultipleSimpleContentColumns", null);

	internal static string DataTable_MissingPrimaryKey => GetResourceString("DataTable_MissingPrimaryKey", null);

	internal static string DataTable_InvalidSortString => GetResourceString("DataTable_InvalidSortString", null);

	internal static string DataTable_CanNotSerializeDataTableHierarchy => GetResourceString("DataTable_CanNotSerializeDataTableHierarchy", null);

	internal static string DataTable_CanNotRemoteDataTable => GetResourceString("DataTable_CanNotRemoteDataTable", null);

	internal static string DataTable_CanNotSetRemotingFormat => GetResourceString("DataTable_CanNotSetRemotingFormat", null);

	internal static string DataTable_CanNotSerializeDataTableWithEmptyName => GetResourceString("DataTable_CanNotSerializeDataTableWithEmptyName", null);

	internal static string DataTable_DuplicateName => GetResourceString("DataTable_DuplicateName", null);

	internal static string DataTable_DuplicateName2 => GetResourceString("DataTable_DuplicateName2", null);

	internal static string DataTable_SelfnestedDatasetConflictingName => GetResourceString("DataTable_SelfnestedDatasetConflictingName", null);

	internal static string DataTable_DatasetConflictingName => GetResourceString("DataTable_DatasetConflictingName", null);

	internal static string DataTable_AlreadyInOtherDataSet => GetResourceString("DataTable_AlreadyInOtherDataSet", null);

	internal static string DataTable_AlreadyInTheDataSet => GetResourceString("DataTable_AlreadyInTheDataSet", null);

	internal static string DataTable_NotInTheDataSet => GetResourceString("DataTable_NotInTheDataSet", null);

	internal static string DataTable_OutOfRange => GetResourceString("DataTable_OutOfRange", null);

	internal static string DataTable_InRelation => GetResourceString("DataTable_InRelation", null);

	internal static string DataTable_InConstraint => GetResourceString("DataTable_InConstraint", null);

	internal static string DataTable_TableNotFound => GetResourceString("DataTable_TableNotFound", null);

	internal static string DataMerge_MissingDefinition => GetResourceString("DataMerge_MissingDefinition", null);

	internal static string DataMerge_MissingConstraint => GetResourceString("DataMerge_MissingConstraint", null);

	internal static string DataMerge_DataTypeMismatch => GetResourceString("DataMerge_DataTypeMismatch", null);

	internal static string DataMerge_PrimaryKeyMismatch => GetResourceString("DataMerge_PrimaryKeyMismatch", null);

	internal static string DataMerge_PrimaryKeyColumnsMismatch => GetResourceString("DataMerge_PrimaryKeyColumnsMismatch", null);

	internal static string DataMerge_ReltionKeyColumnsMismatch => GetResourceString("DataMerge_ReltionKeyColumnsMismatch", null);

	internal static string DataMerge_MissingColumnDefinition => GetResourceString("DataMerge_MissingColumnDefinition", null);

	internal static string DataIndex_RecordStateRange => GetResourceString("DataIndex_RecordStateRange", null);

	internal static string DataIndex_FindWithoutSortOrder => GetResourceString("DataIndex_FindWithoutSortOrder", null);

	internal static string DataIndex_KeyLength => GetResourceString("DataIndex_KeyLength", null);

	internal static string DataStorage_AggregateException => GetResourceString("DataStorage_AggregateException", null);

	internal static string DataStorage_InvalidStorageType => GetResourceString("DataStorage_InvalidStorageType", null);

	internal static string DataStorage_ProblematicChars => GetResourceString("DataStorage_ProblematicChars", null);

	internal static string DataStorage_SetInvalidDataType => GetResourceString("DataStorage_SetInvalidDataType", null);

	internal static string DataStorage_IComparableNotDefined => GetResourceString("DataStorage_IComparableNotDefined", null);

	internal static string DataView_SetFailed => GetResourceString("DataView_SetFailed", null);

	internal static string DataView_SetDataSetFailed => GetResourceString("DataView_SetDataSetFailed", null);

	internal static string DataView_SetRowStateFilter => GetResourceString("DataView_SetRowStateFilter", null);

	internal static string DataView_SetTable => GetResourceString("DataView_SetTable", null);

	internal static string DataView_CanNotSetDataSet => GetResourceString("DataView_CanNotSetDataSet", null);

	internal static string DataView_CanNotUseDataViewManager => GetResourceString("DataView_CanNotUseDataViewManager", null);

	internal static string DataView_CanNotSetTable => GetResourceString("DataView_CanNotSetTable", null);

	internal static string DataView_CanNotUse => GetResourceString("DataView_CanNotUse", null);

	internal static string DataView_CanNotBindTable => GetResourceString("DataView_CanNotBindTable", null);

	internal static string DataView_SetIListObject => GetResourceString("DataView_SetIListObject", null);

	internal static string DataView_AddNewNotAllowNull => GetResourceString("DataView_AddNewNotAllowNull", null);

	internal static string DataView_NotOpen => GetResourceString("DataView_NotOpen", null);

	internal static string DataView_CreateChildView => GetResourceString("DataView_CreateChildView", null);

	internal static string DataView_CanNotDelete => GetResourceString("DataView_CanNotDelete", null);

	internal static string DataView_CanNotEdit => GetResourceString("DataView_CanNotEdit", null);

	internal static string DataView_GetElementIndex => GetResourceString("DataView_GetElementIndex", null);

	internal static string DataView_AddExternalObject => GetResourceString("DataView_AddExternalObject", null);

	internal static string DataView_CanNotClear => GetResourceString("DataView_CanNotClear", null);

	internal static string DataView_InsertExternalObject => GetResourceString("DataView_InsertExternalObject", null);

	internal static string DataView_RemoveExternalObject => GetResourceString("DataView_RemoveExternalObject", null);

	internal static string DataROWView_PropertyNotFound => GetResourceString("DataROWView_PropertyNotFound", null);

	internal static string Range_Argument => GetResourceString("Range_Argument", null);

	internal static string Range_NullRange => GetResourceString("Range_NullRange", null);

	internal static string RecordManager_MinimumCapacity => GetResourceString("RecordManager_MinimumCapacity", null);

	internal static string SqlConvert_ConvertFailed => GetResourceString("SqlConvert_ConvertFailed", null);

	internal static string DataSet_DefaultDataException => GetResourceString("DataSet_DefaultDataException", null);

	internal static string DataSet_DefaultConstraintException => GetResourceString("DataSet_DefaultConstraintException", null);

	internal static string DataSet_DefaultDeletedRowInaccessibleException => GetResourceString("DataSet_DefaultDeletedRowInaccessibleException", null);

	internal static string DataSet_DefaultDuplicateNameException => GetResourceString("DataSet_DefaultDuplicateNameException", null);

	internal static string DataSet_DefaultInRowChangingEventException => GetResourceString("DataSet_DefaultInRowChangingEventException", null);

	internal static string DataSet_DefaultInvalidConstraintException => GetResourceString("DataSet_DefaultInvalidConstraintException", null);

	internal static string DataSet_DefaultMissingPrimaryKeyException => GetResourceString("DataSet_DefaultMissingPrimaryKeyException", null);

	internal static string DataSet_DefaultNoNullAllowedException => GetResourceString("DataSet_DefaultNoNullAllowedException", null);

	internal static string DataSet_DefaultReadOnlyException => GetResourceString("DataSet_DefaultReadOnlyException", null);

	internal static string DataSet_DefaultRowNotInTableException => GetResourceString("DataSet_DefaultRowNotInTableException", null);

	internal static string DataSet_DefaultVersionNotFoundException => GetResourceString("DataSet_DefaultVersionNotFoundException", null);

	internal static string Load_ReadOnlyDataModified => GetResourceString("Load_ReadOnlyDataModified", null);

	internal static string DataTableReader_InvalidDataTableReader => GetResourceString("DataTableReader_InvalidDataTableReader", null);

	internal static string DataTableReader_SchemaInvalidDataTableReader => GetResourceString("DataTableReader_SchemaInvalidDataTableReader", null);

	internal static string DataTableReader_CannotCreateDataReaderOnEmptyDataSet => GetResourceString("DataTableReader_CannotCreateDataReaderOnEmptyDataSet", null);

	internal static string DataTableReader_DataTableReaderArgumentIsEmpty => GetResourceString("DataTableReader_DataTableReaderArgumentIsEmpty", null);

	internal static string DataTableReader_ArgumentContainsNullValue => GetResourceString("DataTableReader_ArgumentContainsNullValue", null);

	internal static string DataTableReader_InvalidRowInDataTableReader => GetResourceString("DataTableReader_InvalidRowInDataTableReader", null);

	internal static string DataTableReader_DataTableCleared => GetResourceString("DataTableReader_DataTableCleared", null);

	internal static string RbTree_InvalidState => GetResourceString("RbTree_InvalidState", null);

	internal static string RbTree_EnumerationBroken => GetResourceString("RbTree_EnumerationBroken", null);

	internal static string NamedSimpleType_InvalidDuplicateNamedSimpleTypeDelaration => GetResourceString("NamedSimpleType_InvalidDuplicateNamedSimpleTypeDelaration", null);

	internal static string DataDom_Foliation => GetResourceString("DataDom_Foliation", null);

	internal static string DataDom_TableNameChange => GetResourceString("DataDom_TableNameChange", null);

	internal static string DataDom_TableNamespaceChange => GetResourceString("DataDom_TableNamespaceChange", null);

	internal static string DataDom_ColumnNameChange => GetResourceString("DataDom_ColumnNameChange", null);

	internal static string DataDom_ColumnNamespaceChange => GetResourceString("DataDom_ColumnNamespaceChange", null);

	internal static string DataDom_ColumnMappingChange => GetResourceString("DataDom_ColumnMappingChange", null);

	internal static string DataDom_TableColumnsChange => GetResourceString("DataDom_TableColumnsChange", null);

	internal static string DataDom_DataSetTablesChange => GetResourceString("DataDom_DataSetTablesChange", null);

	internal static string DataDom_DataSetNestedRelationsChange => GetResourceString("DataDom_DataSetNestedRelationsChange", null);

	internal static string DataDom_DataSetNull => GetResourceString("DataDom_DataSetNull", null);

	internal static string DataDom_DataSetNameChange => GetResourceString("DataDom_DataSetNameChange", null);

	internal static string DataDom_CloneNode => GetResourceString("DataDom_CloneNode", null);

	internal static string DataDom_MultipleLoad => GetResourceString("DataDom_MultipleLoad", null);

	internal static string DataDom_MultipleDataSet => GetResourceString("DataDom_MultipleDataSet", null);

	internal static string DataDom_NotSupport_GetElementById => GetResourceString("DataDom_NotSupport_GetElementById", null);

	internal static string DataDom_NotSupport_EntRef => GetResourceString("DataDom_NotSupport_EntRef", null);

	internal static string DataDom_NotSupport_Clear => GetResourceString("DataDom_NotSupport_Clear", null);

	internal static string ADP_EmptyArray => GetResourceString("ADP_EmptyArray", null);

	internal static string SQL_WrongType => GetResourceString("SQL_WrongType", null);

	internal static string ADP_InvalidConnectionOptionValue => GetResourceString("ADP_InvalidConnectionOptionValue", null);

	internal static string ADP_KeywordNotSupported => GetResourceString("ADP_KeywordNotSupported", null);

	internal static string ADP_InternalProviderError => GetResourceString("ADP_InternalProviderError", null);

	internal static string ADP_NoQuoteChange => GetResourceString("ADP_NoQuoteChange", null);

	internal static string ADP_MissingSourceCommand => GetResourceString("ADP_MissingSourceCommand", null);

	internal static string ADP_MissingSourceCommandConnection => GetResourceString("ADP_MissingSourceCommandConnection", null);

	internal static string ADP_InvalidMultipartName => GetResourceString("ADP_InvalidMultipartName", null);

	internal static string ADP_InvalidMultipartNameQuoteUsage => GetResourceString("ADP_InvalidMultipartNameQuoteUsage", null);

	internal static string ADP_InvalidMultipartNameToManyParts => GetResourceString("ADP_InvalidMultipartNameToManyParts", null);

	internal static string ADP_ColumnSchemaExpression => GetResourceString("ADP_ColumnSchemaExpression", null);

	internal static string ADP_ColumnSchemaMismatch => GetResourceString("ADP_ColumnSchemaMismatch", null);

	internal static string ADP_ColumnSchemaMissing1 => GetResourceString("ADP_ColumnSchemaMissing1", null);

	internal static string ADP_ColumnSchemaMissing2 => GetResourceString("ADP_ColumnSchemaMissing2", null);

	internal static string ADP_InvalidSourceColumn => GetResourceString("ADP_InvalidSourceColumn", null);

	internal static string ADP_MissingColumnMapping => GetResourceString("ADP_MissingColumnMapping", null);

	internal static string ADP_NotSupportedEnumerationValue => GetResourceString("ADP_NotSupportedEnumerationValue", null);

	internal static string ADP_MissingTableSchema => GetResourceString("ADP_MissingTableSchema", null);

	internal static string ADP_InvalidSourceTable => GetResourceString("ADP_InvalidSourceTable", null);

	internal static string ADP_MissingTableMapping => GetResourceString("ADP_MissingTableMapping", null);

	internal static string ADP_ConnectionRequired_Insert => GetResourceString("ADP_ConnectionRequired_Insert", null);

	internal static string ADP_ConnectionRequired_Update => GetResourceString("ADP_ConnectionRequired_Update", null);

	internal static string ADP_ConnectionRequired_Delete => GetResourceString("ADP_ConnectionRequired_Delete", null);

	internal static string ADP_ConnectionRequired_Batch => GetResourceString("ADP_ConnectionRequired_Batch", null);

	internal static string ADP_ConnectionRequired_Clone => GetResourceString("ADP_ConnectionRequired_Clone", null);

	internal static string ADP_OpenConnectionRequired_Insert => GetResourceString("ADP_OpenConnectionRequired_Insert", null);

	internal static string ADP_OpenConnectionRequired_Update => GetResourceString("ADP_OpenConnectionRequired_Update", null);

	internal static string ADP_OpenConnectionRequired_Delete => GetResourceString("ADP_OpenConnectionRequired_Delete", null);

	internal static string ADP_OpenConnectionRequired_Clone => GetResourceString("ADP_OpenConnectionRequired_Clone", null);

	internal static string ADP_MissingSelectCommand => GetResourceString("ADP_MissingSelectCommand", null);

	internal static string ADP_UnwantedStatementType => GetResourceString("ADP_UnwantedStatementType", null);

	internal static string ADP_FillSchemaRequiresSourceTableName => GetResourceString("ADP_FillSchemaRequiresSourceTableName", null);

	internal static string ADP_FillRequiresSourceTableName => GetResourceString("ADP_FillRequiresSourceTableName", null);

	internal static string ADP_FillChapterAutoIncrement => GetResourceString("ADP_FillChapterAutoIncrement", null);

	internal static string ADP_MissingDataReaderFieldType => GetResourceString("ADP_MissingDataReaderFieldType", null);

	internal static string ADP_OnlyOneTableForStartRecordOrMaxRecords => GetResourceString("ADP_OnlyOneTableForStartRecordOrMaxRecords", null);

	internal static string ADP_UpdateRequiresSourceTable => GetResourceString("ADP_UpdateRequiresSourceTable", null);

	internal static string ADP_UpdateRequiresSourceTableName => GetResourceString("ADP_UpdateRequiresSourceTableName", null);

	internal static string ADP_UpdateRequiresCommandClone => GetResourceString("ADP_UpdateRequiresCommandClone", null);

	internal static string ADP_UpdateRequiresCommandSelect => GetResourceString("ADP_UpdateRequiresCommandSelect", null);

	internal static string ADP_UpdateRequiresCommandInsert => GetResourceString("ADP_UpdateRequiresCommandInsert", null);

	internal static string ADP_UpdateRequiresCommandUpdate => GetResourceString("ADP_UpdateRequiresCommandUpdate", null);

	internal static string ADP_UpdateRequiresCommandDelete => GetResourceString("ADP_UpdateRequiresCommandDelete", null);

	internal static string ADP_UpdateMismatchRowTable => GetResourceString("ADP_UpdateMismatchRowTable", null);

	internal static string ADP_RowUpdatedErrors => GetResourceString("ADP_RowUpdatedErrors", null);

	internal static string ADP_RowUpdatingErrors => GetResourceString("ADP_RowUpdatingErrors", null);

	internal static string ADP_ResultsNotAllowedDuringBatch => GetResourceString("ADP_ResultsNotAllowedDuringBatch", null);

	internal static string ADP_UpdateConcurrencyViolation_Update => GetResourceString("ADP_UpdateConcurrencyViolation_Update", null);

	internal static string ADP_UpdateConcurrencyViolation_Delete => GetResourceString("ADP_UpdateConcurrencyViolation_Delete", null);

	internal static string ADP_UpdateConcurrencyViolation_Batch => GetResourceString("ADP_UpdateConcurrencyViolation_Batch", null);

	internal static string ADP_InvalidSourceBufferIndex => GetResourceString("ADP_InvalidSourceBufferIndex", null);

	internal static string ADP_InvalidDestinationBufferIndex => GetResourceString("ADP_InvalidDestinationBufferIndex", null);

	internal static string ADP_StreamClosed => GetResourceString("ADP_StreamClosed", null);

	internal static string ADP_InvalidSeekOrigin => GetResourceString("ADP_InvalidSeekOrigin", null);

	internal static string ADP_DynamicSQLJoinUnsupported => GetResourceString("ADP_DynamicSQLJoinUnsupported", null);

	internal static string ADP_DynamicSQLNoTableInfo => GetResourceString("ADP_DynamicSQLNoTableInfo", null);

	internal static string ADP_DynamicSQLNoKeyInfoDelete => GetResourceString("ADP_DynamicSQLNoKeyInfoDelete", null);

	internal static string ADP_DynamicSQLNoKeyInfoUpdate => GetResourceString("ADP_DynamicSQLNoKeyInfoUpdate", null);

	internal static string ADP_DynamicSQLNoKeyInfoRowVersionDelete => GetResourceString("ADP_DynamicSQLNoKeyInfoRowVersionDelete", null);

	internal static string ADP_DynamicSQLNoKeyInfoRowVersionUpdate => GetResourceString("ADP_DynamicSQLNoKeyInfoRowVersionUpdate", null);

	internal static string ADP_DynamicSQLNestedQuote => GetResourceString("ADP_DynamicSQLNestedQuote", null);

	internal static string SQL_InvalidBufferSizeOrIndex => GetResourceString("SQL_InvalidBufferSizeOrIndex", null);

	internal static string SQL_InvalidDataLength => GetResourceString("SQL_InvalidDataLength", null);

	internal static string SqlMisc_NullString => GetResourceString("SqlMisc_NullString", null);

	internal static string SqlMisc_MessageString => GetResourceString("SqlMisc_MessageString", null);

	internal static string SqlMisc_ArithOverflowMessage => GetResourceString("SqlMisc_ArithOverflowMessage", null);

	internal static string SqlMisc_DivideByZeroMessage => GetResourceString("SqlMisc_DivideByZeroMessage", null);

	internal static string SqlMisc_NullValueMessage => GetResourceString("SqlMisc_NullValueMessage", null);

	internal static string SqlMisc_TruncationMessage => GetResourceString("SqlMisc_TruncationMessage", null);

	internal static string SqlMisc_DateTimeOverflowMessage => GetResourceString("SqlMisc_DateTimeOverflowMessage", null);

	internal static string SqlMisc_ConcatDiffCollationMessage => GetResourceString("SqlMisc_ConcatDiffCollationMessage", null);

	internal static string SqlMisc_CompareDiffCollationMessage => GetResourceString("SqlMisc_CompareDiffCollationMessage", null);

	internal static string SqlMisc_InvalidFlagMessage => GetResourceString("SqlMisc_InvalidFlagMessage", null);

	internal static string SqlMisc_NumeToDecOverflowMessage => GetResourceString("SqlMisc_NumeToDecOverflowMessage", null);

	internal static string SqlMisc_ConversionOverflowMessage => GetResourceString("SqlMisc_ConversionOverflowMessage", null);

	internal static string SqlMisc_InvalidDateTimeMessage => GetResourceString("SqlMisc_InvalidDateTimeMessage", null);

	internal static string SqlMisc_TimeZoneSpecifiedMessage => GetResourceString("SqlMisc_TimeZoneSpecifiedMessage", null);

	internal static string SqlMisc_InvalidArraySizeMessage => GetResourceString("SqlMisc_InvalidArraySizeMessage", null);

	internal static string SqlMisc_InvalidPrecScaleMessage => GetResourceString("SqlMisc_InvalidPrecScaleMessage", null);

	internal static string SqlMisc_FormatMessage => GetResourceString("SqlMisc_FormatMessage", null);

	internal static string SqlMisc_SqlTypeMessage => GetResourceString("SqlMisc_SqlTypeMessage", null);

	internal static string SqlMisc_NoBufferMessage => GetResourceString("SqlMisc_NoBufferMessage", null);

	internal static string SqlMisc_BufferInsufficientMessage => GetResourceString("SqlMisc_BufferInsufficientMessage", null);

	internal static string SqlMisc_WriteNonZeroOffsetOnNullMessage => GetResourceString("SqlMisc_WriteNonZeroOffsetOnNullMessage", null);

	internal static string SqlMisc_WriteOffsetLargerThanLenMessage => GetResourceString("SqlMisc_WriteOffsetLargerThanLenMessage", null);

	internal static string SqlMisc_NotFilledMessage => GetResourceString("SqlMisc_NotFilledMessage", null);

	internal static string SqlMisc_AlreadyFilledMessage => GetResourceString("SqlMisc_AlreadyFilledMessage", null);

	internal static string SqlMisc_ClosedXmlReaderMessage => GetResourceString("SqlMisc_ClosedXmlReaderMessage", null);

	internal static string SqlMisc_InvalidOpStreamClosed => GetResourceString("SqlMisc_InvalidOpStreamClosed", null);

	internal static string SqlMisc_InvalidOpStreamNonWritable => GetResourceString("SqlMisc_InvalidOpStreamNonWritable", null);

	internal static string SqlMisc_InvalidOpStreamNonReadable => GetResourceString("SqlMisc_InvalidOpStreamNonReadable", null);

	internal static string SqlMisc_InvalidOpStreamNonSeekable => GetResourceString("SqlMisc_InvalidOpStreamNonSeekable", null);

	internal static string ADP_DBConcurrencyExceptionMessage => GetResourceString("ADP_DBConcurrencyExceptionMessage", null);

	internal static string ADP_InvalidMaxRecords => GetResourceString("ADP_InvalidMaxRecords", null);

	internal static string ADP_CollectionIndexInt32 => GetResourceString("ADP_CollectionIndexInt32", null);

	internal static string ADP_MissingTableMappingDestination => GetResourceString("ADP_MissingTableMappingDestination", null);

	internal static string ADP_InvalidStartRecord => GetResourceString("ADP_InvalidStartRecord", null);

	internal static string DataDom_EnforceConstraintsShouldBeOff => GetResourceString("DataDom_EnforceConstraintsShouldBeOff", null);

	internal static string DataColumns_RemoveExpression => GetResourceString("DataColumns_RemoveExpression", null);

	internal static string DataRow_RowInsertTwice => GetResourceString("DataRow_RowInsertTwice", null);

	internal static string Xml_ElementTypeNotFound => GetResourceString("Xml_ElementTypeNotFound", null);

	internal static Type ResourceType => typeof(FxResources.System.Data.Common.SR);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string GetResourceString(string resourceKey, string defaultString)
	{
		string text = null;
		try
		{
			text = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		if (defaultString != null && resourceKey.Equals(text, StringComparison.Ordinal))
		{
			return defaultString;
		}
		return text;
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}
}
