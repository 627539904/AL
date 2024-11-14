using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.SysTool.VModels
{
    /// <summary>
    /// 基础内存信息
    /// </summary>
    public abstract class BaseRamVM: BaseVM, INotifyPropertyChanged
    {
        public string Total { get; set; }
        private string _free;
        public string Free
        {
            get { return _free; }
            set { _free = value; OnPropertyChanged(nameof(Free)); }
        }
        private string _used;
        public string Used
        {
            get { return _used; }
            set { _used = value; OnPropertyChanged(nameof(Used)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
