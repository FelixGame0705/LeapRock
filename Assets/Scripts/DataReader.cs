using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts
{
    public class DataReader<T>
    {
        public void saveToJSON(T data, string filename)
        {
            string content = JsonUtility.ToJson(data);
            writeFile(GetPath(filename), content);
        }

        public T loadFromJSON(string filename)
        {
            string content = loadFile(GetPath(filename));
            T temp = JsonUtility.FromJson<T>(content);
            return temp;
        }

        private string GetPath(string filename)
        {
            return Application.persistentDataPath + "/" +filename;
        }
        public void writeFile(string path, string content)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            using(StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(content);
            }
        }

        public string loadFile(string path) { 
            if(File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string contend = reader.ReadToEnd();
                    return contend;
                }
            }
            return null;
        }
    }
}
