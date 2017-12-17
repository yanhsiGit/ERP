using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            //新增命名空間
using System.Windows.Forms; //使用Application.StartupPath所需引用的命名空間
using System.Collections;   //

namespace My
{
    public class MyFileIO
    {
        #region 取得檔案相關資訊

        /// <summary>
        /// 取得檔案相關資訊
        /// </summary>
        /// <param name="FileName">檔案名稱,包含路徑</param>
        /// <param name="InfoStr">查詢檔案的參數
        /// "Directory"      '取得目錄名稱
        /// "DirectoryName"  '取得完整路徑名稱
        /// "CreationTime"   '取得建立檔案時間
        /// "Exists"         '檢查檔案是否存在
        /// "Extension"      '取得副檔名(如: .DOC)
        /// "FullName"       '取得完整路徑及檔案名稱
        /// "Name"           '取得檔案名稱
        /// "Length"         '取得檔案大小
        /// "LastAccessTime" '上次存取時間
        /// "LastWriteTime"  '上次寫入時間
        /// </param>
        /// <returns>回傳字串值</returns>
        public static string FileInformation(string FileName, string InfoStr)
        {
            FileInfo file1 = new FileInfo(FileName);

            switch (InfoStr)
            {
                case "Directory":   //取得目錄名稱
                    return file1.Directory.ToString();
                case "DirectoryName"://取得完整路徑名稱
                    return file1.DirectoryName;
                case "CreationTime"://取得建立檔案時間
                    return file1.CreationTime.ToString();
                case "Exists"://檢查檔案是否存在
                    return file1.Exists.ToString();
                case "Extension"://取得副檔名(如: .DOC)
                    return file1.Extension;
                case "FullName"://取得完整路徑及檔案名稱
                    return file1.FullName;
                case "Name"://取得檔案名稱
                    return file1.Name;
                case "Length"://取得檔案大小
                    return file1.Length.ToString();
                case "LastAccessTime"://上次存取時間
                    return file1.LastAccessTime.ToString();
                case "LastWriteTime"://上次寫入時間
                    return file1.LastWriteTime.ToString();
                default:
                    return "Error";
            }

        }


        #endregion

        /// <summary>
        /// 判斷檔案是否存在
        /// </summary>
        /// <param name="FilePath">傳入檔案路徑</param>
        /// <returns>檔案存在回傳true,否則回傳false</returns>
        public static bool FileExists(string FilePath)
        {
            FileInfo file1 = new FileInfo(FilePath);

            if (file1.Exists == true)
            {
                return true;//表示檔案已經存在
            }
            else
            {
                return false;
            }
        }

        #region 建立檔案

        /// <summary>
        /// 建立檔案
        /// </summary>
        /// <param name="FileName">檔案名稱</param>
        /// <returns>建立檔案成功回傳True,建立檔案失敗回傳False</returns>
        public static bool FileCreate(string FileName)
        {
            //string filePath = Path.GetTempFileName();//從暫存區隨機產生一個暫存檔

            FileInfo file1 = new FileInfo(FileName);

            if (file1.Exists == false)
            {
                file1.Create();
                return true;
            }
            else
            {
                return false;//表示檔案已經存在
            }

        }

        #endregion


        #region 檔案拷貝

        /// <summary>
        /// 檔案拷貝
        /// </summary>
        /// <param name="SourceFile">複製來源檔案</param>
        /// <param name="TargetFile">複製目的檔案</param>
        /// <returns>複製成功回傳True , 複製失敗回傳False</returns>
        public static bool FileCopy(string SourceFile, string TargetFile)
        {
            FileInfo file1 = new FileInfo(SourceFile);
            try
            {
                file1.CopyTo(TargetFile);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息為:" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// 檔案拷貝
        /// </summary>
        /// <param name="SourceFile">複製來源檔案</param>
        /// <param name="TargetFile">複製目的檔案</param>
        /// <param name="isOverwrite">當目的檔案已經存在檔案，若為True，則執行覆寫動作</param>
        /// <returns>複製成功回傳True , 複製失敗回傳False</returns>
        public static bool FileCopy(string SourceFile, string TargetFile , bool isOverwrite)
        {
            FileInfo file1 = new FileInfo(SourceFile);
            try
            {
                file1.CopyTo(TargetFile,isOverwrite);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息為:" + ex.Message.ToString());
                return false;
            }
        }

        #endregion


        #region 刪除檔案

        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="FileName">輸入要刪除的檔案名稱包含路徑</param>
        /// <returns>刪除成功回傳True , 刪除失敗回傳False</returns>
        public static bool FileDelete(string FileName)
        {
            FileInfo file1 = new FileInfo(FileName);

            if (file1.Exists == true)
            {
                file1.Delete();
                return true;
            }
            else
            {
                return false;//表示檔案不存在,無法進行檔案刪除動作
            }

        }

        #endregion


        #region 更改檔名

        /// <summary>
        /// 更改檔名
        /// </summary>
        /// <param name="OldFileName">舊檔案名稱</param>
        /// <param name="NewFileName">欲更改的新檔案名稱</param>
        /// <returns></returns>
        public static bool FileRename(string OldFileName, string NewFileName)
        {
            FileInfo file1 = new FileInfo(OldFileName);
            FileInfo file2 = new FileInfo(NewFileName);

            try
            {
                if (file2.Exists == true)
                {
                    file2.Delete();
                }
                file1.MoveTo(NewFileName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息為:" + ex.Message.ToString());
                return false;
            }
        }

        #endregion


        #region 傳回搜尋目錄下的所有檔案

        /// <summary>
        /// 傳回搜尋目錄下的所有檔案
        /// 用法:SearchAllFiles(ref Alist, @"D:\WeiDa\src", "vb");
        /// </summary>
        /// <param name="SaveObj">將呼叫處所傳入的ArrayList處理完之後再回傳回去</param>
        /// <param name="SearchPath">搜尋目錄路徑</param>
        /// <param name="SearchKeyword">搜尋檔案名稱關鍵字</param>
        public static bool SearchAllFiles(ref ArrayList SaveObj, string SearchPath, string SearchKeyword)
        {
            DirectoryInfo DI = new DirectoryInfo(SearchPath);
            string[] Strbuf;
            int i;

            if (DI.Exists)
            {
                Strbuf = Directory.GetFileSystemEntries(SearchPath, "*" + SearchKeyword + "*");

                if (Strbuf.Length > 0)
                {
                    for (i = 0; i < Strbuf.Length; i++)
                    {
                        SaveObj.Insert(i, Strbuf[i]);
                    }

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        #endregion


        #region 計算目錄下所有檔案的大小

        /// <summary>
        /// 計算目錄下所有檔案的大小
        /// </summary>
        /// <param name="DirPath">欲計算所有檔案大小的目錄路徑</param>
        /// <returns>回傳資料型態為Double,若回傳值為0則表示執行計算過程中發生錯誤 </returns>
        public static double CountDirAllFilesSize(string DirPath)
        {
            DirectoryInfo DI = new DirectoryInfo(DirPath);
            string[] Strbuf;
            int i;
            double AllFileSize = 0;

            if (DI.Exists)
            {
                Strbuf = Directory.GetFileSystemEntries(DirPath);

                if (Strbuf.Length > 0)
                {
                    for (i = 0; i < Strbuf.Length; i++)
                    {
                        FileInfo file1 = new FileInfo(Strbuf[i]);

                        if (file1.Exists == true)//檔案存在才進行檔案大小計算
                        {
                            AllFileSize += Convert.ToDouble(FileInformation(Strbuf[i], "Length"));
                        }

                    }

                    return AllFileSize;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return 0;
            }


        }

        #endregion


        #region 將Byte轉換成Bit或KB或MB或GB或TB

        /// <summary>
        /// 將Byte轉換成Bit或KB或MB或GB或TB
        /// </summary>
        /// <param name="SpaceSize">空間大小,單位為Byte</param>
        /// <param name="TransferType">轉換類型,其參數Bit,KB,MB,GB,TB</param>
        /// <returns>回傳轉換結果其型態為double</returns>
        public static double ByteToKBMBGBTB(double SpaceSize, string TransferType)
        {
            double result = 0;

            switch (TransferType)
            {
                case "Bit":
                    result = SpaceSize * 8;
                    break;
                case "KB": //Kilo Bytes
                    result = Convert.ToDouble(string.Format("{0:F2}", (SpaceSize / 1024)));
                    break;
                case "MB": //Mega Bytes
                    result = Convert.ToDouble(string.Format("{0:F2}", (SpaceSize / (1048576))));
                    break;
                case "GB": //Giga Bytes
                    result = Convert.ToDouble(string.Format("{0:F2}", (SpaceSize / (1073741824))));
                    break;
                case "TB": //Tera Bytes
                    result = Convert.ToDouble(string.Format("{0:F2}", (SpaceSize / (1099511627776))));
                    break;
                default:
                    break;
            }
            return result;

        }


        #endregion


        #region "判斷目錄是否存在"

        /// <summary>
        /// 判斷目錄是否存在
        /// </summary>
        /// <param name="Dirname">目錄路徑</param>
        /// <returns>若目錄存在則回傳True,若不存在則回傳False</returns>
        /// <remarks></remarks>
        public static bool DirExists(string Dirname)
        {
            DirectoryInfo dir1 = new DirectoryInfo(Dirname);

            if (dir1.Exists == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion

        #region 建立目錄名稱

        /// <summary>
        /// 建立目錄名稱
        /// </summary>
        /// <param name="DirName">目錄名稱,例如:C:\TEMP</param>
        /// <returns>若目錄成功建立則回傳True,若目錄建立失敗則回傳False</returns>
        public static bool DirCreate(string DirName)
        {
            DirectoryInfo dir1 = new DirectoryInfo(DirName);

            if (dir1.Exists == false)
            {
                dir1.Create();
                return true;
            }
            else
            {
                return false;//目錄已經存在
            }

        }

        #endregion



        #region 更改目錄名稱

        /// <summary>
        /// 更改目錄名稱
        /// </summary>
        /// <param name="OldDirName">舊目錄名稱</param>
        /// <param name="NewDirName">新目錄名稱</param>
        /// <returns>若目錄更改名稱成功建立則回傳True,若目錄更改名稱失敗則回傳False</returns>
        public static bool DirRename(string OldDirName, string NewDirName)
        {
            DirectoryInfo dir1 = new DirectoryInfo(OldDirName);
            DirectoryInfo dir2 = new DirectoryInfo(NewDirName);
            try
            {
                if (dir2.Exists)
                {
                    return false;
                }
                else
                {
                    dir1.MoveTo(NewDirName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("目錄更名失敗,其錯誤訊息為:" + ex.Message.ToString());
                return false;
            }

        }

        #endregion



        #region 刪除目錄,並且決定該目錄下檔案是否強制刪除

        /// <summary>
        /// 刪除目錄,並且決定該目錄下檔案是否強制刪除
        /// </summary>
        /// <param name="DirName">目錄路徑</param>
        /// <param name="IsDelInDirFiles">若要強制該目錄下檔案全部刪除則傳入True,否則傳入False</param>
        /// <returns>若目錄刪除成功則回傳True,若目錄刪除失敗則回傳False</returns>
        public static bool DirDelete(string DirName, bool IsDelInDirFiles)
        {
            DirectoryInfo dir1 = new DirectoryInfo(DirName);

            try
            {
                if (dir1.Exists == false)
                {
                    return false;
                }
                else
                {
                    if (IsDelInDirFiles)
                    {
                        string[] bufFilePath = Directory.GetFileSystemEntries(DirName);

                        for (int i = 0; i < bufFilePath.Length; i++)
                        {
                            FileInfo file1 = new FileInfo(bufFilePath[i]);
                            file1.Delete();
                        }
                    }

                    dir1.Delete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("目錄刪除失敗,其錯誤訊息為:" + ex.Message.ToString());
                return false;
            }

        }

        #endregion



        #region 查詢磁碟相關資訊

        /// <summary>
        /// 查詢磁碟相關資訊
        /// 用法：DriveInformation("C:\\", "FileSystem").ToString()
        /// </summary>
        /// <param name="Drive">傳入要查詢的磁碟機,例如:C:\\</param>
        /// <param name="InfoType">查詢參數,包含：
        /// "VolumeLabel"://磁碟標記
        /// "FileSystem"://檔案系統
        /// "TotalFreeSpace"://有效空間總量
        /// "TotalSize"://磁碟機的大小
        /// </param>
        /// <returns></returns>
        public static object DriveInformation(string Drive, string InfoType)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            object result;
            if (allDrives.Length > 0)
            {
                foreach (DriveInfo d in allDrives)
                {

                    if (d.DriveType.ToString() == "Fixed" && d.IsReady == true && d.Name == Drive)
                    {
                        switch (InfoType)
                        {
                            case "VolumeLabel"://磁碟標記
                                result = d.VolumeLabel;
                                break;
                            case "FileSystem"://檔案系統
                                result = d.DriveFormat;
                                break;
                            case "TotalFreeSpace"://有效空間總量
                                result = d.TotalFreeSpace;
                                break;
                            case "TotalSize"://磁碟機的大小
                                result = d.TotalSize;
                                break;
                            default:
                                result = false;
                                break;
                        }
                        return result;
                    }

                }
                result = false;
                return result;

            }
            else
            {
                result = false;
                return result;
            }


        }

        #endregion


        #region "檔案與位元陣列之間轉換"

        /// <summary>
        /// 將傳入的檔案轉換成Byte陣列
        /// </summary>
        /// <param name="FilePath">檔案路徑,例如：C:\Temp\BEAUTY.BMP</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static byte[] FileToByteArray(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    FileStream fs = new FileStream(FilePath, FileMode.Open);
                    long fileSize = fs.Length;
                    Int32 inta = (Int32)fileSize;
                    byte[] fileBuffer = new byte[inta + 1];
                    fs.Read(fileBuffer, 0, inta);
                    fs.Close();
                    return fileBuffer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("檔案轉位元陣列失敗,其錯誤訊息為:" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// 將Byte陣列寫成一個檔案
        /// </summary>
        /// <param name="ByteArray">傳入位元陣列</param>
        /// <param name="FilePath">檔案路徑,例如：C:\Temp\BEAUTY.BMP</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool ByteArrayToFile(byte[] ByteArray, string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    FileDelete(FilePath);
                }
                FileStream fs = new FileStream(FilePath, FileMode.Create);
                fs.Write(ByteArray, 0, ByteArray.Length);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("位元陣列轉檔案失敗,其錯誤訊息為:" + ex.Message.ToString());
                return false;
            }
        }
      

        #endregion

        /// <summary>
        /// 用來判斷檔案是否完整拷貝(資源是否有被占用)
        /// </summary>
        /// <param name="filename">傳入檔案名稱</param>
        /// <returns>若資源有被占用則回傳false，若資源沒有被占用則回傳true</returns>
        public static bool IsFileReady(string filename)
        {
            FileInfo FI = new FileInfo(filename);
            FileStream fs = null;
            try
            {
                fs = FI.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                return true;
            }

            catch (IOException ex)
            {
                string errorMsg = ex.Message;
                return false;
            }

            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 寫事件記錄檔
        /// </summary>
        /// <param name="eventType">事件類型，有[資訊][警告][錯誤][危險]</param>
        /// <param name="action">執行動作(執行方法)</param>
        /// <param name="details">細節說明</param>
        /// <returns></returns>
        public static bool WriteEventLog(string eventType, string action, string details)
        {
            string dirPath = System.Windows.Forms.Application.StartupPath + @"\logs\";
            string filename = dirPath + My.MyMethod.RunID("E") + ".log";

            try
            {
                if (Directory.Exists(dirPath) == false)
                {
                    DirCreate(dirPath);
                }
                using (FileStream fs = new FileStream(filename, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {

                        sw.WriteLine(DateTime.Now.ToString() + " | " + eventType + " | " + action + " | " + details);

                        sw.Flush();
                        sw.Close();
                    }
                    fs.Close();
                }

                return true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }

    }
}
