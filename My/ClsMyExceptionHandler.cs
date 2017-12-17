using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My
{
    public class MyExceptionHandler:ApplicationException 
    {
        private string errorCode;//錯誤代碼
        private string errorMessage;//錯誤訊息
        private string errorType;//錯誤類型
        private string suggestSolution;//建議解決方式
        private string ResultMessage;

        public MyExceptionHandler()
        {
            this.errorMessage = "";
            this.errorCode = "";
            this.errorType="";
            this.suggestSolution = "";
            this.ResultMessage = "";
        }

        public MyExceptionHandler(ErrorType errType)
        {
            switch (errType.mainErrorType)
            {
                case  MainErrorType.LoginError :
                    if (errType.loginError.AccountError )
                    {
                        errorCode = "錯誤代碼:[0x800L001]" + "\r\n";
                        errorMessage = "錯誤訊息:輸入帳號有誤或不存在。" + "\r\n";
                        errorType = "錯誤類型:" + MainErrorType.LoginError.ToString() + "\r\n";
                        suggestSolution = "請找資訊人員確認資料庫是否有該帳號!!";
                        ResultMessage = errorCode + errorMessage + errorType + suggestSolution;
                    }
                    else if (errType.loginError.PasswordError)
                    {
                        errorCode = "錯誤代碼:[0x800L002]" + "\r\n";
                        errorMessage = "錯誤訊息:輸入密碼有誤。" + "\r\n";
                        errorType = "錯誤類型:" + MainErrorType.LoginError.ToString() + "\r\n";
                        suggestSolution = "請找資訊人員確認資料庫中密碼是否被更改或重設密碼!!";
                        ResultMessage = errorCode + errorMessage + errorType + suggestSolution;
                    }
                    else if (errType.loginError.AccountOrPasswordError)
                    {
                        errorCode = "錯誤代碼:[0x800L003]" + "\r\n";
                        errorMessage = "錯誤訊息:輸入帳號或密碼有誤。" + "\r\n";
                        errorType = "錯誤類型:" + MainErrorType.LoginError.ToString() + "\r\n";
                        suggestSolution = "請找資訊人員確認資料庫中帳號與密碼是否正確!!";
                        ResultMessage = errorCode + errorMessage + errorType + suggestSolution;
                    }
                    break;
                case MainErrorType.DatabaseError :
                    if (errType.databaseError.QueryNoData)
                    {
                        errorCode = "錯誤代碼:[0x800D001]" + "\r\n";
                        errorMessage = "錯誤訊息:查詢條件沒有任何符合資料。" + "\r\n";
                        errorType = "錯誤類型:" + MainErrorType.DatabaseError.ToString() + "\r\n";
                        suggestSolution = "請重新確認查詢條件是否正確!!";
                        ResultMessage = errorCode + errorMessage + errorType + suggestSolution;
                    }
                    break;

            }
        }

        public override string Message
        {
            get
            {
                return ResultMessage;
            }
        }

    }

    public enum MainErrorType
    {
        LoginError,
        DatabaseError
    }


    public class ErrorType
    {
        public ErrorType(MainErrorType mainErrType)
        {
            this.mainErrorType = mainErrType;
        }

        public MainErrorType mainErrorType
        { get; set; }

        public LoginError loginError
        {
            get;
            set;
        }

        public DatabaseError databaseError
        {
            get;
            set;
        }
    }



    public class LoginError
    {
         public bool AccountError
        {
            get;
            set;
        }
        public bool PasswordError
        {
            get;
            set;
        }
         public bool AccountOrPasswordError
        {
            get;
            set;
        }
    }


    public class DatabaseError
    {
        public bool PrimaryKeyDuplicates
        {
            get;
            set;
        }
        public bool QueryNoData
        {
            get;
            set;
        }

    }


}
