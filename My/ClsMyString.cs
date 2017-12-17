using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//使用ArrayList所需加入的命名空間

namespace My
{
    public class MyString
    {
        #region "去除特定字元"

        /// <summary>
        /// 去除特定字元
        /// 例如: aa  bc  de
        /// 執行結果: aabcde
        /// toRidSpecChar(textBox1.Text," ")
        /// </summary>
        /// <param name="bufstr">處理字串</param>
        /// <param name="toRidChar">去除字串的字元</param>
        /// <returns></returns>
        public static string toRidSpecChar(string bufstr, string toRidChar)
        {
            string newstr = "";
            int index = bufstr.IndexOf(toRidChar);
            do
            {
                newstr = newstr + bufstr.Substring(0, index);
                bufstr = bufstr.Substring(index+1);
                bufstr = bufstr.Trim();
                index = bufstr.IndexOf(toRidChar);
            } while (index != -1);

            return newstr + bufstr;

        }

        #endregion


        #region "將特定字元分隔之後存入ArrayList"

        /// <summary>
        /// 將特定字元分隔之後存入ArrayList
        /// SplitSpecCharToArrayList((textBox1.Text).ToString()," ")[1].ToString()
        /// </summary>
        /// <param name="bufstr"></param>
        /// <param name="toRidChar"></param>
        /// <returns></returns>
        public static ArrayList SplitSpecCharToArrayList(string bufstr, string toRidChar)
        {
            ArrayList aList = new ArrayList();
            int i = 0;
            int index = bufstr.IndexOf(toRidChar);
            do
            {
                aList.Add(bufstr.Substring(0, index));
                bufstr = bufstr.Substring(index);
                bufstr = bufstr.Trim();
                index = bufstr.IndexOf(toRidChar);
                i++;
            } while (index != -1);

            aList.Add(bufstr);
            return aList;

        }

        #endregion


        #region "將特定字元分隔之後存入Array"

        /// <summary>
        /// 將特定字元分隔之後存入Array
        /// SplitSpecCharToArray(textBox1.Text," ")[0].ToString()
        /// </summary>
        /// <param name="bufstr">處理字串</param>
        /// <param name="toRidChar">去除字串中的字元</param>
        /// <returns></returns>
        public static string[] SplitSpecCharToArray(string bufstr, string toRidChar)
        {
            string[] bufarray = new string[bufstr.Length];
            int i = 0;
            int index = bufstr.IndexOf(toRidChar);
            do
            {
                bufarray[i] = bufstr.Substring(0, index);
                bufstr = bufstr.Substring(index);
                bufstr = bufstr.Trim();
                index = bufstr.IndexOf(toRidChar);
                i = i + 1;
            } while (index != -1);

            bufarray[i + 1] = bufstr;
            return bufarray;

        }

        #endregion


        #region "於數字前面補上空格功能方法"

        /// <summary>
        /// 於數字前面補上空格功能方法
        ///  8
        ///  9
        /// 10
        /// </summary>
        /// <param name="bufNum">傳入數字</param>
        /// <param name="blankspaceNum">所需控制數字總長度</param>
        /// <returns></returns>
        public static string patchBlankSpace(int bufNum, int blankspaceNum)
        {
            int bufNumLength = bufNum.ToString().Length;

            if (bufNumLength >= blankspaceNum)
            {
                return bufNum.ToString();
            }
            else
            {
                string resultString = "";

                for (int i = 0; i < (blankspaceNum - bufNum.ToString().Length); i++)
                {
                    resultString = resultString + " ";
                }

                resultString = resultString + bufNum.ToString();
                return resultString;
            }

        }

        #endregion


        #region "在文字後面補上空格"

        /// <summary>
        /// 在文字後面補上空格
        /// </summary>
        /// <param name="bufString">傳入字串</param>
        /// <param name="blankspaceNum">控制字串長度</param>
        /// <returns></returns>
        public static string patchBlankSpaceForString(string bufString, int blankspaceNum)
        {
            int bufNumLength = bufString.Length;

            if (bufNumLength >= blankspaceNum)
            {
                return bufString;
            }
            else
            {
                string resultString = "";

                for (int i = 0; i < (blankspaceNum - bufString.Length); i++)
                {
                    resultString = resultString + " ";
                }

                resultString = bufString + resultString;
                return resultString;
            }

        }

        #endregion
    }
}
