using Game_MEMO.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_MEMO.ViewModel
{
    public class MainPageVM
    {
        public CustomCommand OpenGame { get; set; }

        public MainPageVM(MainWindowVM mainWindowVM)
        {
            OpenGame = new CustomCommand(() =>
            {
                mainWindowVM.CurrentPage = new GamePage(mainWindowVM);
            });
        }
    }
}
