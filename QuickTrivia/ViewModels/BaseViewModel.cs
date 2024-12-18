using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuickTrivia.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        private string? _title;

        public string? Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
