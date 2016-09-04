namespace Eron.core.DataModel
{
    public class VoteBase:EntityBase
    {
        public long PositiveVote { get; set; }

        public long NegativeVote { get; set; }
    }
}