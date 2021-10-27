using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using yeokgank.DataScheduler.Extensions;
using yeokgank.DataScheduler.Http;

namespace yeokgank.DataScheduler.Services
{
    public abstract class OpenData
    {
        public enum FileType
        {
            [Description("Success")] Success,
            [Description("Error")] Error
        }
        public int resultCount;
        public int ResultCount()
        {
            return resultCount;
        }
        public abstract bool Execute();
        public abstract bool Add(dynamic data);
        public abstract bool Delete();
        public abstract bool Update();
        public abstract void Read();
        public abstract void ErrorLog();
        public T Request<T>(string url)
        {
            try
            {
                var http = new HttpConnecter(url);
                var content = http.Get<T>();

                if (content == null)
                {
                    throw new Exception("Process Error. [GetTrade]");

                }
                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Process Error. {e.GetFullMessage()} [GetTrade]");
                return default(T);
            }
        }
        public void Log(FileType type, string msg, string name)
        {
            try
            {
                var getDirectory = string.Format("{0}/Log/{1}/{2}", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName
                                                                   , DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/")
                                                                   , type.GetDescription());

                CreateDirectoryIfDoesNotExist(getDirectory);

                using (StreamWriter sw = File.AppendText(getDirectory + name))
                {
                    sw.WriteLine("{0}", msg);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetFullMessage());
            }
        }
        /// <summary>
        /// 10진수 => N진수 (최대 36진수)
        /// </summary>
        /// <param name="fn_x">값</param>
        /// <param name="fn_n">변경할 진수</param>
        public string DectoN(decimal fn_x, int fn_n)
        {
            string fn_p = "";
            string fn_v = "";

            if (fn_x < 0)
            {
                fn_p = "-";
                fn_x = Math.Abs(fn_x);
            }

            string strIndex = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            while (fn_x > 0)
            {
                int fn_s = Convert.ToInt32(fn_x % fn_n);
                fn_v = strIndex.Substring(fn_s, 1) + fn_v;
                fn_x = (fn_x - fn_s) / fn_n;
            }
            return fn_p + fn_v;
        }

        /// <summary>
        /// 유니크키 생성
        /// </summary>
        /// <param name="uniqueKeyLength">유니크키 길이</param>
        public string GetUniqueKey(int uniqueKeyLength)
        {
            char[] chars = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            RNGCryptoServiceProvider Crypt = new RNGCryptoServiceProvider();
            byte[] Data = new byte[uniqueKeyLength];
            Crypt.GetNonZeroBytes(Data);
            StringBuilder Result = new StringBuilder(uniqueKeyLength);
            foreach (byte b in Data)
            {
                Result.Append(chars[b % (chars.Length - 1)]);
            }
            return Result.ToString();
        }
        /// <summary>
        /// 디렉토리 여부 확인
        /// </summary>
        /// <param name="directory">디렉토리명</param>
        public string CreateDirectoryIfDoesNotExist(string directory)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(directory);
                if (folder.Exists == false)
                {
                    folder.Create();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetFullMessage());
            }

            return directory;
        }

    }
}
