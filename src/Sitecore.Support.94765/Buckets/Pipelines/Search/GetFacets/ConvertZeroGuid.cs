namespace Sitecore.Support.Buckets.Pipelines.Search.GetFacets
{
  using Sitecore.Buckets.Pipelines.Search.GetFacets;
  using Sitecore.Globalization;

  public class ConvertZeroGuid : GetFacetsProcessor
  {
    public string Text { get; }

    public ConvertZeroGuid()
      : this("N/A")
    {
    }

    public ConvertZeroGuid(string text) 
    {
      Text = text;
    }

    public override void Process(GetFacetsArgs args)
    {
      foreach (var facetItems in args.Result)
      {
        foreach (var facetItem in facetItems)
        {
          var localizedName = facetItem.LocalizedName;
          if (localizedName == "00000000000000000000000000000000" || localizedName == "00000000-0000-0000-0000-000000000000" || localizedName == "{00000000-0000-0000-0000-000000000000}")
          {
            facetItem.LocalizedName = Translate.Text(Text);
          }
        }
      }
    }
  }
}