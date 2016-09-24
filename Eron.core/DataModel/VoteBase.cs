namespace Eron.core.DataModel
{
    public class VoteBase<TKey>:EntityBase<TKey>
    {
        public long PositiveVote { get; set; }

        public long NegativeVote { get; set; }
    }
}