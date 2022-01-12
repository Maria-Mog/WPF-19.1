using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_19._1.Models;

namespace WPF_19._1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double number1;
        public double Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }
        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Number2 = Arif.Circum(Number1);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (Number1 >= 0)
                return true;
            else
                return false;
        }
        public ICommand ResetCommand { get; }
        private void OnResetCommandExecute(object p)
        {
            Number2 = Number1 = 0;
        }
        private bool CanResetCommandExecuted(object p)
        {
            return true;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
            ResetCommand = new RelayCommand(OnResetCommandExecute, CanResetCommandExecuted);
        }
    }


}
