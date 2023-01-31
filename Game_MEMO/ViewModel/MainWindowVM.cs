using Game_MEMO.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game_MEMO.ViewModel
{
    public class MainWindowVM : BaseVM
    {
        private Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;

            set
            {
                currentPage = value;
                Signal();
            }
        }

        public MainWindowVM()
        {
            CurrentPage = new MainPage(this);
        }
    }
}
