namespace System.Data.Common;

internal class DataRowDbColumn : DbColumn
{
	private DataColumnCollection _schemaColumns;

	private DataRow _schemaRow;

	public DataRowDbColumn(DataRow readerSchemaRow, DataColumnCollection readerSchemaColumns)
	{
		_schemaRow = readerSchemaRow;
		_schemaColumns = readerSchemaColumns;
		populateFields();
	}

	private void populateFields()
	{
		base.AllowDBNull = GetDbColumnValue<bool?>(SchemaTableColumn.AllowDBNull);
		base.BaseCatalogName = GetDbColumnValue<string>(SchemaTableOptionalColumn.BaseCatalogName);
		base.BaseColumnName = GetDbColumnValue<string>(SchemaTableColumn.BaseColumnName);
		base.BaseSchemaName = GetDbColumnValue<string>(SchemaTableColumn.BaseSchemaName);
		base.BaseServerName = GetDbColumnValue<string>(SchemaTableOptionalColumn.BaseServerName);
		base.BaseTableName = GetDbColumnValue<string>(SchemaTableColumn.BaseTableName);
		base.ColumnName = GetDbColumnValue<string>(SchemaTableColumn.ColumnName);
		base.ColumnOrdinal = GetDbColumnValue<int?>(SchemaTableColumn.ColumnOrdinal);
		base.ColumnSize = GetDbColumnValue<int?>(SchemaTableColumn.ColumnSize);
		base.IsAliased = GetDbColumnValue<bool?>(SchemaTableColumn.IsAliased);
		base.IsAutoIncrement = GetDbColumnValue<bool?>(SchemaTableOptionalColumn.IsAutoIncrement);
		base.IsExpression = GetDbColumnValue<bool>(SchemaTableColumn.IsExpression);
		base.IsHidden = GetDbColumnValue<bool?>(SchemaTableOptionalColumn.IsHidden);
		base.IsIdentity = GetDbColumnValue<bool?>("IsIdentity");
		base.IsKey = GetDbColumnValue<bool?>(SchemaTableColumn.IsKey);
		base.IsLong = GetDbColumnValue<bool?>(SchemaTableColumn.IsLong);
		base.IsReadOnly = GetDbColumnValue<bool?>(SchemaTableOptionalColumn.IsReadOnly);
		base.IsUnique = GetDbColumnValue<bool?>(SchemaTableColumn.IsUnique);
		base.NumericPrecision = GetDbColumnValue<int?>(SchemaTableColumn.NumericPrecision);
		base.NumericScale = GetDbColumnValue<int?>(SchemaTableColumn.NumericScale);
		base.UdtAssemblyQualifiedName = GetDbColumnValue<string>("UdtAssemblyQualifiedName");
		base.DataType = GetDbColumnValue<Type>(SchemaTableColumn.DataType);
		base.DataTypeName = GetDbColumnValue<string>("DataTypeName");
	}

	private T GetDbColumnValue<T>(string columnName)
	{
		if (!_schemaColumns.Contains(columnName))
		{
			return default(T);
		}
		object obj = _schemaRow[columnName];
		if (obj is T)
		{
			return (T)obj;
		}
		return default(T);
	}
}
