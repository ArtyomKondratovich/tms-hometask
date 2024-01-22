using Pair;

var cp1 = new ComparablePair<string, int>("artyo", 19);
var cp2 = new ComparablePair<string, int>("arty", 19);

Console.WriteLine(cp1.CompareTo(cp2));

