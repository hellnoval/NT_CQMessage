using System.IO;
using System;
using LitJson;

namespace NT_CQMsg
{
	/// <summary>
	/// JsonReader
	/// </summary>
	/// <typeparam name="T">the class type you want to serialize</typeparam>
	public class JsonReader<T>
        {
                private JsonReader()
                {
                }

                //public static JsonReader<T> GetInstance()
                //{
                //        if (m_instance == null)
                //        {
                //                m_instance = new JsonReader<T>();
                //        }
                //        return m_instance;
                //}

                /// <summary>
                /// load json file to generate a object
                /// </summary>
                /// <returns></returns>
                public static T ReadObjectFormData(string _JsonData)
                {
                        if (_JsonData.Length > 0)
                        {
                                return JsonMapper.ToObject<T>(_JsonData);
                        }
                        else
                                return default(T);
                }

                /// <summary>
                /// save object to json file
                /// </summary>
                /// <param name="path"></param>
                /// <param name="obj"></param>
                public void WriteObjectToFile(string path, T obj)
                {

                        string json = JsonMapper.ToJson(obj);
                        //File.WriteAllText(path, json, Encoding.UTF8);
                        try
                        {
                                FileStream aFile = new FileStream(path, FileMode.Create);

                                StreamWriter sw = new StreamWriter(aFile);
                                sw.Write(json);
                                sw.Dispose();
                                sw.Close();
                                aFile.Dispose();
                                aFile.Close();

                        }
                        catch (IOException ex)
                        {
                                Console.WriteLine("An IOException has been thrown!");
                                Console.WriteLine(ex.ToString());
                                return;
                        }
                }
        }  
}
