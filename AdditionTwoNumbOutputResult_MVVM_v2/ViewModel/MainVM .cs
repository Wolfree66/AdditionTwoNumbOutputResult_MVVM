using AdditionTwoNumbOutputResult_MVVM_v2.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AdditionTwoNumbOutputResult_MVVM_v2.ViewModel
{
    public class MainVM : BindableBase
    {
        readonly MyMathModel _model = new MyMathModel();

        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }

        public MainVM()
        {
            //таким нехитрым способом мы пробрасываем изменившиеся свойства модели во View
            _model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };

            AddCommand = new DelegateCommand<string>(str => {
                //проверка на валидность ввода - обязанность VM
                int ival;
                if (int.TryParse(str, out ival)) _model.AddValue(ival);
            });

            RemoveCommand = new DelegateCommand<int?>(i => {

                if (i.HasValue) { Debug.WriteLine(i); _model.RemoveValue(i.Value); } 
            });
        }



        private object selectedItem;
        public object SelectedItem
        {
            get { Debug.WriteLine(selectedItem);return selectedItem; }
            set
            {

                selectedItem = value;

               RemoveCommand.Execute(selectedItem); // уведомление View о том, что изменилась сумма
            }
        }
        public int Sum => _model.Sum;
        public ReadOnlyObservableCollection<int> MyValues => _model.MyPublicValues;
    }
}
