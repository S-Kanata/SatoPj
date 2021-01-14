using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatoPj.ViewModel
{
    public class DataGridRow : ViewModelBase
    {
        private int id = 0;
        private string text = "";
        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged(nameof(Id));
            }
            
        }

        #region コンストラクタ
        public DataGridRow()
        {

        }

        public DataGridRow(string name)
        {
            Name = name;
        }
        #endregion
    }
}
