using SatoPj.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatoPj.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region メンバ変数
        DataAccess da;
        private string text = string.Empty;
        private DelegateCommand<object> btnClickCommand;
        private ObservableCollection<DataGridRow> dataGridCollection;
        #endregion

        #region プロパティ
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                RaisePropertyChanged(nameof(Text));     
            }
        }

        /// <summary>
        /// ボタンのコマンド宣言
        /// </summary>
        public DelegateCommand<object> BtnClickCommand
        {
            get
            {
                if (btnClickCommand == null) btnClickCommand = new DelegateCommand<object>(ExecuteBtnClick, CanExecuteBtnClick);
                return btnClickCommand;
            }
            set
            {
                btnClickCommand = value;
            }
        }

        public ObservableCollection<DataGridRow> DataGridCollection
        {
            get
            {
                if (dataGridCollection == null) dataGridCollection = new ObservableCollection<DataGridRow>();
                return dataGridCollection;
            }
            set
            {
                dataGridCollection = value;
                RaisePropertyChanged(nameof(DataGridCollection));
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
            da = new DataAccess();
            // daのDataChangedEventが発行されたときのEventHandlerを登録している
            da.DataChangedEvent += Da_DataChangedEvent;
        }

        #endregion

        #region メソッド
        private void Da_DataChangedEvent(object sender, DataChangedEventArgs e)
        {
            var da = sender as DataAccess;
            var id = e.Id;
            var name = e.Name;
        }

        /// <summary>
        /// ボタンのクリックコマンド
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteBtnClick(object obj)
        {
            List<string> list = da.Get();

            foreach(var name in list)
            {
                var row = new DataGridRow(name);
                DataGridCollection.Add(row);
            }

            da.GetEvent();

        }

        /// <summary>
        /// ボタンの実行判定
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteBtnClick()
        {
            return true;
        }
        #endregion
    }
}
