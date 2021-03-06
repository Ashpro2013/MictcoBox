﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Mictco_Box
{
    public class ORMForSDF
    {
        #region Public Method
        public static T GetObjectDetails<T>(string Query, string Connection)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                DataTable dt = new DataTable();
                dt = GetDataTable(Query, Connection);
                foreach (DataRow row in dt.Rows)
                {
                    obj = GetItem<T>(row);
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDataTable(string Query, string sConnection)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(sConnection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(Query, con))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task<DataTable> GetDataTableAsync(string Query, string sConnection)
        {
            var value = await Task.Run<DataTable>(() =>
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(sConnection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(Query, con))
                        {
                            da.Fill(dt);
                        }
                    }
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            });
            return value;
        }
        public static dynamic ValueFindMethod(string Query, string Connection)
        {
            try
            {
                dynamic Result = null;
                DataTable dt = new DataTable();
                dt = GetDataTable(Query, Connection);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0] != DBNull.Value)
                    {
                        Result = dr[0];
                    }
                }
                return Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<T> GetListMethod<T>(string Query, string Connection)
        {
            try
            {
                List<T> dsList = new List<T>();
                DataTable dt = new DataTable();
                dt = GetDataTable(Query, Connection);
                dsList = ConvertDataTable<T>(dt);
                return dsList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DatabaseMethod(string Query, string Connection)
        {
            if (Query == string.Empty)
            {
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertToDatabase(List<object> datas, string table, string Connection)
        {
            try
            {
                foreach (object data in datas)
                {
                    InsertToDatabaseObj(data, table, Connection);
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }
        public static bool InsertToDatabaseObj(object data, string table, string Connection)
        {
            try
            {
                List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    try
                    {
                        foreach (var item in data.GetType().GetProperties())
                        {
                            if (item.GetValue(data, null) != null)
                            {
                                if (item.PropertyType.Name == "Nullable`1" && item.GetValue(data, null).ToString() == "0")
                                {
                                    continue;
                                }
                                values.Add(new KeyValuePair<string, string>(item.Name, "@" + item.Name));
                            }
                        }
                        string Query = getInsertCommand(table, values);
                        using (SqlCommand cmd = new SqlCommand(Query, con))
                        {
                            cmd.Parameters.Clear();
                            foreach (var item in data.GetType().GetProperties())
                            {
                                if (item.GetValue(data, null) != null)
                                {
                                    if (item.PropertyType.Name == "Nullable`1" && item.GetValue(data, null).ToString() == "0")
                                    {
                                        continue;
                                    }
                                    if (item.PropertyType.Name == "Byte[]")
                                    {
                                        cmd.Parameters.AddWithValue("@" + item.Name, (byte[])(item.GetValue(data, null)));
                                    }
                                    else if (item.PropertyType.Name == "DateTime")
                                    {
                                        cmd.Parameters.AddWithValue("@" + item.Name, AniHelper.GetDate((DateTime)(item.GetValue(data, null))));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@" + item.Name, item.GetValue(data, null).ToString());
                                    }
                                }
                            }
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool UpdateToDatabase(List<object> datas, string table, string column, string Connection)
        {
            try
            {
                int iValue = -1;
                foreach (object data in datas)
                {
                    foreach (var item in data.GetType().GetProperties())
                    {
                        if (item.Name == column)
                        {
                            iValue = item.GetValue(data, null).ToInt32();
                            break;
                        }
                    }
                    UpdateToDatabaseObj(data, table, column, iValue, Connection);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static bool UpdateToDatabaseObj(object data, string table, string column, int iValue, string Connection)
        {
            try
            {
                List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    try
                    {
                        foreach (var item in data.GetType().GetProperties())
                        {
                            if (item.GetValue(data, null) != null && item.Name != column)
                            {
                                if (item.PropertyType.Name == "Nullable`1" && item.GetValue(data, null).ToString() == "0")
                                {
                                    continue;
                                }
                                values.Add(new KeyValuePair<string, string>(item.Name, "@" + item.Name));
                            }
                        }
                        string Query = getUpdateCommand(table, values, column, "@" + column);
                        using (SqlCommand cmd = new SqlCommand(Query, con))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@" + column, iValue);
                            foreach (var item in data.GetType().GetProperties())
                            {
                                if (item.GetValue(data, null) != null && item.Name != column)
                                {
                                    if (item.PropertyType.Name == "Nullable`1" && item.GetValue(data, null).ToString() == "0")
                                    {
                                        continue;
                                    }
                                    if (item.PropertyType.Name == "Byte[]")
                                    {
                                        cmd.Parameters.AddWithValue("@" + item.Name, (byte[])(item.GetValue(data, null)));
                                    }
                                    else if (item.PropertyType.Name == "DateTime")
                                    {
                                        cmd.Parameters.AddWithValue("@" + item.Name, AniHelper.GetDate((DateTime)(item.GetValue(data, null))));
                                    }
                                    else
                                        cmd.Parameters.AddWithValue("@" + item.Name, item.GetValue(data, null).ToString());
                                }
                            }
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Messages.ErrorMessage(ex.Message);
                        return false;
                        throw;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool UpdateDatabase(List<object> newDatas, List<object> oldDatas, string sTable, string IdColumn, string sConnection)
        {
            List<Common> newList = new List<Common>();
            List<Common> oldList = new List<Common>();
            newList = GetIdList(newDatas, IdColumn);
            oldList = GetIdList(oldDatas, IdColumn);
            try
            {
                foreach (Common item in oldList)
                {
                    bool included = newList.Any(x => x.id == item.id);
                    if (!included)
                    {
                        DeleteFromDatabase(sTable, IdColumn, item.id, sConnection);
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            foreach (Common item in newList)
            {
                bool included = oldList.Any(x => x.id == item.id);
                if (!included)
                {
                    int? sVal = item.id;
                    try
                    {
                        foreach (var obj in newDatas)
                        {
                            foreach (var x in obj.GetType().GetProperties())
                            {
                                if (x.Name == IdColumn)
                                {
                                    int? nVal = x.GetValue(obj, null).ToInt32();
                                    if (nVal == sVal)
                                    {
                                        InsertToDatabaseObj(obj, sTable, sConnection);
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                        throw;
                    }
                }
                else
                {
                    int? sVal = item.id;
                    try
                    {
                        foreach (var obj in newDatas)
                        {
                            foreach (var x in obj.GetType().GetProperties())
                            {
                                if (x.Name == IdColumn)
                                {
                                    int? iVal = x.GetValue(obj, null).ToInt32();
                                    if (iVal == sVal)
                                    {
                                        UpdateToDatabaseObj(obj, sTable, IdColumn, sVal.ToInt32(), sConnection);
                                    }
                                }
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                        throw;
                    }
                }
            }
            return true;
        }

        public static bool DeleteFromDatabase(string table, string column, int iValue, string Connection)
        {
            string Query = "Delete From  " + table + " Where " + column + " = @" + column + "";
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@" + column, iValue);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }
        public static bool DeleteMethod(string Query, string Connection)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public static bool UpdateDatabase(DataTable datas, DataTable oldDatas, string table, string sConnection)
        {
            try
            {
                DeleteOldItem(datas, oldDatas, table, sConnection);
                bool result = false;
                string sValue = string.Empty;
                List<KeyValuePair<dynamic, dynamic>> values = new List<KeyValuePair<dynamic, dynamic>>();
                SqlConnection con = new SqlConnection(sConnection);
                con.Open();
                try
                {
                    foreach (DataRow data in datas.Rows)
                    {
                        bool iIncluded = false;
                        string sColumn = string.Empty;
                        string Query = string.Empty;
                        List<Common> iCommon = new List<Common>();
                        values.Clear();
                        foreach (DataColumn item in data.Table.Columns)
                        {
                            if (item.ColumnName == data.Table.Columns[0].ColumnName)
                            {
                                sColumn = item.ColumnName;
                                sValue = data[item.ColumnName].ToString();
                            }
                            else
                            {
                                values.Add(new KeyValuePair<dynamic, dynamic>(item.ColumnName, data[item.ColumnName].ToString()));
                            }
                            iCommon = GetCommon(table, sColumn, sConnection);
                        }
                        if (sValue != null && sValue != string.Empty)
                        {
                            iIncluded = iCommon.Any(x => x.id == Convert.ToInt32(sValue));
                            if (iIncluded)
                            {
                                Query = getUpdateCommand(table, values, sColumn, sValue);
                            }
                            else
                            {
                                Query = getInsertCommand(table, values);
                            }
                            using (SqlCommand cmd = new SqlCommand(Query, con))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DeleteOldItem(DataTable newDt, DataTable oldDt, string sTable, string sConnection)
        {
            try
            {
                string sColumn = string.Empty;
                foreach (DataRow item in newDt.Rows)
                {
                    sColumn = item.Table.Columns[0].ColumnName;
                }
                List<Common> newList = new List<Common>();
                List<Common> oldList = new List<Common>();
                newList = GetIdList(newDt);
                oldList = GetIdList(oldDt);
                foreach (Common item in oldList)
                {
                    bool included = newList.Any(x => x.id == item.id);
                    if (!included)
                    {
                        DeleteFromDatabase(sTable, sColumn, item.id, sConnection);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Private Method
        private static List<Common> GetIdList(List<object> data, string idColumn)
        {
            try
            {
                List<Common> iCommon = new List<Common>();
                foreach (var obj in data)
                {
                    Common cmn = new Common();
                    foreach (var item in obj.GetType().GetProperties())
                    {
                        if (item.Name == idColumn)
                        {
                            cmn.id = item.GetValue(obj, null).ToInt32();
                            iCommon.Add(cmn);
                            break;
                        }
                    }
                }
                return iCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static List<Common> GetCommon(string sTable, string sColumn, string sConnection)
        {
            try
            {
                List<Common> iCommon = new List<Common>();
                DataTable dt = new DataTable();
                dt = GetDataTable("Select " + sColumn + " From " + sTable, sConnection);
                foreach (DataRow drw in dt.Rows)
                {
                    Common cmn = new Common();
                    cmn.id = Convert.ToInt32(drw[0].ToString());
                    iCommon.Add(cmn);
                }
                return iCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static List<Common> GetIdList(DataTable sTable)
        {
            try
            {
                List<Common> iCommon = new List<Common>();
                DataTable dt = new DataTable();
                dt = sTable;
                foreach (DataRow drw in dt.Rows)
                {
                    Common cmn = new Common();
                    cmn.id = Convert.ToInt32(drw[0].ToString());
                    iCommon.Add(cmn);
                }
                return iCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            try
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);

                    data.Add(item);
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static T GetItem<T>(DataRow dr)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)

                            if (dr[column.ColumnName] != DBNull.Value)
                            {
                                if (pro.PropertyType.Name == "Boolean")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                        pro.SetValue(obj, dr[column.ColumnName].ToString().ToBool(), null);
                                }
                                else if (pro.PropertyType.Name == "Int32")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                    {
                                        pro.SetValue(obj, dr[column.ColumnName].ToInt32(), null);
                                    }
                                }
                                else if (pro.PropertyType.Name == "Decimal")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                        pro.SetValue(obj, dr[column.ColumnName].ToString().ToDecimal(), null);
                                }
                                else if (pro.PropertyType.Name == "Nullable`1")
                                {
                                    if (pro.PropertyType.FullName.Contains("System.Int32"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, dr[column.ColumnName].ToInt32(), null);
                                        }
                                    }
                                    else if (pro.PropertyType.FullName.Contains("System.Boolean"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, dr[column.ColumnName].ToString().ToBool(), null);
                                        }
                                    }
                                    else if (pro.PropertyType.FullName.Contains("System.DateTime"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, Convert.ToDateTime(dr[column.ColumnName].ToString()), null);
                                        }
                                    }
                                    else if (pro.PropertyType.FullName.Contains("System.Decimal"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, dr[column.ColumnName].ToString().ToDecimal(), null);
                                        }
                                    }
                                }
                                else if (pro.PropertyType.Name == "DateTime")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                        pro.SetValue(obj, Convert.ToDateTime(dr[column.ColumnName].ToString()), null);
                                }
                                else
                                {
                                    pro.SetValue(obj, dr[column.ColumnName].ToString(), null);
                                }
                            }
                            else
                            {
                                pro.SetValue(obj, null, null);
                            }
                        else
                            continue;
                    }
                }
                return obj;

            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }
        }
        private static string getInsertCommand(string table, List<KeyValuePair<dynamic, dynamic>> values)
        {
            string query = null;
            query += "INSERT INTO " + table + " ( ";
            foreach (var item in values)
            {
                query += item.Key;
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += ") VALUES ( ";
            foreach (var item in values)
            {
                if (item.Key.GetType().Name == "System.Int") // or any other numerics
                {
                    query += item.Value;
                }
                else
                {
                    query += "'";
                    query += item.Value;
                    query += "'";
                }
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += ")";
            return query;
        }
        private static string getUpdateCommand(string table, List<KeyValuePair<dynamic, dynamic>> values, string column, string sValue)
        {
            string query = null;
            query += "Update  " + table + " Set ";
            foreach (var item in values)
            {
                query += item.Key;
                query += "=";
                if (item.Key.GetType().Name == "System.Int") // or any other numerics
                {
                    query += item.Value;
                }
                else
                {
                    query += "'";
                    query += item.Value;
                    query += "'";
                }
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += " Where " + column + " = '" + sValue + "'";
            return query;
        }
        private static bool isValidDataType(string dataType)
        {
            bool isValid = false;
            switch (dataType)
            {
                case "System.Nullable`1[System.Double]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Decimal]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Int16]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Int32]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Int64]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Boolean]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.DateTime]":
                    isValid = true;
                    break;
                case "System.Boolean":
                    isValid = true;
                    break;
                case "System.Int16":
                    isValid = true;
                    break;
                case "System.Int32":
                    isValid = true;
                    break;
                case "System.Int64":
                    isValid = true;
                    break;
                case "System.String":
                    isValid = true;
                    break;
                case "System.Decimal":
                    isValid = true;
                    break;
                case "System.Double":
                    isValid = true;
                    break;
            }
            return isValid;
        }
        private static string getUpdateCommand(string table, List<KeyValuePair<string, string>> values, string column, dynamic sValue)
        {
            string query = null;
            query += "Update  " + table + " Set ";
            foreach (var item in values)
            {
                query += item.Key;
                query += "=";
                query += item.Value;
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += " Where " + column + " = " + sValue;
            return query;
        }
        private static string getInsertCommand(string table, List<KeyValuePair<string, string>> values)
        {
            string query = null;
            query += "INSERT INTO " + table + " ( ";
            foreach (var item in values)
            {
                query += item.Key;
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += ") VALUES ( ";
            foreach (var item in values)
            {

                query += item.Value;
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += ")";
            return query;
        }
        #endregion

        #region Public Method BySP
        public static bool InsertMethod_SP(List<object> entities, string sStoredProceedure, string Connection)
        {
            try
            {
                foreach (object data in entities)
                {
                    InsertMethod_SP(data, sStoredProceedure, Connection);
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }
        public static bool InsertMethod_SP(object entity, string sStoredProceedure, string Connection)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(Connection))
            {
                using (SqlCommand cmd = new SqlCommand(sStoredProceedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        foreach (var item in entity.GetType().GetProperties())
                        {
                            if (item.GetValue(entity, null) != null)
                            {
                                if (item.PropertyType.Name == "Nullable`1" && item.GetValue(entity, null).ToString() == "0")
                                {
                                    continue;
                                }
                                if (item.PropertyType.Name == "Byte[]")
                                {
                                    cmd.Parameters.AddWithValue(item.Name, (byte[])(item.GetValue(entity, null)));
                                }
                                else if (item.PropertyType.Name == "DateTime")
                                {
                                    cmd.Parameters.AddWithValue("@" + item.Name, AniHelper.GetDate((DateTime)(item.GetValue(entity, null))));
                                }
                                else
                                    cmd.Parameters.AddWithValue(item.Name, item.GetValue(entity, null).ToString());
                            }
                        }
                        con.Open();
                        int numRes = cmd.ExecuteNonQuery();
                        if (numRes > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                        throw;
                    }
                }
            }
            return result;
        }
        public static bool UpdateMethod_SP(object entity, string sStoredProceedure, string Connection)
        {
            bool result = false;
            int numRes = 0;
            using (SqlConnection con = new SqlConnection(Connection))
            {
                using (SqlCommand cmd = new SqlCommand(sStoredProceedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        foreach (var item in entity.GetType().GetProperties())
                        {
                            if (item.GetValue(entity, null) != null)
                            {
                                if (item.PropertyType.Name == "Nullable`1" && item.GetValue(entity, null).ToString() == "0")
                                {
                                    continue;
                                }
                                if (item.PropertyType.Name == "Byte[]")
                                {
                                    cmd.Parameters.AddWithValue(item.Name, (byte[])(item.GetValue(entity, null)));
                                }
                                else if (item.PropertyType.Name == "DateTime")
                                {
                                    cmd.Parameters.AddWithValue("@" + item.Name, AniHelper.GetDate((DateTime)(item.GetValue(entity, null))));
                                }
                                else
                                    cmd.Parameters.AddWithValue(item.Name, item.GetValue(entity, null).ToString());
                            }
                        }
                        con.Open();
                        numRes = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        result = false;
                        throw;
                    }
                }
            }
            if (numRes > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool UpdateMethod_SP(List<object> entities, string sStoredProceedure, string Connection)
        {
            try
            {
                foreach (object data in entities)
                {
                    UpdateMethod_SP(data, sStoredProceedure, Connection);
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }
        public static bool DeleteMethod_SP(object entity, string sStoredProceedure, string Connection)
        {
            bool result = false;
            int numRes = 0;
            using (SqlConnection con = new SqlConnection(Connection))
            {
                using (SqlCommand cmd = new SqlCommand(sStoredProceedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("Id", entity.ToInt32());
                        con.Open();
                        numRes = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        result = false;
                        throw;
                    }
                }
            }
            if (numRes > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static DataTable GetDataTable_SP(string sStoredProceedure, string Connection)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    using (SqlCommand cmd = new SqlCommand(sStoredProceedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDataTableWithIdParameter_SP(string sStoredProceedure, string Value, string Connection)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    using (SqlCommand cmd = new SqlCommand(sStoredProceedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Value);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDataTableWithIdParameter_SP(string sStoredProceedure, object entity, string Connection)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    using (SqlCommand cmd = new SqlCommand(sStoredProceedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in entity.GetType().GetProperties())
                        {
                            if (item.GetValue(entity, null) != null)
                            {
                                cmd.Parameters.AddWithValue(item.Name, item.GetValue(entity, null).ToString());
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<T> GetList_SP<T>(string sStoredProceedure, string Connection)
        {
            try
            {
                List<T> dsList = new List<T>();
                DataTable dt = new DataTable();
                dt = GetDataTable_SP(sStoredProceedure, Connection);
                dsList = ConvertDataTable<T>(dt);
                return dsList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<T> GetList_SP<T>(string sStoredProceedure, string Value, string Connection)
        {
            try
            {
                List<T> dsList = new List<T>();
                DataTable dt = new DataTable();
                dt = GetDataTableWithIdParameter_SP(sStoredProceedure, Value, Connection);
                dsList = ConvertDataTable<T>(dt);
                return dsList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<T> GetList_SP<T>(string sStoredProceedure, object entity, string Connection)
        {
            try
            {
                List<T> dsList = new List<T>();
                DataTable dt = new DataTable();
                dt = GetDataTableWithIdParameter_SP(sStoredProceedure, entity, Connection);
                dsList = ConvertDataTable<T>(dt);
                return dsList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static T GetObject_SP<T>(string sStoredProceedure, string Value, string Connection)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                DataTable dt = new DataTable();
                dt = GetDataTableWithIdParameter_SP(sStoredProceedure, Value, Connection);
                foreach (DataRow row in dt.Rows)
                {
                    obj = GetItem<T>(row);
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static T GetObject_SP<T>(string sStoredProceedure, string Connection)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                DataTable dt = new DataTable();
                dt = GetDataTable_SP(sStoredProceedure, Connection);
                foreach (DataRow row in dt.Rows)
                {
                    obj = GetItem<T>(row);
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
