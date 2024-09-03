using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Controls.DialogViewModels
{
    public class TestDialogViewModel : BindableBase, IDialogAware
    {
        //public DelegateCommand<ButtonResult> CloseDialogCommand => new DelegateCommand<ButtonResult>((result) =>
        //{
        //    RequestClose.Invoke();
        //});
        public DelegateCommand CloseDialogCommand => new DelegateCommand(() => { RequestClose.Invoke(); });

        #region Implementation of IDialogAware

        /// <summary>
        /// Evaluates whether the Dialog is in a state that would allow the Dialog to Close
        /// </summary>
        /// <returns><c>true</c> if the Dialog can close</returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// Provides a callback to clean up resources or finalize tasks when the Dialog has been closed
        /// </summary>
        public void OnDialogClosed()
        {
        }

        /// <summary>
        /// Initializes the state of the Dialog with provided DialogParameters
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        /// <summary>
        /// The <see cref="T:Prism.Dialogs.DialogCloseListener" /> will be set by the <see cref="T:Prism.Dialogs.IDialogService" /> and can be called to
        /// invoke the close of the Dialog.
        /// </summary>
        public DialogCloseListener RequestClose { get; }

        #endregion
    }
}