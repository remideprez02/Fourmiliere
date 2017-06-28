using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FourmiliereWpf.ViewModels
{
    public class RelayCommand : ICommand
    {
        #region private fields
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        #endregion

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this._canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Initialise une nouvelle instance de RelayCommand class
        /// </summary>
        /// <param name="execute">Execution de la logique</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de RelayCommand class
        /// </summary>
        /// <param name="execute">Execution de la logique</param>
        /// <param name="canExecute">Statut de l'execution de la logique</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this._canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            this._execute();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }
    }
}
