using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinDataLocal.CustomControls
{
    public class CustomControlViewCell: ViewCell
    {
        //PARA PERSONALIZAR UNA PROPIEDAD, SE UTILIZAN LO 
        //QUE SE LLAMAN BINDABLE PROPERTY, QUE NO DEJA DE SER
        //UNA PROPIEDAD ENLAZADA A NUESTRO CODIGO
        //EL NOMBRE DE LA PROPIEDAD DEBE TERMINAR CON Property
        //DEBEMOS INDICAR EL TIPO DE PROPIEDAD
        public static readonly BindableProperty
            SelectedItemBackgroundColorProperty =
            BindableProperty.Create("SelectedItemBackgroundColor"
                , typeof(Color), typeof(CustomControlViewCell)
                , Color.White);
        //NECESITAMOS UNA PROPIEDAD EXTENDIDA PARA QUE LA UTILICE
        //EL DISPOSITIVO
        public Color SelectedItemBackgroundColor
        {
            get
            {
                return (Color)GetValue(SelectedItemBackgroundColorProperty);
            }
            set
            {
                SetValue(SelectedItemBackgroundColorProperty, value);
            }
        }
    }
}
