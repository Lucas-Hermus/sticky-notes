using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Manager.M
{
    class Main
    {
        public bool settings;
        public bool darkMode;
        public int fontSize;
        public DbClass db = new DbClass();
        public Main()
        {
            settings = false;
            darkMode = false;
            fontSize = 10;
        }
        #region ArraySlicerTwoDim
        public int[,] ArraySlicerTwoDim(int[,,] arr, int index)
        {
            try
            {
                int[,] newArr = new int[arr.GetLength(1), arr.GetLength(2)];
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    for (int j = 0; j < arr.GetLength(2); j++)
                    {
                        newArr[i, j] = arr[index, i, j];
                    }
                }
                return newArr;
            }
            catch (Exception)
            {
                return new int[1, 1];
            }

        }
        #endregion
        #region   ArraySlicerOneDim
        public int[] ArraySlicerOneDim(int[,] arr, int index)
        {
            try
            {
                int[] newArr = new int[arr.GetLength(1)];
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    newArr[i] = arr[index, i];
                }
                return newArr;
            }
            catch (Exception)
            {
                return new int[1];
            }

        }
        #endregion
        public bool ToggleSettings()
        {
            if (settings)
            {
                settings = false;
                return false;
            }
            settings = true;
            return true;
        }
        public bool ToggleDarkMode()
        {
            if (darkMode)
            {
                darkMode = false;
                UpdateDbSettings("darkMode", "0");
                return false;
            }
            darkMode = true;
            UpdateDbSettings("darkMode", "1");
            return true;
        }
        public void UpdateDbSettings(string setting, string settingValue)
        {
            string[] columns = { setting };
            string[] columnValues = { settingValue };
            string[] where = { "settingID" };
            string[] whereValues = { "1" };
            db.Update("settings", columns, columnValues, where, whereValues);
        }
    }
}
