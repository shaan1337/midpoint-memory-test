using System;

namespace midpoint_memory_test
{
    internal struct Midpoint {
        public readonly IndexEntryKey Key;
        public readonly long ItemIndex;

        public Midpoint(IndexEntryKey key, long itemIndex) {
            Key = key;
            ItemIndex = itemIndex;
        }
    }

    internal struct IndexEntryKey {
        public ulong Stream;
        public long Version;

        public IndexEntryKey(ulong stream, long version) {
            Stream = stream;
            Version = version;
        }

        public bool GreaterThan(IndexEntryKey other) {
            if (Stream == other.Stream) {
                return Version > other.Version;
            }

            return Stream > other.Stream;
        }

        public bool SmallerThan(IndexEntryKey other) {
            if (Stream == other.Stream) {
                return Version < other.Version;
            }

            return Stream < other.Stream;
        }

        public bool GreaterEqualsThan(IndexEntryKey other) {
            if (Stream == other.Stream) {
                return Version >= other.Version;
            }

            return Stream >= other.Stream;
        }

        public bool SmallerEqualsThan(IndexEntryKey other) {
            if (Stream == other.Stream) {
                return Version <= other.Version;
            }

            return Stream <= other.Stream;
        }

        public override string ToString() {
            return string.Format("Stream: {0}, Version: {1}", Stream, Version);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of midpoints to create: ");
            var numMidpointsStr = Console.ReadLine();
            var numMidpoints = Int32.Parse(numMidpointsStr);

            Console.WriteLine($"Creating {numMidpoints} midpoints...");

            Midpoint[] midpoints = new Midpoint[numMidpoints];
            for(var i=0;i<numMidpoints;i++){
                var indexEntryKey = new IndexEntryKey(1L, 1L);
                midpoints[i] = new Midpoint(indexEntryKey, 1L);
            }

            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadLine();
        }
    }
}
