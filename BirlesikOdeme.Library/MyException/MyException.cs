using System;
using static BirlesikOdeme.Library.Constant;

namespace BirlesikOdeme.Library.MyException
{
    public class MyException : Exception
    {
        public MyException(int errorCode, Exception ex, string[] args = null): base()
        {
            string message = GetErrorMessage(errorCode, args);
            throw new ArgumentException(message, errorCode.ToString(), ex);
        }

        public string GetErrorMessage(int errorCode, string[] args = null)
        {
            if (errorCode == ErrorCodes.ISLEM_BASARILI)
                return "İşlem başarılı";
            else if (errorCode == ErrorCodes.ISLEM_HATALI)
                return "İşlem Hatalı";
            else
                return "Bilinmeyen hata";
        }
    }
}