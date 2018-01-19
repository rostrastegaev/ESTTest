namespace ESTTest.Models
{
    public class Counter : BindableBase
    {
        private int _value = 0;

        public int Value => _value;

        public void Next()
        {
            ++_value;
            OnPropertyChanged(nameof(Value));
        }
    }
}
