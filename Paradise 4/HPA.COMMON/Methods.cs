using System;
using System.Collections.Generic;

namespace HPA.Common
{
    public class Methods
    {
        public static bool ThumbnailCallback()
        {
            return false;
        }
        
        public static int CountDate(DateTime ValueFrom, DateTime ValueTo)
		{
			int retVal = 1;
			TimeSpan ts = ValueTo - ValueFrom;
			retVal = Convert.ToInt32(ts.TotalDays);
            return retVal;
		}
       
        public static object getParameterValue(string Code)
        {
            try{
                System.Data.DataTable dtValue = UIMessage.DBEngine.execReturnDataTable("sp_GetParameterValue", "@code", Code);
               if (dtValue.Rows.Count > 0)
                   return dtValue.Rows[0][0].ToString();
               else
                   return null;
            }catch(Exception ex){
                throw ex;
            }
        }
        public static string RemoveToneMarks(string inputStr)
        {
            string[,] strArray = new string[14, 17]; 
            string strRet = string.Empty;
            string strTmp = string.Empty;
            Int16 i, j;
            //Int16 i, j;
            string StrNoTone;
            string lowerA, lowerE, lowerO, lowerU, lowerI, lowerD, lowerY;
            string upperA, upperE, upperO, upperU, upperI, upperD, upperY;


            StrNoTone = "aAeEoOuUiIdDyY";
            lowerA = "áàạảãâấầậẩẫăắằặẳẵ";
            upperA = "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ";
            lowerE = "éèẹẻẽêếềệểễeeeeee";
            upperE = "ÉÈẸẺẼÊẾỀỆỂỄEEEEEE";
            lowerO = "óòọỏõôốồộổỗơớờợởỡ";
            upperO = "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ";
            lowerU = "úùụủũưứừựửữuuuuuu";
            upperU = "ÚÙỤỦŨƯỨỪỰỬỮUUUUUU";
            lowerI = "íìịỉĩiiiiiiiiiiii";
            upperI = "ÍÌỊỈĨIIIIIIIIIIII";
            lowerD = "đdddddddddddddddd";
            upperD = "ĐDDDDDDDDDDDDDDDD";
            lowerY = "ýỳỵỷỹyyyyyyyyyyyy";
            upperY = "ÝỲỴỶỸYYYYYYYYYYYY";
            for (i = 0; i < 14; i++)
                strArray[i, 0] = StrNoTone.Substring(i, 1);

            for (j = 1; j < 17; j++)
                for (i = 1; i < 17; i++)
                {
                    strArray[0, i] = lowerA.Substring(i - 1, 1);
                    strArray[1, i] = upperA.Substring(i - 1, 1);
                    strArray[2, i] = lowerE.Substring(i - 1, 1);
                    strArray[3, i] = upperE.Substring(i - 1, 1);
                    strArray[4, i] = lowerO.Substring(i - 1, 1);
                    strArray[5, i] = upperO.Substring(i - 1, 1);
                    strArray[6, i] = lowerU.Substring(i - 1, 1);
                    strArray[7, i] = upperU.Substring(i - 1, 1);
                    strArray[8, i] = lowerI.Substring(i - 1, 1);
                    strArray[9, i] = upperI.Substring(i - 1, 1);
                    strArray[10, i] = lowerD.Substring(i - 1, 1);
                    strArray[11, i] = upperD.Substring(i - 1, 1);
                    strArray[12, i] = lowerY.Substring(i - 1, 1);
                    strArray[13, i] = upperY.Substring(i - 1, 1);
                }


            strRet = inputStr;
            for (j = 0; j < 14; j++)
                for (i = 1; i < 17; i++)
                {
                    strTmp = strRet.Replace(strArray[j, i], strArray[j, 0]);
                    strRet = strTmp;
                }
            return strRet;
        }
      
    }
    
}
