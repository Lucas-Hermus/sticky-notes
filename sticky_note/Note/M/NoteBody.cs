using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.M
{
    public class NoteBody
    {
        public string Text;
        public int[,] Color;
        public string Mode = "Light";
        public int ID;
        public string ColorName;
        public bool Settings;
        public int fontSize = 10;
        public bool darkMode = false;
        public DateTime Changed;
        DbClass db = new DbClass();
        public int[,,] Colors = new int[,,] 
        {
            { { 249, 184, 0 }, { 254, 241, 177 }, { 0, 0, 0 } },        // orange
            { { 50, 136, 0 }, { 208, 238, 194 }, { 0, 0, 0 } },         // green
            { { 206, 24, 170 }, { 249, 205, 229 }, { 0, 0, 0 } },       // pink
            { { 88, 40, 158 }, { 218,201,253 }, { 0, 0, 0 } },          // purple
            { { 39, 122, 218 }, { 203, 229, 255 }, { 0, 0, 0 } },       // blue
            { { 118, 118, 118 }, { 200, 200, 200 }, { 0, 0, 0 } },      // gray
        };

        public NoteBody()
        {
            Text = "";
            Color = ArraySlicerTwoDim(Colors,0);
            ColorName = "Orange";
            Settings = true;
        }
        #region SaveNote
        public void SaveNote()
        {
            string[] column = {"text","colorStyle","editDate"};
            Changed = DateTime.Now;
            string newText = "";
            int counter = 0;
            foreach (char c in Text)
            {
                if (c.ToString() == "'")
                {
                    newText += c.ToString();
                }
                newText += c.ToString();
                counter++;
            }
            int counter2 = 0;
            string newText2 = "";
            foreach (char k in newText)
            {
                if (k.ToString() == @"\")
                {
                    newText += k.ToString();
                }
                newText2 += k.ToString();
                counter2++;
            }
            string[] columnValues = { newText, ColorName,Changed.ToString("yyyy/M/d HH:mm:ss") };
            string[] where = {"ID"};
            string[] whereValues = {ID.ToString()};
            db.Update("note", column, columnValues, where, whereValues);
        }
        #endregion
        #region DeleteNote
        public void DeleteNote()
        {
            db.DeleteWhere("note", "ID", ID);
        }
        #endregion
        #region CreateNewNote
        public void CreateNewNote(string color)
        {
            string[] columns = {"text","colorStyle","editDate"};
            string[] values = {"",color, DateTime.Now.ToString("yyyy/M/d HH:mm:ss")};
            db.Insert("note",columns,values);
            ID = db.SelectInsertedID();
        }
        #endregion
        #region RecetModifyer
        public void RecetModifyer(string modifyer)
        {
            string[] columns = { "modifyer" };
            string[] columnValues = { "NULL" };
            string[] where = { "modifyer" };
            string[] whereValues = { modifyer };
            db.Update("Note", columns, columnValues, where, whereValues);
        }
        #endregion
        #region SetModifyer
        public void SetModifyer(string modifyer, string modifyerID)
        {
            string[] columns = { "modifyer" };
            string[] columnValues = { modifyer };
            string[] where = { "ID" };
            string[] whereValues = { modifyerID };
            db.Update("Note", columns, columnValues, where, whereValues);
        }
        #endregion
        #region ChangeColor
        public void ChangeColor(int index)
        {
            Color = ArraySlicerTwoDim(Colors, index);
            string[] colors = { "Orange", "Green", "Pink", "Purple", "Blue", "Gray" };
            ColorName = colors[index];
        }
        #endregion
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
                return new int[1,1];
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
    }
}
