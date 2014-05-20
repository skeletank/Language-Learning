namespace MRB.LanguageLearning.Data
{
  public partial class Conjugation
  {
    private static readonly Conjugation _empty = new Conjugation
    {
      Id = -1,
      Name = "All"
    };

    public static Conjugation Empty
    {
      get { return _empty; }
    }
  }
}
