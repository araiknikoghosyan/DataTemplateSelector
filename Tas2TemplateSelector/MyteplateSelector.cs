using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace Tas2TemplateSelector
{
    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ColorTemplate { get; set; }
        public DataTemplate IconTemplate { get; set; }
        public DataTemplate GradientTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is Icon)
                return IconTemplate;
            if (item is Color)
                return ColorTemplate;
            if (item is Gradient_Props)
                return GradientTemplate;
            return base.SelectTemplateCore(item, container);
        }
    }
}
