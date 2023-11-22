using ARCarols.Scripts.Data.Interface;
using UnityEngine;


namespace ARCarols.Scripts.Data.Base
{
    public abstract class DataControllerBase<T> where T : IData
    {
        protected T Data;
        
        protected abstract string DataKey { get; }

        public void Save()
        {
            string json = JsonUtility.ToJson(Data);
            
            PlayerPrefs.SetString(json, DataKey);
            
            PlayerPrefs.Save();
        }

        public T Load()
        {
            if (PlayerPrefs.HasKey(DataKey))
            {
                return JsonUtility.FromJson<T>(DataKey);
            }
            else
            {
                return CreatDefault();
            }
            

        }

        protected abstract T CreatDefault();

    }
}