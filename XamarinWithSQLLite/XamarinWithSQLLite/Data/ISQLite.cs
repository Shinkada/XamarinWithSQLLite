using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinWithSQLLite.Data {
	public interface ISQLite {
		SQLiteConnection GetConnection();
	}
}
