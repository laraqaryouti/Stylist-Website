using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace FinalProject.Models
{
    public enum ConsType
    {
        [Display(Name = "Personal Fashion Advice")] FA,
        [Display(Name = "Wardrobe Assessment")] WA,
        [Display(Name = "Color Analysis")] CA,
        [Display(Name = "Closet Organization")] CO,
        [Display(Name = "Special Event Styling")] SES,
        [Display(Name = "Style Makeover")] SM
    }
    public enum Package
    {
        [Display(Name = "Basic Package")] BP,
        [Display(Name = "Premium Package")] PP,
        [Display(Name = "Deluxe Package")] DP
    }
    public enum Types
    {
        [Display(Name = "In-Person Consultation")] PC,
        [Display(Name = "Virtual Consultation")] VC
    }
    public enum Style
    {
        [Display(Name = "Classic & Timeless")] CT,
        [Display(Name = "Bohemian Chic")] BH,
        [Display(Name = "Comfy & Casual")] CC,
        [Display(Name = "Bold & Trendy")] BT
    }
}
