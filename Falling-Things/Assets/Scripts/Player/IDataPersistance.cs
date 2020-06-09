using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public class Data{
    
    };
    public class Data<T> : Data
    {
        public T value;
        public Data(T value)
        {
            this.value = value;
        }
    }  
    public interface IDataPersistance
    {
        Data SaveData();
        void LoadData(Data data);
    }

}
