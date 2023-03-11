using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace Note_Manager.M
{
    public class DbClass
    {
        private readonly MySqlConnection con;


        public DbClass()
        {
            //change this to your own db values
            this.con = new MySqlConnection("datasource=;port=3306 ;username=;password=;database=notesdb;");
        }
        #region SelectSingleWhere
        public string[] SelectSingleWhere(string table, string[] where, string[] value, int length, string neededCols)
        {
            this.con.Open();
            string[] result = new string[length];
            int count = 0;
            string sqlWhereValues = "";
            foreach (var w in where)
            {
                sqlWhereValues += " " + w + " = '" + value[count] + "' AND";
                count++;
            }

            sqlWhereValues = sqlWhereValues.Remove(sqlWhereValues.Length - 3);

            var cmdString = "SELECT " + neededCols + " FROM " + table + " WHERE " + sqlWhereValues;
            var command = new MySqlCommand(cmdString, con);
            var reader = command.ExecuteReader();

            bool succes = false;

            while (reader.Read())
            {
                for (int i = 0; i < length; i++)
                {
                    result[i] = reader.GetString(i);
                }
            }
            this.con.Close();
            return result;
        }
        #endregion
        #region SelectWhere
        public string[,] SelectWhere(string table, string[] where, string[] value, string neededCols, string countingCol)
        {
            string whereString = "";

            for (int i = 0; i < where.GetLength(0); i++)
            {
                whereString += where[i] + "='" + value[i] + "'";

                if (i < where.GetLength(0) - 1)
                {
                    whereString += " AND ";
                }
            }

            this.con.Open();

            var cmdString = "SELECT COUNT(" + countingCol + ") FROM " + table + " WHERE " + whereString;
            var command = new MySqlCommand(cmdString, con);
            var reader = command.ExecuteReader();
            reader.Read();
            int rowAmt = reader.GetInt32(0);

            if (rowAmt == 0)
            {
                rowAmt++;
            }
            this.con.Close();
            this.con.Open();

            cmdString = "SELECT " + neededCols + " FROM " + table + " WHERE " + whereString;
            command = new MySqlCommand(cmdString, con);
            reader = command.ExecuteReader();

            bool succes = false;

            string[,] result = new string[rowAmt, reader.FieldCount];
            int counter = 0;
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        result[counter, i] = reader.GetString(i);
                    }
                }
                counter++;
                succes = true; ;
            }

            if (succes == false)
            {
                for (int i = 0; i < result.GetLength(1); i++)
                {
                    result[0, i] = "";
                }
            }

            this.con.Close();
            return result;
        }
        #endregion
        #region DeleteWhere
        public void DeleteWhere(string table, string where, int value)
        {
            this.con.Open();

            var cmdString = "DELETE FROM " + table + " WHERE " + where + " = " + value; //constructs delete query
            var command = new MySqlCommand(cmdString, con);
            command.ExecuteNonQuery();

            this.con.Close();
        }
        #endregion
        #region Insert
        public void Insert(string table, string[] columns, string[] values)
        {
            this.con.Open();
            string sqlColumns = "";
            foreach (var column in columns) // makes all given columns into a sql usable string
            {
                sqlColumns += "`" + column + "`,";
            }
            sqlColumns = sqlColumns.Remove(sqlColumns.Length - 1);// removes last comma as it isn't needed.

            string sqlValues = "";
            int i = 0;
            foreach (var value in values)
            {
                sqlValues += "'" + value + "',";
                i++;
            }
            sqlValues = sqlValues.Remove(sqlValues.Length - 1);// removes last comma as it isn't needed.
            var cmdString = "INSERT INTO " + table + "(" + sqlColumns + ") VALUES (" + sqlValues + ");";

            var command = new MySqlCommand(cmdString, con);
            command.ExecuteNonQuery();

            this.con.Close();
        }
        #endregion
        #region Update
        public void Update(string table, string[] columns, string[] columnValues, string[] where, string[] whereValues)
        {
            this.con.Open();
            string sqlColumnsWithValues = "";
            int i = 0;
            foreach (var column in columns)
            {
                sqlColumnsWithValues += " `" + column + "` = '" + columnValues[i] + "',";
                i++;
            }
            sqlColumnsWithValues = sqlColumnsWithValues.Remove(sqlColumnsWithValues.Length - 1);// removes last comma as it isn't needed.
            string sqlWhereValues = "";
            int x = 0;
            foreach (var w in where)
            {
                sqlWhereValues += " `" + w + "` = '" + whereValues[x] + "' AND";
                x++;
            }
            sqlWhereValues = sqlWhereValues.Remove(sqlWhereValues.Length - 3);


            var cmdString = "UPDATE " + "`" + table + "`" + " SET " + sqlColumnsWithValues + " WHERE " + sqlWhereValues;

            var command = new MySqlCommand(cmdString, con);
            command.ExecuteNonQuery();
            this.con.Close();
        }
        #endregion
        #region SelectInsertedID
        public int SelectInsertedID()
        {
            this.con.Open();

            var cmdString = "SELECT `ID` FROM note ORDER BY ID DESC LIMIT 1";
            var command = new MySqlCommand(cmdString, con);
            var reader = command.ExecuteReader();
            reader.Read();
            string result = reader.GetString(0);
            this.con.Close();
            return Convert.ToInt32(result);
        }
        #endregion
        #region SelectNotes
        public string[,] SelectNotes()
        {


            this.con.Open();

            var cmdString = "SELECT COUNT(ID) FROM `note` WHERE `text` != ''";
            var command = new MySqlCommand(cmdString, con);
            var reader = command.ExecuteReader();
            reader.Read();
            int rowAmt = reader.GetInt32(0);

            if (rowAmt == 0)
            {
                rowAmt++;
            }
            this.con.Close();
            this.con.Open();

            cmdString = "SELECT * FROM `note` WHERE `text` != '' ORDER BY editDate DESC";
            command = new MySqlCommand(cmdString, con);
            reader = command.ExecuteReader();

            bool succes = false;

            string[,] result = new string[rowAmt, reader.FieldCount];
            int counter = 0;
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        result[counter, i] = reader.GetString(i);
                    }
                }
                counter++;
                succes = true; ;
            }

            if (succes == false)
            {
                for (int i = 0; i < result.GetLength(1); i++)
                {
                    result[0, i] = "";
                }
            }

            this.con.Close();
            return result;
        }
        #endregion
    }
}