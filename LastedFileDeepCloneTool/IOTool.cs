using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace LastedFileDeepCloneTool
{
    public class IOTool
    {
        private const string XmlConfigFile = "config.xml";
        public static bool IsLastedFile(FileInfo fi, DateTime beginDate)
        {
            if (fi.LastWriteTime >= beginDate )
                return true;
            return false;
        }

        public static bool IsLastedFile2(FileInfo fi, DateTime beginDate)
        {
            if (fi.LastWriteTime >= beginDate)
                return true;
            return false;
        }

        public static bool IsSpecifiedSuffix(FileInfo fi, string specifiedSuffix)
        {
            specifiedSuffix = specifiedSuffix.TrimStart('.');
            specifiedSuffix = "." + specifiedSuffix;
            if (fi.Extension.Equals(specifiedSuffix, StringComparison.InvariantCultureIgnoreCase))
            { 
                return true;
            }
            return false;
        }

        public static bool IsSpecifiedFolder(DirectoryInfo di, string specifiedName)
        {
            specifiedName = specifiedName.Trim();

            if (di.Name.Equals(specifiedName, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
        // <summary>
        /// 把对象序列化并返回相应的字节
        /// </summary>
        /// <param name="pObj">需要序列化的对象</param>
        /// <returns>byte[]</returns>
        public static byte[] SerializeObject<T>(T pObj)
        {
            if (pObj==null)
                return null;
            using (var _memory = new System.IO.MemoryStream())
            {
          
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_memory, pObj);
            _memory.Position = 0;
            byte[] read = new byte[_memory.Length];
            _memory.Read(read, 0, read.Length);
            _memory.Close();
                return read;
            }
        }
        /// <summary>
        /// 把字节反序列化成相应的对象
        /// </summary>
        /// <param name="pBytes">字节流</param>
        /// <returns>object</returns>
        public static T DeserializeObject<T>(byte[] pBytes) 
        {
            object _newOjb = null;
            if (pBytes == null)
                return (T)_newOjb;
            using ( var _memory = new System.IO.MemoryStream(pBytes))
            {
                _memory.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                _newOjb = formatter.Deserialize(_memory);
                _memory.Close();
                return (T)_newOjb;
            }
          
        }

        // <summary>
        /// 把对象序xml列化并存到配置文件
        /// </summary>
        /// <param name="pObj">需要序列化的对象</param>
        /// <param name="filename">配置文件名</param>
        /// <returns>byte[]</returns>
        public static void XmlSerializeObject<T>(T pObj,string filename)
        {
            if (pObj == null)
                return ;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (FileStream f = File.Create(filename))
            {
                ser.Serialize(f, pObj);
            }
        }
        /// <summary>
        /// 把配置字节流反序列化成相应的对象
        /// </summary>
        ///<param name="filename">配置文件名</param>
        /// <returns>object</returns>
        public static T XmlDeserializeObject<T>(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (FileStream f = File.OpenRead(filename))
            {
              return  (T)ser.Deserialize(f);
            }
        }
    }
}
