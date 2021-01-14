using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatoPj.Model
{
    public delegate void DataChangedEventHandler(object sender, DataChangedEventArgs e);
    public class DataAccess
    {
        public event DataChangedEventHandler DataChangedEvent = delegate (object sender, DataChangedEventArgs e) { };
        public string Tmp = "";
        public List<string> Get()
        {
            var list = new List<string>();
            list.Add("sato");
            list.Add("honda");
            list.Add("ishikawa");
            list.Add("yoshizawa");
            return list;
        }

        public void GetEvent()
        {
            var tmp = Properties.Settings.Default.DBPath;
            var args = new DataChangedEventArgs(1, "sato");
            DataChangedEvent(this, args);
        }
    }
}
