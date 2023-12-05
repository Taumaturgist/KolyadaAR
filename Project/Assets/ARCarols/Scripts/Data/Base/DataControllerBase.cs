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
            
            Debug.Log(json);
            
            PlayerPrefs.SetString(DataKey, json);
            
            PlayerPrefs.Save();
        }

        public T Load()
        {
            Data = PlayerPrefs.HasKey(DataKey) ? JsonUtility.FromJson<T>(PlayerPrefs.GetString(DataKey)) : CreatDefault();
            Debug.Log(Data);
            return Data;
        }

        protected abstract T CreatDefault();

    }
}