   using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionEventModels;
using WebApp.Core.Models.OrchidModels;

namespace WebApp.Core.Models.AuctionStateModels
{
    public class AuctionStateModel
    {
        public string Id { get; set; }
        public int Position { get; set; }
        //[Required(ErrorMessage = "Position is required ")]
        [CheckPosition]
        public double? StartingPrice { get; set; }
        //[Required(ErrorMessage = "Starting Price is required ")]
        [CheckStartingPrice]
        public double? ExpectedPrice { get; set; }
        //[Required(ErrorMessage = "Expected Price is required ")]
        [CheckExpectedPrice]
        public double? MinRaise { get; set; }
        //[Required(ErrorMessage = "Min Raise is required ")]
        [CheckMinRaise]

        public double? MaxRaise { get; set; }
        //[Required(ErrorMessage = "Max Raise is required ")]
        [CheckMaxRaise]

        public string AuctionStateStatus { get; set; }
        //[Required(ErrorMessage = "Auction Status is required ")]

        public double? FinalPrice {  get; set; }
        public string? OrchidId { get; set; }
        public OrchidModel? Orchid { get; set; }
        public string? AuctionEventId { get; set; }
        public AuctionEventModel ? AuctionEvent { get; set; }

    }

    public class CheckPositionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = (AuctionStateModel)validationContext.ObjectInstance;
            int position = obj.Position;

            if(position != 1) 
            {
                return new ValidationResult("Position must be equal to 1");
            }
            return ValidationResult.Success;
        }
    }
    public class CheckStartingPriceAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = (AuctionStateModel)validationContext.ObjectInstance;
            double StartingPrice = obj.StartingPrice ?? 0.0;

            if (StartingPrice < 0)
            {
                return new ValidationResult("Start Starting Price must be greater than or equal to 0 ");
            }
            return ValidationResult.Success;
        }
    }
    public class CheckExpectedPriceAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = (AuctionStateModel)validationContext.ObjectInstance;
            double ExpectedPrice = obj.ExpectedPrice ?? 0.0;

            if (ExpectedPrice <= 0)
            {
                return new ValidationResult("ExpectedPrice Price must be greater than or equal to 0 ");
            }
            return ValidationResult.Success;
        }
    }
    public class CheckMinRaiseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = (AuctionStateModel)validationContext.ObjectInstance;
            double MinRaise = obj.MinRaise ?? 0.0;


            if (MinRaise <= 0)
            {
                return new ValidationResult("Min Raise must be greater than 0 ");
            }
            return ValidationResult.Success;
        }
    }
    public class CheckMaxRaiseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = (AuctionStateModel)validationContext.ObjectInstance;
            double MinRaise = obj.MinRaise ?? 0.0;
            double MaxRaise = obj.MaxRaise ?? 0.0;


            if (MaxRaise <= 0)
            {
                return new ValidationResult("Max Raise must be greater than  0 ");
            }
            else if (MaxRaise < MinRaise)
            {
                return new ValidationResult("Max Raise must be greater than Min Raise ");
            }
            return ValidationResult.Success;
        }
    }
}
