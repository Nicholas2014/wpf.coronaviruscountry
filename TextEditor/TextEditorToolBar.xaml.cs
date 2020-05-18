using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// TextEditorToolBar.xaml 的交互逻辑
    /// </summary>
    public partial class TextEditorToolBar : UserControl
    {
        public TextEditorToolBar()
        {
            InitializeComponent();
        }

        public bool IsSynchronizing { get; private set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (double i = 8; i < 48; i += 2)
            {
                fontSize.Items.Add(i);
            }
        }

        public void SynchronizeWith(TextSelection selection)
        {
            IsSynchronizing = true;

            Synchronize<double>(selection, TextBlock.FontSizeProperty, SetFontSize);
            Synchronize<FontWeight>(selection, TextBlock.FontWeightProperty, SetFontWeight);
            Synchronize<FontStyle>(selection, TextBlock.FontStyleProperty, SetFontStyle);
            Synchronize<TextDecorationCollection>(selection, TextBlock.TextDecorationsProperty, SetTextDecoration);
            Synchronize<FontFamily>(selection, TextBlock.FontFamilyProperty, SetFontFamily);


            IsSynchronizing = false;
        }

        private void Synchronize<T>(TextSelection selection, DependencyProperty property, Action<T> methodToCall)
        {
            var prop = selection.GetPropertyValue(property);
            if (prop != DependencyProperty.UnsetValue)
            {
                methodToCall((T)prop);
            }
        }

        private void SetFontSize(double size)
        {
            fontSize.SelectedValue = (double)size;
        }

        private void SetFontWeight(FontWeight fontWeight)
        {
            boldButton.IsChecked = (fontWeight == FontWeights.Bold);
        }

        private void SetFontStyle(FontStyle fontStyle)
        {
            italicButton.IsChecked = (fontStyle == FontStyles.Italic);
        }

        private void SetTextDecoration(TextDecorationCollection textDecorations)
        {
            underlineButton.IsChecked = (textDecorations== TextDecorations.Underline);
        }

        private void SetFontFamily(FontFamily fontFamily)
        {
            fonts.SelectedItem = fontFamily;
        }
    }
}
