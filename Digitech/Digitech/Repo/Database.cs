using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digitech
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
