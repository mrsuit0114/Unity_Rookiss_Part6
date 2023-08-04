namespace BlazorAppState.Data
{
    public class CounterState
    {
        //public int Count { get;set; }
        int _count = 0;

        public Action OnStateChanged;

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                Refresh();
            }
        }

        void Refresh()
        {
            OnStateChanged?.Invoke();
        }

    }
}
