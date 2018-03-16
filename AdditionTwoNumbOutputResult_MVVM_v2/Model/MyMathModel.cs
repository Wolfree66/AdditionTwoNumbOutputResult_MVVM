

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdditionTwoNumbOutputResult_MVVM_v2.Model
{
    public class MyMathModel : BindableBase
    {
        private readonly ObservableCollection<int> _myValues = new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> MyPublicValues;

        public MyMathModel()
        {
            MyPublicValues = new ReadOnlyObservableCollection<int>(_myValues);
        }

        //добавление в коллекцию числа и уведомление об изменении суммы
        public void AddValue(int value)
        {
            _myValues.Add(value);
            RaisePropertyChanged("Sum");
        }
        //проверка на валидность, удаление из коллекции и уведомление об изменении суммы
        public void RemoveValue(int index)
        {
            //проверка на валидность удаления из коллекции - обязанность модели
            if (index >= 0 && index < _myValues.Count) _myValues.RemoveAt(index);
            RaisePropertyChanged("Sum");
        }



        internal void RemoveValue(object value)
        {
            RemoveValue((int)value);
        }

        public int Sum => MyPublicValues.Sum(); //сумма
    }

  
}