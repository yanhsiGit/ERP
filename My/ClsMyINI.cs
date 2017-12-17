using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace My
{
    public class MyINI : IDisposable 
    {
        // INI 檔案格式範例
        //[Section]
        //[Key]=[Value]
        //===============
        //[System]
        //Name = SIS
        //Version = 1.0
        //===============
	        [DllImport("kernel32")]
	        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
	        [DllImport("kernel32")]
	        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
	         
	        private bool bDisposed = false;
	        private static string _FilePath = string.Empty;
	        public string FilePath {
	            get {
	                if (_FilePath == null)
	                    return string.Empty;
	                else
	                    return _FilePath;
	            }
	            set {
	                if (_FilePath != value)
	                    _FilePath = value;
	            }
	        }
	 
	        /// <summary>
	        /// 建構子。
	        /// </summary>
	        /// <param name="path">檔案路徑。</param>      
	        public MyINI(string path) {
	            _FilePath = path;
	        }
	 
	        /// <summary>
	        /// 解構子。
	        /// </summary>
	        ~MyINI() {
	            Dispose(false);
	        }
	 
	        /// <summary>
	        /// 釋放資源
	        /// </summary>
	        public void Dispose() {
	            Dispose(true);
	            GC.SuppressFinalize(this); //要求系統不要呼叫指定物件的完成項。
	        }
	 
 /// <summary>
	        /// 釋放資源
	        /// </summary>        
	        protected virtual void Dispose(bool IsDisposing)
            {
	            if (bDisposed) {
	                return;
	            }
	            if (IsDisposing) {
	            }
	 
	            bDisposed = true;
	        }
	 
	        /// <summary>
	        /// 設定 KeyValue 值。
	        /// </summary>
            /// <param name="IniSection">Section。</param>
            /// <param name="IniKey">Key。</param>
            /// <param name="IniValue">Value。</param>
            public void setKeyValue(string IniSection, string IniKey, string IniValue) 
            {
                WritePrivateProfileString(IniSection, IniKey, IniValue, _FilePath);
	        }
	 
	        /// <summary>
	        /// 取得 Key 相對的 Value 值。
	        /// </summary>
            /// <param name="IniSection">Section。</param>
            /// <param name="IniKey">Key。</param>        
            public string getKeyValue(string IniSection, string IniKey) 
            {
	            StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(IniSection, IniKey, "", temp, 255, _FilePath);
	            return temp.ToString();
	        }
	 
	 
	 
	        /// <summary>
	        /// 取得 Key 相對的 Value 值，若沒有則使用預設值(DefaultValue)。
	        /// </summary>
            /// <param name="IniSection">Section。</param>
            /// <param name="IniKey">Key。</param>
	        /// <param name="DefaultValue">DefaultValue。</param>        
            public static string getKeyValue(string IniSection, string IniKey, string DefaultValue) 
            {
	            StringBuilder sbResult = null;
	            try {
	                sbResult = new StringBuilder(255);
                    GetPrivateProfileString(IniSection, IniKey, "", sbResult, 255, _FilePath);
	                return (sbResult.Length > 0) ? sbResult.ToString() : DefaultValue;
	            }
	            catch {
	                return string.Empty;
	            }
	        }
	    }


    }

