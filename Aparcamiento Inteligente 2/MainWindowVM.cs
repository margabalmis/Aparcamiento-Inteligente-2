using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2
{
    class MainWindowVM : ObservableObject
    {
        public MainWindowVM()
        {
            openInfo = new RelayCommand(openInfoWindow);
        }
        public RelayCommand openInfo { get; }
        private void openInfoWindow()
        {
            System.Diagnostics.Process.Start(@"ParkingInteligente.chm");
        }

    }
}
