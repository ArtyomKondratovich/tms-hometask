namespace Pair
{
    public class Pair<TFirst,TSecond>
    {
        public TFirst? First { get; set; }
        public TSecond? Second { get; set; }

        public Pair(TFirst? first, TSecond? second)
        {
            First = first ?? default;
            Second = second ?? default;
        }

        public override string ToString()
        {
            return $"[{First}, {Second}]";
        }
    }
}
