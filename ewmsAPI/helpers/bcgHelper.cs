using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using ewms.common.models;
using System.Web.Script.Serialization;


namespace ewms.common.Helpers
{
    public class bcgHelper
    {


//        public static bool auto_interfaces_call(string Theinterface="")
//        {
//            //DefDomainsBL defDomainsBL = new DefDomainsBL();
//            bool result = false;

//            try
//            {
//                //no desactivar por el momento

//                if (!string.IsNullOrEmpty(Theinterface))
//                {
//                    //Chequea si el tipo de transaccion no se debe de enviar en automatico

//                    //var domain = defDomainsBL.getDefDomain("API_PROD", "_ENVIO_AUTOMATICO_JDE");

//                    if (domain != null)
//                    {

//                        if (string.IsNullOrEmpty(domain.MPC01)) 
//{
//                            result = defDomainsBL.getOnlineInterfaceMode();
//                        }
//                        else
//                        {


//                            if (domain.MPC01 == "1")
//                            {
//                                result = true;
//                            }
//                            else
//                            {
//                                if (Theinterface.Equals("RECEIVING_PROD") || Theinterface.Equals("RECL_MON_PROD") || Theinterface.Equals("TR_PROD") || Theinterface.Equals("TR_ENV_PROD") || Theinterface.Equals("ADJ_ENV_PROD"))
//                                {
//                                    result = false;
//                                }
//                                else
//                                {
//                                    result = true;
//                                }
//                            }
//                        }
//                    }
//                    else
//                    {
//                        //result = defDomainsBL.getOnlineInterfaceMode();
//                    }
//                }
//                else
//                {
//                    //result = defDomainsBL.getOnlineInterfaceMode();
//                }
//            }
//            catch (Exception ex)
//            {
//                result = false;
//            }

//            return result;
//            //return result = defDomainsBL.getOnlineInterfaceMode();
//        }


        public static double calcJulianDate(System.DateTime date)
        {
            //return date.ToOADate() + 64744;
            var a = calCJDEDate(date);
            return calcJulianDate2(date);
        }

        public static string calCJDEDate(System.DateTime date)
        {
            string result = "1";

            var a = date.Year.ToString().Substring(2, 2);

            var b = date.DayOfYear.ToString().PadLeft(3, '0');

            result += a + b.ToString();

            return result;
        }

        public static double calcJulianDate2(System.DateTime date)
        {
            int Month = date.Month;
            int Day = date.Day;
            int Year = date.Year;

            if (Month < 3)
            {
                Month = Month + 12;
                Year = Year - 1;
            }
            long JulianDay = Day + (153 * Month - 457) / 5 + 365 * Year + (Year / 4) - (Year / 100) + (Year / 400) + 1721119;
            return JulianDay;
        }



        public string serializeObject(object theObject) {
            var json = new JavaScriptSerializer().Serialize(theObject);
            return json;
        }

        public DateTime DateTimeNow()
        {
            return DateTime.UtcNow;
        }

        //Encryt 
        public string encriptarPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) password = "";
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();


            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = provider.ComputeHash(data);
            string md5 = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                md5 += data[i].ToString("x2").ToLower();
            }
            return md5;
        }

        public static string getConnectionString()
        {
            return "Data Source=192.168.15.120;Initial Catalog=eWMS_Company;Persist Security Info=True;User ID=sa;Password=r3d3c0ns@";
        }

        //public static void saveLog(string theText, string theModule)
        //{
        //    eWMSEntities dbEWMSLocal = new eWMSEntities();
        //    LogBL log = new LogBL();

        //    int iResult = 0;

        //    try
        //    {
        //        string iFileName = System.Configuration.ConfigurationManager.AppSettings["LogName"] + DateTime.Now.ToString("yyyyMMdd");
        //        using (StreamWriter wFile = new StreamWriter("c:\\temp\\ewms\\" + iFileName + ".log", true))
        //        {
        //            wFile.WriteLine(DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss ") + theModule + " " + theText);
        //        }
        //        iResult = 1;

        //        log.saveDbLog(theModule, theText, iResult.ToString());

        //    }
        //    catch (Exception ex)
        //    {
        //        try
        //        {
        //            string iFileNameErr = System.Configuration.ConfigurationManager.AppSettings["LogName"] + DateTime.Now.ToString("yyyyMMdd");
        //            using (StreamWriter wFile = new StreamWriter("c:\\temp\\ewms\\" + iFileNameErr + ".log", true))
        //            {
        //                wFile.WriteLine(DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss ") + theModule + " " + ex.Message);
        //            }
        //            iResult = 0;
        //            log.saveDbLog(theModule, theText, iResult.ToString());
        //        }
        //        catch (Exception ex2)
        //        {

        //        }
        //    }
        //}
        

        //public void saveLog(bool success, string thetext, string themodule)
        //{
        //    string Logfile = Common.param.interface_erp_logfile_path;
        //    string path = Logfile;
        //    try
        //    {
        //        string strsuccess = "";
        //        if (success)
        //            strsuccess = " [Success]  ";
        //        else
        //            strsuccess = " [Error]  ";

        //        // Create a file to write to. 
        //        using (TextWriter tw = new StreamWriter(path, true))
        //        {
        //            tw.WriteLine(DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss ") + strsuccess + " " + themodule + " " + thetext);
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}




        public void saveLog_test(bool success, string thetext, string themodule)
        {
            string Logfile = @"C:\Users\Consultor\Desktop\Services\log.txt";
            string path = Logfile;
            try
            {
                string strsuccess = "";
                if (success)
                    strsuccess = " [Success]  ";
                else
                    strsuccess = " [Error]  ";

                // Create a file to write to. 
                using (TextWriter tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss ") + strsuccess + " " + themodule + " " + thetext);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    public class EncryptionService
    {
        private const string Llave = "eWMSDEVSecurity";

        public string Encriptar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) throw new ArgumentException("eWMSic: El texto no puede estar en blanco.");
            return EncryptCbcStr(texto, Llave);
        }

        public string Desencriptar(string textoEncriptado)
        {
            if (string.IsNullOrEmpty(textoEncriptado)) throw new System.ArgumentException("eWMSic: El texto no puede estar en blanco");
            return DecryptCbcStr(textoEncriptado, Llave);
        }

        private static RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var llaveBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            Array.Copy(secretKeyBytes, llaveBytes, Math.Min(llaveBytes.Length, secretKeyBytes.Length));

            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = llaveBytes,
                IV = llaveBytes
            };
        }

        private static byte[] EncryptCbc(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        private static byte[] DecryptCbc(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        private static String EncryptCbcStr(String plainText, String key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(EncryptCbc(plainBytes, GetRijndaelManaged(key)));
        }

        private static String DecryptCbcStr(String encryptedText, String key)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(DecryptCbc(encryptedBytes, GetRijndaelManaged(key)));
        }
    }
}
