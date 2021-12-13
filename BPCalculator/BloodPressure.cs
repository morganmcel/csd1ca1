using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                BPCategory PatientStatus;
               
               if ((Systolic >= 140) || (Diastolic >= 90))
                   PatientStatus = BPCategory.High;
               else if ((Systolic >= 120 && Systolic < 140) || (Diastolic >= 80))
                   PatientStatus = BPCategory.PreHigh;
               else if ((Systolic >= 90 && Systolic < 120) || (Diastolic >= 60))
                   PatientStatus = BPCategory.Ideal;
               else if ((Systolic >= 70 && Systolic < 90) || (Diastolic >= 40))
                   PatientStatus = BPCategory.Low;
               else throw new InvalidOperationException ("Unexpected result");
               return PatientStatus;
            }  
        }
    }
}
