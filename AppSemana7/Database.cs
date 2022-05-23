using System;
using SQLite;

namespace AppSemana7
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
