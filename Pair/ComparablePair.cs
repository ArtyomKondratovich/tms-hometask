namespace Pair
{
    public class ComparablePair<T, U>(T first, U second) : IComparable<ComparablePair<T, U>>
        where T : IComparable<T>
        where U : IComparable<U>
    {
        private T _first = first; 
        
        private U _second = second;

        public T First
        {
            get => _first;
            set => _first = value;
        }

        public U Second
        {
            get => _second; 
            set => _second = value;
        }

        public int CompareTo(ComparablePair<T, U>? other)
        {
            if (other == null)
            {
                return 1;
            }

            var compare = _first.CompareTo(other.First);

            if (compare == 0) 
            {
                return _second.CompareTo(other.Second);
            }

            return compare;
        }

    }
}
