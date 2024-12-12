using Newtonsoft.Json;

namespace ClaroVideoJVSR.Models
{

    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Title_Episode { get; set; }
        public string Title_Uri { get; set; }
        public string Title_Original { get; set; }
        public string Description { get; set; }
        public string Description_Large { get; set; }
        public string Short_Description { get; set; }
        public string Image_Large { get; set; }
        public string Image_Medium { get; set; }
        public string Image_Small { get; set; }
        public string Image_Still { get; set; }
        public string Image_Background { get; set; }
        public string Url_Imagen_T1 { get; set; }
        public string Url_Imagen_T2 { get; set; }
        public string Image_Base_Horizontal { get; set; }
        public string Image_Base_Vertical { get; set; }
        public string Image_Base_Square { get; set; }
        public string Image_Clean_Horizontal { get; set; }
        public string Image_Clean_Vertical { get; set; }
        public string Image_Clean_Square { get; set; }
        public string Image_Sprites { get; set; }
        public string Image_Frames { get; set; }
        public string Image_Trickplay { get; set; }
        public string Image_External { get; set; }
        public string Duration { get; set; }
        public string Date { get; set; }
        public string Year { get; set; }
        public bool Preview { get; set; }
        public string SeasonNumber { get; set; }
        public string EpisodeNumber { get; set; }
        public string FormatTypes { get; set; }
        public bool LiveEnabled { get; set; }
        public string LiveType { get; set; }
        public string Live_Ref { get; set; }
        public string SourceUri { get; set; }
        public string Timeshift { get; set; }
        public int VotesAverage { get; set; }
        public string RatingCode { get; set; }
        public string ProveedorName { get; set; }
        public string ProveedorCode { get; set; }
        public EncoderTechnology EncoderTechnology { get; set; }
        public RecorderTechnology RecorderTechnology { get; set; }
        public bool IsSeries { get; set; }
        public string ChannelNumber { get; set; }
    }
}
