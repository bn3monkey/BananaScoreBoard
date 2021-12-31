using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BananaScoreBoard.Auxiliary
{
    class DelegateCommand : ICommand
    {
        private readonly Action action;
        public DelegateCommand(Action action)
        {
            this.action = action;
        }


        private event EventHandler CanExecuteChanged;
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                this.CanExecuteChanged += CanExecuteChanged;
            }

            remove
            {
                this.CanExecuteChanged = null;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            this.action.Invoke();
        }
    }
}
