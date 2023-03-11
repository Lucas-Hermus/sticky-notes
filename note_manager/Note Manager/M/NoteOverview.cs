using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Manager.M
{
    public class NoteBody
    {
        //public string GlabalVars;
        DbClass db = new DbClass();
        public string[,] notes;
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
           //constructor
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
    }
}
