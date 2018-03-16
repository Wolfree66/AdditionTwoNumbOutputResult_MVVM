using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdditionTwoNumbOutputResult_MVVM_v2.Model
{
    public class DelegateCommand<T> : IDelegateCommand
    {
        Action<T> execute;
        Func<object, bool> canExecute;

        // Событие, необходимое для ICommand
        public event EventHandler CanExecuteChanged;

        // Два конструктора
        public DelegateCommand(Action<T> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<T> execute)
        {
            this.execute = execute;
            this.canExecute = this.AlwaysCanExecute;
        }

        // Методы, необходимые для ICommand
        public void Execute(object param)
        {
            execute(((T)param));
        }

        public bool CanExecute(object param)
        {
            return canExecute(((T)param));  
        }

        // Метод, необходимый для IDelegateCommand
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        // Метод CanExecute по умолчанию
        private bool AlwaysCanExecute(object param)
        {
            return true;
        }
    }
}

