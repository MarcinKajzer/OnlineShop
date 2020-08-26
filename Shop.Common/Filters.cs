using Shop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Common
{
    public class Filters
    {
        public Filters()
        {
            foreach (Color color in Enum.GetValues(typeof(Color)))
                ColorCheckboxes.Add(new ColorCheckbox { Color = color });

            foreach (Size size in Enum.GetValues(typeof(Size)))
                SizeCheckboxes.Add(new SizeCheckbox { Size = size });
        }

        public double MinPrice { get; set; } = 0;
        public double MaxPrice { get; set; } = 1000;

        public bool IsOverpriced { get; set; }

        public string SearchBoxValue { get; set; }

        public Gender? Gender { get; set; }
        public Category? Category { get; set; }
        public SortBy SortBy { get; set; }


        public List<ColorCheckbox> ColorCheckboxes { get; set; } = new List<ColorCheckbox>();
        public List<SizeCheckbox> SizeCheckboxes { get; set; } = new List<SizeCheckbox>();
       

        public List<Color> SelectedColors => ColorCheckboxes.Where(c => c.IsSelected).Select(c => c.Color).ToList();
        public List<Size> SelectedSizes => SizeCheckboxes.Where(s => s.IsSelected).Select(s => s.Size).ToList();

    }
}
