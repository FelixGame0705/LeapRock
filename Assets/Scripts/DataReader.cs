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
        public void saveToJSON(Queue<T> dataList, string filename)
        {
            List<T> data = new List<T>();
            while(dataList.Count > 0)
            {
                data.Add(dataList.Dequeue());
            }
            string content = JsonUtility.ToJson(data);
            writeFile(GetPath(filename), content);
        }

        public Queue<T> loadFromJSON(string filename)
        {
            Queue<T> data = new Queue<T>();
            string content = loadFile(GetPath(filename));
            List<T> temp = JsonUtility.FromJson<List<T>>(content);
            foreach (T item in temp)
            {
                data.Enqueue(item);
            }
            return data;
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
