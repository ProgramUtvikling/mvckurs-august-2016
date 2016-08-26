namespace ImdbWeb.Model.MovieModels
{
	public class VoteResultModel
	{
		public double AverageVote { get; internal set; }
		public string MovieId { get; internal set; }
		public int VoteCount { get; internal set; }
		public int YourVote { get; internal set; }
	}
}