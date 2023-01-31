using Kids1135PluginBase;
using System;
using System.Windows.Controls;

namespace Game_MEMO
{
    public class Start : IPlugin
    {
        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public string Author => throw new NotImplementedException();

        public Page GetPage()
        {
            return new MainFrame();
        }
    }
}
