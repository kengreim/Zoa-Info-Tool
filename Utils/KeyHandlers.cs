using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace ZOAHelper.Utils
{
    public static class KeyHandlers
    {
        public static KeyEventHandler NewOnEnterCommandHandler(IRelayCommand command)
        {
            return new KeyEventHandler((sender, e) =>
            {
                if (e.Key == VirtualKey.Enter)
                {
                    command.Execute(null);
                }
            });
        }
    }
}
