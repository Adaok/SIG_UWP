using SIG_UWP.ViewModel;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace SIG_UWP.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class CanvasView : Page
    {
        public CanvasView()
        {
            this.InitializeComponent();
            DataContext = new CanvasViewModel();
        }
    }
}
