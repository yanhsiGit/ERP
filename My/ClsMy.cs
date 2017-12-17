using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
//My.Application 所需引用命名空間  My.User物件
using Microsoft.VisualBasic.Logging; //My.Application.Log所需引用命名空間
using Microsoft.VisualBasic.Devices;
//My.Computer.Info 物件 My.Computer.Keyboard 物件 My.Computer.Mouse 物件 
//My.Computer.Network 物件 My.Computer.Ports 物件
using Microsoft.VisualBasic.MyServices;
//My.Computer.FileSystem 物件 My.Computer.Registry 物件

///****** C# My Object Implement ********
///Step 1 加入參考[Microsoft.VisualBasic.dll]
///Step 2 實作My命名空間

namespace My
{

    #region "Application"

    //My.Application 物件提供與目前應用程式相關的屬性、方法和事件。
    public class Application
    {
        static Application()
        {
            MyApplication = new WindowsFormsApplicationBase();
        }

        //WindowsFormsApplicationBase可支援所有MyApplication的叫用
        public readonly static WindowsFormsApplicationBase MyApplication;

        //My.Application.Log 物件提供一個屬性 (Property) 和多個方法，
        //用以將事件和例外狀況資訊寫入應用程式的記錄檔接聽程式。
        public static Log Log
        {

            get
            {
                Log Log = new Log();
                return Log;
            }
        }

        //My.Application.Info 物件會提供屬性 (Property)，用於取得應用程式組件
        //的相關資訊，例如版本號碼、描述和載入的組件等等。
        public static AssemblyInfo Info
        {
            get
            {
                AssemblyInfo Info = new
                    AssemblyInfo(System.Reflection.Assembly.GetExecutingAssembly());
                return Info;
            }
        }

    }

    #endregion

    #region "Computer"

    //實作My.Computer
    public class Computer
    {
        static Computer()
        {
            //My.Computer.Info 物件 提供存取電腦記憶體,載入組件與作業系統資訊等
            ComputerInfo = new ComputerInfo();
        }

        public readonly static ComputerInfo ComputerInfo;

        //My.Computer.Audio 物件 提供播放音效的屬性和方法
        public static Audio Audio
        {
            get
            {
                Audio Ado = new Audio();
                return Ado;
            }
        }

        //My.Computer.Clock 物件 提供存取目前的本機時間和國際標準時間
        public static Clock Clock
        {
            get
            {
                Clock clk = new Clock();
                return clk;
            }
        }

        //My.Computer.Info 物件 提供存取電腦記憶體,載入組件與作業系統資訊等
        public static ComputerInfo Info
        {
            get
            {
                ComputerInfo CInfo = new ComputerInfo();
                return CInfo;
            }
        }

        //My.Computer.Keyboard 物件 提供存取鍵盤目前狀態
        public static Keyboard Keyboard
        {
            get
            {
                Keyboard Keyb = new Keyboard();
                return Keyb;
            }
        }

        //My.Computer.Mouse 物件 提供存取本機滑鼠組態資訊
        public static Mouse Mouse
        {
            get
            {
                Mouse Mos = new Mouse();
                return Mos;
            }
        }

        //My.Computer.Network 物件 提供與電腦所連接網路的互動屬性和方法
        public static Network Network
        {
            get
            {
                Network Net = new Network();
                return Net;
            }
        }

        //My.Computer.Ports 物件 將字串傳送至電腦的序列埠。
        public static Ports Ports
        {
            get
            {
                Ports Port = new Ports();
                return Port;
            }
        }

        //My.Computer.Clipboard 物件 提供管理[剪貼簿]的方法
        public static ClipboardProxy Clipboard
        {
            get
            {
                GetReturn MyReturn = new GetReturn();
                return MyReturn.ClipboardProxy;
            }
        }

        //My.Computer.FileSystem 物件 提供對磁碟目錄檔案的存取方法與屬性
        public static FileSystemProxy FileSystem
        {
            get
            {
                GetReturn MyReturn = new GetReturn();
                return MyReturn.FileSystemProxy;
            }
        }

        //My.Computer.Registry 物件 提供屬性 (Property) 和方法來操作登錄。
        public static RegistryProxy Registry
        {
            get
            {
                GetReturn MyReturn = new GetReturn();
                return MyReturn.RegistryProxy;
            }
        }

        //獲取電腦名稱
        public static String Name
        {
            get
            {
                Microsoft.VisualBasic.Devices.Computer ComputerName = new Microsoft.VisualBasic.Devices.Computer();
                return ComputerName.Name;
            }
        }

        //獲取電腦主要顯示畫面
        public static System.Windows.Forms.Screen Screen
        {
            get
            {
                Microsoft.VisualBasic.Devices.Computer ComputerName = new Microsoft.VisualBasic.Devices.Computer();
                return ComputerName.Screen;
            }

        }


    }

    #endregion

    #region "User"

    //實作My.User
    public class User
    {

        private static string UserName;
        private static int IndexPath;
        public static string Name
        {
            get
            {
                Microsoft.VisualBasic.ApplicationServices.User NowUser =
                    new Microsoft.VisualBasic.ApplicationServices.User();

                NowUser.InitializeWithWindowsUser();
                IndexPath = NowUser.Name.IndexOf("\\");
                UserName = NowUser.Name.Substring(IndexPath + 1);
                return UserName;
            }
        }
    }

    //版權宣告
    public class Copyrights
    {
        public static string GetCopyrightInfo
        {
            get
            {
                return "Copyright(c) 2014-2016 by Ching-Jung Hsu. All Rights Reserved.";

            }
        }

        public static string Author
        {
            get
            {
                return "Ching-Jung Hsu(許清榮)";

            }
        }

        public static void SayHello()
        {
            MessageBox.Show("Hello World!!");
        }

    }
        #endregion
}


#region "GetReturn"
class GetReturn
{
    public ClipboardProxy ClipboardProxy
    {
        get
        {
            Microsoft.VisualBasic.Devices.Computer ComputerName = new Microsoft.VisualBasic.Devices.Computer();
            return ComputerName.Clipboard;
        }

    }

    public FileSystemProxy FileSystemProxy
    {
        get
        {
            Microsoft.VisualBasic.Devices.Computer ComputerName = new Microsoft.VisualBasic.Devices.Computer();
            return ComputerName.FileSystem;
        }
    }

    public RegistryProxy RegistryProxy
    {
        get
        {
            Microsoft.VisualBasic.Devices.Computer ComputerName = new Microsoft.VisualBasic.Devices.Computer();
            return ComputerName.Registry;
        }
    }
}
#endregion

