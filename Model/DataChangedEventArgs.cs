using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatoPj.Model
{
    public class DataChangedEventArgs : EventArgs
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public DataChangedEventArgs(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}
