using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.core.Encode
{
    public class Encode : IEncode
    {
        //Main Components
        public Guid GetGuid(string code)
        {
            if (code.Length == 11)
            {
                return ElevenCharsReturn(code);
            }else if (code.Length == 22)
                return Base64ToGuid(code);
            throw new Exception("String Code is not Supported");
        }

        public string GetString(Guid code)
        {
            return ElevenCharGuidToString(code);
        }

        public Guid CreateGuid()
        {
            var code = System.Guid.NewGuid();
            return ElevenChars(code);
        }


        //Initialized Components
        public string GuidToBase64(Guid code)
        {
            return Convert.ToBase64String(code.ToByteArray()).Replace("/", "-").Replace("+", "_").Replace("=", "");
        }

        public Guid Base64ToGuid(string code)
        {
            Guid guid = Guid.Empty;
            code = code.Replace("-", "/").Replace("_", "+") + "==";

            try
            {
                guid = new Guid(Convert.FromBase64String(code));
            }
            catch (Exception ex)
            {
                throw new Exception("Bad Base64 conversion to GUID", ex);
            }

            return guid;
        }

        public string GuidToBase64NoReturn(Guid code)
        {
            return Convert.ToBase64String(code.ToByteArray()).Replace("/", "-").Replace("+", "_").Replace("=", "").ToLower().Substring(0, 11);
        }

        public Guid ElevenChars(Guid code)
        {
            var base64 = GuidToBase64(code).ToLower().Substring(0,11);
            base64 = base64 + base64;
            return Base64ToGuid(base64);
        }

        public Guid ElevenCharsReturn(string base64)
        {
            base64 = base64 + base64;
            return Base64ToGuid(base64);
        }

        private string ElevenCharGuidToString(Guid code)
        {
            var fullstr = GuidToBase64(code).Substring(0,11);
            return fullstr;
        }

        public Guid GetCode()
        {
            string cookie;
            try
            {
                if (HttpContext.Current.Request.Cookies["login"] != null)
                {
                    cookie = HttpContext.Current.Request.Cookies["login"].Value;
                }
                else
                {
                    throw new Exception("We found No Cookie");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured." + ex.Message);
            }
            return ElevenCharsReturn(cookie);
        }
    }
}