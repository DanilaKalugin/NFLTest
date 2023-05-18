using Entities.Tables;

namespace Entities.ViewModels;

public class StadiumViewModel
{
    public short StadiumId { get; set; }
    public string StadiumTitle { get; set; }
    public string StadiumLocation { get; set; }
    public short StadiumBookingSectorWidth { get; set; }
    public short StadiumBookingSectorHeight { get; set; }

    public StadiumViewModel(Stadium stadium)
    {
        StadiumBookingSectorWidth = stadium.StadiumBookingSectorWidth;
        StadiumBookingSectorHeight = stadium.StadiumBookingSectorHeight;
        StadiumTitle = stadium.StadiumTitle;
        StadiumLocation = stadium.StadiumLocation.CityLocation;
        StadiumId = stadium.StadiumId;
    }
}