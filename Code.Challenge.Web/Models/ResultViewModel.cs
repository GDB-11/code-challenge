using System.ComponentModel.DataAnnotations;
using X.PagedList;
using Application.Core.DTO.Models;

namespace Code.Challenge.Web.Models
{
    public class ResultViewModel
    {
        [Required(ErrorMessage = "The first input is required.")]
        public int FirstInput { get; set; }

        [Required(ErrorMessage = "The second input is required.")]
        public int SecondInput { get; set; }

        [Required(ErrorMessage = "The sample size input is required.")]
        public int SampleSize { get; set; }

        [Required(ErrorMessage = "The page input is required.")]
        public int? page { get; set; }

        public IPagedList<Result> Results { get; set; }
    }
}
