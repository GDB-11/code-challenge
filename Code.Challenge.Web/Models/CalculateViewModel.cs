using System.ComponentModel.DataAnnotations;

namespace Code.Challenge.Web.Models
{
    public class CalculateViewModel
    {
        [Required(ErrorMessage = "The first input is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The first input must be greater than 0.")]
        public int FirstInput { get; set; }

        [Required(ErrorMessage = "The second input is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The second input must be greater than 0.")]
        public int SecondInput { get; set; }

        [Required(ErrorMessage = "The sample size input is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The sample size must be greater than 0.")]
        public int SampleSize { get; set; }
    }
}
