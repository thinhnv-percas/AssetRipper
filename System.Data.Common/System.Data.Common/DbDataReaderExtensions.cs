using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Data.Common;

public static class DbDataReaderExtensions
{
	public static ReadOnlyCollection<DbColumn> GetColumnSchema(this DbDataReader reader)
	{
		IList<DbColumn> list = new List<DbColumn>();
		DataTable schemaTable = reader.GetSchemaTable();
		DataColumnCollection columns = schemaTable.Columns;
		foreach (DataRow row in schemaTable.Rows)
		{
			DbColumn item = new DataRowDbColumn(row, columns);
			list.Add(item);
		}
		return new ReadOnlyCollection<DbColumn>(list);
	}

	public static bool CanGetColumnSchema(this DbDataReader reader)
	{
		return true;
	}
}
