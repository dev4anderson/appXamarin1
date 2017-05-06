using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XF.LocalDB.Data
{
    public interface IDependencyServiceSQLite
    {
        SQLiteConnection GetConexao();
    }
}
