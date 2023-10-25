using System.ComponentModel.DataAnnotations;

namespace Code.Challenge.Web.Models
{
    public class CalculateViewModel
    {
        [Required(ErrorMessage = "The first input is required.")]
        public int FirstInput { get; set; }

        [Required(ErrorMessage = "The second input is required.")]
        public int SecondInput { get; set; }

        [Required(ErrorMessage = "The sample size input is required.")]
        public int SampleSize { get; set; }
    }
}
