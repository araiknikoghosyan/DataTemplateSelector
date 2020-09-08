using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;
// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419
namespace Tas2TemplateSelector
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Class1[] RootObject { get; set; }
        public ObservableCollection<Class1> RootsCollection { get; set; } = new ObservableCollection<Class1>();
        public MainPage()
        {
            this.InitializeComponent();
           // this.DataContext = roots;
            string FilePath = Path.Combine(Package.Current.InstalledLocation.Path, "Class1.json");
            using (StreamReader file = File.OpenText(FilePath))
            {
                var json = file.ReadToEnd();
                RootObject = JsonConvert.DeserializeObject<Class1[]>(json);
                foreach (var item in RootObject)
                { 
                    foreach (var a in item.details)
                    {
                        if (a.detail_type == "Pattern")
                        {
                            RootsCollection.Add(new Icon
                            {
                                icon_url = a.icon_url
                            });
                        }
                    }
                    foreach (var i in item.details)
                    {
                        if (i.detail_type == "Color")
                        {
                            RootsCollection.Add(new Color
                            {
                                fill_color = i.fill_color
                            });
                        }
                        else if (i.detail_type == "Gradient")
                        {
                            RootsCollection.Add(new Gradient_Props
                            {
                                gradient_stop_1 = i.gradient_props.gradient_stop_1,
                                gradient_stop_2 = i.gradient_props.gradient_stop_2
                            });
                        }
                    }
                }
                itemGridView.ItemsSource = RootsCollection;
            }
        }
        public void dataListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (ColorItem.IsSelected) { itemGridView.ItemsSource = roots; }
            //if (IconItem.IsSelected) { itemGridView.ItemsSource = roots; }
            //if (GradientItem.IsSelected) { itemGridView.ItemsSource = roots; }
        }
    }
}
